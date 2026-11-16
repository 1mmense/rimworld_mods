using RimWorld;
using SettingsHelper;
using System;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class AlphaGene_Settings
    {
        //60000 ticks = 1 day
        //60 ticks = 1 sec
        //2500 ticks = 1 hour

        //Explosions
        public static float abilityAG_AcidicDetonation = 12; //Hours
        public static float abilityAG_Detonation = 12; //Hours
        //Mechanitor
        public static float abilityAG_MechConversion = 24; //Hours
        public static float abilityAG_BandwidthLoop = 24; //Hours
        public static float abilityAG_SummonTempBandwidth = 70; //Days
        public static float abilityAG_SummonMilitor = 24; //Hours
        public static float abilityAG_SummonTesseron = 24; //Hours
        public static float abilityAG_SummonCentipede = 24; //Hours
        //Mineral
        public static float abilityAG_ReactiveArmourA = 5; //Seconds
        public static float abilityAG_MineralOverdriveA = 24; //Hours
        public static float abilityAG_MineralShock = 1; //Seconds
        //PocketPlane
        public static float abilityAG_NereidPocketPlane = 15; //Seconds
        public static float abilityAG_DestroyPocketPlane = 15; //Seconds
        public static float abilityAG_TeleportItemsPocketPlane = 5; //Seconds
        //Projectiles
        public static float abilityAG_Zap = 6; //Hours
        public static float abilityAG_GreaterFireSpew = 5; //Days
        public static float abilityAG_GreaterAcidicVomit = 5; //Days
        public static float abilityAG_PetrifyingGaze = 5; //Days
        public static float abilityAG_Web = 3; //Hours
        public static float abilityAG_InsanityBlast = 24; //Hours
        public static float abilityAG_SterilizingBreath = 24; //Hours
        public static float abilityAG_BansheeScream = 12; //Hours
        public static float abilityAG_FreezingBreath = 24; //Hours
        public static float abilityAG_NoxiousBreath = 24; //Hours
        //Stingers
        public static float abilityAG_InsectStinger = 4; //Days
        public static float abilityAG_InsectStingerEndogenes = 4; //Days
        public static float abilityAG_ParasiticStinger = 2; //Days
        public static float abilityAG_ParasiticStingerEndogenes = 2; //Days
        //Summons
        public static float abilityAG_MinorSummon = 24; //Hours
        public static float abilityAG_Summon = 24; //Hours
        public static float abilityAG_MajorSummon = 24; //Hours
        //Misc
        public static float abilityAG_WingPoweredJump = 40; //Seconds
        public static float abilityAG_UnstableMutation = 24; //Hours
        public static float abilityAG_InsectRally = 12; //Hours
        public static float abilityAG_UnstableMind = 24; //Hours
        public static float abilityAG_DevourBrains = 24; //Hours
        public static float abilityAG_GeneSyphon = 24; //Hours
        public static float abilityAG_TailGrapple = 100; //Seconds
        public static float abilityAG_UnstableRegeneration = 4; //Hours
        public static float abilityAG_AdaptiveBiology = 24; //Hours
        public static float abilityAG_SuperAdaptiveBiology = 24; //Hours
        public static float abilityAG_PsychicAbsorption = 5; //Seconds
        public static float abilityAG_SpeedBurst = 5; //Hours

        public static void ExposeDataAlphaGenes()
        {
            //Explosions
            Scribe_Values.Look(ref abilityAG_AcidicDetonation, "abilityAG_AcidicDetonation");
            Scribe_Values.Look(ref abilityAG_Detonation, "abilityAG_Detonation");
            //Mechanitor
            Scribe_Values.Look(ref abilityAG_MechConversion, "abilityAG_MechConversion");
            Scribe_Values.Look(ref abilityAG_BandwidthLoop, "abilityAG_BandwidthLoop");
            Scribe_Values.Look(ref abilityAG_SummonTempBandwidth, "abilityAG_SummonTempBandwidth");
            Scribe_Values.Look(ref abilityAG_SummonMilitor, "abilityAG_SummonMilitor");
            Scribe_Values.Look(ref abilityAG_SummonTesseron, "abilityAG_SummonTesseron");
            Scribe_Values.Look(ref abilityAG_SummonCentipede, "abilityAG_SummonCentipede");
            //Mineral
            Scribe_Values.Look(ref abilityAG_ReactiveArmourA, "abilityAG_ReactiveArmourA");
            Scribe_Values.Look(ref abilityAG_MineralOverdriveA, "abilityAG_MineralOverdriveA");
            Scribe_Values.Look(ref abilityAG_MineralShock, "abilityAG_MineralShock");
            //PocketPlane
            Scribe_Values.Look(ref abilityAG_NereidPocketPlane, "abilityAG_NereidPocketPlane");
            Scribe_Values.Look(ref abilityAG_DestroyPocketPlane, "abilityAG_DestroyPocketPlane");
            Scribe_Values.Look(ref abilityAG_TeleportItemsPocketPlane, "abilityAG_TeleportItemsPocketPlane");
            //Projectiles
            Scribe_Values.Look(ref abilityAG_Zap, "abilityAG_Zap");
            Scribe_Values.Look(ref abilityAG_GreaterFireSpew, "abilityAG_GreaterFireSpew");
            Scribe_Values.Look(ref abilityAG_GreaterAcidicVomit, "abilityAG_GreaterAcidicVomit");
            Scribe_Values.Look(ref abilityAG_PetrifyingGaze, "abilityAG_PetrifyingGaze");
            Scribe_Values.Look(ref abilityAG_Web, "abilityAG_Web");
            Scribe_Values.Look(ref abilityAG_InsanityBlast, "abilityAG_InsanityBlast");
            Scribe_Values.Look(ref abilityAG_SterilizingBreath, "abilityAG_SterilizingBreath");
            Scribe_Values.Look(ref abilityAG_BansheeScream, "abilityAG_BansheeScream");
            Scribe_Values.Look(ref abilityAG_FreezingBreath, "abilityAG_FreezingBreath");
            Scribe_Values.Look(ref abilityAG_NoxiousBreath, "abilityAG_NoxiousBreath");
            //Stingers
            Scribe_Values.Look(ref abilityAG_InsectStinger, "abilityAG_InsectStinger");
            Scribe_Values.Look(ref abilityAG_InsectStingerEndogenes, "abilityAG_InsectStingerEndogenes");
            Scribe_Values.Look(ref abilityAG_ParasiticStinger, "abilityAG_ParasiticStinger");
            Scribe_Values.Look(ref abilityAG_ParasiticStingerEndogenes, "abilityAG_ParasiticStingerEndogenes");
            //Summons
            Scribe_Values.Look(ref abilityAG_MinorSummon, "abilityAG_MinorSummon");
            Scribe_Values.Look(ref abilityAG_Summon, "abilityAG_Summon");
            Scribe_Values.Look(ref abilityAG_MajorSummon, "abilityAG_MajorSummon");
            //Misc
            Scribe_Values.Look(ref abilityAG_WingPoweredJump, "abilityAG_WingPoweredJump");
            Scribe_Values.Look(ref abilityAG_UnstableMutation, "abilityAG_UnstableMutation");
            Scribe_Values.Look(ref abilityAG_InsectRally, "abilityAG_InsectRally");
            Scribe_Values.Look(ref abilityAG_UnstableMind, "abilityAG_UnstableMind");
            Scribe_Values.Look(ref abilityAG_DevourBrains, "abilityAG_DevourBrains");
            Scribe_Values.Look(ref abilityAG_GeneSyphon, "abilityAG_GeneSyphon");
            Scribe_Values.Look(ref abilityAG_TailGrapple, "abilityAG_TailGrapple");
            Scribe_Values.Look(ref abilityAG_UnstableRegeneration, "abilityAG_UnstableRegeneration");
            Scribe_Values.Look(ref abilityAG_AdaptiveBiology, "abilityAG_AdaptiveBiology");
            Scribe_Values.Look(ref abilityAG_SuperAdaptiveBiology, "abilityAG_SuperAdaptiveBiology");
            Scribe_Values.Look(ref abilityAG_PsychicAbsorption, "abilityAG_PsychicAbsorption");
            Scribe_Values.Look(ref abilityAG_SpeedBurst, "abilityAG_SpeedBurst");
        }
        public static void DrawAlphaGenes(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("Explosions abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Acidic Detonation (" + abilityAG_AcidicDetonation + ") Hours", ref abilityAG_AcidicDetonation, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Detonation (" + abilityAG_Detonation + ") Hours", ref abilityAG_Detonation, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddHorizontalLine();
            listing_Standard.Label("Mechanitor abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Mech IFF scrambler (" + abilityAG_MechConversion + ") Hours", ref abilityAG_MechConversion, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Bandwidth loop (" + abilityAG_BandwidthLoop + ") Hours", ref abilityAG_BandwidthLoop, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Summon band node (" + abilityAG_SummonTempBandwidth + ") Days", ref abilityAG_SummonTempBandwidth, 0, 120, "0", "120", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Summon militor (" + abilityAG_SummonMilitor + ") Hours", ref abilityAG_SummonMilitor, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Summon tesseron (" + abilityAG_SummonTesseron + ") Hours", ref abilityAG_SummonTesseron, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Summon centipede (" + abilityAG_SummonCentipede + ") Hours", ref abilityAG_SummonCentipede, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddHorizontalLine();
            listing_Standard.Label("Mineral abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Reactive armour (" + abilityAG_ReactiveArmourA + ") Seconds", ref abilityAG_ReactiveArmourA, 0, 60, "0", "60", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Mineral overdrive (" + abilityAG_MineralOverdriveA + ") Hours", ref abilityAG_MineralOverdriveA, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Mineral shock (" + abilityAG_MineralShock + ") Seconds", ref abilityAG_MineralShock, 0, 60, "0", "60", 1);
            listing_Standard.AddHorizontalLine();
            listing_Standard.Label("PocketPlane abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Nereid pocket plane (" + abilityAG_NereidPocketPlane + ") Seconds", ref abilityAG_NereidPocketPlane, 0, 60, "0", "60", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Destroy pocket plane (" + abilityAG_DestroyPocketPlane + ") Seconds", ref abilityAG_DestroyPocketPlane, 0, 60, "0", "60", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Transfer to pocket plane (" + abilityAG_TeleportItemsPocketPlane + ") Seconds", ref abilityAG_TeleportItemsPocketPlane, 0, 60, "0", "60", 1);
            listing_Standard.AddHorizontalLine();
            listing_Standard.Label("Projectiles abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Zap (" + abilityAG_Zap + ") Hours", ref abilityAG_Zap, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Greater Fire Spew (" + abilityAG_GreaterFireSpew + ") Days", ref abilityAG_GreaterFireSpew, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Greater Acidic Vomit (" + abilityAG_GreaterAcidicVomit + ") Days", ref abilityAG_GreaterAcidicVomit, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Petrifying Gaze (" + abilityAG_PetrifyingGaze + ") Days", ref abilityAG_PetrifyingGaze, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Web (" + abilityAG_Web + ") Hours", ref abilityAG_Web, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Insanity Blast (" + abilityAG_InsanityBlast + ") Hours", ref abilityAG_InsanityBlast, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Sterilizing Breath (" + abilityAG_SterilizingBreath + ") Hours", ref abilityAG_SterilizingBreath, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Banshee Scream (" + abilityAG_BansheeScream + ") Hours", ref abilityAG_BansheeScream, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Freezing Breath (" + abilityAG_FreezingBreath + ") Hours", ref abilityAG_FreezingBreath, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Noxious Breath (" + abilityAG_NoxiousBreath + ") Hours", ref abilityAG_NoxiousBreath, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddHorizontalLine();
            listing_Standard.Label("Stingers abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Insect Stinger (" + abilityAG_InsectStinger + ") Days", ref abilityAG_InsectStinger, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Insect Stinger Endogenes (" + abilityAG_InsectStingerEndogenes + ") Days", ref abilityAG_InsectStingerEndogenes, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Parasitic Stinger (" + abilityAG_ParasiticStinger + ") Days", ref abilityAG_ParasiticStinger, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Parasitic Stinger Endogenes (" + abilityAG_ParasiticStingerEndogenes + ") Days", ref abilityAG_ParasiticStingerEndogenes, 0, 15, "0", "15", 0.5f);
            listing_Standard.AddHorizontalLine();
            listing_Standard.Label("Summons abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Minor summon (" + abilityAG_MinorSummon + ") Hours", ref abilityAG_MinorSummon, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Summon (" + abilityAG_Summon + ") Hours", ref abilityAG_Summon, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Major summon (" + abilityAG_MajorSummon + ") Hours", ref abilityAG_MajorSummon, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddHorizontalLine();
            listing_Standard.Label("Misc abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Wing powered jump (" + abilityAG_WingPoweredJump + ") Seconds", ref abilityAG_WingPoweredJump, 0, 60, "0", "60", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Unstable mutation (" + abilityAG_UnstableMutation + ") Hours", ref abilityAG_UnstableMutation, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Insect rally (" + abilityAG_InsectRally + ") Hours", ref abilityAG_InsectRally, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Unstable mind (" + abilityAG_UnstableMind + ") Hours", ref abilityAG_UnstableMind, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Devour brains (" + abilityAG_DevourBrains + ") Hours", ref abilityAG_DevourBrains, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Gene syphon (" + abilityAG_GeneSyphon + ") Hours", ref abilityAG_GeneSyphon, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Tail grapple (" + abilityAG_TailGrapple + ") Seconds", ref abilityAG_TailGrapple, 0, 120, "0", "120", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Unstable regeneration (" + abilityAG_UnstableRegeneration + ") Hours", ref abilityAG_UnstableRegeneration, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Adaptive biology (" + abilityAG_AdaptiveBiology + ") Hours", ref abilityAG_AdaptiveBiology, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Super adaptive biology (" + abilityAG_SuperAdaptiveBiology + ") Hours", ref abilityAG_SuperAdaptiveBiology, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Psychic absorption (" + abilityAG_PsychicAbsorption + ") Seconds", ref abilityAG_PsychicAbsorption, 0, 60, "0", "60", 1);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Speed burst (" + abilityAG_SpeedBurst + ") Hours", ref abilityAG_SpeedBurst, 0, 24, "0", "24", 0.5f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Gap(10);
            //Save settings
            GUI.color = Color.green;
            if (listing_Standard.ButtonText("Apply Alpha Genes Settings"))
            {
                ApplySettingAlphaGenes();
                Messages.Message("Applied Alpha Genes Settings", MessageTypeDefOf.NeutralEvent);
            }
            //Reset settings
            GUI.color = Color.red;
            if (listing_Standard.ButtonText("Reset Alpha Genes Settings"))
            {
                ResetSettingsAlphaGenes();
                Messages.Message("Reset Alpha Genes Settings", MessageTypeDefOf.NeutralEvent);

            }
            listing_Standard.Gap(10);
        }
        public static void ApplySettingAlphaGenes()
        {
            //Explosions
            int tickAG_AcidicDetonation = Convert.ToInt32(abilityAG_AcidicDetonation * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_AcidicDetonation").cooldownTicksRange = new IntRange(tickAG_AcidicDetonation, tickAG_AcidicDetonation);
            int tickAG_Detonation = Convert.ToInt32(abilityAG_Detonation * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_Detonation").cooldownTicksRange = new IntRange(tickAG_Detonation, tickAG_Detonation);
            //Mechanitor
            int tickAG_MechConversion = Convert.ToInt32(abilityAG_MechConversion * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_MechConversion").cooldownTicksRange = new IntRange(tickAG_MechConversion, tickAG_MechConversion);
            int tickAG_BandwidthLoop = Convert.ToInt32(abilityAG_BandwidthLoop * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_BandwidthLoop").cooldownTicksRange = new IntRange(tickAG_BandwidthLoop, tickAG_BandwidthLoop);
            int tickAG_SummonTempBandwidth = Convert.ToInt32(abilityAG_SummonTempBandwidth * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_SummonTempBandwidth").cooldownTicksRange = new IntRange(tickAG_SummonTempBandwidth, tickAG_SummonTempBandwidth);
            int tickAG_SummonMilitor = Convert.ToInt32(abilityAG_SummonMilitor * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_SummonMilitor").cooldownTicksRange = new IntRange(tickAG_SummonMilitor, tickAG_SummonMilitor);
            int tickAG_SummonTesseron = Convert.ToInt32(abilityAG_SummonTesseron * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_SummonTesseron").cooldownTicksRange = new IntRange(tickAG_SummonTesseron, tickAG_SummonTesseron);
            int tickAG_SummonCentipede = Convert.ToInt32(abilityAG_SummonCentipede * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_SummonCentipede").cooldownTicksRange = new IntRange(tickAG_SummonCentipede, tickAG_SummonCentipede);
            //Mineral
            int tickAG_ReactiveArmourA = Convert.ToInt32(abilityAG_ReactiveArmourA * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_ReactiveArmourA").cooldownTicksRange = new IntRange(tickAG_ReactiveArmourA, tickAG_ReactiveArmourA);
            int tickAG_MineralOverdriveA = Convert.ToInt32(abilityAG_MineralOverdriveA * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_MineralOverdriveA").cooldownTicksRange = new IntRange(tickAG_MineralOverdriveA, tickAG_MineralOverdriveA);
            int tickAG_MineralShock = Convert.ToInt32(abilityAG_MineralShock * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_MineralShock").cooldownTicksRange = new IntRange(tickAG_MineralShock, tickAG_MineralShock);
            //PocketPlane
            int tickAG_NereidPocketPlane = Convert.ToInt32(abilityAG_NereidPocketPlane * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_NereidPocketPlane").cooldownTicksRange = new IntRange(tickAG_NereidPocketPlane, tickAG_NereidPocketPlane);
            int tickAG_DestroyPocketPlane = Convert.ToInt32(abilityAG_DestroyPocketPlane * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_DestroyPocketPlane").cooldownTicksRange = new IntRange(tickAG_DestroyPocketPlane, tickAG_DestroyPocketPlane);
            int tickAG_TeleportItemsPocketPlane = Convert.ToInt32(abilityAG_TeleportItemsPocketPlane * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_TeleportItemsPocketPlane").cooldownTicksRange = new IntRange(tickAG_TeleportItemsPocketPlane, tickAG_TeleportItemsPocketPlane);
            //Projectiles
            int tickAG_Zap = Convert.ToInt32(abilityAG_Zap * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_Zap").cooldownTicksRange = new IntRange(tickAG_Zap, tickAG_Zap);
            int tickAG_GreaterFireSpew = Convert.ToInt32(abilityAG_GreaterFireSpew * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_GreaterFireSpew").cooldownTicksRange = new IntRange(tickAG_GreaterFireSpew, tickAG_GreaterFireSpew);
            int tickAG_GreaterAcidicVomit = Convert.ToInt32(abilityAG_GreaterAcidicVomit * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_GreaterAcidicVomit").cooldownTicksRange = new IntRange(tickAG_GreaterAcidicVomit, tickAG_GreaterAcidicVomit);
            int tickAG_PetrifyingGaze = Convert.ToInt32(abilityAG_PetrifyingGaze * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_PetrifyingGaze").cooldownTicksRange = new IntRange(tickAG_PetrifyingGaze, tickAG_PetrifyingGaze);
            int tickAG_Web = Convert.ToInt32(abilityAG_Web * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_Web").cooldownTicksRange = new IntRange(tickAG_Web, tickAG_Web);
            int tickAG_InsanityBlast = Convert.ToInt32(abilityAG_InsanityBlast * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_InsanityBlast").cooldownTicksRange = new IntRange(tickAG_InsanityBlast, tickAG_InsanityBlast);
            int tickAG_SterilizingBreath = Convert.ToInt32(abilityAG_SterilizingBreath * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_SterilizingBreath").cooldownTicksRange = new IntRange(tickAG_SterilizingBreath, tickAG_SterilizingBreath);
            int tickAG_BansheeScream = Convert.ToInt32(abilityAG_BansheeScream * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_BansheeScream").cooldownTicksRange = new IntRange(tickAG_BansheeScream, tickAG_BansheeScream);
            int tickAG_FreezingBreath = Convert.ToInt32(abilityAG_FreezingBreath * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_FreezingBreath").cooldownTicksRange = new IntRange(tickAG_FreezingBreath, tickAG_FreezingBreath);
            int tickAG_NoxiousBreath = Convert.ToInt32(abilityAG_NoxiousBreath * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_NoxiousBreath").cooldownTicksRange = new IntRange(tickAG_NoxiousBreath, tickAG_NoxiousBreath);
            // Stingers
            int tickAG_InsectStinger = Convert.ToInt32(abilityAG_InsectStinger * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_InsectStinger").cooldownTicksRange = new IntRange(tickAG_InsectStinger, tickAG_InsectStinger);
            int tickAG_InsectStingerEndogenes = Convert.ToInt32(abilityAG_InsectStingerEndogenes * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_InsectStingerEndogenes").cooldownTicksRange = new IntRange(tickAG_InsectStingerEndogenes, tickAG_InsectStingerEndogenes);
            int tickAG_ParasiticStinger = Convert.ToInt32(abilityAG_ParasiticStinger * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_ParasiticStinger").cooldownTicksRange = new IntRange(tickAG_ParasiticStinger, tickAG_ParasiticStinger);
            int tickAG_ParasiticStingerEndogenes = Convert.ToInt32(abilityAG_ParasiticStingerEndogenes * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_ParasiticStingerEndogenes").cooldownTicksRange = new IntRange(tickAG_ParasiticStingerEndogenes, tickAG_ParasiticStingerEndogenes);
            // Summons
            int tickAG_MinorSummon = Convert.ToInt32(abilityAG_MinorSummon * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_MinorSummon").cooldownTicksRange = new IntRange(tickAG_MinorSummon, tickAG_MinorSummon);
            int tickAG_Summon = Convert.ToInt32(abilityAG_Summon * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_Summon").cooldownTicksRange = new IntRange(tickAG_Summon, tickAG_Summon);
            int tickAG_MajorSummon = Convert.ToInt32(abilityAG_MajorSummon * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_MajorSummon").cooldownTicksRange = new IntRange(tickAG_MajorSummon, tickAG_MajorSummon);
            // Miscellaneous
            int tickAG_WingPoweredJump = Convert.ToInt32(abilityAG_WingPoweredJump * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_WingPoweredJump").cooldownTicksRange = new IntRange(tickAG_WingPoweredJump, tickAG_WingPoweredJump);
            int tickAG_UnstableMutation = Convert.ToInt32(abilityAG_UnstableMutation * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_UnstableMutation").cooldownTicksRange = new IntRange(tickAG_UnstableMutation, tickAG_UnstableMutation);
            int tickAG_InsectRally = Convert.ToInt32(abilityAG_InsectRally * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_InsectRally").cooldownTicksRange = new IntRange(tickAG_InsectRally, tickAG_InsectRally);
            int tickAG_UnstableMind = Convert.ToInt32(abilityAG_UnstableMind * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_UnstableMind").cooldownTicksRange = new IntRange(tickAG_UnstableMind, tickAG_UnstableMind);
            int tickAG_DevourBrains = Convert.ToInt32(abilityAG_DevourBrains * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_DevourBrains").cooldownTicksRange = new IntRange(tickAG_DevourBrains, tickAG_DevourBrains);
            int tickAG_GeneSyphon = Convert.ToInt32(abilityAG_GeneSyphon * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_GeneSyphon").cooldownTicksRange = new IntRange(tickAG_GeneSyphon, tickAG_GeneSyphon);
            int tickAG_TailGrapple = Convert.ToInt32(abilityAG_TailGrapple * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_TailGrapple").cooldownTicksRange = new IntRange(tickAG_TailGrapple, tickAG_TailGrapple);
            int tickAG_UnstableRegeneration = Convert.ToInt32(abilityAG_UnstableRegeneration * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_UnstableRegeneration").cooldownTicksRange = new IntRange(tickAG_UnstableRegeneration, tickAG_UnstableRegeneration);
            int tickAG_AdaptiveBiology = Convert.ToInt32(abilityAG_AdaptiveBiology * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_AdaptiveBiology").cooldownTicksRange = new IntRange(tickAG_AdaptiveBiology, tickAG_AdaptiveBiology);
            int tickAG_SuperAdaptiveBiology = Convert.ToInt32(abilityAG_SuperAdaptiveBiology * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_SuperAdaptiveBiology").cooldownTicksRange = new IntRange(tickAG_SuperAdaptiveBiology, tickAG_SuperAdaptiveBiology);
            int tickAG_PsychicAbsorption = Convert.ToInt32(abilityAG_PsychicAbsorption * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_PsychicAbsorption").cooldownTicksRange = new IntRange(tickAG_PsychicAbsorption, tickAG_PsychicAbsorption);
            int tickAG_SpeedBurst = Convert.ToInt32(abilityAG_SpeedBurst * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("AG_SpeedBurst").cooldownTicksRange = new IntRange(tickAG_SpeedBurst, tickAG_SpeedBurst);
        }
        public static void ResetSettingsAlphaGenes()
        {
            //Explosions
            abilityAG_AcidicDetonation = 12; //Hours
            abilityAG_Detonation = 12; //Hours
                                       //Mechanitor
            abilityAG_MechConversion = 24; //Hours
            abilityAG_BandwidthLoop = 24; //Hours
            abilityAG_SummonTempBandwidth = 70; //Days
            abilityAG_SummonMilitor = 24; //Hours
            abilityAG_SummonTesseron = 24; //Hours
            abilityAG_SummonCentipede = 24; //Hours
                                            //Mineral
            abilityAG_ReactiveArmourA = 5; //Seconds
            abilityAG_MineralOverdriveA = 24; //Hours
            abilityAG_MineralShock = 1; //Seconds
                                        //PocketPlane
            abilityAG_NereidPocketPlane = 15; //Seconds
            abilityAG_DestroyPocketPlane = 15; //Seconds
            abilityAG_TeleportItemsPocketPlane = 5; //Seconds
                                                    //Projectiles
            abilityAG_Zap = 6; //Hours
            abilityAG_GreaterFireSpew = 5; //Days
            abilityAG_GreaterAcidicVomit = 5; //Days
            abilityAG_PetrifyingGaze = 5; //Days
            abilityAG_Web = 3; //Hours
            abilityAG_InsanityBlast = 24; //Hours
            abilityAG_SterilizingBreath = 24; //Hours
            abilityAG_BansheeScream = 12; //Hours
            abilityAG_FreezingBreath = 24; //Hours
            abilityAG_NoxiousBreath = 24; //Hours
                                          //Stingers
            abilityAG_InsectStinger = 4; //Days
            abilityAG_InsectStingerEndogenes = 4; //Days
            abilityAG_ParasiticStinger = 2; //Days
            abilityAG_ParasiticStingerEndogenes = 2; //Days
                                                     //Summons
            abilityAG_MinorSummon = 24; //Hours
            abilityAG_Summon = 24; //Hours
            abilityAG_MajorSummon = 24; //Hours
                                        //Misc
            abilityAG_WingPoweredJump = 40; //Seconds
            abilityAG_UnstableMutation = 24; //Hours
            abilityAG_InsectRally = 12; //Hours
            abilityAG_UnstableMind = 24; //Hours
            abilityAG_DevourBrains = 24; //Hours
            abilityAG_GeneSyphon = 24; //Hours
            abilityAG_TailGrapple = 100; //Seconds
            abilityAG_UnstableRegeneration = 4; //Hours
            abilityAG_AdaptiveBiology = 24; //Hours
            abilityAG_SuperAdaptiveBiology = 24; //Hours
            abilityAG_PsychicAbsorption = 5; //Seconds
            abilityAG_SpeedBurst = 5; //Hours

            ApplySettingAlphaGenes();
        }
    }
}
