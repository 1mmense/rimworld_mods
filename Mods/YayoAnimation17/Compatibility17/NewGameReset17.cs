using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace YayoAnimation17
{
    // 1.7-only companion. Check each lifecycle hook independently; older packages are unchanged.
    [StaticConstructorOnStartup]
    public static class NewGameReset17
    {
        private const string Owner = "com.yayo.yayoAni.continued.compat17";
        private static readonly MethodInfo OriginalReset = AccessTools.Method("YayoAnimation.Data.PawnDataUtility:Reset");

        static NewGameReset17()
        {
            if (ModLister.AnyModActiveNoSuffix(new[] { "zetrith.prepatcher", "jikulopo.prepatcher" })) return;
            EnsureReset(nameof(GameComponentUtility.StartedNewGame));
            EnsureReset(nameof(GameComponentUtility.LoadedGame));
        }

        private static void EnsureReset(string methodName)
        {
            var target = AccessTools.Method(typeof(GameComponentUtility), methodName);
            var existing = Harmony.GetPatchInfo(target);
            if (existing != null && (existing.Owners.Contains("com.yayo.yayoAni") || existing.Owners.Contains(Owner))) return;
            if (OriginalReset == null) throw new MissingMethodException("Yayo animation data Reset method was not found.");
            new Harmony(Owner).Patch(target, postfix: new HarmonyMethod(typeof(NewGameReset17), nameof(ResetAnimationData)));
            Log.Message("[Yayo's Animation 1.7] " + methodName + " animation-cache reset compatibility patch active.");
        }

        private static void ResetAnimationData() => OriginalReset.Invoke(null, null);
    }
}
