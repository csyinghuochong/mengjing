// Made with Amplify Shader Editor v1.9.8.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ANGRYMESH/Stylized Pack/Tree Bark"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HDR][Header(Base)]_BaseAlbedoColor("Base Albedo Color", Color) = (0.5019608,0.5019608,0.5019608,0.5019608)
		_BaseAlbedoBrightness("Base Albedo Brightness", Range( 0 , 5)) = 1
		_BaseAlbedoDesaturation("Base Albedo Desaturation", Range( 0 , 1)) = 0
		_BaseMetallicIntensity("Base Metallic Intensity", Range( 0 , 1)) = 0
		_BaseSmoothnessMin("Base Smoothness Min", Range( 0 , 5)) = 0
		_BaseSmoothnessMax("Base Smoothness Max", Range( 0 , 5)) = 1
		_BaseNormalIntensity("Base Normal Intensity", Range( 0 , 5)) = 1
		_BaseBarkAOIntensity("Base Bark AO Intensity", Range( 0 , 1)) = 0.5
		_BaseTreeAOIntensity("Base Tree AO Intensity", Range( 0 , 1)) = 0
		[HDR]_BaseEmissiveColor("Base Emissive Color", Color) = (0,0,0)
		_BaseEmissiveIntensity("Base Emissive Intensity", Float) = 2
		_BaseEmissiveMaskContrast("Base Emissive Mask Contrast", Float) = 2
		[NoScaleOffset]_BaseAlbedo("Base Albedo", 2D) = "gray" {}
		[NoScaleOffset]_BaseNormal("Base Normal", 2D) = "bump" {}
		[NoScaleOffset]_BaseSMAE("Base SMAE", 2D) = "gray" {}
		[Header(Top Layer)][Toggle(_ENABLETOPLAYERBLEND_ON)] _EnableTopLayerBlend("Enable Top Layer Blend", Float) = 1
		[HDR]_TopLayerAlbedoColor("Top Layer Albedo Color", Color) = (0.5019608,0.5019608,0.5019608,0.5019608)
		_TopLayerUVScale("Top Layer UV Scale", Range( 0 , 50)) = 1
		_TopLayerSmoothnessMin("Top Layer Smoothness Min", Range( 0 , 5)) = 0
		_TopLayerSmoothnessMax("Top Layer Smoothness Max", Range( 0 , 5)) = 1
		_TopLayerNormalIntensity("Top Layer Normal Intensity", Range( 0 , 5)) = 1
		_TopLayerNormalInfluence("Top Layer Normal Influence", Range( 0 , 1)) = 0
		_TopLayerIntensity("Top Layer Intensity", Range( 0 , 1)) = 1
		_TopLayerOffset("Top Layer Offset", Range( 0 , 1)) = 0.5
		_TopLayerContrast("Top Layer Contrast", Range( 0 , 30)) = 10
		_TopArrowDirectionOffset("Top Arrow Direction Offset", Range( 0 , 2)) = 0
		_TopLayerBottomOffset("Top Layer Bottom Offset", Range( 0 , 5)) = 1
		[NoScaleOffset]_TopLayerAlbedo("Top Layer Albedo", 2D) = "gray" {}
		[NoScaleOffset][Normal]_TopLayerNormal("Top Layer Normal", 2D) = "bump" {}
		[NoScaleOffset]_TopLayerSmoothness("Top Layer Smoothness", 2D) = "gray" {}
		[Header(Wind)][Toggle(_ENABLEWIND_ON)] _EnableWind("Enable Wind", Float) = 1
		[Header(Wind (Use the same values for each tree material))]_WindTreeFlexibility("Wind Tree Flexibility", Range( 0 , 2)) = 1
		_WindTreeBaseRigidity("Wind Tree Base Rigidity", Range( 0 , 5)) = 2.5
		[Toggle(_ENABLESTATICMESHSUPPORT_ON)] _EnableStaticMeshSupport("Enable Static Mesh Support", Float) = 0


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
				float4 ase_texcoord3 : TEXCOORD3;
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
				float4 ase_texcoord9 : TEXCOORD9;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _WindTreeFlexibility;
			half _BaseSmoothnessMax;
			half _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			float _TopLayerBottomOffset;
			half _TopArrowDirectionOffset;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _BaseTreeAOIntensity;
			half _BaseBarkAOIntensity;
			float _TopLayerUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindTreeBaseRigidity;
			half _TopLayerSmoothnessMin;
			half _TopLayerSmoothnessMax;
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
			float ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			sampler2D _TopLayerAlbedo;
			sampler2D _BaseSMAE;
			sampler2D _BaseNormal;
			half ASPT_TopLayerOffset;
			half ASPT_TopLayerContrast;
			half ASPT_TopLayerIntensity;
			half ASPT_TopLayerArrowDirection;
			half ASPT_TopLayerBottomOffset;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;
			sampler2D _TopLayerNormal;
			sampler2D _TopLayerSmoothness;


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
				float3 Global_Wind_Direction493_g22 = ASPW_WindDirection;
				float3 worldToObjDir269_g22 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g22, 0.0 ) ).xyz;
				float3 normalizeResult268_g22 = ASESafeNormalize( worldToObjDir269_g22 );
				float3 Wind_Direction_Leaf85_g22 = normalizeResult268_g22;
				float3 break86_g22 = Wind_Direction_Leaf85_g22;
				float3 appendResult89_g22 = (float3(break86_g22.z , 0.0 , ( break86_g22.x * -1.0 )));
				float3 Wind_Direction91_g22 = appendResult89_g22;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g22 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g22 = ( Wind_Tree_Randomization149_g22 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g22 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g22 = ( Global_Wind_Tree_Speed491_g22 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g22 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g22 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g22 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g22 ) * 0.3 );
				float Wind_Tree_257_g22 = ( ( ( ( ( sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.1 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.3 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g22 ) * Global_Wind_Tree_Amplitude464_g22 ) * 0.01 ) * temp_output_383_0_g22 );
				float3 rotatedValue99_g22 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g22, Wind_Tree_257_g22 );
				float3 Rotate_About_Axis354_g22 = ( rotatedValue99_g22 - input.positionOS.xyz );
				float3 break452_g22 = normalizeResult268_g22;
				float3 appendResult454_g22 = (float3(break452_g22.x , 0.0 , break452_g22.z));
				float3 Wind_Direction_SM_Support453_g22 = appendResult454_g22;
				float Wind_Tree_Flexibility483_g22 = temp_output_383_0_g22;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g22 = ( Global_Wind_Tree_Amplitude464_g22 * Wind_Tree_257_g22 * Wind_Direction_SM_Support453_g22 * Wind_Tree_Flexibility483_g22 );
				#else
				float3 staticSwitch482_g22 = Rotate_About_Axis354_g22;
				#endif
				float3 Wind_Global450_g22 = staticSwitch482_g22;
				float2 texCoord433_g22 = input.texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g22 = texCoord433_g22.y;
				float saferPower113_g22 = abs( Wind_Mask_UV_CH2_VChannel434_g22 );
				float Wind_Tree_Mask114_g22 = pow( saferPower113_g22 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g22 = ( Wind_Global450_g22 * Wind_Tree_Mask114_g22 );
				float Global_Wind_Toggle504_g22 = ASPW_WindToggle;
				float3 lerpResult124_g22 = lerp( float3( 0,0,0 ) , temp_output_385_0_g22 , Global_Wind_Toggle504_g22);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch468_g22 = lerpResult124_g22;
				#else
				float3 staticSwitch468_g22 = temp_cast_0;
				#endif
				
				output.ase_texcoord8.xy = input.texcoord.xy;
				output.ase_texcoord8.zw = input.ase_texcoord3.xy;
				output.ase_color = input.ase_color;
				output.ase_texcoord9.xy = input.texcoord2.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord9.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch468_g22;

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
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.texcoord = input.texcoord;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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

				float2 texCoord563 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 texCoord565 = input.ase_texcoord8.zw * float2( 1,1 ) + float2( 0,0 );
				float VColor_Blue_Tree_Mask561 = input.ase_color.b;
				float3 lerpResult566 = lerp( tex2D( _BaseAlbedo, texCoord563 ).rgb , tex2D( _BaseAlbedo, texCoord565 ).rgb , VColor_Blue_Tree_Mask561);
				float3 desaturateInitialColor1070 = lerpResult566;
				float desaturateDot1070 = dot( desaturateInitialColor1070, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar1070 = lerp( desaturateInitialColor1070, desaturateDot1070.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc345 = ( desaturateVar1070 * _BaseAlbedoBrightness );
				float3 blendOpDest345 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo350 = ( saturate( (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) ));
				float2 texCoord594 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale597 = ( texCoord594 * _TopLayerUVScale );
				float3 blendOpSrc599 = tex2D( _TopLayerAlbedo, Top_Layer_UV_Scale597 ).rgb;
				float3 blendOpDest599 = _TopLayerAlbedoColor.rgb;
				float2 texCoord580 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode577 = tex2D( _BaseSMAE, texCoord580 );
				float2 texCoord581 = input.ase_texcoord8.zw * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode576 = tex2D( _BaseSMAE, texCoord581 );
				float3 lerpResult579 = lerp( tex2DNode577.rgb , tex2DNode576.rgb , VColor_Blue_Tree_Mask561);
				float3 break582 = lerpResult579;
				float lerpResult365 = lerp( 1.0 , break582.z , _BaseBarkAOIntensity);
				float lerpResult559 = lerp( 1.0 , input.ase_color.a , _BaseTreeAOIntensity);
				float VColor_Alpha_Tree_AO562 = lerpResult559;
				float Base_AO348 = ( lerpResult365 * VColor_Alpha_Tree_AO562 );
				float2 texCoord571 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack569 = UnpackNormalScale( tex2D( _BaseNormal, texCoord571 ), _BaseNormalIntensity );
				unpack569.z = lerp( 1, unpack569.z, saturate(_BaseNormalIntensity) );
				float2 texCoord572 = input.ase_texcoord8.zw * float2( 1,1 ) + float2( 0,0 );
				float3 unpack570 = UnpackNormalScale( tex2D( _BaseNormal, texCoord572 ), _BaseNormalIntensity );
				unpack570.z = lerp( 1, unpack570.z, saturate(_BaseNormalIntensity) );
				float3 lerpResult573 = lerp( unpack569 , unpack570 , VColor_Blue_Tree_Mask561);
				float3 Base_Normal355 = lerpResult573;
				float3 tanToWorld0 = float3( WorldTangent.x, WorldBiTangent.x, WorldNormal.x );
				float3 tanToWorld1 = float3( WorldTangent.y, WorldBiTangent.y, WorldNormal.y );
				float3 tanToWorld2 = float3( WorldTangent.z, WorldBiTangent.z, WorldNormal.z );
				float3 tanNormal776 = Base_Normal355;
				float3 worldNormal776 = float3( dot( tanToWorld0, tanNormal776 ), dot( tanToWorld1, tanNormal776 ), dot( tanToWorld2, tanNormal776 ) );
				float temp_output_616_0 = ( _TopLayerOffset * ASPT_TopLayerOffset );
				float saferPower17_g23 = abs( abs( ( saturate( worldNormal776.y ) + temp_output_616_0 ) ) );
				float temp_output_617_0 = ( _TopLayerContrast * ASPT_TopLayerContrast );
				float temp_output_615_0 = ( _TopLayerIntensity * ASPT_TopLayerIntensity );
				float3 tanNormal629 = Base_Normal355;
				float3 worldNormal629 = float3( dot( tanToWorld0, tanNormal629 ), dot( tanToWorld1, tanNormal629 ), dot( tanToWorld2, tanNormal629 ) );
				float3 Global_Arrow_Direction655 = ASPW_WindDirection;
				float dotResult633 = dot( worldNormal629 , Global_Arrow_Direction655 );
				float dotResult682 = dot( worldNormal629 , float3(0,1,0) );
				float2 texCoord668 = input.ase_texcoord9.xy * float2( 1,1 ) + float2( 0,0 );
				float Arrow_Direction_Mask693 = ( ( ( 1.0 - dotResult633 ) * ( _TopArrowDirectionOffset * ASPT_TopLayerArrowDirection ) ) * ( ( ( 3.0 - ( 1.0 - dotResult682 ) ) * ( 1.0 - texCoord668.y ) ) + 0.05 ) );
				float2 texCoord705 = input.ase_texcoord9.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_706_0 = ( 1.0 - texCoord705.y );
				float temp_output_711_0 = ( ( ( temp_output_706_0 * temp_output_706_0 ) * ( temp_output_706_0 * temp_output_706_0 ) ) * _TopLayerBottomOffset * ASPT_TopLayerBottomOffset );
				float3 tanNormal715 = Base_Normal355;
				float3 worldNormal715 = float3( dot( tanToWorld0, tanNormal715 ), dot( tanToWorld1, tanNormal715 ), dot( tanToWorld2, tanNormal715 ) );
				float dotResult716 = dot( worldNormal715 , float3(0,1,0) );
				float Top_Layer_Bottom_Offset721 = ( ( temp_output_711_0 * temp_output_711_0 ) + ( dotResult716 - 1.0 ) );
				float clampResult1046 = clamp( ( Arrow_Direction_Mask693 + Top_Layer_Bottom_Offset721 ) , 0.0 , 5.0 );
				float Top_Layer_Offset696 = temp_output_616_0;
				float saferPower698 = abs( ( clampResult1046 * Top_Layer_Offset696 ) );
				float Top_Layer_Contrast699 = temp_output_617_0;
				float Top_Layer_Intensity702 = temp_output_615_0;
				float Top_Layer_Direction1057 = saturate( ( pow( saferPower698 , Top_Layer_Contrast699 ) * Top_Layer_Intensity702 ) );
				float Top_Layer_Mask621 = saturate( ( ( ( saturate( pow( saferPower17_g23 , temp_output_617_0 ) ) * temp_output_615_0 ) + Top_Layer_Direction1057 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) ) );
				float3 lerpResult605 = lerp( Base_Albedo350 , ( (( blendOpDest599 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest599 ) * ( 1.0 - blendOpSrc599 ) ) : ( 2.0 * blendOpDest599 * blendOpSrc599 ) ) * Base_AO348 ) , Top_Layer_Mask621);
				float3 Top_Layer_Albedo625 = lerpResult605;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch623 = Top_Layer_Albedo625;
				#else
				float3 staticSwitch623 = Base_Albedo350;
				#endif
				float3 Output_Albedo627 = staticSwitch623;
				
				float3 unpack646 = UnpackNormalScale( tex2D( _TopLayerNormal, Top_Layer_UV_Scale597 ), _TopLayerNormalIntensity );
				unpack646.z = lerp( 1, unpack646.z, saturate(_TopLayerNormalIntensity) );
				float3 tex2DNode646 = unpack646;
				float3 lerpResult649 = lerp( BlendNormal( tex2DNode646 , Base_Normal355 ) , tex2DNode646 , _TopLayerNormalInfluence);
				float3 lerpResult652 = lerp( Base_Normal355 , lerpResult649 , Top_Layer_Mask621);
				float3 Top_Layer_Normal653 = lerpResult652;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch738 = Top_Layer_Normal653;
				#else
				float3 staticSwitch738 = Base_Normal355;
				#endif
				float3 Output_Normal742 = staticSwitch738;
				
				float lerpResult587 = lerp( tex2DNode577.a , tex2DNode576.a , VColor_Blue_Tree_Mask561);
				float Emissive_Mask371 = lerpResult587;
				float saferPower373 = abs( Emissive_Mask371 );
				float3 Base_Emissive377 = ( ( _BaseEmissiveColor * pow( saferPower373 , _BaseEmissiveMaskContrast ) ) * _BaseEmissiveIntensity );
				float3 lerpResult755 = lerp( Base_Emissive377 , float3( 0,0,0 ) , Top_Layer_Mask621);
				float3 Top_Layer_Emissive757 = lerpResult755;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch766 = Top_Layer_Emissive757;
				#else
				float3 staticSwitch766 = Base_Emissive377;
				#endif
				float3 Output_Emissive769 = staticSwitch766;
				
				float Base_Metallic364 = ( break582.y * _BaseMetallicIntensity );
				float lerpResult747 = lerp( Base_Metallic364 , 0.0 , Top_Layer_Mask621);
				float Top_Layer_Metallic749 = lerpResult747;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch758 = Top_Layer_Metallic749;
				#else
				float staticSwitch758 = Base_Metallic364;
				#endif
				float Output_Metallic761 = staticSwitch758;
				
				float Texture_Smoothness1073 = break582.x;
				float lerpResult1076 = lerp( _BaseSmoothnessMin , _BaseSmoothnessMax , Texture_Smoothness1073);
				float Base_Smoothness361 = saturate( lerpResult1076 );
				float lerpResult1079 = lerp( _TopLayerSmoothnessMin , _TopLayerSmoothnessMax , tex2D( _TopLayerSmoothness, Top_Layer_UV_Scale597 ).r);
				float lerpResult734 = lerp( Base_Smoothness361 , lerpResult1079 , Top_Layer_Mask621);
				float Top_Layer_Smoothness737 = saturate( lerpResult734 );
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch741 = Top_Layer_Smoothness737;
				#else
				float staticSwitch741 = Base_Smoothness361;
				#endif
				float Output_Smoothness745 = staticSwitch741;
				
				float lerpResult751 = lerp( Base_AO348 , 1.0 , Top_Layer_Mask621);
				float Top_Layer_AO753 = lerpResult751;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch762 = Top_Layer_AO753;
				#else
				float staticSwitch762 = Base_AO348;
				#endif
				float Output_AO765 = staticSwitch762;
				

				float3 BaseColor = Output_Albedo627;
				float3 Normal = Output_Normal742;
				float3 Emission = Output_Emissive769;
				float3 Specular = 0.5;
				float Metallic = Output_Metallic761;
				float Smoothness = Output_Smoothness745;
				float Occlusion = Output_AO765;
				float Alpha = 1;
				float AlphaClipThreshold = 0.5;
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
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON


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
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _WindTreeFlexibility;
			half _BaseSmoothnessMax;
			half _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			float _TopLayerBottomOffset;
			half _TopArrowDirectionOffset;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _BaseTreeAOIntensity;
			half _BaseBarkAOIntensity;
			float _TopLayerUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindTreeBaseRigidity;
			half _TopLayerSmoothnessMin;
			half _TopLayerSmoothnessMax;
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
			float ASPW_WindToggle;


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
				float3 Global_Wind_Direction493_g22 = ASPW_WindDirection;
				float3 worldToObjDir269_g22 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g22, 0.0 ) ).xyz;
				float3 normalizeResult268_g22 = ASESafeNormalize( worldToObjDir269_g22 );
				float3 Wind_Direction_Leaf85_g22 = normalizeResult268_g22;
				float3 break86_g22 = Wind_Direction_Leaf85_g22;
				float3 appendResult89_g22 = (float3(break86_g22.z , 0.0 , ( break86_g22.x * -1.0 )));
				float3 Wind_Direction91_g22 = appendResult89_g22;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g22 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g22 = ( Wind_Tree_Randomization149_g22 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g22 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g22 = ( Global_Wind_Tree_Speed491_g22 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g22 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g22 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g22 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g22 ) * 0.3 );
				float Wind_Tree_257_g22 = ( ( ( ( ( sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.1 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.3 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g22 ) * Global_Wind_Tree_Amplitude464_g22 ) * 0.01 ) * temp_output_383_0_g22 );
				float3 rotatedValue99_g22 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g22, Wind_Tree_257_g22 );
				float3 Rotate_About_Axis354_g22 = ( rotatedValue99_g22 - input.positionOS.xyz );
				float3 break452_g22 = normalizeResult268_g22;
				float3 appendResult454_g22 = (float3(break452_g22.x , 0.0 , break452_g22.z));
				float3 Wind_Direction_SM_Support453_g22 = appendResult454_g22;
				float Wind_Tree_Flexibility483_g22 = temp_output_383_0_g22;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g22 = ( Global_Wind_Tree_Amplitude464_g22 * Wind_Tree_257_g22 * Wind_Direction_SM_Support453_g22 * Wind_Tree_Flexibility483_g22 );
				#else
				float3 staticSwitch482_g22 = Rotate_About_Axis354_g22;
				#endif
				float3 Wind_Global450_g22 = staticSwitch482_g22;
				float2 texCoord433_g22 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g22 = texCoord433_g22.y;
				float saferPower113_g22 = abs( Wind_Mask_UV_CH2_VChannel434_g22 );
				float Wind_Tree_Mask114_g22 = pow( saferPower113_g22 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g22 = ( Wind_Global450_g22 * Wind_Tree_Mask114_g22 );
				float Global_Wind_Toggle504_g22 = ASPW_WindToggle;
				float3 lerpResult124_g22 = lerp( float3( 0,0,0 ) , temp_output_385_0_g22 , Global_Wind_Toggle504_g22);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch468_g22 = lerpResult124_g22;
				#else
				float3 staticSwitch468_g22 = temp_cast_0;
				#endif
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch468_g22;
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

				

				float Alpha = 1;
				float AlphaClipThreshold = 0.5;
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
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON


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
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _WindTreeFlexibility;
			half _BaseSmoothnessMax;
			half _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			float _TopLayerBottomOffset;
			half _TopArrowDirectionOffset;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _BaseTreeAOIntensity;
			half _BaseBarkAOIntensity;
			float _TopLayerUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindTreeBaseRigidity;
			half _TopLayerSmoothnessMin;
			half _TopLayerSmoothnessMax;
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
			float ASPW_WindToggle;


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
				float3 Global_Wind_Direction493_g22 = ASPW_WindDirection;
				float3 worldToObjDir269_g22 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g22, 0.0 ) ).xyz;
				float3 normalizeResult268_g22 = ASESafeNormalize( worldToObjDir269_g22 );
				float3 Wind_Direction_Leaf85_g22 = normalizeResult268_g22;
				float3 break86_g22 = Wind_Direction_Leaf85_g22;
				float3 appendResult89_g22 = (float3(break86_g22.z , 0.0 , ( break86_g22.x * -1.0 )));
				float3 Wind_Direction91_g22 = appendResult89_g22;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g22 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g22 = ( Wind_Tree_Randomization149_g22 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g22 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g22 = ( Global_Wind_Tree_Speed491_g22 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g22 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g22 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g22 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g22 ) * 0.3 );
				float Wind_Tree_257_g22 = ( ( ( ( ( sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.1 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.3 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g22 ) * Global_Wind_Tree_Amplitude464_g22 ) * 0.01 ) * temp_output_383_0_g22 );
				float3 rotatedValue99_g22 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g22, Wind_Tree_257_g22 );
				float3 Rotate_About_Axis354_g22 = ( rotatedValue99_g22 - input.positionOS.xyz );
				float3 break452_g22 = normalizeResult268_g22;
				float3 appendResult454_g22 = (float3(break452_g22.x , 0.0 , break452_g22.z));
				float3 Wind_Direction_SM_Support453_g22 = appendResult454_g22;
				float Wind_Tree_Flexibility483_g22 = temp_output_383_0_g22;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g22 = ( Global_Wind_Tree_Amplitude464_g22 * Wind_Tree_257_g22 * Wind_Direction_SM_Support453_g22 * Wind_Tree_Flexibility483_g22 );
				#else
				float3 staticSwitch482_g22 = Rotate_About_Axis354_g22;
				#endif
				float3 Wind_Global450_g22 = staticSwitch482_g22;
				float2 texCoord433_g22 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g22 = texCoord433_g22.y;
				float saferPower113_g22 = abs( Wind_Mask_UV_CH2_VChannel434_g22 );
				float Wind_Tree_Mask114_g22 = pow( saferPower113_g22 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g22 = ( Wind_Global450_g22 * Wind_Tree_Mask114_g22 );
				float Global_Wind_Toggle504_g22 = ASPW_WindToggle;
				float3 lerpResult124_g22 = lerp( float3( 0,0,0 ) , temp_output_385_0_g22 , Global_Wind_Toggle504_g22);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch468_g22 = lerpResult124_g22;
				#else
				float3 staticSwitch468_g22 = temp_cast_0;
				#endif
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch468_g22;

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

				

				float Alpha = 1;
				float AlphaClipThreshold = 0.5;

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


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
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
				float4 ase_texcoord8 : TEXCOORD8;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _WindTreeFlexibility;
			half _BaseSmoothnessMax;
			half _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			float _TopLayerBottomOffset;
			half _TopArrowDirectionOffset;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _BaseTreeAOIntensity;
			half _BaseBarkAOIntensity;
			float _TopLayerUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindTreeBaseRigidity;
			half _TopLayerSmoothnessMin;
			half _TopLayerSmoothnessMax;
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
			float ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			sampler2D _TopLayerAlbedo;
			sampler2D _BaseSMAE;
			sampler2D _BaseNormal;
			half ASPT_TopLayerOffset;
			half ASPT_TopLayerContrast;
			half ASPT_TopLayerIntensity;
			half ASPT_TopLayerArrowDirection;
			half ASPT_TopLayerBottomOffset;
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
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction493_g22 = ASPW_WindDirection;
				float3 worldToObjDir269_g22 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g22, 0.0 ) ).xyz;
				float3 normalizeResult268_g22 = ASESafeNormalize( worldToObjDir269_g22 );
				float3 Wind_Direction_Leaf85_g22 = normalizeResult268_g22;
				float3 break86_g22 = Wind_Direction_Leaf85_g22;
				float3 appendResult89_g22 = (float3(break86_g22.z , 0.0 , ( break86_g22.x * -1.0 )));
				float3 Wind_Direction91_g22 = appendResult89_g22;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g22 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g22 = ( Wind_Tree_Randomization149_g22 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g22 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g22 = ( Global_Wind_Tree_Speed491_g22 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g22 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g22 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g22 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g22 ) * 0.3 );
				float Wind_Tree_257_g22 = ( ( ( ( ( sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.1 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.3 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g22 ) * Global_Wind_Tree_Amplitude464_g22 ) * 0.01 ) * temp_output_383_0_g22 );
				float3 rotatedValue99_g22 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g22, Wind_Tree_257_g22 );
				float3 Rotate_About_Axis354_g22 = ( rotatedValue99_g22 - input.positionOS.xyz );
				float3 break452_g22 = normalizeResult268_g22;
				float3 appendResult454_g22 = (float3(break452_g22.x , 0.0 , break452_g22.z));
				float3 Wind_Direction_SM_Support453_g22 = appendResult454_g22;
				float Wind_Tree_Flexibility483_g22 = temp_output_383_0_g22;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g22 = ( Global_Wind_Tree_Amplitude464_g22 * Wind_Tree_257_g22 * Wind_Direction_SM_Support453_g22 * Wind_Tree_Flexibility483_g22 );
				#else
				float3 staticSwitch482_g22 = Rotate_About_Axis354_g22;
				#endif
				float3 Wind_Global450_g22 = staticSwitch482_g22;
				float2 texCoord433_g22 = input.texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g22 = texCoord433_g22.y;
				float saferPower113_g22 = abs( Wind_Mask_UV_CH2_VChannel434_g22 );
				float Wind_Tree_Mask114_g22 = pow( saferPower113_g22 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g22 = ( Wind_Global450_g22 * Wind_Tree_Mask114_g22 );
				float Global_Wind_Toggle504_g22 = ASPW_WindToggle;
				float3 lerpResult124_g22 = lerp( float3( 0,0,0 ) , temp_output_385_0_g22 , Global_Wind_Toggle504_g22);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch468_g22 = lerpResult124_g22;
				#else
				float3 staticSwitch468_g22 = temp_cast_0;
				#endif
				
				float3 ase_tangentWS = TransformObjectToWorldDir( input.ase_tangent.xyz );
				output.ase_texcoord5.xyz = ase_tangentWS;
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord6.xyz = ase_normalWS;
				float ase_tangentSign = input.ase_tangent.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord7.xyz = ase_bitangentWS;
				
				output.ase_texcoord4.xy = input.texcoord0.xy;
				output.ase_texcoord4.zw = input.ase_texcoord3.xy;
				output.ase_color = input.ase_color;
				output.ase_texcoord8.xy = input.texcoord2.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord5.w = 0;
				output.ase_texcoord6.w = 0;
				output.ase_texcoord7.w = 0;
				output.ase_texcoord8.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch468_g22;

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
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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

				float2 texCoord563 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float2 texCoord565 = input.ase_texcoord4.zw * float2( 1,1 ) + float2( 0,0 );
				float VColor_Blue_Tree_Mask561 = input.ase_color.b;
				float3 lerpResult566 = lerp( tex2D( _BaseAlbedo, texCoord563 ).rgb , tex2D( _BaseAlbedo, texCoord565 ).rgb , VColor_Blue_Tree_Mask561);
				float3 desaturateInitialColor1070 = lerpResult566;
				float desaturateDot1070 = dot( desaturateInitialColor1070, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar1070 = lerp( desaturateInitialColor1070, desaturateDot1070.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc345 = ( desaturateVar1070 * _BaseAlbedoBrightness );
				float3 blendOpDest345 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo350 = ( saturate( (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) ));
				float2 texCoord594 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale597 = ( texCoord594 * _TopLayerUVScale );
				float3 blendOpSrc599 = tex2D( _TopLayerAlbedo, Top_Layer_UV_Scale597 ).rgb;
				float3 blendOpDest599 = _TopLayerAlbedoColor.rgb;
				float2 texCoord580 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode577 = tex2D( _BaseSMAE, texCoord580 );
				float2 texCoord581 = input.ase_texcoord4.zw * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode576 = tex2D( _BaseSMAE, texCoord581 );
				float3 lerpResult579 = lerp( tex2DNode577.rgb , tex2DNode576.rgb , VColor_Blue_Tree_Mask561);
				float3 break582 = lerpResult579;
				float lerpResult365 = lerp( 1.0 , break582.z , _BaseBarkAOIntensity);
				float lerpResult559 = lerp( 1.0 , input.ase_color.a , _BaseTreeAOIntensity);
				float VColor_Alpha_Tree_AO562 = lerpResult559;
				float Base_AO348 = ( lerpResult365 * VColor_Alpha_Tree_AO562 );
				float2 texCoord571 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack569 = UnpackNormalScale( tex2D( _BaseNormal, texCoord571 ), _BaseNormalIntensity );
				unpack569.z = lerp( 1, unpack569.z, saturate(_BaseNormalIntensity) );
				float2 texCoord572 = input.ase_texcoord4.zw * float2( 1,1 ) + float2( 0,0 );
				float3 unpack570 = UnpackNormalScale( tex2D( _BaseNormal, texCoord572 ), _BaseNormalIntensity );
				unpack570.z = lerp( 1, unpack570.z, saturate(_BaseNormalIntensity) );
				float3 lerpResult573 = lerp( unpack569 , unpack570 , VColor_Blue_Tree_Mask561);
				float3 Base_Normal355 = lerpResult573;
				float3 ase_tangentWS = input.ase_texcoord5.xyz;
				float3 ase_normalWS = input.ase_texcoord6.xyz;
				float3 ase_bitangentWS = input.ase_texcoord7.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal776 = Base_Normal355;
				float3 worldNormal776 = float3( dot( tanToWorld0, tanNormal776 ), dot( tanToWorld1, tanNormal776 ), dot( tanToWorld2, tanNormal776 ) );
				float temp_output_616_0 = ( _TopLayerOffset * ASPT_TopLayerOffset );
				float saferPower17_g23 = abs( abs( ( saturate( worldNormal776.y ) + temp_output_616_0 ) ) );
				float temp_output_617_0 = ( _TopLayerContrast * ASPT_TopLayerContrast );
				float temp_output_615_0 = ( _TopLayerIntensity * ASPT_TopLayerIntensity );
				float3 tanNormal629 = Base_Normal355;
				float3 worldNormal629 = float3( dot( tanToWorld0, tanNormal629 ), dot( tanToWorld1, tanNormal629 ), dot( tanToWorld2, tanNormal629 ) );
				float3 Global_Arrow_Direction655 = ASPW_WindDirection;
				float dotResult633 = dot( worldNormal629 , Global_Arrow_Direction655 );
				float dotResult682 = dot( worldNormal629 , float3(0,1,0) );
				float2 texCoord668 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float Arrow_Direction_Mask693 = ( ( ( 1.0 - dotResult633 ) * ( _TopArrowDirectionOffset * ASPT_TopLayerArrowDirection ) ) * ( ( ( 3.0 - ( 1.0 - dotResult682 ) ) * ( 1.0 - texCoord668.y ) ) + 0.05 ) );
				float2 texCoord705 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_706_0 = ( 1.0 - texCoord705.y );
				float temp_output_711_0 = ( ( ( temp_output_706_0 * temp_output_706_0 ) * ( temp_output_706_0 * temp_output_706_0 ) ) * _TopLayerBottomOffset * ASPT_TopLayerBottomOffset );
				float3 tanNormal715 = Base_Normal355;
				float3 worldNormal715 = float3( dot( tanToWorld0, tanNormal715 ), dot( tanToWorld1, tanNormal715 ), dot( tanToWorld2, tanNormal715 ) );
				float dotResult716 = dot( worldNormal715 , float3(0,1,0) );
				float Top_Layer_Bottom_Offset721 = ( ( temp_output_711_0 * temp_output_711_0 ) + ( dotResult716 - 1.0 ) );
				float clampResult1046 = clamp( ( Arrow_Direction_Mask693 + Top_Layer_Bottom_Offset721 ) , 0.0 , 5.0 );
				float Top_Layer_Offset696 = temp_output_616_0;
				float saferPower698 = abs( ( clampResult1046 * Top_Layer_Offset696 ) );
				float Top_Layer_Contrast699 = temp_output_617_0;
				float Top_Layer_Intensity702 = temp_output_615_0;
				float Top_Layer_Direction1057 = saturate( ( pow( saferPower698 , Top_Layer_Contrast699 ) * Top_Layer_Intensity702 ) );
				float Top_Layer_Mask621 = saturate( ( ( ( saturate( pow( saferPower17_g23 , temp_output_617_0 ) ) * temp_output_615_0 ) + Top_Layer_Direction1057 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) ) );
				float3 lerpResult605 = lerp( Base_Albedo350 , ( (( blendOpDest599 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest599 ) * ( 1.0 - blendOpSrc599 ) ) : ( 2.0 * blendOpDest599 * blendOpSrc599 ) ) * Base_AO348 ) , Top_Layer_Mask621);
				float3 Top_Layer_Albedo625 = lerpResult605;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch623 = Top_Layer_Albedo625;
				#else
				float3 staticSwitch623 = Base_Albedo350;
				#endif
				float3 Output_Albedo627 = staticSwitch623;
				
				float lerpResult587 = lerp( tex2DNode577.a , tex2DNode576.a , VColor_Blue_Tree_Mask561);
				float Emissive_Mask371 = lerpResult587;
				float saferPower373 = abs( Emissive_Mask371 );
				float3 Base_Emissive377 = ( ( _BaseEmissiveColor * pow( saferPower373 , _BaseEmissiveMaskContrast ) ) * _BaseEmissiveIntensity );
				float3 lerpResult755 = lerp( Base_Emissive377 , float3( 0,0,0 ) , Top_Layer_Mask621);
				float3 Top_Layer_Emissive757 = lerpResult755;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch766 = Top_Layer_Emissive757;
				#else
				float3 staticSwitch766 = Base_Emissive377;
				#endif
				float3 Output_Emissive769 = staticSwitch766;
				

				float3 BaseColor = Output_Albedo627;
				float3 Emission = Output_Emissive769;
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

			#pragma multi_compile_fragment _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
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


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord3 : TEXCOORD3;
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
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_texcoord6 : TEXCOORD6;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _WindTreeFlexibility;
			half _BaseSmoothnessMax;
			half _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			float _TopLayerBottomOffset;
			half _TopArrowDirectionOffset;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _BaseTreeAOIntensity;
			half _BaseBarkAOIntensity;
			float _TopLayerUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindTreeBaseRigidity;
			half _TopLayerSmoothnessMin;
			half _TopLayerSmoothnessMax;
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
			float ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			sampler2D _TopLayerAlbedo;
			sampler2D _BaseSMAE;
			sampler2D _BaseNormal;
			half ASPT_TopLayerOffset;
			half ASPT_TopLayerContrast;
			half ASPT_TopLayerIntensity;
			half ASPT_TopLayerArrowDirection;
			half ASPT_TopLayerBottomOffset;
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
				float3 Global_Wind_Direction493_g22 = ASPW_WindDirection;
				float3 worldToObjDir269_g22 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g22, 0.0 ) ).xyz;
				float3 normalizeResult268_g22 = ASESafeNormalize( worldToObjDir269_g22 );
				float3 Wind_Direction_Leaf85_g22 = normalizeResult268_g22;
				float3 break86_g22 = Wind_Direction_Leaf85_g22;
				float3 appendResult89_g22 = (float3(break86_g22.z , 0.0 , ( break86_g22.x * -1.0 )));
				float3 Wind_Direction91_g22 = appendResult89_g22;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g22 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g22 = ( Wind_Tree_Randomization149_g22 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g22 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g22 = ( Global_Wind_Tree_Speed491_g22 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g22 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g22 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g22 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g22 ) * 0.3 );
				float Wind_Tree_257_g22 = ( ( ( ( ( sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.1 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.3 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g22 ) * Global_Wind_Tree_Amplitude464_g22 ) * 0.01 ) * temp_output_383_0_g22 );
				float3 rotatedValue99_g22 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g22, Wind_Tree_257_g22 );
				float3 Rotate_About_Axis354_g22 = ( rotatedValue99_g22 - input.positionOS.xyz );
				float3 break452_g22 = normalizeResult268_g22;
				float3 appendResult454_g22 = (float3(break452_g22.x , 0.0 , break452_g22.z));
				float3 Wind_Direction_SM_Support453_g22 = appendResult454_g22;
				float Wind_Tree_Flexibility483_g22 = temp_output_383_0_g22;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g22 = ( Global_Wind_Tree_Amplitude464_g22 * Wind_Tree_257_g22 * Wind_Direction_SM_Support453_g22 * Wind_Tree_Flexibility483_g22 );
				#else
				float3 staticSwitch482_g22 = Rotate_About_Axis354_g22;
				#endif
				float3 Wind_Global450_g22 = staticSwitch482_g22;
				float2 texCoord433_g22 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g22 = texCoord433_g22.y;
				float saferPower113_g22 = abs( Wind_Mask_UV_CH2_VChannel434_g22 );
				float Wind_Tree_Mask114_g22 = pow( saferPower113_g22 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g22 = ( Wind_Global450_g22 * Wind_Tree_Mask114_g22 );
				float Global_Wind_Toggle504_g22 = ASPW_WindToggle;
				float3 lerpResult124_g22 = lerp( float3( 0,0,0 ) , temp_output_385_0_g22 , Global_Wind_Toggle504_g22);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch468_g22 = lerpResult124_g22;
				#else
				float3 staticSwitch468_g22 = temp_cast_0;
				#endif
				
				float3 ase_tangentWS = TransformObjectToWorldDir( input.ase_tangent.xyz );
				output.ase_texcoord3.xyz = ase_tangentWS;
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord4.xyz = ase_normalWS;
				float ase_tangentSign = input.ase_tangent.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord5.xyz = ase_bitangentWS;
				
				output.ase_texcoord2.xy = input.ase_texcoord.xy;
				output.ase_texcoord2.zw = input.ase_texcoord3.xy;
				output.ase_color = input.ase_color;
				output.ase_texcoord6.xy = input.ase_texcoord2.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord3.w = 0;
				output.ase_texcoord4.w = 0;
				output.ase_texcoord5.w = 0;
				output.ase_texcoord6.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch468_g22;

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
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.ase_texcoord2 = input.ase_texcoord2;
				output.ase_texcoord = input.ase_texcoord;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord2 = patch[0].ase_texcoord2 * bary.x + patch[1].ase_texcoord2 * bary.y + patch[2].ase_texcoord2 * bary.z;
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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

				float2 texCoord563 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float2 texCoord565 = input.ase_texcoord2.zw * float2( 1,1 ) + float2( 0,0 );
				float VColor_Blue_Tree_Mask561 = input.ase_color.b;
				float3 lerpResult566 = lerp( tex2D( _BaseAlbedo, texCoord563 ).rgb , tex2D( _BaseAlbedo, texCoord565 ).rgb , VColor_Blue_Tree_Mask561);
				float3 desaturateInitialColor1070 = lerpResult566;
				float desaturateDot1070 = dot( desaturateInitialColor1070, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar1070 = lerp( desaturateInitialColor1070, desaturateDot1070.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc345 = ( desaturateVar1070 * _BaseAlbedoBrightness );
				float3 blendOpDest345 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo350 = ( saturate( (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) ));
				float2 texCoord594 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale597 = ( texCoord594 * _TopLayerUVScale );
				float3 blendOpSrc599 = tex2D( _TopLayerAlbedo, Top_Layer_UV_Scale597 ).rgb;
				float3 blendOpDest599 = _TopLayerAlbedoColor.rgb;
				float2 texCoord580 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode577 = tex2D( _BaseSMAE, texCoord580 );
				float2 texCoord581 = input.ase_texcoord2.zw * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode576 = tex2D( _BaseSMAE, texCoord581 );
				float3 lerpResult579 = lerp( tex2DNode577.rgb , tex2DNode576.rgb , VColor_Blue_Tree_Mask561);
				float3 break582 = lerpResult579;
				float lerpResult365 = lerp( 1.0 , break582.z , _BaseBarkAOIntensity);
				float lerpResult559 = lerp( 1.0 , input.ase_color.a , _BaseTreeAOIntensity);
				float VColor_Alpha_Tree_AO562 = lerpResult559;
				float Base_AO348 = ( lerpResult365 * VColor_Alpha_Tree_AO562 );
				float2 texCoord571 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack569 = UnpackNormalScale( tex2D( _BaseNormal, texCoord571 ), _BaseNormalIntensity );
				unpack569.z = lerp( 1, unpack569.z, saturate(_BaseNormalIntensity) );
				float2 texCoord572 = input.ase_texcoord2.zw * float2( 1,1 ) + float2( 0,0 );
				float3 unpack570 = UnpackNormalScale( tex2D( _BaseNormal, texCoord572 ), _BaseNormalIntensity );
				unpack570.z = lerp( 1, unpack570.z, saturate(_BaseNormalIntensity) );
				float3 lerpResult573 = lerp( unpack569 , unpack570 , VColor_Blue_Tree_Mask561);
				float3 Base_Normal355 = lerpResult573;
				float3 ase_tangentWS = input.ase_texcoord3.xyz;
				float3 ase_normalWS = input.ase_texcoord4.xyz;
				float3 ase_bitangentWS = input.ase_texcoord5.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal776 = Base_Normal355;
				float3 worldNormal776 = float3( dot( tanToWorld0, tanNormal776 ), dot( tanToWorld1, tanNormal776 ), dot( tanToWorld2, tanNormal776 ) );
				float temp_output_616_0 = ( _TopLayerOffset * ASPT_TopLayerOffset );
				float saferPower17_g23 = abs( abs( ( saturate( worldNormal776.y ) + temp_output_616_0 ) ) );
				float temp_output_617_0 = ( _TopLayerContrast * ASPT_TopLayerContrast );
				float temp_output_615_0 = ( _TopLayerIntensity * ASPT_TopLayerIntensity );
				float3 tanNormal629 = Base_Normal355;
				float3 worldNormal629 = float3( dot( tanToWorld0, tanNormal629 ), dot( tanToWorld1, tanNormal629 ), dot( tanToWorld2, tanNormal629 ) );
				float3 Global_Arrow_Direction655 = ASPW_WindDirection;
				float dotResult633 = dot( worldNormal629 , Global_Arrow_Direction655 );
				float dotResult682 = dot( worldNormal629 , float3(0,1,0) );
				float2 texCoord668 = input.ase_texcoord6.xy * float2( 1,1 ) + float2( 0,0 );
				float Arrow_Direction_Mask693 = ( ( ( 1.0 - dotResult633 ) * ( _TopArrowDirectionOffset * ASPT_TopLayerArrowDirection ) ) * ( ( ( 3.0 - ( 1.0 - dotResult682 ) ) * ( 1.0 - texCoord668.y ) ) + 0.05 ) );
				float2 texCoord705 = input.ase_texcoord6.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_706_0 = ( 1.0 - texCoord705.y );
				float temp_output_711_0 = ( ( ( temp_output_706_0 * temp_output_706_0 ) * ( temp_output_706_0 * temp_output_706_0 ) ) * _TopLayerBottomOffset * ASPT_TopLayerBottomOffset );
				float3 tanNormal715 = Base_Normal355;
				float3 worldNormal715 = float3( dot( tanToWorld0, tanNormal715 ), dot( tanToWorld1, tanNormal715 ), dot( tanToWorld2, tanNormal715 ) );
				float dotResult716 = dot( worldNormal715 , float3(0,1,0) );
				float Top_Layer_Bottom_Offset721 = ( ( temp_output_711_0 * temp_output_711_0 ) + ( dotResult716 - 1.0 ) );
				float clampResult1046 = clamp( ( Arrow_Direction_Mask693 + Top_Layer_Bottom_Offset721 ) , 0.0 , 5.0 );
				float Top_Layer_Offset696 = temp_output_616_0;
				float saferPower698 = abs( ( clampResult1046 * Top_Layer_Offset696 ) );
				float Top_Layer_Contrast699 = temp_output_617_0;
				float Top_Layer_Intensity702 = temp_output_615_0;
				float Top_Layer_Direction1057 = saturate( ( pow( saferPower698 , Top_Layer_Contrast699 ) * Top_Layer_Intensity702 ) );
				float Top_Layer_Mask621 = saturate( ( ( ( saturate( pow( saferPower17_g23 , temp_output_617_0 ) ) * temp_output_615_0 ) + Top_Layer_Direction1057 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) ) );
				float3 lerpResult605 = lerp( Base_Albedo350 , ( (( blendOpDest599 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest599 ) * ( 1.0 - blendOpSrc599 ) ) : ( 2.0 * blendOpDest599 * blendOpSrc599 ) ) * Base_AO348 ) , Top_Layer_Mask621);
				float3 Top_Layer_Albedo625 = lerpResult605;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch623 = Top_Layer_Albedo625;
				#else
				float3 staticSwitch623 = Base_Albedo350;
				#endif
				float3 Output_Albedo627 = staticSwitch623;
				

				float3 BaseColor = Output_Albedo627;
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

			

			

			#pragma multi_compile _ALPHATEST_ON
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#pragma multi_compile_fragment _ DEBUG_DISPLAY
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
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_VERT_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON


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
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_color : COLOR;
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
				float4 ase_texcoord6 : TEXCOORD6;
				float4 ase_texcoord7 : TEXCOORD7;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _WindTreeFlexibility;
			half _BaseSmoothnessMax;
			half _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			float _TopLayerBottomOffset;
			half _TopArrowDirectionOffset;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _BaseTreeAOIntensity;
			half _BaseBarkAOIntensity;
			float _TopLayerUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindTreeBaseRigidity;
			half _TopLayerSmoothnessMin;
			half _TopLayerSmoothnessMax;
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
			float ASPW_WindToggle;
			sampler2D _BaseNormal;
			sampler2D _TopLayerNormal;
			half ASPT_TopLayerOffset;
			half ASPT_TopLayerContrast;
			half ASPT_TopLayerIntensity;
			half ASPT_TopLayerArrowDirection;
			half ASPT_TopLayerBottomOffset;
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
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction493_g22 = ASPW_WindDirection;
				float3 worldToObjDir269_g22 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g22, 0.0 ) ).xyz;
				float3 normalizeResult268_g22 = ASESafeNormalize( worldToObjDir269_g22 );
				float3 Wind_Direction_Leaf85_g22 = normalizeResult268_g22;
				float3 break86_g22 = Wind_Direction_Leaf85_g22;
				float3 appendResult89_g22 = (float3(break86_g22.z , 0.0 , ( break86_g22.x * -1.0 )));
				float3 Wind_Direction91_g22 = appendResult89_g22;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g22 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g22 = ( Wind_Tree_Randomization149_g22 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g22 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g22 = ( Global_Wind_Tree_Speed491_g22 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g22 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g22 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g22 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g22 ) * 0.3 );
				float Wind_Tree_257_g22 = ( ( ( ( ( sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.1 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.3 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g22 ) * Global_Wind_Tree_Amplitude464_g22 ) * 0.01 ) * temp_output_383_0_g22 );
				float3 rotatedValue99_g22 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g22, Wind_Tree_257_g22 );
				float3 Rotate_About_Axis354_g22 = ( rotatedValue99_g22 - input.positionOS.xyz );
				float3 break452_g22 = normalizeResult268_g22;
				float3 appendResult454_g22 = (float3(break452_g22.x , 0.0 , break452_g22.z));
				float3 Wind_Direction_SM_Support453_g22 = appendResult454_g22;
				float Wind_Tree_Flexibility483_g22 = temp_output_383_0_g22;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g22 = ( Global_Wind_Tree_Amplitude464_g22 * Wind_Tree_257_g22 * Wind_Direction_SM_Support453_g22 * Wind_Tree_Flexibility483_g22 );
				#else
				float3 staticSwitch482_g22 = Rotate_About_Axis354_g22;
				#endif
				float3 Wind_Global450_g22 = staticSwitch482_g22;
				float2 texCoord433_g22 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g22 = texCoord433_g22.y;
				float saferPower113_g22 = abs( Wind_Mask_UV_CH2_VChannel434_g22 );
				float Wind_Tree_Mask114_g22 = pow( saferPower113_g22 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g22 = ( Wind_Global450_g22 * Wind_Tree_Mask114_g22 );
				float Global_Wind_Toggle504_g22 = ASPW_WindToggle;
				float3 lerpResult124_g22 = lerp( float3( 0,0,0 ) , temp_output_385_0_g22 , Global_Wind_Toggle504_g22);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch468_g22 = lerpResult124_g22;
				#else
				float3 staticSwitch468_g22 = temp_cast_0;
				#endif
				
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				float3 ase_tangentWS = TransformObjectToWorldDir( input.tangentOS.xyz );
				float ase_tangentSign = input.tangentOS.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord6.xyz = ase_bitangentWS;
				
				output.ase_texcoord5.xy = input.ase_texcoord.xy;
				output.ase_texcoord5.zw = input.ase_texcoord3.xy;
				output.ase_color = input.ase_color;
				output.ase_texcoord7.xy = input.ase_texcoord2.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord6.w = 0;
				output.ase_texcoord7.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch468_g22;

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
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.ase_texcoord = input.ase_texcoord;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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

				float2 texCoord571 = input.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack569 = UnpackNormalScale( tex2D( _BaseNormal, texCoord571 ), _BaseNormalIntensity );
				unpack569.z = lerp( 1, unpack569.z, saturate(_BaseNormalIntensity) );
				float2 texCoord572 = input.ase_texcoord5.zw * float2( 1,1 ) + float2( 0,0 );
				float3 unpack570 = UnpackNormalScale( tex2D( _BaseNormal, texCoord572 ), _BaseNormalIntensity );
				unpack570.z = lerp( 1, unpack570.z, saturate(_BaseNormalIntensity) );
				float VColor_Blue_Tree_Mask561 = input.ase_color.b;
				float3 lerpResult573 = lerp( unpack569 , unpack570 , VColor_Blue_Tree_Mask561);
				float3 Base_Normal355 = lerpResult573;
				float2 texCoord594 = input.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale597 = ( texCoord594 * _TopLayerUVScale );
				float3 unpack646 = UnpackNormalScale( tex2D( _TopLayerNormal, Top_Layer_UV_Scale597 ), _TopLayerNormalIntensity );
				unpack646.z = lerp( 1, unpack646.z, saturate(_TopLayerNormalIntensity) );
				float3 tex2DNode646 = unpack646;
				float3 lerpResult649 = lerp( BlendNormal( tex2DNode646 , Base_Normal355 ) , tex2DNode646 , _TopLayerNormalInfluence);
				float3 ase_bitangentWS = input.ase_texcoord6.xyz;
				float3 tanToWorld0 = float3( WorldTangent.xyz.x, ase_bitangentWS.x, WorldNormal.x );
				float3 tanToWorld1 = float3( WorldTangent.xyz.y, ase_bitangentWS.y, WorldNormal.y );
				float3 tanToWorld2 = float3( WorldTangent.xyz.z, ase_bitangentWS.z, WorldNormal.z );
				float3 tanNormal776 = Base_Normal355;
				float3 worldNormal776 = float3( dot( tanToWorld0, tanNormal776 ), dot( tanToWorld1, tanNormal776 ), dot( tanToWorld2, tanNormal776 ) );
				float temp_output_616_0 = ( _TopLayerOffset * ASPT_TopLayerOffset );
				float saferPower17_g23 = abs( abs( ( saturate( worldNormal776.y ) + temp_output_616_0 ) ) );
				float temp_output_617_0 = ( _TopLayerContrast * ASPT_TopLayerContrast );
				float temp_output_615_0 = ( _TopLayerIntensity * ASPT_TopLayerIntensity );
				float3 tanNormal629 = Base_Normal355;
				float3 worldNormal629 = float3( dot( tanToWorld0, tanNormal629 ), dot( tanToWorld1, tanNormal629 ), dot( tanToWorld2, tanNormal629 ) );
				float3 Global_Arrow_Direction655 = ASPW_WindDirection;
				float dotResult633 = dot( worldNormal629 , Global_Arrow_Direction655 );
				float dotResult682 = dot( worldNormal629 , float3(0,1,0) );
				float2 texCoord668 = input.ase_texcoord7.xy * float2( 1,1 ) + float2( 0,0 );
				float Arrow_Direction_Mask693 = ( ( ( 1.0 - dotResult633 ) * ( _TopArrowDirectionOffset * ASPT_TopLayerArrowDirection ) ) * ( ( ( 3.0 - ( 1.0 - dotResult682 ) ) * ( 1.0 - texCoord668.y ) ) + 0.05 ) );
				float2 texCoord705 = input.ase_texcoord7.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_706_0 = ( 1.0 - texCoord705.y );
				float temp_output_711_0 = ( ( ( temp_output_706_0 * temp_output_706_0 ) * ( temp_output_706_0 * temp_output_706_0 ) ) * _TopLayerBottomOffset * ASPT_TopLayerBottomOffset );
				float3 tanNormal715 = Base_Normal355;
				float3 worldNormal715 = float3( dot( tanToWorld0, tanNormal715 ), dot( tanToWorld1, tanNormal715 ), dot( tanToWorld2, tanNormal715 ) );
				float dotResult716 = dot( worldNormal715 , float3(0,1,0) );
				float Top_Layer_Bottom_Offset721 = ( ( temp_output_711_0 * temp_output_711_0 ) + ( dotResult716 - 1.0 ) );
				float clampResult1046 = clamp( ( Arrow_Direction_Mask693 + Top_Layer_Bottom_Offset721 ) , 0.0 , 5.0 );
				float Top_Layer_Offset696 = temp_output_616_0;
				float saferPower698 = abs( ( clampResult1046 * Top_Layer_Offset696 ) );
				float Top_Layer_Contrast699 = temp_output_617_0;
				float Top_Layer_Intensity702 = temp_output_615_0;
				float Top_Layer_Direction1057 = saturate( ( pow( saferPower698 , Top_Layer_Contrast699 ) * Top_Layer_Intensity702 ) );
				float Top_Layer_Mask621 = saturate( ( ( ( saturate( pow( saferPower17_g23 , temp_output_617_0 ) ) * temp_output_615_0 ) + Top_Layer_Direction1057 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) ) );
				float3 lerpResult652 = lerp( Base_Normal355 , lerpResult649 , Top_Layer_Mask621);
				float3 Top_Layer_Normal653 = lerpResult652;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch738 = Top_Layer_Normal653;
				#else
				float3 staticSwitch738 = Base_Normal355;
				#endif
				float3 Output_Normal742 = staticSwitch738;
				

				float3 Normal = Output_Normal742;
				float Alpha = 1;
				float AlphaClipThreshold = 0.5;

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
			#define _EMISSION
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
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLEWIND_ON
			#pragma shader_feature_local _ENABLESTATICMESHSUPPORT_ON
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON


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
				float4 ase_texcoord3 : TEXCOORD3;
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
				float4 ase_texcoord9 : TEXCOORD9;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _WindTreeFlexibility;
			half _BaseSmoothnessMax;
			half _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			float _TopLayerBottomOffset;
			half _TopArrowDirectionOffset;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _BaseTreeAOIntensity;
			half _BaseBarkAOIntensity;
			float _TopLayerUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindTreeBaseRigidity;
			half _TopLayerSmoothnessMin;
			half _TopLayerSmoothnessMax;
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
			float ASPW_WindToggle;
			sampler2D _BaseAlbedo;
			sampler2D _TopLayerAlbedo;
			sampler2D _BaseSMAE;
			sampler2D _BaseNormal;
			half ASPT_TopLayerOffset;
			half ASPT_TopLayerContrast;
			half ASPT_TopLayerIntensity;
			half ASPT_TopLayerArrowDirection;
			half ASPT_TopLayerBottomOffset;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;
			sampler2D _TopLayerNormal;
			sampler2D _TopLayerSmoothness;


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
			

			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 temp_cast_0 = (0.0).xxx;
				float3 Global_Wind_Direction493_g22 = ASPW_WindDirection;
				float3 worldToObjDir269_g22 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g22, 0.0 ) ).xyz;
				float3 normalizeResult268_g22 = ASESafeNormalize( worldToObjDir269_g22 );
				float3 Wind_Direction_Leaf85_g22 = normalizeResult268_g22;
				float3 break86_g22 = Wind_Direction_Leaf85_g22;
				float3 appendResult89_g22 = (float3(break86_g22.z , 0.0 , ( break86_g22.x * -1.0 )));
				float3 Wind_Direction91_g22 = appendResult89_g22;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g22 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g22 = ( Wind_Tree_Randomization149_g22 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g22 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g22 = ( Global_Wind_Tree_Speed491_g22 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g22 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g22 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g22 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g22 ) * 0.3 );
				float Wind_Tree_257_g22 = ( ( ( ( ( sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.1 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.3 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g22 ) * Global_Wind_Tree_Amplitude464_g22 ) * 0.01 ) * temp_output_383_0_g22 );
				float3 rotatedValue99_g22 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g22, Wind_Tree_257_g22 );
				float3 Rotate_About_Axis354_g22 = ( rotatedValue99_g22 - input.positionOS.xyz );
				float3 break452_g22 = normalizeResult268_g22;
				float3 appendResult454_g22 = (float3(break452_g22.x , 0.0 , break452_g22.z));
				float3 Wind_Direction_SM_Support453_g22 = appendResult454_g22;
				float Wind_Tree_Flexibility483_g22 = temp_output_383_0_g22;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g22 = ( Global_Wind_Tree_Amplitude464_g22 * Wind_Tree_257_g22 * Wind_Direction_SM_Support453_g22 * Wind_Tree_Flexibility483_g22 );
				#else
				float3 staticSwitch482_g22 = Rotate_About_Axis354_g22;
				#endif
				float3 Wind_Global450_g22 = staticSwitch482_g22;
				float2 texCoord433_g22 = input.texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g22 = texCoord433_g22.y;
				float saferPower113_g22 = abs( Wind_Mask_UV_CH2_VChannel434_g22 );
				float Wind_Tree_Mask114_g22 = pow( saferPower113_g22 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g22 = ( Wind_Global450_g22 * Wind_Tree_Mask114_g22 );
				float Global_Wind_Toggle504_g22 = ASPW_WindToggle;
				float3 lerpResult124_g22 = lerp( float3( 0,0,0 ) , temp_output_385_0_g22 , Global_Wind_Toggle504_g22);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch468_g22 = lerpResult124_g22;
				#else
				float3 staticSwitch468_g22 = temp_cast_0;
				#endif
				
				output.ase_texcoord8.xy = input.texcoord.xy;
				output.ase_texcoord8.zw = input.ase_texcoord3.xy;
				output.ase_color = input.ase_color;
				output.ase_texcoord9.xy = input.texcoord2.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord9.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch468_g22;

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
				float4 ase_texcoord3 : TEXCOORD3;
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
				output.texcoord = input.texcoord;
				output.ase_texcoord3 = input.ase_texcoord3;
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
				output.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				output.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
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

				float2 texCoord563 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 texCoord565 = input.ase_texcoord8.zw * float2( 1,1 ) + float2( 0,0 );
				float VColor_Blue_Tree_Mask561 = input.ase_color.b;
				float3 lerpResult566 = lerp( tex2D( _BaseAlbedo, texCoord563 ).rgb , tex2D( _BaseAlbedo, texCoord565 ).rgb , VColor_Blue_Tree_Mask561);
				float3 desaturateInitialColor1070 = lerpResult566;
				float desaturateDot1070 = dot( desaturateInitialColor1070, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar1070 = lerp( desaturateInitialColor1070, desaturateDot1070.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc345 = ( desaturateVar1070 * _BaseAlbedoBrightness );
				float3 blendOpDest345 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo350 = ( saturate( (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) ));
				float2 texCoord594 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale597 = ( texCoord594 * _TopLayerUVScale );
				float3 blendOpSrc599 = tex2D( _TopLayerAlbedo, Top_Layer_UV_Scale597 ).rgb;
				float3 blendOpDest599 = _TopLayerAlbedoColor.rgb;
				float2 texCoord580 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode577 = tex2D( _BaseSMAE, texCoord580 );
				float2 texCoord581 = input.ase_texcoord8.zw * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode576 = tex2D( _BaseSMAE, texCoord581 );
				float3 lerpResult579 = lerp( tex2DNode577.rgb , tex2DNode576.rgb , VColor_Blue_Tree_Mask561);
				float3 break582 = lerpResult579;
				float lerpResult365 = lerp( 1.0 , break582.z , _BaseBarkAOIntensity);
				float lerpResult559 = lerp( 1.0 , input.ase_color.a , _BaseTreeAOIntensity);
				float VColor_Alpha_Tree_AO562 = lerpResult559;
				float Base_AO348 = ( lerpResult365 * VColor_Alpha_Tree_AO562 );
				float2 texCoord571 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack569 = UnpackNormalScale( tex2D( _BaseNormal, texCoord571 ), _BaseNormalIntensity );
				unpack569.z = lerp( 1, unpack569.z, saturate(_BaseNormalIntensity) );
				float2 texCoord572 = input.ase_texcoord8.zw * float2( 1,1 ) + float2( 0,0 );
				float3 unpack570 = UnpackNormalScale( tex2D( _BaseNormal, texCoord572 ), _BaseNormalIntensity );
				unpack570.z = lerp( 1, unpack570.z, saturate(_BaseNormalIntensity) );
				float3 lerpResult573 = lerp( unpack569 , unpack570 , VColor_Blue_Tree_Mask561);
				float3 Base_Normal355 = lerpResult573;
				float3 tanToWorld0 = float3( WorldTangent.x, WorldBiTangent.x, WorldNormal.x );
				float3 tanToWorld1 = float3( WorldTangent.y, WorldBiTangent.y, WorldNormal.y );
				float3 tanToWorld2 = float3( WorldTangent.z, WorldBiTangent.z, WorldNormal.z );
				float3 tanNormal776 = Base_Normal355;
				float3 worldNormal776 = float3( dot( tanToWorld0, tanNormal776 ), dot( tanToWorld1, tanNormal776 ), dot( tanToWorld2, tanNormal776 ) );
				float temp_output_616_0 = ( _TopLayerOffset * ASPT_TopLayerOffset );
				float saferPower17_g23 = abs( abs( ( saturate( worldNormal776.y ) + temp_output_616_0 ) ) );
				float temp_output_617_0 = ( _TopLayerContrast * ASPT_TopLayerContrast );
				float temp_output_615_0 = ( _TopLayerIntensity * ASPT_TopLayerIntensity );
				float3 tanNormal629 = Base_Normal355;
				float3 worldNormal629 = float3( dot( tanToWorld0, tanNormal629 ), dot( tanToWorld1, tanNormal629 ), dot( tanToWorld2, tanNormal629 ) );
				float3 Global_Arrow_Direction655 = ASPW_WindDirection;
				float dotResult633 = dot( worldNormal629 , Global_Arrow_Direction655 );
				float dotResult682 = dot( worldNormal629 , float3(0,1,0) );
				float2 texCoord668 = input.ase_texcoord9.xy * float2( 1,1 ) + float2( 0,0 );
				float Arrow_Direction_Mask693 = ( ( ( 1.0 - dotResult633 ) * ( _TopArrowDirectionOffset * ASPT_TopLayerArrowDirection ) ) * ( ( ( 3.0 - ( 1.0 - dotResult682 ) ) * ( 1.0 - texCoord668.y ) ) + 0.05 ) );
				float2 texCoord705 = input.ase_texcoord9.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_706_0 = ( 1.0 - texCoord705.y );
				float temp_output_711_0 = ( ( ( temp_output_706_0 * temp_output_706_0 ) * ( temp_output_706_0 * temp_output_706_0 ) ) * _TopLayerBottomOffset * ASPT_TopLayerBottomOffset );
				float3 tanNormal715 = Base_Normal355;
				float3 worldNormal715 = float3( dot( tanToWorld0, tanNormal715 ), dot( tanToWorld1, tanNormal715 ), dot( tanToWorld2, tanNormal715 ) );
				float dotResult716 = dot( worldNormal715 , float3(0,1,0) );
				float Top_Layer_Bottom_Offset721 = ( ( temp_output_711_0 * temp_output_711_0 ) + ( dotResult716 - 1.0 ) );
				float clampResult1046 = clamp( ( Arrow_Direction_Mask693 + Top_Layer_Bottom_Offset721 ) , 0.0 , 5.0 );
				float Top_Layer_Offset696 = temp_output_616_0;
				float saferPower698 = abs( ( clampResult1046 * Top_Layer_Offset696 ) );
				float Top_Layer_Contrast699 = temp_output_617_0;
				float Top_Layer_Intensity702 = temp_output_615_0;
				float Top_Layer_Direction1057 = saturate( ( pow( saferPower698 , Top_Layer_Contrast699 ) * Top_Layer_Intensity702 ) );
				float Top_Layer_Mask621 = saturate( ( ( ( saturate( pow( saferPower17_g23 , temp_output_617_0 ) ) * temp_output_615_0 ) + Top_Layer_Direction1057 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) ) );
				float3 lerpResult605 = lerp( Base_Albedo350 , ( (( blendOpDest599 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest599 ) * ( 1.0 - blendOpSrc599 ) ) : ( 2.0 * blendOpDest599 * blendOpSrc599 ) ) * Base_AO348 ) , Top_Layer_Mask621);
				float3 Top_Layer_Albedo625 = lerpResult605;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch623 = Top_Layer_Albedo625;
				#else
				float3 staticSwitch623 = Base_Albedo350;
				#endif
				float3 Output_Albedo627 = staticSwitch623;
				
				float3 unpack646 = UnpackNormalScale( tex2D( _TopLayerNormal, Top_Layer_UV_Scale597 ), _TopLayerNormalIntensity );
				unpack646.z = lerp( 1, unpack646.z, saturate(_TopLayerNormalIntensity) );
				float3 tex2DNode646 = unpack646;
				float3 lerpResult649 = lerp( BlendNormal( tex2DNode646 , Base_Normal355 ) , tex2DNode646 , _TopLayerNormalInfluence);
				float3 lerpResult652 = lerp( Base_Normal355 , lerpResult649 , Top_Layer_Mask621);
				float3 Top_Layer_Normal653 = lerpResult652;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch738 = Top_Layer_Normal653;
				#else
				float3 staticSwitch738 = Base_Normal355;
				#endif
				float3 Output_Normal742 = staticSwitch738;
				
				float lerpResult587 = lerp( tex2DNode577.a , tex2DNode576.a , VColor_Blue_Tree_Mask561);
				float Emissive_Mask371 = lerpResult587;
				float saferPower373 = abs( Emissive_Mask371 );
				float3 Base_Emissive377 = ( ( _BaseEmissiveColor * pow( saferPower373 , _BaseEmissiveMaskContrast ) ) * _BaseEmissiveIntensity );
				float3 lerpResult755 = lerp( Base_Emissive377 , float3( 0,0,0 ) , Top_Layer_Mask621);
				float3 Top_Layer_Emissive757 = lerpResult755;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch766 = Top_Layer_Emissive757;
				#else
				float3 staticSwitch766 = Base_Emissive377;
				#endif
				float3 Output_Emissive769 = staticSwitch766;
				
				float Base_Metallic364 = ( break582.y * _BaseMetallicIntensity );
				float lerpResult747 = lerp( Base_Metallic364 , 0.0 , Top_Layer_Mask621);
				float Top_Layer_Metallic749 = lerpResult747;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch758 = Top_Layer_Metallic749;
				#else
				float staticSwitch758 = Base_Metallic364;
				#endif
				float Output_Metallic761 = staticSwitch758;
				
				float Texture_Smoothness1073 = break582.x;
				float lerpResult1076 = lerp( _BaseSmoothnessMin , _BaseSmoothnessMax , Texture_Smoothness1073);
				float Base_Smoothness361 = saturate( lerpResult1076 );
				float lerpResult1079 = lerp( _TopLayerSmoothnessMin , _TopLayerSmoothnessMax , tex2D( _TopLayerSmoothness, Top_Layer_UV_Scale597 ).r);
				float lerpResult734 = lerp( Base_Smoothness361 , lerpResult1079 , Top_Layer_Mask621);
				float Top_Layer_Smoothness737 = saturate( lerpResult734 );
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch741 = Top_Layer_Smoothness737;
				#else
				float staticSwitch741 = Base_Smoothness361;
				#endif
				float Output_Smoothness745 = staticSwitch741;
				
				float lerpResult751 = lerp( Base_AO348 , 1.0 , Top_Layer_Mask621);
				float Top_Layer_AO753 = lerpResult751;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch762 = Top_Layer_AO753;
				#else
				float staticSwitch762 = Base_AO348;
				#endif
				float Output_AO765 = staticSwitch762;
				

				float3 BaseColor = Output_Albedo627;
				float3 Normal = Output_Normal742;
				float3 Emission = Output_Emissive769;
				float3 Specular = 0.5;
				float Metallic = Output_Metallic761;
				float Smoothness = Output_Smoothness745;
				float Occlusion = Output_AO765;
				float Alpha = 1;
				float AlphaClipThreshold = 0.5;
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


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_texcoord2 : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _WindTreeFlexibility;
			half _BaseSmoothnessMax;
			half _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			float _TopLayerBottomOffset;
			half _TopArrowDirectionOffset;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _BaseTreeAOIntensity;
			half _BaseBarkAOIntensity;
			float _TopLayerUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindTreeBaseRigidity;
			half _TopLayerSmoothnessMin;
			half _TopLayerSmoothnessMax;
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
			float ASPW_WindToggle;


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
				float3 Global_Wind_Direction493_g22 = ASPW_WindDirection;
				float3 worldToObjDir269_g22 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g22, 0.0 ) ).xyz;
				float3 normalizeResult268_g22 = ASESafeNormalize( worldToObjDir269_g22 );
				float3 Wind_Direction_Leaf85_g22 = normalizeResult268_g22;
				float3 break86_g22 = Wind_Direction_Leaf85_g22;
				float3 appendResult89_g22 = (float3(break86_g22.z , 0.0 , ( break86_g22.x * -1.0 )));
				float3 Wind_Direction91_g22 = appendResult89_g22;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g22 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g22 = ( Wind_Tree_Randomization149_g22 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g22 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g22 = ( Global_Wind_Tree_Speed491_g22 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g22 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g22 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g22 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g22 ) * 0.3 );
				float Wind_Tree_257_g22 = ( ( ( ( ( sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.1 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.3 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g22 ) * Global_Wind_Tree_Amplitude464_g22 ) * 0.01 ) * temp_output_383_0_g22 );
				float3 rotatedValue99_g22 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g22, Wind_Tree_257_g22 );
				float3 Rotate_About_Axis354_g22 = ( rotatedValue99_g22 - input.positionOS.xyz );
				float3 break452_g22 = normalizeResult268_g22;
				float3 appendResult454_g22 = (float3(break452_g22.x , 0.0 , break452_g22.z));
				float3 Wind_Direction_SM_Support453_g22 = appendResult454_g22;
				float Wind_Tree_Flexibility483_g22 = temp_output_383_0_g22;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g22 = ( Global_Wind_Tree_Amplitude464_g22 * Wind_Tree_257_g22 * Wind_Direction_SM_Support453_g22 * Wind_Tree_Flexibility483_g22 );
				#else
				float3 staticSwitch482_g22 = Rotate_About_Axis354_g22;
				#endif
				float3 Wind_Global450_g22 = staticSwitch482_g22;
				float2 texCoord433_g22 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g22 = texCoord433_g22.y;
				float saferPower113_g22 = abs( Wind_Mask_UV_CH2_VChannel434_g22 );
				float Wind_Tree_Mask114_g22 = pow( saferPower113_g22 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g22 = ( Wind_Global450_g22 * Wind_Tree_Mask114_g22 );
				float Global_Wind_Toggle504_g22 = ASPW_WindToggle;
				float3 lerpResult124_g22 = lerp( float3( 0,0,0 ) , temp_output_385_0_g22 , Global_Wind_Toggle504_g22);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch468_g22 = lerpResult124_g22;
				#else
				float3 staticSwitch468_g22 = temp_cast_0;
				#endif
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch468_g22;

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

				

				surfaceDescription.Alpha = 1;
				surfaceDescription.AlphaClipThreshold = 0.5;

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


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_texcoord2 : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct PackedVaryings
			{
				float4 positionCS : SV_POSITION;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _WindTreeFlexibility;
			half _BaseSmoothnessMax;
			half _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			float _TopLayerBottomOffset;
			half _TopArrowDirectionOffset;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _BaseTreeAOIntensity;
			half _BaseBarkAOIntensity;
			float _TopLayerUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _WindTreeBaseRigidity;
			half _TopLayerSmoothnessMin;
			half _TopLayerSmoothnessMax;
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
			float ASPW_WindToggle;


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
				float3 Global_Wind_Direction493_g22 = ASPW_WindDirection;
				float3 worldToObjDir269_g22 = mul( GetWorldToObjectMatrix(), float4( Global_Wind_Direction493_g22, 0.0 ) ).xyz;
				float3 normalizeResult268_g22 = ASESafeNormalize( worldToObjDir269_g22 );
				float3 Wind_Direction_Leaf85_g22 = normalizeResult268_g22;
				float3 break86_g22 = Wind_Direction_Leaf85_g22;
				float3 appendResult89_g22 = (float3(break86_g22.z , 0.0 , ( break86_g22.x * -1.0 )));
				float3 Wind_Direction91_g22 = appendResult89_g22;
				float3 ase_objectPosition = GetAbsolutePositionWS( UNITY_MATRIX_M._m03_m13_m23 );
				float Wind_Tree_Randomization149_g22 = frac( ( ( ase_objectPosition.x + ase_objectPosition.y + ase_objectPosition.z ) * 1.23 ) );
				float temp_output_56_0_g22 = ( Wind_Tree_Randomization149_g22 + _TimeParameters.x );
				float Global_Wind_Tree_Speed491_g22 = ASPW_WindTreeSpeed;
				float temp_output_213_0_g22 = ( Global_Wind_Tree_Speed491_g22 * 7.0 );
				float Global_Wind_Tree_Amplitude464_g22 = ASPW_WindTreeAmplitude;
				float Global_Wind_Tree_Flexibility490_g22 = ASPW_WindTreeFlexibility;
				float temp_output_383_0_g22 = ( ( _WindTreeFlexibility * Global_Wind_Tree_Flexibility490_g22 ) * 0.3 );
				float Wind_Tree_257_g22 = ( ( ( ( ( sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.1 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.3 ) ) ) + sin( ( temp_output_56_0_g22 * ( temp_output_213_0_g22 * 0.5 ) ) ) ) + Global_Wind_Tree_Amplitude464_g22 ) * Global_Wind_Tree_Amplitude464_g22 ) * 0.01 ) * temp_output_383_0_g22 );
				float3 rotatedValue99_g22 = RotateAroundAxis( float3( 0,0,0 ), input.positionOS.xyz, Wind_Direction91_g22, Wind_Tree_257_g22 );
				float3 Rotate_About_Axis354_g22 = ( rotatedValue99_g22 - input.positionOS.xyz );
				float3 break452_g22 = normalizeResult268_g22;
				float3 appendResult454_g22 = (float3(break452_g22.x , 0.0 , break452_g22.z));
				float3 Wind_Direction_SM_Support453_g22 = appendResult454_g22;
				float Wind_Tree_Flexibility483_g22 = temp_output_383_0_g22;
				#ifdef _ENABLESTATICMESHSUPPORT_ON
				float3 staticSwitch482_g22 = ( Global_Wind_Tree_Amplitude464_g22 * Wind_Tree_257_g22 * Wind_Direction_SM_Support453_g22 * Wind_Tree_Flexibility483_g22 );
				#else
				float3 staticSwitch482_g22 = Rotate_About_Axis354_g22;
				#endif
				float3 Wind_Global450_g22 = staticSwitch482_g22;
				float2 texCoord433_g22 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float Wind_Mask_UV_CH2_VChannel434_g22 = texCoord433_g22.y;
				float saferPower113_g22 = abs( Wind_Mask_UV_CH2_VChannel434_g22 );
				float Wind_Tree_Mask114_g22 = pow( saferPower113_g22 , _WindTreeBaseRigidity );
				float3 temp_output_385_0_g22 = ( Wind_Global450_g22 * Wind_Tree_Mask114_g22 );
				float Global_Wind_Toggle504_g22 = ASPW_WindToggle;
				float3 lerpResult124_g22 = lerp( float3( 0,0,0 ) , temp_output_385_0_g22 , Global_Wind_Toggle504_g22);
				#ifdef _ENABLEWIND_ON
				float3 staticSwitch468_g22 = lerpResult124_g22;
				#else
				float3 staticSwitch468_g22 = temp_cast_0;
				#endif
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = staticSwitch468_g22;

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

				

				surfaceDescription.Alpha = 1;
				surfaceDescription.AlphaClipThreshold = 0.5;

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
Node;AmplifyShaderEditor.CommentaryNode;1059;-560,4560;Inherit;False;1988;291;;12;694;725;697;724;1046;695;703;701;782;700;698;1057;Top Layer Mask - Bottom + Direction;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;974;5313,-3122;Inherit;False;1021.699;815.5093;;6;593;592;591;590;589;588;Output;1,0,0,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;977;-576,3536;Inherit;False;2110;811;;16;721;778;710;719;713;718;711;716;709;717;715;708;707;714;706;705;Top Layer Mask - Bottom Offset;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;976;-576,2384;Inherit;False;2233;1006;;20;693;631;632;671;692;637;690;636;635;691;666;633;668;689;663;630;682;629;683;628;Top Layer Mask - Arrow Direction;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;975;-574.2462,1104;Inherit;False;2492.488;934.5208;;20;621;704;1054;1058;657;1056;608;609;613;610;699;776;617;611;614;702;696;615;616;612;Top Layer Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;973;3140,-3122;Inherit;False;1083;1552;;24;743;744;765;762;764;763;769;761;745;742;627;766;758;741;738;623;768;767;760;759;740;739;626;624;Switches;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;972;-575.3077,592;Inherit;False;829.8768;302.2256;;4;597;596;595;594;Top Layer UVs;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;969;-574.2872,64;Inherit;False;1089.959;319.5745;;4;757;755;756;754;Top Layer Emissive;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;968;-576,-448;Inherit;False;1086.533;320.595;;4;753;751;752;750;Top Layer AO;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;967;-574.2872,-944;Inherit;False;1084.492;306.3078;;4;749;747;748;746;Top Layer Metallic;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;966;-572,-1584;Inherit;False;2238.248;486.1763;;10;949;734;736;735;1081;1080;1079;730;737;731;Top Layer Smoothness;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;965;-573,-2224;Inherit;False;2237.935;432.6967;;11;644;648;646;653;652;650;651;649;647;645;643;Top Layer Normal;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;964;-571,-2992;Inherit;False;1979;558;;10;601;600;625;605;607;606;604;599;603;602;Top Layer Albedo;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;963;-4032,1216;Inherit;False;570;238;;2;655;654;Global Arrow Direction;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;962;-4032,704;Inherit;False;960;341;Comment;5;561;562;783;559;558;VColor Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;961;-4032,-64;Inherit;False;1467;561;;8;376;374;377;375;370;369;373;372;Base Emissive;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;960;-4030,-1328;Inherit;False;2389.493;1073.822;[R] Smoothness | [G] Metallic | [B] AmbientOcclusion | [A] Emissive;25;1073;367;363;362;361;1078;1076;1074;1077;1075;348;575;576;364;371;587;583;584;365;582;579;578;577;581;580;Base SMAE;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;959;-4031,-2224;Inherit;False;1723;687;;9;568;354;355;573;574;570;569;572;571;Base Normal;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;958;-4030,-2994;Inherit;False;2370;594;;14;350;345;481;1069;1072;1068;1070;557;566;567;556;564;563;565;Base Albedo;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;565;-3968,-2560;Inherit;False;3;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;563;-3968,-2688;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;564;-3456,-2752;Inherit;True;Property;_TextureSample1;Texture Sample 0;12;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SamplerNode;556;-3456,-2944;Inherit;True;Property;_TextureSample0;Texture Sample 0;12;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;567;-3456,-2560;Inherit;False;561;VColor Blue Tree Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;566;-2944,-2944;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;571;-3968,-1920;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;572;-3968,-1792;Inherit;False;3;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;569;-3456,-2176;Inherit;True;Property;_TextureSample2;Texture Sample 0;12;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SamplerNode;570;-3456,-1952;Inherit;True;Property;_TextureSample3;Texture Sample 0;12;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;574;-3456,-1760;Inherit;False;561;VColor Blue Tree Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;573;-2944,-2176;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;355;-2560,-2176;Inherit;False;Base Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;354;-3968,-1664;Half;False;Property;_BaseNormalIntensity;Base Normal Intensity;6;0;Create;True;0;0;0;False;0;False;1;1.22;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;568;-3968,-2176;Inherit;True;Property;_BaseNormal;Base Normal;13;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;None;a4739660e9799a44ab3ef54b5e0573ae;True;bump;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TextureCoordinatesNode;580;-3968,-1024;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;581;-3968,-896;Inherit;False;3;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;577;-3456,-1280;Inherit;True;Property;_TextureSample5;Texture Sample 0;12;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;578;-3456,-768;Inherit;False;561;VColor Blue Tree Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;579;-2944,-1280;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BreakToComponentsNode;582;-2688,-1280;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.LerpOp;365;-2432,-1024;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;584;-2432,-896;Inherit;False;562;VColor Alpha Tree AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;583;-2176,-1024;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;587;-2944,-768;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;371;-2432,-768;Inherit;False;Emissive Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;364;-1920,-1152;Inherit;False;Base Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;576;-3456,-1088;Inherit;True;Property;_TextureSample4;Texture Sample 0;12;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.TexturePropertyNode;575;-3968,-1280;Inherit;True;Property;_BaseSMAE;Base SMAE;14;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;None;f78e6efa310d4d741a29de6228c8fb80;False;gray;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RegisterLocalVarNode;348;-1920,-1024;Inherit;False;Base AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;602;-512,-2944;Inherit;False;597;Top Layer UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;603;384,-2816;Inherit;False;348;Base AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.BlendOpsNode;599;384,-2944;Inherit;False;Overlay;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;604;640,-2944;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;606;640,-2816;Inherit;False;350;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;607;640,-2688;Inherit;False;621;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;605;896,-2944;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;625;1152,-2944;Inherit;False;Top Layer Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;600;0,-2944;Inherit;True;Property;_TopLayerAlbedo;Top Layer Albedo;27;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;f6dc7c0cfcd8cb54cb5f4dbe15bb7047;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.ColorNode;601;0,-2688;Half;False;Property;_TopLayerAlbedoColor;Top Layer Albedo Color;16;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0.5019608;0.5019608,0.5019608,0.5019608,0.5019608;False;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;643;-512,-2176;Inherit;False;597;Top Layer UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;645;0,-1920;Inherit;False;355;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BlendNormalsNode;647;384,-2048;Inherit;False;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;649;768,-2176;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;651;768,-2048;Inherit;False;355;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;650;768,-1920;Inherit;False;621;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;652;1152,-2176;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;653;1408,-2176;Inherit;False;Top Layer Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;646;0,-2176;Inherit;True;Property;_TopLayerNormal;Top Layer Normal;28;2;[NoScaleOffset];[Normal];Create;True;0;0;0;False;0;False;-1;None;ce33c7bbfcc6ff044979c54b9fb01fae;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;648;384,-1920;Half;False;Property;_TopLayerNormalInfluence;Top Layer Normal Influence;21;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;644;-512,-2048;Half;False;Property;_TopLayerNormalIntensity;Top Layer Normal Intensity;20;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;731;-512,-1536;Inherit;False;597;Top Layer UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;737;1408,-1536;Inherit;False;Top Layer Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;730;0,-1536;Inherit;True;Property;_TopLayerSmoothness;Top Layer Smoothness;29;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;8e8ac0c4acbd18f45891d51182feebda;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;746;-512,-896;Inherit;False;364;Base Metallic;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;748;-512,-768;Inherit;False;621;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;747;-128,-896;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;749;256,-896;Inherit;False;Top Layer Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;750;-512,-384;Inherit;False;348;Base AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;752;-512,-256;Inherit;False;621;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;751;-128,-384;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;753;256,-384;Inherit;False;Top Layer AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;754;-512,128;Inherit;False;377;Base Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;756;-512,256;Inherit;False;621;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;755;-128,128;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;757;256,128;Inherit;False;Top Layer Emissive;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;594;-512,640;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;595;-512,768;Inherit;False;Property;_TopLayerUVScale;Top Layer UV Scale;17;0;Create;True;0;0;0;False;0;False;1;6.2;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;596;-256,640;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;597;0,640;Inherit;False;Top Layer UV Scale;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;624;3200,-3072;Inherit;False;350;Base Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;626;3200,-2976;Inherit;False;625;Top Layer Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;739;3200,-2816;Inherit;False;355;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;740;3200,-2720;Inherit;False;653;Top Layer Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;759;3200,-2304;Inherit;False;364;Base Metallic;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;760;3200,-2208;Inherit;False;749;Top Layer Metallic;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;767;3200,-1792;Inherit;False;377;Base Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;768;3200,-1696;Inherit;False;757;Top Layer Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;738;3584,-2816;Inherit;False;Property;_Keyword0;Keyword 0;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;623;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;741;3584,-2560;Inherit;False;Property;_Keyword1;Keyword 0;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;623;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;758;3584,-2304;Inherit;False;Property;_Keyword2;Keyword 0;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;623;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;766;3584,-1792;Inherit;False;Property;_Keyword4;Keyword 0;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;623;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;627;3968,-3072;Inherit;False;Output Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;742;3968,-2816;Inherit;False;Output Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;745;3968,-2560;Inherit;False;Output Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;761;3968,-2304;Inherit;False;Output Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;769;3968,-1792;Inherit;False;Output Emissive;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;763;3200,-2048;Inherit;False;348;Base AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;764;3200,-1952;Inherit;False;753;Top Layer AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;762;3584,-2048;Inherit;False;Property;_Keyword3;Keyword 0;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;623;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;765;3968,-2048;Inherit;False;Output AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;744;3200,-2464;Inherit;False;737;Top Layer Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;743;3200,-2560;Inherit;False;361;Base Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;588;5376,-3072;Inherit;False;627;Output Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;589;5376,-2976;Inherit;False;742;Output Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;590;5376,-2880;Inherit;False;769;Output Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;591;5376,-2784;Inherit;False;761;Output Metallic;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;592;5376,-2688;Inherit;False;745;Output Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;593;5376,-2592;Inherit;False;765;Output AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;612;-512,1698;Half;False;Global;ASPT_TopLayerOffset;ASPT_TopLayerOffset;27;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;616;-128,1602;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;615;-128,1410;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;696;128,1602;Inherit;False;Top Layer Offset;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;702;128,1410;Inherit;False;Top Layer Intensity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;614;-512,1154;Inherit;False;355;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;611;-512,1890;Half;False;Global;ASPT_TopLayerContrast;ASPT_TopLayerContrast;26;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;617;-128,1794;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;776;-256,1154;Inherit;False;False;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RegisterLocalVarNode;699;128,1794;Inherit;False;Top Layer Contrast;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;610;-512,1410;Half;False;Property;_TopLayerIntensity;Top Layer Intensity;22;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;613;-512,1506;Half;False;Global;ASPT_TopLayerIntensity;ASPT_TopLayerIntensity;27;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;609;-512,1602;Half;False;Property;_TopLayerOffset;Top Layer Offset;23;0;Create;True;0;0;0;False;0;False;0.5;0.485;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;608;-512,1794;Half;False;Property;_TopLayerContrast;Top Layer Contrast;24;0;Create;True;0;0;0;False;0;False;10;10;0;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;1052;5376,-2496;Inherit;False;MF_ASP_Global_WindTrees;30;;22;587b51c6cec05a64bb99d28802483760;0;0;2;FLOAT3;49;FLOAT3;0
Node;AmplifyShaderEditor.FunctionNode;1056;128,1154;Inherit;False;MF_ASP_Global_TopLayer;-1;;23;6dc1725aa9649cc439f99987e8365ea2;0;4;22;FLOAT;0;False;24;FLOAT;1;False;23;FLOAT;0.5;False;25;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;628;-512,2432;Inherit;False;355;Base Normal;1;0;OBJECT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.Vector3Node;683;-256,2944;Inherit;False;Constant;_Vector0;Vector 0;25;0;Create;True;0;0;0;False;0;False;0,1,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldNormalVector;629;-256,2432;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DotProductOpNode;682;0,2944;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;630;-256,2624;Inherit;False;655;Global Arrow Direction;1;0;OBJECT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode;663;256,2944;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;689;256,3072;Inherit;False;Constant;_Float2;Float 2;25;0;Create;True;0;0;0;False;0;False;3;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;668;256,3200;Inherit;False;2;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DotProductOpNode;633;0,2432;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;666;512,2944;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;691;512,3200;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;635;576,2560;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;636;256,2432;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;690;768,2944;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;637;768,2432;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;692;1024,2944;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.05;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;671;1152,2432;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;632;256,2560;Half;False;Property;_TopArrowDirectionOffset;Top Arrow Direction Offset;25;0;Create;True;0;0;0;False;0;False;0;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;631;256,2656;Half;False;Global;ASPT_TopLayerArrowDirection;ASPT_TopLayerArrowDirection;19;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;693;1408,2432;Inherit;False;Arrow Direction Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;705;-512,3584;Inherit;False;2;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;706;-256,3584;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;714;0,3968;Inherit;False;355;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;707;0,3584;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;708;0,3712;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;715;256,3968;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.Vector3Node;717;256,4128;Inherit;False;Constant;_Vector1;Vector 0;25;0;Create;True;0;0;0;False;0;False;0,1,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;709;256,3584;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DotProductOpNode;716;512,3968;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;711;512,3584;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;718;768,3968;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;713;768,3584;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;719;1024,3584;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;710;256,3712;Inherit;False;Property;_TopLayerBottomOffset;Top Layer Bottom Offset;26;0;Create;True;0;0;0;False;0;False;1;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;778;256,3808;Half;False;Global;ASPT_TopLayerBottomOffset;ASPT_TopLayerBottomOffset;19;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;721;1280,3584;Inherit;False;Top Layer Bottom Offset;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;694;-512,4608;Inherit;False;693;Arrow Direction Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;725;-512,4736;Inherit;False;721;Top Layer Bottom Offset;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;697;-256,4736;Inherit;False;696;Top Layer Offset;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;724;-256,4608;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;1046;-128,4608;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;695;128,4608;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;703;384,4736;Inherit;False;702;Top Layer Intensity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;701;640,4608;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;782;896,4608;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;700;128,4736;Inherit;False;699;Top Layer Contrast;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;698;384,4608;Inherit;False;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1057;1152,4608;Inherit;False;Top Layer Direction;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;657;896,1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1054;1152,1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;704;1408,1152;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;621;1664,1152;Inherit;False;Top Layer Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1058;512,1280;Inherit;False;1057;Top Layer Direction;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;1064;512,1408;Inherit;False;MF_ASP_Global_TopLayerHeight;-1;;29;0851e7dd80a2406479a4b23dfe36fe1f;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.BlendOpsNode;345;-2176,-2944;Inherit;False;Overlay;True;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;350;-1920,-2944;Inherit;False;Base Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DesaturateOpNode;1070;-2688,-2944;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;1072;-2944,-2816;Inherit;False;Property;_BaseAlbedoDesaturation;Base Albedo Desaturation;2;0;Create;True;0;0;0;False;0;False;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1069;-2944,-2688;Inherit;False;Property;_BaseAlbedoBrightness;Base Albedo Brightness;1;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1068;-2432,-2944;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TexturePropertyNode;557;-3968,-2944;Inherit;True;Property;_BaseAlbedo;Base Albedo;12;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;None;c0b2daca0354f734d91cbf280e0a6523;False;gray;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.ColorNode;481;-2432,-2816;Half;False;Property;_BaseAlbedoColor;Base Albedo Color;0;1;[HDR];Create;True;0;0;0;False;1;Header(Base);False;0.5019608,0.5019608,0.5019608,0.5019608;0.5019608,0.5019608,0.5019608,0.5019608;False;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;1074;-2816,-384;Inherit;False;1073;Texture Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1076;-2432,-576;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;1078;-2176,-576;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;361;-1920,-576;Inherit;False;Base Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;362;-2432,-1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;363;-2816,-1088;Half;False;Property;_BaseMetallicIntensity;Base Metallic Intensity;3;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;367;-2816,-992;Half;False;Property;_BaseBarkAOIntensity;Base Bark AO Intensity;7;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1073;-1920,-1280;Inherit;False;Texture Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;372;-3968,240;Inherit;False;371;Emissive Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;373;-3584,240;Inherit;False;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;369;-3968,-16;Half;False;Property;_BaseEmissiveColor;Base Emissive Color;9;1;[HDR];Create;True;0;0;0;False;0;False;0,0,0,0;0,0,0,1;False;False;0;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;370;-3456,-16;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;375;-3072,-16;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;377;-2816,-16;Inherit;False;Base Emissive;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;374;-3968,368;Inherit;False;Property;_BaseEmissiveMaskContrast;Base Emissive Mask Contrast;11;0;Create;True;0;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;376;-3328,240;Inherit;False;Property;_BaseEmissiveIntensity;Base Emissive Intensity;10;0;Create;True;0;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;558;-3968,752;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;559;-3584,752;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;783;-3968,944;Inherit;False;Property;_BaseTreeAOIntensity;Base Tree AO Intensity;8;0;Create;True;0;0;0;False;0;False;0;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;654;-3968,1264;Half;False;Global;ASPW_WindDirection;ASPW_WindDirection;20;0;Create;True;0;0;0;False;0;False;0,0,0;0.9863343,-0.1647567,-1.029111E-07;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RegisterLocalVarNode;562;-3328,752;Inherit;False;VColor Alpha Tree AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;561;-3584,880;Inherit;False;VColor Blue Tree Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;655;-3712,1264;Inherit;False;Global Arrow Direction;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;1079;384,-1536;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1081;0,-1216;Half;False;Property;_TopLayerSmoothnessMax;Top Layer Smoothness Max;19;0;Create;True;0;0;0;False;0;False;1;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;735;384,-1408;Inherit;False;361;Base Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;736;384,-1312;Inherit;False;621;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;734;768,-1536;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;949;1024,-1536;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1080;0,-1312;Half;False;Property;_TopLayerSmoothnessMin;Top Layer Smoothness Min;18;0;Create;True;0;0;0;False;0;False;0;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1075;-2816,-576;Half;False;Property;_BaseSmoothnessMin;Base Smoothness Min;4;0;Create;True;0;0;0;False;0;False;0;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1077;-2816,-480;Half;False;Property;_BaseSmoothnessMax;Base Smoothness Max;5;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;623;3584,-3072;Inherit;False;Property;_EnableTopLayerBlend;Enable Top Layer Blend;15;0;Create;True;0;0;0;False;1;Header(Top Layer);False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1082;6016,-3072;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ExtraPrePass;0;0;ExtraPrePass;5;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1083;6016,-3072;Float;False;True;-1;3;;0;12;ANGRYMESH/Stylized Pack/Tree Bark;94348b07e5e8bab40bd6c8a1e3df54cd;True;Forward;0;1;Forward;21;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalForward;False;False;0;;0;0;Standard;43;Lighting Model;0;0;Workflow;1;0;Surface;0;0;  Refraction Model;0;0;  Blend;0;0;Two Sided;1;0;Alpha Clipping;1;0;  Use Shadow Threshold;0;0;Fragment Normal Space,InvertActionOnDeselection;0;0;Forward Only;0;0;Transmission;0;0;  Transmission Shadow;0.5,False,;0;Translucency;0;0;  Translucency Strength;1,False,;0;  Normal Distortion;0.5,False,;0;  Scattering;2,False,;0;  Direct;0.9,False,;0;  Ambient;0.1,False,;0;  Shadow;0.5,False,;0;Cast Shadows;1;0;Receive Shadows;1;0;Receive SSAO;1;0;GPU Instancing;1;0;LOD CrossFade;1;0;Built-in Fog;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Write Depth;0;0;  Early Z;0;0;Vertex Position,InvertActionOnDeselection;1;0;Debug Display;1;638780774901264886;Clear Coat;0;0;0;10;False;True;True;True;True;True;True;True;True;True;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1084;6016,-3072;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1085;6016,-3072;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;True;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1086;6016,-3072;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1087;6016,-3072;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1088;6016,-3072;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormals;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1089;6016,-3072;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;GBuffer;0;7;GBuffer;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalGBuffer;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1090;6016,-3072;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;SceneSelectionPass;0;8;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1091;6016,-3072;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ScenePickingPass;0;9;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
WireConnection;564;0;557;0
WireConnection;564;1;565;0
WireConnection;556;0;557;0
WireConnection;556;1;563;0
WireConnection;566;0;556;5
WireConnection;566;1;564;5
WireConnection;566;2;567;0
WireConnection;569;0;568;0
WireConnection;569;1;571;0
WireConnection;569;5;354;0
WireConnection;570;0;568;0
WireConnection;570;1;572;0
WireConnection;570;5;354;0
WireConnection;573;0;569;0
WireConnection;573;1;570;0
WireConnection;573;2;574;0
WireConnection;355;0;573;0
WireConnection;577;0;575;0
WireConnection;577;1;580;0
WireConnection;579;0;577;5
WireConnection;579;1;576;5
WireConnection;579;2;578;0
WireConnection;582;0;579;0
WireConnection;365;1;582;2
WireConnection;365;2;367;0
WireConnection;583;0;365;0
WireConnection;583;1;584;0
WireConnection;587;0;577;4
WireConnection;587;1;576;4
WireConnection;587;2;578;0
WireConnection;371;0;587;0
WireConnection;364;0;362;0
WireConnection;576;0;575;0
WireConnection;576;1;581;0
WireConnection;348;0;583;0
WireConnection;599;0;600;5
WireConnection;599;1;601;5
WireConnection;604;0;599;0
WireConnection;604;1;603;0
WireConnection;605;0;606;0
WireConnection;605;1;604;0
WireConnection;605;2;607;0
WireConnection;625;0;605;0
WireConnection;600;1;602;0
WireConnection;647;0;646;0
WireConnection;647;1;645;0
WireConnection;649;0;647;0
WireConnection;649;1;646;0
WireConnection;649;2;648;0
WireConnection;652;0;651;0
WireConnection;652;1;649;0
WireConnection;652;2;650;0
WireConnection;653;0;652;0
WireConnection;646;1;643;0
WireConnection;646;5;644;0
WireConnection;737;0;949;0
WireConnection;730;1;731;0
WireConnection;747;0;746;0
WireConnection;747;2;748;0
WireConnection;749;0;747;0
WireConnection;751;0;750;0
WireConnection;751;2;752;0
WireConnection;753;0;751;0
WireConnection;755;0;754;0
WireConnection;755;2;756;0
WireConnection;757;0;755;0
WireConnection;596;0;594;0
WireConnection;596;1;595;0
WireConnection;597;0;596;0
WireConnection;738;1;739;0
WireConnection;738;0;740;0
WireConnection;741;1;743;0
WireConnection;741;0;744;0
WireConnection;758;1;759;0
WireConnection;758;0;760;0
WireConnection;766;1;767;0
WireConnection;766;0;768;0
WireConnection;627;0;623;0
WireConnection;742;0;738;0
WireConnection;745;0;741;0
WireConnection;761;0;758;0
WireConnection;769;0;766;0
WireConnection;762;1;763;0
WireConnection;762;0;764;0
WireConnection;765;0;762;0
WireConnection;616;0;609;0
WireConnection;616;1;612;0
WireConnection;615;0;610;0
WireConnection;615;1;613;0
WireConnection;696;0;616;0
WireConnection;702;0;615;0
WireConnection;617;0;608;0
WireConnection;617;1;611;0
WireConnection;776;0;614;0
WireConnection;699;0;617;0
WireConnection;1056;22;776;2
WireConnection;1056;24;615;0
WireConnection;1056;23;616;0
WireConnection;1056;25;617;0
WireConnection;629;0;628;0
WireConnection;682;0;629;0
WireConnection;682;1;683;0
WireConnection;663;0;682;0
WireConnection;633;0;629;0
WireConnection;633;1;630;0
WireConnection;666;0;689;0
WireConnection;666;1;663;0
WireConnection;691;0;668;2
WireConnection;635;0;632;0
WireConnection;635;1;631;0
WireConnection;636;0;633;0
WireConnection;690;0;666;0
WireConnection;690;1;691;0
WireConnection;637;0;636;0
WireConnection;637;1;635;0
WireConnection;692;0;690;0
WireConnection;671;0;637;0
WireConnection;671;1;692;0
WireConnection;693;0;671;0
WireConnection;706;0;705;2
WireConnection;707;0;706;0
WireConnection;707;1;706;0
WireConnection;708;0;706;0
WireConnection;708;1;706;0
WireConnection;715;0;714;0
WireConnection;709;0;707;0
WireConnection;709;1;708;0
WireConnection;716;0;715;0
WireConnection;716;1;717;0
WireConnection;711;0;709;0
WireConnection;711;1;710;0
WireConnection;711;2;778;0
WireConnection;718;0;716;0
WireConnection;713;0;711;0
WireConnection;713;1;711;0
WireConnection;719;0;713;0
WireConnection;719;1;718;0
WireConnection;721;0;719;0
WireConnection;724;0;694;0
WireConnection;724;1;725;0
WireConnection;1046;0;724;0
WireConnection;695;0;1046;0
WireConnection;695;1;697;0
WireConnection;701;0;698;0
WireConnection;701;1;703;0
WireConnection;782;0;701;0
WireConnection;698;0;695;0
WireConnection;698;1;700;0
WireConnection;1057;0;782;0
WireConnection;657;0;1056;0
WireConnection;657;1;1058;0
WireConnection;1054;0;657;0
WireConnection;1054;1;1064;0
WireConnection;704;0;1054;0
WireConnection;621;0;704;0
WireConnection;345;0;1068;0
WireConnection;345;1;481;5
WireConnection;350;0;345;0
WireConnection;1070;0;566;0
WireConnection;1070;1;1072;0
WireConnection;1068;0;1070;0
WireConnection;1068;1;1069;0
WireConnection;1076;0;1075;0
WireConnection;1076;1;1077;0
WireConnection;1076;2;1074;0
WireConnection;1078;0;1076;0
WireConnection;361;0;1078;0
WireConnection;362;0;582;1
WireConnection;362;1;363;0
WireConnection;1073;0;582;0
WireConnection;373;0;372;0
WireConnection;373;1;374;0
WireConnection;370;0;369;0
WireConnection;370;1;373;0
WireConnection;375;0;370;0
WireConnection;375;1;376;0
WireConnection;377;0;375;0
WireConnection;559;1;558;4
WireConnection;559;2;783;0
WireConnection;562;0;559;0
WireConnection;561;0;558;3
WireConnection;655;0;654;0
WireConnection;1079;0;1080;0
WireConnection;1079;1;1081;0
WireConnection;1079;2;730;1
WireConnection;734;0;735;0
WireConnection;734;1;1079;0
WireConnection;734;2;736;0
WireConnection;949;0;734;0
WireConnection;623;1;624;0
WireConnection;623;0;626;0
WireConnection;1083;0;588;0
WireConnection;1083;1;589;0
WireConnection;1083;2;590;0
WireConnection;1083;3;591;0
WireConnection;1083;4;592;0
WireConnection;1083;5;593;0
WireConnection;1083;8;1052;49
ASEEND*/
//CHKSM=612A053745070CC37192482C2A3766D09B1547E7