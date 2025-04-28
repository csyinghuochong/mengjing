Shader "Diffuse_Linear" {
	Properties{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200
	
	Fog {Mode Off}

CGPROGRAM
#pragma surface surf Lambert finalcolor:fogColor vertex:fogVertex

sampler2D _MainTex;
fixed4 _Color;

struct Input {
	float2 uv_MainTex;
	float4 viewSpacePos;
};

//uniform half4 unity_FogColor;
uniform half4 unity_FogStart;
uniform half4 unity_FogEnd;

void fogVertex(inout appdata_full v,out Input data){
	data.viewSpacePos = mul( UNITY_MATRIX_MV, v.vertex);
}

void fogColor(Input IN,SurfaceOutput o,inout fixed4 color){
	float dist = IN.viewSpacePos.z;//length(IN.viewSpacePos);
	float fogFactor = ( abs(dist) - unity_FogStart.x) / (unity_FogEnd.x - unity_FogStart.x);
	fogFactor = clamp(fogFactor, 0.0, 1.0);
			
	color = float4(lerp(color.rgb,unity_FogColor.rgb, fogFactor),color.a);
}

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG
}

Fallback "VertexLit"
}
