#version 450

layout(location = 1) in vec2 vUv;
layout(location = 0) out vec4 outColor;

layout(set = 2, binding = 0) uniform MaterialUniforms
{
    vec4 _MainUVScale; // @default = vec4(1.0, 1.0, 0.0, 0.0)
    vec4 _OutlineUVScale; // @default = vec4(1.0, 1.0, 0.0, 0.0)
    vec4 _FillColor; // @color @default = vec4(1.0, 0.0, 0.0, 1.0)
    vec4 _OutlineColor; // @color @default = vec4(1.0, 1.0, 1.0, 1.0)
    float _OutlineFactor; // @default = 0.075
    float _ShrinkFactor; // @default = 4.0
} u;

layout(set = 2, binding = 1) uniform sampler2D _MainTex;
layout(set = 2, binding = 2) uniform sampler2D _OutlineTex;

void main()
{
    vec2 baseUV = mix(vec2(0.5), vUv, 1.0 + u._OutlineFactor * u._ShrinkFactor);
    vec2 mainUV = (baseUV - 0.5) * u._MainUVScale.xy + 0.5;
    vec4 mainColor = vec4(0.0);
    if (all(greaterThanEqual(mainUV, vec2(0.0))) && all(lessThanEqual(mainUV, vec2(1.0))))
        mainColor = texture(_MainTex, mainUV);

    mainColor.rgb = mix(mainColor.rgb, u._FillColor.rgb, u._FillColor.a);
    if (u._OutlineFactor == 0.0)
    {
        outColor = vec4(mainColor.rgb * mainColor.a, mainColor.a);
        return;
    }

    vec2 outlineUV = (baseUV - 0.5) * u._OutlineUVScale.xy + 0.5;
    float outlineAlpha = 0.0;
    if (all(greaterThanEqual(outlineUV, vec2(0.0))) && all(lessThanEqual(outlineUV, vec2(1.0))))
        outlineAlpha = texture(_OutlineTex, outlineUV).a;

    float fillAlpha = mainColor.a;
    float visibleOutlineAlpha = outlineAlpha * u._OutlineColor.a * (1.0 - fillAlpha);
    float combinedAlpha = fillAlpha + visibleOutlineAlpha;
    vec3 combinedColor = mainColor.rgb * fillAlpha + u._OutlineColor.rgb * visibleOutlineAlpha;
    outColor = vec4(combinedColor, combinedAlpha);
}
