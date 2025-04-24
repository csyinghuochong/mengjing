Shader "E3D/EffectEN/ADD_Top"
{
    Properties
    {
        _MainTex("MainTex", 2D) = "white" {}
        [HDR]_MainColor("MainColor", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque" "Queue" = "Overlay+0"
        }
        Cull Off
        ZWrite Off
        ZTest Always
        Blend One One

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            // Properties
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _MainColor;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = TransformObjectToHClip(IN.positionOS);
                OUT.color = IN.color;
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);
                float4 mainColor = _MainColor;
                float4 vertexColor = IN.color;

                // Calculate final color
                float4 finalColor;
                finalColor.rgb = (vertexColor * texColor * mainColor).rgb;
                finalColor.a = 1;
                return finalColor;
            }

            ENDHLSL
        }
    }

    CustomEditor "ASEMaterialInspector"
}