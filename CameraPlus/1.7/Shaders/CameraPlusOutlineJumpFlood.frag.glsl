#version 450

layout(location = 1) in vec2 vUv;
layout(location = 0) out vec4 outColor;

layout(set = 2, binding = 0) uniform MaterialUniforms
{
    vec4 _MainTex_ST; // @default = vec4(0.0, 0.0, 1.0, 1.0)
    vec4 _SourceUVScale; // @default = vec4(1.0, 1.0, 0.0, 0.0)
    float _Step; // @default = 1.0
} u;
layout(set = 2, binding = 1) uniform sampler2D _MainTex;

void main()
{
    vec2 texelSize = 1.0 / vec2(textureSize(_MainTex, 0));
    vec4 best = vec4(0.0);
    float bestDistance = 1e20;
    for (int y = -1; y <= 1; ++y)
    {
        for (int x = -1; x <= 1; ++x)
        {
            vec2 sampleUV = vUv + vec2(x, y) * texelSize * u._Step;
            vec4 candidate = texture(_MainTex, vec2(sampleUV.x, 1.0 - sampleUV.y));
            vec2 delta = (candidate.xy - vUv) * u._SourceUVScale.xy;
            float candidateDistance = dot(delta, delta);
            if (candidate.a > 0.0 && candidateDistance < bestDistance)
            {
                best = candidate;
                bestDistance = candidateDistance;
            }
        }
    }
    outColor = best;
}
