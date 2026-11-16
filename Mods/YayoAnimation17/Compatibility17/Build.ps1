param(
    [string]$GameRoot = 'C:\Program Files (x86)\Steam\steamapps\common\RimWorld',
    [string]$HarmonyDll = 'C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2009463077\1.7\Assemblies\0Harmony.dll',
    [string]$Compiler = 'C:\Program Files\dotnet\sdk\8.0.424\Roslyn\bincore\csc.dll'
)
$ErrorActionPreference = 'Stop'
if (@(Get-CimInstance Win32_Process -Filter "Name = 'RimWorld.exe' OR Name = 'RimWorldWin64.exe'").Count) { throw 'Close RimWorld before rebuilding a potentially loaded assembly.' }
if ((Get-Content -LiteralPath (Join-Path $GameRoot 'Version.txt') -Raw) -notmatch '^1\.7\.') { throw 'This companion targets RimWorld 1.7 only.' }
$out = Join-Path $PSScriptRoot '..\1.7\Assemblies\YayoAnimation17Compatibility.dll'
$refs = @('System.Private.CoreLib.dll','System.Runtime.dll','netstandard.dll','System.Collections.dll','System.Linq.dll','System.Reflection.dll','System.Runtime.Extensions.dll','System.ObjectModel.dll','Assembly-CSharp.dll','UnityStubs.dll') | ForEach-Object { '/reference:'+(Join-Path $GameRoot $_) }
$refs += '/reference:'+$HarmonyDll
& 'C:\Program Files\dotnet\dotnet.exe' $Compiler /nologo /noconfig /nostdlib+ /target:library ('/out:'+$out) @refs (Join-Path $PSScriptRoot 'NewGameReset17.cs')
if ($LASTEXITCODE) { throw "Compiler failed with exit code $LASTEXITCODE" }
Get-FileHash -LiteralPath $out -Algorithm SHA256
