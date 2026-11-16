using RimWorld;
using SettingsHelper;
using System;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class Ideology_Setting
    {
        //Ritual
        public static float ritualPenalty = 95;
        public static float ritualCooldown = 20;

        //Leader
        public static float abilityRoleLeader = 10; //Days
        public static float abilityLeaderSpeech = 10; //Days
        public static float abilityTrial = 10; //Days
        public static float abilityWorkDrive = 10; //Days
        public static float abilityCombatCommand = 10; //Days

        //Moral Guide
        public static float abilityRoleMoralist = 3;
        public static float abilityConvert = 3; //Days
        public static float abilityPreachHealth = 3; //Days
        public static float abilityReassure = 3; //Days
        public static float abilityCounsel = 3; //Days

        //Multirole
        public static float abilityRoleMultiRole = 3; //Days
        public static float abilityAnimalCalm = 20; //Days
        public static float abilityImmunityDrive = 3; //Days
        public static float abilityBerserkTrance = 3; //Days
        public static float abilityMiningCommand = 3; //Days
        public static float abilityFarmingCommand = 3; //Days
        public static float abilityProductionCommand = 3; //Days
        public static float abilityResearchCommand = 3; //Days
        public static float abilityMarksmanCommand = 3; //Days

        public static bool separatedAblilitiesIdeology = false;
        public static bool notificationOnCooldownCompleteIdeology = true;
        public static void ExposeDataIdeology()
        {
            //Ritual
            Scribe_Values.Look(ref ritualPenalty, "ritualPenalty");
            Scribe_Values.Look(ref ritualCooldown, "ritualCooldown");

            //Leader abilities
            Scribe_Values.Look(ref abilityRoleLeader, "abilityRoleLeader");
            Scribe_Values.Look(ref abilityLeaderSpeech, "abilityLeaderSpeech");
            Scribe_Values.Look(ref abilityTrial, "abilityTrial");
            Scribe_Values.Look(ref abilityWorkDrive, "abilityWorkDrive");
            Scribe_Values.Look(ref abilityCombatCommand, "abilityCombatCommand");

            //Moralist abilities
            Scribe_Values.Look(ref abilityRoleMoralist, "abilityRoleMoralist");
            Scribe_Values.Look(ref abilityConvert, "abilityConvert");
            Scribe_Values.Look(ref abilityPreachHealth, "abilityPreachHealth");
            Scribe_Values.Look(ref abilityReassure, "abilityReassure");
            Scribe_Values.Look(ref abilityCounsel, "abilityCounsel");

            //MultiRole abilities
            Scribe_Values.Look(ref abilityRoleMultiRole, "abilityRoleMultiRole");
            Scribe_Values.Look(ref abilityAnimalCalm, "abilityAnimalCalm");
            Scribe_Values.Look(ref abilityImmunityDrive, "abilityImmunityDrive");
            Scribe_Values.Look(ref abilityBerserkTrance, "abilityBerserkTrance");
            Scribe_Values.Look(ref abilityMiningCommand, "abilityMiningCommand");
            Scribe_Values.Look(ref abilityFarmingCommand, "abilityFarmingCommand");
            Scribe_Values.Look(ref abilityProductionCommand, "abilityProductionCommand");
            Scribe_Values.Look(ref abilityResearchCommand, "abilityResearchCommand");
            Scribe_Values.Look(ref abilityMarksmanCommand, "abilityMarksmanCommand");

            Scribe_Values.Look(ref separatedAblilitiesIdeology, "separatedAblilities", false);
            Scribe_Values.Look(ref notificationOnCooldownCompleteIdeology, "notificationOnCooldownComplete", true);
        }
        public static void DrawIdeology(Listing_Standard listing_Standard)
        {
            //ritual penalty
            listing_Standard.Label("Ritual");
            listing_Standard.AddLabeledSlider("Percentage for the Ritual Penalty (" + ritualPenalty + ") %", ref ritualPenalty, 0, 100, "0", "100", 1f);
            listing_Standard.AddLabeledSlider("Cooldown for the Rituals (" + ritualCooldown + ") Days", ref ritualCooldown, 0, 20, "0", "20", 0.5f);
            listing_Standard.Label("This works for all rituals including rituals added by other mods");
            //Abilities
            listing_Standard.AddHorizontalLine();
            listing_Standard.Label("Leader abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: LeaderSpeech (" + abilityLeaderSpeech + ") Days", ref abilityLeaderSpeech, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Trial (" + abilityTrial + ") Days", ref abilityTrial, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: WorkDrive (" + abilityWorkDrive + ") Days", ref abilityWorkDrive, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: CombatCommand (" + abilityCombatCommand + ") Days", ref abilityCombatCommand, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Moral Guide abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Convert (" + abilityConvert + ") Days", ref abilityConvert, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: PreachHealth (" + abilityPreachHealth + ") Days", ref abilityPreachHealth, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Reassure (" + abilityReassure + ") Days", ref abilityReassure, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Counsel (" + abilityCounsel + ") Days", ref abilityCounsel, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Specialist abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: AnimalCalm (" + abilityAnimalCalm + ") Days", ref abilityAnimalCalm, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: ImmunityDrive (" + abilityImmunityDrive + ") Days", ref abilityImmunityDrive, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: BerserkTrance (" + abilityBerserkTrance + ") Days", ref abilityBerserkTrance, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: MiningCommand (" + abilityMiningCommand + ") Days", ref abilityMiningCommand, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: FarmingCommand (" + abilityFarmingCommand + ") Days", ref abilityFarmingCommand, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: ProductionCommand (" + abilityProductionCommand + ") Days", ref abilityProductionCommand, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: ResearchCommand (" + abilityResearchCommand + ") Days", ref abilityResearchCommand, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: MarksmanCommand (" + abilityMarksmanCommand + ") Days", ref abilityMarksmanCommand, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("More options");
            listing_Standard.AddLabeledCheckbox("Get notification when cooldown of ability is complete", ref notificationOnCooldownCompleteIdeology);
            listing_Standard.AddLabeledCheckbox("Use ablilities separately from each other", ref separatedAblilitiesIdeology);
            listing_Standard.Label("If option above is off, Sliders from the Leader, Moralist and Specialist role abilities will no longer work and the sliders below will allow you to adjust the cooldown of those roles");
            listing_Standard.AddLabeledSlider("Cooldown for the role: Leader (" + abilityRoleLeader + ") Days", ref abilityRoleLeader, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the role: Moralist (" + abilityRoleMoralist + ") Days", ref abilityRoleMoralist, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the role: Specialist (" + abilityRoleMultiRole + ") Days", ref abilityRoleMultiRole, 0, 20, "0", "20", 0.5f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Gap(10);
            //Save settings
            GUI.color = Color.green;
            if (listing_Standard.ButtonText("Apply Ideology Settings"))
            {
                ApplySettingIdeology();
                Messages.Message("Applied Ideology Settings", MessageTypeDefOf.NeutralEvent);

            }
            //Reset settings
            GUI.color = Color.red;
            if (listing_Standard.ButtonText("Reset Ideology Settings"))
            {
                ResetSettingsIdeology();
                Messages.Message("Reset Ideology Settings", MessageTypeDefOf.NeutralEvent);

            }
            listing_Standard.Gap(10);
        }
        public static void ApplySettingIdeology()
        {
            //Leader abilities
            DefDatabase<AbilityGroupDef>.GetNamed("Leader").cooldownTicks = Convert.ToInt32(abilityRoleLeader * 60000 + 1);

            int tickLeaderSpeech = Convert.ToInt32(abilityLeaderSpeech * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").cooldownTicksRange = new IntRange(tickLeaderSpeech, tickLeaderSpeech);
            int tickTrial = Convert.ToInt32(abilityTrial * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("Trial").cooldownTicksRange = new IntRange(tickTrial, tickTrial);
            int tickWorkDrive = Convert.ToInt32(abilityWorkDrive * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("WorkDrive").cooldownTicksRange = new IntRange(tickWorkDrive, tickWorkDrive);
            int tickCombatCommand = Convert.ToInt32(abilityCombatCommand * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("CombatCommand").cooldownTicksRange = new IntRange(tickCombatCommand, tickCombatCommand);

            //Moralist abilities
            DefDatabase<AbilityGroupDef>.GetNamed("Moralist").cooldownTicks = Convert.ToInt32(abilityRoleMoralist * 60000 + 1);

            int tickConvert = Convert.ToInt32(abilityConvert * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("Convert").cooldownTicksRange = new IntRange(tickConvert, tickConvert);
            int tickPreachHealth = Convert.ToInt32(abilityPreachHealth * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("PreachHealth").cooldownTicksRange = new IntRange(tickPreachHealth, tickPreachHealth);
            int tickReassure = Convert.ToInt32(abilityReassure * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("Reassure").cooldownTicksRange = new IntRange(tickReassure, tickReassure);
            int tickCounsel = Convert.ToInt32(abilityCounsel * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("Counsel").cooldownTicksRange = new IntRange(tickCounsel, tickCounsel);

            //MultiRole abilities
            DefDatabase<AbilityGroupDef>.GetNamed("MultiRole").cooldownTicks = Convert.ToInt32(abilityRoleMultiRole * 60000 + 1);

            int tickAnimalCalm = Convert.ToInt32(abilityAnimalCalm * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AnimalCalm").cooldownTicksRange = new IntRange(tickAnimalCalm, tickAnimalCalm);
            int tickImmunityDrive = Convert.ToInt32(abilityImmunityDrive * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("ImmunityDrive").cooldownTicksRange = new IntRange(tickImmunityDrive, tickImmunityDrive);
            int tickBerserkTrance = Convert.ToInt32(abilityBerserkTrance * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("BerserkTrance").cooldownTicksRange = new IntRange(tickBerserkTrance, tickBerserkTrance);
            int tickMiningCommand = Convert.ToInt32(abilityMiningCommand * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("MiningCommand").cooldownTicksRange = new IntRange(tickMiningCommand, tickMiningCommand);
            int tickFarmingCommand = Convert.ToInt32(abilityFarmingCommand * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("FarmingCommand").cooldownTicksRange = new IntRange(tickFarmingCommand, tickFarmingCommand);
            int tickProductionCommand = Convert.ToInt32(abilityProductionCommand * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("ProductionCommand").cooldownTicksRange = new IntRange(tickProductionCommand, tickProductionCommand);
            int tickResearchCommand = Convert.ToInt32(abilityResearchCommand * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("ResearchCommand").cooldownTicksRange = new IntRange(tickResearchCommand, tickResearchCommand);
            int tickMarksmanCommand = Convert.ToInt32(abilityMarksmanCommand * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("MarksmanCommand").cooldownTicksRange = new IntRange(tickMarksmanCommand, tickMarksmanCommand);

            if (notificationOnCooldownCompleteIdeology)
            {
                if (separatedAblilitiesIdeology)
                {
                    DefDatabase<AbilityGroupDef>.GetNamed("Leader").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityGroupDef>.GetNamed("Moralist").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityGroupDef>.GetNamed("MultiRole").sendMessageOnCooldownComplete = false;

                    DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("Trial").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("WorkDrive").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("CombatCommand").sendMessageOnCooldownComplete = true;

                    DefDatabase<AbilityDef>.GetNamed("Convert").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("PreachHealth").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("Reassure").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("Counsel").sendMessageOnCooldownComplete = true;

                    DefDatabase<AbilityDef>.GetNamed("AnimalCalm").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("ImmunityDrive").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("BerserkTrance").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("MiningCommand").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("FarmingCommand").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("ProductionCommand").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("ResearchCommand").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("MarksmanCommand").sendMessageOnCooldownComplete = true;
                }
                else if (!separatedAblilitiesIdeology)
                {
                    DefDatabase<AbilityGroupDef>.GetNamed("Leader").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityGroupDef>.GetNamed("Moralist").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityGroupDef>.GetNamed("MultiRole").sendMessageOnCooldownComplete = true;

                    DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("Trial").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("WorkDrive").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("CombatCommand").sendMessageOnCooldownComplete = false;

                    DefDatabase<AbilityDef>.GetNamed("Convert").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("PreachHealth").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("Reassure").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("Counsel").sendMessageOnCooldownComplete = false;

                    DefDatabase<AbilityDef>.GetNamed("AnimalCalm").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("ImmunityDrive").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("BerserkTrance").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("MiningCommand").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("FarmingCommand").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("ProductionCommand").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("ResearchCommand").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("MarksmanCommand").sendMessageOnCooldownComplete = false;
                }

            }
            else if (!notificationOnCooldownCompleteIdeology)
            {
                DefDatabase<AbilityGroupDef>.GetNamed("Leader").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("Moralist").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("MultiRole").sendMessageOnCooldownComplete = false;

                DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("Trial").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("WorkDrive").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("CombatCommand").sendMessageOnCooldownComplete = false;

                DefDatabase<AbilityDef>.GetNamed("Convert").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("PreachHealth").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("Reassure").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("Counsel").sendMessageOnCooldownComplete = false;

                DefDatabase<AbilityDef>.GetNamed("AnimalCalm").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("ImmunityDrive").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("BerserkTrance").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("MiningCommand").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("FarmingCommand").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("ProductionCommand").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("ResearchCommand").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("MarksmanCommand").sendMessageOnCooldownComplete = false;
            }

            if (separatedAblilitiesIdeology)
            {
                DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("Trial").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("WorkDrive").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("CombatCommand").groupDef = null;

                DefDatabase<AbilityDef>.GetNamed("Convert").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("PreachHealth").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("Reassure").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("Counsel").groupDef = null;

                DefDatabase<AbilityDef>.GetNamed("AnimalCalm").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("ImmunityDrive").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("BerserkTrance").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("MiningCommand").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("FarmingCommand").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("ProductionCommand").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("ResearchCommand").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("MarksmanCommand").groupDef = null;
            }
            else
            {
                DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Leader");
                DefDatabase<AbilityDef>.GetNamed("Trial").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Leader");
                DefDatabase<AbilityDef>.GetNamed("WorkDrive").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Leader");
                DefDatabase<AbilityDef>.GetNamed("CombatCommand").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Leader");

                DefDatabase<AbilityDef>.GetNamed("Convert").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Moralist");
                DefDatabase<AbilityDef>.GetNamed("PreachHealth").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Moralist");
                DefDatabase<AbilityDef>.GetNamed("Reassure").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Moralist");
                DefDatabase<AbilityDef>.GetNamed("Counsel").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Moralist");
            }
        }
        public static void ResetSettingsIdeology()
        {
            //Rituals
            ritualPenalty = 95; //%
            ritualCooldown = 20; //Days

            //Leader abilities
            abilityRoleLeader = 10; //Days
            abilityLeaderSpeech = 10; //Days
            abilityTrial = 10; //Days
            abilityWorkDrive = 10; //Days
            abilityCombatCommand = 10; //Days

            //Moralist abilities
            abilityRoleMoralist = 3; //Days
            abilityConvert = 3; //Days
            abilityPreachHealth = 3; //Days
            abilityReassure = 3; //Days
            abilityCounsel = 3; //Days

            //MultiRole abilities
            abilityRoleMultiRole = 3; //Days
            abilityAnimalCalm = 20; //Days
            abilityImmunityDrive = 3; //Days
            abilityBerserkTrance = 3; //Days
            abilityMiningCommand = 3; //Days
            abilityFarmingCommand = 3; //Days
            abilityProductionCommand = 3; //Days
            abilityResearchCommand = 3; //Days
            abilityMarksmanCommand = 3; //Days

            separatedAblilitiesIdeology = false;
            notificationOnCooldownCompleteIdeology = true;

            ApplySettingIdeology();
        }

    }
}
