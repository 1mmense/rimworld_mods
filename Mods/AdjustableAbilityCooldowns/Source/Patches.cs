using Adjustable_Ability_Cooldowns.Utilities;
using HarmonyLib;
using RimWorld;
using System.Text;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns
{
    [HarmonyPatch(typeof(Precept_Ritual), "get_RepeatQualityPenalty")]
    internal class Patch_RepeatQualityPenalty
    {
        private static bool Prefix(Precept_Ritual __instance, ref float __result)
        {
            __result = Mathf.Lerp(Ideology_Setting.ritualPenalty * -1 / 100, 0f, __instance.TicksSinceLastPerformed / (60000f * Ideology_Setting.ritualCooldown));
            return false;
        }
    }

    [HarmonyPatch(typeof(Precept_Ritual), "TipMainPart")]
    internal class Patch_TipMainPart
    {
        private static string ColorizeWarning(TaggedString title)
        {
            return title.Resolve().Colorize(ColoredText.ThreatColor);
        }

        private static bool Prefix(Precept_Ritual __instance, ref string __result, StringBuilder ___tmpCompsDesc)
        {
            float ritualCooldown = Ideology_Setting.ritualCooldown;

            ___tmpCompsDesc.Clear();
            if (__instance.RepeatPenaltyActive)
            {
                float value = Mathf.RoundToInt(__instance.RepeatPenaltyProgress * ritualCooldown * 10f) / 10f;
                float value2 = Mathf.RoundToInt((1f - __instance.RepeatPenaltyProgress) * ritualCooldown * 10f) / 10f;
                ___tmpCompsDesc.AppendLine(ColorizeWarning("RitualRepeatPenaltyTip".Translate(ritualCooldown, value, __instance.RepeatQualityPenalty.ToStringPercent(), value2)));
                ___tmpCompsDesc.AppendLine();
            }
            if (!__instance.Description.NullOrEmpty())
            {
                ___tmpCompsDesc.Append(__instance.Description);
            }
            if (__instance.outcomeEffect != null)
            {
                StringBuilder stringBuilder = new StringBuilder(__instance.outcomeEffect.def.Description);
                if (!__instance.outcomeEffect.def.extraPredictedOutcomeDescriptions.NullOrEmpty<string>())
                {
                    foreach (string str in __instance.outcomeEffect.def.extraPredictedOutcomeDescriptions)
                    {
                        stringBuilder.Append(" " + str.Formatted(__instance.shortDescOverride ?? __instance.def.label));
                    }
                }
                if (__instance.attachableOutcomeEffect != null)
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.AppendLine();
                    }
                    stringBuilder.AppendInNewLine(__instance.attachableOutcomeEffect.DescriptionForRitualValidated(__instance));
                }
                if (stringBuilder.Length > 0)
                {
                    ___tmpCompsDesc.AppendLine();
                    ___tmpCompsDesc.AppendInNewLine(stringBuilder.ToString());
                }
            }
            __result = ___tmpCompsDesc.ToString();
            return false;
        }
    }
    [HarmonyPatch(typeof(Command_Ritual), "DrawIcon")]
    public class Patch_DrawIcon
    {
        private static void DrawIcon(Rect rect, Material buttonMat, GizmoRenderParms parms, Command_Ritual instance)
        {
            Texture badTex = instance.icon;
            if (badTex == null)
            {
                badTex = BaseContent.BadTex;
            }
            rect.position += new Vector2(instance.iconOffset.x * rect.size.x, instance.iconOffset.y * rect.size.y);
            if (!instance.Disabled || parms.lowLight)
            {
                GUI.color = instance.IconDrawColor;
            }
            else
            {
                GUI.color = instance.IconDrawColor.SaturationChanged(0f);
            }
            if (parms.lowLight)
            {
                GUI.color = GUI.color.ToTransparent(0.6f);
            }
            Widgets.DrawTextureFitted(rect, badTex, instance.iconDrawScale * 0.85f, instance.iconProportions, instance.iconTexCoords, instance.iconAngle, buttonMat);
            GUI.color = Color.white;
        }
        public static bool Prefix(Command_Ritual __instance, Rect rect, Material buttonMat, GizmoRenderParms parms, Precept_Ritual ___ritual, Texture2D ___CooldownBarTex, IntVec2 ___PenaltyIconSize)
        {
            float ritualCooldown = Ideology_Setting.ritualCooldown;
            Texture2D ___PenaltyArrowTex = ContentFinder<Texture2D>.Get("UI/Icons/Rituals/QualityPenalty");
            float ritualCooldownTicks = 60000f * ritualCooldown;

            Patch_DrawIcon.DrawIcon(rect, buttonMat, parms, __instance);
            if (___ritual.RepeatPenaltyActive)
            {
                float value = Mathf.InverseLerp(ritualCooldownTicks, 0f, ___ritual.TicksSinceLastPerformed);
                Widgets.FillableBar(rect.ContractedBy(1f), Mathf.Clamp01(value), ___CooldownBarTex, null, doBorder: false);
                Text.Font = GameFont.Tiny;
                Text.Anchor = TextAnchor.UpperCenter;
                float num = (float)(ritualCooldownTicks - ___ritual.TicksSinceLastPerformed) / 60000f;
                Widgets.Label(label: "PeriodDays".Translate((!(num >= 1f)) ? ((int)(num * 10f) / 10f) : Mathf.RoundToInt(num)), rect: rect);
                Text.Anchor = TextAnchor.UpperLeft;
                GUI.DrawTexture(new Rect(rect.xMax - ___PenaltyIconSize.x, rect.yMin + 4f, ___PenaltyIconSize.x, ___PenaltyIconSize.z), ___PenaltyArrowTex);
            }

            return false;
        }
    }

    [HarmonyPatch(typeof(Precept_Ritual), "get_RepeatPenaltyProgress")]
    internal class Patch_RepeatPenaltyProgress
    {
        private static bool Prefix(Precept_Ritual __instance, ref float __result)
        {
            float ritualCooldown = Ideology_Setting.ritualCooldown;
            __result = __instance.TicksSinceLastPerformed / (ritualCooldown * 60000f);
            return false;
        }
    }

    [HarmonyPatch(typeof(Precept_Ritual), "get_RepeatPenaltyActive")]
    internal class Patch_RepeatPenaltyActive
    {
        private static bool Prefix(Precept_Ritual __instance, ref bool __result)
        {
            float ritualCooldown = Ideology_Setting.ritualCooldown;
            __result = __instance.isAnytime && __instance.lastFinishedTick != -1 && __instance.def.useRepeatPenalty && __instance.TicksSinceLastPerformed < (ritualCooldown * 60000f);
            return false;
        }
    }
}
