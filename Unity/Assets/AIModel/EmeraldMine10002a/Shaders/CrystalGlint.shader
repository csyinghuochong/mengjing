Shader "EmeraldMine10002a/SparseCrystalGlint"
{
    Properties{[HDR]_Tint("Glint",Color)=(1.8,1.8,1.8,1)}
    SubShader
    {
        Tags{"RenderPipeline"="UniversalPipeline" "Queue"="Transparent" "RenderType"="Transparent"}
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
            struct Attributes{float4 positionOS:POSITION;half4 color:COLOR;float2 uv:TEXCOORD0;};
            struct Varyings{float4 positionCS:SV_POSITION;half4 color:COLOR;float2 uv:TEXCOORD0;};
            Varyings vert(Attributes v){Varyings o;o.positionCS=TransformObjectToHClip(v.positionOS.xyz);o.color=v.color;o.uv=v.uv;return o;}
            half4 frag(Varyings i):SV_Target
            {
                float2 p=abs(i.uv*2-1);
                half cross=exp(-p.x*38-p.y*4.8)+exp(-p.y*38-p.x*4.8);
                half core=exp(-dot(p,p)*105);half edge=saturate(1-max(p.x,p.y));
                return half4(_Tint.rgb*i.color.rgb,saturate(cross*.55+core*.60)*edge*i.color.a*_Tint.a);
            }
            ENDHLSL
        }
    }
}
