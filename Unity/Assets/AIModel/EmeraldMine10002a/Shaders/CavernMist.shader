Shader "EmeraldMine10002a/QuietCavernMist" {
 Properties {_BaseColor("Mist tint",Color)=(.14,.34,.29,.075)}
 SubShader {Tags{"RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent+30"}
 Pass {Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Off
 HLSLPROGRAM
 #pragma vertex Vert
 #pragma fragment Frag
 #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
 CBUFFER_START(UnityPerMaterial)
 half4 _BaseColor;
 CBUFFER_END
 struct A{float4 positionOS:POSITION;float2 uv:TEXCOORD0;half4 color:COLOR;};
 struct V{float4 positionCS:SV_POSITION;float2 uv:TEXCOORD0;float3 world:TEXCOORD1;half alpha:COLOR;};
 V Vert(A i){V o;o.world=TransformObjectToWorld(i.positionOS.xyz);o.positionCS=TransformWorldToHClip(o.world);o.uv=i.uv;o.alpha=i.color.a;return o;}
 half4 Frag(V i):SV_Target {half w=sin(i.world.x*.47+_Time.y*.035)*sin(i.world.z*.39-_Time.y*.025)*.20+.55;return half4(_BaseColor.rgb,_BaseColor.a*i.alpha*w);}
 ENDHLSL
 }}Fallback Off
}
