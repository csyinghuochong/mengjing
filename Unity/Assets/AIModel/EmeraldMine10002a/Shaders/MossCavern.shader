Shader "EmeraldMine10002a/NaturalMossRock" {
 Properties {
 _BaseMap("Rock albedo",2D)="white"{}
 _BaseColor("Rock tint",Color)=(.72,.8,.78,1)
 _MossMap("Moss texture",2D)="white"{}
 _MossColor("Moss tint",Color)=(.44,.65,.3,1)
 _MossAmount("Moss cover",Range(0,1))=.62
 _Smoothness("Dampness",Range(0,1))=.22
 _Cutoff("Cutoff",Float)=.5
 }
 SubShader {
 Tags {"RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" "Queue"="Geometry"}
 Pass {
 Name "ForwardLit" Tags {"LightMode"="UniversalForward"}
 HLSLPROGRAM
 #pragma target 3.0
 #pragma vertex Vert
 #pragma fragment Frag
 #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
 #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
 #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
 #pragma multi_compile_fragment _ _SHADOWS_SOFT
 #pragma multi_compile_fog
 #pragma multi_compile_instancing
 #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
 #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
 TEXTURE2D(_BaseMap);SAMPLER(sampler_BaseMap);TEXTURE2D(_MossMap);SAMPLER(sampler_MossMap);
 CBUFFER_START(UnityPerMaterial)
 float4 _BaseMap_ST;half4 _BaseColor,_MossColor;half _MossAmount,_Smoothness,_Cutoff;
 CBUFFER_END
 struct A{float4 positionOS:POSITION;float3 normalOS:NORMAL;float2 uv:TEXCOORD0;UNITY_VERTEX_INPUT_INSTANCE_ID};
 struct V{float4 positionCS:SV_POSITION;float3 positionWS:TEXCOORD0;half3 normalWS:TEXCOORD1;float2 uv:TEXCOORD2;half fog:TEXCOORD3;UNITY_VERTEX_INPUT_INSTANCE_ID UNITY_VERTEX_OUTPUT_STEREO};
 V Vert(A i){V o=(V)0;UNITY_SETUP_INSTANCE_ID(i);UNITY_TRANSFER_INSTANCE_ID(i,o);UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);VertexPositionInputs p=GetVertexPositionInputs(i.positionOS.xyz);o.positionCS=p.positionCS;o.positionWS=p.positionWS;o.normalWS=TransformObjectToWorldNormal(i.normalOS);o.uv=TRANSFORM_TEX(i.uv,_BaseMap);o.fog=ComputeFogFactor(p.positionCS.z);return o;}
 float Hash3(float3 p){return frac(sin(dot(p,float3(127.1,311.7,74.7)))*43758.5453);}
 float Noise3(float3 p){float3 a=floor(p),b=frac(p);b=b*b*(3-2*b);return lerp(lerp(lerp(Hash3(a),Hash3(a+float3(1,0,0)),b.x),lerp(Hash3(a+float3(0,1,0)),Hash3(a+float3(1,1,0)),b.x),b.y),lerp(lerp(Hash3(a+float3(0,0,1)),Hash3(a+float3(1,0,1)),b.x),lerp(Hash3(a+float3(0,1,1)),Hash3(a+float3(1,1,1)),b.x),b.y),b.z);}
 half4 Frag(V i):SV_Target {
 UNITY_SETUP_INSTANCE_ID(i);UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
 half3 n=normalize(i.normalWS);float3 p=i.positionWS;
 half noise=Noise3(p*.75),small=Noise3(p*3.4);
 half low=saturate(1-p.y/6)*.045;
 half mask=smoothstep(.44,.76,noise*.72+small*.20+saturate(n.y)*.16+low)*_MossAmount;
 half3 base=SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,i.uv).rgb*_BaseColor.rgb;
 half3 moss=SAMPLE_TEXTURE2D(_MossMap,sampler_MossMap,p.xz*.6+p.y*.12).rgb*_MossColor.rgb+base*.18;
 SurfaceData s=(SurfaceData)0;s.albedo=lerp(base,moss,mask);s.smoothness=lerp(.11,_Smoothness,mask);s.occlusion=1;s.alpha=1;s.normalTS=half3(0,0,1);s.emission=half3(.009,.014,.01);
 InputData d=(InputData)0;d.positionWS=p;d.normalWS=n;d.viewDirectionWS=GetWorldSpaceNormalizeViewDir(p);d.shadowCoord=TransformWorldToShadowCoord(p);d.bakedGI=SampleSH(n);d.normalizedScreenSpaceUV=GetNormalizedScreenSpaceUV(i.positionCS);d.vertexLighting=VertexLighting(p,n);d.shadowMask=1;
 half4 c=UniversalFragmentPBR(d,s);c.rgb=MixFog(c.rgb,i.fog);return c;
 }
 ENDHLSL
 }
 UsePass "Universal Render Pipeline/Lit/ShadowCaster"
 UsePass "Universal Render Pipeline/Lit/DepthOnly"
 UsePass "Universal Render Pipeline/Lit/DepthNormals"
 }
 Fallback Off
}
