// Made with Amplify Shader Editor v1.9.8.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "TriForge/Four Layer Blend"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[Header(Layer 1 Maps)][SingleLineTexture][Space(10)]_Layer1BaseColorMap("Layer 1 Base Color Map", 2D) = "white" {}
		[Normal][SingleLineTexture]_Layer1NormalMap("Layer 1 Normal Map", 2D) = "bump" {}
		[SingleLineTexture]_Layer1MaskMap("Layer 1 Mask Map", 2D) = "white" {}
		[Header(Layer 1 Attributes)][Space(10)]_Layer1Color("Layer 1 Color", Color) = (1,1,1,0)
		_Layer1Smoothness("Layer 1 Smoothness", Range( 0 , 1)) = 1
		_Layer1AOIntensity("Layer 1 AO Intensity", Range( 0 , 1)) = 1
		_Layer1NormalIntensity("Layer 1 Normal Intensity", Range( -2 , 2)) = 1
		[Toggle(_LAYER1USEAOASHEIGHT_ON)] _Layer1UseAOasHeight("Layer 1 Use AO as Height", Float) = 0
		[Header(Layer 1 Blend Map)][Space(10)]_Layer1BlendMidLevel("Layer 1 Blend Mid Level", Range( -1 , 2)) = 1
		_Layer1LowLevel("Layer 1 Low Level", Float) = 0
		_Layer1HighLevel("Layer 1 High Level", Float) = 1
		[Header(Layer 2 Maps)][SingleLineTexture][Space(10)]_Layer2BaseColorMap("Layer 2 Base Color Map", 2D) = "white" {}
		[Normal][SingleLineTexture]_Layer2NormalMap("Layer 2 Normal Map", 2D) = "bump" {}
		[SingleLineTexture]_Layer2MaskMap("Layer 2 Mask Map", 2D) = "white" {}
		[Header(Layer 2 Attributes)][Space(10)]_Layer2Color("Layer 2 Color", Color) = (1,1,1,0)
		_Layer2Smoothness("Layer 2 Smoothness", Range( 0 , 1)) = 1
		_Layer1AOIntensity("Layer 2 AO Intensity", Range( 0 , 1)) = 1
		_Layer2NormalIntensity("Layer 2 Normal Intensity", Range( -2 , 2)) = 1
		[Toggle(_LAYER2USEAOASHEIGHT_ON)] _Layer2UseAOasHeight("Layer 2 Use AO as Height", Float) = 0
		[Header(Layer 2 Blend Map)][Space(10)]_Layer2BlendMidLevel("Layer 2 Blend Mid Level", Range( -1 , 2)) = 1
		_Layer2LowLevel("Layer 2 Low Level", Float) = 0
		_Layer2HighLevel("Layer 2 High Level", Float) = 1
		_Layer2BlendSharpness("Layer 2 Blend Sharpness", Float) = 5
		[Header(Layer 3 Maps)][SingleLineTexture][Space(10)]_Layer3BaseColorMap("Layer 3 Base Color Map", 2D) = "white" {}
		[Normal][SingleLineTexture]_Layer3NormalMap("Layer 3 Normal Map", 2D) = "bump" {}
		[SingleLineTexture]_Layer3MaskMap("Layer 3 Mask Map", 2D) = "white" {}
		[Header(Layer 3 Attributes)][Space(10)]_Layer3Color("Layer 3 Color", Color) = (1,1,1,0)
		_Layer3Smoothness("Layer 3 Smoothness", Range( 0 , 1)) = 1
		_Layer3AOIntensity("Layer 3 AO Intensity", Range( 0 , 1)) = 1
		_Layer3NormalIntensity("Layer 3 Normal Intensity", Range( -2 , 2)) = 0
		[Toggle(_LAYER3USEAOASHEIGHT_ON)] _Layer3UseAOasHeight("Layer 3 Use AO as Height", Float) = 0
		[Header(Layer 3 Blend Map)][Space(10)]_Layer3BlendMidLevel("Layer 3 Blend Mid Level", Range( -1 , 2)) = 1
		_Layer3LowLevel("Layer 3 Low Level", Float) = 0
		_Layer3HighLevel("Layer 3 High Level", Float) = 1
		_Layer3BlendSharpness("Layer 3 Blend Sharpness", Range( 0 , 50)) = 1
		[Header(Layer 4 Maps)][SingleLineTexture][Space(10)]_Layer4BaseColorMap("Layer 4 Base Color Map", 2D) = "white" {}
		[Normal][SingleLineTexture]_Layer4NormalMap("Layer 4 Normal Map", 2D) = "bump" {}
		[SingleLineTexture]_Layer4MaskMap("Layer 4 Mask Map", 2D) = "white" {}
		[Header(Layer 4 Attributes)][Space(10)]_Layer4Color("Layer 4 Color", Color) = (1,1,1,0)
		_Layer4Smoothness("Layer 4 Smoothness", Range( 0 , 1)) = 1
		_Layer4AOIntensity("Layer 4 AO Intensity", Range( 0 , 1)) = 1
		_Layer4NormalIntensity("Layer 4 Normal Intensity", Range( -2 , 2)) = 0
		_Layer4BlendSharpness("Layer 4 Blend Sharpness", Range( 0 , 30)) = 3
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
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011
			#define ASE_USING_SAMPLING_MACROS 1


			

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

			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _LAYER1USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER2USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER3USEAOASHEIGHT_ON


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
			float4 _Layer1Color;
			float4 _Layer3MaskMap_ST;
			float4 _Layer4Color;
			float4 _Layer3Color;
			float4 _Layer4MaskMap_ST;
			float4 _Layer2MaskMap_ST;
			float4 _Layer1MaskMap_ST;
			float4 _Layer2Color;
			float _Layer3Smoothness;
			float _Layer1AOIntensity;
			float _Layer1NormalIntensity;
			float _Layer2Smoothness;
			float _Layer1Smoothness;
			float _Layer4NormalIntensity;
			float _Layer3NormalIntensity;
			float _Layer2NormalIntensity;
			float _Layer4Smoothness;
			float _Layer4BlendSharpness;
			float _Layer3BlendMidLevel;
			float _Layer3LowLevel;
			float _Layer3AOIntensity;
			float _Layer3BlendSharpness;
			float _Layer2HighLevel;
			float _Layer2LowLevel;
			float _Layer2BlendMidLevel;
			float _Layer2BlendSharpness;
			float _Layer1HighLevel;
			float _Layer1LowLevel;
			float _Layer1BlendMidLevel;
			float _Layer3HighLevel;
			float _Layer4AOIntensity;
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

			TEXTURE2D(_Layer1BaseColorMap);
			SAMPLER(sampler_Trilinear_Repeat_Aniso16);
			TEXTURE2D(_Layer2BaseColorMap);
			TEXTURE2D(_Layer1MaskMap);
			TEXTURE2D(_Layer3BaseColorMap);
			TEXTURE2D(_Layer2MaskMap);
			TEXTURE2D(_Layer4BaseColorMap);
			TEXTURE2D(_Layer3MaskMap);
			TEXTURE2D(_Layer1NormalMap);
			TEXTURE2D(_Layer2NormalMap);
			TEXTURE2D(_Layer3NormalMap);
			TEXTURE2D(_Layer4NormalMap);
			TEXTURE2D(_Layer4MaskMap);


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

				float2 texCoord62_g19 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g19 = SAMPLE_TEXTURE2D( _Layer1BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g19 );
				float3 temp_output_12_0_g21 = tex2DNode1_g19.rgb;
				float dotResult28_g21 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g21 );
				float3 temp_cast_1 = (dotResult28_g21).xxx;
				float temp_output_21_0_g21 = 1.0;
				float3 lerpResult31_g21 = lerp( temp_cast_1 , temp_output_12_0_g21 , temp_output_21_0_g21);
				float4 Layer1Color27 = ( CalculateContrast(1.0,float4( ( lerpResult31_g21 * 1.0 ) , 0.0 )) * _Layer1Color );
				float2 texCoord62_g234 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g234 = SAMPLE_TEXTURE2D( _Layer2BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g234 );
				float3 temp_output_12_0_g236 = tex2DNode1_g234.rgb;
				float dotResult28_g236 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g236 );
				float3 temp_cast_6 = (dotResult28_g236).xxx;
				float temp_output_21_0_g236 = 1.0;
				float3 lerpResult31_g236 = lerp( temp_cast_6 , temp_output_12_0_g236 , temp_output_21_0_g236);
				float4 Layer2Color58 = ( CalculateContrast(1.0,float4( ( lerpResult31_g236 * 1.0 ) , 0.0 )) * float4( _Layer2Color.rgb , 0.0 ) );
				float2 uv_Layer1MaskMap = input.ase_texcoord8.xy * _Layer1MaskMap_ST.xy + _Layer1MaskMap_ST.zw;
				float4 tex2DNode1_g22 = SAMPLE_TEXTURE2D( _Layer1MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer1MaskMap );
				#ifdef _LAYER1USEAOASHEIGHT_ON
				float staticSwitch45_g1 = ( 1.0 - (tex2DNode1_g22).g );
				#else
				float staticSwitch45_g1 = ( 1.0 - tex2DNode1_g22.b );
				#endif
				float Layer1BlendMap293 = (_Layer1LowLevel + (( staticSwitch45_g1 * _Layer1BlendMidLevel ) - 0.0) * (_Layer1HighLevel - _Layer1LowLevel) / (1.0 - 0.0));
				float VCRed18 = input.ase_color.r;
				float HeightMask10 = saturate(pow(max( (((Layer1BlendMap293*VCRed18)*4)+(VCRed18*2)), 0 ),_Layer2BlendSharpness));
				float Layer2Mask143 = saturate( HeightMask10 );
				float4 lerpResult5_g222 = lerp( Layer1Color27 , Layer2Color58 , Layer2Mask143);
				float2 texCoord62_g229 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g229 = SAMPLE_TEXTURE2D( _Layer3BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g229 );
				float3 temp_output_12_0_g231 = tex2DNode1_g229.rgb;
				float dotResult28_g231 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g231 );
				float3 temp_cast_11 = (dotResult28_g231).xxx;
				float temp_output_21_0_g231 = 1.0;
				float3 lerpResult31_g231 = lerp( temp_cast_11 , temp_output_12_0_g231 , temp_output_21_0_g231);
				float4 Layer3Color98 = ( CalculateContrast(1.0,float4( ( lerpResult31_g231 * 1.0 ) , 0.0 )) * float4( _Layer3Color.rgb , 0.0 ) );
				float2 uv_Layer2MaskMap = input.ase_texcoord8.xy * _Layer2MaskMap_ST.xy + _Layer2MaskMap_ST.zw;
				float4 tex2DNode1_g237 = SAMPLE_TEXTURE2D( _Layer2MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer2MaskMap );
				#ifdef _LAYER2USEAOASHEIGHT_ON
				float staticSwitch46_g233 = ( 1.0 - (tex2DNode1_g237).g );
				#else
				float staticSwitch46_g233 = ( 1.0 - tex2DNode1_g237.b );
				#endif
				float Layer2BlendMap299 = (_Layer2LowLevel + (( staticSwitch46_g233 * _Layer2BlendMidLevel ) - 0.0) * (_Layer2HighLevel - _Layer2LowLevel) / (1.0 - 0.0));
				float lerpResult302 = lerp( Layer1BlendMap293 , Layer2BlendMap299 , Layer2Mask143);
				float VCGreen19 = input.ase_color.g;
				float HeightMask126 = saturate(pow(max( (((lerpResult302*VCGreen19)*4)+(VCGreen19*2)), 0 ),_Layer3BlendSharpness));
				float Layer3Mask144 = saturate( HeightMask126 );
				float4 lerpResult1_g222 = lerp( lerpResult5_g222 , Layer3Color98 , Layer3Mask144);
				float2 texCoord62_g224 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g224 = SAMPLE_TEXTURE2D( _Layer4BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g224 );
				float3 temp_output_12_0_g226 = tex2DNode1_g224.rgb;
				float dotResult28_g226 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g226 );
				float3 temp_cast_16 = (dotResult28_g226).xxx;
				float temp_output_21_0_g226 = 1.0;
				float3 lerpResult31_g226 = lerp( temp_cast_16 , temp_output_12_0_g226 , temp_output_21_0_g226);
				float4 Layer4Color117 = ( CalculateContrast(1.0,float4( ( lerpResult31_g226 * 1.0 ) , 0.0 )) * float4( _Layer4Color.rgb , 0.0 ) );
				float2 uv_Layer3MaskMap = input.ase_texcoord8.xy * _Layer3MaskMap_ST.xy + _Layer3MaskMap_ST.zw;
				float4 tex2DNode1_g232 = SAMPLE_TEXTURE2D( _Layer3MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer3MaskMap );
				#ifdef _LAYER3USEAOASHEIGHT_ON
				float staticSwitch46_g228 = ( 1.0 - (tex2DNode1_g232).g );
				#else
				float staticSwitch46_g228 = ( 1.0 - tex2DNode1_g232.b );
				#endif
				float Layer3BlendMap300 = (_Layer3LowLevel + (( staticSwitch46_g228 * _Layer3BlendMidLevel ) - 0.0) * (_Layer3HighLevel - _Layer3LowLevel) / (1.0 - 0.0));
				float lerpResult304 = lerp( lerpResult302 , Layer3BlendMap300 , Layer3Mask144);
				float VCBlue20 = input.ase_color.b;
				float HeightMask134 = saturate(pow(max( (((lerpResult304*VCBlue20)*4)+(VCBlue20*2)), 0 ),_Layer4BlendSharpness));
				float Layer4Mask145 = saturate( HeightMask134 );
				float4 lerpResult2_g222 = lerp( lerpResult1_g222 , Layer4Color117 , Layer4Mask145);
				float4 FinalColorBlend141 = lerpResult2_g222;
				
				float3 unpack7_g19 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer1NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g19 ), _Layer1NormalIntensity );
				unpack7_g19.z = lerp( 1, unpack7_g19.z, saturate(_Layer1NormalIntensity) );
				float3 Layer1Normal28 = unpack7_g19;
				float3 unpack7_g234 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer2NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g234 ), _Layer2NormalIntensity );
				unpack7_g234.z = lerp( 1, unpack7_g234.z, saturate(_Layer2NormalIntensity) );
				float3 Layer2Normal56 = unpack7_g234;
				float3 lerpResult5_g219 = lerp( Layer1Normal28 , Layer2Normal56 , Layer2Mask143);
				float3 unpack7_g229 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer3NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g229 ), _Layer3NormalIntensity );
				unpack7_g229.z = lerp( 1, unpack7_g229.z, saturate(_Layer3NormalIntensity) );
				float3 Layer3Normal105 = unpack7_g229;
				float3 lerpResult1_g219 = lerp( lerpResult5_g219 , Layer3Normal105 , Layer3Mask144);
				float3 unpack7_g224 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer4NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g224 ), _Layer4NormalIntensity );
				unpack7_g224.z = lerp( 1, unpack7_g224.z, saturate(_Layer4NormalIntensity) );
				float3 Layer4Normal118 = unpack7_g224;
				float3 lerpResult2_g219 = lerp( lerpResult1_g219 , Layer4Normal118 , Layer4Mask145);
				float3 FinalNormalBlend161 = lerpResult2_g219;
				
				float Layer1Smoothness32 = ( tex2DNode1_g22.a * _Layer1Smoothness );
				float Layer2Smoothness53 = ( tex2DNode1_g237.a * _Layer2Smoothness );
				float lerpResult5_g221 = lerp( Layer1Smoothness32 , Layer2Smoothness53 , Layer2Mask143);
				float Layer3Smoothness100 = ( tex2DNode1_g232.a * _Layer3Smoothness );
				float lerpResult1_g221 = lerp( lerpResult5_g221 , Layer3Smoothness100 , Layer3Mask144);
				float2 uv_Layer4MaskMap = input.ase_texcoord8.xy * _Layer4MaskMap_ST.xy + _Layer4MaskMap_ST.zw;
				float4 tex2DNode1_g227 = SAMPLE_TEXTURE2D( _Layer4MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer4MaskMap );
				float Layer4Smoothness122 = ( tex2DNode1_g227.a * _Layer4Smoothness );
				float lerpResult2_g221 = lerp( lerpResult1_g221 , Layer4Smoothness122 , Layer4Mask145);
				float FinalSmoothnessBlend229 = lerpResult2_g221;
				
				float Layer1AO30 = saturate( ( tex2DNode1_g22.g - ( ( 1.0 - _Layer1AOIntensity ) * -1.0 ) ) );
				float Layer2AO49 = saturate( ( tex2DNode1_g237.g - ( ( 1.0 - _Layer1AOIntensity ) * -1.0 ) ) );
				float lerpResult5_g220 = lerp( Layer1AO30 , Layer2AO49 , Layer2Mask143);
				float Layer3AO103 = saturate( ( tex2DNode1_g232.g - ( ( 1.0 - _Layer3AOIntensity ) * -1.0 ) ) );
				float lerpResult1_g220 = lerp( lerpResult5_g220 , Layer3AO103 , Layer3Mask144);
				float Layer4AO120 = saturate( ( tex2DNode1_g227.g - ( ( 1.0 - _Layer4AOIntensity ) * -1.0 ) ) );
				float lerpResult2_g220 = lerp( lerpResult1_g220 , Layer4AO120 , Layer4Mask145);
				float FinalAOBlend177 = lerpResult2_g220;
				

				float3 BaseColor = FinalColorBlend141.rgb;
				float3 Normal = FinalNormalBlend161;
				float3 Emission = 0;
				float3 Specular = 0.5;
				float Metallic = 0;
				float Smoothness = FinalSmoothnessBlend229;
				float Occlusion = FinalAOBlend177;
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
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011
			#define ASE_USING_SAMPLING_MACROS 1


			

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
			float4 _Layer1Color;
			float4 _Layer3MaskMap_ST;
			float4 _Layer4Color;
			float4 _Layer3Color;
			float4 _Layer4MaskMap_ST;
			float4 _Layer2MaskMap_ST;
			float4 _Layer1MaskMap_ST;
			float4 _Layer2Color;
			float _Layer3Smoothness;
			float _Layer1AOIntensity;
			float _Layer1NormalIntensity;
			float _Layer2Smoothness;
			float _Layer1Smoothness;
			float _Layer4NormalIntensity;
			float _Layer3NormalIntensity;
			float _Layer2NormalIntensity;
			float _Layer4Smoothness;
			float _Layer4BlendSharpness;
			float _Layer3BlendMidLevel;
			float _Layer3LowLevel;
			float _Layer3AOIntensity;
			float _Layer3BlendSharpness;
			float _Layer2HighLevel;
			float _Layer2LowLevel;
			float _Layer2BlendMidLevel;
			float _Layer2BlendSharpness;
			float _Layer1HighLevel;
			float _Layer1LowLevel;
			float _Layer1BlendMidLevel;
			float _Layer3HighLevel;
			float _Layer4AOIntensity;
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
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011
			#define ASE_USING_SAMPLING_MACROS 1


			

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
			float4 _Layer1Color;
			float4 _Layer3MaskMap_ST;
			float4 _Layer4Color;
			float4 _Layer3Color;
			float4 _Layer4MaskMap_ST;
			float4 _Layer2MaskMap_ST;
			float4 _Layer1MaskMap_ST;
			float4 _Layer2Color;
			float _Layer3Smoothness;
			float _Layer1AOIntensity;
			float _Layer1NormalIntensity;
			float _Layer2Smoothness;
			float _Layer1Smoothness;
			float _Layer4NormalIntensity;
			float _Layer3NormalIntensity;
			float _Layer2NormalIntensity;
			float _Layer4Smoothness;
			float _Layer4BlendSharpness;
			float _Layer3BlendMidLevel;
			float _Layer3LowLevel;
			float _Layer3AOIntensity;
			float _Layer3BlendSharpness;
			float _Layer2HighLevel;
			float _Layer2LowLevel;
			float _Layer2BlendMidLevel;
			float _Layer2BlendSharpness;
			float _Layer1HighLevel;
			float _Layer1LowLevel;
			float _Layer1BlendMidLevel;
			float _Layer3HighLevel;
			float _Layer4AOIntensity;
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
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011
			#define ASE_USING_SAMPLING_MACROS 1

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

			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _LAYER1USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER2USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER3USEAOASHEIGHT_ON


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
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _Layer1Color;
			float4 _Layer3MaskMap_ST;
			float4 _Layer4Color;
			float4 _Layer3Color;
			float4 _Layer4MaskMap_ST;
			float4 _Layer2MaskMap_ST;
			float4 _Layer1MaskMap_ST;
			float4 _Layer2Color;
			float _Layer3Smoothness;
			float _Layer1AOIntensity;
			float _Layer1NormalIntensity;
			float _Layer2Smoothness;
			float _Layer1Smoothness;
			float _Layer4NormalIntensity;
			float _Layer3NormalIntensity;
			float _Layer2NormalIntensity;
			float _Layer4Smoothness;
			float _Layer4BlendSharpness;
			float _Layer3BlendMidLevel;
			float _Layer3LowLevel;
			float _Layer3AOIntensity;
			float _Layer3BlendSharpness;
			float _Layer2HighLevel;
			float _Layer2LowLevel;
			float _Layer2BlendMidLevel;
			float _Layer2BlendSharpness;
			float _Layer1HighLevel;
			float _Layer1LowLevel;
			float _Layer1BlendMidLevel;
			float _Layer3HighLevel;
			float _Layer4AOIntensity;
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

			TEXTURE2D(_Layer1BaseColorMap);
			SAMPLER(sampler_Trilinear_Repeat_Aniso16);
			TEXTURE2D(_Layer2BaseColorMap);
			TEXTURE2D(_Layer1MaskMap);
			TEXTURE2D(_Layer3BaseColorMap);
			TEXTURE2D(_Layer2MaskMap);
			TEXTURE2D(_Layer4BaseColorMap);
			TEXTURE2D(_Layer3MaskMap);


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

				output.ase_texcoord4.xy = input.texcoord0.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord4.zw = 0;

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

				float2 texCoord62_g19 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g19 = SAMPLE_TEXTURE2D( _Layer1BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g19 );
				float3 temp_output_12_0_g21 = tex2DNode1_g19.rgb;
				float dotResult28_g21 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g21 );
				float3 temp_cast_1 = (dotResult28_g21).xxx;
				float temp_output_21_0_g21 = 1.0;
				float3 lerpResult31_g21 = lerp( temp_cast_1 , temp_output_12_0_g21 , temp_output_21_0_g21);
				float4 Layer1Color27 = ( CalculateContrast(1.0,float4( ( lerpResult31_g21 * 1.0 ) , 0.0 )) * _Layer1Color );
				float2 texCoord62_g234 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g234 = SAMPLE_TEXTURE2D( _Layer2BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g234 );
				float3 temp_output_12_0_g236 = tex2DNode1_g234.rgb;
				float dotResult28_g236 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g236 );
				float3 temp_cast_6 = (dotResult28_g236).xxx;
				float temp_output_21_0_g236 = 1.0;
				float3 lerpResult31_g236 = lerp( temp_cast_6 , temp_output_12_0_g236 , temp_output_21_0_g236);
				float4 Layer2Color58 = ( CalculateContrast(1.0,float4( ( lerpResult31_g236 * 1.0 ) , 0.0 )) * float4( _Layer2Color.rgb , 0.0 ) );
				float2 uv_Layer1MaskMap = input.ase_texcoord4.xy * _Layer1MaskMap_ST.xy + _Layer1MaskMap_ST.zw;
				float4 tex2DNode1_g22 = SAMPLE_TEXTURE2D( _Layer1MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer1MaskMap );
				#ifdef _LAYER1USEAOASHEIGHT_ON
				float staticSwitch45_g1 = ( 1.0 - (tex2DNode1_g22).g );
				#else
				float staticSwitch45_g1 = ( 1.0 - tex2DNode1_g22.b );
				#endif
				float Layer1BlendMap293 = (_Layer1LowLevel + (( staticSwitch45_g1 * _Layer1BlendMidLevel ) - 0.0) * (_Layer1HighLevel - _Layer1LowLevel) / (1.0 - 0.0));
				float VCRed18 = input.ase_color.r;
				float HeightMask10 = saturate(pow(max( (((Layer1BlendMap293*VCRed18)*4)+(VCRed18*2)), 0 ),_Layer2BlendSharpness));
				float Layer2Mask143 = saturate( HeightMask10 );
				float4 lerpResult5_g222 = lerp( Layer1Color27 , Layer2Color58 , Layer2Mask143);
				float2 texCoord62_g229 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g229 = SAMPLE_TEXTURE2D( _Layer3BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g229 );
				float3 temp_output_12_0_g231 = tex2DNode1_g229.rgb;
				float dotResult28_g231 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g231 );
				float3 temp_cast_11 = (dotResult28_g231).xxx;
				float temp_output_21_0_g231 = 1.0;
				float3 lerpResult31_g231 = lerp( temp_cast_11 , temp_output_12_0_g231 , temp_output_21_0_g231);
				float4 Layer3Color98 = ( CalculateContrast(1.0,float4( ( lerpResult31_g231 * 1.0 ) , 0.0 )) * float4( _Layer3Color.rgb , 0.0 ) );
				float2 uv_Layer2MaskMap = input.ase_texcoord4.xy * _Layer2MaskMap_ST.xy + _Layer2MaskMap_ST.zw;
				float4 tex2DNode1_g237 = SAMPLE_TEXTURE2D( _Layer2MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer2MaskMap );
				#ifdef _LAYER2USEAOASHEIGHT_ON
				float staticSwitch46_g233 = ( 1.0 - (tex2DNode1_g237).g );
				#else
				float staticSwitch46_g233 = ( 1.0 - tex2DNode1_g237.b );
				#endif
				float Layer2BlendMap299 = (_Layer2LowLevel + (( staticSwitch46_g233 * _Layer2BlendMidLevel ) - 0.0) * (_Layer2HighLevel - _Layer2LowLevel) / (1.0 - 0.0));
				float lerpResult302 = lerp( Layer1BlendMap293 , Layer2BlendMap299 , Layer2Mask143);
				float VCGreen19 = input.ase_color.g;
				float HeightMask126 = saturate(pow(max( (((lerpResult302*VCGreen19)*4)+(VCGreen19*2)), 0 ),_Layer3BlendSharpness));
				float Layer3Mask144 = saturate( HeightMask126 );
				float4 lerpResult1_g222 = lerp( lerpResult5_g222 , Layer3Color98 , Layer3Mask144);
				float2 texCoord62_g224 = input.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g224 = SAMPLE_TEXTURE2D( _Layer4BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g224 );
				float3 temp_output_12_0_g226 = tex2DNode1_g224.rgb;
				float dotResult28_g226 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g226 );
				float3 temp_cast_16 = (dotResult28_g226).xxx;
				float temp_output_21_0_g226 = 1.0;
				float3 lerpResult31_g226 = lerp( temp_cast_16 , temp_output_12_0_g226 , temp_output_21_0_g226);
				float4 Layer4Color117 = ( CalculateContrast(1.0,float4( ( lerpResult31_g226 * 1.0 ) , 0.0 )) * float4( _Layer4Color.rgb , 0.0 ) );
				float2 uv_Layer3MaskMap = input.ase_texcoord4.xy * _Layer3MaskMap_ST.xy + _Layer3MaskMap_ST.zw;
				float4 tex2DNode1_g232 = SAMPLE_TEXTURE2D( _Layer3MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer3MaskMap );
				#ifdef _LAYER3USEAOASHEIGHT_ON
				float staticSwitch46_g228 = ( 1.0 - (tex2DNode1_g232).g );
				#else
				float staticSwitch46_g228 = ( 1.0 - tex2DNode1_g232.b );
				#endif
				float Layer3BlendMap300 = (_Layer3LowLevel + (( staticSwitch46_g228 * _Layer3BlendMidLevel ) - 0.0) * (_Layer3HighLevel - _Layer3LowLevel) / (1.0 - 0.0));
				float lerpResult304 = lerp( lerpResult302 , Layer3BlendMap300 , Layer3Mask144);
				float VCBlue20 = input.ase_color.b;
				float HeightMask134 = saturate(pow(max( (((lerpResult304*VCBlue20)*4)+(VCBlue20*2)), 0 ),_Layer4BlendSharpness));
				float Layer4Mask145 = saturate( HeightMask134 );
				float4 lerpResult2_g222 = lerp( lerpResult1_g222 , Layer4Color117 , Layer4Mask145);
				float4 FinalColorBlend141 = lerpResult2_g222;
				

				float3 BaseColor = FinalColorBlend141.rgb;
				float3 Emission = 0;
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
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011
			#define ASE_USING_SAMPLING_MACROS 1


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

			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _LAYER1USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER2USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER3USEAOASHEIGHT_ON


			struct Attributes
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
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
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _Layer1Color;
			float4 _Layer3MaskMap_ST;
			float4 _Layer4Color;
			float4 _Layer3Color;
			float4 _Layer4MaskMap_ST;
			float4 _Layer2MaskMap_ST;
			float4 _Layer1MaskMap_ST;
			float4 _Layer2Color;
			float _Layer3Smoothness;
			float _Layer1AOIntensity;
			float _Layer1NormalIntensity;
			float _Layer2Smoothness;
			float _Layer1Smoothness;
			float _Layer4NormalIntensity;
			float _Layer3NormalIntensity;
			float _Layer2NormalIntensity;
			float _Layer4Smoothness;
			float _Layer4BlendSharpness;
			float _Layer3BlendMidLevel;
			float _Layer3LowLevel;
			float _Layer3AOIntensity;
			float _Layer3BlendSharpness;
			float _Layer2HighLevel;
			float _Layer2LowLevel;
			float _Layer2BlendMidLevel;
			float _Layer2BlendSharpness;
			float _Layer1HighLevel;
			float _Layer1LowLevel;
			float _Layer1BlendMidLevel;
			float _Layer3HighLevel;
			float _Layer4AOIntensity;
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

			TEXTURE2D(_Layer1BaseColorMap);
			SAMPLER(sampler_Trilinear_Repeat_Aniso16);
			TEXTURE2D(_Layer2BaseColorMap);
			TEXTURE2D(_Layer1MaskMap);
			TEXTURE2D(_Layer3BaseColorMap);
			TEXTURE2D(_Layer2MaskMap);
			TEXTURE2D(_Layer4BaseColorMap);
			TEXTURE2D(_Layer3MaskMap);


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

				output.ase_texcoord2.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord2.zw = 0;

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

				float2 texCoord62_g19 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g19 = SAMPLE_TEXTURE2D( _Layer1BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g19 );
				float3 temp_output_12_0_g21 = tex2DNode1_g19.rgb;
				float dotResult28_g21 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g21 );
				float3 temp_cast_1 = (dotResult28_g21).xxx;
				float temp_output_21_0_g21 = 1.0;
				float3 lerpResult31_g21 = lerp( temp_cast_1 , temp_output_12_0_g21 , temp_output_21_0_g21);
				float4 Layer1Color27 = ( CalculateContrast(1.0,float4( ( lerpResult31_g21 * 1.0 ) , 0.0 )) * _Layer1Color );
				float2 texCoord62_g234 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g234 = SAMPLE_TEXTURE2D( _Layer2BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g234 );
				float3 temp_output_12_0_g236 = tex2DNode1_g234.rgb;
				float dotResult28_g236 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g236 );
				float3 temp_cast_6 = (dotResult28_g236).xxx;
				float temp_output_21_0_g236 = 1.0;
				float3 lerpResult31_g236 = lerp( temp_cast_6 , temp_output_12_0_g236 , temp_output_21_0_g236);
				float4 Layer2Color58 = ( CalculateContrast(1.0,float4( ( lerpResult31_g236 * 1.0 ) , 0.0 )) * float4( _Layer2Color.rgb , 0.0 ) );
				float2 uv_Layer1MaskMap = input.ase_texcoord2.xy * _Layer1MaskMap_ST.xy + _Layer1MaskMap_ST.zw;
				float4 tex2DNode1_g22 = SAMPLE_TEXTURE2D( _Layer1MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer1MaskMap );
				#ifdef _LAYER1USEAOASHEIGHT_ON
				float staticSwitch45_g1 = ( 1.0 - (tex2DNode1_g22).g );
				#else
				float staticSwitch45_g1 = ( 1.0 - tex2DNode1_g22.b );
				#endif
				float Layer1BlendMap293 = (_Layer1LowLevel + (( staticSwitch45_g1 * _Layer1BlendMidLevel ) - 0.0) * (_Layer1HighLevel - _Layer1LowLevel) / (1.0 - 0.0));
				float VCRed18 = input.ase_color.r;
				float HeightMask10 = saturate(pow(max( (((Layer1BlendMap293*VCRed18)*4)+(VCRed18*2)), 0 ),_Layer2BlendSharpness));
				float Layer2Mask143 = saturate( HeightMask10 );
				float4 lerpResult5_g222 = lerp( Layer1Color27 , Layer2Color58 , Layer2Mask143);
				float2 texCoord62_g229 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g229 = SAMPLE_TEXTURE2D( _Layer3BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g229 );
				float3 temp_output_12_0_g231 = tex2DNode1_g229.rgb;
				float dotResult28_g231 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g231 );
				float3 temp_cast_11 = (dotResult28_g231).xxx;
				float temp_output_21_0_g231 = 1.0;
				float3 lerpResult31_g231 = lerp( temp_cast_11 , temp_output_12_0_g231 , temp_output_21_0_g231);
				float4 Layer3Color98 = ( CalculateContrast(1.0,float4( ( lerpResult31_g231 * 1.0 ) , 0.0 )) * float4( _Layer3Color.rgb , 0.0 ) );
				float2 uv_Layer2MaskMap = input.ase_texcoord2.xy * _Layer2MaskMap_ST.xy + _Layer2MaskMap_ST.zw;
				float4 tex2DNode1_g237 = SAMPLE_TEXTURE2D( _Layer2MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer2MaskMap );
				#ifdef _LAYER2USEAOASHEIGHT_ON
				float staticSwitch46_g233 = ( 1.0 - (tex2DNode1_g237).g );
				#else
				float staticSwitch46_g233 = ( 1.0 - tex2DNode1_g237.b );
				#endif
				float Layer2BlendMap299 = (_Layer2LowLevel + (( staticSwitch46_g233 * _Layer2BlendMidLevel ) - 0.0) * (_Layer2HighLevel - _Layer2LowLevel) / (1.0 - 0.0));
				float lerpResult302 = lerp( Layer1BlendMap293 , Layer2BlendMap299 , Layer2Mask143);
				float VCGreen19 = input.ase_color.g;
				float HeightMask126 = saturate(pow(max( (((lerpResult302*VCGreen19)*4)+(VCGreen19*2)), 0 ),_Layer3BlendSharpness));
				float Layer3Mask144 = saturate( HeightMask126 );
				float4 lerpResult1_g222 = lerp( lerpResult5_g222 , Layer3Color98 , Layer3Mask144);
				float2 texCoord62_g224 = input.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g224 = SAMPLE_TEXTURE2D( _Layer4BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g224 );
				float3 temp_output_12_0_g226 = tex2DNode1_g224.rgb;
				float dotResult28_g226 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g226 );
				float3 temp_cast_16 = (dotResult28_g226).xxx;
				float temp_output_21_0_g226 = 1.0;
				float3 lerpResult31_g226 = lerp( temp_cast_16 , temp_output_12_0_g226 , temp_output_21_0_g226);
				float4 Layer4Color117 = ( CalculateContrast(1.0,float4( ( lerpResult31_g226 * 1.0 ) , 0.0 )) * float4( _Layer4Color.rgb , 0.0 ) );
				float2 uv_Layer3MaskMap = input.ase_texcoord2.xy * _Layer3MaskMap_ST.xy + _Layer3MaskMap_ST.zw;
				float4 tex2DNode1_g232 = SAMPLE_TEXTURE2D( _Layer3MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer3MaskMap );
				#ifdef _LAYER3USEAOASHEIGHT_ON
				float staticSwitch46_g228 = ( 1.0 - (tex2DNode1_g232).g );
				#else
				float staticSwitch46_g228 = ( 1.0 - tex2DNode1_g232.b );
				#endif
				float Layer3BlendMap300 = (_Layer3LowLevel + (( staticSwitch46_g228 * _Layer3BlendMidLevel ) - 0.0) * (_Layer3HighLevel - _Layer3LowLevel) / (1.0 - 0.0));
				float lerpResult304 = lerp( lerpResult302 , Layer3BlendMap300 , Layer3Mask144);
				float VCBlue20 = input.ase_color.b;
				float HeightMask134 = saturate(pow(max( (((lerpResult304*VCBlue20)*4)+(VCBlue20*2)), 0 ),_Layer4BlendSharpness));
				float Layer4Mask145 = saturate( HeightMask134 );
				float4 lerpResult2_g222 = lerp( lerpResult1_g222 , Layer4Color117 , Layer4Mask145);
				float4 FinalColorBlend141 = lerpResult2_g222;
				

				float3 BaseColor = FinalColorBlend141.rgb;
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
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011
			#define ASE_USING_SAMPLING_MACROS 1


			

			

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

			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _LAYER1USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER2USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER3USEAOASHEIGHT_ON


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
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _Layer1Color;
			float4 _Layer3MaskMap_ST;
			float4 _Layer4Color;
			float4 _Layer3Color;
			float4 _Layer4MaskMap_ST;
			float4 _Layer2MaskMap_ST;
			float4 _Layer1MaskMap_ST;
			float4 _Layer2Color;
			float _Layer3Smoothness;
			float _Layer1AOIntensity;
			float _Layer1NormalIntensity;
			float _Layer2Smoothness;
			float _Layer1Smoothness;
			float _Layer4NormalIntensity;
			float _Layer3NormalIntensity;
			float _Layer2NormalIntensity;
			float _Layer4Smoothness;
			float _Layer4BlendSharpness;
			float _Layer3BlendMidLevel;
			float _Layer3LowLevel;
			float _Layer3AOIntensity;
			float _Layer3BlendSharpness;
			float _Layer2HighLevel;
			float _Layer2LowLevel;
			float _Layer2BlendMidLevel;
			float _Layer2BlendSharpness;
			float _Layer1HighLevel;
			float _Layer1LowLevel;
			float _Layer1BlendMidLevel;
			float _Layer3HighLevel;
			float _Layer4AOIntensity;
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

			TEXTURE2D(_Layer1NormalMap);
			SAMPLER(sampler_Trilinear_Repeat_Aniso16);
			TEXTURE2D(_Layer2NormalMap);
			TEXTURE2D(_Layer1MaskMap);
			TEXTURE2D(_Layer3NormalMap);
			TEXTURE2D(_Layer2MaskMap);
			TEXTURE2D(_Layer4NormalMap);
			TEXTURE2D(_Layer3MaskMap);


			
			PackedVaryings VertexFunction( Attributes input  )
			{
				PackedVaryings output = (PackedVaryings)0;
				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_TRANSFER_INSTANCE_ID(input, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

				output.ase_texcoord5.xy = input.ase_texcoord.xy;
				output.ase_color = input.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				output.ase_texcoord5.zw = 0;
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

				float2 texCoord62_g19 = input.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack7_g19 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer1NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g19 ), _Layer1NormalIntensity );
				unpack7_g19.z = lerp( 1, unpack7_g19.z, saturate(_Layer1NormalIntensity) );
				float3 Layer1Normal28 = unpack7_g19;
				float2 texCoord62_g234 = input.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack7_g234 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer2NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g234 ), _Layer2NormalIntensity );
				unpack7_g234.z = lerp( 1, unpack7_g234.z, saturate(_Layer2NormalIntensity) );
				float3 Layer2Normal56 = unpack7_g234;
				float2 uv_Layer1MaskMap = input.ase_texcoord5.xy * _Layer1MaskMap_ST.xy + _Layer1MaskMap_ST.zw;
				float4 tex2DNode1_g22 = SAMPLE_TEXTURE2D( _Layer1MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer1MaskMap );
				#ifdef _LAYER1USEAOASHEIGHT_ON
				float staticSwitch45_g1 = ( 1.0 - (tex2DNode1_g22).g );
				#else
				float staticSwitch45_g1 = ( 1.0 - tex2DNode1_g22.b );
				#endif
				float Layer1BlendMap293 = (_Layer1LowLevel + (( staticSwitch45_g1 * _Layer1BlendMidLevel ) - 0.0) * (_Layer1HighLevel - _Layer1LowLevel) / (1.0 - 0.0));
				float VCRed18 = input.ase_color.r;
				float HeightMask10 = saturate(pow(max( (((Layer1BlendMap293*VCRed18)*4)+(VCRed18*2)), 0 ),_Layer2BlendSharpness));
				float Layer2Mask143 = saturate( HeightMask10 );
				float3 lerpResult5_g219 = lerp( Layer1Normal28 , Layer2Normal56 , Layer2Mask143);
				float2 texCoord62_g229 = input.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack7_g229 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer3NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g229 ), _Layer3NormalIntensity );
				unpack7_g229.z = lerp( 1, unpack7_g229.z, saturate(_Layer3NormalIntensity) );
				float3 Layer3Normal105 = unpack7_g229;
				float2 uv_Layer2MaskMap = input.ase_texcoord5.xy * _Layer2MaskMap_ST.xy + _Layer2MaskMap_ST.zw;
				float4 tex2DNode1_g237 = SAMPLE_TEXTURE2D( _Layer2MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer2MaskMap );
				#ifdef _LAYER2USEAOASHEIGHT_ON
				float staticSwitch46_g233 = ( 1.0 - (tex2DNode1_g237).g );
				#else
				float staticSwitch46_g233 = ( 1.0 - tex2DNode1_g237.b );
				#endif
				float Layer2BlendMap299 = (_Layer2LowLevel + (( staticSwitch46_g233 * _Layer2BlendMidLevel ) - 0.0) * (_Layer2HighLevel - _Layer2LowLevel) / (1.0 - 0.0));
				float lerpResult302 = lerp( Layer1BlendMap293 , Layer2BlendMap299 , Layer2Mask143);
				float VCGreen19 = input.ase_color.g;
				float HeightMask126 = saturate(pow(max( (((lerpResult302*VCGreen19)*4)+(VCGreen19*2)), 0 ),_Layer3BlendSharpness));
				float Layer3Mask144 = saturate( HeightMask126 );
				float3 lerpResult1_g219 = lerp( lerpResult5_g219 , Layer3Normal105 , Layer3Mask144);
				float2 texCoord62_g224 = input.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float3 unpack7_g224 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer4NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g224 ), _Layer4NormalIntensity );
				unpack7_g224.z = lerp( 1, unpack7_g224.z, saturate(_Layer4NormalIntensity) );
				float3 Layer4Normal118 = unpack7_g224;
				float2 uv_Layer3MaskMap = input.ase_texcoord5.xy * _Layer3MaskMap_ST.xy + _Layer3MaskMap_ST.zw;
				float4 tex2DNode1_g232 = SAMPLE_TEXTURE2D( _Layer3MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer3MaskMap );
				#ifdef _LAYER3USEAOASHEIGHT_ON
				float staticSwitch46_g228 = ( 1.0 - (tex2DNode1_g232).g );
				#else
				float staticSwitch46_g228 = ( 1.0 - tex2DNode1_g232.b );
				#endif
				float Layer3BlendMap300 = (_Layer3LowLevel + (( staticSwitch46_g228 * _Layer3BlendMidLevel ) - 0.0) * (_Layer3HighLevel - _Layer3LowLevel) / (1.0 - 0.0));
				float lerpResult304 = lerp( lerpResult302 , Layer3BlendMap300 , Layer3Mask144);
				float VCBlue20 = input.ase_color.b;
				float HeightMask134 = saturate(pow(max( (((lerpResult304*VCBlue20)*4)+(VCBlue20*2)), 0 ),_Layer4BlendSharpness));
				float Layer4Mask145 = saturate( HeightMask134 );
				float3 lerpResult2_g219 = lerp( lerpResult1_g219 , Layer4Normal118 , Layer4Mask145);
				float3 FinalNormalBlend161 = lerpResult2_g219;
				

				float3 Normal = FinalNormalBlend161;
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
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011
			#define ASE_USING_SAMPLING_MACROS 1


			

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

			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _LAYER1USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER2USEAOASHEIGHT_ON
			#pragma shader_feature_local _LAYER3USEAOASHEIGHT_ON


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
			float4 _Layer1Color;
			float4 _Layer3MaskMap_ST;
			float4 _Layer4Color;
			float4 _Layer3Color;
			float4 _Layer4MaskMap_ST;
			float4 _Layer2MaskMap_ST;
			float4 _Layer1MaskMap_ST;
			float4 _Layer2Color;
			float _Layer3Smoothness;
			float _Layer1AOIntensity;
			float _Layer1NormalIntensity;
			float _Layer2Smoothness;
			float _Layer1Smoothness;
			float _Layer4NormalIntensity;
			float _Layer3NormalIntensity;
			float _Layer2NormalIntensity;
			float _Layer4Smoothness;
			float _Layer4BlendSharpness;
			float _Layer3BlendMidLevel;
			float _Layer3LowLevel;
			float _Layer3AOIntensity;
			float _Layer3BlendSharpness;
			float _Layer2HighLevel;
			float _Layer2LowLevel;
			float _Layer2BlendMidLevel;
			float _Layer2BlendSharpness;
			float _Layer1HighLevel;
			float _Layer1LowLevel;
			float _Layer1BlendMidLevel;
			float _Layer3HighLevel;
			float _Layer4AOIntensity;
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

			TEXTURE2D(_Layer1BaseColorMap);
			SAMPLER(sampler_Trilinear_Repeat_Aniso16);
			TEXTURE2D(_Layer2BaseColorMap);
			TEXTURE2D(_Layer1MaskMap);
			TEXTURE2D(_Layer3BaseColorMap);
			TEXTURE2D(_Layer2MaskMap);
			TEXTURE2D(_Layer4BaseColorMap);
			TEXTURE2D(_Layer3MaskMap);
			TEXTURE2D(_Layer1NormalMap);
			TEXTURE2D(_Layer2NormalMap);
			TEXTURE2D(_Layer3NormalMap);
			TEXTURE2D(_Layer4NormalMap);
			TEXTURE2D(_Layer4MaskMap);


			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityGBuffer.hlsl"

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

				float2 texCoord62_g19 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g19 = SAMPLE_TEXTURE2D( _Layer1BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g19 );
				float3 temp_output_12_0_g21 = tex2DNode1_g19.rgb;
				float dotResult28_g21 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g21 );
				float3 temp_cast_1 = (dotResult28_g21).xxx;
				float temp_output_21_0_g21 = 1.0;
				float3 lerpResult31_g21 = lerp( temp_cast_1 , temp_output_12_0_g21 , temp_output_21_0_g21);
				float4 Layer1Color27 = ( CalculateContrast(1.0,float4( ( lerpResult31_g21 * 1.0 ) , 0.0 )) * _Layer1Color );
				float2 texCoord62_g234 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g234 = SAMPLE_TEXTURE2D( _Layer2BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g234 );
				float3 temp_output_12_0_g236 = tex2DNode1_g234.rgb;
				float dotResult28_g236 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g236 );
				float3 temp_cast_6 = (dotResult28_g236).xxx;
				float temp_output_21_0_g236 = 1.0;
				float3 lerpResult31_g236 = lerp( temp_cast_6 , temp_output_12_0_g236 , temp_output_21_0_g236);
				float4 Layer2Color58 = ( CalculateContrast(1.0,float4( ( lerpResult31_g236 * 1.0 ) , 0.0 )) * float4( _Layer2Color.rgb , 0.0 ) );
				float2 uv_Layer1MaskMap = input.ase_texcoord8.xy * _Layer1MaskMap_ST.xy + _Layer1MaskMap_ST.zw;
				float4 tex2DNode1_g22 = SAMPLE_TEXTURE2D( _Layer1MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer1MaskMap );
				#ifdef _LAYER1USEAOASHEIGHT_ON
				float staticSwitch45_g1 = ( 1.0 - (tex2DNode1_g22).g );
				#else
				float staticSwitch45_g1 = ( 1.0 - tex2DNode1_g22.b );
				#endif
				float Layer1BlendMap293 = (_Layer1LowLevel + (( staticSwitch45_g1 * _Layer1BlendMidLevel ) - 0.0) * (_Layer1HighLevel - _Layer1LowLevel) / (1.0 - 0.0));
				float VCRed18 = input.ase_color.r;
				float HeightMask10 = saturate(pow(max( (((Layer1BlendMap293*VCRed18)*4)+(VCRed18*2)), 0 ),_Layer2BlendSharpness));
				float Layer2Mask143 = saturate( HeightMask10 );
				float4 lerpResult5_g222 = lerp( Layer1Color27 , Layer2Color58 , Layer2Mask143);
				float2 texCoord62_g229 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g229 = SAMPLE_TEXTURE2D( _Layer3BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g229 );
				float3 temp_output_12_0_g231 = tex2DNode1_g229.rgb;
				float dotResult28_g231 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g231 );
				float3 temp_cast_11 = (dotResult28_g231).xxx;
				float temp_output_21_0_g231 = 1.0;
				float3 lerpResult31_g231 = lerp( temp_cast_11 , temp_output_12_0_g231 , temp_output_21_0_g231);
				float4 Layer3Color98 = ( CalculateContrast(1.0,float4( ( lerpResult31_g231 * 1.0 ) , 0.0 )) * float4( _Layer3Color.rgb , 0.0 ) );
				float2 uv_Layer2MaskMap = input.ase_texcoord8.xy * _Layer2MaskMap_ST.xy + _Layer2MaskMap_ST.zw;
				float4 tex2DNode1_g237 = SAMPLE_TEXTURE2D( _Layer2MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer2MaskMap );
				#ifdef _LAYER2USEAOASHEIGHT_ON
				float staticSwitch46_g233 = ( 1.0 - (tex2DNode1_g237).g );
				#else
				float staticSwitch46_g233 = ( 1.0 - tex2DNode1_g237.b );
				#endif
				float Layer2BlendMap299 = (_Layer2LowLevel + (( staticSwitch46_g233 * _Layer2BlendMidLevel ) - 0.0) * (_Layer2HighLevel - _Layer2LowLevel) / (1.0 - 0.0));
				float lerpResult302 = lerp( Layer1BlendMap293 , Layer2BlendMap299 , Layer2Mask143);
				float VCGreen19 = input.ase_color.g;
				float HeightMask126 = saturate(pow(max( (((lerpResult302*VCGreen19)*4)+(VCGreen19*2)), 0 ),_Layer3BlendSharpness));
				float Layer3Mask144 = saturate( HeightMask126 );
				float4 lerpResult1_g222 = lerp( lerpResult5_g222 , Layer3Color98 , Layer3Mask144);
				float2 texCoord62_g224 = input.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode1_g224 = SAMPLE_TEXTURE2D( _Layer4BaseColorMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g224 );
				float3 temp_output_12_0_g226 = tex2DNode1_g224.rgb;
				float dotResult28_g226 = dot( float3(0.2126729,0.7151522,0.072175) , temp_output_12_0_g226 );
				float3 temp_cast_16 = (dotResult28_g226).xxx;
				float temp_output_21_0_g226 = 1.0;
				float3 lerpResult31_g226 = lerp( temp_cast_16 , temp_output_12_0_g226 , temp_output_21_0_g226);
				float4 Layer4Color117 = ( CalculateContrast(1.0,float4( ( lerpResult31_g226 * 1.0 ) , 0.0 )) * float4( _Layer4Color.rgb , 0.0 ) );
				float2 uv_Layer3MaskMap = input.ase_texcoord8.xy * _Layer3MaskMap_ST.xy + _Layer3MaskMap_ST.zw;
				float4 tex2DNode1_g232 = SAMPLE_TEXTURE2D( _Layer3MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer3MaskMap );
				#ifdef _LAYER3USEAOASHEIGHT_ON
				float staticSwitch46_g228 = ( 1.0 - (tex2DNode1_g232).g );
				#else
				float staticSwitch46_g228 = ( 1.0 - tex2DNode1_g232.b );
				#endif
				float Layer3BlendMap300 = (_Layer3LowLevel + (( staticSwitch46_g228 * _Layer3BlendMidLevel ) - 0.0) * (_Layer3HighLevel - _Layer3LowLevel) / (1.0 - 0.0));
				float lerpResult304 = lerp( lerpResult302 , Layer3BlendMap300 , Layer3Mask144);
				float VCBlue20 = input.ase_color.b;
				float HeightMask134 = saturate(pow(max( (((lerpResult304*VCBlue20)*4)+(VCBlue20*2)), 0 ),_Layer4BlendSharpness));
				float Layer4Mask145 = saturate( HeightMask134 );
				float4 lerpResult2_g222 = lerp( lerpResult1_g222 , Layer4Color117 , Layer4Mask145);
				float4 FinalColorBlend141 = lerpResult2_g222;
				
				float3 unpack7_g19 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer1NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g19 ), _Layer1NormalIntensity );
				unpack7_g19.z = lerp( 1, unpack7_g19.z, saturate(_Layer1NormalIntensity) );
				float3 Layer1Normal28 = unpack7_g19;
				float3 unpack7_g234 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer2NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g234 ), _Layer2NormalIntensity );
				unpack7_g234.z = lerp( 1, unpack7_g234.z, saturate(_Layer2NormalIntensity) );
				float3 Layer2Normal56 = unpack7_g234;
				float3 lerpResult5_g219 = lerp( Layer1Normal28 , Layer2Normal56 , Layer2Mask143);
				float3 unpack7_g229 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer3NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g229 ), _Layer3NormalIntensity );
				unpack7_g229.z = lerp( 1, unpack7_g229.z, saturate(_Layer3NormalIntensity) );
				float3 Layer3Normal105 = unpack7_g229;
				float3 lerpResult1_g219 = lerp( lerpResult5_g219 , Layer3Normal105 , Layer3Mask144);
				float3 unpack7_g224 = UnpackNormalScale( SAMPLE_TEXTURE2D( _Layer4NormalMap, sampler_Trilinear_Repeat_Aniso16, texCoord62_g224 ), _Layer4NormalIntensity );
				unpack7_g224.z = lerp( 1, unpack7_g224.z, saturate(_Layer4NormalIntensity) );
				float3 Layer4Normal118 = unpack7_g224;
				float3 lerpResult2_g219 = lerp( lerpResult1_g219 , Layer4Normal118 , Layer4Mask145);
				float3 FinalNormalBlend161 = lerpResult2_g219;
				
				float Layer1Smoothness32 = ( tex2DNode1_g22.a * _Layer1Smoothness );
				float Layer2Smoothness53 = ( tex2DNode1_g237.a * _Layer2Smoothness );
				float lerpResult5_g221 = lerp( Layer1Smoothness32 , Layer2Smoothness53 , Layer2Mask143);
				float Layer3Smoothness100 = ( tex2DNode1_g232.a * _Layer3Smoothness );
				float lerpResult1_g221 = lerp( lerpResult5_g221 , Layer3Smoothness100 , Layer3Mask144);
				float2 uv_Layer4MaskMap = input.ase_texcoord8.xy * _Layer4MaskMap_ST.xy + _Layer4MaskMap_ST.zw;
				float4 tex2DNode1_g227 = SAMPLE_TEXTURE2D( _Layer4MaskMap, sampler_Trilinear_Repeat_Aniso16, uv_Layer4MaskMap );
				float Layer4Smoothness122 = ( tex2DNode1_g227.a * _Layer4Smoothness );
				float lerpResult2_g221 = lerp( lerpResult1_g221 , Layer4Smoothness122 , Layer4Mask145);
				float FinalSmoothnessBlend229 = lerpResult2_g221;
				
				float Layer1AO30 = saturate( ( tex2DNode1_g22.g - ( ( 1.0 - _Layer1AOIntensity ) * -1.0 ) ) );
				float Layer2AO49 = saturate( ( tex2DNode1_g237.g - ( ( 1.0 - _Layer1AOIntensity ) * -1.0 ) ) );
				float lerpResult5_g220 = lerp( Layer1AO30 , Layer2AO49 , Layer2Mask143);
				float Layer3AO103 = saturate( ( tex2DNode1_g232.g - ( ( 1.0 - _Layer3AOIntensity ) * -1.0 ) ) );
				float lerpResult1_g220 = lerp( lerpResult5_g220 , Layer3AO103 , Layer3Mask144);
				float Layer4AO120 = saturate( ( tex2DNode1_g227.g - ( ( 1.0 - _Layer4AOIntensity ) * -1.0 ) ) );
				float lerpResult2_g220 = lerp( lerpResult1_g220 , Layer4AO120 , Layer4Mask145);
				float FinalAOBlend177 = lerpResult2_g220;
				

				float3 BaseColor = FinalColorBlend141.rgb;
				float3 Normal = FinalNormalBlend161;
				float3 Emission = 0;
				float3 Specular = 0.5;
				float Metallic = 0;
				float Smoothness = FinalSmoothnessBlend229;
				float Occlusion = FinalAOBlend177;
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
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011
			#define ASE_USING_SAMPLING_MACROS 1


			

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
			float4 _Layer1Color;
			float4 _Layer3MaskMap_ST;
			float4 _Layer4Color;
			float4 _Layer3Color;
			float4 _Layer4MaskMap_ST;
			float4 _Layer2MaskMap_ST;
			float4 _Layer1MaskMap_ST;
			float4 _Layer2Color;
			float _Layer3Smoothness;
			float _Layer1AOIntensity;
			float _Layer1NormalIntensity;
			float _Layer2Smoothness;
			float _Layer1Smoothness;
			float _Layer4NormalIntensity;
			float _Layer3NormalIntensity;
			float _Layer2NormalIntensity;
			float _Layer4Smoothness;
			float _Layer4BlendSharpness;
			float _Layer3BlendMidLevel;
			float _Layer3LowLevel;
			float _Layer3AOIntensity;
			float _Layer3BlendSharpness;
			float _Layer2HighLevel;
			float _Layer2LowLevel;
			float _Layer2BlendMidLevel;
			float _Layer2BlendSharpness;
			float _Layer1HighLevel;
			float _Layer1LowLevel;
			float _Layer1BlendMidLevel;
			float _Layer3HighLevel;
			float _Layer4AOIntensity;
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
			#define _NORMALMAP 1
			#define ASE_VERSION 19801
			#define ASE_SRP_VERSION 140011
			#define ASE_USING_SAMPLING_MACROS 1


			

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
			float4 _Layer1Color;
			float4 _Layer3MaskMap_ST;
			float4 _Layer4Color;
			float4 _Layer3Color;
			float4 _Layer4MaskMap_ST;
			float4 _Layer2MaskMap_ST;
			float4 _Layer1MaskMap_ST;
			float4 _Layer2Color;
			float _Layer3Smoothness;
			float _Layer1AOIntensity;
			float _Layer1NormalIntensity;
			float _Layer2Smoothness;
			float _Layer1Smoothness;
			float _Layer4NormalIntensity;
			float _Layer3NormalIntensity;
			float _Layer2NormalIntensity;
			float _Layer4Smoothness;
			float _Layer4BlendSharpness;
			float _Layer3BlendMidLevel;
			float _Layer3LowLevel;
			float _Layer3AOIntensity;
			float _Layer3BlendSharpness;
			float _Layer2HighLevel;
			float _Layer2LowLevel;
			float _Layer2BlendMidLevel;
			float _Layer2BlendSharpness;
			float _Layer1HighLevel;
			float _Layer1LowLevel;
			float _Layer1BlendMidLevel;
			float _Layer3HighLevel;
			float _Layer4AOIntensity;
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
Node;AmplifyShaderEditor.CommentaryNode;216;-2667.201,-3532.647;Inherit;False;538.6532;411.3999;Comment;5;18;19;20;21;13;Vertex Colors;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;142;-2432,-2752;Inherit;False;776.5806;564.5394;Comment;8;141;65;66;132;133;147;148;149;Color Blend;0.135849,0.5675491,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;40;-3968,-3536;Inherit;False;1120.403;753.2085;Comment;7;251;32;30;29;28;27;293;Layer 1;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;41;-3968,-2720;Inherit;False;1127.168;711.5681;Comment;7;53;49;58;59;56;273;299;Layer 2;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;88;-3959.993,-1952;Inherit;False;1116.448;650.5231;Comment;7;100;103;104;105;98;281;300;Layer 3;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;107;-3959.763,-1248;Inherit;False;1105.367;617.3002;Comment;7;254;122;301;120;119;117;118;Layer 4;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;152;-1632,-2752;Inherit;False;828.7581;566.7303;Comment;8;154;159;160;161;153;162;155;158;Normal Blend;0.4980392,0.5764706,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;166;-784,-2752;Inherit;False;814.2734;566.3071;Comment;8;177;172;173;174;176;175;167;170;AO Blend;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;218;48,-2752;Inherit;False;903.2924;568.6662;Comment;8;229;225;226;228;227;219;224;222;Smoothness Blend;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;98;-3088,-1824;Inherit;False;Layer3Color;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;18;-2357.349,-3482.647;Inherit;False;VCRed;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;19;-2356.347,-3403.647;Inherit;False;VCGreen;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;20;-2354.347,-3321.647;Inherit;False;VCBlue;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;21;-2353.348,-3236.647;Inherit;False;VCAlpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;13;-2617.201,-3415.516;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;250;-3728,-3968;Inherit;False;SamplerState;-1;True;1;0;SAMPLERSTATE;;False;1;SAMPLERSTATE;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;27;-3088,-3376;Inherit;False;Layer1Color;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;28;-3088,-3296;Inherit;False;Layer1Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;29;-3088,-3216;Inherit;False;Layer1Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;30;-3088,-3136;Inherit;False;Layer1AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;251;-3904,-3376;Inherit;False;250;SamplerState;1;0;OBJECT;;False;1;SAMPLERSTATE;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;56;-3072,-2512;Inherit;False;Layer2Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;59;-3072,-2432;Inherit;False;Layer2Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;58;-3072,-2592;Inherit;False;Layer2Color;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;49;-3072,-2352;Inherit;False;Layer2AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;105;-3088,-1744;Inherit;False;Layer3Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;104;-3088,-1664;Inherit;False;Layer3Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;103;-3088,-1584;Inherit;False;Layer3AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;100;-3120,-1424;Inherit;False;Layer3Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;273;-3904,-2592;Inherit;False;250;SamplerState;1;0;OBJECT;;False;1;SAMPLERSTATE;0
Node;AmplifyShaderEditor.GetLocalVarNode;281;-3920,-1824;Inherit;False;250;SamplerState;1;0;OBJECT;;False;1;SAMPLERSTATE;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;32;-3120,-2976;Inherit;False;Layer1Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;53;-3104,-2192;Inherit;False;Layer2Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;299;-3072,-2272;Inherit;False;Layer2BlendMap;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;118;-3088,-1056;Inherit;False;Layer4Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;117;-3088,-1136;Inherit;False;Layer4Color;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;119;-3088,-976;Inherit;False;Layer4Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;120;-3088,-896;Inherit;False;Layer4AO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;301;-3088,-816;Inherit;False;Layer4BlendMap;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;122;-3120,-736;Inherit;False;Layer4Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;254;-3936,-1136;Inherit;False;250;SamplerState;1;0;OBJECT;;False;1;SAMPLERSTATE;0
Node;AmplifyShaderEditor.HeightMapBlendNode;126;-1520,-864;Inherit;False;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;127;-2096,-672;Inherit;False;19;VCGreen;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;128;-2192,-592;Inherit;False;Property;_Layer3BlendSharpness;Layer 3 Blend Sharpness;40;0;Create;True;0;0;0;False;0;False;1;25;0;50;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;62;-2096,-1152;Inherit;False;18;VCRed;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;15;-2160,-1072;Inherit;False;Property;_Layer2BlendSharpness;Layer 2 Blend Sharpness;26;0;Create;True;0;0;0;False;0;False;5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;181;-1280,-464;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;145;-1120,-464;Inherit;False;Layer4Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;304;-1744,-464;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;138;-2096,-240;Inherit;False;20;VCBlue;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;135;-2192,-160;Inherit;False;Property;_Layer4BlendSharpness;Layer 4 Blend Sharpness;54;0;Create;True;0;0;0;False;0;False;3;19.3;0;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;179;-1264,-1232;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.HeightMapBlendNode;10;-1520,-1232;Inherit;False;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;133;-2400,-2496;Inherit;False;117;Layer4Color;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;141;-1872,-2576;Inherit;False;FinalColorBlend;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;65;-2400,-2688;Inherit;False;27;Layer1Color;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;66;-2400,-2624;Inherit;False;58;Layer2Color;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;132;-2400,-2560;Inherit;False;98;Layer3Color;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;158;-1616,-2496;Inherit;False;118;Layer4Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;155;-1616,-2560;Inherit;False;105;Layer3Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;162;-1616,-2688;Inherit;False;28;Layer1Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;153;-1616,-2624;Inherit;False;56;Layer2Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;161;-1040,-2576;Inherit;False;FinalNormalBlend;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;160;-1584,-2272;Inherit;False;145;Layer4Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;159;-1584,-2336;Inherit;False;144;Layer3Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;154;-1584,-2400;Inherit;False;143;Layer2Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;176;-752,-2496;Inherit;False;120;Layer4AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;174;-752,-2560;Inherit;False;103;Layer3AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;173;-752,-2624;Inherit;False;49;Layer2AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;172;-752,-2688;Inherit;False;30;Layer1AO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;177;-192,-2544;Inherit;False;FinalAOBlend;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;170;-752,-2272;Inherit;False;145;Layer4Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;167;-752,-2400;Inherit;False;143;Layer2Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;175;-752,-2336;Inherit;False;144;Layer3Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;227;80,-2560;Inherit;False;100;Layer3Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;228;80,-2496;Inherit;False;122;Layer4Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;226;80,-2624;Inherit;False;53;Layer2Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;225;80,-2688;Inherit;False;32;Layer1Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;229;704,-2560;Inherit;False;FinalSmoothnessBlend;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;224;144,-2336;Inherit;False;144;Layer3Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;219;144,-2400;Inherit;False;143;Layer2Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;222;144,-2272;Inherit;False;145;Layer4Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;164;-256,-1152;Inherit;False;161;FinalNormalBlend;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;233;-288,-1072;Inherit;False;229;FinalSmoothnessBlend;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;178;-240,-976;Inherit;False;177;FinalAOBlend;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;150;-256,-1232;Inherit;False;141;FinalColorBlend;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;184;-2128,-832;Inherit;False;299;Layer2BlendMap;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;143;-1120,-1232;Inherit;False;Layer2Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;302;-1744,-864;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;300;-3088,-1504;Inherit;False;Layer3BlendMap;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;188;-2128,-432;Inherit;False;300;Layer3BlendMap;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.HeightMapBlendNode;134;-1536,-464;Inherit;False;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;192;-2096,-752;Inherit;False;143;Layer2Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;180;-1264,-880;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerStateNode;248;-3936,-3968;Inherit;False;0;0;0;2;-1;X16;1;0;SAMPLER2D;;False;1;SAMPLERSTATE;0
Node;AmplifyShaderEditor.GetLocalVarNode;148;-2400,-2336;Inherit;False;144;Layer3Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;149;-2400,-2272;Inherit;False;145;Layer4Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;147;-2400,-2400;Inherit;False;143;Layer2Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;144;-1120,-880;Inherit;False;Layer3Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;344;-1296,-2576;Inherit;False;FW_4LayerBlend;-1;;219;3a483134f3baab542a830c60e9c0c497;0;7;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;13;FLOAT3;0,0,0;False;10;FLOAT;0;False;12;FLOAT;0;False;14;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.FunctionNode;345;-448,-2544;Inherit;False;FW_4LayerBlend;-1;;220;3a483134f3baab542a830c60e9c0c497;0;7;7;FLOAT;0;False;8;FLOAT;0;False;11;FLOAT;0;False;13;FLOAT;0;False;10;FLOAT;0;False;12;FLOAT;0;False;14;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;346;448,-2560;Inherit;False;FW_4LayerBlend;-1;;221;3a483134f3baab542a830c60e9c0c497;0;7;7;FLOAT;0;False;8;FLOAT;0;False;11;FLOAT;0;False;13;FLOAT;0;False;10;FLOAT;0;False;12;FLOAT;0;False;14;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;347;-2128,-2576;Inherit;False;FW_4LayerBlend;-1;;222;3a483134f3baab542a830c60e9c0c497;0;7;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;11;COLOR;0,0,0,0;False;13;COLOR;0,0,0,0;False;10;FLOAT;0;False;12;FLOAT;0;False;14;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;348;-3664,-1136;Inherit;False;FW_VertexBlend_Layer4;41;;223;7ad328042df9a0f40bc6bdaa10c27df9;0;2;6;SAMPLERSTATE;0;False;9;SAMPLERSTATE;0;False;6;COLOR;0;FLOAT3;32;FLOAT;34;FLOAT;35;FLOAT;37;FLOAT;54
Node;AmplifyShaderEditor.FunctionNode;349;-3680,-1824;Inherit;False;FW_VertexBlend_Layer3;27;;228;4b88a1014d792634e80a39ee366e952c;0;2;6;SAMPLERSTATE;0;False;9;SAMPLERSTATE;0;False;6;COLOR;0;FLOAT3;32;FLOAT;34;FLOAT;35;FLOAT;37;FLOAT;50
Node;AmplifyShaderEditor.FunctionNode;350;-3664,-2592;Inherit;False;FW_VertexBlend_Layer2;13;;233;30b48f6f38724a14fab83cd90052a8b4;0;2;6;SAMPLERSTATE;0;False;9;SAMPLERSTATE;0;False;6;COLOR;0;FLOAT3;32;FLOAT;34;FLOAT;35;FLOAT;37;FLOAT;50
Node;AmplifyShaderEditor.GetLocalVarNode;294;-2128,-1232;Inherit;False;293;Layer1BlendMap;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;293;-3088,-3056;Inherit;False;Layer1BlendMap;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;352;-3680,-3376;Inherit;False;FW_VertexBlend_Layer1;0;;1;a698df54f0d481c40bcd024576d16391;0;2;6;SAMPLERSTATE;0;False;9;SAMPLERSTATE;0;False;6;COLOR;0;FLOAT3;32;FLOAT;34;FLOAT;35;FLOAT;37;FLOAT;46
Node;AmplifyShaderEditor.GetLocalVarNode;305;-2096,-336;Inherit;False;144;Layer3Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;238;176,-1136;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ExtraPrePass;0;0;ExtraPrePass;5;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;240;175.1501,-14.42413;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;241;175.1501,-14.42413;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;True;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;242;175.1501,-14.42413;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;243;175.1501,-14.42413;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;244;175.1501,-14.42413;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormals;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;245;175.1501,-14.42413;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;GBuffer;0;7;GBuffer;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalGBuffer;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;246;175.1501,-14.42413;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;SceneSelectionPass;0;8;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;247;175.1501,-14.42413;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ScenePickingPass;0;9;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;239;176,-1232;Float;False;True;-1;2;;0;12;TriForge/Four Layer Blend;94348b07e5e8bab40bd6c8a1e3df54cd;True;Forward;0;1;Forward;21;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;1;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalForward;False;False;0;;0;0;Standard;43;Lighting Model;0;0;Workflow;1;0;Surface;0;0;  Refraction Model;0;0;  Blend;0;0;Two Sided;1;0;Alpha Clipping;1;0;  Use Shadow Threshold;0;0;Fragment Normal Space,InvertActionOnDeselection;0;0;Forward Only;0;0;Transmission;0;0;  Transmission Shadow;0.5,False,;0;Translucency;0;0;  Translucency Strength;1,False,;0;  Normal Distortion;0.5,False,;0;  Scattering;2,False,;0;  Direct;0.9,False,;0;  Ambient;0.1,False,;0;  Shadow;0.5,False,;0;Cast Shadows;1;0;Receive Shadows;1;0;Receive SSAO;1;0;GPU Instancing;1;0;LOD CrossFade;1;0;Built-in Fog;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Write Depth;0;0;  Early Z;0;0;Vertex Position,InvertActionOnDeselection;1;0;Debug Display;0;0;Clear Coat;0;0;0;10;False;True;True;True;True;True;True;True;True;True;False;;True;0
WireConnection;98;0;349;0
WireConnection;18;0;13;1
WireConnection;19;0;13;2
WireConnection;20;0;13;3
WireConnection;21;0;13;4
WireConnection;250;0;248;0
WireConnection;27;0;352;0
WireConnection;28;0;352;32
WireConnection;29;0;352;34
WireConnection;30;0;352;37
WireConnection;56;0;350;32
WireConnection;59;0;350;34
WireConnection;58;0;350;0
WireConnection;49;0;350;37
WireConnection;105;0;349;32
WireConnection;104;0;349;34
WireConnection;103;0;349;37
WireConnection;100;0;349;35
WireConnection;32;0;352;35
WireConnection;53;0;350;35
WireConnection;299;0;350;50
WireConnection;118;0;348;32
WireConnection;117;0;348;0
WireConnection;119;0;348;34
WireConnection;120;0;348;37
WireConnection;301;0;348;54
WireConnection;122;0;348;35
WireConnection;126;0;302;0
WireConnection;126;1;127;0
WireConnection;126;2;128;0
WireConnection;181;0;134;0
WireConnection;145;0;181;0
WireConnection;304;0;302;0
WireConnection;304;1;188;0
WireConnection;304;2;305;0
WireConnection;179;0;10;0
WireConnection;10;0;294;0
WireConnection;10;1;62;0
WireConnection;10;2;15;0
WireConnection;141;0;347;0
WireConnection;161;0;344;0
WireConnection;177;0;345;0
WireConnection;229;0;346;0
WireConnection;143;0;179;0
WireConnection;302;0;294;0
WireConnection;302;1;184;0
WireConnection;302;2;192;0
WireConnection;300;0;349;50
WireConnection;134;0;304;0
WireConnection;134;1;138;0
WireConnection;134;2;135;0
WireConnection;180;0;126;0
WireConnection;144;0;180;0
WireConnection;344;7;162;0
WireConnection;344;8;153;0
WireConnection;344;11;155;0
WireConnection;344;13;158;0
WireConnection;344;10;154;0
WireConnection;344;12;159;0
WireConnection;344;14;160;0
WireConnection;345;7;172;0
WireConnection;345;8;173;0
WireConnection;345;11;174;0
WireConnection;345;13;176;0
WireConnection;345;10;167;0
WireConnection;345;12;175;0
WireConnection;345;14;170;0
WireConnection;346;7;225;0
WireConnection;346;8;226;0
WireConnection;346;11;227;0
WireConnection;346;13;228;0
WireConnection;346;10;219;0
WireConnection;346;12;224;0
WireConnection;346;14;222;0
WireConnection;347;7;65;0
WireConnection;347;8;66;0
WireConnection;347;11;132;0
WireConnection;347;13;133;0
WireConnection;347;10;147;0
WireConnection;347;12;148;0
WireConnection;347;14;149;0
WireConnection;348;6;254;0
WireConnection;348;9;254;0
WireConnection;349;6;281;0
WireConnection;349;9;281;0
WireConnection;350;6;273;0
WireConnection;350;9;273;0
WireConnection;293;0;352;46
WireConnection;352;6;251;0
WireConnection;352;9;251;0
WireConnection;239;0;150;0
WireConnection;239;1;164;0
WireConnection;239;4;233;0
WireConnection;239;5;178;0
ASEEND*/
//CHKSM=9D7247F2C59D3AD1FC154AE3E844017C919FDCE9