using Verse;

namespace SunLampHonesty
{
    public class SunLampHonestyMod : Mod
    {
        public const string PACKAGE_ID = "sunlamphonesty.1trickPwnyta";
        public const string PACKAGE_NAME = "Sun Lamp Auto-Basins";

        public SunLampHonestyMod(ModContentPack content) : base(content)
        {
            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
