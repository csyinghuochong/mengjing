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
            
            Cull Off  // ˫����Ⱦȷ���ݴ�����ɼ�
            
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
                float4 color : COLOR; // ����ɫ���ưڶ�Ȩ��
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

            // �糡��������
            float3 WindAnimation(float3 positionWS, float weight)
            {
                // �淶������
                float3 windVector = normalize(float3(_WindDir.x, 0, _WindDir.z));
                
                // ������������
                float2 noiseUV = positionWS.xz * 0.1 + _Time.y * _WindSpeed * 0.3;
                float2 noise = tex2Dlod(_NoiseTex, float4(noiseUV, 0, 0)).rg;
                
                // �������Ҳ�
                float baseWave = sin(_Time.y * _WindSpeed + positionWS.x * _Frequency) * 0.5 + 0.5;
                
                // ���Ϸ糡 (����+���Ҳ�)
                float windPower = (noise.r * 0.8 + noise.g * 0.4 + baseWave * 0.6) * _WindStrength;
                
                // Ӧ��Ȩ�أ�����ɫRͨ�����ƣ�
                windPower *= weight * _BendScale;
                
                return windVector * windPower;
            }

            Varyings vert(Attributes input)
            {
                Varyings output;
                UNITY_SETUP_INSTANCE_ID(input);
                
                // ��ȡ����ռ�λ��
                float3 positionWS = TransformObjectToWorld(input.positionOS.xyz);
                
                // ����糡ƫ��
                float3 windOffset = WindAnimation(positionWS, input.color.r);
                
                // Ӧ��ƫ�� (��ҪӰ��XZƽ��)
                positionWS += float3(windOffset.x, 0, windOffset.z);
                
                // Y����΢����Ч��
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
                // ���������� - ֻʹ��alphaͨ��
                half4 texSample = tex2D(_MainTex, input.uv);
                
                // Alpha�ü� - �ؼ�����
                clip(texSample.a - _Cutoff);
                
                // ʹ��_Color��Ϊ������ɫ����������RGB��
                half4 col = _Color;
                
                // �򵥹��ռ���
                Light mainLight = GetMainLight();
                float3 lightDir = normalize(mainLight.direction);
                float NdotL = saturate(dot(input.normalWS, lightDir)) + 0.5;

                if(NdotL > 1)
                {
                    NdotL = 1;
                }

                float3 diffuse = mainLight.color * NdotL;
                
                // Ӧ�ù��ղ���ǿ�ײ���Ӱ
                col.rgb *= diffuse *lerp(0.7, 1.2, input.color.r);
                
                // ��ӻ�����
               col.rgb += SampleSH(input.normalWS) * 0.3;
                
                return col;
            }
            ENDHLSL
        }
        
        // �����Ⱥ���ӰPassȷ����ȷ��Ⱦ
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
                

                // �糡���� (�򻯰�)
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