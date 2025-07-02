Shader "Polyart/Dreamscape/URP/Water River"
{
    Properties
    {
        [Header(Maps)]
        [SingleLineTexture]_FlowMask("Flow Mask", 2D) = "white" {}
        [SingleLineTexture]_FoamMask("Foam Mask", 2D) = "white" {}
        [Normal][SingleLineTexture]_NormalMap("Normal Map", 2D) = "bump" {}
        [SingleLineTexture]_HeightMap("Height Map", 2D) = "white" {}
        
        [Header(Color)]
        _ColorShallow("Color Shallow", Color) = (0.5990566,0.9091429,1,0)
        _ColorDeep("Color Deep", Color) = (0.1213065,0.347919,0.5471698,0)
        _ColorDepthFade("Color Depth Fade", Range(0, 100)) = 0
        _WaterFoamColor("Water Foam Color", Color) = (1,1,1,1)
        _WaterFoamColorIntensity("Water Foam Color Intensity", Float) = 1
        
        [Header(Refraction)]
        _RefractionStrength("Refraction Strength", Range(0, 10)) = 1
        _RefractionDepth("Refraction Depth", Range(0, 100)) = 1
        
        [Header(Edge Foam)]
        _EdgeFoamSpeed("Edge Foam Speed", Vector) = (0,0,0,0)
        _EdgeFoamScale("Edge Foam Scale", Range(0, 10)) = 1
        _EdgeFoamDepthFade("Edge Foam Depth Fade", Range(0, 10)) = 0.19
        _EdgeFoamIntensity("Edge Foam Intensity", Range(0, 100)) = 1
        _EdgeFoamCutoff("Edge Foam Cutoff", Range(0, 5)) = 1
        
        [Header(Foam)]
        _FoamUVTiling("Foam UV Tiling", Vector) = (1,1,0,0)
        _FoamSpeed("Foam Speed", Vector) = (1,1,0,0)
        _FoamIntensity("Foam Intensity", Range(0, 100)) = 1
        _FoamPower("Foam Power", Range(0, 20)) = 1
        _FoamRandomizeUV("Foam Randomize UV", Range(0, 1)) = 0.26
        
        [Header(Flow)]
        _FlowUVTiling("Flow UV Tiling", Vector) = (1,1,0,0)
        _FlowSpeed("Flow Speed", Vector) = (0,-0.2,0,0)
        _FlowIntensity("Flow Intensity", Range(0, 100)) = 1
        _FlowPower("Flow Power", Range(0, 20)) = 1
        _FlowRandomizeUV("Flow Randomize UV", Range(0, 1)) = 0.26
        
        [Header(Normal)]
        _NormalUVTiling("Normal UV Tiling", Vector) = (1,1,0,0)
        _NormalSpeed("Normal Speed", Vector) = (0,-0.2,0,0)
        _NormalIntensity("Normal Intensity", Range(0, 1)) = 0.5
        _NormalRandomizeUV("Normal Randomize UV", Range(0, 1)) = 0.26
        
        [Header(Displacement)]
        _HeightUVTiling("Height UV Tiling", Vector) = (1,1,0,0)
        _HeightSpeed("Height Speed", Vector) = (1,1,0,0)
        _HeightIntensity("Height Intensity", Float) = 1
        _HeightPower("Height Power", Float) = 1
        _HeightRandomizeUV("Height Randomize UV", Range(0, 1)) = 0.26
        
        [Header(PBR)]
        _Metallic("Metallic", Range(0, 1)) = 0.2
        _Roughness("Roughness", Range(0, 1)) = 0.05
        _Opacity("Opacity", Range(0, 1)) = 1
        
        [Toggle(_USESTEPFORFLOW_ON)] _useStepforFlow("use Step for Flow?", Float) = 0
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "Transparent" 
            "Queue" = "Transparent" 
            "RenderPipeline" = "UniversalPipeline"
        }
        
        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }
            
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite On
            ZTest LEqual
            Cull Back
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _SHADOWS_SOFT
            #pragma multi_compile_fog
            
            #pragma shader_feature_local _USESTEPFORFLOW_ON
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 positionWS : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float4 tangentWS : TEXCOORD2;
                float2 uv : TEXCOORD3;
                float4 screenPos : TEXCOORD4;
                float fogCoord : TEXCOORD5;
                float3 viewDirWS : TEXCOORD6;
                float4 shadowCoord : TEXCOORD7;
            };

            TEXTURE2D(_HeightMap);            SAMPLER(sampler_HeightMap);
            TEXTURE2D(_FlowMask);             SAMPLER(sampler_FlowMask);
            TEXTURE2D(_FoamMask);             SAMPLER(sampler_FoamMask);
            TEXTURE2D(_NormalMap);            SAMPLER(sampler_NormalMap);
            
            CBUFFER_START(UnityPerMaterial)
            float4 _ColorShallow;
            float4 _ColorDeep;
            float4 _WaterFoamColor;
            float2 _FlowSpeed;
            float2 _HeightSpeed;
            float2 _HeightUVTiling;
            float2 _FoamSpeed;
            float2 _FoamUVTiling;
            float2 _FlowUVTiling;
            float2 _NormalUVTiling;
            float2 _NormalSpeed;
            float2 _EdgeFoamSpeed;
            float _HeightIntensity;
            float _FoamPower;
            float _NormalIntensity;
            float _RefractionStrength;
            float _RefractionDepth;
            float _Metallic;
            float _NormalRandomizeUV;
            float _FoamRandomizeUV;
            float _FlowRandomizeUV;
            float _FlowPower;
            float _Roughness;
            float _FlowIntensity;
            float _EdgeFoamIntensity;
            float _EdgeFoamScale;
            float _EdgeFoamCutoff;
            float _EdgeFoamDepthFade;
            float _WaterFoamColorIntensity;
            float _ColorDepthFade;
            float _HeightPower;
            float _HeightRandomizeUV;
            float _FoamIntensity;
            float _Opacity;
            CBUFFER_END

            float2 Panner(float2 uv, float2 speed, float time)
            {
                return uv + speed * time;
            }

            float SimpleNoise(float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233)) * 43758.5453));
            }

            Varyings vert(Attributes input)
            {
                Varyings output;
                
                // 高度图位移
                float time = _TimeParameters.x;
                float2 heightUV = input.uv * _HeightUVTiling;
                float2 panner1 = Panner(heightUV, _HeightSpeed, time);
                float2 panner2 = Panner(heightUV + float2(0.45, 0.3), _HeightSpeed * float2(-1, -1), time);
                float2 panner3 = Panner(heightUV + float2(0.85, 0.14), _HeightSpeed * float2(-1, 1), time);
                
                float height1 = SAMPLE_TEXTURE2D_LOD(_HeightMap, sampler_HeightMap, panner1, 0).r;
                float height2 = SAMPLE_TEXTURE2D_LOD(_HeightMap, sampler_HeightMap, panner2, 0).r;
                float height3 = SAMPLE_TEXTURE2D_LOD(_HeightMap, sampler_HeightMap, panner3, 0).r;
                
                float height = (height1 + height2 + height3) / 3.0;
                height = pow(height, _HeightPower) * _HeightIntensity;
                
                float3 displacement = input.normalOS * height;
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz + displacement);
                
                output.positionCS = vertexInput.positionCS;
                output.positionWS = vertexInput.positionWS;
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.tangentWS = float4(TransformObjectToWorldDir(input.tangentOS.xyz), input.tangentOS.w);
                output.uv = input.uv;
                output.screenPos = ComputeScreenPos(output.positionCS);
                output.fogCoord = ComputeFogFactor(vertexInput.positionCS.z);
                output.viewDirWS = GetWorldSpaceNormalizeViewDir(vertexInput.positionWS);
                output.shadowCoord = TransformWorldToShadowCoord(output.positionWS);
                
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // 深度计算
                float2 screenUV = input.screenPos.xy / input.screenPos.w;
                float sceneDepth = LinearEyeDepth(SampleSceneDepth(screenUV), _ZBufferParams);
                float surfaceDepth = LinearEyeDepth(input.positionCS.z, _ZBufferParams);
                float depthDifference = sceneDepth - surfaceDepth;
                
                // 基础颜色
                float depthFade = saturate(depthDifference / _ColorDepthFade);
                half4 waterColor = lerp(_ColorShallow, _ColorDeep, depthFade);
                
                // 法线计算
                float2 normalUV = input.uv * _NormalUVTiling;
                float2 panner1 = Panner(normalUV, _NormalSpeed, _Time.y);
                float2 panner2 = Panner(normalUV + float2(0.45, 0.3), _NormalSpeed * float2(-1, -1), _Time.y);
                float2 panner3 = Panner(normalUV + float2(0.85, 0.14), _NormalSpeed * float2(-1, 1), _Time.y);
                
                half3 normal1 = UnpackNormalScale(SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, panner1), _NormalIntensity);
                half3 normal2 = UnpackNormalScale(SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, panner2), _NormalIntensity);
                half3 normal3 = UnpackNormalScale(SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, panner3), _NormalIntensity);
                
                half3 normalTS = normalize(normal1 + normal2 + normal3);
                half3 normalWS = TransformTangentToWorld(normalTS, half3x3(input.tangentWS.xyz, cross(input.normalWS, input.tangentWS.xyz) * input.tangentWS.w, input.normalWS));
                
                // 边缘泡沫
                float edgeDepthFade = saturate(depthDifference / _EdgeFoamDepthFade);
                float2 edgeUV = input.uv * _EdgeFoamScale;
                float2 edgePanner = Panner(edgeUV, _EdgeFoamSpeed, _Time.y * 0.1);
                float noise = SimpleNoise(edgePanner * 50.0);
                float edgeFoam = step(edgeDepthFade * _EdgeFoamCutoff, noise) * _EdgeFoamIntensity;
                
                // 水流效果
                float2 flowUV = input.uv * _FlowUVTiling;
                float2 flowPanner1 = Panner(flowUV, _FlowSpeed, _Time.y);
                float2 flowPanner2 = Panner(flowUV + float2(0.45, 0.3), _FlowSpeed * float2(-1, -1), _Time.y);
                float2 flowPanner3 = Panner(flowUV + float2(0.85, 0.14), _FlowSpeed * float2(-1, 1), _Time.y);
                
                half flow1 = SAMPLE_TEXTURE2D(_FlowMask, sampler_FlowMask, flowPanner1).r;
                half flow2 = SAMPLE_TEXTURE2D(_FlowMask, sampler_FlowMask, flowPanner2).r;
                half flow3 = SAMPLE_TEXTURE2D(_FlowMask, sampler_FlowMask, flowPanner3).r;
                
                half flow = pow((flow1 + flow2 + flow3) / 3.0, _FlowPower) * _FlowIntensity;
                
                // 表面泡沫
                float2 foamUV = input.uv * _FoamUVTiling;
                float2 foamPanner1 = Panner(foamUV, _FoamSpeed, _Time.y);
                float2 foamPanner2 = Panner(foamUV + float2(0.45, 0.3), _FoamSpeed * float2(-1, -1), _Time.y);
                float2 foamPanner3 = Panner(foamUV + float2(0.85, 0.14), _FoamSpeed * float2(-1, 1), _Time.y);
                
                half foam1 = SAMPLE_TEXTURE2D(_FoamMask, sampler_FoamMask, foamPanner1).r;
                half foam2 = SAMPLE_TEXTURE2D(_FoamMask, sampler_FoamMask, foamPanner2).r;
                half foam3 = SAMPLE_TEXTURE2D(_FoamMask, sampler_FoamMask, foamPanner3).r;
                
                half surfaceFoam = pow((foam1 + foam2 + foam3) / 3.0, _FoamPower) * _FoamIntensity;
                
                // 泡沫混合
                half foamMask = edgeFoam + flow;
                #ifdef _USESTEPFORFLOW_ON
                    half foam = step(foamMask, surfaceFoam) + edgeFoam;
                #else
                    half foam = saturate(foamMask - surfaceFoam);
                #endif
                
                half4 foamColor = _WaterFoamColor * foam * _WaterFoamColorIntensity;
                
                // 折射效果
                float2 refractionOffset = normalTS.xy * _RefractionStrength * 0.1;
                float2 refractedUV = screenUV + refractionOffset;
                float refractedDepth = LinearEyeDepth(SampleSceneDepth(refractedUV), _ZBufferParams);
                float depthMask = saturate((sceneDepth - surfaceDepth) / _RefractionDepth);
                
                // 最终颜色合成
                half4 finalColor = waterColor + foamColor;
                finalColor.rgb = lerp(waterColor.rgb, finalColor.rgb, depthMask);
                finalColor.a = _Opacity;
                
                // 光照计算
                Light mainLight = GetMainLight(input.shadowCoord);
                float3 lightDir = mainLight.direction;
                float3 viewDir = input.viewDirWS;
                float3 halfVec = normalize(lightDir + viewDir);
                
                float NdotL = saturate(dot(normalWS, lightDir));
                float NdotH = saturate(dot(normalWS, halfVec));
                float NdotV = saturate(dot(normalWS, viewDir));
                
                // 粗糙度处理
                float roughness = 1.0 - _Roughness;
                roughness = roughness * roughness;
                
                // 菲涅尔效应
                float fresnel = pow(1.0 - NdotV, 5.0);
                
                // 高光反射
                float3 specular = fresnel * pow(NdotH, exp2(10.0 * roughness + 1.0)) * _Metallic;
                
                // 组合光照
                float3 ambient = SampleSH(normalWS);
                float3 diffuse = mainLight.color * NdotL;
                float3 color = (ambient + diffuse) * finalColor.rgb + specular;
                
                // 雾效
                color = MixFog(color, input.fogCoord);
                
                return half4(color, finalColor.a);
            }
            ENDHLSL
        }
    }
    
    FallBack "Universal Render Pipeline/Simple Lit"
}