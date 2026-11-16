using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace VFECore
{
	// Token: 0x0200025D RID: 605
	[HarmonyPatch(typeof(StatWorker), "GetBaseValueFor")]
	public static class StatWorker_GetBaseValueFor_Patch
	{
		// Token: 0x060007AD RID: 1965 RVA: 0x0003574C File Offset: 0x0003394C
		public static void Postfix(StatDef ___stat, StatRequest request, ref float __result)
		{
			Pawn pawn;
			bool flag;
			if (___stat == VFEDefOf.VEF_MassCarryCapacity)
			{
				pawn = (request.Thing as Pawn);
				flag = (pawn != null);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			if (flag2)
			{
				MassUtility_Capacity_Patch.includeStatWorkerResult = false;
				__result += MassUtility.Capacity(pawn, null);
				MassUtility_Capacity_Patch.includeStatWorkerResult = true;
			}
		}
	}
}
