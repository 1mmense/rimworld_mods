#version 450

layout(location = 1) in vec2 vUv;
layout(location = 0) out vec4 outColor;

layout(set = 2, binding = 0) uniform MaterialUniforms
{
    vec4 _MainTex_ST; // @default = vec4(0.0, 0.0, 1.0, 1.0)
    vec4 _SourceUVScale; // @default = vec4(1.0, 1.0, 0.0, 0.0)
} u;
layout(set = 2, binding = 1) uniform sampler2D _MainTex;

void main()
{
    vec2 sourceUV = (vUv - 0.5) * u._SourceUVScale.xy + 0.5;
    if (any(lessThan(sourceUV, vec2(0.0))) || any(greaterThan(sourceUV, vec2(1.0))))
    {
        outColor = vec4(0.0);
        return;
    }
    outColor = texture(_MainTex, sourceUV);
}
