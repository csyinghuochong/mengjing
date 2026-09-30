// Made with Amplify Shader Editor v1.9.9
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "TriForge/Tree Branch"
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
		[Normal][SingleLineTexture] _NormalMap( "Normal Map", 2D ) = "bump" {}
		[SingleLineTexture] _MaskMap( "Mask Map", 2D ) = "white" {}
		[Header(COLOR ADJUSTMENT)][Space(10)] _Color( "Color", Color ) = ( 1, 1, 1, 0 )
		_Undercolor( "Undercolor", Color ) = ( 1, 1, 1, 0 )
		_UndercolorAmount( "Undercolor Amount", Range( -1, 1 ) ) = 0.5
		_BaseColorBrightness( "Base Color Brightness", Range( -1, 2 ) ) = 1
		_BaseColorSaturation( "Base Color Saturation", Range( -1, 2 ) ) = 1
		_BaseColorContrast( "Base Color Contrast", Range( 0, 2 ) ) = 1
		[Header(BASE ATTRIBUTES)][Space(10)] _Smoothness( "Smoothness", Range( 0, 1 ) ) = 0
		_Specular( "Specular", Float ) = 0.05
		_NormalScale( "Normal Scale", Range( -2, 2 ) ) = 0
		[Toggle( _TFW_FLIPNORMALS )] _FlipBackNormals( "Flip Back Normals", Float ) = 0
		_AOIntensity( "AO Intensity", Range( 0, 1 ) ) = 1
		_VertexAOIntensity( "Vertex AO Intensity", Range( 0, 1 ) ) = 1
		_MaskClip( "Mask Clip", Range( 0, 1 ) ) = 0.5588235
		[Toggle( _DISTANCEBASEDMASKCLIP_ON )] _DistanceBasedMaskClip( "Distance Based Mask Clip", Float ) = 1
		[Header(WIND SETTINGS)][Space(10)][Toggle( _ENABLEWIND_ON )] _EnableWind( "Enable Wind", Float ) = 0
		_WindOverallStrength( "Wind Overall Strength", Range( 0, 1 ) ) = 1
		_LeafFlutterStrength( "Leaf Flutter Strength", Range( 0, 2 ) ) = 0.3
		[Header(Main Wind)][Space(5)] _MainWindStrength( "Main Wind Strength", Range( 0, 2 ) ) = 0.5
		_MainBendMaskStrength( "Main Bend Mask Strength", Range( 0, 5 ) ) = 0
		_MainWindScale( "Main Wind Scale", Range( 0, 1 ) ) = 1
		[Header(Parent Wind)][Space(5)] _ParentWindStrength( "Parent Wind Strength", Range( 0, 2 ) ) = 0.5
		_ParentWindMapScale( "Parent Wind Map Scale", Range( 0, 50 ) ) = 1
		_BendingMaskStrength( "Bending Mask Strength", Range( 0.05, 2 ) ) = 1.236128
		[Header(Child Wind)][Space(5)] _ChildWindStrength( "Child Wind Strength", Range( 0, 2 ) ) = 0.5
		_HueTest( "Hue Test", Range( 0, 1 ) ) = 1
		_ChildWindMapScale( "Child Wind Map Scale", Range( 0, 5 ) ) = 0
		[Header(WIND MAPS)][SingleLineTexture][Space(10)] _WindDirectionMap( "Wind Direction Map", 2D ) = "white" {}
		_WindDirectionMapScale( "Wind Direction Map Scale", Float ) = 200
		[Header(WIND DIRECTION)][Space(10)][Toggle( _USEWINDDIRECTIONMAP_ON )] _UseWindDirectionMap( "Use Wind Direction Map", Float ) = 0
		_WindDirectionMapInfluence( "Wind Direction Map Influence", Range( 0, 2 ) ) = 1
		_LFMapPanningSpeed( "LF Map Panning Speed", Vector ) = ( 0.04, 0, 0, 0 )
		_HFRotationMapInfluence( "HF Rotation Map Influence", Range( 0, 1 ) ) = 1
		_HFMapPanningSpeed( "HF Map Panning Speed", Vector ) = ( 0.04, 0, 0, 0 )
		[Header(TRANSLUCENCY)][Space(10)] _TranslucencyStrength( "Translucency Strength", Range( 0, 10 ) ) = 0
		_Transmission( "Transmission", Range( 0, 2 ) ) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}


		_TransmissionShadow( "Transmission Shadow", Range( 0, 1 ) ) = 0.5
		//_TransStrength( "Strength", Range( 0, 50 ) ) = 1
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

		

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" "Queue"="Geometry" "UniversalMaterialType"="Lit" "DisableBatching"="True" }

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
			Tags { "LightMode"="UniversalForwardOnly" "DisableBatching"="True" }

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
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
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
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_TEXTURE_COORDINATES4
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES4
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature _TFW_FLIPNORMALS
			#pragma shader_feature_local _USECOLORVARIANCE_ON
			#pragma shader_feature_local _DISTANCEBASEDMASKCLIP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
			#pragma multi_compilefragment  LOD_FADE_CROSSFADE


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
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_color : COLOR;
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
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _Color;
			float4 _Undercolor;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _HueTest;
			float _ColorVarianceBiasShift;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _ColorVarianceMin;
			float _ColorVarianceMax;
			float _ColorVarianceIntensity;
			float _BrightnessVarianceIntensity;
			float _Specular;
			float _Smoothness;
			float _VertexAOIntensity;
			float _AOIntensity;
			float _MaskClip;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _UndercolorAmount;
			float _Transmission;
			float _WindDirectionMapScale;
			float _HFRotationMapInfluence;
			float _WindDirectionMapInfluence;
			float _ChildWindMapScale;
			float _ChildWindStrength;
			float _BendingMaskStrength;
			float _BaseColorContrast;
			float _ParentWindMapScale;
			float _MainBendMaskStrength;
			float _MainWindScale;
			float _MainWindStrength;
			float _WindOverallStrength;
			float _LeafFlutterStrength;
			float _NormalScale;
			float _ParentWindStrength;
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
			float TF_WIND_STRENGTH;
			sampler2D _ColorMap;
			sampler2D _NormalMap;
			sampler2D _MaskMap;
			float TF_ColorVarianceBiasShift;
			sampler2D _ColorVarianceMask;
			float TF_ColorVarianceMaskScale;
			float TF_ColorVarianceMin;
			float TF_ColorVarianceMax;
			float TF_ColorVarianceIntensity;
			float TF_BrightnessVariance;
			int TF_ColorVarianceEnable;


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
				float3 appendResult18_g217 = (float3(( -1.0 * input.texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g217 = ( 0.001 * appendResult18_g217 );
				float dotResult16_g217 = dot( temp_output_20_0_g217 , temp_output_20_0_g217 );
				float ifLocalVar182_g217 = 0;
				if( dotResult16_g217 > 0.0001 )
				ifLocalVar182_g217 = 1.0;
				else if( dotResult16_g217 < 0.0001 )
				ifLocalVar182_g217 = 0.0;
				float ChildMask26_g217 = saturate( ( ifLocalVar182_g217 * 100.0 ) );
				float SelfBendMask34_g217 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g218 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g218 = 0.0;
				else
				ifLocalVar33_g218 = 1.0;
				float ifLocalVar34_g218 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g218 = 0.0;
				else
				ifLocalVar34_g218 = 1.0;
				float3 lerpResult41_g218 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g218 + ifLocalVar34_g218 ));
				float3 WindVector47_g218 = lerpResult41_g218;
				float3 objToWorld6_g219 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g218 = (( objToWorld6_g219 / _WindDirectionMapScale )).xz;
				float2 panner7_g218 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode11_g218 = tex2Dlod( _WindDirectionMap, float4( panner7_g218, 0, 0.0) );
				float2 RotationMapLF16_g218 = (tex2DNode11_g218).rg;
				float2 break35_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g218 = (float3(( break35_g218.x * -1.0 ) , 0.0 , break35_g218.y));
				float2 panner9_g218 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode10_g218 = tex2Dlod( _WindDirectionMap, float4( panner9_g218, 0, 0.0) );
				float2 RotationMapHF17_g218 = (tex2DNode10_g218).ba;
				float2 break36_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g218 = (float3(( break36_g218.x * -1.0 ) , 0.0 , break36_g218.y));
				float3 lerpResult48_g218 = lerp( appendResult42_g218 , appendResult43_g218 , _HFRotationMapInfluence);
				float3 lerpResult51_g218 = lerp( WindVector47_g218 , lerpResult48_g218 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g218 = lerpResult51_g218;
				#else
				float3 staticSwitch55_g218 = WindVector47_g218;
				#endif
				float3 worldToObjDir52_g218 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g218, 0.0 ) ).xyz;
				float3 WindVector226_g217 = worldToObjDir52_g218;
				float3 appendResult11_g217 = (float3(( -1.0 * input.texcoord1.x ) , input.texcoord2.x , ( -1.0 * input.texcoord1.y )));
				float3 temp_output_19_0_g217 = ( 0.001 * appendResult11_g217 );
				float3 SelfPivot28_g217 = temp_output_19_0_g217;
				float3 objToWorld54_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g217 * 1.0 ) + ( objToWorld54_g217 / -2.0 ) )).z).xx;
				float2 panner48_g217 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g217 = snoise( panner48_g217*_ChildWindMapScale );
				simplePerlin2D53_g217 = simplePerlin2D53_g217*0.5 + 0.5;
				float ChildRotation43_g217 = radians( ( simplePerlin2D53_g217 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g217 = RotateAroundAxis( SelfPivot28_g217, input.positionOS.xyz, normalize( WindVector226_g217 ), ChildRotation43_g217 );
				float3 ChildRotationResult119_g217 = ( ( ChildMask26_g217 * SelfBendMask34_g217 ) * ( rotatedValue81_g217 - input.positionOS.xyz ) );
				float temp_output_113_0_g217 = saturate( ( 4.0 * pow( SelfBendMask34_g217 , _BendingMaskStrength ) ) );
				float dotResult9_g217 = dot( temp_output_19_0_g217 , temp_output_19_0_g217 );
				float ifLocalVar189_g217 = 0;
				if( dotResult9_g217 > 0.0001 )
				ifLocalVar189_g217 = 1.0;
				else if( dotResult9_g217 < 0.0001 )
				ifLocalVar189_g217 = 0.0;
				float TrunkMask29_g217 = saturate( ( ifLocalVar189_g217 * 1000.0 ) );
				float3 ParentPivot27_g217 = temp_output_20_0_g217;
				float3 lerpResult51_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float2 temp_cast_2 = ((( lerpResult51_g217 / -0.2 )).z).xx;
				float2 panner61_g217 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g217 = snoise( panner61_g217*_ParentWindMapScale );
				simplePerlin2D60_g217 = simplePerlin2D60_g217*0.5 + 0.5;
				float saferPower185_g217 = abs( simplePerlin2D60_g217 );
				float saferPower160_g217 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g217 = saturate( pow( saferPower160_g217 , _MainBendMaskStrength ) );
				float ParentRotation63_g217 = radians( ( pow( saferPower185_g217 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g217 ) );
				float3 lerpResult98_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float3 rotatedValue96_g217 = RotateAroundAxis( lerpResult98_g217, ( ChildRotationResult119_g217 + input.positionOS.xyz ), normalize( WindVector226_g217 ), ParentRotation63_g217 );
				float3 ParentRotationResult131_g217 = ( ChildRotationResult119_g217 + ( ( ( ( ( temp_output_113_0_g217 * ( 1.0 - ChildMask26_g217 ) ) + ChildMask26_g217 ) * TrunkMask29_g217 ) * ( rotatedValue96_g217 - input.positionOS.xyz ) ) * MainBendMask35_g217 ) );
				float3 objToWorld47_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g217 = abs( ( objToWorld47_g217 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g217 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g217 , 2.0 )).xz);
				float simplePerlin2D70_g217 = snoise( panner71_g217*2.0 );
				simplePerlin2D70_g217 = simplePerlin2D70_g217*0.5 + 0.5;
				float MainRotation67_g217 = radians( ( simplePerlin2D70_g217 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g217 = ( ParentRotationResult131_g217 + input.positionOS.xyz );
				float3 rotatedValue121_g217 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g217, normalize( WindVector226_g217 ), MainRotation67_g217 );
				float temp_output_148_0_g217 = pow( MainBendMask35_g217 , 5.0 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner86 = ( 1.0 * _Time.y * float2( -0.2,0.4 ) + (( ase_positionWS / -8.0 )).xz);
				float simplePerlin2D85 = snoise( panner86*10.0 );
				simplePerlin2D85 = simplePerlin2D85*0.5 + 0.5;
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch287 = ( ( ( ParentRotationResult131_g217 + ( ( rotatedValue121_g217 - temp_output_125_0_g217 ) * temp_output_148_0_g217 ) ) * _WindOverallStrength * TF_WIND_STRENGTH ) + ( ( ( 1.0 - input.ase_color.b ) * _LeafFlutterStrength ) * ( input.texcoord.y * simplePerlin2D85 ) * TF_WIND_STRENGTH * 0.6 ) );
				#else
				float3 staticSwitch287 = temp_cast_0;
				#endif
				
				output.ase_texcoord6.xy = input.texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord6.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch287;

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
				float4 ase_texcoord4 : TEXCOORD4;
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
				#if defined(LIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES1)
					output.texcoord1 = input.texcoord1;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES2)
					output.texcoord2 = input.texcoord2;
				#endif
				output.texcoord = input.texcoord;
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
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
				#if defined(LIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES1)
					output.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON) || defined(ASE_NEEDS_TEXTURE_COORDINATES2)
					output.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				#endif
				output.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
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

				float2 texCoord62_g213 = input.ase_texcoord6.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g213 = tex2D( _ColorMap, texCoord62_g213 );
				float4 ColorClean386 = tex2DNode1_g213;
				float3 unpack7_g213 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g213 ), _NormalScale );
				unpack7_g213.z = lerp( 1, unpack7_g213.z, saturate(_NormalScale) );
				float3 temp_output_6_0_g220 = unpack7_g213;
				float3 break1_g220 = temp_output_6_0_g220;
				float switchResult4_g220 = (((ase_vface>0)?(break1_g220.z):(-break1_g220.z)));
				float3 appendResult3_g220 = (float3(break1_g220.x , break1_g220.y , switchResult4_g220));
				#ifdef _TFW_FLIPNORMALS
				float3 staticSwitch5_g220 = appendResult3_g220;
				#else
				float3 staticSwitch5_g220 = temp_output_6_0_g220;
				#endif
				float3 FinalNormal8 = staticSwitch5_g220;
				float3 tanToWorld0 = float3( TangentWS.x, BitangentWS.x, NormalWS.x );
				float3 tanToWorld1 = float3( TangentWS.y, BitangentWS.y, NormalWS.y );
				float3 tanToWorld2 = float3( TangentWS.z, BitangentWS.z, NormalWS.z );
				float3 tanNormal377 = FinalNormal8;
				float3 worldNormal377 = normalize( float3( dot( tanToWorld0, tanNormal377 ), dot( tanToWorld1, tanNormal377 ), dot( tanToWorld2, tanNormal377 ) ) );
				float4 lerpResult263 = lerp( _Undercolor , _Color , saturate( ( worldNormal377.y + _UndercolorAmount ) ));
				float3 temp_output_12_0_g216 = tex2DNode1_g213.rgb;
				float dotResult28_g216 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g216 );
				float3 temp_cast_1 = (dotResult28_g216).xxx;
				float temp_output_21_0_g216 = _BaseColorSaturation;
				float3 lerpResult31_g216 = lerp( temp_cast_1 , temp_output_12_0_g216 , temp_output_21_0_g216);
				float4 color380 = IsGammaSpace() ? float4( 1, 1, 1, 0 ) : float4( 1, 1, 1, 0 );
				float3 hsvTorgb14_g215 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g216 * _BaseColorBrightness ) , 0.0 )) * color380 ).rgb );
				float3 hsvTorgb13_g215 = HSVToRGB( float3(( hsvTorgb14_g215.x + _HueTest ),hsvTorgb14_g215.y,hsvTorgb14_g215.z) );
				float3 Color385 = hsvTorgb13_g215;
				float2 uv_MaskMap = input.ase_texcoord6.xy * _MaskMap_ST.xy + _MaskMap_ST.zw;
				float4 tex2DNode1_g214 = tex2D( _MaskMap, uv_MaskMap );
				float temp_output_376_28 = tex2DNode1_g214.b;
				float ColorMask389 = temp_output_376_28;
				float4 lerpResult375 = lerp( ColorClean386 , float4( Color385 , 0.0 ) , ColorMask389);
				float4 lerpResult383 = lerp( ColorClean386 , ( lerpResult263 * lerpResult375 ) , ColorMask389);
				float4 LeafColor392 = lerpResult383;
				float4 temp_output_13_0_g223 = LeafColor392;
				float3 objToWorld6_g221 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float4 tex2DNode8_g223 = tex2D( _ColorVarianceMask, (( objToWorld6_g221 / ( TF_ColorVarianceMaskScale * _ColorVarianceMaskScale ) )).xz );
				float3 hsvTorgb3_g223 = RGBToHSV( temp_output_13_0_g223.rgb );
				float3 hsvTorgb1_g223 = HSVToRGB( float3(( ( ( _ColorVarianceBiasShift * TF_ColorVarianceBiasShift ) +  (( _ColorVarianceMin * TF_ColorVarianceMin ) + ( pow( tex2DNode8_g223.g , _MaskContrast ) - 0.0 ) * ( ( _ColorVarianceMax * TF_ColorVarianceMax ) - ( _ColorVarianceMin * TF_ColorVarianceMin ) ) / ( 1.0 - 0.0 ) ) ) + hsvTorgb3_g223.x ),hsvTorgb3_g223.y,hsvTorgb3_g223.z) );
				float4 lerpResult38_g223 = lerp( temp_output_13_0_g223 , float4( hsvTorgb1_g223 , 0.0 ) , ( _ColorVarianceIntensity * TF_ColorVarianceIntensity ));
				float Value_Mask39_g223 = tex2DNode8_g223.a;
				float4 lerpResult44_g223 = lerp( lerpResult38_g223 , ( lerpResult38_g223 * Value_Mask39_g223 ) , ( _BrightnessVarianceIntensity * TF_BrightnessVariance ));
				float4 FinalValue46_g223 = lerpResult44_g223;
				#ifdef _USECOLORVARIANCE_ON
				float4 staticSwitch2_g223 = FinalValue46_g223;
				#else
				float4 staticSwitch2_g223 = temp_output_13_0_g223;
				#endif
				float4 lerpResult394 = lerp( ColorClean386 , staticSwitch2_g223 , ColorMask389);
				float4 lerpResult416 = lerp( LeafColor392 , lerpResult394 , (float)TF_ColorVarianceEnable);
				float4 FinalColor37 = lerpResult416;
				
				float3 temp_cast_11 = (_Specular).xxx;
				
				float Smoothness277 = ( tex2DNode1_g214.a * _Smoothness );
				
				float temp_output_169_0 = saturate( ( ( 1.0 - _VertexAOIntensity ) + input.ase_color.r ) );
				float AmbientOcclusion269 = saturate( ( tex2DNode1_g214.g - ( ( 1.0 - _AOIntensity ) * -1.0 ) ) );
				float FinalAmbientOcclusion273 = saturate( ( temp_output_169_0 * AmbientOcclusion269 ) );
				
				float Opacity34 = tex2DNode1_g213.a;
				
				float lerpResult167 = lerp( _MaskClip , ( _MaskClip * 0.4 ) , ( distance( PositionWS , _WorldSpaceCameraPos ) / 150.0 ));
				#ifdef _DISTANCEBASEDMASKCLIP_ON
				float staticSwitch196 = lerpResult167;
				#else
				float staticSwitch196 = _MaskClip;
				#endif
				float Mask_Clip157 = staticSwitch196;
				
				float3 temp_cast_12 = (_Transmission).xxx;
				
				float TranslucencyMask278 = temp_output_376_28;
				float3 temp_cast_13 = (( _TranslucencyStrength * TranslucencyMask278 * input.ase_color.r )).xxx;
				

				float3 BaseColor = FinalColor37.rgb;
				float3 Normal = FinalNormal8;
				float3 Specular = temp_cast_11;
				float Metallic = 0;
				float Smoothness = Smoothness277;
				float Occlusion = FinalAmbientOcclusion273;
				float3 Emission = 0;
				float Alpha = Opacity34;
				float AlphaClipThreshold = Mask_Clip157;
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
					float strength = _TranslucencyStrength;

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
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
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
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_TEXTURE_COORDINATES4
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES4
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _DISTANCEBASEDMASKCLIP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
			#pragma multi_compilefragment  LOD_FADE_CROSSFADE


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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
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
			float4 _Color;
			float4 _Undercolor;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _HueTest;
			float _ColorVarianceBiasShift;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _ColorVarianceMin;
			float _ColorVarianceMax;
			float _ColorVarianceIntensity;
			float _BrightnessVarianceIntensity;
			float _Specular;
			float _Smoothness;
			float _VertexAOIntensity;
			float _AOIntensity;
			float _MaskClip;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _UndercolorAmount;
			float _Transmission;
			float _WindDirectionMapScale;
			float _HFRotationMapInfluence;
			float _WindDirectionMapInfluence;
			float _ChildWindMapScale;
			float _ChildWindStrength;
			float _BendingMaskStrength;
			float _BaseColorContrast;
			float _ParentWindMapScale;
			float _MainBendMaskStrength;
			float _MainWindScale;
			float _MainWindStrength;
			float _WindOverallStrength;
			float _LeafFlutterStrength;
			float _NormalScale;
			float _ParentWindStrength;
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
			float TF_WIND_STRENGTH;
			sampler2D _ColorMap;


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
				float3 appendResult18_g217 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g217 = ( 0.001 * appendResult18_g217 );
				float dotResult16_g217 = dot( temp_output_20_0_g217 , temp_output_20_0_g217 );
				float ifLocalVar182_g217 = 0;
				if( dotResult16_g217 > 0.0001 )
				ifLocalVar182_g217 = 1.0;
				else if( dotResult16_g217 < 0.0001 )
				ifLocalVar182_g217 = 0.0;
				float ChildMask26_g217 = saturate( ( ifLocalVar182_g217 * 100.0 ) );
				float SelfBendMask34_g217 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g218 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g218 = 0.0;
				else
				ifLocalVar33_g218 = 1.0;
				float ifLocalVar34_g218 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g218 = 0.0;
				else
				ifLocalVar34_g218 = 1.0;
				float3 lerpResult41_g218 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g218 + ifLocalVar34_g218 ));
				float3 WindVector47_g218 = lerpResult41_g218;
				float3 objToWorld6_g219 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g218 = (( objToWorld6_g219 / _WindDirectionMapScale )).xz;
				float2 panner7_g218 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode11_g218 = tex2Dlod( _WindDirectionMap, float4( panner7_g218, 0, 0.0) );
				float2 RotationMapLF16_g218 = (tex2DNode11_g218).rg;
				float2 break35_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g218 = (float3(( break35_g218.x * -1.0 ) , 0.0 , break35_g218.y));
				float2 panner9_g218 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode10_g218 = tex2Dlod( _WindDirectionMap, float4( panner9_g218, 0, 0.0) );
				float2 RotationMapHF17_g218 = (tex2DNode10_g218).ba;
				float2 break36_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g218 = (float3(( break36_g218.x * -1.0 ) , 0.0 , break36_g218.y));
				float3 lerpResult48_g218 = lerp( appendResult42_g218 , appendResult43_g218 , _HFRotationMapInfluence);
				float3 lerpResult51_g218 = lerp( WindVector47_g218 , lerpResult48_g218 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g218 = lerpResult51_g218;
				#else
				float3 staticSwitch55_g218 = WindVector47_g218;
				#endif
				float3 worldToObjDir52_g218 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g218, 0.0 ) ).xyz;
				float3 WindVector226_g217 = worldToObjDir52_g218;
				float3 appendResult11_g217 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g217 = ( 0.001 * appendResult11_g217 );
				float3 SelfPivot28_g217 = temp_output_19_0_g217;
				float3 objToWorld54_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g217 * 1.0 ) + ( objToWorld54_g217 / -2.0 ) )).z).xx;
				float2 panner48_g217 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g217 = snoise( panner48_g217*_ChildWindMapScale );
				simplePerlin2D53_g217 = simplePerlin2D53_g217*0.5 + 0.5;
				float ChildRotation43_g217 = radians( ( simplePerlin2D53_g217 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g217 = RotateAroundAxis( SelfPivot28_g217, input.positionOS.xyz, normalize( WindVector226_g217 ), ChildRotation43_g217 );
				float3 ChildRotationResult119_g217 = ( ( ChildMask26_g217 * SelfBendMask34_g217 ) * ( rotatedValue81_g217 - input.positionOS.xyz ) );
				float temp_output_113_0_g217 = saturate( ( 4.0 * pow( SelfBendMask34_g217 , _BendingMaskStrength ) ) );
				float dotResult9_g217 = dot( temp_output_19_0_g217 , temp_output_19_0_g217 );
				float ifLocalVar189_g217 = 0;
				if( dotResult9_g217 > 0.0001 )
				ifLocalVar189_g217 = 1.0;
				else if( dotResult9_g217 < 0.0001 )
				ifLocalVar189_g217 = 0.0;
				float TrunkMask29_g217 = saturate( ( ifLocalVar189_g217 * 1000.0 ) );
				float3 ParentPivot27_g217 = temp_output_20_0_g217;
				float3 lerpResult51_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float2 temp_cast_2 = ((( lerpResult51_g217 / -0.2 )).z).xx;
				float2 panner61_g217 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g217 = snoise( panner61_g217*_ParentWindMapScale );
				simplePerlin2D60_g217 = simplePerlin2D60_g217*0.5 + 0.5;
				float saferPower185_g217 = abs( simplePerlin2D60_g217 );
				float saferPower160_g217 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g217 = saturate( pow( saferPower160_g217 , _MainBendMaskStrength ) );
				float ParentRotation63_g217 = radians( ( pow( saferPower185_g217 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g217 ) );
				float3 lerpResult98_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float3 rotatedValue96_g217 = RotateAroundAxis( lerpResult98_g217, ( ChildRotationResult119_g217 + input.positionOS.xyz ), normalize( WindVector226_g217 ), ParentRotation63_g217 );
				float3 ParentRotationResult131_g217 = ( ChildRotationResult119_g217 + ( ( ( ( ( temp_output_113_0_g217 * ( 1.0 - ChildMask26_g217 ) ) + ChildMask26_g217 ) * TrunkMask29_g217 ) * ( rotatedValue96_g217 - input.positionOS.xyz ) ) * MainBendMask35_g217 ) );
				float3 objToWorld47_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g217 = abs( ( objToWorld47_g217 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g217 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g217 , 2.0 )).xz);
				float simplePerlin2D70_g217 = snoise( panner71_g217*2.0 );
				simplePerlin2D70_g217 = simplePerlin2D70_g217*0.5 + 0.5;
				float MainRotation67_g217 = radians( ( simplePerlin2D70_g217 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g217 = ( ParentRotationResult131_g217 + input.positionOS.xyz );
				float3 rotatedValue121_g217 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g217, normalize( WindVector226_g217 ), MainRotation67_g217 );
				float temp_output_148_0_g217 = pow( MainBendMask35_g217 , 5.0 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner86 = ( 1.0 * _Time.y * float2( -0.2,0.4 ) + (( ase_positionWS / -8.0 )).xz);
				float simplePerlin2D85 = snoise( panner86*10.0 );
				simplePerlin2D85 = simplePerlin2D85*0.5 + 0.5;
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch287 = ( ( ( ParentRotationResult131_g217 + ( ( rotatedValue121_g217 - temp_output_125_0_g217 ) * temp_output_148_0_g217 ) ) * _WindOverallStrength * TF_WIND_STRENGTH ) + ( ( ( 1.0 - input.ase_color.b ) * _LeafFlutterStrength ) * ( input.ase_texcoord.y * simplePerlin2D85 ) * TF_WIND_STRENGTH * 0.6 ) );
				#else
				float3 staticSwitch287 = temp_cast_0;
				#endif
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch287;
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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
				output.ase_texcoord1 = input.ase_texcoord1;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

				float2 texCoord62_g213 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g213 = tex2D( _ColorMap, texCoord62_g213 );
				float Opacity34 = tex2DNode1_g213.a;
				
				float lerpResult167 = lerp( _MaskClip , ( _MaskClip * 0.4 ) , ( distance( PositionWS , _WorldSpaceCameraPos ) / 150.0 ));
				#ifdef _DISTANCEBASEDMASKCLIP_ON
				float staticSwitch196 = lerpResult167;
				#else
				float staticSwitch196 = _MaskClip;
				#endif
				float Mask_Clip157 = staticSwitch196;
				

				float Alpha = Opacity34;
				float AlphaClipThreshold = Mask_Clip157;
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
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
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
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_TEXTURE_COORDINATES4
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES4
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _DISTANCEBASEDMASKCLIP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
			#pragma multi_compilefragment  LOD_FADE_CROSSFADE


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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
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
			float4 _Color;
			float4 _Undercolor;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _HueTest;
			float _ColorVarianceBiasShift;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _ColorVarianceMin;
			float _ColorVarianceMax;
			float _ColorVarianceIntensity;
			float _BrightnessVarianceIntensity;
			float _Specular;
			float _Smoothness;
			float _VertexAOIntensity;
			float _AOIntensity;
			float _MaskClip;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _UndercolorAmount;
			float _Transmission;
			float _WindDirectionMapScale;
			float _HFRotationMapInfluence;
			float _WindDirectionMapInfluence;
			float _ChildWindMapScale;
			float _ChildWindStrength;
			float _BendingMaskStrength;
			float _BaseColorContrast;
			float _ParentWindMapScale;
			float _MainBendMaskStrength;
			float _MainWindScale;
			float _MainWindStrength;
			float _WindOverallStrength;
			float _LeafFlutterStrength;
			float _NormalScale;
			float _ParentWindStrength;
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
			float TF_WIND_STRENGTH;
			sampler2D _ColorMap;


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
				float3 appendResult18_g217 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g217 = ( 0.001 * appendResult18_g217 );
				float dotResult16_g217 = dot( temp_output_20_0_g217 , temp_output_20_0_g217 );
				float ifLocalVar182_g217 = 0;
				if( dotResult16_g217 > 0.0001 )
				ifLocalVar182_g217 = 1.0;
				else if( dotResult16_g217 < 0.0001 )
				ifLocalVar182_g217 = 0.0;
				float ChildMask26_g217 = saturate( ( ifLocalVar182_g217 * 100.0 ) );
				float SelfBendMask34_g217 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g218 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g218 = 0.0;
				else
				ifLocalVar33_g218 = 1.0;
				float ifLocalVar34_g218 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g218 = 0.0;
				else
				ifLocalVar34_g218 = 1.0;
				float3 lerpResult41_g218 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g218 + ifLocalVar34_g218 ));
				float3 WindVector47_g218 = lerpResult41_g218;
				float3 objToWorld6_g219 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g218 = (( objToWorld6_g219 / _WindDirectionMapScale )).xz;
				float2 panner7_g218 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode11_g218 = tex2Dlod( _WindDirectionMap, float4( panner7_g218, 0, 0.0) );
				float2 RotationMapLF16_g218 = (tex2DNode11_g218).rg;
				float2 break35_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g218 = (float3(( break35_g218.x * -1.0 ) , 0.0 , break35_g218.y));
				float2 panner9_g218 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode10_g218 = tex2Dlod( _WindDirectionMap, float4( panner9_g218, 0, 0.0) );
				float2 RotationMapHF17_g218 = (tex2DNode10_g218).ba;
				float2 break36_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g218 = (float3(( break36_g218.x * -1.0 ) , 0.0 , break36_g218.y));
				float3 lerpResult48_g218 = lerp( appendResult42_g218 , appendResult43_g218 , _HFRotationMapInfluence);
				float3 lerpResult51_g218 = lerp( WindVector47_g218 , lerpResult48_g218 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g218 = lerpResult51_g218;
				#else
				float3 staticSwitch55_g218 = WindVector47_g218;
				#endif
				float3 worldToObjDir52_g218 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g218, 0.0 ) ).xyz;
				float3 WindVector226_g217 = worldToObjDir52_g218;
				float3 appendResult11_g217 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g217 = ( 0.001 * appendResult11_g217 );
				float3 SelfPivot28_g217 = temp_output_19_0_g217;
				float3 objToWorld54_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g217 * 1.0 ) + ( objToWorld54_g217 / -2.0 ) )).z).xx;
				float2 panner48_g217 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g217 = snoise( panner48_g217*_ChildWindMapScale );
				simplePerlin2D53_g217 = simplePerlin2D53_g217*0.5 + 0.5;
				float ChildRotation43_g217 = radians( ( simplePerlin2D53_g217 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g217 = RotateAroundAxis( SelfPivot28_g217, input.positionOS.xyz, normalize( WindVector226_g217 ), ChildRotation43_g217 );
				float3 ChildRotationResult119_g217 = ( ( ChildMask26_g217 * SelfBendMask34_g217 ) * ( rotatedValue81_g217 - input.positionOS.xyz ) );
				float temp_output_113_0_g217 = saturate( ( 4.0 * pow( SelfBendMask34_g217 , _BendingMaskStrength ) ) );
				float dotResult9_g217 = dot( temp_output_19_0_g217 , temp_output_19_0_g217 );
				float ifLocalVar189_g217 = 0;
				if( dotResult9_g217 > 0.0001 )
				ifLocalVar189_g217 = 1.0;
				else if( dotResult9_g217 < 0.0001 )
				ifLocalVar189_g217 = 0.0;
				float TrunkMask29_g217 = saturate( ( ifLocalVar189_g217 * 1000.0 ) );
				float3 ParentPivot27_g217 = temp_output_20_0_g217;
				float3 lerpResult51_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float2 temp_cast_2 = ((( lerpResult51_g217 / -0.2 )).z).xx;
				float2 panner61_g217 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g217 = snoise( panner61_g217*_ParentWindMapScale );
				simplePerlin2D60_g217 = simplePerlin2D60_g217*0.5 + 0.5;
				float saferPower185_g217 = abs( simplePerlin2D60_g217 );
				float saferPower160_g217 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g217 = saturate( pow( saferPower160_g217 , _MainBendMaskStrength ) );
				float ParentRotation63_g217 = radians( ( pow( saferPower185_g217 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g217 ) );
				float3 lerpResult98_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float3 rotatedValue96_g217 = RotateAroundAxis( lerpResult98_g217, ( ChildRotationResult119_g217 + input.positionOS.xyz ), normalize( WindVector226_g217 ), ParentRotation63_g217 );
				float3 ParentRotationResult131_g217 = ( ChildRotationResult119_g217 + ( ( ( ( ( temp_output_113_0_g217 * ( 1.0 - ChildMask26_g217 ) ) + ChildMask26_g217 ) * TrunkMask29_g217 ) * ( rotatedValue96_g217 - input.positionOS.xyz ) ) * MainBendMask35_g217 ) );
				float3 objToWorld47_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g217 = abs( ( objToWorld47_g217 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g217 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g217 , 2.0 )).xz);
				float simplePerlin2D70_g217 = snoise( panner71_g217*2.0 );
				simplePerlin2D70_g217 = simplePerlin2D70_g217*0.5 + 0.5;
				float MainRotation67_g217 = radians( ( simplePerlin2D70_g217 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g217 = ( ParentRotationResult131_g217 + input.positionOS.xyz );
				float3 rotatedValue121_g217 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g217, normalize( WindVector226_g217 ), MainRotation67_g217 );
				float temp_output_148_0_g217 = pow( MainBendMask35_g217 , 5.0 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner86 = ( 1.0 * _Time.y * float2( -0.2,0.4 ) + (( ase_positionWS / -8.0 )).xz);
				float simplePerlin2D85 = snoise( panner86*10.0 );
				simplePerlin2D85 = simplePerlin2D85*0.5 + 0.5;
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch287 = ( ( ( ParentRotationResult131_g217 + ( ( rotatedValue121_g217 - temp_output_125_0_g217 ) * temp_output_148_0_g217 ) ) * _WindOverallStrength * TF_WIND_STRENGTH ) + ( ( ( 1.0 - input.ase_color.b ) * _LeafFlutterStrength ) * ( input.ase_texcoord.y * simplePerlin2D85 ) * TF_WIND_STRENGTH * 0.6 ) );
				#else
				float3 staticSwitch287 = temp_cast_0;
				#endif
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch287;

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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
				output.ase_texcoord1 = input.ase_texcoord1;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

				float2 texCoord62_g213 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g213 = tex2D( _ColorMap, texCoord62_g213 );
				float Opacity34 = tex2DNode1_g213.a;
				
				float lerpResult167 = lerp( _MaskClip , ( _MaskClip * 0.4 ) , ( distance( PositionWS , _WorldSpaceCameraPos ) / 150.0 ));
				#ifdef _DISTANCEBASEDMASKCLIP_ON
				float staticSwitch196 = lerpResult167;
				#else
				float staticSwitch196 = _MaskClip;
				#endif
				float Mask_Clip157 = staticSwitch196;
				

				float Alpha = Opacity34;
				float AlphaClipThreshold = Mask_Clip157;

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
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_TEXTURE_COORDINATES4
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES4
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TANGENT
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature _TFW_FLIPNORMALS
			#pragma shader_feature_local _USECOLORVARIANCE_ON
			#pragma shader_feature_local _DISTANCEBASEDMASKCLIP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
			#pragma multi_compilefragment  LOD_FADE_CROSSFADE


			struct Attributes
			{
				float4 positionOS : POSITION;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_color : COLOR;
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
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_texcoord6 : TEXCOORD6;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _Color;
			float4 _Undercolor;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _HueTest;
			float _ColorVarianceBiasShift;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _ColorVarianceMin;
			float _ColorVarianceMax;
			float _ColorVarianceIntensity;
			float _BrightnessVarianceIntensity;
			float _Specular;
			float _Smoothness;
			float _VertexAOIntensity;
			float _AOIntensity;
			float _MaskClip;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _UndercolorAmount;
			float _Transmission;
			float _WindDirectionMapScale;
			float _HFRotationMapInfluence;
			float _WindDirectionMapInfluence;
			float _ChildWindMapScale;
			float _ChildWindStrength;
			float _BendingMaskStrength;
			float _BaseColorContrast;
			float _ParentWindMapScale;
			float _MainBendMaskStrength;
			float _MainWindScale;
			float _MainWindStrength;
			float _WindOverallStrength;
			float _LeafFlutterStrength;
			float _NormalScale;
			float _ParentWindStrength;
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
			float TF_WIND_STRENGTH;
			sampler2D _ColorMap;
			sampler2D _NormalMap;
			sampler2D _MaskMap;
			float TF_ColorVarianceBiasShift;
			sampler2D _ColorVarianceMask;
			float TF_ColorVarianceMaskScale;
			float TF_ColorVarianceMin;
			float TF_ColorVarianceMax;
			float TF_ColorVarianceIntensity;
			float TF_BrightnessVariance;
			int TF_ColorVarianceEnable;


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
				float3 appendResult18_g217 = (float3(( -1.0 * input.texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g217 = ( 0.001 * appendResult18_g217 );
				float dotResult16_g217 = dot( temp_output_20_0_g217 , temp_output_20_0_g217 );
				float ifLocalVar182_g217 = 0;
				if( dotResult16_g217 > 0.0001 )
				ifLocalVar182_g217 = 1.0;
				else if( dotResult16_g217 < 0.0001 )
				ifLocalVar182_g217 = 0.0;
				float ChildMask26_g217 = saturate( ( ifLocalVar182_g217 * 100.0 ) );
				float SelfBendMask34_g217 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g218 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g218 = 0.0;
				else
				ifLocalVar33_g218 = 1.0;
				float ifLocalVar34_g218 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g218 = 0.0;
				else
				ifLocalVar34_g218 = 1.0;
				float3 lerpResult41_g218 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g218 + ifLocalVar34_g218 ));
				float3 WindVector47_g218 = lerpResult41_g218;
				float3 objToWorld6_g219 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g218 = (( objToWorld6_g219 / _WindDirectionMapScale )).xz;
				float2 panner7_g218 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode11_g218 = tex2Dlod( _WindDirectionMap, float4( panner7_g218, 0, 0.0) );
				float2 RotationMapLF16_g218 = (tex2DNode11_g218).rg;
				float2 break35_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g218 = (float3(( break35_g218.x * -1.0 ) , 0.0 , break35_g218.y));
				float2 panner9_g218 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode10_g218 = tex2Dlod( _WindDirectionMap, float4( panner9_g218, 0, 0.0) );
				float2 RotationMapHF17_g218 = (tex2DNode10_g218).ba;
				float2 break36_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g218 = (float3(( break36_g218.x * -1.0 ) , 0.0 , break36_g218.y));
				float3 lerpResult48_g218 = lerp( appendResult42_g218 , appendResult43_g218 , _HFRotationMapInfluence);
				float3 lerpResult51_g218 = lerp( WindVector47_g218 , lerpResult48_g218 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g218 = lerpResult51_g218;
				#else
				float3 staticSwitch55_g218 = WindVector47_g218;
				#endif
				float3 worldToObjDir52_g218 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g218, 0.0 ) ).xyz;
				float3 WindVector226_g217 = worldToObjDir52_g218;
				float3 appendResult11_g217 = (float3(( -1.0 * input.texcoord1.x ) , input.texcoord2.x , ( -1.0 * input.texcoord1.y )));
				float3 temp_output_19_0_g217 = ( 0.001 * appendResult11_g217 );
				float3 SelfPivot28_g217 = temp_output_19_0_g217;
				float3 objToWorld54_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g217 * 1.0 ) + ( objToWorld54_g217 / -2.0 ) )).z).xx;
				float2 panner48_g217 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g217 = snoise( panner48_g217*_ChildWindMapScale );
				simplePerlin2D53_g217 = simplePerlin2D53_g217*0.5 + 0.5;
				float ChildRotation43_g217 = radians( ( simplePerlin2D53_g217 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g217 = RotateAroundAxis( SelfPivot28_g217, input.positionOS.xyz, normalize( WindVector226_g217 ), ChildRotation43_g217 );
				float3 ChildRotationResult119_g217 = ( ( ChildMask26_g217 * SelfBendMask34_g217 ) * ( rotatedValue81_g217 - input.positionOS.xyz ) );
				float temp_output_113_0_g217 = saturate( ( 4.0 * pow( SelfBendMask34_g217 , _BendingMaskStrength ) ) );
				float dotResult9_g217 = dot( temp_output_19_0_g217 , temp_output_19_0_g217 );
				float ifLocalVar189_g217 = 0;
				if( dotResult9_g217 > 0.0001 )
				ifLocalVar189_g217 = 1.0;
				else if( dotResult9_g217 < 0.0001 )
				ifLocalVar189_g217 = 0.0;
				float TrunkMask29_g217 = saturate( ( ifLocalVar189_g217 * 1000.0 ) );
				float3 ParentPivot27_g217 = temp_output_20_0_g217;
				float3 lerpResult51_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float2 temp_cast_2 = ((( lerpResult51_g217 / -0.2 )).z).xx;
				float2 panner61_g217 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g217 = snoise( panner61_g217*_ParentWindMapScale );
				simplePerlin2D60_g217 = simplePerlin2D60_g217*0.5 + 0.5;
				float saferPower185_g217 = abs( simplePerlin2D60_g217 );
				float saferPower160_g217 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g217 = saturate( pow( saferPower160_g217 , _MainBendMaskStrength ) );
				float ParentRotation63_g217 = radians( ( pow( saferPower185_g217 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g217 ) );
				float3 lerpResult98_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float3 rotatedValue96_g217 = RotateAroundAxis( lerpResult98_g217, ( ChildRotationResult119_g217 + input.positionOS.xyz ), normalize( WindVector226_g217 ), ParentRotation63_g217 );
				float3 ParentRotationResult131_g217 = ( ChildRotationResult119_g217 + ( ( ( ( ( temp_output_113_0_g217 * ( 1.0 - ChildMask26_g217 ) ) + ChildMask26_g217 ) * TrunkMask29_g217 ) * ( rotatedValue96_g217 - input.positionOS.xyz ) ) * MainBendMask35_g217 ) );
				float3 objToWorld47_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g217 = abs( ( objToWorld47_g217 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g217 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g217 , 2.0 )).xz);
				float simplePerlin2D70_g217 = snoise( panner71_g217*2.0 );
				simplePerlin2D70_g217 = simplePerlin2D70_g217*0.5 + 0.5;
				float MainRotation67_g217 = radians( ( simplePerlin2D70_g217 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g217 = ( ParentRotationResult131_g217 + input.positionOS.xyz );
				float3 rotatedValue121_g217 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g217, normalize( WindVector226_g217 ), MainRotation67_g217 );
				float temp_output_148_0_g217 = pow( MainBendMask35_g217 , 5.0 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner86 = ( 1.0 * _Time.y * float2( -0.2,0.4 ) + (( ase_positionWS / -8.0 )).xz);
				float simplePerlin2D85 = snoise( panner86*10.0 );
				simplePerlin2D85 = simplePerlin2D85*0.5 + 0.5;
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch287 = ( ( ( ParentRotationResult131_g217 + ( ( rotatedValue121_g217 - temp_output_125_0_g217 ) * temp_output_148_0_g217 ) ) * _WindOverallStrength * TF_WIND_STRENGTH ) + ( ( ( 1.0 - input.ase_color.b ) * _LeafFlutterStrength ) * ( input.texcoord0.y * simplePerlin2D85 ) * TF_WIND_STRENGTH * 0.6 ) );
				#else
				float3 staticSwitch287 = temp_cast_0;
				#endif
				
				float3 ase_tangentWS = TransformObjectToWorldDir( input.tangentOS.xyz );
				output.ase_texcoord4.xyz = ase_tangentWS;
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord5.xyz = ase_normalWS;
				float ase_tangentSign = input.tangentOS.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord6.xyz = ase_bitangentWS;
				
				output.ase_texcoord3.xy = input.texcoord0.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord3.zw = 0;
				output.ase_texcoord4.w = 0;
				output.ase_texcoord5.w = 0;
				output.ase_texcoord6.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch287;

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
				float4 ase_texcoord4 : TEXCOORD4;
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
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
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
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
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

			half4 frag(PackedVaryings input , bool ase_vface : SV_IsFrontFace ) : SV_Target
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

				float2 texCoord62_g213 = input.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g213 = tex2D( _ColorMap, texCoord62_g213 );
				float4 ColorClean386 = tex2DNode1_g213;
				float3 unpack7_g213 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g213 ), _NormalScale );
				unpack7_g213.z = lerp( 1, unpack7_g213.z, saturate(_NormalScale) );
				float3 temp_output_6_0_g220 = unpack7_g213;
				float3 break1_g220 = temp_output_6_0_g220;
				float switchResult4_g220 = (((ase_vface>0)?(break1_g220.z):(-break1_g220.z)));
				float3 appendResult3_g220 = (float3(break1_g220.x , break1_g220.y , switchResult4_g220));
				#ifdef _TFW_FLIPNORMALS
				float3 staticSwitch5_g220 = appendResult3_g220;
				#else
				float3 staticSwitch5_g220 = temp_output_6_0_g220;
				#endif
				float3 FinalNormal8 = staticSwitch5_g220;
				float3 ase_tangentWS = input.ase_texcoord4.xyz;
				float3 ase_normalWS = input.ase_texcoord5.xyz;
				float3 ase_bitangentWS = input.ase_texcoord6.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal377 = FinalNormal8;
				float3 worldNormal377 = normalize( float3( dot( tanToWorld0, tanNormal377 ), dot( tanToWorld1, tanNormal377 ), dot( tanToWorld2, tanNormal377 ) ) );
				float4 lerpResult263 = lerp( _Undercolor , _Color , saturate( ( worldNormal377.y + _UndercolorAmount ) ));
				float3 temp_output_12_0_g216 = tex2DNode1_g213.rgb;
				float dotResult28_g216 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g216 );
				float3 temp_cast_1 = (dotResult28_g216).xxx;
				float temp_output_21_0_g216 = _BaseColorSaturation;
				float3 lerpResult31_g216 = lerp( temp_cast_1 , temp_output_12_0_g216 , temp_output_21_0_g216);
				float4 color380 = IsGammaSpace() ? float4( 1, 1, 1, 0 ) : float4( 1, 1, 1, 0 );
				float3 hsvTorgb14_g215 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g216 * _BaseColorBrightness ) , 0.0 )) * color380 ).rgb );
				float3 hsvTorgb13_g215 = HSVToRGB( float3(( hsvTorgb14_g215.x + _HueTest ),hsvTorgb14_g215.y,hsvTorgb14_g215.z) );
				float3 Color385 = hsvTorgb13_g215;
				float2 uv_MaskMap = input.ase_texcoord3.xy * _MaskMap_ST.xy + _MaskMap_ST.zw;
				float4 tex2DNode1_g214 = tex2D( _MaskMap, uv_MaskMap );
				float temp_output_376_28 = tex2DNode1_g214.b;
				float ColorMask389 = temp_output_376_28;
				float4 lerpResult375 = lerp( ColorClean386 , float4( Color385 , 0.0 ) , ColorMask389);
				float4 lerpResult383 = lerp( ColorClean386 , ( lerpResult263 * lerpResult375 ) , ColorMask389);
				float4 LeafColor392 = lerpResult383;
				float4 temp_output_13_0_g223 = LeafColor392;
				float3 objToWorld6_g221 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float4 tex2DNode8_g223 = tex2D( _ColorVarianceMask, (( objToWorld6_g221 / ( TF_ColorVarianceMaskScale * _ColorVarianceMaskScale ) )).xz );
				float3 hsvTorgb3_g223 = RGBToHSV( temp_output_13_0_g223.rgb );
				float3 hsvTorgb1_g223 = HSVToRGB( float3(( ( ( _ColorVarianceBiasShift * TF_ColorVarianceBiasShift ) +  (( _ColorVarianceMin * TF_ColorVarianceMin ) + ( pow( tex2DNode8_g223.g , _MaskContrast ) - 0.0 ) * ( ( _ColorVarianceMax * TF_ColorVarianceMax ) - ( _ColorVarianceMin * TF_ColorVarianceMin ) ) / ( 1.0 - 0.0 ) ) ) + hsvTorgb3_g223.x ),hsvTorgb3_g223.y,hsvTorgb3_g223.z) );
				float4 lerpResult38_g223 = lerp( temp_output_13_0_g223 , float4( hsvTorgb1_g223 , 0.0 ) , ( _ColorVarianceIntensity * TF_ColorVarianceIntensity ));
				float Value_Mask39_g223 = tex2DNode8_g223.a;
				float4 lerpResult44_g223 = lerp( lerpResult38_g223 , ( lerpResult38_g223 * Value_Mask39_g223 ) , ( _BrightnessVarianceIntensity * TF_BrightnessVariance ));
				float4 FinalValue46_g223 = lerpResult44_g223;
				#ifdef _USECOLORVARIANCE_ON
				float4 staticSwitch2_g223 = FinalValue46_g223;
				#else
				float4 staticSwitch2_g223 = temp_output_13_0_g223;
				#endif
				float4 lerpResult394 = lerp( ColorClean386 , staticSwitch2_g223 , ColorMask389);
				float4 lerpResult416 = lerp( LeafColor392 , lerpResult394 , (float)TF_ColorVarianceEnable);
				float4 FinalColor37 = lerpResult416;
				
				float Opacity34 = tex2DNode1_g213.a;
				
				float lerpResult167 = lerp( _MaskClip , ( _MaskClip * 0.4 ) , ( distance( PositionWS , _WorldSpaceCameraPos ) / 150.0 ));
				#ifdef _DISTANCEBASEDMASKCLIP_ON
				float staticSwitch196 = lerpResult167;
				#else
				float staticSwitch196 = _MaskClip;
				#endif
				float Mask_Clip157 = staticSwitch196;
				

				float3 BaseColor = FinalColor37.rgb;
				float3 Emission = 0;
				float Alpha = Opacity34;
				float AlphaClipThreshold = Mask_Clip157;

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
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_TEXTURE_COORDINATES4
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES4
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TANGENT
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature _TFW_FLIPNORMALS
			#pragma shader_feature_local _USECOLORVARIANCE_ON
			#pragma shader_feature_local _DISTANCEBASEDMASKCLIP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
			#pragma multi_compilefragment  LOD_FADE_CROSSFADE


			struct Attributes
			{
				float4 positionOS : POSITION;
				half3 normalOS : NORMAL;
				half4 tangentOS : TANGENT;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _Color;
			float4 _Undercolor;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _HueTest;
			float _ColorVarianceBiasShift;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _ColorVarianceMin;
			float _ColorVarianceMax;
			float _ColorVarianceIntensity;
			float _BrightnessVarianceIntensity;
			float _Specular;
			float _Smoothness;
			float _VertexAOIntensity;
			float _AOIntensity;
			float _MaskClip;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _UndercolorAmount;
			float _Transmission;
			float _WindDirectionMapScale;
			float _HFRotationMapInfluence;
			float _WindDirectionMapInfluence;
			float _ChildWindMapScale;
			float _ChildWindStrength;
			float _BendingMaskStrength;
			float _BaseColorContrast;
			float _ParentWindMapScale;
			float _MainBendMaskStrength;
			float _MainWindScale;
			float _MainWindStrength;
			float _WindOverallStrength;
			float _LeafFlutterStrength;
			float _NormalScale;
			float _ParentWindStrength;
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
			float TF_WIND_STRENGTH;
			sampler2D _ColorMap;
			sampler2D _NormalMap;
			sampler2D _MaskMap;
			float TF_ColorVarianceBiasShift;
			sampler2D _ColorVarianceMask;
			float TF_ColorVarianceMaskScale;
			float TF_ColorVarianceMin;
			float TF_ColorVarianceMax;
			float TF_ColorVarianceIntensity;
			float TF_BrightnessVariance;
			int TF_ColorVarianceEnable;


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
				float3 appendResult18_g217 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g217 = ( 0.001 * appendResult18_g217 );
				float dotResult16_g217 = dot( temp_output_20_0_g217 , temp_output_20_0_g217 );
				float ifLocalVar182_g217 = 0;
				if( dotResult16_g217 > 0.0001 )
				ifLocalVar182_g217 = 1.0;
				else if( dotResult16_g217 < 0.0001 )
				ifLocalVar182_g217 = 0.0;
				float ChildMask26_g217 = saturate( ( ifLocalVar182_g217 * 100.0 ) );
				float SelfBendMask34_g217 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g218 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g218 = 0.0;
				else
				ifLocalVar33_g218 = 1.0;
				float ifLocalVar34_g218 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g218 = 0.0;
				else
				ifLocalVar34_g218 = 1.0;
				float3 lerpResult41_g218 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g218 + ifLocalVar34_g218 ));
				float3 WindVector47_g218 = lerpResult41_g218;
				float3 objToWorld6_g219 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g218 = (( objToWorld6_g219 / _WindDirectionMapScale )).xz;
				float2 panner7_g218 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode11_g218 = tex2Dlod( _WindDirectionMap, float4( panner7_g218, 0, 0.0) );
				float2 RotationMapLF16_g218 = (tex2DNode11_g218).rg;
				float2 break35_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g218 = (float3(( break35_g218.x * -1.0 ) , 0.0 , break35_g218.y));
				float2 panner9_g218 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode10_g218 = tex2Dlod( _WindDirectionMap, float4( panner9_g218, 0, 0.0) );
				float2 RotationMapHF17_g218 = (tex2DNode10_g218).ba;
				float2 break36_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g218 = (float3(( break36_g218.x * -1.0 ) , 0.0 , break36_g218.y));
				float3 lerpResult48_g218 = lerp( appendResult42_g218 , appendResult43_g218 , _HFRotationMapInfluence);
				float3 lerpResult51_g218 = lerp( WindVector47_g218 , lerpResult48_g218 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g218 = lerpResult51_g218;
				#else
				float3 staticSwitch55_g218 = WindVector47_g218;
				#endif
				float3 worldToObjDir52_g218 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g218, 0.0 ) ).xyz;
				float3 WindVector226_g217 = worldToObjDir52_g218;
				float3 appendResult11_g217 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g217 = ( 0.001 * appendResult11_g217 );
				float3 SelfPivot28_g217 = temp_output_19_0_g217;
				float3 objToWorld54_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g217 * 1.0 ) + ( objToWorld54_g217 / -2.0 ) )).z).xx;
				float2 panner48_g217 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g217 = snoise( panner48_g217*_ChildWindMapScale );
				simplePerlin2D53_g217 = simplePerlin2D53_g217*0.5 + 0.5;
				float ChildRotation43_g217 = radians( ( simplePerlin2D53_g217 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g217 = RotateAroundAxis( SelfPivot28_g217, input.positionOS.xyz, normalize( WindVector226_g217 ), ChildRotation43_g217 );
				float3 ChildRotationResult119_g217 = ( ( ChildMask26_g217 * SelfBendMask34_g217 ) * ( rotatedValue81_g217 - input.positionOS.xyz ) );
				float temp_output_113_0_g217 = saturate( ( 4.0 * pow( SelfBendMask34_g217 , _BendingMaskStrength ) ) );
				float dotResult9_g217 = dot( temp_output_19_0_g217 , temp_output_19_0_g217 );
				float ifLocalVar189_g217 = 0;
				if( dotResult9_g217 > 0.0001 )
				ifLocalVar189_g217 = 1.0;
				else if( dotResult9_g217 < 0.0001 )
				ifLocalVar189_g217 = 0.0;
				float TrunkMask29_g217 = saturate( ( ifLocalVar189_g217 * 1000.0 ) );
				float3 ParentPivot27_g217 = temp_output_20_0_g217;
				float3 lerpResult51_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float2 temp_cast_2 = ((( lerpResult51_g217 / -0.2 )).z).xx;
				float2 panner61_g217 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g217 = snoise( panner61_g217*_ParentWindMapScale );
				simplePerlin2D60_g217 = simplePerlin2D60_g217*0.5 + 0.5;
				float saferPower185_g217 = abs( simplePerlin2D60_g217 );
				float saferPower160_g217 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g217 = saturate( pow( saferPower160_g217 , _MainBendMaskStrength ) );
				float ParentRotation63_g217 = radians( ( pow( saferPower185_g217 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g217 ) );
				float3 lerpResult98_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float3 rotatedValue96_g217 = RotateAroundAxis( lerpResult98_g217, ( ChildRotationResult119_g217 + input.positionOS.xyz ), normalize( WindVector226_g217 ), ParentRotation63_g217 );
				float3 ParentRotationResult131_g217 = ( ChildRotationResult119_g217 + ( ( ( ( ( temp_output_113_0_g217 * ( 1.0 - ChildMask26_g217 ) ) + ChildMask26_g217 ) * TrunkMask29_g217 ) * ( rotatedValue96_g217 - input.positionOS.xyz ) ) * MainBendMask35_g217 ) );
				float3 objToWorld47_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g217 = abs( ( objToWorld47_g217 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g217 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g217 , 2.0 )).xz);
				float simplePerlin2D70_g217 = snoise( panner71_g217*2.0 );
				simplePerlin2D70_g217 = simplePerlin2D70_g217*0.5 + 0.5;
				float MainRotation67_g217 = radians( ( simplePerlin2D70_g217 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g217 = ( ParentRotationResult131_g217 + input.positionOS.xyz );
				float3 rotatedValue121_g217 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g217, normalize( WindVector226_g217 ), MainRotation67_g217 );
				float temp_output_148_0_g217 = pow( MainBendMask35_g217 , 5.0 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner86 = ( 1.0 * _Time.y * float2( -0.2,0.4 ) + (( ase_positionWS / -8.0 )).xz);
				float simplePerlin2D85 = snoise( panner86*10.0 );
				simplePerlin2D85 = simplePerlin2D85*0.5 + 0.5;
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch287 = ( ( ( ParentRotationResult131_g217 + ( ( rotatedValue121_g217 - temp_output_125_0_g217 ) * temp_output_148_0_g217 ) ) * _WindOverallStrength * TF_WIND_STRENGTH ) + ( ( ( 1.0 - input.ase_color.b ) * _LeafFlutterStrength ) * ( input.ase_texcoord.y * simplePerlin2D85 ) * TF_WIND_STRENGTH * 0.6 ) );
				#else
				float3 staticSwitch287 = temp_cast_0;
				#endif
				
				float3 ase_tangentWS = TransformObjectToWorldDir( input.tangentOS.xyz );
				output.ase_texcoord2.xyz = ase_tangentWS;
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord3.xyz = ase_normalWS;
				float ase_tangentSign = input.tangentOS.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord4.xyz = ase_bitangentWS;
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord1.zw = 0;
				output.ase_texcoord2.w = 0;
				output.ase_texcoord3.w = 0;
				output.ase_texcoord4.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch287;

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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
				output.ase_texcoord1 = input.ase_texcoord1;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

			half4 frag(PackedVaryings input , bool ase_vface : SV_IsFrontFace ) : SV_Target
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

				float2 texCoord62_g213 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g213 = tex2D( _ColorMap, texCoord62_g213 );
				float4 ColorClean386 = tex2DNode1_g213;
				float3 unpack7_g213 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g213 ), _NormalScale );
				unpack7_g213.z = lerp( 1, unpack7_g213.z, saturate(_NormalScale) );
				float3 temp_output_6_0_g220 = unpack7_g213;
				float3 break1_g220 = temp_output_6_0_g220;
				float switchResult4_g220 = (((ase_vface>0)?(break1_g220.z):(-break1_g220.z)));
				float3 appendResult3_g220 = (float3(break1_g220.x , break1_g220.y , switchResult4_g220));
				#ifdef _TFW_FLIPNORMALS
				float3 staticSwitch5_g220 = appendResult3_g220;
				#else
				float3 staticSwitch5_g220 = temp_output_6_0_g220;
				#endif
				float3 FinalNormal8 = staticSwitch5_g220;
				float3 ase_tangentWS = input.ase_texcoord2.xyz;
				float3 ase_normalWS = input.ase_texcoord3.xyz;
				float3 ase_bitangentWS = input.ase_texcoord4.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal377 = FinalNormal8;
				float3 worldNormal377 = normalize( float3( dot( tanToWorld0, tanNormal377 ), dot( tanToWorld1, tanNormal377 ), dot( tanToWorld2, tanNormal377 ) ) );
				float4 lerpResult263 = lerp( _Undercolor , _Color , saturate( ( worldNormal377.y + _UndercolorAmount ) ));
				float3 temp_output_12_0_g216 = tex2DNode1_g213.rgb;
				float dotResult28_g216 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g216 );
				float3 temp_cast_1 = (dotResult28_g216).xxx;
				float temp_output_21_0_g216 = _BaseColorSaturation;
				float3 lerpResult31_g216 = lerp( temp_cast_1 , temp_output_12_0_g216 , temp_output_21_0_g216);
				float4 color380 = IsGammaSpace() ? float4( 1, 1, 1, 0 ) : float4( 1, 1, 1, 0 );
				float3 hsvTorgb14_g215 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g216 * _BaseColorBrightness ) , 0.0 )) * color380 ).rgb );
				float3 hsvTorgb13_g215 = HSVToRGB( float3(( hsvTorgb14_g215.x + _HueTest ),hsvTorgb14_g215.y,hsvTorgb14_g215.z) );
				float3 Color385 = hsvTorgb13_g215;
				float2 uv_MaskMap = input.ase_texcoord1.xy * _MaskMap_ST.xy + _MaskMap_ST.zw;
				float4 tex2DNode1_g214 = tex2D( _MaskMap, uv_MaskMap );
				float temp_output_376_28 = tex2DNode1_g214.b;
				float ColorMask389 = temp_output_376_28;
				float4 lerpResult375 = lerp( ColorClean386 , float4( Color385 , 0.0 ) , ColorMask389);
				float4 lerpResult383 = lerp( ColorClean386 , ( lerpResult263 * lerpResult375 ) , ColorMask389);
				float4 LeafColor392 = lerpResult383;
				float4 temp_output_13_0_g223 = LeafColor392;
				float3 objToWorld6_g221 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float4 tex2DNode8_g223 = tex2D( _ColorVarianceMask, (( objToWorld6_g221 / ( TF_ColorVarianceMaskScale * _ColorVarianceMaskScale ) )).xz );
				float3 hsvTorgb3_g223 = RGBToHSV( temp_output_13_0_g223.rgb );
				float3 hsvTorgb1_g223 = HSVToRGB( float3(( ( ( _ColorVarianceBiasShift * TF_ColorVarianceBiasShift ) +  (( _ColorVarianceMin * TF_ColorVarianceMin ) + ( pow( tex2DNode8_g223.g , _MaskContrast ) - 0.0 ) * ( ( _ColorVarianceMax * TF_ColorVarianceMax ) - ( _ColorVarianceMin * TF_ColorVarianceMin ) ) / ( 1.0 - 0.0 ) ) ) + hsvTorgb3_g223.x ),hsvTorgb3_g223.y,hsvTorgb3_g223.z) );
				float4 lerpResult38_g223 = lerp( temp_output_13_0_g223 , float4( hsvTorgb1_g223 , 0.0 ) , ( _ColorVarianceIntensity * TF_ColorVarianceIntensity ));
				float Value_Mask39_g223 = tex2DNode8_g223.a;
				float4 lerpResult44_g223 = lerp( lerpResult38_g223 , ( lerpResult38_g223 * Value_Mask39_g223 ) , ( _BrightnessVarianceIntensity * TF_BrightnessVariance ));
				float4 FinalValue46_g223 = lerpResult44_g223;
				#ifdef _USECOLORVARIANCE_ON
				float4 staticSwitch2_g223 = FinalValue46_g223;
				#else
				float4 staticSwitch2_g223 = temp_output_13_0_g223;
				#endif
				float4 lerpResult394 = lerp( ColorClean386 , staticSwitch2_g223 , ColorMask389);
				float4 lerpResult416 = lerp( LeafColor392 , lerpResult394 , (float)TF_ColorVarianceEnable);
				float4 FinalColor37 = lerpResult416;
				
				float Opacity34 = tex2DNode1_g213.a;
				
				float lerpResult167 = lerp( _MaskClip , ( _MaskClip * 0.4 ) , ( distance( PositionWS , _WorldSpaceCameraPos ) / 150.0 ));
				#ifdef _DISTANCEBASEDMASKCLIP_ON
				float staticSwitch196 = lerpResult167;
				#else
				float staticSwitch196 = _MaskClip;
				#endif
				float Mask_Clip157 = staticSwitch196;
				

				float3 BaseColor = FinalColor37.rgb;
				float Alpha = Opacity34;
				float AlphaClipThreshold = Mask_Clip157;

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
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define ASE_TRANSMISSION 1
			#define _SPECULAR_SETUP 1
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
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
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_TEXTURE_COORDINATES4
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES4
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature _TFW_FLIPNORMALS
			#pragma shader_feature_local _DISTANCEBASEDMASKCLIP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
			#pragma multi_compilefragment  LOD_FADE_CROSSFADE


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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
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
			float4 _Color;
			float4 _Undercolor;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _HueTest;
			float _ColorVarianceBiasShift;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _ColorVarianceMin;
			float _ColorVarianceMax;
			float _ColorVarianceIntensity;
			float _BrightnessVarianceIntensity;
			float _Specular;
			float _Smoothness;
			float _VertexAOIntensity;
			float _AOIntensity;
			float _MaskClip;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _UndercolorAmount;
			float _Transmission;
			float _WindDirectionMapScale;
			float _HFRotationMapInfluence;
			float _WindDirectionMapInfluence;
			float _ChildWindMapScale;
			float _ChildWindStrength;
			float _BendingMaskStrength;
			float _BaseColorContrast;
			float _ParentWindMapScale;
			float _MainBendMaskStrength;
			float _MainWindScale;
			float _MainWindStrength;
			float _WindOverallStrength;
			float _LeafFlutterStrength;
			float _NormalScale;
			float _ParentWindStrength;
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
			float TF_WIND_STRENGTH;
			sampler2D _NormalMap;
			sampler2D _ColorMap;


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
				float3 appendResult18_g217 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g217 = ( 0.001 * appendResult18_g217 );
				float dotResult16_g217 = dot( temp_output_20_0_g217 , temp_output_20_0_g217 );
				float ifLocalVar182_g217 = 0;
				if( dotResult16_g217 > 0.0001 )
				ifLocalVar182_g217 = 1.0;
				else if( dotResult16_g217 < 0.0001 )
				ifLocalVar182_g217 = 0.0;
				float ChildMask26_g217 = saturate( ( ifLocalVar182_g217 * 100.0 ) );
				float SelfBendMask34_g217 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g218 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g218 = 0.0;
				else
				ifLocalVar33_g218 = 1.0;
				float ifLocalVar34_g218 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g218 = 0.0;
				else
				ifLocalVar34_g218 = 1.0;
				float3 lerpResult41_g218 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g218 + ifLocalVar34_g218 ));
				float3 WindVector47_g218 = lerpResult41_g218;
				float3 objToWorld6_g219 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g218 = (( objToWorld6_g219 / _WindDirectionMapScale )).xz;
				float2 panner7_g218 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode11_g218 = tex2Dlod( _WindDirectionMap, float4( panner7_g218, 0, 0.0) );
				float2 RotationMapLF16_g218 = (tex2DNode11_g218).rg;
				float2 break35_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g218 = (float3(( break35_g218.x * -1.0 ) , 0.0 , break35_g218.y));
				float2 panner9_g218 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode10_g218 = tex2Dlod( _WindDirectionMap, float4( panner9_g218, 0, 0.0) );
				float2 RotationMapHF17_g218 = (tex2DNode10_g218).ba;
				float2 break36_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g218 = (float3(( break36_g218.x * -1.0 ) , 0.0 , break36_g218.y));
				float3 lerpResult48_g218 = lerp( appendResult42_g218 , appendResult43_g218 , _HFRotationMapInfluence);
				float3 lerpResult51_g218 = lerp( WindVector47_g218 , lerpResult48_g218 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g218 = lerpResult51_g218;
				#else
				float3 staticSwitch55_g218 = WindVector47_g218;
				#endif
				float3 worldToObjDir52_g218 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g218, 0.0 ) ).xyz;
				float3 WindVector226_g217 = worldToObjDir52_g218;
				float3 appendResult11_g217 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g217 = ( 0.001 * appendResult11_g217 );
				float3 SelfPivot28_g217 = temp_output_19_0_g217;
				float3 objToWorld54_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g217 * 1.0 ) + ( objToWorld54_g217 / -2.0 ) )).z).xx;
				float2 panner48_g217 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g217 = snoise( panner48_g217*_ChildWindMapScale );
				simplePerlin2D53_g217 = simplePerlin2D53_g217*0.5 + 0.5;
				float ChildRotation43_g217 = radians( ( simplePerlin2D53_g217 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g217 = RotateAroundAxis( SelfPivot28_g217, input.positionOS.xyz, normalize( WindVector226_g217 ), ChildRotation43_g217 );
				float3 ChildRotationResult119_g217 = ( ( ChildMask26_g217 * SelfBendMask34_g217 ) * ( rotatedValue81_g217 - input.positionOS.xyz ) );
				float temp_output_113_0_g217 = saturate( ( 4.0 * pow( SelfBendMask34_g217 , _BendingMaskStrength ) ) );
				float dotResult9_g217 = dot( temp_output_19_0_g217 , temp_output_19_0_g217 );
				float ifLocalVar189_g217 = 0;
				if( dotResult9_g217 > 0.0001 )
				ifLocalVar189_g217 = 1.0;
				else if( dotResult9_g217 < 0.0001 )
				ifLocalVar189_g217 = 0.0;
				float TrunkMask29_g217 = saturate( ( ifLocalVar189_g217 * 1000.0 ) );
				float3 ParentPivot27_g217 = temp_output_20_0_g217;
				float3 lerpResult51_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float2 temp_cast_2 = ((( lerpResult51_g217 / -0.2 )).z).xx;
				float2 panner61_g217 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g217 = snoise( panner61_g217*_ParentWindMapScale );
				simplePerlin2D60_g217 = simplePerlin2D60_g217*0.5 + 0.5;
				float saferPower185_g217 = abs( simplePerlin2D60_g217 );
				float saferPower160_g217 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g217 = saturate( pow( saferPower160_g217 , _MainBendMaskStrength ) );
				float ParentRotation63_g217 = radians( ( pow( saferPower185_g217 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g217 ) );
				float3 lerpResult98_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float3 rotatedValue96_g217 = RotateAroundAxis( lerpResult98_g217, ( ChildRotationResult119_g217 + input.positionOS.xyz ), normalize( WindVector226_g217 ), ParentRotation63_g217 );
				float3 ParentRotationResult131_g217 = ( ChildRotationResult119_g217 + ( ( ( ( ( temp_output_113_0_g217 * ( 1.0 - ChildMask26_g217 ) ) + ChildMask26_g217 ) * TrunkMask29_g217 ) * ( rotatedValue96_g217 - input.positionOS.xyz ) ) * MainBendMask35_g217 ) );
				float3 objToWorld47_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g217 = abs( ( objToWorld47_g217 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g217 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g217 , 2.0 )).xz);
				float simplePerlin2D70_g217 = snoise( panner71_g217*2.0 );
				simplePerlin2D70_g217 = simplePerlin2D70_g217*0.5 + 0.5;
				float MainRotation67_g217 = radians( ( simplePerlin2D70_g217 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g217 = ( ParentRotationResult131_g217 + input.positionOS.xyz );
				float3 rotatedValue121_g217 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g217, normalize( WindVector226_g217 ), MainRotation67_g217 );
				float temp_output_148_0_g217 = pow( MainBendMask35_g217 , 5.0 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner86 = ( 1.0 * _Time.y * float2( -0.2,0.4 ) + (( ase_positionWS / -8.0 )).xz);
				float simplePerlin2D85 = snoise( panner86*10.0 );
				simplePerlin2D85 = simplePerlin2D85*0.5 + 0.5;
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch287 = ( ( ( ParentRotationResult131_g217 + ( ( rotatedValue121_g217 - temp_output_125_0_g217 ) * temp_output_148_0_g217 ) ) * _WindOverallStrength * TF_WIND_STRENGTH ) + ( ( ( 1.0 - input.ase_color.b ) * _LeafFlutterStrength ) * ( input.ase_texcoord.y * simplePerlin2D85 ) * TF_WIND_STRENGTH * 0.6 ) );
				#else
				float3 staticSwitch287 = temp_cast_0;
				#endif
				
				output.ase_texcoord3.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord3.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch287;

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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
				output.ase_texcoord1 = input.ase_texcoord1;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

				float2 texCoord62_g213 = input.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack7_g213 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g213 ), _NormalScale );
				unpack7_g213.z = lerp( 1, unpack7_g213.z, saturate(_NormalScale) );
				float3 temp_output_6_0_g220 = unpack7_g213;
				float3 break1_g220 = temp_output_6_0_g220;
				float switchResult4_g220 = (((ase_vface>0)?(break1_g220.z):(-break1_g220.z)));
				float3 appendResult3_g220 = (float3(break1_g220.x , break1_g220.y , switchResult4_g220));
				#ifdef _TFW_FLIPNORMALS
				float3 staticSwitch5_g220 = appendResult3_g220;
				#else
				float3 staticSwitch5_g220 = temp_output_6_0_g220;
				#endif
				float3 FinalNormal8 = staticSwitch5_g220;
				
				float4 tex2DNode1_g213 = tex2D( _ColorMap, texCoord62_g213 );
				float Opacity34 = tex2DNode1_g213.a;
				
				float lerpResult167 = lerp( _MaskClip , ( _MaskClip * 0.4 ) , ( distance( PositionWS , _WorldSpaceCameraPos ) / 150.0 ));
				#ifdef _DISTANCEBASEDMASKCLIP_ON
				float staticSwitch196 = lerpResult167;
				#else
				float staticSwitch196 = _MaskClip;
				#endif
				float Mask_Clip157 = staticSwitch196;
				

				float3 Normal = FinalNormal8;
				float Alpha = Opacity34;
				float AlphaClipThreshold = Mask_Clip157;

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
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_TEXTURE_COORDINATES4
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES4
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _DISTANCEBASEDMASKCLIP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
			#pragma multi_compilefragment  LOD_FADE_CROSSFADE


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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
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
			float4 _Color;
			float4 _Undercolor;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _HueTest;
			float _ColorVarianceBiasShift;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _ColorVarianceMin;
			float _ColorVarianceMax;
			float _ColorVarianceIntensity;
			float _BrightnessVarianceIntensity;
			float _Specular;
			float _Smoothness;
			float _VertexAOIntensity;
			float _AOIntensity;
			float _MaskClip;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _UndercolorAmount;
			float _Transmission;
			float _WindDirectionMapScale;
			float _HFRotationMapInfluence;
			float _WindDirectionMapInfluence;
			float _ChildWindMapScale;
			float _ChildWindStrength;
			float _BendingMaskStrength;
			float _BaseColorContrast;
			float _ParentWindMapScale;
			float _MainBendMaskStrength;
			float _MainWindScale;
			float _MainWindStrength;
			float _WindOverallStrength;
			float _LeafFlutterStrength;
			float _NormalScale;
			float _ParentWindStrength;
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
			float TF_WIND_STRENGTH;
			sampler2D _ColorMap;


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
				float3 appendResult18_g217 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g217 = ( 0.001 * appendResult18_g217 );
				float dotResult16_g217 = dot( temp_output_20_0_g217 , temp_output_20_0_g217 );
				float ifLocalVar182_g217 = 0;
				if( dotResult16_g217 > 0.0001 )
				ifLocalVar182_g217 = 1.0;
				else if( dotResult16_g217 < 0.0001 )
				ifLocalVar182_g217 = 0.0;
				float ChildMask26_g217 = saturate( ( ifLocalVar182_g217 * 100.0 ) );
				float SelfBendMask34_g217 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g218 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g218 = 0.0;
				else
				ifLocalVar33_g218 = 1.0;
				float ifLocalVar34_g218 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g218 = 0.0;
				else
				ifLocalVar34_g218 = 1.0;
				float3 lerpResult41_g218 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g218 + ifLocalVar34_g218 ));
				float3 WindVector47_g218 = lerpResult41_g218;
				float3 objToWorld6_g219 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g218 = (( objToWorld6_g219 / _WindDirectionMapScale )).xz;
				float2 panner7_g218 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode11_g218 = tex2Dlod( _WindDirectionMap, float4( panner7_g218, 0, 0.0) );
				float2 RotationMapLF16_g218 = (tex2DNode11_g218).rg;
				float2 break35_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g218 = (float3(( break35_g218.x * -1.0 ) , 0.0 , break35_g218.y));
				float2 panner9_g218 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode10_g218 = tex2Dlod( _WindDirectionMap, float4( panner9_g218, 0, 0.0) );
				float2 RotationMapHF17_g218 = (tex2DNode10_g218).ba;
				float2 break36_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g218 = (float3(( break36_g218.x * -1.0 ) , 0.0 , break36_g218.y));
				float3 lerpResult48_g218 = lerp( appendResult42_g218 , appendResult43_g218 , _HFRotationMapInfluence);
				float3 lerpResult51_g218 = lerp( WindVector47_g218 , lerpResult48_g218 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g218 = lerpResult51_g218;
				#else
				float3 staticSwitch55_g218 = WindVector47_g218;
				#endif
				float3 worldToObjDir52_g218 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g218, 0.0 ) ).xyz;
				float3 WindVector226_g217 = worldToObjDir52_g218;
				float3 appendResult11_g217 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g217 = ( 0.001 * appendResult11_g217 );
				float3 SelfPivot28_g217 = temp_output_19_0_g217;
				float3 objToWorld54_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g217 * 1.0 ) + ( objToWorld54_g217 / -2.0 ) )).z).xx;
				float2 panner48_g217 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g217 = snoise( panner48_g217*_ChildWindMapScale );
				simplePerlin2D53_g217 = simplePerlin2D53_g217*0.5 + 0.5;
				float ChildRotation43_g217 = radians( ( simplePerlin2D53_g217 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g217 = RotateAroundAxis( SelfPivot28_g217, input.positionOS.xyz, normalize( WindVector226_g217 ), ChildRotation43_g217 );
				float3 ChildRotationResult119_g217 = ( ( ChildMask26_g217 * SelfBendMask34_g217 ) * ( rotatedValue81_g217 - input.positionOS.xyz ) );
				float temp_output_113_0_g217 = saturate( ( 4.0 * pow( SelfBendMask34_g217 , _BendingMaskStrength ) ) );
				float dotResult9_g217 = dot( temp_output_19_0_g217 , temp_output_19_0_g217 );
				float ifLocalVar189_g217 = 0;
				if( dotResult9_g217 > 0.0001 )
				ifLocalVar189_g217 = 1.0;
				else if( dotResult9_g217 < 0.0001 )
				ifLocalVar189_g217 = 0.0;
				float TrunkMask29_g217 = saturate( ( ifLocalVar189_g217 * 1000.0 ) );
				float3 ParentPivot27_g217 = temp_output_20_0_g217;
				float3 lerpResult51_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float2 temp_cast_2 = ((( lerpResult51_g217 / -0.2 )).z).xx;
				float2 panner61_g217 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g217 = snoise( panner61_g217*_ParentWindMapScale );
				simplePerlin2D60_g217 = simplePerlin2D60_g217*0.5 + 0.5;
				float saferPower185_g217 = abs( simplePerlin2D60_g217 );
				float saferPower160_g217 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g217 = saturate( pow( saferPower160_g217 , _MainBendMaskStrength ) );
				float ParentRotation63_g217 = radians( ( pow( saferPower185_g217 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g217 ) );
				float3 lerpResult98_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float3 rotatedValue96_g217 = RotateAroundAxis( lerpResult98_g217, ( ChildRotationResult119_g217 + input.positionOS.xyz ), normalize( WindVector226_g217 ), ParentRotation63_g217 );
				float3 ParentRotationResult131_g217 = ( ChildRotationResult119_g217 + ( ( ( ( ( temp_output_113_0_g217 * ( 1.0 - ChildMask26_g217 ) ) + ChildMask26_g217 ) * TrunkMask29_g217 ) * ( rotatedValue96_g217 - input.positionOS.xyz ) ) * MainBendMask35_g217 ) );
				float3 objToWorld47_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g217 = abs( ( objToWorld47_g217 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g217 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g217 , 2.0 )).xz);
				float simplePerlin2D70_g217 = snoise( panner71_g217*2.0 );
				simplePerlin2D70_g217 = simplePerlin2D70_g217*0.5 + 0.5;
				float MainRotation67_g217 = radians( ( simplePerlin2D70_g217 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g217 = ( ParentRotationResult131_g217 + input.positionOS.xyz );
				float3 rotatedValue121_g217 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g217, normalize( WindVector226_g217 ), MainRotation67_g217 );
				float temp_output_148_0_g217 = pow( MainBendMask35_g217 , 5.0 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner86 = ( 1.0 * _Time.y * float2( -0.2,0.4 ) + (( ase_positionWS / -8.0 )).xz);
				float simplePerlin2D85 = snoise( panner86*10.0 );
				simplePerlin2D85 = simplePerlin2D85*0.5 + 0.5;
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch287 = ( ( ( ParentRotationResult131_g217 + ( ( rotatedValue121_g217 - temp_output_125_0_g217 ) * temp_output_148_0_g217 ) ) * _WindOverallStrength * TF_WIND_STRENGTH ) + ( ( ( 1.0 - input.ase_color.b ) * _LeafFlutterStrength ) * ( input.ase_texcoord.y * simplePerlin2D85 ) * TF_WIND_STRENGTH * 0.6 ) );
				#else
				float3 staticSwitch287 = temp_cast_0;
				#endif
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch287;

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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
				output.ase_texcoord1 = input.ase_texcoord1;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

				float2 texCoord62_g213 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g213 = tex2D( _ColorMap, texCoord62_g213 );
				float Opacity34 = tex2DNode1_g213.a;
				
				float lerpResult167 = lerp( _MaskClip , ( _MaskClip * 0.4 ) , ( distance( PositionWS , _WorldSpaceCameraPos ) / 150.0 ));
				#ifdef _DISTANCEBASEDMASKCLIP_ON
				float staticSwitch196 = lerpResult167;
				#else
				float staticSwitch196 = _MaskClip;
				#endif
				float Mask_Clip157 = staticSwitch196;
				

				surfaceDescription.Alpha = Opacity34;
				surfaceDescription.AlphaClipThreshold = Mask_Clip157;

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
			#define ASE_NEEDS_TEXTURE_COORDINATES3
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES3
			#define ASE_NEEDS_TEXTURE_COORDINATES4
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES4
			#define ASE_NEEDS_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES1
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_VERT_TEXTURE_COORDINATES0
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _DISTANCEBASEDMASKCLIP_ON
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
			#pragma multi_compilefragment  LOD_FADE_CROSSFADE


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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
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
			float4 _Color;
			float4 _Undercolor;
			float4 _MaskMap_ST;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _HueTest;
			float _ColorVarianceBiasShift;
			float _ColorVarianceMaskScale;
			float _MaskContrast;
			float _ColorVarianceMin;
			float _ColorVarianceMax;
			float _ColorVarianceIntensity;
			float _BrightnessVarianceIntensity;
			float _Specular;
			float _Smoothness;
			float _VertexAOIntensity;
			float _AOIntensity;
			float _MaskClip;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _UndercolorAmount;
			float _Transmission;
			float _WindDirectionMapScale;
			float _HFRotationMapInfluence;
			float _WindDirectionMapInfluence;
			float _ChildWindMapScale;
			float _ChildWindStrength;
			float _BendingMaskStrength;
			float _BaseColorContrast;
			float _ParentWindMapScale;
			float _MainBendMaskStrength;
			float _MainWindScale;
			float _MainWindStrength;
			float _WindOverallStrength;
			float _LeafFlutterStrength;
			float _NormalScale;
			float _ParentWindStrength;
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
			float TF_WIND_STRENGTH;
			sampler2D _ColorMap;


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
				float3 appendResult18_g217 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g217 = ( 0.001 * appendResult18_g217 );
				float dotResult16_g217 = dot( temp_output_20_0_g217 , temp_output_20_0_g217 );
				float ifLocalVar182_g217 = 0;
				if( dotResult16_g217 > 0.0001 )
				ifLocalVar182_g217 = 1.0;
				else if( dotResult16_g217 < 0.0001 )
				ifLocalVar182_g217 = 0.0;
				float ChildMask26_g217 = saturate( ( ifLocalVar182_g217 * 100.0 ) );
				float SelfBendMask34_g217 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g218 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g218 = 0.0;
				else
				ifLocalVar33_g218 = 1.0;
				float ifLocalVar34_g218 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g218 = 0.0;
				else
				ifLocalVar34_g218 = 1.0;
				float3 lerpResult41_g218 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g218 + ifLocalVar34_g218 ));
				float3 WindVector47_g218 = lerpResult41_g218;
				float3 objToWorld6_g219 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g218 = (( objToWorld6_g219 / _WindDirectionMapScale )).xz;
				float2 panner7_g218 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode11_g218 = tex2Dlod( _WindDirectionMap, float4( panner7_g218, 0, 0.0) );
				float2 RotationMapLF16_g218 = (tex2DNode11_g218).rg;
				float2 break35_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g218 = (float3(( break35_g218.x * -1.0 ) , 0.0 , break35_g218.y));
				float2 panner9_g218 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g218);
				float4 tex2DNode10_g218 = tex2Dlod( _WindDirectionMap, float4( panner9_g218, 0, 0.0) );
				float2 RotationMapHF17_g218 = (tex2DNode10_g218).ba;
				float2 break36_g218 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g218 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g218 = (float3(( break36_g218.x * -1.0 ) , 0.0 , break36_g218.y));
				float3 lerpResult48_g218 = lerp( appendResult42_g218 , appendResult43_g218 , _HFRotationMapInfluence);
				float3 lerpResult51_g218 = lerp( WindVector47_g218 , lerpResult48_g218 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g218 = lerpResult51_g218;
				#else
				float3 staticSwitch55_g218 = WindVector47_g218;
				#endif
				float3 worldToObjDir52_g218 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g218, 0.0 ) ).xyz;
				float3 WindVector226_g217 = worldToObjDir52_g218;
				float3 appendResult11_g217 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g217 = ( 0.001 * appendResult11_g217 );
				float3 SelfPivot28_g217 = temp_output_19_0_g217;
				float3 objToWorld54_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g217 * 1.0 ) + ( objToWorld54_g217 / -2.0 ) )).z).xx;
				float2 panner48_g217 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g217 = snoise( panner48_g217*_ChildWindMapScale );
				simplePerlin2D53_g217 = simplePerlin2D53_g217*0.5 + 0.5;
				float ChildRotation43_g217 = radians( ( simplePerlin2D53_g217 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g217 = RotateAroundAxis( SelfPivot28_g217, input.positionOS.xyz, normalize( WindVector226_g217 ), ChildRotation43_g217 );
				float3 ChildRotationResult119_g217 = ( ( ChildMask26_g217 * SelfBendMask34_g217 ) * ( rotatedValue81_g217 - input.positionOS.xyz ) );
				float temp_output_113_0_g217 = saturate( ( 4.0 * pow( SelfBendMask34_g217 , _BendingMaskStrength ) ) );
				float dotResult9_g217 = dot( temp_output_19_0_g217 , temp_output_19_0_g217 );
				float ifLocalVar189_g217 = 0;
				if( dotResult9_g217 > 0.0001 )
				ifLocalVar189_g217 = 1.0;
				else if( dotResult9_g217 < 0.0001 )
				ifLocalVar189_g217 = 0.0;
				float TrunkMask29_g217 = saturate( ( ifLocalVar189_g217 * 1000.0 ) );
				float3 ParentPivot27_g217 = temp_output_20_0_g217;
				float3 lerpResult51_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float2 temp_cast_2 = ((( lerpResult51_g217 / -0.2 )).z).xx;
				float2 panner61_g217 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g217 = snoise( panner61_g217*_ParentWindMapScale );
				simplePerlin2D60_g217 = simplePerlin2D60_g217*0.5 + 0.5;
				float saferPower185_g217 = abs( simplePerlin2D60_g217 );
				float saferPower160_g217 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g217 = saturate( pow( saferPower160_g217 , _MainBendMaskStrength ) );
				float ParentRotation63_g217 = radians( ( pow( saferPower185_g217 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g217 ) );
				float3 lerpResult98_g217 = lerp( SelfPivot28_g217 , ParentPivot27_g217 , ChildMask26_g217);
				float3 rotatedValue96_g217 = RotateAroundAxis( lerpResult98_g217, ( ChildRotationResult119_g217 + input.positionOS.xyz ), normalize( WindVector226_g217 ), ParentRotation63_g217 );
				float3 ParentRotationResult131_g217 = ( ChildRotationResult119_g217 + ( ( ( ( ( temp_output_113_0_g217 * ( 1.0 - ChildMask26_g217 ) ) + ChildMask26_g217 ) * TrunkMask29_g217 ) * ( rotatedValue96_g217 - input.positionOS.xyz ) ) * MainBendMask35_g217 ) );
				float3 objToWorld47_g217 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g217 = abs( ( objToWorld47_g217 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g217 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g217 , 2.0 )).xz);
				float simplePerlin2D70_g217 = snoise( panner71_g217*2.0 );
				simplePerlin2D70_g217 = simplePerlin2D70_g217*0.5 + 0.5;
				float MainRotation67_g217 = radians( ( simplePerlin2D70_g217 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g217 = ( ParentRotationResult131_g217 + input.positionOS.xyz );
				float3 rotatedValue121_g217 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g217, normalize( WindVector226_g217 ), MainRotation67_g217 );
				float temp_output_148_0_g217 = pow( MainBendMask35_g217 , 5.0 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float2 panner86 = ( 1.0 * _Time.y * float2( -0.2,0.4 ) + (( ase_positionWS / -8.0 )).xz);
				float simplePerlin2D85 = snoise( panner86*10.0 );
				simplePerlin2D85 = simplePerlin2D85*0.5 + 0.5;
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch287 = ( ( ( ParentRotationResult131_g217 + ( ( rotatedValue121_g217 - temp_output_125_0_g217 ) * temp_output_148_0_g217 ) ) * _WindOverallStrength * TF_WIND_STRENGTH ) + ( ( ( 1.0 - input.ase_color.b ) * _LeafFlutterStrength ) * ( input.ase_texcoord.y * simplePerlin2D85 ) * TF_WIND_STRENGTH * 0.6 ) );
				#else
				float3 staticSwitch287 = temp_cast_0;
				#endif
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch287;

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
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord1 : TEXCOORD1;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
				output.ase_texcoord1 = input.ase_texcoord1;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

				float2 texCoord62_g213 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g213 = tex2D( _ColorMap, texCoord62_g213 );
				float Opacity34 = tex2DNode1_g213.a;
				
				float lerpResult167 = lerp( _MaskClip , ( _MaskClip * 0.4 ) , ( distance( PositionWS , _WorldSpaceCameraPos ) / 150.0 ));
				#ifdef _DISTANCEBASEDMASKCLIP_ON
				float staticSwitch196 = lerpResult167;
				#else
				float staticSwitch196 = _MaskClip;
				#endif
				float Mask_Clip157 = staticSwitch196;
				

				surfaceDescription.Alpha = Opacity34;
				surfaceDescription.AlphaClipThreshold = Mask_Clip157;

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
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;126;-1662.21,987.6677;Inherit;False;1505.534;663.9109;Comment;13;228;95;94;91;92;89;90;84;86;93;85;87;370;Leaf Flutter;1,1,1,1;0;0
Node;AmplifyShaderEditor.WorldPosInputsNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;89;-1612.21,1320.179;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;92;-1588.21,1469.179;Inherit;False;Constant;_Float2;Float 2;18;0;Create;True;0;0;0;False;0;False;-8;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;156;-1664,1760;Inherit;False;1503.509;750.4954;Comment;12;157;196;167;162;165;151;166;163;159;161;160;299;Opacity;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleDivideOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;91;-1361.21,1321.178;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WorldSpaceCameraPos, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;160;-1632,2336;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldPosInputsNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;161;-1568,2176;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ComponentMaskNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;90;-1219.73,1315.01;Inherit;False;True;False;True;True;1;0;FLOAT3;0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DistanceOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;159;-1312,2240;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;163;-1328,2352;Inherit;False;Constant;_Float18;Float 18;24;0;Create;True;0;0;0;False;0;False;150;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;166;-1488,1936;Inherit;False;Constant;_Float17;Float 17;24;0;Create;True;0;0;0;False;0;False;0.4;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;86;-993.4615,1320.82;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;-0.2,0.4;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.VertexColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;369;-848,816;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;151;-1616,1808;Inherit;False;Property;_MaskClip;Mask Clip;26;0;Create;True;0;0;0;False;0;False;0.5588235;0.65;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;165;-1328,1904;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;162;-1136,2240;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;85;-770.3206,1418.038;Inherit;False;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;84;-774.1773,1270.457;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;94;-848.191,1034.668;Inherit;False;Property;_LeafFlutterStrength;Leaf Flutter Strength;30;0;Create;True;0;0;0;False;0;False;0.3;0.15;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;372;-656,896;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;167;-1136,1888;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;87;-511.2187,1400.518;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;228;-714.99,1193.772;Inherit;False;Constant;_Float1;Float 1;24;0;Create;True;0;0;0;False;0;False;0.6;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;83;-1152,320;Inherit;False;Property;_WindOverallStrength;Wind Overall Strength;29;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;97;-1152,224;Inherit;False;Property;_MainBendMaskStrength;Main Bend Mask Strength;32;0;Create;True;0;0;0;False;0;False;0;0.5;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;102;-1152,48;Inherit;False;Property;_ChildWindMapScale;Child Wind Map Scale;39;0;Create;True;0;0;0;False;0;False;0;2;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;105;-1152,128;Inherit;False;Property;_ParentWindMapScale;Parent Wind Map Scale;35;0;Create;True;0;0;0;False;0;False;1;1;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;63;-1152,416;Inherit;False;Property;_BendingMaskStrength;Bending Mask Strength;36;0;Create;True;0;0;0;False;0;False;1.236128;1;0.05;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;60;-1152.919,664.3174;Inherit;False;Property;_MainWindStrength;Main Wind Strength;31;1;[Header];Create;True;1;Main Wind;0;0;False;1;Space(5);False;0.5;0.5;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;58;-1152.919,501.32;Inherit;False;Property;_ParentWindStrength;Parent Wind Strength;34;1;[Header];Create;True;1;Parent Wind;0;0;False;1;Space(5);False;0.5;0.35;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;59;-1152,576;Inherit;False;Property;_ChildWindStrength;Child Wind Strength;37;1;[Header];Create;True;1;Child Wind;0;0;False;1;Space(5);False;0.5;0.4;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;289;-1104,-320;Inherit;True;Property;_WindDirectionMap;Wind Direction Map;40;2;[Header];[SingleLineTexture];Create;True;1;WIND MAPS;0;0;False;1;Space(10);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;107;-1152,-32;Inherit;False;Property;_MainWindScale;Main Wind Scale;33;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;303;-1120,-112;Inherit;False;Property;_WindDirectionMapScale;Wind Direction Map Scale;41;0;Create;True;0;0;0;False;0;False;200;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;276;-2688,-2688;Inherit;False;Property;_BaseColorBrightness;Base Color Brightness;16;0;Create;True;0;0;0;False;0;False;1;0;-1;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;275;-2688,-2528;Inherit;False;Property;_BaseColorContrast;Base Color Contrast;18;0;Create;True;0;0;0;False;0;False;1;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;184;-2688,-2608;Inherit;False;Property;_BaseColorSaturation;Base Color Saturation;17;0;Create;True;0;0;0;False;0;False;1;0;-1;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;143;-2672,-1568;Inherit;False;Property;_AOIntensity;AO Intensity;24;0;Create;True;0;0;0;False;0;False;1;0.8;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;266;-2624,-2112;Inherit;True;Property;_NormalMap;Normal Map;11;2;[Normal];[SingleLineTexture];Create;True;0;0;0;False;0;False;None;None;False;bump;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;13;-2672,-1632;Inherit;False;Property;_Smoothness;Smoothness;19;1;[Header];Create;True;1;BASE ATTRIBUTES;0;0;False;1;Space(10);False;0;0.106;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;53;-2688,-1920;Inherit;False;Property;_NormalScale;Normal Scale;21;0;Create;True;0;0;0;False;0;False;0;0.25;-2;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;267;-2624,-1840;Inherit;True;Property;_MaskMap;Mask Map;12;1;[SingleLineTexture];Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;360;-2688,-2448;Inherit;False;Property;_HueTest;Hue Test;38;0;Create;True;0;0;0;False;0;False;1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;370;-512,1008;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;380;-2624,-2896;Inherit;False;Constant;_Color0;Color 0;43;0;Create;True;0;0;0;False;0;False;1,1,1,0;0,0,0,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;255;-2624,-2304;Inherit;True;Property;_ColorMap;Color Map;10;2;[Header];[SingleLineTexture];Create;True;1;BASE MAPS;0;0;False;1;Space(10);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;95;-813.6607,1112.578;Inherit;False;Global;TF_WIND_STRENGTH;TF_WIND_STRENGTH;19;0;Create;True;0;0;0;False;0;False;0.3;0.3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;196;-960,1808;Inherit;False;Property;_DistanceBasedMaskClip;Distance Based Mask Clip;27;0;Create;True;0;0;0;False;0;False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;93;-343.0762,1224.777;Inherit;False;4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;376;-2160,-2528;Inherit;False;FW_StandardLayer;-1;;213;c3b2175e566bb5047b1cf46c43eb1c3f;0;16;41;FLOAT4;0,0,0,0;False;50;FLOAT;1;False;52;FLOAT;1;False;51;FLOAT;1;False;65;FLOAT;1;False;8;SAMPLER2D;;False;54;SAMPLER2D;;False;55;FLOAT4;1,1,1,0;False;2;SAMPLERSTATE;;False;9;SAMPLER2D;;False;11;FLOAT;1;False;10;SAMPLERSTATE;;False;13;SAMPLER2D;0,0,0;False;21;FLOAT;0;False;22;FLOAT;0;False;23;FLOAT;0;False;10;FLOAT3;0;COLOR;89;FLOAT3;25;FLOAT;26;FLOAT;27;FLOAT;29;COLOR;60;FLOAT;53;FLOAT;28;COLOR;40
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;447;-640,384;Inherit;False;FW_Wind;42;;217;6d75e8b57dd6aca4f88bb3d789062339;0;11;231;SAMPLER2D;0;False;238;FLOAT;200;False;166;FLOAT;1;False;162;FLOAT;2;False;163;FLOAT;1;False;157;FLOAT;1;False;154;FLOAT;0;False;142;FLOAT;0.5;False;77;FLOAT;1;False;141;FLOAT;1;False;78;FLOAT;1;False;6;FLOAT;167;FLOAT;147;FLOAT;143;FLOAT;144;FLOAT;145;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;43;-1680,-3920;Inherit;False;2572.573;697.3469;Comment;19;392;388;387;383;390;381;375;384;263;377;262;261;187;176;256;265;52;260;391;Base Color;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;282;-2704,-1264;Inherit;False;1572;338.8;Comment;10;145;169;168;170;141;146;147;271;273;351;Additional Vertex Color AO;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;157;-608,1808;Inherit;False;Mask Clip;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;288;-144,432;Inherit;False;Constant;_Float0;Float 0;31;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;88;-112,512;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;34;-1696,-2208;Inherit;False;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;368;-2560,-2384;Inherit;False;Constant;_Float20;Float 20;43;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;158;31.56996,127.5134;Inherit;False;34;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;277;-1696,-2368;Inherit;False;Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;269;-1696,-2288;Inherit;False;AmbientOcclusion;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;279;32,48;Inherit;False;Property;_Specular;Specular;20;0;Create;True;0;0;0;False;0;False;0.05;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;39;-112,-352;Inherit;False;37;FinalColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;274;-176,-224;Inherit;False;273;FinalAmbientOcclusion;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;12;-112,-288;Inherit;False;8;FinalNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;280;-144,-160;Inherit;False;277;Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;145;-1744,-1200;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;169;-1984,-1200;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;168;-2144,-1200;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;170;-2336,-1200;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;141;-2624,-1120;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;146;-2640,-1200;Inherit;False;Property;_VertexAOIntensity;Vertex AO Intensity;25;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;147;-1568,-1200;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;273;-1392,-1200;Inherit;False;FinalAmbientOcclusion;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;287;32,480;Inherit;False;Property;_EnableWind;Enable Wind;28;0;Create;True;0;0;0;False;2;Header(WIND SETTINGS);Space(10);False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StickyNoteNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;299;-960,1952;Inherit;False;277.2001;100;New Note;;0,0,0,1;Dynamic Mask clipping based on distance$;0;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;271;-2128,-1024;Inherit;False;269;AmbientOcclusion;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;351;-1776,-1056;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;252;-80,784;Inherit;False;Property;_TranslucencyStrength;Translucency Strength;50;1;[Header];Create;True;1;TRANSLUCENCY;0;0;False;1;Space(10);False;0;0;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;278;-1696,-2128;Inherit;False;TranslucencyMask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;268;-1712,-2448;Inherit;False;TF_FlipNormalBackfaces;22;;220;ac34ec6731ca09c4bb272e16fbf2fe92;0;1;6;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;239;32.91937,209.7682;Inherit;False;157;Mask Clip;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;292;-48,864;Inherit;False;278;TranslucencyMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;251;-64,288;Inherit;False;Property;_Transmission;Transmission;51;0;Create;True;0;0;0;False;0;False;1;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;291;224,800;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;371;16,944;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;8;-1472,-2448;Inherit;False;FinalNormal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BreakToComponentsNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;260;-1024,-3440;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;52;-1184,-3312;Inherit;False;Property;_UndercolorAmount;Undercolor Amount;15;0;Create;True;0;0;0;False;0;False;0.5;0.207;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;265;-864,-3408;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;256;-752,-3408;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;176;-816,-3840;Inherit;False;Property;_Color;Color;13;1;[Header];Create;True;1;COLOR ADJUSTMENT;0;0;False;1;Space(10);False;1,1,1,0;0.3757727,0.509434,0.3046992,1;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.ColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;187;-816,-3648;Inherit;False;Property;_Undercolor;Undercolor;14;0;Create;True;0;0;0;False;0;False;1,1,1,0;1,1,1,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.NormalVertexDataNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;261;-1408,-3408;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexToFragmentNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;262;-1232,-3408;Inherit;False;False;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WorldNormalVector, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;377;-1408,-3584;Inherit;False;True;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;263;-496,-3840;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;384;-1632,-3584;Inherit;False;8;FinalNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;385;-1664,-2816;Inherit;False;Color;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;386;-1664,-2736;Inherit;False;ColorClean;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;389;-1696,-2032;Inherit;False;ColorMask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;375;32,-3568;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;381;240,-3840;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;390;-224,-3520;Inherit;False;389;ColorMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;383;448,-3856;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;387;-224,-3600;Inherit;False;385;Color;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;388;-224,-3680;Inherit;False;386;ColorClean;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;392;624,-3856;Inherit;False;LeafColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;391;224,-3904;Inherit;False;386;ColorClean;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;394;2416,-3808;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;396;2208,-3824;Inherit;False;386;ColorClean;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;395;2208,-3712;Inherit;False;389;ColorMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;416;2896,-3808;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;417;2656,-3856;Inherit;False;392;LeafColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.IntNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;411;2592,-3680;Inherit;False;Global;TF_ColorVarianceEnable;TF_ColorVarianceEnable;37;0;Create;True;0;0;0;False;0;False;0;1;False;0;1;INT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;37;3088,-3808;Inherit;False;FinalColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;413;1328,-3728;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;352;1024,-3664;Inherit;False;Property;_ColorVarianceMaskScale;Color Variance Mask Scale;9;0;Create;True;0;0;0;False;0;False;-100;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;393;1552,-3824;Inherit;False;392;LeafColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;414;1024,-3760;Inherit;False;Global;TF_ColorVarianceMaskScale;TF_ColorVarianceMaskScale;37;0;Create;True;0;0;0;False;0;False;100;2.35;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;341;1488,-3728;Inherit;False;TF_WorldPositionCoords;-1;;221;9dc59717bff26214ea4f3f351d35fe94;1,7,1;1;5;FLOAT;-133.16;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;405;1472,-3440;Inherit;False;Global;TF_ColorVarianceMax;TF_ColorVarianceMax;5;0;Create;True;0;0;0;False;0;False;1;0.675;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;404;1472,-3536;Inherit;False;Global;TF_ColorVarianceMin;TF_ColorVarianceMin;6;0;Create;True;0;0;0;False;0;False;-1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;403;1440,-3632;Inherit;False;Global;TF_ColorVarianceBiasShift;TF_ColorVarianceBiasShift;4;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;406;1440,-3344;Inherit;False;Global;TF_ColorVarianceIntensity;TF_ColorVarianceIntensity;3;0;Create;True;0;0;0;False;0;False;0;0.166;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;440;1472,-3248;Inherit;False;Global;TF_BrightnessVariance;TF_BrightnessVariance;3;0;Create;True;0;0;0;False;0;False;0;0.3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;448;1808,-3808;Inherit;False;TF_ColorHueVariance;0;;223;d9bb501bc9f1ce84a8d082570c3540ee;0;7;13;COLOR;0,0,0,0;False;14;FLOAT2;0,0;False;34;FLOAT;1;False;35;FLOAT;-1;False;36;FLOAT;1;False;37;FLOAT;0;False;55;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;229;279.2643,-21.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ExtraPrePass;0;0;ExtraPrePass;6;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;230;279.2643,-21.37782;Float;False;True;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;TriForge/Tree Branch;94348b07e5e8bab40bd6c8a1e3df54cd;True;Forward;0;1;Forward;21;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;5;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;DisableBatching=True=DisableBatching;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;2;LightMode=UniversalForwardOnly;DisableBatching=True=DisableBatching;False;False;3;Include;;False;;Native;False;0;0;;Include;Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl;False;;Custom;False;0;0;;Pragma;multi_compilefragment  LOD_FADE_CROSSFADE;False;;Custom;False;0;0;;;0;0;Standard;45;Lighting Model;0;0;Workflow;0;638785227992954225;Surface;0;638339402805002931;  Refraction Model;0;0;  Blend;0;0;Two Sided;0;638339353251761143;Alpha Clipping;1;0;  Use Shadow Threshold;0;0;Fragment Normal Space,InvertActionOnDeselection;0;0;Forward Only;1;638339406119559019;Transmission;1;638784211794765987;  Transmission Shadow;0.5,False,;0;Translucency;1;638340030505829549;  Translucency Strength;1,True,_TranslucencyStrength;638962119024286553;  Normal Distortion;0.5,False,;0;  Scattering;2,False,;0;  Direct;0.9,False,;0;  Ambient;0.1,False,;0;  Shadow;0.5,False,;0;Cast Shadows;1;0;Receive Shadows;1;0;Receive SSAO;1;0;Specular Highlights;1;0;Environment Reflections;1;0;GPU Instancing;1;0;LOD CrossFade;1;638841104172243557;Built-in Fog;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Write Depth;0;0;  Early Z;0;0;Vertex Position,InvertActionOnDeselection;1;0;Debug Display;0;0;Clear Coat;0;0;0;10;False;True;True;True;True;True;True;False;True;True;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;231;279.2643,-21.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;232;279.2643,-21.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;True;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;233;279.2643,-21.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;234;279.2643,-21.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;235;279.2643,-21.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormalsOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;236;279.2643,-21.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;GBuffer;0;7;GBuffer;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalGBuffer;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;237;279.2643,-21.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;SceneSelectionPass;0;8;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;238;279.2643,-21.37782;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ScenePickingPass;0;9;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
WireConnection;91;0;89;0
WireConnection;91;1;92;0
WireConnection;90;0;91;0
WireConnection;159;0;161;0
WireConnection;159;1;160;0
WireConnection;86;0;90;0
WireConnection;165;0;151;0
WireConnection;165;1;166;0
WireConnection;162;0;159;0
WireConnection;162;1;163;0
WireConnection;85;0;86;0
WireConnection;372;0;369;3
WireConnection;167;0;151;0
WireConnection;167;1;165;0
WireConnection;167;2;162;0
WireConnection;87;0;84;2
WireConnection;87;1;85;0
WireConnection;370;0;372;0
WireConnection;370;1;94;0
WireConnection;196;1;151;0
WireConnection;196;0;167;0
WireConnection;93;0;370;0
WireConnection;93;1;87;0
WireConnection;93;2;95;0
WireConnection;93;3;228;0
WireConnection;376;41;380;0
WireConnection;376;50;276;0
WireConnection;376;52;184;0
WireConnection;376;51;275;0
WireConnection;376;65;360;0
WireConnection;376;8;255;0
WireConnection;376;9;266;0
WireConnection;376;11;53;0
WireConnection;376;13;267;0
WireConnection;376;22;13;0
WireConnection;376;23;143;0
WireConnection;447;231;289;0
WireConnection;447;238;303;0
WireConnection;447;166;107;0
WireConnection;447;162;102;0
WireConnection;447;163;105;0
WireConnection;447;157;97;0
WireConnection;447;154;83;0
WireConnection;447;142;63;0
WireConnection;447;77;58;0
WireConnection;447;141;59;0
WireConnection;447;78;60;0
WireConnection;157;0;196;0
WireConnection;88;0;447;0
WireConnection;88;1;93;0
WireConnection;34;0;376;53
WireConnection;277;0;376;27
WireConnection;269;0;376;29
WireConnection;145;0;169;0
WireConnection;145;1;271;0
WireConnection;169;0;168;0
WireConnection;168;0;170;0
WireConnection;168;1;141;1
WireConnection;170;0;146;0
WireConnection;147;0;351;0
WireConnection;273;0;147;0
WireConnection;287;1;288;0
WireConnection;287;0;88;0
WireConnection;351;0;169;0
WireConnection;351;1;271;0
WireConnection;278;0;376;28
WireConnection;268;6;376;25
WireConnection;291;0;252;0
WireConnection;291;1;292;0
WireConnection;291;2;371;1
WireConnection;8;0;268;0
WireConnection;260;0;377;0
WireConnection;265;0;260;1
WireConnection;265;1;52;0
WireConnection;256;0;265;0
WireConnection;262;0;261;0
WireConnection;377;0;384;0
WireConnection;263;0;187;0
WireConnection;263;1;176;0
WireConnection;263;2;256;0
WireConnection;385;0;376;0
WireConnection;386;0;376;89
WireConnection;389;0;376;28
WireConnection;375;0;388;0
WireConnection;375;1;387;0
WireConnection;375;2;390;0
WireConnection;381;0;263;0
WireConnection;381;1;375;0
WireConnection;383;0;391;0
WireConnection;383;1;381;0
WireConnection;383;2;390;0
WireConnection;392;0;383;0
WireConnection;394;0;396;0
WireConnection;394;1;448;0
WireConnection;394;2;395;0
WireConnection;416;0;417;0
WireConnection;416;1;394;0
WireConnection;416;2;411;0
WireConnection;37;0;416;0
WireConnection;413;0;414;0
WireConnection;413;1;352;0
WireConnection;341;5;413;0
WireConnection;448;13;393;0
WireConnection;448;14;341;0
WireConnection;448;34;403;0
WireConnection;448;35;404;0
WireConnection;448;36;405;0
WireConnection;448;37;406;0
WireConnection;448;55;440;0
WireConnection;230;0;39;0
WireConnection;230;1;12;0
WireConnection;230;9;279;0
WireConnection;230;4;280;0
WireConnection;230;5;274;0
WireConnection;230;6;158;0
WireConnection;230;7;239;0
WireConnection;230;14;251;0
WireConnection;230;15;291;0
WireConnection;230;8;287;0
ASEEND*/
//CHKSM=58FACD320CA69AA9331A47EFB6EBF4FC9CE5A82D