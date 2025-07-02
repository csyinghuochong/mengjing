// Made with Amplify Shader Editor v1.9.1.3
Shader "Polyart/Dreamscape/URP/Water Lake"
{
    Properties
    {
        [HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
        [HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
        [Header(COLOR)]_ColorShallow("Color Shallow", Color) = (0.5990566,0.9091429,1,0)
        _ColorDeep("Color Deep", Color) = (0.1213065,0.347919,0.5471698,0)
        _ColorDepthFade("Color Depth Fade", Float) = 0
        _Smoothness("Smoothness", Range(0, 1)) = 0
        _Opacity("Opacity", Range(0, 1)) = 1
        [Header(FOAM)]_FoamColor("Foam Color", Color) = (1,1,1,1)
        _FoamDepthFade("Foam Depth Fade", Float) = 0.19
        _FoamCutoff("Foam Cutoff", Float) = 0
        _FoamScale("Foam Scale", Float) = 2
        _FoamSpeed("Foam Speed", Float) = 1
        [Header(REFRACTION)]_RefractionStrength("Refraction Strength", Float) = 0
        _RefractionDepth("Refraction Depth", Float) = 0
        [Header(WAVES)]_WaveNormal("Wave Normal", 2D) = "bump" {}
        _WaveNormalIntensity("Wave Normal Intensity", Range(0, 1)) = 1
        _Displacement("Displacement", 2D) = "gray" {}
        _DisplaceStrength("Displace Strength", Range(-1, 1)) = 0
        [IntRange]_WaveTiling01("Wave Tiling 01", Range(0, 50)) = 1
        [IntRange]_WaveTiling02("Wave Tiling 02", Range(0, 50)) = 1
    }

    SubShader
    {
        Tags { 
            "RenderPipeline"="UniversalPipeline" 
            "RenderType"="Transparent" 
            "Queue"="Transparent" 
        }
        
        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode"="UniversalForward" }
            
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            ZTest LEqual
            Cull Back

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct VertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct VertexOutput
            {
                float4 clipPos : SV_POSITION;
                float4 screenPos : TEXCOORD0;
                float2 uv : TEXCOORD1;
            };

            // Material Properties
            CBUFFER_START(UnityPerMaterial)
                float4 _ColorShallow;
                float4 _ColorDeep;
                float4 _FoamColor;
                float _WaveTiling01;
                float _WaveTiling02;
                float _DisplaceStrength;
                float _ColorDepthFade;
                float _FoamSpeed;
                float _FoamScale;
                float _RefractionStrength;
                float _RefractionDepth;
                float _FoamDepthFade;
                float _FoamCutoff;
                float _WaveNormalIntensity;
                float _Smoothness;
                float _Opacity;
            CBUFFER_END

            // Texture Samplers
            TEXTURE2D(_CameraOpaqueTexture);
            SAMPLER(sampler_CameraOpaqueTexture);
            TEXTURE2D(_CameraDepthTexture);
            SAMPLER(sampler_CameraDepthTexture);
            TEXTURE2D(_WaveNormal);
            SAMPLER(sampler_WaveNormal);

            // 优化的噪声函数
            float SimpleNoise(float2 UV)
            {
                float2 p = floor(UV);
                float2 f = frac(UV);
                
                float a = dot(p, float2(12.9898, 78.233));
                float b = dot(p + float2(1, 0), float2(12.9898, 78.233));
                float c = dot(p + float2(0, 1), float2(12.9898, 78.233));
                float d = dot(p + float2(1, 1), float2(12.9898, 78.233));
                
                a = frac(sin(a) * 43758.5453);
                b = frac(sin(b) * 43758.5453);
                c = frac(sin(c) * 43758.5453);
                d = frac(sin(d) * 43758.5453);
                
                float2 u = f * f * (3.0 - 2.0 * f);
                return lerp(lerp(a, b, u.x), lerp(c, d, u.x), u.y);
            }

            VertexOutput vert(VertexInput v)
            {
                VertexOutput o;
                o.uv = v.uv;
                o.clipPos = TransformObjectToHClip(v.vertex.xyz);
                o.screenPos = ComputeScreenPos(o.clipPos);
                return o;
            }

            half4 frag(VertexOutput IN) : SV_Target
            {
                // 屏幕空间计算
                float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
                float rawDepth = SAMPLE_TEXTURE2D(_CameraDepthTexture, sampler_CameraDepthTexture, screenUV).r;
                float sceneDepth = LinearEyeDepth(rawDepth, _ZBufferParams);
                float surfaceDepth = LinearEyeDepth(IN.screenPos.z, _ZBufferParams);
                float depthDifference = sceneDepth - surfaceDepth;
                
                // 基础颜色计算
                float depthFade = saturate(depthDifference / _ColorDepthFade);
                float4 waterColor = lerp(_ColorShallow, _ColorDeep, depthFade);
                
                // 泡沫计算
                float foamDepthFade = saturate(depthDifference / _FoamDepthFade);
                float foamThreshold = foamDepthFade * _FoamCutoff;
                
                // 优化后的噪声计算
                float noiseTime = _Time.y * _FoamSpeed * 0.1;
                float2 noiseUV = IN.uv * _FoamScale + float2(noiseTime, noiseTime * 0.8);
                float noise = SimpleNoise(noiseUV);
                
                float foam = step(foamThreshold, noise);
                
                // 法线计算（仅用于折射）
                float waveTime = _Time.y * 0.07;
                float2 waveUV1 = IN.uv * _WaveTiling01 + float2(waveTime, waveTime * 1.2);
                float2 waveUV2 = IN.uv * _WaveTiling02 - float2(waveTime, waveTime * 0.7);
                
                // 只采样法线贴图的RG通道，忽略B通道
                float2 normalSample1 = SAMPLE_TEXTURE2D(_WaveNormal, sampler_WaveNormal, waveUV1).rg;
                float2 normalSample2 = SAMPLE_TEXTURE2D(_WaveNormal, sampler_WaveNormal, waveUV2).rg;
                
                // 直接组合法线偏移
                float2 combinedNormalOffset = (normalSample1 + normalSample2) * _WaveNormalIntensity;
                
                // 折射计算
                float refractionFactor = saturate(depthDifference / _RefractionDepth);
                float2 refractionOffset = combinedNormalOffset * _RefractionStrength * refractionFactor * 0.01;
                
                // 采样折射颜色
                float4 refractionColor = SAMPLE_TEXTURE2D(_CameraOpaqueTexture, sampler_CameraOpaqueTexture, screenUV + refractionOffset);
                
                // 颜色混合
                float4 baseColor = lerp(refractionColor, waterColor, refractionFactor);
                float4 finalColor = lerp(baseColor, _FoamColor, foam * _FoamColor.a);
                
                // 简化的光照计算（环境光 + 主光源）
                Light mainLight = GetMainLight();
                half3 ambient = SampleSH(float3(0, 1, 0)); // 使用朝上的法线获取环境光
                half3 lighting = ambient + mainLight.color * 0.5;
                
                // 应用光照
                finalColor.rgb *= lighting;
                
                // 最终输出
                half4 color = half4(finalColor.rgb, _Opacity);
                color.rgb = MixFog(color.rgb, IN.screenPos.w);
                return color;
            }
            ENDHLSL
        }
    }
    FallBack "Hidden/InternalErrorShader"
}