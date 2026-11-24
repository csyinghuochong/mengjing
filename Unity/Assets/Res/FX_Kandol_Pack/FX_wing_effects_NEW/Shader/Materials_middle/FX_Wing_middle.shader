// Made with Amplify Shader Editor v1.9.3.3
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "kandol_pack/FX_Wing_middle"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		[Toggle]_NOAlphaRChannel("@NO Alpha R Channel  ----------------", Float) = 0
		_Texture_Emissive("Texture_Emissive", Float) = 1
		_Texture_TilingU("Texture_TilingU", Float) = 1
		_Texture_TilingV("Texture_TilingV", Float) = 1
		_Texture_OffsetU("Texture_OffsetU", Float) = 1
		_Texture_OffsetV("Texture_OffsetV", Float) = 1
		_Texture_SpeedU("Texture_SpeedU", Float) = 0
		_Texture_SpeedV("Texture_SpeedV", Float) = 0
		_Tex_Mask("Tex_Mask", 2D) = "white" {}
		_XY_tilingZW_offsrt("XY_tiling - ZW_offsrt", Vector) = (1,1,0,0)
		_Tex_Mask_Opacity("Tex_Mask_Opacity", Range( 0 , 1)) = 1
		[Toggle]_Tex_Noise_Switch("@Tex_Noise_Switch ----------------", Float) = 1
		_Tex_Noise("Tex_Noise", 2D) = "white" {}
		_XYtilingZWspeed("XY-tiling - ZW-speed", Vector) = (1,1,0,0)
		_Tex_Noise_Intensity("Tex_Noise_Intensity", Range( 0 , 1)) = 0.1

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
				uniform float _Tex_Noise_Switch;
				uniform float _Texture_SpeedU;
				uniform float _Texture_SpeedV;
				uniform float _Texture_OffsetU;
				uniform float _Texture_OffsetV;
				uniform float _Texture_TilingU;
				uniform float _Texture_TilingV;
				uniform sampler2D _Tex_Noise;
				uniform float4 _XYtilingZWspeed;
				uniform float _Tex_Noise_Intensity;
				uniform float _Texture_Emissive;
				uniform float _NOAlphaRChannel;
				uniform sampler2D _Tex_Mask;
				uniform float4 _XY_tilingZW_offsrt;
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
					float2 texCoord89 = i.texcoord.xy * (_XYtilingZWspeed).xy + float2( 0,0 );
					float2 panner91 = ( -1.0 * _Time.y * (_XYtilingZWspeed).zw + texCoord89);
					float4 tex2DNode41 = tex2D( _MainTex, (( _Tex_Noise_Switch )?( ( panner55 + ( tex2D( _Tex_Noise, panner91 ).r * _Tex_Noise_Intensity ) ) ):( panner55 )) );
					float2 texCoord339 = i.texcoord.xy * (_XY_tilingZW_offsrt).xy + (_XY_tilingZW_offsrt).zw;
					float2 temp_cast_1 = (0.5).xx;
					float2 panner343 = ( 0.5 * float2( 1,1 ) + ( texCoord339 - temp_cast_1 ));
					

					fixed4 col = ( ( ( ( _TintColor * tex2DNode41 ) * _Texture_Emissive ) * i.color ) * ( i.color.a * ( (( _NOAlphaRChannel )?( tex2DNode41.r ):( tex2DNode41.a )) * ( _TintColor.a * ( tex2D( _Tex_Mask, panner343 ).r * _Tex_Mask_Opacity ) ) ) ) );
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
Node;AmplifyShaderEditor.CommentaryNode;98;-2832,-144;Inherit;False;1458.504;368.5324;노이즈  텍스처 (왜곡 효과);10;331;82;94;95;80;91;88;332;89;85;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;54;-2707.436,-803.9799;Inherit;False;3061.658;645.7587;텍스처 타일링, 위치 이동, 애니메이션;27;29;333;30;41;2;155;79;55;28;57;44;59;46;45;49;58;56;60;47;48;52;42;12;43;50;51;27;;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector4Node;331;-2768,-80;Inherit;False;Property;_XYtilingZWspeed;XY-tiling - ZW-speed;13;0;Create;True;0;0;0;False;0;False;1,1,0,0;1,1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;51;-2480,-464;Inherit;False;Property;_Texture_TilingU;Texture_TilingU;2;0;Create;True;0;0;0;False;0;False;1;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;50;-2464,-368;Inherit;False;Property;_Texture_TilingV;Texture_TilingV;3;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;43;-2464,-576;Inherit;False;Constant;_Float1;Float 1;13;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;85;-2528,-96;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;12;-2608,-720;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;74;-1344,32;Inherit;False;1889.002;509.3439;칼라 오파시티 / 텍스쳐오파시티;11;78;341;344;340;343;77;75;339;349;350;348;;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;89;-2304,-112;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;42;-2272,-672;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;52;-2240,-544;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;48;-2192,-352;Inherit;False;Property;_Texture_OffsetV;Texture_OffsetV;5;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;47;-2192,-432;Inherit;False;Property;_Texture_OffsetU;Texture_OffsetU;4;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;332;-2528,32;Inherit;False;False;False;True;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector4Node;348;-1232,144;Inherit;False;Property;_XY_tilingZW_offsrt;XY_tiling - ZW_offsrt;9;0;Create;True;0;0;0;False;0;False;1,1,0,0;1,1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;49;-2041.334,-663.3702;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;45;-2064,-528;Inherit;False;Constant;_Float0;Float 0;12;0;Create;True;0;0;0;False;0;False;0.5;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;46;-1952,-432;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;91;-2048,-32;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,0.1;False;1;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;58;-1728,-368;Inherit;False;Property;_Texture_SpeedU;Texture_SpeedU;6;0;Create;True;0;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;60;-1728,-288;Inherit;False;Property;_Texture_SpeedV;Texture_SpeedV;7;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;350;-944,256;Inherit;False;False;False;True;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ComponentMaskNode;349;-944,160;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;80;-1872,-80;Inherit;True;Property;_Tex_Noise;Tex_Noise;12;0;Create;True;0;0;0;False;0;False;-1;7d582596d0e40014b982cf02edcfe56e;fd36c2d70cb158245b3e1ddd2a6a6f63;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;44;-1792,-704;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;95;-1856,128;Inherit;False;Property;_Tex_Noise_Intensity;Tex_Noise_Intensity;14;0;Create;True;0;0;0;False;0;False;0.1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;57;-1504,-384;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;339;-688,224;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;341;-656,384;Inherit;False;Constant;_Float2;Float 1;13;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;55;-1392,-704;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1,0;False;1;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;94;-1568,-64;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;344;-416,400;Inherit;False;Constant;_Float3;Float 0;12;0;Create;True;0;0;0;False;0;False;0.5;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;340;-432,224;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;79;-1292.943,-289.8674;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;343;-192,128;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1,1;False;1;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ToggleSwitchNode;155;-1200,-448;Inherit;False;Property;_Tex_Noise_Switch;@Tex_Noise_Switch ----------------;11;0;Create;True;0;0;0;False;0;False;1;True;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;2;-1184,-752;Inherit;True;0;0;_MainTex;Shader;False;0;5;SAMPLER2D;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;75;16,96;Inherit;True;Property;_Tex_Mask;Tex_Mask;8;0;Create;True;0;0;0;False;0;False;-1;92c3a13c5f4252c4688c7e02091810f1;cc5e7df09fa92ca40a38947b2354a4ae;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;77;-16,320;Inherit;False;Property;_Tex_Mask_Opacity;Tex_Mask_Opacity;10;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;78;336,128;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;28;-496,-768;Inherit;False;0;0;_TintColor;Shader;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;41;-816,-528;Inherit;True;Property;_TextureSample2;Texture Sample 2;0;0;Create;True;0;0;0;False;0;False;-1;430e3135b68acba4dad0dd82f68c4e1d;430e3135b68acba4dad0dd82f68c4e1d;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;30;-128,-576;Inherit;False;Property;_Texture_Emissive;Texture_Emissive;1;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-160,-736;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ToggleSwitchNode;333;-384,-288;Inherit;False;Property;_NOAlphaRChannel;@NO Alpha R Channel  ----------------;0;0;Create;True;0;0;0;False;0;False;0;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;371;544,-144;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;248;816,-496;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;128,-608;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;328;752,-272;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;320;1056,-608;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;321;1072,-320;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;82;-2528,128;Inherit;False;Property;_Tex_Noise_speed;Tex_Noise_speed;15;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;88;-2256,112;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;56;-1712,-512;Inherit;False;Constant;_Texture_Time;Texture_Time;1;0;Create;True;0;0;0;False;0;False;0.1;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;59;-1616,-560;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;372;1520,-432;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;1728,-432;Float;False;True;-1;2;ASEMaterialInspector;0;11;kandol_pack/FX_Wing_middle;0b6a9f8b4f707c74ca64c0be8e590de0;True;SubShader 0 Pass 0;0;0;SubShader 0 Pass 0;2;True;True;4;1;False;__SrcBlendMode__;1;False;__DstBlendMode__;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;True;True;2;False;__CullMode__;True;True;True;True;True;False;0;False;;False;False;False;False;False;False;False;False;True;True;2;False;__ZWrite__;True;3;False;__ZDepth__;False;True;4;Queue=Transparent=Queue=0;IgnoreProjector=True;RenderType=Transparent=RenderType;PreviewType=Plane;False;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;0;;0;0;Standard;0;0;1;True;False;;False;0
WireConnection;85;0;331;0
WireConnection;89;0;85;0
WireConnection;42;0;12;0
WireConnection;42;1;43;0
WireConnection;52;0;51;0
WireConnection;52;1;50;0
WireConnection;332;0;331;0
WireConnection;49;0;42;0
WireConnection;49;1;52;0
WireConnection;46;0;47;0
WireConnection;46;1;48;0
WireConnection;91;0;89;0
WireConnection;91;2;332;0
WireConnection;350;0;348;0
WireConnection;349;0;348;0
WireConnection;80;1;91;0
WireConnection;44;0;49;0
WireConnection;44;2;46;0
WireConnection;44;1;45;0
WireConnection;57;0;58;0
WireConnection;57;1;60;0
WireConnection;339;0;349;0
WireConnection;339;1;350;0
WireConnection;55;0;44;0
WireConnection;55;2;57;0
WireConnection;94;0;80;1
WireConnection;94;1;95;0
WireConnection;340;0;339;0
WireConnection;340;1;341;0
WireConnection;79;0;55;0
WireConnection;79;1;94;0
WireConnection;343;0;340;0
WireConnection;343;1;344;0
WireConnection;155;0;55;0
WireConnection;155;1;79;0
WireConnection;75;1;343;0
WireConnection;78;0;75;1
WireConnection;78;1;77;0
WireConnection;41;0;2;0
WireConnection;41;1;155;0
WireConnection;27;0;28;0
WireConnection;27;1;41;0
WireConnection;333;0;41;4
WireConnection;333;1;41;1
WireConnection;371;0;28;4
WireConnection;371;1;78;0
WireConnection;29;0;27;0
WireConnection;29;1;30;0
WireConnection;328;0;333;0
WireConnection;328;1;371;0
WireConnection;320;0;29;0
WireConnection;320;1;248;0
WireConnection;321;0;248;4
WireConnection;321;1;328;0
WireConnection;88;0;82;0
WireConnection;59;0;56;0
WireConnection;372;0;320;0
WireConnection;372;1;321;0
WireConnection;0;0;372;0
ASEEND*/
//CHKSM=A05917B5F87DCF58289C511E3EF3AACC3D64AE26