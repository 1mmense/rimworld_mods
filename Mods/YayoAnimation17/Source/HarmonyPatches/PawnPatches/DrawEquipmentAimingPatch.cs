// using System.Collections.Generic;
// using System.Reflection.Emit;
// using HarmonyLib;
// using Verse;
//
// namespace YayoAnimation.HarmonyPatches.PawnPatches;
//
// [HarmonyPatch(typeof(PawnRenderUtility), nameof(PawnRenderUtility.DrawEquipmentAiming))]
// public static class DrawEquipmentAimingPatch
// {
//     private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instr)
//     {
//         var matcher = new CodeMatcher(instr);
//
//         matcher.MatchStartForward(
//             CodeMatch.IsLdloc(),
//             CodeMatch.LoadsConstant(360f),
//             new CodeMatch(OpCodes.Rem),
//             CodeMatch.IsStloc()
//         );
//
//         var branchPos = matcher.Pos;
//         matcher.Reset();
//
//         matcher.MatchStartForward(
//             CodeMatch.IsLdarg(),
//             CodeMatch.LoadsConstant(20f),
//             CodeMatch.Branches()
//         );
//
//         matcher.InsertBranch(OpCodes.Jmp, branchPos);
//
//         return matcher.Instructions();
//     }
// }