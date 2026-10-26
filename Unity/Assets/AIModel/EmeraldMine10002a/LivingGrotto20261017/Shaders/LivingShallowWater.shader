Shader "EmeraldMine10002a/LivingShallowWater" {
 Properties {
 _ShallowColor("Jade shallows",Color)=(.075,.58,.46,.78)
 _DeepColor("Turquoise centre",Color)=(.025,.29,.28,.87)
 _EmissionColor("Soft water bounce",Color)=(.008,.055,.045,1)
 _Smoothness("Gentle wet sheen",Range(0,1))=.5
 _FlowSpeed("Flow",Float)=.18
 }
 SubShader {
 Tags {"RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent"}
 Pass {
 Name "ForwardLit" Tags {"LightMode"="UniversalForward"}
 Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Off
 HLSLPROGRAM
 #pragma target 3.0
 #pragma vertex Vert
 #pragma fragment Frag
 #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
 #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
 #pragma multi_compile_fog
 #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
 #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
 CBUFFER_START(UnityPerMaterial)
 half4 _ShallowColor,_DeepColor,_EmissionColor;half _Smoothness,_FlowSpeed;
 CBUFFER_END
 struct A{float4 positionOS:POSITION;float3 normalOS:NORMAL;half4 color:COLOR;float2 uv:TEXCOORD0;};
 struct V{float4 positionCS:SV_POSITION;float3 positionWS:TEXCOORD0;half3 normalWS:TEXCOORD1;half4 color:COLOR;half fog:TEXCOORD2;};
 V Vert(A i){V o;VertexPositionInputs p=GetVertexPositionInputs(i.positionOS.xyz);o.positionCS=p.positionCS;o.positionWS=p.positionWS;o.normalWS=TransformObjectToWorldNormal(i.normalOS);o.color=i.color;o.fog=ComputeFogFactor(p.positionCS.z);return o;}
 half4 Frag(V i):SV_Target{
 float t=_Time.y*_FlowSpeed;float2 p=i.positionWS.xz;
 half waves=sin(p.x*2.5+sin(p.y*2.2)+t)*sin(p.y*3.2-p.x*.65-t*.7);
 half caustics=pow(saturate(1-abs(sin(p.x*3.1+sin(p.y*2.8)+t)*sin(p.y*3.4-p.x*.4-t))),22);
 half depth=saturate(i.color.a*1.35);half4 tint=lerp(_ShallowColor,_DeepColor,depth*.76);
 half3 n=normalize(i.normalWS+half3(cos(p.x*2.1+t),0,sin(p.y*1.8-t))*.016);
 SurfaceData s=(SurfaceData)0;s.albedo=tint.rgb*(.96+waves*.035);s.metallic=0;s.smoothness=_Smoothness;s.occlusion=1;s.alpha=1;s.normalTS=half3(0,0,1);s.emission=_EmissionColor.rgb+caustics*half3(.012,.040,.035);
 InputData d=(InputData)0;d.positionWS=i.positionWS;d.normalWS=n;d.viewDirectionWS=GetWorldSpaceNormalizeViewDir(i.positionWS);d.shadowCoord=TransformWorldToShadowCoord(i.positionWS);d.bakedGI=SampleSH(n);d.normalizedScreenSpaceUV=GetNormalizedScreenSpaceUV(i.positionCS);d.vertexLighting=VertexLighting(i.positionWS,n);d.shadowMask=1;
 half4 c=UniversalFragmentPBR(d,s);c.rgb=MixFog(c.rgb,i.fog);c.a=tint.a*smoothstep(0,.12,i.color.a);return c;
 }
 ENDHLSL
 }
 }
 Fallback Off
}
