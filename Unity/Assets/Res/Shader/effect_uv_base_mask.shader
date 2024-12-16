Shader "Effect/UV_Base_Mask" {
    Properties {
		_NoAlpha("NoAlpha",float) = 0
		_OffsetFactor("OffsetFactor",Int) = 0
		_OffsetUnit("OffsetUnit",Int) = 0

		_dilate("_Dilate",float) = 0

        _MainColor ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Main Tex", 2D) = "white" {}
        _MainTexBrightness ("Main Tex Brightness", Float ) = 1
        _MainTexPannerX ("Main Tex Panner X", Float ) = 0
        _MainTexPannerY ("Main Tex Panner Y", Float ) = 0
        _MainTexContrast ("Main Tex Contrast", Float ) = 1
        _MaskTex ("Mask Tex", 2D) = "white" {}
        _MaskTexPannerX ("Mask Tex Panner X", Float ) = 0
        _MaskTexPannerY ("Mask Tex Panner Y", Float ) = 0
        [MaterialToggle] _MaskTexDynmatic ("Mask Tex Dynmatic", Float ) = 0
        _TurbulenceTex ("Turbulence Tex", 2D) = "bump" {}
        _UVEffectPower ("UV Effect Power", Float ) = 0
        _NormalTexPannerX ("Normal Tex Panner X", Float ) = 0
        _NormalTexPannerY ("Normal Tex Panner Y", Float ) = 0
		_ClipRect("ClipRect",Vector) = (0,0,0,0)
        _Dis ("Dis", Float ) = 1
    	_MulAlpha("Mul Alpha",float) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    	[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest ("ZTest", Float) = 4
		[Enum(UnityEngine.Rendering.BlendMode)] SrcBlend("SrcBlend", Float) = 5//SrcAlpha
		[Enum(UnityEngine.Rendering.BlendMode)] DstBlend("DstBlend", Float) = 10//One
    }
    SubShader {
        Tags {
            "RenderPipeline"="UniversalPipeline"
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
			Offset[_OffsetFactor],[_OffsetUnit]

        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="UniversalForward"
            }
			Blend[SrcBlend][DstBlend]
        	ZTest [_ZTest]
            Cull Off
            ZWrite Off
			Offset -1, -1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
			#include "UnityUI.cginc"
			uniform	float _NoAlpha;

			#pragma multi_compile __ ForUIUse
			#pragma multi_compile __ UI_CLIP

            //#pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            //#pragma target 2.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _MainTexPannerX;
            uniform float _MainTexPannerY;
            uniform sampler2D _MaskTex; uniform float4 _MaskTex_ST;
            uniform float _MainTexBrightness;
            uniform float _MainTexContrast;
            uniform sampler2D _TurbulenceTex; uniform float4 _TurbulenceTex_ST;
            uniform float _UVEffectPower;
            uniform float _NormalTexPannerX;
            uniform float _NormalTexPannerY;
            uniform float _MaskTexPannerX;
            uniform float _MaskTexPannerY;
			float4 _ClipRect;
            uniform fixed _MaskTexDynmatic;
            uniform float4 _MainColor;
            uniform float _Dis;
            uniform float _MulAlpha;
			
			float _dilate;

            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
				float3 normal:NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 uv1 : TEXCOORD1;
                float4 vertexColor : COLOR;
#ifdef UI_CLIP
				float2 worldPosition : TEXCOORD02;//�˴�����
#endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;

				//v.vertex.xyz = v.vertex.xyz + v.normal.xyz*_dilate;

				//o.pos = mul(UNITY_MATRIX_MV, v.vertex);
				o.pos = float4(UnityObjectToViewPos(v.vertex), 1.0);
				o.pos.z += _dilate;
				o.pos = mul(UNITY_MATRIX_P, o.pos);

                //o.pos = UnityObjectToClipPos( v.vertex );

#ifdef UI_CLIP
//�����Ҫmask�ü��븴���������� begin
				o.worldPosition = mul(unity_ObjectToWorld, v.vertex).xy;
				//�����Ҫmask�ü��븴���������� end
#endif
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_7882 = _Time;
                float2 node_1145 = (i.uv0+(float2(_NormalTexPannerX,_NormalTexPannerY)*node_7882.g));
                float4 _TurbulenceTex_var = tex2D(_TurbulenceTex,TRANSFORM_TEX(node_1145, _TurbulenceTex));
                //clip((_TurbulenceTex_var.r+_Dis) - 0.5);
////// Lighting:
////// Emissive:
                float4 node_2160 = _Time;
                float2 node_407 = ((_TurbulenceTex_var.r*_UVEffectPower)+(i.uv0+(float2(_MainTexPannerX,_MainTexPannerY)*node_2160.g)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_407, _MainTex));
                float3 emissive = (_MainColor.rgb * (pow((_MainTexBrightness * _MainTex_var.rgb), _MainTexContrast)*i.vertexColor.rgb));
                float3 finalColor = emissive;
                float4 node_6409 = _Time;
                float2 node_514 = (i.uv0+lerp( (float2(_MaskTexPannerX,_MaskTexPannerY)*node_6409.g), float2(i.uv1.b,i.uv1.a), _MaskTexDynmatic ));
                float4 _MaskTex_var = tex2D(_MaskTex,TRANSFORM_TEX(node_514, _MaskTex));


				
#ifdef ForUIUse
				float a0 = _MainTex_var.a;// saturate(length(_MainTex_var.rgb));
				a0 = (_MainColor.a*(i.vertexColor.a*(a0*_MaskTex_var.r)));
				float a = _NoAlpha > 0.01 ? saturate(_MainColor.a*(i.vertexColor.a*(_MainTex_var.a*_MaskTex_var.r))*saturate(length(_MainTex_var.rgb))) : a0;
				
				return float4(finalColor, a);
				//return fixed4(finalColor, saturate(_MainColor.a*(i.vertexColor.a*(_MainTex_var.a*_MaskTex_var.r))*saturate(length(_MainTex_var.rgb))));
#else
            	
				float a = (_MainTex_var.a >= 1) ? saturate(length(_MainTex_var.rgb * _MulAlpha)) : _MainTex_var.a;            	
#ifdef UI_CLIP				
				clip(a - 0.001);            	
#endif
            	
                return float4(finalColor,(_MainColor.a*(i.vertexColor.a*(a*_MaskTex_var.r))));
#endif

            }
            ENDCG
        }
    }
    //CustomEditor "ShaderForgeMaterialInspector"
}
