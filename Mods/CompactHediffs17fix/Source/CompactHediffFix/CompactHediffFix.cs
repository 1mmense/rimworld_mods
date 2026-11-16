using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace CompactHediffFix;

public class CompactHediffFixMod : Mod
{
    public CompactHediffFixMod(ModContentPack content) : base(content)
    {
        new Harmony("RobTRG.CompactHediffFix").PatchAll();
    }
}

// Compact Hediffs tiles its bar textures by passing UVs past 1.0 to GUI.DrawTextureWithTexCoords and
// relying on wrapMode = Repeat. Waylith's ImGui backend samples every UI texture with ClampToEdge and
// ignores wrapMode, so the bars smear their edge pixel instead of repeating. Swap those calls for one
// that splits the rect into tiles whose UVs stay inside [0, 1].
[HarmonyPatch]
public static class CustomHealthCardUtility_TiledBars
{
    private const string TargetType = "PeteTimesSix.CompactHediffs.Rimworld.CustomHealthCardUtility";

    private static readonly MethodInfo DrawTextureWithTexCoords =
        AccessTools.Method(typeof(GUI), nameof(GUI.DrawTextureWithTexCoords), new[] { typeof(Rect), typeof(Texture), typeof(Rect) });

    private static readonly MethodInfo DrawTiled =
        AccessTools.Method(typeof(CustomHealthCardUtility_TiledBars), nameof(DrawTextureTiled));

    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(TargetType + ":DrawSeverityBar");
        yield return AccessTools.Method(TargetType + ":DrawCumulativeThreatmentBar");
    }

    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, MethodBase original)
    {
        int replaced = 0;
        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.Calls(DrawTextureWithTexCoords))
            {
                instruction.operand = DrawTiled;
                replaced++;
            }
            yield return instruction;
        }
        if (replaced == 0)
        {
            Log.Warning($"[CompactHediffFix] No DrawTextureWithTexCoords calls found in {original.Name}; bars will stay untiled.");
        }
    }

    public static void DrawTextureTiled(Rect position, Texture image, Rect texCoords)
    {
        if (image == null || texCoords.width <= 0f || texCoords.height <= 0f
            || (texCoords.xMin >= 0f && texCoords.xMax <= 1f && texCoords.yMin >= 0f && texCoords.yMax <= 1f))
        {
            GUI.DrawTextureWithTexCoords(position, image, texCoords);
            return;
        }

        // Screen pixels covered by one UV unit on each axis.
        float pxPerU = position.width / texCoords.width;
        float pxPerV = position.height / texCoords.height;

        for (float v = texCoords.yMin; v < texCoords.yMax - 0.0001f;)
        {
            float vEnd = Mathf.Min(Mathf.Floor(v) + 1f, texCoords.yMax);
            float vTile = Mathf.Floor(v);
            float y = position.y + (v - texCoords.yMin) * pxPerV;
            float h = (vEnd - v) * pxPerV;

            for (float u = texCoords.xMin; u < texCoords.xMax - 0.0001f;)
            {
                float uEnd = Mathf.Min(Mathf.Floor(u) + 1f, texCoords.xMax);
                float uTile = Mathf.Floor(u);
                float x = position.x + (u - texCoords.xMin) * pxPerU;
                float w = (uEnd - u) * pxPerU;

                GUI.DrawTextureWithTexCoords(new Rect(x, y, w, h), image,
                    new Rect(u - uTile, v - vTile, uEnd - u, vEnd - v));
                u = uEnd;
            }
            v = vEnd;
        }
    }
}
