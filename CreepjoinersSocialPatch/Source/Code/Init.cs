
using HarmonyLib;
using Verse;

namespace Microus.Patches
{
    [StaticConstructorOnStartup]
    internal class Init
    {
        static Init()
        {
            var harmony = new Harmony("microus.creepjoinersromance");
            harmony.PatchAll();
        }
    }
}
