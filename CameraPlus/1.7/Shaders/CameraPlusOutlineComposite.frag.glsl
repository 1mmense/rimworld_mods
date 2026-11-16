#version 450

layout(location = 1) in vec2 vUv;
layout(location = 0) out vec4 outColor;

layout(set = 2, binding = 0) uniform MaterialUniforms
{
    vec4 _MainTex_ST; // @default = vec4(0.0, 0.0, 1.0, 1.0)
    vec4 _SourceUVScale; // @default = vec4(1.0, 1.0, 0.0, 0.0)
    float _OutlineFactor; // @default = 0.075
} u;
layout(set = 2, binding = 1) uniform sampler2D _MainTex;

void main()
{
    vec4 nearest = texture(_MainTex, vec2(vUv.x, 1.0 - vUv.y));
    if (nearest.a == 0.0)
    {
        outColor = vec4(0.0);
        return;
    }
    float distanceToShape = length((nearest.xy - vUv) * u._SourceUVScale.xy);
    vec2 sourceTexelSize = u._SourceUVScale.xy / vec2(textureSize(_MainTex, 0));
    float antialiasWidth = max(sourceTexelSize.x, sourceTexelSize.y);
    float alpha = clamp(0.5 + (u._OutlineFactor - distanceToShape) / antialiasWidth, 0.0, 1.0);
    outColor = vec4(1.0, 1.0, 1.0, alpha);
}
