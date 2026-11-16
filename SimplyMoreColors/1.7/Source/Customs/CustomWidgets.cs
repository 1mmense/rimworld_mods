using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace SimplyMoreColors
{
    [StaticConstructorOnStartup]
    internal static class CustomWidgets
    {
        public static bool ColorSelector(Rect rect, ref Color color, List<Color> colors, out float height, Texture icon = null, int colorSize = 22, int colorPadding = 2, Action<Color, Rect> extraOnGUI = null)
        {
            height = 0f;
            bool result = false;
            int num = colorSize + colorPadding * 2;
            float num2 = ((icon != null) ? ((float)(colorSize * 4) + 10f) : 0f);
            int num3 = Mathf.FloorToInt((rect.width - num2 + (float)colorPadding) / (float)(num + colorPadding));
            int num4 = Mathf.CeilToInt((float)colors.Count / (float)num3);
            Widgets.BeginGroup(rect);
            Widgets.ColorSelectorIcon(new Rect(5f, 5f, colorSize * 4, colorSize * 4), icon, color);
            for (int i = 0; i < colors.Count; i++)
            {
                int num5 = i / num3;
                int num6 = i % num3;
                
                // ------------------ Change here
                // No idea where this value came from ... hopefully it will be corrected next time
                float num7 = colorPadding; // ((icon != null) ? ((num2 - (float)(num * num4) - (float)colorPadding) / 2f) : 0f);
                // ---------------------------

                Rect rect2 = new Rect(num2 + (float)(num6 * num) + (float)(num6 * colorPadding), num7 + (float)(num5 * num) + (float)(num5 * colorPadding), num, num);
                if (Widgets.ColorBox(rect2, ref color, colors[i], colorSize, colorPadding, extraOnGUI))
                {
                    result = true;
                }
                height = Mathf.Max(height, rect2.yMax);
            }
            Widgets.EndGroup();
            return result;
        }
    }
}
