// Made with Amplify Shader Editor v1.9.9
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "TriForge/FWGrass"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[Header(Color Variance)][Space(10)][Toggle( _USECOLORVARIANCE_ON )] _UseColorVariance( "Use Color Variance", Float ) = 0
		[SingleLineTexture] _ColorVarianceMask( "Color Variance Mask", 2D ) = "white" {}
		_MaskContrast( "Mask Contrast", Float ) = 1
		_ColorVarianceIntensity( "Color Variance Intensity", Range( 0, 1 ) ) = 0
		_ColorVarianceBiasShift( "Color Variance Bias Shift", Range( -1, 1 ) ) = 0
		_ColorVarianceMax( "Color Variance Max", Float ) = 1
		_ColorVarianceMin( "Color Variance Min", Float ) = -1
		_BrightnessVarianceIntensity( "Brightness Variance Intensity", Range( 0, 1 ) ) = 0
		_ColorVarianceMaskScale( "Color Variance Mask Scale", Float ) = -100
		[Header(BASE MAPS)][SingleLineTexture][Space(10)] _ColorMap( "Color Map", 2D ) = "white" {}
		[Normal][SingleLineTexture] _NormalMap( "Normal Map", 2D ) = "white" {}
		[SingleLineTexture] _MaskMap( "Mask Map", 2D ) = "white" {}
		[Header(COLOR ADJUSTMENT)][Space(10)] _Color( "Color", Color ) = ( 1, 1, 1, 0 )
		_RootColor( "Root Color", Color ) = ( 0.2235294, 0.2431373, 0.1058824, 1 )
		_BaseColorBrightness( "Base Color Brightness", Range( 0, 5 ) ) = 1
		_BaseColorSaturation( "Base Color Saturation", Range( 0, 2 ) ) = 1
		_BaseColorContrast( "Base Color Contrast", Range( 0, 2 ) ) = 1
		_RootMaskStrength( "Root Mask Strength", Range( -1, 1 ) ) = 0
		[Header(BASE ATTRIBUTES)][Space(10)] _Smoothness( "Smoothness", Range( 0, 1 ) ) = 1
		_Specular( "Specular", Float ) = 0.05
		_MaskClip( "Mask Clip", Range( 0, 1 ) ) = 0.51
		_AOStrength( "AO Strength", Range( 0, 1 ) ) = 0
		_FadeFalloff( "Fade Falloff", Range( 1, 5 ) ) = 2
		_FadeDistance( "Fade Distance", Float ) = 30
		_NormalScale( "Normal Scale", Float ) = 1
		_NormalYVectorInfluence( "Normal Y Vector Influence", Range( 0, 1 ) ) = 0
		[Toggle( _TFW_FLIPNORMALS )] _FlipBackNormals( "Flip Back Normals", Float ) = 0
		[Header(WIND MAPS)][SingleLineTexture][Space(15)] _WindMap( "Wind Map", 2D ) = "white" {}
		[SingleLineTexture] _WindDirectionMap( "Wind Direction Map", 2D ) = "white" {}
		[Header(WIND SETTINGS)][Space(10)][Toggle( _ENABLEWIND_ON )] _EnableWind( "Enable Wind", Float ) = 1
		_WindStrength( "Wind Strength", Range( 0, 1 ) ) = 1
		_WindRootMaskOffset( "Wind Root Mask Offset", Range( -1, 1 ) ) = 0
		_MainBendingStrength( "Main Bending Strength", Range( 0, 5 ) ) = 1
		_SecondaryBendingStrength( "Secondary Bending Strength", Range( 0, 1 ) ) = 0
		[Header(WIND DIRECTION)][Space(10)][Toggle( _USEWINDDIRECTIONMAP_ON )] _UseWindDirectionMap( "Use Wind Direction Map", Float ) = 0
		_WindDirectionMapInfluence( "Wind Direction Map Influence", Range( 0, 2 ) ) = 1
		_LFMapPanningSpeed( "LF Map Panning Speed", Vector ) = ( 0.04, 0, 0, 0 )
		_HFRotationMapInfluence( "HF Rotation Map Influence", Range( 0, 1 ) ) = 1
		_HFMapPanningSpeed( "HF Map Panning Speed", Vector ) = ( 0.04, 0, 0, 0 )
		_Transmission( "Transmission", Range( 0, 1 ) ) = 0.2
		_TranslucencyStrength( "Translucency Strength", Float ) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}


		_TransmissionShadow( "Transmission Shadow", Range( 0, 1 ) ) = 0.5
		_TransStrength( "Strength", Range( 0, 50 ) ) = 1
		_TransNormal( "Normal Distortion", Range( 0, 1 ) ) = 0.5
		_TransScattering( "Scattering", Range( 1, 50 ) ) = 2
		_TransDirect( "Direct", Range( 0, 1 ) ) = 0.9
		_TransAmbient( "Ambient", Range( 0, 1 ) ) = 0.1
		_TransShadow( "Shadow", Range( 0, 1 ) ) = 0.5
		//_TessPhongStrength( "Tess Phong Strength", Range( 0, 1 ) ) = 0.5
		//_TessValue( "Tess Max Tessellation", Range( 1, 32 ) ) = 16
		//_TessMin( "Tess Min Distance", Float ) = 10
		//_TessMax( "Tess Max Distance", Float ) = 25
		//_TessEdgeLength ( "Tess Edge length", Range( 2, 50 ) ) = 16
		//_TessMaxDisp( "Tess Max Displacement", Float ) = 25

		[HideInInspector][ToggleOff] _SpecularHighlights("Specular Highlights", Float) = 1
		[HideInInspector][ToggleOff] _EnvironmentReflections("Environment Reflections", Float) = 1
		[HideInInspector][ToggleOff] _ReceiveShadows("Receive Shadows", Float) = 1

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
			Tags { "LightMode"="UniversalForwardOnly" }

			Blend One Zero, One Zero
			ZWrite On
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA

			

			HLSLPROGRAM

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
			#pragma multi_compile_instancing
			#pragma instancing_options renderinglayer
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#define _NORMALMAP 1
			#define ASE_VERSION 19900
			#define ASE_SRP_VERSION 140012


			

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

			#if defined(_SPECULAR_SETUP) && defined(ASE_LIGHTING_SIMPLE)
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

			#define ASE_NEEDS_TEXTURE_COORDINATES2
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES2
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES2
			#define ASE_NEEDS_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _USECOLORVARIANCE_ON
			#pragma shader_feature _TFW_FLIPNORMALS
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"


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
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 texcoord : TEXCOORD0;
				#if defined(LIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES1)
					float4 texcoord1 : TEXCOORD1;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES2)
					float4 texcoord2 : TEXCOORD2;
				#endif
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				half3 normalWS : TEXCOORD1;
				half4 tangentWS : TEXCOORD2;
				float4 lightmapUVOrVertexSH : TEXCOORD3;
				#if defined(ASE_FOG) || defined(_ADDITIONAL_LIGHTS_VERTEX)
					half4 fogFactorAndVertexLight : TEXCOORD4;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON)
					float2 dynamicLightmapUV : TEXCOORD5;
				#endif
				float4 ase_texcoord6 : TEXCOORD6;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _RootColor;
			float4 _Color;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _BrightnessVarianceIntensity;
			float _NormalScale;
			float _NormalYVectorInfluence;
			float _Specular;
			float _WindRootMaskOffset;
			float _Smoothness;
			float _AOStrength;
			float _FadeDistance;
			float _FadeFalloff;
			float _MaskClip;
			float _ColorVarianceIntensity;
			float _ColorVarianceMax;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _Transmission;
			float _ColorVarianceBiasShift;
			float _RootMaskStrength;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindStrength;
			float _SecondaryBendingStrength;
			float _MainBendingStrength;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _ColorVarianceMin;
			float _TranslucencyStrength;
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

			float3 TF_WIND_DIRECTION;
			sampler2D _WindDirectionMap;
			float TF_ROTATION_MAP_INFLUENCE;
			sampler2D _WindMap;
			float TF_WIND_STRENGTH;
			float TF_GRASS_WIND_STRENGTH;
			int TF_EnableGrassWind;
			sampler2D _ColorMap;
			float TF_GrassVarianceBiasShift;
			sampler2D _ColorVarianceMask;
			float TF_GrassVarianceMaskScale;
			float TF_GrassVarianceMin;
			float TF_GrassVarianceMax;
			float TF_GrassVarianceIntensity;
			float TF_GrassBrightnessVariance;
			float TF_GrassVarianceRootInfluence;
			int TF_GrassVarianceEnable;
			sampler2D _NormalMap;
			sampler2D _MaskMap;
			float TF_GrassFadeDistance;


			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
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
			
			float3 HSVToRGB( float3 c )
			{
				float4 K = float4( 1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0 );
				float3 p = abs( frac( c.xxx + K.xyz ) * 6.0 - K.www );
				return c.z * lerp( K.xxx, saturate( p - K.xxx ), c.y );
			}
			
			float3 RGBToHSV(float3 c)
			{
				float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
				float4 p = lerp( float4( c.bg, K.wz ), float4( c.gb, K.xy ), step( c.b, c.g ) );
				float4 q = lerp( float4( p.xyw, c.r ), float4( c.r, p.yzx ), step( p.x, c.r ) );
				float d = q.x - min( q.w, q.y );
				float e = 1.0e-10;
				return float3( abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
			}
			float4 CalculateContrast( float contrastValue, float4 colorTarget )
			{
				float t = 0.5 * ( 1.0 - contrastValue );
				return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
			}

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float RootMask261 = ( 1.0 - input.texcoord2.y );
				float ifLocalVar33_g28 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g28 = 0.0;
				else
				ifLocalVar33_g28 = 1.0;
				float ifLocalVar34_g28 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g28 = 0.0;
				else
				ifLocalVar34_g28 = 1.0;
				float3 lerpResult41_g28 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g28 + ifLocalVar34_g28 ));
				float3 WindVector47_g28 = lerpResult41_g28;
				float3 objToWorld6_g29 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g28 = (( objToWorld6_g29 / 200.0 )).xz;
				float2 panner7_g28 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode11_g28 = tex2Dlod( _WindDirectionMap, float4( panner7_g28, 0, 0.0) );
				float2 RotationMapLF16_g28 = (tex2DNode11_g28).rg;
				float2 break35_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g28 = (float3(( break35_g28.x * -1.0 ) , 0.0 , break35_g28.y));
				float2 panner9_g28 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode10_g28 = tex2Dlod( _WindDirectionMap, float4( panner9_g28, 0, 0.0) );
				float2 RotationMapHF17_g28 = (tex2DNode10_g28).ba;
				float2 break36_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g28 = (float3(( break36_g28.x * -1.0 ) , 0.0 , break36_g28.y));
				float3 lerpResult48_g28 = lerp( appendResult42_g28 , appendResult43_g28 , _HFRotationMapInfluence);
				float3 lerpResult51_g28 = lerp( WindVector47_g28 , lerpResult48_g28 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g28 = lerpResult51_g28;
				#else
				float3 staticSwitch55_g28 = WindVector47_g28;
				#endif
				float3 worldToObjDir52_g28 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g28, 0.0 ) ).xyz;
				float3 WindDirection212 = worldToObjDir52_g28;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner15_g102 = ( 1.0 * _Time.y * float2( 0.02,0 ) + (( ase_positionWS / -200.0 )).xz);
				float3 objToWorld6_g102 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 panner18_g102 = ( 1.0 * _Time.y * float2( 1,0 ) + ( ( ( input.texcoord1.xy + float2( 2,2 ) ) * 50.0 ) + ( (objToWorld6_g102).xz * 1.0 ) ));
				float simplePerlin2D21_g102 = snoise( panner18_g102 );
				float temp_output_5_0_g4 = ( -1.0 * input.texcoord1.x );
				float3 appendResult14_g4 = (float3(temp_output_5_0_g4 , 0.0 , input.texcoord1.y));
				float3 PivotCoords138 = ( 0.01 * appendResult14_g4 );
				float3 rotatedValue38_g102 = RotateAroundAxis( PivotCoords138, input.positionOS.xyz, normalize( WindDirection212 ), ( ( radians( ( (  (0.3 + ( (tex2Dlod( _WindMap, float4( panner15_g102, 0, 0.0) )).r - 0.0 ) * ( 1.0 - 0.3 ) / ( 1.0 - 0.0 ) ) * 100.0 * _MainBendingStrength ) + ( simplePerlin2D21_g102 * _SecondaryBendingStrength * 30.0 ) ) ) * _WindStrength * TF_WIND_STRENGTH * TF_GRASS_WIND_STRENGTH ) * input.ase_texcoord3.x ) );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch64_g102 = ( saturate( ( _WindRootMaskOffset + RootMask261 ) ) * ( rotatedValue38_g102 - input.positionOS.xyz ) );
				#else
				float3 staticSwitch64_g102 = temp_cast_0;
				#endif
				float3 Wind342 = ( staticSwitch64_g102 * TF_EnableGrassWind );
				
				output.ase_texcoord6.xy = input.texcoord.xy;
				output.ase_texcoord6.zw = input.texcoord2.xy;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = Wind342;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif
				input.normalOS = input.normalOS;
				input.tangentOS = input.tangentOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );
				VertexNormalInputs normalInput = GetVertexNormalInputs( input.normalOS, input.tangentOS );

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

				output.positionCS = vertexInput.positionCS;
				output.positionWS = vertexInput.positionWS;
				output.normalWS = normalInput.normalWS;
				output.tangentWS = float4( normalInput.tangentWS, ( input.tangentOS.w > 0.0 ? 1.0 : -1.0 ) * GetOddNegativeScale() );
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 texcoord : TEXCOORD0;
				#if defined(LIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES1)
					float4 texcoord1 : TEXCOORD1;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES2)
					float4 texcoord2 : TEXCOORD2;
				#endif
				float4 ase_texcoord3 : TEXCOORD3;

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
				#if defined(LIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES1)
					output.texcoord1 = input.texcoord1;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES2)
					output.texcoord2 = input.texcoord2;
				#endif
				output.texcoord = input.texcoord;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				#if defined(LIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES1)
					output.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES2)
					output.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				#endif
				output.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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
						#if defined( ASE_DEPTH_WRITE_ON )
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						#ifdef _WRITE_RENDERING_LAYERS
						, out float4 outRenderingLayers : SV_Target1
						#endif
						, bool ase_vface : SV_IsFrontFace ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( input.positionCS );
				#endif

				#if defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					float4 shadowCoord = TransformWorldToShadowCoord( input.positionWS );
				#else
					float4 shadowCoord = float4(0, 0, 0, 0);
				#endif

				// @diogo: mikktspace compliant
				float renormFactor = 1.0 / max( FLT_MIN, length( input.normalWS ) );

				float3 PositionWS = input.positionWS;
				float3 PositionRWS = GetCameraRelativePositionWS( PositionWS );
				float3 ViewDirWS = GetWorldSpaceNormalizeViewDir( PositionWS );
				float4 ShadowCoord = shadowCoord;
				float4 ScreenPosNorm = float4( GetNormalizedScreenSpaceUV( input.positionCS ), input.positionCS.zw );
				float4 ClipPos = ComputeClipSpacePosition( ScreenPosNorm.xy, input.positionCS.z ) * input.positionCS.w;
				float4 ScreenPos = ComputeScreenPos( ClipPos );
				float3 TangentWS = input.tangentWS.xyz * renormFactor;
				float3 BitangentWS = cross( input.normalWS, input.tangentWS.xyz ) * input.tangentWS.w * renormFactor;
				float3 NormalWS = input.normalWS * renormFactor;

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float2 sampleCoords = (input.lightmapUVOrVertexSH.zw / _TerrainHeightmapRecipSize.zw + 0.5f) * _TerrainHeightmapRecipSize.xy;
					NormalWS = TransformObjectToWorldNormal(normalize(SAMPLE_TEXTURE2D(_TerrainNormalmapTexture, sampler_TerrainNormalmapTexture, sampleCoords).rgb * 2 - 1));
					TangentWS = -cross(GetObjectToWorldMatrix()._13_23_33, NormalWS);
					BitangentWS = cross(NormalWS, -TangentWS);
				#endif

				float2 texCoord62_g95 = input.ase_texcoord6.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g95 = tex2D( _ColorMap, texCoord62_g95 );
				float3 temp_output_12_0_g98 = tex2DNode1_g95.rgb;
				float dotResult28_g98 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g98 );
				float3 temp_cast_1 = (dotResult28_g98).xxx;
				float temp_output_21_0_g98 = _BaseColorSaturation;
				float3 lerpResult31_g98 = lerp( temp_cast_1 , temp_output_12_0_g98 , temp_output_21_0_g98);
				float3 hsvTorgb14_g97 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g98 * _BaseColorBrightness ) , 0.0 )) * _Color ).rgb );
				float3 hsvTorgb13_g97 = HSVToRGB( float3(( hsvTorgb14_g97.x + 1.0 ),hsvTorgb14_g97.y,hsvTorgb14_g97.z) );
				float3 BaseColor34 = hsvTorgb13_g97;
				float RootMask261 = ( 1.0 - input.ase_texcoord6.zw.y );
				float RootColorMask349 = saturate( ( _RootMaskStrength + RootMask261 ) );
				float4 lerpResult125 = lerp( _RootColor , float4( BaseColor34 , 0.0 ) , RootColorMask349);
				float4 Color413 = lerpResult125;
				float4 temp_output_13_0_g221 = Color413;
				float3 objToWorld6_g222 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float4 tex2DNode8_g221 = tex2D( _ColorVarianceMask, (( objToWorld6_g222 / ( TF_GrassVarianceMaskScale * _ColorVarianceMaskScale ) )).xz );
				float3 hsvTorgb3_g221 = RGBToHSV( temp_output_13_0_g221.rgb );
				float3 hsvTorgb1_g221 = HSVToRGB( float3(( ( ( _ColorVarianceBiasShift * TF_GrassVarianceBiasShift ) +  (( _ColorVarianceMin * TF_GrassVarianceMin ) + ( pow( tex2DNode8_g221.g , _MaskContrast ) - 0.0 ) * ( ( _ColorVarianceMax * TF_GrassVarianceMax ) - ( _ColorVarianceMin * TF_GrassVarianceMin ) ) / ( 1.0 - 0.0 ) ) ) + hsvTorgb3_g221.x ),hsvTorgb3_g221.y,hsvTorgb3_g221.z) );
				float4 lerpResult38_g221 = lerp( temp_output_13_0_g221 , float4( hsvTorgb1_g221 , 0.0 ) , ( _ColorVarianceIntensity * TF_GrassVarianceIntensity ));
				float Value_Mask39_g221 = tex2DNode8_g221.a;
				float4 lerpResult44_g221 = lerp( lerpResult38_g221 , ( lerpResult38_g221 * Value_Mask39_g221 ) , ( _BrightnessVarianceIntensity * TF_GrassBrightnessVariance ));
				float4 FinalValue46_g221 = lerpResult44_g221;
				#ifdef _USECOLORVARIANCE_ON
				float4 staticSwitch2_g221 = FinalValue46_g221;
				#else
				float4 staticSwitch2_g221 = temp_output_13_0_g221;
				#endif
				float lerpResult425 = lerp( RootColorMask349 , 1.0 , TF_GrassVarianceRootInfluence);
				float4 lerpResult416 = lerp( Color413 , staticSwitch2_g221 , lerpResult425);
				float4 lerpResult418 = lerp( Color413 , lerpResult416 , (float)TF_GrassVarianceEnable);
				float4 FinalColor326 = lerpResult418;
				
				float3 unpack7_g95 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g95 ), _NormalScale );
				unpack7_g95.z = lerp( 1, unpack7_g95.z, saturate(_NormalScale) );
				float3 Normal400 = unpack7_g95;
				float3x3 ase_worldToTangent = float3x3( TangentWS, BitangentWS, NormalWS );
				float3 objectToTangentDir370 = mul( ase_worldToTangent, mul( GetObjectToWorldMatrix(), float4( float3( 0, 1, 0 ), 0.0 ) ).xyz );
				float3 lerpResult371 = lerp( Normal400 , objectToTangentDir370 , _NormalYVectorInfluence);
				float3 temp_output_6_0_g220 = lerpResult371;
				float3 break1_g220 = temp_output_6_0_g220;
				float switchResult4_g220 = (((ase_vface>0)?(break1_g220.z):(-break1_g220.z)));
				float3 appendResult3_g220 = (float3(break1_g220.x , break1_g220.y , switchResult4_g220));
				#ifdef _TFW_FLIPNORMALS
				float3 staticSwitch5_g220 = appendResult3_g220;
				#else
				float3 staticSwitch5_g220 = temp_output_6_0_g220;
				#endif
				float3 FinalNormal357 = staticSwitch5_g220;
				
				float3 temp_cast_11 = (_Specular).xxx;
				
				float2 uv_MaskMap = input.ase_texcoord6.xy * _MaskMap_ST.xy + _MaskMap_ST.zw;
				float4 tex2DNode1_g96 = tex2D( _MaskMap, uv_MaskMap );
				float Smoothness358 = ( tex2DNode1_g96.a * _Smoothness );
				
				float AmbientOcclusion359 = saturate( ( tex2DNode1_g96.g - ( ( 1.0 - _AOStrength ) * -1.0 ) ) );
				
				float OpacityMap35 = tex2DNode1_g95.a;
				float lerpResult433 = lerp( _FadeDistance , ( _FadeDistance * TF_GrassFadeDistance ) , TF_GrassFadeDistance);
				float Distance_Mask290 = ( 1.0 - saturate( pow( ( distance( PositionWS , _WorldSpaceCameraPos ) / lerpResult433 ) , _FadeFalloff ) ) );
				float lerpResult297 = lerp( 0.0 , OpacityMap35 , Distance_Mask290);
				float Opacity300 = lerpResult297;
				
				float3 temp_cast_12 = (_Transmission).xxx;
				
				float3 temp_cast_13 = (( RootColorMask349 * _TranslucencyStrength )).xxx;
				

				float3 BaseColor = FinalColor326.rgb;
				float3 Normal = FinalNormal357;
				float3 Specular = temp_cast_11;
				float Metallic = 0;
				float Smoothness = Smoothness358;
				float Occlusion = AmbientOcclusion359;
				float3 Emission = 0;
				float Alpha = Opacity300;
				float AlphaClipThreshold = _MaskClip;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = temp_cast_12;
				float3 Translucency = temp_cast_13;

				#if defined( ASE_DEPTH_WRITE_ON )
					float DeviceDepth = ClipPos.z;
				#endif

				#ifdef _CLEARCOAT
					float CoatMask = 0;
					float CoatSmoothness = 0;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#if defined(MAIN_LIGHT_CALCULATE_SHADOWS) && defined(ASE_CHANGES_WORLD_POS)
					ShadowCoord = TransformWorldToShadowCoord( PositionWS );
				#endif

				InputData inputData = (InputData)0;
				inputData.positionWS = PositionWS;
				inputData.positionCS = float4( input.positionCS.xy, ClipPos.zw / ClipPos.w );
				inputData.normalizedScreenSpaceUV = ScreenPosNorm.xy;
				inputData.viewDirectionWS = ViewDirWS;
				inputData.shadowCoord = ShadowCoord;

				#ifdef _NORMALMAP
						#if _NORMAL_DROPOFF_TS
							inputData.normalWS = TransformTangentToWorld(Normal, half3x3(TangentWS, BitangentWS, NormalWS));
						#elif _NORMAL_DROPOFF_OS
							inputData.normalWS = TransformObjectToWorldNormal(Normal);
						#elif _NORMAL_DROPOFF_WS
							inputData.normalWS = Normal;
						#endif
					inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
				#else
					inputData.normalWS = NormalWS;
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

				#ifdef ASE_LIGHTING_SIMPLE
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
					float3 refractionOffset = ( RefractionIndex - 1.0 ) * mul( UNITY_MATRIX_V, float4( NormalWS,0 ) ).xyz * ( 1.0 - dot( NormalWS, ViewDirWS ) );
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

				#if defined( ASE_DEPTH_WRITE_ON )
					outputDepth = DeviceDepth;
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

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#define _NORMALMAP 1
			#define ASE_VERSION 19900
			#define ASE_SRP_VERSION 140012


			

			#pragma multi_compile_vertex _ _CASTING_PUNCTUAL_LIGHT_SHADOW

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(ASE_LIGHTING_SIMPLE)
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

			#define ASE_NEEDS_TEXTURE_COORDINATES2
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES2
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"


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
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _RootColor;
			float4 _Color;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _BrightnessVarianceIntensity;
			float _NormalScale;
			float _NormalYVectorInfluence;
			float _Specular;
			float _WindRootMaskOffset;
			float _Smoothness;
			float _AOStrength;
			float _FadeDistance;
			float _FadeFalloff;
			float _MaskClip;
			float _ColorVarianceIntensity;
			float _ColorVarianceMax;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _Transmission;
			float _ColorVarianceBiasShift;
			float _RootMaskStrength;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindStrength;
			float _SecondaryBendingStrength;
			float _MainBendingStrength;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _ColorVarianceMin;
			float _TranslucencyStrength;
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

			float3 TF_WIND_DIRECTION;
			sampler2D _WindDirectionMap;
			float TF_ROTATION_MAP_INFLUENCE;
			sampler2D _WindMap;
			float TF_WIND_STRENGTH;
			float TF_GRASS_WIND_STRENGTH;
			int TF_EnableGrassWind;
			sampler2D _ColorMap;
			float TF_GrassFadeDistance;


			float3 _LightDirection;
			float3 _LightPosition;

			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
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
			

			PackedVaryings VertexFunction( Attributes input )
			{
				PackedVaryings output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( output );

				float3 temp_cast_0 = (0.0).xxx;
				float RootMask261 = ( 1.0 - input.ase_texcoord2.y );
				float ifLocalVar33_g28 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g28 = 0.0;
				else
				ifLocalVar33_g28 = 1.0;
				float ifLocalVar34_g28 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g28 = 0.0;
				else
				ifLocalVar34_g28 = 1.0;
				float3 lerpResult41_g28 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g28 + ifLocalVar34_g28 ));
				float3 WindVector47_g28 = lerpResult41_g28;
				float3 objToWorld6_g29 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g28 = (( objToWorld6_g29 / 200.0 )).xz;
				float2 panner7_g28 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode11_g28 = tex2Dlod( _WindDirectionMap, float4( panner7_g28, 0, 0.0) );
				float2 RotationMapLF16_g28 = (tex2DNode11_g28).rg;
				float2 break35_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g28 = (float3(( break35_g28.x * -1.0 ) , 0.0 , break35_g28.y));
				float2 panner9_g28 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode10_g28 = tex2Dlod( _WindDirectionMap, float4( panner9_g28, 0, 0.0) );
				float2 RotationMapHF17_g28 = (tex2DNode10_g28).ba;
				float2 break36_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g28 = (float3(( break36_g28.x * -1.0 ) , 0.0 , break36_g28.y));
				float3 lerpResult48_g28 = lerp( appendResult42_g28 , appendResult43_g28 , _HFRotationMapInfluence);
				float3 lerpResult51_g28 = lerp( WindVector47_g28 , lerpResult48_g28 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g28 = lerpResult51_g28;
				#else
				float3 staticSwitch55_g28 = WindVector47_g28;
				#endif
				float3 worldToObjDir52_g28 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g28, 0.0 ) ).xyz;
				float3 WindDirection212 = worldToObjDir52_g28;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner15_g102 = ( 1.0 * _Time.y * float2( 0.02,0 ) + (( ase_positionWS / -200.0 )).xz);
				float3 objToWorld6_g102 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 panner18_g102 = ( 1.0 * _Time.y * float2( 1,0 ) + ( ( ( input.ase_texcoord1.xy + float2( 2,2 ) ) * 50.0 ) + ( (objToWorld6_g102).xz * 1.0 ) ));
				float simplePerlin2D21_g102 = snoise( panner18_g102 );
				float temp_output_5_0_g4 = ( -1.0 * input.ase_texcoord1.x );
				float3 appendResult14_g4 = (float3(temp_output_5_0_g4 , 0.0 , input.ase_texcoord1.y));
				float3 PivotCoords138 = ( 0.01 * appendResult14_g4 );
				float3 rotatedValue38_g102 = RotateAroundAxis( PivotCoords138, input.positionOS.xyz, normalize( WindDirection212 ), ( ( radians( ( (  (0.3 + ( (tex2Dlod( _WindMap, float4( panner15_g102, 0, 0.0) )).r - 0.0 ) * ( 1.0 - 0.3 ) / ( 1.0 - 0.0 ) ) * 100.0 * _MainBendingStrength ) + ( simplePerlin2D21_g102 * _SecondaryBendingStrength * 30.0 ) ) ) * _WindStrength * TF_WIND_STRENGTH * TF_GRASS_WIND_STRENGTH ) * input.ase_texcoord3.x ) );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch64_g102 = ( saturate( ( _WindRootMaskOffset + RootMask261 ) ) * ( rotatedValue38_g102 - input.positionOS.xyz ) );
				#else
				float3 staticSwitch64_g102 = temp_cast_0;
				#endif
				float3 Wind342 = ( staticSwitch64_g102 * TF_EnableGrassWind );
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = Wind342;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;
				input.tangentOS = input.tangentOS;

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

				output.positionCS = positionCS;
				output.positionWS = positionWS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord1 = input.ase_texcoord1;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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
						#if defined( ASE_DEPTH_WRITE_ON )
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( input );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( input );

				#if defined(MAIN_LIGHT_CALCULATE_SHADOWS) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord = TransformWorldToShadowCoord(input.positionWS);
				#else
					float4 shadowCoord = float4(0, 0, 0, 0);
				#endif

				float3 PositionWS = input.positionWS;
				float3 PositionRWS = GetCameraRelativePositionWS( input.positionWS );
				float4 ShadowCoord = shadowCoord;
				float4 ScreenPosNorm = float4( GetNormalizedScreenSpaceUV( input.positionCS ), input.positionCS.zw );
				float4 ClipPos = ComputeClipSpacePosition( ScreenPosNorm.xy, input.positionCS.z ) * input.positionCS.w;
				float4 ScreenPos = ComputeScreenPos( ClipPos );

				float2 texCoord62_g95 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g95 = tex2D( _ColorMap, texCoord62_g95 );
				float OpacityMap35 = tex2DNode1_g95.a;
				float lerpResult433 = lerp( _FadeDistance , ( _FadeDistance * TF_GrassFadeDistance ) , TF_GrassFadeDistance);
				float Distance_Mask290 = ( 1.0 - saturate( pow( ( distance( PositionWS , _WorldSpaceCameraPos ) / lerpResult433 ) , _FadeFalloff ) ) );
				float lerpResult297 = lerp( 0.0 , OpacityMap35 , Distance_Mask290);
				float Opacity300 = lerpResult297;
				

				float Alpha = Opacity300;
				float AlphaClipThreshold = _MaskClip;
				float AlphaClipThresholdShadow = 0.5;

				#if defined( ASE_DEPTH_WRITE_ON )
					float DeviceDepth = input.positionCS.z;
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

				#if defined( ASE_DEPTH_WRITE_ON )
					outputDepth = DeviceDepth;
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

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#define _NORMALMAP 1
			#define ASE_VERSION 19900
			#define ASE_SRP_VERSION 140012


			

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(ASE_LIGHTING_SIMPLE)
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

			#define ASE_NEEDS_TEXTURE_COORDINATES2
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES2
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"


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
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _RootColor;
			float4 _Color;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _BrightnessVarianceIntensity;
			float _NormalScale;
			float _NormalYVectorInfluence;
			float _Specular;
			float _WindRootMaskOffset;
			float _Smoothness;
			float _AOStrength;
			float _FadeDistance;
			float _FadeFalloff;
			float _MaskClip;
			float _ColorVarianceIntensity;
			float _ColorVarianceMax;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _Transmission;
			float _ColorVarianceBiasShift;
			float _RootMaskStrength;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindStrength;
			float _SecondaryBendingStrength;
			float _MainBendingStrength;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _ColorVarianceMin;
			float _TranslucencyStrength;
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

			float3 TF_WIND_DIRECTION;
			sampler2D _WindDirectionMap;
			float TF_ROTATION_MAP_INFLUENCE;
			sampler2D _WindMap;
			float TF_WIND_STRENGTH;
			float TF_GRASS_WIND_STRENGTH;
			int TF_EnableGrassWind;
			sampler2D _ColorMap;
			float TF_GrassFadeDistance;


			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
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
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float RootMask261 = ( 1.0 - input.ase_texcoord2.y );
				float ifLocalVar33_g28 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g28 = 0.0;
				else
				ifLocalVar33_g28 = 1.0;
				float ifLocalVar34_g28 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g28 = 0.0;
				else
				ifLocalVar34_g28 = 1.0;
				float3 lerpResult41_g28 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g28 + ifLocalVar34_g28 ));
				float3 WindVector47_g28 = lerpResult41_g28;
				float3 objToWorld6_g29 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g28 = (( objToWorld6_g29 / 200.0 )).xz;
				float2 panner7_g28 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode11_g28 = tex2Dlod( _WindDirectionMap, float4( panner7_g28, 0, 0.0) );
				float2 RotationMapLF16_g28 = (tex2DNode11_g28).rg;
				float2 break35_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g28 = (float3(( break35_g28.x * -1.0 ) , 0.0 , break35_g28.y));
				float2 panner9_g28 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode10_g28 = tex2Dlod( _WindDirectionMap, float4( panner9_g28, 0, 0.0) );
				float2 RotationMapHF17_g28 = (tex2DNode10_g28).ba;
				float2 break36_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g28 = (float3(( break36_g28.x * -1.0 ) , 0.0 , break36_g28.y));
				float3 lerpResult48_g28 = lerp( appendResult42_g28 , appendResult43_g28 , _HFRotationMapInfluence);
				float3 lerpResult51_g28 = lerp( WindVector47_g28 , lerpResult48_g28 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g28 = lerpResult51_g28;
				#else
				float3 staticSwitch55_g28 = WindVector47_g28;
				#endif
				float3 worldToObjDir52_g28 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g28, 0.0 ) ).xyz;
				float3 WindDirection212 = worldToObjDir52_g28;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner15_g102 = ( 1.0 * _Time.y * float2( 0.02,0 ) + (( ase_positionWS / -200.0 )).xz);
				float3 objToWorld6_g102 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 panner18_g102 = ( 1.0 * _Time.y * float2( 1,0 ) + ( ( ( input.ase_texcoord1.xy + float2( 2,2 ) ) * 50.0 ) + ( (objToWorld6_g102).xz * 1.0 ) ));
				float simplePerlin2D21_g102 = snoise( panner18_g102 );
				float temp_output_5_0_g4 = ( -1.0 * input.ase_texcoord1.x );
				float3 appendResult14_g4 = (float3(temp_output_5_0_g4 , 0.0 , input.ase_texcoord1.y));
				float3 PivotCoords138 = ( 0.01 * appendResult14_g4 );
				float3 rotatedValue38_g102 = RotateAroundAxis( PivotCoords138, input.positionOS.xyz, normalize( WindDirection212 ), ( ( radians( ( (  (0.3 + ( (tex2Dlod( _WindMap, float4( panner15_g102, 0, 0.0) )).r - 0.0 ) * ( 1.0 - 0.3 ) / ( 1.0 - 0.0 ) ) * 100.0 * _MainBendingStrength ) + ( simplePerlin2D21_g102 * _SecondaryBendingStrength * 30.0 ) ) ) * _WindStrength * TF_WIND_STRENGTH * TF_GRASS_WIND_STRENGTH ) * input.ase_texcoord3.x ) );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch64_g102 = ( saturate( ( _WindRootMaskOffset + RootMask261 ) ) * ( rotatedValue38_g102 - input.positionOS.xyz ) );
				#else
				float3 staticSwitch64_g102 = temp_cast_0;
				#endif
				float3 Wind342 = ( staticSwitch64_g102 * TF_EnableGrassWind );
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = Wind342;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;
				input.tangentOS = input.tangentOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );

				output.positionCS = vertexInput.positionCS;
				output.positionWS = vertexInput.positionWS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord1 = input.ase_texcoord1;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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
						#if defined( ASE_DEPTH_WRITE_ON )
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( input );

				#if defined(MAIN_LIGHT_CALCULATE_SHADOWS) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord = TransformWorldToShadowCoord(input.positionWS);
				#else
					float4 shadowCoord = float4(0, 0, 0, 0);
				#endif

				float3 PositionWS = input.positionWS;
				float3 PositionRWS = GetCameraRelativePositionWS( input.positionWS );
				float4 ShadowCoord = shadowCoord;
				float4 ScreenPosNorm = float4( GetNormalizedScreenSpaceUV( input.positionCS ), input.positionCS.zw );
				float4 ClipPos = ComputeClipSpacePosition( ScreenPosNorm.xy, input.positionCS.z ) * input.positionCS.w;
				float4 ScreenPos = ComputeScreenPos( ClipPos );

				float2 texCoord62_g95 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g95 = tex2D( _ColorMap, texCoord62_g95 );
				float OpacityMap35 = tex2DNode1_g95.a;
				float lerpResult433 = lerp( _FadeDistance , ( _FadeDistance * TF_GrassFadeDistance ) , TF_GrassFadeDistance);
				float Distance_Mask290 = ( 1.0 - saturate( pow( ( distance( PositionWS , _WorldSpaceCameraPos ) / lerpResult433 ) , _FadeFalloff ) ) );
				float lerpResult297 = lerp( 0.0 , OpacityMap35 , Distance_Mask290);
				float Opacity300 = lerpResult297;
				

				float Alpha = Opacity300;
				float AlphaClipThreshold = _MaskClip;

				#if defined( ASE_DEPTH_WRITE_ON )
					float DeviceDepth = input.positionCS.z;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( input.positionCS );
				#endif

				#if defined( ASE_DEPTH_WRITE_ON )
					outputDepth = DeviceDepth;
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
			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#define _NORMALMAP 1
			#define ASE_VERSION 19900
			#define ASE_SRP_VERSION 140012

			#pragma shader_feature EDITOR_VISUALIZATION

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(ASE_LIGHTING_SIMPLE)
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

			#define ASE_NEEDS_TEXTURE_COORDINATES2
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES2
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES2
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _USECOLORVARIANCE_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"


			struct Attributes
			{
				float4 positionOS : POSITION;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				#ifdef EDITOR_VISUALIZATION
					float4 VizUV : TEXCOORD1;
					float4 LightCoord : TEXCOORD2;
				#endif
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _RootColor;
			float4 _Color;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _BrightnessVarianceIntensity;
			float _NormalScale;
			float _NormalYVectorInfluence;
			float _Specular;
			float _WindRootMaskOffset;
			float _Smoothness;
			float _AOStrength;
			float _FadeDistance;
			float _FadeFalloff;
			float _MaskClip;
			float _ColorVarianceIntensity;
			float _ColorVarianceMax;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _Transmission;
			float _ColorVarianceBiasShift;
			float _RootMaskStrength;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindStrength;
			float _SecondaryBendingStrength;
			float _MainBendingStrength;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _ColorVarianceMin;
			float _TranslucencyStrength;
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

			float3 TF_WIND_DIRECTION;
			sampler2D _WindDirectionMap;
			float TF_ROTATION_MAP_INFLUENCE;
			sampler2D _WindMap;
			float TF_WIND_STRENGTH;
			float TF_GRASS_WIND_STRENGTH;
			int TF_EnableGrassWind;
			sampler2D _ColorMap;
			float TF_GrassVarianceBiasShift;
			sampler2D _ColorVarianceMask;
			float TF_GrassVarianceMaskScale;
			float TF_GrassVarianceMin;
			float TF_GrassVarianceMax;
			float TF_GrassVarianceIntensity;
			float TF_GrassBrightnessVariance;
			float TF_GrassVarianceRootInfluence;
			int TF_GrassVarianceEnable;
			float TF_GrassFadeDistance;


			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
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
			
			float3 HSVToRGB( float3 c )
			{
				float4 K = float4( 1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0 );
				float3 p = abs( frac( c.xxx + K.xyz ) * 6.0 - K.www );
				return c.z * lerp( K.xxx, saturate( p - K.xxx ), c.y );
			}
			
			float3 RGBToHSV(float3 c)
			{
				float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
				float4 p = lerp( float4( c.bg, K.wz ), float4( c.gb, K.xy ), step( c.b, c.g ) );
				float4 q = lerp( float4( p.xyw, c.r ), float4( c.r, p.yzx ), step( p.x, c.r ) );
				float d = q.x - min( q.w, q.y );
				float e = 1.0e-10;
				return float3( abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
			}
			float4 CalculateContrast( float contrastValue, float4 colorTarget )
			{
				float t = 0.5 * ( 1.0 - contrastValue );
				return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
			}

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float RootMask261 = ( 1.0 - input.texcoord2.y );
				float ifLocalVar33_g28 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g28 = 0.0;
				else
				ifLocalVar33_g28 = 1.0;
				float ifLocalVar34_g28 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g28 = 0.0;
				else
				ifLocalVar34_g28 = 1.0;
				float3 lerpResult41_g28 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g28 + ifLocalVar34_g28 ));
				float3 WindVector47_g28 = lerpResult41_g28;
				float3 objToWorld6_g29 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g28 = (( objToWorld6_g29 / 200.0 )).xz;
				float2 panner7_g28 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode11_g28 = tex2Dlod( _WindDirectionMap, float4( panner7_g28, 0, 0.0) );
				float2 RotationMapLF16_g28 = (tex2DNode11_g28).rg;
				float2 break35_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g28 = (float3(( break35_g28.x * -1.0 ) , 0.0 , break35_g28.y));
				float2 panner9_g28 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode10_g28 = tex2Dlod( _WindDirectionMap, float4( panner9_g28, 0, 0.0) );
				float2 RotationMapHF17_g28 = (tex2DNode10_g28).ba;
				float2 break36_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g28 = (float3(( break36_g28.x * -1.0 ) , 0.0 , break36_g28.y));
				float3 lerpResult48_g28 = lerp( appendResult42_g28 , appendResult43_g28 , _HFRotationMapInfluence);
				float3 lerpResult51_g28 = lerp( WindVector47_g28 , lerpResult48_g28 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g28 = lerpResult51_g28;
				#else
				float3 staticSwitch55_g28 = WindVector47_g28;
				#endif
				float3 worldToObjDir52_g28 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g28, 0.0 ) ).xyz;
				float3 WindDirection212 = worldToObjDir52_g28;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner15_g102 = ( 1.0 * _Time.y * float2( 0.02,0 ) + (( ase_positionWS / -200.0 )).xz);
				float3 objToWorld6_g102 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 panner18_g102 = ( 1.0 * _Time.y * float2( 1,0 ) + ( ( ( input.texcoord1.xy + float2( 2,2 ) ) * 50.0 ) + ( (objToWorld6_g102).xz * 1.0 ) ));
				float simplePerlin2D21_g102 = snoise( panner18_g102 );
				float temp_output_5_0_g4 = ( -1.0 * input.texcoord1.x );
				float3 appendResult14_g4 = (float3(temp_output_5_0_g4 , 0.0 , input.texcoord1.y));
				float3 PivotCoords138 = ( 0.01 * appendResult14_g4 );
				float3 rotatedValue38_g102 = RotateAroundAxis( PivotCoords138, input.positionOS.xyz, normalize( WindDirection212 ), ( ( radians( ( (  (0.3 + ( (tex2Dlod( _WindMap, float4( panner15_g102, 0, 0.0) )).r - 0.0 ) * ( 1.0 - 0.3 ) / ( 1.0 - 0.0 ) ) * 100.0 * _MainBendingStrength ) + ( simplePerlin2D21_g102 * _SecondaryBendingStrength * 30.0 ) ) ) * _WindStrength * TF_WIND_STRENGTH * TF_GRASS_WIND_STRENGTH ) * input.ase_texcoord3.x ) );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch64_g102 = ( saturate( ( _WindRootMaskOffset + RootMask261 ) ) * ( rotatedValue38_g102 - input.positionOS.xyz ) );
				#else
				float3 staticSwitch64_g102 = temp_cast_0;
				#endif
				float3 Wind342 = ( staticSwitch64_g102 * TF_EnableGrassWind );
				
				output.ase_texcoord3.xy = input.texcoord0.xy;
				output.ase_texcoord3.zw = input.texcoord2.xy;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = Wind342;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;
				input.tangentOS = input.tangentOS;

				#ifdef EDITOR_VISUALIZATION
					float2 VizUV = 0;
					float4 LightCoord = 0;
					UnityEditorVizData(input.positionOS.xyz, input.texcoord0.xy, input.texcoord1.xy, input.texcoord2.xy, VizUV, LightCoord);
					output.VizUV = float4(VizUV, 0, 0);
					output.LightCoord = LightCoord;
				#endif

				output.positionCS = MetaVertexPosition( input.positionOS, input.texcoord1.xy, input.texcoord1.xy, unity_LightmapST, unity_DynamicLightmapST );
				output.positionWS = TransformObjectToWorld( input.positionOS.xyz );
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord3 : TEXCOORD3;

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
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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

				#if defined(MAIN_LIGHT_CALCULATE_SHADOWS) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord = TransformWorldToShadowCoord(input.positionWS);
				#else
					float4 shadowCoord = float4(0, 0, 0, 0);
				#endif

				float3 PositionWS = input.positionWS;
				float3 PositionRWS = GetCameraRelativePositionWS( input.positionWS );
				float4 ShadowCoord = shadowCoord;

				float2 texCoord62_g95 = input.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g95 = tex2D( _ColorMap, texCoord62_g95 );
				float3 temp_output_12_0_g98 = tex2DNode1_g95.rgb;
				float dotResult28_g98 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g98 );
				float3 temp_cast_1 = (dotResult28_g98).xxx;
				float temp_output_21_0_g98 = _BaseColorSaturation;
				float3 lerpResult31_g98 = lerp( temp_cast_1 , temp_output_12_0_g98 , temp_output_21_0_g98);
				float3 hsvTorgb14_g97 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g98 * _BaseColorBrightness ) , 0.0 )) * _Color ).rgb );
				float3 hsvTorgb13_g97 = HSVToRGB( float3(( hsvTorgb14_g97.x + 1.0 ),hsvTorgb14_g97.y,hsvTorgb14_g97.z) );
				float3 BaseColor34 = hsvTorgb13_g97;
				float RootMask261 = ( 1.0 - input.ase_texcoord3.zw.y );
				float RootColorMask349 = saturate( ( _RootMaskStrength + RootMask261 ) );
				float4 lerpResult125 = lerp( _RootColor , float4( BaseColor34 , 0.0 ) , RootColorMask349);
				float4 Color413 = lerpResult125;
				float4 temp_output_13_0_g221 = Color413;
				float3 objToWorld6_g222 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float4 tex2DNode8_g221 = tex2D( _ColorVarianceMask, (( objToWorld6_g222 / ( TF_GrassVarianceMaskScale * _ColorVarianceMaskScale ) )).xz );
				float3 hsvTorgb3_g221 = RGBToHSV( temp_output_13_0_g221.rgb );
				float3 hsvTorgb1_g221 = HSVToRGB( float3(( ( ( _ColorVarianceBiasShift * TF_GrassVarianceBiasShift ) +  (( _ColorVarianceMin * TF_GrassVarianceMin ) + ( pow( tex2DNode8_g221.g , _MaskContrast ) - 0.0 ) * ( ( _ColorVarianceMax * TF_GrassVarianceMax ) - ( _ColorVarianceMin * TF_GrassVarianceMin ) ) / ( 1.0 - 0.0 ) ) ) + hsvTorgb3_g221.x ),hsvTorgb3_g221.y,hsvTorgb3_g221.z) );
				float4 lerpResult38_g221 = lerp( temp_output_13_0_g221 , float4( hsvTorgb1_g221 , 0.0 ) , ( _ColorVarianceIntensity * TF_GrassVarianceIntensity ));
				float Value_Mask39_g221 = tex2DNode8_g221.a;
				float4 lerpResult44_g221 = lerp( lerpResult38_g221 , ( lerpResult38_g221 * Value_Mask39_g221 ) , ( _BrightnessVarianceIntensity * TF_GrassBrightnessVariance ));
				float4 FinalValue46_g221 = lerpResult44_g221;
				#ifdef _USECOLORVARIANCE_ON
				float4 staticSwitch2_g221 = FinalValue46_g221;
				#else
				float4 staticSwitch2_g221 = temp_output_13_0_g221;
				#endif
				float lerpResult425 = lerp( RootColorMask349 , 1.0 , TF_GrassVarianceRootInfluence);
				float4 lerpResult416 = lerp( Color413 , staticSwitch2_g221 , lerpResult425);
				float4 lerpResult418 = lerp( Color413 , lerpResult416 , (float)TF_GrassVarianceEnable);
				float4 FinalColor326 = lerpResult418;
				
				float OpacityMap35 = tex2DNode1_g95.a;
				float lerpResult433 = lerp( _FadeDistance , ( _FadeDistance * TF_GrassFadeDistance ) , TF_GrassFadeDistance);
				float Distance_Mask290 = ( 1.0 - saturate( pow( ( distance( PositionWS , _WorldSpaceCameraPos ) / lerpResult433 ) , _FadeFalloff ) ) );
				float lerpResult297 = lerp( 0.0 , OpacityMap35 , Distance_Mask290);
				float Opacity300 = lerpResult297;
				

				float3 BaseColor = FinalColor326.rgb;
				float3 Emission = 0;
				float Alpha = Opacity300;
				float AlphaClipThreshold = _MaskClip;

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

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#define _NORMALMAP 1
			#define ASE_VERSION 19900
			#define ASE_SRP_VERSION 140012


			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(ASE_LIGHTING_SIMPLE)
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

			#define ASE_NEEDS_TEXTURE_COORDINATES2
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES2
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES2
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _USECOLORVARIANCE_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"


			struct Attributes
			{
				float4 positionOS : POSITION;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _RootColor;
			float4 _Color;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _BrightnessVarianceIntensity;
			float _NormalScale;
			float _NormalYVectorInfluence;
			float _Specular;
			float _WindRootMaskOffset;
			float _Smoothness;
			float _AOStrength;
			float _FadeDistance;
			float _FadeFalloff;
			float _MaskClip;
			float _ColorVarianceIntensity;
			float _ColorVarianceMax;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _Transmission;
			float _ColorVarianceBiasShift;
			float _RootMaskStrength;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindStrength;
			float _SecondaryBendingStrength;
			float _MainBendingStrength;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _ColorVarianceMin;
			float _TranslucencyStrength;
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

			float3 TF_WIND_DIRECTION;
			sampler2D _WindDirectionMap;
			float TF_ROTATION_MAP_INFLUENCE;
			sampler2D _WindMap;
			float TF_WIND_STRENGTH;
			float TF_GRASS_WIND_STRENGTH;
			int TF_EnableGrassWind;
			sampler2D _ColorMap;
			float TF_GrassVarianceBiasShift;
			sampler2D _ColorVarianceMask;
			float TF_GrassVarianceMaskScale;
			float TF_GrassVarianceMin;
			float TF_GrassVarianceMax;
			float TF_GrassVarianceIntensity;
			float TF_GrassBrightnessVariance;
			float TF_GrassVarianceRootInfluence;
			int TF_GrassVarianceEnable;
			float TF_GrassFadeDistance;


			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
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
			
			float3 HSVToRGB( float3 c )
			{
				float4 K = float4( 1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0 );
				float3 p = abs( frac( c.xxx + K.xyz ) * 6.0 - K.www );
				return c.z * lerp( K.xxx, saturate( p - K.xxx ), c.y );
			}
			
			float3 RGBToHSV(float3 c)
			{
				float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
				float4 p = lerp( float4( c.bg, K.wz ), float4( c.gb, K.xy ), step( c.b, c.g ) );
				float4 q = lerp( float4( p.xyw, c.r ), float4( c.r, p.yzx ), step( p.x, c.r ) );
				float d = q.x - min( q.w, q.y );
				float e = 1.0e-10;
				return float3( abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
			}
			float4 CalculateContrast( float contrastValue, float4 colorTarget )
			{
				float t = 0.5 * ( 1.0 - contrastValue );
				return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
			}

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID( input );
				UNITY_TRANSFER_INSTANCE_ID( input, output );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( output );

				float3 temp_cast_0 = (0.0).xxx;
				float RootMask261 = ( 1.0 - input.ase_texcoord2.y );
				float ifLocalVar33_g28 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g28 = 0.0;
				else
				ifLocalVar33_g28 = 1.0;
				float ifLocalVar34_g28 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g28 = 0.0;
				else
				ifLocalVar34_g28 = 1.0;
				float3 lerpResult41_g28 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g28 + ifLocalVar34_g28 ));
				float3 WindVector47_g28 = lerpResult41_g28;
				float3 objToWorld6_g29 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g28 = (( objToWorld6_g29 / 200.0 )).xz;
				float2 panner7_g28 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode11_g28 = tex2Dlod( _WindDirectionMap, float4( panner7_g28, 0, 0.0) );
				float2 RotationMapLF16_g28 = (tex2DNode11_g28).rg;
				float2 break35_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g28 = (float3(( break35_g28.x * -1.0 ) , 0.0 , break35_g28.y));
				float2 panner9_g28 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode10_g28 = tex2Dlod( _WindDirectionMap, float4( panner9_g28, 0, 0.0) );
				float2 RotationMapHF17_g28 = (tex2DNode10_g28).ba;
				float2 break36_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g28 = (float3(( break36_g28.x * -1.0 ) , 0.0 , break36_g28.y));
				float3 lerpResult48_g28 = lerp( appendResult42_g28 , appendResult43_g28 , _HFRotationMapInfluence);
				float3 lerpResult51_g28 = lerp( WindVector47_g28 , lerpResult48_g28 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g28 = lerpResult51_g28;
				#else
				float3 staticSwitch55_g28 = WindVector47_g28;
				#endif
				float3 worldToObjDir52_g28 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g28, 0.0 ) ).xyz;
				float3 WindDirection212 = worldToObjDir52_g28;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner15_g102 = ( 1.0 * _Time.y * float2( 0.02,0 ) + (( ase_positionWS / -200.0 )).xz);
				float3 objToWorld6_g102 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 panner18_g102 = ( 1.0 * _Time.y * float2( 1,0 ) + ( ( ( input.ase_texcoord1.xy + float2( 2,2 ) ) * 50.0 ) + ( (objToWorld6_g102).xz * 1.0 ) ));
				float simplePerlin2D21_g102 = snoise( panner18_g102 );
				float temp_output_5_0_g4 = ( -1.0 * input.ase_texcoord1.x );
				float3 appendResult14_g4 = (float3(temp_output_5_0_g4 , 0.0 , input.ase_texcoord1.y));
				float3 PivotCoords138 = ( 0.01 * appendResult14_g4 );
				float3 rotatedValue38_g102 = RotateAroundAxis( PivotCoords138, input.positionOS.xyz, normalize( WindDirection212 ), ( ( radians( ( (  (0.3 + ( (tex2Dlod( _WindMap, float4( panner15_g102, 0, 0.0) )).r - 0.0 ) * ( 1.0 - 0.3 ) / ( 1.0 - 0.0 ) ) * 100.0 * _MainBendingStrength ) + ( simplePerlin2D21_g102 * _SecondaryBendingStrength * 30.0 ) ) ) * _WindStrength * TF_WIND_STRENGTH * TF_GRASS_WIND_STRENGTH ) * input.ase_texcoord3.x ) );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch64_g102 = ( saturate( ( _WindRootMaskOffset + RootMask261 ) ) * ( rotatedValue38_g102 - input.positionOS.xyz ) );
				#else
				float3 staticSwitch64_g102 = temp_cast_0;
				#endif
				float3 Wind342 = ( staticSwitch64_g102 * TF_EnableGrassWind );
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				output.ase_texcoord1.zw = input.ase_texcoord2.xy;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = Wind342;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;
				input.tangentOS = input.tangentOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );

				output.positionCS = vertexInput.positionCS;
				output.positionWS = vertexInput.positionWS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord1 = input.ase_texcoord1;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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

				#if defined(MAIN_LIGHT_CALCULATE_SHADOWS) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord = TransformWorldToShadowCoord(input.positionWS);
				#else
					float4 shadowCoord = float4(0, 0, 0, 0);
				#endif

				float3 PositionWS = input.positionWS;
				float3 PositionRWS = GetCameraRelativePositionWS( input.positionWS );
				float4 ShadowCoord = shadowCoord;

				float2 texCoord62_g95 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g95 = tex2D( _ColorMap, texCoord62_g95 );
				float3 temp_output_12_0_g98 = tex2DNode1_g95.rgb;
				float dotResult28_g98 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g98 );
				float3 temp_cast_1 = (dotResult28_g98).xxx;
				float temp_output_21_0_g98 = _BaseColorSaturation;
				float3 lerpResult31_g98 = lerp( temp_cast_1 , temp_output_12_0_g98 , temp_output_21_0_g98);
				float3 hsvTorgb14_g97 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g98 * _BaseColorBrightness ) , 0.0 )) * _Color ).rgb );
				float3 hsvTorgb13_g97 = HSVToRGB( float3(( hsvTorgb14_g97.x + 1.0 ),hsvTorgb14_g97.y,hsvTorgb14_g97.z) );
				float3 BaseColor34 = hsvTorgb13_g97;
				float RootMask261 = ( 1.0 - input.ase_texcoord1.zw.y );
				float RootColorMask349 = saturate( ( _RootMaskStrength + RootMask261 ) );
				float4 lerpResult125 = lerp( _RootColor , float4( BaseColor34 , 0.0 ) , RootColorMask349);
				float4 Color413 = lerpResult125;
				float4 temp_output_13_0_g221 = Color413;
				float3 objToWorld6_g222 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float4 tex2DNode8_g221 = tex2D( _ColorVarianceMask, (( objToWorld6_g222 / ( TF_GrassVarianceMaskScale * _ColorVarianceMaskScale ) )).xz );
				float3 hsvTorgb3_g221 = RGBToHSV( temp_output_13_0_g221.rgb );
				float3 hsvTorgb1_g221 = HSVToRGB( float3(( ( ( _ColorVarianceBiasShift * TF_GrassVarianceBiasShift ) +  (( _ColorVarianceMin * TF_GrassVarianceMin ) + ( pow( tex2DNode8_g221.g , _MaskContrast ) - 0.0 ) * ( ( _ColorVarianceMax * TF_GrassVarianceMax ) - ( _ColorVarianceMin * TF_GrassVarianceMin ) ) / ( 1.0 - 0.0 ) ) ) + hsvTorgb3_g221.x ),hsvTorgb3_g221.y,hsvTorgb3_g221.z) );
				float4 lerpResult38_g221 = lerp( temp_output_13_0_g221 , float4( hsvTorgb1_g221 , 0.0 ) , ( _ColorVarianceIntensity * TF_GrassVarianceIntensity ));
				float Value_Mask39_g221 = tex2DNode8_g221.a;
				float4 lerpResult44_g221 = lerp( lerpResult38_g221 , ( lerpResult38_g221 * Value_Mask39_g221 ) , ( _BrightnessVarianceIntensity * TF_GrassBrightnessVariance ));
				float4 FinalValue46_g221 = lerpResult44_g221;
				#ifdef _USECOLORVARIANCE_ON
				float4 staticSwitch2_g221 = FinalValue46_g221;
				#else
				float4 staticSwitch2_g221 = temp_output_13_0_g221;
				#endif
				float lerpResult425 = lerp( RootColorMask349 , 1.0 , TF_GrassVarianceRootInfluence);
				float4 lerpResult416 = lerp( Color413 , staticSwitch2_g221 , lerpResult425);
				float4 lerpResult418 = lerp( Color413 , lerpResult416 , (float)TF_GrassVarianceEnable);
				float4 FinalColor326 = lerpResult418;
				
				float OpacityMap35 = tex2DNode1_g95.a;
				float lerpResult433 = lerp( _FadeDistance , ( _FadeDistance * TF_GrassFadeDistance ) , TF_GrassFadeDistance);
				float Distance_Mask290 = ( 1.0 - saturate( pow( ( distance( PositionWS , _WorldSpaceCameraPos ) / lerpResult433 ) , _FadeFalloff ) ) );
				float lerpResult297 = lerp( 0.0 , OpacityMap35 , Distance_Mask290);
				float Opacity300 = lerpResult297;
				

				float3 BaseColor = FinalColor326.rgb;
				float Alpha = Opacity300;
				float AlphaClipThreshold = _MaskClip;

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
			Tags { "LightMode"="DepthNormalsOnly" }

			ZWrite On
			Blend One Zero
			ZTest LEqual
			ZWrite On

			HLSLPROGRAM

			

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#define _NORMALMAP 1
			#define ASE_VERSION 19900
			#define ASE_SRP_VERSION 140012


			

			

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(ASE_LIGHTING_SIMPLE)
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

			#define ASE_NEEDS_TEXTURE_COORDINATES2
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES2
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature _TFW_FLIPNORMALS
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"


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
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				float3 normalWS : TEXCOORD1;
				half4 tangentWS : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _RootColor;
			float4 _Color;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _BrightnessVarianceIntensity;
			float _NormalScale;
			float _NormalYVectorInfluence;
			float _Specular;
			float _WindRootMaskOffset;
			float _Smoothness;
			float _AOStrength;
			float _FadeDistance;
			float _FadeFalloff;
			float _MaskClip;
			float _ColorVarianceIntensity;
			float _ColorVarianceMax;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _Transmission;
			float _ColorVarianceBiasShift;
			float _RootMaskStrength;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindStrength;
			float _SecondaryBendingStrength;
			float _MainBendingStrength;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _ColorVarianceMin;
			float _TranslucencyStrength;
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

			float3 TF_WIND_DIRECTION;
			sampler2D _WindDirectionMap;
			float TF_ROTATION_MAP_INFLUENCE;
			sampler2D _WindMap;
			float TF_WIND_STRENGTH;
			float TF_GRASS_WIND_STRENGTH;
			int TF_EnableGrassWind;
			sampler2D _NormalMap;
			sampler2D _ColorMap;
			float TF_GrassFadeDistance;


			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
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
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float RootMask261 = ( 1.0 - input.ase_texcoord2.y );
				float ifLocalVar33_g28 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g28 = 0.0;
				else
				ifLocalVar33_g28 = 1.0;
				float ifLocalVar34_g28 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g28 = 0.0;
				else
				ifLocalVar34_g28 = 1.0;
				float3 lerpResult41_g28 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g28 + ifLocalVar34_g28 ));
				float3 WindVector47_g28 = lerpResult41_g28;
				float3 objToWorld6_g29 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g28 = (( objToWorld6_g29 / 200.0 )).xz;
				float2 panner7_g28 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode11_g28 = tex2Dlod( _WindDirectionMap, float4( panner7_g28, 0, 0.0) );
				float2 RotationMapLF16_g28 = (tex2DNode11_g28).rg;
				float2 break35_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g28 = (float3(( break35_g28.x * -1.0 ) , 0.0 , break35_g28.y));
				float2 panner9_g28 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode10_g28 = tex2Dlod( _WindDirectionMap, float4( panner9_g28, 0, 0.0) );
				float2 RotationMapHF17_g28 = (tex2DNode10_g28).ba;
				float2 break36_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g28 = (float3(( break36_g28.x * -1.0 ) , 0.0 , break36_g28.y));
				float3 lerpResult48_g28 = lerp( appendResult42_g28 , appendResult43_g28 , _HFRotationMapInfluence);
				float3 lerpResult51_g28 = lerp( WindVector47_g28 , lerpResult48_g28 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g28 = lerpResult51_g28;
				#else
				float3 staticSwitch55_g28 = WindVector47_g28;
				#endif
				float3 worldToObjDir52_g28 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g28, 0.0 ) ).xyz;
				float3 WindDirection212 = worldToObjDir52_g28;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner15_g102 = ( 1.0 * _Time.y * float2( 0.02,0 ) + (( ase_positionWS / -200.0 )).xz);
				float3 objToWorld6_g102 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 panner18_g102 = ( 1.0 * _Time.y * float2( 1,0 ) + ( ( ( input.ase_texcoord1.xy + float2( 2,2 ) ) * 50.0 ) + ( (objToWorld6_g102).xz * 1.0 ) ));
				float simplePerlin2D21_g102 = snoise( panner18_g102 );
				float temp_output_5_0_g4 = ( -1.0 * input.ase_texcoord1.x );
				float3 appendResult14_g4 = (float3(temp_output_5_0_g4 , 0.0 , input.ase_texcoord1.y));
				float3 PivotCoords138 = ( 0.01 * appendResult14_g4 );
				float3 rotatedValue38_g102 = RotateAroundAxis( PivotCoords138, input.positionOS.xyz, normalize( WindDirection212 ), ( ( radians( ( (  (0.3 + ( (tex2Dlod( _WindMap, float4( panner15_g102, 0, 0.0) )).r - 0.0 ) * ( 1.0 - 0.3 ) / ( 1.0 - 0.0 ) ) * 100.0 * _MainBendingStrength ) + ( simplePerlin2D21_g102 * _SecondaryBendingStrength * 30.0 ) ) ) * _WindStrength * TF_WIND_STRENGTH * TF_GRASS_WIND_STRENGTH ) * input.ase_texcoord3.x ) );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch64_g102 = ( saturate( ( _WindRootMaskOffset + RootMask261 ) ) * ( rotatedValue38_g102 - input.positionOS.xyz ) );
				#else
				float3 staticSwitch64_g102 = temp_cast_0;
				#endif
				float3 Wind342 = ( staticSwitch64_g102 * TF_EnableGrassWind );
				
				output.ase_texcoord3.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord3.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = Wind342;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;
				input.tangentOS = input.tangentOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );
				VertexNormalInputs normalInput = GetVertexNormalInputs( input.normalOS, input.tangentOS );

				output.positionCS = vertexInput.positionCS;
				output.positionWS = vertexInput.positionWS;
				output.normalWS = normalInput.normalWS;
				output.tangentWS = float4( normalInput.tangentWS, ( input.tangentOS.w > 0.0 ? 1.0 : -1.0 ) * GetOddNegativeScale() );
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord1 = input.ase_texcoord1;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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
						#if defined( ASE_DEPTH_WRITE_ON )
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						#ifdef _WRITE_RENDERING_LAYERS
						, out float4 outRenderingLayers : SV_Target1
						#endif
						, bool ase_vface : SV_IsFrontFace )
			{
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( input );

				#if defined(MAIN_LIGHT_CALCULATE_SHADOWS) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord = TransformWorldToShadowCoord(input.positionWS);
				#else
					float4 shadowCoord = float4(0, 0, 0, 0);
				#endif

				// @diogo: mikktspace compliant
				float renormFactor = 1.0 / max( FLT_MIN, length( input.normalWS ) );

				float3 PositionWS = input.positionWS;
				float3 PositionRWS = GetCameraRelativePositionWS( input.positionWS );
				float4 ShadowCoord = shadowCoord;
				float4 ScreenPosNorm = float4( GetNormalizedScreenSpaceUV( input.positionCS ), input.positionCS.zw );
				float4 ClipPos = ComputeClipSpacePosition( ScreenPosNorm.xy, input.positionCS.z ) * input.positionCS.w;
				float4 ScreenPos = ComputeScreenPos( ClipPos );
				float3 TangentWS = input.tangentWS.xyz * renormFactor;
				float3 BitangentWS = cross( input.normalWS, input.tangentWS.xyz ) * input.tangentWS.w * renormFactor;
				float3 NormalWS = input.normalWS * renormFactor;

				float2 texCoord62_g95 = input.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack7_g95 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g95 ), _NormalScale );
				unpack7_g95.z = lerp( 1, unpack7_g95.z, saturate(_NormalScale) );
				float3 Normal400 = unpack7_g95;
				float3x3 ase_worldToTangent = float3x3( TangentWS, BitangentWS, NormalWS );
				float3 objectToTangentDir370 = mul( ase_worldToTangent, mul( GetObjectToWorldMatrix(), float4( float3( 0, 1, 0 ), 0.0 ) ).xyz );
				float3 lerpResult371 = lerp( Normal400 , objectToTangentDir370 , _NormalYVectorInfluence);
				float3 temp_output_6_0_g220 = lerpResult371;
				float3 break1_g220 = temp_output_6_0_g220;
				float switchResult4_g220 = (((ase_vface>0)?(break1_g220.z):(-break1_g220.z)));
				float3 appendResult3_g220 = (float3(break1_g220.x , break1_g220.y , switchResult4_g220));
				#ifdef _TFW_FLIPNORMALS
				float3 staticSwitch5_g220 = appendResult3_g220;
				#else
				float3 staticSwitch5_g220 = temp_output_6_0_g220;
				#endif
				float3 FinalNormal357 = staticSwitch5_g220;
				
				float4 tex2DNode1_g95 = tex2D( _ColorMap, texCoord62_g95 );
				float OpacityMap35 = tex2DNode1_g95.a;
				float lerpResult433 = lerp( _FadeDistance , ( _FadeDistance * TF_GrassFadeDistance ) , TF_GrassFadeDistance);
				float Distance_Mask290 = ( 1.0 - saturate( pow( ( distance( PositionWS , _WorldSpaceCameraPos ) / lerpResult433 ) , _FadeFalloff ) ) );
				float lerpResult297 = lerp( 0.0 , OpacityMap35 , Distance_Mask290);
				float Opacity300 = lerpResult297;
				

				float3 Normal = FinalNormal357;
				float Alpha = Opacity300;
				float AlphaClipThreshold = _MaskClip;

				#if defined( ASE_DEPTH_WRITE_ON )
					float DeviceDepth = input.positionCS.z;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( input.positionCS );
				#endif

				#if defined( ASE_DEPTH_WRITE_ON )
					outputDepth = DeviceDepth;
				#endif

				#if defined(_GBUFFER_NORMALS_OCT)
					float2 octNormalWS = PackNormalOctQuadEncode(NormalWS);
					float2 remappedOctNormalWS = saturate(octNormalWS * 0.5 + 0.5);
					half3 packedNormalWS = PackFloat2To888(remappedOctNormalWS);
					outNormalWS = half4(packedNormalWS, 0.0);
				#else
					#if defined(_NORMALMAP)
						#if _NORMAL_DROPOFF_TS
							float3 normalWS = TransformTangentToWorld(Normal, half3x3(TangentWS, BitangentWS, NormalWS));
						#elif _NORMAL_DROPOFF_OS
							float3 normalWS = TransformObjectToWorldNormal(Normal);
						#elif _NORMAL_DROPOFF_WS
							float3 normalWS = Normal;
						#endif
					#else
						float3 normalWS = NormalWS;
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
			
			Name "SceneSelectionPass"
			Tags { "LightMode"="SceneSelectionPass" }

			Cull Off
			AlphaToMask Off

			HLSLPROGRAM

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#define _NORMALMAP 1
			#define ASE_VERSION 19900
			#define ASE_SRP_VERSION 140012


			

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(ASE_LIGHTING_SIMPLE)
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

			#define ASE_NEEDS_TEXTURE_COORDINATES2
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES2
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"


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
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _RootColor;
			float4 _Color;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _BrightnessVarianceIntensity;
			float _NormalScale;
			float _NormalYVectorInfluence;
			float _Specular;
			float _WindRootMaskOffset;
			float _Smoothness;
			float _AOStrength;
			float _FadeDistance;
			float _FadeFalloff;
			float _MaskClip;
			float _ColorVarianceIntensity;
			float _ColorVarianceMax;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _Transmission;
			float _ColorVarianceBiasShift;
			float _RootMaskStrength;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindStrength;
			float _SecondaryBendingStrength;
			float _MainBendingStrength;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _ColorVarianceMin;
			float _TranslucencyStrength;
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

			float3 TF_WIND_DIRECTION;
			sampler2D _WindDirectionMap;
			float TF_ROTATION_MAP_INFLUENCE;
			sampler2D _WindMap;
			float TF_WIND_STRENGTH;
			float TF_GRASS_WIND_STRENGTH;
			int TF_EnableGrassWind;
			sampler2D _ColorMap;
			float TF_GrassFadeDistance;


			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
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
				float RootMask261 = ( 1.0 - input.ase_texcoord2.y );
				float ifLocalVar33_g28 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g28 = 0.0;
				else
				ifLocalVar33_g28 = 1.0;
				float ifLocalVar34_g28 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g28 = 0.0;
				else
				ifLocalVar34_g28 = 1.0;
				float3 lerpResult41_g28 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g28 + ifLocalVar34_g28 ));
				float3 WindVector47_g28 = lerpResult41_g28;
				float3 objToWorld6_g29 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g28 = (( objToWorld6_g29 / 200.0 )).xz;
				float2 panner7_g28 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode11_g28 = tex2Dlod( _WindDirectionMap, float4( panner7_g28, 0, 0.0) );
				float2 RotationMapLF16_g28 = (tex2DNode11_g28).rg;
				float2 break35_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g28 = (float3(( break35_g28.x * -1.0 ) , 0.0 , break35_g28.y));
				float2 panner9_g28 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode10_g28 = tex2Dlod( _WindDirectionMap, float4( panner9_g28, 0, 0.0) );
				float2 RotationMapHF17_g28 = (tex2DNode10_g28).ba;
				float2 break36_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g28 = (float3(( break36_g28.x * -1.0 ) , 0.0 , break36_g28.y));
				float3 lerpResult48_g28 = lerp( appendResult42_g28 , appendResult43_g28 , _HFRotationMapInfluence);
				float3 lerpResult51_g28 = lerp( WindVector47_g28 , lerpResult48_g28 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g28 = lerpResult51_g28;
				#else
				float3 staticSwitch55_g28 = WindVector47_g28;
				#endif
				float3 worldToObjDir52_g28 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g28, 0.0 ) ).xyz;
				float3 WindDirection212 = worldToObjDir52_g28;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner15_g102 = ( 1.0 * _Time.y * float2( 0.02,0 ) + (( ase_positionWS / -200.0 )).xz);
				float3 objToWorld6_g102 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 panner18_g102 = ( 1.0 * _Time.y * float2( 1,0 ) + ( ( ( input.ase_texcoord1.xy + float2( 2,2 ) ) * 50.0 ) + ( (objToWorld6_g102).xz * 1.0 ) ));
				float simplePerlin2D21_g102 = snoise( panner18_g102 );
				float temp_output_5_0_g4 = ( -1.0 * input.ase_texcoord1.x );
				float3 appendResult14_g4 = (float3(temp_output_5_0_g4 , 0.0 , input.ase_texcoord1.y));
				float3 PivotCoords138 = ( 0.01 * appendResult14_g4 );
				float3 rotatedValue38_g102 = RotateAroundAxis( PivotCoords138, input.positionOS.xyz, normalize( WindDirection212 ), ( ( radians( ( (  (0.3 + ( (tex2Dlod( _WindMap, float4( panner15_g102, 0, 0.0) )).r - 0.0 ) * ( 1.0 - 0.3 ) / ( 1.0 - 0.0 ) ) * 100.0 * _MainBendingStrength ) + ( simplePerlin2D21_g102 * _SecondaryBendingStrength * 30.0 ) ) ) * _WindStrength * TF_WIND_STRENGTH * TF_GRASS_WIND_STRENGTH ) * input.ase_texcoord3.x ) );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch64_g102 = ( saturate( ( _WindRootMaskOffset + RootMask261 ) ) * ( rotatedValue38_g102 - input.positionOS.xyz ) );
				#else
				float3 staticSwitch64_g102 = temp_cast_0;
				#endif
				float3 Wind342 = ( staticSwitch64_g102 * TF_EnableGrassWind );
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = Wind342;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );

				output.positionCS = vertexInput.positionCS;
				output.positionWS = vertexInput.positionWS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord1 = input.ase_texcoord1;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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

			half4 frag( PackedVaryings input
				#if defined( ASE_DEPTH_WRITE_ON )
				,out float outputDepth : ASE_SV_DEPTH
				#endif
				 ) : SV_Target
			{
				SurfaceDescription surfaceDescription = (SurfaceDescription)0;

				float3 PositionWS = input.positionWS;
				float3 PositionRWS = GetCameraRelativePositionWS( PositionWS );
				float4 ScreenPosNorm = float4( GetNormalizedScreenSpaceUV( input.positionCS ), input.positionCS.zw );
				float4 ClipPos = ComputeClipSpacePosition( ScreenPosNorm.xy, input.positionCS.z ) * input.positionCS.w;

				float2 texCoord62_g95 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g95 = tex2D( _ColorMap, texCoord62_g95 );
				float OpacityMap35 = tex2DNode1_g95.a;
				float lerpResult433 = lerp( _FadeDistance , ( _FadeDistance * TF_GrassFadeDistance ) , TF_GrassFadeDistance);
				float Distance_Mask290 = ( 1.0 - saturate( pow( ( distance( PositionWS , _WorldSpaceCameraPos ) / lerpResult433 ) , _FadeFalloff ) ) );
				float lerpResult297 = lerp( 0.0 , OpacityMap35 , Distance_Mask290);
				float Opacity300 = lerpResult297;
				

				surfaceDescription.Alpha = Opacity300;
				surfaceDescription.AlphaClipThreshold = _MaskClip;

				#if defined( ASE_DEPTH_WRITE_ON )
					float DeviceDepth = input.positionCS.z;
				#endif

				#if _ALPHATEST_ON
					float alphaClipThreshold = 0.01f;
					#if ALPHA_CLIP_THRESHOLD
						alphaClipThreshold = surfaceDescription.AlphaClipThreshold;
					#endif
					clip(surfaceDescription.Alpha - alphaClipThreshold);
				#endif

				#if defined( ASE_DEPTH_WRITE_ON )
					outputDepth = DeviceDepth;
				#endif

				return half4( _ObjectId, _PassValue, 1.0, 1.0 );
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "ScenePickingPass"
			Tags { "LightMode"="Picking" }

			AlphaToMask Off

			HLSLPROGRAM

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#define _NORMALMAP 1
			#define ASE_VERSION 19900
			#define ASE_SRP_VERSION 140012


			

			#pragma vertex vert
			#pragma fragment frag

			#if defined(_SPECULAR_SETUP) && defined(ASE_LIGHTING_SIMPLE)
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

			#define ASE_NEEDS_TEXTURE_COORDINATES2
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES2
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"


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
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _RootColor;
			float4 _Color;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _BrightnessVarianceIntensity;
			float _NormalScale;
			float _NormalYVectorInfluence;
			float _Specular;
			float _WindRootMaskOffset;
			float _Smoothness;
			float _AOStrength;
			float _FadeDistance;
			float _FadeFalloff;
			float _MaskClip;
			float _ColorVarianceIntensity;
			float _ColorVarianceMax;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _Transmission;
			float _ColorVarianceBiasShift;
			float _RootMaskStrength;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindStrength;
			float _SecondaryBendingStrength;
			float _MainBendingStrength;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _ColorVarianceMin;
			float _TranslucencyStrength;
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

			float3 TF_WIND_DIRECTION;
			sampler2D _WindDirectionMap;
			float TF_ROTATION_MAP_INFLUENCE;
			sampler2D _WindMap;
			float TF_WIND_STRENGTH;
			float TF_GRASS_WIND_STRENGTH;
			int TF_EnableGrassWind;
			sampler2D _ColorMap;
			float TF_GrassFadeDistance;


			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
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
			

			struct SurfaceDescription
			{
				float Alpha;
				float AlphaClipThreshold;
			};

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output;
				ZERO_INITIALIZE(PackedVaryings, output);

				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float RootMask261 = ( 1.0 - input.ase_texcoord2.y );
				float ifLocalVar33_g28 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g28 = 0.0;
				else
				ifLocalVar33_g28 = 1.0;
				float ifLocalVar34_g28 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g28 = 0.0;
				else
				ifLocalVar34_g28 = 1.0;
				float3 lerpResult41_g28 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g28 + ifLocalVar34_g28 ));
				float3 WindVector47_g28 = lerpResult41_g28;
				float3 objToWorld6_g29 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g28 = (( objToWorld6_g29 / 200.0 )).xz;
				float2 panner7_g28 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode11_g28 = tex2Dlod( _WindDirectionMap, float4( panner7_g28, 0, 0.0) );
				float2 RotationMapLF16_g28 = (tex2DNode11_g28).rg;
				float2 break35_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g28 = (float3(( break35_g28.x * -1.0 ) , 0.0 , break35_g28.y));
				float2 panner9_g28 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g28);
				float4 tex2DNode10_g28 = tex2Dlod( _WindDirectionMap, float4( panner9_g28, 0, 0.0) );
				float2 RotationMapHF17_g28 = (tex2DNode10_g28).ba;
				float2 break36_g28 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g28 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g28 = (float3(( break36_g28.x * -1.0 ) , 0.0 , break36_g28.y));
				float3 lerpResult48_g28 = lerp( appendResult42_g28 , appendResult43_g28 , _HFRotationMapInfluence);
				float3 lerpResult51_g28 = lerp( WindVector47_g28 , lerpResult48_g28 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g28 = lerpResult51_g28;
				#else
				float3 staticSwitch55_g28 = WindVector47_g28;
				#endif
				float3 worldToObjDir52_g28 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g28, 0.0 ) ).xyz;
				float3 WindDirection212 = worldToObjDir52_g28;
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner15_g102 = ( 1.0 * _Time.y * float2( 0.02,0 ) + (( ase_positionWS / -200.0 )).xz);
				float3 objToWorld6_g102 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 panner18_g102 = ( 1.0 * _Time.y * float2( 1,0 ) + ( ( ( input.ase_texcoord1.xy + float2( 2,2 ) ) * 50.0 ) + ( (objToWorld6_g102).xz * 1.0 ) ));
				float simplePerlin2D21_g102 = snoise( panner18_g102 );
				float temp_output_5_0_g4 = ( -1.0 * input.ase_texcoord1.x );
				float3 appendResult14_g4 = (float3(temp_output_5_0_g4 , 0.0 , input.ase_texcoord1.y));
				float3 PivotCoords138 = ( 0.01 * appendResult14_g4 );
				float3 rotatedValue38_g102 = RotateAroundAxis( PivotCoords138, input.positionOS.xyz, normalize( WindDirection212 ), ( ( radians( ( (  (0.3 + ( (tex2Dlod( _WindMap, float4( panner15_g102, 0, 0.0) )).r - 0.0 ) * ( 1.0 - 0.3 ) / ( 1.0 - 0.0 ) ) * 100.0 * _MainBendingStrength ) + ( simplePerlin2D21_g102 * _SecondaryBendingStrength * 30.0 ) ) ) * _WindStrength * TF_WIND_STRENGTH * TF_GRASS_WIND_STRENGTH ) * input.ase_texcoord3.x ) );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch64_g102 = ( saturate( ( _WindRootMaskOffset + RootMask261 ) ) * ( rotatedValue38_g102 - input.positionOS.xyz ) );
				#else
				float3 staticSwitch64_g102 = temp_cast_0;
				#endif
				float3 Wind342 = ( staticSwitch64_g102 * TF_EnableGrassWind );
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = Wind342;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					input.positionOS.xyz = vertexValue;
				#else
					input.positionOS.xyz += vertexValue;
				#endif

				input.normalOS = input.normalOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( input.positionOS.xyz );

				output.positionCS = vertexInput.positionCS;
				output.positionWS = vertexInput.positionWS;
				return output;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 positionOS : INTERNALTESSPOS;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord1 = input.ase_texcoord1;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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

			half4 frag( PackedVaryings input
				#if defined( ASE_DEPTH_WRITE_ON )
				,out float outputDepth : ASE_SV_DEPTH
				#endif
				 ) : SV_Target
			{
				SurfaceDescription surfaceDescription = (SurfaceDescription)0;

				float3 PositionWS = input.positionWS;
				float3 PositionRWS = GetCameraRelativePositionWS( PositionWS );
				float4 ScreenPosNorm = float4( GetNormalizedScreenSpaceUV( input.positionCS ), input.positionCS.zw );
				float4 ClipPos = ComputeClipSpacePosition( ScreenPosNorm.xy, input.positionCS.z ) * input.positionCS.w;

				float2 texCoord62_g95 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g95 = tex2D( _ColorMap, texCoord62_g95 );
				float OpacityMap35 = tex2DNode1_g95.a;
				float lerpResult433 = lerp( _FadeDistance , ( _FadeDistance * TF_GrassFadeDistance ) , TF_GrassFadeDistance);
				float Distance_Mask290 = ( 1.0 - saturate( pow( ( distance( PositionWS , _WorldSpaceCameraPos ) / lerpResult433 ) , _FadeFalloff ) ) );
				float lerpResult297 = lerp( 0.0 , OpacityMap35 , Distance_Mask290);
				float Opacity300 = lerpResult297;
				

				surfaceDescription.Alpha = Opacity300;
				surfaceDescription.AlphaClipThreshold = _MaskClip;

				#if defined( ASE_DEPTH_WRITE_ON )
					float DeviceDepth = input.positionCS.z;
				#endif

				#if _ALPHATEST_ON
					float alphaClipThreshold = 0.01f;
					#if ALPHA_CLIP_THRESHOLD
						alphaClipThreshold = surfaceDescription.AlphaClipThreshold;
					#endif
						clip(surfaceDescription.Alpha - alphaClipThreshold);
				#endif

				#if defined( ASE_DEPTH_WRITE_ON )
					outputDepth = DeviceDepth;
				#endif

				return _SelectionID;
			}
			ENDHLSL
		}
		
	}
	
	CustomEditor "UnityEditor.ShaderGraphLitGUI"
	FallBack "Hidden/Shader Graph/FallbackError"
	
	Fallback Off
}

/*ASEBEGIN
Version=19900
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;353;-2448,-1392;Inherit;False;2841.857;1795.137;Comment;14;342;265;395;348;339;338;337;366;50;331;351;352;431;432;Wind;0.3981131,0.7896479,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;307;-2448,-2112;Inherit;False;1927.333;674.0164;Comment;16;397;300;297;290;296;292;294;293;295;287;396;286;288;285;284;433;Distance Fade;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;352;-2272,-704;Inherit;False;612;501;Comment;4;155;225;154;165;Wind Maps;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;288;-2320,-1744;Inherit;False;Property;_FadeDistance;Fade Distance;24;0;Create;True;0;0;0;False;0;False;30;30;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;397;-2384,-1648;Inherit;False;Global;TF_GrassFadeDistance;TF_GrassFadeDistance;25;0;Create;True;0;0;0;False;0;False;1;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceCameraPos, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;284;-2384,-1904;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldPosInputsNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;285;-2352,-2048;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;155;-2224,-432;Inherit;True;Property;_WindDirectionMap;Wind Direction Map;30;1;[SingleLineTexture];Create;True;0;0;0;False;0;False;65ab1e588993cfb4ea2a248548b02eaf;65ab1e588993cfb4ea2a248548b02eaf;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;396;-2080,-1744;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DistanceOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;286;-2080,-1936;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;351;-2272,-1216;Inherit;False;692;210.8;Comment;3;82;86;261;Root Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;331;-2272,-144;Inherit;False;804;162.8;Comment;2;330;212;Wind Direction;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;50;-2272,80;Inherit;False;646.6168;187.3347;Comment;3;48;328;138;Pivot Coords;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;225;-1936,-432;Inherit;False;WindDirectionMap;-1;True;1;0;SAMPLER2D;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;433;-1936,-1632;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;287;-1888,-1936;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;295;-1840,-1824;Inherit;False;Property;_FadeFalloff;Fade Falloff;23;0;Create;True;0;0;0;False;0;False;2;1;1;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;48;-2240,144;Inherit;False;Constant;_Float3;Float 3;9;0;Create;True;0;0;0;False;0;False;0.01;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;330;-2224,-80;Inherit;False;225;WindDirectionMap;1;0;OBJECT;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;82;-2224,-1168;Inherit;False;2;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PowerNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;293;-1712,-1936;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1.06;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;43;-4368,-2880;Inherit;False;Property;_NormalScale;Normal Scale;25;0;Create;True;0;0;0;False;0;False;1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;323;-4464,-3344;Inherit;False;Property;_BaseColorContrast;Base Color Contrast;17;0;Create;True;0;0;0;False;0;False;1;1;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;360;-4400,-2800;Inherit;True;Property;_MaskMap;Mask Map;12;1;[SingleLineTexture];Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;361;-4400,-3072;Inherit;True;Property;_NormalMap;Normal Map;11;2;[Normal];[SingleLineTexture];Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.ColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;15;-4416,-3760;Inherit;False;Property;_Color;Color;13;1;[Header];Create;True;1;COLOR ADJUSTMENT;0;0;False;1;Space(10);False;1,1,1,0;0.9151317,1,0.7490196,1;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;41;-4464,-3424;Inherit;False;Property;_BaseColorSaturation;Base Color Saturation;16;0;Create;True;0;0;0;False;0;False;1;0.538;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;355;-4400,-3264;Inherit;True;Property;_ColorMap;Color Map;10;2;[Header];[SingleLineTexture];Create;True;1;BASE MAPS;0;0;False;1;Space(10);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;362;-4448,-2496;Inherit;False;Property;_AOStrength;AO Strength;22;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;13;-4448,-2592;Inherit;False;Property;_Smoothness;Smoothness;19;1;[Header];Create;True;1;BASE ATTRIBUTES;0;0;False;1;Space(10);False;1;0.228;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;86;-2000,-1120;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;328;-2096,144;Inherit;False;TF_PivotFromUV;-1;;4;4c1a0f27228ccf340bc766c028a036ad;1,13,1;1;11;FLOAT;0.001;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;154;-2224,-656;Inherit;True;Property;_WindMap;Wind Map;29;2;[Header];[SingleLineTexture];Create;True;1;WIND MAPS;0;0;False;1;Space(15);False;378eb7a6f1fcee54e90afb0250e0e090;378eb7a6f1fcee54e90afb0250e0e090;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;366;-2240,-224;Inherit;False;TF_WindDirection;38;;28;33a6a3d56d7ad9f4db7bbb814bfef215;0;2;63;FLOAT;200;False;58;SAMPLER2D;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;322;-4464,-3504;Inherit;False;Property;_BaseColorBrightness;Base Color Brightness;15;0;Create;True;0;0;0;False;0;False;1;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;294;-1552,-1936;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;394;-3776,-3184;Inherit;False;FW_StandardLayer;-1;;95;c3b2175e566bb5047b1cf46c43eb1c3f;0;16;41;FLOAT4;0,0,0,0;False;50;FLOAT;1;False;52;FLOAT;1;False;51;FLOAT;1;False;65;FLOAT;1;False;8;SAMPLER2D;;False;54;SAMPLER2D;;False;55;FLOAT4;1,1,1,0;False;2;SAMPLERSTATE;;False;9;SAMPLER2D;;False;11;FLOAT;1;False;10;SAMPLERSTATE;;False;13;SAMPLER2D;0,0,0;False;21;FLOAT;0;False;22;FLOAT;0;False;23;FLOAT;0;False;10;FLOAT3;0;COLOR;89;FLOAT3;25;FLOAT;26;FLOAT;27;FLOAT;29;COLOR;60;FLOAT;53;FLOAT;28;COLOR;40
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;261;-1824,-1120;Inherit;False;RootMask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;212;-1712,-80;Inherit;False;WindDirection;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;138;-1888,144;Inherit;False;PivotCoords;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;165;-1936,-656;Inherit;False;WindMap;-1;True;1;0;SAMPLER2D;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;292;-1392,-1936;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;35;-3232,-2768;Inherit;False;OpacityMap;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;337;-1312,-1088;Inherit;False;165;WindMap;1;0;OBJECT;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;338;-1344,-1008;Inherit;False;212;WindDirection;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;339;-1312,-928;Inherit;False;138;PivotCoords;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;348;-1312,-1168;Inherit;False;261;RootMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;296;-1200,-2032;Inherit;False;35;OpacityMap;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;290;-1232,-1936;Inherit;False;Distance Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;395;-960,-1152;Inherit;False;TF_GrassWind;31;;102;8e3dc58c492ab004d9e34bd9790f9f4a;0;4;62;FLOAT;1;False;42;SAMPLER2D;;False;41;FLOAT3;0,0,0;False;45;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.IntNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;431;-928,-928;Inherit;False;Global;TF_EnableGrassWind;TF_EnableGrassWind;26;0;Create;True;0;0;0;False;0;False;1;1;False;0;1;INT;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;297;-976,-2048;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;432;-592,-1152;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;INT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;414;-2432,-2720;Inherit;False;1108;450.8;Comment;7;371;357;372;356;370;368;401;Normal Modification;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;325;-3072,-4256;Inherit;False;837.6001;465.2001;Comment;5;125;126;263;37;413;Root Color;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;265;-2272,-976;Inherit;False;812.3862;213.1514;Comment;5;346;119;349;241;240;Color Root Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;300;-784,-2064;Inherit;False;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;342;96,-1152;Inherit;False;Wind;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;125;-2688,-4208;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;240;-1984,-912;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;37;-2992,-4016;Inherit;False;34;BaseColor;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;39;96,-2432;Inherit;False;300;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;318;0,-2352;Inherit;False;Property;_MaskClip;Mask Clip;21;0;Create;True;0;0;0;False;0;False;0.51;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;363;80,-2608;Inherit;False;358;Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;364;48,-2528;Inherit;False;359;AmbientOcclusion;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;126;-3024,-4208;Inherit;False;Property;_RootColor;Root Color;14;0;Create;True;0;0;0;False;0;False;0.2235294,0.2431373,0.1058824,1;0.1302307,0.1886792,0.09683155,1;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;346;-2192,-848;Inherit;False;261;RootMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;333;0,-2272;Inherit;False;Property;_Transmission;Transmission;45;0;Create;True;0;0;0;False;0;False;0.2;0.2;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;12;112,-2816;Inherit;False;357;FinalNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;327;112,-2896;Inherit;False;326;FinalColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;367;112,-2688;Inherit;False;Property;_Specular;Specular;20;0;Create;True;0;0;0;False;0;False;0.05;0.05;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;119;-2256,-928;Inherit;False;Property;_RootMaskStrength;Root Mask Strength;18;0;Create;True;0;0;0;False;0;False;0;-0.03;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;241;-1856,-928;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;349;-1712,-928;Inherit;False;RootColorMask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;413;-2464,-4208;Inherit;False;Color;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;371;-1952,-2480;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;357;-1568,-2480;Inherit;False;FinalNormal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;372;-2352,-2384;Inherit;False;Property;_NormalYVectorInfluence;Normal Y Vector Influence;26;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;356;-1808,-2480;Inherit;False;TF_FlipNormalBackfaces;27;;220;ac34ec6731ca09c4bb272e16fbf2fe92;0;1;6;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TransformDirectionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;370;-2208,-2672;Inherit;False;Object;Tangent;False;Fast;False;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.Vector3Node, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;368;-2384,-2672;Inherit;False;Constant;_Vector0;Vector 0;23;0;Create;True;0;0;0;False;0;False;0,1,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;401;-2240,-2480;Inherit;False;400;Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;358;-3232,-2928;Inherit;False;Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;359;-3232,-2848;Inherit;False;AmbientOcclusion;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;400;-3232,-3040;Inherit;False;Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;34;-3232,-3136;Inherit;False;BaseColor;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;390;-4048,-3664;Inherit;False;Property;_Float1;Float 1;37;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;326;-400,-4384;Inherit;False;FinalColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;402;-1856,-4208;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;405;-2160,-4240;Inherit;False;Global;TF_GrassVarianceMaskScale;TF_GrassVarianceMaskScale;37;0;Create;True;0;0;0;False;0;False;100;100;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;418;-624,-4304;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;416;-912,-4384;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;421;-928,-4208;Inherit;False;413;Color;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;403;-2160,-4144;Inherit;False;Property;_ColorVarianceMaskScale;Color Variance Mask Scale;9;0;Create;True;0;0;0;False;0;False;-100;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;404;-1568,-4384;Inherit;False;413;Color;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;424;-1312,-4288;Inherit;False;TF_ColorHueVariance;0;;221;d9bb501bc9f1ce84a8d082570c3540ee;0;7;13;COLOR;0,0,0,0;False;14;FLOAT2;0,0;False;34;FLOAT;1;False;35;FLOAT;-1;False;36;FLOAT;1;False;37;FLOAT;0;False;55;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;410;-1680,-3824;Inherit;False;Global;TF_GrassVarianceIntensity;TF_GrassVarianceIntensity;3;0;Create;True;0;0;0;False;0;False;0;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;411;-1680,-3728;Inherit;False;Global;TF_GrassBrightnessVariance;TF_GrassBrightnessVariance;3;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;409;-1680,-4112;Inherit;False;Global;TF_GrassVarianceBiasShift;TF_GrassVarianceBiasShift;4;0;Create;True;0;0;0;False;0;False;1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;408;-1648,-4016;Inherit;False;Global;TF_GrassVarianceMin;TF_GrassVarianceMin;6;0;Create;True;0;0;0;False;0;False;-1;-0.15;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;407;-1648,-3920;Inherit;False;Global;TF_GrassVarianceMax;TF_GrassVarianceMax;5;0;Create;True;0;0;0;False;0;False;1;0.15;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;406;-1632,-4208;Inherit;False;TF_WorldPositionCoords;-1;;222;9dc59717bff26214ea4f3f351d35fe94;1,7,1;1;5;FLOAT;-133.16;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;417;-1216,-4016;Inherit;False;349;RootColorMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.IntNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;420;-880,-3744;Inherit;False;Global;TF_GrassVarianceEnable;TF_GrassVarianceEnable;26;0;Create;True;0;0;0;False;0;False;0;0;False;0;1;INT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;426;-1312,-3936;Inherit;False;Global;TF_GrassVarianceRootInfluence;TF_GrassVarianceRootInfluence;26;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;425;-960,-4016;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;434;-272,-2016;Inherit;False;Property;_TranslucencyStrength;Translucency Strength;46;0;Create;True;1;;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;350;-272,-2128;Inherit;False;349;RootColorMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;343;176,-2112;Inherit;False;342;Wind;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;435;0,-2128;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;263;-3024,-3936;Inherit;False;349;RootColorMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;308;336,-2624;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ExtraPrePass;0;0;ExtraPrePass;6;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;310;567.2643,-38.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;311;567.2643,-38.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;True;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;312;567.2643,-38.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;313;567.2643,-38.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;314;567.2643,-38.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormalsOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;315;567.2643,-38.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;GBuffer;0;7;GBuffer;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalGBuffer;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;316;567.2643,-38.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;SceneSelectionPass;0;8;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;317;567.2643,-38.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ScenePickingPass;0;9;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;309;416,-2624;Float;False;True;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;TriForge/FWGrass;94348b07e5e8bab40bd6c8a1e3df54cd;True;Forward;0;1;Forward;21;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalForwardOnly;False;False;2;Include;;False;;Native;False;0;0;;Include;Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl;False;;Custom;False;0;0;;;0;0;Standard;45;Lighting Model;0;0;Workflow;0;638784370229859278;Surface;0;638339367536332125;  Refraction Model;0;0;  Blend;0;0;Two Sided;0;638339355192885103;Alpha Clipping;1;0;  Use Shadow Threshold;0;0;Fragment Normal Space,InvertActionOnDeselection;0;0;Forward Only;1;0;Transmission;1;638784308792749078;  Transmission Shadow;0.5,False,;0;Translucency;1;638339355283409961;  Translucency Strength;1,True,_TranslucencyStrength;638969100286405708;  Normal Distortion;0.5,False,;0;  Scattering;2,False,;0;  Direct;0.9,False,;0;  Ambient;0.1,False,;0;  Shadow;0.5,False,;0;Cast Shadows;1;0;Receive Shadows;1;0;Receive SSAO;1;0;Specular Highlights;1;0;Environment Reflections;1;0;GPU Instancing;1;0;LOD CrossFade;1;0;Built-in Fog;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Write Depth;0;0;  Early Z;0;0;Vertex Position,InvertActionOnDeselection;1;0;Debug Display;0;0;Clear Coat;0;0;0;10;False;True;True;True;True;True;True;False;True;True;False;;False;0
WireConnection;396;0;288;0
WireConnection;396;1;397;0
WireConnection;286;0;285;0
WireConnection;286;1;284;0
WireConnection;225;0;155;0
WireConnection;433;0;288;0
WireConnection;433;1;396;0
WireConnection;433;2;397;0
WireConnection;287;0;286;0
WireConnection;287;1;433;0
WireConnection;293;0;287;0
WireConnection;293;1;295;0
WireConnection;86;0;82;2
WireConnection;328;11;48;0
WireConnection;366;58;330;0
WireConnection;294;0;293;0
WireConnection;394;41;15;0
WireConnection;394;50;322;0
WireConnection;394;52;41;0
WireConnection;394;51;323;0
WireConnection;394;8;355;0
WireConnection;394;9;361;0
WireConnection;394;11;43;0
WireConnection;394;13;360;0
WireConnection;394;22;13;0
WireConnection;394;23;362;0
WireConnection;261;0;86;0
WireConnection;212;0;366;0
WireConnection;138;0;328;0
WireConnection;165;0;154;0
WireConnection;292;0;294;0
WireConnection;35;0;394;53
WireConnection;290;0;292;0
WireConnection;395;62;348;0
WireConnection;395;42;337;0
WireConnection;395;41;338;0
WireConnection;395;45;339;0
WireConnection;297;1;296;0
WireConnection;297;2;290;0
WireConnection;432;0;395;0
WireConnection;432;1;431;0
WireConnection;300;0;297;0
WireConnection;342;0;432;0
WireConnection;125;0;126;0
WireConnection;125;1;37;0
WireConnection;125;2;263;0
WireConnection;240;0;119;0
WireConnection;240;1;346;0
WireConnection;241;0;240;0
WireConnection;349;0;241;0
WireConnection;413;0;125;0
WireConnection;371;0;401;0
WireConnection;371;1;370;0
WireConnection;371;2;372;0
WireConnection;357;0;356;0
WireConnection;356;6;371;0
WireConnection;370;0;368;0
WireConnection;358;0;394;27
WireConnection;359;0;394;29
WireConnection;400;0;394;25
WireConnection;34;0;394;0
WireConnection;326;0;418;0
WireConnection;402;0;405;0
WireConnection;402;1;403;0
WireConnection;418;0;421;0
WireConnection;418;1;416;0
WireConnection;418;2;420;0
WireConnection;416;0;404;0
WireConnection;416;1;424;0
WireConnection;416;2;425;0
WireConnection;424;13;404;0
WireConnection;424;14;406;0
WireConnection;424;34;409;0
WireConnection;424;35;408;0
WireConnection;424;36;407;0
WireConnection;424;37;410;0
WireConnection;424;55;411;0
WireConnection;406;5;402;0
WireConnection;425;0;417;0
WireConnection;425;2;426;0
WireConnection;435;0;350;0
WireConnection;435;1;434;0
WireConnection;309;0;327;0
WireConnection;309;1;12;0
WireConnection;309;9;367;0
WireConnection;309;4;363;0
WireConnection;309;5;364;0
WireConnection;309;6;39;0
WireConnection;309;7;318;0
WireConnection;309;14;333;0
WireConnection;309;15;435;0
WireConnection;309;8;343;0
ASEEND*/
//CHKSM=C1576CEED243905A8B22DA738374D8314B08E674