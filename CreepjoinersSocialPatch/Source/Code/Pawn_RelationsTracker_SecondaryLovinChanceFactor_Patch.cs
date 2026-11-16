using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Verse;

namespace Microus.Patches
{
    [HarmonyPatch(typeof(Pawn_RelationsTracker), "SecondaryLovinChanceFactor", typeof(Pawn))]
    class Pawn_RelationsTracker_SecondaryLovinChanceFactor_Patch
    {
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var pawnField = AccessTools.Field(typeof(Pawn_RelationsTracker), "pawn");
            if (pawnField == null)
            {
                Log.Error("[CreepJoinersRomancePatch]: Fail to find field 'pawn' in Pawn_RelationsTracker");
            }
            var defField = AccessTools.Field(typeof(Thing), "def");
            if (defField == null)
            {
                Log.Error("[CreepJoinersRomancePatch]: Fail to find field 'def' in Pawn");
            }

            var instructionsList = instructions.ToList();
            if (instructionsList.Count > 6)
            {
                if (instructionsList[0].opcode == OpCodes.Ldarg_0 && instructionsList[1].Is(OpCodes.Ldfld, pawnField) && instructionsList[2].Is(OpCodes.Ldfld, defField))
                {
                    if (instructionsList[3].opcode == OpCodes.Ldarg_1 && instructionsList[4].Is(OpCodes.Ldfld, defField) && instructionsList[5].opcode == OpCodes.Bne_Un_S)
                    {
                        try
                        {
                            var cachedlabel = instructionsList[5].operand;
                            instructionsList.RemoveRange(0, 6);
                            var temp = new CodeInstruction(OpCodes.Brfalse_S);
                            temp.operand = cachedlabel;
                            instructionsList.InsertRange(0, new List<CodeInstruction>()
                            {
                                 new CodeInstruction(OpCodes.Ldarg_0),
                                 new CodeInstruction(OpCodes.Ldfld, pawnField),
                                 new CodeInstruction(OpCodes.Ldarg_1),
                                 new CodeInstruction(OpCodes.Call, ((Func<Pawn, Pawn, bool>)PatchFunctions.CheckBothHumanLike).Method),
                                 temp
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        Log.Message("[CreepJoinersRomancePatch]: Pawn_RelationsTracker.SecondaryLovinChanceFactor Patched");
                    }
                }
            }
            return instructionsList.AsEnumerable();
        }
    }
}
