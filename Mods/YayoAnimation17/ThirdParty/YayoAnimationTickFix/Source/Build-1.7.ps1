param(
    [string]$GameRoot = 'C:\Program Files (x86)\Steam\steamapps\common\RimWorld',
    [string]$HarmonyDll = 'C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2009463077\1.7\Assemblies\0Harmony.dll',
    [string]$Compiler = 'C:\Program Files\dotnet\sdk\8.0.424\Roslyn\bincore\csc.dll'
)
$ErrorActionPreference = 'Stop'
$packageRoot = (Resolve-Path -LiteralPath (Join-Path $PSScriptRoot '..\..\..')).Path
$output = Join-Path $packageRoot '1.7\Assemblies\YayoAnimationTickFix.dll'
$references = @('System.Private.CoreLib.dll','System.Runtime.dll','mscorlib.dll','netstandard.dll','System.Collections.dll','System.Reflection.dll','System.Reflection.Primitives.dll','System.Reflection.Emit.dll','System.Reflection.Emit.ILGeneration.dll','Assembly-CSharp.dll') | ForEach-Object { Join-Path $GameRoot $_ }
$references += $HarmonyDll
$references += Join-Path $packageRoot '1.7\Assemblies\yayoAni.dll'
foreach ($path in $references + $Compiler) { if (-not (Test-Path -LiteralPath $path -PathType Leaf)) { throw "Missing build dependency: $path" } }
$compileArgs = @($Compiler,'/noconfig','/nostdlib+','/target:library','/warnaserror+','/deterministic+','/optimize+','/define:YAYO_NATIVE_17',('/out:' + $output))
$compileArgs += $references | ForEach-Object { '/reference:' + $_ }
$compileArgs += Get-ChildItem -LiteralPath $PSScriptRoot -Filter '*.cs' -File | ForEach-Object { $_.FullName }
& 'C:\Program Files\dotnet\dotnet.exe' @compileArgs
if ($LASTEXITCODE) { throw 'Native 1.7 tick/facing fix compilation failed.' }
Get-FileHash -LiteralPath $output -Algorithm SHA256
