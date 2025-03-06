Shader "Toon/BasicURPShadow"
{
    Properties
    {
        [MainTexture] _BaseMap("Albedo", 2D) = "white" {}
        [MainColor] _BaseColor("Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Geometry"
        }

        // 禁止投射阴影
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
                float3 normalWS : TEXCOORD1;
                float3 positionWS : TEXCOORD2;
                float4 shadowCoord : TEXCOORD3;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);
            
            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                half4 _BaseColor;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                
                // 顶点变换
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = vertexInput.positionCS;
                output.positionWS = vertexInput.positionWS;
                
                // 法线变换（统一处理为正面法线）
                output.normalWS = normalize(mul((float3x3)GetObjectToWorldMatrix(), input.normalOS));
                
                // 处理UV
                output.uv = TRANSFORM_TEX(input.uv, _BaseMap);
                
                // 阴影坐标计算
                output.shadowCoord = TransformWorldToShadowCoord(output.positionWS);
                
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // 采样基础贴图
                half4 albedo = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, input.uv) * _BaseColor;
                
                // 主光源数据
                Light mainLight = GetMainLight(input.shadowCoord);
                
                // 阴影衰减
                float shadow = mainLight.shadowAttenuation;
                
                // 统一光照方向（消除背面变暗）
                float3 lightDir = normalize(mainLight.direction);
                float NdotL = saturate(dot(abs(input.normalWS), lightDir));
                
                // 最终颜色计算
                half3 color = albedo.rgb * mainLight.color * (NdotL * shadow);
                
                return half4(color, albedo.a);
            }
            ENDHLSL
        }
    }
}