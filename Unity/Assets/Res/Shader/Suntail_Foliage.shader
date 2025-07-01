Shader "Raygeas/Suntail Foliage"
{
    Properties
    {
        [MainTexture]_Albedo("Albedo", 2D) = "white" {}
        _SmoothnessTexture("Smoothness", 2D) = "white" {}
        _MainColor("Main Color", Color) = (1,1,1,0)
        _Smoothness("Smoothness", Range(0,1)) = 0
        _AlphaCutoff("Alpha Cutoff", Range(0,1)) = 0.35
        _TranslucencyInt("Translucency Int", Range(0,100)) = 1
        
        [Toggle(_COLOR2ENABLE_ON)] _Color2Enable("Enable Second Color", Float) = 0
        _SecondColor("Second Color", Color) = (0,0,0,0)
        [KeywordEnum(World_Position,UV_Based)] _SecondColorOverlayType("Overlay Type", Float) = 0
        _SecondColorOffset("Offset", Float) = 0
        _SecondColorFade("Fade", Range(-1,1)) = 0.5
        _WorldScale("World Scale", Float) = 1
        
        [Toggle(_ENABLEWIND_ON)] _EnableWind("Enable Wind", Float) = 1
        _WindForce("Force", Range(0,1)) = 0.3
        _WindWavesScale("Waves Scale", Range(0,1)) = 0.25
        _WindSpeed("Speed", Range(0,1)) = 0.5
        [Toggle(_ANCHORTHEFOLIAGEBASE_ON)] _Anchorthefoliagebase("Anchor the foliage base", Float) = 0
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "AlphaTest"
            "IgnoreProjector" = "True"
        }
        
        LOD 300

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }
            
            Cull Off
            AlphaToMask On
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            // Universal Pipeline keywords
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile_fragment _ _SHADOWS_SOFT
            #pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
            #pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
            #pragma multi_compile _ SHADOWS_SHADOWMASK
            
            // Material Keywords
            #pragma shader_feature_local _ENABLEWIND_ON
            #pragma shader_feature_local _ANCHORTHEFOLIAGEBASE_ON
            #pragma shader_feature_local _COLOR2ENABLE_ON
            #pragma shader_feature_local _SECONDCOLOROVERLAYTYPE_WORLD_POSITION _SECONDCOLOROVERLAYTYPE_UV_BASED
            
            // Unity defined
            #pragma multi_compile_fog
            
            // GPU Instancing
            #pragma multi_compile_instancing
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float3 normalOS     : NORMAL;
                float4 tangentOS    : TANGENT;
                float2 texcoord     : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS  : SV_POSITION;
                float2 uv          : TEXCOORD0;
                float3 positionWS  : TEXCOORD1;
                float3 normalWS   : TEXCOORD2;
                float3 viewDirWS  : TEXCOORD3;
                half4 fogFactorAndVertexLight : TEXCOORD4;
                #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
                float4 shadowCoord : TEXCOORD5;
                #endif
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            CBUFFER_START(UnityPerMaterial)
            float4 _MainColor;
            float4 _Albedo_ST;
            float4 _SecondColor;
            float4 _SmoothnessTexture_ST;
            float _WindSpeed;
            float _WindWavesScale;
            float _WindForce;
            float _WorldScale;
            float _SecondColorOffset;
            float _SecondColorFade;
            float _TranslucencyInt;
            float _Smoothness;
            float _AlphaCutoff;
            CBUFFER_END

            TEXTURE2D(_Albedo);            SAMPLER(sampler_Albedo);
            TEXTURE2D(_SmoothnessTexture); SAMPLER(sampler_SmoothnessTexture);

            // Simple noise function for wind
            float noise(float3 value)
            {
                return frac(sin(dot(value, float3(12.9898, 78.233, 45.5432))) * 43758.5453);
            }

            Varyings vert(Attributes input)
            {
                Varyings output = (Varyings)0;
                UNITY_SETUP_INSTANCE_ID(input);
                UNITY_TRANSFER_INSTANCE_ID(input, output);

                // Wind animation
                #ifdef _ENABLEWIND_ON
                float3 worldPos = TransformObjectToWorld(input.positionOS.xyz);
                float windTime = _Time.y * _WindSpeed * 5.0;
                float windNoise = sin(windTime + worldPos.x * _WindWavesScale) * cos(windTime + worldPos.z * _WindWavesScale);
                float windStrength = windNoise * _WindForce * 0.1;
                
                #ifdef _ANCHORTHEFOLIAGEBASE_ON
                windStrength *= input.texcoord.y * input.texcoord.y; // Anchor base
                #endif
                
                input.positionOS.xyz += float3(windStrength, 0, windStrength) * 0.5;
                #endif

                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                VertexNormalInputs normalInput = GetVertexNormalInputs(input.normalOS, input.tangentOS);
                
                output.positionCS = vertexInput.positionCS;
                output.positionWS = vertexInput.positionWS;
                output.normalWS = normalInput.normalWS;
                output.viewDirWS = GetWorldSpaceViewDir(vertexInput.positionWS);
                output.uv = TRANSFORM_TEX(input.texcoord, _Albedo);
                
                // Fog and vertex lighting
                half3 vertexLight = VertexLighting(vertexInput.positionWS, normalInput.normalWS);
                half fogFactor = ComputeFogFactor(vertexInput.positionCS.z);
                output.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
                
                // Shadow coordinates
                #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
                output.shadowCoord = GetShadowCoord(vertexInput);
                #endif
                
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(input);
                
                // Sample main texture
                half4 albedoAlpha = SAMPLE_TEXTURE2D(_Albedo, sampler_Albedo, input.uv);
                half3 albedo = albedoAlpha.rgb * _MainColor.rgb;
                half alpha = albedoAlpha.a;
                
                // Alpha clipping
                clip(alpha - _AlphaCutoff);
                
                // Second color overlay
                #ifdef _COLOR2ENABLE_ON
                float overlayValue;
                #if defined(_SECONDCOLOROVERLAYTYPE_WORLD_POSITION)
                overlayValue = input.positionWS.y * _WorldScale;
                #else
                overlayValue = input.uv.y;
                #endif
                
                float mask = saturate((overlayValue + _SecondColorOffset) * _SecondColorFade * 2.0);
                half3 secondColor = SAMPLE_TEXTURE2D(_Albedo, sampler_Albedo, input.uv).rgb * _SecondColor.rgb;
                albedo = lerp(albedo, secondColor, mask);
                #endif
                
                // Lighting setup
                half3 normalWS = normalize(input.normalWS);
                half3 viewDirWS = SafeNormalize(input.viewDirWS);
                
                // Main light with shadows
                #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
                float4 shadowCoord = input.shadowCoord;
                #else
                float4 shadowCoord = float4(0, 0, 0, 0);
                #endif
                
                Light mainLight = GetMainLight(shadowCoord);
                half3 lightDir = mainLight.direction;
                half3 lightColor = mainLight.color;
                half atten = mainLight.shadowAttenuation * mainLight.distanceAttenuation;
                
                // Translucency effect
                half transDot = dot(lightDir, -viewDirWS);
                half translucency = saturate(transDot) * _TranslucencyInt * 0.1;
                half3 transColor = albedo * lightColor * translucency * atten;
                
                // Diffuse lighting
                half NdotL = saturate(dot(normalWS, lightDir));
                half3 diffuse = albedo * lightColor * (NdotL * atten + transColor);
                
                // Additional lights
                #ifdef _ADDITIONAL_LIGHTS
                uint pixelLightCount = GetAdditionalLightsCount();
                for (uint lightIndex = 0; lightIndex < pixelLightCount; ++lightIndex)
                {
                    Light light = GetAdditionalLight(lightIndex, input.positionWS);
                    half3 addLightDir = light.direction;
                    half3 addLightColor = light.color;
                    half addAtten = light.distanceAttenuation * light.shadowAttenuation;
                    
                    half addNdotL = saturate(dot(normalWS, addLightDir));
                    diffuse += albedo * addLightColor * addNdotL * addAtten;
                }
                #endif
                
                // Ambient lighting
                half3 ambient = SampleSH(normalWS) * albedo;
                
                // Smoothness
                half4 smoothnessTex = SAMPLE_TEXTURE2D(_SmoothnessTexture, sampler_SmoothnessTexture, input.uv);
                half smoothness = smoothnessTex.r * _Smoothness;
                
                // Final color composition
                half3 color = diffuse + ambient;
                color = MixFog(color, input.fogFactorAndVertexLight.x);
                
                return half4(color, alpha);
            }
            ENDHLSL
        }
    }
    
    FallBack "Nature/SpeedTree"
    CustomEditor "UnityEditor.ShaderGraphUnlitGUI"
}