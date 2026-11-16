using System;
using System.Collections.Generic;
using System.Text;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Reflection;

using RimWorld;
//using UnityEngine;
using Verse;
using HarmonyLib;
using LudeonTK;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine; 


namespace NepCaravanGhouls
{
    [StaticConstructorOnStartup]
    public static class NepCaravanGhouls
    {


        static NepCaravanGhouls() //our constructor
        {
            Log.Message("NepCaravanGhouls Loaded");

            Harmony harmony = new Harmony("nep.caravanghouls");
            harmony.PatchAll();

            Log.Message("NepCaravanGhouls Patching Complete");
            Log.Message("NepCaravanGhouls: bool: " + LoadedModManager.GetMod<NepCaravanGhoulsMod>().GetSettings<NepCaravanGhoulsSettings>().overrideGhoulCarryWeight.ToString());
            Log.Message("NepCaravanGhouls: float: " + LoadedModManager.GetMod<NepCaravanGhoulsMod>().GetSettings<NepCaravanGhoulsSettings>().ghoulCarryWeightModifier.ToString());

        }
    }

    /// <summary>
    /// Mod settings stuff copied from https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    

    public class NepCaravanGhoulsSettings : ModSettings
    {

        /// The settings our mod has.
        public  bool overrideGhoulCarryWeight;
        public  float  ghoulCarryWeightModifier = 1f;
        public  bool applyVFEFix;

        // The part that writes our settings to file. Note that saving is by ref.
        public override void ExposeData()
        {
            Scribe_Values.Look(ref overrideGhoulCarryWeight, "NepCaravanGhoulsBool");
            Scribe_Values.Look(ref ghoulCarryWeightModifier, "NepCaravanGhoulsFloat", 1f);
            base.ExposeData();
        }
    }

    public class NepCaravanGhoulsMod : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        NepCaravanGhoulsSettings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public NepCaravanGhoulsMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<NepCaravanGhoulsSettings>();
        }

        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);

            //Enable Weight override
            //listingStandard.CheckboxLabeled("NEP_CG_Settings_overrideGhoulCarryWeight".Translate(), ref settings.overrideGhoulCarryWeight, "NEP_CG_Settings_overrideGhoulCarryWeightDesc".Translate());
            // Why bother with an enable text box when the slider can just be set to 100%?  

            // But this does need some explaining
            listingStandard.Label("NEP_CG_Explain".Translate());
            listingStandard.Gap(12f);

            //  slider for override amount
            Text.Anchor = TextAnchor.MiddleCenter;
            listingStandard.Label(settings.ghoulCarryWeightModifier.ToStringPercent() + " (" + (settings.ghoulCarryWeightModifier * 35.0f).ToString("0.0") + "kg)");
            Text.Anchor = TextAnchor.UpperLeft;
            listingStandard.Gap(12f);
            settings.ghoulCarryWeightModifier = Widgets.HorizontalSlider(listingStandard.GetRect(20f, 1f), settings.ghoulCarryWeightModifier, 0f, 30f, false, null, null, null, 0.1f);
            listingStandard.Gap(12f);

            // Tickbox for VFE double-apply issue. 
            listingStandard.CheckboxLabeled("NEP_CG_Settings_ApplyVFEFix".Translate(), ref settings.applyVFEFix, "NEP_CG_Settings_ApplyVFEFixDesc".Translate());



            //a reset button
            Text.Anchor = TextAnchor.MiddleCenter;
            listingStandard.Gap(48f);
            if (listingStandard.ButtonText("NEP_CG_Reset".Translate(),null,0.25f))
            {
                settings.overrideGhoulCarryWeight = false;
                settings.ghoulCarryWeightModifier = 1f;
                settings.applyVFEFix = false;
            }

            Text.Anchor = TextAnchor.UpperLeft;
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory()
        {

            return "NEP_CG_ModName".Translate();
        }
    }






    /// <summary>
    /// And now for the actual patches
    /// </summary>



    [HarmonyPatch]
    public static class NepCaravanGhoulsEnablePatch
    {
        [HarmonyPatch(typeof(MassUtility), nameof(MassUtility.CanEverCarryAnything))]
        [HarmonyPrefix]
        public static bool CanEverCarryAnything(ref bool __result, Pawn p)
        {
            // Original Function code:
            // return (p.RaceProps.ToolUser && !p.DevelopmentalStage.Baby() && !p.IsMutant) || p.RaceProps.packAnimal;

            //Destructive Prefix patch:
            __result = (p.RaceProps.ToolUser && !p.DevelopmentalStage.Baby()) || p.RaceProps.packAnimal;
            return false;



        }

    }

    [HarmonyPatch]
    public static class NepCaravanGhoulsCapacityPatch
    {
        [HarmonyPatch(typeof(RimWorld.MassUtility), nameof(MassUtility.Capacity))]
        [HarmonyPostfix]
        public static void Capacity(ref float __result, Pawn p, StringBuilder explanation = null)
        {
            
            float adjustmentAmount = LoadedModManager.GetMod<NepCaravanGhoulsMod>().GetSettings<NepCaravanGhoulsSettings>().ghoulCarryWeightModifier;
            bool applyVFEFix = LoadedModManager.GetMod<NepCaravanGhoulsMod>().GetSettings<NepCaravanGhoulsSettings>().applyVFEFix;

            // If the multiplier is going to be applied twice, this will make it work out
            if (applyVFEFix) {
                adjustmentAmount= (float)Math.Sqrt(adjustmentAmount);
            }

            if (p.IsMutant)
            {
                __result *= adjustmentAmount;
            }

        }

    }



}
