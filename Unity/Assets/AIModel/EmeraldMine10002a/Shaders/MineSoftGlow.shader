Shader "EmeraldMine10002a/SoftCavernGlow"
{
    Properties{_Tint("Tint",Color)=(1,.3,.03,.3)}
    SubShader
    {
        Tags{"RenderPipeline"="UniversalPipeline" "Queue"="Transparent-10" "RenderType"="Transparent"}
        Pass
        {
            Blend SrcAlpha One
            ZWrite Off
            Cull Off
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            CBUFFER_START(UnityPerMaterial)
            half4 _Tint;
            CBUFFER_END
            struct Attributes{float4 positionOS:POSITION;float2 uv:TEXCOORD0;};
            struct Varyings{float4 positionCS:SV_POSITION;float2 uv:TEXCOORD0;};
            Varyings vert(Attributes input){Varyings o;o.positionCS=TransformObjectToHClip(input.positionOS.xyz);o.uv=input.uv;return o;}
            half4 frag(Varyings i):SV_Target{float2 p=i.uv*2-1;half a=pow(saturate(1-dot(p,p)),2.8);return half4(_Tint.rgb,a*_Tint.a);}
            ENDHLSL
        }
    }
}
