// Made with Amplify Shader Editor v1.9.8.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ANGRYMESH/Stylized Pack/Tree Leaf"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[Header(Base)][Toggle(_ENABLEFLIPNORMALS_ON)] _EnableFlipNormals("Enable Flip Normals", Float) = 0
		[Toggle(_ENABLEGLANCINGANGLECUT_ON)] _EnableGlancingAngleCut("Enable Glancing Angle Cut", Float) = 0
		_BaseGlancingAngleCut("Base Glancing Angle Cut", Range( 0 , 1)) = 0.8
		_CutOff("Base Opacity Cutoff", Range( 0 , 1)) = 0.3
		[HDR]_BaseAlbedoColor("Base Albedo Color", Color) = (0.5019608,0.5019608,0.5019608)
		_BaseAlbedoBrightness("Base Albedo Brightness", Range( 0 , 5)) = 1
		_BaseAlbedoDesaturation("Base Albedo Desaturation", Range( 0 , 1)) = 0
		_BaseNormalIntensity("Base Normal Intensity", Range( 0 , 5)) = 1
		_BaseSmoothnessMin("Base Smoothness Min", Range( 0 , 5)) = 0
		_BaseSmoothnessMax("Base Smoothness Max", Range( 0 , 5)) = 1
		_BaseTreeAOIntensity("Base Tree AO Intensity", Range( 0 , 1)) = 0.5
		_BaseLerpBetweenColorandTexture("Base Lerp Between Color and Texture", Range( 0 , 1)) = 1
		[NoScaleOffset]_BaseAlbedo("Base Albedo", 2D) = "gray" {}
		[NoScaleOffset]_BaseNormal("Base Normal", 2D) = "bump" {}
		[NoScaleOffset]_BaseSSE("Base SSE", 2D) = "white" {}
		[HDR][Header(Base SSS)]_BaseSSSColor("Base SSS Color", Color) = (1,1,1)
		_BaseSSSIntensity("Base SSS Intensity", Range( 0 , 50)) = 1
		_BaseSSSAOInfluence("Base SSS AO Influence", Range( 0 , 1)) = 0.8
		_BaseSSSNormalDistortion("Base SSS Normal Distortion", Range( 0 , 1)) = 0.5
		_BaseSSSScattering("Base SSS Scattering", Range( 1 , 50)) = 2
		_BaseSSSDirect("Base SSS Direct", Range( 0 , 1)) = 0.9
		_BaseSSSAmbiet("Base SSS Ambiet", Range( 0 , 1)) = 0.1
		_BaseSSSShadow("Base SSS Shadow", Range( 0 , 1)) = 0.9
		[HDR][Header(Base Emissive)]_BaseEmissiveColor("Base Emissive Color", Color) = (0,0,0,0)
		_BaseEmissiveIntensity("Base Emissive Intensity", Range( 0 , 50)) = 1
		_BaseEmissiveMaskContrast("Base Emissive Mask Contrast", Range( 0 , 50)) = 1
		_BaseEmissiveAOMask("Base Emissive AO Mask", Range( 0 , 1)) = 0
		[Header(Base Gradient Color)][Toggle(_ENABLEGRADIENTCOLOR_ON)] _EnableGradientColor("Enable Gradient Color", Float) = 0
		[HDR]_GradientColor("Gradient Color", Color) = (0.5019608,0.5019608,0.5019608)
		_GradientColorIntensity("Gradient Color Intensity", Range( 0 , 1)) = 1
		_GradientColorOffset("Gradient Color Offset", Range( 0 , 5)) = 1
		_GradientColorContrast("Gradient Color Contrast", Range( 0 , 30)) = 1
		[IntRange]_GradientColorInvertMask("Gradient Color Invert Mask", Range( 0 , 1)) = 0
		[Header(Base Second Color)][Toggle(_ENABLESECONDCOLOR_ON)] _EnableSecondColor("Enable Second Color", Float) = 0
		[HDR]_SecondColor("Second Color", Color) = (0.5019608,0.5019608,0.5019608)
		_SecondColorIntensity("Second Color Intensity", Range( 0 , 1)) = 1
		_SecondColorOffset("Second Color Offset", Range( 0 , 3)) = 1
		_SecondColorContrast("Second Color Contrast", Range( 0 , 30)) = 1
		[IntRange]_SecondColorInvertMask("Second Color Invert Mask", Range( 0 , 1)) = 0
		[Header(Base Tint Color)][Toggle(_ENABLETINTCOLOR_ON)] _EnableTintColor("Enable Tint Color", Float) = 0
		[HDR]_TintColor1("Tint Color 1", Color) = (0.5019608,0.5019608,0.5019608,0)
		[HDR]_TintColor2("Tint Color 2", Color) = (0.5019608,0.5019608,0.5019608,0)
		_TintNoiseIntensity("Tint Noise Intensity", Range( 0 , 1)) = 1
		_TintNoiseOffset("Tint Noise Offset", Range( 0 , 10)) = 1
		_TintNoiseContrast("Tint Noise Contrast", Range( 0 , 10)) = 1
		[Header(Top Layer)][Toggle(_ENABLETOPLAYERBLEND_ON)] _EnableTopLayerBlend("Enable Top Layer Blend", Float) = 0
		[HDR]_TopLayerColor("Top Layer Color", Color) = (0.7764706,0.8392157,0.9490196)
		[HDR]_TopLayerSSSColor("Top Layer SSS Color", Color) = (0.7843137,0.9215686,1)
		_TopLayerSSSIntensity("Top Layer SSS Intensity", Range( 0 , 1)) = 0.5
		_TopLayerSmoothnessIntensity("Top Layer Smoothness Intensity", Range( 0 , 5)) = 0
		_TopLayerIntensity("Top Layer Intensity", Range( 0 , 1)) = 1
		_TopLayerOffset("Top Layer Offset", Range( 0 , 1)) = 0.5
		_TopLayerContrast("Top Layer Contrast", Range( 0 , 30)) = 10
		_TopLayerAOMask("Top Layer AO Mask", Range( 0 , 10)) = 1
		[Toggle(_ENABLEWORLDPROJECTION_ON)] _EnableWorldProjection("Enable World Projection", Float) = 1
		[Toggle(_ENABLEBACKFACEPROJECTION_ON)] _EnableBackfaceProjection("Enable Backface Projection", Float) = 1
		[Header(Wind)][Toggle(_ENABLEWIND_ON)] _EnableWind("Enable Wind", Float) = 1
		_WindLeafAmplitude("Wind Leaf Amplitude", Range( 0 , 2)) = 1
		_WindLeafSpeed("Wind Leaf Speed", Range( 0 , 2)) = 1
		_WindLeafScale("Wind Leaf Scale", Range( 0 , 2)) = 1
		_WindLeafTurbulence("Wind Leaf Turbulence", Range( 0 , 2)) = 1
		_WindLeafOffset("Wind Leaf Offset", Range( 0 , 2)) = 1
		[Header(Wind (Use the same values for each tree material))]_WindTreeFlexibility("Wind Tree Flexibility", Range( 0 , 2)) = 1
		_WindTreeBaseRigidity("Wind Tree Base Rigidity", Range( 0 , 5)) = 2.5
		[Toggle(_ENABLESTATICMESHSUPPORT_ON)] _EnableStaticMeshSupport("Enable Static Mesh Support", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}


		//_TransmissionShadow( "Transmission Shadow", Range( 0, 1 ) ) = 0.5
		//_TransStrength( "Strength", Range( 0, 50 ) ) = 1
		//_TransNormal( "Normal Distortion", Range( 0, 1 ) ) = 0.5
		//_TransScattering( "Scattering", Range( 1, 50 ) ) = 2
		//_TransDirect( "Direct", Range( 0, 1 ) ) = 0.9
		//_TransAmbient( "Ambient", Range( 0, 1 ) ) = 0.1
		//_TransShadow( "Shadow", Range( 0, 1 ) ) = 0.5
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
			Tags { "LightMode"="UniversalForwardOnly" }

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
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define _EMISSION
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
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON
			#pragma shader_feature_local _ENABLETINTCOLOR_ON
			#pragma shader_feature_local _ENABLESECONDCOLOR_ON
			#pragma shader_feature_local _ENABLEGRADIENTCOLOR_ON
			#pragma shader_feature_local _ENABLEBACKFACEPROJECTION_ON
			#pragma shader_feature_local _ENABLEWORLDPROJECTION_ON
			#pragma shader_feature_local _ENABLEFLIPNORMALS_ON
			#pragma shader_feature_local _ENABLEGLANCINGANGLECUT_ON


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
			float4 _BaseEmissiveColor;
			float4 _TintColor2;
			float4 _TintColor1;
			float3 _TopLayerSSSColor;
			float3 _SecondColor;
			float3 _TopLayerColor;
			float3 _GradientColor;
			half3 _BaseAlbedoColor;
			float3 _BaseSSSColor;
			float _TintNoiseOffset;
			float _TintNoiseContrast;
			float _TintNoiseIntensity;
			float _BaseNormalIntensity;
			half _TopLayerOffset;
			half _TopLayerContrast;
			half _TopLayerAOMask;
			float _BaseSSSAOInfluence;
			float _BaseEmissiveMaskContrast;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveAOMask;
			float _BaseSmoothnessMin;
			float _BaseSmoothnessMax;
			float _TopLayerSmoothnessIntensity;
			float _BaseGlancingAngleCut;
			float _CutOff;
			half _TopLayerIntensity;
			float _BaseSSSIntensity;
			float _SecondColorInvertMask;
			float _TopLayerSSSIntensity;
			float _BaseSSSAmbiet;
			float _BaseSSSShadow;
			float _BaseSSSNormalDistortion;
			float _BaseSSSScattering;
			float _WindTreeFlexibility;
			float _WindTreeBaseRigidity;
			float _WindLeafScale;
			float _WindLeafSpeed;
			float _WindLeafAmplitude;
			float _WindLeafTurbulence;
			float _WindLeafOffset;
			float _BaseAlbedoDesaturation;
			float _BaseAlbedoBrightness;
			float _BaseLerpBetweenColorandTexture;
			float _BaseTreeAOIntensity;
			float _GradientColorOffset;
			float _GradientColorContrast;
			float _GradientColorInvertMask;
			float _GradientColorIntensity;
			float _SecondColorOffset;
			float _SecondColorContrast;
			float _SecondColorIntensity;
			float _BaseSSSDirect;
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

			sampler2D ASP_GlobalTintNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindTreeSpeed;
			half ASPW_WindTreeAmplitude;
			half ASPW_WindTreeFlexibility;
			half ASPW_WindTreeLeafSpeed;
			half ASPW_WindTreeLeafAmplitude;
			half ASPW_WindTreeLeafTurbulence;
			half ASPW_WindTreeLeafOffset;
			float ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			half ASP_GlobalTreeAO;
			half ASP_GlobalTintNoiseUVScale;
			half ASP_GlobalTintNoiseContrast;
			half ASP_GlobalTintNoiseIntensity;
			sampler2D _BaseNormal;
			half ASPT_TopLayerOffset;
			half ASPT_TopLayerContrast;
			half ASPT_TopLayerIntensity;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;
			sampler2D _BaseSSE;
			half ASP_GlobalTreeSSSIntensity;
			half ASP_GlobalTreeSSSAOInfluence;
			half ASP_GlobalTreeSSSDistance;


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
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction493_g37 = ASPW_WindDirection;
				float3 worldToObjDir269_g37 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g37, 0.0 ) ).xyz;
				float3 normalizeResult268_g37 = ASESafeNormalize( worldToObjDir269_g37 );
				float3 Wind_Direction_Leaf85_g37 = normalizeResult268_g37;
				float3 break86_g37 = Wind_Direction_Leaf85_g37;
				float3 appendResult89_g37 = (float3(break86_g37.z , 0.0 , ( break86_g37.x * -1.0 )));
				float3 Wind_Direction91_g37 = appendResult89_g37;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g37 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g37 = ( Wind_Tree_Randomization149_g37 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g37 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g37 = ( Global_Wind_Tree_Speed491_g37 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g37 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g37 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g37 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g37 ) * 0.3 );
				float Wind_Tree_257_g37 = ( ( ( ( ( sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.1 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.3 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g37 ) * Global_Wind_Tree_Amplitude464_g37 ) * 0.01 ) * temp_output_383_0_g37 );
				float3 rotatedValue99_g37 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g37, Wind_Tree_257_g37 );
				float3 Rotate_About_Axis354_g37 = ( rotatedValue99_g37 - input.positionOS.xyz );
				float3 break452_g37 = normalizeResult268_g37;
				float3 appendResult454_g37 = (float3(break452_g37.x , 0.0 , break452_g37.z));
				float3 Wind_Direction_SM_Support453_g37 = appendResult454_g37;
				float Wind_Tree_Flexibility483_g37 = temp_output_383_0_g37;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g37 = ( Global_Wind_Tree_Amplitude464_g37 * Wind_Tree_257_g37 * Wind_Direction_SM_Support453_g37 * Wind_Tree_Flexibility483_g37 );
				#else
				float3 staticSwitch482_g37 = Rotate_About_Axis354_g37;
				#endif
				float3 Wind_Global450_g37 = staticSwitch482_g37;
				float2 texCoord433_g37 = input.texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g37 = texCoord433_g37.y;
				float saferPower113_g37 = abs( Wind_Mask_UV_CH2_VChannel434_g37 );
				float Wind_Tree_Mask114_g37 = pow( saferPower113_g37 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g37 = ( Wind_Global450_g37 * Wind_Tree_Mask114_g37 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float temp_output_227_0_g37 = ( ( ase_positionWS.y * ( _WindLeafScale * 30.0 ) ) + _TimeParameters.x );
				float Global_Wind_Tree_Leaf_Speed495_g37 = ASPW_WindTreeLeafSpeed;
				float temp_output_223_0_g37 = ( _WindLeafSpeed * Global_Wind_Tree_Leaf_Speed495_g37 * 4.0 );
				float Global_Wind_Tree_Leaf_Amplitude497_g37 = ASPW_WindTreeLeafAmplitude;
				float temp_output_242_0_g37 = ( ( sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 0.5 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.25 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.5 ) ) ) ) * ( ( _WindLeafAmplitude * Global_Wind_Tree_Leaf_Amplitude497_g37 ) * 0.1 ) );
				float temp_output_243_0_g37 = ( temp_output_242_0_g37 * 0.2 );
				float3 appendResult244_g37 = (float3(temp_output_243_0_g37 , temp_output_242_0_g37 , temp_output_243_0_g37));
				float3 Wind_Leaf245_g37 = appendResult244_g37;
				float3 break416_g37 = normalizeResult268_g37;
				float3 appendResult417_g37 = (float3(( break416_g37.x * -1.0 ) , ( break416_g37.z * -1.0 ) , 0.0));
				float3 Wind_Direction_Turbulence419_g37 = appendResult417_g37;
				float2 appendResult322_g37 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Tree_Leaf_Turbulence502_g37 = ASPW_WindTreeLeafTurbulence;
				float Wind_Leaf_Turbulence334_g37 = saturate( ( tex2Dlod( ASP_GlobalTintNoiseTexture, float4( ( ( ( Wind_Direction_Turbulence419_g37 * _TimeParameters.x ) * 0.1 ) + float3( ( appendResult322_g37 * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).g + ( ( Global_Wind_Tree_Leaf_Turbulence502_g37 * _WindLeafTurbulence ) * 0.1 ) ) );
				float Wind_Mask_VColor_Blue429_g37 = input.ase_color.b;
				float3 Wind_Leaf_Mask285_g37 = ( ( ( Wind_Leaf245_g37 * Wind_Direction_Leaf85_g37 ) * Wind_Leaf_Turbulence334_g37 ) * Wind_Mask_VColor_Blue429_g37 );
				float Global_Wind_Tree_Leaf_Offset500_g37 = ASPW_WindTreeLeafOffset;
				float Wind_Mask_VColor_Green430_g37 = input.ase_color.g;
				float2 texCoord312_g37 = input.texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float3 Wind_Leaf_Offset314_g37 = ( ( ( ( Wind_Direction_Leaf85_g37 * ( _WindLeafOffset * Global_Wind_Tree_Leaf_Offset500_g37 * 0.5 ) ) + Wind_Leaf_Mask285_g37 ) * Wind_Mask_VColor_Green430_g37 ) * texCoord312_g37.y );
				float Global_Wind_Toggle504_g37 = ASPW_WindToggle;
				float3 lerpResult125_g37 = lerp( float3( 0,0,0 ) , ( temp_output_385_0_g37 + ( Wind_Leaf_Mask285_g37 + Wind_Leaf_Offset314_g37 ) ) , Global_Wind_Toggle504_g37);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch469_g37 = lerpResult125_g37;
				#else
				float3 staticSwitch469_g37 = temp_cast_0;
				#endif
				
				output.ase_texcoord8.xy = input.texcoord.xy;
				output.ase_color = input.ase_color;
				output.ase_texcoord8.zw = input.texcoord2.xy;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch469_g37;

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
						, bool ase_vface : SV_IsFrontFace ) : SV_Target
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

				float2 uv_BaseAlbedo1753 = input.ase_texcoord8.xy;
				float4 tex2DNode1753 = tex2D( _BaseAlbedo, uv_BaseAlbedo1753 );
				float3 desaturateInitialColor1712 = tex2DNode1753.rgb;
				float desaturateDot1712 = dot( desaturateInitialColor1712, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar1712 = lerp( desaturateInitialColor1712, desaturateDot1712.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc3324 = ( desaturateVar1712 * _BaseAlbedoBrightness );
				float3 blendOpDest3324 = _BaseAlbedoColor;
				float3 lerpResult1716 = lerp( _BaseAlbedoColor , ( saturate( (( blendOpDest3324 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest3324 ) * ( 1.0 - blendOpSrc3324 ) ) : ( 2.0 * blendOpDest3324 * blendOpSrc3324 ) ) )) , _BaseLerpBetweenColorandTexture);
				float lerpResult1727 = lerp( 1.0 , input.ase_color.a , saturate( ( _BaseTreeAOIntensity * ASP_GlobalTreeAO ) ));
				float Base_AO1735 = lerpResult1727;
				float3 Base_Albedo1723 = ( lerpResult1716 * Base_AO1735 );
				float3 blendOpSrc1836 = Base_Albedo1723;
				float3 blendOpDest1836 = _GradientColor;
				float3 temp_output_1836_0 = ( saturate( (( blendOpDest1836 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest1836 ) * ( 1.0 - blendOpSrc1836 ) ) : ( 2.0 * blendOpDest1836 * blendOpSrc1836 ) ) ));
				float2 texCoord1840 = input.ase_texcoord8.zw * float2( 1,1 ) + float2( 0,0 );
				float saferPower1879 = abs( ( ( 1.0 - texCoord1840.y ) * _GradientColorOffset ) );
				float temp_output_1848_0 = saturate( pow( saferPower1879 , _GradientColorContrast ) );
				float lerpResult1877 = lerp( temp_output_1848_0 , ( 1.0 - temp_output_1848_0 ) , _GradientColorInvertMask);
				float Gradient_Color_Mask1854 = ( lerpResult1877 * _GradientColorIntensity );
				float3 lerpResult1838 = lerp( Base_Albedo1723 , temp_output_1836_0 , Gradient_Color_Mask1854);
				float3 Gradient_Color_Albedo1856 = lerpResult1838;
				#ifdef _ENABLEGRADIENTCOLOR_ON
				float3 staticSwitch1867 = Gradient_Color_Albedo1856;
				#else
				float3 staticSwitch1867 = Base_Albedo1723;
				#endif
				float3 Step_2_Albedo1914 = staticSwitch1867;
				float3 blendOpSrc1897 = Base_Albedo1723;
				float3 blendOpDest1897 = _SecondColor;
				float3 temp_output_1897_0 = ( saturate( (( blendOpDest1897 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest1897 ) * ( 1.0 - blendOpSrc1897 ) ) : ( 2.0 * blendOpDest1897 * blendOpSrc1897 ) ) ));
				float saferPower1886 = abs( ( ( 1.0 - input.ase_color.a ) * _SecondColorOffset ) );
				float temp_output_1889_0 = saturate( pow( saferPower1886 , ( _SecondColorContrast + 2.0 ) ) );
				float lerpResult1890 = lerp( temp_output_1889_0 , ( 1.0 - temp_output_1889_0 ) , _SecondColorInvertMask);
				float Second_Color_Mask1895 = ( lerpResult1890 * _SecondColorIntensity );
				float3 lerpResult1899 = lerp( Step_2_Albedo1914 , temp_output_1897_0 , Second_Color_Mask1895);
				float3 Second_Color_Albedo1902 = lerpResult1899;
				#ifdef _ENABLESECONDCOLOR_ON
				float3 staticSwitch1921 = Second_Color_Albedo1902;
				#else
				float3 staticSwitch1921 = Step_2_Albedo1914;
				#endif
				float3 Step_3_Albedo1954 = staticSwitch1921;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Tint_Color_Mask1949 = saturate( round( ( frac( ( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) * ( _TintNoiseOffset * ASP_GlobalTintNoiseUVScale ) ) ) * ( _TintNoiseContrast * ASP_GlobalTintNoiseContrast ) ) ) );
				float3 lerpResult1951 = lerp( _TintColor1.rgb , _TintColor2.rgb , Tint_Color_Mask1949);
				float3 blendOpSrc1952 = Step_3_Albedo1954;
				float3 blendOpDest1952 = lerpResult1951;
				float3 temp_output_1952_0 = ( saturate( (( blendOpDest1952 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest1952 ) * ( 1.0 - blendOpSrc1952 ) ) : ( 2.0 * blendOpDest1952 * blendOpSrc1952 ) ) ));
				float temp_output_1961_0 = ( _TintNoiseIntensity * ASP_GlobalTintNoiseIntensity );
				float3 lerpResult1956 = lerp( Step_3_Albedo1954 , temp_output_1952_0 , temp_output_1961_0);
				float3 Tint_Color_Albedo1963 = lerpResult1956;
				#ifdef _ENABLETINTCOLOR_ON
				float3 staticSwitch2080 = Tint_Color_Albedo1963;
				#else
				float3 staticSwitch2080 = Step_3_Albedo1954;
				#endif
				float3 Step_4_Albedo2083 = staticSwitch2080;
				float3 Top_Layer_Color1995 = _TopLayerColor;
				float2 uv_BaseNormal1741 = input.ase_texcoord8.xy;
				float3 unpack1741 = UnpackNormalScale( tex2D( _BaseNormal, uv_BaseNormal1741 ), _BaseNormalIntensity );
				unpack1741.z = lerp( 1, unpack1741.z, saturate(_BaseNormalIntensity) );
				float3 tex2DNode1741 = unpack1741;
				float3 break105_g45 = tex2DNode1741;
				float switchResult107_g45 = (((ase_vface>0)?(break105_g45.z):(-break105_g45.z)));
				float3 appendResult108_g45 = (float3(break105_g45.x , break105_g45.y , switchResult107_g45));
				#ifdef _ENABLEFLIPNORMALS_ON
				float3 staticSwitch1744 = appendResult108_g45;
				#else
				float3 staticSwitch1744 = tex2DNode1741;
				#endif
				float3 Base_Normal1747 = staticSwitch1744;
				float3 desaturateInitialColor2013 = Base_Normal1747;
				float desaturateDot2013 = dot( desaturateInitialColor2013, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar2013 = lerp( desaturateInitialColor2013, desaturateDot2013.xxx, 1.0 );
				float3 tanToWorld0 = float3( WorldTangent.x, WorldBiTangent.x, WorldNormal.x );
				float3 tanToWorld1 = float3( WorldTangent.y, WorldBiTangent.y, WorldNormal.y );
				float3 tanToWorld2 = float3( WorldTangent.z, WorldBiTangent.z, WorldNormal.z );
				float3 tanNormal2012 = Base_Normal1747;
				float3 worldNormal2012 = float3( dot( tanToWorld0, tanNormal2012 ), dot( tanToWorld1, tanNormal2012 ), dot( tanToWorld2, tanNormal2012 ) );
				float3 temp_cast_0 = (worldNormal2012.y).xxx;
				#ifdef _ENABLEWORLDPROJECTION_ON
				float3 staticSwitch2017 = temp_cast_0;
				#else
				float3 staticSwitch2017 = desaturateVar2013;
				#endif
				float3 saferPower17_g32 = abs( abs( ( saturate( staticSwitch2017 ) + ( _TopLayerOffset * ASPT_TopLayerOffset ) ) ) );
				float temp_output_2005_0 = ( _TopLayerContrast * ASPT_TopLayerContrast );
				float3 temp_cast_1 = (temp_output_2005_0).xxx;
				float saferPower2024 = abs( ( 1.0 - input.ase_color.a ) );
				float Top_Layer_Contrast2025 = temp_output_2005_0;
				float3 lerpResult2029 = lerp( ( ( saturate( pow( saferPower17_g32 , temp_cast_1 ) ) * ( _TopLayerIntensity * ASPT_TopLayerIntensity ) ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) ) , float3( 0,0,0 ) , saturate( ( pow( saferPower2024 , Top_Layer_Contrast2025 ) * _TopLayerAOMask ) ));
				float3 Top_Layer_Mask2031 = saturate( lerpResult2029 );
				float3 lerpResult2034 = lerp( Step_4_Albedo2083 , Top_Layer_Color1995 , Top_Layer_Mask2031);
				float3 lerpResult2037 = lerp( Step_4_Albedo2083 , lerpResult2034 , saturate( ( ase_vface > 0 ? +1 : -1 ) ));
				#ifdef _ENABLEBACKFACEPROJECTION_ON
				float3 staticSwitch2041 = lerpResult2034;
				#else
				float3 staticSwitch2041 = lerpResult2037;
				#endif
				float3 Top_Layer_Albedo2042 = staticSwitch2041;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch2043 = Top_Layer_Albedo2042;
				#else
				float3 staticSwitch2043 = Step_4_Albedo2083;
				#endif
				float3 Output_Albedo1873 = staticSwitch2043;
				
				float2 uv_BaseSSE1757 = input.ase_texcoord8.xy;
				float4 tex2DNode1757 = tex2D( _BaseSSE, uv_BaseSSE1757 );
				float RSE_Emissive_Mask1762 = tex2DNode1757.b;
				float saferPower1804 = abs( RSE_Emissive_Mask1762 );
				float3 temp_output_1806_0 = ( ( _BaseEmissiveColor.rgb * pow( saferPower1804 , _BaseEmissiveMaskContrast ) ) * _BaseEmissiveIntensity );
				float3 lerpResult1808 = lerp( temp_output_1806_0 , ( temp_output_1806_0 * input.ase_color.a ) , _BaseEmissiveAOMask);
				float3 Base_Emissive1812 = lerpResult1808;
				float3 lerpResult3341 = lerp( Base_Emissive1812 , float3( 0,0,0 ) , Top_Layer_Mask2031);
				float3 Top_Layer_Emissive3342 = lerpResult3341;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch3343 = Top_Layer_Emissive3342;
				#else
				float3 staticSwitch3343 = Base_Emissive1812;
				#endif
				float3 Output_Emissive3346 = staticSwitch3343;
				
				float Texture_Smoothness3646 = tex2DNode1757.r;
				float lerpResult3649 = lerp( _BaseSmoothnessMin , _BaseSmoothnessMax , Texture_Smoothness3646);
				float Base_Smoothness1760 = saturate( lerpResult3649 );
				float lerpResult2064 = lerp( Base_Smoothness1760 , _TopLayerSmoothnessIntensity , Top_Layer_Mask2031.x);
				float lerpResult2069 = lerp( Base_Smoothness1760 , lerpResult2064 , saturate( ( ase_vface > 0 ? +1 : -1 ) ));
				#ifdef _ENABLEBACKFACEPROJECTION_ON
				float staticSwitch2072 = lerpResult2064;
				#else
				float staticSwitch2072 = lerpResult2069;
				#endif
				float Top_Layer_Smoothness2073 = saturate( staticSwitch2072 );
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch2074 = Top_Layer_Smoothness2073;
				#else
				float staticSwitch2074 = Base_Smoothness1760;
				#endif
				float Output_Smoothness2077 = staticSwitch2074;
				
				float Opacity_Texture1737 = tex2DNode1753.a;
				float3 normalizeResult1780 = normalize( cross( ddx( WorldPosition ) , ddy( WorldPosition ) ) );
				float3 normalizeResult1787 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float dotResult1782 = dot( normalizeResult1780 , normalizeResult1787 );
				float lerpResult1794 = lerp( 1.0 , abs( dotResult1782 ) , _BaseGlancingAngleCut);
				#ifdef _ENABLEGLANCINGANGLECUT_ON
				float staticSwitch1788 = lerpResult1794;
				#else
				float staticSwitch1788 = 1.0;
				#endif
				float Base_Glancing_Angle1790 = staticSwitch1788;
				float Base_Opacity1739 = ( Opacity_Texture1737 * Base_Glancing_Angle1790 );
				
				float Local_SSS_Intensity3538 = _BaseSSSIntensity;
				float RSE_Subsurface_Mask1761 = tex2DNode1757.g;
				float lerpResult1726 = lerp( 1.0 , input.ase_color.a , saturate( ( _BaseSSSAOInfluence * ASP_GlobalTreeSSSAOInfluence ) ));
				float Base_SSS_AO_Influence1734 = lerpResult1726;
				float clampResult3460 = clamp( ( 1.0 - (0.0 + (distance( WorldPosition , _WorldSpaceCameraPos ) - 0.0) * (1.0 - 0.0) / (ASP_GlobalTreeSSSDistance - 0.0)) ) , 0.0 , 1.0 );
				float Base_SSS_Max_Distance3461 = clampResult3460;
				float3 Base_SSS1769 = ( ( ( ( ( Local_SSS_Intensity3538 * ASP_GlobalTreeSSSIntensity * 2.0 ) * RSE_Subsurface_Mask1761 ) * Base_SSS_AO_Influence1734 ) * Base_SSS_Max_Distance3461 ) * _BaseSSSColor );
				float3 lerpResult1859 = lerp( ( Base_Albedo1723 * Base_SSS1769 ) , ( temp_output_1836_0 * Base_SSS1769 ) , Gradient_Color_Mask1854);
				float3 Gradient_Color_SSS1864 = lerpResult1859;
				#ifdef _ENABLEGRADIENTCOLOR_ON
				float3 staticSwitch1869 = Gradient_Color_SSS1864;
				#else
				float3 staticSwitch1869 = ( Base_Albedo1723 * Base_SSS1769 );
				#endif
				float3 Step_2_SSS1915 = staticSwitch1869;
				float3 lerpResult1908 = lerp( Step_2_SSS1915 , ( temp_output_1897_0 * Base_SSS1769 ) , Second_Color_Mask1895);
				float3 Second_Color_SSS1910 = lerpResult1908;
				#ifdef _ENABLESECONDCOLOR_ON
				float3 staticSwitch1922 = Second_Color_SSS1910;
				#else
				float3 staticSwitch1922 = Step_2_SSS1915;
				#endif
				float3 Step_3_SSS1955 = staticSwitch1922;
				float3 lerpResult1966 = lerp( Step_3_SSS1955 , ( temp_output_1952_0 * Base_SSS1769 ) , temp_output_1961_0);
				float3 Tint_Color_SSS1968 = lerpResult1966;
				#ifdef _ENABLETINTCOLOR_ON
				float3 staticSwitch2081 = Tint_Color_SSS1968;
				#else
				float3 staticSwitch2081 = Step_3_SSS1955;
				#endif
				float3 Step_4_SSS2084 = staticSwitch2081;
				float Global_SSS_Intensity2050 = ASP_GlobalTreeSSSIntensity;
				float3 lerpResult2054 = lerp( Step_4_SSS2084 , ( ( Top_Layer_Color1995 * _TopLayerSSSIntensity * Global_SSS_Intensity2050 ) * _TopLayerSSSColor ) , Top_Layer_Mask2031);
				float3 lerpResult2059 = lerp( Step_4_SSS2084 , lerpResult2054 , saturate( ( ase_vface > 0 ? +1 : -1 ) ));
				#ifdef _ENABLEBACKFACEPROJECTION_ON
				float3 staticSwitch2060 = lerpResult2054;
				#else
				float3 staticSwitch2060 = lerpResult2059;
				#endif
				float3 Top_Layer_SSS2061 = staticSwitch2060;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch2045 = Top_Layer_SSS2061;
				#else
				float3 staticSwitch2045 = Step_4_SSS2084;
				#endif
				float3 Output_SSS1874 = staticSwitch2045;
				

				float3 BaseColor = Output_Albedo1873;
				float3 Normal = Base_Normal1747;
				float3 Emission = Output_Emissive3346;
				float3 Specular = 0.5;
				float Metallic = 0;
				float Smoothness = Output_Smoothness2077;
				float Occlusion = Base_AO1735;
				float Alpha = Base_Opacity1739;
				float AlphaClipThreshold = _CutOff;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = Output_SSS1874;

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
					float shadow = _BaseSSSShadow;
					float normal = _BaseSSSNormalDistortion;
					float scattering = _BaseSSSScattering;
					float direct = _BaseSSSDirect;
					float ambient = _BaseSSSAmbiet;
					float strength = _BaseSSSIntensity;

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
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define _EMISSION
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
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLEGLANCINGANGLECUT_ON


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
				float4 ase_texcoord2 : TEXCOORD2;
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
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseEmissiveColor;
			float4 _TintColor2;
			float4 _TintColor1;
			float3 _TopLayerSSSColor;
			float3 _SecondColor;
			float3 _TopLayerColor;
			float3 _GradientColor;
			half3 _BaseAlbedoColor;
			float3 _BaseSSSColor;
			float _TintNoiseOffset;
			float _TintNoiseContrast;
			float _TintNoiseIntensity;
			float _BaseNormalIntensity;
			half _TopLayerOffset;
			half _TopLayerContrast;
			half _TopLayerAOMask;
			float _BaseSSSAOInfluence;
			float _BaseEmissiveMaskContrast;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveAOMask;
			float _BaseSmoothnessMin;
			float _BaseSmoothnessMax;
			float _TopLayerSmoothnessIntensity;
			float _BaseGlancingAngleCut;
			float _CutOff;
			half _TopLayerIntensity;
			float _BaseSSSIntensity;
			float _SecondColorInvertMask;
			float _TopLayerSSSIntensity;
			float _BaseSSSAmbiet;
			float _BaseSSSShadow;
			float _BaseSSSNormalDistortion;
			float _BaseSSSScattering;
			float _WindTreeFlexibility;
			float _WindTreeBaseRigidity;
			float _WindLeafScale;
			float _WindLeafSpeed;
			float _WindLeafAmplitude;
			float _WindLeafTurbulence;
			float _WindLeafOffset;
			float _BaseAlbedoDesaturation;
			float _BaseAlbedoBrightness;
			float _BaseLerpBetweenColorandTexture;
			float _BaseTreeAOIntensity;
			float _GradientColorOffset;
			float _GradientColorContrast;
			float _GradientColorInvertMask;
			float _GradientColorIntensity;
			float _SecondColorOffset;
			float _SecondColorContrast;
			float _SecondColorIntensity;
			float _BaseSSSDirect;
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

			sampler2D ASP_GlobalTintNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindTreeSpeed;
			half ASPW_WindTreeAmplitude;
			half ASPW_WindTreeFlexibility;
			half ASPW_WindTreeLeafSpeed;
			half ASPW_WindTreeLeafAmplitude;
			half ASPW_WindTreeLeafTurbulence;
			half ASPW_WindTreeLeafOffset;
			float ASPW_WindToggle;
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
			

			float3 _LightDirection;
			float3 _LightPosition;

			PackedVaryings VertexFunction( Attributes input )
			{
				PackedVaryings output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( output );

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction493_g37 = ASPW_WindDirection;
				float3 worldToObjDir269_g37 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g37, 0.0 ) ).xyz;
				float3 normalizeResult268_g37 = ASESafeNormalize( worldToObjDir269_g37 );
				float3 Wind_Direction_Leaf85_g37 = normalizeResult268_g37;
				float3 break86_g37 = Wind_Direction_Leaf85_g37;
				float3 appendResult89_g37 = (float3(break86_g37.z , 0.0 , ( break86_g37.x * -1.0 )));
				float3 Wind_Direction91_g37 = appendResult89_g37;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g37 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g37 = ( Wind_Tree_Randomization149_g37 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g37 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g37 = ( Global_Wind_Tree_Speed491_g37 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g37 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g37 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g37 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g37 ) * 0.3 );
				float Wind_Tree_257_g37 = ( ( ( ( ( sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.1 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.3 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g37 ) * Global_Wind_Tree_Amplitude464_g37 ) * 0.01 ) * temp_output_383_0_g37 );
				float3 rotatedValue99_g37 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g37, Wind_Tree_257_g37 );
				float3 Rotate_About_Axis354_g37 = ( rotatedValue99_g37 - input.positionOS.xyz );
				float3 break452_g37 = normalizeResult268_g37;
				float3 appendResult454_g37 = (float3(break452_g37.x , 0.0 , break452_g37.z));
				float3 Wind_Direction_SM_Support453_g37 = appendResult454_g37;
				float Wind_Tree_Flexibility483_g37 = temp_output_383_0_g37;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g37 = ( Global_Wind_Tree_Amplitude464_g37 * Wind_Tree_257_g37 * Wind_Direction_SM_Support453_g37 * Wind_Tree_Flexibility483_g37 );
				#else
				float3 staticSwitch482_g37 = Rotate_About_Axis354_g37;
				#endif
				float3 Wind_Global450_g37 = staticSwitch482_g37;
				float2 texCoord433_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g37 = texCoord433_g37.y;
				float saferPower113_g37 = abs( Wind_Mask_UV_CH2_VChannel434_g37 );
				float Wind_Tree_Mask114_g37 = pow( saferPower113_g37 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g37 = ( Wind_Global450_g37 * Wind_Tree_Mask114_g37 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float temp_output_227_0_g37 = ( ( ase_positionWS.y * ( _WindLeafScale * 30.0 ) ) + _TimeParameters.x );
				float Global_Wind_Tree_Leaf_Speed495_g37 = ASPW_WindTreeLeafSpeed;
				float temp_output_223_0_g37 = ( _WindLeafSpeed * Global_Wind_Tree_Leaf_Speed495_g37 * 4.0 );
				float Global_Wind_Tree_Leaf_Amplitude497_g37 = ASPW_WindTreeLeafAmplitude;
				float temp_output_242_0_g37 = ( ( sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 0.5 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.25 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.5 ) ) ) ) * ( ( _WindLeafAmplitude * Global_Wind_Tree_Leaf_Amplitude497_g37 ) * 0.1 ) );
				float temp_output_243_0_g37 = ( temp_output_242_0_g37 * 0.2 );
				float3 appendResult244_g37 = (float3(temp_output_243_0_g37 , temp_output_242_0_g37 , temp_output_243_0_g37));
				float3 Wind_Leaf245_g37 = appendResult244_g37;
				float3 break416_g37 = normalizeResult268_g37;
				float3 appendResult417_g37 = (float3(( break416_g37.x * -1.0 ) , ( break416_g37.z * -1.0 ) , 0.0));
				float3 Wind_Direction_Turbulence419_g37 = appendResult417_g37;
				float2 appendResult322_g37 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Tree_Leaf_Turbulence502_g37 = ASPW_WindTreeLeafTurbulence;
				float Wind_Leaf_Turbulence334_g37 = saturate( ( tex2Dlod( ASP_GlobalTintNoiseTexture, float4( ( ( ( Wind_Direction_Turbulence419_g37 * _TimeParameters.x ) * 0.1 ) + float3( ( appendResult322_g37 * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).g + ( ( Global_Wind_Tree_Leaf_Turbulence502_g37 * _WindLeafTurbulence ) * 0.1 ) ) );
				float Wind_Mask_VColor_Blue429_g37 = input.ase_color.b;
				float3 Wind_Leaf_Mask285_g37 = ( ( ( Wind_Leaf245_g37 * Wind_Direction_Leaf85_g37 ) * Wind_Leaf_Turbulence334_g37 ) * Wind_Mask_VColor_Blue429_g37 );
				float Global_Wind_Tree_Leaf_Offset500_g37 = ASPW_WindTreeLeafOffset;
				float Wind_Mask_VColor_Green430_g37 = input.ase_color.g;
				float2 texCoord312_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float3 Wind_Leaf_Offset314_g37 = ( ( ( ( Wind_Direction_Leaf85_g37 * ( _WindLeafOffset * Global_Wind_Tree_Leaf_Offset500_g37 * 0.5 ) ) + Wind_Leaf_Mask285_g37 ) * Wind_Mask_VColor_Green430_g37 ) * texCoord312_g37.y );
				float Global_Wind_Toggle504_g37 = ASPW_WindToggle;
				float3 lerpResult125_g37 = lerp( float3( 0,0,0 ) , ( temp_output_385_0_g37 + ( Wind_Leaf_Mask285_g37 + Wind_Leaf_Offset314_g37 ) ) , Global_Wind_Toggle504_g37);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch469_g37 = lerpResult125_g37;
				#else
				float3 staticSwitch469_g37 = temp_cast_0;
				#endif
				
				output.ase_texcoord3.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord3.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch469_g37;
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
				float4 ase_texcoord2 : TEXCOORD2;
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
				output.ase_texcoord2 = input.ase_texcoord2;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
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

				float2 uv_BaseAlbedo1753 = input.ase_texcoord3.xy;
				float4 tex2DNode1753 = tex2D( _BaseAlbedo, uv_BaseAlbedo1753 );
				float Opacity_Texture1737 = tex2DNode1753.a;
				float3 normalizeResult1780 = normalize( cross( ddx( WorldPosition ) , ddy( WorldPosition ) ) );
				float3 normalizeResult1787 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float dotResult1782 = dot( normalizeResult1780 , normalizeResult1787 );
				float lerpResult1794 = lerp( 1.0 , abs( dotResult1782 ) , _BaseGlancingAngleCut);
				#ifdef _ENABLEGLANCINGANGLECUT_ON
				float staticSwitch1788 = lerpResult1794;
				#else
				float staticSwitch1788 = 1.0;
				#endif
				float Base_Glancing_Angle1790 = staticSwitch1788;
				float Base_Opacity1739 = ( Opacity_Texture1737 * Base_Glancing_Angle1790 );
				

				float Alpha = Base_Opacity1739;
				float AlphaClipThreshold = _CutOff;
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
			#pragma multi_compile_ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define _EMISSION
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
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLEGLANCINGANGLECUT_ON


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
				float4 ase_texcoord2 : TEXCOORD2;
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
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseEmissiveColor;
			float4 _TintColor2;
			float4 _TintColor1;
			float3 _TopLayerSSSColor;
			float3 _SecondColor;
			float3 _TopLayerColor;
			float3 _GradientColor;
			half3 _BaseAlbedoColor;
			float3 _BaseSSSColor;
			float _TintNoiseOffset;
			float _TintNoiseContrast;
			float _TintNoiseIntensity;
			float _BaseNormalIntensity;
			half _TopLayerOffset;
			half _TopLayerContrast;
			half _TopLayerAOMask;
			float _BaseSSSAOInfluence;
			float _BaseEmissiveMaskContrast;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveAOMask;
			float _BaseSmoothnessMin;
			float _BaseSmoothnessMax;
			float _TopLayerSmoothnessIntensity;
			float _BaseGlancingAngleCut;
			float _CutOff;
			half _TopLayerIntensity;
			float _BaseSSSIntensity;
			float _SecondColorInvertMask;
			float _TopLayerSSSIntensity;
			float _BaseSSSAmbiet;
			float _BaseSSSShadow;
			float _BaseSSSNormalDistortion;
			float _BaseSSSScattering;
			float _WindTreeFlexibility;
			float _WindTreeBaseRigidity;
			float _WindLeafScale;
			float _WindLeafSpeed;
			float _WindLeafAmplitude;
			float _WindLeafTurbulence;
			float _WindLeafOffset;
			float _BaseAlbedoDesaturation;
			float _BaseAlbedoBrightness;
			float _BaseLerpBetweenColorandTexture;
			float _BaseTreeAOIntensity;
			float _GradientColorOffset;
			float _GradientColorContrast;
			float _GradientColorInvertMask;
			float _GradientColorIntensity;
			float _SecondColorOffset;
			float _SecondColorContrast;
			float _SecondColorIntensity;
			float _BaseSSSDirect;
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

			sampler2D ASP_GlobalTintNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindTreeSpeed;
			half ASPW_WindTreeAmplitude;
			half ASPW_WindTreeFlexibility;
			half ASPW_WindTreeLeafSpeed;
			half ASPW_WindTreeLeafAmplitude;
			half ASPW_WindTreeLeafTurbulence;
			half ASPW_WindTreeLeafOffset;
			float ASPW_WindToggle;
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
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction493_g37 = ASPW_WindDirection;
				float3 worldToObjDir269_g37 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g37, 0.0 ) ).xyz;
				float3 normalizeResult268_g37 = ASESafeNormalize( worldToObjDir269_g37 );
				float3 Wind_Direction_Leaf85_g37 = normalizeResult268_g37;
				float3 break86_g37 = Wind_Direction_Leaf85_g37;
				float3 appendResult89_g37 = (float3(break86_g37.z , 0.0 , ( break86_g37.x * -1.0 )));
				float3 Wind_Direction91_g37 = appendResult89_g37;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g37 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g37 = ( Wind_Tree_Randomization149_g37 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g37 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g37 = ( Global_Wind_Tree_Speed491_g37 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g37 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g37 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g37 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g37 ) * 0.3 );
				float Wind_Tree_257_g37 = ( ( ( ( ( sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.1 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.3 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g37 ) * Global_Wind_Tree_Amplitude464_g37 ) * 0.01 ) * temp_output_383_0_g37 );
				float3 rotatedValue99_g37 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g37, Wind_Tree_257_g37 );
				float3 Rotate_About_Axis354_g37 = ( rotatedValue99_g37 - input.positionOS.xyz );
				float3 break452_g37 = normalizeResult268_g37;
				float3 appendResult454_g37 = (float3(break452_g37.x , 0.0 , break452_g37.z));
				float3 Wind_Direction_SM_Support453_g37 = appendResult454_g37;
				float Wind_Tree_Flexibility483_g37 = temp_output_383_0_g37;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g37 = ( Global_Wind_Tree_Amplitude464_g37 * Wind_Tree_257_g37 * Wind_Direction_SM_Support453_g37 * Wind_Tree_Flexibility483_g37 );
				#else
				float3 staticSwitch482_g37 = Rotate_About_Axis354_g37;
				#endif
				float3 Wind_Global450_g37 = staticSwitch482_g37;
				float2 texCoord433_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g37 = texCoord433_g37.y;
				float saferPower113_g37 = abs( Wind_Mask_UV_CH2_VChannel434_g37 );
				float Wind_Tree_Mask114_g37 = pow( saferPower113_g37 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g37 = ( Wind_Global450_g37 * Wind_Tree_Mask114_g37 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float temp_output_227_0_g37 = ( ( ase_positionWS.y * ( _WindLeafScale * 30.0 ) ) + _TimeParameters.x );
				float Global_Wind_Tree_Leaf_Speed495_g37 = ASPW_WindTreeLeafSpeed;
				float temp_output_223_0_g37 = ( _WindLeafSpeed * Global_Wind_Tree_Leaf_Speed495_g37 * 4.0 );
				float Global_Wind_Tree_Leaf_Amplitude497_g37 = ASPW_WindTreeLeafAmplitude;
				float temp_output_242_0_g37 = ( ( sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 0.5 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.25 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.5 ) ) ) ) * ( ( _WindLeafAmplitude * Global_Wind_Tree_Leaf_Amplitude497_g37 ) * 0.1 ) );
				float temp_output_243_0_g37 = ( temp_output_242_0_g37 * 0.2 );
				float3 appendResult244_g37 = (float3(temp_output_243_0_g37 , temp_output_242_0_g37 , temp_output_243_0_g37));
				float3 Wind_Leaf245_g37 = appendResult244_g37;
				float3 break416_g37 = normalizeResult268_g37;
				float3 appendResult417_g37 = (float3(( break416_g37.x * -1.0 ) , ( break416_g37.z * -1.0 ) , 0.0));
				float3 Wind_Direction_Turbulence419_g37 = appendResult417_g37;
				float2 appendResult322_g37 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Tree_Leaf_Turbulence502_g37 = ASPW_WindTreeLeafTurbulence;
				float Wind_Leaf_Turbulence334_g37 = saturate( ( tex2Dlod( ASP_GlobalTintNoiseTexture, float4( ( ( ( Wind_Direction_Turbulence419_g37 * _TimeParameters.x ) * 0.1 ) + float3( ( appendResult322_g37 * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).g + ( ( Global_Wind_Tree_Leaf_Turbulence502_g37 * _WindLeafTurbulence ) * 0.1 ) ) );
				float Wind_Mask_VColor_Blue429_g37 = input.ase_color.b;
				float3 Wind_Leaf_Mask285_g37 = ( ( ( Wind_Leaf245_g37 * Wind_Direction_Leaf85_g37 ) * Wind_Leaf_Turbulence334_g37 ) * Wind_Mask_VColor_Blue429_g37 );
				float Global_Wind_Tree_Leaf_Offset500_g37 = ASPW_WindTreeLeafOffset;
				float Wind_Mask_VColor_Green430_g37 = input.ase_color.g;
				float2 texCoord312_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float3 Wind_Leaf_Offset314_g37 = ( ( ( ( Wind_Direction_Leaf85_g37 * ( _WindLeafOffset * Global_Wind_Tree_Leaf_Offset500_g37 * 0.5 ) ) + Wind_Leaf_Mask285_g37 ) * Wind_Mask_VColor_Green430_g37 ) * texCoord312_g37.y );
				float Global_Wind_Toggle504_g37 = ASPW_WindToggle;
				float3 lerpResult125_g37 = lerp( float3( 0,0,0 ) , ( temp_output_385_0_g37 + ( Wind_Leaf_Mask285_g37 + Wind_Leaf_Offset314_g37 ) ) , Global_Wind_Toggle504_g37);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch469_g37 = lerpResult125_g37;
				#else
				float3 staticSwitch469_g37 = temp_cast_0;
				#endif
				
				output.ase_texcoord3.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord3.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch469_g37;

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
				float4 ase_texcoord2 : TEXCOORD2;
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
				output.ase_texcoord2 = input.ase_texcoord2;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
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

				float2 uv_BaseAlbedo1753 = input.ase_texcoord3.xy;
				float4 tex2DNode1753 = tex2D( _BaseAlbedo, uv_BaseAlbedo1753 );
				float Opacity_Texture1737 = tex2DNode1753.a;
				float3 normalizeResult1780 = normalize( cross( ddx( WorldPosition ) , ddy( WorldPosition ) ) );
				float3 normalizeResult1787 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float dotResult1782 = dot( normalizeResult1780 , normalizeResult1787 );
				float lerpResult1794 = lerp( 1.0 , abs( dotResult1782 ) , _BaseGlancingAngleCut);
				#ifdef _ENABLEGLANCINGANGLECUT_ON
				float staticSwitch1788 = lerpResult1794;
				#else
				float staticSwitch1788 = 1.0;
				#endif
				float Base_Glancing_Angle1790 = staticSwitch1788;
				float Base_Opacity1739 = ( Opacity_Texture1737 * Base_Glancing_Angle1790 );
				

				float Alpha = Base_Opacity1739;
				float AlphaClipThreshold = _CutOff;

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
			#define ASE_TRANSLUCENCY 1
			#define _EMISSION
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
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON
			#pragma shader_feature_local _ENABLETINTCOLOR_ON
			#pragma shader_feature_local _ENABLESECONDCOLOR_ON
			#pragma shader_feature_local _ENABLEGRADIENTCOLOR_ON
			#pragma shader_feature_local _ENABLEBACKFACEPROJECTION_ON
			#pragma shader_feature_local _ENABLEWORLDPROJECTION_ON
			#pragma shader_feature_local _ENABLEFLIPNORMALS_ON
			#pragma shader_feature_local _ENABLEGLANCINGANGLECUT_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				float4 ase_tangent : TANGENT;
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
				float4 ase_texcoord6 : TEXCOORD6;
				float4 ase_texcoord7 : TEXCOORD7;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseEmissiveColor;
			float4 _TintColor2;
			float4 _TintColor1;
			float3 _TopLayerSSSColor;
			float3 _SecondColor;
			float3 _TopLayerColor;
			float3 _GradientColor;
			half3 _BaseAlbedoColor;
			float3 _BaseSSSColor;
			float _TintNoiseOffset;
			float _TintNoiseContrast;
			float _TintNoiseIntensity;
			float _BaseNormalIntensity;
			half _TopLayerOffset;
			half _TopLayerContrast;
			half _TopLayerAOMask;
			float _BaseSSSAOInfluence;
			float _BaseEmissiveMaskContrast;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveAOMask;
			float _BaseSmoothnessMin;
			float _BaseSmoothnessMax;
			float _TopLayerSmoothnessIntensity;
			float _BaseGlancingAngleCut;
			float _CutOff;
			half _TopLayerIntensity;
			float _BaseSSSIntensity;
			float _SecondColorInvertMask;
			float _TopLayerSSSIntensity;
			float _BaseSSSAmbiet;
			float _BaseSSSShadow;
			float _BaseSSSNormalDistortion;
			float _BaseSSSScattering;
			float _WindTreeFlexibility;
			float _WindTreeBaseRigidity;
			float _WindLeafScale;
			float _WindLeafSpeed;
			float _WindLeafAmplitude;
			float _WindLeafTurbulence;
			float _WindLeafOffset;
			float _BaseAlbedoDesaturation;
			float _BaseAlbedoBrightness;
			float _BaseLerpBetweenColorandTexture;
			float _BaseTreeAOIntensity;
			float _GradientColorOffset;
			float _GradientColorContrast;
			float _GradientColorInvertMask;
			float _GradientColorIntensity;
			float _SecondColorOffset;
			float _SecondColorContrast;
			float _SecondColorIntensity;
			float _BaseSSSDirect;
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

			sampler2D ASP_GlobalTintNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindTreeSpeed;
			half ASPW_WindTreeAmplitude;
			half ASPW_WindTreeFlexibility;
			half ASPW_WindTreeLeafSpeed;
			half ASPW_WindTreeLeafAmplitude;
			half ASPW_WindTreeLeafTurbulence;
			half ASPW_WindTreeLeafOffset;
			float ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			half ASP_GlobalTreeAO;
			half ASP_GlobalTintNoiseUVScale;
			half ASP_GlobalTintNoiseContrast;
			half ASP_GlobalTintNoiseIntensity;
			sampler2D _BaseNormal;
			half ASPT_TopLayerOffset;
			half ASPT_TopLayerContrast;
			half ASPT_TopLayerIntensity;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;
			sampler2D _BaseSSE;


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
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction493_g37 = ASPW_WindDirection;
				float3 worldToObjDir269_g37 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g37, 0.0 ) ).xyz;
				float3 normalizeResult268_g37 = ASESafeNormalize( worldToObjDir269_g37 );
				float3 Wind_Direction_Leaf85_g37 = normalizeResult268_g37;
				float3 break86_g37 = Wind_Direction_Leaf85_g37;
				float3 appendResult89_g37 = (float3(break86_g37.z , 0.0 , ( break86_g37.x * -1.0 )));
				float3 Wind_Direction91_g37 = appendResult89_g37;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g37 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g37 = ( Wind_Tree_Randomization149_g37 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g37 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g37 = ( Global_Wind_Tree_Speed491_g37 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g37 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g37 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g37 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g37 ) * 0.3 );
				float Wind_Tree_257_g37 = ( ( ( ( ( sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.1 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.3 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g37 ) * Global_Wind_Tree_Amplitude464_g37 ) * 0.01 ) * temp_output_383_0_g37 );
				float3 rotatedValue99_g37 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g37, Wind_Tree_257_g37 );
				float3 Rotate_About_Axis354_g37 = ( rotatedValue99_g37 - input.positionOS.xyz );
				float3 break452_g37 = normalizeResult268_g37;
				float3 appendResult454_g37 = (float3(break452_g37.x , 0.0 , break452_g37.z));
				float3 Wind_Direction_SM_Support453_g37 = appendResult454_g37;
				float Wind_Tree_Flexibility483_g37 = temp_output_383_0_g37;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g37 = ( Global_Wind_Tree_Amplitude464_g37 * Wind_Tree_257_g37 * Wind_Direction_SM_Support453_g37 * Wind_Tree_Flexibility483_g37 );
				#else
				float3 staticSwitch482_g37 = Rotate_About_Axis354_g37;
				#endif
				float3 Wind_Global450_g37 = staticSwitch482_g37;
				float2 texCoord433_g37 = input.texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g37 = texCoord433_g37.y;
				float saferPower113_g37 = abs( Wind_Mask_UV_CH2_VChannel434_g37 );
				float Wind_Tree_Mask114_g37 = pow( saferPower113_g37 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g37 = ( Wind_Global450_g37 * Wind_Tree_Mask114_g37 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float temp_output_227_0_g37 = ( ( ase_positionWS.y * ( _WindLeafScale * 30.0 ) ) + _TimeParameters.x );
				float Global_Wind_Tree_Leaf_Speed495_g37 = ASPW_WindTreeLeafSpeed;
				float temp_output_223_0_g37 = ( _WindLeafSpeed * Global_Wind_Tree_Leaf_Speed495_g37 * 4.0 );
				float Global_Wind_Tree_Leaf_Amplitude497_g37 = ASPW_WindTreeLeafAmplitude;
				float temp_output_242_0_g37 = ( ( sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 0.5 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.25 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.5 ) ) ) ) * ( ( _WindLeafAmplitude * Global_Wind_Tree_Leaf_Amplitude497_g37 ) * 0.1 ) );
				float temp_output_243_0_g37 = ( temp_output_242_0_g37 * 0.2 );
				float3 appendResult244_g37 = (float3(temp_output_243_0_g37 , temp_output_242_0_g37 , temp_output_243_0_g37));
				float3 Wind_Leaf245_g37 = appendResult244_g37;
				float3 break416_g37 = normalizeResult268_g37;
				float3 appendResult417_g37 = (float3(( break416_g37.x * -1.0 ) , ( break416_g37.z * -1.0 ) , 0.0));
				float3 Wind_Direction_Turbulence419_g37 = appendResult417_g37;
				float2 appendResult322_g37 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Tree_Leaf_Turbulence502_g37 = ASPW_WindTreeLeafTurbulence;
				float Wind_Leaf_Turbulence334_g37 = saturate( ( tex2Dlod( ASP_GlobalTintNoiseTexture, float4( ( ( ( Wind_Direction_Turbulence419_g37 * _TimeParameters.x ) * 0.1 ) + float3( ( appendResult322_g37 * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).g + ( ( Global_Wind_Tree_Leaf_Turbulence502_g37 * _WindLeafTurbulence ) * 0.1 ) ) );
				float Wind_Mask_VColor_Blue429_g37 = input.ase_color.b;
				float3 Wind_Leaf_Mask285_g37 = ( ( ( Wind_Leaf245_g37 * Wind_Direction_Leaf85_g37 ) * Wind_Leaf_Turbulence334_g37 ) * Wind_Mask_VColor_Blue429_g37 );
				float Global_Wind_Tree_Leaf_Offset500_g37 = ASPW_WindTreeLeafOffset;
				float Wind_Mask_VColor_Green430_g37 = input.ase_color.g;
				float2 texCoord312_g37 = input.texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float3 Wind_Leaf_Offset314_g37 = ( ( ( ( Wind_Direction_Leaf85_g37 * ( _WindLeafOffset * Global_Wind_Tree_Leaf_Offset500_g37 * 0.5 ) ) + Wind_Leaf_Mask285_g37 ) * Wind_Mask_VColor_Green430_g37 ) * texCoord312_g37.y );
				float Global_Wind_Toggle504_g37 = ASPW_WindToggle;
				float3 lerpResult125_g37 = lerp( float3( 0,0,0 ) , ( temp_output_385_0_g37 + ( Wind_Leaf_Mask285_g37 + Wind_Leaf_Offset314_g37 ) ) , Global_Wind_Toggle504_g37);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch469_g37 = lerpResult125_g37;
				#else
				float3 staticSwitch469_g37 = temp_cast_0;
				#endif
				
				float3 ase_tangentWS = TransformObjectToWorldDir( input.ase_tangent.xyz );
				output.ase_texcoord5.xyz = ase_tangentWS;
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord6.xyz = ase_normalWS;
				float ase_tangentSign = input.ase_tangent.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord7.xyz = ase_bitangentWS;
				
				output.ase_texcoord4.xy = input.texcoord0.xy;
				output.ase_color = input.ase_color;
				output.ase_texcoord4.zw = input.texcoord2.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord5.w = 0;
				output.ase_texcoord6.w = 0;
				output.ase_texcoord7.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch469_g37;

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
				float4 ase_tangent : TANGENT;

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
				output.ase_tangent = input.ase_tangent;
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
				output.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
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

				float2 uv_BaseAlbedo1753 = input.ase_texcoord4.xy;
				float4 tex2DNode1753 = tex2D( _BaseAlbedo, uv_BaseAlbedo1753 );
				float3 desaturateInitialColor1712 = tex2DNode1753.rgb;
				float desaturateDot1712 = dot( desaturateInitialColor1712, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar1712 = lerp( desaturateInitialColor1712, desaturateDot1712.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc3324 = ( desaturateVar1712 * _BaseAlbedoBrightness );
				float3 blendOpDest3324 = _BaseAlbedoColor;
				float3 lerpResult1716 = lerp( _BaseAlbedoColor , ( saturate( (( blendOpDest3324 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest3324 ) * ( 1.0 - blendOpSrc3324 ) ) : ( 2.0 * blendOpDest3324 * blendOpSrc3324 ) ) )) , _BaseLerpBetweenColorandTexture);
				float lerpResult1727 = lerp( 1.0 , input.ase_color.a , saturate( ( _BaseTreeAOIntensity * ASP_GlobalTreeAO ) ));
				float Base_AO1735 = lerpResult1727;
				float3 Base_Albedo1723 = ( lerpResult1716 * Base_AO1735 );
				float3 blendOpSrc1836 = Base_Albedo1723;
				float3 blendOpDest1836 = _GradientColor;
				float3 temp_output_1836_0 = ( saturate( (( blendOpDest1836 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest1836 ) * ( 1.0 - blendOpSrc1836 ) ) : ( 2.0 * blendOpDest1836 * blendOpSrc1836 ) ) ));
				float2 texCoord1840 = input.ase_texcoord4.zw * float2( 1,1 ) + float2( 0,0 );
				float saferPower1879 = abs( ( ( 1.0 - texCoord1840.y ) * _GradientColorOffset ) );
				float temp_output_1848_0 = saturate( pow( saferPower1879 , _GradientColorContrast ) );
				float lerpResult1877 = lerp( temp_output_1848_0 , ( 1.0 - temp_output_1848_0 ) , _GradientColorInvertMask);
				float Gradient_Color_Mask1854 = ( lerpResult1877 * _GradientColorIntensity );
				float3 lerpResult1838 = lerp( Base_Albedo1723 , temp_output_1836_0 , Gradient_Color_Mask1854);
				float3 Gradient_Color_Albedo1856 = lerpResult1838;
				#ifdef _ENABLEGRADIENTCOLOR_ON
				float3 staticSwitch1867 = Gradient_Color_Albedo1856;
				#else
				float3 staticSwitch1867 = Base_Albedo1723;
				#endif
				float3 Step_2_Albedo1914 = staticSwitch1867;
				float3 blendOpSrc1897 = Base_Albedo1723;
				float3 blendOpDest1897 = _SecondColor;
				float3 temp_output_1897_0 = ( saturate( (( blendOpDest1897 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest1897 ) * ( 1.0 - blendOpSrc1897 ) ) : ( 2.0 * blendOpDest1897 * blendOpSrc1897 ) ) ));
				float saferPower1886 = abs( ( ( 1.0 - input.ase_color.a ) * _SecondColorOffset ) );
				float temp_output_1889_0 = saturate( pow( saferPower1886 , ( _SecondColorContrast + 2.0 ) ) );
				float lerpResult1890 = lerp( temp_output_1889_0 , ( 1.0 - temp_output_1889_0 ) , _SecondColorInvertMask);
				float Second_Color_Mask1895 = ( lerpResult1890 * _SecondColorIntensity );
				float3 lerpResult1899 = lerp( Step_2_Albedo1914 , temp_output_1897_0 , Second_Color_Mask1895);
				float3 Second_Color_Albedo1902 = lerpResult1899;
				#ifdef _ENABLESECONDCOLOR_ON
				float3 staticSwitch1921 = Second_Color_Albedo1902;
				#else
				float3 staticSwitch1921 = Step_2_Albedo1914;
				#endif
				float3 Step_3_Albedo1954 = staticSwitch1921;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Tint_Color_Mask1949 = saturate( round( ( frac( ( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) * ( _TintNoiseOffset * ASP_GlobalTintNoiseUVScale ) ) ) * ( _TintNoiseContrast * ASP_GlobalTintNoiseContrast ) ) ) );
				float3 lerpResult1951 = lerp( _TintColor1.rgb , _TintColor2.rgb , Tint_Color_Mask1949);
				float3 blendOpSrc1952 = Step_3_Albedo1954;
				float3 blendOpDest1952 = lerpResult1951;
				float3 temp_output_1952_0 = ( saturate( (( blendOpDest1952 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest1952 ) * ( 1.0 - blendOpSrc1952 ) ) : ( 2.0 * blendOpDest1952 * blendOpSrc1952 ) ) ));
				float temp_output_1961_0 = ( _TintNoiseIntensity * ASP_GlobalTintNoiseIntensity );
				float3 lerpResult1956 = lerp( Step_3_Albedo1954 , temp_output_1952_0 , temp_output_1961_0);
				float3 Tint_Color_Albedo1963 = lerpResult1956;
				#ifdef _ENABLETINTCOLOR_ON
				float3 staticSwitch2080 = Tint_Color_Albedo1963;
				#else
				float3 staticSwitch2080 = Step_3_Albedo1954;
				#endif
				float3 Step_4_Albedo2083 = staticSwitch2080;
				float3 Top_Layer_Color1995 = _TopLayerColor;
				float2 uv_BaseNormal1741 = input.ase_texcoord4.xy;
				float3 unpack1741 = UnpackNormalScale( tex2D( _BaseNormal, uv_BaseNormal1741 ), _BaseNormalIntensity );
				unpack1741.z = lerp( 1, unpack1741.z, saturate(_BaseNormalIntensity) );
				float3 tex2DNode1741 = unpack1741;
				float3 break105_g45 = tex2DNode1741;
				float switchResult107_g45 = (((ase_vface>0)?(break105_g45.z):(-break105_g45.z)));
				float3 appendResult108_g45 = (float3(break105_g45.x , break105_g45.y , switchResult107_g45));
				#ifdef _ENABLEFLIPNORMALS_ON
				float3 staticSwitch1744 = appendResult108_g45;
				#else
				float3 staticSwitch1744 = tex2DNode1741;
				#endif
				float3 Base_Normal1747 = staticSwitch1744;
				float3 desaturateInitialColor2013 = Base_Normal1747;
				float desaturateDot2013 = dot( desaturateInitialColor2013, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar2013 = lerp( desaturateInitialColor2013, desaturateDot2013.xxx, 1.0 );
				float3 ase_tangentWS = input.ase_texcoord5.xyz;
				float3 ase_normalWS = input.ase_texcoord6.xyz;
				float3 ase_bitangentWS = input.ase_texcoord7.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal2012 = Base_Normal1747;
				float3 worldNormal2012 = float3( dot( tanToWorld0, tanNormal2012 ), dot( tanToWorld1, tanNormal2012 ), dot( tanToWorld2, tanNormal2012 ) );
				float3 temp_cast_0 = (worldNormal2012.y).xxx;
				#ifdef _ENABLEWORLDPROJECTION_ON
				float3 staticSwitch2017 = temp_cast_0;
				#else
				float3 staticSwitch2017 = desaturateVar2013;
				#endif
				float3 saferPower17_g32 = abs( abs( ( saturate( staticSwitch2017 ) + ( _TopLayerOffset * ASPT_TopLayerOffset ) ) ) );
				float temp_output_2005_0 = ( _TopLayerContrast * ASPT_TopLayerContrast );
				float3 temp_cast_1 = (temp_output_2005_0).xxx;
				float saferPower2024 = abs( ( 1.0 - input.ase_color.a ) );
				float Top_Layer_Contrast2025 = temp_output_2005_0;
				float3 lerpResult2029 = lerp( ( ( saturate( pow( saferPower17_g32 , temp_cast_1 ) ) * ( _TopLayerIntensity * ASPT_TopLayerIntensity ) ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) ) , float3( 0,0,0 ) , saturate( ( pow( saferPower2024 , Top_Layer_Contrast2025 ) * _TopLayerAOMask ) ));
				float3 Top_Layer_Mask2031 = saturate( lerpResult2029 );
				float3 lerpResult2034 = lerp( Step_4_Albedo2083 , Top_Layer_Color1995 , Top_Layer_Mask2031);
				float3 lerpResult2037 = lerp( Step_4_Albedo2083 , lerpResult2034 , saturate( ( ase_vface > 0 ? +1 : -1 ) ));
				#ifdef _ENABLEBACKFACEPROJECTION_ON
				float3 staticSwitch2041 = lerpResult2034;
				#else
				float3 staticSwitch2041 = lerpResult2037;
				#endif
				float3 Top_Layer_Albedo2042 = staticSwitch2041;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch2043 = Top_Layer_Albedo2042;
				#else
				float3 staticSwitch2043 = Step_4_Albedo2083;
				#endif
				float3 Output_Albedo1873 = staticSwitch2043;
				
				float2 uv_BaseSSE1757 = input.ase_texcoord4.xy;
				float4 tex2DNode1757 = tex2D( _BaseSSE, uv_BaseSSE1757 );
				float RSE_Emissive_Mask1762 = tex2DNode1757.b;
				float saferPower1804 = abs( RSE_Emissive_Mask1762 );
				float3 temp_output_1806_0 = ( ( _BaseEmissiveColor.rgb * pow( saferPower1804 , _BaseEmissiveMaskContrast ) ) * _BaseEmissiveIntensity );
				float3 lerpResult1808 = lerp( temp_output_1806_0 , ( temp_output_1806_0 * input.ase_color.a ) , _BaseEmissiveAOMask);
				float3 Base_Emissive1812 = lerpResult1808;
				float3 lerpResult3341 = lerp( Base_Emissive1812 , float3( 0,0,0 ) , Top_Layer_Mask2031);
				float3 Top_Layer_Emissive3342 = lerpResult3341;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch3343 = Top_Layer_Emissive3342;
				#else
				float3 staticSwitch3343 = Base_Emissive1812;
				#endif
				float3 Output_Emissive3346 = staticSwitch3343;
				
				float Opacity_Texture1737 = tex2DNode1753.a;
				float3 normalizeResult1780 = normalize( cross( ddx( WorldPosition ) , ddy( WorldPosition ) ) );
				float3 normalizeResult1787 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float dotResult1782 = dot( normalizeResult1780 , normalizeResult1787 );
				float lerpResult1794 = lerp( 1.0 , abs( dotResult1782 ) , _BaseGlancingAngleCut);
				#ifdef _ENABLEGLANCINGANGLECUT_ON
				float staticSwitch1788 = lerpResult1794;
				#else
				float staticSwitch1788 = 1.0;
				#endif
				float Base_Glancing_Angle1790 = staticSwitch1788;
				float Base_Opacity1739 = ( Opacity_Texture1737 * Base_Glancing_Angle1790 );
				

				float3 BaseColor = Output_Albedo1873;
				float3 Emission = Output_Emissive3346;
				float Alpha = Base_Opacity1739;
				float AlphaClipThreshold = _CutOff;

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
			#define ASE_TRANSLUCENCY 1
			#define _EMISSION
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
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON
			#pragma shader_feature_local _ENABLETINTCOLOR_ON
			#pragma shader_feature_local _ENABLESECONDCOLOR_ON
			#pragma shader_feature_local _ENABLEGRADIENTCOLOR_ON
			#pragma shader_feature_local _ENABLEBACKFACEPROJECTION_ON
			#pragma shader_feature_local _ENABLEWORLDPROJECTION_ON
			#pragma shader_feature_local _ENABLEFLIPNORMALS_ON
			#pragma shader_feature_local _ENABLEGLANCINGANGLECUT_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;
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
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseEmissiveColor;
			float4 _TintColor2;
			float4 _TintColor1;
			float3 _TopLayerSSSColor;
			float3 _SecondColor;
			float3 _TopLayerColor;
			float3 _GradientColor;
			half3 _BaseAlbedoColor;
			float3 _BaseSSSColor;
			float _TintNoiseOffset;
			float _TintNoiseContrast;
			float _TintNoiseIntensity;
			float _BaseNormalIntensity;
			half _TopLayerOffset;
			half _TopLayerContrast;
			half _TopLayerAOMask;
			float _BaseSSSAOInfluence;
			float _BaseEmissiveMaskContrast;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveAOMask;
			float _BaseSmoothnessMin;
			float _BaseSmoothnessMax;
			float _TopLayerSmoothnessIntensity;
			float _BaseGlancingAngleCut;
			float _CutOff;
			half _TopLayerIntensity;
			float _BaseSSSIntensity;
			float _SecondColorInvertMask;
			float _TopLayerSSSIntensity;
			float _BaseSSSAmbiet;
			float _BaseSSSShadow;
			float _BaseSSSNormalDistortion;
			float _BaseSSSScattering;
			float _WindTreeFlexibility;
			float _WindTreeBaseRigidity;
			float _WindLeafScale;
			float _WindLeafSpeed;
			float _WindLeafAmplitude;
			float _WindLeafTurbulence;
			float _WindLeafOffset;
			float _BaseAlbedoDesaturation;
			float _BaseAlbedoBrightness;
			float _BaseLerpBetweenColorandTexture;
			float _BaseTreeAOIntensity;
			float _GradientColorOffset;
			float _GradientColorContrast;
			float _GradientColorInvertMask;
			float _GradientColorIntensity;
			float _SecondColorOffset;
			float _SecondColorContrast;
			float _SecondColorIntensity;
			float _BaseSSSDirect;
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

			sampler2D ASP_GlobalTintNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindTreeSpeed;
			half ASPW_WindTreeAmplitude;
			half ASPW_WindTreeFlexibility;
			half ASPW_WindTreeLeafSpeed;
			half ASPW_WindTreeLeafAmplitude;
			half ASPW_WindTreeLeafTurbulence;
			half ASPW_WindTreeLeafOffset;
			float ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			half ASP_GlobalTreeAO;
			half ASP_GlobalTintNoiseUVScale;
			half ASP_GlobalTintNoiseContrast;
			half ASP_GlobalTintNoiseIntensity;
			sampler2D _BaseNormal;
			half ASPT_TopLayerOffset;
			half ASPT_TopLayerContrast;
			half ASPT_TopLayerIntensity;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;


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
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID( input );
				UNITY_TRANSFER_INSTANCE_ID( input, output );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( output );

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction493_g37 = ASPW_WindDirection;
				float3 worldToObjDir269_g37 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g37, 0.0 ) ).xyz;
				float3 normalizeResult268_g37 = ASESafeNormalize( worldToObjDir269_g37 );
				float3 Wind_Direction_Leaf85_g37 = normalizeResult268_g37;
				float3 break86_g37 = Wind_Direction_Leaf85_g37;
				float3 appendResult89_g37 = (float3(break86_g37.z , 0.0 , ( break86_g37.x * -1.0 )));
				float3 Wind_Direction91_g37 = appendResult89_g37;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g37 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g37 = ( Wind_Tree_Randomization149_g37 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g37 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g37 = ( Global_Wind_Tree_Speed491_g37 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g37 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g37 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g37 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g37 ) * 0.3 );
				float Wind_Tree_257_g37 = ( ( ( ( ( sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.1 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.3 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g37 ) * Global_Wind_Tree_Amplitude464_g37 ) * 0.01 ) * temp_output_383_0_g37 );
				float3 rotatedValue99_g37 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g37, Wind_Tree_257_g37 );
				float3 Rotate_About_Axis354_g37 = ( rotatedValue99_g37 - input.positionOS.xyz );
				float3 break452_g37 = normalizeResult268_g37;
				float3 appendResult454_g37 = (float3(break452_g37.x , 0.0 , break452_g37.z));
				float3 Wind_Direction_SM_Support453_g37 = appendResult454_g37;
				float Wind_Tree_Flexibility483_g37 = temp_output_383_0_g37;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g37 = ( Global_Wind_Tree_Amplitude464_g37 * Wind_Tree_257_g37 * Wind_Direction_SM_Support453_g37 * Wind_Tree_Flexibility483_g37 );
				#else
				float3 staticSwitch482_g37 = Rotate_About_Axis354_g37;
				#endif
				float3 Wind_Global450_g37 = staticSwitch482_g37;
				float2 texCoord433_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g37 = texCoord433_g37.y;
				float saferPower113_g37 = abs( Wind_Mask_UV_CH2_VChannel434_g37 );
				float Wind_Tree_Mask114_g37 = pow( saferPower113_g37 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g37 = ( Wind_Global450_g37 * Wind_Tree_Mask114_g37 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float temp_output_227_0_g37 = ( ( ase_positionWS.y * ( _WindLeafScale * 30.0 ) ) + _TimeParameters.x );
				float Global_Wind_Tree_Leaf_Speed495_g37 = ASPW_WindTreeLeafSpeed;
				float temp_output_223_0_g37 = ( _WindLeafSpeed * Global_Wind_Tree_Leaf_Speed495_g37 * 4.0 );
				float Global_Wind_Tree_Leaf_Amplitude497_g37 = ASPW_WindTreeLeafAmplitude;
				float temp_output_242_0_g37 = ( ( sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 0.5 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.25 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.5 ) ) ) ) * ( ( _WindLeafAmplitude * Global_Wind_Tree_Leaf_Amplitude497_g37 ) * 0.1 ) );
				float temp_output_243_0_g37 = ( temp_output_242_0_g37 * 0.2 );
				float3 appendResult244_g37 = (float3(temp_output_243_0_g37 , temp_output_242_0_g37 , temp_output_243_0_g37));
				float3 Wind_Leaf245_g37 = appendResult244_g37;
				float3 break416_g37 = normalizeResult268_g37;
				float3 appendResult417_g37 = (float3(( break416_g37.x * -1.0 ) , ( break416_g37.z * -1.0 ) , 0.0));
				float3 Wind_Direction_Turbulence419_g37 = appendResult417_g37;
				float2 appendResult322_g37 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Tree_Leaf_Turbulence502_g37 = ASPW_WindTreeLeafTurbulence;
				float Wind_Leaf_Turbulence334_g37 = saturate( ( tex2Dlod( ASP_GlobalTintNoiseTexture, float4( ( ( ( Wind_Direction_Turbulence419_g37 * _TimeParameters.x ) * 0.1 ) + float3( ( appendResult322_g37 * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).g + ( ( Global_Wind_Tree_Leaf_Turbulence502_g37 * _WindLeafTurbulence ) * 0.1 ) ) );
				float Wind_Mask_VColor_Blue429_g37 = input.ase_color.b;
				float3 Wind_Leaf_Mask285_g37 = ( ( ( Wind_Leaf245_g37 * Wind_Direction_Leaf85_g37 ) * Wind_Leaf_Turbulence334_g37 ) * Wind_Mask_VColor_Blue429_g37 );
				float Global_Wind_Tree_Leaf_Offset500_g37 = ASPW_WindTreeLeafOffset;
				float Wind_Mask_VColor_Green430_g37 = input.ase_color.g;
				float2 texCoord312_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float3 Wind_Leaf_Offset314_g37 = ( ( ( ( Wind_Direction_Leaf85_g37 * ( _WindLeafOffset * Global_Wind_Tree_Leaf_Offset500_g37 * 0.5 ) ) + Wind_Leaf_Mask285_g37 ) * Wind_Mask_VColor_Green430_g37 ) * texCoord312_g37.y );
				float Global_Wind_Toggle504_g37 = ASPW_WindToggle;
				float3 lerpResult125_g37 = lerp( float3( 0,0,0 ) , ( temp_output_385_0_g37 + ( Wind_Leaf_Mask285_g37 + Wind_Leaf_Offset314_g37 ) ) , Global_Wind_Toggle504_g37);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch469_g37 = lerpResult125_g37;
				#else
				float3 staticSwitch469_g37 = temp_cast_0;
				#endif
				
				float3 ase_tangentWS = TransformObjectToWorldDir( input.ase_tangent.xyz );
				output.ase_texcoord3.xyz = ase_tangentWS;
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord4.xyz = ase_normalWS;
				float ase_tangentSign = input.ase_tangent.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord5.xyz = ase_bitangentWS;
				
				output.ase_texcoord2.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				output.ase_texcoord2.zw = input.ase_texcoord2.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord3.w = 0;
				output.ase_texcoord4.w = 0;
				output.ase_texcoord5.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch469_g37;

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
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;

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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_color = input.ase_color;
				output.ase_texcoord = input.ase_texcoord;
				output.ase_tangent = input.ase_tangent;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				output.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
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

				float2 uv_BaseAlbedo1753 = input.ase_texcoord2.xy;
				float4 tex2DNode1753 = tex2D( _BaseAlbedo, uv_BaseAlbedo1753 );
				float3 desaturateInitialColor1712 = tex2DNode1753.rgb;
				float desaturateDot1712 = dot( desaturateInitialColor1712, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar1712 = lerp( desaturateInitialColor1712, desaturateDot1712.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc3324 = ( desaturateVar1712 * _BaseAlbedoBrightness );
				float3 blendOpDest3324 = _BaseAlbedoColor;
				float3 lerpResult1716 = lerp( _BaseAlbedoColor , ( saturate( (( blendOpDest3324 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest3324 ) * ( 1.0 - blendOpSrc3324 ) ) : ( 2.0 * blendOpDest3324 * blendOpSrc3324 ) ) )) , _BaseLerpBetweenColorandTexture);
				float lerpResult1727 = lerp( 1.0 , input.ase_color.a , saturate( ( _BaseTreeAOIntensity * ASP_GlobalTreeAO ) ));
				float Base_AO1735 = lerpResult1727;
				float3 Base_Albedo1723 = ( lerpResult1716 * Base_AO1735 );
				float3 blendOpSrc1836 = Base_Albedo1723;
				float3 blendOpDest1836 = _GradientColor;
				float3 temp_output_1836_0 = ( saturate( (( blendOpDest1836 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest1836 ) * ( 1.0 - blendOpSrc1836 ) ) : ( 2.0 * blendOpDest1836 * blendOpSrc1836 ) ) ));
				float2 texCoord1840 = input.ase_texcoord2.zw * float2( 1,1 ) + float2( 0,0 );
				float saferPower1879 = abs( ( ( 1.0 - texCoord1840.y ) * _GradientColorOffset ) );
				float temp_output_1848_0 = saturate( pow( saferPower1879 , _GradientColorContrast ) );
				float lerpResult1877 = lerp( temp_output_1848_0 , ( 1.0 - temp_output_1848_0 ) , _GradientColorInvertMask);
				float Gradient_Color_Mask1854 = ( lerpResult1877 * _GradientColorIntensity );
				float3 lerpResult1838 = lerp( Base_Albedo1723 , temp_output_1836_0 , Gradient_Color_Mask1854);
				float3 Gradient_Color_Albedo1856 = lerpResult1838;
				#ifdef _ENABLEGRADIENTCOLOR_ON
				float3 staticSwitch1867 = Gradient_Color_Albedo1856;
				#else
				float3 staticSwitch1867 = Base_Albedo1723;
				#endif
				float3 Step_2_Albedo1914 = staticSwitch1867;
				float3 blendOpSrc1897 = Base_Albedo1723;
				float3 blendOpDest1897 = _SecondColor;
				float3 temp_output_1897_0 = ( saturate( (( blendOpDest1897 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest1897 ) * ( 1.0 - blendOpSrc1897 ) ) : ( 2.0 * blendOpDest1897 * blendOpSrc1897 ) ) ));
				float saferPower1886 = abs( ( ( 1.0 - input.ase_color.a ) * _SecondColorOffset ) );
				float temp_output_1889_0 = saturate( pow( saferPower1886 , ( _SecondColorContrast + 2.0 ) ) );
				float lerpResult1890 = lerp( temp_output_1889_0 , ( 1.0 - temp_output_1889_0 ) , _SecondColorInvertMask);
				float Second_Color_Mask1895 = ( lerpResult1890 * _SecondColorIntensity );
				float3 lerpResult1899 = lerp( Step_2_Albedo1914 , temp_output_1897_0 , Second_Color_Mask1895);
				float3 Second_Color_Albedo1902 = lerpResult1899;
				#ifdef _ENABLESECONDCOLOR_ON
				float3 staticSwitch1921 = Second_Color_Albedo1902;
				#else
				float3 staticSwitch1921 = Step_2_Albedo1914;
				#endif
				float3 Step_3_Albedo1954 = staticSwitch1921;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Tint_Color_Mask1949 = saturate( round( ( frac( ( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) * ( _TintNoiseOffset * ASP_GlobalTintNoiseUVScale ) ) ) * ( _TintNoiseContrast * ASP_GlobalTintNoiseContrast ) ) ) );
				float3 lerpResult1951 = lerp( _TintColor1.rgb , _TintColor2.rgb , Tint_Color_Mask1949);
				float3 blendOpSrc1952 = Step_3_Albedo1954;
				float3 blendOpDest1952 = lerpResult1951;
				float3 temp_output_1952_0 = ( saturate( (( blendOpDest1952 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest1952 ) * ( 1.0 - blendOpSrc1952 ) ) : ( 2.0 * blendOpDest1952 * blendOpSrc1952 ) ) ));
				float temp_output_1961_0 = ( _TintNoiseIntensity * ASP_GlobalTintNoiseIntensity );
				float3 lerpResult1956 = lerp( Step_3_Albedo1954 , temp_output_1952_0 , temp_output_1961_0);
				float3 Tint_Color_Albedo1963 = lerpResult1956;
				#ifdef _ENABLETINTCOLOR_ON
				float3 staticSwitch2080 = Tint_Color_Albedo1963;
				#else
				float3 staticSwitch2080 = Step_3_Albedo1954;
				#endif
				float3 Step_4_Albedo2083 = staticSwitch2080;
				float3 Top_Layer_Color1995 = _TopLayerColor;
				float2 uv_BaseNormal1741 = input.ase_texcoord2.xy;
				float3 unpack1741 = UnpackNormalScale( tex2D( _BaseNormal, uv_BaseNormal1741 ), _BaseNormalIntensity );
				unpack1741.z = lerp( 1, unpack1741.z, saturate(_BaseNormalIntensity) );
				float3 tex2DNode1741 = unpack1741;
				float3 break105_g45 = tex2DNode1741;
				float switchResult107_g45 = (((ase_vface>0)?(break105_g45.z):(-break105_g45.z)));
				float3 appendResult108_g45 = (float3(break105_g45.x , break105_g45.y , switchResult107_g45));
				#ifdef _ENABLEFLIPNORMALS_ON
				float3 staticSwitch1744 = appendResult108_g45;
				#else
				float3 staticSwitch1744 = tex2DNode1741;
				#endif
				float3 Base_Normal1747 = staticSwitch1744;
				float3 desaturateInitialColor2013 = Base_Normal1747;
				float desaturateDot2013 = dot( desaturateInitialColor2013, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar2013 = lerp( desaturateInitialColor2013, desaturateDot2013.xxx, 1.0 );
				float3 ase_tangentWS = input.ase_texcoord3.xyz;
				float3 ase_normalWS = input.ase_texcoord4.xyz;
				float3 ase_bitangentWS = input.ase_texcoord5.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal2012 = Base_Normal1747;
				float3 worldNormal2012 = float3( dot( tanToWorld0, tanNormal2012 ), dot( tanToWorld1, tanNormal2012 ), dot( tanToWorld2, tanNormal2012 ) );
				float3 temp_cast_0 = (worldNormal2012.y).xxx;
				#ifdef _ENABLEWORLDPROJECTION_ON
				float3 staticSwitch2017 = temp_cast_0;
				#else
				float3 staticSwitch2017 = desaturateVar2013;
				#endif
				float3 saferPower17_g32 = abs( abs( ( saturate( staticSwitch2017 ) + ( _TopLayerOffset * ASPT_TopLayerOffset ) ) ) );
				float temp_output_2005_0 = ( _TopLayerContrast * ASPT_TopLayerContrast );
				float3 temp_cast_1 = (temp_output_2005_0).xxx;
				float saferPower2024 = abs( ( 1.0 - input.ase_color.a ) );
				float Top_Layer_Contrast2025 = temp_output_2005_0;
				float3 lerpResult2029 = lerp( ( ( saturate( pow( saferPower17_g32 , temp_cast_1 ) ) * ( _TopLayerIntensity * ASPT_TopLayerIntensity ) ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) ) , float3( 0,0,0 ) , saturate( ( pow( saferPower2024 , Top_Layer_Contrast2025 ) * _TopLayerAOMask ) ));
				float3 Top_Layer_Mask2031 = saturate( lerpResult2029 );
				float3 lerpResult2034 = lerp( Step_4_Albedo2083 , Top_Layer_Color1995 , Top_Layer_Mask2031);
				float3 lerpResult2037 = lerp( Step_4_Albedo2083 , lerpResult2034 , saturate( ( ase_vface > 0 ? +1 : -1 ) ));
				#ifdef _ENABLEBACKFACEPROJECTION_ON
				float3 staticSwitch2041 = lerpResult2034;
				#else
				float3 staticSwitch2041 = lerpResult2037;
				#endif
				float3 Top_Layer_Albedo2042 = staticSwitch2041;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch2043 = Top_Layer_Albedo2042;
				#else
				float3 staticSwitch2043 = Step_4_Albedo2083;
				#endif
				float3 Output_Albedo1873 = staticSwitch2043;
				
				float Opacity_Texture1737 = tex2DNode1753.a;
				float3 normalizeResult1780 = normalize( cross( ddx( WorldPosition ) , ddy( WorldPosition ) ) );
				float3 normalizeResult1787 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float dotResult1782 = dot( normalizeResult1780 , normalizeResult1787 );
				float lerpResult1794 = lerp( 1.0 , abs( dotResult1782 ) , _BaseGlancingAngleCut);
				#ifdef _ENABLEGLANCINGANGLECUT_ON
				float staticSwitch1788 = lerpResult1794;
				#else
				float staticSwitch1788 = 1.0;
				#endif
				float Base_Glancing_Angle1790 = staticSwitch1788;
				float Base_Opacity1739 = ( Opacity_Texture1737 * Base_Glancing_Angle1790 );
				

				float3 BaseColor = Output_Albedo1873;
				float Alpha = Base_Opacity1739;
				float AlphaClipThreshold = _CutOff;

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

			

			

			#pragma multi_compile _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile_ _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define _EMISSION
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
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLEFLIPNORMALS_ON
			#pragma shader_feature_local _ENABLEGLANCINGANGLECUT_ON


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
				float4 ase_texcoord2 : TEXCOORD2;
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
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseEmissiveColor;
			float4 _TintColor2;
			float4 _TintColor1;
			float3 _TopLayerSSSColor;
			float3 _SecondColor;
			float3 _TopLayerColor;
			float3 _GradientColor;
			half3 _BaseAlbedoColor;
			float3 _BaseSSSColor;
			float _TintNoiseOffset;
			float _TintNoiseContrast;
			float _TintNoiseIntensity;
			float _BaseNormalIntensity;
			half _TopLayerOffset;
			half _TopLayerContrast;
			half _TopLayerAOMask;
			float _BaseSSSAOInfluence;
			float _BaseEmissiveMaskContrast;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveAOMask;
			float _BaseSmoothnessMin;
			float _BaseSmoothnessMax;
			float _TopLayerSmoothnessIntensity;
			float _BaseGlancingAngleCut;
			float _CutOff;
			half _TopLayerIntensity;
			float _BaseSSSIntensity;
			float _SecondColorInvertMask;
			float _TopLayerSSSIntensity;
			float _BaseSSSAmbiet;
			float _BaseSSSShadow;
			float _BaseSSSNormalDistortion;
			float _BaseSSSScattering;
			float _WindTreeFlexibility;
			float _WindTreeBaseRigidity;
			float _WindLeafScale;
			float _WindLeafSpeed;
			float _WindLeafAmplitude;
			float _WindLeafTurbulence;
			float _WindLeafOffset;
			float _BaseAlbedoDesaturation;
			float _BaseAlbedoBrightness;
			float _BaseLerpBetweenColorandTexture;
			float _BaseTreeAOIntensity;
			float _GradientColorOffset;
			float _GradientColorContrast;
			float _GradientColorInvertMask;
			float _GradientColorIntensity;
			float _SecondColorOffset;
			float _SecondColorContrast;
			float _SecondColorIntensity;
			float _BaseSSSDirect;
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

			sampler2D ASP_GlobalTintNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindTreeSpeed;
			half ASPW_WindTreeAmplitude;
			half ASPW_WindTreeFlexibility;
			half ASPW_WindTreeLeafSpeed;
			half ASPW_WindTreeLeafAmplitude;
			half ASPW_WindTreeLeafTurbulence;
			half ASPW_WindTreeLeafOffset;
			float ASPW_WindToggle;
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
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction493_g37 = ASPW_WindDirection;
				float3 worldToObjDir269_g37 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g37, 0.0 ) ).xyz;
				float3 normalizeResult268_g37 = ASESafeNormalize( worldToObjDir269_g37 );
				float3 Wind_Direction_Leaf85_g37 = normalizeResult268_g37;
				float3 break86_g37 = Wind_Direction_Leaf85_g37;
				float3 appendResult89_g37 = (float3(break86_g37.z , 0.0 , ( break86_g37.x * -1.0 )));
				float3 Wind_Direction91_g37 = appendResult89_g37;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g37 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g37 = ( Wind_Tree_Randomization149_g37 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g37 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g37 = ( Global_Wind_Tree_Speed491_g37 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g37 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g37 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g37 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g37 ) * 0.3 );
				float Wind_Tree_257_g37 = ( ( ( ( ( sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.1 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.3 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g37 ) * Global_Wind_Tree_Amplitude464_g37 ) * 0.01 ) * temp_output_383_0_g37 );
				float3 rotatedValue99_g37 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g37, Wind_Tree_257_g37 );
				float3 Rotate_About_Axis354_g37 = ( rotatedValue99_g37 - input.positionOS.xyz );
				float3 break452_g37 = normalizeResult268_g37;
				float3 appendResult454_g37 = (float3(break452_g37.x , 0.0 , break452_g37.z));
				float3 Wind_Direction_SM_Support453_g37 = appendResult454_g37;
				float Wind_Tree_Flexibility483_g37 = temp_output_383_0_g37;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g37 = ( Global_Wind_Tree_Amplitude464_g37 * Wind_Tree_257_g37 * Wind_Direction_SM_Support453_g37 * Wind_Tree_Flexibility483_g37 );
				#else
				float3 staticSwitch482_g37 = Rotate_About_Axis354_g37;
				#endif
				float3 Wind_Global450_g37 = staticSwitch482_g37;
				float2 texCoord433_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g37 = texCoord433_g37.y;
				float saferPower113_g37 = abs( Wind_Mask_UV_CH2_VChannel434_g37 );
				float Wind_Tree_Mask114_g37 = pow( saferPower113_g37 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g37 = ( Wind_Global450_g37 * Wind_Tree_Mask114_g37 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float temp_output_227_0_g37 = ( ( ase_positionWS.y * ( _WindLeafScale * 30.0 ) ) + _TimeParameters.x );
				float Global_Wind_Tree_Leaf_Speed495_g37 = ASPW_WindTreeLeafSpeed;
				float temp_output_223_0_g37 = ( _WindLeafSpeed * Global_Wind_Tree_Leaf_Speed495_g37 * 4.0 );
				float Global_Wind_Tree_Leaf_Amplitude497_g37 = ASPW_WindTreeLeafAmplitude;
				float temp_output_242_0_g37 = ( ( sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 0.5 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.25 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.5 ) ) ) ) * ( ( _WindLeafAmplitude * Global_Wind_Tree_Leaf_Amplitude497_g37 ) * 0.1 ) );
				float temp_output_243_0_g37 = ( temp_output_242_0_g37 * 0.2 );
				float3 appendResult244_g37 = (float3(temp_output_243_0_g37 , temp_output_242_0_g37 , temp_output_243_0_g37));
				float3 Wind_Leaf245_g37 = appendResult244_g37;
				float3 break416_g37 = normalizeResult268_g37;
				float3 appendResult417_g37 = (float3(( break416_g37.x * -1.0 ) , ( break416_g37.z * -1.0 ) , 0.0));
				float3 Wind_Direction_Turbulence419_g37 = appendResult417_g37;
				float2 appendResult322_g37 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Tree_Leaf_Turbulence502_g37 = ASPW_WindTreeLeafTurbulence;
				float Wind_Leaf_Turbulence334_g37 = saturate( ( tex2Dlod( ASP_GlobalTintNoiseTexture, float4( ( ( ( Wind_Direction_Turbulence419_g37 * _TimeParameters.x ) * 0.1 ) + float3( ( appendResult322_g37 * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).g + ( ( Global_Wind_Tree_Leaf_Turbulence502_g37 * _WindLeafTurbulence ) * 0.1 ) ) );
				float Wind_Mask_VColor_Blue429_g37 = input.ase_color.b;
				float3 Wind_Leaf_Mask285_g37 = ( ( ( Wind_Leaf245_g37 * Wind_Direction_Leaf85_g37 ) * Wind_Leaf_Turbulence334_g37 ) * Wind_Mask_VColor_Blue429_g37 );
				float Global_Wind_Tree_Leaf_Offset500_g37 = ASPW_WindTreeLeafOffset;
				float Wind_Mask_VColor_Green430_g37 = input.ase_color.g;
				float2 texCoord312_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float3 Wind_Leaf_Offset314_g37 = ( ( ( ( Wind_Direction_Leaf85_g37 * ( _WindLeafOffset * Global_Wind_Tree_Leaf_Offset500_g37 * 0.5 ) ) + Wind_Leaf_Mask285_g37 ) * Wind_Mask_VColor_Green430_g37 ) * texCoord312_g37.y );
				float Global_Wind_Toggle504_g37 = ASPW_WindToggle;
				float3 lerpResult125_g37 = lerp( float3( 0,0,0 ) , ( temp_output_385_0_g37 + ( Wind_Leaf_Mask285_g37 + Wind_Leaf_Offset314_g37 ) ) , Global_Wind_Toggle504_g37);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch469_g37 = lerpResult125_g37;
				#else
				float3 staticSwitch469_g37 = temp_cast_0;
				#endif
				
				output.ase_texcoord5.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord5.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch469_g37;

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
				float4 ase_texcoord2 : TEXCOORD2;
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
						, bool ase_vface : SV_IsFrontFace )
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

				float2 uv_BaseNormal1741 = input.ase_texcoord5.xy;
				float3 unpack1741 = UnpackNormalScale( tex2D( _BaseNormal, uv_BaseNormal1741 ), _BaseNormalIntensity );
				unpack1741.z = lerp( 1, unpack1741.z, saturate(_BaseNormalIntensity) );
				float3 tex2DNode1741 = unpack1741;
				float3 break105_g45 = tex2DNode1741;
				float switchResult107_g45 = (((ase_vface>0)?(break105_g45.z):(-break105_g45.z)));
				float3 appendResult108_g45 = (float3(break105_g45.x , break105_g45.y , switchResult107_g45));
				#ifdef _ENABLEFLIPNORMALS_ON
				float3 staticSwitch1744 = appendResult108_g45;
				#else
				float3 staticSwitch1744 = tex2DNode1741;
				#endif
				float3 Base_Normal1747 = staticSwitch1744;
				
				float2 uv_BaseAlbedo1753 = input.ase_texcoord5.xy;
				float4 tex2DNode1753 = tex2D( _BaseAlbedo, uv_BaseAlbedo1753 );
				float Opacity_Texture1737 = tex2DNode1753.a;
				float3 normalizeResult1780 = normalize( cross( ddx( WorldPosition ) , ddy( WorldPosition ) ) );
				float3 normalizeResult1787 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float dotResult1782 = dot( normalizeResult1780 , normalizeResult1787 );
				float lerpResult1794 = lerp( 1.0 , abs( dotResult1782 ) , _BaseGlancingAngleCut);
				#ifdef _ENABLEGLANCINGANGLECUT_ON
				float staticSwitch1788 = lerpResult1794;
				#else
				float staticSwitch1788 = 1.0;
				#endif
				float Base_Glancing_Angle1790 = staticSwitch1788;
				float Base_Opacity1739 = ( Opacity_Texture1737 * Base_Glancing_Angle1790 );
				

				float3 Normal = Base_Normal1747;
				float Alpha = Base_Opacity1739;
				float AlphaClipThreshold = _CutOff;

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
			
			Name "SceneSelectionPass"
			Tags { "LightMode"="SceneSelectionPass" }

			Cull Off
			AlphaToMask Off

			HLSLPROGRAM

			

			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#define ASE_TRANSLUCENCY 1
			#define _EMISSION
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
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLEGLANCINGANGLECUT_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseEmissiveColor;
			float4 _TintColor2;
			float4 _TintColor1;
			float3 _TopLayerSSSColor;
			float3 _SecondColor;
			float3 _TopLayerColor;
			float3 _GradientColor;
			half3 _BaseAlbedoColor;
			float3 _BaseSSSColor;
			float _TintNoiseOffset;
			float _TintNoiseContrast;
			float _TintNoiseIntensity;
			float _BaseNormalIntensity;
			half _TopLayerOffset;
			half _TopLayerContrast;
			half _TopLayerAOMask;
			float _BaseSSSAOInfluence;
			float _BaseEmissiveMaskContrast;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveAOMask;
			float _BaseSmoothnessMin;
			float _BaseSmoothnessMax;
			float _TopLayerSmoothnessIntensity;
			float _BaseGlancingAngleCut;
			float _CutOff;
			half _TopLayerIntensity;
			float _BaseSSSIntensity;
			float _SecondColorInvertMask;
			float _TopLayerSSSIntensity;
			float _BaseSSSAmbiet;
			float _BaseSSSShadow;
			float _BaseSSSNormalDistortion;
			float _BaseSSSScattering;
			float _WindTreeFlexibility;
			float _WindTreeBaseRigidity;
			float _WindLeafScale;
			float _WindLeafSpeed;
			float _WindLeafAmplitude;
			float _WindLeafTurbulence;
			float _WindLeafOffset;
			float _BaseAlbedoDesaturation;
			float _BaseAlbedoBrightness;
			float _BaseLerpBetweenColorandTexture;
			float _BaseTreeAOIntensity;
			float _GradientColorOffset;
			float _GradientColorContrast;
			float _GradientColorInvertMask;
			float _GradientColorIntensity;
			float _SecondColorOffset;
			float _SecondColorContrast;
			float _SecondColorIntensity;
			float _BaseSSSDirect;
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

			sampler2D ASP_GlobalTintNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindTreeSpeed;
			half ASPW_WindTreeAmplitude;
			half ASPW_WindTreeFlexibility;
			half ASPW_WindTreeLeafSpeed;
			half ASPW_WindTreeLeafAmplitude;
			half ASPW_WindTreeLeafTurbulence;
			half ASPW_WindTreeLeafOffset;
			float ASPW_WindToggle;
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
				float3 Global_Wind_Direction493_g37 = ASPW_WindDirection;
				float3 worldToObjDir269_g37 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g37, 0.0 ) ).xyz;
				float3 normalizeResult268_g37 = ASESafeNormalize( worldToObjDir269_g37 );
				float3 Wind_Direction_Leaf85_g37 = normalizeResult268_g37;
				float3 break86_g37 = Wind_Direction_Leaf85_g37;
				float3 appendResult89_g37 = (float3(break86_g37.z , 0.0 , ( break86_g37.x * -1.0 )));
				float3 Wind_Direction91_g37 = appendResult89_g37;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g37 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g37 = ( Wind_Tree_Randomization149_g37 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g37 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g37 = ( Global_Wind_Tree_Speed491_g37 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g37 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g37 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g37 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g37 ) * 0.3 );
				float Wind_Tree_257_g37 = ( ( ( ( ( sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.1 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.3 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g37 ) * Global_Wind_Tree_Amplitude464_g37 ) * 0.01 ) * temp_output_383_0_g37 );
				float3 rotatedValue99_g37 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g37, Wind_Tree_257_g37 );
				float3 Rotate_About_Axis354_g37 = ( rotatedValue99_g37 - input.positionOS.xyz );
				float3 break452_g37 = normalizeResult268_g37;
				float3 appendResult454_g37 = (float3(break452_g37.x , 0.0 , break452_g37.z));
				float3 Wind_Direction_SM_Support453_g37 = appendResult454_g37;
				float Wind_Tree_Flexibility483_g37 = temp_output_383_0_g37;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g37 = ( Global_Wind_Tree_Amplitude464_g37 * Wind_Tree_257_g37 * Wind_Direction_SM_Support453_g37 * Wind_Tree_Flexibility483_g37 );
				#else
				float3 staticSwitch482_g37 = Rotate_About_Axis354_g37;
				#endif
				float3 Wind_Global450_g37 = staticSwitch482_g37;
				float2 texCoord433_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g37 = texCoord433_g37.y;
				float saferPower113_g37 = abs( Wind_Mask_UV_CH2_VChannel434_g37 );
				float Wind_Tree_Mask114_g37 = pow( saferPower113_g37 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g37 = ( Wind_Global450_g37 * Wind_Tree_Mask114_g37 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float temp_output_227_0_g37 = ( ( ase_positionWS.y * ( _WindLeafScale * 30.0 ) ) + _TimeParameters.x );
				float Global_Wind_Tree_Leaf_Speed495_g37 = ASPW_WindTreeLeafSpeed;
				float temp_output_223_0_g37 = ( _WindLeafSpeed * Global_Wind_Tree_Leaf_Speed495_g37 * 4.0 );
				float Global_Wind_Tree_Leaf_Amplitude497_g37 = ASPW_WindTreeLeafAmplitude;
				float temp_output_242_0_g37 = ( ( sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 0.5 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.25 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.5 ) ) ) ) * ( ( _WindLeafAmplitude * Global_Wind_Tree_Leaf_Amplitude497_g37 ) * 0.1 ) );
				float temp_output_243_0_g37 = ( temp_output_242_0_g37 * 0.2 );
				float3 appendResult244_g37 = (float3(temp_output_243_0_g37 , temp_output_242_0_g37 , temp_output_243_0_g37));
				float3 Wind_Leaf245_g37 = appendResult244_g37;
				float3 break416_g37 = normalizeResult268_g37;
				float3 appendResult417_g37 = (float3(( break416_g37.x * -1.0 ) , ( break416_g37.z * -1.0 ) , 0.0));
				float3 Wind_Direction_Turbulence419_g37 = appendResult417_g37;
				float2 appendResult322_g37 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Tree_Leaf_Turbulence502_g37 = ASPW_WindTreeLeafTurbulence;
				float Wind_Leaf_Turbulence334_g37 = saturate( ( tex2Dlod( ASP_GlobalTintNoiseTexture, float4( ( ( ( Wind_Direction_Turbulence419_g37 * _TimeParameters.x ) * 0.1 ) + float3( ( appendResult322_g37 * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).g + ( ( Global_Wind_Tree_Leaf_Turbulence502_g37 * _WindLeafTurbulence ) * 0.1 ) ) );
				float Wind_Mask_VColor_Blue429_g37 = input.ase_color.b;
				float3 Wind_Leaf_Mask285_g37 = ( ( ( Wind_Leaf245_g37 * Wind_Direction_Leaf85_g37 ) * Wind_Leaf_Turbulence334_g37 ) * Wind_Mask_VColor_Blue429_g37 );
				float Global_Wind_Tree_Leaf_Offset500_g37 = ASPW_WindTreeLeafOffset;
				float Wind_Mask_VColor_Green430_g37 = input.ase_color.g;
				float2 texCoord312_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float3 Wind_Leaf_Offset314_g37 = ( ( ( ( Wind_Direction_Leaf85_g37 * ( _WindLeafOffset * Global_Wind_Tree_Leaf_Offset500_g37 * 0.5 ) ) + Wind_Leaf_Mask285_g37 ) * Wind_Mask_VColor_Green430_g37 ) * texCoord312_g37.y );
				float Global_Wind_Toggle504_g37 = ASPW_WindToggle;
				float3 lerpResult125_g37 = lerp( float3( 0,0,0 ) , ( temp_output_385_0_g37 + ( Wind_Leaf_Mask285_g37 + Wind_Leaf_Offset314_g37 ) ) , Global_Wind_Toggle504_g37);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch469_g37 = lerpResult125_g37;
				#else
				float3 staticSwitch469_g37 = temp_cast_0;
				#endif
				
				output.ase_texcoord1.xyz = ase_positionWS;
				
				output.ase_texcoord.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord.zw = 0;
				output.ase_texcoord1.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch469_g37;

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
				float4 ase_texcoord2 : TEXCOORD2;
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
				output.ase_texcoord2 = input.ase_texcoord2;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
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

				float2 uv_BaseAlbedo1753 = input.ase_texcoord.xy;
				float4 tex2DNode1753 = tex2D( _BaseAlbedo, uv_BaseAlbedo1753 );
				float Opacity_Texture1737 = tex2DNode1753.a;
				float3 ase_positionWS = input.ase_texcoord1.xyz;
				float3 normalizeResult1780 = normalize( cross( ddx( ase_positionWS ) , ddy( ase_positionWS ) ) );
				float3 normalizeResult1787 = normalize( ( _WorldSpaceCameraPos - ase_positionWS ) );
				float dotResult1782 = dot( normalizeResult1780 , normalizeResult1787 );
				float lerpResult1794 = lerp( 1.0 , abs( dotResult1782 ) , _BaseGlancingAngleCut);
				#ifdef _ENABLEGLANCINGANGLECUT_ON
				float staticSwitch1788 = lerpResult1794;
				#else
				float staticSwitch1788 = 1.0;
				#endif
				float Base_Glancing_Angle1790 = staticSwitch1788;
				float Base_Opacity1739 = ( Opacity_Texture1737 * Base_Glancing_Angle1790 );
				

				surfaceDescription.Alpha = Base_Opacity1739;
				surfaceDescription.AlphaClipThreshold = _CutOff;

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
			#define ASE_TRANSLUCENCY 1
			#define _EMISSION
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
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLEGLANCINGANGLECUT_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _BaseEmissiveColor;
			float4 _TintColor2;
			float4 _TintColor1;
			float3 _TopLayerSSSColor;
			float3 _SecondColor;
			float3 _TopLayerColor;
			float3 _GradientColor;
			half3 _BaseAlbedoColor;
			float3 _BaseSSSColor;
			float _TintNoiseOffset;
			float _TintNoiseContrast;
			float _TintNoiseIntensity;
			float _BaseNormalIntensity;
			half _TopLayerOffset;
			half _TopLayerContrast;
			half _TopLayerAOMask;
			float _BaseSSSAOInfluence;
			float _BaseEmissiveMaskContrast;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveAOMask;
			float _BaseSmoothnessMin;
			float _BaseSmoothnessMax;
			float _TopLayerSmoothnessIntensity;
			float _BaseGlancingAngleCut;
			float _CutOff;
			half _TopLayerIntensity;
			float _BaseSSSIntensity;
			float _SecondColorInvertMask;
			float _TopLayerSSSIntensity;
			float _BaseSSSAmbiet;
			float _BaseSSSShadow;
			float _BaseSSSNormalDistortion;
			float _BaseSSSScattering;
			float _WindTreeFlexibility;
			float _WindTreeBaseRigidity;
			float _WindLeafScale;
			float _WindLeafSpeed;
			float _WindLeafAmplitude;
			float _WindLeafTurbulence;
			float _WindLeafOffset;
			float _BaseAlbedoDesaturation;
			float _BaseAlbedoBrightness;
			float _BaseLerpBetweenColorandTexture;
			float _BaseTreeAOIntensity;
			float _GradientColorOffset;
			float _GradientColorContrast;
			float _GradientColorInvertMask;
			float _GradientColorIntensity;
			float _SecondColorOffset;
			float _SecondColorContrast;
			float _SecondColorIntensity;
			float _BaseSSSDirect;
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

			sampler2D ASP_GlobalTintNoiseTexture;
			half3 ASPW_WindDirection;
			half ASPW_WindTreeSpeed;
			half ASPW_WindTreeAmplitude;
			half ASPW_WindTreeFlexibility;
			half ASPW_WindTreeLeafSpeed;
			half ASPW_WindTreeLeafAmplitude;
			half ASPW_WindTreeLeafTurbulence;
			half ASPW_WindTreeLeafOffset;
			float ASPW_WindToggle;
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
				float3 Global_Wind_Direction493_g37 = ASPW_WindDirection;
				float3 worldToObjDir269_g37 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g37, 0.0 ) ).xyz;
				float3 normalizeResult268_g37 = ASESafeNormalize( worldToObjDir269_g37 );
				float3 Wind_Direction_Leaf85_g37 = normalizeResult268_g37;
				float3 break86_g37 = Wind_Direction_Leaf85_g37;
				float3 appendResult89_g37 = (float3(break86_g37.z , 0.0 , ( break86_g37.x * -1.0 )));
				float3 Wind_Direction91_g37 = appendResult89_g37;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g37 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g37 = ( Wind_Tree_Randomization149_g37 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g37 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g37 = ( Global_Wind_Tree_Speed491_g37 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g37 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g37 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g37 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g37 ) * 0.3 );
				float Wind_Tree_257_g37 = ( ( ( ( ( sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.1 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.3 ) ) ) + sin( ( temp_output_56_0_g37 * ( temp_output_213_0_g37 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g37 ) * Global_Wind_Tree_Amplitude464_g37 ) * 0.01 ) * temp_output_383_0_g37 );
				float3 rotatedValue99_g37 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g37, Wind_Tree_257_g37 );
				float3 Rotate_About_Axis354_g37 = ( rotatedValue99_g37 - input.positionOS.xyz );
				float3 break452_g37 = normalizeResult268_g37;
				float3 appendResult454_g37 = (float3(break452_g37.x , 0.0 , break452_g37.z));
				float3 Wind_Direction_SM_Support453_g37 = appendResult454_g37;
				float Wind_Tree_Flexibility483_g37 = temp_output_383_0_g37;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g37 = ( Global_Wind_Tree_Amplitude464_g37 * Wind_Tree_257_g37 * Wind_Direction_SM_Support453_g37 * Wind_Tree_Flexibility483_g37 );
				#else
				float3 staticSwitch482_g37 = Rotate_About_Axis354_g37;
				#endif
				float3 Wind_Global450_g37 = staticSwitch482_g37;
				float2 texCoord433_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g37 = texCoord433_g37.y;
				float saferPower113_g37 = abs( Wind_Mask_UV_CH2_VChannel434_g37 );
				float Wind_Tree_Mask114_g37 = pow( saferPower113_g37 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g37 = ( Wind_Global450_g37 * Wind_Tree_Mask114_g37 );
				float3 ase_positionWS = TransformObjectToWorld( ( input.positionOS ).xyz );
				float temp_output_227_0_g37 = ( ( ase_positionWS.y * ( _WindLeafScale * 30.0 ) ) + _TimeParameters.x );
				float Global_Wind_Tree_Leaf_Speed495_g37 = ASPW_WindTreeLeafSpeed;
				float temp_output_223_0_g37 = ( _WindLeafSpeed * Global_Wind_Tree_Leaf_Speed495_g37 * 4.0 );
				float Global_Wind_Tree_Leaf_Amplitude497_g37 = ASPW_WindTreeLeafAmplitude;
				float temp_output_242_0_g37 = ( ( sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 0.5 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.25 ) ) ) + sin( ( temp_output_227_0_g37 * ( temp_output_223_0_g37 * 1.5 ) ) ) ) * ( ( _WindLeafAmplitude * Global_Wind_Tree_Leaf_Amplitude497_g37 ) * 0.1 ) );
				float temp_output_243_0_g37 = ( temp_output_242_0_g37 * 0.2 );
				float3 appendResult244_g37 = (float3(temp_output_243_0_g37 , temp_output_242_0_g37 , temp_output_243_0_g37));
				float3 Wind_Leaf245_g37 = appendResult244_g37;
				float3 break416_g37 = normalizeResult268_g37;
				float3 appendResult417_g37 = (float3(( break416_g37.x * -1.0 ) , ( break416_g37.z * -1.0 ) , 0.0));
				float3 Wind_Direction_Turbulence419_g37 = appendResult417_g37;
				float2 appendResult322_g37 = (float2(ase_positionWS.x , ase_positionWS.z));
				float Global_Wind_Tree_Leaf_Turbulence502_g37 = ASPW_WindTreeLeafTurbulence;
				float Wind_Leaf_Turbulence334_g37 = saturate( ( tex2Dlod( ASP_GlobalTintNoiseTexture, float4( ( ( ( Wind_Direction_Turbulence419_g37 * _TimeParameters.x ) * 0.1 ) + float3( ( appendResult322_g37 * 0.1 ) ,  0.0 ) ).xy, 0, 0.0) ).g + ( ( Global_Wind_Tree_Leaf_Turbulence502_g37 * _WindLeafTurbulence ) * 0.1 ) ) );
				float Wind_Mask_VColor_Blue429_g37 = input.ase_color.b;
				float3 Wind_Leaf_Mask285_g37 = ( ( ( Wind_Leaf245_g37 * Wind_Direction_Leaf85_g37 ) * Wind_Leaf_Turbulence334_g37 ) * Wind_Mask_VColor_Blue429_g37 );
				float Global_Wind_Tree_Leaf_Offset500_g37 = ASPW_WindTreeLeafOffset;
				float Wind_Mask_VColor_Green430_g37 = input.ase_color.g;
				float2 texCoord312_g37 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float3 Wind_Leaf_Offset314_g37 = ( ( ( ( Wind_Direction_Leaf85_g37 * ( _WindLeafOffset * Global_Wind_Tree_Leaf_Offset500_g37 * 0.5 ) ) + Wind_Leaf_Mask285_g37 ) * Wind_Mask_VColor_Green430_g37 ) * texCoord312_g37.y );
				float Global_Wind_Toggle504_g37 = ASPW_WindToggle;
				float3 lerpResult125_g37 = lerp( float3( 0,0,0 ) , ( temp_output_385_0_g37 + ( Wind_Leaf_Mask285_g37 + Wind_Leaf_Offset314_g37 ) ) , Global_Wind_Toggle504_g37);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch469_g37 = lerpResult125_g37;
				#else
				float3 staticSwitch469_g37 = temp_cast_0;
				#endif
				
				output.ase_texcoord1.xyz = ase_positionWS;
				
				output.ase_texcoord.xy = input.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord.zw = 0;
				output.ase_texcoord1.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch469_g37;

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
				float4 ase_texcoord2 : TEXCOORD2;
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
				output.ase_texcoord2 = input.ase_texcoord2;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
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

				float2 uv_BaseAlbedo1753 = input.ase_texcoord.xy;
				float4 tex2DNode1753 = tex2D( _BaseAlbedo, uv_BaseAlbedo1753 );
				float Opacity_Texture1737 = tex2DNode1753.a;
				float3 ase_positionWS = input.ase_texcoord1.xyz;
				float3 normalizeResult1780 = normalize( cross( ddx( ase_positionWS ) , ddy( ase_positionWS ) ) );
				float3 normalizeResult1787 = normalize( ( _WorldSpaceCameraPos - ase_positionWS ) );
				float dotResult1782 = dot( normalizeResult1780 , normalizeResult1787 );
				float lerpResult1794 = lerp( 1.0 , abs( dotResult1782 ) , _BaseGlancingAngleCut);
				#ifdef _ENABLEGLANCINGANGLECUT_ON
				float staticSwitch1788 = lerpResult1794;
				#else
				float staticSwitch1788 = 1.0;
				#endif
				float Base_Glancing_Angle1790 = staticSwitch1788;
				float Base_Opacity1739 = ( Opacity_Texture1737 * Base_Glancing_Angle1790 );
				

				surfaceDescription.Alpha = Base_Opacity1739;
				surfaceDescription.AlphaClipThreshold = _CutOff;

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
Node;AmplifyShaderEditor.CommentaryNode;1832;-2747,4560;Inherit;False;2747;687;;16;1790;1788;1789;1794;1793;1783;1782;1787;1780;1785;1779;1784;1786;1778;1777;1776;Base Glancing Angle Cut;1,1,1,1;0;0
Node;AmplifyShaderEditor.WorldPosInputsNode;1776;-2688,4608;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DdxOpNode;1777;-2432,4608;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DdyOpNode;1778;-2432,4688;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WorldPosInputsNode;1786;-2688,5024;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldSpaceCameraPos;1784;-2688,4864;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleSubtractOpNode;1785;-2304,4864;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CrossProductOpNode;1779;-2304,4608;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.NormalizeNode;1780;-2048,4608;Inherit;False;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.NormalizeNode;1787;-2048,4864;Inherit;False;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DotProductOpNode;1782;-1792,4608;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1793;-1536,4736;Inherit;False;Property;_BaseGlancingAngleCut;Base Glancing Angle Cut;2;0;Create;True;0;0;0;False;0;False;0.8;0.8;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.AbsOpNode;1783;-1536,4608;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;1823;-2751,-2098;Inherit;False;2236;689;;13;1723;3617;3618;3324;1722;1717;1714;1721;1716;1713;1712;1737;1753;Base Albedo;1,1,1,1;0;0
Node;AmplifyShaderEditor.LerpOp;1794;-1152,4608;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1789;-1152,4736;Inherit;False;Constant;_One;One;20;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1753;-2688,-2048;Inherit;True;Property;_BaseAlbedo;Base Albedo;12;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;5a350584f9ab3f847a1d216801dbcaa4;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.StaticSwitch;1788;-784,4608;Inherit;False;Property;_EnableGlancingAngleCut;Enable Glancing Angle Cut;1;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;1834;-2750,4032;Inherit;False;818;323;;4;1739;1740;1791;1738;Base Opacity;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1737;-2304,-1920;Inherit;False;Opacity Texture;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1790;-272,4608;Inherit;False;Base Glancing Angle;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1738;-2688,4096;Inherit;False;1737;Opacity Texture;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1791;-2688,4224;Inherit;False;1790;Base Glancing Angle;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1740;-2432,4096;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;3283;18752,-2096;Inherit;False;1018.207;978.311;;8;1746;2792;1875;1813;1814;1774;1751;1876;Outputs;1,0,0,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;3540;-2751,718;Inherit;False;701;593;;7;3325;3262;3263;3261;3260;3538;1754;Base SSS Parameters;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;3537;-2749,2512;Inherit;False;1873;400;;9;3461;3460;3454;3455;3453;3452;3451;3450;3449;Base SSS Max Distance;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;3347;10693,208;Inherit;False;828;306;;4;3341;3342;3340;3339;Top Layer Emissive;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;1881;700,-2098;Inherit;False;2627;1330;;28;1860;1861;1862;1854;1864;1856;1837;1835;1853;1880;1846;1843;1839;1855;1859;1863;1858;1857;1838;1836;1852;1877;1851;1848;1879;1841;1842;1840;Gradient Color;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;1831;-2752,1472;Inherit;False;1597;831;;13;1726;1729;3287;1727;1731;1728;1725;1730;3288;1733;1732;1734;1735;Base AO/SSS Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;1925;3780,-2098;Inherit;False;2494;1456;;27;1896;1910;1902;1894;1892;1885;1884;1916;1917;1908;1909;1904;1903;1899;1901;1897;1895;1958;1893;1890;1891;1889;1886;1888;1887;1883;1882;Second Color;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;1993;6975,-2098;Inherit;False;2365.561;1843.417;;32;1953;1968;1963;1943;1932;1931;1942;1962;1960;1930;1929;1967;1949;3281;3282;1944;1933;3280;3279;3273;3275;3274;3272;1966;1965;1964;1956;1961;1959;1952;1951;1950;Tint Color;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;2092;14400,-2096;Inherit;False;3649.281;1072.076;;36;3346;2077;3345;3344;3343;2076;2075;2074;1954;1918;2043;2080;1869;1921;1867;1955;1874;2045;2062;2084;2081;1972;1922;1919;1915;1872;1873;2044;2083;1970;1914;1865;1866;1870;1871;1868;Switches;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;1828;-2752,-1202;Inherit;False;1853.396;306.4712;;5;1741;1744;1742;1747;3615;Base Normal;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;2088;10692,704;Inherit;False;3259;1028;;26;3349;2021;2003;1996;1999;2001;2000;1998;1997;2005;2009;2031;2030;2029;2028;2027;2024;2026;2023;2022;2017;2013;2012;2018;2025;3638;Top Layer Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;2091;10689,-2112;Inherit;False;2235;574;;10;2036;3312;2041;2042;2037;2039;2034;2035;2038;1995;Top Layer Albedo;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;1829;-2751,-688;Inherit;False;1218;650;[R] Smoothness | [G] Subsurface | [B] Emissive;10;1760;3651;3650;3649;3648;3647;1762;1761;3646;1757;Base SSE;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;1833;-2751,3136;Inherit;False;2227;573;;12;1811;1807;1805;1801;1812;1808;1810;1809;1806;1802;1804;1803;Base Emissive;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;1830;-2753,80;Inherit;False;2371;431;;14;3539;3536;1768;1767;3458;3350;1764;1766;1765;1755;1763;1769;1756;2050;Base SSS;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;2090;10690,-1344;Inherit;False;2235;573;;14;3309;2061;2060;2059;2058;2054;2056;2057;2052;2055;2047;2048;2051;2046;Top Layer SSS;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;2089;10690,-576;Inherit;False;2362.389;511.3842;;11;2064;2066;2063;2070;2069;2068;2067;2065;3308;2073;2072;Top Layer Smoothness;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1739;-2176,4096;Inherit;False;Base Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;1840;768,-1152;Inherit;False;2;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;1842;1024,-1152;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1841;1280,-1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;1879;1664,-1152;Inherit;False;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;1848;1920,-1152;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;1851;2176,-1024;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1877;2432,-1152;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;1882;3840,-1152;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1852;2816,-1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;1883;4096,-1152;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1887;4352,-1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1888;4352,-768;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;1886;4608,-1152;Inherit;False;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1838;1920,-2048;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1893;5760,-1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1901;4608,-1792;Inherit;False;1895;Second Color Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1899;4864,-2048;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1950;7040,-1536;Inherit;False;1949;Tint Color Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1951;7424,-2048;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1959;8192,-1792;Inherit;False;1954;Step 3 Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1961;8576,-1664;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1956;8704,-2048;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1858;1536,-1664;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1863;1536,-1408;Inherit;False;1854;Gradient Color Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1859;1920,-1664;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1903;3840,-1664;Inherit;False;1769;Base SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1904;4608,-1664;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1909;4608,-1408;Inherit;False;1895;Second Color Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1908;5120,-1664;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1964;8176,-1248;Inherit;False;1955;Step 3 SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1965;8192,-1408;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;1966;8704,-1408;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3272;7424,-896;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;1.23;False;1;FLOAT;0
Node;AmplifyShaderEditor.ObjectPositionNode;3274;7040,-896;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;3275;7296,-896;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FractNode;3273;7936,-896;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3279;7680,-896;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3280;8192,-896;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1933;7424,-640;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1944;8064,-640;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RoundOpNode;3282;8448,-896;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;3281;8704,-896;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1949;9088,-896;Inherit;False;Tint Color Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1855;1536,-1792;Inherit;False;1854;Gradient Color Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1839;1536,-1920;Inherit;False;1723;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1917;4608,-1920;Inherit;False;1914;Step 2 Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1916;4608,-1536;Inherit;False;1915;Step 2 SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1967;7808,-1280;Inherit;False;1769;Base SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1995;11136,-2048;Inherit;False;Top Layer Color;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TwoSidedSign;2038;11392,-1664;Inherit;False;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;2035;11392,-1920;Inherit;False;2083;Step 4 Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;2034;11776,-2048;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;2039;11648,-1664;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;2037;12032,-1920;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1735;-1536,1664;Inherit;False;Base AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;2072;12032,-512;Inherit;False;Property;_Keyword5;Keyword 4;55;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;2041;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1713;-2688,-1792;Inherit;False;Property;_BaseAlbedoDesaturation;Base Albedo Desaturation;6;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1843;768,-1024;Inherit;False;Property;_GradientColorOffset;Gradient Color Offset;30;0;Create;True;0;0;0;False;0;False;1;1.72;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1846;1280,-1024;Inherit;False;Property;_GradientColorContrast;Gradient Color Contrast;31;0;Create;True;0;0;0;False;0;False;1;1;0;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1880;2065.281,-879.9517;Inherit;False;Property;_GradientColorInvertMask;Gradient Color Invert Mask;32;1;[IntRange];Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1853;2432,-1024;Inherit;False;Property;_GradientColorIntensity;Gradient Color Intensity;29;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1884;3840,-896;Inherit;False;Property;_SecondColorOffset;Second Color Offset;36;0;Create;True;0;0;0;False;0;False;1;1;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1885;3840,-768;Inherit;False;Property;_SecondColorContrast;Second Color Contrast;37;0;Create;True;0;0;0;False;0;False;1;7.06;0;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;1929;7040,-2048;Inherit;False;Property;_TintColor1;Tint Color 1;40;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0;0.8679245,0.5694438,0.4134924,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.ColorNode;1930;7040,-1792;Inherit;False;Property;_TintColor2;Tint Color 2;41;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0;0.5019608,0.5019608,0.5019608,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;1960;8192,-1664;Inherit;False;Property;_TintNoiseIntensity;Tint Noise Intensity;42;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1962;8192,-1536;Half;False;Global;ASP_GlobalTintNoiseIntensity;ASP_GlobalTintNoiseIntensity;15;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1942;7680,-640;Inherit;False;Property;_TintNoiseContrast;Tint Noise Contrast;44;0;Create;True;0;0;0;False;0;False;1;1;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1931;7040,-640;Inherit;False;Property;_TintNoiseOffset;Tint Noise Offset;43;0;Create;True;0;0;0;False;0;False;1;1;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1932;7040,-512;Half;False;Global;ASP_GlobalTintNoiseUVScale;ASP_GlobalTintNoiseUVScale;15;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1943;7680,-512;Half;False;Global;ASP_GlobalTintNoiseContrast;ASP_GlobalTintNoiseContrast;15;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1963;9088,-2048;Inherit;False;Tint Color Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1968;9088,-1408;Inherit;False;Tint Color SSS;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1902;5376,-2048;Inherit;False;Second Color Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1910;5376,-1664;Inherit;False;Second Color SSS;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;2042;12672,-2048;Inherit;False;Top Layer Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;2073;12672,-512;Inherit;False;Top Layer Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1747;-1152,-1152;Inherit;False;Base Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;2046;10752,-1280;Inherit;False;1995;Top Layer Color;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;2051;10752,-1024;Inherit;False;2050;Global SSS Intensity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2047;11136,-1280;Inherit;False;3;3;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;2055;11392,-1072;Inherit;False;2031;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2052;11392,-1280;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TwoSidedSign;2057;11392,-896;Inherit;False;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;2056;11392,-1152;Inherit;False;2084;Step 4 SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;2054;11776,-1280;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;2058;11648,-896;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;2059;12032,-1152;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;2060;12288,-1280;Inherit;False;Property;_Keyword4;Keyword 4;55;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;2041;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;2061;12672,-1280;Inherit;False;Top Layer SSS;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;2041;12288,-2048;Inherit;False;Property;_EnableBackfaceProjection;Enable Backface Projection;55;0;Create;True;0;0;0;False;0;False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1868;14464,-2048;Inherit;False;1723;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1866;14464,-1600;Inherit;False;1864;Gradient Color SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1865;14464,-1920;Inherit;False;1856;Gradient Color Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1914;15360,-2048;Inherit;False;Step 2 Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1970;16128,-1920;Inherit;False;1963;Tint Color Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;2083;16896,-2048;Inherit;False;Step 4 Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;2044;16896,-1920;Inherit;False;2042;Top Layer Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1873;17792,-2048;Inherit;False;Output Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1872;14720,-1792;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1915;15360,-1792;Inherit;False;Step 2 SSS;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1919;15360,-1696;Inherit;False;1910;Second Color SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;1922;15744,-1792;Inherit;False;Property;_Keyword1;Keyword 1;33;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;1921;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1972;16128,-1664;Inherit;False;1968;Tint Color SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;2081;16512,-1792;Inherit;False;Property;_Keyword2;Keyword 2;39;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;2080;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;2084;16896,-1792;Inherit;False;Step 4 SSS;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;2062;16896,-1664;Inherit;False;2061;Top Layer SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;2045;17280,-1792;Inherit;False;Property;_Keyword3;Keyword 3;45;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;2043;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1874;17792,-1792;Inherit;False;Output SSS;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1955;16128,-1792;Inherit;False;Step 3 SSS;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;1867;14976,-2048;Inherit;False;Property;_EnableGradientColor;Enable Gradient Color;27;0;Create;True;0;0;0;False;1;Header(Base Gradient Color);False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;1921;15744,-2048;Inherit;False;Property;_EnableSecondColor;Enable Second Color;33;0;Create;True;0;0;0;False;1;Header(Base Second Color);False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;1869;14976,-1792;Inherit;False;Property;_Keyword0;Keyword 0;27;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;1867;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;2080;16512,-2048;Inherit;False;Property;_EnableTintColor;Enable Tint Color;39;0;Create;True;0;0;0;False;1;Header(Base Tint Color);False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;2043;17280,-2048;Inherit;False;Property;_EnableTopLayerBlend;Enable Top Layer Blend;45;0;Create;True;0;0;0;False;1;Header(Top Layer);False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1918;15360,-1920;Inherit;False;1902;Second Color Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;3308;12416,-512;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TwoSidedSign;2067;11136,-256;Inherit;False;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;2068;11392,-256;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;2069;11648,-384;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;3309;11136,-1152;Inherit;False;Property;_TopLayerSSSColor;Top Layer SSS Color;47;1;[HDR];Create;True;0;0;0;False;0;False;0.7843137,0.9215686,1,1;0.3915094,1,0.8225385,1;True;False;0;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.ColorNode;3312;10752,-2048;Inherit;False;Property;_TopLayerColor;Top Layer Color;46;1;[HDR];Create;True;0;0;0;False;0;False;0.7764706,0.8392157,0.9490196,0;0.25,0.5227272,1,1;True;False;0;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;2070;11136,-384;Inherit;False;1760;Base Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1856;2304,-2048;Inherit;False;Gradient Color Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1864;2304,-1664;Inherit;False;Gradient Color SSS;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1854;3072,-1152;Inherit;False;Gradient Color Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1862;1536,-1536;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1861;1280,-1440;Inherit;False;1769;Base SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1734;-1536,1536;Inherit;False;Base SSS AO Influence;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1860;1280,-1536;Inherit;False;1723;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;2050;-2304,384;Inherit;False;Global SSS Intensity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1716;-1280,-2048;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1954;16128,-2048;Inherit;False;Step 3 Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1721;-2048,-2048;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;1714;-1920,-1792;Half;False;Property;_BaseAlbedoColor;Base Albedo Color;4;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0.5019608;0.2933233,0.3396226,0.07529369,1;False;False;0;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;1717;-1920,-1632;Inherit;False;Property;_BaseLerpBetweenColorandTexture;Base Lerp Between Color and Texture;11;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1732;-2688,1920;Half;False;Global;ASP_GlobalTreeAO;ASP_GlobalTreeAO;15;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1733;-2304,1792;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;3288;-2048,1792;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1730;-2688,1664;Half;False;Global;ASP_GlobalTreeSSSAOInfluence;ASP_GlobalTreeSSSAOInfluence;13;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;1725;-2048,1920;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;1756;-2688,256;Half;False;Global;ASP_GlobalTreeSSSIntensity;ASP_GlobalTreeSSSIntensity;14;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1769;-768,128;Inherit;False;Base SSS;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;1742;-2688,-1152;Inherit;False;Property;_BaseNormalIntensity;Base Normal Intensity;7;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1728;-2688,1536;Inherit;False;Property;_BaseSSSAOInfluence;Base SSS AO Influence;17;0;Create;True;0;0;0;False;0;False;0.8;0.95;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1731;-2688,1792;Inherit;False;Property;_BaseTreeAOIntensity;Base Tree AO Intensity;10;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;1744;-1536,-1152;Inherit;False;Property;_EnableFlipNormals;Enable Flip Normals;0;0;Create;True;0;0;0;False;1;Header(Base);False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;2036;11392,-1792;Inherit;False;2031;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;2063;10752,-512;Inherit;False;1760;Base Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;2066;10752,-256;Inherit;False;2031;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;2064;11136,-512;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;2074;17280,-1536;Inherit;False;Property;_Keyword6;Keyword 3;45;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;2043;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;2075;16896,-1536;Inherit;False;1760;Base Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;2076;16896,-1408;Inherit;False;2073;Top Layer Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;3343;17280,-1280;Inherit;False;Property;_Keyword7;Keyword 3;45;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;2043;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;3344;16896,-1280;Inherit;False;1812;Base Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;3345;16896,-1152;Inherit;False;3342;Top Layer Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;2077;17792,-1536;Inherit;False;Output Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;3346;17792,-1280;Inherit;False;Output Emissive;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;2025;11776,1536;Inherit;False;Top Layer Contrast;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;2018;10752,768;Inherit;False;1747;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WorldNormalVector;2012;11136,896;Inherit;False;False;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DesaturateOpNode;2013;11136,768;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;2017;11520,768;Float;False;Property;_EnableWorldProjection;Enable World Projection;54;0;Create;True;0;0;0;False;0;False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;2029;13184,768;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;2030;13440,768;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;2031;13696,768;Inherit;False;Top Layer Mask;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;2009;11136,1632;Half;False;Global;ASPT_TopLayerContrast;ASPT_TopLayerContrast;32;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2005;11520,1536;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1997;11136,1440;Half;False;Global;ASPT_TopLayerOffset;ASPT_TopLayerOffset;27;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1998;11136,1248;Half;False;Global;ASPT_TopLayerIntensity;ASPT_TopLayerIntensity;27;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2000;11520,1344;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2001;11520,1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1999;11136,1152;Half;False;Property;_TopLayerIntensity;Top Layer Intensity;50;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1996;11136,1344;Half;False;Property;_TopLayerOffset;Top Layer Offset;51;0;Create;True;0;0;0;False;0;False;0.5;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;2003;11136,1536;Half;False;Property;_TopLayerContrast;Top Layer Contrast;52;0;Create;True;0;0;0;False;0;False;10;30;0;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;3339;10752,256;Inherit;False;1812;Base Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;3340;10752,384;Inherit;False;2031;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;3342;11264,256;Inherit;False;Top Layer Emissive;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;1741;-2304,-1152;Inherit;True;Property;_BaseNormal;Base Normal;13;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.FunctionNode;3349;11904,768;Inherit;False;MF_ASP_Global_TopLayer;-1;;32;6dc1725aa9649cc439f99987e8365ea2;0;4;22;FLOAT3;0,0,0;False;24;FLOAT;1;False;23;FLOAT;0.5;False;25;FLOAT;10;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;3341;11008,256;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1876;18816,-1376;Inherit;False;1874;Output SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1763;-2048,128;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1755;-2304,128;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1765;-1664,128;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1766;-2048,256;Inherit;False;1734;Base SSS AO Influence;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1757;-2688,-640;Inherit;True;Property;_BaseSSE;Base SSE;14;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.LerpOp;1727;-1792,1664;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;3287;-2048,1536;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1729;-2304,1536;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1726;-1792,1536;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3458;-1408,128;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1767;-1152,128;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;3536;-1664,256;Inherit;False;3461;Base SSS Max Distance;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1803;-2688,3456;Inherit;False;1762;RSE Emissive Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;1804;-2304,3456;Inherit;False;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1802;-2048,3200;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1806;-1792,3200;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1810;-1408,3456;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;1808;-1152,3200;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1812;-768,3200;Inherit;False;Base Emissive;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;1801;-2688,3200;Inherit;False;Property;_BaseEmissiveColor;Base Emissive Color;23;1;[HDR];Create;True;0;0;0;False;1;Header(Base Emissive);False;0,0,0,0;0,0,0,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;1805;-2688,3584;Inherit;False;Property;_BaseEmissiveMaskContrast;Base Emissive Mask Contrast;25;0;Create;True;0;0;0;False;0;False;1;1;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1807;-2048,3456;Inherit;False;Property;_BaseEmissiveIntensity;Base Emissive Intensity;24;0;Create;True;0;0;0;False;0;False;1;1;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1811;-1408,3584;Inherit;False;Property;_BaseEmissiveAOMask;Base Emissive AO Mask;26;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceCameraPos;3449;-2688,2720;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldPosInputsNode;3450;-2688,2560;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DistanceOpNode;3451;-2304,2560;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3452;-2304,2688;Half;False;Constant;_MinDistance;Min Distance;27;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;3453;-1920,2560;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;3455;-1664,2560;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3454;-2304,2784;Half;False;Global;ASP_GlobalTreeSSSDistance;ASP_GlobalTreeSSSDistance;24;0;Create;True;0;0;0;False;0;False;200;5000;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;3460;-1408,2560;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;3461;-1152,2560;Inherit;False;Base SSS Max Distance;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;3539;-2688,128;Inherit;False;3538;Local SSS Intensity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;3538;-2304,768;Inherit;False;Local SSS Intensity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3261;-2688,1024;Inherit;False;Property;_BaseSSSDirect;Base SSS Direct;20;0;Create;True;0;0;0;True;0;False;0.9;0.9;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3262;-2688,1104;Inherit;False;Property;_BaseSSSAmbiet;Base SSS Ambiet;21;0;Create;True;0;0;0;True;0;False;0.1;0.1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1751;18816,-1952;Inherit;False;1747;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1774;18816,-1664;Inherit;False;1735;Base AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1814;18816,-1760;Inherit;False;2077;Output Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1813;18816,-1856;Inherit;False;3346;Output Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1746;18816,-1568;Inherit;False;1739;Base Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;1809;-1664,3456;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;2023;12160,1152;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;2021;12416,1280;Half;False;Property;_TopLayerAOMask;Top Layer AO Mask;53;0;Create;True;0;0;0;False;0;False;1;3.75;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3263;-2688,1184;Inherit;False;Property;_BaseSSSShadow;Base SSS Shadow;22;0;Create;True;0;0;0;True;0;False;0.9;0.9;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;2792;18816,-1472;Inherit;False;Property;_CutOff;Base Opacity Cutoff;3;0;Create;False;0;0;0;False;0;False;0.3;0.3;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3325;-2688,864;Inherit;False;Property;_BaseSSSNormalDistortion;Base SSS Normal Distortion;18;0;Create;True;0;0;0;True;0;False;0.5;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1764;-2304,256;Inherit;False;1761;RSE Subsurface Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1857;768,-1664;Inherit;False;1769;Base SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1870;14464,-1792;Inherit;False;1723;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1871;14464,-1696;Inherit;False;1769;Base SSS;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;3350;-2688,384;Inherit;False;Constant;_Float4;Float 4;56;0;Create;True;0;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1754;-2688,768;Inherit;False;Property;_BaseSSSIntensity;Base SSS Intensity;16;0;Create;True;0;0;0;True;0;False;1;9.5;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1895;6016,-1152;Inherit;False;Second Color Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1892;4992,-896;Inherit;False;Property;_SecondColorInvertMask;Second Color Invert Mask;38;1;[IntRange];Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1890;5376,-1152;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;1891;5120,-1024;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;1889;4864,-1152;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1894;5376,-896;Inherit;False;Property;_SecondColorIntensity;Second Color Intensity;35;0;Create;True;0;0;0;False;0;False;1;0.7;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1953;7424,-1792;Inherit;False;1954;Step 3 Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1837;768,-2048;Inherit;False;1723;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;1835;768,-1920;Inherit;False;Property;_GradientColor;Gradient Color;28;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0;0.9716981,0,0,0;True;False;0;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.ColorNode;1896;3840,-1920;Inherit;False;Property;_SecondColor;Second Color;34;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0;0.2074582,0.3961525,0.6981132,1;True;False;0;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;1958;3840,-2048;Inherit;False;1723;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3618;-1024,-2048;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;3617;-1280,-1920;Inherit;False;1735;Base AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1723;-768,-2048;Inherit;False;Base Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;1768;-1408,256;Inherit;False;Property;_BaseSSSColor;Base SSS Color;15;1;[HDR];Create;True;0;0;0;False;1;Header(Base SSS);False;1,1,1,0;1,0.6039734,0,0;True;False;0;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;3260;-2688,944;Inherit;False;Property;_BaseSSSScattering;Base SSS Scattering;19;0;Create;True;0;0;0;True;0;False;2;10;1;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.BlendOpsNode;1952;7808,-2048;Inherit;False;Overlay;True;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BlendOpsNode;1897;4224,-2048;Inherit;False;Overlay;True;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BlendOpsNode;1836;1152,-2048;Inherit;False;Overlay;True;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1875;18816,-2048;Inherit;False;1873;Output Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.FunctionNode;3637;18816,-1280;Inherit;False;MF_ASP_Global_WindTrees;56;;37;587b51c6cec05a64bb99d28802483760;0;0;2;FLOAT3;49;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3638;12416,768;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.PowerNode;2024;12416,1152;Inherit;False;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2027;12784,1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;2028;12928,1152;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;2026;12160,1280;Inherit;False;2025;Top Layer Contrast;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;2022;11904,1152;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;3645;11904,1024;Inherit;False;MF_ASP_Global_TopLayerHeight;-1;;44;0851e7dd80a2406479a4b23dfe36fe1f;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DesaturateOpNode;1712;-2304,-2048;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BlendOpsNode;3324;-1664,-2048;Inherit;False;Overlay;True;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;1722;-2304,-1792;Inherit;False;Property;_BaseAlbedoBrightness;Base Albedo Brightness;5;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;3615;-1920,-1024;Inherit;False;MF_ASP_FlipNormals;-1;;45;7bd57a034e214964eb311c43f973a80e;0;1;110;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;3646;-2304,-640;Inherit;False;Texture Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1761;-2304,-544;Inherit;False;RSE Subsurface Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1762;-2304,-448;Inherit;False;RSE Emissive Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3647;-2688,-320;Inherit;False;Property;_BaseSmoothnessMin;Base Smoothness Min;8;0;Create;True;0;0;0;False;0;False;0;0.5;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3648;-2688,-224;Inherit;False;Property;_BaseSmoothnessMax;Base Smoothness Max;9;0;Create;True;0;0;0;False;0;False;1;0.5;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;3649;-2304,-320;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;3650;-2048,-320;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;3651;-2688,-128;Inherit;False;3646;Texture Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1760;-1776,-320;Inherit;False;Base Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;2065;10752,-384;Inherit;False;Property;_TopLayerSmoothnessIntensity;Top Layer Smoothness Intensity;49;0;Create;True;0;0;0;False;0;False;0;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;2048;10752,-1152;Inherit;False;Property;_TopLayerSSSIntensity;Top Layer SSS Intensity;48;0;Create;True;0;0;0;False;0;False;0.5;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3712;19456,-2048;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;8cbf178bc0e2fcc40b198d79862c4ead;True;ExtraPrePass;0;0;ExtraPrePass;5;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3713;19456,-2048;Float;False;True;-1;3;;0;16;ANGRYMESH/Stylized Pack/Tree Leaf;8cbf178bc0e2fcc40b198d79862c4ead;True;Forward;0;1;Forward;21;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalForwardOnly;False;False;0;;0;0;Standard;42;Lighting Model;0;0;Workflow;1;0;Surface;0;0;  Refraction Model;0;0;  Blend;0;0;Two Sided;0;638786663094041061;Alpha Clipping;1;0;  Use Shadow Threshold;0;0;Fragment Normal Space,InvertActionOnDeselection;0;0;Forward Only;1;0;Transmission;0;0;  Transmission Shadow;0.5,False,;0;Translucency;1;638786663113430732;  Translucency Strength;1,True,_BaseSSSIntensity;638786663207142307;  Normal Distortion;0.5,True,_BaseSSSNormalDistortion;638786663218866155;  Scattering;2,True,_BaseSSSScattering;638786663223766916;  Direct;0.9,True,_BaseSSSDirect;638786663231609517;  Ambient;0.1,True,_BaseSSSAmbiet;638786663235562101;  Shadow;0.5,True,_BaseSSSShadow;638786663239033254;Cast Shadows;1;0;Receive Shadows;1;0;Receive SSAO;1;0;GPU Instancing;1;0;LOD CrossFade;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Write Depth;0;0;  Early Z;0;0;Vertex Position,InvertActionOnDeselection;1;0;Debug Display;0;0;Clear Coat;0;0;0;10;False;True;True;True;True;True;True;False;True;True;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3714;19456,-2048;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;8cbf178bc0e2fcc40b198d79862c4ead;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3715;19456,-2048;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;8cbf178bc0e2fcc40b198d79862c4ead;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;True;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3716;19456,-2048;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;8cbf178bc0e2fcc40b198d79862c4ead;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3717;19456,-2048;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;8cbf178bc0e2fcc40b198d79862c4ead;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3718;19456,-2048;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;8cbf178bc0e2fcc40b198d79862c4ead;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormalsOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3719;19456,-2048;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;8cbf178bc0e2fcc40b198d79862c4ead;True;GBuffer;0;7;GBuffer;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalGBuffer;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3720;19456,-2048;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;8cbf178bc0e2fcc40b198d79862c4ead;True;SceneSelectionPass;0;8;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3721;19456,-2048;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;8cbf178bc0e2fcc40b198d79862c4ead;True;ScenePickingPass;0;9;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
WireConnection;1777;0;1776;0
WireConnection;1778;0;1776;0
WireConnection;1785;0;1784;0
WireConnection;1785;1;1786;0
WireConnection;1779;0;1777;0
WireConnection;1779;1;1778;0
WireConnection;1780;0;1779;0
WireConnection;1787;0;1785;0
WireConnection;1782;0;1780;0
WireConnection;1782;1;1787;0
WireConnection;1783;0;1782;0
WireConnection;1794;1;1783;0
WireConnection;1794;2;1793;0
WireConnection;1788;1;1789;0
WireConnection;1788;0;1794;0
WireConnection;1737;0;1753;4
WireConnection;1790;0;1788;0
WireConnection;1740;0;1738;0
WireConnection;1740;1;1791;0
WireConnection;1739;0;1740;0
WireConnection;1842;0;1840;2
WireConnection;1841;0;1842;0
WireConnection;1841;1;1843;0
WireConnection;1879;0;1841;0
WireConnection;1879;1;1846;0
WireConnection;1848;0;1879;0
WireConnection;1851;0;1848;0
WireConnection;1877;0;1848;0
WireConnection;1877;1;1851;0
WireConnection;1877;2;1880;0
WireConnection;1852;0;1877;0
WireConnection;1852;1;1853;0
WireConnection;1883;0;1882;4
WireConnection;1887;0;1883;0
WireConnection;1887;1;1884;0
WireConnection;1888;0;1885;0
WireConnection;1886;0;1887;0
WireConnection;1886;1;1888;0
WireConnection;1838;0;1839;0
WireConnection;1838;1;1836;0
WireConnection;1838;2;1855;0
WireConnection;1893;0;1890;0
WireConnection;1893;1;1894;0
WireConnection;1899;0;1917;0
WireConnection;1899;1;1897;0
WireConnection;1899;2;1901;0
WireConnection;1951;0;1929;5
WireConnection;1951;1;1930;5
WireConnection;1951;2;1950;0
WireConnection;1961;0;1960;0
WireConnection;1961;1;1962;0
WireConnection;1956;0;1959;0
WireConnection;1956;1;1952;0
WireConnection;1956;2;1961;0
WireConnection;1858;0;1836;0
WireConnection;1858;1;1857;0
WireConnection;1859;0;1862;0
WireConnection;1859;1;1858;0
WireConnection;1859;2;1863;0
WireConnection;1904;0;1897;0
WireConnection;1904;1;1903;0
WireConnection;1908;0;1916;0
WireConnection;1908;1;1904;0
WireConnection;1908;2;1909;0
WireConnection;1965;0;1952;0
WireConnection;1965;1;1967;0
WireConnection;1966;0;1964;0
WireConnection;1966;1;1965;0
WireConnection;1966;2;1961;0
WireConnection;3272;0;3275;0
WireConnection;3275;0;3274;1
WireConnection;3275;1;3274;2
WireConnection;3275;2;3274;3
WireConnection;3273;0;3279;0
WireConnection;3279;0;3272;0
WireConnection;3279;1;1933;0
WireConnection;3280;0;3273;0
WireConnection;3280;1;1944;0
WireConnection;1933;0;1931;0
WireConnection;1933;1;1932;0
WireConnection;1944;0;1942;0
WireConnection;1944;1;1943;0
WireConnection;3282;0;3280;0
WireConnection;3281;0;3282;0
WireConnection;1949;0;3281;0
WireConnection;1995;0;3312;0
WireConnection;2034;0;2035;0
WireConnection;2034;1;1995;0
WireConnection;2034;2;2036;0
WireConnection;2039;0;2038;0
WireConnection;2037;0;2035;0
WireConnection;2037;1;2034;0
WireConnection;2037;2;2039;0
WireConnection;1735;0;1727;0
WireConnection;2072;1;2069;0
WireConnection;2072;0;2064;0
WireConnection;1963;0;1956;0
WireConnection;1968;0;1966;0
WireConnection;1902;0;1899;0
WireConnection;1910;0;1908;0
WireConnection;2042;0;2041;0
WireConnection;2073;0;3308;0
WireConnection;1747;0;1744;0
WireConnection;2047;0;2046;0
WireConnection;2047;1;2048;0
WireConnection;2047;2;2051;0
WireConnection;2052;0;2047;0
WireConnection;2052;1;3309;0
WireConnection;2054;0;2056;0
WireConnection;2054;1;2052;0
WireConnection;2054;2;2055;0
WireConnection;2058;0;2057;0
WireConnection;2059;0;2056;0
WireConnection;2059;1;2054;0
WireConnection;2059;2;2058;0
WireConnection;2060;1;2059;0
WireConnection;2060;0;2054;0
WireConnection;2061;0;2060;0
WireConnection;2041;1;2037;0
WireConnection;2041;0;2034;0
WireConnection;1914;0;1867;0
WireConnection;2083;0;2080;0
WireConnection;1873;0;2043;0
WireConnection;1872;0;1870;0
WireConnection;1872;1;1871;0
WireConnection;1915;0;1869;0
WireConnection;1922;1;1915;0
WireConnection;1922;0;1919;0
WireConnection;2081;1;1955;0
WireConnection;2081;0;1972;0
WireConnection;2084;0;2081;0
WireConnection;2045;1;2084;0
WireConnection;2045;0;2062;0
WireConnection;1874;0;2045;0
WireConnection;1955;0;1922;0
WireConnection;1867;1;1868;0
WireConnection;1867;0;1865;0
WireConnection;1921;1;1914;0
WireConnection;1921;0;1918;0
WireConnection;1869;1;1872;0
WireConnection;1869;0;1866;0
WireConnection;2080;1;1954;0
WireConnection;2080;0;1970;0
WireConnection;2043;1;2083;0
WireConnection;2043;0;2044;0
WireConnection;3308;0;2072;0
WireConnection;2068;0;2067;0
WireConnection;2069;0;2070;0
WireConnection;2069;1;2064;0
WireConnection;2069;2;2068;0
WireConnection;1856;0;1838;0
WireConnection;1864;0;1859;0
WireConnection;1854;0;1852;0
WireConnection;1862;0;1860;0
WireConnection;1862;1;1861;0
WireConnection;1734;0;1726;0
WireConnection;2050;0;1756;0
WireConnection;1716;0;1714;0
WireConnection;1716;1;3324;0
WireConnection;1716;2;1717;0
WireConnection;1954;0;1921;0
WireConnection;1721;0;1712;0
WireConnection;1721;1;1722;0
WireConnection;1733;0;1731;0
WireConnection;1733;1;1732;0
WireConnection;3288;0;1733;0
WireConnection;1769;0;1767;0
WireConnection;1744;1;1741;0
WireConnection;1744;0;3615;0
WireConnection;2064;0;2063;0
WireConnection;2064;1;2065;0
WireConnection;2064;2;2066;0
WireConnection;2074;1;2075;0
WireConnection;2074;0;2076;0
WireConnection;3343;1;3344;0
WireConnection;3343;0;3345;0
WireConnection;2077;0;2074;0
WireConnection;3346;0;3343;0
WireConnection;2025;0;2005;0
WireConnection;2012;0;2018;0
WireConnection;2013;0;2018;0
WireConnection;2017;1;2013;0
WireConnection;2017;0;2012;2
WireConnection;2029;0;3638;0
WireConnection;2029;2;2028;0
WireConnection;2030;0;2029;0
WireConnection;2031;0;2030;0
WireConnection;2005;0;2003;0
WireConnection;2005;1;2009;0
WireConnection;2000;0;1996;0
WireConnection;2000;1;1997;0
WireConnection;2001;0;1999;0
WireConnection;2001;1;1998;0
WireConnection;3342;0;3341;0
WireConnection;1741;5;1742;0
WireConnection;3349;22;2017;0
WireConnection;3349;24;2001;0
WireConnection;3349;23;2000;0
WireConnection;3349;25;2005;0
WireConnection;3341;0;3339;0
WireConnection;3341;2;3340;0
WireConnection;1763;0;1755;0
WireConnection;1763;1;1764;0
WireConnection;1755;0;3539;0
WireConnection;1755;1;1756;0
WireConnection;1755;2;3350;0
WireConnection;1765;0;1763;0
WireConnection;1765;1;1766;0
WireConnection;1727;1;1725;4
WireConnection;1727;2;3288;0
WireConnection;3287;0;1729;0
WireConnection;1729;0;1728;0
WireConnection;1729;1;1730;0
WireConnection;1726;1;1725;4
WireConnection;1726;2;3287;0
WireConnection;3458;0;1765;0
WireConnection;3458;1;3536;0
WireConnection;1767;0;3458;0
WireConnection;1767;1;1768;0
WireConnection;1804;0;1803;0
WireConnection;1804;1;1805;0
WireConnection;1802;0;1801;5
WireConnection;1802;1;1804;0
WireConnection;1806;0;1802;0
WireConnection;1806;1;1807;0
WireConnection;1810;0;1806;0
WireConnection;1810;1;1809;4
WireConnection;1808;0;1806;0
WireConnection;1808;1;1810;0
WireConnection;1808;2;1811;0
WireConnection;1812;0;1808;0
WireConnection;3451;0;3450;0
WireConnection;3451;1;3449;0
WireConnection;3453;0;3451;0
WireConnection;3453;1;3452;0
WireConnection;3453;2;3454;0
WireConnection;3455;0;3453;0
WireConnection;3460;0;3455;0
WireConnection;3461;0;3460;0
WireConnection;3538;0;1754;0
WireConnection;2023;0;2022;4
WireConnection;1895;0;1893;0
WireConnection;1890;0;1889;0
WireConnection;1890;1;1891;0
WireConnection;1890;2;1892;0
WireConnection;1891;0;1889;0
WireConnection;1889;0;1886;0
WireConnection;3618;0;1716;0
WireConnection;3618;1;3617;0
WireConnection;1723;0;3618;0
WireConnection;1952;0;1953;0
WireConnection;1952;1;1951;0
WireConnection;1897;0;1958;0
WireConnection;1897;1;1896;0
WireConnection;1836;0;1837;0
WireConnection;1836;1;1835;0
WireConnection;3638;0;3349;0
WireConnection;3638;1;3645;0
WireConnection;2024;0;2023;0
WireConnection;2024;1;2026;0
WireConnection;2027;0;2024;0
WireConnection;2027;1;2021;0
WireConnection;2028;0;2027;0
WireConnection;1712;0;1753;5
WireConnection;1712;1;1713;0
WireConnection;3324;0;1721;0
WireConnection;3324;1;1714;0
WireConnection;3615;110;1741;0
WireConnection;3646;0;1757;1
WireConnection;1761;0;1757;2
WireConnection;1762;0;1757;3
WireConnection;3649;0;3647;0
WireConnection;3649;1;3648;0
WireConnection;3649;2;3651;0
WireConnection;3650;0;3649;0
WireConnection;1760;0;3650;0
WireConnection;3713;0;1875;0
WireConnection;3713;1;1751;0
WireConnection;3713;2;1813;0
WireConnection;3713;4;1814;0
WireConnection;3713;5;1774;0
WireConnection;3713;6;1746;0
WireConnection;3713;7;2792;0
WireConnection;3713;15;1876;0
WireConnection;3713;8;3637;0
ASEEND*/
//CHKSM=8255CB7C0BB24438B139F4A4F4CA80602256505B