using RimWorld;
using System.Collections.Generic;
using Verse;

namespace SunLampHonesty
{
    public class CompSunLampAutoBasin : ThingComp
    {
        struct Blueprint
        {
            public IntVec3 position;
            public Rot4 rotation;
        }

        private static Blueprint[] blueprintsClassic = new[]
        {
            new Blueprint() { position = IntVec3.North * 2, rotation = Rot4.North },
            new Blueprint() { position = IntVec3.North * 2 + IntVec3.East, rotation = Rot4.North },
            new Blueprint() { position = IntVec3.North * 3 + IntVec3.East * 2, rotation = Rot4.North },
            new Blueprint() { position = IntVec3.North * 2 + IntVec3.East * 3, rotation = Rot4.North },
            new Blueprint() { position = IntVec3.North * 2 + IntVec3.East * 4, rotation = Rot4.North },
            new Blueprint() { position = IntVec3.East * 5, rotation = Rot4.North },
            new Blueprint() { position = IntVec3.East * 2, rotation = Rot4.East },
            new Blueprint() { position = IntVec3.East * 2 + IntVec3.South, rotation = Rot4.East },
            new Blueprint() { position = IntVec3.East * 3 + IntVec3.South * 2, rotation = Rot4.East },
            new Blueprint() { position = IntVec3.East * 2 + IntVec3.South * 3, rotation = Rot4.East },
            new Blueprint() { position = IntVec3.East * 2 + IntVec3.South * 4, rotation = Rot4.East },
            new Blueprint() { position = IntVec3.South * 5, rotation = Rot4.East },
            new Blueprint() { position = IntVec3.South * 2, rotation = Rot4.South },
            new Blueprint() { position = IntVec3.South * 2 + IntVec3.West, rotation = Rot4.South },
            new Blueprint() { position = IntVec3.South * 3 + IntVec3.West * 2, rotation = Rot4.South },
            new Blueprint() { position = IntVec3.South * 2 + IntVec3.West * 3, rotation = Rot4.South },
            new Blueprint() { position = IntVec3.South * 2 + IntVec3.West * 4, rotation = Rot4.South },
            new Blueprint() { position = IntVec3.West * 5, rotation = Rot4.South },
            new Blueprint() { position = IntVec3.West * 2, rotation = Rot4.West },
            new Blueprint() { position = IntVec3.West * 2 + IntVec3.North, rotation = Rot4.West },
            new Blueprint() { position = IntVec3.West * 3 + IntVec3.North * 2, rotation = Rot4.West },
            new Blueprint() { position = IntVec3.West * 2 + IntVec3.North * 3, rotation = Rot4.West },
            new Blueprint() { position = IntVec3.West * 2 + IntVec3.North * 4, rotation = Rot4.West },
            new Blueprint() { position = IntVec3.North * 5, rotation = Rot4.West }
        };

        private void PlaceBlueprints()
        {
            bool blueprintPlaced = false;
            ThingDef hydroponicsDef = ThingDef.Named("HydroponicsBasin");
            Blueprint[] blueprintsToUse = blueprintsClassic;
            foreach (Blueprint blueprint in blueprintsToUse)
            {
                if (GenConstruct.CanPlaceBlueprintAt(hydroponicsDef, parent.Position + blueprint.position, blueprint.rotation, parent.Map).Accepted)
                {
                    GenConstruct.PlaceBlueprintForBuild(hydroponicsDef, parent.Position + blueprint.position, parent.Map, blueprint.rotation, Faction.OfPlayer, null);
                    blueprintPlaced = true;
                }
            }
            if (!blueprintPlaced)
            {
                Messages.Message("SunLampHonesty_NowhereToPlaceBlueprints".Translate(), MessageTypeDefOf.RejectInput, false);
            }
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            ThingDef hydroponicsDef = ThingDef.Named("HydroponicsBasin");
            if (hydroponicsDef.IsResearchFinished || DebugSettings.godMode)
            {
                Designator_Build designator = BuildCopyCommandUtility.FindAllowedDesignator(hydroponicsDef, true);
                yield return new Command_Action
                {
                    defaultLabel = "SunLampHonesty_CommandBuildBasins".Translate(),
                    defaultDesc = "SunLampHonesty_CommandBuildBasinsDesc".Translate(),
                    icon = designator.icon,
                    action = PlaceBlueprints,
                    iconDrawScale = designator.iconDrawScale,
                    iconProportions = designator.iconProportions
                };
            }
        }
    }
}
