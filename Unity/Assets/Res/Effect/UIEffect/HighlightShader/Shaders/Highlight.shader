Shader "Custom/Selection/Highlight"
{
	Properties {
		_Color ("Base Color", Color) = (0.5,0.5,0.5,1)
		_HiColor ("Hot Color", Color) = (0.5,0.5,0.5,1)
		_Colorize ("Colorize", Color) = (1,1,1,1)
		_ColorIntensity ("Color Intensity", Float) = 1
		_Intensity ("Intensity", Float) = 1
		_FlareTex ("Flare Texture", 2D) = "white" {}
		_FlareIntensity ("Flare Intensity", Float) = 1
		_VflareSpeed ("Flare V Speed", Float) = 1
		_UflareScale ("Flare U Scale", Float) = 1
		_VflareScale ("Flare V Scale", Float) = 1
		_MainTex ("Main Texture", 2D) = "black" {}
		_Seed ("_Seed", Float) = 0
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask RGB -1
			ZClip Off
			ZWrite Off
			Cull Off
			Fog {
				Color (0,0,0,1)
			}
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv0 : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
				float4 color : COLOR;
			};

			struct v2f
			{
				float2 uv0 : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
			};

            float4 _Color;
		    float4 _HiColor;
		    float4 _Colorize;
		    float _ColorIntensity;
		    float _Intensity;
		    sampler2D _FlareTex;
		    float _FlareIntensity;
		    float _VflareSpeed;
		    float _UflareScale;
		    float _VflareScale;
		    sampler2D _MainTex;
		    float _Seed;

			float4 _MainTex_ST;
			float4 _FlareTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv0 = TRANSFORM_TEX(v.uv0, _MainTex);
				o.uv1 = TRANSFORM_TEX(v.uv1, _MainTex);
                o.color = v.color;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float offset;
				float4 uvFlare;
                float3 mColor;
				offset = _Seed + _Time[0];
                mColor.r = offset * 0.05;
                offset *= _VflareSpeed;
                uvFlare.x = i.uv1.x * _UflareScale + mColor.r;
                mColor.r = tex2D(_MainTex, i.uv0.xy).r * _Intensity * 1.2;
                uvFlare.y = mColor.r * _VflareScale + offset;
                                
                float flare;
                flare = tex2D(_FlareTex, uvFlare.xy).r * i.color.r + mColor.r;
                flare = mColor.r * flare;
                flare = flare * _FlareIntensity * 2;
                mColor.rgb = _HiColor.rgb * flare + (-_Color.rgb);
                mColor.rgb = flare * mColor.rgb + _Color.rgb;
                
                float4 color;
                color.a = flare * i.color.r;
                color.rgb = mColor.rgb * _ColorIntensity;
                return color * _Colorize;
			}
			ENDCG
		}
	}
}
