Shader "Universal Render Pipeline/Transparent/DiffuseDetachAlpha" {
    Properties {
        _MainTex ("LigthMap Base (RGB) A", 2D) = "white" {}
        _MainTexLM ("Base (RGB)", 2D) = "white" {}
        _AlphaTexLM ("Trans (A)", 2D) = "white" {}
    }

    SubShader {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" }
        LOD 200

        Pass {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            TEXTURE2D(_MainTexLM);
            SAMPLER(sampler_MainTexLM);

            TEXTURE2D(_AlphaTexLM);
            SAMPLER(sampler_AlphaTexLM);

            struct Attributes {
                float4 positionOS : POSITION;
                float2 uv_MainTexLM : TEXCOORD0;
                float2 uv_AlphaTexLM : TEXCOORD1;
            };

            struct Varyings {
                float4 positionHCS : SV_POSITION;
                float2 uv_MainTexLM : TEXCOORD0;
                float2 uv_AlphaTexLM : TEXCOORD1;
            };

            Varyings vert(Attributes IN) {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
                OUT.uv_MainTexLM = IN.uv_MainTexLM;
                OUT.uv_AlphaTexLM = IN.uv_AlphaTexLM;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target {
                half4 color = SAMPLE_TEXTURE2D(_MainTexLM, sampler_MainTexLM, IN.uv_MainTexLM);
                half4 alpha = SAMPLE_TEXTURE2D(_AlphaTexLM, sampler_AlphaTexLM, IN.uv_AlphaTexLM);
                half4 outputColor = half4(color.rgb, alpha.a);
                return outputColor;
            }

            ENDHLSL
        }
    }

    Fallback "Universal Render Pipeline/Unlit"
}
