using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace MultiSelectDrugs
{
    public class MultiSelectDrugsSettings : ModSettings
    {
        public Dictionary<string, bool> enabledDrugs = new Dictionary<string, bool>();
        public bool draftedOnly = true;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref enabledDrugs, "enabledDrugs", LookMode.Value, LookMode.Value);
            Scribe_Values.Look(ref draftedOnly, "draftedOnly", true);

            if (enabledDrugs == null)
                enabledDrugs = new Dictionary<string, bool>();

            foreach (var def in Pawn_GetGizmos_Patch.DrugItems)
            {
                if (!enabledDrugs.ContainsKey(def.defName))
                    enabledDrugs[def.defName] = true;
            }

            foreach (var def in Pawn_GetGizmos_Patch.MealItems)
            {
                if (!enabledDrugs.ContainsKey(def.defName))
                    enabledDrugs[def.defName] = true;
            }

            // Raw food disabled by default
            foreach (var def in Pawn_GetGizmos_Patch.RawFoodItems)
            {
                if (!enabledDrugs.ContainsKey(def.defName))
                    enabledDrugs[def.defName] = false;
            }
        }
    }

    public class MultiSelectDrugsMod : Mod
    {
        public static MultiSelectDrugsSettings settings;
        private Vector2 scrollPosition = Vector2.zero;

        public MultiSelectDrugsMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<MultiSelectDrugsSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            float contentHeight = 100f + (Pawn_GetGizmos_Patch.AllItems.Count * 26f) + 300f;
            Rect viewRect = new Rect(0f, 0f, inRect.width - 20f, contentHeight);

            Widgets.BeginScrollView(inRect, ref scrollPosition, viewRect);

            var listingStandard = new Listing_Standard();
            listingStandard.Begin(viewRect);

            listingStandard.Gap(12f);

            listingStandard.CheckboxLabeled("GroupActions.DraftedOnly".Translate(), ref settings.draftedOnly,
                "GroupActions.DraftedOnlyDesc".Translate());

            listingStandard.Gap(12f);

            if (listingStandard.ButtonText("GroupActions.EnableAll".Translate()))
            {
                foreach (var def in Pawn_GetGizmos_Patch.AllItems)
                    settings.enabledDrugs[def.defName] = true;
            }

            if (listingStandard.ButtonText("GroupActions.DisableAll".Translate()))
            {
                foreach (var def in Pawn_GetGizmos_Patch.AllItems)
                    settings.enabledDrugs[def.defName] = false;
            }

            // Drugs section
            listingStandard.Gap(12f);
            listingStandard.Label("GroupActions.SectionDrugs".Translate());
            listingStandard.Gap(4f);

            if (listingStandard.ButtonText("GroupActions.EnableAllDrugs".Translate()))
            {
                foreach (var def in Pawn_GetGizmos_Patch.DrugItems)
                    settings.enabledDrugs[def.defName] = true;
            }

            if (listingStandard.ButtonText("GroupActions.DisableAllDrugs".Translate()))
            {
                foreach (var def in Pawn_GetGizmos_Patch.DrugItems)
                    settings.enabledDrugs[def.defName] = false;
            }

            listingStandard.Gap(4f);

            DrawItemList(listingStandard, Pawn_GetGizmos_Patch.DrugItems);

            // Meals section
            listingStandard.Gap(12f);
            listingStandard.Label("GroupActions.SectionMeals".Translate());
            listingStandard.Gap(4f);

            if (listingStandard.ButtonText("GroupActions.EnableAllMeals".Translate()))
            {
                foreach (var def in Pawn_GetGizmos_Patch.MealItems)
                    settings.enabledDrugs[def.defName] = true;
            }

            if (listingStandard.ButtonText("GroupActions.DisableAllMeals".Translate()))
            {
                foreach (var def in Pawn_GetGizmos_Patch.MealItems)
                    settings.enabledDrugs[def.defName] = false;
            }

            listingStandard.Gap(4f);

            DrawItemList(listingStandard, Pawn_GetGizmos_Patch.MealItems);

            // Raw food section
            listingStandard.Gap(12f);
            listingStandard.Label("GroupActions.SectionRawFood".Translate());
            listingStandard.Gap(4f);

            if (listingStandard.ButtonText("GroupActions.EnableAllRawFood".Translate()))
            {
                foreach (var def in Pawn_GetGizmos_Patch.RawFoodItems)
                    settings.enabledDrugs[def.defName] = true;
            }

            if (listingStandard.ButtonText("GroupActions.DisableAllRawFood".Translate()))
            {
                foreach (var def in Pawn_GetGizmos_Patch.RawFoodItems)
                    settings.enabledDrugs[def.defName] = false;
            }

            listingStandard.Gap(4f);

            DrawItemList(listingStandard, Pawn_GetGizmos_Patch.RawFoodItems);

            listingStandard.End();
            Widgets.EndScrollView();
        }

        private void DrawItemList(Listing_Standard listing, List<ThingDef> items)
        {
            foreach (var def in items)
            {
                var currentValue = settings.enabledDrugs.TryGetValue(def.defName, out bool enabled) ? enabled : true;
                var rect = listing.GetRect(24f);

                var iconRect = new Rect(rect.x, rect.y, 24f, 24f);
                Widgets.DrawTextureFitted(iconRect, def.uiIcon ?? BaseContent.BadTex, 1f);

                var labelRect = new Rect(rect.x + 30f, rect.y, rect.width - 30f, rect.height);
                bool newValue = currentValue;
                Widgets.CheckboxLabeled(labelRect, def.LabelCap, ref newValue);

                if (newValue != currentValue)
                    settings.enabledDrugs[def.defName] = newValue;
            }
        }

        public override string SettingsCategory()
        {
            return "Group Actions";
        }
    }

    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("MultiSelectDrugs.Mod");
            harmony.PatchAll();

            Pawn_GetGizmos_Patch.BuildItemLists();
        }
    }

    [HarmonyPatch(typeof(Pawn), "GetGizmos")]
    public static class Pawn_GetGizmos_Patch
    {
        public static List<ThingDef> DrugItems = new List<ThingDef>();
        public static List<ThingDef> MealItems = new List<ThingDef>();
        public static List<ThingDef> RawFoodItems = new List<ThingDef>();
        public static List<ThingDef> AllItems = new List<ThingDef>();

        private static readonly Texture2D DrugTex = ContentFinder<Texture2D>.Get("UI/Commands/TakeDrug");

        private static readonly FoodTypeFlags RawFoodTypes =
            FoodTypeFlags.VegetableOrFruit | FoodTypeFlags.AnimalProduct | FoodTypeFlags.Meat;

        public static void BuildItemLists()
        {
            DrugItems = DefDatabase<ThingDef>.AllDefsListForReading
                .Where(t => t.ingestible != null && t.ingestible.drugCategory != DrugCategory.None)
                .OrderBy(t => t.label)
                .ToList();

            var allFood = DefDatabase<ThingDef>.AllDefsListForReading
                .Where(t => t.ingestible != null
                    && t.ingestible.drugCategory == DrugCategory.None
                    && (t.ingestible.foodType & (FoodTypeFlags.Meal | RawFoodTypes)) != 0
                    && t.ingestible.preferability > FoodPreferability.NeverForNutrition)
                .OrderBy(t => t.label)
                .ToList();

            MealItems = allFood
                .Where(t => (t.ingestible.foodType & FoodTypeFlags.Meal) != 0)
                .ToList();

            RawFoodItems = allFood
                .Where(t => (t.ingestible.foodType & FoodTypeFlags.Meal) == 0
                    && (t.ingestible.foodType & RawFoodTypes) != 0)
                .ToList();

            AllItems = DrugItems.Concat(MealItems).Concat(RawFoodItems).ToList();
        }

        public static void Postfix(Pawn __instance, ref IEnumerable<Gizmo> __result)
        {
            var selectedPawns = Find.Selector.SelectedPawns;
            if (selectedPawns == null || selectedPawns.Count <= 1 || !selectedPawns.Contains(__instance))
                return;

            if (selectedPawns.First() != __instance)
                return;

            var playerPawns = selectedPawns.Where(p => p.Faction != null && p.Faction.IsPlayer && p.IsColonist).ToList();
            if (playerPawns.Count == 0)
                return;

            if (MultiSelectDrugsMod.settings?.draftedOnly == true && !playerPawns.All(p => p.Drafted))
                return;

            var gizmos = __result.ToList();

            var availableDrugs = BuildAvailable(selectedPawns, DrugItems);
            var availableMeals = BuildAvailable(selectedPawns, MealItems);
            var availableRaw = BuildAvailable(selectedPawns, RawFoodItems);

            AddGizmos(gizmos, availableDrugs, selectedPawns, isFood: false);
            AddGizmos(gizmos, availableMeals, selectedPawns, isFood: true);
            AddGizmos(gizmos, availableRaw, selectedPawns, isFood: true);

            __result = gizmos;
        }

        private static List<(ThingDef def, List<Pawn> pawns)> BuildAvailable(List<Pawn> selectedPawns, List<ThingDef> itemList)
        {
            var result = new List<(ThingDef, List<Pawn>)>();
            foreach (var def in itemList)
            {
                if (MultiSelectDrugsMod.settings?.enabledDrugs?.TryGetValue(def.defName, out bool enabled) == true && !enabled)
                    continue;

                var pawnsWithItem = GetPawnsWithItem(selectedPawns, def);
                if (pawnsWithItem.Count == 0)
                    continue;

                result.Add((def, pawnsWithItem));
            }
            return result;
        }

        private static void AddGizmos(List<Gizmo> gizmos, List<(ThingDef def, List<Pawn> pawns)> available,
            List<Pawn> selectedPawns, bool isFood)
        {
            if (available.Count == 0)
                return;

            if (available.Count == 1)
            {
                var (def, pawns) = available[0];
                gizmos.Add(CreateSingleGizmo(pawns, selectedPawns, def, isFood));
            }
            else
            {
                gizmos.Add(CreateCombinedGizmo(available, selectedPawns, isFood));
            }
        }

        private static List<Pawn> GetPawnsWithItem(List<Pawn> selectedPawns, ThingDef def)
        {
            var result = new List<Pawn>();
            foreach (var pawn in selectedPawns)
            {
                if (pawn.Faction != null && pawn.Faction.IsPlayer && pawn.IsColonist &&
                    pawn.inventory?.innerContainer?.Any(thing => thing.def == def) == true)
                {
                    result.Add(pawn);
                }
            }
            return result;
        }

        private static void ExecuteIngest(List<Pawn> pawns, ThingDef def)
        {
            foreach (var pawn in pawns)
            {
                var item = pawn.inventory.innerContainer.FirstOrDefault(t => t.def == def);
                if (item != null && (item.def.IsIngestible || item.def.ingestible != null))
                {
                    pawn.inventory.innerContainer.TryDrop(item, pawn.Position, pawn.Map,
                        ThingPlaceMode.Near, 1, out Thing dropped);

                    if (dropped != null)
                    {
                        var job = JobMaker.MakeJob(JobDefOf.Ingest, dropped);
                        job.count = 1;
                        pawn.jobs.TryTakeOrderedJob(job);
                    }
                }
            }
        }

        private static Command_Action CreateSingleGizmo(List<Pawn> pawns, List<Pawn> selectedPawns,
            ThingDef def, bool isFood)
        {
            var name = def.LabelCap;
            string labelKey = isFood ? "GroupActions.LabelFood" : "GroupActions.Label";
            string descAllKey = isFood ? "GroupActions.DescAllFood" : "GroupActions.DescAll";
            string descPartialKey = isFood ? "GroupActions.DescPartialFood" : "GroupActions.DescPartial";

            return new Command_Action
            {
                defaultLabel = labelKey.Translate(name, pawns.Count),
                defaultDesc = pawns.Count == selectedPawns.Count
                    ? descAllKey.Translate(pawns.Count, name)
                    : descPartialKey.Translate(pawns.Count, selectedPawns.Count, name),
                icon = def.uiIcon ?? BaseContent.BadTex,
                action = delegate () { ExecuteIngest(pawns, def); }
            };
        }

        private static Command_Action CreateCombinedGizmo(List<(ThingDef def, List<Pawn> pawns)> available,
            List<Pawn> selectedPawns, bool isFood)
        {
            string combinedLabelKey = isFood ? "GroupActions.CombinedLabelFood" : "GroupActions.CombinedLabel";
            string combinedDescKey = isFood ? "GroupActions.CombinedDescFood" : "GroupActions.CombinedDesc";
            string descAllKey = isFood ? "GroupActions.DescAllFood" : "GroupActions.DescAll";
            string descPartialKey = isFood ? "GroupActions.DescPartialFood" : "GroupActions.DescPartial";

            return new Command_Action
            {
                defaultLabel = combinedLabelKey.Translate(available.Count),
                defaultDesc = combinedDescKey.Translate(),
                icon = isFood ? (available[0].def.uiIcon ?? BaseContent.BadTex) : (DrugTex ?? BaseContent.BadTex),
                action = delegate ()
                {
                    var options = new List<FloatMenuOption>();
                    foreach (var (def, pawns) in available)
                    {
                        var name = def.LabelCap;
                        var label = pawns.Count == selectedPawns.Count
                            ? descAllKey.Translate(pawns.Count, name).ToString()
                            : descPartialKey.Translate(pawns.Count, selectedPawns.Count, name).ToString();

                        var capturedDef = def;
                        var capturedPawns = pawns;
                        options.Add(new FloatMenuOption(label, () => ExecuteIngest(capturedPawns, capturedDef),
                            def.uiIcon ?? BaseContent.BadTex, Color.white));
                    }
                    Find.WindowStack.Add(new FloatMenu(options));
                }
            };
        }
    }
}
