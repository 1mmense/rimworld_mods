using RimWorld;
using SettingsHelper;
using System;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class Odyssey_Settings
    {
        //60000 ticks = 1 day
        //60 ticks = 1 sec
        //2500 ticks = 1 hour
        public static float abilitySludgeSpew = 2; //Hours
        public static float abilityEggSpew = 2; //Hours
        public static float abilityCallMechanoids = 3; //Hours
        public static float abilityCallDropPods = 3; //Days
        public static float abilityDeactivateMechanoid = 3; //Hours
        public static float abilityTerrorRoar = 3; //Hours
        public static void ExposeDataOdyssey()
        {
            Scribe_Values.Look(ref abilitySludgeSpew, "abilitySludgeSpew");
            Scribe_Values.Look(ref abilityEggSpew, "abilityEggSpew");
            Scribe_Values.Look(ref abilityCallMechanoids, "abilityCallMechanoids");
            Scribe_Values.Look(ref abilityCallDropPods, "abilityCallDropPods");
            Scribe_Values.Look(ref abilityDeactivateMechanoid, "abilityDeactivateMechanoid");
            Scribe_Values.Look(ref abilityTerrorRoar, "abilityTerrorRoar");
        }
        public static void DrawOdyssey(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("Odyssey abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: SludgeSpew (" + abilitySludgeSpew + ") Hours", ref abilitySludgeSpew, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: EggSpew (" + abilityEggSpew + ") Hours", ref abilityEggSpew, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: CallMechanoids (" + abilityCallMechanoids + ") Hours", ref abilityCallMechanoids, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: CallDropPods (" + abilityCallDropPods + ") Hours", ref abilityCallDropPods, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: DeactivateMechanoid (" + abilityDeactivateMechanoid + ") Hours", ref abilityDeactivateMechanoid, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: TerrorRoar (" + abilityTerrorRoar + ") Hours", ref abilityTerrorRoar, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Gap(10);

            //Save settings
            GUI.color = Color.green;
            if (listing_Standard.ButtonText("Apply Example Settings"))
            {
                ApplySettingOdyssey();
                Messages.Message("Applied Example Settings", MessageTypeDefOf.NeutralEvent);

            }
            //Reset settings
            GUI.color = Color.red;
            if (listing_Standard.ButtonText("Reset Example Settings"))
            {
                ResetSettingsOdyssey();
                Messages.Message("Reset Example Settings", MessageTypeDefOf.NeutralEvent);

            }
            listing_Standard.Gap(10);

        }
        public static void ApplySettingOdyssey()
        {
            int tickAbilitySludgeSpew = Convert.ToInt32(abilitySludgeSpew * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("SludgeSpew").cooldownTicksRange = new IntRange(tickAbilitySludgeSpew, tickAbilitySludgeSpew);
            int tickAbilityEggSpew = Convert.ToInt32(abilityEggSpew * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("EggSpew").cooldownTicksRange = new IntRange(tickAbilityEggSpew, tickAbilityEggSpew);
            int tickRitualCallMechanoids = Convert.ToInt32(abilityCallMechanoids * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("CallMechanoids").cooldownTicksRange = new IntRange(tickRitualCallMechanoids, tickRitualCallMechanoids);
            int tickAbilityCallDropPods = Convert.ToInt32(abilityCallDropPods * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("CallDropPods").cooldownTicksRange = new IntRange(tickAbilityCallDropPods, tickAbilityCallDropPods);
            int tickAbilityDeactivateMechanoid = Convert.ToInt32(abilityDeactivateMechanoid * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("DeactivateMechanoid").cooldownTicksRange = new IntRange(tickAbilityDeactivateMechanoid, tickAbilityDeactivateMechanoid);
            int tickAbilityTerrorRoar = Convert.ToInt32(abilityTerrorRoar * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("TerrorRoar").cooldownTicksRange = new IntRange(tickAbilityTerrorRoar, tickAbilityTerrorRoar);
        }
        public static void ResetSettingsOdyssey()
        {
            abilitySludgeSpew = 2; //Hours
            abilityEggSpew = 2; //Hours
            abilityCallMechanoids = 3; //Hours
            abilityCallDropPods = 3; //Days
            abilityDeactivateMechanoid = 3; //Hours
            abilityTerrorRoar = 3; //Hours

            ApplySettingOdyssey();
        }
    }
}
