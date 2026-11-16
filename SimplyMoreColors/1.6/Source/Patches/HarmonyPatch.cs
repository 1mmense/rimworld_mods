using HarmonyLib;
using Verse;

namespace SimplyMoreColors
{
    [StaticConstructorOnStartup]
    static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            new Harmony("Haecriver.SimplyMoreColors").PatchAll();
        }
    }
}