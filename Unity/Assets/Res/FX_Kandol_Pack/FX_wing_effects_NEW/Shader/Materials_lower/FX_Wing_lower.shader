// Made with Amplify Shader Editor v1.9.3.3
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "kandol_pack/FX_Wing_lower"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		_Texture_Emissive("Texture_Emissive", Float) = 1
		[Toggle]_NOAlphaRChannel("@NO Alpha R Channel  ----------------", Float) = 0
		_Texture_TilingU("Texture_TilingU", Float) = 1
		_Texture_TilingV("Texture_TilingV", Float) = 1
		_Texture_OffsetU("Texture_OffsetU", Float) = 1
		_Texture_OffsetV("Texture_OffsetV", Float) = 1
		_Texture_SpeedU("Texture_SpeedU", Float) = 0
		_Texture_SpeedV("Texture_SpeedV", Float) = 0
		_Tex_Mask("Tex_Mask", 2D) = "white" {}
		_Tex_Mask_Opacity("Tex_Mask_Opacity", Range( 0 , 1)) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}


	Category 
	{
		SubShader
		{
		LOD 0

			Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
			Blend One One
			ColorMask RGB
			Cull Off
			Lighting Off 
			ZWrite Off
			ZTest LEqual
			
			Pass {
			
				CGPROGRAM
				
				#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
				#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
				#endif
				
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 2.0
				#pragma multi_compile_instancing
				#pragma multi_compile_particles
				#pragma multi_compile_fog
				#include "UnityShaderVariables.cginc"
				#define ASE_NEEDS_FRAG_COLOR


				#include "UnityCG.cginc"

				struct appdata_t 
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
					UNITY_VERTEX_INPUT_INSTANCE_ID
					
				};

				struct v2f 
				{
					float4 vertex : SV_POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					#ifdef SOFTPARTICLES_ON
					float4 projPos : TEXCOORD2;
					#endif
					UNITY_VERTEX_INPUT_INSTANCE_ID
					UNITY_VERTEX_OUTPUT_STEREO
					
				};
				
				
				#if UNITY_VERSION >= 560
				UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
				#else
				uniform sampler2D_float _CameraDepthTexture;
				#endif

				//Don't delete this comment
				// uniform sampler2D_float _CameraDepthTexture;

				uniform sampler2D _MainTex;
				uniform fixed4 _TintColor;
				uniform float4 _MainTex_ST;
				uniform float _InvFade;
				uniform float _Texture_SpeedU;
				uniform float _Texture_SpeedV;
				uniform float _Texture_OffsetU;
				uniform float _Texture_OffsetV;
				uniform float _Texture_TilingU;
				uniform float _Texture_TilingV;
				uniform float _Texture_Emissive;
				uniform float _NOAlphaRChannel;
				uniform sampler2D _Tex_Mask;
				uniform float4 _Tex_Mask_ST;
				uniform float _Tex_Mask_Opacity;


				v2f vert ( appdata_t v  )
				{
					v2f o;
					UNITY_SETUP_INSTANCE_ID(v);
					UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
					UNITY_TRANSFER_INSTANCE_ID(v, o);
					

					v.vertex.xyz +=  float3( 0, 0, 0 ) ;
					o.vertex = UnityObjectToClipPos(v.vertex);
					#ifdef SOFTPARTICLES_ON
						o.projPos = ComputeScreenPos (o.vertex);
						COMPUTE_EYEDEPTH(o.projPos.z);
					#endif
					o.color = v.color;
					o.texcoord = v.texcoord;
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				fixed4 frag ( v2f i  ) : SV_Target
				{
					UNITY_SETUP_INSTANCE_ID( i );
					UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( i );

					#ifdef SOFTPARTICLES_ON
						float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
						float partZ = i.projPos.z;
						float fade = saturate (_InvFade * (sceneZ-partZ));
						i.color.a *= fade;
					#endif

					float2 appendResult57 = (float2(_Texture_SpeedU , _Texture_SpeedV));
					float2 appendResult46 = (float2(_Texture_OffsetU , _Texture_OffsetV));
					float2 texCoord12 = i.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
					float2 temp_cast_0 = (0.5).xx;
					float2 appendResult52 = (float2(_Texture_TilingU , _Texture_TilingV));
					float2 panner44 = ( 0.5 * appendResult46 + ( ( texCoord12 - temp_cast_0 ) * appendResult52 ));
					float2 panner55 = ( -1.0 * _Time.y * appendResult57 + panner44);
					float4 tex2DNode41 = tex2D( _MainTex, panner55 );
					float2 uv_Tex_Mask = i.texcoord.xy * _Tex_Mask_ST.xy + _Tex_Mask_ST.zw;
					

					fixed4 col = ( ( ( ( _TintColor * tex2DNode41 ) * _Texture_Emissive ) * i.color ) * ( i.color.a * ( (( _NOAlphaRChannel )?( tex2DNode41.r ):( tex2DNode41.a )) * ( tex2D( _Tex_Mask, uv_Tex_Mask ).r * _Tex_Mask_Opacity ) ) ) );
					UNITY_APPLY_FOG(i.fogCoord, col);
					return col;
				}
				ENDCG 
			}
		}	
	}
	CustomEditor "ASEMaterialInspector"
	
	Fallback Off
}
/*ASEBEGIN
Version=19303
Node;AmplifyShaderEditor.RangedFloatNode;51;-2128,-528;Inherit;False;Property;_Texture_TilingU;Texture_TilingU;2;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;50;-2128,-432;Inherit;False;Property;_Texture_TilingV;Texture_TilingV;3;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;43;-2128,-608;Inherit;False;Constant;_Float1;Float 1;13;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;12;-2192,-736;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;48;-1888,-448;Inherit;False;Property;_Texture_OffsetV;Texture_OffsetV;5;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;47;-1888,-528;Inherit;False;Property;_Texture_OffsetU;Texture_OffsetU;4;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;42;-1888,-736;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;52;-1888,-624;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;60;-1424,-304;Inherit;False;Property;_Texture_SpeedV;Texture_SpeedV;7;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;58;-1424,-384;Inherit;False;Property;_Texture_SpeedU;Texture_SpeedU;6;0;Create;True;0;0;0;False;0;False;0;-1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;45;-1440,-464;Inherit;False;Constant;_Float0;Float 0;12;0;Create;True;0;0;0;False;0;False;0.5;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;46;-1648,-528;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;49;-1616,-720;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;57;-1200,-384;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;44;-1248,-592;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;55;-992,-448;Inherit;False;3;0;FLOAT2;1,1;False;2;FLOAT2;1,0;False;1;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;337;-1120,-832;Inherit;True;0;0;_MainTex;Shader;False;0;5;SAMPLER2D;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;77;-80,432;Inherit;False;Property;_Tex_Mask_Opacity;Tex_Mask_Opacity;9;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;75;-80,208;Inherit;True;Property;_Tex_Mask;Tex_Mask;8;0;Create;True;0;0;0;False;0;False;-1;13679ed304e82c148b045557169ecc0a;13679ed304e82c148b045557169ecc0a;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;41;-752,-672;Inherit;True;Property;_TextureSample2;Texture Sample 2;2;0;Create;True;0;0;0;False;0;False;-1;f1cb13c97e7e923489922a8e58cc9c6e;f1cb13c97e7e923489922a8e58cc9c6e;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;336;-656,-912;Inherit;False;0;0;_TintColor;Shader;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;78;256,320;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;338;-176,-816;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;30;48,-480;Inherit;False;Property;_Texture_Emissive;Texture_Emissive;0;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;339;-144,-288;Inherit;False;Property;_NOAlphaRChannel;@NO Alpha R Channel  ----------------;1;0;Create;True;0;0;0;False;0;False;0;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;320,-576;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.VertexColorNode;248;352,-320;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;340;413.584,87.34888;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;320;672,-480;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;321;704,-128;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;335;944,-352;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;56;-1392,-208;Inherit;False;Constant;_Texture_Time;Texture_Time;1;0;Create;True;0;0;0;False;0;False;0.1;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;59;-1184,-208;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;332;1216,-352;Float;False;True;-1;2;ASEMaterialInspector;0;11;kandol_pack/FX_Wing_lower;0b6a9f8b4f707c74ca64c0be8e590de0;True;SubShader 0 Pass 0;0;0;SubShader 0 Pass 0;2;True;True;4;1;False;;1;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;True;True;True;True;True;False;0;False;;False;False;False;False;False;False;False;False;True;True;2;False;;True;3;False;;False;True;4;Queue=Transparent=Queue=0;IgnoreProjector=True;RenderType=Transparent=RenderType;PreviewType=Plane;False;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;0;;0;0;Standard;0;0;1;True;False;;False;0
Node;AmplifyShaderEditor.CommentaryNode;319;1392,-352;Inherit;False;395;107;파티클에디티브 = 모든이미지 가능.(Scr Alpha/One);0;;1,0.5704393,0,1;0;0
WireConnection;42;0;12;0
WireConnection;42;1;43;0
WireConnection;52;0;51;0
WireConnection;52;1;50;0
WireConnection;46;0;47;0
WireConnection;46;1;48;0
WireConnection;49;0;42;0
WireConnection;49;1;52;0
WireConnection;57;0;58;0
WireConnection;57;1;60;0
WireConnection;44;0;49;0
WireConnection;44;2;46;0
WireConnection;44;1;45;0
WireConnection;55;0;44;0
WireConnection;55;2;57;0
WireConnection;41;0;337;0
WireConnection;41;1;55;0
WireConnection;78;0;75;1
WireConnection;78;1;77;0
WireConnection;338;0;336;0
WireConnection;338;1;41;0
WireConnection;339;0;41;4
WireConnection;339;1;41;1
WireConnection;29;0;338;0
WireConnection;29;1;30;0
WireConnection;340;0;339;0
WireConnection;340;1;78;0
WireConnection;320;0;29;0
WireConnection;320;1;248;0
WireConnection;321;0;248;4
WireConnection;321;1;340;0
WireConnection;335;0;320;0
WireConnection;335;1;321;0
WireConnection;59;0;56;0
WireConnection;332;0;335;0
ASEEND*/
//CHKSM=DC05ADCD134908617AC59002FF391C81B9348EF3