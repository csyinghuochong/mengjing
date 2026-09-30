// Made with Amplify Shader Editor v1.9.8.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ANGRYMESH/Stylized Pack/Props"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HDR][Header(Base)]_BaseAlbedoColor("Base Albedo Color", Color) = (0.5019608,0.5019608,0.5019608,0.5019608)
		_BaseAlbedoBrightness("Base Albedo Brightness", Range( 0 , 5)) = 1
		_BaseAlbedoDesaturation("Base Albedo Desaturation", Range( 0 , 1)) = 0
		_BaseUVScale("Base UV Scale", Range( 0 , 50)) = 1
		_BaseMetallicIntensity("Base Metallic Intensity", Range( 0 , 1)) = 0
		_BaseSmoothnessMin("Base Smoothness Min", Range( 0 , 5)) = 0
		_BaseSmoothnessMax("Base Smoothness Max", Range( 0 , 5)) = 1
		_BaseNormalIntensity("Base Normal Intensity", Range( 0 , 5)) = 1
		_BaseAOIntensity("Base AO Intensity", Range( 0 , 1)) = 0.5
		[HDR]_BaseEmissiveColor("Base Emissive Color", Color) = (0,0,0)
		_BaseEmissiveIntensity("Base Emissive Intensity", Float) = 2
		_BaseEmissiveMaskContrast("Base Emissive Mask Contrast", Float) = 2
		[NoScaleOffset]_BaseAlbedo("Base Albedo", 2D) = "gray" {}
		[NoScaleOffset][Normal]_BaseNormal("Base Normal", 2D) = "bump" {}
		[NoScaleOffset]_BaseSMAE("Base SMAE", 2D) = "gray" {}
		[Header(Top Layer)][Toggle(_ENABLETOPLAYERBLEND_ON)] _EnableTopLayerBlend("Enable Top Layer Blend", Float) = 1
		[HDR]_TopLayerAlbedoColor("Top Layer Albedo Color", Color) = (0.5019608,0.5019608,0.5019608,0.5019608)
		_TopLayerUVScale("Top Layer UV Scale", Range( 0 , 50)) = 5
		_TopLayerSmoothnessMin("Top Layer Smoothness Min", Range( 0 , 5)) = 0
		_TopLayerSmoothnessMax("Top Layer Smoothness Max", Range( 0 , 5)) = 1
		_TopLayerNormalIntensity("Top Layer Normal Intensity", Range( 0 , 5)) = 1
		_TopLayerNormalInfluence("Top Layer Normal Influence", Range( 0 , 1)) = 0
		_TopLayerIntensity("Top Layer Intensity", Range( 0 , 1)) = 1
		_TopLayerOffset("Top Layer Offset", Range( 0 , 1)) = 0.5
		_TopLayerContrast("Top Layer Contrast", Range( 0 , 30)) = 10
		_TopLayerVPaintMaskIntensity("Top Layer VPaint Mask Intensity", Range( 0 , 1)) = 0
		[NoScaleOffset]_TopLayerAlbedo("Top Layer Albedo", 2D) = "gray" {}
		[NoScaleOffset][Normal]_TopLayerNormal("Top Layer Normal", 2D) = "bump" {}
		[NoScaleOffset]_TopLayerSmoothness("Top Layer Smoothness", 2D) = "gray" {}
		[Header(Top Layer Noise)][Toggle(_ENABLETOPLAYERNOISE_ON)] _EnableTopLayerNoise("Enable Top Layer Noise", Float) = 0
		_TopLayerNoiseUVScale("Top Layer Noise UV Scale", Range( 0 , 50)) = 5
		_TopLayerNoiseContrast("Top Layer Noise Contrast", Range( 0 , 20)) = 1
		[NoScaleOffset]_TopLayerNoise("Top Layer Noise", 2D) = "black" {}
		[Header(Detail)][Toggle(_ENABLEDETAIL_ON)] _EnableDetail("Enable Detail", Float) = 1
		_DetailUVScale("Detail UV Scale", Range( 0 , 50)) = 2
		_DetailAlbedoIntensity("Detail Albedo Intensity", Range( 0 , 1)) = 1
		_DetailAlbedoPower("Detail Albedo Power", Range( 0 , 10)) = 1
		_DetailNormalIntensity("Detail Normal Intensity", Range( 0 , 5)) = 1
		[NoScaleOffset]_DetailAlbedo("Detail Albedo", 2D) = "gray" {}
		[NoScaleOffset][Normal]_DetailNormal("Detail Normal", 2D) = "bump" {}


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

			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON
			#pragma shader_feature_local _ENABLEDETAIL_ON
			#pragma shader_feature_local _ENABLETOPLAYERNOISE_ON


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
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _BaseUVScale;
			half _TopLayerSmoothnessMin;
			float _BaseSmoothnessMax;
			float _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			half _DetailNormalIntensity;
			float _TopLayerVPaintMaskIntensity;
			float _TopLayerNoiseUVScale;
			half _TopLayerSmoothnessMax;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _TopLayerUVScale;
			float _DetailAlbedoIntensity;
			float _DetailAlbedoPower;
			float _DetailUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _TopLayerNoiseContrast;
			half _BaseAOIntensity;
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

			sampler2D _BaseAlbedo;
			sampler2D _DetailAlbedo;
			sampler2D _TopLayerAlbedo;
			sampler2D _BaseNormal;
			half ASPP_TopLayerOffset;
			half ASPP_TopLayerContrast;
			half ASPP_TopLayerIntensity;
			sampler2D _TopLayerNoise;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;
			sampler2D _DetailNormal;
			sampler2D _TopLayerNormal;
			sampler2D _BaseSMAE;
			sampler2D _TopLayerSmoothness;


			
			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				output.ase_texcoord8.xy = input.texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord8.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

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

				float2 texCoord339 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Base_UV_Scale342 = ( texCoord339 * _BaseUVScale );
				float3 desaturateInitialColor658 = tex2D( _BaseAlbedo, Base_UV_Scale342 ).rgb;
				float desaturateDot658 = dot( desaturateInitialColor658, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar658 = lerp( desaturateInitialColor658, desaturateDot658.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc345 = ( desaturateVar658 * _BaseAlbedoBrightness );
				float3 blendOpDest345 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo350 = ( saturate( (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) ));
				float2 texCoord392 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Detail_UV_Scale395 = ( texCoord392 * _DetailUVScale );
				float3 saferPower400 = abs( ( tex2D( _DetailAlbedo, Detail_UV_Scale395 ).rgb * float3( 2,2,2 ) ) );
				float3 temp_cast_0 = (_DetailAlbedoPower).xxx;
				float3 blendOpSrc402 = Base_Albedo350;
				float3 blendOpDest402 = pow( saferPower400 , temp_cast_0 );
				float3 lerpResult407 = lerp( Base_Albedo350 , saturate( (( blendOpDest402 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest402 ) * ( 1.0 - blendOpSrc402 ) ) : ( 2.0 * blendOpDest402 * blendOpSrc402 ) ) ) , _DetailAlbedoIntensity);
				float3 Detail_Albedo410 = lerpResult407;
				#ifdef _ENABLEDETAIL_ON
				float3 staticSwitch421 = Detail_Albedo410;
				#else
				float3 staticSwitch421 = Base_Albedo350;
				#endif
				float3 Base_Detail_Albedo474 = staticSwitch421;
				float2 texCoord426 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale428 = ( texCoord426 * _TopLayerUVScale );
				float3 blendOpSrc432 = tex2D( _TopLayerAlbedo, Top_Layer_UV_Scale428 ).rgb;
				float3 blendOpDest432 = _TopLayerAlbedoColor.rgb;
				float3 unpack352 = UnpackNormalScale( tex2D( _BaseNormal, Base_UV_Scale342 ), _BaseNormalIntensity );
				unpack352.z = lerp( 1, unpack352.z, saturate(_BaseNormalIntensity) );
				float3 Base_Normal355 = unpack352;
				float3 tanToWorld0 = float3( WorldTangent.x, WorldBiTangent.x, WorldNormal.x );
				float3 tanToWorld1 = float3( WorldTangent.y, WorldBiTangent.y, WorldNormal.y );
				float3 tanToWorld2 = float3( WorldTangent.z, WorldBiTangent.z, WorldNormal.z );
				float3 tanNormal558 = Base_Normal355;
				float3 worldNormal558 = float3( dot( tanToWorld0, tanNormal558 ), dot( tanToWorld1, tanNormal558 ), dot( tanToWorld2, tanNormal558 ) );
				float saferPower17_g5 = abs( abs( ( saturate( worldNormal558.y ) + ( _TopLayerOffset * ASPP_TopLayerOffset ) ) ) );
				float3 temp_cast_1 = (1.0).xxx;
				float3 temp_cast_2 = (1.0).xxx;
				float2 texCoord535 = input.ase_texcoord8.xy * float2( 0.1,0.1 ) + float2( 0,0 );
				float3 saferPower647 = abs( ( 1.0 - tex2D( _TopLayerNoise, ( texCoord535 * _TopLayerNoiseUVScale ) ).rgb ) );
				float3 temp_cast_3 = (_TopLayerNoiseContrast).xxx;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch545 = saturate( pow( saferPower647 , temp_cast_3 ) );
				#else
				float3 staticSwitch545 = temp_cast_2;
				#endif
				#ifdef _ENABLETOPLAYERNOISE_ON
				float3 staticSwitch551 = staticSwitch545;
				#else
				float3 staticSwitch551 = temp_cast_1;
				#endif
				float3 Top_Layer_Noise_Mask547 = staticSwitch551;
				float lerpResult664 = lerp( 1.0 , input.ase_color.r , _TopLayerVPaintMaskIntensity);
				float Top_Layer_VPaint_Mask665 = lerpResult664;
				float3 Top_Layer_Mask462 = ( ( ( saturate( pow( saferPower17_g5 , ( _TopLayerContrast * ASPP_TopLayerContrast ) ) ) * ( _TopLayerIntensity * ASPP_TopLayerIntensity ) ) * Top_Layer_Noise_Mask547 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) * Top_Layer_VPaint_Mask665 );
				float3 lerpResult464 = lerp( Base_Detail_Albedo474 , (( blendOpDest432 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest432 ) * ( 1.0 - blendOpSrc432 ) ) : ( 2.0 * blendOpDest432 * blendOpSrc432 ) ) , Top_Layer_Mask462);
				float3 Top_Layer_Albedo467 = lerpResult464;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch472 = Top_Layer_Albedo467;
				#else
				float3 staticSwitch472 = Base_Detail_Albedo474;
				#endif
				float3 Output_Albedo520 = staticSwitch472;
				
				float3 unpack411 = UnpackNormalScale( tex2D( _DetailNormal, Detail_UV_Scale395 ), _DetailNormalIntensity );
				unpack411.z = lerp( 1, unpack411.z, saturate(_DetailNormalIntensity) );
				float3 Detail_Normal416 = BlendNormal( unpack411 , Base_Normal355 );
				#ifdef _ENABLEDETAIL_ON
				float3 staticSwitch446 = Detail_Normal416;
				#else
				float3 staticSwitch446 = Base_Normal355;
				#endif
				float3 Base_Detail_Normal475 = staticSwitch446;
				float3 unpack436 = UnpackNormalScale( tex2D( _TopLayerNormal, Top_Layer_UV_Scale428 ), _TopLayerNormalIntensity );
				unpack436.z = lerp( 1, unpack436.z, saturate(_TopLayerNormalIntensity) );
				float3 tex2DNode436 = unpack436;
				float3 lerpResult438 = lerp( BlendNormal( tex2DNode436 , Base_Normal355 ) , tex2DNode436 , _TopLayerNormalInfluence);
				float3 lerpResult443 = lerp( Base_Detail_Normal475 , lerpResult438 , Top_Layer_Mask462);
				float3 Top_Layer_Normal470 = lerpResult443;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch473 = Top_Layer_Normal470;
				#else
				float3 staticSwitch473 = Base_Detail_Normal475;
				#endif
				float3 Output_Normal523 = staticSwitch473;
				
				float4 tex2DNode357 = tex2D( _BaseSMAE, Base_UV_Scale342 );
				float Emissive_Mask371 = tex2DNode357.a;
				float saferPower373 = abs( Emissive_Mask371 );
				float3 Base_Emissive377 = ( ( _BaseEmissiveColor * pow( saferPower373 , _BaseEmissiveMaskContrast ) ) * _BaseEmissiveIntensity );
				float3 lerpResult507 = lerp( Base_Emissive377 , float3( 0,0,0 ) , Top_Layer_Mask462);
				float3 Top_Layer_Emissive509 = lerpResult507;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch510 = Top_Layer_Emissive509;
				#else
				float3 staticSwitch510 = Base_Emissive377;
				#endif
				float3 Output_Emissive526 = staticSwitch510;
				
				float Base_Metallic364 = ( tex2DNode357.g * _BaseMetallicIntensity );
				float lerpResult483 = lerp( Base_Metallic364 , 0.0 , Top_Layer_Mask462.x);
				float Top_Layer_Metallic486 = lerpResult483;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch489 = Top_Layer_Metallic486;
				#else
				float staticSwitch489 = Base_Metallic364;
				#endif
				float Output_Metallic524 = staticSwitch489;
				
				float Texture_Smoothness668 = tex2DNode357.r;
				float lerpResult673 = lerp( _BaseSmoothnessMin , _BaseSmoothnessMax , Texture_Smoothness668);
				float Base_Smoothness361 = saturate( lerpResult673 );
				float lerpResult679 = lerp( _TopLayerSmoothnessMin , _TopLayerSmoothnessMax , tex2D( _TopLayerSmoothness, Top_Layer_UV_Scale428 ).r);
				float lerpResult499 = lerp( Base_Smoothness361 , lerpResult679 , Top_Layer_Mask462.x);
				float Top_Layer_Smoothness502 = saturate( lerpResult499 );
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch503 = Top_Layer_Smoothness502;
				#else
				float staticSwitch503 = Base_Smoothness361;
				#endif
				float Output_Smoothness525 = staticSwitch503;
				
				float lerpResult365 = lerp( 1.0 , tex2DNode357.b , _BaseAOIntensity);
				float Base_AO348 = lerpResult365;
				float lerpResult514 = lerp( Base_AO348 , 1.0 , Top_Layer_Mask462.x);
				float Top_Layer_AO516 = lerpResult514;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch517 = Top_Layer_AO516;
				#else
				float staticSwitch517 = Base_AO348;
				#endif
				float Output_AO527 = staticSwitch517;
				

				float3 BaseColor = Output_Albedo520;
				float3 Normal = Output_Normal523;
				float3 Emission = Output_Emissive526;
				float3 Specular = 0.5;
				float Metallic = Output_Metallic524;
				float Smoothness = Output_Smoothness525;
				float Occlusion = Output_AO527;
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
			float _BaseUVScale;
			half _TopLayerSmoothnessMin;
			float _BaseSmoothnessMax;
			float _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			half _DetailNormalIntensity;
			float _TopLayerVPaintMaskIntensity;
			float _TopLayerNoiseUVScale;
			half _TopLayerSmoothnessMax;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _TopLayerUVScale;
			float _DetailAlbedoIntensity;
			float _DetailAlbedoPower;
			float _DetailUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _TopLayerNoiseContrast;
			half _BaseAOIntensity;
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

			

			
			float3 _LightDirection;
			float3 _LightPosition;

			PackedVaryings VertexFunction( Attributes input )
			{
				PackedVaryings output;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( output );

				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;
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
			float _BaseUVScale;
			half _TopLayerSmoothnessMin;
			float _BaseSmoothnessMax;
			float _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			half _DetailNormalIntensity;
			float _TopLayerVPaintMaskIntensity;
			float _TopLayerNoiseUVScale;
			half _TopLayerSmoothnessMax;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _TopLayerUVScale;
			float _DetailAlbedoIntensity;
			float _DetailAlbedoPower;
			float _DetailUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _TopLayerNoiseContrast;
			half _BaseAOIntensity;
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

			

			
			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

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

			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON
			#pragma shader_feature_local _ENABLEDETAIL_ON
			#pragma shader_feature_local _ENABLETOPLAYERNOISE_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_tangent : TANGENT;
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
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_texcoord6 : TEXCOORD6;
				float4 ase_texcoord7 : TEXCOORD7;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _BaseUVScale;
			half _TopLayerSmoothnessMin;
			float _BaseSmoothnessMax;
			float _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			half _DetailNormalIntensity;
			float _TopLayerVPaintMaskIntensity;
			float _TopLayerNoiseUVScale;
			half _TopLayerSmoothnessMax;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _TopLayerUVScale;
			float _DetailAlbedoIntensity;
			float _DetailAlbedoPower;
			float _DetailUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _TopLayerNoiseContrast;
			half _BaseAOIntensity;
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

			sampler2D _BaseAlbedo;
			sampler2D _DetailAlbedo;
			sampler2D _TopLayerAlbedo;
			sampler2D _BaseNormal;
			half ASPP_TopLayerOffset;
			half ASPP_TopLayerContrast;
			half ASPP_TopLayerIntensity;
			sampler2D _TopLayerNoise;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;
			sampler2D _BaseSMAE;


			
			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 ase_tangentWS = TransformObjectToWorldDir( input.ase_tangent.xyz );
				output.ase_texcoord5.xyz = ase_tangentWS;
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord6.xyz = ase_normalWS;
				float ase_tangentSign = input.ase_tangent.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord7.xyz = ase_bitangentWS;
				
				output.ase_texcoord4.xy = input.texcoord0.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord4.zw = 0;
				output.ase_texcoord5.w = 0;
				output.ase_texcoord6.w = 0;
				output.ase_texcoord7.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

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
				float4 ase_tangent : TANGENT;
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
				output.ase_tangent = input.ase_tangent;
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
				output.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
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

				float2 texCoord339 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Base_UV_Scale342 = ( texCoord339 * _BaseUVScale );
				float3 desaturateInitialColor658 = tex2D( _BaseAlbedo, Base_UV_Scale342 ).rgb;
				float desaturateDot658 = dot( desaturateInitialColor658, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar658 = lerp( desaturateInitialColor658, desaturateDot658.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc345 = ( desaturateVar658 * _BaseAlbedoBrightness );
				float3 blendOpDest345 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo350 = ( saturate( (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) ));
				float2 texCoord392 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Detail_UV_Scale395 = ( texCoord392 * _DetailUVScale );
				float3 saferPower400 = abs( ( tex2D( _DetailAlbedo, Detail_UV_Scale395 ).rgb * float3( 2,2,2 ) ) );
				float3 temp_cast_0 = (_DetailAlbedoPower).xxx;
				float3 blendOpSrc402 = Base_Albedo350;
				float3 blendOpDest402 = pow( saferPower400 , temp_cast_0 );
				float3 lerpResult407 = lerp( Base_Albedo350 , saturate( (( blendOpDest402 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest402 ) * ( 1.0 - blendOpSrc402 ) ) : ( 2.0 * blendOpDest402 * blendOpSrc402 ) ) ) , _DetailAlbedoIntensity);
				float3 Detail_Albedo410 = lerpResult407;
				#ifdef _ENABLEDETAIL_ON
				float3 staticSwitch421 = Detail_Albedo410;
				#else
				float3 staticSwitch421 = Base_Albedo350;
				#endif
				float3 Base_Detail_Albedo474 = staticSwitch421;
				float2 texCoord426 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale428 = ( texCoord426 * _TopLayerUVScale );
				float3 blendOpSrc432 = tex2D( _TopLayerAlbedo, Top_Layer_UV_Scale428 ).rgb;
				float3 blendOpDest432 = _TopLayerAlbedoColor.rgb;
				float3 unpack352 = UnpackNormalScale( tex2D( _BaseNormal, Base_UV_Scale342 ), _BaseNormalIntensity );
				unpack352.z = lerp( 1, unpack352.z, saturate(_BaseNormalIntensity) );
				float3 Base_Normal355 = unpack352;
				float3 ase_tangentWS = input.ase_texcoord5.xyz;
				float3 ase_normalWS = input.ase_texcoord6.xyz;
				float3 ase_bitangentWS = input.ase_texcoord7.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal558 = Base_Normal355;
				float3 worldNormal558 = float3( dot( tanToWorld0, tanNormal558 ), dot( tanToWorld1, tanNormal558 ), dot( tanToWorld2, tanNormal558 ) );
				float saferPower17_g5 = abs( abs( ( saturate( worldNormal558.y ) + ( _TopLayerOffset * ASPP_TopLayerOffset ) ) ) );
				float3 temp_cast_1 = (1.0).xxx;
				float3 temp_cast_2 = (1.0).xxx;
				float2 texCoord535 = input.ase_texcoord4.xy * float2( 0.1,0.1 ) + float2( 0,0 );
				float3 saferPower647 = abs( ( 1.0 - tex2D( _TopLayerNoise, ( texCoord535 * _TopLayerNoiseUVScale ) ).rgb ) );
				float3 temp_cast_3 = (_TopLayerNoiseContrast).xxx;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch545 = saturate( pow( saferPower647 , temp_cast_3 ) );
				#else
				float3 staticSwitch545 = temp_cast_2;
				#endif
				#ifdef _ENABLETOPLAYERNOISE_ON
				float3 staticSwitch551 = staticSwitch545;
				#else
				float3 staticSwitch551 = temp_cast_1;
				#endif
				float3 Top_Layer_Noise_Mask547 = staticSwitch551;
				float lerpResult664 = lerp( 1.0 , input.ase_color.r , _TopLayerVPaintMaskIntensity);
				float Top_Layer_VPaint_Mask665 = lerpResult664;
				float3 Top_Layer_Mask462 = ( ( ( saturate( pow( saferPower17_g5 , ( _TopLayerContrast * ASPP_TopLayerContrast ) ) ) * ( _TopLayerIntensity * ASPP_TopLayerIntensity ) ) * Top_Layer_Noise_Mask547 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) * Top_Layer_VPaint_Mask665 );
				float3 lerpResult464 = lerp( Base_Detail_Albedo474 , (( blendOpDest432 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest432 ) * ( 1.0 - blendOpSrc432 ) ) : ( 2.0 * blendOpDest432 * blendOpSrc432 ) ) , Top_Layer_Mask462);
				float3 Top_Layer_Albedo467 = lerpResult464;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch472 = Top_Layer_Albedo467;
				#else
				float3 staticSwitch472 = Base_Detail_Albedo474;
				#endif
				float3 Output_Albedo520 = staticSwitch472;
				
				float4 tex2DNode357 = tex2D( _BaseSMAE, Base_UV_Scale342 );
				float Emissive_Mask371 = tex2DNode357.a;
				float saferPower373 = abs( Emissive_Mask371 );
				float3 Base_Emissive377 = ( ( _BaseEmissiveColor * pow( saferPower373 , _BaseEmissiveMaskContrast ) ) * _BaseEmissiveIntensity );
				float3 lerpResult507 = lerp( Base_Emissive377 , float3( 0,0,0 ) , Top_Layer_Mask462);
				float3 Top_Layer_Emissive509 = lerpResult507;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch510 = Top_Layer_Emissive509;
				#else
				float3 staticSwitch510 = Base_Emissive377;
				#endif
				float3 Output_Emissive526 = staticSwitch510;
				

				float3 BaseColor = Output_Albedo520;
				float3 Emission = Output_Emissive526;
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

			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON
			#pragma shader_feature_local _ENABLEDETAIL_ON
			#pragma shader_feature_local _ENABLETOPLAYERNOISE_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;
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
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _BaseUVScale;
			half _TopLayerSmoothnessMin;
			float _BaseSmoothnessMax;
			float _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			half _DetailNormalIntensity;
			float _TopLayerVPaintMaskIntensity;
			float _TopLayerNoiseUVScale;
			half _TopLayerSmoothnessMax;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _TopLayerUVScale;
			float _DetailAlbedoIntensity;
			float _DetailAlbedoPower;
			float _DetailUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _TopLayerNoiseContrast;
			half _BaseAOIntensity;
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

			sampler2D _BaseAlbedo;
			sampler2D _DetailAlbedo;
			sampler2D _TopLayerAlbedo;
			sampler2D _BaseNormal;
			half ASPP_TopLayerOffset;
			half ASPP_TopLayerContrast;
			half ASPP_TopLayerIntensity;
			sampler2D _TopLayerNoise;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;


			
			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID( input );
				UNITY_TRANSFER_INSTANCE_ID( input, output );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( output );

				float3 ase_tangentWS = TransformObjectToWorldDir( input.ase_tangent.xyz );
				output.ase_texcoord3.xyz = ase_tangentWS;
				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				output.ase_texcoord4.xyz = ase_normalWS;
				float ase_tangentSign = input.ase_tangent.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord5.xyz = ase_bitangentWS;
				
				output.ase_texcoord2.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord2.zw = 0;
				output.ase_texcoord3.w = 0;
				output.ase_texcoord4.w = 0;
				output.ase_texcoord5.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

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
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;
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
				output.ase_texcoord = input.ase_texcoord;
				output.ase_tangent = input.ase_tangent;
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
				output.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				output.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
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

				float2 texCoord339 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Base_UV_Scale342 = ( texCoord339 * _BaseUVScale );
				float3 desaturateInitialColor658 = tex2D( _BaseAlbedo, Base_UV_Scale342 ).rgb;
				float desaturateDot658 = dot( desaturateInitialColor658, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar658 = lerp( desaturateInitialColor658, desaturateDot658.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc345 = ( desaturateVar658 * _BaseAlbedoBrightness );
				float3 blendOpDest345 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo350 = ( saturate( (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) ));
				float2 texCoord392 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Detail_UV_Scale395 = ( texCoord392 * _DetailUVScale );
				float3 saferPower400 = abs( ( tex2D( _DetailAlbedo, Detail_UV_Scale395 ).rgb * float3( 2,2,2 ) ) );
				float3 temp_cast_0 = (_DetailAlbedoPower).xxx;
				float3 blendOpSrc402 = Base_Albedo350;
				float3 blendOpDest402 = pow( saferPower400 , temp_cast_0 );
				float3 lerpResult407 = lerp( Base_Albedo350 , saturate( (( blendOpDest402 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest402 ) * ( 1.0 - blendOpSrc402 ) ) : ( 2.0 * blendOpDest402 * blendOpSrc402 ) ) ) , _DetailAlbedoIntensity);
				float3 Detail_Albedo410 = lerpResult407;
				#ifdef _ENABLEDETAIL_ON
				float3 staticSwitch421 = Detail_Albedo410;
				#else
				float3 staticSwitch421 = Base_Albedo350;
				#endif
				float3 Base_Detail_Albedo474 = staticSwitch421;
				float2 texCoord426 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale428 = ( texCoord426 * _TopLayerUVScale );
				float3 blendOpSrc432 = tex2D( _TopLayerAlbedo, Top_Layer_UV_Scale428 ).rgb;
				float3 blendOpDest432 = _TopLayerAlbedoColor.rgb;
				float3 unpack352 = UnpackNormalScale( tex2D( _BaseNormal, Base_UV_Scale342 ), _BaseNormalIntensity );
				unpack352.z = lerp( 1, unpack352.z, saturate(_BaseNormalIntensity) );
				float3 Base_Normal355 = unpack352;
				float3 ase_tangentWS = input.ase_texcoord3.xyz;
				float3 ase_normalWS = input.ase_texcoord4.xyz;
				float3 ase_bitangentWS = input.ase_texcoord5.xyz;
				float3 tanToWorld0 = float3( ase_tangentWS.x, ase_bitangentWS.x, ase_normalWS.x );
				float3 tanToWorld1 = float3( ase_tangentWS.y, ase_bitangentWS.y, ase_normalWS.y );
				float3 tanToWorld2 = float3( ase_tangentWS.z, ase_bitangentWS.z, ase_normalWS.z );
				float3 tanNormal558 = Base_Normal355;
				float3 worldNormal558 = float3( dot( tanToWorld0, tanNormal558 ), dot( tanToWorld1, tanNormal558 ), dot( tanToWorld2, tanNormal558 ) );
				float saferPower17_g5 = abs( abs( ( saturate( worldNormal558.y ) + ( _TopLayerOffset * ASPP_TopLayerOffset ) ) ) );
				float3 temp_cast_1 = (1.0).xxx;
				float3 temp_cast_2 = (1.0).xxx;
				float2 texCoord535 = input.ase_texcoord2.xy * float2( 0.1,0.1 ) + float2( 0,0 );
				float3 saferPower647 = abs( ( 1.0 - tex2D( _TopLayerNoise, ( texCoord535 * _TopLayerNoiseUVScale ) ).rgb ) );
				float3 temp_cast_3 = (_TopLayerNoiseContrast).xxx;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch545 = saturate( pow( saferPower647 , temp_cast_3 ) );
				#else
				float3 staticSwitch545 = temp_cast_2;
				#endif
				#ifdef _ENABLETOPLAYERNOISE_ON
				float3 staticSwitch551 = staticSwitch545;
				#else
				float3 staticSwitch551 = temp_cast_1;
				#endif
				float3 Top_Layer_Noise_Mask547 = staticSwitch551;
				float lerpResult664 = lerp( 1.0 , input.ase_color.r , _TopLayerVPaintMaskIntensity);
				float Top_Layer_VPaint_Mask665 = lerpResult664;
				float3 Top_Layer_Mask462 = ( ( ( saturate( pow( saferPower17_g5 , ( _TopLayerContrast * ASPP_TopLayerContrast ) ) ) * ( _TopLayerIntensity * ASPP_TopLayerIntensity ) ) * Top_Layer_Noise_Mask547 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) * Top_Layer_VPaint_Mask665 );
				float3 lerpResult464 = lerp( Base_Detail_Albedo474 , (( blendOpDest432 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest432 ) * ( 1.0 - blendOpSrc432 ) ) : ( 2.0 * blendOpDest432 * blendOpSrc432 ) ) , Top_Layer_Mask462);
				float3 Top_Layer_Albedo467 = lerpResult464;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch472 = Top_Layer_Albedo467;
				#else
				float3 staticSwitch472 = Base_Detail_Albedo474;
				#endif
				float3 Output_Albedo520 = staticSwitch472;
				

				float3 BaseColor = Output_Albedo520;
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

			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_VERT_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON
			#pragma shader_feature_local _ENABLEDETAIL_ON
			#pragma shader_feature_local _ENABLETOPLAYERNOISE_ON


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
				float4 ase_texcoord : TEXCOORD0;
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
				float4 ase_texcoord6 : TEXCOORD6;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _BaseUVScale;
			half _TopLayerSmoothnessMin;
			float _BaseSmoothnessMax;
			float _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			half _DetailNormalIntensity;
			float _TopLayerVPaintMaskIntensity;
			float _TopLayerNoiseUVScale;
			half _TopLayerSmoothnessMax;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _TopLayerUVScale;
			float _DetailAlbedoIntensity;
			float _DetailAlbedoPower;
			float _DetailUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _TopLayerNoiseContrast;
			half _BaseAOIntensity;
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

			sampler2D _BaseNormal;
			sampler2D _DetailNormal;
			sampler2D _TopLayerNormal;
			half ASPP_TopLayerOffset;
			half ASPP_TopLayerContrast;
			half ASPP_TopLayerIntensity;
			sampler2D _TopLayerNoise;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;


			
			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				float3 ase_normalWS = TransformObjectToWorldNormal( input.normalOS );
				float3 ase_tangentWS = TransformObjectToWorldDir( input.tangentOS.xyz );
				float ase_tangentSign = input.tangentOS.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_bitangentWS = cross( ase_normalWS, ase_tangentWS ) * ase_tangentSign;
				output.ase_texcoord6.xyz = ase_bitangentWS;
				
				output.ase_texcoord5.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord5.zw = 0;
				output.ase_texcoord6.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

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

				float2 texCoord339 = input.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Base_UV_Scale342 = ( texCoord339 * _BaseUVScale );
				float3 unpack352 = UnpackNormalScale( tex2D( _BaseNormal, Base_UV_Scale342 ), _BaseNormalIntensity );
				unpack352.z = lerp( 1, unpack352.z, saturate(_BaseNormalIntensity) );
				float3 Base_Normal355 = unpack352;
				float2 texCoord392 = input.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Detail_UV_Scale395 = ( texCoord392 * _DetailUVScale );
				float3 unpack411 = UnpackNormalScale( tex2D( _DetailNormal, Detail_UV_Scale395 ), _DetailNormalIntensity );
				unpack411.z = lerp( 1, unpack411.z, saturate(_DetailNormalIntensity) );
				float3 Detail_Normal416 = BlendNormal( unpack411 , Base_Normal355 );
				#ifdef _ENABLEDETAIL_ON
				float3 staticSwitch446 = Detail_Normal416;
				#else
				float3 staticSwitch446 = Base_Normal355;
				#endif
				float3 Base_Detail_Normal475 = staticSwitch446;
				float2 texCoord426 = input.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale428 = ( texCoord426 * _TopLayerUVScale );
				float3 unpack436 = UnpackNormalScale( tex2D( _TopLayerNormal, Top_Layer_UV_Scale428 ), _TopLayerNormalIntensity );
				unpack436.z = lerp( 1, unpack436.z, saturate(_TopLayerNormalIntensity) );
				float3 tex2DNode436 = unpack436;
				float3 lerpResult438 = lerp( BlendNormal( tex2DNode436 , Base_Normal355 ) , tex2DNode436 , _TopLayerNormalInfluence);
				float3 ase_bitangentWS = input.ase_texcoord6.xyz;
				float3 tanToWorld0 = float3( WorldTangent.xyz.x, ase_bitangentWS.x, WorldNormal.x );
				float3 tanToWorld1 = float3( WorldTangent.xyz.y, ase_bitangentWS.y, WorldNormal.y );
				float3 tanToWorld2 = float3( WorldTangent.xyz.z, ase_bitangentWS.z, WorldNormal.z );
				float3 tanNormal558 = Base_Normal355;
				float3 worldNormal558 = float3( dot( tanToWorld0, tanNormal558 ), dot( tanToWorld1, tanNormal558 ), dot( tanToWorld2, tanNormal558 ) );
				float saferPower17_g5 = abs( abs( ( saturate( worldNormal558.y ) + ( _TopLayerOffset * ASPP_TopLayerOffset ) ) ) );
				float3 temp_cast_0 = (1.0).xxx;
				float3 temp_cast_1 = (1.0).xxx;
				float2 texCoord535 = input.ase_texcoord5.xy * float2( 0.1,0.1 ) + float2( 0,0 );
				float3 saferPower647 = abs( ( 1.0 - tex2D( _TopLayerNoise, ( texCoord535 * _TopLayerNoiseUVScale ) ).rgb ) );
				float3 temp_cast_2 = (_TopLayerNoiseContrast).xxx;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch545 = saturate( pow( saferPower647 , temp_cast_2 ) );
				#else
				float3 staticSwitch545 = temp_cast_1;
				#endif
				#ifdef _ENABLETOPLAYERNOISE_ON
				float3 staticSwitch551 = staticSwitch545;
				#else
				float3 staticSwitch551 = temp_cast_0;
				#endif
				float3 Top_Layer_Noise_Mask547 = staticSwitch551;
				float lerpResult664 = lerp( 1.0 , input.ase_color.r , _TopLayerVPaintMaskIntensity);
				float Top_Layer_VPaint_Mask665 = lerpResult664;
				float3 Top_Layer_Mask462 = ( ( ( saturate( pow( saferPower17_g5 , ( _TopLayerContrast * ASPP_TopLayerContrast ) ) ) * ( _TopLayerIntensity * ASPP_TopLayerIntensity ) ) * Top_Layer_Noise_Mask547 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) * Top_Layer_VPaint_Mask665 );
				float3 lerpResult443 = lerp( Base_Detail_Normal475 , lerpResult438 , Top_Layer_Mask462);
				float3 Top_Layer_Normal470 = lerpResult443;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch473 = Top_Layer_Normal470;
				#else
				float3 staticSwitch473 = Base_Detail_Normal475;
				#endif
				float3 Output_Normal523 = staticSwitch473;
				

				float3 Normal = Output_Normal523;
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

			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _ENABLETOPLAYERBLEND_ON
			#pragma shader_feature_local _ENABLEDETAIL_ON
			#pragma shader_feature_local _ENABLETOPLAYERNOISE_ON


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
			half4 _BaseAlbedoColor;
			half4 _TopLayerAlbedoColor;
			half3 _BaseEmissiveColor;
			float _BaseUVScale;
			half _TopLayerSmoothnessMin;
			float _BaseSmoothnessMax;
			float _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			half _DetailNormalIntensity;
			float _TopLayerVPaintMaskIntensity;
			float _TopLayerNoiseUVScale;
			half _TopLayerSmoothnessMax;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _TopLayerUVScale;
			float _DetailAlbedoIntensity;
			float _DetailAlbedoPower;
			float _DetailUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _TopLayerNoiseContrast;
			half _BaseAOIntensity;
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

			sampler2D _BaseAlbedo;
			sampler2D _DetailAlbedo;
			sampler2D _TopLayerAlbedo;
			sampler2D _BaseNormal;
			half ASPP_TopLayerOffset;
			half ASPP_TopLayerContrast;
			half ASPP_TopLayerIntensity;
			sampler2D _TopLayerNoise;
			half ASPT_TopLayerHeightStart;
			float ASPT_TopLayerHeightFade;
			sampler2D _DetailNormal;
			sampler2D _TopLayerNormal;
			sampler2D _BaseSMAE;
			sampler2D _TopLayerSmoothness;


			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityGBuffer.hlsl"

			
			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				output.ase_texcoord8.xy = input.texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord8.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

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

				float2 texCoord339 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Base_UV_Scale342 = ( texCoord339 * _BaseUVScale );
				float3 desaturateInitialColor658 = tex2D( _BaseAlbedo, Base_UV_Scale342 ).rgb;
				float desaturateDot658 = dot( desaturateInitialColor658, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar658 = lerp( desaturateInitialColor658, desaturateDot658.xxx, _BaseAlbedoDesaturation );
				float3 blendOpSrc345 = ( desaturateVar658 * _BaseAlbedoBrightness );
				float3 blendOpDest345 = _BaseAlbedoColor.rgb;
				float3 Base_Albedo350 = ( saturate( (( blendOpDest345 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest345 ) * ( 1.0 - blendOpSrc345 ) ) : ( 2.0 * blendOpDest345 * blendOpSrc345 ) ) ));
				float2 texCoord392 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Detail_UV_Scale395 = ( texCoord392 * _DetailUVScale );
				float3 saferPower400 = abs( ( tex2D( _DetailAlbedo, Detail_UV_Scale395 ).rgb * float3( 2,2,2 ) ) );
				float3 temp_cast_0 = (_DetailAlbedoPower).xxx;
				float3 blendOpSrc402 = Base_Albedo350;
				float3 blendOpDest402 = pow( saferPower400 , temp_cast_0 );
				float3 lerpResult407 = lerp( Base_Albedo350 , saturate( (( blendOpDest402 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest402 ) * ( 1.0 - blendOpSrc402 ) ) : ( 2.0 * blendOpDest402 * blendOpSrc402 ) ) ) , _DetailAlbedoIntensity);
				float3 Detail_Albedo410 = lerpResult407;
				#ifdef _ENABLEDETAIL_ON
				float3 staticSwitch421 = Detail_Albedo410;
				#else
				float3 staticSwitch421 = Base_Albedo350;
				#endif
				float3 Base_Detail_Albedo474 = staticSwitch421;
				float2 texCoord426 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 Top_Layer_UV_Scale428 = ( texCoord426 * _TopLayerUVScale );
				float3 blendOpSrc432 = tex2D( _TopLayerAlbedo, Top_Layer_UV_Scale428 ).rgb;
				float3 blendOpDest432 = _TopLayerAlbedoColor.rgb;
				float3 unpack352 = UnpackNormalScale( tex2D( _BaseNormal, Base_UV_Scale342 ), _BaseNormalIntensity );
				unpack352.z = lerp( 1, unpack352.z, saturate(_BaseNormalIntensity) );
				float3 Base_Normal355 = unpack352;
				float3 tanToWorld0 = float3( WorldTangent.x, WorldBiTangent.x, WorldNormal.x );
				float3 tanToWorld1 = float3( WorldTangent.y, WorldBiTangent.y, WorldNormal.y );
				float3 tanToWorld2 = float3( WorldTangent.z, WorldBiTangent.z, WorldNormal.z );
				float3 tanNormal558 = Base_Normal355;
				float3 worldNormal558 = float3( dot( tanToWorld0, tanNormal558 ), dot( tanToWorld1, tanNormal558 ), dot( tanToWorld2, tanNormal558 ) );
				float saferPower17_g5 = abs( abs( ( saturate( worldNormal558.y ) + ( _TopLayerOffset * ASPP_TopLayerOffset ) ) ) );
				float3 temp_cast_1 = (1.0).xxx;
				float3 temp_cast_2 = (1.0).xxx;
				float2 texCoord535 = input.ase_texcoord8.xy * float2( 0.1,0.1 ) + float2( 0,0 );
				float3 saferPower647 = abs( ( 1.0 - tex2D( _TopLayerNoise, ( texCoord535 * _TopLayerNoiseUVScale ) ).rgb ) );
				float3 temp_cast_3 = (_TopLayerNoiseContrast).xxx;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch545 = saturate( pow( saferPower647 , temp_cast_3 ) );
				#else
				float3 staticSwitch545 = temp_cast_2;
				#endif
				#ifdef _ENABLETOPLAYERNOISE_ON
				float3 staticSwitch551 = staticSwitch545;
				#else
				float3 staticSwitch551 = temp_cast_1;
				#endif
				float3 Top_Layer_Noise_Mask547 = staticSwitch551;
				float lerpResult664 = lerp( 1.0 , input.ase_color.r , _TopLayerVPaintMaskIntensity);
				float Top_Layer_VPaint_Mask665 = lerpResult664;
				float3 Top_Layer_Mask462 = ( ( ( saturate( pow( saferPower17_g5 , ( _TopLayerContrast * ASPP_TopLayerContrast ) ) ) * ( _TopLayerIntensity * ASPP_TopLayerIntensity ) ) * Top_Layer_Noise_Mask547 ) * saturate( (0.0 + (WorldPosition.y - ASPT_TopLayerHeightStart) * (1.0 - 0.0) / (( ASPT_TopLayerHeightStart + ASPT_TopLayerHeightFade ) - ASPT_TopLayerHeightStart)) ) * Top_Layer_VPaint_Mask665 );
				float3 lerpResult464 = lerp( Base_Detail_Albedo474 , (( blendOpDest432 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest432 ) * ( 1.0 - blendOpSrc432 ) ) : ( 2.0 * blendOpDest432 * blendOpSrc432 ) ) , Top_Layer_Mask462);
				float3 Top_Layer_Albedo467 = lerpResult464;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch472 = Top_Layer_Albedo467;
				#else
				float3 staticSwitch472 = Base_Detail_Albedo474;
				#endif
				float3 Output_Albedo520 = staticSwitch472;
				
				float3 unpack411 = UnpackNormalScale( tex2D( _DetailNormal, Detail_UV_Scale395 ), _DetailNormalIntensity );
				unpack411.z = lerp( 1, unpack411.z, saturate(_DetailNormalIntensity) );
				float3 Detail_Normal416 = BlendNormal( unpack411 , Base_Normal355 );
				#ifdef _ENABLEDETAIL_ON
				float3 staticSwitch446 = Detail_Normal416;
				#else
				float3 staticSwitch446 = Base_Normal355;
				#endif
				float3 Base_Detail_Normal475 = staticSwitch446;
				float3 unpack436 = UnpackNormalScale( tex2D( _TopLayerNormal, Top_Layer_UV_Scale428 ), _TopLayerNormalIntensity );
				unpack436.z = lerp( 1, unpack436.z, saturate(_TopLayerNormalIntensity) );
				float3 tex2DNode436 = unpack436;
				float3 lerpResult438 = lerp( BlendNormal( tex2DNode436 , Base_Normal355 ) , tex2DNode436 , _TopLayerNormalInfluence);
				float3 lerpResult443 = lerp( Base_Detail_Normal475 , lerpResult438 , Top_Layer_Mask462);
				float3 Top_Layer_Normal470 = lerpResult443;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch473 = Top_Layer_Normal470;
				#else
				float3 staticSwitch473 = Base_Detail_Normal475;
				#endif
				float3 Output_Normal523 = staticSwitch473;
				
				float4 tex2DNode357 = tex2D( _BaseSMAE, Base_UV_Scale342 );
				float Emissive_Mask371 = tex2DNode357.a;
				float saferPower373 = abs( Emissive_Mask371 );
				float3 Base_Emissive377 = ( ( _BaseEmissiveColor * pow( saferPower373 , _BaseEmissiveMaskContrast ) ) * _BaseEmissiveIntensity );
				float3 lerpResult507 = lerp( Base_Emissive377 , float3( 0,0,0 ) , Top_Layer_Mask462);
				float3 Top_Layer_Emissive509 = lerpResult507;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float3 staticSwitch510 = Top_Layer_Emissive509;
				#else
				float3 staticSwitch510 = Base_Emissive377;
				#endif
				float3 Output_Emissive526 = staticSwitch510;
				
				float Base_Metallic364 = ( tex2DNode357.g * _BaseMetallicIntensity );
				float lerpResult483 = lerp( Base_Metallic364 , 0.0 , Top_Layer_Mask462.x);
				float Top_Layer_Metallic486 = lerpResult483;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch489 = Top_Layer_Metallic486;
				#else
				float staticSwitch489 = Base_Metallic364;
				#endif
				float Output_Metallic524 = staticSwitch489;
				
				float Texture_Smoothness668 = tex2DNode357.r;
				float lerpResult673 = lerp( _BaseSmoothnessMin , _BaseSmoothnessMax , Texture_Smoothness668);
				float Base_Smoothness361 = saturate( lerpResult673 );
				float lerpResult679 = lerp( _TopLayerSmoothnessMin , _TopLayerSmoothnessMax , tex2D( _TopLayerSmoothness, Top_Layer_UV_Scale428 ).r);
				float lerpResult499 = lerp( Base_Smoothness361 , lerpResult679 , Top_Layer_Mask462.x);
				float Top_Layer_Smoothness502 = saturate( lerpResult499 );
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch503 = Top_Layer_Smoothness502;
				#else
				float staticSwitch503 = Base_Smoothness361;
				#endif
				float Output_Smoothness525 = staticSwitch503;
				
				float lerpResult365 = lerp( 1.0 , tex2DNode357.b , _BaseAOIntensity);
				float Base_AO348 = lerpResult365;
				float lerpResult514 = lerp( Base_AO348 , 1.0 , Top_Layer_Mask462.x);
				float Top_Layer_AO516 = lerpResult514;
				#ifdef _ENABLETOPLAYERBLEND_ON
				float staticSwitch517 = Top_Layer_AO516;
				#else
				float staticSwitch517 = Base_AO348;
				#endif
				float Output_AO527 = staticSwitch517;
				

				float3 BaseColor = Output_Albedo520;
				float3 Normal = Output_Normal523;
				float3 Emission = Output_Emissive526;
				float3 Specular = 0.5;
				float Metallic = Output_Metallic524;
				float Smoothness = Output_Smoothness525;
				float Occlusion = Output_AO527;
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

			

			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				
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
			float _BaseUVScale;
			half _TopLayerSmoothnessMin;
			float _BaseSmoothnessMax;
			float _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			half _DetailNormalIntensity;
			float _TopLayerVPaintMaskIntensity;
			float _TopLayerNoiseUVScale;
			half _TopLayerSmoothnessMax;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _TopLayerUVScale;
			float _DetailAlbedoIntensity;
			float _DetailAlbedoPower;
			float _DetailUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _TopLayerNoiseContrast;
			half _BaseAOIntensity;
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

				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

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

			

			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				
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
			float _BaseUVScale;
			half _TopLayerSmoothnessMin;
			float _BaseSmoothnessMax;
			float _BaseSmoothnessMin;
			half _BaseMetallicIntensity;
			float _BaseEmissiveIntensity;
			float _BaseEmissiveMaskContrast;
			half _TopLayerNormalInfluence;
			half _TopLayerNormalIntensity;
			half _DetailNormalIntensity;
			float _TopLayerVPaintMaskIntensity;
			float _TopLayerNoiseUVScale;
			half _TopLayerSmoothnessMax;
			half _TopLayerIntensity;
			half _TopLayerContrast;
			half _TopLayerOffset;
			half _BaseNormalIntensity;
			float _TopLayerUVScale;
			float _DetailAlbedoIntensity;
			float _DetailAlbedoPower;
			float _DetailUVScale;
			float _BaseAlbedoBrightness;
			float _BaseAlbedoDesaturation;
			float _TopLayerNoiseContrast;
			half _BaseAOIntensity;
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

				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = input.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

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
Node;AmplifyShaderEditor.CommentaryNode;667;1726,2896;Inherit;False;960.5;429.0999;;4;663;665;664;662;Top Layer VPaint Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;626;1728,590;Inherit;False;832;305;;4;428;427;429;426;Top Layer UVs;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;625;1727,1104;Inherit;False;1983;914;;17;650;462;649;549;455;454;453;548;460;461;459;558;456;458;457;448;666;Top Layer Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;624;1730,78;Inherit;False;960;304;;4;509;507;508;506;Top Layer Emissive;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;623;1729,-434;Inherit;False;955;304;;4;516;514;513;515;Top Layer AO;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;622;1731,-946;Inherit;False;957;308;;4;486;483;484;482;Top Layer Metallic;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;621;1732,-1586;Inherit;False;2238;498;;10;678;677;679;500;501;584;499;496;502;495;Top Layer Smoothness;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;620;1733,-2240;Inherit;False;2233;447;;11;436;442;435;470;443;477;469;438;439;440;437;Top Layer Normal;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;619;1730,-2994;Inherit;False;1852;559;;8;466;430;476;433;467;464;432;431;Top Layer Albedo;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;618;-1469,-1714;Inherit;False;831;304;;4;395;394;393;392;Detail UVs;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;617;-1473,-2354;Inherit;False;1473;434;;6;416;413;411;414;415;412;Detail Normal;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;616;-1471,-2994;Inherit;False;2495;432;;12;409;401;396;410;407;408;406;402;400;403;398;397;Detail Albedo;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;615;-3776,80;Inherit;False;827;303;;4;342;341;340;339;Base UVs;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;614;-3776,-688;Inherit;False;1602;560;;8;376;374;369;377;375;370;373;372;Base Emissive;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;613;-3774,-1840;Inherit;False;1599;934;[R] Smoothness | [G] Metallic | [B] AmbientOcclusion | [A] Emissive;16;674;361;570;673;672;671;367;363;364;362;371;348;365;668;357;358;Base SMAE;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;612;-3777,-2352;Inherit;False;1600;303;;4;352;355;354;353;Base Normal;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;611;-3772,-2994;Inherit;False;1853;501;;9;350;345;481;660;659;661;658;343;344;Base Albedo;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;552;1729,2256;Inherit;False;2882;431;;12;539;536;543;545;547;551;546;544;541;537;535;647;Top Layer Noise Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;556;4804,-2992;Inherit;False;1729;1580;;30;527;517;519;518;525;524;526;523;520;472;510;503;489;473;380;504;490;488;512;511;471;468;474;475;421;446;319;419;420;356;Switches;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;603;6979,-2992;Inherit;False;889;688;Comment;16;641;640;639;638;637;636;635;634;633;632;533;532;531;530;529;522;Output;1,0,0,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;344;-3712,-2944;Inherit;False;342;Base UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;353;-3712,-2304;Inherit;False;342;Base UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;354;-3712,-2176;Half;False;Property;_BaseNormalIntensity;Base Normal Intensity;7;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;358;-3712,-1792;Inherit;False;342;Base UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;355;-2432,-2304;Inherit;False;Base Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;397;-1408,-2944;Inherit;False;395;Detail UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;398;-640,-2944;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;2,2,2;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;403;-256,-2816;Inherit;False;350;Base Albedo;1;0;OBJECT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;406;256,-2944;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;408;256,-2816;Inherit;False;350;Base Albedo;1;0;OBJECT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;407;512,-2944;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;396;-1024,-2944;Inherit;True;Property;_DetailAlbedo;Detail Albedo;38;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;3b5ec0ed815e27d4c80112b53c024182;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;401;-640,-2816;Inherit;False;Property;_DetailAlbedoPower;Detail Albedo Power;36;0;Create;True;0;0;0;False;0;False;1;1;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;409;256,-2720;Inherit;False;Property;_DetailAlbedoIntensity;Detail Albedo Intensity;35;0;Create;True;0;0;0;False;0;False;1;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;412;-1408,-2304;Inherit;False;395;Detail UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;415;-1024,-2080;Inherit;False;355;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BlendNormalsNode;414;-640,-2304;Inherit;False;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;411;-1024,-2304;Inherit;True;Property;_DetailNormal;Detail Normal;39;2;[NoScaleOffset];[Normal];Create;True;0;0;0;False;0;False;-1;None;df04d36d54fbf4248bdad4d753206afe;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.TextureCoordinatesNode;392;-1408,-1664;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;393;-1408,-1536;Inherit;False;Property;_DetailUVScale;Detail UV Scale;34;0;Create;True;0;0;0;False;0;False;2;2;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;394;-1152,-1664;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;395;-880,-1664;Inherit;False;Detail UV Scale;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;431;1792,-2944;Inherit;False;428;Top Layer UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.BlendOpsNode;432;2688,-2944;Inherit;False;Overlay;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;464;3072,-2944;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;467;3328,-2944;Inherit;False;Top Layer Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;433;2304,-2688;Half;False;Property;_TopLayerAlbedoColor;Top Layer Albedo Color;16;1;[HDR];Create;True;0;0;0;False;0;False;0.5019608,0.5019608,0.5019608,0.5019608;0.5019608,0.5019608,0.5019608,0.5019608;False;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;476;2688,-2816;Inherit;False;474;Base Detail Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;437;1792,-2176;Inherit;False;428;Top Layer UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;440;2304,-1920;Inherit;False;355;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BlendNormalsNode;439;2688,-2048;Inherit;False;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;438;3072,-2176;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;469;3072,-1920;Inherit;False;462;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;477;3072,-2048;Inherit;False;475;Base Detail Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;443;3456,-2176;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;470;3712,-2176;Inherit;False;Top Layer Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;435;1792,-2048;Half;False;Property;_TopLayerNormalIntensity;Top Layer Normal Intensity;20;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;442;2688,-1920;Half;False;Property;_TopLayerNormalInfluence;Top Layer Normal Influence;21;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;495;1792,-1536;Inherit;False;428;Top Layer UV Scale;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;502;3712,-1536;Inherit;False;Top Layer Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;482;1792,-896;Inherit;False;364;Base Metallic;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;484;1792,-768;Inherit;False;462;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;483;2176,-896;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;486;2432,-896;Inherit;False;Top Layer Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;515;1792,-256;Inherit;False;462;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;513;1792,-384;Inherit;False;348;Base AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;514;2176,-384;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;516;2432,-384;Inherit;False;Top Layer AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;506;1792,128;Inherit;False;377;Base Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;508;1792,256;Inherit;False;462;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;507;2176,128;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;509;2432,128;Inherit;False;Top Layer Emissive;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;496;2304,-1536;Inherit;True;Property;_TopLayerSmoothness;Top Layer Smoothness;28;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;8e8ac0c4acbd18f45891d51182feebda;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SamplerNode;436;2304,-2176;Inherit;True;Property;_TopLayerNormal;Top Layer Normal;27;2;[NoScaleOffset];[Normal];Create;True;0;0;0;False;0;False;-1;None;ce33c7bbfcc6ff044979c54b9fb01fae;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SamplerNode;430;2304,-2944;Inherit;True;Property;_TopLayerAlbedo;Top Layer Albedo;26;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;f6dc7c0cfcd8cb54cb5f4dbe15bb7047;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;448;1792,1152;Inherit;False;355;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;457;1792,1888;Half;False;Global;ASPP_TopLayerContrast;ASPP_TopLayerContrast;27;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;458;1792,1696;Half;False;Global;ASPP_TopLayerOffset;ASPP_TopLayerOffset;27;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;456;1792,1504;Half;False;Global;ASPP_TopLayerIntensity;ASPP_TopLayerIntensity;27;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;558;2048,1152;Inherit;False;False;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;459;2176,1408;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;461;2176,1792;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;460;2176,1600;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;548;2816,1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;453;1792,1408;Half;False;Property;_TopLayerIntensity;Top Layer Intensity;22;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;454;1792,1600;Half;False;Property;_TopLayerOffset;Top Layer Offset;23;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;455;1792,1792;Half;False;Property;_TopLayerContrast;Top Layer Contrast;24;0;Create;True;0;0;0;False;0;False;10;10;0;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;537;2048,2304;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;541;2688,2304;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;544;3328,2304;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;545;3584,2304;Inherit;False;Property;_EnableDetail8;Enable Detail;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;472;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;426;1792,640;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;429;1792,768;Inherit;False;Property;_TopLayerUVScale;Top Layer UV Scale;17;0;Create;True;0;0;0;False;0;False;5;5;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;427;2048,640;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;428;2304,640;Inherit;False;Top Layer UV Scale;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;356;4864,-2688;Inherit;False;355;Base Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;420;4864,-2560;Inherit;False;416;Detail Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;419;4864,-2816;Inherit;False;410;Detail Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;319;4864,-2944;Inherit;False;350;Base Albedo;1;0;OBJECT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;446;5248,-2688;Inherit;False;Property;_EnableDetail2;Enable Detail;33;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;421;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;421;5248,-2944;Inherit;False;Property;_EnableDetail;Enable Detail;33;0;Create;True;0;0;0;False;1;Header(Detail);False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;475;5504,-2688;Inherit;False;Base Detail Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;474;5504,-2944;Inherit;False;Base Detail Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;468;5504,-2816;Inherit;False;467;Top Layer Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;471;5504,-2560;Inherit;False;470;Top Layer Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;511;5504,-2432;Inherit;False;377;Base Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;512;5504,-2336;Inherit;False;509;Top Layer Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;488;5504,-2080;Inherit;False;486;Top Layer Metallic;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;490;5504,-2176;Inherit;False;364;Base Metallic;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;504;5504,-1824;Inherit;False;502;Top Layer Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;380;5504,-1920;Inherit;False;361;Base Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;473;5888,-2688;Inherit;False;Property;_EnableDetail3;Enable Detail;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;472;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;489;5888,-2176;Inherit;False;Property;_EnableDetail4;Enable Detail;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;472;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;503;5888,-1920;Inherit;False;Property;_EnableDetail5;Enable Detail;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;472;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;510;5888,-2432;Inherit;False;Property;_EnableDetail6;Enable Detail;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;472;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;472;5888,-2944;Inherit;False;Property;_EnableTopLayerBlend;Enable Top Layer Blend;15;0;Create;True;0;0;0;False;1;Header(Top Layer);False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;520;6272,-2944;Inherit;False;Output Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;523;6272,-2688;Inherit;False;Output Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;526;6272,-2432;Inherit;False;Output Emissive;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;524;6272,-2176;Inherit;False;Output Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;525;6272,-1920;Inherit;False;Output Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;518;5504,-1664;Inherit;False;348;Base AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;519;5504,-1568;Inherit;False;516;Top Layer AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;517;5888,-1664;Inherit;False;Property;_EnableDetail7;Enable Detail;15;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;472;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;527;6272,-1664;Inherit;False;Output AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;522;7040,-2944;Inherit;False;520;Output Albedo;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;529;7040,-2848;Inherit;False;523;Output Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;530;7040,-2752;Inherit;False;526;Output Emissive;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;531;7040,-2656;Inherit;False;524;Output Metallic;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;532;7040,-2560;Inherit;False;525;Output Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;533;7040,-2464;Inherit;False;527;Output AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;343;-3328,-2944;Inherit;True;Property;_BaseAlbedo;Base Albedo;12;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;1c7b87cad3de94e4a8b4db83be10366f;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SamplerNode;352;-3328,-2304;Inherit;True;Property;_BaseNormal;Base Normal;13;2;[NoScaleOffset];[Normal];Create;True;0;0;0;False;0;False;-1;None;988a757117eb83b418d8e0372d15c040;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SamplerNode;357;-3328,-1792;Inherit;True;Property;_BaseSMAE;Base SMAE;14;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;3dee2eec0b6a3a74c868dd970b9ba25c;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;466;2688,-2688;Inherit;False;462;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;416;-256,-2304;Inherit;False;Detail Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;413;-1408,-2176;Half;False;Property;_DetailNormalIntensity;Detail Normal Intensity;37;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.BlendOpsNode;402;0,-2944;Inherit;False;Overlay;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;410;768,-2944;Inherit;False;Detail Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;535;1792,2304;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;0.1,0.1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;547;4352,2304;Inherit;False;Top Layer Noise Mask;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;549;2432,1408;Inherit;False;547;Top Layer Noise Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.FunctionNode;649;2432,1152;Inherit;False;MF_ASP_Global_TopLayer;-1;;5;6dc1725aa9649cc439f99987e8365ea2;0;4;22;FLOAT;0;False;24;FLOAT;1;False;23;FLOAT;0.5;False;25;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;462;3456,1152;Inherit;False;Top Layer Mask;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;650;3200,1152;Inherit;False;3;3;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.FunctionNode;657;2816,1408;Inherit;False;MF_ASP_Global_TopLayerHeight;-1;;44;0851e7dd80a2406479a4b23dfe36fe1f;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DesaturateOpNode;658;-2944,-2944;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;661;-2688,-2944;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;659;-3328,-2688;Inherit;False;Property;_BaseAlbedoDesaturation;Base Albedo Desaturation;2;0;Create;True;0;0;0;False;0;False;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;481;-2688,-2816;Half;False;Property;_BaseAlbedoColor;Base Albedo Color;0;1;[HDR];Create;True;0;0;0;False;1;Header(Base);False;0.5019608,0.5019608,0.5019608,0.5019608;0.5520116,0.4178852,0.3419144,0;False;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RegisterLocalVarNode;350;-2176,-2944;Inherit;False;Base Albedo;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BlendOpsNode;345;-2432,-2944;Inherit;False;Overlay;True;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.PowerNode;400;-256,-2944;Inherit;False;True;2;0;FLOAT3;0,0,0;False;1;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.PowerNode;647;3072,2304;Inherit;False;True;2;0;FLOAT3;0,0,0;False;1;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;660;-3328,-2592;Inherit;False;Property;_BaseAlbedoBrightness;Base Albedo Brightness;1;0;Create;True;0;0;0;False;0;False;1;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;666;2816,1536;Inherit;False;665;Top Layer VPaint Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;543;2688,2432;Inherit;False;Property;_TopLayerNoiseContrast;Top Layer Noise Contrast;31;0;Create;True;0;0;0;False;0;False;1;1;0;20;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;536;1792,2432;Inherit;False;Property;_TopLayerNoiseUVScale;Top Layer Noise UV Scale;30;0;Create;True;0;0;0;False;0;False;5;5;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;539;2304,2304;Inherit;True;Property;_TopLayerNoise;Top Layer Noise;32;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;e93d8f0da5bea8144ad9925e81909be8;True;0;False;black;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;546;3328,2432;Inherit;False;Constant;_One;One;40;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;551;3968,2304;Inherit;False;Property;_EnableTopLayerNoise;Enable Top Layer Noise;29;0;Create;True;0;0;0;False;1;Header(Top Layer Noise);False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.VertexColorNode;662;1792,2946;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;664;2176,2946;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;665;2432,2946;Inherit;False;Top Layer VPaint Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;663;1792,3136;Inherit;False;Property;_TopLayerVPaintMaskIntensity;Top Layer VPaint Mask Intensity;25;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;372;-3712,-384;Inherit;False;371;Emissive Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;370;-3200,-640;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;375;-2816,-640;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;377;-2432,-640;Inherit;False;Base Emissive;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;369;-3712,-640;Half;False;Property;_BaseEmissiveColor;Base Emissive Color;9;1;[HDR];Create;True;0;0;0;False;0;False;0,0,0,0;0,0,0,1;False;False;0;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;374;-3712,-256;Inherit;False;Property;_BaseEmissiveMaskContrast;Base Emissive Mask Contrast;11;0;Create;True;0;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;376;-3072,-384;Inherit;False;Property;_BaseEmissiveIntensity;Base Emissive Intensity;10;0;Create;True;0;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;339;-3712,128;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;340;-3712,256;Inherit;False;Property;_BaseUVScale;Base UV Scale;3;0;Create;True;0;0;0;False;0;False;1;1;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;341;-3456,128;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;342;-3200,128;Inherit;False;Base UV Scale;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PowerNode;373;-3328,-384;Inherit;False;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;365;-2944,-1568;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;348;-2432,-1568;Inherit;False;Base AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;371;-2944,-1440;Inherit;False;Emissive Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;362;-2944,-1696;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;364;-2432,-1696;Inherit;False;Base Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;363;-3328,-1568;Half;False;Property;_BaseMetallicIntensity;Base Metallic Intensity;4;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;367;-3328,-1472;Half;False;Property;_BaseAOIntensity;Base AO Intensity;8;0;Create;True;0;0;0;False;0;False;0.5;0.491;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;361;-2432,-1280;Inherit;False;Base Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;668;-2944,-1792;Inherit;False;Texture Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;500;2688,-1408;Inherit;False;361;Base Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;501;2688,-1312;Inherit;False;462;Top Layer Mask;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;499;2944,-1536;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;584;3200,-1536;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;679;2688,-1536;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;677;2304,-1312;Half;False;Property;_TopLayerSmoothnessMin;Top Layer Smoothness Min;18;0;Create;True;0;0;0;False;0;False;0;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;678;2304,-1216;Half;False;Property;_TopLayerSmoothnessMax;Top Layer Smoothness Max;19;0;Create;True;0;0;0;False;0;False;1;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;671;-3328,-1280;Inherit;False;Property;_BaseSmoothnessMin;Base Smoothness Min;5;0;Create;True;0;0;0;False;0;False;0;0.5;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;672;-3328,-1184;Inherit;False;Property;_BaseSmoothnessMax;Base Smoothness Max;6;0;Create;True;0;0;0;False;0;False;1;0.5;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;673;-2944,-1280;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;570;-2688,-1280;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;674;-3328,-1088;Inherit;False;668;Texture Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;632;7552,-2944;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ExtraPrePass;0;0;ExtraPrePass;5;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;633;7552,-2944;Float;False;True;-1;3;;0;12;ANGRYMESH/Stylized Pack/Props;94348b07e5e8bab40bd6c8a1e3df54cd;True;Forward;0;1;Forward;21;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalForward;False;False;0;;0;0;Standard;43;Lighting Model;0;0;Workflow;1;0;Surface;0;0;  Refraction Model;0;0;  Blend;0;0;Two Sided;1;0;Alpha Clipping;1;0;  Use Shadow Threshold;0;0;Fragment Normal Space,InvertActionOnDeselection;0;0;Forward Only;0;0;Transmission;0;0;  Transmission Shadow;0.5,False,;0;Translucency;0;0;  Translucency Strength;1,False,;0;  Normal Distortion;0.5,False,;0;  Scattering;2,False,;0;  Direct;0.9,False,;0;  Ambient;0.1,False,;0;  Shadow;0.5,False,;0;Cast Shadows;1;0;Receive Shadows;1;0;Receive SSAO;1;0;GPU Instancing;1;0;LOD CrossFade;1;0;Built-in Fog;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Write Depth;0;0;  Early Z;0;0;Vertex Position,InvertActionOnDeselection;1;0;Debug Display;1;638761850733217956;Clear Coat;0;0;0;10;False;True;True;True;True;True;True;True;True;True;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;634;7552,-2944;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;635;7552,-2944;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;True;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;636;7552,-2944;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;637;7552,-2944;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;638;7552,-2944;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormals;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;639;7552,-2944;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;GBuffer;0;7;GBuffer;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalGBuffer;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;640;7552,-2944;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;SceneSelectionPass;0;8;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;641;7552,-2944;Float;False;False;-1;3;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ScenePickingPass;0;9;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
WireConnection;355;0;352;0
WireConnection;398;0;396;5
WireConnection;406;0;402;0
WireConnection;407;0;408;0
WireConnection;407;1;406;0
WireConnection;407;2;409;0
WireConnection;396;1;397;0
WireConnection;414;0;411;0
WireConnection;414;1;415;0
WireConnection;411;1;412;0
WireConnection;411;5;413;0
WireConnection;394;0;392;0
WireConnection;394;1;393;0
WireConnection;395;0;394;0
WireConnection;432;0;430;5
WireConnection;432;1;433;5
WireConnection;464;0;476;0
WireConnection;464;1;432;0
WireConnection;464;2;466;0
WireConnection;467;0;464;0
WireConnection;439;0;436;0
WireConnection;439;1;440;0
WireConnection;438;0;439;0
WireConnection;438;1;436;0
WireConnection;438;2;442;0
WireConnection;443;0;477;0
WireConnection;443;1;438;0
WireConnection;443;2;469;0
WireConnection;470;0;443;0
WireConnection;502;0;584;0
WireConnection;483;0;482;0
WireConnection;483;2;484;0
WireConnection;486;0;483;0
WireConnection;514;0;513;0
WireConnection;514;2;515;0
WireConnection;516;0;514;0
WireConnection;507;0;506;0
WireConnection;507;2;508;0
WireConnection;509;0;507;0
WireConnection;496;1;495;0
WireConnection;436;1;437;0
WireConnection;436;5;435;0
WireConnection;430;1;431;0
WireConnection;558;0;448;0
WireConnection;459;0;453;0
WireConnection;459;1;456;0
WireConnection;461;0;455;0
WireConnection;461;1;457;0
WireConnection;460;0;454;0
WireConnection;460;1;458;0
WireConnection;548;0;649;0
WireConnection;548;1;549;0
WireConnection;537;0;535;0
WireConnection;537;1;536;0
WireConnection;541;0;539;5
WireConnection;544;0;647;0
WireConnection;545;1;546;0
WireConnection;545;0;544;0
WireConnection;427;0;426;0
WireConnection;427;1;429;0
WireConnection;428;0;427;0
WireConnection;446;1;356;0
WireConnection;446;0;420;0
WireConnection;421;1;319;0
WireConnection;421;0;419;0
WireConnection;475;0;446;0
WireConnection;474;0;421;0
WireConnection;473;1;475;0
WireConnection;473;0;471;0
WireConnection;489;1;490;0
WireConnection;489;0;488;0
WireConnection;503;1;380;0
WireConnection;503;0;504;0
WireConnection;510;1;511;0
WireConnection;510;0;512;0
WireConnection;472;1;474;0
WireConnection;472;0;468;0
WireConnection;520;0;472;0
WireConnection;523;0;473;0
WireConnection;526;0;510;0
WireConnection;524;0;489;0
WireConnection;525;0;503;0
WireConnection;517;1;518;0
WireConnection;517;0;519;0
WireConnection;527;0;517;0
WireConnection;343;1;344;0
WireConnection;352;1;353;0
WireConnection;352;5;354;0
WireConnection;357;1;358;0
WireConnection;416;0;414;0
WireConnection;402;0;403;0
WireConnection;402;1;400;0
WireConnection;410;0;407;0
WireConnection;547;0;551;0
WireConnection;649;22;558;2
WireConnection;649;24;459;0
WireConnection;649;23;460;0
WireConnection;649;25;461;0
WireConnection;462;0;650;0
WireConnection;650;0;548;0
WireConnection;650;1;657;0
WireConnection;650;2;666;0
WireConnection;658;0;343;5
WireConnection;658;1;659;0
WireConnection;661;0;658;0
WireConnection;661;1;660;0
WireConnection;350;0;345;0
WireConnection;345;0;661;0
WireConnection;345;1;481;5
WireConnection;400;0;398;0
WireConnection;400;1;401;0
WireConnection;647;0;541;0
WireConnection;647;1;543;0
WireConnection;539;1;537;0
WireConnection;551;1;546;0
WireConnection;551;0;545;0
WireConnection;664;1;662;1
WireConnection;664;2;663;0
WireConnection;665;0;664;0
WireConnection;370;0;369;0
WireConnection;370;1;373;0
WireConnection;375;0;370;0
WireConnection;375;1;376;0
WireConnection;377;0;375;0
WireConnection;341;0;339;0
WireConnection;341;1;340;0
WireConnection;342;0;341;0
WireConnection;373;0;372;0
WireConnection;373;1;374;0
WireConnection;365;1;357;3
WireConnection;365;2;367;0
WireConnection;348;0;365;0
WireConnection;371;0;357;4
WireConnection;362;0;357;2
WireConnection;362;1;363;0
WireConnection;364;0;362;0
WireConnection;361;0;570;0
WireConnection;668;0;357;1
WireConnection;499;0;500;0
WireConnection;499;1;679;0
WireConnection;499;2;501;0
WireConnection;584;0;499;0
WireConnection;679;0;677;0
WireConnection;679;1;678;0
WireConnection;679;2;496;1
WireConnection;673;0;671;0
WireConnection;673;1;672;0
WireConnection;673;2;674;0
WireConnection;570;0;673;0
WireConnection;633;0;522;0
WireConnection;633;1;529;0
WireConnection;633;2;530;0
WireConnection;633;3;531;0
WireConnection;633;4;532;0
WireConnection;633;5;533;0
ASEEND*/
//CHKSM=BE93EF170183910CD7876139E409034E3D16F4BE