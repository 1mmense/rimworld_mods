namespace SunLampHonesty
{
    public static class Debug
    {
        public static void Log(string message)
        {
#if DEBUG
            Verse.Log.Message($"[{SunLampHonestyMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
