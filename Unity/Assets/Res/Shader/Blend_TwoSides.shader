Shader "Hovl/Particles/Blend_TwoSides_URP"
{
    Properties
    {
        _Cutoff( "Mask Clip Value", Float ) = 0.5
        _MainTex("Main Tex", 2D) = "white" {}
        _Mask("Mask", 2D) = "white" {}
        _Noise("Noise", 2D) = "white" {}
        _SpeedMainTexUVNoiseZW("Speed MainTex U/V + Noise Z/W", Vector) = (0,0,0,0)
        _FrontFacesColor("Front Faces Color", Color) = (0,0.2313726,1,1)
        _BackFacesColor("Back Faces Color", Color) = (0.1098039,0.4235294,1,1)
        _Emission("Emission", Float) = 2
        [Toggle]_UseFresnel("Use Fresnel?", Float) = 1
        [Toggle]_SeparateFresnel("SeparateFresnel", Float) = 0
        _SeparateEmission("Separate Emission", Float) = 2
        _FresnelColor("Fresnel Color", Color) = (1,1,1,1)
        _Fresnel("Fresnel", Float) = 1
        _FresnelEmission("Fresnel Emission", Float) = 1
        [Toggle]_UseCustomData("Use Custom Data?", Float) = 0
    }

    SubShader
    {
        Tags { "RenderType" = "TransparentCutout" "Queue" = "Transparent" }
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 uv2 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 uv2 : TEXCOORD1;
                float4 vertexColor : COLOR;
                float3 worldPos : TEXCOORD2;
                float3 worldNormal : TEXCOORD3;
                float3 viewDir : TEXCOORD4;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _Mask_ST;
                float4 _Noise_ST;
                float4 _SpeedMainTexUVNoiseZW;
                float4 _FrontFacesColor;
                float4 _BackFacesColor;
                float _Emission;
                float _Fresnel;
                float _FresnelEmission;
                float4 _FresnelColor;
                float _SeparateEmission;
                float _UseFresnel;
                float _SeparateFresnel;
                float _UseCustomData;
                float _Cutoff;
            CBUFFER_END

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            TEXTURE2D(_Mask);
            SAMPLER(sampler_Mask);

            TEXTURE2D(_Noise);
            SAMPLER(sampler_Noise);

            Varyings vert(Attributes input)
            {
                Varyings output;
                float3 worldPos = TransformObjectToWorld(input.positionOS.xyz);
                output.positionHCS = TransformWorldToHClip(worldPos);
                output.worldPos = worldPos;
                output.worldNormal = TransformObjectToWorldNormal(float3(0, 0, 1));
                output.viewDir = GetCameraPositionWS() - worldPos;
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                output.uv2 = input.uv2;
                output.vertexColor = input.vertexColor;
                return output;
            }

            half4 LightingUnlit(half4 color)
            {
                return color;
            }

            half4 frag(Varyings input) : SV_TARGET
            {
                float3 worldNormal = normalize(input.worldNormal);
                float3 viewDir = normalize(input.viewDir);
                float fresnelNdotV95 = dot(worldNormal, viewDir);
                float fresnelNode95 = pow(1.0 - fresnelNdotV95, _Fresnel);
                float dotResult87 = dot(worldNormal, viewDir);
                float4 lerpResult91 = lerp(lerp(_FrontFacesColor, (_FrontFacesColor * (1.0 - fresnelNode95) + _FresnelEmission * _FresnelColor * fresnelNode95), _UseFresnel), _BackFacesColor, step(0.0, dotResult87));
                float2 uv0_MainTex = input.uv;
                float2 appendResult21 = float2(_SpeedMainTexUVNoiseZW.x, _SpeedMainTexUVNoiseZW.y);
                float4 tex2DNode105 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv0_MainTex + appendResult21 * _Time.y);
                half4 finalColor = lerp(lerpResult91 * _Emission * input.vertexColor * tex2DNode105, (lerpResult91 + _FresnelColor * tex2DNode105 * _SeparateEmission) * _Emission, _SeparateFresnel);
                float2 uv_Mask = input.uv;
                float4 uv0_Noise = input.uv2;
                uv0_Noise.xy = uv0_Noise.xy * _Noise_ST.xy + _Noise_ST.zw;
                float2 appendResult22 = float2(_SpeedMainTexUVNoiseZW.z, _SpeedMainTexUVNoiseZW.w);
                clip(SAMPLE_TEXTURE2D(_Mask, sampler_Mask, uv_Mask) * SAMPLE_TEXTURE2D(_Noise, sampler_Noise, uv0_Noise.xy + _Time.y * appendResult22 + uv0_Noise.w) * lerp(1.0, uv0_Noise.z, _UseCustomData).r - _Cutoff);
                return half4(finalColor.rgb, 1);
            }
            ENDHLSL
        }
    }
}