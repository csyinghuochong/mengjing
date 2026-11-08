Shader "AIMonsterSet/MineralSkin" {
Properties { _BaseMap("Original skin",2D)="white" {}  _Rock("Rock",Color)=(.08,.025,.01,1) [HDR]_Glow("Glow",Color)=(0,0,0,1) }
SubShader {
Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline" }
Pass {
Tags { "LightMode"="UniversalForward" }
HLSLPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_fog
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
CBUFFER_START(UnityPerMaterial)
float4 _Rock; float4 _Glow;
CBUFFER_END
TEXTURE2D(_BaseMap); SAMPLER(sampler_BaseMap);
struct Attributes {float4 positionOS:POSITION; float3 normalOS:NORMAL; float2 uv:TEXCOORD0;};
struct Varyings {float4 positionCS:SV_POSITION;float3 normalWS:TEXCOORD0;float2 uv:TEXCOORD1;float fog:TEXCOORD2;};
Varyings vert(Attributes v){Varyings o;o.positionCS=TransformObjectToHClip(v.positionOS.xyz);o.normalWS=TransformObjectToWorldNormal(v.normalOS);o.uv=v.uv;o.fog=ComputeFogFactor(o.positionCS.z);return o;}
float2 hash(float2 p){return frac(sin(float2(dot(p,float2(127.1,311.7)),dot(p,float2(269.5,183.3))))*43758.5453);}
half4 frag(Varyings i):SV_Target{
float2 uv=i.uv; float2 p=uv*22 + .65*sin(uv.yx*83)+.2*sin(uv.yx*219);float2 cell=floor(p);float first=10,second=10;
for(int x=-1;x<=1;x++)for(int y=-1;y<=1;y++){float2 c=cell+float2(x,y);float d=length(c+hash(c)-p);if(d<first){second=first;first=d;}else second=min(second,d);}
float mask=saturate(sin(dot(cell,float2(1.7,2.9)))*1.8); float crack=(1-smoothstep(.008,.035,second-first))*mask;
Light l=GetMainLight();float3 n=normalize(i.normalWS);float3 lighting=max(SampleSH(n),float3(.12,.12,.12))+l.color*saturate(dot(n,l.direction));
float3 tex=SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,uv).rgb; float detail=dot(tex,float3(.3,.59,.11)); float3 color=lerp(_Rock.rgb,tex*.35,.4)*(.65+detail)*lighting+crack*_Glow.rgb*.38;
return half4(MixFog(color,i.fog),1);
}
ENDHLSL
}
UsePass "Universal Render Pipeline/Lit/ShadowCaster"
UsePass "Universal Render Pipeline/Lit/DepthOnly"
}
}

