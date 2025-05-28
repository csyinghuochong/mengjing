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
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Geometry"
        }

        // 禁用阴影投射
        UsePass "Universal Render Pipeline/Lit/ShadowCaster"

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }
            
            Cull Off // 双面渲染
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            // 阴影相关宏
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
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

            Varyings vert(Attributes input)
            {
                Varyings output;
                
                // 顶点变换
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = vertexInput.positionCS;
                output.positionWS = vertexInput.positionWS;
                
                // 处理UV
                output.uv = TRANSFORM_TEX(input.uv, _BaseMap);
                
                // 阴影坐标计算
                output.shadowCoord = TransformWorldToShadowCoord(output.positionWS);
                
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // 直接采样贴图颜色（不受光照影响）
                half4 baseColor = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, input.uv) * _BaseColor;
                
                // 获取阴影衰减
                Light mainLight = GetMainLight(input.shadowCoord);
                float shadow = lerp(1.0, mainLight.shadowAttenuation, _ShadowIntensity);
                
                // 应用阴影（保持贴图原有颜色，仅叠加阴影效果）
                half3 finalColor = baseColor.rgb * shadow;
                
                return half4(finalColor, baseColor.a);
            }
            ENDHLSL
        }
    }
    
    Fallback "Universal Render Pipeline/Unlit"
}