Shader "Toon/Basic"
{
    Properties
    {
        _Color ("Main Color", Color) = (.5,.5,.5,1)
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _ToonShade ("ToonShader Cubemap(RGB)", CUBE) = "" { }
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline" }
        Pass
        {
            Name "BASE"
            Cull Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // URP specific includes
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURECUBE(_ToonShade);
            SAMPLER(sampler_ToonShade);
            float4 _MainTex_ST;
            float4 _Color;

            struct Attributes
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
                float3 normal : NORMAL;

                // Add instance ID
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 pos : SV_POSITION;
                float2 texcoord : TEXCOORD0;
                float3 cubenormal : TEXCOORD1;
                //UNITY_FOG_COORDS(2)  20240624 error

                // Add instance ID
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            Varyings vert(Attributes v)
            {
                Varyings o;

                // Set up instance ID
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);

                o.pos = TransformObjectToHClip(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.cubenormal = mul(GetObjectToWorldMatrix(), float4(v.normal, 0.0)).xyz;
                //UNITY_TRANSFER_FOG(o, o.pos);  20240624 error
                return o;
            }

            half4 frag(Varyings i) : SV_Target
            {
                // Set up instance ID
                UNITY_SETUP_INSTANCE_ID(i);

                half4 col = _Color * SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
                half4 cube = SAMPLE_TEXTURECUBE(_ToonShade, sampler_ToonShade, i.cubenormal);
                half4 c = half4(3.0f * cube.rgb * col.rgb, col.a);
                //UNITY_APPLY_FOG(i.fogCoord, c); // 20240624 error
                return c;
            }
            ENDHLSL
        }
    }

    Fallback "VertexLit"
}
