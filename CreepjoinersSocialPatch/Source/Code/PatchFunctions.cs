using Verse;

namespace Microus.Patches
{
    public static class PatchFunctions
    {
        public static bool CheckBothHumanLike(Pawn pawn, Pawn otherPawn)
        {
            return pawn.RaceProps.Humanlike && otherPawn.RaceProps.Humanlike;
        }
    }
}
