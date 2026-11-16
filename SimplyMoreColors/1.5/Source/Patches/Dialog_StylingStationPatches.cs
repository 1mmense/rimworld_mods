using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace SimplyMoreColors
{
    internal static class Dialog_StylingStationPatches
    {
        [HarmonyPatch(typeof(Dialog_StylingStation))]
        [HarmonyPatch("DrawApparelColor")]
        class DrawApparelColorPatch
        {
            // Reflection
            private static bool DevMode
            {
                get
                {
                    return (bool)typeof(Dialog_StylingStation)
                        .GetProperty("DevMode", BindingFlags.NonPublic | BindingFlags.Instance)
                        .GetValue(instance);
                }
            }

            private static List<Color> AllColors
            {
                get
                {
                    return (List<Color>)typeof(Dialog_StylingStation)
                        .GetProperty("AllColors", BindingFlags.NonPublic | BindingFlags.Instance)
                        .GetValue(instance);
                }
            }

            private static void DrawDyeRequirement(Rect rect, ref float curY, int requiredDye)
            {
                object[] arguments = new object[] { rect, curY, requiredDye };
                typeof(Dialog_StylingStation)
                    .GetMethod("DrawDyeRequirement", BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(instance, arguments);

                curY = (float)arguments[1];
            }

            private static void ColorSelecterExtraOnGUI(Color color, Rect boxRect)
            {
                typeof(Dialog_StylingStation)
                    .GetMethod("ColorSelecterExtraOnGUI", BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(instance, new object[] { color, boxRect });
            }


            // Customs
            private static Dialog_StylingStation instance;

            private static float GetHeight(float width, ref Color color, List<Color> colors, Texture icon = null, int colorSize = 22, int colorPadding = 2)
            {
                // Maybe not the best optimized function, but I guess it's enough for a simple Dialog
                int dim = colorSize + colorPadding * 2;
                float paddingX = ((icon != null) ? ((float)(colorSize * 4) + 10f) : 0f); // padding x
                int colNb = Mathf.FloorToInt((width - paddingX + (float)colorPadding) / (float)(dim + colorPadding)); // colNb
                int rowNb = Mathf.CeilToInt((float)colors.Count / (float)colNb); // rowNb
                return rowNb * (colorPadding + dim) + colorPadding;
            }

            // Main

            public static bool Prefix (
                Dialog_StylingStation __instance,
                ref float ___viewRectHeight,                // private static var
                ref Vector2 ___apparelColorScrollPosition,  // private static var
                Pawn ___pawn,                                // private static var
                Dictionary<Apparel,
                Color> ___apparelColors,                    // private static var
                Rect rect
            )
            {
                instance = __instance;

                Rect viewRect = new Rect(rect.x, rect.y, rect.width - 16f, ___viewRectHeight);
                Widgets.BeginScrollView(rect, ref ___apparelColorScrollPosition, viewRect);
                int num = 0;
                float curY = rect.y;
                foreach (Apparel item in ___pawn.apparel.WornApparel)
                {
                    if (!___apparelColors.TryGetValue(item, out var value))
                    {
                        continue;
                    }

                    // ------------------ change here
                    Texture2D icon = Widgets.GetIconFor(item.def, item.Stuff, item.StyleDef);
                    float width = (int)viewRect.width;
                    float height = GetHeight(width, ref value, AllColors, icon, 22, 2);
                    Rect rect2 = new Rect(rect.x, curY, width, height);
                    // ---------------------------

                    curY += rect2.height + 10f;
                    if (!___pawn.apparel.IsLocked(item) || DevMode)
                    {
                        // ------------------ Change here
                        CustomWidgets.ColorSelector(rect2, ref value, AllColors, out var _, icon, 22, 2, ColorSelecterExtraOnGUI);
                        // ---------------------------

                        float num2 = rect2.x;
                        if (___pawn.Ideo != null && !Find.IdeoManager.classicMode)
                        {
                            rect2 = new Rect(num2, curY, 200f, 24f);
                            if (Widgets.ButtonText(rect2, "SetIdeoColor".Translate()))
                            {
                                value = ___pawn.Ideo.ApparelColor;
                                SoundDefOf.Tick_Low.PlayOneShotOnCamera();
                            }
                            num2 += 210f;
                        }
                        Pawn_StoryTracker story = ___pawn.story;
                        if (story != null && story.favoriteColor.HasValue)
                        {
                            rect2 = new Rect(num2, curY, 200f, 24f);
                            if (Widgets.ButtonText(rect2, "SetFavoriteColor".Translate()))
                            {
                                value = ___pawn.story.favoriteColor.Value;
                                SoundDefOf.Tick_Low.PlayOneShotOnCamera();
                            }
                        }
                        if (!value.IndistinguishableFrom(item.DrawColor))
                        {
                            num++;
                        }
                        ___apparelColors[item] = value;
                    }
                    else
                    {
                        Widgets.ColorSelectorIcon(new Rect(rect2.x, rect2.y, 88f, 88f), item.def.uiIcon, value);
                        Text.Anchor = (TextAnchor)3;
                        Rect rect3 = rect2;
                        rect3.x += 100f;
                        Widgets.Label(rect3, ((string)"ApparelLockedCannotRecolor".Translate(___pawn.Named("PAWN"), item.Named("APPAREL"))).Colorize(ColorLibrary.RedReadable));
                        Text.Anchor = (TextAnchor)0;
                    }
                    curY += 34f;
                }
                if (___pawn.Spawned)
                {
                    if (num > 0)
                    {
                        DrawDyeRequirement(rect, ref curY, num);
                    }
                    if (___pawn.Map.resourceCounter.GetCount(ThingDefOf.Dye) < num)
                    {
                        Rect rect4 = new Rect(rect.x, curY, rect.width - 16f - 10f, 60f);
                        Color color = GUI.color;
                        GUI.color = ColorLibrary.RedReadable;
                        Widgets.Label(rect4, "NotEnoughDye".Translate() + " " + "NotEnoughDyeWillRecolorApparel".Translate());
                        GUI.color = color;
                        curY += rect4.height;
                    }
                }
                if ((int)Event.current.type == 8)
                {
                    ___viewRectHeight = curY - rect.y;
                }
                Widgets.EndScrollView();
                return false;
            }
        }

       
    }
}
