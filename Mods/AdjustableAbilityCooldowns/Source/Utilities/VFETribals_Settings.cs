using RimWorld;
using SettingsHelper;
using System;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class VFETribals_Settings
    {
        //60000 ticks = 1 day
        //60 ticks = 1 sec
        //2500 ticks = 1 hour
        public static float ritualVFET_TribalGathering = 24; //Hours
        public static void ExposeDataVFETribals()
        {
            Scribe_Values.Look(ref ritualVFET_TribalGathering, "ritualVFET_TribalGathering");
        }
        public static void DrawVFETribals(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("VFE Tribals rituals");
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: Tribal Gathering (" + ritualVFET_TribalGathering + ") Hours", ref ritualVFET_TribalGathering, 0, 72, "0", "72", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Gap(10);
            //Save settings
            GUI.color = Color.green;
            if (listing_Standard.ButtonText("Apply VFE Tribal Settings"))
            {
                ApplySettingVFETribals();
                Messages.Message("Applied VFE Tribal settings", MessageTypeDefOf.NeutralEvent);

            }
            //Reset settings
            GUI.color = Color.red;
            if (listing_Standard.ButtonText("Reset VFE Tribal Settings"))
            {
                ResetSettingsVFETribals();
                Messages.Message("Reset VFE Tribal settings", MessageTypeDefOf.NeutralEvent);

            }
            listing_Standard.Gap(10);
        }
        public static void ApplySettingVFETribals()
        {
            DefDatabase<AbilityGroupDef>.GetNamed("VFET_TribalGathering").cooldownTicks = Convert.ToInt32(ritualVFET_TribalGathering * 2500 + 1);
        }
        public static void ResetSettingsVFETribals()
        {
            ritualVFET_TribalGathering = 24; //Hours

            ApplySettingVFETribals();
        }
    }
}
