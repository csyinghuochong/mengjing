Shader "GAP/AdditiveMobileDistortionScroll" {
    Properties {
        _TintColor ("Color", Color) = (1,0.5342799,0.1764706,1)
        _ColorRamp ("Color Ramp", 2D) = "white" {}
        _ColorMultiplier ("Color Multiplier", Range(0, 10)) = 1.32872
        _MainTextureUSpeed ("Main Texture U Speed", Float ) = 0
        _MainTextureVSpeed ("Main Texture V Speed", Float ) = 0
        _MainTexture ("Main Texture", 2D) = "white" {}
        [MaterialToggle] _DistortMainTexture ("Distort Main Texture", Float ) = 0
        _GradientPower ("Gradient Power", Range(0, 50)) = 2.214298
        _GradientUSpeed ("Gradient U Speed", Float ) = -0.2
        _GradientVSpeed ("Gradient V Speed", Float ) = -0.2
        _Gradient ("Gradient", 2D) = "white" {}
        _NoiseAmount ("Noise Amount", Range(-1, 1)) = 0.1144851
        _DistortionUSpeed ("Distortion U Speed", Float ) = 0.2
        _DistortionVSpeed ("Distortion V Speed", Float ) = 0
        _Distortion ("Distortion", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _DoubleSided ("Double Sided", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }
        Pass {
            Name "ForwardLit"
            Tags {
                "LightMode"="UniversalForward"
            }
            Blend One One
            Cull Off
            ZWrite Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            TEXTURE2D(_MainTexture); SAMPLER(sampler_MainTexture);
            float4 _MainTexture_ST;
            float4 _TintColor;
            float _GradientUSpeed;
            float _GradientVSpeed;
            TEXTURE2D(_Gradient); SAMPLER(sampler_Gradient);
            float4 _Gradient_ST;
            float _NoiseAmount;
            TEXTURE2D(_Distortion); SAMPLER(sampler_Distortion);
            float4 _Distortion_ST;
            float _DistortMainTexture;
            float _DistortionUSpeed;
            float _DistortionVSpeed;
            float _GradientPower;
            float _ColorMultiplier;
            TEXTURE2D(_Mask); SAMPLER(sampler_Mask);
            float4 _Mask_ST;
            TEXTURE2D(_ColorRamp); SAMPLER(sampler_ColorRamp);
            float4 _ColorRamp_ST;
            float _MainTextureVSpeed;
            float _MainTextureUSpeed;
            float _DoubleSided;

            struct Attributes {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct Varyings {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            Varyings vert (Attributes v) {
                Varyings o;
                o.position = TransformObjectToHClip(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTexture);
                o.worldPos = TransformObjectToWorld(v.vertex.xyz);
                return o;
            }

            float4 frag (Varyings i) : SV_Target {
                float2 mainTexCoords = i.uv + float2(_MainTextureUSpeed, _MainTextureVSpeed) * _Time.y;
                float4 mainTexColor = SAMPLE_TEXTURE2D(_MainTexture, sampler_MainTexture, mainTexCoords);
                float2 gradientTexCoords = i.uv + float2(_GradientUSpeed, _GradientVSpeed) * _Time.y;
                float4 gradientTexColor = SAMPLE_TEXTURE2D(_Gradient, sampler_Gradient, gradientTexCoords);
                float2 distortionTexCoords = i.uv + float2(_DistortionUSpeed, _DistortionVSpeed) * _Time.y;
                float4 distortionTexColor = SAMPLE_TEXTURE2D(_Distortion, sampler_Distortion, distortionTexCoords);
                float4 maskTexColor = SAMPLE_TEXTURE2D(_Mask, sampler_Mask, i.uv);

                float2 distortedUV = i.uv + (distortionTexColor.rg - 0.5) * _NoiseAmount;
                float4 finalColor = mainTexColor * _ColorMultiplier * _TintColor * float4(gradientTexColor.rgb, 1.0) * maskTexColor.a;
                finalColor.rgb *= pow(gradientTexColor.r, _GradientPower);

                return finalColor;
            }
            ENDHLSL
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}