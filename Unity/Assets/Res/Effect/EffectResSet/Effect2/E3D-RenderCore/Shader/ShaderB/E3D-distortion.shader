Shader "E3DEffect/heat-distortion"
{
    Properties
    {
        _NoiseTex ("Noise Texture (RG)", 2D) = "white" {}
        _MainTex ("Alpha (A)", 2D) = "white" {}
        _HeatTime ("Heat Time", range (0,1.5)) = 1
        _HeatForce ("Heat Force", range (0,6)) = 0.1
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent+1" "RenderType"="Transparent" "RenderPipeline"="UniversalPipeline"
        }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off Lighting Off ZWrite Off ZTest LEqual

        Pass
        {
            Name "BASE"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

            struct Attributes
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct Varyings
            {
                float4 position : SV_POSITION;
                float2 uvgrab : TEXCOORD0;
                float2 uvmain : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
            };

            TEXTURE2D(_NoiseTex);
            SAMPLER(sampler_NoiseTex);
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURE2D(_CameraOpaqueTexture);
            SAMPLER(sampler_CameraOpaqueTexture);

            float _HeatForce;
            float _HeatTime;

            Varyings vert (Attributes v)
            {
                Varyings o;
                o.position = TransformObjectToHClip(v.vertex);
                o.uvmain = v.texcoord;
                o.screenPos = ComputeScreenPos(o.position);

                // Correct for UV flip if necessary
                #if UNITY_UV_STARTS_AT_TOP
                float scale = -1.0;
                #else
                float scale = 1.0;
                #endif
                o.uvgrab = (o.screenPos.xy / o.screenPos.w) * 0.5 + 0.5;
                o.uvgrab.y *= scale;

                return o;
            }

            half4 frag (Varyings i) : SV_Target
            {
                // Noise effect
                half4 offsetColor1 = SAMPLE_TEXTURE2D(_NoiseTex, sampler_NoiseTex, i.uvmain + _Time.xz * _HeatTime);
                half4 offsetColor2 = SAMPLE_TEXTURE2D(_NoiseTex, sampler_NoiseTex, i.uvmain - _Time.yx * _HeatTime);
                i.uvgrab.x += ((offsetColor1.r + offsetColor1.r) - 1) * _HeatForce;
                i.uvgrab.y += ((offsetColor2.g + offsetColor2.g) - 1) * _HeatForce;

                // Grab texture
                half4 col = SAMPLE_TEXTURE2D(_CameraOpaqueTexture, sampler_CameraOpaqueTexture, i.uvgrab);
                col.a = 1.0f;
                half4 tint = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uvmain);
                tint.rgb = float3(1.0f, 1.0f, 1.0f);

                return col * tint;
            }
            ENDHLSL
        }
    }

    // Fallback for older cards and Unity non-Pro
    SubShader
    {
        Blend DstColor Zero
        Pass
        {
            Name "BASE"
            SetTexture [_MainTex] { combine texture }
        }
    }
}