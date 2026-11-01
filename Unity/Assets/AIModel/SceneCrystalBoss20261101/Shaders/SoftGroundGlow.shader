Shader "CrystalBoss/SoftGroundGlow" {
 Properties { _Tint("Tint",Color)=(1,.5,.15,1) }
 SubShader { Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent+10" }
  Pass { Blend One One ZWrite Off Cull Off
   HLSLPROGRAM
   #pragma vertex vert
   #pragma fragment frag
   #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
   CBUFFER_START(UnityPerMaterial)
    half4 _Tint;
   CBUFFER_END
   struct A { float4 positionOS:POSITION; half4 color:COLOR; };
   struct V { float4 positionCS:SV_POSITION; half4 color:COLOR; };
   V vert(A i){V o;o.positionCS=TransformObjectToHClip(i.positionOS.xyz);o.color=i.color;return o;}
   half4 frag(V i):SV_Target{return half4(_Tint.rgb*i.color.a,i.color.a);}
   ENDHLSL
  }
 }
}
