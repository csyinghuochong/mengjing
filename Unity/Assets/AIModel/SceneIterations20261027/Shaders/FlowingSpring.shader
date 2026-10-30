Shader "SceneIterations20261027/FlowingSpring" {
 Properties { _Color("Water",Color)=(.24,.78,.66,.62) }
 SubShader {
  Tags {"RenderPipeline"="UniversalPipeline" "Queue"="Transparent" "RenderType"="Transparent"}
  Pass {
   Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Off
   HLSLPROGRAM
   #pragma vertex vert
   #pragma fragment frag
   #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
   struct A{float4 positionOS:POSITION;float2 uv:TEXCOORD0;};
   struct V{float4 positionCS:SV_POSITION;float2 uv:TEXCOORD0;};
   CBUFFER_START(UnityPerMaterial)
   half4 _Color;
   CBUFFER_END
   V vert(A i){V o;o.positionCS=TransformObjectToHClip(i.positionOS.xyz);o.uv=i.uv;return o;}
   half4 frag(V i):SV_Target{
    float streak=pow(saturate(sin(i.uv.x*52+sin(i.uv.y*8-_Time.y*2)*.7)),8);
    float flow=sin(i.uv.y*31-_Time.y*3+i.uv.x*5)*.07;
    half edge=smoothstep(0,.14,i.uv.x)*smoothstep(0,.14,1-i.uv.x);
    return half4(_Color.rgb*(.7+streak*.6+flow),_Color.a*edge);
   }
   ENDHLSL
  }
 }
}
