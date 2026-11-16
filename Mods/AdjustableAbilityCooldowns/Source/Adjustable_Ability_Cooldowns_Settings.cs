using Adjustable_Ability_Cooldowns.Utilities;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns
{
    public class Adjustable_Ability_Cooldowns_Settings : ModSettings
    {
        public override void ExposeData()
        {
            base.ExposeData();
            Ideology_Setting.ExposeDataIdeology();
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                Biotech_Setting.ExposeDataBiotech();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                Anomaly_Settings.ExposeDataAnomaly();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.odyssey") != null)
            {
                Odyssey_Settings.ExposeDataOdyssey();
            }
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                AlphaGene_Settings.ExposeDataAlphaGenes();
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                VFETribals_Settings.ExposeDataVFETribals();
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                VME_Settings.ExposeDataVME();
            }

        }
    }

    public class Adjustable_Ability_Cooldowns : Mod
    {
        public static Adjustable_Ability_Cooldowns_Settings settings;
        private Vector2 scrollPosition = new Vector2(0f, 0f);
        public float scrollViewHeight;
        //DLC
        public static bool SectionIdeology = false;
        public static bool SectionBiotech = false;
        public static bool SectionAnomaly = false;
        public static bool SectionOdyssey = false;
        //Mods
        public static bool SectionAlphaGenes = false;
        public static bool SectionVFETribals = false;
        public static bool SectionVME = false;

        public Adjustable_Ability_Cooldowns(ModContentPack content) : base(content)
        {
            settings = GetSettings<Adjustable_Ability_Cooldowns_Settings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            GUI.BeginGroup(inRect);
            Listing_Standard options = new Listing_Standard();
            Rect viewRect = new Rect(0f, 0f, inRect.width - 16f, scrollViewHeight + 50f);

            options.BeginScrollViewEx(inRect, ref scrollPosition, viewRect);

            //DLC
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.ideology") != null)
            {
                if (SectionIdeology)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;

                if (options.ButtonText("Ideology"))
                {
                    SectionIdeology = !SectionIdeology;
                }
                GUI.color = Color.white;

                if (SectionIdeology)
                {
                    Ideology_Setting.DrawIdeology(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                if (SectionBiotech)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Biotech"))
                {
                    SectionBiotech = !SectionBiotech;
                }
                GUI.color = Color.white;

                if (SectionBiotech)
                {
                    Biotech_Setting.DrawBiotech(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                if (SectionAnomaly)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Anomaly"))
                {
                    SectionAnomaly = !SectionAnomaly;
                }
                GUI.color = Color.white;

                if (SectionAnomaly)
                {
                    Anomaly_Settings.DrawAnomaly(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.odyssey") != null)
            {
                if (SectionOdyssey)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Odyssey"))
                {
                    SectionOdyssey = !SectionOdyssey;
                }
                GUI.color = Color.white;

                if (SectionOdyssey)
                {
                    Odyssey_Settings.DrawOdyssey(options);
                }
            }
            //Mods
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                if (SectionAlphaGenes)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("AlphaGenes"))
                {
                    SectionAlphaGenes = !SectionAlphaGenes;
                }
                GUI.color = Color.white;

                if (SectionAlphaGenes)
                {
                    AlphaGene_Settings.DrawAlphaGenes(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                if (SectionVFETribals)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Vanilla Factions Expanded - Tribals"))
                {
                    SectionVFETribals = !SectionVFETribals;
                }
                GUI.color = Color.white;

                if (SectionVFETribals)
                {
                    VFETribals_Settings.DrawVFETribals(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                if (SectionVME)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Vanilla Ideology Expanded - Memes and Structures"))
                {
                    SectionVME = !SectionVME;
                }
                GUI.color = Color.white;

                if (SectionVME)
                {
                    VME_Settings.DrawVME(options);
                }
            }

            options.EndScrollView(ref viewRect);
            scrollViewHeight = viewRect.height;
            GUI.EndGroup();

            //Save settings
            GUI.color = Color.green;
            if (Widgets.ButtonText(inRect.BottomPart(0.1f).LeftPart(0.1f), "Apply All Settings", true, true, true))
            {
                Adjustable_Ability_Cooldowns.ApplySettings();
                Messages.Message("Applied all settings", MessageTypeDefOf.NeutralEvent);

            }
            //Reset settings
            GUI.color = Color.red;
            if (Widgets.ButtonText(inRect.BottomPart(0.1f).RightPart(0.1f), "Reset All Settings", true, true, true))
            {
                Adjustable_Ability_Cooldowns.ResetSettings();
                Messages.Message("Reset all settings", MessageTypeDefOf.NeutralEvent);
            }
            GUI.color = Color.white;

        }

        private static void ApplySettings()
        {
            Ideology_Setting.ApplySettingIdeology();
            //DLC
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                Biotech_Setting.ApplySettingBiotech();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                Anomaly_Settings.ApplySettingAnomaly();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.odyssey") != null)
            {
                Odyssey_Settings.ApplySettingOdyssey();
            }
            //Mods
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                AlphaGene_Settings.ApplySettingAlphaGenes();
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                VFETribals_Settings.ApplySettingVFETribals();
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                VME_Settings.ApplySettingVME();
            }
        }

        private static void ResetSettings()
        {
            Ideology_Setting.ResetSettingsIdeology();
            //DLC
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                Biotech_Setting.ResetSettingsBiotech();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                Anomaly_Settings.ResetSettingsAnomaly();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.odyssey") != null)
            {
                Odyssey_Settings.ResetSettingsOdyssey();
            }
            //Mod
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                AlphaGene_Settings.ResetSettingsAlphaGenes();
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                VFETribals_Settings.ResetSettingsVFETribals();
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                VME_Settings.ResetSettingsVME();
            }
        }

        public override string SettingsCategory()
        {
            return "Adjustable_Ability_Cooldowns".Translate();
        }

        [StaticConstructorOnStartup]
        internal static class StartupAdjustable_Ability_Cooldowns
        {
            static StartupAdjustable_Ability_Cooldowns()
            {
                ApplySettings();
                Harmony harmony = new Harmony("KipsMods.AdjustableAbilityCooldowns");
                harmony.PatchAll();
            }
        }
    }

}