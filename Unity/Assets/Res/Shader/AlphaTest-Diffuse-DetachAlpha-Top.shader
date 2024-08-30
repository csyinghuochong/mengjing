Shader "URP/Custom/TransparentDiffuseDetachAlphaTop"
{
    Properties
    {
        _MainTex ("LightMap Base (RGB) A", 2D) = "white" {}
        _MainTexLM ("Base (RGB)", 2D) = "white" {}
        _AlphaTexLM ("Trans (A)", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "Queue" = "Transparent+1" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        LOD 200

        Pass
        {
            Name "ForwardPass"
            Tags { "LightMode" = "UniversalForward" }
            
            Blend SrcAlpha OneMinusSrcAlpha

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_MainTexLM);
            SAMPLER(sampler_MainTexLM);
            TEXTURE2D(_AlphaTexLM);
            SAMPLER(sampler_AlphaTexLM);

            Varyings vert(Attributes v)
            {
                Varyings o;
                o.positionHCS = TransformObjectToHClip(v.positionOS);
                o.uv = v.uv;
                return o;
            }

            half4 frag(Varyings i) : SV_Target
            {
                half4 color = SAMPLE_TEXTURE2D(_MainTexLM, sampler_MainTexLM, i.uv);
                half4 alpha = SAMPLE_TEXTURE2D(_AlphaTexLM, sampler_AlphaTexLM, i.uv);
                return half4(color.rgb, alpha.x);
            }
            ENDHLSL
        }
    }

    Fallback "Transparent/VertexLit"
}


//Shader "Transparent/DiffuseDetachAlphaTop" {
//Properties {
//	//_MainTex ("LigthMap Base (RGB) A", 2D) = "white" {}
//	_MainTexLM ("Base (RGB)", 2D) = "white" {}
//	_AlphaTexLM ("Trans (A)", 2D) = "white" {}
//}
//
//SubShader {
//	Tags {"Queue"="Transparent+1" "IgnoreProjector"="True" "RenderType"="Transparent"}
//	LOD 200
//
//CGPROGRAM
//#pragma surface surf Lambert alpha
//
//sampler2D _MainTexLM;
//sampler2D _AlphaTexLM;
//
//struct Input {
//	float2 uv_MainTexLM;
//	float2 uv_AlphaTexLM;
//};
//
//void surf (Input IN, inout SurfaceOutput o) {
//	fixed4 c = tex2D(_MainTexLM, IN.uv_MainTexLM);
//	fixed4 a = tex2D(_AlphaTexLM, IN.uv_AlphaTexLM);
//	o.Albedo = c.rgb;
//	o.Alpha = a;   //o.Alpha = a.x;
//}
//ENDCG
//}
//
//Fallback "Transparent/VertexLit"
//}
