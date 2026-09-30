// Made with Amplify Shader Editor v1.9.8.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ANGRYMESH/Stylized Pack/Grass"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[Header(Base)][Toggle(_ENABLESMOOTHNESSWAVES_ON)] _EnableSmoothnessWaves("Enable Smoothness Waves", Float) = 1
		_BaseOpacityCutoff("Base Opacity Cutoff", Range( 0 , 1)) = 0.3
		[HDR]_BaseAlbedoColor("Base Albedo Color", Color) = (0.5019608,0.5019608,0.5019608,0)
		_BaseAlbedoBrightness("Base Albedo Brightness", Range( 0 , 5)) = 1
		_BaseAlbedoDesaturation("Base Albedo Desaturation", Range( 0 , 1)) = 0
		_BaseSmoothnessIntensity("Base Smoothness Intensity", Range( 0 , 1)) = 0.5
		_BaseSmoothnessWaves("Base Smoothness Waves", Range( 0 , 1)) = 0.5
		_BaseNormalIntensity("Base Normal Intensity", Range( 0 , 5)) = 0
		[NoScaleOffset]_BaseAlbedo("Base Albedo", 2D) = "gray" {}
		[NoScaleOffset]_BaseNormal("Base Normal", 2D) = "bump" {}
		[Header(Bottom Color)][Toggle(_ENABLEBOTTOMCOLOR_ON)] _EnableBottomColor("Enable Bottom Color", Float) = 1
		[Toggle(_ENABLEBOTTOMDITHER_ON)] _EnableBottomDither("Enable Bottom Dither", Float) = 0
		[HDR]_BottomColor("Bottom Color", Color) = (0.5019608,0.5019608,0.5019608,0)
		_BottomColorOffset("Bottom Color Offset", Range( 0 , 5)) = 1
		_BottomColorContrast("Bottom Color Contrast", Range( 0 , 5)) = 1
		_BottomDitherOffset("Bottom Dither Offset", Range( -1 , 1)) = 0
		_BottomDitherContrast("Bottom Dither Contrast", Range( 1 , 10)) = 3
		[Header(Tint Color)][Toggle(_ENABLETINTVARIATIONCOLOR_ON)] _EnableTintVariationColor("Enable Tint Variation Color", Float) = 1
		[HDR]_TintColor("Tint Color", Color) = (0.5019608,0.5019608,0.5019608,0)
		_TintNoiseUVScale("Tint Noise UV Scale", Range( 0 , 50)) = 5
		_TintNoiseIntensity("Tint Noise Intensity", Range( 0 , 1)) = 1
		_TintNoiseContrast("Tint Noise Contrast", Range( 0 , 10)) = 5
		[IntRange]_TintNoiseInvertMask("Tint Noise Invert Mask", Range( 0 , 1)) = 0
		[Header(Wind)][Toggle(_ENABLEWIND_ON)] _EnableWind("Enable Wind", Float) = 1
		_WindGrassAmplitude("Wind Grass Amplitude", Range( 0 , 1)) = 1
		_WindGrassSpeed("Wind Grass Speed", Range( 0 , 1)) = 1
		_WindGrassScale("Wind Grass Scale", Range( 0 , 1)) = 1
		_WindGrassTurbulence("Wind Grass Turbulence", Range( 0 , 1)) = 1
		_WindGrassFlexibility("Wind Grass Flexibility", Range( 0 , 1)) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}


		//_TransmissionShadow( "Transmission Shadow", Range( 0, 1 ) ) = 0.5
		//_TransStrength( "Trans Strength", Range( 0, 50 ) ) = 1
		//_TransNormal( "Trans Normal Distortion", Range( 0, 1 ) ) = 0.5
		//_TransScattering( "Trans Scattering", Range( 1, 50 ) ) = 2
		//_TransDirect( "Trans Direct", Range( 0, 1 ) ) = 0.9
		//_TransAmbient( "Trans Ambient", Range( 0, 1 ) ) = 0.1
		//_TransShadow( "Trans Shadow", Range( 0, 1 ) ) = 0.5
		//_TessPhongStrength( "Tess Phong Strength", Range( 0, 1 ) ) = 0.5
		//_TessValue( "Tess Max Tessellation", Range( 1, 32 ) ) = 16
		//_TessMin( "Tess Min Distance", Float ) = 10
		//_TessMax( "Tess Max Distance", Float ) = 25
		//_TessEdgeLength ( "Tess Edge length", Range( 2, 50 ) ) = 16
		//_TessMaxDisp( "Tess Max Displacement", Float ) = 25

		[HideInInspector][ToggleOff] _SpecularHighlights("Specular Highlights", Float) = 1
		[HideInInspector][ToggleOff] _EnvironmentReflections("Environment Reflections", Float) = 1
		[HideInInspector][ToggleOff] _ReceiveShadows("Receive Shadows", Float) = 1.0

		[HideInInspector] _QueueOffset("_QueueOffset", Float) = 0
        [HideInInspector] _QueueControl("_QueueControl", Float) = -1

        [HideInInspector][NoScaleOffset] unity_Lightmaps("unity_Lightmaps", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset] unity_LightmapsInd("unity_LightmapsInd", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset] unity_ShadowMasks("unity_ShadowMasks", 2DArray) = "" {}
	}

	SubShader
	{
		LOD 0

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" "Queue"="Geometry" "UniversalMaterialType"="Lit" }

		Cull Off
		ZWrite On
		ZTest LEqual
		Offset 0 , 0
		AlphaToMask Off

		

		HLSLINCLUDE
		#pragma target 4.5
		#pragma prefer_hlslcc gles
		// ensure rendering platforms toggle list is visible

		#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
		#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Filtering.hlsl"

		#ifndef ASE_TESS_FUNCS
		#define ASE_TESS_FUNCS
		float4 FixedTess( float tessValue )
		{
			return tessValue;
		}

		float CalcDistanceTessFactor (float4 vertex, float minDist, float maxDist, float tess, float4x4 o2w, float3 cameraPos )
		{
			float3 wpos = mul(o2w,vertex).xyz;
			float dist = distance (wpos, cameraPos);
			float f = clamp(1.0 - (dist - minDist) / (maxDist - minDist), 0.01, 1.0) * tess;
			return f;
		}

		float4 CalcTriEdgeTessFactors (float3 triVertexFactors)
		{
			float4 tess;
			tess.x = 0.5 * (triVertexFactors.y + triVertexFactors.z);
			tess.y = 0.5 * (triVertexFactors.x + triVertexFactors.z);
			tess.z = 0.5 * (triVertexFactors.x + triVertexFactors.y);
			tess.w = (triVertexFactors.x + triVertexFactors.y + triVertexFactors.z) / 3.0f;
			return tess;
		}

		float CalcEdgeTessFactor (float3 wpos0, float3 wpos1, float edgeLen, float3 cameraPos, float4 scParams )
		{
			float dist = distance (0.5 * (wpos0+wpos1), cameraPos);
			float len = distance(wpos0, wpos1);
			float f = max(len * scParams.y / (edgeLen * dist), 1.0);
			return f;
		}

		float DistanceFromPlane (float3 pos, float4 plane)
		{
			float d = dot (float4(pos,1.0f), plane);
			return d;
		}

		bool WorldViewFrustumCull (float3 wpos0, float3 wpos1, float3 wpos2, float cullEps, float4 planes[6] )
		{
			float4 planeTest;
			planeTest.x = (( DistanceFromPlane(wpos0, planes[0]) > -cullEps) ? 1.0f : 0.0f ) +
							(( DistanceFromPlane(wpos1, planes[0]) > -cullEps) ? 1.0f : 0.0f ) +
							(( DistanceFromPlane(wpos2, planes[0]) > -cullEps) ? 1.0f : 0.0f );
			planeTest.y = (( DistanceFromPlane(wpos0, planes[1]) > -cullEps) ? 1.0f : 0.0f ) +
							(( DistanceFromPlane(wpos1, planes[1]) > -cullEps) ? 1.0f : 0.0f ) +
							(( DistanceFromPlane(wpos2, planes[1]) > -cullEps) ? 1.0f : 0.0f );
			planeTest.z = (( DistanceFromPlane(wpos0, planes[2]) > -cullEps) ? 1.0f : 0.0f ) +
							(( DistanceFromPlane(wpos1, planes[2]) > -cullEps) ? 1.0f : 0.0f ) +
							(( DistanceFromPlane(wpos2, planes[2]) > -cullEps) ? 1.0f : 0.0f );
			planeTest.w = (( DistanceFromPlane(wpos0, planes[3]) > -cullEps) ? 1.0f : 0.0f ) +
							(( DistanceFromPlane(wpos1, planes[3]) > -cullEps) ? 1.0f : 0.0f ) +
							(( DistanceFromPlane(wpos2, planes[3]) > -cullEps) ? 1.0f : 0.0f );
			return !all (planeTest);
		}

		float4 DistanceBasedTess( float4 v0, float4 v1, float4 v2, float tess, float minDist, float maxDist, float4x4 o2w, float3 cameraPos )
		{
			float3 f;
			f.x = CalcDistanceTessFactor (v0,minDist,maxDist,tess,o2w,cameraPos);
			f.y = CalcDistanceTessFactor (v1,minDist,maxDist,tess,o2w,cameraPos);
			f.z = CalcDistanceTessFactor (v2,minDist,maxDist,tess,o2w,cameraPos);

			return CalcTriEdgeTessFactors (f);
		}

		float4 EdgeLengthBasedTess( float4 v0, float4 v1, float4 v2, float edgeLength, float4x4 o2w, float3 cameraPos, float4 scParams )
		{
			float3 pos0 = mul(o2w,v0).xyz;
			float3 pos1 = mul(o2w,v1).xyz;
			float3 pos2 = mul(o2w,v2).xyz;
			float4 tess;
			tess.x = CalcEdgeTessFactor (pos1, pos2, edgeLength, cameraPos, scParams);
			tess.y = CalcEdgeTessFactor (pos2, pos0, edgeLength, cameraPos, scParams);
			tess.z = CalcEdgeTessFactor (pos0, pos1, edgeLength, cameraPos, scParams);
			tess.w = (tess.x + tess.y + tess.z) / 3.0f;
			return tess;
		}

		float4 EdgeLengthBasedTessCull( float4 v0, float4 v1, float4 v2, float edgeLength, float maxDisplacement, float4x4 o2w, float3 cameraPos, float4 scParams, float4 planes[6] )
		{
			float3 pos0 = mul(o2w,v0).xyz;
			float3 pos1 = mul(o2w,v1).xyz;
			float3 pos2 = mul(o2w,v2).xyz;
			float4 tess;

			if (WorldViewFrustumCull(pos0, pos1, pos2, maxDisplacement, planes))
			{
				tess = 0.0f;
			}
			else
			{
				tess.x = CalcEdgeTessFactor (pos1, pos2, edgeLength, cameraPos, scParams);
				tess.y = CalcEdgeTessFactor (pos2, pos0, edgeLength, cameraPos, scParams);
				tess.z = CalcEdgeTessFactor (pos0, pos1, edgeLength, cameraPos, scParams);
				tess.w = (tess.x + tess.y + tess.z) / 3.0f;
			}
			return tess;
		}
		#endif //ASE_TESS_FUNCS
		ENDHLSL

		
		Pass
		{
			
			Name "Forward"
			Tags { "LightMode"="UniversalForward" }

			Blend One Zero, One Zero
			ZWrite On
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA

			

			HLSLPROGRAM

			

			#pragma multi_compile_fragment _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma shader_feature_local _RECEIVE_SHADOWS_OFF
			#pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
			#pragma multi_compile_instancing
			#pragma instancing_options renderinglayer
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011


			

			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
			#pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS

			
            #pragma multi_compile _ EVALUATE_SH_MIXED EVALUATE_SH_VERTEX
		

			#pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BLENDING
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BOX_PROJECTION

			

			
			#pragma multi_compile_fragment _ _SHADOWS_SOFT _SHADOWS_SOFT_LOW _SHADOWS_SOFT_MEDIUM _SHADOWS_SOFT_HIGH
           

			#pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
			#pragma multi_compile _ _LIGHT_LAYERS
			#pragma multi_compile_fragment _ _LIGHT_COOKIES
			#pragma multi_compile _ _FORWARD_PLUS

			

			#pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
			#pragma multi_compile _ SHADOWS_SHADOWMASK
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON
			#pragma multi_compile _ DYNAMICLIGHTMAP_ON

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(_ASE_LIGHTING_SIMPLE)
				#define _SPECULAR_COLOR 1
			#endif

			#define SHADERPASS SHADERPASS_FORWARD

			
            #if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#endif
		

			
			#if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"

			
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
           

			
            #if ASE_SRP_VERSION >=140009
			#include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DBuffer.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#if defined(UNITY_INSTANCING_ENABLED) && defined(_TERRAIN_INSTANCED_PERPIXEL_NORMAL)
				#define ENABLE_TERRAIN_PERPIXEL_NORMAL
			#endif

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLEBOTTOMCOLOR_ON
			#pragma shader_feature_local _ENABLETINTVARIATIONCOLOR_ON
			#pragma shader_feature_local _ENABLESMOOTHNESSWAVES_ON
			#pragma shader_feature_local _ENABLEBOTTOMDITHER_ON


			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE) && (SHADER_TARGET >= 45)
				#define ASE_SV_DEPTH SV_DepthLessEqual
				#define ASE_SV_POSITION_QUALIFIERS linear noperspective centroid
			#else
				#define ASE_SV_DEPTH SV_Depth
				#define ASE_SV_POSITION_QUALIFIERS
			#endif

			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				float4 lightmapUVOrVertexSH : TEXCOORD1;
				#if defined(ASE_FOG) || defined(_ADDITIONAL_LIGHTS_VERTEX)
					half4 fogFactorAndVertexLight : TEXCOORD2;
				#endif
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					float4 shadowCoord : TEXCOORD6;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON)
					float2 dynamicLightmapUV : TEXCOORD7;
				#endif
				float4 ase_texcoord8 : TEXCOORD8;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseAlbedoColor;
			float4 _TintColor;
			float4 _BottomColor;
			float _WindGrassSpeed;
			float _BottomDitherOffset;
			float _BaseSmoothnessWaves;
			float _BaseSmoothnessIntensity;
			float _BaseNormalIntensity;
			float _BottomColorContrast;
			float _BottomColorOffset;
			float _TintNoiseIntensity;
			float _TintNoiseInvertMask;
			float _BottomDitherContrast;
			float _TintNoiseUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindGrassTurbulence;
			float _WindGrassScale;
			float _WindGrassFlexibility;
			float _WindGrassAmplitude;
			float _TintNoiseContrast;
			float _BaseOpacityCutoff;
			#ifdef ASE_TRANSMISSION
				float _TransmissionShadow;
			#endif
			#ifdef ASE_TRANSLUCENCY
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D ASPW_WindGrassWavesNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindGrassSpeed;
			half ASPW_WindGrassAmplitude;
			half ASPW_WindGrassFlexibility;
			half ASPW_WindGrassWavesAmplitude;
			half ASPW_WindGrassWavesSpeed;
			half ASPW_WindGrassWavesScale;
			half ASPW_WindGrassTurbulence;
			half ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			sampler2D ASP_GlobalTintNoiseTexture;
			half ASP_GlobalTintNoiseUVScale;
			half ASP_GlobalTintNoiseContrast;
			half ASP_GlobalTintNoiseToggle;
			half ASP_GlobalTintNoiseIntensity;
			sampler2D _BaseNormal;


			float3 ASESafeNormalize(float3 inVec)
			{
				float dp3 = max(1.175494351e-38, dot(inVec, inVec));
				return inVec* rsqrt(dp3);
			}
			
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 ASEScreenPositionNormalizedToPixel( float4 screenPosNorm )
			{
				float4 screenPosPixel = screenPosNorm * float4( _ScreenParams.xy, 1, 1 );
				#if UNITY_UV_STARTS_AT_TOP
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x < 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#else
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x > 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#endif
				return screenPosPixel;
			}
			
			inline float Dither4x4Bayer( int x, int y )
			{
				const float dither[ 16 ] = {
				     1,  9,  3, 11,
				    13,  5, 15,  7,
				     4, 12,  2, 10,
				    16,  8, 14,  6 };
				int r = y * 4 + x;
				return dither[ r ] / 16; // same # of instructions as pre-dividing due to compiler magic
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 worldToObjDir40_g1 = mul( GetWorldToObjectMatrix(), float4( normalizeResult41_g1, 0.0 ) ).xyz;
				float3 Wind_Direction_Leaf50_g1 = worldToObjDir40_g1;
				float3 break42_g1 = Wind_Direction_Leaf50_g1;
				float3 appendResult43_g1 = (float3(break42_g1.z , 0.0 , ( break42_g1.x * -1.0 )));
				float3 Wind_Direction52_g1 = appendResult43_g1;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Grass_Randomization65_g1 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_5_0_g1 = ( Wind_Grass_Randomization65_g1 + _TimeParameters.x );
				float Global_Wind_Grass_Speed144_g1 = ASPW_WindGrassSpeed;
				float temp_output_9_0_g1 = ( _WindGrassSpeed * Global_Wind_Grass_Speed144_g1 * 10.0 );
				float Local_Wind_Grass_Aplitude180_g1 = _WindGrassAmplitude;
				float Global_Wind_Grass_Amplitude172_g1 = ASPW_WindGrassAmplitude;
				float temp_output_27_0_g1 = ( Local_Wind_Grass_Aplitude180_g1 * Global_Wind_Grass_Amplitude172_g1 );
				float Global_Wind_Grass_Flexibility164_g1 = ASPW_WindGrassFlexibility;
				float Wind_Main31_g1 = ( ( ( ( ( sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.0 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.25 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.5 ) ) ) ) + temp_output_27_0_g1 ) * temp_output_27_0_g1 ) / 50.0 ) * ( ( Global_Wind_Grass_Flexibility164_g1 * _WindGrassFlexibility ) * 0.1 ) );
				float Global_Wind_Grass_Waves_Amplitude162_g1 = ASPW_WindGrassWavesAmplitude;
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 appendResult73_g1 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2Dlod( ASPW_WindGrassWavesNoiseTexture, float4( ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).r;
				float lerpResult96_g1 = lerp( Wind_Main31_g1 , ( Wind_Main31_g1 * Global_Wind_Grass_Waves_Amplitude162_g1 ) , Wind_Waves93_g1);
				float Wind_Main_with_Waves108_g1 = lerpResult96_g1;
				float temp_output_141_0_g1 = ( ( ase_positionWS.y * ( _WindGrassScale * 10.0 ) ) + _TimeParameters.x );
				float Local_Wind_Grass_Speed186_g1 = _WindGrassSpeed;
				float temp_output_146_0_g1 = ( Global_Wind_Grass_Speed144_g1 * Local_Wind_Grass_Speed186_g1 * 10.0 );
				float Global_Wind_Grass_Turbulence161_g1 = ASPW_WindGrassTurbulence;
				float clampResult175_g1 = clamp( Global_Wind_Grass_Amplitude172_g1 , 0.0 , 1.0 );
				float temp_output_188_0_g1 = ( ( ( sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.0 ) ) ) + sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.25 ) ) ) ) * 0.5 ) * ( ( Global_Wind_Grass_Turbulence161_g1 * ( clampResult175_g1 * ( _WindGrassTurbulence * Local_Wind_Grass_Aplitude180_g1 ) ) ) * 0.1 ) );
				float3 appendResult183_g1 = (float3(temp_output_188_0_g1 , ( temp_output_188_0_g1 * 0.2 ) , temp_output_188_0_g1));
				float3 Wind_Turbulence185_g1 = appendResult183_g1;
				float3 rotatedValue56_g1 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction52_g1, ( Wind_Main_with_Waves108_g1 + Wind_Turbulence185_g1 ).x );
				float3 Output_Wind35_g1 = ( rotatedValue56_g1 - input.positionOS.xyz );
				float Wind_Mask225_g1 = input.ase_color.r;
				float3 lerpResult232_g1 = lerp( float3( 0,0,0 ) , ( Output_Wind35_g1 * Wind_Mask225_g1 ) , ASPW_WindToggle);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch192_g1 = lerpResult232_g1;
				#else
				float3 staticSwitch192_g1 = temp_cast_0;
				#endif
				
				output.ase_texcoord8.xy = input.texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord8.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch192_g1;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif
				input.normalOS = input.normalOS;
				input.tangentOS = input.tangentOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );
				VertexNormalInputs normalInput = GetVertexNormalInputs( input.normalOS, input.tangentOS );

				output.tSpace0 = float4( normalInput.normalWS, vertexInput.positionWS.x );
				output.tSpace1 = float4( normalInput.tangentWS, vertexInput.positionWS.y );
				output.tSpace2 = float4( normalInput.bitangentWS, vertexInput.positionWS.z );

				#if defined(LIGHTMAP_ON)
					OUTPUT_LIGHTMAP_UV(input.texcoord1, unity_LightmapST, output.lightmapUVOrVertexSH.xy);
				#else
					OUTPUT_SH(normalInput.normalWS.xyz, output.lightmapUVOrVertexSH.xyz);
				#endif
				#if defined(DYNAMICLIGHTMAP_ON)
					output.dynamicLightmapUV.xy = input.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					output.lightmapUVOrVertexSH.zw = input.texcoord.xy;
					output.lightmapUVOrVertexSH.xy = input.texcoord.xy * unity_LightmapST.xy + unity_LightmapST.zw;
				#endif

				#if defined(ASE_FOG) || defined(_ADDITIONAL_LIGHTS_VERTEX)
					output.fogFactorAndVertexLight = 0;
					#if defined(ASE_FOG) && !defined(_FOG_FRAGMENT)
						output.fogFactorAndVertexLight.x = ComputeFogFactor(vertexInput.positionCS.z);
					#endif
					#ifdef _ADDITIONAL_LIGHTS_VERTEX
						half3 vertexLight = VertexLighting( vertexInput.positionWS, normalInput.normalWS );
						output.fogFactorAndVertexLight.yzw = vertexLight;
					#endif
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					output.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				output.positionCS = vertexInput.positionCS;
				output.clipPosV = vertexInput.positionCS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( Attributes input )
			{
				VertexControl output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				output.positionOS = input.positionOS;
				output.normalOS = input.normalOS;
				output.tangentOS = input.tangentOS;
				output.texcoord = input.texcoord;
				output.texcoord1 = input.texcoord1;
				output.texcoord2 = input.texcoord2;
				output.ase_color = input.ase_color;
				return output;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> input)
			{
				TessellationFactors output;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				output.edge[0] = tf.x; output.edge[1] = tf.y; output.edge[2] = tf.z; output.inside = tf.w;
				return output;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
				return patch[id];
			}

			[domain("tri")]
			PackedVaryings DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				Attributes output = (Attributes) 0;
				output.positionOS = patch[0].positionOS * bary.x + patch[1].positionOS * bary.y + patch[2].positionOS * bary.z;
				output.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				output.tangentOS = patch[0].tangentOS * bary.x + patch[1].tangentOS * bary.y + patch[2].tangentOS * bary.z;
				output.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				output.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				output.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = output.positionOS.xyz - patch[i].normalOS * (dot(output.positionOS.xyz, patch[i].normalOS) - dot(patch[i].positionOS.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				output.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * output.positionOS.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], output);
				return VertexFunction(output);
			}
			#else
			PackedVaryings vert ( Attributes input )
			{
				return VertexFunction( input );
			}
			#endif

			half4 frag ( PackedVaryings input
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						#ifdef _WRITE_RENDERING_LAYERS
						, out float4 outRenderingLayers : SV_Target1
						#endif
						 ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( input.positionCS );
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float2 sampleCoords = (input.lightmapUVOrVertexSH.zw / _TerrainHeightmapRecipSize.zw + 0.5f) * _TerrainHeightmapRecipSize.xy;
					float3 WorldNormal = TransformObjectToWorldNormal(normalize(SAMPLE_TEXTURE2D(_TerrainNormalmapTexture, sampler_TerrainNormalmapTexture, sampleCoords).rgb * 2 - 1));
					float3 WorldTangent = -cross(GetObjectToWorldMatrix()._13_23_33, WorldNormal);
					float3 WorldBiTangent = cross(WorldNormal, -WorldTangent);
				#else
					float3 WorldNormal = normalize( input.tSpace0.xyz );
					float3 WorldTangent = input.tSpace1.xyz;
					float3 WorldBiTangent = input.tSpace2.xyz;
				#endif

				float3 WorldPosition = float3(input.tSpace0.w,input.tSpace1.w,input.tSpace2.w);
				float3 WorldViewDirection = GetWorldSpaceNormalizeViewDir( WorldPosition );
				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				float4 ClipPos = input.clipPosV;
				float4 ScreenPos = ComputeScreenPos( input.clipPosV );

				float2 NormalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(input.positionCS);

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					ShadowCoords = input.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
				#endif

				float2 uv_BaseAlbedo280 = input.ase_texcoord8.xy;
				float4 tex2DNode280 = tex2D( _BaseAlbedo, uv_BaseAlbedo280 );
				float3 desaturateInitialColor281 = tex2DNode280.rgb;
				float desaturateDot281 = dot( desaturateInitialColor281, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar281 = lerp( desaturateInitialColor281, desaturateDot281.xxx, _BaseAlbedoDesaturation );
				float3 Albedo_Texture299 = saturate( ( desaturateVar281 * _BaseAlbedoBrightness ) );
				float3 blendOpSrc283 = Albedo_Texture299;
				float3 blendOpDest283 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo289 = (( blendOpDest283 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest283 ) * ( 1.0 - blendOpSrc283 ) ) : ( 2.0 * blendOpDest283 * blendOpSrc283 ) );
				float3 blendOpSrc345 = Albedo_Texture299;
				float3 blendOpDest345 = _TintColor.rgb;
				float2 appendResult649 = (float2(WorldPosition.x , WorldPosition.z));
				float4 tex2DNode651 = tex2D( ASP_GlobalTintNoiseTexture, ( appendResult649 * ( 0.01 * ASP_GlobalTintNoiseUVScale * _TintNoiseUVScale ) ) );
				float lerpResult676 = lerp( tex2DNode651.r , ( 1.0 - tex2DNode651.r ) , _TintNoiseInvertMask);
				float Base_Tint_Color_Mask659 = saturate( ( lerpResult676 * ( ASP_GlobalTintNoiseContrast * _TintNoiseContrast ) * input.ase_color.r ) );
				float3 lerpResult656 = lerp( Base_Albedo289 , (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) , Base_Tint_Color_Mask659);
				float3 lerpResult661 = lerp( Base_Albedo289 , lerpResult656 , ( ASP_GlobalTintNoiseToggle * _TintNoiseIntensity * ASP_GlobalTintNoiseIntensity ));
				#ifdef _ENABLETINTVARIATIONCOLOR_ON
				float3 staticSwitch403 = lerpResult661;
				#else
				float3 staticSwitch403 = Base_Albedo289;
				#endif
				float3 Base_Albedo_and_Tint_Color374 = staticSwitch403;
				float3 blendOpSrc331 = Albedo_Texture299;
				float3 blendOpDest331 = _BottomColor.rgb;
				float saferPower336 = abs( ( 1.0 - input.ase_color.a ) );
				float3 lerpResult340 = lerp( Base_Albedo_and_Tint_Color374 , (( blendOpDest331 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest331 ) * ( 1.0 - blendOpSrc331 ) ) : ( 2.0 * blendOpDest331 * blendOpSrc331 ) ) , saturate( ( _BottomColorOffset * pow( saferPower336 , _BottomColorContrast ) ) ));
				#ifdef _ENABLEBOTTOMCOLOR_ON
				float3 staticSwitch375 = lerpResult340;
				#else
				float3 staticSwitch375 = Base_Albedo_and_Tint_Color374;
				#endif
				float3 Output_Albedo342 = staticSwitch375;
				
				float2 uv_BaseNormal318 = input.ase_texcoord8.xy;
				float3 unpack318 = UnpackNormalScale( tex2D( _BaseNormal, uv_BaseNormal318 ), _BaseNormalIntensity );
				unpack318.z = lerp( 1, unpack318.z, saturate(_BaseNormalIntensity) );
				float3 Base_Normal642 = unpack318;
				
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float2 appendResult73_g1 = (float2(WorldPosition.x , WorldPosition.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2D( ASPW_WindGrassWavesNoiseTexture, ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy ).r;
				float Wind_Waves621 = Wind_Waves93_g1;
				float lerpResult304 = lerp( 0.0 , _BaseSmoothnessIntensity , ( input.ase_color.r * ( Wind_Waves621 + _BaseSmoothnessWaves ) ));
				#ifdef _ENABLESMOOTHNESSWAVES_ON
				float staticSwitch726 = lerpResult304;
				#else
				float staticSwitch726 = _BaseSmoothnessIntensity;
				#endif
				float Base_Smoothness314 = saturate( staticSwitch726 );
				
				float Base_Opacity295 = tex2DNode280.a;
				float4 ase_positionSSNorm = ScreenPos / ScreenPos.w;
				ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
				float4 ase_positionSS_Pixel = ASEScreenPositionNormalizedToPixel( ase_positionSSNorm );
				float dither735 = Dither4x4Bayer( fmod( ase_positionSS_Pixel.x, 4 ), fmod( ase_positionSS_Pixel.y, 4 ) );
				dither735 = step( dither735, saturate( saturate( ( ( input.ase_color.r - _BottomDitherOffset ) * ( _BottomDitherContrast * 2 ) ) ) * 1.00001 ) );
				#ifdef _ENABLEBOTTOMDITHER_ON
				float staticSwitch738 = ( dither735 * Base_Opacity295 );
				#else
				float staticSwitch738 = Base_Opacity295;
				#endif
				float Output_Opacity739 = staticSwitch738;
				

				float3 BaseColor = Output_Albedo342;
				float3 Normal = Base_Normal642;
				float3 Emission = 0;
				float3 Specular = 0.5;
				float Metallic = 0;
				float Smoothness = Base_Smoothness314;
				float Occlusion = 1;
				float Alpha = Output_Opacity739;
				float AlphaClipThreshold = _BaseOpacityCutoff;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = input.positionCS.z;
				#endif

				#ifdef _CLEARCOAT
					float CoatMask = 0;
					float CoatSmoothness = 0;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				InputData inputData = (InputData)0;
				inputData.positionWS = WorldPosition;
				inputData.positionCS = input.positionCS;
				inputData.viewDirectionWS = WorldViewDirection;

				#ifdef _NORMALMAP
						#if _NORMAL_DROPOFF_TS
							inputData.normalWS = TransformTangentToWorld(Normal, half3x3(WorldTangent, WorldBiTangent, WorldNormal));
						#elif _NORMAL_DROPOFF_OS
							inputData.normalWS = TransformObjectToWorldNormal(Normal);
						#elif _NORMAL_DROPOFF_WS
							inputData.normalWS = Normal;
						#endif
					inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
				#else
					inputData.normalWS = WorldNormal;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					inputData.shadowCoord = ShadowCoords;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					inputData.shadowCoord = TransformWorldToShadowCoord(inputData.positionWS);
				#else
					inputData.shadowCoord = float4(0, 0, 0, 0);
				#endif

				#ifdef ASE_FOG
					inputData.fogCoord = InitializeInputDataFog(float4(inputData.positionWS, 1.0), input.fogFactorAndVertexLight.x);
				#endif
				#ifdef _ADDITIONAL_LIGHTS_VERTEX
					inputData.vertexLighting = input.fogFactorAndVertexLight.yzw;
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float3 SH = SampleSH(inputData.normalWS.xyz);
				#else
					float3 SH = input.lightmapUVOrVertexSH.xyz;
				#endif

				#if defined(DYNAMICLIGHTMAP_ON)
					inputData.bakedGI = SAMPLE_GI(input.lightmapUVOrVertexSH.xy, input.dynamicLightmapUV.xy, SH, inputData.normalWS);
				#else
					inputData.bakedGI = SAMPLE_GI(input.lightmapUVOrVertexSH.xy, SH, inputData.normalWS);
				#endif

				#ifdef ASE_BAKEDGI
					inputData.bakedGI = BakedGI;
				#endif

				inputData.normalizedScreenSpaceUV = NormalizedScreenSpaceUV;
				inputData.shadowMask = SAMPLE_SHADOWMASK(input.lightmapUVOrVertexSH.xy);

				#if defined(DEBUG_DISPLAY)
					#if defined(DYNAMICLIGHTMAP_ON)
						inputData.dynamicLightmapUV = input.dynamicLightmapUV.xy;
					#endif
					#if defined(LIGHTMAP_ON)
						inputData.staticLightmapUV = input.lightmapUVOrVertexSH.xy;
					#else
						inputData.vertexSH = SH;
					#endif
				#endif

				SurfaceData surfaceData;
				surfaceData.albedo              = BaseColor;
				surfaceData.metallic            = saturate(Metallic);
				surfaceData.specular            = Specular;
				surfaceData.smoothness          = saturate(Smoothness),
				surfaceData.occlusion           = Occlusion,
				surfaceData.emission            = Emission,
				surfaceData.alpha               = saturate(Alpha);
				surfaceData.normalTS            = Normal;
				surfaceData.clearCoatMask       = 0;
				surfaceData.clearCoatSmoothness = 1;

				#ifdef _CLEARCOAT
					surfaceData.clearCoatMask       = saturate(CoatMask);
					surfaceData.clearCoatSmoothness = saturate(CoatSmoothness);
				#endif

				#ifdef _DBUFFER
					ApplyDecalToSurfaceData(input.positionCS, surfaceData, inputData);
				#endif

				#ifdef _ASE_LIGHTING_SIMPLE
					half4 color = UniversalFragmentBlinnPhong( inputData, surfaceData);
				#else
					half4 color = UniversalFragmentPBR( inputData, surfaceData);
				#endif

				#ifdef ASE_TRANSMISSION
				{
					float shadow = _TransmissionShadow;

					#define SUM_LIGHT_TRANSMISSION(Light)\
						float3 atten = Light.color * Light.distanceAttenuation;\
						atten = lerp( atten, atten * Light.shadowAttenuation, shadow );\
						half3 transmission = max( 0, -dot( inputData.normalWS, Light.direction ) ) * atten * Transmission;\
						color.rgb += BaseColor * transmission;

					SUM_LIGHT_TRANSMISSION( GetMainLight( inputData.shadowCoord ) );

					#if defined(_ADDITIONAL_LIGHTS)
						uint meshRenderingLayers = GetMeshRenderingLayer();
						uint pixelLightCount = GetAdditionalLightsCount();
						#if USE_FORWARD_PLUS
							for (uint lightIndex = 0; lightIndex < min(URP_FP_DIRECTIONAL_LIGHTS_COUNT, MAX_VISIBLE_LIGHTS); lightIndex++)
							{
								FORWARD_PLUS_SUBTRACTIVE_LIGHT_CHECK

								Light light = GetAdditionalLight(lightIndex, inputData.positionWS, inputData.shadowMask);
								#ifdef _LIGHT_LAYERS
								if (IsMatchingLightLayer(light.layerMask, meshRenderingLayers))
								#endif
								{
									SUM_LIGHT_TRANSMISSION( light );
								}
							}
						#endif
						LIGHT_LOOP_BEGIN( pixelLightCount )
							Light light = GetAdditionalLight(lightIndex, inputData.positionWS, inputData.shadowMask);
							#ifdef _LIGHT_LAYERS
							if (IsMatchingLightLayer(light.layerMask, meshRenderingLayers))
							#endif
							{
								SUM_LIGHT_TRANSMISSION( light );
							}
						LIGHT_LOOP_END
					#endif
				}
				#endif

				#ifdef ASE_TRANSLUCENCY
				{
					float shadow = _TransShadow;
					float normal = _TransNormal;
					float scattering = _TransScattering;
					float direct = _TransDirect;
					float ambient = _TransAmbient;
					float strength = _TransStrength;

					#define SUM_LIGHT_TRANSLUCENCY(Light)\
						float3 atten = Light.color * Light.distanceAttenuation;\
						atten = lerp( atten, atten * Light.shadowAttenuation, shadow );\
						half3 lightDir = Light.direction + inputData.normalWS * normal;\
						half VdotL = pow( saturate( dot( inputData.viewDirectionWS, -lightDir ) ), scattering );\
						half3 translucency = atten * ( VdotL * direct + inputData.bakedGI * ambient ) * Translucency;\
						color.rgb += BaseColor * translucency * strength;

					SUM_LIGHT_TRANSLUCENCY( GetMainLight( inputData.shadowCoord ) );

					#if defined(_ADDITIONAL_LIGHTS)
						uint meshRenderingLayers = GetMeshRenderingLayer();
						uint pixelLightCount = GetAdditionalLightsCount();
						#if USE_FORWARD_PLUS
							for (uint lightIndex = 0; lightIndex < min(URP_FP_DIRECTIONAL_LIGHTS_COUNT, MAX_VISIBLE_LIGHTS); lightIndex++)
							{
								FORWARD_PLUS_SUBTRACTIVE_LIGHT_CHECK

								Light light = GetAdditionalLight(lightIndex, inputData.positionWS, inputData.shadowMask);
								#ifdef _LIGHT_LAYERS
								if (IsMatchingLightLayer(light.layerMask, meshRenderingLayers))
								#endif
								{
									SUM_LIGHT_TRANSLUCENCY( light );
								}
							}
						#endif
						LIGHT_LOOP_BEGIN( pixelLightCount )
							Light light = GetAdditionalLight(lightIndex, inputData.positionWS, inputData.shadowMask);
							#ifdef _LIGHT_LAYERS
							if (IsMatchingLightLayer(light.layerMask, meshRenderingLayers))
							#endif
							{
								SUM_LIGHT_TRANSLUCENCY( light );
							}
						LIGHT_LOOP_END
					#endif
				}
				#endif

				#ifdef ASE_REFRACTION
					float4 projScreenPos = ScreenPos / ScreenPos.w;
					float3 refractionOffset = ( RefractionIndex - 1.0 ) * mul( UNITY_MATRIX_V, float4( WorldNormal,0 ) ).xyz * ( 1.0 - dot( WorldNormal, WorldViewDirection ) );
					projScreenPos.xy += refractionOffset.xy;
					float3 refraction = SHADERGRAPH_SAMPLE_SCENE_COLOR( projScreenPos.xy ) * RefractionColor;
					color.rgb = lerp( refraction, color.rgb, color.a );
					color.a = 1;
				#endif

				#ifdef ASE_FINAL_COLOR_ALPHA_MULTIPLY
					color.rgb *= color.a;
				#endif

				#ifdef ASE_FOG
					#ifdef TERRAIN_SPLAT_ADDPASS
						color.rgb = MixFogColor(color.rgb, half3(0,0,0), inputData.fogCoord);
					#else
						color.rgb = MixFog(color.rgb, inputData.fogCoord);
					#endif
				#endif

				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
				#endif

				#ifdef _WRITE_RENDERING_LAYERS
					uint renderingLayers = GetMeshRenderingLayer();
					outRenderingLayers = float4( EncodeMeshRenderingLayer( renderingLayers ), 0, 0, 0 );
				#endif

				return color;
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "ShadowCaster"
			Tags { "LightMode"="ShadowCaster" }

			ZWrite On
			ZTest LEqual
			AlphaToMask Off
			ColorMask 0

			HLSLPROGRAM

			

			#pragma multi_compile _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011


			

			#pragma multi_compile_vertex _ _CASTING_PUNCTUAL_LIGHT_SHADOW

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(_ASE_LIGHTING_SIMPLE)
				#define _SPECULAR_COLOR 1
			#endif

			#define SHADERPASS SHADERPASS_SHADOWCASTER

			
            #if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"

			
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
           

			
            #if ASE_SRP_VERSION >=140009
			#include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLEBOTTOMDITHER_ON


			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE) && (SHADER_TARGET >= 45)
				#define ASE_SV_DEPTH SV_DepthLessEqual
				#define ASE_SV_POSITION_QUALIFIERS linear noperspective centroid
			#else
				#define ASE_SV_DEPTH SV_Depth
				#define ASE_SV_POSITION_QUALIFIERS
			#endif

			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				float3 positionWS : TEXCOORD1;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD2;
				#endif
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseAlbedoColor;
			float4 _TintColor;
			float4 _BottomColor;
			float _WindGrassSpeed;
			float _BottomDitherOffset;
			float _BaseSmoothnessWaves;
			float _BaseSmoothnessIntensity;
			float _BaseNormalIntensity;
			float _BottomColorContrast;
			float _BottomColorOffset;
			float _TintNoiseIntensity;
			float _TintNoiseInvertMask;
			float _BottomDitherContrast;
			float _TintNoiseUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindGrassTurbulence;
			float _WindGrassScale;
			float _WindGrassFlexibility;
			float _WindGrassAmplitude;
			float _TintNoiseContrast;
			float _BaseOpacityCutoff;
			#ifdef ASE_TRANSMISSION
				float _TransmissionShadow;
			#endif
			#ifdef ASE_TRANSLUCENCY
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D ASPW_WindGrassWavesNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindGrassSpeed;
			half ASPW_WindGrassAmplitude;
			half ASPW_WindGrassFlexibility;
			half ASPW_WindGrassWavesAmplitude;
			half ASPW_WindGrassWavesSpeed;
			half ASPW_WindGrassWavesScale;
			half ASPW_WindGrassTurbulence;
			half ASPW_WindToggle;
			sampler2D _BaseAlbedo;


			float3 ASESafeNormalize(float3 inVec)
			{
				float dp3 = max(1.175494351e-38, dot(inVec, inVec));
				return inVec* rsqrt(dp3);
			}
			
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 ASEScreenPositionNormalizedToPixel( float4 screenPosNorm )
			{
				float4 screenPosPixel = screenPosNorm * float4( _ScreenParams.xy, 1, 1 );
				#if UNITY_UV_STARTS_AT_TOP
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x < 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#else
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x > 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#endif
				return screenPosPixel;
			}
			
			inline float Dither4x4Bayer( int x, int y )
			{
				const float dither[ 16 ] = {
				     1,  9,  3, 11,
				    13,  5, 15,  7,
				     4, 12,  2, 10,
				    16,  8, 14,  6 };
				int r = y * 4 + x;
				return dither[ r ] / 16; // same # of instructions as pre-dividing due to compiler magic
			}
			

			float3 _LightDirection;
			float3 _LightPosition;

			PackedVaryings VertexFunction( Attributes input )
			{
				PackedVaryings output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( output );

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 worldToObjDir40_g1 = mul( GetWorldToObjectMatrix(), float4( normalizeResult41_g1, 0.0 ) ).xyz;
				float3 Wind_Direction_Leaf50_g1 = worldToObjDir40_g1;
				float3 break42_g1 = Wind_Direction_Leaf50_g1;
				float3 appendResult43_g1 = (float3(break42_g1.z , 0.0 , ( break42_g1.x * -1.0 )));
				float3 Wind_Direction52_g1 = appendResult43_g1;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Grass_Randomization65_g1 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_5_0_g1 = ( Wind_Grass_Randomization65_g1 + _TimeParameters.x );
				float Global_Wind_Grass_Speed144_g1 = ASPW_WindGrassSpeed;
				float temp_output_9_0_g1 = ( _WindGrassSpeed * Global_Wind_Grass_Speed144_g1 * 10.0 );
				float Local_Wind_Grass_Aplitude180_g1 = _WindGrassAmplitude;
				float Global_Wind_Grass_Amplitude172_g1 = ASPW_WindGrassAmplitude;
				float temp_output_27_0_g1 = ( Local_Wind_Grass_Aplitude180_g1 * Global_Wind_Grass_Amplitude172_g1 );
				float Global_Wind_Grass_Flexibility164_g1 = ASPW_WindGrassFlexibility;
				float Wind_Main31_g1 = ( ( ( ( ( sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.0 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.25 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.5 ) ) ) ) + temp_output_27_0_g1 ) * temp_output_27_0_g1 ) / 50.0 ) * ( ( Global_Wind_Grass_Flexibility164_g1 * _WindGrassFlexibility ) * 0.1 ) );
				float Global_Wind_Grass_Waves_Amplitude162_g1 = ASPW_WindGrassWavesAmplitude;
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 appendResult73_g1 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2Dlod( ASPW_WindGrassWavesNoiseTexture, float4( ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).r;
				float lerpResult96_g1 = lerp( Wind_Main31_g1 , ( Wind_Main31_g1 * Global_Wind_Grass_Waves_Amplitude162_g1 ) , Wind_Waves93_g1);
				float Wind_Main_with_Waves108_g1 = lerpResult96_g1;
				float temp_output_141_0_g1 = ( ( ase_positionWS.y * ( _WindGrassScale * 10.0 ) ) + _TimeParameters.x );
				float Local_Wind_Grass_Speed186_g1 = _WindGrassSpeed;
				float temp_output_146_0_g1 = ( Global_Wind_Grass_Speed144_g1 * Local_Wind_Grass_Speed186_g1 * 10.0 );
				float Global_Wind_Grass_Turbulence161_g1 = ASPW_WindGrassTurbulence;
				float clampResult175_g1 = clamp( Global_Wind_Grass_Amplitude172_g1 , 0.0 , 1.0 );
				float temp_output_188_0_g1 = ( ( ( sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.0 ) ) ) + sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.25 ) ) ) ) * 0.5 ) * ( ( Global_Wind_Grass_Turbulence161_g1 * ( clampResult175_g1 * ( _WindGrassTurbulence * Local_Wind_Grass_Aplitude180_g1 ) ) ) * 0.1 ) );
				float3 appendResult183_g1 = (float3(temp_output_188_0_g1 , ( temp_output_188_0_g1 * 0.2 ) , temp_output_188_0_g1));
				float3 Wind_Turbulence185_g1 = appendResult183_g1;
				float3 rotatedValue56_g1 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction52_g1, ( Wind_Main_with_Waves108_g1 + Wind_Turbulence185_g1 ).x );
				float3 Output_Wind35_g1 = ( rotatedValue56_g1 - input.positionOS.xyz );
				float Wind_Mask225_g1 = input.ase_color.r;
				float3 lerpResult232_g1 = lerp( float3( 0,0,0 ) , ( Output_Wind35_g1 * Wind_Mask225_g1 ) , ASPW_WindToggle);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch192_g1 = lerpResult232_g1;
				#else
				float3 staticSwitch192_g1 = temp_cast_0;
				#endif
				
				output.ase_texcoord3.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord3.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch192_g1;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;

				float3 positionWS = TransformObjectToWorld( input.positionOS.xyz );
				float3 normalWS = TransformObjectToWorldDir(input.normalOS);

				#if _CASTING_PUNCTUAL_LIGHT_SHADOW
					float3 lightDirectionWS = normalize(_LightPosition - positionWS);
				#else
					float3 lightDirectionWS = _LightDirection;
				#endif

				float4 positionCS = TransformWorldToHClip(ApplyShadowBias(positionWS, normalWS, lightDirectionWS));

				#if UNITY_REVERSED_Z
					positionCS.z = min(positionCS.z, UNITY_NEAR_CLIP_VALUE);
				#else
					positionCS.z = max(positionCS.z, UNITY_NEAR_CLIP_VALUE);
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					output.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				output.positionCS = positionCS;
				output.clipPosV = positionCS;
				output.positionWS = positionWS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( Attributes input )
			{
				VertexControl output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				output.positionOS = input.positionOS;
				output.normalOS = input.normalOS;
				output.ase_color = input.ase_color;
				output.ase_texcoord = input.ase_texcoord;
				return output;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> input)
			{
				TessellationFactors output;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				output.edge[0] = tf.x; output.edge[1] = tf.y; output.edge[2] = tf.z; output.inside = tf.w;
				return output;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
				return patch[id];
			}

			[domain("tri")]
			PackedVaryings DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				Attributes output = (Attributes) 0;
				output.positionOS = patch[0].positionOS * bary.x + patch[1].positionOS * bary.y + patch[2].positionOS * bary.z;
				output.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = output.positionOS.xyz - patch[i].normalOS * (dot(output.positionOS.xyz, patch[i].normalOS) - dot(patch[i].positionOS.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				output.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * output.positionOS.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], output);
				return VertexFunction(output);
			}
			#else
			PackedVaryings vert ( Attributes input )
			{
				return VertexFunction( input );
			}
			#endif

			half4 frag(	PackedVaryings input
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( input );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( input );

				float3 WorldPosition = input.positionWS;
				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				float4 ClipPos = input.clipPosV;
				float4 ScreenPos = ComputeScreenPos( input.clipPosV );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = input.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float2 uv_BaseAlbedo280 = input.ase_texcoord3.xy;
				float4 tex2DNode280 = tex2D( _BaseAlbedo, uv_BaseAlbedo280 );
				float Base_Opacity295 = tex2DNode280.a;
				float4 ase_positionSSNorm = ScreenPos / ScreenPos.w;
				ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
				float4 ase_positionSS_Pixel = ASEScreenPositionNormalizedToPixel( ase_positionSSNorm );
				float dither735 = Dither4x4Bayer( fmod( ase_positionSS_Pixel.x, 4 ), fmod( ase_positionSS_Pixel.y, 4 ) );
				dither735 = step( dither735, saturate( saturate( ( ( input.ase_color.r - _BottomDitherOffset ) * ( _BottomDitherContrast * 2 ) ) ) * 1.00001 ) );
				#ifdef _ENABLEBOTTOMDITHER_ON
				float staticSwitch738 = ( dither735 * Base_Opacity295 );
				#else
				float staticSwitch738 = Base_Opacity295;
				#endif
				float Output_Opacity739 = staticSwitch738;
				

				float Alpha = Output_Opacity739;
				float AlphaClipThreshold = _BaseOpacityCutoff;
				float AlphaClipThresholdShadow = 0.5;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = input.positionCS.z;
				#endif

				#ifdef _ALPHATEST_ON
					#ifdef _ALPHATEST_SHADOW_ON
						clip(Alpha - AlphaClipThresholdShadow);
					#else
						clip(Alpha - AlphaClipThreshold);
					#endif
				#endif

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( input.positionCS );
				#endif

				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
				#endif

				return 0;
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "DepthOnly"
			Tags { "LightMode"="DepthOnly" }

			ZWrite On
			ColorMask R
			AlphaToMask Off

			HLSLPROGRAM

			

			#pragma multi_compile _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011


			

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(_ASE_LIGHTING_SIMPLE)
				#define _SPECULAR_COLOR 1
			#endif

			#define SHADERPASS SHADERPASS_DEPTHONLY

			
            #if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"

			
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
           

			
            #if ASE_SRP_VERSION >=140009
			#include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLEBOTTOMDITHER_ON


			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE) && (SHADER_TARGET >= 45)
				#define ASE_SV_DEPTH SV_DepthLessEqual
				#define ASE_SV_POSITION_QUALIFIERS linear noperspective centroid
			#else
				#define ASE_SV_DEPTH SV_Depth
				#define ASE_SV_POSITION_QUALIFIERS
			#endif

			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				float3 positionWS : TEXCOORD1;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD2;
				#endif
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseAlbedoColor;
			float4 _TintColor;
			float4 _BottomColor;
			float _WindGrassSpeed;
			float _BottomDitherOffset;
			float _BaseSmoothnessWaves;
			float _BaseSmoothnessIntensity;
			float _BaseNormalIntensity;
			float _BottomColorContrast;
			float _BottomColorOffset;
			float _TintNoiseIntensity;
			float _TintNoiseInvertMask;
			float _BottomDitherContrast;
			float _TintNoiseUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindGrassTurbulence;
			float _WindGrassScale;
			float _WindGrassFlexibility;
			float _WindGrassAmplitude;
			float _TintNoiseContrast;
			float _BaseOpacityCutoff;
			#ifdef ASE_TRANSMISSION
				float _TransmissionShadow;
			#endif
			#ifdef ASE_TRANSLUCENCY
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D ASPW_WindGrassWavesNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindGrassSpeed;
			half ASPW_WindGrassAmplitude;
			half ASPW_WindGrassFlexibility;
			half ASPW_WindGrassWavesAmplitude;
			half ASPW_WindGrassWavesSpeed;
			half ASPW_WindGrassWavesScale;
			half ASPW_WindGrassTurbulence;
			half ASPW_WindToggle;
			sampler2D _BaseAlbedo;


			float3 ASESafeNormalize(float3 inVec)
			{
				float dp3 = max(1.175494351e-38, dot(inVec, inVec));
				return inVec* rsqrt(dp3);
			}
			
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 ASEScreenPositionNormalizedToPixel( float4 screenPosNorm )
			{
				float4 screenPosPixel = screenPosNorm * float4( _ScreenParams.xy, 1, 1 );
				#if UNITY_UV_STARTS_AT_TOP
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x < 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#else
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x > 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#endif
				return screenPosPixel;
			}
			
			inline float Dither4x4Bayer( int x, int y )
			{
				const float dither[ 16 ] = {
				     1,  9,  3, 11,
				    13,  5, 15,  7,
				     4, 12,  2, 10,
				    16,  8, 14,  6 };
				int r = y * 4 + x;
				return dither[ r ] / 16; // same # of instructions as pre-dividing due to compiler magic
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 worldToObjDir40_g1 = mul( GetWorldToObjectMatrix(), float4( normalizeResult41_g1, 0.0 ) ).xyz;
				float3 Wind_Direction_Leaf50_g1 = worldToObjDir40_g1;
				float3 break42_g1 = Wind_Direction_Leaf50_g1;
				float3 appendResult43_g1 = (float3(break42_g1.z , 0.0 , ( break42_g1.x * -1.0 )));
				float3 Wind_Direction52_g1 = appendResult43_g1;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Grass_Randomization65_g1 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_5_0_g1 = ( Wind_Grass_Randomization65_g1 + _TimeParameters.x );
				float Global_Wind_Grass_Speed144_g1 = ASPW_WindGrassSpeed;
				float temp_output_9_0_g1 = ( _WindGrassSpeed * Global_Wind_Grass_Speed144_g1 * 10.0 );
				float Local_Wind_Grass_Aplitude180_g1 = _WindGrassAmplitude;
				float Global_Wind_Grass_Amplitude172_g1 = ASPW_WindGrassAmplitude;
				float temp_output_27_0_g1 = ( Local_Wind_Grass_Aplitude180_g1 * Global_Wind_Grass_Amplitude172_g1 );
				float Global_Wind_Grass_Flexibility164_g1 = ASPW_WindGrassFlexibility;
				float Wind_Main31_g1 = ( ( ( ( ( sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.0 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.25 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.5 ) ) ) ) + temp_output_27_0_g1 ) * temp_output_27_0_g1 ) / 50.0 ) * ( ( Global_Wind_Grass_Flexibility164_g1 * _WindGrassFlexibility ) * 0.1 ) );
				float Global_Wind_Grass_Waves_Amplitude162_g1 = ASPW_WindGrassWavesAmplitude;
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 appendResult73_g1 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2Dlod( ASPW_WindGrassWavesNoiseTexture, float4( ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).r;
				float lerpResult96_g1 = lerp( Wind_Main31_g1 , ( Wind_Main31_g1 * Global_Wind_Grass_Waves_Amplitude162_g1 ) , Wind_Waves93_g1);
				float Wind_Main_with_Waves108_g1 = lerpResult96_g1;
				float temp_output_141_0_g1 = ( ( ase_positionWS.y * ( _WindGrassScale * 10.0 ) ) + _TimeParameters.x );
				float Local_Wind_Grass_Speed186_g1 = _WindGrassSpeed;
				float temp_output_146_0_g1 = ( Global_Wind_Grass_Speed144_g1 * Local_Wind_Grass_Speed186_g1 * 10.0 );
				float Global_Wind_Grass_Turbulence161_g1 = ASPW_WindGrassTurbulence;
				float clampResult175_g1 = clamp( Global_Wind_Grass_Amplitude172_g1 , 0.0 , 1.0 );
				float temp_output_188_0_g1 = ( ( ( sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.0 ) ) ) + sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.25 ) ) ) ) * 0.5 ) * ( ( Global_Wind_Grass_Turbulence161_g1 * ( clampResult175_g1 * ( _WindGrassTurbulence * Local_Wind_Grass_Aplitude180_g1 ) ) ) * 0.1 ) );
				float3 appendResult183_g1 = (float3(temp_output_188_0_g1 , ( temp_output_188_0_g1 * 0.2 ) , temp_output_188_0_g1));
				float3 Wind_Turbulence185_g1 = appendResult183_g1;
				float3 rotatedValue56_g1 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction52_g1, ( Wind_Main_with_Waves108_g1 + Wind_Turbulence185_g1 ).x );
				float3 Output_Wind35_g1 = ( rotatedValue56_g1 - input.positionOS.xyz );
				float Wind_Mask225_g1 = input.ase_color.r;
				float3 lerpResult232_g1 = lerp( float3( 0,0,0 ) , ( Output_Wind35_g1 * Wind_Mask225_g1 ) , ASPW_WindToggle);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch192_g1 = lerpResult232_g1;
				#else
				float3 staticSwitch192_g1 = temp_cast_0;
				#endif
				
				output.ase_texcoord3.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord3.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch192_g1;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					output.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				output.positionCS = vertexInput.positionCS;
				output.clipPosV = vertexInput.positionCS;
				output.positionWS = vertexInput.positionWS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( Attributes input )
			{
				VertexControl output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				output.positionOS = input.positionOS;
				output.normalOS = input.normalOS;
				output.ase_color = input.ase_color;
				output.ase_texcoord = input.ase_texcoord;
				return output;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> input)
			{
				TessellationFactors output;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				output.edge[0] = tf.x; output.edge[1] = tf.y; output.edge[2] = tf.z; output.inside = tf.w;
				return output;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
				return patch[id];
			}

			[domain("tri")]
			PackedVaryings DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				Attributes output = (Attributes) 0;
				output.positionOS = patch[0].positionOS * bary.x + patch[1].positionOS * bary.y + patch[2].positionOS * bary.z;
				output.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = output.positionOS.xyz - patch[i].normalOS * (dot(output.positionOS.xyz, patch[i].normalOS) - dot(patch[i].positionOS.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				output.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * output.positionOS.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], output);
				return VertexFunction(output);
			}
			#else
			PackedVaryings vert ( Attributes input )
			{
				return VertexFunction( input );
			}
			#endif

			half4 frag(	PackedVaryings input
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( input );

				float3 WorldPosition = input.positionWS;
				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				float4 ClipPos = input.clipPosV;
				float4 ScreenPos = ComputeScreenPos( input.clipPosV );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = input.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float2 uv_BaseAlbedo280 = input.ase_texcoord3.xy;
				float4 tex2DNode280 = tex2D( _BaseAlbedo, uv_BaseAlbedo280 );
				float Base_Opacity295 = tex2DNode280.a;
				float4 ase_positionSSNorm = ScreenPos / ScreenPos.w;
				ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
				float4 ase_positionSS_Pixel = ASEScreenPositionNormalizedToPixel( ase_positionSSNorm );
				float dither735 = Dither4x4Bayer( fmod( ase_positionSS_Pixel.x, 4 ), fmod( ase_positionSS_Pixel.y, 4 ) );
				dither735 = step( dither735, saturate( saturate( ( ( input.ase_color.r - _BottomDitherOffset ) * ( _BottomDitherContrast * 2 ) ) ) * 1.00001 ) );
				#ifdef _ENABLEBOTTOMDITHER_ON
				float staticSwitch738 = ( dither735 * Base_Opacity295 );
				#else
				float staticSwitch738 = Base_Opacity295;
				#endif
				float Output_Opacity739 = staticSwitch738;
				

				float Alpha = Output_Opacity739;
				float AlphaClipThreshold = _BaseOpacityCutoff;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = input.positionCS.z;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( input.positionCS );
				#endif

				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
				#endif

				return 0;
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "Meta"
			Tags { "LightMode"="Meta" }

			Cull Off

			HLSLPROGRAM
			#pragma multi_compile_fragment _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011

			#pragma shader_feature EDITOR_VISUALIZATION

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(_ASE_LIGHTING_SIMPLE)
				#define _SPECULAR_COLOR 1
			#endif

			#define SHADERPASS SHADERPASS_META

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"

			
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
           

			
            #if ASE_SRP_VERSION >=140009
			#include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLEBOTTOMCOLOR_ON
			#pragma shader_feature_local _ENABLETINTVARIATIONCOLOR_ON
			#pragma shader_feature_local _ENABLEBOTTOMDITHER_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 positionWS : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD1;
				#endif
				#ifdef EDITOR_VISUALIZATION
					float4 VizUV : TEXCOORD2;
					float4 LightCoord : TEXCOORD3;
				#endif
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_color : COLOR;
				float4 ase_texcoord5 : TEXCOORD5;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseAlbedoColor;
			float4 _TintColor;
			float4 _BottomColor;
			float _WindGrassSpeed;
			float _BottomDitherOffset;
			float _BaseSmoothnessWaves;
			float _BaseSmoothnessIntensity;
			float _BaseNormalIntensity;
			float _BottomColorContrast;
			float _BottomColorOffset;
			float _TintNoiseIntensity;
			float _TintNoiseInvertMask;
			float _BottomDitherContrast;
			float _TintNoiseUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindGrassTurbulence;
			float _WindGrassScale;
			float _WindGrassFlexibility;
			float _WindGrassAmplitude;
			float _TintNoiseContrast;
			float _BaseOpacityCutoff;
			#ifdef ASE_TRANSMISSION
				float _TransmissionShadow;
			#endif
			#ifdef ASE_TRANSLUCENCY
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D ASPW_WindGrassWavesNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindGrassSpeed;
			half ASPW_WindGrassAmplitude;
			half ASPW_WindGrassFlexibility;
			half ASPW_WindGrassWavesAmplitude;
			half ASPW_WindGrassWavesSpeed;
			half ASPW_WindGrassWavesScale;
			half ASPW_WindGrassTurbulence;
			half ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			sampler2D ASP_GlobalTintNoiseTexture;
			half ASP_GlobalTintNoiseUVScale;
			half ASP_GlobalTintNoiseContrast;
			half ASP_GlobalTintNoiseToggle;
			half ASP_GlobalTintNoiseIntensity;


			float3 ASESafeNormalize(float3 inVec)
			{
				float dp3 = max(1.175494351e-38, dot(inVec, inVec));
				return inVec* rsqrt(dp3);
			}
			
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 ASEScreenPositionNormalizedToPixel( float4 screenPosNorm )
			{
				float4 screenPosPixel = screenPosNorm * float4( _ScreenParams.xy, 1, 1 );
				#if UNITY_UV_STARTS_AT_TOP
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x < 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#else
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x > 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#endif
				return screenPosPixel;
			}
			
			inline float Dither4x4Bayer( int x, int y )
			{
				const float dither[ 16 ] = {
				     1,  9,  3, 11,
				    13,  5, 15,  7,
				     4, 12,  2, 10,
				    16,  8, 14,  6 };
				int r = y * 4 + x;
				return dither[ r ] / 16; // same # of instructions as pre-dividing due to compiler magic
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 worldToObjDir40_g1 = mul( GetWorldToObjectMatrix(), float4( normalizeResult41_g1, 0.0 ) ).xyz;
				float3 Wind_Direction_Leaf50_g1 = worldToObjDir40_g1;
				float3 break42_g1 = Wind_Direction_Leaf50_g1;
				float3 appendResult43_g1 = (float3(break42_g1.z , 0.0 , ( break42_g1.x * -1.0 )));
				float3 Wind_Direction52_g1 = appendResult43_g1;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Grass_Randomization65_g1 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_5_0_g1 = ( Wind_Grass_Randomization65_g1 + _TimeParameters.x );
				float Global_Wind_Grass_Speed144_g1 = ASPW_WindGrassSpeed;
				float temp_output_9_0_g1 = ( _WindGrassSpeed * Global_Wind_Grass_Speed144_g1 * 10.0 );
				float Local_Wind_Grass_Aplitude180_g1 = _WindGrassAmplitude;
				float Global_Wind_Grass_Amplitude172_g1 = ASPW_WindGrassAmplitude;
				float temp_output_27_0_g1 = ( Local_Wind_Grass_Aplitude180_g1 * Global_Wind_Grass_Amplitude172_g1 );
				float Global_Wind_Grass_Flexibility164_g1 = ASPW_WindGrassFlexibility;
				float Wind_Main31_g1 = ( ( ( ( ( sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.0 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.25 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.5 ) ) ) ) + temp_output_27_0_g1 ) * temp_output_27_0_g1 ) / 50.0 ) * ( ( Global_Wind_Grass_Flexibility164_g1 * _WindGrassFlexibility ) * 0.1 ) );
				float Global_Wind_Grass_Waves_Amplitude162_g1 = ASPW_WindGrassWavesAmplitude;
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 appendResult73_g1 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2Dlod( ASPW_WindGrassWavesNoiseTexture, float4( ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).r;
				float lerpResult96_g1 = lerp( Wind_Main31_g1 , ( Wind_Main31_g1 * Global_Wind_Grass_Waves_Amplitude162_g1 ) , Wind_Waves93_g1);
				float Wind_Main_with_Waves108_g1 = lerpResult96_g1;
				float temp_output_141_0_g1 = ( ( ase_positionWS.y * ( _WindGrassScale * 10.0 ) ) + _TimeParameters.x );
				float Local_Wind_Grass_Speed186_g1 = _WindGrassSpeed;
				float temp_output_146_0_g1 = ( Global_Wind_Grass_Speed144_g1 * Local_Wind_Grass_Speed186_g1 * 10.0 );
				float Global_Wind_Grass_Turbulence161_g1 = ASPW_WindGrassTurbulence;
				float clampResult175_g1 = clamp( Global_Wind_Grass_Amplitude172_g1 , 0.0 , 1.0 );
				float temp_output_188_0_g1 = ( ( ( sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.0 ) ) ) + sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.25 ) ) ) ) * 0.5 ) * ( ( Global_Wind_Grass_Turbulence161_g1 * ( clampResult175_g1 * ( _WindGrassTurbulence * Local_Wind_Grass_Aplitude180_g1 ) ) ) * 0.1 ) );
				float3 appendResult183_g1 = (float3(temp_output_188_0_g1 , ( temp_output_188_0_g1 * 0.2 ) , temp_output_188_0_g1));
				float3 Wind_Turbulence185_g1 = appendResult183_g1;
				float3 rotatedValue56_g1 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction52_g1, ( Wind_Main_with_Waves108_g1 + Wind_Turbulence185_g1 ).x );
				float3 Output_Wind35_g1 = ( rotatedValue56_g1 - input.positionOS.xyz );
				float Wind_Mask225_g1 = input.ase_color.r;
				float3 lerpResult232_g1 = lerp( float3( 0,0,0 ) , ( Output_Wind35_g1 * Wind_Mask225_g1 ) , ASPW_WindToggle);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch192_g1 = lerpResult232_g1;
				#else
				float3 staticSwitch192_g1 = temp_cast_0;
				#endif
				
				float4 ase_positionCS = TransformObjectToHClip( ( input.positionOS ).xyz );
				float4 screenPos = ComputeScreenPos( ase_positionCS );
				output.ase_texcoord5 = screenPos;
				
				output.ase_texcoord4.xy = input.texcoord0.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord4.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch192_g1;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;

				float3 positionWS = TransformObjectToWorld( input.positionOS.xyz );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					output.positionWS = positionWS;
				#endif

				output.positionCS = MetaVertexPosition( input.positionOS, input.texcoord1.xy, input.texcoord1.xy, unity_LightmapST, unity_DynamicLightmapST );

				#ifdef EDITOR_VISUALIZATION
					float2 VizUV = 0;
					float4 LightCoord = 0;
					UnityEditorVizData(input.positionOS.xyz, input.texcoord0.xy, input.texcoord1.xy, input.texcoord2.xy, VizUV, LightCoord);
					output.VizUV = float4(VizUV, 0, 0);
					output.LightCoord = LightCoord;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = output.positionCS;
					output.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( Attributes input )
			{
				VertexControl output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				output.positionOS = input.positionOS;
				output.normalOS = input.normalOS;
				output.texcoord0 = input.texcoord0;
				output.texcoord1 = input.texcoord1;
				output.texcoord2 = input.texcoord2;
				output.ase_color = input.ase_color;
				return output;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> input)
			{
				TessellationFactors output;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				output.edge[0] = tf.x; output.edge[1] = tf.y; output.edge[2] = tf.z; output.inside = tf.w;
				return output;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
				return patch[id];
			}

			[domain("tri")]
			PackedVaryings DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				Attributes output = (Attributes) 0;
				output.positionOS = patch[0].positionOS * bary.x + patch[1].positionOS * bary.y + patch[2].positionOS * bary.z;
				output.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				output.texcoord0 = patch[0].texcoord0 * bary.x + patch[1].texcoord0 * bary.y + patch[2].texcoord0 * bary.z;
				output.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				output.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = output.positionOS.xyz - patch[i].normalOS * (dot(output.positionOS.xyz, patch[i].normalOS) - dot(patch[i].positionOS.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				output.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * output.positionOS.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], output);
				return VertexFunction(output);
			}
			#else
			PackedVaryings vert ( Attributes input )
			{
				return VertexFunction( input );
			}
			#endif

			half4 frag(PackedVaryings input  ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( input );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 WorldPosition = input.positionWS;
				#endif

				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = input.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float2 uv_BaseAlbedo280 = input.ase_texcoord4.xy;
				float4 tex2DNode280 = tex2D( _BaseAlbedo, uv_BaseAlbedo280 );
				float3 desaturateInitialColor281 = tex2DNode280.rgb;
				float desaturateDot281 = dot( desaturateInitialColor281, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar281 = lerp( desaturateInitialColor281, desaturateDot281.xxx, _BaseAlbedoDesaturation );
				float3 Albedo_Texture299 = saturate( ( desaturateVar281 * _BaseAlbedoBrightness ) );
				float3 blendOpSrc283 = Albedo_Texture299;
				float3 blendOpDest283 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo289 = (( blendOpDest283 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest283 ) * ( 1.0 - blendOpSrc283 ) ) : ( 2.0 * blendOpDest283 * blendOpSrc283 ) );
				float3 blendOpSrc345 = Albedo_Texture299;
				float3 blendOpDest345 = _TintColor.rgb;
				float2 appendResult649 = (float2(WorldPosition.x , WorldPosition.z));
				float4 tex2DNode651 = tex2D( ASP_GlobalTintNoiseTexture, ( appendResult649 * ( 0.01 * ASP_GlobalTintNoiseUVScale * _TintNoiseUVScale ) ) );
				float lerpResult676 = lerp( tex2DNode651.r , ( 1.0 - tex2DNode651.r ) , _TintNoiseInvertMask);
				float Base_Tint_Color_Mask659 = saturate( ( lerpResult676 * ( ASP_GlobalTintNoiseContrast * _TintNoiseContrast ) * input.ase_color.r ) );
				float3 lerpResult656 = lerp( Base_Albedo289 , (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) , Base_Tint_Color_Mask659);
				float3 lerpResult661 = lerp( Base_Albedo289 , lerpResult656 , ( ASP_GlobalTintNoiseToggle * _TintNoiseIntensity * ASP_GlobalTintNoiseIntensity ));
				#ifdef _ENABLETINTVARIATIONCOLOR_ON
				float3 staticSwitch403 = lerpResult661;
				#else
				float3 staticSwitch403 = Base_Albedo289;
				#endif
				float3 Base_Albedo_and_Tint_Color374 = staticSwitch403;
				float3 blendOpSrc331 = Albedo_Texture299;
				float3 blendOpDest331 = _BottomColor.rgb;
				float saferPower336 = abs( ( 1.0 - input.ase_color.a ) );
				float3 lerpResult340 = lerp( Base_Albedo_and_Tint_Color374 , (( blendOpDest331 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest331 ) * ( 1.0 - blendOpSrc331 ) ) : ( 2.0 * blendOpDest331 * blendOpSrc331 ) ) , saturate( ( _BottomColorOffset * pow( saferPower336 , _BottomColorContrast ) ) ));
				#ifdef _ENABLEBOTTOMCOLOR_ON
				float3 staticSwitch375 = lerpResult340;
				#else
				float3 staticSwitch375 = Base_Albedo_and_Tint_Color374;
				#endif
				float3 Output_Albedo342 = staticSwitch375;
				
				float Base_Opacity295 = tex2DNode280.a;
				float4 screenPos = input.ase_texcoord5;
				float4 ase_positionSSNorm = screenPos / screenPos.w;
				ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
				float4 ase_positionSS_Pixel = ASEScreenPositionNormalizedToPixel( ase_positionSSNorm );
				float dither735 = Dither4x4Bayer( fmod( ase_positionSS_Pixel.x, 4 ), fmod( ase_positionSS_Pixel.y, 4 ) );
				dither735 = step( dither735, saturate( saturate( ( ( input.ase_color.r - _BottomDitherOffset ) * ( _BottomDitherContrast * 2 ) ) ) * 1.00001 ) );
				#ifdef _ENABLEBOTTOMDITHER_ON
				float staticSwitch738 = ( dither735 * Base_Opacity295 );
				#else
				float staticSwitch738 = Base_Opacity295;
				#endif
				float Output_Opacity739 = staticSwitch738;
				

				float3 BaseColor = Output_Albedo342;
				float3 Emission = 0;
				float Alpha = Output_Opacity739;
				float AlphaClipThreshold = _BaseOpacityCutoff;

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				MetaInput metaInput = (MetaInput)0;
				metaInput.Albedo = BaseColor;
				metaInput.Emission = Emission;
				#ifdef EDITOR_VISUALIZATION
					metaInput.VizUV = input.VizUV.xy;
					metaInput.LightCoord = input.LightCoord;
				#endif

				return UnityMetaFragment(metaInput);
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "Universal2D"
			Tags { "LightMode"="Universal2D" }

			Blend One Zero, One Zero
			ZWrite On
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA

			HLSLPROGRAM

			#pragma multi_compile_fragment _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011


			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(_ASE_LIGHTING_SIMPLE)
				#define _SPECULAR_COLOR 1
			#endif

			#define SHADERPASS SHADERPASS_2D

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"

			
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
           

			
            #if ASE_SRP_VERSION >=140009
			#include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLEBOTTOMCOLOR_ON
			#pragma shader_feature_local _ENABLETINTVARIATIONCOLOR_ON
			#pragma shader_feature_local _ENABLEBOTTOMDITHER_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 positionWS : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseAlbedoColor;
			float4 _TintColor;
			float4 _BottomColor;
			float _WindGrassSpeed;
			float _BottomDitherOffset;
			float _BaseSmoothnessWaves;
			float _BaseSmoothnessIntensity;
			float _BaseNormalIntensity;
			float _BottomColorContrast;
			float _BottomColorOffset;
			float _TintNoiseIntensity;
			float _TintNoiseInvertMask;
			float _BottomDitherContrast;
			float _TintNoiseUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindGrassTurbulence;
			float _WindGrassScale;
			float _WindGrassFlexibility;
			float _WindGrassAmplitude;
			float _TintNoiseContrast;
			float _BaseOpacityCutoff;
			#ifdef ASE_TRANSMISSION
				float _TransmissionShadow;
			#endif
			#ifdef ASE_TRANSLUCENCY
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D ASPW_WindGrassWavesNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindGrassSpeed;
			half ASPW_WindGrassAmplitude;
			half ASPW_WindGrassFlexibility;
			half ASPW_WindGrassWavesAmplitude;
			half ASPW_WindGrassWavesSpeed;
			half ASPW_WindGrassWavesScale;
			half ASPW_WindGrassTurbulence;
			half ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			sampler2D ASP_GlobalTintNoiseTexture;
			half ASP_GlobalTintNoiseUVScale;
			half ASP_GlobalTintNoiseContrast;
			half ASP_GlobalTintNoiseToggle;
			half ASP_GlobalTintNoiseIntensity;


			float3 ASESafeNormalize(float3 inVec)
			{
				float dp3 = max(1.175494351e-38, dot(inVec, inVec));
				return inVec* rsqrt(dp3);
			}
			
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 ASEScreenPositionNormalizedToPixel( float4 screenPosNorm )
			{
				float4 screenPosPixel = screenPosNorm * float4( _ScreenParams.xy, 1, 1 );
				#if UNITY_UV_STARTS_AT_TOP
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x < 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#else
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x > 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#endif
				return screenPosPixel;
			}
			
			inline float Dither4x4Bayer( int x, int y )
			{
				const float dither[ 16 ] = {
				     1,  9,  3, 11,
				    13,  5, 15,  7,
				     4, 12,  2, 10,
				    16,  8, 14,  6 };
				int r = y * 4 + x;
				return dither[ r ] / 16; // same # of instructions as pre-dividing due to compiler magic
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID( input );
				UNITY_TRANSFER_INSTANCE_ID( input, output );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( output );

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 worldToObjDir40_g1 = mul( GetWorldToObjectMatrix(), float4( normalizeResult41_g1, 0.0 ) ).xyz;
				float3 Wind_Direction_Leaf50_g1 = worldToObjDir40_g1;
				float3 break42_g1 = Wind_Direction_Leaf50_g1;
				float3 appendResult43_g1 = (float3(break42_g1.z , 0.0 , ( break42_g1.x * -1.0 )));
				float3 Wind_Direction52_g1 = appendResult43_g1;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Grass_Randomization65_g1 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_5_0_g1 = ( Wind_Grass_Randomization65_g1 + _TimeParameters.x );
				float Global_Wind_Grass_Speed144_g1 = ASPW_WindGrassSpeed;
				float temp_output_9_0_g1 = ( _WindGrassSpeed * Global_Wind_Grass_Speed144_g1 * 10.0 );
				float Local_Wind_Grass_Aplitude180_g1 = _WindGrassAmplitude;
				float Global_Wind_Grass_Amplitude172_g1 = ASPW_WindGrassAmplitude;
				float temp_output_27_0_g1 = ( Local_Wind_Grass_Aplitude180_g1 * Global_Wind_Grass_Amplitude172_g1 );
				float Global_Wind_Grass_Flexibility164_g1 = ASPW_WindGrassFlexibility;
				float Wind_Main31_g1 = ( ( ( ( ( sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.0 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.25 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.5 ) ) ) ) + temp_output_27_0_g1 ) * temp_output_27_0_g1 ) / 50.0 ) * ( ( Global_Wind_Grass_Flexibility164_g1 * _WindGrassFlexibility ) * 0.1 ) );
				float Global_Wind_Grass_Waves_Amplitude162_g1 = ASPW_WindGrassWavesAmplitude;
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 appendResult73_g1 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2Dlod( ASPW_WindGrassWavesNoiseTexture, float4( ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).r;
				float lerpResult96_g1 = lerp( Wind_Main31_g1 , ( Wind_Main31_g1 * Global_Wind_Grass_Waves_Amplitude162_g1 ) , Wind_Waves93_g1);
				float Wind_Main_with_Waves108_g1 = lerpResult96_g1;
				float temp_output_141_0_g1 = ( ( ase_positionWS.y * ( _WindGrassScale * 10.0 ) ) + _TimeParameters.x );
				float Local_Wind_Grass_Speed186_g1 = _WindGrassSpeed;
				float temp_output_146_0_g1 = ( Global_Wind_Grass_Speed144_g1 * Local_Wind_Grass_Speed186_g1 * 10.0 );
				float Global_Wind_Grass_Turbulence161_g1 = ASPW_WindGrassTurbulence;
				float clampResult175_g1 = clamp( Global_Wind_Grass_Amplitude172_g1 , 0.0 , 1.0 );
				float temp_output_188_0_g1 = ( ( ( sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.0 ) ) ) + sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.25 ) ) ) ) * 0.5 ) * ( ( Global_Wind_Grass_Turbulence161_g1 * ( clampResult175_g1 * ( _WindGrassTurbulence * Local_Wind_Grass_Aplitude180_g1 ) ) ) * 0.1 ) );
				float3 appendResult183_g1 = (float3(temp_output_188_0_g1 , ( temp_output_188_0_g1 * 0.2 ) , temp_output_188_0_g1));
				float3 Wind_Turbulence185_g1 = appendResult183_g1;
				float3 rotatedValue56_g1 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction52_g1, ( Wind_Main_with_Waves108_g1 + Wind_Turbulence185_g1 ).x );
				float3 Output_Wind35_g1 = ( rotatedValue56_g1 - input.positionOS.xyz );
				float Wind_Mask225_g1 = input.ase_color.r;
				float3 lerpResult232_g1 = lerp( float3( 0,0,0 ) , ( Output_Wind35_g1 * Wind_Mask225_g1 ) , ASPW_WindToggle);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch192_g1 = lerpResult232_g1;
				#else
				float3 staticSwitch192_g1 = temp_cast_0;
				#endif
				
				float4 ase_positionCS = TransformObjectToHClip( ( input.positionOS ).xyz );
				float4 screenPos = ComputeScreenPos( ase_positionCS );
				output.ase_texcoord3 = screenPos;
				
				output.ase_texcoord2.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord2.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch192_g1;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					output.positionWS = vertexInput.positionWS;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					output.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				output.positionCS = vertexInput.positionCS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( Attributes input )
			{
				VertexControl output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				output.positionOS = input.positionOS;
				output.normalOS = input.normalOS;
				output.ase_color = input.ase_color;
				output.ase_texcoord = input.ase_texcoord;
				return output;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> input)
			{
				TessellationFactors output;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				output.edge[0] = tf.x; output.edge[1] = tf.y; output.edge[2] = tf.z; output.inside = tf.w;
				return output;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
				return patch[id];
			}

			[domain("tri")]
			PackedVaryings DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				Attributes output = (Attributes) 0;
				output.positionOS = patch[0].positionOS * bary.x + patch[1].positionOS * bary.y + patch[2].positionOS * bary.z;
				output.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = output.positionOS.xyz - patch[i].normalOS * (dot(output.positionOS.xyz, patch[i].normalOS) - dot(patch[i].positionOS.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				output.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * output.positionOS.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], output);
				return VertexFunction(output);
			}
			#else
			PackedVaryings vert ( Attributes input )
			{
				return VertexFunction( input );
			}
			#endif

			half4 frag(PackedVaryings input  ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( input );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( input );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 WorldPosition = input.positionWS;
				#endif

				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = input.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float2 uv_BaseAlbedo280 = input.ase_texcoord2.xy;
				float4 tex2DNode280 = tex2D( _BaseAlbedo, uv_BaseAlbedo280 );
				float3 desaturateInitialColor281 = tex2DNode280.rgb;
				float desaturateDot281 = dot( desaturateInitialColor281, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar281 = lerp( desaturateInitialColor281, desaturateDot281.xxx, _BaseAlbedoDesaturation );
				float3 Albedo_Texture299 = saturate( ( desaturateVar281 * _BaseAlbedoBrightness ) );
				float3 blendOpSrc283 = Albedo_Texture299;
				float3 blendOpDest283 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo289 = (( blendOpDest283 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest283 ) * ( 1.0 - blendOpSrc283 ) ) : ( 2.0 * blendOpDest283 * blendOpSrc283 ) );
				float3 blendOpSrc345 = Albedo_Texture299;
				float3 blendOpDest345 = _TintColor.rgb;
				float2 appendResult649 = (float2(WorldPosition.x , WorldPosition.z));
				float4 tex2DNode651 = tex2D( ASP_GlobalTintNoiseTexture, ( appendResult649 * ( 0.01 * ASP_GlobalTintNoiseUVScale * _TintNoiseUVScale ) ) );
				float lerpResult676 = lerp( tex2DNode651.r , ( 1.0 - tex2DNode651.r ) , _TintNoiseInvertMask);
				float Base_Tint_Color_Mask659 = saturate( ( lerpResult676 * ( ASP_GlobalTintNoiseContrast * _TintNoiseContrast ) * input.ase_color.r ) );
				float3 lerpResult656 = lerp( Base_Albedo289 , (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) , Base_Tint_Color_Mask659);
				float3 lerpResult661 = lerp( Base_Albedo289 , lerpResult656 , ( ASP_GlobalTintNoiseToggle * _TintNoiseIntensity * ASP_GlobalTintNoiseIntensity ));
				#ifdef _ENABLETINTVARIATIONCOLOR_ON
				float3 staticSwitch403 = lerpResult661;
				#else
				float3 staticSwitch403 = Base_Albedo289;
				#endif
				float3 Base_Albedo_and_Tint_Color374 = staticSwitch403;
				float3 blendOpSrc331 = Albedo_Texture299;
				float3 blendOpDest331 = _BottomColor.rgb;
				float saferPower336 = abs( ( 1.0 - input.ase_color.a ) );
				float3 lerpResult340 = lerp( Base_Albedo_and_Tint_Color374 , (( blendOpDest331 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest331 ) * ( 1.0 - blendOpSrc331 ) ) : ( 2.0 * blendOpDest331 * blendOpSrc331 ) ) , saturate( ( _BottomColorOffset * pow( saferPower336 , _BottomColorContrast ) ) ));
				#ifdef _ENABLEBOTTOMCOLOR_ON
				float3 staticSwitch375 = lerpResult340;
				#else
				float3 staticSwitch375 = Base_Albedo_and_Tint_Color374;
				#endif
				float3 Output_Albedo342 = staticSwitch375;
				
				float Base_Opacity295 = tex2DNode280.a;
				float4 screenPos = input.ase_texcoord3;
				float4 ase_positionSSNorm = screenPos / screenPos.w;
				ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
				float4 ase_positionSS_Pixel = ASEScreenPositionNormalizedToPixel( ase_positionSSNorm );
				float dither735 = Dither4x4Bayer( fmod( ase_positionSS_Pixel.x, 4 ), fmod( ase_positionSS_Pixel.y, 4 ) );
				dither735 = step( dither735, saturate( saturate( ( ( input.ase_color.r - _BottomDitherOffset ) * ( _BottomDitherContrast * 2 ) ) ) * 1.00001 ) );
				#ifdef _ENABLEBOTTOMDITHER_ON
				float staticSwitch738 = ( dither735 * Base_Opacity295 );
				#else
				float staticSwitch738 = Base_Opacity295;
				#endif
				float Output_Opacity739 = staticSwitch738;
				

				float3 BaseColor = Output_Albedo342;
				float Alpha = Output_Opacity739;
				float AlphaClipThreshold = _BaseOpacityCutoff;

				half4 color = half4(BaseColor, Alpha );

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				return color;
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "DepthNormals"
			Tags { "LightMode"="DepthNormals" }

			ZWrite On
			Blend One Zero
			ZTest LEqual
			ZWrite On

			HLSLPROGRAM

			

			

			#pragma multi_compile _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011


			

			

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(_ASE_LIGHTING_SIMPLE)
				#define _SPECULAR_COLOR 1
			#endif

			#define SHADERPASS SHADERPASS_DEPTHNORMALSONLY
			//#define SHADERPASS SHADERPASS_DEPTHNORMALS

			
            #if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#endif
		

			
			#if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"

			
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
           

			
            #if ASE_SRP_VERSION >=140009
			#include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLEBOTTOMDITHER_ON


			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE) && (SHADER_TARGET >= 45)
				#define ASE_SV_DEPTH SV_DepthLessEqual
				#define ASE_SV_POSITION_QUALIFIERS linear noperspective centroid
			#else
				#define ASE_SV_DEPTH SV_Depth
				#define ASE_SV_POSITION_QUALIFIERS
			#endif

			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				float3 positionWS : TEXCOORD1;
				float3 normalWS : TEXCOORD2;
				float4 tangentWS : TEXCOORD3;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD4;
				#endif
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseAlbedoColor;
			float4 _TintColor;
			float4 _BottomColor;
			float _WindGrassSpeed;
			float _BottomDitherOffset;
			float _BaseSmoothnessWaves;
			float _BaseSmoothnessIntensity;
			float _BaseNormalIntensity;
			float _BottomColorContrast;
			float _BottomColorOffset;
			float _TintNoiseIntensity;
			float _TintNoiseInvertMask;
			float _BottomDitherContrast;
			float _TintNoiseUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindGrassTurbulence;
			float _WindGrassScale;
			float _WindGrassFlexibility;
			float _WindGrassAmplitude;
			float _TintNoiseContrast;
			float _BaseOpacityCutoff;
			#ifdef ASE_TRANSMISSION
				float _TransmissionShadow;
			#endif
			#ifdef ASE_TRANSLUCENCY
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D ASPW_WindGrassWavesNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindGrassSpeed;
			half ASPW_WindGrassAmplitude;
			half ASPW_WindGrassFlexibility;
			half ASPW_WindGrassWavesAmplitude;
			half ASPW_WindGrassWavesSpeed;
			half ASPW_WindGrassWavesScale;
			half ASPW_WindGrassTurbulence;
			half ASPW_WindToggle;
			sampler2D _BaseNormal;
			sampler2D _BaseAlbedo;


			float3 ASESafeNormalize(float3 inVec)
			{
				float dp3 = max(1.175494351e-38, dot(inVec, inVec));
				return inVec* rsqrt(dp3);
			}
			
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 ASEScreenPositionNormalizedToPixel( float4 screenPosNorm )
			{
				float4 screenPosPixel = screenPosNorm * float4( _ScreenParams.xy, 1, 1 );
				#if UNITY_UV_STARTS_AT_TOP
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x < 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#else
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x > 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#endif
				return screenPosPixel;
			}
			
			inline float Dither4x4Bayer( int x, int y )
			{
				const float dither[ 16 ] = {
				     1,  9,  3, 11,
				    13,  5, 15,  7,
				     4, 12,  2, 10,
				    16,  8, 14,  6 };
				int r = y * 4 + x;
				return dither[ r ] / 16; // same # of instructions as pre-dividing due to compiler magic
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 worldToObjDir40_g1 = mul( GetWorldToObjectMatrix(), float4( normalizeResult41_g1, 0.0 ) ).xyz;
				float3 Wind_Direction_Leaf50_g1 = worldToObjDir40_g1;
				float3 break42_g1 = Wind_Direction_Leaf50_g1;
				float3 appendResult43_g1 = (float3(break42_g1.z , 0.0 , ( break42_g1.x * -1.0 )));
				float3 Wind_Direction52_g1 = appendResult43_g1;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Grass_Randomization65_g1 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_5_0_g1 = ( Wind_Grass_Randomization65_g1 + _TimeParameters.x );
				float Global_Wind_Grass_Speed144_g1 = ASPW_WindGrassSpeed;
				float temp_output_9_0_g1 = ( _WindGrassSpeed * Global_Wind_Grass_Speed144_g1 * 10.0 );
				float Local_Wind_Grass_Aplitude180_g1 = _WindGrassAmplitude;
				float Global_Wind_Grass_Amplitude172_g1 = ASPW_WindGrassAmplitude;
				float temp_output_27_0_g1 = ( Local_Wind_Grass_Aplitude180_g1 * Global_Wind_Grass_Amplitude172_g1 );
				float Global_Wind_Grass_Flexibility164_g1 = ASPW_WindGrassFlexibility;
				float Wind_Main31_g1 = ( ( ( ( ( sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.0 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.25 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.5 ) ) ) ) + temp_output_27_0_g1 ) * temp_output_27_0_g1 ) / 50.0 ) * ( ( Global_Wind_Grass_Flexibility164_g1 * _WindGrassFlexibility ) * 0.1 ) );
				float Global_Wind_Grass_Waves_Amplitude162_g1 = ASPW_WindGrassWavesAmplitude;
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 appendResult73_g1 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2Dlod( ASPW_WindGrassWavesNoiseTexture, float4( ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).r;
				float lerpResult96_g1 = lerp( Wind_Main31_g1 , ( Wind_Main31_g1 * Global_Wind_Grass_Waves_Amplitude162_g1 ) , Wind_Waves93_g1);
				float Wind_Main_with_Waves108_g1 = lerpResult96_g1;
				float temp_output_141_0_g1 = ( ( ase_positionWS.y * ( _WindGrassScale * 10.0 ) ) + _TimeParameters.x );
				float Local_Wind_Grass_Speed186_g1 = _WindGrassSpeed;
				float temp_output_146_0_g1 = ( Global_Wind_Grass_Speed144_g1 * Local_Wind_Grass_Speed186_g1 * 10.0 );
				float Global_Wind_Grass_Turbulence161_g1 = ASPW_WindGrassTurbulence;
				float clampResult175_g1 = clamp( Global_Wind_Grass_Amplitude172_g1 , 0.0 , 1.0 );
				float temp_output_188_0_g1 = ( ( ( sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.0 ) ) ) + sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.25 ) ) ) ) * 0.5 ) * ( ( Global_Wind_Grass_Turbulence161_g1 * ( clampResult175_g1 * ( _WindGrassTurbulence * Local_Wind_Grass_Aplitude180_g1 ) ) ) * 0.1 ) );
				float3 appendResult183_g1 = (float3(temp_output_188_0_g1 , ( temp_output_188_0_g1 * 0.2 ) , temp_output_188_0_g1));
				float3 Wind_Turbulence185_g1 = appendResult183_g1;
				float3 rotatedValue56_g1 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction52_g1, ( Wind_Main_with_Waves108_g1 + Wind_Turbulence185_g1 ).x );
				float3 Output_Wind35_g1 = ( rotatedValue56_g1 - input.positionOS.xyz );
				float Wind_Mask225_g1 = input.ase_color.r;
				float3 lerpResult232_g1 = lerp( float3( 0,0,0 ) , ( Output_Wind35_g1 * Wind_Mask225_g1 ) , ASPW_WindToggle);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch192_g1 = lerpResult232_g1;
				#else
				float3 staticSwitch192_g1 = temp_cast_0;
				#endif
				
				output.ase_texcoord5.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord5.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch192_g1;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;
				input.tangentOS = input.tangentOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );

				float3 normalWS = TransformObjectToWorldNormal( input.normalOS );
				float4 tangentWS = float4( TransformObjectToWorldDir( input.tangentOS.xyz ), input.tangentOS.w );

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					output.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				output.positionCS = vertexInput.positionCS;
				output.clipPosV = vertexInput.positionCS;
				output.positionWS = vertexInput.positionWS;
				output.normalWS = normalWS;
				output.tangentWS = tangentWS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( Attributes input )
			{
				VertexControl output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				output.positionOS = input.positionOS;
				output.normalOS = input.normalOS;
				output.tangentOS = input.tangentOS;
				output.ase_color = input.ase_color;
				output.ase_texcoord = input.ase_texcoord;
				return output;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> input)
			{
				TessellationFactors output;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				output.edge[0] = tf.x; output.edge[1] = tf.y; output.edge[2] = tf.z; output.inside = tf.w;
				return output;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
				return patch[id];
			}

			[domain("tri")]
			PackedVaryings DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				Attributes output = (Attributes) 0;
				output.positionOS = patch[0].positionOS * bary.x + patch[1].positionOS * bary.y + patch[2].positionOS * bary.z;
				output.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				output.tangentOS = patch[0].tangentOS * bary.x + patch[1].tangentOS * bary.y + patch[2].tangentOS * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = output.positionOS.xyz - patch[i].normalOS * (dot(output.positionOS.xyz, patch[i].normalOS) - dot(patch[i].positionOS.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				output.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * output.positionOS.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], output);
				return VertexFunction(output);
			}
			#else
			PackedVaryings vert ( Attributes input )
			{
				return VertexFunction( input );
			}
			#endif

			void frag(	PackedVaryings input
						, out half4 outNormalWS : SV_Target0
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						#ifdef _WRITE_RENDERING_LAYERS
						, out float4 outRenderingLayers : SV_Target1
						#endif
						 )
			{
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( input );

				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				float3 WorldNormal = input.normalWS;
				float4 WorldTangent = input.tangentWS;
				float3 WorldPosition = input.positionWS;
				float4 ClipPos = input.clipPosV;
				float4 ScreenPos = ComputeScreenPos( input.clipPosV );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = input.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float2 uv_BaseNormal318 = input.ase_texcoord5.xy;
				float3 unpack318 = UnpackNormalScale( tex2D( _BaseNormal, uv_BaseNormal318 ), _BaseNormalIntensity );
				unpack318.z = lerp( 1, unpack318.z, saturate(_BaseNormalIntensity) );
				float3 Base_Normal642 = unpack318;
				
				float2 uv_BaseAlbedo280 = input.ase_texcoord5.xy;
				float4 tex2DNode280 = tex2D( _BaseAlbedo, uv_BaseAlbedo280 );
				float Base_Opacity295 = tex2DNode280.a;
				float4 ase_positionSSNorm = ScreenPos / ScreenPos.w;
				ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
				float4 ase_positionSS_Pixel = ASEScreenPositionNormalizedToPixel( ase_positionSSNorm );
				float dither735 = Dither4x4Bayer( fmod( ase_positionSS_Pixel.x, 4 ), fmod( ase_positionSS_Pixel.y, 4 ) );
				dither735 = step( dither735, saturate( saturate( ( ( input.ase_color.r - _BottomDitherOffset ) * ( _BottomDitherContrast * 2 ) ) ) * 1.00001 ) );
				#ifdef _ENABLEBOTTOMDITHER_ON
				float staticSwitch738 = ( dither735 * Base_Opacity295 );
				#else
				float staticSwitch738 = Base_Opacity295;
				#endif
				float Output_Opacity739 = staticSwitch738;
				

				float3 Normal = Base_Normal642;
				float Alpha = Output_Opacity739;
				float AlphaClipThreshold = _BaseOpacityCutoff;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = input.positionCS.z;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( input.positionCS );
				#endif

				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
				#endif

				#if defined(_GBUFFER_NORMALS_OCT)
					float2 octNormalWS = PackNormalOctQuadEncode(WorldNormal);
					float2 remappedOctNormalWS = saturate(octNormalWS * 0.5 + 0.5);
					half3 packedNormalWS = PackFloat2To888(remappedOctNormalWS);
					outNormalWS = half4(packedNormalWS, 0.0);
				#else
					#if defined(_NORMALMAP)
						#if _NORMAL_DROPOFF_TS
							float crossSign = (WorldTangent.w > 0.0 ? 1.0 : -1.0) * GetOddNegativeScale();
							float3 bitangent = crossSign * cross(WorldNormal.xyz, WorldTangent.xyz);
							float3 normalWS = TransformTangentToWorld(Normal, half3x3(WorldTangent.xyz, bitangent, WorldNormal.xyz));
						#elif _NORMAL_DROPOFF_OS
							float3 normalWS = TransformObjectToWorldNormal(Normal);
						#elif _NORMAL_DROPOFF_WS
							float3 normalWS = Normal;
						#endif
					#else
						float3 normalWS = WorldNormal;
					#endif
					outNormalWS = half4(NormalizeNormalPerPixel(normalWS), 0.0);
				#endif

				#ifdef _WRITE_RENDERING_LAYERS
					uint renderingLayers = GetMeshRenderingLayer();
					outRenderingLayers = float4(EncodeMeshRenderingLayer(renderingLayers), 0, 0, 0);
				#endif
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "GBuffer"
			Tags { "LightMode"="UniversalGBuffer" }

			Blend One Zero, One Zero
			ZWrite On
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA
			

			HLSLPROGRAM

			

			#pragma multi_compile_fragment _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma shader_feature_local _RECEIVE_SHADOWS_OFF
			#pragma multi_compile_instancing
			#pragma instancing_options renderinglayer
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011


			

			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BLENDING
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BOX_PROJECTION

			

			
			#pragma multi_compile_fragment _ _SHADOWS_SOFT _SHADOWS_SOFT_LOW _SHADOWS_SOFT_MEDIUM _SHADOWS_SOFT_HIGH
           

			#pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
			#pragma multi_compile_fragment _ _GBUFFER_NORMALS_OCT
			#pragma multi_compile_fragment _ _RENDER_PASS_ENABLED

			

			#pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
			#pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
			#pragma multi_compile _ SHADOWS_SHADOWMASK
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON
			#pragma multi_compile _ DYNAMICLIGHTMAP_ON

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(_ASE_LIGHTING_SIMPLE)
				#define _SPECULAR_COLOR 1
			#endif

			#define SHADERPASS SHADERPASS_GBUFFER

			
            #if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#endif
		

			
			#if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"

			
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
           

			
            #if ASE_SRP_VERSION >=140009
			#include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DBuffer.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#if defined(UNITY_INSTANCING_ENABLED) && defined(_TERRAIN_INSTANCED_PERPIXEL_NORMAL)
				#define ENABLE_TERRAIN_PERPIXEL_NORMAL
			#endif

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLEBOTTOMCOLOR_ON
			#pragma shader_feature_local _ENABLETINTVARIATIONCOLOR_ON
			#pragma shader_feature_local _ENABLESMOOTHNESSWAVES_ON
			#pragma shader_feature_local _ENABLEBOTTOMDITHER_ON


			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE) && (SHADER_TARGET >= 45)
				#define ASE_SV_DEPTH SV_DepthLessEqual
				#define ASE_SV_POSITION_QUALIFIERS linear noperspective centroid
			#else
				#define ASE_SV_DEPTH SV_Depth
				#define ASE_SV_POSITION_QUALIFIERS
			#endif

			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				float4 lightmapUVOrVertexSH : TEXCOORD1;
				#if defined(ASE_FOG) || defined(_ADDITIONAL_LIGHTS_VERTEX)
					half4 fogFactorAndVertexLight : TEXCOORD2;
				#endif
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				float4 shadowCoord : TEXCOORD6;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON)
				float2 dynamicLightmapUV : TEXCOORD7;
				#endif
				float4 ase_texcoord8 : TEXCOORD8;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseAlbedoColor;
			float4 _TintColor;
			float4 _BottomColor;
			float _WindGrassSpeed;
			float _BottomDitherOffset;
			float _BaseSmoothnessWaves;
			float _BaseSmoothnessIntensity;
			float _BaseNormalIntensity;
			float _BottomColorContrast;
			float _BottomColorOffset;
			float _TintNoiseIntensity;
			float _TintNoiseInvertMask;
			float _BottomDitherContrast;
			float _TintNoiseUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindGrassTurbulence;
			float _WindGrassScale;
			float _WindGrassFlexibility;
			float _WindGrassAmplitude;
			float _TintNoiseContrast;
			float _BaseOpacityCutoff;
			#ifdef ASE_TRANSMISSION
				float _TransmissionShadow;
			#endif
			#ifdef ASE_TRANSLUCENCY
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D ASPW_WindGrassWavesNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindGrassSpeed;
			half ASPW_WindGrassAmplitude;
			half ASPW_WindGrassFlexibility;
			half ASPW_WindGrassWavesAmplitude;
			half ASPW_WindGrassWavesSpeed;
			half ASPW_WindGrassWavesScale;
			half ASPW_WindGrassTurbulence;
			half ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			sampler2D ASP_GlobalTintNoiseTexture;
			half ASP_GlobalTintNoiseUVScale;
			half ASP_GlobalTintNoiseContrast;
			half ASP_GlobalTintNoiseToggle;
			half ASP_GlobalTintNoiseIntensity;
			sampler2D _BaseNormal;


			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityGBuffer.hlsl"

			float3 ASESafeNormalize(float3 inVec)
			{
				float dp3 = max(1.175494351e-38, dot(inVec, inVec));
				return inVec* rsqrt(dp3);
			}
			
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 ASEScreenPositionNormalizedToPixel( float4 screenPosNorm )
			{
				float4 screenPosPixel = screenPosNorm * float4( _ScreenParams.xy, 1, 1 );
				#if UNITY_UV_STARTS_AT_TOP
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x < 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#else
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x > 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#endif
				return screenPosPixel;
			}
			
			inline float Dither4x4Bayer( int x, int y )
			{
				const float dither[ 16 ] = {
				     1,  9,  3, 11,
				    13,  5, 15,  7,
				     4, 12,  2, 10,
				    16,  8, 14,  6 };
				int r = y * 4 + x;
				return dither[ r ] / 16; // same # of instructions as pre-dividing due to compiler magic
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 worldToObjDir40_g1 = mul( GetWorldToObjectMatrix(), float4( normalizeResult41_g1, 0.0 ) ).xyz;
				float3 Wind_Direction_Leaf50_g1 = worldToObjDir40_g1;
				float3 break42_g1 = Wind_Direction_Leaf50_g1;
				float3 appendResult43_g1 = (float3(break42_g1.z , 0.0 , ( break42_g1.x * -1.0 )));
				float3 Wind_Direction52_g1 = appendResult43_g1;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Grass_Randomization65_g1 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_5_0_g1 = ( Wind_Grass_Randomization65_g1 + _TimeParameters.x );
				float Global_Wind_Grass_Speed144_g1 = ASPW_WindGrassSpeed;
				float temp_output_9_0_g1 = ( _WindGrassSpeed * Global_Wind_Grass_Speed144_g1 * 10.0 );
				float Local_Wind_Grass_Aplitude180_g1 = _WindGrassAmplitude;
				float Global_Wind_Grass_Amplitude172_g1 = ASPW_WindGrassAmplitude;
				float temp_output_27_0_g1 = ( Local_Wind_Grass_Aplitude180_g1 * Global_Wind_Grass_Amplitude172_g1 );
				float Global_Wind_Grass_Flexibility164_g1 = ASPW_WindGrassFlexibility;
				float Wind_Main31_g1 = ( ( ( ( ( sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.0 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.25 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.5 ) ) ) ) + temp_output_27_0_g1 ) * temp_output_27_0_g1 ) / 50.0 ) * ( ( Global_Wind_Grass_Flexibility164_g1 * _WindGrassFlexibility ) * 0.1 ) );
				float Global_Wind_Grass_Waves_Amplitude162_g1 = ASPW_WindGrassWavesAmplitude;
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 appendResult73_g1 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2Dlod( ASPW_WindGrassWavesNoiseTexture, float4( ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).r;
				float lerpResult96_g1 = lerp( Wind_Main31_g1 , ( Wind_Main31_g1 * Global_Wind_Grass_Waves_Amplitude162_g1 ) , Wind_Waves93_g1);
				float Wind_Main_with_Waves108_g1 = lerpResult96_g1;
				float temp_output_141_0_g1 = ( ( ase_positionWS.y * ( _WindGrassScale * 10.0 ) ) + _TimeParameters.x );
				float Local_Wind_Grass_Speed186_g1 = _WindGrassSpeed;
				float temp_output_146_0_g1 = ( Global_Wind_Grass_Speed144_g1 * Local_Wind_Grass_Speed186_g1 * 10.0 );
				float Global_Wind_Grass_Turbulence161_g1 = ASPW_WindGrassTurbulence;
				float clampResult175_g1 = clamp( Global_Wind_Grass_Amplitude172_g1 , 0.0 , 1.0 );
				float temp_output_188_0_g1 = ( ( ( sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.0 ) ) ) + sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.25 ) ) ) ) * 0.5 ) * ( ( Global_Wind_Grass_Turbulence161_g1 * ( clampResult175_g1 * ( _WindGrassTurbulence * Local_Wind_Grass_Aplitude180_g1 ) ) ) * 0.1 ) );
				float3 appendResult183_g1 = (float3(temp_output_188_0_g1 , ( temp_output_188_0_g1 * 0.2 ) , temp_output_188_0_g1));
				float3 Wind_Turbulence185_g1 = appendResult183_g1;
				float3 rotatedValue56_g1 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction52_g1, ( Wind_Main_with_Waves108_g1 + Wind_Turbulence185_g1 ).x );
				float3 Output_Wind35_g1 = ( rotatedValue56_g1 - input.positionOS.xyz );
				float Wind_Mask225_g1 = input.ase_color.r;
				float3 lerpResult232_g1 = lerp( float3( 0,0,0 ) , ( Output_Wind35_g1 * Wind_Mask225_g1 ) , ASPW_WindToggle);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch192_g1 = lerpResult232_g1;
				#else
				float3 staticSwitch192_g1 = temp_cast_0;
				#endif
				
				output.ase_texcoord8.xy = input.texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord8.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch192_g1;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;
				input.tangentOS = input.tangentOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );
				VertexNormalInputs normalInput = GetVertexNormalInputs( input.normalOS, input.tangentOS );

				output.tSpace0 = float4( normalInput.normalWS, vertexInput.positionWS.x);
				output.tSpace1 = float4( normalInput.tangentWS, vertexInput.positionWS.y);
				output.tSpace2 = float4( normalInput.bitangentWS, vertexInput.positionWS.z);

				#if defined(LIGHTMAP_ON)
					OUTPUT_LIGHTMAP_UV(input.texcoord1, unity_LightmapST, output.lightmapUVOrVertexSH.xy);
				#endif

				#if defined(DYNAMICLIGHTMAP_ON)
					output.dynamicLightmapUV.xy = input.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
				#endif

				#if !defined(LIGHTMAP_ON)
					OUTPUT_SH(normalInput.normalWS.xyz, output.lightmapUVOrVertexSH.xyz);
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					output.lightmapUVOrVertexSH.zw = input.texcoord.xy;
					output.lightmapUVOrVertexSH.xy = input.texcoord.xy * unity_LightmapST.xy + unity_LightmapST.zw;
				#endif

				#if defined(ASE_FOG) || defined(_ADDITIONAL_LIGHTS_VERTEX)
					output.fogFactorAndVertexLight = 0;
					#if defined(ASE_FOG) && !defined(_FOG_FRAGMENT)
						// @diogo: no fog applied in GBuffer
					#endif
					#ifdef _ADDITIONAL_LIGHTS_VERTEX
						half3 vertexLight = VertexLighting( vertexInput.positionWS, normalInput.normalWS );
						output.fogFactorAndVertexLight.yzw = vertexLight;
					#endif
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					output.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				output.positionCS = vertexInput.positionCS;
				output.clipPosV = vertexInput.positionCS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( Attributes input )
			{
				VertexControl output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				output.positionOS = input.positionOS;
				output.normalOS = input.normalOS;
				output.tangentOS = input.tangentOS;
				output.texcoord = input.texcoord;
				output.texcoord1 = input.texcoord1;
				output.texcoord2 = input.texcoord2;
				output.ase_color = input.ase_color;
				return output;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> input)
			{
				TessellationFactors output;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				output.edge[0] = tf.x; output.edge[1] = tf.y; output.edge[2] = tf.z; output.inside = tf.w;
				return output;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
				return patch[id];
			}

			[domain("tri")]
			PackedVaryings DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				Attributes output = (Attributes) 0;
				output.positionOS = patch[0].positionOS * bary.x + patch[1].positionOS * bary.y + patch[2].positionOS * bary.z;
				output.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				output.tangentOS = patch[0].tangentOS * bary.x + patch[1].tangentOS * bary.y + patch[2].tangentOS * bary.z;
				output.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				output.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				output.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = output.positionOS.xyz - patch[i].normalOS * (dot(output.positionOS.xyz, patch[i].normalOS) - dot(patch[i].positionOS.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				output.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * output.positionOS.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], output);
				return VertexFunction(output);
			}
			#else
			PackedVaryings vert ( Attributes input )
			{
				return VertexFunction( input );
			}
			#endif

			FragmentOutput frag ( PackedVaryings input
								#ifdef ASE_DEPTH_WRITE_ON
								,out float outputDepth : ASE_SV_DEPTH
								#endif
								 )
			{
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( input.positionCS );
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float2 sampleCoords = (input.lightmapUVOrVertexSH.zw / _TerrainHeightmapRecipSize.zw + 0.5f) * _TerrainHeightmapRecipSize.xy;
					float3 WorldNormal = TransformObjectToWorldNormal(normalize(SAMPLE_TEXTURE2D(_TerrainNormalmapTexture, sampler_TerrainNormalmapTexture, sampleCoords).rgb * 2 - 1));
					float3 WorldTangent = -cross(GetObjectToWorldMatrix()._13_23_33, WorldNormal);
					float3 WorldBiTangent = cross(WorldNormal, -WorldTangent);
				#else
					float3 WorldNormal = normalize( input.tSpace0.xyz );
					float3 WorldTangent = input.tSpace1.xyz;
					float3 WorldBiTangent = input.tSpace2.xyz;
				#endif

				float3 WorldPosition = float3(input.tSpace0.w,input.tSpace1.w,input.tSpace2.w);
				float3 WorldViewDirection = GetWorldSpaceNormalizeViewDir( WorldPosition );
				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				float4 ClipPos = input.clipPosV;
				float4 ScreenPos = ComputeScreenPos( input.clipPosV );

				float2 NormalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(input.positionCS);

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					ShadowCoords = input.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
				#else
					ShadowCoords = float4(0, 0, 0, 0);
				#endif

				float2 uv_BaseAlbedo280 = input.ase_texcoord8.xy;
				float4 tex2DNode280 = tex2D( _BaseAlbedo, uv_BaseAlbedo280 );
				float3 desaturateInitialColor281 = tex2DNode280.rgb;
				float desaturateDot281 = dot( desaturateInitialColor281, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar281 = lerp( desaturateInitialColor281, desaturateDot281.xxx, _BaseAlbedoDesaturation );
				float3 Albedo_Texture299 = saturate( ( desaturateVar281 * _BaseAlbedoBrightness ) );
				float3 blendOpSrc283 = Albedo_Texture299;
				float3 blendOpDest283 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo289 = (( blendOpDest283 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest283 ) * ( 1.0 - blendOpSrc283 ) ) : ( 2.0 * blendOpDest283 * blendOpSrc283 ) );
				float3 blendOpSrc345 = Albedo_Texture299;
				float3 blendOpDest345 = _TintColor.rgb;
				float2 appendResult649 = (float2(WorldPosition.x , WorldPosition.z));
				float4 tex2DNode651 = tex2D( ASP_GlobalTintNoiseTexture, ( appendResult649 * ( 0.01 * ASP_GlobalTintNoiseUVScale * _TintNoiseUVScale ) ) );
				float lerpResult676 = lerp( tex2DNode651.r , ( 1.0 - tex2DNode651.r ) , _TintNoiseInvertMask);
				float Base_Tint_Color_Mask659 = saturate( ( lerpResult676 * ( ASP_GlobalTintNoiseContrast * _TintNoiseContrast ) * input.ase_color.r ) );
				float3 lerpResult656 = lerp( Base_Albedo289 , (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) , Base_Tint_Color_Mask659);
				float3 lerpResult661 = lerp( Base_Albedo289 , lerpResult656 , ( ASP_GlobalTintNoiseToggle * _TintNoiseIntensity * ASP_GlobalTintNoiseIntensity ));
				#ifdef _ENABLETINTVARIATIONCOLOR_ON
				float3 staticSwitch403 = lerpResult661;
				#else
				float3 staticSwitch403 = Base_Albedo289;
				#endif
				float3 Base_Albedo_and_Tint_Color374 = staticSwitch403;
				float3 blendOpSrc331 = Albedo_Texture299;
				float3 blendOpDest331 = _BottomColor.rgb;
				float saferPower336 = abs( ( 1.0 - input.ase_color.a ) );
				float3 lerpResult340 = lerp( Base_Albedo_and_Tint_Color374 , (( blendOpDest331 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest331 ) * ( 1.0 - blendOpSrc331 ) ) : ( 2.0 * blendOpDest331 * blendOpSrc331 ) ) , saturate( ( _BottomColorOffset * pow( saferPower336 , _BottomColorContrast ) ) ));
				#ifdef _ENABLEBOTTOMCOLOR_ON
				float3 staticSwitch375 = lerpResult340;
				#else
				float3 staticSwitch375 = Base_Albedo_and_Tint_Color374;
				#endif
				float3 Output_Albedo342 = staticSwitch375;
				
				float2 uv_BaseNormal318 = input.ase_texcoord8.xy;
				float3 unpack318 = UnpackNormalScale( tex2D( _BaseNormal, uv_BaseNormal318 ), _BaseNormalIntensity );
				unpack318.z = lerp( 1, unpack318.z, saturate(_BaseNormalIntensity) );
				float3 Base_Normal642 = unpack318;
				
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float2 appendResult73_g1 = (float2(WorldPosition.x , WorldPosition.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2D( ASPW_WindGrassWavesNoiseTexture, ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy ).r;
				float Wind_Waves621 = Wind_Waves93_g1;
				float lerpResult304 = lerp( 0.0 , _BaseSmoothnessIntensity , ( input.ase_color.r * ( Wind_Waves621 + _BaseSmoothnessWaves ) ));
				#ifdef _ENABLESMOOTHNESSWAVES_ON
				float staticSwitch726 = lerpResult304;
				#else
				float staticSwitch726 = _BaseSmoothnessIntensity;
				#endif
				float Base_Smoothness314 = saturate( staticSwitch726 );
				
				float Base_Opacity295 = tex2DNode280.a;
				float4 ase_positionSSNorm = ScreenPos / ScreenPos.w;
				ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
				float4 ase_positionSS_Pixel = ASEScreenPositionNormalizedToPixel( ase_positionSSNorm );
				float dither735 = Dither4x4Bayer( fmod( ase_positionSS_Pixel.x, 4 ), fmod( ase_positionSS_Pixel.y, 4 ) );
				dither735 = step( dither735, saturate( saturate( ( ( input.ase_color.r - _BottomDitherOffset ) * ( _BottomDitherContrast * 2 ) ) ) * 1.00001 ) );
				#ifdef _ENABLEBOTTOMDITHER_ON
				float staticSwitch738 = ( dither735 * Base_Opacity295 );
				#else
				float staticSwitch738 = Base_Opacity295;
				#endif
				float Output_Opacity739 = staticSwitch738;
				

				float3 BaseColor = Output_Albedo342;
				float3 Normal = Base_Normal642;
				float3 Emission = 0;
				float3 Specular = 0.5;
				float Metallic = 0;
				float Smoothness = Base_Smoothness314;
				float Occlusion = 1;
				float Alpha = Output_Opacity739;
				float AlphaClipThreshold = _BaseOpacityCutoff;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = input.positionCS.z;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				InputData inputData = (InputData)0;
				inputData.positionWS = WorldPosition;
				inputData.positionCS = input.positionCS;
				inputData.shadowCoord = ShadowCoords;

				#ifdef _NORMALMAP
					#if _NORMAL_DROPOFF_TS
						inputData.normalWS = TransformTangentToWorld(Normal, half3x3( WorldTangent, WorldBiTangent, WorldNormal ));
					#elif _NORMAL_DROPOFF_OS
						inputData.normalWS = TransformObjectToWorldNormal(Normal);
					#elif _NORMAL_DROPOFF_WS
						inputData.normalWS = Normal;
					#endif
				#else
					inputData.normalWS = WorldNormal;
				#endif

				inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
				inputData.viewDirectionWS = SafeNormalize( WorldViewDirection );

				#ifdef ASE_FOG
					// @diogo: no fog applied in GBuffer
				#endif
				#ifdef _ADDITIONAL_LIGHTS_VERTEX
					inputData.vertexLighting = input.fogFactorAndVertexLight.yzw;
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float3 SH = SampleSH(inputData.normalWS.xyz);
				#else
					float3 SH = input.lightmapUVOrVertexSH.xyz;
				#endif

				#ifdef ASE_BAKEDGI
					inputData.bakedGI = BakedGI;
				#else
					#if defined(DYNAMICLIGHTMAP_ON)
						inputData.bakedGI = SAMPLE_GI( input.lightmapUVOrVertexSH.xy, input.dynamicLightmapUV.xy, SH, inputData.normalWS);
					#else
						inputData.bakedGI = SAMPLE_GI( input.lightmapUVOrVertexSH.xy, SH, inputData.normalWS );
					#endif
				#endif

				inputData.normalizedScreenSpaceUV = NormalizedScreenSpaceUV;
				inputData.shadowMask = SAMPLE_SHADOWMASK(input.lightmapUVOrVertexSH.xy);

				#if defined(DEBUG_DISPLAY)
					#if defined(DYNAMICLIGHTMAP_ON)
						inputData.dynamicLightmapUV = input.dynamicLightmapUV.xy;
						#endif
					#if defined(LIGHTMAP_ON)
						inputData.staticLightmapUV = input.lightmapUVOrVertexSH.xy;
					#else
						inputData.vertexSH = SH;
					#endif
				#endif

				#ifdef _DBUFFER
					ApplyDecal(input.positionCS,
						BaseColor,
						Specular,
						inputData.normalWS,
						Metallic,
						Occlusion,
						Smoothness);
				#endif

				BRDFData brdfData;
				InitializeBRDFData
				(BaseColor, Metallic, Specular, Smoothness, Alpha, brdfData);

				Light mainLight = GetMainLight(inputData.shadowCoord, inputData.positionWS, inputData.shadowMask);
				half4 color;
				MixRealtimeAndBakedGI(mainLight, inputData.normalWS, inputData.bakedGI, inputData.shadowMask);
				color.rgb = GlobalIllumination(brdfData, inputData.bakedGI, Occlusion, inputData.positionWS, inputData.normalWS, inputData.viewDirectionWS);
				color.a = Alpha;

				#ifdef ASE_FINAL_COLOR_ALPHA_MULTIPLY
					color.rgb *= color.a;
				#endif

				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
				#endif

				return BRDFDataToGbuffer(brdfData, inputData, Smoothness, Emission + color.rgb, Occlusion);
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "SceneSelectionPass"
			Tags { "LightMode"="SceneSelectionPass" }

			Cull Off
			AlphaToMask Off

			HLSLPROGRAM

			

			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011


			

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(_ASE_LIGHTING_SIMPLE)
				#define _SPECULAR_COLOR 1
			#endif

			#define SCENESELECTIONPASS 1

			#define ATTRIBUTES_NEED_NORMAL
			#define ATTRIBUTES_NEED_TANGENT
			#define SHADERPASS SHADERPASS_DEPTHONLY

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"

			
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
           

			
            #if ASE_SRP_VERSION >=140009
			#include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			
            #if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLEBOTTOMDITHER_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseAlbedoColor;
			float4 _TintColor;
			float4 _BottomColor;
			float _WindGrassSpeed;
			float _BottomDitherOffset;
			float _BaseSmoothnessWaves;
			float _BaseSmoothnessIntensity;
			float _BaseNormalIntensity;
			float _BottomColorContrast;
			float _BottomColorOffset;
			float _TintNoiseIntensity;
			float _TintNoiseInvertMask;
			float _BottomDitherContrast;
			float _TintNoiseUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindGrassTurbulence;
			float _WindGrassScale;
			float _WindGrassFlexibility;
			float _WindGrassAmplitude;
			float _TintNoiseContrast;
			float _BaseOpacityCutoff;
			#ifdef ASE_TRANSMISSION
				float _TransmissionShadow;
			#endif
			#ifdef ASE_TRANSLUCENCY
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D ASPW_WindGrassWavesNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindGrassSpeed;
			half ASPW_WindGrassAmplitude;
			half ASPW_WindGrassFlexibility;
			half ASPW_WindGrassWavesAmplitude;
			half ASPW_WindGrassWavesSpeed;
			half ASPW_WindGrassWavesScale;
			half ASPW_WindGrassTurbulence;
			half ASPW_WindToggle;
			sampler2D _BaseAlbedo;


			float3 ASESafeNormalize(float3 inVec)
			{
				float dp3 = max(1.175494351e-38, dot(inVec, inVec));
				return inVec* rsqrt(dp3);
			}
			
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 ASEScreenPositionNormalizedToPixel( float4 screenPosNorm )
			{
				float4 screenPosPixel = screenPosNorm * float4( _ScreenParams.xy, 1, 1 );
				#if UNITY_UV_STARTS_AT_TOP
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x < 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#else
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x > 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#endif
				return screenPosPixel;
			}
			
			inline float Dither4x4Bayer( int x, int y )
			{
				const float dither[ 16 ] = {
				     1,  9,  3, 11,
				    13,  5, 15,  7,
				     4, 12,  2, 10,
				    16,  8, 14,  6 };
				int r = y * 4 + x;
				return dither[ r ] / 16; // same # of instructions as pre-dividing due to compiler magic
			}
			

			struct SurfaceDescription
			{
				float Alpha;
				float AlphaClipThreshold;
			};

			PackedVaryings VertexFunction(Attributes input  )
			{
				PackedVaryings output;
				ZERO_INITIALIZE(PackedVaryings, output);

				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 worldToObjDir40_g1 = mul( GetWorldToObjectMatrix(), float4( normalizeResult41_g1, 0.0 ) ).xyz;
				float3 Wind_Direction_Leaf50_g1 = worldToObjDir40_g1;
				float3 break42_g1 = Wind_Direction_Leaf50_g1;
				float3 appendResult43_g1 = (float3(break42_g1.z , 0.0 , ( break42_g1.x * -1.0 )));
				float3 Wind_Direction52_g1 = appendResult43_g1;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Grass_Randomization65_g1 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_5_0_g1 = ( Wind_Grass_Randomization65_g1 + _TimeParameters.x );
				float Global_Wind_Grass_Speed144_g1 = ASPW_WindGrassSpeed;
				float temp_output_9_0_g1 = ( _WindGrassSpeed * Global_Wind_Grass_Speed144_g1 * 10.0 );
				float Local_Wind_Grass_Aplitude180_g1 = _WindGrassAmplitude;
				float Global_Wind_Grass_Amplitude172_g1 = ASPW_WindGrassAmplitude;
				float temp_output_27_0_g1 = ( Local_Wind_Grass_Aplitude180_g1 * Global_Wind_Grass_Amplitude172_g1 );
				float Global_Wind_Grass_Flexibility164_g1 = ASPW_WindGrassFlexibility;
				float Wind_Main31_g1 = ( ( ( ( ( sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.0 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.25 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.5 ) ) ) ) + temp_output_27_0_g1 ) * temp_output_27_0_g1 ) / 50.0 ) * ( ( Global_Wind_Grass_Flexibility164_g1 * _WindGrassFlexibility ) * 0.1 ) );
				float Global_Wind_Grass_Waves_Amplitude162_g1 = ASPW_WindGrassWavesAmplitude;
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 appendResult73_g1 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2Dlod( ASPW_WindGrassWavesNoiseTexture, float4( ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).r;
				float lerpResult96_g1 = lerp( Wind_Main31_g1 , ( Wind_Main31_g1 * Global_Wind_Grass_Waves_Amplitude162_g1 ) , Wind_Waves93_g1);
				float Wind_Main_with_Waves108_g1 = lerpResult96_g1;
				float temp_output_141_0_g1 = ( ( ase_positionWS.y * ( _WindGrassScale * 10.0 ) ) + _TimeParameters.x );
				float Local_Wind_Grass_Speed186_g1 = _WindGrassSpeed;
				float temp_output_146_0_g1 = ( Global_Wind_Grass_Speed144_g1 * Local_Wind_Grass_Speed186_g1 * 10.0 );
				float Global_Wind_Grass_Turbulence161_g1 = ASPW_WindGrassTurbulence;
				float clampResult175_g1 = clamp( Global_Wind_Grass_Amplitude172_g1 , 0.0 , 1.0 );
				float temp_output_188_0_g1 = ( ( ( sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.0 ) ) ) + sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.25 ) ) ) ) * 0.5 ) * ( ( Global_Wind_Grass_Turbulence161_g1 * ( clampResult175_g1 * ( _WindGrassTurbulence * Local_Wind_Grass_Aplitude180_g1 ) ) ) * 0.1 ) );
				float3 appendResult183_g1 = (float3(temp_output_188_0_g1 , ( temp_output_188_0_g1 * 0.2 ) , temp_output_188_0_g1));
				float3 Wind_Turbulence185_g1 = appendResult183_g1;
				float3 rotatedValue56_g1 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction52_g1, ( Wind_Main_with_Waves108_g1 + Wind_Turbulence185_g1 ).x );
				float3 Output_Wind35_g1 = ( rotatedValue56_g1 - input.positionOS.xyz );
				float Wind_Mask225_g1 = input.ase_color.r;
				float3 lerpResult232_g1 = lerp( float3( 0,0,0 ) , ( Output_Wind35_g1 * Wind_Mask225_g1 ) , ASPW_WindToggle);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch192_g1 = lerpResult232_g1;
				#else
				float3 staticSwitch192_g1 = temp_cast_0;
				#endif
				
				float4 ase_positionCS = TransformObjectToHClip( ( input.positionOS ).xyz );
				float4 screenPos = ComputeScreenPos( ase_positionCS );
				output.ase_texcoord1 = screenPos;
				
				output.ase_texcoord.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch192_g1;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;

				float3 positionWS = TransformObjectToWorld( input.positionOS.xyz );

				output.positionCS = TransformWorldToHClip(positionWS);

				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( Attributes input )
			{
				VertexControl output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				output.positionOS = input.positionOS;
				output.normalOS = input.normalOS;
				output.ase_color = input.ase_color;
				output.ase_texcoord = input.ase_texcoord;
				return output;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> input)
			{
				TessellationFactors output;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				output.edge[0] = tf.x; output.edge[1] = tf.y; output.edge[2] = tf.z; output.inside = tf.w;
				return output;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
				return patch[id];
			}

			[domain("tri")]
			PackedVaryings DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				Attributes output = (Attributes) 0;
				output.positionOS = patch[0].positionOS * bary.x + patch[1].positionOS * bary.y + patch[2].positionOS * bary.z;
				output.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = output.positionOS.xyz - patch[i].normalOS * (dot(output.positionOS.xyz, patch[i].normalOS) - dot(patch[i].positionOS.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				output.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * output.positionOS.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], output);
				return VertexFunction(output);
			}
			#else
			PackedVaryings vert ( Attributes input )
			{
				return VertexFunction( input );
			}
			#endif

			half4 frag(PackedVaryings input ) : SV_Target
			{
				SurfaceDescription surfaceDescription = (SurfaceDescription)0;

				float2 uv_BaseAlbedo280 = input.ase_texcoord.xy;
				float4 tex2DNode280 = tex2D( _BaseAlbedo, uv_BaseAlbedo280 );
				float Base_Opacity295 = tex2DNode280.a;
				float4 screenPos = input.ase_texcoord1;
				float4 ase_positionSSNorm = screenPos / screenPos.w;
				ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
				float4 ase_positionSS_Pixel = ASEScreenPositionNormalizedToPixel( ase_positionSSNorm );
				float dither735 = Dither4x4Bayer( fmod( ase_positionSS_Pixel.x, 4 ), fmod( ase_positionSS_Pixel.y, 4 ) );
				dither735 = step( dither735, saturate( saturate( ( ( input.ase_color.r - _BottomDitherOffset ) * ( _BottomDitherContrast * 2 ) ) ) * 1.00001 ) );
				#ifdef _ENABLEBOTTOMDITHER_ON
				float staticSwitch738 = ( dither735 * Base_Opacity295 );
				#else
				float staticSwitch738 = Base_Opacity295;
				#endif
				float Output_Opacity739 = staticSwitch738;
				

				surfaceDescription.Alpha = Output_Opacity739;
				surfaceDescription.AlphaClipThreshold = _BaseOpacityCutoff;

				#if _ALPHATEST_ON
					float alphaClipThreshold = 0.01f;
					#if ALPHA_CLIP_THRESHOLD
						alphaClipThreshold = surfaceDescription.AlphaClipThreshold;
					#endif
					clip(surfaceDescription.Alpha - alphaClipThreshold);
				#endif

				half4 outColor = 0;

				#ifdef SCENESELECTIONPASS
					outColor = half4(_ObjectId, _PassValue, 1.0, 1.0);
				#elif defined(SCENEPICKINGPASS)
					outColor = _SelectionID;
				#endif

				return outColor;
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "ScenePickingPass"
			Tags { "LightMode"="Picking" }

			AlphaToMask Off

			HLSLPROGRAM

			

			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011


			

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(_ASE_LIGHTING_SIMPLE)
				#define _SPECULAR_COLOR 1
			#endif

		    #define SCENEPICKINGPASS 1

			#define ATTRIBUTES_NEED_NORMAL
			#define ATTRIBUTES_NEED_TANGENT
			#define SHADERPASS SHADERPASS_DEPTHONLY

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"

			
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
           

			
            #if ASE_SRP_VERSION >=140009
			#include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			
            #if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLEBOTTOMDITHER_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseAlbedoColor;
			float4 _TintColor;
			float4 _BottomColor;
			float _WindGrassSpeed;
			float _BottomDitherOffset;
			float _BaseSmoothnessWaves;
			float _BaseSmoothnessIntensity;
			float _BaseNormalIntensity;
			float _BottomColorContrast;
			float _BottomColorOffset;
			float _TintNoiseIntensity;
			float _TintNoiseInvertMask;
			float _BottomDitherContrast;
			float _TintNoiseUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindGrassTurbulence;
			float _WindGrassScale;
			float _WindGrassFlexibility;
			float _WindGrassAmplitude;
			float _TintNoiseContrast;
			float _BaseOpacityCutoff;
			#ifdef ASE_TRANSMISSION
				float _TransmissionShadow;
			#endif
			#ifdef ASE_TRANSLUCENCY
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D ASPW_WindGrassWavesNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindGrassSpeed;
			half ASPW_WindGrassAmplitude;
			half ASPW_WindGrassFlexibility;
			half ASPW_WindGrassWavesAmplitude;
			half ASPW_WindGrassWavesSpeed;
			half ASPW_WindGrassWavesScale;
			half ASPW_WindGrassTurbulence;
			half ASPW_WindToggle;
			sampler2D _BaseAlbedo;


			float3 ASESafeNormalize(float3 inVec)
			{
				float dp3 = max(1.175494351e-38, dot(inVec, inVec));
				return inVec* rsqrt(dp3);
			}
			
			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			
			float4 ASEScreenPositionNormalizedToPixel( float4 screenPosNorm )
			{
				float4 screenPosPixel = screenPosNorm * float4( _ScreenParams.xy, 1, 1 );
				#if UNITY_UV_STARTS_AT_TOP
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x < 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#else
					screenPosPixel.xy = float2( screenPosPixel.x, ( _ProjectionParams.x > 0 ) ? _ScreenParams.y - screenPosPixel.y : screenPosPixel.y );
				#endif
				return screenPosPixel;
			}
			
			inline float Dither4x4Bayer( int x, int y )
			{
				const float dither[ 16 ] = {
				     1,  9,  3, 11,
				    13,  5, 15,  7,
				     4, 12,  2, 10,
				    16,  8, 14,  6 };
				int r = y * 4 + x;
				return dither[ r ] / 16; // same # of instructions as pre-dividing due to compiler magic
			}
			

			struct SurfaceDescription
			{
				float Alpha;
				float AlphaClipThreshold;
			};

			PackedVaryings VertexFunction(Attributes input  )
			{
				PackedVaryings output;
				ZERO_INITIALIZE(PackedVaryings, output);

				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction238_g1 = ASPW_WindDirection;
				float3 normalizeResult41_g1 = ASESafeNormalize( Global_Wind_Direction238_g1 );
				float3 worldToObjDir40_g1 = mul( GetWorldToObjectMatrix(), float4( normalizeResult41_g1, 0.0 ) ).xyz;
				float3 Wind_Direction_Leaf50_g1 = worldToObjDir40_g1;
				float3 break42_g1 = Wind_Direction_Leaf50_g1;
				float3 appendResult43_g1 = (float3(break42_g1.z , 0.0 , ( break42_g1.x * -1.0 )));
				float3 Wind_Direction52_g1 = appendResult43_g1;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Grass_Randomization65_g1 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_5_0_g1 = ( Wind_Grass_Randomization65_g1 + _TimeParameters.x );
				float Global_Wind_Grass_Speed144_g1 = ASPW_WindGrassSpeed;
				float temp_output_9_0_g1 = ( _WindGrassSpeed * Global_Wind_Grass_Speed144_g1 * 10.0 );
				float Local_Wind_Grass_Aplitude180_g1 = _WindGrassAmplitude;
				float Global_Wind_Grass_Amplitude172_g1 = ASPW_WindGrassAmplitude;
				float temp_output_27_0_g1 = ( Local_Wind_Grass_Aplitude180_g1 * Global_Wind_Grass_Amplitude172_g1 );
				float Global_Wind_Grass_Flexibility164_g1 = ASPW_WindGrassFlexibility;
				float Wind_Main31_g1 = ( ( ( ( ( sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.0 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.25 ) ) ) + sin( ( temp_output_5_0_g1 * ( temp_output_9_0_g1 * 1.5 ) ) ) ) + temp_output_27_0_g1 ) * temp_output_27_0_g1 ) / 50.0 ) * ( ( Global_Wind_Grass_Flexibility164_g1 * _WindGrassFlexibility ) * 0.1 ) );
				float Global_Wind_Grass_Waves_Amplitude162_g1 = ASPW_WindGrassWavesAmplitude;
				float3 appendResult119_g1 = (float3(( normalizeResult41_g1.x * -1.0 ) , ( 0.0 * -1.0 ) , 0.0));
				float3 Wind_Direction_Waves118_g1 = appendResult119_g1;
				float Global_Wind_Grass_Waves_Speed166_g1 = ASPW_WindGrassWavesSpeed;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 appendResult73_g1 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Grass_Waves_Scale168_g1 = ASPW_WindGrassWavesScale;
				float Wind_Waves93_g1 = tex2Dlod( ASPW_WindGrassWavesNoiseTexture, float4( ( ( ( Wind_Direction_Waves118_g1 * _TimeParameters.x ) * ( Global_Wind_Grass_Waves_Speed166_g1 * 0.1 ) ) + float3( ( ( appendResult73_g1 * Global_Wind_Grass_Waves_Scale168_g1 ) * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).r;
				float lerpResult96_g1 = lerp( Wind_Main31_g1 , ( Wind_Main31_g1 * Global_Wind_Grass_Waves_Amplitude162_g1 ) , Wind_Waves93_g1);
				float Wind_Main_with_Waves108_g1 = lerpResult96_g1;
				float temp_output_141_0_g1 = ( ( ase_positionWS.y * ( _WindGrassScale * 10.0 ) ) + _TimeParameters.x );
				float Local_Wind_Grass_Speed186_g1 = _WindGrassSpeed;
				float temp_output_146_0_g1 = ( Global_Wind_Grass_Speed144_g1 * Local_Wind_Grass_Speed186_g1 * 10.0 );
				float Global_Wind_Grass_Turbulence161_g1 = ASPW_WindGrassTurbulence;
				float clampResult175_g1 = clamp( Global_Wind_Grass_Amplitude172_g1 , 0.0 , 1.0 );
				float temp_output_188_0_g1 = ( ( ( sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.0 ) ) ) + sin( ( temp_output_141_0_g1 * ( temp_output_146_0_g1 * 1.25 ) ) ) ) * 0.5 ) * ( ( Global_Wind_Grass_Turbulence161_g1 * ( clampResult175_g1 * ( _WindGrassTurbulence * Local_Wind_Grass_Aplitude180_g1 ) ) ) * 0.1 ) );
				float3 appendResult183_g1 = (float3(temp_output_188_0_g1 , ( temp_output_188_0_g1 * 0.2 ) , temp_output_188_0_g1));
				float3 Wind_Turbulence185_g1 = appendResult183_g1;
				float3 rotatedValue56_g1 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction52_g1, ( Wind_Main_with_Waves108_g1 + Wind_Turbulence185_g1 ).x );
				float3 Output_Wind35_g1 = ( rotatedValue56_g1 - input.positionOS.xyz );
				float Wind_Mask225_g1 = input.ase_color.r;
				float3 lerpResult232_g1 = lerp( float3( 0,0,0 ) , ( Output_Wind35_g1 * Wind_Mask225_g1 ) , ASPW_WindToggle);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch192_g1 = lerpResult232_g1;
				#else
				float3 staticSwitch192_g1 = temp_cast_0;
				#endif
				
				float4 ase_positionCS = TransformObjectToHClip( ( input.positionOS ).xyz );
				float4 screenPos = ComputeScreenPos( ase_positionCS );
				output.ase_texcoord1 = screenPos;
				
				output.ase_texcoord.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch192_g1;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;

				float3 positionWS = TransformObjectToWorld( input.positionOS.xyz );
				output.positionCS = TransformWorldToHClip(positionWS);

				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( Attributes input )
			{
				VertexControl output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				output.positionOS = input.positionOS;
				output.normalOS = input.normalOS;
				output.ase_color = input.ase_color;
				output.ase_texcoord = input.ase_texcoord;
				return output;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> input)
			{
				TessellationFactors output;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(input[0].positionOS, input[1].positionOS, input[2].positionOS, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				output.edge[0] = tf.x; output.edge[1] = tf.y; output.edge[2] = tf.z; output.inside = tf.w;
				return output;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
				return patch[id];
			}

			[domain("tri")]
			PackedVaryings DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				Attributes output = (Attributes) 0;
				output.positionOS = patch[0].positionOS * bary.x + patch[1].positionOS * bary.y + patch[2].positionOS * bary.z;
				output.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = output.positionOS.xyz - patch[i].normalOS * (dot(output.positionOS.xyz, patch[i].normalOS) - dot(patch[i].positionOS.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				output.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * output.positionOS.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], output);
				return VertexFunction(output);
			}
			#else
			PackedVaryings vert ( Attributes input )
			{
				return VertexFunction( input );
			}
			#endif

			half4 frag(PackedVaryings input ) : SV_Target
			{
				SurfaceDescription surfaceDescription = (SurfaceDescription)0;

				float2 uv_BaseAlbedo280 = input.ase_texcoord.xy;
				float4 tex2DNode280 = tex2D( _BaseAlbedo, uv_BaseAlbedo280 );
				float Base_Opacity295 = tex2DNode280.a;
				float4 screenPos = input.ase_texcoord1;
				float4 ase_positionSSNorm = screenPos / screenPos.w;
				ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
				float4 ase_positionSS_Pixel = ASEScreenPositionNormalizedToPixel( ase_positionSSNorm );
				float dither735 = Dither4x4Bayer( fmod( ase_positionSS_Pixel.x, 4 ), fmod( ase_positionSS_Pixel.y, 4 ) );
				dither735 = step( dither735, saturate( saturate( ( ( input.ase_color.r - _BottomDitherOffset ) * ( _BottomDitherContrast * 2 ) ) ) * 1.00001 ) );
				#ifdef _ENABLEBOTTOMDITHER_ON
				float staticSwitch738 = ( dither735 * Base_Opacity295 );
				#else
				float staticSwitch738 = Base_Opacity295;
				#endif
				float Output_Opacity739 = staticSwitch738;
				

				surfaceDescription.Alpha = Output_Opacity739;
				surfaceDescription.AlphaClipThreshold = _BaseOpacityCutoff;

				#if _ALPHATEST_ON
					float alphaClipThreshold = 0.01f;
					#if ALPHA_CLIP_THRESHOLD
						alphaClipThreshold = surfaceDescription.AlphaClipThreshold;
					#endif
						clip(surfaceDescription.Alpha - alphaClipThreshold);
				#endif

				half4 outColor = 0;

				#ifdef SCENESELECTIONPASS
					outColor = half4(_ObjectId, _PassValue, 1.0, 1.0);
				#elif defined(SCENEPICKINGPASS)
					outColor = _SelectionID;
				#endif

				return outColor;
			}

			ENDHLSL
		}
		
	}
	
	
	FallBack "Hidden/Shader Graph/FallbackError"
	
	Fallback Off
}
/*ASEBEGIN
Version=19801
Node;AmplifyShaderEditor.CommentaryNode;727;-48,960;Inherit;False;2481;469;;12;739;738;737;736;735;734;733;732;731;730;729;728;Base Bottom Dither;1,1,1,1;0;0
Node;AmplifyShaderEditor.VertexColorNode;728;0,1024;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;729;0,1312;Inherit;False;Property;_BottomDitherContrast;Bottom Dither Contrast;17;0;Create;True;0;0;0;False;0;False;3;0;1;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;730;0,1216;Inherit;False;Property;_BottomDitherOffset;Bottom Dither Offset;16;0;Create;True;0;0;0;False;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;639;-2752,-1840;Inherit;False;2241;429;;11;289;283;285;299;425;287;288;281;282;295;280;Base Albedo;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;731;384,1024;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScaleNode;732;384,1280;Inherit;False;2;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;280;-2688,-1792;Inherit;True;Property;_BaseAlbedo;Base Albedo;9;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;d7b5f571c971c2844b6578a9de1662fb;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;733;640,1024;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;295;-2304,-1664;Inherit;False;Base Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;734;896,1024;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DitheringNode;735;1152,1024;Inherit;False;0;False;4;0;FLOAT;0;False;1;SAMPLER2D;;False;2;FLOAT4;0,0,0,0;False;3;SAMPLERSTATE;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;736;1152,1152;Inherit;False;295;Base Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;737;1408,1024;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;738;1664,1024;Inherit;False;Property;_EnableBottomDither;Enable Bottom Dither;12;0;Create;True;0;0;0;False;1;;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;675;3008,-1842;Inherit;False;768;689;;7;644;423;296;315;290;621;707;Output;1,0,0,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;671;-64,-1840;Inherit;False;2498;1449;;32;401;654;678;655;677;670;658;653;676;374;403;404;661;662;665;656;412;664;663;657;660;345;343;344;651;650;647;649;354;652;648;659;Base Tint Color;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;673;-48,-176;Inherit;False;2481;941;;15;342;375;376;340;370;339;331;338;332;330;333;336;337;335;334;Base Bottom Color;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;674;-2751,-690;Inherit;False;1854;690;;10;726;304;314;424;312;711;311;622;307;306;Base Smoothness;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;643;-2752,-1200;Inherit;False;1087;302;;3;642;318;319;Base Normal;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;739;2048,1024;Inherit;False;Output Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;648;0,-1024;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;652;0,-768;Half;False;Global;ASP_GlobalTintNoiseUVScale;ASP_GlobalTintNoiseUVScale;20;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;354;0,-672;Inherit;False;Property;_TintNoiseUVScale;Tint Noise UV Scale;20;0;Create;True;0;0;0;False;0;False;5;10;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;649;256,-1024;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;647;384,-768;Inherit;False;3;3;0;FLOAT;0.01;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;650;512,-1024;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DesaturateOpNode;281;-2304,-1792;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;287;-1920,-1792;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;425;-1664,-1792;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;299;-1408,-1792;Inherit;False;Albedo Texture;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;285;-1408,-1664;Inherit;False;Property;_BaseAlbedoColor;Base Albedo Color;3;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0;0.1004732,0.2924528,0.06207726,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RegisterLocalVarNode;289;-768,-1792;Inherit;False;Base Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;344;0,-1664;Inherit;False;Property;_TintColor;Tint Color;19;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0;0.6037736,0.5754763,0.1623354,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;343;0,-1792;Inherit;False;299;Albedo Texture;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BlendOpsNode;345;256,-1792;Inherit;False;Overlay;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;660;256,-1568;Inherit;False;659;Base Tint Color Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;657;256,-1664;Inherit;False;289;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;663;640,-1536;Half;False;Global;ASP_GlobalTintNoiseToggle;ASP_GlobalTintNoiseToggle;1;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;664;640,-1344;Half;False;Global;ASP_GlobalTintNoiseIntensity;ASP_GlobalTintNoiseIntensity;1;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;412;640,-1440;Inherit;False;Property;_TintNoiseIntensity;Tint Noise Intensity;21;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;656;640,-1792;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;665;640,-1664;Inherit;False;289;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;662;1024,-1536;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;661;1280,-1792;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;404;1280,-1536;Inherit;False;289;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;374;2048,-1792;Inherit;False;Base Albedo and Tint Color;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;621;3456,-1328;Inherit;False;Wind Waves;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;290;3072,-1792;Inherit;False;342;Output Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;644;3072,-1712;Inherit;False;642;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;319;-2688,-1152;Inherit;False;Property;_BaseNormalIntensity;Base Normal Intensity;8;0;Create;True;0;0;0;False;0;False;0;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;318;-2304,-1152;Inherit;True;Property;_BaseNormal;Base Normal;10;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RegisterLocalVarNode;642;-1920,-1152;Inherit;False;Base Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;676;1280,-1024;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;653;1536,-1024;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;655;1280,-768;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;654;768,-672;Half;False;Global;ASP_GlobalTintNoiseContrast;ASP_GlobalTintNoiseContrast;20;0;Create;True;0;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;334;0,384;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;335;256,384;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;337;0,640;Inherit;False;Property;_BottomColorContrast;Bottom Color Contrast;15;0;Create;True;0;0;0;False;0;False;1;3;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;336;512,384;Inherit;False;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;333;0,256;Inherit;False;Property;_BottomColorOffset;Bottom Color Offset;14;0;Create;True;0;0;0;False;0;False;1;2.53;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;330;0,-128;Inherit;False;299;Albedo Texture;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;332;0,0;Inherit;False;Property;_BottomColor;Bottom Color;13;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0;0.05126947,0.1912017,0.04231142,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;338;768,256;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BlendOpsNode;331;384,-128;Inherit;False;Overlay;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;339;1024,256;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;370;896,0;Inherit;False;374;Base Albedo and Tint Color;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;340;1280,-128;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;376;1280,0;Inherit;False;374;Base Albedo and Tint Color;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;375;1664,-128;Inherit;False;Property;_EnableBottomColor;Enable Bottom Color;11;0;Create;True;0;0;0;False;1;Header(Bottom Color);False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;342;2176,-128;Inherit;False;Output Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.VertexColorNode;670;1280,-640;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;658;1792,-1024;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;659;2048,-1024;Inherit;False;Base Tint Color Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;401;768,-592;Inherit;False;Property;_TintNoiseContrast;Tint Noise Contrast;22;0;Create;True;0;0;0;False;0;False;5;5;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;678;768,-768;Inherit;False;Property;_TintNoiseInvertMask;Tint Noise Invert Mask;23;1;[IntRange];Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;677;1104,-896;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;651;768,-1024;Inherit;True;Global;ASP_GlobalTintNoiseTexture;ASP_GlobalTintNoiseTexture;0;1;[NoScaleOffset];Create;True;0;0;0;True;1;Header(Tint);False;-1;None;e93d8f0da5bea8144ad9925e81909be8;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.BlendOpsNode;283;-1152,-1792;Inherit;False;Overlay;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;288;-2304,-1536;Inherit;False;Property;_BaseAlbedoBrightness;Base Albedo Brightness;4;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;282;-2688,-1536;Inherit;False;Property;_BaseAlbedoDesaturation;Base Albedo Desaturation;5;0;Create;True;0;0;0;False;0;False;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;306;-2688,-448;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;307;-2176,-448;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;622;-2688,-256;Inherit;False;621;Wind Waves;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;311;-2368,-256;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;707;3072,-1344;Inherit;False;MF_ASP_Global_WindGrass;24;;1;ebd015072dd6d824783224f1cda1c365;0;0;2;FLOAT3;0;FLOAT;229
Node;AmplifyShaderEditor.RangedFloatNode;312;-2688,-128;Inherit;False;Property;_BaseSmoothnessWaves;Base Smoothness Waves;7;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;423;3072,-1440;Inherit;False;Property;_BaseOpacityCutoff;Base Opacity Cutoff;2;0;Create;True;0;0;0;False;0;False;0.3;0.3;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;424;-1408,-640;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;314;-1200,-640;Inherit;False;Base Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;304;-1920,-512;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;726;-1792,-640;Inherit;False;Property;_EnableSmoothnessWaves;Enable Smoothness Waves;1;0;Create;True;0;0;0;False;1;Header(Base);False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;711;-2688,-640;Inherit;False;Property;_BaseSmoothnessIntensity;Base Smoothness Intensity;6;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;315;3072,-1632;Inherit;False;314;Base Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;403;1536,-1792;Inherit;False;Property;_EnableTintVariationColor;Enable Tint Variation Color;18;0;Create;True;0;0;0;False;1;Header(Tint Color);False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;296;3072,-1536;Inherit;False;739;Output Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;714;3456,-1792;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ExtraPrePass;0;0;ExtraPrePass;5;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;715;3456,-1792;Float;False;True;-1;3;;0;12;ANGRYMESH/Stylized Pack/Grass;94348b07e5e8bab40bd6c8a1e3df54cd;True;Forward;0;1;Forward;21;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalForward;False;False;0;;0;0;Standard;43;Lighting Model;0;0;Workflow;1;0;Surface;0;0;  Refraction Model;0;0;  Blend;0;0;Two Sided;0;638780773846977307;Alpha Clipping;1;0;  Use Shadow Threshold;0;0;Fragment Normal Space,InvertActionOnDeselection;0;0;Forward Only;0;0;Transmission;0;0;  Transmission Shadow;0.5,False,;0;Translucency;0;0;  Translucency Strength;1,False,;0;  Normal Distortion;0.5,False,;0;  Scattering;2,False,;0;  Direct;0.9,False,;0;  Ambient;0.1,False,;0;  Shadow;0.5,False,;0;Cast Shadows;1;0;Receive Shadows;1;0;Receive SSAO;1;0;GPU Instancing;1;0;LOD CrossFade;1;0;Built-in Fog;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Write Depth;0;0;  Early Z;0;0;Vertex Position,InvertActionOnDeselection;1;0;Debug Display;1;638780774314552149;Clear Coat;0;0;0;10;False;True;True;True;True;True;True;True;True;True;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;716;3456,-1792;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;717;3456,-1792;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;True;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;718;3456,-1792;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;719;3456,-1792;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;720;3456,-1792;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormals;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;721;3456,-1792;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;GBuffer;0;7;GBuffer;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalGBuffer;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;722;3456,-1792;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;SceneSelectionPass;0;8;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;723;3456,-1792;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ScenePickingPass;0;9;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
WireConnection;731;0;728;1
WireConnection;731;1;730;0
WireConnection;732;0;729;0
WireConnection;733;0;731;0
WireConnection;733;1;732;0
WireConnection;295;0;280;4
WireConnection;734;0;733;0
WireConnection;735;0;734;0
WireConnection;737;0;735;0
WireConnection;737;1;736;0
WireConnection;738;1;736;0
WireConnection;738;0;737;0
WireConnection;739;0;738;0
WireConnection;649;0;648;1
WireConnection;649;1;648;3
WireConnection;647;1;652;0
WireConnection;647;2;354;0
WireConnection;650;0;649;0
WireConnection;650;1;647;0
WireConnection;281;0;280;5
WireConnection;281;1;282;0
WireConnection;287;0;281;0
WireConnection;287;1;288;0
WireConnection;425;0;287;0
WireConnection;299;0;425;0
WireConnection;289;0;283;0
WireConnection;345;0;343;0
WireConnection;345;1;344;5
WireConnection;656;0;657;0
WireConnection;656;1;345;0
WireConnection;656;2;660;0
WireConnection;662;0;663;0
WireConnection;662;1;412;0
WireConnection;662;2;664;0
WireConnection;661;0;665;0
WireConnection;661;1;656;0
WireConnection;661;2;662;0
WireConnection;374;0;403;0
WireConnection;621;0;707;229
WireConnection;318;5;319;0
WireConnection;642;0;318;0
WireConnection;676;0;651;1
WireConnection;676;1;677;0
WireConnection;676;2;678;0
WireConnection;653;0;676;0
WireConnection;653;1;655;0
WireConnection;653;2;670;1
WireConnection;655;0;654;0
WireConnection;655;1;401;0
WireConnection;335;0;334;4
WireConnection;336;0;335;0
WireConnection;336;1;337;0
WireConnection;338;0;333;0
WireConnection;338;1;336;0
WireConnection;331;0;330;0
WireConnection;331;1;332;5
WireConnection;339;0;338;0
WireConnection;340;0;370;0
WireConnection;340;1;331;0
WireConnection;340;2;339;0
WireConnection;375;1;376;0
WireConnection;375;0;340;0
WireConnection;342;0;375;0
WireConnection;658;0;653;0
WireConnection;659;0;658;0
WireConnection;677;0;651;1
WireConnection;651;1;650;0
WireConnection;283;0;299;0
WireConnection;283;1;285;5
WireConnection;307;0;306;1
WireConnection;307;1;311;0
WireConnection;311;0;622;0
WireConnection;311;1;312;0
WireConnection;424;0;726;0
WireConnection;314;0;424;0
WireConnection;304;1;711;0
WireConnection;304;2;307;0
WireConnection;726;1;711;0
WireConnection;726;0;304;0
WireConnection;403;1;404;0
WireConnection;403;0;661;0
WireConnection;715;0;290;0
WireConnection;715;1;644;0
WireConnection;715;4;315;0
WireConnection;715;6;296;0
WireConnection;715;7;423;0
WireConnection;715;8;707;0
ASEEND*/
//CHKSM=6DAE09F3C99A1279BDA792DD141605B8F74952A0