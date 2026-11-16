using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace VFECore
{
	// Token: 0x0200025E RID: 606
	[HarmonyPatch(typeof(MassUtility), "Capacity")]
	public static class MassUtility_Capacity_Patch
	{
		// Token: 0x060007AE RID: 1966 RVA: 0x00035794 File Offset: 0x00033994
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> codeInstructions)
		{
			foreach (CodeInstruction code in codeInstructions)
			{
				yield return code;
				bool flag = code.opcode == OpCodes.Stloc_0;
				if (flag)
				{
					yield return new CodeInstruction(OpCodes.Ldarg_0, null);
					yield return new CodeInstruction(OpCodes.Ldloca_S, 0);
					yield return new CodeInstruction(OpCodes.Call, MassUtility_Capacity_Patch.SetCarryCapacityInfo);
				}
				code = null;
			}
			IEnumerator<CodeInstruction> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x000357A4 File Offset: 0x000339A4
		public static void SetCarryCapacity(Pawn p, ref float __result)
		{
			bool flag = MassUtility_Capacity_Patch.includeStatWorkerResult;
			if (flag)
			{
				__result = p.GetStatValue(VFEDefOf.VEF_MassCarryCapacity, true, -1);
			}
		}

		// Token: 0x04000550 RID: 1360
		public static bool includeStatWorkerResult = true;

		// Token: 0x04000551 RID: 1361
		public static MethodInfo SetCarryCapacityInfo = AccessTools.Method(typeof(MassUtility_Capacity_Patch), "SetCarryCapacity", null, null);
	}
}
