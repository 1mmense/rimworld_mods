using HarmonyLib;
using RimWorld;
using Verse;
using YayoAnimation;
using YayoAnimation.Data;

namespace YayoAnimationTickFix
{
    // From ifchen0's 2026-10-20 Workshop update; original MIT LICENSE and NOTICE retained.
    // Invalidate only the indefinitely cached standing-job case. Scheduled animation poses
    // keep their chosen facing; the original CheckAni recomputes the invalidated cache.
    [HarmonyPatch(typeof(AnimationCore), nameof(AnimationCore.CheckAni))]
    public static class Patch_AnimationCore_CheckAni
    {
        public static void Prefix(Pawn pawn, Rot4 rot, PawnDrawData pdd)
        {
            if (pdd.nextUpdateTick == int.MaxValue && pdd.fixedRot.HasValue && pdd.fixedRot.Value != rot
                && pawn.GetPosture() == PawnPosture.Standing)
                pdd.nextUpdateTick = int.MinValue;
        }
    }
}
