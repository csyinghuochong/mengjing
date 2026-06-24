Shader "Toon/BasicShadow"
{
    Properties
    {
        [MainTexture] _BaseMap("Albedo", 2D) = "white" {}
        [MainColor] _BaseColor("Color", Color) = (1,1,1,1)
        _ShadowIntensity("Shadow Intensity", Range(0, 1)) = 0.5
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
            "RenderPipeline" = "UniversalPipeline"
        }

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            Cull Off // 双面渲染

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // 支持阴影宏
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
            #pragma multi_compile _ _SHADOWS_SOFT

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 positionWS : TEXCOORD1;
                float4 shadowCoord : TEXCOORD2;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                half4 _BaseColor;
                float _ShadowIntensity;
            CBUFFER_END

            bool IsUrpEmptyMainLightShadow()
            {
                // URP 14 strips the main-light "OFF" variant in UniversalRenderer and
                // emulates it with an empty shadow map plus this sentinel shadow param.
                // Treat that path as "no shadow" for this shadow-only shader to avoid
                // sampling stale shadow coords on device builds.
                half4 shadowParams = GetMainLightShadowParams();
                return all(abs(shadowParams - half4(1.0h, 0.0h, 1.0h, 0.0h)) < 1e-4h);
            }

            Varyings vert(Attributes input)
            {
                Varyings output;
                VertexPositionInputs vPos = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = vPos.positionCS;
                output.positionWS = vPos.positionWS;
                output.uv = TRANSFORM_TEX(input.uv, _BaseMap);
                output.shadowCoord = TransformWorldToShadowCoord(output.positionWS);
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                half4 albedo = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, input.uv) * _BaseColor;
                float shadowAttenuation = 1.0;

                #if defined(MAIN_LIGHT_CALCULATE_SHADOWS)
                if (!IsUrpEmptyMainLightShadow())
                {
                    Light light = GetMainLight(input.shadowCoord);
                    shadowAttenuation = lerp(1.0, light.shadowAttenuation, _ShadowIntensity);
                }
                #endif

                half3 finalColor = albedo.rgb * shadowAttenuation;
                return half4(finalColor, albedo.a);
            }
            ENDHLSL
        }
    }

    Fallback "Hidden/InternalErrorShader"
}
