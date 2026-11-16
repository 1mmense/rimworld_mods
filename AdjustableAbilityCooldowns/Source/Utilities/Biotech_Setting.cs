using RimWorld;
using SettingsHelper;
using System;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class Biotech_Setting
    {
        public static float abilityPiercingSpine = 1;
        public static float abilityResurrect = 120;
        public static float abilityAcidSpray = 12; //Hours
        public static float abilityFoamSpray = 12; //Hours
        public static float abilityFireSpew = 5; //Days
        public static float abilityLongjump = 1; //Seconds
        public static float abilityFireBurst = 45; //Seconds
        public static float abilityAnimalWarcall = 15; //Days
        public static float abilityLongjumpMech = 8; //Seconds
        public static float abilityLongjumpMechLauncher = 8; //Hours
        public static float abilitySmokepopMech = 15; //Days
        public static float abilityFirefoampopMech = 5; //Days
        public static float abilityResurrectionMech = 2; //Seconds

        public static void ExposeDataBiotech()
        {
            //Biotech
            Scribe_Values.Look(ref abilityPiercingSpine, "abilityPiercingSpine");
            Scribe_Values.Look(ref abilityResurrect, "abilityResurrect");
            Scribe_Values.Look(ref abilityAcidSpray, "abilityAcidSpray");
            Scribe_Values.Look(ref abilityFoamSpray, "abilityFoamSpray");
            Scribe_Values.Look(ref abilityFireSpew, "abilityFireSpew");
            Scribe_Values.Look(ref abilityLongjump, "abilityLongjump");
            Scribe_Values.Look(ref abilityFireBurst, "abilityFireBurst");
            Scribe_Values.Look(ref abilityAnimalWarcall, "abilityAnimalWarcall");
            Scribe_Values.Look(ref abilityLongjumpMech, "abilityLongjumpMech");
            Scribe_Values.Look(ref abilityLongjumpMechLauncher, "abilityLongjumpMechLauncher");
            Scribe_Values.Look(ref abilitySmokepopMech, "abilitySmokepopMech");
            Scribe_Values.Look(ref abilityFirefoampopMech, "abilityFirefoampopMech");
            Scribe_Values.Look(ref abilityResurrectionMech, "abilityResurrectionMech");
        }
        public static void DrawBiotech(Listing_Standard listing_Standard)
        {
            //Biotech
            listing_Standard.Label("Biotech abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: PiercingSpine (" + abilityPiercingSpine + ") Seconds", ref abilityPiercingSpine, 0, 60, "0", "60", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Resurrect (" + abilityResurrect + ") Days", ref abilityResurrect, 0, 120, "0", "120", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: AcidSpray (" + abilityAcidSpray + ") Hours", ref abilityAcidSpray, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: FoamSpray (" + abilityFoamSpray + ") Hours", ref abilityFoamSpray, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: FireSpew (" + abilityFireSpew + ") Days", ref abilityFireSpew, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Longjump (" + abilityLongjump + ") Seconds", ref abilityLongjump, 0, 60, "0", "60", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: FireBurst (" + abilityFireBurst + ") Seconds", ref abilityFireBurst, 0, 60, "0", "60", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: AnimalWarcall (" + abilityAnimalWarcall + ") Days", ref abilityAnimalWarcall, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: LongjumpMech (" + abilityLongjumpMech + ") Seconds", ref abilityLongjumpMech, 0, 60, "0", "60", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: LongjumpMechLauncher (" + abilityLongjumpMechLauncher + ") Hours", ref abilityLongjumpMechLauncher, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: SmokepopMech (" + abilitySmokepopMech + ") Days", ref abilitySmokepopMech, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: FirefoampopMech (" + abilityFirefoampopMech + ") Days", ref abilityFirefoampopMech, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: ResurrectionMech (" + abilityResurrectionMech + ") Seconds", ref abilityResurrectionMech, 0, 60, "0", "60", 1);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Gap(10);
            //Save settings
            GUI.color = Color.green;
            if (listing_Standard.ButtonText("Apply Biotech Settings"))
            {
                ApplySettingBiotech();
                Messages.Message("Applied Biotech Settings", MessageTypeDefOf.NeutralEvent);

            }
            //Reset settings
            GUI.color = Color.red;
            if (listing_Standard.ButtonText("Reset Biotech Settings"))
            {
                ResetSettingsBiotech();
                Messages.Message("Reset Biotech Settings", MessageTypeDefOf.NeutralEvent);

            }
            listing_Standard.Gap(10);
        }
        public static void ApplySettingBiotech()
        {
            //Biotech
            int tickPiercingSpine = Convert.ToInt32(abilityPiercingSpine * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("PiercingSpine").cooldownTicksRange = new IntRange(tickPiercingSpine, tickPiercingSpine);
            int tickResurrect = Convert.ToInt32(abilityResurrect * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("Resurrect").cooldownTicksRange = new IntRange(tickResurrect, tickResurrect);
            int tickAcidSpray = Convert.ToInt32(abilityAcidSpray * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AcidSpray").cooldownTicksRange = new IntRange(tickAcidSpray, tickAcidSpray);
            int tickFoamSpray = Convert.ToInt32(abilityFoamSpray * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("FoamSpray").cooldownTicksRange = new IntRange(tickFoamSpray, tickFoamSpray);
            int tickFireSpew = Convert.ToInt32(abilityFireSpew * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("FireSpew").cooldownTicksRange = new IntRange(tickFireSpew, tickFireSpew);
            int tickLongjump = Convert.ToInt32(abilityLongjump * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("Longjump").cooldownTicksRange = new IntRange(tickLongjump, tickLongjump);
            int tickFireBurst = Convert.ToInt32(abilityFireBurst * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("FireBurst").cooldownTicksRange = new IntRange(tickFireBurst, tickFireBurst);
            int tickAnimalWarcall = Convert.ToInt32(abilityAnimalWarcall * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AnimalWarcall").cooldownTicksRange = new IntRange(tickAnimalWarcall, tickAnimalWarcall);
            int tickLongjumpMech = Convert.ToInt32(abilityLongjumpMech * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("LongjumpMech").cooldownTicksRange = new IntRange(tickLongjumpMech, tickLongjumpMech);
            int tickLongjumpMechLauncher = Convert.ToInt32(abilityLongjumpMechLauncher * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("LongjumpMechLauncher").cooldownTicksRange = new IntRange(tickLongjumpMechLauncher, tickLongjumpMechLauncher);
            int tickSmokepopMech = Convert.ToInt32(abilitySmokepopMech * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("SmokepopMech").cooldownTicksRange = new IntRange(tickSmokepopMech, tickSmokepopMech);
            int tickFirefoampopMech = Convert.ToInt32(abilityFirefoampopMech * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("FirefoampopMech").cooldownTicksRange = new IntRange(tickFirefoampopMech, tickFirefoampopMech);
            int tickResurrectionMech = Convert.ToInt32(abilityResurrectionMech * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("ResurrectionMech").cooldownTicksRange = new IntRange(tickResurrectionMech, tickResurrectionMech);

        }
        public static void ResetSettingsBiotech()
        {
            //biotech
            abilityPiercingSpine = 1; //Seconds
            abilityResurrect = 120; //Days
            abilityAcidSpray = 12; //Hours
            abilityFoamSpray = 12; //Hours
            abilityFireSpew = 5; //Days
            abilityLongjump = 1; //Seconds
            abilityFireBurst = 45; //Seconds
            abilityAnimalWarcall = 15; //Days
            abilityLongjumpMech = 8; //Seconds
            abilityLongjumpMechLauncher = 8; //Hours
            abilitySmokepopMech = 15; //Days
            abilityFirefoampopMech = 5; //Days
            abilityResurrectionMech = 2; //Seconds

            ApplySettingBiotech();
        }
    }
}
