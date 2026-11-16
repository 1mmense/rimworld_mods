using RimWorld;
using SettingsHelper;
using System;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class VME_Settings
    {
        //60000 ticks = 1 day
        //60 ticks = 1 sec
        //2500 ticks = 1 hour
        //Exalted Leader
        public static float abilityRoleVME_ExaltedLeader = 10; //Days
        public static float abilityVME_LeaderConversionRitual = 8; //Days
        public static float abilityVME_LeaderConvert = 10; //Days
        public static float abilityVME_LeaderPreachHealth = 10; //Days
        public static float abilityVME_LeaderReassure = 10; //Days
        public static float abilityVME_LeaderCounsel = 10; //Days
        //Commissar
        public static float abilityVME_EnforceCompliance = 24; //Hours
        //Flame Keeper
        public static float abilityVME_StrengthenFlame = 3; //Hours
        //Fleshcrafter
        public static float abilityVME_HarvestBodyParts = 24; //Hours
        //Insectoid Herder
        public static float abilityVME_TameInsectoid = 24; //Hours
        //Insectoid Herder Nest
        public static float abilityVME_ConstructANest = 120; //Days
        //Mechacker
        public static float abilityVME_EnableSelfDestruct = 24; //Hours
        //Nurse
        public static float abilityVME_MedicalEmergency = 24; //Hours
        //Party Host
        public static float abilityVME_ThrowParty = 24; //Hours
        //Trader
        public static float abilityVME_CallTradeCaravan = 5; //Days

        public static bool separatedAblilitiesVME = false;
        public static bool notificationOnCooldownCompleteVME = true;

        public static void ExposeDataVME()
        {
            //Exalted Leader
            Scribe_Values.Look(ref abilityRoleVME_ExaltedLeader, "abilityRoleVME_ExaltedLeader");
            Scribe_Values.Look(ref abilityVME_LeaderConversionRitual, "abilityVME_LeaderConversionRitual");
            Scribe_Values.Look(ref abilityVME_LeaderConvert, "abilityVME_LeaderConvert");
            Scribe_Values.Look(ref abilityVME_LeaderPreachHealth, "abilityVME_LeaderPreachHealth");
            Scribe_Values.Look(ref abilityVME_LeaderReassure, "abilityVME_LeaderReassure");
            Scribe_Values.Look(ref abilityVME_LeaderCounsel, "abilityVME_LeaderCounsel");
            //Commissar
            Scribe_Values.Look(ref abilityVME_EnforceCompliance, "abilityVME_EnforceCompliance");
            //Flame Keeper
            Scribe_Values.Look(ref abilityVME_StrengthenFlame, "abilityVME_StrengthenFlame");
            //Fleshcrafter
            Scribe_Values.Look(ref abilityVME_HarvestBodyParts, "abilityVME_HarvestBodyParts");
            //Insectoid Herder
            Scribe_Values.Look(ref abilityVME_TameInsectoid, "abilityVME_TameInsectoid");
            //Insectoid Herder Nest
            Scribe_Values.Look(ref abilityVME_ConstructANest, "abilityVME_ConstructANest");
            //Mechacker
            Scribe_Values.Look(ref abilityVME_EnableSelfDestruct, "abilityVME_EnableSelfDestruct");
            //Nurse
            Scribe_Values.Look(ref abilityVME_MedicalEmergency, "abilityVME_MedicalEmergency");
            //Party Host
            Scribe_Values.Look(ref abilityVME_ThrowParty, "abilityVME_ThrowParty");
            //Trader
            Scribe_Values.Look(ref abilityVME_CallTradeCaravan, "abilityVME_CallTradeCaravan");

            Scribe_Values.Look(ref separatedAblilitiesVME, "separatedAblilitiesVME");
            Scribe_Values.Look(ref notificationOnCooldownCompleteVME, "notificationOnCooldownCompleteVME", true);

        }
        public static void DrawVME(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("Exalted Leader abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ritual: Conversion Ritual (" + abilityVME_LeaderConversionRitual + ") days", ref abilityVME_LeaderConversionRitual, 0, 15, "0", "15", 1f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Convert (" + abilityVME_LeaderConvert + ") days", ref abilityVME_LeaderConvert, 0, 15, "0", "15", 1f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Preach Health (" + abilityVME_LeaderPreachHealth + ") days", ref abilityVME_LeaderPreachHealth, 0, 15, "0", "15", 1f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Reassure (" + abilityVME_LeaderReassure + ") days", ref abilityVME_LeaderReassure, 0, 15, "0", "15", 1f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Counsel (" + abilityVME_LeaderCounsel + ") days", ref abilityVME_LeaderCounsel, 0, 15, "0", "15", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Commissar abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Enforce Compliance (" + abilityVME_EnforceCompliance + ") Hours", ref abilityVME_EnforceCompliance, 0, 72, "0", "72", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Flame Keeper abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Strengthen Flame (" + abilityVME_StrengthenFlame + ") Hours", ref abilityVME_StrengthenFlame, 0, 72, "0", "72", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Fleshcrafter");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Harvest Body Parts (" + abilityVME_HarvestBodyParts + ") Hours", ref abilityVME_HarvestBodyParts, 0, 72, "0", "72", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Insectoid Herder abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Tame Insectoid (" + abilityVME_TameInsectoid + ") Hours", ref abilityVME_TameInsectoid, 0, 72, "0", "72", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Insectoid Herder Nest abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Construct A Nest (" + abilityVME_ConstructANest + ") days", ref abilityVME_ConstructANest, 0, 120, "0", "120", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Mechacker abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Enable Self Destruct (" + abilityVME_EnableSelfDestruct + ") Hours", ref abilityVME_EnableSelfDestruct, 0, 72, "0", "72", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Nurse abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Medical Emergency (" + abilityVME_MedicalEmergency + ") Hours", ref abilityVME_MedicalEmergency, 0, 72, "0", "72", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Party Host abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Throw Party (" + abilityVME_ThrowParty + ") Hours", ref abilityVME_ThrowParty, 0, 72, "0", "72", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("Trader abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Call Trade Caravan (" + abilityVME_CallTradeCaravan + ") days", ref abilityVME_CallTradeCaravan, 0, 15, "0", "15", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Label("More options");
            listing_Standard.AddLabeledCheckbox("Get notification when cooldown of ability is complete", ref notificationOnCooldownCompleteVME);
            listing_Standard.AddLabeledCheckbox("Use ablilities separately from each other", ref separatedAblilitiesVME);
            listing_Standard.Label("If option above is off, Sliders from the Exalted Leader abilities will no longer work and the slider below will allow you to adjust the cooldown of those roles");
            listing_Standard.AddLabeledSlider("Cooldown for the role: Exalted Leader (" + abilityRoleVME_ExaltedLeader + ") Days", ref abilityRoleVME_ExaltedLeader, 0, 15, "0", "15", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Gap(10);
            //Save settings
            GUI.color = Color.green;
            if (listing_Standard.ButtonText("Apply Memes and Structures Settings"))
            {
                ApplySettingVME();
                Messages.Message("Applied Memes and Structures Settings", MessageTypeDefOf.NeutralEvent);

            }
            //Reset settings
            GUI.color = Color.red;
            if (listing_Standard.ButtonText("Reset Memes and Structures Settings"))
            {
                ResetSettingsVME();
                Messages.Message("Reset Memes and Structures Settings", MessageTypeDefOf.NeutralEvent);

            }
            listing_Standard.Gap(10);
        }
        public static void ApplySettingVME()
        {
            DefDatabase<AbilityGroupDef>.GetNamed("VME_ExaltedLeader").cooldownTicks = Convert.ToInt32(abilityRoleVME_ExaltedLeader * 60000 + 1);

            int tickVME_LeaderConversionRitual = Convert.ToInt32(abilityVME_LeaderConversionRitual * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("VME_LeaderConversionRitual").cooldownTicksRange = new IntRange(tickVME_LeaderConversionRitual, tickVME_LeaderConversionRitual);
            int tickVME_LeaderConvert = Convert.ToInt32(abilityVME_LeaderConvert * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("VME_LeaderConvert").cooldownTicksRange = new IntRange(tickVME_LeaderConvert, tickVME_LeaderConvert);
            int tickVME_LeaderPreachHealth = Convert.ToInt32(abilityVME_LeaderPreachHealth * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("VME_LeaderPreachHealth").cooldownTicksRange = new IntRange(tickVME_LeaderPreachHealth, tickVME_LeaderPreachHealth);
            int tickVME_LeaderReassure = Convert.ToInt32(abilityVME_LeaderReassure * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("VME_LeaderReassure").cooldownTicksRange = new IntRange(tickVME_LeaderReassure, tickVME_LeaderReassure);
            int tickVME_LeaderCounsel = Convert.ToInt32(abilityVME_LeaderCounsel * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("VME_LeaderCounsel").cooldownTicksRange = new IntRange(tickVME_LeaderCounsel, tickVME_LeaderCounsel);

            DefDatabase<AbilityGroupDef>.GetNamed("VME_Commissar").cooldownTicks = Convert.ToInt32(abilityVME_EnforceCompliance * 2500 + 1);
            DefDatabase<AbilityGroupDef>.GetNamed("VME_FlameKeeper").cooldownTicks = Convert.ToInt32(abilityVME_StrengthenFlame * 2500 + 1);
            DefDatabase<AbilityGroupDef>.GetNamed("VME_Fleshcrafter").cooldownTicks = Convert.ToInt32(abilityVME_HarvestBodyParts * 2500 + 1);
            DefDatabase<AbilityGroupDef>.GetNamed("VME_InsectoidHerder").cooldownTicks = Convert.ToInt32(abilityVME_TameInsectoid * 2500 + 1);
            DefDatabase<AbilityGroupDef>.GetNamed("VME_InsectoidHerderNest").cooldownTicks = Convert.ToInt32(abilityVME_ConstructANest * 60000 + 1);
            DefDatabase<AbilityGroupDef>.GetNamed("VME_Mechacker").cooldownTicks = Convert.ToInt32(abilityVME_EnableSelfDestruct * 2500 + 1);
            DefDatabase<AbilityGroupDef>.GetNamed("VME_Nurse").cooldownTicks = Convert.ToInt32(abilityVME_MedicalEmergency * 2500 + 1);
            DefDatabase<AbilityGroupDef>.GetNamed("VME_PartyHost").cooldownTicks = Convert.ToInt32(abilityVME_ThrowParty * 2500 + 1);
            DefDatabase<AbilityGroupDef>.GetNamed("VME_Trader").cooldownTicks = Convert.ToInt32(abilityVME_CallTradeCaravan * 60000 + 1);

            if (notificationOnCooldownCompleteVME)
            {
                if (separatedAblilitiesVME)
                {
                    DefDatabase<AbilityGroupDef>.GetNamed("VME_ExaltedLeader").sendMessageOnCooldownComplete = false;

                    DefDatabase<AbilityDef>.GetNamed("VME_LeaderConversionRitual").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("VME_LeaderConvert").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("VME_LeaderReassure").sendMessageOnCooldownComplete = true;
                    DefDatabase<AbilityDef>.GetNamed("VME_LeaderCounsel").sendMessageOnCooldownComplete = true;
                }
                else if (!separatedAblilitiesVME)
                {
                    DefDatabase<AbilityGroupDef>.GetNamed("VME_ExaltedLeader").sendMessageOnCooldownComplete = true;

                    DefDatabase<AbilityDef>.GetNamed("VME_LeaderConversionRitual").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("VME_LeaderConvert").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("VME_LeaderReassure").sendMessageOnCooldownComplete = false;
                    DefDatabase<AbilityDef>.GetNamed("VME_LeaderCounsel").sendMessageOnCooldownComplete = false;
                }
                DefDatabase<AbilityGroupDef>.GetNamed("VME_Commissar").sendMessageOnCooldownComplete = true;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_FlameKeeper").sendMessageOnCooldownComplete = true;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_Fleshcrafter").sendMessageOnCooldownComplete = true;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_InsectoidHerder").sendMessageOnCooldownComplete = true;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_InsectoidHerderNest").sendMessageOnCooldownComplete = true;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_Mechacker").sendMessageOnCooldownComplete = true;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_Nurse").sendMessageOnCooldownComplete = true;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_PartyHost").sendMessageOnCooldownComplete = true;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_Trader").sendMessageOnCooldownComplete = true;
            }
            else if (!notificationOnCooldownCompleteVME)
            {
                DefDatabase<AbilityGroupDef>.GetNamed("VME_ExaltedLeader").sendMessageOnCooldownComplete = false;

                DefDatabase<AbilityDef>.GetNamed("VME_LeaderConversionRitual").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderConvert").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderReassure").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderCounsel").sendMessageOnCooldownComplete = false;

                DefDatabase<AbilityGroupDef>.GetNamed("VME_Commissar").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_FlameKeeper").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_Fleshcrafter").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_InsectoidHerder").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_InsectoidHerderNest").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_Mechacker").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_Nurse").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_PartyHost").sendMessageOnCooldownComplete = false;
                DefDatabase<AbilityGroupDef>.GetNamed("VME_Trader").sendMessageOnCooldownComplete = false;
            }

            if (separatedAblilitiesVME)
            {
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderConversionRitual").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderConvert").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderPreachHealth").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderReassure").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderCounsel").groupDef = null;
            }
            else
            {
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderConversionRitual").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("VME_ExaltedLeader");
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderConvert").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("VME_ExaltedLeader");
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderPreachHealth").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("VME_ExaltedLeader");
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderReassure").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("VME_ExaltedLeader");
                DefDatabase<AbilityDef>.GetNamed("VME_LeaderCounsel").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("VME_ExaltedLeader");
            }
        }
        public static void ResetSettingsVME()
        {
            abilityRoleVME_ExaltedLeader = 10; //Days
            abilityVME_LeaderConversionRitual = 8; //Days
            abilityVME_LeaderConvert = 10; //Days
            abilityVME_LeaderPreachHealth = 10; //Days
            abilityVME_LeaderReassure = 10; //Days
            abilityVME_LeaderCounsel = 10; //Days

            abilityVME_EnforceCompliance = 24; //Hours
            abilityVME_StrengthenFlame = 3; //Hours
            abilityVME_HarvestBodyParts = 24; //Hours
            abilityVME_TameInsectoid = 24; //Hours
            abilityVME_ConstructANest = 120; //Days
            abilityVME_EnableSelfDestruct = 24; //Hours
            abilityVME_MedicalEmergency = 24; //Hours
            abilityVME_ThrowParty = 24; //Hours
            abilityVME_CallTradeCaravan = 5; //Days

            separatedAblilitiesVME = false;
            notificationOnCooldownCompleteVME = true;

            ApplySettingVME();

        }
    }
}
