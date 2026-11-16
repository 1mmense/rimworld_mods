using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace SimplyMoreColors
{
    internal static class Dialog_ChooseColorPatches
    {
        [HarmonyPatch(typeof(Dialog_ChooseColor))]
        [HarmonyPatch("InitialSize", MethodType.Getter)]
        class InitialSizePatch
        {
            // Main
            public static bool Prefix(ref Vector2 __result)
            {
                __result = new Vector2(500f, 600f);
                return false;
            }
        }
    }
}
