Shader "Universal Render Pipeline/Nature/Stylized Grass"
{
    Properties
    {
        _MainTex ("Base Texture (RGBA)", 2D) = "white" {}
        _Color ("Tint Color", Color) = (1,1,1,1)
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
        _WindDir ("Wind Direction", Vector) = (0.5, 0, 0.5, 0)
        _WindStrength ("Wind Strength", Range(0, 2)) = 0.5
        _WindSpeed ("Wind Speed", Range(0, 5)) = 1.0
        _BendScale ("Bend Scale", Range(0, 3)) = 1.0
        _Frequency ("Frequency", Range(0, 10)) = 4.0
        _NoiseTex ("Wind Noise", 2D) = "gray" {}
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "TransparentCutout"
            "Queue" = "AlphaTest"
            "RenderPipeline" = "UniversalPipeline"
            "IgnoreProjector" = "True"
        }
        
        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }
            
            Cull Off  // 双面渲染确保草丛两面可见
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma shader_feature_local _ALPHATEST_ON

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float3 normalOS : NORMAL;
                float4 color : COLOR; // 顶点色控制摆动权重
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 positionWS : TEXCOORD1;
                float3 normalWS : TEXCOORD2;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            sampler2D _NoiseTex;
            float4 _MainTex_ST;
            
            CBUFFER_START(UnityPerMaterial)
                float4 _Color;
                float4 _WindDir;
                float _WindStrength;
                float _WindSpeed;
                float _BendScale;
                float _Frequency;
                float _Cutoff;
            CBUFFER_END

            // 风场动画函数
            float3 WindAnimation(float3 positionWS, float weight)
            {
                // 规范化风向
                float3 windVector = normalize(float3(_WindDir.x, 0, _WindDir.z));
                
                // 采样噪声纹理
                float2 noiseUV = positionWS.xz * 0.1 + _Time.y * _WindSpeed * 0.3;
                float2 noise = tex2Dlod(_NoiseTex, float4(noiseUV, 0, 0)).rg;
                
                // 基础正弦波
                float baseWave = sin(_Time.y * _WindSpeed + positionWS.x * _Frequency) * 0.5 + 0.5;
                
                // 复合风场 (噪声+正弦波)
                float windPower = (noise.r * 0.8 + noise.g * 0.4 + baseWave * 0.6) * _WindStrength;
                
                // 应用权重（顶点色R通道控制）
                windPower *= weight * _BendScale;
                
                return windVector * windPower;
            }

            Varyings vert(Attributes input)
            {
                Varyings output;
                UNITY_SETUP_INSTANCE_ID(input);
                
                // 获取世界空间位置
                float3 positionWS = TransformObjectToWorld(input.positionOS.xyz);
                
                // 计算风场偏移
                float3 windOffset = WindAnimation(positionWS, input.color.r);
                
                // 应用偏移 (主要影响XZ平面)
                positionWS += float3(windOffset.x, 0, windOffset.z);
                
                // Y轴轻微弯曲效果
                positionWS.y -= abs(windOffset.x + windOffset.z) * 0.1;
                
                output.positionCS = TransformWorldToHClip(positionWS);
                output.positionWS = positionWS;
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                output.color = input.color;
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // 采样主纹理 - 只使用alpha通道
                half4 texSample = tex2D(_MainTex, input.uv);
                
                // Alpha裁剪 - 关键步骤
                clip(texSample.a - _Cutoff);
                
                // 使用_Color作为基础颜色（忽略纹理RGB）
                half4 col = _Color;
                
                // 简单光照计算
                Light mainLight = GetMainLight();
                float3 lightDir = normalize(mainLight.direction);
                float NdotL = saturate(dot(input.normalWS, lightDir)) + 0.5;

                if(NdotL > 1)
                {
                    NdotL = 1;
                }

                float3 diffuse = mainLight.color * NdotL;
                
                // 应用光照并增强底部阴影
                col.rgb *= diffuse *lerp(0.7, 1.2, input.color.r);
                
                // 添加环境光
               col.rgb += SampleSH(input.normalWS) * 0.3;
                
                return col;
            }
            ENDHLSL
        }
        
        // 添加深度和阴影Pass确保正确渲染
        Pass
        {
            Name "DepthOnly"
            Tags { "LightMode" = "DepthOnly" }
            
            Cull Off
            
            HLSLPROGRAM
            #pragma vertex DepthOnlyVertex
            #pragma fragment DepthOnlyFragment
            #pragma multi_compile_instancing
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            struct DepthAttributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            
            struct DepthVaryings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
            
            float4 _WindDir;
            float _WindSpeed;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Cutoff;
            sampler2D _NoiseTex;
            float _WindStrength;
            float _BendScale;
            
            DepthVaryings DepthOnlyVertex(DepthAttributes input)
            {
                DepthVaryings output;
                UNITY_SETUP_INSTANCE_ID(input);
                
                float3 positionWS = TransformObjectToWorld(input.positionOS.xyz);
                

                // 风场动画 (简化版)
                float3 windVector = normalize(float3(_WindDir.x, 0, _WindDir.z));
                float2 noiseUV = positionWS.xz * 0.1 + _Time.y * _WindSpeed * 0.3;
                float noise = tex2Dlod(_NoiseTex, float4(noiseUV, 0, 0)).r;
                float windPower = noise * _WindStrength * input.color.r * _BendScale;
                positionWS += windVector * windPower;
                
                output.positionCS = TransformWorldToHClip(positionWS);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                return output;
            }
            
            half4 DepthOnlyFragment(DepthVaryings input) : SV_Target
            {
                half alpha = tex2D(_MainTex, input.uv).a;
                clip(alpha - _Cutoff);
                return 0;
            }
            ENDHLSL
        }
    }
    
    Fallback "Universal Render Pipeline/Simple Lit"
}