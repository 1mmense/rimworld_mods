// using HarmonyLib;
// using UnityEngine;
// using Verse;
//
// namespace YayoAnimation.HarmonyPatches;
//
// [HarmonyPatch(typeof(Pawn), nameof(Pawn.GetInspectString))]
// public static class Debug
// {
//     public static int attackType = 0;
//     public static float addZ;
//     public static float addX;
//     public static float ani;
//     public static float ani2;
//     public static float wiggle;
//     public static float drawAngle;
//     public static float addAngle;
//     public static Vector3 before;
//     public static Vector3 after;
//     
//     private static void Postfix(Pawn __instance, ref string __result)
//     {
//         var type = attackType switch
//         {
//             0 => "Ordinary",
//             1 => "Takedown",
//             2 => "Head stab",
//             _ => "???"
//         };
//
//         __result += $"\nAttack type: {type}\naddX: {addX}, addZ: {addZ}, addAngle: {addAngle}\nani1: {ani}, ani2: {ani2}\nwiggle: {wiggle}, draw angle: {drawAngle}\nBefore: {before}\nAfter: {after}";
//     }
// }