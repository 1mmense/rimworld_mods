using RimWorld;
using SettingsHelper;
using System;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class Anomaly_Settings
    {
        //Rituals
        public static float ritualVoidProvocation = 5;
        public static float ritualImbueDeathRefusal = 15;
        public static float ritualPhilophagy = 5; //Days
        public static float ritualSummonAnimals = 10; //Days
        public static float ritualSummonShamblers = 5; //Days
        public static float ritualSummonPitGate = 45; //360
        public static float ritualChronophagy = 5; //Days
        public static float ritualPleasurePulse = 5; //Days
        public static float ritualNeurosisPulse = 5; //Days
        public static float ritualBloodRain = 25; //Days
        public static float ritualBrainwipe = 20; //Days
        public static float ritualPsychophagy = 5; //Days
        public static float ritualSkipAbduction = 10; //Days
        public static float ritualSummonFleshbeasts = 5; //Days

        //Abilities
        public static float abilityUnnaturalHealing = 6; //Days
        public static float abilityShapeFlesh = 40; //Seconds
        public static float abilityTransmuteSteel = 20; //Hours
        public static float abilityPsychicSlaughter = 1; //Days
        public static float abilityReleaseDeadlifeDust = 1; //Days
        public static float abilityGhoulFrenzy = 30; //Seconds
        public static float abilityCorrosiveSpray = 90; //Seconds
        public static float abilityMetalbloodInjection = 6; //Hours
        public static float abilityRevenantInvisibility = 6; //Hours
        public static float abilityVoidTerror = 3; //Hours

        public static void ExposeDataAnomaly()
        {
            //Rituals
            Scribe_Values.Look(ref ritualVoidProvocation, "ritualVoidProvocation");
            Scribe_Values.Look(ref ritualImbueDeathRefusal, "ritualImbueDeathRefusal");
            Scribe_Values.Look(ref ritualPhilophagy, "ritualPhilophagy");
            Scribe_Values.Look(ref ritualSummonAnimals, "ritualSummonAnimals");
            Scribe_Values.Look(ref ritualSummonShamblers, "ritualSummonShamblers");
            Scribe_Values.Look(ref ritualSummonPitGate, "ritualSummonPitGate");
            Scribe_Values.Look(ref ritualChronophagy, "ritualChronophagy");
            Scribe_Values.Look(ref ritualPleasurePulse, "ritualPleasurePulse");
            Scribe_Values.Look(ref ritualNeurosisPulse, "ritualNeurosisPulse");
            Scribe_Values.Look(ref ritualBloodRain, "ritualBloodRain");
            Scribe_Values.Look(ref ritualBrainwipe, "ritualBrainwipe");
            Scribe_Values.Look(ref ritualPsychophagy, "ritualPsychophagy");
            Scribe_Values.Look(ref ritualSkipAbduction, "ritualSkipAbduction");
            Scribe_Values.Look(ref ritualSummonFleshbeasts, "ritualSummonFleshbeasts");

            //Abilities
            Scribe_Values.Look(ref abilityUnnaturalHealing, "abilityUnnaturalHealing");
            Scribe_Values.Look(ref abilityShapeFlesh, "abilityShapeFlesh");
            Scribe_Values.Look(ref abilityTransmuteSteel, "abilityTransmuteSteel");
            Scribe_Values.Look(ref abilityPsychicSlaughter, "abilityPsychicSlaughter");
            Scribe_Values.Look(ref abilityReleaseDeadlifeDust, "abilityReleaseDeadlifeDust");
            Scribe_Values.Look(ref abilityGhoulFrenzy, "abilityGhoulFrenzy");
            Scribe_Values.Look(ref abilityCorrosiveSpray, "abilityCorrosiveSpray");
            Scribe_Values.Look(ref abilityMetalbloodInjection, "abilityMetalbloodInjection");
            Scribe_Values.Look(ref abilityRevenantInvisibility, "abilityRevenantInvisibility");
            Scribe_Values.Look(ref abilityVoidTerror, "abilityVoidTerror");
        }
        public static void DrawAnomaly(Listing_Standard listing_Standard)
        {
            //Rituals
            listing_Standard.Label("Anomaly rituals");
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: VoidProvocation (" + ritualVoidProvocation + ") Days", ref ritualVoidProvocation, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: ImbueDeathRefusal (" + ritualImbueDeathRefusal + ") Days", ref ritualImbueDeathRefusal, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: Philophagy (" + ritualPhilophagy + ") Days", ref ritualPhilophagy, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: SummonAnimals (" + ritualSummonAnimals + ") Days", ref ritualSummonAnimals, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: SummonShamblers (" + ritualSummonShamblers + ") Days", ref ritualSummonShamblers, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: SummonPitGate (" + ritualSummonPitGate + ") Days", ref ritualSummonPitGate, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: Chronophagy (" + ritualChronophagy + ") Days", ref ritualChronophagy, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: PleasurePulse (" + ritualPleasurePulse + ") Days", ref ritualPleasurePulse, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: NeurosisPulse (" + ritualNeurosisPulse + ") Days", ref ritualNeurosisPulse, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: BloodRain (" + ritualBloodRain + ") Days", ref ritualBloodRain, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: Brainwipe (" + ritualBrainwipe + ") Days", ref ritualBrainwipe, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: Psychophagy (" + ritualPsychophagy + ") Days", ref ritualPsychophagy, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: SkipAbduction (" + ritualSkipAbduction + ") Days", ref ritualSkipAbduction, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: SummonFleshbeasts (" + ritualSummonFleshbeasts + ") Days", ref ritualSummonFleshbeasts, 0.5f, 60, "0.5", "60", 0.5f);
            listing_Standard.AddHorizontalLine();

            //Abilities
            listing_Standard.Label("Anomaly abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: UnnaturalHealing (" + abilityUnnaturalHealing + ") Days", ref abilityUnnaturalHealing, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: ShapeFlesh (" + abilityShapeFlesh + ") Seconds", ref abilityShapeFlesh, 0, 120, "0", "120", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: TransmuteSteel (" + abilityTransmuteSteel + ") Hours", ref abilityTransmuteSteel, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: PsychicSlaughter (" + abilityPsychicSlaughter + ") Days", ref abilityPsychicSlaughter, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: ReleaseDeadlifeDust (" + abilityReleaseDeadlifeDust + ") Days", ref abilityReleaseDeadlifeDust, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: GhoulFrenzy (" + abilityGhoulFrenzy + ") Seconds", ref abilityGhoulFrenzy, 0, 120, "0", "120", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: CorrosiveSpray (" + abilityCorrosiveSpray + ") Seconds", ref abilityCorrosiveSpray, 0, 120, "0", "120", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: MetalbloodInjection (" + abilityMetalbloodInjection + ") Hours", ref abilityMetalbloodInjection, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: RevenantInvisibility (" + abilityRevenantInvisibility + ") Hours", ref abilityRevenantInvisibility, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: VoidTerror (" + abilityVoidTerror + ") Hours", ref abilityVoidTerror, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Gap(10);
            //Save settings
            GUI.color = Color.green;
            if (listing_Standard.ButtonText("Apply Anomaly Settings"))
            {
                ApplySettingAnomaly();
                Messages.Message("Applied Anomaly Settings", MessageTypeDefOf.NeutralEvent);

            }
            //Reset settings
            GUI.color = Color.red;
            if (listing_Standard.ButtonText("Reset Anomaly Settings"))
            {
                ResetSettingsAnomaly();
                Messages.Message("Reset Anomaly Settings", MessageTypeDefOf.NeutralEvent);

            }
            listing_Standard.Gap(10);
        }
        public static void ApplySettingAnomaly()
        {
            //Rituals
            DefDatabase<PsychicRitualDef>.GetNamed("VoidProvocation").cooldownHours = Convert.ToInt32(ritualVoidProvocation * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("ImbueDeathRefusal").cooldownHours = Convert.ToInt32(ritualImbueDeathRefusal * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("Philophagy").cooldownHours = Convert.ToInt32(ritualPhilophagy * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("SummonAnimals").cooldownHours = Convert.ToInt32(ritualSummonAnimals * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("SummonShamblers").cooldownHours = Convert.ToInt32(ritualSummonShamblers * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("SummonPitGate").cooldownHours = Convert.ToInt32(ritualSummonPitGate * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("Chronophagy").cooldownHours = Convert.ToInt32(ritualChronophagy * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("PleasurePulse").cooldownHours = Convert.ToInt32(ritualPleasurePulse * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("NeurosisPulse").cooldownHours = Convert.ToInt32(ritualNeurosisPulse * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("BloodRain").cooldownHours = Convert.ToInt32(ritualBloodRain * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("Brainwipe").cooldownHours = Convert.ToInt32(ritualBrainwipe * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("Psychophagy").cooldownHours = Convert.ToInt32(ritualPsychophagy * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("SkipAbductionPlayer").cooldownHours = Convert.ToInt32(ritualSkipAbduction * 24);
            DefDatabase<PsychicRitualDef>.GetNamed("SummonFleshbeastsPlayer").cooldownHours = Convert.ToInt32(ritualSummonFleshbeasts * 24);

            //Abilities
            int tickUnnaturalHealing = Convert.ToInt32(abilityUnnaturalHealing * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("UnnaturalHealing").cooldownTicksRange = new IntRange(tickUnnaturalHealing, tickUnnaturalHealing);
            int tickShapeFlesh = Convert.ToInt32(abilityShapeFlesh * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("ShapeFlesh").cooldownTicksRange = new IntRange(tickShapeFlesh, tickShapeFlesh);
            int tickTransmuteSteel = Convert.ToInt32(abilityTransmuteSteel * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("TransmuteSteel").cooldownTicksRange = new IntRange(tickTransmuteSteel, tickTransmuteSteel);
            int tickPsychicSlaughter = Convert.ToInt32(abilityPsychicSlaughter * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("PsychicSlaughter").cooldownTicksRange = new IntRange(tickPsychicSlaughter, tickPsychicSlaughter);
            int tickReleaseDeadlifeDust = Convert.ToInt32(abilityReleaseDeadlifeDust * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("ReleaseDeadlifeDust").cooldownTicksRange = new IntRange(tickReleaseDeadlifeDust, tickReleaseDeadlifeDust);
            int tickGhoulFrenzy = Convert.ToInt32(abilityGhoulFrenzy * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("GhoulFrenzy").cooldownTicksRange = new IntRange(tickGhoulFrenzy, tickGhoulFrenzy);
            int tickCorrosiveSpray = Convert.ToInt32(abilityCorrosiveSpray * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("CorrosiveSpray").cooldownTicksRange = new IntRange(tickCorrosiveSpray, tickCorrosiveSpray);
            int tickMetalbloodInjection = Convert.ToInt32(abilityMetalbloodInjection * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("MetalbloodInjection").cooldownTicksRange = new IntRange(tickMetalbloodInjection, tickMetalbloodInjection);
            int tickRevenantInvisibility = Convert.ToInt32(abilityRevenantInvisibility * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("RevenantInvisibility").cooldownTicksRange = new IntRange(tickRevenantInvisibility, tickRevenantInvisibility);
            int tickVoidTerror = Convert.ToInt32(abilityVoidTerror * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("VoidTerror").cooldownTicksRange = new IntRange(tickVoidTerror, tickVoidTerror);
        }
        public static void ResetSettingsAnomaly()
        {
            //Rituals
            ritualVoidProvocation = 5; //Days
            ritualImbueDeathRefusal = 15; //Days
            ritualPhilophagy = 5; //Days
            ritualSummonAnimals = 10; //Days
            ritualSummonShamblers = 5; //Days
            ritualSummonPitGate = 45; //360
            ritualChronophagy = 5; //Days
            ritualPleasurePulse = 5; //Days
            ritualNeurosisPulse = 5; //Days
            ritualBloodRain = 25; //Days
            ritualBrainwipe = 20; //Days
            ritualPsychophagy = 5; //Days
            ritualSkipAbduction = 10; //Days
            ritualSummonFleshbeasts = 5; //Days

            //Abilities
            abilityUnnaturalHealing = 6; //Days
            abilityShapeFlesh = 40; //Seconds
            abilityTransmuteSteel = 20; //Hours
            abilityPsychicSlaughter = 1; //Days
            abilityReleaseDeadlifeDust = 1; //Days
            abilityGhoulFrenzy = 30; //Seconds
            abilityCorrosiveSpray = 90; //Seconds
            abilityMetalbloodInjection = 6; //Hours
            abilityRevenantInvisibility = 6; //Hours
            abilityVoidTerror = 3; //Hours

            ApplySettingAnomaly();
        }
    }
}
