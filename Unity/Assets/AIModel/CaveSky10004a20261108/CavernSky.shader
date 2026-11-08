Shader "AIModel/Skybox/10004a Deep Cavern" {
Properties {
_RockColor("Vault rock",Color)=(0.12,0.16,0.17,1)
_HazeColor("Distant cool haze",Color)=(0.045,0.075,0.08,1)
_DepthColor("Depth shadow",Color)=(0.018,0.025,0.03,1)
_Exposure("Exposure",Range(0.1,2))=1
_Scale("Rock formation scale",Range(1,15))=5
}
SubShader {
Tags {"Queue"="Background" "RenderType"="Background" "PreviewType"="Skybox"}
Cull Off ZWrite Off
Pass {
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma target 3.0
#include "UnityCG.cginc"
float4 _RockColor,_HazeColor,_DepthColor;float _Exposure,_Scale;
struct appdata{float4 vertex:POSITION;};struct v2f{float4 pos:SV_POSITION;float3 dir:TEXCOORD0;};
v2f vert(appdata v){v2f o;o.pos=UnityObjectToClipPos(v.vertex);o.dir=v.vertex.xyz;return o;}
float hash3(float3 p){p=frac(p*.1031);p+=dot(p,p.yzx+33.33);return frac((p.x+p.y)*p.z);}
float noise3(float3 p){float3 i=floor(p),f=frac(p);f=f*f*(3-2*f);return lerp(lerp(lerp(hash3(i),hash3(i+float3(1,0,0)),f.x),lerp(hash3(i+float3(0,1,0)),hash3(i+float3(1,1,0)),f.x),f.y),lerp(lerp(hash3(i+float3(0,0,1)),hash3(i+float3(1,0,1)),f.x),lerp(hash3(i+float3(0,1,1)),hash3(i+1),f.x),f.y),f.z);}
float fbm(float3 p){float n=0,a=.54;[unroll]for(int i=0;i<5;i++){n+=noise3(p)*a;p=p*2.07+float3(13.1,7.4,19.7);a*=.49;}return n;}
float4 frag(v2f i):SV_Target{float3 d=normalize(i.dir);float3 p=d*_Scale;float large=fbm(p);float detail=fbm(p*5.4);float ridge=abs(fbm(p+large*2.5)-.48);float fracture=smoothstep(.018,.075,ridge);float roof=smoothstep(-.30,.60,d.y);float stone=lerp(.48,1.15,large)*lerp(.65,1,fracture)*(detail*.22+.86);float3 color=lerp(_HazeColor.rgb,_RockColor.rgb*stone,roof*.84+.16);color=lerp(_DepthColor.rgb,color,smoothstep(-.85,.05,d.y));float mist=pow(saturate(1-abs(d.y+.13)*1.7),3)*fbm(p*.7+31);color=lerp(color,_HazeColor.rgb*1.3,mist*.22);return float4(color*_Exposure,1);}
ENDCG
}
}
Fallback Off
}
