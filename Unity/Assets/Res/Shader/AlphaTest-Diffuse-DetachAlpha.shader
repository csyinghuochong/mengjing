Shader "Custom/URP/TransparentCutoutDetachAlphaDiffuse"
{
    Properties
    {
        _MainTex ("LightMap Base (RGB) A", 2D) = "white" {}
        _MainTexLM ("Base (RGB)", 2D) = "white" {}
        _AlphaTexLM ("Trans (A)", 2D) = "white" {}
        _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }

    SubShader
    {
        Tags { "Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" }
        LOD 200

        Pass
        {
            Name "ForwardPass"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_MainTexLM);
            SAMPLER(sampler_MainTexLM);
            TEXTURE2D(_AlphaTexLM);
            SAMPLER(sampler_AlphaTexLM);

            float _Cutoff;

            Varyings vert(Attributes v)
            {
                Varyings o;
                o.positionHCS = TransformObjectToHClip(v.positionOS);
                o.uv = v.uv;
                return o;
            }

            half4 frag(Varyings i) : SV_Target
            {
                half4 color = SAMPLE_TEXTURE2D(_MainTexLM, sampler_MainTexLM, i.uv);
                half4 alpha = SAMPLE_TEXTURE2D(_AlphaTexLM, sampler_AlphaTexLM, i.uv);

                if (alpha.a < _Cutoff)
                    discard;

                return half4(color.rgb, alpha.a);
            }
            ENDHLSL
        }
    }

    Fallback "Transparent/Cutout/VertexLit"
}