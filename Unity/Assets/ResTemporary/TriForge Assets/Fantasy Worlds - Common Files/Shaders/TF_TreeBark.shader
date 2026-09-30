// Made with Amplify Shader Editor v1.9.9
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "TriForge/Tree Bark"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[Header(LAYER MASK)][Space(10)][KeywordEnum( TopProjection,VertexColor,Combined )] _LayerMaskMode( "Layer Mask Mode", Float ) = 0
		[KeywordEnum( Red,Green,Blue,Alpha )] _VertexColorMask( "Vertex Color Mask", Float ) = 0
		_ProjectionMaskOffset( "Projection Mask Offset", Range( -1, 1 ) ) = 0
		_BlendMaskAOInfluence( "Blend Mask AO Influence", Range( 0, 1 ) ) = 0
		_BlendFactor( "Blend Factor", Float ) = 1
		_BlendFalloff( "Blend Falloff", Float ) = 2
		_LayerHeightMapInfluence( "Layer Height Map Influence", Range( 0, 1 ) ) = 1
		[Header(BASE MAP)][SingleLineTexture][Space(10)] _ColorMap( "Color Map", 2D ) = "white" {}
		[SingleLineTexture] _NormalMap( "Normal Map", 2D ) = "white" {}
		[SingleLineTexture] _MaskMapMAOS( "Mask Map (M, AO, S)", 2D ) = "white" {}
		[SingleLineTexture] _EmissiveMap( "Emissive Map", 2D ) = "black" {}
		[Header(COLOR ADJUSTMENT)][Space(10)] _Color( "Color", Color ) = ( 1, 1, 1, 0 )
		_BaseColorBrightness( "Base Color Brightness", Range( 0, 2 ) ) = 1
		_BaseColorSaturation( "Base Color Saturation", Range( 0, 1 ) ) = 1
		_BaseColorContrast( "Base Color Contrast", Range( 0, 2 ) ) = 1
		[Header(LAYER MAPS)][SingleLineTexture][Space(10)] _LayerAlbedo( "Layer Albedo", 2D ) = "white" {}
		[Normal][SingleLineTexture] _LayerNormal( "Layer Normal", 2D ) = "bump" {}
		[SingleLineTexture] _LayerMask( "Layer Mask", 2D ) = "white" {}
		[Header(LAYER ATTRIBUTES)][Space(10)][Toggle( _USELAYER_ON )] _UseLayer( "Use Layer", Float ) = 0
		_LayerSmoothness( "Layer Smoothness", Range( 0, 1 ) ) = 1
		_LayerNormalIntensity( "Layer Normal Intensity", Range( 0, 2 ) ) = 1
		_LayerAOStrength( "Layer AO Strength", Range( 0, 1 ) ) = 0
		_LayerTiling( "Layer Tiling", Range( 0.1, 5 ) ) = 1
		_LayerColor( "Layer Color", Color ) = ( 1, 1, 1, 0 )
		[Header(BASE ATTRIBUTES)][Space(10)] _Smoothness( "Smoothness", Range( 0, 1 ) ) = 0
		_NormalIntensity( "Normal Intensity", Range( -2, 2 ) ) = 1
		_AOIntensity( "AO Intensity", Range( 0, 1 ) ) = 1
		_VertexAOIntensity( "Vertex AO Intensity", Range( 0, 5 ) ) = 1
		[Header(WIND SETTINGS)][Space(10)][Toggle( _ENABLEWIND_ON )] _EnableWind( "Enable Wind", Float ) = 1
		_WindOverallStrength( "Wind Overall Strength", Range( 0, 1 ) ) = 1
		[Header(Main Wind)][Space(5)] _MainWindStrength( "Main Wind Strength", Range( 0, 2 ) ) = 0.5
		_MainBendMaskStrength( "Main Bend Mask Strength", Range( 0, 5 ) ) = 0
		_MainWindScale( "Main Wind Scale", Range( 0, 1 ) ) = 1
		[Header(Parent Wind)][Space(5)] _ParentWindStrength( "Parent Wind Strength", Range( 0, 2 ) ) = 0.5
		_ParentWindMapScale( "Parent Wind Map Scale", Range( 0, 50 ) ) = 1
		_BendingMaskStrength1( "Bending Mask Strength", Range( 0.05, 2 ) ) = 1.236128
		[Header(Child Wind)][Space(5)] _ChildWindStrength( "Child Wind Strength", Range( 0, 2 ) ) = 0.5
		_ChildWindMapScale( "Child Wind Map Scale", Range( 0, 5 ) ) = 2
		[Header(WIND MAPS)][SingleLineTexture][Space(10)] _WindDirectionMap( "Wind Direction Map", 2D ) = "white" {}
		_WindDirectionMapScale( "Wind Direction Map Scale", Float ) = 200
		[Header(WIND DIRECTION)][Space(10)][Toggle( _USEWINDDIRECTIONMAP_ON )] _UseWindDirectionMap( "Use Wind Direction Map", Float ) = 0
		_WindDirectionMapInfluence( "Wind Direction Map Influence", Range( 0, 2 ) ) = 1
		_LFMapPanningSpeed( "LF Map Panning Speed", Vector ) = ( 0.04, 0, 0, 0 )
		_HFRotationMapInfluence( "HF Rotation Map Influence", Range( 0, 1 ) ) = 1
		_HFMapPanningSpeed( "HF Map Panning Speed", Vector ) = ( 0.04, 0, 0, 0 )
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

		Cull Back
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

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
			#pragma multi_compile_instancing
			#pragma instancing_options renderinglayer
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define _EMISSION
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
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _USELAYER_ON
			#pragma shader_feature_local _LAYERMASKMODE_TOPPROJECTION _LAYERMASKMODE_VERTEXCOLOR _LAYERMASKMODE_COMBINED
			#pragma shader_feature_local _VERTEXCOLORMASK_RED _VERTEXCOLORMASK_GREEN _VERTEXCOLORMASK_BLUE _VERTEXCOLORMASK_ALPHA
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
			float4 _MaskMapMAOS_ST;
			float4 _LayerColor;
			float4 _Color;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _Smoothness;
			float _LayerNormalIntensity;
			float _BlendFalloff;
			float _BlendFactor;
			float _BlendMaskAOInfluence;
			float _AOIntensity;
			float _VertexAOIntensity;
			float _LayerHeightMapInfluence;
			float _ProjectionMaskOffset;
			float _NormalIntensity;
			float _LayerTiling;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindOverallStrength;
			float _MainWindStrength;
			float _MainWindScale;
			float _MainBendMaskStrength;
			float _ParentWindStrength;
			float _ParentWindMapScale;
			float _BendingMaskStrength1;
			float _ChildWindStrength;
			float _ChildWindMapScale;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _WindDirectionMapScale;
			float _LayerSmoothness;
			float _LayerAOStrength;
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
			sampler2D _LayerAlbedo;
			sampler2D _NormalMap;
			sampler2D _LayerMask;
			sampler2D _MaskMapMAOS;
			sampler2D _LayerNormal;
			sampler2D _EmissiveMap;


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
			inline float4 TriplanarSampling49_g128( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			
			inline float4 TriplanarSampling31_g129( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			
			inline float3 TriplanarSampling52_g128( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				xNorm.xyz  = half3( UnpackNormalScale( xNorm, normalScale.y ).xy * float2(  nsign.x, 1.0 ) + worldNormal.zy, worldNormal.x ).zyx;
				yNorm.xyz  = half3( UnpackNormalScale( yNorm, normalScale.x ).xy * float2(  nsign.y, 1.0 ) + worldNormal.xz, worldNormal.y ).xzy;
				zNorm.xyz  = half3( UnpackNormalScale( zNorm, normalScale.y ).xy * float2( -nsign.z, 1.0 ) + worldNormal.xy, worldNormal.z ).xyz;
				return normalize( xNorm.xyz * projNormal.x + yNorm.xyz * projNormal.y + zNorm.xyz * projNormal.z );
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 appendResult18_g114 = (float3(( -1.0 * input.texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g114 = ( 0.001 * appendResult18_g114 );
				float dotResult16_g114 = dot( temp_output_20_0_g114 , temp_output_20_0_g114 );
				float ifLocalVar182_g114 = 0;
				if( dotResult16_g114 > 0.0001 )
				ifLocalVar182_g114 = 1.0;
				else if( dotResult16_g114 < 0.0001 )
				ifLocalVar182_g114 = 0.0;
				float ChildMask26_g114 = saturate( ( ifLocalVar182_g114 * 100.0 ) );
				float SelfBendMask34_g114 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g115 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g115 = 0.0;
				else
				ifLocalVar33_g115 = 1.0;
				float ifLocalVar34_g115 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g115 = 0.0;
				else
				ifLocalVar34_g115 = 1.0;
				float3 lerpResult41_g115 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g115 + ifLocalVar34_g115 ));
				float3 WindVector47_g115 = lerpResult41_g115;
				float3 objToWorld6_g116 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g115 = (( objToWorld6_g116 / _WindDirectionMapScale )).xz;
				float2 panner7_g115 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode11_g115 = tex2Dlod( _WindDirectionMap, float4( panner7_g115, 0, 0.0) );
				float2 RotationMapLF16_g115 = (tex2DNode11_g115).rg;
				float2 break35_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g115 = (float3(( break35_g115.x * -1.0 ) , 0.0 , break35_g115.y));
				float2 panner9_g115 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode10_g115 = tex2Dlod( _WindDirectionMap, float4( panner9_g115, 0, 0.0) );
				float2 RotationMapHF17_g115 = (tex2DNode10_g115).ba;
				float2 break36_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g115 = (float3(( break36_g115.x * -1.0 ) , 0.0 , break36_g115.y));
				float3 lerpResult48_g115 = lerp( appendResult42_g115 , appendResult43_g115 , _HFRotationMapInfluence);
				float3 lerpResult51_g115 = lerp( WindVector47_g115 , lerpResult48_g115 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g115 = lerpResult51_g115;
				#else
				float3 staticSwitch55_g115 = WindVector47_g115;
				#endif
				float3 worldToObjDir52_g115 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g115, 0.0 ) ).xyz;
				float3 WindVector226_g114 = worldToObjDir52_g115;
				float3 appendResult11_g114 = (float3(( -1.0 * input.texcoord1.x ) , input.texcoord2.x , ( -1.0 * input.texcoord1.y )));
				float3 temp_output_19_0_g114 = ( 0.001 * appendResult11_g114 );
				float3 SelfPivot28_g114 = temp_output_19_0_g114;
				float3 objToWorld54_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g114 * 1.0 ) + ( objToWorld54_g114 / -2.0 ) )).z).xx;
				float2 panner48_g114 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g114 = snoise( panner48_g114*_ChildWindMapScale );
				simplePerlin2D53_g114 = simplePerlin2D53_g114*0.5 + 0.5;
				float ChildRotation43_g114 = radians( ( simplePerlin2D53_g114 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g114 = RotateAroundAxis( SelfPivot28_g114, input.positionOS.xyz, normalize( WindVector226_g114 ), ChildRotation43_g114 );
				float3 ChildRotationResult119_g114 = ( ( ChildMask26_g114 * SelfBendMask34_g114 ) * ( rotatedValue81_g114 - input.positionOS.xyz ) );
				float temp_output_113_0_g114 = saturate( ( 4.0 * pow( SelfBendMask34_g114 , _BendingMaskStrength1 ) ) );
				float dotResult9_g114 = dot( temp_output_19_0_g114 , temp_output_19_0_g114 );
				float ifLocalVar189_g114 = 0;
				if( dotResult9_g114 > 0.0001 )
				ifLocalVar189_g114 = 1.0;
				else if( dotResult9_g114 < 0.0001 )
				ifLocalVar189_g114 = 0.0;
				float TrunkMask29_g114 = saturate( ( ifLocalVar189_g114 * 1000.0 ) );
				float3 ParentPivot27_g114 = temp_output_20_0_g114;
				float3 lerpResult51_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float2 temp_cast_2 = ((( lerpResult51_g114 / -0.2 )).z).xx;
				float2 panner61_g114 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g114 = snoise( panner61_g114*_ParentWindMapScale );
				simplePerlin2D60_g114 = simplePerlin2D60_g114*0.5 + 0.5;
				float saferPower185_g114 = abs( simplePerlin2D60_g114 );
				float saferPower160_g114 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g114 = saturate( pow( saferPower160_g114 , _MainBendMaskStrength ) );
				float ParentRotation63_g114 = radians( ( pow( saferPower185_g114 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g114 ) );
				float3 lerpResult98_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float3 rotatedValue96_g114 = RotateAroundAxis( lerpResult98_g114, ( ChildRotationResult119_g114 + input.positionOS.xyz ), normalize( WindVector226_g114 ), ParentRotation63_g114 );
				float3 ParentRotationResult131_g114 = ( ChildRotationResult119_g114 + ( ( ( ( ( temp_output_113_0_g114 * ( 1.0 - ChildMask26_g114 ) ) + ChildMask26_g114 ) * TrunkMask29_g114 ) * ( rotatedValue96_g114 - input.positionOS.xyz ) ) * MainBendMask35_g114 ) );
				float3 objToWorld47_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g114 = abs( ( objToWorld47_g114 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g114 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g114 , 2.0 )).xz);
				float simplePerlin2D70_g114 = snoise( panner71_g114*2.0 );
				simplePerlin2D70_g114 = simplePerlin2D70_g114*0.5 + 0.5;
				float MainRotation67_g114 = radians( ( simplePerlin2D70_g114 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g114 = ( ParentRotationResult131_g114 + input.positionOS.xyz );
				float3 rotatedValue121_g114 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g114, normalize( WindVector226_g114 ), MainRotation67_g114 );
				float temp_output_148_0_g114 = pow( MainBendMask35_g114 , 5.0 );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch419 = ( ( ParentRotationResult131_g114 + ( ( rotatedValue121_g114 - temp_output_125_0_g114 ) * temp_output_148_0_g114 ) ) * _WindOverallStrength * TF_WIND_STRENGTH );
				#else
				float3 staticSwitch419 = temp_cast_0;
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

				float3 vertexValue = staticSwitch419;

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
						 ) : SV_Target
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

				float2 texCoord62_g151 = input.ase_texcoord6.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g151 = tex2D( _ColorMap, texCoord62_g151 );
				float3 temp_output_12_0_g154 = tex2DNode1_g151.rgb;
				float dotResult28_g154 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g154 );
				float3 temp_cast_1 = (dotResult28_g154).xxx;
				float temp_output_21_0_g154 = _BaseColorSaturation;
				float3 lerpResult31_g154 = lerp( temp_cast_1 , temp_output_12_0_g154 , temp_output_21_0_g154);
				float3 hsvTorgb14_g153 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g154 * _BaseColorBrightness ) , 0.0 )) * _Color ).rgb );
				float3 hsvTorgb13_g153 = HSVToRGB( float3(( hsvTorgb14_g153.x + 1.0 ),hsvTorgb14_g153.y,hsvTorgb14_g153.z) );
				float3 FinalColor385 = hsvTorgb13_g153;
				float3 temp_output_1_0_g135 = FinalColor385;
				float temp_output_50_0_g128 = _LayerTiling;
				float2 temp_cast_9 = (temp_output_50_0_g128).xx;
				float temp_output_51_0_g128 = 1.0;
				float4 triplanar49_g128 = TriplanarSampling49_g128( _LayerAlbedo, PositionWS, NormalWS, temp_output_51_0_g128, temp_cast_9, 1.0, 0 );
				float4 LayerColor457 = ( _LayerColor * triplanar49_g128 );
				float3 unpack7_g151 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g151 ), _NormalIntensity );
				unpack7_g151.z = lerp( 1, unpack7_g151.z, saturate(_NormalIntensity) );
				float3 FinalNormal387 = unpack7_g151;
				float3 tanToWorld0 = float3( TangentWS.x, BitangentWS.x, NormalWS.x );
				float3 tanToWorld1 = float3( TangentWS.y, BitangentWS.y, NormalWS.y );
				float3 tanToWorld2 = float3( TangentWS.z, BitangentWS.z, NormalWS.z );
				float3 tanNormal5_g136 = FinalNormal387;
				float3 worldNormal5_g136 = normalize( float3( dot( tanToWorld0, tanNormal5_g136 ), dot( tanToWorld1, tanNormal5_g136 ), dot( tanToWorld2, tanNormal5_g136 ) ) );
				float2 temp_cast_10 = (temp_output_50_0_g128).xx;
				float4 triplanar31_g129 = TriplanarSampling31_g129( _LayerMask, PositionWS, NormalWS, temp_output_51_0_g128, temp_cast_10, 1.0, 0 );
				float LayerHeight469 = triplanar31_g129.z;
				float lerpResult32_g136 = lerp( 0.0 , LayerHeight469 , _LayerHeightMapInfluence);
				float2 uv_MaskMapMAOS = input.ase_texcoord6.xy * _MaskMapMAOS_ST.xy + _MaskMapMAOS_ST.zw;
				float4 tex2DNode1_g152 = tex2D( _MaskMapMAOS, uv_MaskMapMAOS );
				float AmbientOcclusion389 = saturate( ( tex2DNode1_g152.g - ( ( 1.0 - _AOIntensity ) * -1.0 ) ) );
				float FinalAmbientOcclusion403 = saturate( ( saturate( ( ( 1.0 - _VertexAOIntensity ) + pow( input.ase_color.r , 2.0 ) ) ) * AmbientOcclusion389 ) );
				float lerpResult27_g136 = lerp( 0.0 , ( 1.0 - FinalAmbientOcclusion403 ) , _BlendMaskAOInfluence);
				float BlendMask37_g136 = saturate( ( lerpResult32_g136 + lerpResult27_g136 ) );
				float temp_output_9_0_g138 = saturate( pow( max( ( saturate( ( worldNormal5_g136.y + _ProjectionMaskOffset ) ) * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_36_0_g136 = temp_output_9_0_g138;
				#if defined( _VERTEXCOLORMASK_RED )
				float staticSwitch17_g136 = input.ase_color.r;
				#elif defined( _VERTEXCOLORMASK_GREEN )
				float staticSwitch17_g136 = input.ase_color.g;
				#elif defined( _VERTEXCOLORMASK_BLUE )
				float staticSwitch17_g136 = input.ase_color.b;
				#elif defined( _VERTEXCOLORMASK_ALPHA )
				float staticSwitch17_g136 = input.ase_color.a;
				#else
				float staticSwitch17_g136 = input.ase_color.r;
				#endif
				float temp_output_9_0_g137 = saturate( pow( max( ( staticSwitch17_g136 * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_14_0_g136 = temp_output_9_0_g137;
				#if defined( _LAYERMASKMODE_TOPPROJECTION )
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#elif defined( _LAYERMASKMODE_VERTEXCOLOR )
				float staticSwitch18_g136 = temp_output_14_0_g136;
				#elif defined( _LAYERMASKMODE_COMBINED )
				float staticSwitch18_g136 = saturate( ( temp_output_36_0_g136 + temp_output_14_0_g136 ) );
				#else
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#endif
				float temp_output_11_0_g135 = staticSwitch18_g136;
				float4 lerpResult12_g135 = lerp( float4( temp_output_1_0_g135 , 0.0 ) , LayerColor457 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float4 staticSwitch38_g135 = lerpResult12_g135;
				#else
				float4 staticSwitch38_g135 = float4( temp_output_1_0_g135 , 0.0 );
				#endif
				
				float3 temp_output_2_0_g135 = FinalNormal387;
				float2 temp_cast_12 = (temp_output_50_0_g128).xx;
				float3x3 ase_worldToTangent = float3x3( TangentWS, BitangentWS, NormalWS );
				float3 triplanar52_g128 = TriplanarSampling52_g128( _LayerNormal, PositionWS, NormalWS, temp_output_51_0_g128, temp_cast_12, _LayerNormalIntensity, 0 );
				float3 tanTriplanarNormal52_g128 = mul( ase_worldToTangent, triplanar52_g128 );
				float3 LayerNormal456 = tanTriplanarNormal52_g128;
				float3 lerpResult13_g135 = lerp( temp_output_2_0_g135 , LayerNormal456 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float3 staticSwitch39_g135 = lerpResult13_g135;
				#else
				float3 staticSwitch39_g135 = temp_output_2_0_g135;
				#endif
				
				float Smoothness388 = ( tex2DNode1_g152.a * _Smoothness );
				float temp_output_4_0_g135 = Smoothness388;
				float LayerSmoothness454 = ( triplanar31_g129.a * _LayerSmoothness );
				float lerpResult15_g135 = lerp( temp_output_4_0_g135 , LayerSmoothness454 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float staticSwitch41_g135 = lerpResult15_g135;
				#else
				float staticSwitch41_g135 = temp_output_4_0_g135;
				#endif
				
				float temp_output_5_0_g135 = AmbientOcclusion389;
				float LayerAmbientOcclusion466 = saturate( ( triplanar31_g129.g - ( ( 1.0 - _LayerAOStrength ) * -1.0 ) ) );
				float lerpResult22_g135 = lerp( temp_output_5_0_g135 , LayerAmbientOcclusion466 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float staticSwitch43_g135 = lerpResult22_g135;
				#else
				float staticSwitch43_g135 = temp_output_5_0_g135;
				#endif
				
				float4 color406 = IsGammaSpace() ? float4( 1, 1, 1, 0 ) : float4( 1, 1, 1, 0 );
				float4 Emissive420 = ( tex2D( _EmissiveMap, texCoord62_g151 ) * color406 );
				float4 temp_output_33_0_g135 = Emissive420;
				float4 temp_cast_13 = (0.0).xxxx;
				float4 lerpResult34_g135 = lerp( temp_output_33_0_g135 , temp_cast_13 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float4 staticSwitch44_g135 = lerpResult34_g135;
				#else
				float4 staticSwitch44_g135 = temp_output_33_0_g135;
				#endif
				

				float3 BaseColor = staticSwitch38_g135.xyz;
				float3 Normal = staticSwitch39_g135;
				float3 Specular = 0.5;
				float Metallic = 0;
				float Smoothness = staticSwitch41_g135;
				float Occlusion = staticSwitch43_g135;
				float3 Emission = staticSwitch44_g135.rgb;
				float Alpha = 1;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;

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
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define _EMISSION
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
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
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
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _MaskMapMAOS_ST;
			float4 _LayerColor;
			float4 _Color;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _Smoothness;
			float _LayerNormalIntensity;
			float _BlendFalloff;
			float _BlendFactor;
			float _BlendMaskAOInfluence;
			float _AOIntensity;
			float _VertexAOIntensity;
			float _LayerHeightMapInfluence;
			float _ProjectionMaskOffset;
			float _NormalIntensity;
			float _LayerTiling;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindOverallStrength;
			float _MainWindStrength;
			float _MainWindScale;
			float _MainBendMaskStrength;
			float _ParentWindStrength;
			float _ParentWindMapScale;
			float _BendingMaskStrength1;
			float _ChildWindStrength;
			float _ChildWindMapScale;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _WindDirectionMapScale;
			float _LayerSmoothness;
			float _LayerAOStrength;
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
				float3 appendResult18_g114 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g114 = ( 0.001 * appendResult18_g114 );
				float dotResult16_g114 = dot( temp_output_20_0_g114 , temp_output_20_0_g114 );
				float ifLocalVar182_g114 = 0;
				if( dotResult16_g114 > 0.0001 )
				ifLocalVar182_g114 = 1.0;
				else if( dotResult16_g114 < 0.0001 )
				ifLocalVar182_g114 = 0.0;
				float ChildMask26_g114 = saturate( ( ifLocalVar182_g114 * 100.0 ) );
				float SelfBendMask34_g114 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g115 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g115 = 0.0;
				else
				ifLocalVar33_g115 = 1.0;
				float ifLocalVar34_g115 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g115 = 0.0;
				else
				ifLocalVar34_g115 = 1.0;
				float3 lerpResult41_g115 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g115 + ifLocalVar34_g115 ));
				float3 WindVector47_g115 = lerpResult41_g115;
				float3 objToWorld6_g116 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g115 = (( objToWorld6_g116 / _WindDirectionMapScale )).xz;
				float2 panner7_g115 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode11_g115 = tex2Dlod( _WindDirectionMap, float4( panner7_g115, 0, 0.0) );
				float2 RotationMapLF16_g115 = (tex2DNode11_g115).rg;
				float2 break35_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g115 = (float3(( break35_g115.x * -1.0 ) , 0.0 , break35_g115.y));
				float2 panner9_g115 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode10_g115 = tex2Dlod( _WindDirectionMap, float4( panner9_g115, 0, 0.0) );
				float2 RotationMapHF17_g115 = (tex2DNode10_g115).ba;
				float2 break36_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g115 = (float3(( break36_g115.x * -1.0 ) , 0.0 , break36_g115.y));
				float3 lerpResult48_g115 = lerp( appendResult42_g115 , appendResult43_g115 , _HFRotationMapInfluence);
				float3 lerpResult51_g115 = lerp( WindVector47_g115 , lerpResult48_g115 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g115 = lerpResult51_g115;
				#else
				float3 staticSwitch55_g115 = WindVector47_g115;
				#endif
				float3 worldToObjDir52_g115 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g115, 0.0 ) ).xyz;
				float3 WindVector226_g114 = worldToObjDir52_g115;
				float3 appendResult11_g114 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g114 = ( 0.001 * appendResult11_g114 );
				float3 SelfPivot28_g114 = temp_output_19_0_g114;
				float3 objToWorld54_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g114 * 1.0 ) + ( objToWorld54_g114 / -2.0 ) )).z).xx;
				float2 panner48_g114 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g114 = snoise( panner48_g114*_ChildWindMapScale );
				simplePerlin2D53_g114 = simplePerlin2D53_g114*0.5 + 0.5;
				float ChildRotation43_g114 = radians( ( simplePerlin2D53_g114 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g114 = RotateAroundAxis( SelfPivot28_g114, input.positionOS.xyz, normalize( WindVector226_g114 ), ChildRotation43_g114 );
				float3 ChildRotationResult119_g114 = ( ( ChildMask26_g114 * SelfBendMask34_g114 ) * ( rotatedValue81_g114 - input.positionOS.xyz ) );
				float temp_output_113_0_g114 = saturate( ( 4.0 * pow( SelfBendMask34_g114 , _BendingMaskStrength1 ) ) );
				float dotResult9_g114 = dot( temp_output_19_0_g114 , temp_output_19_0_g114 );
				float ifLocalVar189_g114 = 0;
				if( dotResult9_g114 > 0.0001 )
				ifLocalVar189_g114 = 1.0;
				else if( dotResult9_g114 < 0.0001 )
				ifLocalVar189_g114 = 0.0;
				float TrunkMask29_g114 = saturate( ( ifLocalVar189_g114 * 1000.0 ) );
				float3 ParentPivot27_g114 = temp_output_20_0_g114;
				float3 lerpResult51_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float2 temp_cast_2 = ((( lerpResult51_g114 / -0.2 )).z).xx;
				float2 panner61_g114 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g114 = snoise( panner61_g114*_ParentWindMapScale );
				simplePerlin2D60_g114 = simplePerlin2D60_g114*0.5 + 0.5;
				float saferPower185_g114 = abs( simplePerlin2D60_g114 );
				float saferPower160_g114 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g114 = saturate( pow( saferPower160_g114 , _MainBendMaskStrength ) );
				float ParentRotation63_g114 = radians( ( pow( saferPower185_g114 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g114 ) );
				float3 lerpResult98_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float3 rotatedValue96_g114 = RotateAroundAxis( lerpResult98_g114, ( ChildRotationResult119_g114 + input.positionOS.xyz ), normalize( WindVector226_g114 ), ParentRotation63_g114 );
				float3 ParentRotationResult131_g114 = ( ChildRotationResult119_g114 + ( ( ( ( ( temp_output_113_0_g114 * ( 1.0 - ChildMask26_g114 ) ) + ChildMask26_g114 ) * TrunkMask29_g114 ) * ( rotatedValue96_g114 - input.positionOS.xyz ) ) * MainBendMask35_g114 ) );
				float3 objToWorld47_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g114 = abs( ( objToWorld47_g114 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g114 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g114 , 2.0 )).xz);
				float simplePerlin2D70_g114 = snoise( panner71_g114*2.0 );
				simplePerlin2D70_g114 = simplePerlin2D70_g114*0.5 + 0.5;
				float MainRotation67_g114 = radians( ( simplePerlin2D70_g114 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g114 = ( ParentRotationResult131_g114 + input.positionOS.xyz );
				float3 rotatedValue121_g114 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g114, normalize( WindVector226_g114 ), MainRotation67_g114 );
				float temp_output_148_0_g114 = pow( MainBendMask35_g114 , 5.0 );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch419 = ( ( ParentRotationResult131_g114 + ( ( rotatedValue121_g114 - temp_output_125_0_g114 ) * temp_output_148_0_g114 ) ) * _WindOverallStrength * TF_WIND_STRENGTH );
				#else
				float3 staticSwitch419 = temp_cast_0;
				#endif
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch419;
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

				

				float Alpha = 1;
				float AlphaClipThreshold = 0.5;
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
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define _EMISSION
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
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
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
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _MaskMapMAOS_ST;
			float4 _LayerColor;
			float4 _Color;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _Smoothness;
			float _LayerNormalIntensity;
			float _BlendFalloff;
			float _BlendFactor;
			float _BlendMaskAOInfluence;
			float _AOIntensity;
			float _VertexAOIntensity;
			float _LayerHeightMapInfluence;
			float _ProjectionMaskOffset;
			float _NormalIntensity;
			float _LayerTiling;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindOverallStrength;
			float _MainWindStrength;
			float _MainWindScale;
			float _MainBendMaskStrength;
			float _ParentWindStrength;
			float _ParentWindMapScale;
			float _BendingMaskStrength1;
			float _ChildWindStrength;
			float _ChildWindMapScale;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _WindDirectionMapScale;
			float _LayerSmoothness;
			float _LayerAOStrength;
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
				float3 appendResult18_g114 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g114 = ( 0.001 * appendResult18_g114 );
				float dotResult16_g114 = dot( temp_output_20_0_g114 , temp_output_20_0_g114 );
				float ifLocalVar182_g114 = 0;
				if( dotResult16_g114 > 0.0001 )
				ifLocalVar182_g114 = 1.0;
				else if( dotResult16_g114 < 0.0001 )
				ifLocalVar182_g114 = 0.0;
				float ChildMask26_g114 = saturate( ( ifLocalVar182_g114 * 100.0 ) );
				float SelfBendMask34_g114 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g115 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g115 = 0.0;
				else
				ifLocalVar33_g115 = 1.0;
				float ifLocalVar34_g115 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g115 = 0.0;
				else
				ifLocalVar34_g115 = 1.0;
				float3 lerpResult41_g115 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g115 + ifLocalVar34_g115 ));
				float3 WindVector47_g115 = lerpResult41_g115;
				float3 objToWorld6_g116 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g115 = (( objToWorld6_g116 / _WindDirectionMapScale )).xz;
				float2 panner7_g115 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode11_g115 = tex2Dlod( _WindDirectionMap, float4( panner7_g115, 0, 0.0) );
				float2 RotationMapLF16_g115 = (tex2DNode11_g115).rg;
				float2 break35_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g115 = (float3(( break35_g115.x * -1.0 ) , 0.0 , break35_g115.y));
				float2 panner9_g115 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode10_g115 = tex2Dlod( _WindDirectionMap, float4( panner9_g115, 0, 0.0) );
				float2 RotationMapHF17_g115 = (tex2DNode10_g115).ba;
				float2 break36_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g115 = (float3(( break36_g115.x * -1.0 ) , 0.0 , break36_g115.y));
				float3 lerpResult48_g115 = lerp( appendResult42_g115 , appendResult43_g115 , _HFRotationMapInfluence);
				float3 lerpResult51_g115 = lerp( WindVector47_g115 , lerpResult48_g115 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g115 = lerpResult51_g115;
				#else
				float3 staticSwitch55_g115 = WindVector47_g115;
				#endif
				float3 worldToObjDir52_g115 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g115, 0.0 ) ).xyz;
				float3 WindVector226_g114 = worldToObjDir52_g115;
				float3 appendResult11_g114 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g114 = ( 0.001 * appendResult11_g114 );
				float3 SelfPivot28_g114 = temp_output_19_0_g114;
				float3 objToWorld54_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g114 * 1.0 ) + ( objToWorld54_g114 / -2.0 ) )).z).xx;
				float2 panner48_g114 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g114 = snoise( panner48_g114*_ChildWindMapScale );
				simplePerlin2D53_g114 = simplePerlin2D53_g114*0.5 + 0.5;
				float ChildRotation43_g114 = radians( ( simplePerlin2D53_g114 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g114 = RotateAroundAxis( SelfPivot28_g114, input.positionOS.xyz, normalize( WindVector226_g114 ), ChildRotation43_g114 );
				float3 ChildRotationResult119_g114 = ( ( ChildMask26_g114 * SelfBendMask34_g114 ) * ( rotatedValue81_g114 - input.positionOS.xyz ) );
				float temp_output_113_0_g114 = saturate( ( 4.0 * pow( SelfBendMask34_g114 , _BendingMaskStrength1 ) ) );
				float dotResult9_g114 = dot( temp_output_19_0_g114 , temp_output_19_0_g114 );
				float ifLocalVar189_g114 = 0;
				if( dotResult9_g114 > 0.0001 )
				ifLocalVar189_g114 = 1.0;
				else if( dotResult9_g114 < 0.0001 )
				ifLocalVar189_g114 = 0.0;
				float TrunkMask29_g114 = saturate( ( ifLocalVar189_g114 * 1000.0 ) );
				float3 ParentPivot27_g114 = temp_output_20_0_g114;
				float3 lerpResult51_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float2 temp_cast_2 = ((( lerpResult51_g114 / -0.2 )).z).xx;
				float2 panner61_g114 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g114 = snoise( panner61_g114*_ParentWindMapScale );
				simplePerlin2D60_g114 = simplePerlin2D60_g114*0.5 + 0.5;
				float saferPower185_g114 = abs( simplePerlin2D60_g114 );
				float saferPower160_g114 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g114 = saturate( pow( saferPower160_g114 , _MainBendMaskStrength ) );
				float ParentRotation63_g114 = radians( ( pow( saferPower185_g114 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g114 ) );
				float3 lerpResult98_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float3 rotatedValue96_g114 = RotateAroundAxis( lerpResult98_g114, ( ChildRotationResult119_g114 + input.positionOS.xyz ), normalize( WindVector226_g114 ), ParentRotation63_g114 );
				float3 ParentRotationResult131_g114 = ( ChildRotationResult119_g114 + ( ( ( ( ( temp_output_113_0_g114 * ( 1.0 - ChildMask26_g114 ) ) + ChildMask26_g114 ) * TrunkMask29_g114 ) * ( rotatedValue96_g114 - input.positionOS.xyz ) ) * MainBendMask35_g114 ) );
				float3 objToWorld47_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g114 = abs( ( objToWorld47_g114 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g114 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g114 , 2.0 )).xz);
				float simplePerlin2D70_g114 = snoise( panner71_g114*2.0 );
				simplePerlin2D70_g114 = simplePerlin2D70_g114*0.5 + 0.5;
				float MainRotation67_g114 = radians( ( simplePerlin2D70_g114 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g114 = ( ParentRotationResult131_g114 + input.positionOS.xyz );
				float3 rotatedValue121_g114 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g114, normalize( WindVector226_g114 ), MainRotation67_g114 );
				float temp_output_148_0_g114 = pow( MainBendMask35_g114 , 5.0 );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch419 = ( ( ParentRotationResult131_g114 + ( ( rotatedValue121_g114 - temp_output_125_0_g114 ) * temp_output_148_0_g114 ) ) * _WindOverallStrength * TF_WIND_STRENGTH );
				#else
				float3 staticSwitch419 = temp_cast_0;
				#endif
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch419;

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

				

				float Alpha = 1;
				float AlphaClipThreshold = 0.5;

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
			#define _EMISSION
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
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_VERT_TANGENT
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _USELAYER_ON
			#pragma shader_feature_local _LAYERMASKMODE_TOPPROJECTION _LAYERMASKMODE_VERTEXCOLOR _LAYERMASKMODE_COMBINED
			#pragma shader_feature_local _VERTEXCOLORMASK_RED _VERTEXCOLORMASK_GREEN _VERTEXCOLORMASK_BLUE _VERTEXCOLORMASK_ALPHA
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
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _MaskMapMAOS_ST;
			float4 _LayerColor;
			float4 _Color;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _Smoothness;
			float _LayerNormalIntensity;
			float _BlendFalloff;
			float _BlendFactor;
			float _BlendMaskAOInfluence;
			float _AOIntensity;
			float _VertexAOIntensity;
			float _LayerHeightMapInfluence;
			float _ProjectionMaskOffset;
			float _NormalIntensity;
			float _LayerTiling;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindOverallStrength;
			float _MainWindStrength;
			float _MainWindScale;
			float _MainBendMaskStrength;
			float _ParentWindStrength;
			float _ParentWindMapScale;
			float _BendingMaskStrength1;
			float _ChildWindStrength;
			float _ChildWindMapScale;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _WindDirectionMapScale;
			float _LayerSmoothness;
			float _LayerAOStrength;
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
			sampler2D _LayerAlbedo;
			sampler2D _NormalMap;
			sampler2D _LayerMask;
			sampler2D _MaskMapMAOS;
			sampler2D _EmissiveMap;


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
			inline float4 TriplanarSampling49_g128( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			
			inline float4 TriplanarSampling31_g129( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 appendResult18_g114 = (float3(( -1.0 * input.texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g114 = ( 0.001 * appendResult18_g114 );
				float dotResult16_g114 = dot( temp_output_20_0_g114 , temp_output_20_0_g114 );
				float ifLocalVar182_g114 = 0;
				if( dotResult16_g114 > 0.0001 )
				ifLocalVar182_g114 = 1.0;
				else if( dotResult16_g114 < 0.0001 )
				ifLocalVar182_g114 = 0.0;
				float ChildMask26_g114 = saturate( ( ifLocalVar182_g114 * 100.0 ) );
				float SelfBendMask34_g114 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g115 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g115 = 0.0;
				else
				ifLocalVar33_g115 = 1.0;
				float ifLocalVar34_g115 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g115 = 0.0;
				else
				ifLocalVar34_g115 = 1.0;
				float3 lerpResult41_g115 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g115 + ifLocalVar34_g115 ));
				float3 WindVector47_g115 = lerpResult41_g115;
				float3 objToWorld6_g116 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g115 = (( objToWorld6_g116 / _WindDirectionMapScale )).xz;
				float2 panner7_g115 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode11_g115 = tex2Dlod( _WindDirectionMap, float4( panner7_g115, 0, 0.0) );
				float2 RotationMapLF16_g115 = (tex2DNode11_g115).rg;
				float2 break35_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g115 = (float3(( break35_g115.x * -1.0 ) , 0.0 , break35_g115.y));
				float2 panner9_g115 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode10_g115 = tex2Dlod( _WindDirectionMap, float4( panner9_g115, 0, 0.0) );
				float2 RotationMapHF17_g115 = (tex2DNode10_g115).ba;
				float2 break36_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g115 = (float3(( break36_g115.x * -1.0 ) , 0.0 , break36_g115.y));
				float3 lerpResult48_g115 = lerp( appendResult42_g115 , appendResult43_g115 , _HFRotationMapInfluence);
				float3 lerpResult51_g115 = lerp( WindVector47_g115 , lerpResult48_g115 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g115 = lerpResult51_g115;
				#else
				float3 staticSwitch55_g115 = WindVector47_g115;
				#endif
				float3 worldToObjDir52_g115 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g115, 0.0 ) ).xyz;
				float3 WindVector226_g114 = worldToObjDir52_g115;
				float3 appendResult11_g114 = (float3(( -1.0 * input.texcoord1.x ) , input.texcoord2.x , ( -1.0 * input.texcoord1.y )));
				float3 temp_output_19_0_g114 = ( 0.001 * appendResult11_g114 );
				float3 SelfPivot28_g114 = temp_output_19_0_g114;
				float3 objToWorld54_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g114 * 1.0 ) + ( objToWorld54_g114 / -2.0 ) )).z).xx;
				float2 panner48_g114 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g114 = snoise( panner48_g114*_ChildWindMapScale );
				simplePerlin2D53_g114 = simplePerlin2D53_g114*0.5 + 0.5;
				float ChildRotation43_g114 = radians( ( simplePerlin2D53_g114 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g114 = RotateAroundAxis( SelfPivot28_g114, input.positionOS.xyz, normalize( WindVector226_g114 ), ChildRotation43_g114 );
				float3 ChildRotationResult119_g114 = ( ( ChildMask26_g114 * SelfBendMask34_g114 ) * ( rotatedValue81_g114 - input.positionOS.xyz ) );
				float temp_output_113_0_g114 = saturate( ( 4.0 * pow( SelfBendMask34_g114 , _BendingMaskStrength1 ) ) );
				float dotResult9_g114 = dot( temp_output_19_0_g114 , temp_output_19_0_g114 );
				float ifLocalVar189_g114 = 0;
				if( dotResult9_g114 > 0.0001 )
				ifLocalVar189_g114 = 1.0;
				else if( dotResult9_g114 < 0.0001 )
				ifLocalVar189_g114 = 0.0;
				float TrunkMask29_g114 = saturate( ( ifLocalVar189_g114 * 1000.0 ) );
				float3 ParentPivot27_g114 = temp_output_20_0_g114;
				float3 lerpResult51_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float2 temp_cast_2 = ((( lerpResult51_g114 / -0.2 )).z).xx;
				float2 panner61_g114 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g114 = snoise( panner61_g114*_ParentWindMapScale );
				simplePerlin2D60_g114 = simplePerlin2D60_g114*0.5 + 0.5;
				float saferPower185_g114 = abs( simplePerlin2D60_g114 );
				float saferPower160_g114 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g114 = saturate( pow( saferPower160_g114 , _MainBendMaskStrength ) );
				float ParentRotation63_g114 = radians( ( pow( saferPower185_g114 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g114 ) );
				float3 lerpResult98_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float3 rotatedValue96_g114 = RotateAroundAxis( lerpResult98_g114, ( ChildRotationResult119_g114 + input.positionOS.xyz ), normalize( WindVector226_g114 ), ParentRotation63_g114 );
				float3 ParentRotationResult131_g114 = ( ChildRotationResult119_g114 + ( ( ( ( ( temp_output_113_0_g114 * ( 1.0 - ChildMask26_g114 ) ) + ChildMask26_g114 ) * TrunkMask29_g114 ) * ( rotatedValue96_g114 - input.positionOS.xyz ) ) * MainBendMask35_g114 ) );
				float3 objToWorld47_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g114 = abs( ( objToWorld47_g114 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g114 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g114 , 2.0 )).xz);
				float simplePerlin2D70_g114 = snoise( panner71_g114*2.0 );
				simplePerlin2D70_g114 = simplePerlin2D70_g114*0.5 + 0.5;
				float MainRotation67_g114 = radians( ( simplePerlin2D70_g114 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g114 = ( ParentRotationResult131_g114 + input.positionOS.xyz );
				float3 rotatedValue121_g114 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g114, normalize( WindVector226_g114 ), MainRotation67_g114 );
				float temp_output_148_0_g114 = pow( MainBendMask35_g114 , 5.0 );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch419 = ( ( ParentRotationResult131_g114 + ( ( rotatedValue121_g114 - temp_output_125_0_g114 ) * temp_output_148_0_g114 ) ) * _WindOverallStrength * TF_WIND_STRENGTH );
				#else
				float3 staticSwitch419 = temp_cast_0;
				#endif
				
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord4.xyz = ase_normalWS;
				float3 ase_tangentWS = TransformObjectToWorldDir( input.tangentOS.xyz );
				output.ase_texcoord5.xyz = ase_tangentWS;
				float ase_tangentSign = input.tangentOS.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord6.xyz = ase_bitangentWS;
				
				output.ase_texcoord3.xy = input.texcoord0.xy;
				output.ase_color = input.ase_color;
				
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

				float3 vertexValue = staticSwitch419;

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

				float2 texCoord62_g151 = input.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g151 = tex2D( _ColorMap, texCoord62_g151 );
				float3 temp_output_12_0_g154 = tex2DNode1_g151.rgb;
				float dotResult28_g154 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g154 );
				float3 temp_cast_1 = (dotResult28_g154).xxx;
				float temp_output_21_0_g154 = _BaseColorSaturation;
				float3 lerpResult31_g154 = lerp( temp_cast_1 , temp_output_12_0_g154 , temp_output_21_0_g154);
				float3 hsvTorgb14_g153 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g154 * _BaseColorBrightness ) , 0.0 )) * _Color ).rgb );
				float3 hsvTorgb13_g153 = HSVToRGB( float3(( hsvTorgb14_g153.x + 1.0 ),hsvTorgb14_g153.y,hsvTorgb14_g153.z) );
				float3 FinalColor385 = hsvTorgb13_g153;
				float3 temp_output_1_0_g135 = FinalColor385;
				float temp_output_50_0_g128 = _LayerTiling;
				float2 temp_cast_9 = (temp_output_50_0_g128).xx;
				float temp_output_51_0_g128 = 1.0;
				float3 ase_normalWS = input.ase_texcoord4.xyz;
				float4 triplanar49_g128 = TriplanarSampling49_g128( _LayerAlbedo, PositionWS, ase_normalWS, temp_output_51_0_g128, temp_cast_9, 1.0, 0 );
				float4 LayerColor457 = ( _LayerColor * triplanar49_g128 );
				float3 unpack7_g151 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g151 ), _NormalIntensity );
				unpack7_g151.z = lerp( 1, unpack7_g151.z, saturate(_NormalIntensity) );
				float3 FinalNormal387 = unpack7_g151;
				float3 ase_tangentWS = input.ase_texcoord5.xyz;
				float3 ase_bitangentWS = input.ase_texcoord6.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal5_g136 = FinalNormal387;
				float3 worldNormal5_g136 = normalize( float3( dot( tanToWorld0, tanNormal5_g136 ), dot( tanToWorld1, tanNormal5_g136 ), dot( tanToWorld2, tanNormal5_g136 ) ) );
				float2 temp_cast_10 = (temp_output_50_0_g128).xx;
				float4 triplanar31_g129 = TriplanarSampling31_g129( _LayerMask, PositionWS, ase_normalWS, temp_output_51_0_g128, temp_cast_10, 1.0, 0 );
				float LayerHeight469 = triplanar31_g129.z;
				float lerpResult32_g136 = lerp( 0.0 , LayerHeight469 , _LayerHeightMapInfluence);
				float2 uv_MaskMapMAOS = input.ase_texcoord3.xy * _MaskMapMAOS_ST.xy + _MaskMapMAOS_ST.zw;
				float4 tex2DNode1_g152 = tex2D( _MaskMapMAOS, uv_MaskMapMAOS );
				float AmbientOcclusion389 = saturate( ( tex2DNode1_g152.g - ( ( 1.0 - _AOIntensity ) * -1.0 ) ) );
				float FinalAmbientOcclusion403 = saturate( ( saturate( ( ( 1.0 - _VertexAOIntensity ) + pow( input.ase_color.r , 2.0 ) ) ) * AmbientOcclusion389 ) );
				float lerpResult27_g136 = lerp( 0.0 , ( 1.0 - FinalAmbientOcclusion403 ) , _BlendMaskAOInfluence);
				float BlendMask37_g136 = saturate( ( lerpResult32_g136 + lerpResult27_g136 ) );
				float temp_output_9_0_g138 = saturate( pow( max( ( saturate( ( worldNormal5_g136.y + _ProjectionMaskOffset ) ) * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_36_0_g136 = temp_output_9_0_g138;
				#if defined( _VERTEXCOLORMASK_RED )
				float staticSwitch17_g136 = input.ase_color.r;
				#elif defined( _VERTEXCOLORMASK_GREEN )
				float staticSwitch17_g136 = input.ase_color.g;
				#elif defined( _VERTEXCOLORMASK_BLUE )
				float staticSwitch17_g136 = input.ase_color.b;
				#elif defined( _VERTEXCOLORMASK_ALPHA )
				float staticSwitch17_g136 = input.ase_color.a;
				#else
				float staticSwitch17_g136 = input.ase_color.r;
				#endif
				float temp_output_9_0_g137 = saturate( pow( max( ( staticSwitch17_g136 * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_14_0_g136 = temp_output_9_0_g137;
				#if defined( _LAYERMASKMODE_TOPPROJECTION )
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#elif defined( _LAYERMASKMODE_VERTEXCOLOR )
				float staticSwitch18_g136 = temp_output_14_0_g136;
				#elif defined( _LAYERMASKMODE_COMBINED )
				float staticSwitch18_g136 = saturate( ( temp_output_36_0_g136 + temp_output_14_0_g136 ) );
				#else
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#endif
				float temp_output_11_0_g135 = staticSwitch18_g136;
				float4 lerpResult12_g135 = lerp( float4( temp_output_1_0_g135 , 0.0 ) , LayerColor457 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float4 staticSwitch38_g135 = lerpResult12_g135;
				#else
				float4 staticSwitch38_g135 = float4( temp_output_1_0_g135 , 0.0 );
				#endif
				
				float4 color406 = IsGammaSpace() ? float4( 1, 1, 1, 0 ) : float4( 1, 1, 1, 0 );
				float4 Emissive420 = ( tex2D( _EmissiveMap, texCoord62_g151 ) * color406 );
				float4 temp_output_33_0_g135 = Emissive420;
				float4 temp_cast_12 = (0.0).xxxx;
				float4 lerpResult34_g135 = lerp( temp_output_33_0_g135 , temp_cast_12 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float4 staticSwitch44_g135 = lerpResult34_g135;
				#else
				float4 staticSwitch44_g135 = temp_output_33_0_g135;
				#endif
				

				float3 BaseColor = staticSwitch38_g135.xyz;
				float3 Emission = staticSwitch44_g135.rgb;
				float Alpha = 1;
				float AlphaClipThreshold = 0.5;

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
			#define _EMISSION
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
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_VERT_TANGENT
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _USELAYER_ON
			#pragma shader_feature_local _LAYERMASKMODE_TOPPROJECTION _LAYERMASKMODE_VERTEXCOLOR _LAYERMASKMODE_COMBINED
			#pragma shader_feature_local _VERTEXCOLORMASK_RED _VERTEXCOLORMASK_GREEN _VERTEXCOLORMASK_BLUE _VERTEXCOLORMASK_ALPHA
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
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
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
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _MaskMapMAOS_ST;
			float4 _LayerColor;
			float4 _Color;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _Smoothness;
			float _LayerNormalIntensity;
			float _BlendFalloff;
			float _BlendFactor;
			float _BlendMaskAOInfluence;
			float _AOIntensity;
			float _VertexAOIntensity;
			float _LayerHeightMapInfluence;
			float _ProjectionMaskOffset;
			float _NormalIntensity;
			float _LayerTiling;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindOverallStrength;
			float _MainWindStrength;
			float _MainWindScale;
			float _MainBendMaskStrength;
			float _ParentWindStrength;
			float _ParentWindMapScale;
			float _BendingMaskStrength1;
			float _ChildWindStrength;
			float _ChildWindMapScale;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _WindDirectionMapScale;
			float _LayerSmoothness;
			float _LayerAOStrength;
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
			sampler2D _LayerAlbedo;
			sampler2D _NormalMap;
			sampler2D _LayerMask;
			sampler2D _MaskMapMAOS;


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
			inline float4 TriplanarSampling49_g128( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			
			inline float4 TriplanarSampling31_g129( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID( input );
				UNITY_TRANSFER_INSTANCE_ID( input, output );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( output );

				float3 temp_cast_0 = (0.0).xxx;
				float3 appendResult18_g114 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g114 = ( 0.001 * appendResult18_g114 );
				float dotResult16_g114 = dot( temp_output_20_0_g114 , temp_output_20_0_g114 );
				float ifLocalVar182_g114 = 0;
				if( dotResult16_g114 > 0.0001 )
				ifLocalVar182_g114 = 1.0;
				else if( dotResult16_g114 < 0.0001 )
				ifLocalVar182_g114 = 0.0;
				float ChildMask26_g114 = saturate( ( ifLocalVar182_g114 * 100.0 ) );
				float SelfBendMask34_g114 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g115 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g115 = 0.0;
				else
				ifLocalVar33_g115 = 1.0;
				float ifLocalVar34_g115 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g115 = 0.0;
				else
				ifLocalVar34_g115 = 1.0;
				float3 lerpResult41_g115 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g115 + ifLocalVar34_g115 ));
				float3 WindVector47_g115 = lerpResult41_g115;
				float3 objToWorld6_g116 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g115 = (( objToWorld6_g116 / _WindDirectionMapScale )).xz;
				float2 panner7_g115 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode11_g115 = tex2Dlod( _WindDirectionMap, float4( panner7_g115, 0, 0.0) );
				float2 RotationMapLF16_g115 = (tex2DNode11_g115).rg;
				float2 break35_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g115 = (float3(( break35_g115.x * -1.0 ) , 0.0 , break35_g115.y));
				float2 panner9_g115 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode10_g115 = tex2Dlod( _WindDirectionMap, float4( panner9_g115, 0, 0.0) );
				float2 RotationMapHF17_g115 = (tex2DNode10_g115).ba;
				float2 break36_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g115 = (float3(( break36_g115.x * -1.0 ) , 0.0 , break36_g115.y));
				float3 lerpResult48_g115 = lerp( appendResult42_g115 , appendResult43_g115 , _HFRotationMapInfluence);
				float3 lerpResult51_g115 = lerp( WindVector47_g115 , lerpResult48_g115 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g115 = lerpResult51_g115;
				#else
				float3 staticSwitch55_g115 = WindVector47_g115;
				#endif
				float3 worldToObjDir52_g115 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g115, 0.0 ) ).xyz;
				float3 WindVector226_g114 = worldToObjDir52_g115;
				float3 appendResult11_g114 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g114 = ( 0.001 * appendResult11_g114 );
				float3 SelfPivot28_g114 = temp_output_19_0_g114;
				float3 objToWorld54_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g114 * 1.0 ) + ( objToWorld54_g114 / -2.0 ) )).z).xx;
				float2 panner48_g114 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g114 = snoise( panner48_g114*_ChildWindMapScale );
				simplePerlin2D53_g114 = simplePerlin2D53_g114*0.5 + 0.5;
				float ChildRotation43_g114 = radians( ( simplePerlin2D53_g114 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g114 = RotateAroundAxis( SelfPivot28_g114, input.positionOS.xyz, normalize( WindVector226_g114 ), ChildRotation43_g114 );
				float3 ChildRotationResult119_g114 = ( ( ChildMask26_g114 * SelfBendMask34_g114 ) * ( rotatedValue81_g114 - input.positionOS.xyz ) );
				float temp_output_113_0_g114 = saturate( ( 4.0 * pow( SelfBendMask34_g114 , _BendingMaskStrength1 ) ) );
				float dotResult9_g114 = dot( temp_output_19_0_g114 , temp_output_19_0_g114 );
				float ifLocalVar189_g114 = 0;
				if( dotResult9_g114 > 0.0001 )
				ifLocalVar189_g114 = 1.0;
				else if( dotResult9_g114 < 0.0001 )
				ifLocalVar189_g114 = 0.0;
				float TrunkMask29_g114 = saturate( ( ifLocalVar189_g114 * 1000.0 ) );
				float3 ParentPivot27_g114 = temp_output_20_0_g114;
				float3 lerpResult51_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float2 temp_cast_2 = ((( lerpResult51_g114 / -0.2 )).z).xx;
				float2 panner61_g114 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g114 = snoise( panner61_g114*_ParentWindMapScale );
				simplePerlin2D60_g114 = simplePerlin2D60_g114*0.5 + 0.5;
				float saferPower185_g114 = abs( simplePerlin2D60_g114 );
				float saferPower160_g114 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g114 = saturate( pow( saferPower160_g114 , _MainBendMaskStrength ) );
				float ParentRotation63_g114 = radians( ( pow( saferPower185_g114 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g114 ) );
				float3 lerpResult98_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float3 rotatedValue96_g114 = RotateAroundAxis( lerpResult98_g114, ( ChildRotationResult119_g114 + input.positionOS.xyz ), normalize( WindVector226_g114 ), ParentRotation63_g114 );
				float3 ParentRotationResult131_g114 = ( ChildRotationResult119_g114 + ( ( ( ( ( temp_output_113_0_g114 * ( 1.0 - ChildMask26_g114 ) ) + ChildMask26_g114 ) * TrunkMask29_g114 ) * ( rotatedValue96_g114 - input.positionOS.xyz ) ) * MainBendMask35_g114 ) );
				float3 objToWorld47_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g114 = abs( ( objToWorld47_g114 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g114 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g114 , 2.0 )).xz);
				float simplePerlin2D70_g114 = snoise( panner71_g114*2.0 );
				simplePerlin2D70_g114 = simplePerlin2D70_g114*0.5 + 0.5;
				float MainRotation67_g114 = radians( ( simplePerlin2D70_g114 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g114 = ( ParentRotationResult131_g114 + input.positionOS.xyz );
				float3 rotatedValue121_g114 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g114, normalize( WindVector226_g114 ), MainRotation67_g114 );
				float temp_output_148_0_g114 = pow( MainBendMask35_g114 , 5.0 );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch419 = ( ( ParentRotationResult131_g114 + ( ( rotatedValue121_g114 - temp_output_125_0_g114 ) * temp_output_148_0_g114 ) ) * _WindOverallStrength * TF_WIND_STRENGTH );
				#else
				float3 staticSwitch419 = temp_cast_0;
				#endif
				
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord2.xyz = ase_normalWS;
				float3 ase_tangentWS = TransformObjectToWorldDir( input.tangentOS.xyz );
				output.ase_texcoord3.xyz = ase_tangentWS;
				float ase_tangentSign = input.tangentOS.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord4.xyz = ase_bitangentWS;
				
				output.ase_texcoord1.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
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

				float3 vertexValue = staticSwitch419;

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
				float4 ase_texcoord : TEXCOORD0;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
				output.ase_texcoord1 = input.ase_texcoord1;
				output.ase_texcoord = input.ase_texcoord;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
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

				float2 texCoord62_g151 = input.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g151 = tex2D( _ColorMap, texCoord62_g151 );
				float3 temp_output_12_0_g154 = tex2DNode1_g151.rgb;
				float dotResult28_g154 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g154 );
				float3 temp_cast_1 = (dotResult28_g154).xxx;
				float temp_output_21_0_g154 = _BaseColorSaturation;
				float3 lerpResult31_g154 = lerp( temp_cast_1 , temp_output_12_0_g154 , temp_output_21_0_g154);
				float3 hsvTorgb14_g153 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g154 * _BaseColorBrightness ) , 0.0 )) * _Color ).rgb );
				float3 hsvTorgb13_g153 = HSVToRGB( float3(( hsvTorgb14_g153.x + 1.0 ),hsvTorgb14_g153.y,hsvTorgb14_g153.z) );
				float3 FinalColor385 = hsvTorgb13_g153;
				float3 temp_output_1_0_g135 = FinalColor385;
				float temp_output_50_0_g128 = _LayerTiling;
				float2 temp_cast_9 = (temp_output_50_0_g128).xx;
				float temp_output_51_0_g128 = 1.0;
				float3 ase_normalWS = input.ase_texcoord2.xyz;
				float4 triplanar49_g128 = TriplanarSampling49_g128( _LayerAlbedo, PositionWS, ase_normalWS, temp_output_51_0_g128, temp_cast_9, 1.0, 0 );
				float4 LayerColor457 = ( _LayerColor * triplanar49_g128 );
				float3 unpack7_g151 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g151 ), _NormalIntensity );
				unpack7_g151.z = lerp( 1, unpack7_g151.z, saturate(_NormalIntensity) );
				float3 FinalNormal387 = unpack7_g151;
				float3 ase_tangentWS = input.ase_texcoord3.xyz;
				float3 ase_bitangentWS = input.ase_texcoord4.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal5_g136 = FinalNormal387;
				float3 worldNormal5_g136 = normalize( float3( dot( tanToWorld0, tanNormal5_g136 ), dot( tanToWorld1, tanNormal5_g136 ), dot( tanToWorld2, tanNormal5_g136 ) ) );
				float2 temp_cast_10 = (temp_output_50_0_g128).xx;
				float4 triplanar31_g129 = TriplanarSampling31_g129( _LayerMask, PositionWS, ase_normalWS, temp_output_51_0_g128, temp_cast_10, 1.0, 0 );
				float LayerHeight469 = triplanar31_g129.z;
				float lerpResult32_g136 = lerp( 0.0 , LayerHeight469 , _LayerHeightMapInfluence);
				float2 uv_MaskMapMAOS = input.ase_texcoord1.xy * _MaskMapMAOS_ST.xy + _MaskMapMAOS_ST.zw;
				float4 tex2DNode1_g152 = tex2D( _MaskMapMAOS, uv_MaskMapMAOS );
				float AmbientOcclusion389 = saturate( ( tex2DNode1_g152.g - ( ( 1.0 - _AOIntensity ) * -1.0 ) ) );
				float FinalAmbientOcclusion403 = saturate( ( saturate( ( ( 1.0 - _VertexAOIntensity ) + pow( input.ase_color.r , 2.0 ) ) ) * AmbientOcclusion389 ) );
				float lerpResult27_g136 = lerp( 0.0 , ( 1.0 - FinalAmbientOcclusion403 ) , _BlendMaskAOInfluence);
				float BlendMask37_g136 = saturate( ( lerpResult32_g136 + lerpResult27_g136 ) );
				float temp_output_9_0_g138 = saturate( pow( max( ( saturate( ( worldNormal5_g136.y + _ProjectionMaskOffset ) ) * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_36_0_g136 = temp_output_9_0_g138;
				#if defined( _VERTEXCOLORMASK_RED )
				float staticSwitch17_g136 = input.ase_color.r;
				#elif defined( _VERTEXCOLORMASK_GREEN )
				float staticSwitch17_g136 = input.ase_color.g;
				#elif defined( _VERTEXCOLORMASK_BLUE )
				float staticSwitch17_g136 = input.ase_color.b;
				#elif defined( _VERTEXCOLORMASK_ALPHA )
				float staticSwitch17_g136 = input.ase_color.a;
				#else
				float staticSwitch17_g136 = input.ase_color.r;
				#endif
				float temp_output_9_0_g137 = saturate( pow( max( ( staticSwitch17_g136 * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_14_0_g136 = temp_output_9_0_g137;
				#if defined( _LAYERMASKMODE_TOPPROJECTION )
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#elif defined( _LAYERMASKMODE_VERTEXCOLOR )
				float staticSwitch18_g136 = temp_output_14_0_g136;
				#elif defined( _LAYERMASKMODE_COMBINED )
				float staticSwitch18_g136 = saturate( ( temp_output_36_0_g136 + temp_output_14_0_g136 ) );
				#else
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#endif
				float temp_output_11_0_g135 = staticSwitch18_g136;
				float4 lerpResult12_g135 = lerp( float4( temp_output_1_0_g135 , 0.0 ) , LayerColor457 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float4 staticSwitch38_g135 = lerpResult12_g135;
				#else
				float4 staticSwitch38_g135 = float4( temp_output_1_0_g135 , 0.0 );
				#endif
				

				float3 BaseColor = staticSwitch38_g135.xyz;
				float Alpha = 1;
				float AlphaClipThreshold = 0.5;

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

			

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define _EMISSION
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
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _USELAYER_ON
			#pragma shader_feature_local _LAYERMASKMODE_TOPPROJECTION _LAYERMASKMODE_VERTEXCOLOR _LAYERMASKMODE_COMBINED
			#pragma shader_feature_local _VERTEXCOLORMASK_RED _VERTEXCOLORMASK_GREEN _VERTEXCOLORMASK_BLUE _VERTEXCOLORMASK_ALPHA
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
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				float3 normalWS : TEXCOORD1;
				half4 tangentWS : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _MaskMapMAOS_ST;
			float4 _LayerColor;
			float4 _Color;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _Smoothness;
			float _LayerNormalIntensity;
			float _BlendFalloff;
			float _BlendFactor;
			float _BlendMaskAOInfluence;
			float _AOIntensity;
			float _VertexAOIntensity;
			float _LayerHeightMapInfluence;
			float _ProjectionMaskOffset;
			float _NormalIntensity;
			float _LayerTiling;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindOverallStrength;
			float _MainWindStrength;
			float _MainWindScale;
			float _MainBendMaskStrength;
			float _ParentWindStrength;
			float _ParentWindMapScale;
			float _BendingMaskStrength1;
			float _ChildWindStrength;
			float _ChildWindMapScale;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _WindDirectionMapScale;
			float _LayerSmoothness;
			float _LayerAOStrength;
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
			sampler2D _LayerNormal;
			sampler2D _LayerMask;
			sampler2D _MaskMapMAOS;


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
			
			inline float3 TriplanarSampling52_g128( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				xNorm.xyz  = half3( UnpackNormalScale( xNorm, normalScale.y ).xy * float2(  nsign.x, 1.0 ) + worldNormal.zy, worldNormal.x ).zyx;
				yNorm.xyz  = half3( UnpackNormalScale( yNorm, normalScale.x ).xy * float2(  nsign.y, 1.0 ) + worldNormal.xz, worldNormal.y ).xzy;
				zNorm.xyz  = half3( UnpackNormalScale( zNorm, normalScale.y ).xy * float2( -nsign.z, 1.0 ) + worldNormal.xy, worldNormal.z ).xyz;
				return normalize( xNorm.xyz * projNormal.x + yNorm.xyz * projNormal.y + zNorm.xyz * projNormal.z );
			}
			
			inline float4 TriplanarSampling31_g129( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 appendResult18_g114 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g114 = ( 0.001 * appendResult18_g114 );
				float dotResult16_g114 = dot( temp_output_20_0_g114 , temp_output_20_0_g114 );
				float ifLocalVar182_g114 = 0;
				if( dotResult16_g114 > 0.0001 )
				ifLocalVar182_g114 = 1.0;
				else if( dotResult16_g114 < 0.0001 )
				ifLocalVar182_g114 = 0.0;
				float ChildMask26_g114 = saturate( ( ifLocalVar182_g114 * 100.0 ) );
				float SelfBendMask34_g114 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g115 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g115 = 0.0;
				else
				ifLocalVar33_g115 = 1.0;
				float ifLocalVar34_g115 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g115 = 0.0;
				else
				ifLocalVar34_g115 = 1.0;
				float3 lerpResult41_g115 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g115 + ifLocalVar34_g115 ));
				float3 WindVector47_g115 = lerpResult41_g115;
				float3 objToWorld6_g116 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g115 = (( objToWorld6_g116 / _WindDirectionMapScale )).xz;
				float2 panner7_g115 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode11_g115 = tex2Dlod( _WindDirectionMap, float4( panner7_g115, 0, 0.0) );
				float2 RotationMapLF16_g115 = (tex2DNode11_g115).rg;
				float2 break35_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g115 = (float3(( break35_g115.x * -1.0 ) , 0.0 , break35_g115.y));
				float2 panner9_g115 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode10_g115 = tex2Dlod( _WindDirectionMap, float4( panner9_g115, 0, 0.0) );
				float2 RotationMapHF17_g115 = (tex2DNode10_g115).ba;
				float2 break36_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g115 = (float3(( break36_g115.x * -1.0 ) , 0.0 , break36_g115.y));
				float3 lerpResult48_g115 = lerp( appendResult42_g115 , appendResult43_g115 , _HFRotationMapInfluence);
				float3 lerpResult51_g115 = lerp( WindVector47_g115 , lerpResult48_g115 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g115 = lerpResult51_g115;
				#else
				float3 staticSwitch55_g115 = WindVector47_g115;
				#endif
				float3 worldToObjDir52_g115 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g115, 0.0 ) ).xyz;
				float3 WindVector226_g114 = worldToObjDir52_g115;
				float3 appendResult11_g114 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g114 = ( 0.001 * appendResult11_g114 );
				float3 SelfPivot28_g114 = temp_output_19_0_g114;
				float3 objToWorld54_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g114 * 1.0 ) + ( objToWorld54_g114 / -2.0 ) )).z).xx;
				float2 panner48_g114 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g114 = snoise( panner48_g114*_ChildWindMapScale );
				simplePerlin2D53_g114 = simplePerlin2D53_g114*0.5 + 0.5;
				float ChildRotation43_g114 = radians( ( simplePerlin2D53_g114 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g114 = RotateAroundAxis( SelfPivot28_g114, input.positionOS.xyz, normalize( WindVector226_g114 ), ChildRotation43_g114 );
				float3 ChildRotationResult119_g114 = ( ( ChildMask26_g114 * SelfBendMask34_g114 ) * ( rotatedValue81_g114 - input.positionOS.xyz ) );
				float temp_output_113_0_g114 = saturate( ( 4.0 * pow( SelfBendMask34_g114 , _BendingMaskStrength1 ) ) );
				float dotResult9_g114 = dot( temp_output_19_0_g114 , temp_output_19_0_g114 );
				float ifLocalVar189_g114 = 0;
				if( dotResult9_g114 > 0.0001 )
				ifLocalVar189_g114 = 1.0;
				else if( dotResult9_g114 < 0.0001 )
				ifLocalVar189_g114 = 0.0;
				float TrunkMask29_g114 = saturate( ( ifLocalVar189_g114 * 1000.0 ) );
				float3 ParentPivot27_g114 = temp_output_20_0_g114;
				float3 lerpResult51_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float2 temp_cast_2 = ((( lerpResult51_g114 / -0.2 )).z).xx;
				float2 panner61_g114 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g114 = snoise( panner61_g114*_ParentWindMapScale );
				simplePerlin2D60_g114 = simplePerlin2D60_g114*0.5 + 0.5;
				float saferPower185_g114 = abs( simplePerlin2D60_g114 );
				float saferPower160_g114 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g114 = saturate( pow( saferPower160_g114 , _MainBendMaskStrength ) );
				float ParentRotation63_g114 = radians( ( pow( saferPower185_g114 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g114 ) );
				float3 lerpResult98_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float3 rotatedValue96_g114 = RotateAroundAxis( lerpResult98_g114, ( ChildRotationResult119_g114 + input.positionOS.xyz ), normalize( WindVector226_g114 ), ParentRotation63_g114 );
				float3 ParentRotationResult131_g114 = ( ChildRotationResult119_g114 + ( ( ( ( ( temp_output_113_0_g114 * ( 1.0 - ChildMask26_g114 ) ) + ChildMask26_g114 ) * TrunkMask29_g114 ) * ( rotatedValue96_g114 - input.positionOS.xyz ) ) * MainBendMask35_g114 ) );
				float3 objToWorld47_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g114 = abs( ( objToWorld47_g114 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g114 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g114 , 2.0 )).xz);
				float simplePerlin2D70_g114 = snoise( panner71_g114*2.0 );
				simplePerlin2D70_g114 = simplePerlin2D70_g114*0.5 + 0.5;
				float MainRotation67_g114 = radians( ( simplePerlin2D70_g114 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g114 = ( ParentRotationResult131_g114 + input.positionOS.xyz );
				float3 rotatedValue121_g114 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g114, normalize( WindVector226_g114 ), MainRotation67_g114 );
				float temp_output_148_0_g114 = pow( MainBendMask35_g114 , 5.0 );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch419 = ( ( ParentRotationResult131_g114 + ( ( rotatedValue121_g114 - temp_output_125_0_g114 ) * temp_output_148_0_g114 ) ) * _WindOverallStrength * TF_WIND_STRENGTH );
				#else
				float3 staticSwitch419 = temp_cast_0;
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

				float3 vertexValue = staticSwitch419;

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
				float4 ase_texcoord : TEXCOORD0;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord3 = input.ase_texcoord3;
				output.ase_texcoord4 = input.ase_texcoord4;
				output.ase_texcoord1 = input.ase_texcoord1;
				output.ase_texcoord = input.ase_texcoord;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				output.ase_texcoord4 = patch[0].ase_texcoord4 * bary.x + patch[1].ase_texcoord4 * bary.y + patch[2].ase_texcoord4 * bary.z;
				output.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
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

			void frag(	PackedVaryings input
						, out half4 outNormalWS : SV_Target0
						#if defined( ASE_DEPTH_WRITE_ON )
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						#ifdef _WRITE_RENDERING_LAYERS
						, out float4 outRenderingLayers : SV_Target1
						#endif
						 )
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

				float2 texCoord62_g151 = input.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack7_g151 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g151 ), _NormalIntensity );
				unpack7_g151.z = lerp( 1, unpack7_g151.z, saturate(_NormalIntensity) );
				float3 FinalNormal387 = unpack7_g151;
				float3 temp_output_2_0_g135 = FinalNormal387;
				float temp_output_50_0_g128 = _LayerTiling;
				float2 temp_cast_0 = (temp_output_50_0_g128).xx;
				float temp_output_51_0_g128 = 1.0;
				float3x3 ase_worldToTangent = float3x3( TangentWS, BitangentWS, NormalWS );
				float3 triplanar52_g128 = TriplanarSampling52_g128( _LayerNormal, PositionWS, NormalWS, temp_output_51_0_g128, temp_cast_0, _LayerNormalIntensity, 0 );
				float3 tanTriplanarNormal52_g128 = mul( ase_worldToTangent, triplanar52_g128 );
				float3 LayerNormal456 = tanTriplanarNormal52_g128;
				float3 tanToWorld0 = float3( TangentWS.x, BitangentWS.x, NormalWS.x );
				float3 tanToWorld1 = float3( TangentWS.y, BitangentWS.y, NormalWS.y );
				float3 tanToWorld2 = float3( TangentWS.z, BitangentWS.z, NormalWS.z );
				float3 tanNormal5_g136 = FinalNormal387;
				float3 worldNormal5_g136 = normalize( float3( dot( tanToWorld0, tanNormal5_g136 ), dot( tanToWorld1, tanNormal5_g136 ), dot( tanToWorld2, tanNormal5_g136 ) ) );
				float2 temp_cast_1 = (temp_output_50_0_g128).xx;
				float4 triplanar31_g129 = TriplanarSampling31_g129( _LayerMask, PositionWS, NormalWS, temp_output_51_0_g128, temp_cast_1, 1.0, 0 );
				float LayerHeight469 = triplanar31_g129.z;
				float lerpResult32_g136 = lerp( 0.0 , LayerHeight469 , _LayerHeightMapInfluence);
				float2 uv_MaskMapMAOS = input.ase_texcoord3.xy * _MaskMapMAOS_ST.xy + _MaskMapMAOS_ST.zw;
				float4 tex2DNode1_g152 = tex2D( _MaskMapMAOS, uv_MaskMapMAOS );
				float AmbientOcclusion389 = saturate( ( tex2DNode1_g152.g - ( ( 1.0 - _AOIntensity ) * -1.0 ) ) );
				float FinalAmbientOcclusion403 = saturate( ( saturate( ( ( 1.0 - _VertexAOIntensity ) + pow( input.ase_color.r , 2.0 ) ) ) * AmbientOcclusion389 ) );
				float lerpResult27_g136 = lerp( 0.0 , ( 1.0 - FinalAmbientOcclusion403 ) , _BlendMaskAOInfluence);
				float BlendMask37_g136 = saturate( ( lerpResult32_g136 + lerpResult27_g136 ) );
				float temp_output_9_0_g138 = saturate( pow( max( ( saturate( ( worldNormal5_g136.y + _ProjectionMaskOffset ) ) * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_36_0_g136 = temp_output_9_0_g138;
				#if defined( _VERTEXCOLORMASK_RED )
				float staticSwitch17_g136 = input.ase_color.r;
				#elif defined( _VERTEXCOLORMASK_GREEN )
				float staticSwitch17_g136 = input.ase_color.g;
				#elif defined( _VERTEXCOLORMASK_BLUE )
				float staticSwitch17_g136 = input.ase_color.b;
				#elif defined( _VERTEXCOLORMASK_ALPHA )
				float staticSwitch17_g136 = input.ase_color.a;
				#else
				float staticSwitch17_g136 = input.ase_color.r;
				#endif
				float temp_output_9_0_g137 = saturate( pow( max( ( staticSwitch17_g136 * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_14_0_g136 = temp_output_9_0_g137;
				#if defined( _LAYERMASKMODE_TOPPROJECTION )
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#elif defined( _LAYERMASKMODE_VERTEXCOLOR )
				float staticSwitch18_g136 = temp_output_14_0_g136;
				#elif defined( _LAYERMASKMODE_COMBINED )
				float staticSwitch18_g136 = saturate( ( temp_output_36_0_g136 + temp_output_14_0_g136 ) );
				#else
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#endif
				float temp_output_11_0_g135 = staticSwitch18_g136;
				float3 lerpResult13_g135 = lerp( temp_output_2_0_g135 , LayerNormal456 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float3 staticSwitch39_g135 = lerpResult13_g135;
				#else
				float3 staticSwitch39_g135 = temp_output_2_0_g135;
				#endif
				

				float3 Normal = staticSwitch39_g135;
				float Alpha = 1;
				float AlphaClipThreshold = 0.5;

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
			
			Name "GBuffer"
			Tags { "LightMode"="UniversalGBuffer" }

			Blend One Zero, One Zero
			ZWrite On
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA
			

			HLSLPROGRAM

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma instancing_options renderinglayer
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_VERSION 19900
			#define ASE_SRP_VERSION 140012


			

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

			#if defined(_SPECULAR_SETUP) && defined(ASE_LIGHTING_SIMPLE)
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
			#define ASE_NEEDS_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
			#pragma shader_feature_local _USELAYER_ON
			#pragma shader_feature_local _LAYERMASKMODE_TOPPROJECTION _LAYERMASKMODE_VERTEXCOLOR _LAYERMASKMODE_COMBINED
			#pragma shader_feature_local _VERTEXCOLORMASK_RED _VERTEXCOLORMASK_GREEN _VERTEXCOLORMASK_BLUE _VERTEXCOLORMASK_ALPHA
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
			float4 _MaskMapMAOS_ST;
			float4 _LayerColor;
			float4 _Color;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _Smoothness;
			float _LayerNormalIntensity;
			float _BlendFalloff;
			float _BlendFactor;
			float _BlendMaskAOInfluence;
			float _AOIntensity;
			float _VertexAOIntensity;
			float _LayerHeightMapInfluence;
			float _ProjectionMaskOffset;
			float _NormalIntensity;
			float _LayerTiling;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindOverallStrength;
			float _MainWindStrength;
			float _MainWindScale;
			float _MainBendMaskStrength;
			float _ParentWindStrength;
			float _ParentWindMapScale;
			float _BendingMaskStrength1;
			float _ChildWindStrength;
			float _ChildWindMapScale;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _WindDirectionMapScale;
			float _LayerSmoothness;
			float _LayerAOStrength;
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
			sampler2D _LayerAlbedo;
			sampler2D _NormalMap;
			sampler2D _LayerMask;
			sampler2D _MaskMapMAOS;
			sampler2D _LayerNormal;
			sampler2D _EmissiveMap;


			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityGBuffer.hlsl"

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
			inline float4 TriplanarSampling49_g128( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			
			inline float4 TriplanarSampling31_g129( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			
			inline float3 TriplanarSampling52_g128( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				xNorm.xyz  = half3( UnpackNormalScale( xNorm, normalScale.y ).xy * float2(  nsign.x, 1.0 ) + worldNormal.zy, worldNormal.x ).zyx;
				yNorm.xyz  = half3( UnpackNormalScale( yNorm, normalScale.x ).xy * float2(  nsign.y, 1.0 ) + worldNormal.xz, worldNormal.y ).xzy;
				zNorm.xyz  = half3( UnpackNormalScale( zNorm, normalScale.y ).xy * float2( -nsign.z, 1.0 ) + worldNormal.xy, worldNormal.z ).xyz;
				return normalize( xNorm.xyz * projNormal.x + yNorm.xyz * projNormal.y + zNorm.xyz * projNormal.z );
			}
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 appendResult18_g114 = (float3(( -1.0 * input.texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g114 = ( 0.001 * appendResult18_g114 );
				float dotResult16_g114 = dot( temp_output_20_0_g114 , temp_output_20_0_g114 );
				float ifLocalVar182_g114 = 0;
				if( dotResult16_g114 > 0.0001 )
				ifLocalVar182_g114 = 1.0;
				else if( dotResult16_g114 < 0.0001 )
				ifLocalVar182_g114 = 0.0;
				float ChildMask26_g114 = saturate( ( ifLocalVar182_g114 * 100.0 ) );
				float SelfBendMask34_g114 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g115 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g115 = 0.0;
				else
				ifLocalVar33_g115 = 1.0;
				float ifLocalVar34_g115 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g115 = 0.0;
				else
				ifLocalVar34_g115 = 1.0;
				float3 lerpResult41_g115 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g115 + ifLocalVar34_g115 ));
				float3 WindVector47_g115 = lerpResult41_g115;
				float3 objToWorld6_g116 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g115 = (( objToWorld6_g116 / _WindDirectionMapScale )).xz;
				float2 panner7_g115 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode11_g115 = tex2Dlod( _WindDirectionMap, float4( panner7_g115, 0, 0.0) );
				float2 RotationMapLF16_g115 = (tex2DNode11_g115).rg;
				float2 break35_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g115 = (float3(( break35_g115.x * -1.0 ) , 0.0 , break35_g115.y));
				float2 panner9_g115 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode10_g115 = tex2Dlod( _WindDirectionMap, float4( panner9_g115, 0, 0.0) );
				float2 RotationMapHF17_g115 = (tex2DNode10_g115).ba;
				float2 break36_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g115 = (float3(( break36_g115.x * -1.0 ) , 0.0 , break36_g115.y));
				float3 lerpResult48_g115 = lerp( appendResult42_g115 , appendResult43_g115 , _HFRotationMapInfluence);
				float3 lerpResult51_g115 = lerp( WindVector47_g115 , lerpResult48_g115 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g115 = lerpResult51_g115;
				#else
				float3 staticSwitch55_g115 = WindVector47_g115;
				#endif
				float3 worldToObjDir52_g115 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g115, 0.0 ) ).xyz;
				float3 WindVector226_g114 = worldToObjDir52_g115;
				float3 appendResult11_g114 = (float3(( -1.0 * input.texcoord1.x ) , input.texcoord2.x , ( -1.0 * input.texcoord1.y )));
				float3 temp_output_19_0_g114 = ( 0.001 * appendResult11_g114 );
				float3 SelfPivot28_g114 = temp_output_19_0_g114;
				float3 objToWorld54_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g114 * 1.0 ) + ( objToWorld54_g114 / -2.0 ) )).z).xx;
				float2 panner48_g114 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g114 = snoise( panner48_g114*_ChildWindMapScale );
				simplePerlin2D53_g114 = simplePerlin2D53_g114*0.5 + 0.5;
				float ChildRotation43_g114 = radians( ( simplePerlin2D53_g114 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g114 = RotateAroundAxis( SelfPivot28_g114, input.positionOS.xyz, normalize( WindVector226_g114 ), ChildRotation43_g114 );
				float3 ChildRotationResult119_g114 = ( ( ChildMask26_g114 * SelfBendMask34_g114 ) * ( rotatedValue81_g114 - input.positionOS.xyz ) );
				float temp_output_113_0_g114 = saturate( ( 4.0 * pow( SelfBendMask34_g114 , _BendingMaskStrength1 ) ) );
				float dotResult9_g114 = dot( temp_output_19_0_g114 , temp_output_19_0_g114 );
				float ifLocalVar189_g114 = 0;
				if( dotResult9_g114 > 0.0001 )
				ifLocalVar189_g114 = 1.0;
				else if( dotResult9_g114 < 0.0001 )
				ifLocalVar189_g114 = 0.0;
				float TrunkMask29_g114 = saturate( ( ifLocalVar189_g114 * 1000.0 ) );
				float3 ParentPivot27_g114 = temp_output_20_0_g114;
				float3 lerpResult51_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float2 temp_cast_2 = ((( lerpResult51_g114 / -0.2 )).z).xx;
				float2 panner61_g114 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g114 = snoise( panner61_g114*_ParentWindMapScale );
				simplePerlin2D60_g114 = simplePerlin2D60_g114*0.5 + 0.5;
				float saferPower185_g114 = abs( simplePerlin2D60_g114 );
				float saferPower160_g114 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g114 = saturate( pow( saferPower160_g114 , _MainBendMaskStrength ) );
				float ParentRotation63_g114 = radians( ( pow( saferPower185_g114 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g114 ) );
				float3 lerpResult98_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float3 rotatedValue96_g114 = RotateAroundAxis( lerpResult98_g114, ( ChildRotationResult119_g114 + input.positionOS.xyz ), normalize( WindVector226_g114 ), ParentRotation63_g114 );
				float3 ParentRotationResult131_g114 = ( ChildRotationResult119_g114 + ( ( ( ( ( temp_output_113_0_g114 * ( 1.0 - ChildMask26_g114 ) ) + ChildMask26_g114 ) * TrunkMask29_g114 ) * ( rotatedValue96_g114 - input.positionOS.xyz ) ) * MainBendMask35_g114 ) );
				float3 objToWorld47_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g114 = abs( ( objToWorld47_g114 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g114 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g114 , 2.0 )).xz);
				float simplePerlin2D70_g114 = snoise( panner71_g114*2.0 );
				simplePerlin2D70_g114 = simplePerlin2D70_g114*0.5 + 0.5;
				float MainRotation67_g114 = radians( ( simplePerlin2D70_g114 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g114 = ( ParentRotationResult131_g114 + input.positionOS.xyz );
				float3 rotatedValue121_g114 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g114, normalize( WindVector226_g114 ), MainRotation67_g114 );
				float temp_output_148_0_g114 = pow( MainBendMask35_g114 , 5.0 );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch419 = ( ( ParentRotationResult131_g114 + ( ( rotatedValue121_g114 - temp_output_125_0_g114 ) * temp_output_148_0_g114 ) ) * _WindOverallStrength * TF_WIND_STRENGTH );
				#else
				float3 staticSwitch419 = temp_cast_0;
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

				float3 vertexValue = staticSwitch419;

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
						// @diogo: no fog applied in GBuffer
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

			FragmentOutput frag ( PackedVaryings input
								#if defined( ASE_DEPTH_WRITE_ON )
								,out float outputDepth : ASE_SV_DEPTH
								#endif
								 )
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

				float2 texCoord62_g151 = input.ase_texcoord6.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g151 = tex2D( _ColorMap, texCoord62_g151 );
				float3 temp_output_12_0_g154 = tex2DNode1_g151.rgb;
				float dotResult28_g154 = dot( float3( 0.2126729, 0.7151522, 0.072175 ) , temp_output_12_0_g154 );
				float3 temp_cast_1 = (dotResult28_g154).xxx;
				float temp_output_21_0_g154 = _BaseColorSaturation;
				float3 lerpResult31_g154 = lerp( temp_cast_1 , temp_output_12_0_g154 , temp_output_21_0_g154);
				float3 hsvTorgb14_g153 = RGBToHSV( ( CalculateContrast(_BaseColorContrast,float4( ( lerpResult31_g154 * _BaseColorBrightness ) , 0.0 )) * _Color ).rgb );
				float3 hsvTorgb13_g153 = HSVToRGB( float3(( hsvTorgb14_g153.x + 1.0 ),hsvTorgb14_g153.y,hsvTorgb14_g153.z) );
				float3 FinalColor385 = hsvTorgb13_g153;
				float3 temp_output_1_0_g135 = FinalColor385;
				float temp_output_50_0_g128 = _LayerTiling;
				float2 temp_cast_9 = (temp_output_50_0_g128).xx;
				float temp_output_51_0_g128 = 1.0;
				float4 triplanar49_g128 = TriplanarSampling49_g128( _LayerAlbedo, PositionWS, NormalWS, temp_output_51_0_g128, temp_cast_9, 1.0, 0 );
				float4 LayerColor457 = ( _LayerColor * triplanar49_g128 );
				float3 unpack7_g151 = UnpackNormalScale( tex2D( _NormalMap, texCoord62_g151 ), _NormalIntensity );
				unpack7_g151.z = lerp( 1, unpack7_g151.z, saturate(_NormalIntensity) );
				float3 FinalNormal387 = unpack7_g151;
				float3 tanToWorld0 = float3( TangentWS.x, BitangentWS.x, NormalWS.x );
				float3 tanToWorld1 = float3( TangentWS.y, BitangentWS.y, NormalWS.y );
				float3 tanToWorld2 = float3( TangentWS.z, BitangentWS.z, NormalWS.z );
				float3 tanNormal5_g136 = FinalNormal387;
				float3 worldNormal5_g136 = normalize( float3( dot( tanToWorld0, tanNormal5_g136 ), dot( tanToWorld1, tanNormal5_g136 ), dot( tanToWorld2, tanNormal5_g136 ) ) );
				float2 temp_cast_10 = (temp_output_50_0_g128).xx;
				float4 triplanar31_g129 = TriplanarSampling31_g129( _LayerMask, PositionWS, NormalWS, temp_output_51_0_g128, temp_cast_10, 1.0, 0 );
				float LayerHeight469 = triplanar31_g129.z;
				float lerpResult32_g136 = lerp( 0.0 , LayerHeight469 , _LayerHeightMapInfluence);
				float2 uv_MaskMapMAOS = input.ase_texcoord6.xy * _MaskMapMAOS_ST.xy + _MaskMapMAOS_ST.zw;
				float4 tex2DNode1_g152 = tex2D( _MaskMapMAOS, uv_MaskMapMAOS );
				float AmbientOcclusion389 = saturate( ( tex2DNode1_g152.g - ( ( 1.0 - _AOIntensity ) * -1.0 ) ) );
				float FinalAmbientOcclusion403 = saturate( ( saturate( ( ( 1.0 - _VertexAOIntensity ) + pow( input.ase_color.r , 2.0 ) ) ) * AmbientOcclusion389 ) );
				float lerpResult27_g136 = lerp( 0.0 , ( 1.0 - FinalAmbientOcclusion403 ) , _BlendMaskAOInfluence);
				float BlendMask37_g136 = saturate( ( lerpResult32_g136 + lerpResult27_g136 ) );
				float temp_output_9_0_g138 = saturate( pow( max( ( saturate( ( worldNormal5_g136.y + _ProjectionMaskOffset ) ) * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_36_0_g136 = temp_output_9_0_g138;
				#if defined( _VERTEXCOLORMASK_RED )
				float staticSwitch17_g136 = input.ase_color.r;
				#elif defined( _VERTEXCOLORMASK_GREEN )
				float staticSwitch17_g136 = input.ase_color.g;
				#elif defined( _VERTEXCOLORMASK_BLUE )
				float staticSwitch17_g136 = input.ase_color.b;
				#elif defined( _VERTEXCOLORMASK_ALPHA )
				float staticSwitch17_g136 = input.ase_color.a;
				#else
				float staticSwitch17_g136 = input.ase_color.r;
				#endif
				float temp_output_9_0_g137 = saturate( pow( max( ( staticSwitch17_g136 * BlendMask37_g136 * ( 1.0 + _BlendFactor ) ) , 0.0 ) , _BlendFalloff ) );
				float temp_output_14_0_g136 = temp_output_9_0_g137;
				#if defined( _LAYERMASKMODE_TOPPROJECTION )
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#elif defined( _LAYERMASKMODE_VERTEXCOLOR )
				float staticSwitch18_g136 = temp_output_14_0_g136;
				#elif defined( _LAYERMASKMODE_COMBINED )
				float staticSwitch18_g136 = saturate( ( temp_output_36_0_g136 + temp_output_14_0_g136 ) );
				#else
				float staticSwitch18_g136 = temp_output_36_0_g136;
				#endif
				float temp_output_11_0_g135 = staticSwitch18_g136;
				float4 lerpResult12_g135 = lerp( float4( temp_output_1_0_g135 , 0.0 ) , LayerColor457 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float4 staticSwitch38_g135 = lerpResult12_g135;
				#else
				float4 staticSwitch38_g135 = float4( temp_output_1_0_g135 , 0.0 );
				#endif
				
				float3 temp_output_2_0_g135 = FinalNormal387;
				float2 temp_cast_12 = (temp_output_50_0_g128).xx;
				float3x3 ase_worldToTangent = float3x3( TangentWS, BitangentWS, NormalWS );
				float3 triplanar52_g128 = TriplanarSampling52_g128( _LayerNormal, PositionWS, NormalWS, temp_output_51_0_g128, temp_cast_12, _LayerNormalIntensity, 0 );
				float3 tanTriplanarNormal52_g128 = mul( ase_worldToTangent, triplanar52_g128 );
				float3 LayerNormal456 = tanTriplanarNormal52_g128;
				float3 lerpResult13_g135 = lerp( temp_output_2_0_g135 , LayerNormal456 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float3 staticSwitch39_g135 = lerpResult13_g135;
				#else
				float3 staticSwitch39_g135 = temp_output_2_0_g135;
				#endif
				
				float Smoothness388 = ( tex2DNode1_g152.a * _Smoothness );
				float temp_output_4_0_g135 = Smoothness388;
				float LayerSmoothness454 = ( triplanar31_g129.a * _LayerSmoothness );
				float lerpResult15_g135 = lerp( temp_output_4_0_g135 , LayerSmoothness454 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float staticSwitch41_g135 = lerpResult15_g135;
				#else
				float staticSwitch41_g135 = temp_output_4_0_g135;
				#endif
				
				float temp_output_5_0_g135 = AmbientOcclusion389;
				float LayerAmbientOcclusion466 = saturate( ( triplanar31_g129.g - ( ( 1.0 - _LayerAOStrength ) * -1.0 ) ) );
				float lerpResult22_g135 = lerp( temp_output_5_0_g135 , LayerAmbientOcclusion466 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float staticSwitch43_g135 = lerpResult22_g135;
				#else
				float staticSwitch43_g135 = temp_output_5_0_g135;
				#endif
				
				float4 color406 = IsGammaSpace() ? float4( 1, 1, 1, 0 ) : float4( 1, 1, 1, 0 );
				float4 Emissive420 = ( tex2D( _EmissiveMap, texCoord62_g151 ) * color406 );
				float4 temp_output_33_0_g135 = Emissive420;
				float4 temp_cast_13 = (0.0).xxxx;
				float4 lerpResult34_g135 = lerp( temp_output_33_0_g135 , temp_cast_13 , temp_output_11_0_g135);
				#ifdef _USELAYER_ON
				float4 staticSwitch44_g135 = lerpResult34_g135;
				#else
				float4 staticSwitch44_g135 = temp_output_33_0_g135;
				#endif
				

				float3 BaseColor = staticSwitch38_g135.xyz;
				float3 Normal = staticSwitch39_g135;
				float3 Specular = 0.5;
				float Metallic = 0;
				float Smoothness = staticSwitch41_g135;
				float Occlusion = staticSwitch43_g135;
				float3 Emission = staticSwitch44_g135.rgb;
				float Alpha = 1;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;

				#if defined( ASE_DEPTH_WRITE_ON )
					float DeviceDepth = ClipPos.z;
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
				inputData.shadowCoord = ShadowCoord;

				#ifdef _NORMALMAP
					#if _NORMAL_DROPOFF_TS
						inputData.normalWS = TransformTangentToWorld(Normal, half3x3( TangentWS, BitangentWS, NormalWS ));
					#elif _NORMAL_DROPOFF_OS
						inputData.normalWS = TransformObjectToWorldNormal(Normal);
					#elif _NORMAL_DROPOFF_WS
						inputData.normalWS = Normal;
					#endif
				#else
					inputData.normalWS = NormalWS;
				#endif

				inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
				inputData.viewDirectionWS = SafeNormalize( ViewDirWS );

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
				InitializeBRDFData(BaseColor, Metallic, Specular, Smoothness, Alpha, brdfData);

				Light mainLight = GetMainLight(inputData.shadowCoord, inputData.positionWS, inputData.shadowMask);
				half4 color;
				MixRealtimeAndBakedGI(mainLight, inputData.normalWS, inputData.bakedGI, inputData.shadowMask);
				color.rgb = GlobalIllumination(brdfData, inputData.bakedGI, Occlusion, inputData.positionWS, inputData.normalWS, inputData.viewDirectionWS);
				color.a = Alpha;

				#ifdef ASE_FINAL_COLOR_ALPHA_MULTIPLY
					color.rgb *= color.a;
				#endif

				#if defined( ASE_DEPTH_WRITE_ON )
					outputDepth = DeviceDepth;
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

			

			#pragma multi_compile_local _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#define _EMISSION
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
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
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
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _MaskMapMAOS_ST;
			float4 _LayerColor;
			float4 _Color;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _Smoothness;
			float _LayerNormalIntensity;
			float _BlendFalloff;
			float _BlendFactor;
			float _BlendMaskAOInfluence;
			float _AOIntensity;
			float _VertexAOIntensity;
			float _LayerHeightMapInfluence;
			float _ProjectionMaskOffset;
			float _NormalIntensity;
			float _LayerTiling;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindOverallStrength;
			float _MainWindStrength;
			float _MainWindScale;
			float _MainBendMaskStrength;
			float _ParentWindStrength;
			float _ParentWindMapScale;
			float _BendingMaskStrength1;
			float _ChildWindStrength;
			float _ChildWindMapScale;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _WindDirectionMapScale;
			float _LayerSmoothness;
			float _LayerAOStrength;
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
				float3 appendResult18_g114 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g114 = ( 0.001 * appendResult18_g114 );
				float dotResult16_g114 = dot( temp_output_20_0_g114 , temp_output_20_0_g114 );
				float ifLocalVar182_g114 = 0;
				if( dotResult16_g114 > 0.0001 )
				ifLocalVar182_g114 = 1.0;
				else if( dotResult16_g114 < 0.0001 )
				ifLocalVar182_g114 = 0.0;
				float ChildMask26_g114 = saturate( ( ifLocalVar182_g114 * 100.0 ) );
				float SelfBendMask34_g114 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g115 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g115 = 0.0;
				else
				ifLocalVar33_g115 = 1.0;
				float ifLocalVar34_g115 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g115 = 0.0;
				else
				ifLocalVar34_g115 = 1.0;
				float3 lerpResult41_g115 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g115 + ifLocalVar34_g115 ));
				float3 WindVector47_g115 = lerpResult41_g115;
				float3 objToWorld6_g116 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g115 = (( objToWorld6_g116 / _WindDirectionMapScale )).xz;
				float2 panner7_g115 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode11_g115 = tex2Dlod( _WindDirectionMap, float4( panner7_g115, 0, 0.0) );
				float2 RotationMapLF16_g115 = (tex2DNode11_g115).rg;
				float2 break35_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g115 = (float3(( break35_g115.x * -1.0 ) , 0.0 , break35_g115.y));
				float2 panner9_g115 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode10_g115 = tex2Dlod( _WindDirectionMap, float4( panner9_g115, 0, 0.0) );
				float2 RotationMapHF17_g115 = (tex2DNode10_g115).ba;
				float2 break36_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g115 = (float3(( break36_g115.x * -1.0 ) , 0.0 , break36_g115.y));
				float3 lerpResult48_g115 = lerp( appendResult42_g115 , appendResult43_g115 , _HFRotationMapInfluence);
				float3 lerpResult51_g115 = lerp( WindVector47_g115 , lerpResult48_g115 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g115 = lerpResult51_g115;
				#else
				float3 staticSwitch55_g115 = WindVector47_g115;
				#endif
				float3 worldToObjDir52_g115 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g115, 0.0 ) ).xyz;
				float3 WindVector226_g114 = worldToObjDir52_g115;
				float3 appendResult11_g114 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g114 = ( 0.001 * appendResult11_g114 );
				float3 SelfPivot28_g114 = temp_output_19_0_g114;
				float3 objToWorld54_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g114 * 1.0 ) + ( objToWorld54_g114 / -2.0 ) )).z).xx;
				float2 panner48_g114 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g114 = snoise( panner48_g114*_ChildWindMapScale );
				simplePerlin2D53_g114 = simplePerlin2D53_g114*0.5 + 0.5;
				float ChildRotation43_g114 = radians( ( simplePerlin2D53_g114 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g114 = RotateAroundAxis( SelfPivot28_g114, input.positionOS.xyz, normalize( WindVector226_g114 ), ChildRotation43_g114 );
				float3 ChildRotationResult119_g114 = ( ( ChildMask26_g114 * SelfBendMask34_g114 ) * ( rotatedValue81_g114 - input.positionOS.xyz ) );
				float temp_output_113_0_g114 = saturate( ( 4.0 * pow( SelfBendMask34_g114 , _BendingMaskStrength1 ) ) );
				float dotResult9_g114 = dot( temp_output_19_0_g114 , temp_output_19_0_g114 );
				float ifLocalVar189_g114 = 0;
				if( dotResult9_g114 > 0.0001 )
				ifLocalVar189_g114 = 1.0;
				else if( dotResult9_g114 < 0.0001 )
				ifLocalVar189_g114 = 0.0;
				float TrunkMask29_g114 = saturate( ( ifLocalVar189_g114 * 1000.0 ) );
				float3 ParentPivot27_g114 = temp_output_20_0_g114;
				float3 lerpResult51_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float2 temp_cast_2 = ((( lerpResult51_g114 / -0.2 )).z).xx;
				float2 panner61_g114 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g114 = snoise( panner61_g114*_ParentWindMapScale );
				simplePerlin2D60_g114 = simplePerlin2D60_g114*0.5 + 0.5;
				float saferPower185_g114 = abs( simplePerlin2D60_g114 );
				float saferPower160_g114 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g114 = saturate( pow( saferPower160_g114 , _MainBendMaskStrength ) );
				float ParentRotation63_g114 = radians( ( pow( saferPower185_g114 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g114 ) );
				float3 lerpResult98_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float3 rotatedValue96_g114 = RotateAroundAxis( lerpResult98_g114, ( ChildRotationResult119_g114 + input.positionOS.xyz ), normalize( WindVector226_g114 ), ParentRotation63_g114 );
				float3 ParentRotationResult131_g114 = ( ChildRotationResult119_g114 + ( ( ( ( ( temp_output_113_0_g114 * ( 1.0 - ChildMask26_g114 ) ) + ChildMask26_g114 ) * TrunkMask29_g114 ) * ( rotatedValue96_g114 - input.positionOS.xyz ) ) * MainBendMask35_g114 ) );
				float3 objToWorld47_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g114 = abs( ( objToWorld47_g114 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g114 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g114 , 2.0 )).xz);
				float simplePerlin2D70_g114 = snoise( panner71_g114*2.0 );
				simplePerlin2D70_g114 = simplePerlin2D70_g114*0.5 + 0.5;
				float MainRotation67_g114 = radians( ( simplePerlin2D70_g114 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g114 = ( ParentRotationResult131_g114 + input.positionOS.xyz );
				float3 rotatedValue121_g114 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g114, normalize( WindVector226_g114 ), MainRotation67_g114 );
				float temp_output_148_0_g114 = pow( MainBendMask35_g114 , 5.0 );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch419 = ( ( ParentRotationResult131_g114 + ( ( rotatedValue121_g114 - temp_output_125_0_g114 ) * temp_output_148_0_g114 ) ) * _WindOverallStrength * TF_WIND_STRENGTH );
				#else
				float3 staticSwitch419 = temp_cast_0;
				#endif
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch419;

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

				

				surfaceDescription.Alpha = 1;
				surfaceDescription.AlphaClipThreshold = 0.5;

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
			#define _EMISSION
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
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _USEWINDDIRECTIONMAP_ON
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
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float3 positionWS : TEXCOORD0;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _MaskMapMAOS_ST;
			float4 _LayerColor;
			float4 _Color;
			float2 _LFMapPanningSpeed;
			float2 _HFMapPanningSpeed;
			float _Smoothness;
			float _LayerNormalIntensity;
			float _BlendFalloff;
			float _BlendFactor;
			float _BlendMaskAOInfluence;
			float _AOIntensity;
			float _VertexAOIntensity;
			float _LayerHeightMapInfluence;
			float _ProjectionMaskOffset;
			float _NormalIntensity;
			float _LayerTiling;
			float _BaseColorBrightness;
			float _BaseColorSaturation;
			float _BaseColorContrast;
			float _WindOverallStrength;
			float _MainWindStrength;
			float _MainWindScale;
			float _MainBendMaskStrength;
			float _ParentWindStrength;
			float _ParentWindMapScale;
			float _BendingMaskStrength1;
			float _ChildWindStrength;
			float _ChildWindMapScale;
			float _WindDirectionMapInfluence;
			float _HFRotationMapInfluence;
			float _WindDirectionMapScale;
			float _LayerSmoothness;
			float _LayerAOStrength;
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
				float3 appendResult18_g114 = (float3(( -1.0 * input.ase_texcoord2.y ) , ( -1.0 * input.ase_texcoord3.y ) , input.ase_texcoord3.x));
				float3 temp_output_20_0_g114 = ( 0.001 * appendResult18_g114 );
				float dotResult16_g114 = dot( temp_output_20_0_g114 , temp_output_20_0_g114 );
				float ifLocalVar182_g114 = 0;
				if( dotResult16_g114 > 0.0001 )
				ifLocalVar182_g114 = 1.0;
				else if( dotResult16_g114 < 0.0001 )
				ifLocalVar182_g114 = 0.0;
				float ChildMask26_g114 = saturate( ( ifLocalVar182_g114 * 100.0 ) );
				float SelfBendMask34_g114 = ( 1.0 - input.ase_texcoord4.y );
				float ifLocalVar33_g115 = 0;
				if( TF_WIND_DIRECTION.x == 0.0 )
				ifLocalVar33_g115 = 0.0;
				else
				ifLocalVar33_g115 = 1.0;
				float ifLocalVar34_g115 = 0;
				if( TF_WIND_DIRECTION.z == 0.0 )
				ifLocalVar34_g115 = 0.0;
				else
				ifLocalVar34_g115 = 1.0;
				float3 lerpResult41_g115 = lerp( float3( 0, 0, 1 ) , TF_WIND_DIRECTION , ( ifLocalVar33_g115 + ifLocalVar34_g115 ));
				float3 WindVector47_g115 = lerpResult41_g115;
				float3 objToWorld6_g116 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_output_62_0_g115 = (( objToWorld6_g116 / _WindDirectionMapScale )).xz;
				float2 panner7_g115 = ( _TimeParameters.x * _LFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode11_g115 = tex2Dlod( _WindDirectionMap, float4( panner7_g115, 0, 0.0) );
				float2 RotationMapLF16_g115 = (tex2DNode11_g115).rg;
				float2 break35_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapLF16_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 2.0 );
				float3 appendResult42_g115 = (float3(( break35_g115.x * -1.0 ) , 0.0 , break35_g115.y));
				float2 panner9_g115 = ( _TimeParameters.x * _HFMapPanningSpeed + temp_output_62_0_g115);
				float4 tex2DNode10_g115 = tex2Dlod( _WindDirectionMap, float4( panner9_g115, 0, 0.0) );
				float2 RotationMapHF17_g115 = (tex2DNode10_g115).ba;
				float2 break36_g115 = (  (float2( -0.5,-0.5 ) + ( RotationMapHF17_g115 - float2( 0,0 ) ) * ( float2( 0.5,0.5 ) - float2( -0.5,-0.5 ) ) / ( float2( 1,1 ) - float2( 0,0 ) ) ) * 1.0 );
				float3 appendResult43_g115 = (float3(( break36_g115.x * -1.0 ) , 0.0 , break36_g115.y));
				float3 lerpResult48_g115 = lerp( appendResult42_g115 , appendResult43_g115 , _HFRotationMapInfluence);
				float3 lerpResult51_g115 = lerp( WindVector47_g115 , lerpResult48_g115 , ( _WindDirectionMapInfluence * TF_ROTATION_MAP_INFLUENCE ));
				#ifdef _USEWINDDIRECTIONMAP_ON
				float3 staticSwitch55_g115 = lerpResult51_g115;
				#else
				float3 staticSwitch55_g115 = WindVector47_g115;
				#endif
				float3 worldToObjDir52_g115 = mul( GetWorldToObjectMatrix(), float4( staticSwitch55_g115, 0.0 ) ).xyz;
				float3 WindVector226_g114 = worldToObjDir52_g115;
				float3 appendResult11_g114 = (float3(( -1.0 * input.ase_texcoord1.x ) , input.ase_texcoord2.x , ( -1.0 * input.ase_texcoord1.y )));
				float3 temp_output_19_0_g114 = ( 0.001 * appendResult11_g114 );
				float3 SelfPivot28_g114 = temp_output_19_0_g114;
				float3 objToWorld54_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float2 temp_cast_1 = ((( ( SelfPivot28_g114 * 1.0 ) + ( objToWorld54_g114 / -2.0 ) )).z).xx;
				float2 panner48_g114 = ( 1.0 * _Time.y * float2( 0,0.85 ) + temp_cast_1);
				float simplePerlin2D53_g114 = snoise( panner48_g114*_ChildWindMapScale );
				simplePerlin2D53_g114 = simplePerlin2D53_g114*0.5 + 0.5;
				float ChildRotation43_g114 = radians( ( simplePerlin2D53_g114 * 12.0 * _ChildWindStrength ) );
				float3 rotatedValue81_g114 = RotateAroundAxis( SelfPivot28_g114, input.positionOS.xyz, normalize( WindVector226_g114 ), ChildRotation43_g114 );
				float3 ChildRotationResult119_g114 = ( ( ChildMask26_g114 * SelfBendMask34_g114 ) * ( rotatedValue81_g114 - input.positionOS.xyz ) );
				float temp_output_113_0_g114 = saturate( ( 4.0 * pow( SelfBendMask34_g114 , _BendingMaskStrength1 ) ) );
				float dotResult9_g114 = dot( temp_output_19_0_g114 , temp_output_19_0_g114 );
				float ifLocalVar189_g114 = 0;
				if( dotResult9_g114 > 0.0001 )
				ifLocalVar189_g114 = 1.0;
				else if( dotResult9_g114 < 0.0001 )
				ifLocalVar189_g114 = 0.0;
				float TrunkMask29_g114 = saturate( ( ifLocalVar189_g114 * 1000.0 ) );
				float3 ParentPivot27_g114 = temp_output_20_0_g114;
				float3 lerpResult51_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float2 temp_cast_2 = ((( lerpResult51_g114 / -0.2 )).z).xx;
				float2 panner61_g114 = ( 1.0 * _Time.y * float2( 0,0.45 ) + temp_cast_2);
				float simplePerlin2D60_g114 = snoise( panner61_g114*_ParentWindMapScale );
				simplePerlin2D60_g114 = simplePerlin2D60_g114*0.5 + 0.5;
				float saferPower185_g114 = abs( simplePerlin2D60_g114 );
				float saferPower160_g114 = abs( input.ase_texcoord4.x );
				float MainBendMask35_g114 = saturate( pow( saferPower160_g114 , _MainBendMaskStrength ) );
				float ParentRotation63_g114 = radians( ( pow( saferPower185_g114 , 1.0 ) * 25.0 * _ParentWindStrength * MainBendMask35_g114 ) );
				float3 lerpResult98_g114 = lerp( SelfPivot28_g114 , ParentPivot27_g114 , ChildMask26_g114);
				float3 rotatedValue96_g114 = RotateAroundAxis( lerpResult98_g114, ( ChildRotationResult119_g114 + input.positionOS.xyz ), normalize( WindVector226_g114 ), ParentRotation63_g114 );
				float3 ParentRotationResult131_g114 = ( ChildRotationResult119_g114 + ( ( ( ( ( temp_output_113_0_g114 * ( 1.0 - ChildMask26_g114 ) ) + ChildMask26_g114 ) * TrunkMask29_g114 ) * ( rotatedValue96_g114 - input.positionOS.xyz ) ) * MainBendMask35_g114 ) );
				float3 objToWorld47_g114 = mul( GetObjectToWorldMatrix(), float4( float3( 0,0,0 ), 1 ) ).xyz;
				float3 saferPower172_g114 = abs( ( objToWorld47_g114 / ( -15.0 * _MainWindScale ) ) );
				float2 panner71_g114 = ( 1.0 * _Time.y * float2( 0,0.07 ) + (pow( saferPower172_g114 , 2.0 )).xz);
				float simplePerlin2D70_g114 = snoise( panner71_g114*2.0 );
				simplePerlin2D70_g114 = simplePerlin2D70_g114*0.5 + 0.5;
				float MainRotation67_g114 = radians( ( simplePerlin2D70_g114 * 25.0 * _MainWindStrength ) );
				float3 temp_output_125_0_g114 = ( ParentRotationResult131_g114 + input.positionOS.xyz );
				float3 rotatedValue121_g114 = RotateAroundAxis( float3( 0, 0, 0 ), temp_output_125_0_g114, normalize( WindVector226_g114 ), MainRotation67_g114 );
				float temp_output_148_0_g114 = pow( MainBendMask35_g114 , 5.0 );
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch419 = ( ( ParentRotationResult131_g114 + ( ( rotatedValue121_g114 - temp_output_125_0_g114 ) * temp_output_148_0_g114 ) ) * _WindOverallStrength * TF_WIND_STRENGTH );
				#else
				float3 staticSwitch419 = temp_cast_0;
				#endif
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch419;

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

				

				surfaceDescription.Alpha = 1;
				surfaceDescription.AlphaClipThreshold = 0.5;

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
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;244;-1520,672;Inherit;False;Property;_BendingMaskStrength1;Bending Mask Strength;38;0;Create;True;0;0;0;False;0;False;1.236128;1.5;0.05;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;291;-1520,592;Inherit;False;Property;_WindOverallStrength;Wind Overall Strength;32;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;293;-1520,512;Inherit;False;Property;_MainBendMaskStrength;Main Bend Mask Strength;34;0;Create;True;0;0;0;False;0;False;0;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;297;-1520,272;Inherit;False;Property;_MainWindScale;Main Wind Scale;35;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;410;-1520,352;Inherit;False;Property;_ChildWindMapScale;Child Wind Map Scale;40;0;Create;True;0;0;0;False;0;False;2;2;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;412;-1488,192;Inherit;False;Property;_WindDirectionMapScale;Wind Direction Map Scale;42;0;Create;True;0;0;0;False;0;False;200;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;411;-1472,0;Inherit;True;Property;_WindDirectionMap;Wind Direction Map;41;2;[Header];[SingleLineTexture];Create;True;1;WIND MAPS;0;0;False;1;Space(10);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;242;-1520,912;Inherit;False;Property;_MainWindStrength;Main Wind Strength;33;1;[Header];Create;True;1;Main Wind;0;0;False;1;Space(5);False;0.5;0.5;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;243;-1520,832;Inherit;False;Property;_ChildWindStrength;Child Wind Strength;39;1;[Header];Create;True;1;Child Wind;0;0;False;1;Space(5);False;0.5;0.16;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;241;-1520,752;Inherit;False;Property;_ParentWindStrength;Parent Wind Strength;36;1;[Header];Create;True;1;Parent Wind;0;0;False;1;Space(5);False;0.5;0.35;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;295;-1520,432;Inherit;False;Property;_ParentWindMapScale;Parent Wind Map Scale;37;0;Create;True;0;0;0;False;0;False;1;1;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;478;-4224,-1776;Inherit;False;1172;1266.8;Comment;16;454;455;456;457;458;459;460;461;462;463;464;465;466;467;468;469;Layer;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;477;-4226,-3714;Inherit;False;1828;1762.8;Comment;19;391;392;393;385;387;388;406;15;13;407;409;404;405;389;420;423;329;497;496;Base;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;394;-2304,-3456;Inherit;False;1299.2;345.2;Comment;10;402;403;401;396;399;344;398;397;424;427;Additional Vertex Color AO;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;417;-384,432;Inherit;False;Constant;_Float17;Float 0;31;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;453;-1078.665,387.9401;Inherit;False;FW_Wind;43;;114;6d75e8b57dd6aca4f88bb3d789062339;0;11;231;SAMPLER2D;0;False;238;FLOAT;200;False;166;FLOAT;1;False;162;FLOAT;2;False;163;FLOAT;1;False;157;FLOAT;1;False;154;FLOAT;0;False;142;FLOAT;0.5;False;77;FLOAT;1;False;141;FLOAT;1;False;78;FLOAT;1;False;6;FLOAT;167;FLOAT;147;FLOAT;143;FLOAT;144;FLOAT;145;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;419;-208,480;Inherit;False;Property;_EnableWind;Enable Wind;31;0;Create;True;0;0;0;False;2;Header(WIND SETTINGS);Space(10);False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;397;-1808,-3392;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;398;-2000,-3392;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;396;-1696,-3392;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;401;-1440,-3392;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;403;-1264,-3392;Inherit;False;FinalAmbientOcclusion;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;344;-2288,-3392;Inherit;False;Property;_VertexAOIntensity;Vertex AO Intensity;30;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;402;-1808,-3232;Inherit;False;389;AmbientOcclusion;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;424;-1536,-3264;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;399;-2288,-3296;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PowerNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;427;-2000,-3264;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;391;-4176,-3296;Inherit;False;Property;_BaseColorContrast;Base Color Contrast;15;0;Create;True;0;0;0;False;0;False;1;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;392;-4176,-3376;Inherit;False;Property;_BaseColorSaturation;Base Color Saturation;14;0;Create;True;0;0;0;False;0;False;1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;393;-4176,-3456;Inherit;False;Property;_BaseColorBrightness;Base Color Brightness;13;0;Create;True;0;0;0;False;0;False;1;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;385;-2640,-3440;Inherit;False;FinalColor;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;387;-2640,-3376;Inherit;False;FinalNormal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;388;-2640,-3312;Inherit;False;Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;406;-4112,-2832;Inherit;False;Constant;_EmissiveColor;Emissive Color;21;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,0;0,0,0,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.ColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;15;-4112,-3664;Inherit;False;Property;_Color;Color;12;1;[Header];Create;True;1;COLOR ADJUSTMENT;0;0;False;1;Space(10);False;1,1,1,0;1,1,1,1;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;13;-4176,-2224;Inherit;False;Property;_Smoothness;Smoothness;27;1;[Header];Create;True;1;BASE ATTRIBUTES;0;0;False;1;Space(10);False;0;0.6;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;407;-4112,-2624;Inherit;True;Property;_NormalMap;Normal Map;9;1;[SingleLineTexture];Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;409;-4112,-2432;Inherit;True;Property;_MaskMapMAOS;Mask Map (M, AO, S);10;1;[SingleLineTexture];Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;405;-4112,-3024;Inherit;True;Property;_EmissiveMap;Emissive Map;11;1;[SingleLineTexture];Create;True;0;0;0;False;0;False;None;None;False;black;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;389;-2672,-3248;Inherit;False;AmbientOcclusion;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;420;-2640,-3184;Inherit;False;Emissive;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;423;-4176,-2064;Inherit;False;Property;_NormalIntensity;Normal Intensity;28;0;Create;True;0;0;0;False;0;False;1;1;-2;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;329;-4176,-2144;Inherit;False;Property;_AOIntensity;AO Intensity;29;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;454;-3296,-1168;Inherit;False;LayerSmoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;455;-3296,-1088;Inherit;False;LayerMetallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;456;-3296,-1328;Inherit;False;LayerNormal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;457;-3296,-1408;Inherit;False;LayerColor;-1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;458;-4128,-1072;Inherit;True;Property;_LayerMask;Layer Mask;18;1;[SingleLineTexture];Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;461;-4176,-864;Inherit;False;Property;_LayerMetallic;Layer Metallic;26;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;462;-4176,-784;Inherit;False;Property;_LayerSmoothness;Layer Smoothness;21;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;463;-4176,-704;Inherit;False;Property;_LayerAOStrength;Layer AO Strength;23;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;464;-4176,-624;Inherit;False;Property;_LayerTiling;Layer Tiling;24;0;Create;True;0;0;0;False;0;False;1;2;0.1;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;465;-4176,-1152;Inherit;False;Property;_LayerNormalIntensity;Layer Normal Intensity;22;0;Create;True;0;0;0;False;0;False;1;1;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;466;-3360,-1008;Inherit;False;LayerAmbientOcclusion;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;468;-4128,-1344;Inherit;True;Property;_LayerNormal;Layer Normal;17;2;[Normal];[SingleLineTexture];Create;True;0;0;0;False;0;False;None;None;False;bump;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;469;-3296,-1248;Inherit;False;LayerHeight;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;475;-1072,-1328;Inherit;False;385;FinalColor;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;476;-1072,-1264;Inherit;False;387;FinalNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;479;-1104,-1200;Inherit;False;388;Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;480;-1136,-1136;Inherit;False;389;AmbientOcclusion;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;481;-1072,-1072;Inherit;False;420;Emissive;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;474;-1392,-416;Inherit;False;469;LayerHeight;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;482;-1136,-960;Inherit;False;457;LayerColor;1;0;OBJECT;;False;1;FLOAT4;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;484;-1168,-896;Inherit;False;456;LayerNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;483;-1168,-832;Inherit;False;454;LayerSmoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;485;-1232,-768;Inherit;False;466;LayerAmbientOcclusion;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;487;-1104,-704;Inherit;False;Constant;_Float18;Float 18;37;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;467;-3776,-1408;Inherit;False;FW_TriplanarLayer;-1;;128;027053523f8a5fb48a0d2c540d12996a;0;10;41;FLOAT4;0,0,0,0;False;8;SAMPLER2D;;False;9;SAMPLER2D;;False;11;FLOAT;1;False;13;SAMPLER2D;0,0,0;False;21;FLOAT;0;False;22;FLOAT;0;False;23;FLOAT;1;False;50;FLOAT;1;False;51;FLOAT;1;False;7;FLOAT4;0;FLOAT3;25;FLOAT;26;FLOAT;27;FLOAT;29;FLOAT;28;FLOAT4;40
Node;AmplifyShaderEditor.ColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;460;-4128,-1728;Inherit;False;Property;_LayerColor;Layer Color;25;0;Create;True;1;Layer Attributes;0;0;False;0;False;1,1,1,0;0.7169812,0.7169812,0.7169812,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;459;-4128,-1536;Inherit;True;Property;_LayerAlbedo;Layer Albedo;16;2;[Header];[SingleLineTexture];Create;True;1;LAYER MAPS;0;0;False;1;Space(10);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;490;-752,-1168;Inherit;False;TF_2LayerBlend;19;;135;4f150f3422ae77440842fdf616a8b4e4;0;13;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;33;COLOR;0,0,0,0;False;6;FLOAT4;0,0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;10;FLOAT;0;False;9;FLOAT;0;False;35;FLOAT;0;False;11;FLOAT;0;False;6;FLOAT4;0;FLOAT3;27;FLOAT;28;FLOAT;29;FLOAT;30;COLOR;37
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;472;-1392,-480;Inherit;False;387;FinalNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;473;-1456,-352;Inherit;False;403;FinalAmbientOcclusion;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;491;-1120,-400;Inherit;False;TF_BlendMask;0;;136;a02c578b043b0c847bf12ac6e97d990e;0;3;38;FLOAT3;0,0,0;False;39;FLOAT;0;False;40;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;492;-80,-1312;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;497;-3200,-3440;Inherit;False;FW_StandardLayer;-1;;151;c3b2175e566bb5047b1cf46c43eb1c3f;0;16;41;FLOAT4;0,0,0,0;False;50;FLOAT;1;False;52;FLOAT;1;False;51;FLOAT;1;False;65;FLOAT;1;False;8;SAMPLER2D;;False;54;SAMPLER2D;;False;55;COLOR;1,1,1,0;False;2;SAMPLERSTATE;;False;9;SAMPLER2D;;False;11;FLOAT;1;False;10;SAMPLERSTATE;;False;13;SAMPLER2D;0,0,0;False;21;FLOAT;0;False;22;FLOAT;0;False;23;FLOAT;0;False;10;FLOAT3;0;COLOR;89;FLOAT3;25;FLOAT;26;FLOAT;27;FLOAT;29;COLOR;60;FLOAT;53;FLOAT;28;COLOR;40
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;496;-3525.87,-3623.302;Inherit;False;Constant;_Float20;Float 20;37;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;404;-4112,-3216;Inherit;True;Property;_ColorMap;Color Map;8;2;[Header];[SingleLineTexture];Create;True;1;BASE MAP;0;0;False;1;Space(10);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;372;240,-1104;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ExtraPrePass;0;0;ExtraPrePass;6;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;373;240,-1104;Float;False;True;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;TriForge/Tree Bark;94348b07e5e8bab40bd6c8a1e3df54cd;True;Forward;0;1;Forward;21;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalForward;False;False;3;Include;;False;;Native;False;0;0;;Include;Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl;False;;Custom;False;0;0;;Pragma;multi_compilefragment  LOD_FADE_CROSSFADE;False;;Custom;False;0;0;;;0;0;Standard;45;Lighting Model;0;0;Workflow;1;0;Surface;0;0;  Refraction Model;0;0;  Blend;0;0;Two Sided;1;0;Alpha Clipping;1;0;  Use Shadow Threshold;0;0;Fragment Normal Space,InvertActionOnDeselection;0;0;Forward Only;0;0;Transmission;0;0;  Transmission Shadow;0.5,False,;0;Translucency;0;0;  Translucency Strength;1,True,_TranslucencyStrength;0;  Normal Distortion;0.5,False,;0;  Scattering;2,False,;0;  Direct;0.9,False,;0;  Ambient;0.1,False,;0;  Shadow;0.5,False,;0;Cast Shadows;1;0;Receive Shadows;1;0;Receive SSAO;1;0;Specular Highlights;1;0;Environment Reflections;1;0;GPU Instancing;1;0;LOD CrossFade;1;638841104103051851;Built-in Fog;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Write Depth;0;0;  Early Z;0;0;Vertex Position,InvertActionOnDeselection;1;0;Debug Display;0;0;Clear Coat;0;0;0;10;False;True;True;True;True;True;True;True;True;True;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;374;205.876,-182.3051;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;375;205.876,-182.3051;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;True;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;376;205.876,-182.3051;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;377;205.876,-182.3051;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;378;205.876,-182.3051;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormals;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;379;205.876,-182.3051;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;GBuffer;0;7;GBuffer;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalGBuffer;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;380;205.876,-182.3051;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;SceneSelectionPass;0;8;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;381;205.876,-182.3051;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ScenePickingPass;0;9;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
WireConnection;453;231;411;0
WireConnection;453;238;412;0
WireConnection;453;166;297;0
WireConnection;453;162;410;0
WireConnection;453;163;295;0
WireConnection;453;157;293;0
WireConnection;453;154;291;0
WireConnection;453;142;244;0
WireConnection;453;77;241;0
WireConnection;453;141;243;0
WireConnection;453;78;242;0
WireConnection;419;1;417;0
WireConnection;419;0;453;0
WireConnection;397;0;398;0
WireConnection;397;1;427;0
WireConnection;398;0;344;0
WireConnection;396;0;397;0
WireConnection;401;0;424;0
WireConnection;403;0;401;0
WireConnection;424;0;396;0
WireConnection;424;1;402;0
WireConnection;427;0;399;1
WireConnection;385;0;497;0
WireConnection;387;0;497;25
WireConnection;388;0;497;27
WireConnection;389;0;497;29
WireConnection;420;0;497;60
WireConnection;454;0;467;27
WireConnection;455;0;467;26
WireConnection;456;0;467;25
WireConnection;457;0;467;0
WireConnection;466;0;467;29
WireConnection;469;0;467;28
WireConnection;467;41;460;0
WireConnection;467;8;459;0
WireConnection;467;9;468;0
WireConnection;467;11;465;0
WireConnection;467;13;458;0
WireConnection;467;21;461;0
WireConnection;467;22;462;0
WireConnection;467;23;463;0
WireConnection;467;50;464;0
WireConnection;490;1;475;0
WireConnection;490;2;476;0
WireConnection;490;4;479;0
WireConnection;490;5;480;0
WireConnection;490;33;481;0
WireConnection;490;6;482;0
WireConnection;490;7;484;0
WireConnection;490;10;483;0
WireConnection;490;9;485;0
WireConnection;490;35;487;0
WireConnection;490;11;491;0
WireConnection;491;38;472;0
WireConnection;491;39;474;0
WireConnection;491;40;473;0
WireConnection;497;41;15;0
WireConnection;497;50;393;0
WireConnection;497;52;392;0
WireConnection;497;51;391;0
WireConnection;497;8;404;0
WireConnection;497;54;405;0
WireConnection;497;55;406;0
WireConnection;497;9;407;0
WireConnection;497;11;423;0
WireConnection;497;13;409;0
WireConnection;497;22;13;0
WireConnection;497;23;329;0
WireConnection;373;0;490;0
WireConnection;373;1;490;27
WireConnection;373;4;490;29
WireConnection;373;5;490;30
WireConnection;373;2;490;37
WireConnection;373;8;419;0
ASEEND*/
//CHKSM=62100C93657D8D53C40B0B3446D0A4F5D29E4262