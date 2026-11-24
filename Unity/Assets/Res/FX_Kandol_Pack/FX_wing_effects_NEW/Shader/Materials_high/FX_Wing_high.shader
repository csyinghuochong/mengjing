// Made with Amplify Shader Editor v1.9.3.3
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "kandol_pack/FX_Wing_high"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		[Toggle]_NOAlphaRChannel("@NO Alpha R Channel  ----------------", Float) = 0
		_Texture_Power("Texture_Power", Float) = 1
		_Texture_Emissive("Texture_Emissive", Float) = 1
		_Texture_Opacity("Texture_Opacity", Range( 0 , 1)) = 1
		_Texture_TilingU("Texture_TilingU", Float) = 1
		_Texture_TilingV("Texture_TilingV", Float) = 1
		_Texture_OffsetU("Texture_OffsetU", Float) = 1
		_Texture_OffsetV("Texture_OffsetV", Float) = 1
		_Texture_SpeedU("Texture_SpeedU", Float) = 0
		_Texture_SpeedV("Texture_SpeedV", Float) = 0
		_Texture_Rorator("Texture_Rorator", Range( 0 , 1)) = 0
		_Texture_Rorator_Speed("Texture_Rorator_Speed", Float) = 0
		[Header(TEXTURE NOISE )][Toggle]_Tex_Noise_Switch("@Tex_Noise_Switch ----------------", Float) = 1
		[NoScaleOffset]_Tex_Noise("Tex_Noise", 2D) = "white" {}
		_NoiseXYtilingZWspeed("Noise XY-tiling - ZW-speed", Vector) = (1,1,0,0)
		_Tex_Noise_Intensity("Tex_Noise_Intensity", Range( 0 , 1)) = 1
		[Header (TEXTURE MASK)][Toggle]_Tex_Mask_Switch("@Tex_Mask_Switch ----------------", Float) = 1
		[NoScaleOffset]_Tex_Mask("Tex_Mask", 2D) = "white" {}
		_MaskXY_tilingZW_offsrt("Mask XY_tiling - ZW_offsrt", Vector) = (1,1,0,0)
		_Tex_Mask_Opacity("Tex_Mask_Opacity", Range( 0 , 1)) = 1
		_Tex_Mask_Rorator("Tex_Mask_Rorator", Range( 0 , 1)) = 0
		_Tex_Mask_invert("Tex_Mask_invert", Range( -1 , 1)) = 1
		[Header (TEXTURE DISSOLVE)][Toggle]_Tex_Dissolve_Switch("@Tex_Dissolve_Switch ----------------", Float) = 0
		[NoScaleOffset]_Tex_Dissolve("Tex_Dissolve", 2D) = "white" {}
		_Diss_XYtilingZWspeed("Diss_XY-tiling - ZW-speed", Vector) = (1,1,0,0)
		[HDR]_Dissolve_Color("Dissolve_Color", Color) = (1,1,1,0)
		_Dissolve_Line("Dissolve_Line", Range( 0 , 3)) = 2.1
		_Dissolve_Emissive("Dissolve_Emissive", Range( 0 , 5)) = 1
		_Dissolve_Smooth("Dissolve_Smooth", Range( 0.05 , 1)) = 0.3274966
		_Dissolve_Intensity("Dissolve_Intensity", Range( 0 , 1)) = 0.3274966
		[Header(BENDER MODE)][Enum(UnityEngine.Rendering.BlendMode)]__SrcBlendMode__("__SrcBlendMode__", Int) = 5
		[Enum(UnityEngine.Rendering.BlendMode)]__DstBlendMode__("__DstBlendMode__", Int) = 1
		[Enum(UnityEngine.Rendering.CullMode)]__CullMode__("__CullMode__", Int) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)]__ZDepth__("__Z Depth__", Int) = 4
		[Toggle]__ZWrite__("__Z Write__", Float) = 0

	}


	Category 
	{
		SubShader
		{
		LOD 0

			Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
			Blend [__SrcBlendMode__] [__DstBlendMode__]
			ColorMask RGBA
			Cull [__CullMode__]
			Lighting Off 
			ZWrite [__ZWrite__]
			ZTest [__ZDepth__]
			
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
				uniform int __DstBlendMode__;
				uniform int __CullMode__;
				uniform int __ZDepth__;
				uniform float __ZWrite__;
				uniform int __SrcBlendMode__;
				uniform float _Tex_Dissolve_Switch;
				uniform float _Tex_Noise_Switch;
				uniform float _Texture_SpeedU;
				uniform float _Texture_SpeedV;
				uniform float _Texture_OffsetU;
				uniform float _Texture_OffsetV;
				uniform float _Texture_Rorator;
				uniform float _Texture_Rorator_Speed;
				uniform float _Texture_TilingU;
				uniform float _Texture_TilingV;
				uniform sampler2D _Tex_Noise;
				uniform float4 _NoiseXYtilingZWspeed;
				uniform float _Tex_Noise_Intensity;
				uniform float _Texture_Power;
				uniform float _Texture_Emissive;
				uniform float _Dissolve_Emissive;
				uniform float4 _Dissolve_Color;
				uniform float _Dissolve_Intensity;
				uniform float _Dissolve_Smooth;
				uniform float _Dissolve_Line;
				uniform sampler2D _Tex_Dissolve;
				uniform float4 _Diss_XYtilingZWspeed;
				uniform float _NOAlphaRChannel;
				uniform float _Tex_Mask_Switch;
				uniform float _Texture_Opacity;
				uniform sampler2D _Tex_Mask;
				uniform float4 _MaskXY_tilingZW_offsrt;
				uniform float _Tex_Mask_Rorator;
				uniform float _Tex_Mask_invert;
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
					float mulTime105 = _Time.y * _Texture_Rorator_Speed;
					float cos100 = cos( ( (0.0 + (_Texture_Rorator - 0.0) * (6.2825 - 0.0) / (1.0 - 0.0)) + mulTime105 ) );
					float sin100 = sin( ( (0.0 + (_Texture_Rorator - 0.0) * (6.2825 - 0.0) / (1.0 - 0.0)) + mulTime105 ) );
					float2 rotator100 = mul( texCoord12 - float2( 0.5,0.5 ) , float2x2( cos100 , -sin100 , sin100 , cos100 )) + float2( 0.5,0.5 );
					float2 temp_cast_0 = (0.5).xx;
					float2 appendResult52 = (float2(_Texture_TilingU , _Texture_TilingV));
					float2 panner44 = ( 0.5 * appendResult46 + ( ( rotator100 - temp_cast_0 ) * appendResult52 ));
					float2 panner55 = ( -1.0 * _Time.y * appendResult57 + panner44);
					float2 texCoord89 = i.texcoord.xy * (_NoiseXYtilingZWspeed).xy + float2( 0,0 );
					float2 panner91 = ( -1.0 * _Time.y * (_NoiseXYtilingZWspeed).zw + texCoord89);
					float Tex_Noise378 = ( tex2D( _Tex_Noise, panner91 ).r * _Tex_Noise_Intensity );
					float4 tex2DNode41 = tex2D( _MainTex, (( _Tex_Noise_Switch )?( ( panner55 + Tex_Noise378 ) ):( panner55 )) );
					float4 temp_cast_1 = (_Texture_Power).xxxx;
					float4 temp_output_29_0 = ( ( _TintColor * pow( tex2DNode41 , temp_cast_1 ) ) * _Texture_Emissive );
					float temp_output_402_0 = (-_Dissolve_Smooth + (_Dissolve_Intensity - 0.0) * (1.0 - -_Dissolve_Smooth) / (1.0 - 0.0));
					float temp_output_403_0 = ( temp_output_402_0 + _Dissolve_Smooth );
					float2 texCoord438 = i.texcoord.xy * (_Diss_XYtilingZWspeed).xy + float2( 0,0 );
					float2 panner440 = ( -1.0 * _Time.y * (_Diss_XYtilingZWspeed).zw + texCoord438);
					float4 tex2DNode407 = tex2D( _Tex_Dissolve, panner440 );
					float smoothstepResult417 = smoothstep( (-_Dissolve_Smooth + (_Dissolve_Intensity - 0.0) * (1.0 - -_Dissolve_Smooth) / (1.0 - 0.0)) , ( temp_output_403_0 * _Dissolve_Line ) , tex2DNode407.r);
					float smoothstepResult408 = smoothstep( temp_output_402_0 , temp_output_403_0 , tex2DNode407.r);
					float4 Tex_Dissolve_Color425 = ( _Dissolve_Emissive * ( _Dissolve_Color * ( ( 1.0 - smoothstepResult417 ) * smoothstepResult408 ) * i.color ) );
					float Tint_Color_Alpha382 = _TintColor.a;
					float Tint_Color_Option421 = saturate( ( Tint_Color_Alpha382 * _Texture_Opacity ) );
					float2 texCoord339 = i.texcoord.xy * (_MaskXY_tilingZW_offsrt).xy + (_MaskXY_tilingZW_offsrt).zw;
					float cos334 = cos( (0.0 + (_Tex_Mask_Rorator - 0.0) * (6.2825 - 0.0) / (1.0 - 0.0)) );
					float sin334 = sin( (0.0 + (_Tex_Mask_Rorator - 0.0) * (6.2825 - 0.0) / (1.0 - 0.0)) );
					float2 rotator334 = mul( texCoord339 - float2( 0.5,0.5 ) , float2x2( cos334 , -sin334 , sin334 , cos334 )) + float2( 0.5,0.5 );
					float2 temp_cast_2 = (0.5).xx;
					float2 appendResult346 = (float2(_Tex_Mask_invert , 1.0));
					float2 panner343 = ( 0.5 * float2( 1,1 ) + ( ( rotator334 - temp_cast_2 ) * appendResult346 ));
					float temp_output_384_0 = ( Tint_Color_Option421 * ( tex2D( _Tex_Mask, panner343 ).r * _Tex_Mask_Opacity ) );
					float Tex_Dissolve_Alpha426 = smoothstepResult408;
					

					fixed4 col = ( ( (( _Tex_Dissolve_Switch )?( ( temp_output_29_0 + Tex_Dissolve_Color425 ) ):( temp_output_29_0 )) * i.color ) * ( i.color.a * ( (( _NOAlphaRChannel )?( tex2DNode41.r ):( tex2DNode41.a )) * (( _Tex_Mask_Switch )?( (( _Tex_Dissolve_Switch )?( ( temp_output_384_0 * Tex_Dissolve_Alpha426 ) ):( temp_output_384_0 )) ):( Tint_Color_Option421 )) ) ) );
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
Node;AmplifyShaderEditor.CommentaryNode;98;-3184,-96;Inherit;False;1815.812;418.263;노이즈  텍스처 (왜곡 효과);9;378;94;95;80;91;332;89;85;331;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;54;-3182.065,-803.9799;Inherit;False;3400.171;672.4631;텍스처 타일링, 위치 이동, 애니메이션;36;333;29;30;27;20;21;41;155;2;79;379;55;57;44;382;58;60;49;45;46;28;47;48;52;42;50;51;43;100;294;12;103;105;300;104;293;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;293;-3168,-464;Inherit;False;Property;_Texture_Rorator;Texture_Rorator;10;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;104;-3136,-272;Inherit;False;Property;_Texture_Rorator_Speed;Texture_Rorator_Speed;11;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector4Node;331;-3216,-48;Inherit;False;Property;_NoiseXYtilingZWspeed;Noise XY-tiling - ZW-speed;14;0;Create;True;0;0;0;False;0;False;1,1,0,0;1,1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCRemapNode;300;-2848,-464;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;6.2825;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;105;-2864,-272;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;397;-3701,1072;Inherit;False;3127.256;776.669;디졸브 용해;26;436;440;439;438;437;404;425;414;412;426;413;411;410;416;409;408;417;405;406;407;403;402;401;399;400;398;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;74;-3184,352;Inherit;False;3101.207;669.8044;칼라 오파시티 / 텍스쳐오파시티;26;62;384;64;78;75;77;63;65;343;385;344;342;346;340;345;347;341;334;339;336;338;349;335;350;348;421;;1,1,1,1;0;0
Node;AmplifyShaderEditor.ComponentMaskNode;85;-2880,-48;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;103;-2769.887,-619.1868;Inherit;False;Constant;_Vector0;Vector 0;9;0;Create;True;0;0;0;False;0;False;0.5,0.5;0.5,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;12;-2810.739,-758.1675;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;294;-2640,-400;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;398;-2656,1728;Inherit;False;Property;_Dissolve_Smooth;Dissolve_Smooth;28;0;Create;True;0;0;0;False;0;False;0.3274966;0.085;0.05;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;89;-2656,-64;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ComponentMaskNode;332;-2880,80;Inherit;False;False;False;True;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector4Node;348;-3200,480;Inherit;False;Property;_MaskXY_tilingZW_offsrt;Mask XY_tiling - ZW_offsrt;18;0;Create;True;0;0;0;False;0;False;1,1,0,0;1,1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector4Node;436;-3536,1248;Inherit;False;Property;_Diss_XYtilingZWspeed;Diss_XY-tiling - ZW-speed;24;0;Create;True;0;0;0;False;0;False;1,1,0,0;1,1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RotatorNode;100;-2512,-720;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.NegateNode;400;-2352,1664;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;43;-2480,-592;Inherit;False;Constant;_Float1;Float 1;13;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;51;-2480,-512;Inherit;False;Property;_Texture_TilingU;Texture_TilingU;4;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;50;-2480,-432;Inherit;False;Property;_Texture_TilingV;Texture_TilingV;5;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;399;-2640,1520;Inherit;False;Property;_Dissolve_Intensity;Dissolve_Intensity;29;0;Create;True;0;0;0;False;0;False;0.3274966;0.066;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;350;-2864,592;Inherit;False;False;False;True;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;335;-2864,752;Inherit;False;Property;_Tex_Mask_Rorator;Tex_Mask_Rorator;20;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;349;-2864,496;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;91;-2400,16;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,0.1;False;1;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ComponentMaskNode;437;-3296,1232;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;95;-2176,176;Inherit;False;Property;_Tex_Noise_Intensity;Tex_Noise_Intensity;15;0;Create;True;0;0;0;False;0;False;1;0.1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;80;-2176,-32;Inherit;True;Property;_Tex_Noise;Tex_Noise;13;1;[NoScaleOffset];Create;True;1;TEXTURE NOISE;0;0;False;0;False;-1;7d582596d0e40014b982cf02edcfe56e;423b56893048d8f4cad77b837eceda5e;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WireNode;401;-2000,1760;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;402;-2144,1584;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;42;-2288,-720;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;52;-2256,-608;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;48;-2480,-256;Inherit;False;Property;_Texture_OffsetV;Texture_OffsetV;7;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;47;-2480,-336;Inherit;False;Property;_Texture_OffsetU;Texture_OffsetU;6;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;28;-768,-752;Inherit;False;0;0;_TintColor;Shader;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;338;-2560,608;Inherit;False;Constant;_Vector1;Vector 0;9;0;Create;True;0;0;0;False;0;False;0.5,0.5;0.5,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TFHCRemapNode;336;-2544,752;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;6.2825;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;339;-2592,480;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;438;-3072,1216;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ComponentMaskNode;439;-3296,1360;Inherit;False;False;False;True;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;94;-1808,48;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;403;-1920,1664;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;46;-2176,-480;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;45;-2176,-352;Inherit;False;Constant;_Float0;Float 0;12;0;Create;True;0;0;0;False;0;False;0.5;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;49;-2112,-720;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;60;-1968,-368;Inherit;False;Property;_Texture_SpeedV;Texture_SpeedV;9;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;58;-1968,-448;Inherit;False;Property;_Texture_SpeedU;Texture_SpeedU;8;0;Create;True;0;0;0;False;0;False;0;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;334;-2288,512;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;341;-2288,640;Inherit;False;Constant;_Float2;Float 1;13;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;347;-2224,848;Inherit;False;Constant;_Float5;Float 0;12;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;345;-2304,736;Inherit;False;Property;_Tex_Mask_invert;Tex_Mask_invert;21;0;Create;True;0;0;0;False;0;False;1;1;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;382;-576,-656;Inherit;False;Tint Color Alpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;404;-2320,1184;Inherit;False;Property;_Dissolve_Line;Dissolve_Line;26;0;Create;True;0;0;0;False;0;False;2.1;1.68;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;440;-2816,1296;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,0.1;False;1;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TFHCRemapNode;406;-2144,1424;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;405;-1984,1248;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;378;-1648,48;Inherit;True;Tex_Noise;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;44;-1936,-640;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;57;-1696,-448;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;340;-2048,512;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;346;-2016,736;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;385;-1328,400;Inherit;True;382;Tint Color Alpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;407;-2624,1280;Inherit;True;Property;_Tex_Dissolve;Tex_Dissolve;23;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;89532c9cab86c954b9cbb82bfe68383d;ff2e77283ac27c54d8b818dc6c5bfee8;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;417;-1760,1376;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;55;-1552,-640;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1,0;False;1;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;379;-1664,-336;Inherit;False;378;Tex_Noise;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;342;-1824,512;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;1,1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;344;-1968,848;Inherit;False;Constant;_Float3;Float 0;12;0;Create;True;0;0;0;False;0;False;0.5;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;62;-1264,592;Inherit;False;Property;_Texture_Opacity;Texture_Opacity;3;1;[Header];Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;65;-1120,400;Inherit;False;False;False;False;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;408;-1712,1584;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;409;-1536,1472;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;79;-1376,-480;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;343;-1648,640;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1,1;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;63;-912,400;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;416;-1344,1488;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;410;-1520,1280;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;411;-1744,1120;Inherit;False;Property;_Dissolve_Color;Dissolve_Color;25;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ToggleSwitchNode;155;-1216,-528;Inherit;False;Property;_Tex_Noise_Switch;@Tex_Noise_Switch ----------------;12;0;Create;True;0;0;0;False;1;Header(TEXTURE NOISE );False;1;True;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;77;-896,816;Inherit;False;Property;_Tex_Mask_Opacity;Tex_Mask_Opacity;19;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;75;-896,608;Inherit;True;Property;_Tex_Mask;Tex_Mask;17;1;[NoScaleOffset];Create;True;1;;0;0;False;0;False;-1;92c3a13c5f4252c4688c7e02091810f1;92c3a13c5f4252c4688c7e02091810f1;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;64;-768,400;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;2;-1216,-768;Inherit;True;0;0;_MainTex;Shader;False;0;5;SAMPLER2D;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;413;-1248,1216;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;21;-864,-320;Inherit;False;Property;_Texture_Power;Texture_Power;1;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;78;-592,688;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;421;-608,400;Inherit;True;Tint Color Option;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;426;-832,1584;Inherit;True;Tex_Dissolve_Alpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;412;-1296,1120;Inherit;False;Property;_Dissolve_Emissive;Dissolve_Emissive;27;0;Create;True;0;0;0;False;0;False;1;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;41;-864,-544;Inherit;True;Property;_TextureSample2;Texture Sample 2;0;1;[NoScaleOffset];Create;True;1;TEXTURE WING;0;0;False;0;False;-1;52ee16b5b62807a448d8d02421200c93;52ee16b5b62807a448d8d02421200c93;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PowerNode;20;-416,-544;Inherit;False;False;2;0;COLOR;0,0,0,0;False;1;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;384;-304,592;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;429;-368,1120;Inherit;False;426;Tex_Dissolve_Alpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;414;-1008,1168;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-240,-752;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;30;-320,-432;Inherit;False;Property;_Texture_Emissive;Texture_Emissive;2;0;Create;True;0;0;0;False;0;False;1;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;423;80,928;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;425;-832,1152;Inherit;True;Tex_Dissolve_Color;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;-16,-608;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;428;224,-352;Inherit;False;425;Tex_Dissolve_Color;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ToggleSwitchNode;333;-128,-272;Inherit;False;Property;_NOAlphaRChannel;@NO Alpha R Channel  ----------------;0;0;Create;True;0;0;0;False;0;False;0;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;435;160,592;Inherit;False;Property;_Tex_Dissolve_Switch;@Tex_Dissolve_Switch ----------------;22;0;Create;True;0;0;0;False;1;Header (TEXTURE DISSOLVE);False;0;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;434;256,48;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;433;512,-480;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ToggleSwitchNode;76;544,432;Inherit;False;Property;_Tex_Mask_Switch;@Tex_Mask_Switch ----------------;16;0;Create;True;0;0;0;False;1;Header (TEXTURE MASK);False;1;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;248;992,-288;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;328;1120,176;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;431;752,-592;Inherit;True;Property;_Tex_Dissolve_Switch;@Tex_Dissolve_Switch ----------------;22;0;Create;False;0;0;0;False;1;Header (TEXTURE DISSOLVE);False;0;True;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;179;1648,-32;Inherit;False;295.7283;491.8835;Custom Additive (5.1.0.4.0);5;174;177;325;178;176;;1,0.5704393,0,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;320;1248,-368;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;321;1264,-128;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.IntNode;178;1712,112;Inherit;False;Property;__DstBlendMode__;__DstBlendMode__;31;1;[Enum];Create;True;0;0;1;UnityEngine.Rendering.BlendMode;True;0;False;1;1;False;0;1;INT;0
Node;AmplifyShaderEditor.IntNode;174;1712,192;Inherit;False;Property;__CullMode__;__CullMode__;32;1;[Enum];Create;True;0;0;1;UnityEngine.Rendering.CullMode;True;0;False;0;0;False;0;1;INT;0
Node;AmplifyShaderEditor.IntNode;176;1712,288;Inherit;False;Property;__ZDepth__;__Z Depth__;33;1;[Enum];Create;True;0;0;1;UnityEngine.Rendering.CompareFunction;True;0;False;4;4;False;0;1;INT;0
Node;AmplifyShaderEditor.RangedFloatNode;325;1728,368;Inherit;False;Property;__ZWrite__;__Z Write__;34;1;[Toggle];Create;True;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.IntNode;177;1712,16;Inherit;False;Property;__SrcBlendMode__;__SrcBlendMode__;30;2;[Header];[Enum];Create;True;1;BENDER MODE;0;1;UnityEngine.Rendering.BlendMode;True;0;False;5;1;False;0;1;INT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;396;1456,-272;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;1648,-272;Float;False;True;-1;2;ASEMaterialInspector;0;11;kandol_pack/FX_Wing_high;0b6a9f8b4f707c74ca64c0be8e590de0;True;SubShader 0 Pass 0;0;0;SubShader 0 Pass 0;2;True;True;2;5;True;__SrcBlendMode__;10;True;__DstBlendMode__;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;True;True;0;True;__CullMode__;True;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;True;True;2;True;__ZWrite__;True;3;True;__ZDepth__;False;True;4;Queue=Transparent=Queue=0;IgnoreProjector=True;RenderType=Transparent=RenderType;PreviewType=Plane;False;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;0;;0;0;Standard;0;0;1;True;False;;False;0
Node;AmplifyShaderEditor.CommentaryNode;395;1952,-32;Inherit;False;292;100;Particles Additive (Scr Alpha/One);0;;1,1,1,1;0;0
WireConnection;300;0;293;0
WireConnection;105;0;104;0
WireConnection;85;0;331;0
WireConnection;294;0;300;0
WireConnection;294;1;105;0
WireConnection;89;0;85;0
WireConnection;332;0;331;0
WireConnection;100;0;12;0
WireConnection;100;1;103;0
WireConnection;100;2;294;0
WireConnection;400;0;398;0
WireConnection;350;0;348;0
WireConnection;349;0;348;0
WireConnection;91;0;89;0
WireConnection;91;2;332;0
WireConnection;437;0;436;0
WireConnection;80;1;91;0
WireConnection;401;0;398;0
WireConnection;402;0;399;0
WireConnection;402;3;400;0
WireConnection;42;0;100;0
WireConnection;42;1;43;0
WireConnection;52;0;51;0
WireConnection;52;1;50;0
WireConnection;336;0;335;0
WireConnection;339;0;349;0
WireConnection;339;1;350;0
WireConnection;438;0;437;0
WireConnection;439;0;436;0
WireConnection;94;0;80;1
WireConnection;94;1;95;0
WireConnection;403;0;402;0
WireConnection;403;1;401;0
WireConnection;46;0;47;0
WireConnection;46;1;48;0
WireConnection;49;0;42;0
WireConnection;49;1;52;0
WireConnection;334;0;339;0
WireConnection;334;1;338;0
WireConnection;334;2;336;0
WireConnection;382;0;28;4
WireConnection;440;0;438;0
WireConnection;440;2;439;0
WireConnection;406;0;399;0
WireConnection;406;3;400;0
WireConnection;405;0;403;0
WireConnection;405;1;404;0
WireConnection;378;0;94;0
WireConnection;44;0;49;0
WireConnection;44;2;46;0
WireConnection;44;1;45;0
WireConnection;57;0;58;0
WireConnection;57;1;60;0
WireConnection;340;0;334;0
WireConnection;340;1;341;0
WireConnection;346;0;345;0
WireConnection;346;1;347;0
WireConnection;407;1;440;0
WireConnection;417;0;407;1
WireConnection;417;1;406;0
WireConnection;417;2;405;0
WireConnection;55;0;44;0
WireConnection;55;2;57;0
WireConnection;342;0;340;0
WireConnection;342;1;346;0
WireConnection;65;0;385;0
WireConnection;408;0;407;1
WireConnection;408;1;402;0
WireConnection;408;2;403;0
WireConnection;409;0;417;0
WireConnection;79;0;55;0
WireConnection;79;1;379;0
WireConnection;343;0;342;0
WireConnection;343;1;344;0
WireConnection;63;0;65;0
WireConnection;63;1;62;0
WireConnection;416;0;409;0
WireConnection;416;1;408;0
WireConnection;155;0;55;0
WireConnection;155;1;79;0
WireConnection;75;1;343;0
WireConnection;64;0;63;0
WireConnection;413;0;411;0
WireConnection;413;1;416;0
WireConnection;413;2;410;0
WireConnection;78;0;75;1
WireConnection;78;1;77;0
WireConnection;421;0;64;0
WireConnection;426;0;408;0
WireConnection;41;0;2;0
WireConnection;41;1;155;0
WireConnection;20;0;41;0
WireConnection;20;1;21;0
WireConnection;384;0;421;0
WireConnection;384;1;78;0
WireConnection;414;0;412;0
WireConnection;414;1;413;0
WireConnection;27;0;28;0
WireConnection;27;1;20;0
WireConnection;423;0;384;0
WireConnection;423;1;429;0
WireConnection;425;0;414;0
WireConnection;29;0;27;0
WireConnection;29;1;30;0
WireConnection;333;0;41;4
WireConnection;333;1;41;1
WireConnection;435;0;384;0
WireConnection;435;1;423;0
WireConnection;434;0;333;0
WireConnection;433;0;29;0
WireConnection;433;1;428;0
WireConnection;76;0;421;0
WireConnection;76;1;435;0
WireConnection;328;0;434;0
WireConnection;328;1;76;0
WireConnection;431;0;29;0
WireConnection;431;1;433;0
WireConnection;320;0;431;0
WireConnection;320;1;248;0
WireConnection;321;0;248;4
WireConnection;321;1;328;0
WireConnection;396;0;320;0
WireConnection;396;1;321;0
WireConnection;0;0;396;0
ASEEND*/
//CHKSM=48EB9546F3923268A8A58E52440D7EABC851D375