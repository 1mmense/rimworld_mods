using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse.Sound;
using Verse;
using System.Collections.Generic;
using System.Reflection;

namespace SimplyMoreColors
{
    internal static class Dialog_ChooseIdeoSymbolsPatches
    {
        [HarmonyPatch(typeof(Dialog_ChooseIdeoSymbols))]
        [HarmonyPatch("DoColorSelector")]
        class DoColorSelectorPatch
        {
            // Reflection
            private static List<ColorDef> IdeoColorsSorted
            {
                get
                {
                    return (List<ColorDef>)typeof(Dialog_ChooseIdeoSymbols)
                        .GetProperty("IdeoColorsSorted", BindingFlags.NonPublic | BindingFlags.Static)
                        .GetValue(instance);
                }
            }

            // Customs
            private static Dialog_ChooseIdeoSymbols instance;

            // Main
            public static bool Prefix(
                Dialog_ChooseIdeoSymbols __instance,
                ref ColorDef ___newColorDef, // private static var
                IdeoIconDef ___newIconDef, // private static var
                Rect mainRect,
                ref float curY
            )
            {
                instance = __instance;

                int num = 26;
                float num2 = 98f;
                int num3 = Mathf.FloorToInt((mainRect.width - num2) / (float)(num + 2));
                int num4 = Mathf.CeilToInt((float)IdeoColorsSorted.Count / (float)num3);
                Widgets.BeginGroup(mainRect);
                GUI.color = ___newColorDef.color;
                GUI.DrawTexture(new Rect(5f, 5f, 88f, 88f), (Texture)___newIconDef.Icon);
                GUI.color = Color.white;
                curY += num2;
                int num5 = 0;
                foreach (ColorDef item in IdeoColorsSorted)
                {
                    int num6 = num5 / num3;
                    int num7 = num5 % num3;

                    // --------------- Change here
                    float num8 = 0f;
                    // -----------------------

                    Rect rect = new Rect(num2 + (float)(num7 * num) + (float)(num7 * 2), num8 + (float)(num6 * num) + (float)(num6 * 2), num, num);
                    Widgets.DrawLightHighlight(rect);
                    Widgets.DrawHighlightIfMouseover(rect);
                    if (___newColorDef == item)
                    {
                        Widgets.DrawBox(rect);
                    }
                    Widgets.DrawBoxSolid(new Rect(rect.x + 2f, rect.y + 2f, 22f, 22f), item.color);
                    if (Widgets.ButtonInvisible(rect))
                    {
                        ___newColorDef = item;
                        SoundDefOf.Tick_High.PlayOneShotOnCamera();
                    }
                    curY = Mathf.Max(curY, mainRect.yMin + rect.yMax);
                    num5++;
                }
                Widgets.EndGroup();
                curY += 4f;

                return false; // do not use original function
            }
        }
    }
}
