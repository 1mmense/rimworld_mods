using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class Listing_StandardExtensions
    {
        public static FieldInfo rectInfo = AccessTools.Field(typeof(Listing_Standard), "listingRect");
        public static FieldInfo widthInfo = AccessTools.Field(typeof(Listing_Standard), "columnWidthInt");
        public static FieldInfo curXInfo = AccessTools.Field(typeof(Listing_Standard), "curX");
        public static FieldInfo curYInfo = AccessTools.Field(typeof(Listing_Standard), "curY");
        public static FieldInfo fontInfo = AccessTools.Field(typeof(Listing_Standard), "font");
        public static void BeginScrollViewEx(this Listing_Standard listing, Rect rect, ref Vector2 scrollPosition, Rect viewRect)
        {
            Widgets.BeginGroup(rect);
            Widgets.BeginScrollView(rect.AtZero(), ref scrollPosition, viewRect, true);

            rect.height = 100000f;
            rect.width -= 20f;

            rectInfo.SetValue(listing, rect);
            widthInfo.SetValue(listing, rect.width);
            curXInfo.SetValue(listing, 0);
            curYInfo.SetValue(listing, 0);

            Text.Font = (GameFont)fontInfo.GetValue(listing);
        }
        public static void EndScrollView(this Listing_Standard listing, ref Rect viewRect)
        {
            viewRect = new Rect(0f, 0f, listing.ColumnWidth, listing.CurHeight);
            Widgets.EndScrollView();
            listing.End();
        }
    }
}