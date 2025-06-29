// Made with Amplify Shader Editor v1.9.1.3
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Polyart/Dreamscape/URP/Water River"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[ASEBegin][Header(Maps)][Header(.)][SingleLineTexture]_FlowMask("Flow Mask", 2D) = "white" {}
		[SingleLineTexture]_FoamMask("Foam Mask", 2D) = "white" {}
		[Normal][SingleLineTexture]_NormalMap("Normal Map", 2D) = "bump" {}
		[SingleLineTexture]_HeightMap("Height Map", 2D) = "white" {}
		_WaterFoamColor("Water Foam Color", Color) = (1,1,1,1)
		_WaterFoamColorIntensity("Water Foam Color Intensity", Float) = 1
		[Header(Color)]_ColorShallow("Color Shallow", Color) = (0.5990566,0.9091429,1,0)
		_ColorDeep("Color Deep", Color) = (0.1213065,0.347919,0.5471698,0)
		_ColorDepthFade("Color Depth Fade", Range( 0 , 100)) = 0
		[Header(Refraction)]_RefractionStrength("Refraction Strength", Range( 0 , 10)) = 1
		_RefractionDepth("Refraction Depth", Range( 0 , 100)) = 1
		[Header(Edge Foam)]_EdgeFoamSpeed("Edge Foam Speed", Vector) = (0,0,0,0)
		_EdgeFoamScale("Edge Foam Scale", Range( 0 , 10)) = 1
		_EdgeFoamDepthFade("Edge Foam Depth Fade", Range( 0 , 10)) = 0.19
		_EdgeFoamIntensity("Edge Foam Intensity", Range( 0 , 100)) = 1
		_EdgeFoamCutoff("Edge Foam Cutoff", Range( 0 , 5)) = 1
		[Header(Foam)]_FoamUVTiling("Foam UV Tiling", Vector) = (1,1,0,0)
		_FoamSpeed("Foam Speed", Vector) = (1,1,0,0)
		_FoamIntensity("Foam Intensity", Range( 0 , 100)) = 1
		_FoamPower("Foam Power", Range( 0 , 20)) = 1
		_FoamRandomizeUV("Foam Randomize UV", Range( 0 , 1)) = 0.26
		[Header(Flow)]_FlowUVTiling("Flow UV Tiling", Vector) = (1,1,0,0)
		_FlowSpeed("Flow Speed", Vector) = (0,-0.2,0,0)
		_FlowIntensity("Flow Intensity", Range( 0 , 100)) = 1
		_FlowPower("Flow Power", Range( 0 , 20)) = 1
		_FlowRandomizeUV("Flow Randomize UV", Range( 0 , 1)) = 0.26
		[Header(Normal)]_NormalUVTiling("Normal UV Tiling", Vector) = (1,1,0,0)
		_NormalSpeed("Normal Speed", Vector) = (0,-0.2,0,0)
		_NormalIntensity("Normal Intensity", Range( 0 , 1)) = 0.5
		_NormalRandomizeUV("Normal Randomize UV", Range( 0 , 1)) = 0.26
		[Header(Displacement)]_HeightUVTiling("Height UV Tiling", Vector) = (1,1,0,0)
		_HeightSpeed("Height Speed", Vector) = (1,1,0,0)
		_HeightIntensity("Height Intensity", Float) = 1
		_HeightPower("Height  Power", Float) = 1
		_HeightRandomizeUV("Height Randomize UV", Range( 0 , 1)) = 0.26
		_Metallic("Metallic", Range( 0 , 1)) = 0.2
		_Roughness("Roughness", Range( 0 , 1)) = 0.05
		[Toggle(_USESTEPFORFLOW_ON)] _useStepforFlow("use Step for Flow?", Float) = 0
		[ASEEnd]_Opacity("Opacity", Range( 0 , 1)) = 1


		[HideInInspector][ToggleOff] _SpecularHighlights("Specular Highlights", Float) = 1.0
		[HideInInspector][ToggleOff] _EnvironmentReflections("Environment Reflections", Float) = 1.0
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

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent" }

		Cull Back
		ZWrite On
		ZTest LEqual
		Offset 0 , 0
		AlphaToMask Off

		

		HLSLINCLUDE
		#pragma target 3.5
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

			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZWrite Off
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA

			

			HLSLPROGRAM

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma instancing_options renderinglayer
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 120108
			#define REQUIRE_DEPTH_TEXTURE 1
			#define REQUIRE_OPAQUE_TEXTURE 1


			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
			#pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
			#pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BLENDING
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BOX_PROJECTION
			#pragma multi_compile_fragment _ _SHADOWS_SOFT
			#pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
			#pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
			#pragma multi_compile_fragment _ _LIGHT_LAYERS
			#pragma multi_compile_fragment _ _LIGHT_COOKIES
			#pragma multi_compile _ _CLUSTERED_RENDERING
			#pragma shader_feature_local _RECEIVE_SHADOWS_OFF
			#pragma shader_feature_local_fragment _SPECULARHIGHLIGHTS_OFF
			#pragma shader_feature_local_fragment _ENVIRONMENTREFLECTIONS_OFF

			#pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
			#pragma multi_compile _ SHADOWS_SHADOWMASK
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON
			#pragma multi_compile _ DYNAMICLIGHTMAP_ON
			#pragma multi_compile_fragment _ DEBUG_DISPLAY

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS SHADERPASS_FORWARD

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DBuffer.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(UNITY_INSTANCING_ENABLED) && defined(_TERRAIN_INSTANCED_PERPIXEL_NORMAL)
				#define ENABLE_TERRAIN_PERPIXEL_NORMAL
			#endif

			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local _USESTEPFORFLOW_ON


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 lightmapUVOrVertexSH : TEXCOORD0;
				half4 fogFactorAndVertexLight : TEXCOORD1;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					float4 shadowCoord : TEXCOORD2;
				#endif
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
					float4 screenPos : TEXCOORD6;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON)
					float2 dynamicLightmapUV : TEXCOORD7;
				#endif
				float4 ase_texcoord8 : TEXCOORD8;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _ColorShallow;
			float4 _ColorDeep;
			float4 _WaterFoamColor;
			float2 _FlowSpeed;
			float2 _HeightSpeed;
			float2 _HeightUVTiling;
			float2 _FoamSpeed;
			float2 _FoamUVTiling;
			float2 _FlowUVTiling;
			float2 _NormalUVTiling;
			float2 _NormalSpeed;
			float2 _EdgeFoamSpeed;
			float _HeightIntensity;
			float _FoamPower;
			float _NormalIntensity;
			float _RefractionStrength;
			float _RefractionDepth;
			float _Metallic;
			float _NormalRandomizeUV;
			float _FoamRandomizeUV;
			float _FlowRandomizeUV;
			float _FlowPower;
			float _Roughness;
			float _FlowIntensity;
			float _EdgeFoamIntensity;
			float _EdgeFoamScale;
			float _EdgeFoamCutoff;
			float _EdgeFoamDepthFade;
			float _WaterFoamColorIntensity;
			float _ColorDepthFade;
			float _HeightPower;
			float _HeightRandomizeUV;
			float _FoamIntensity;
			float _Opacity;
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

			// Property used by ScenePickingPass
			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			// Properties used by SceneSelectionPass
			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D _HeightMap;
			uniform float4 _CameraDepthTexture_TexelSize;
			sampler2D _FlowMask;
			sampler2D _FoamMask;
			sampler2D _NormalMap;


			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/PBRForwardPass.hlsl"

			//#ifdef HAVE_VFX_MODIFICATION
			//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
			//#endif

			inline float noise_randomValue (float2 uv) { return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453); }
			inline float noise_interpolate (float a, float b, float t) { return (1.0-t)*a + (t*b); }
			inline float valueNoise (float2 uv)
			{
				float2 i = floor(uv);
				float2 f = frac( uv );
				f = f* f * (3.0 - 2.0 * f);
				uv = abs( frac(uv) - 0.5);
				float2 c0 = i + float2( 0.0, 0.0 );
				float2 c1 = i + float2( 1.0, 0.0 );
				float2 c2 = i + float2( 0.0, 1.0 );
				float2 c3 = i + float2( 1.0, 1.0 );
				float r0 = noise_randomValue( c0 );
				float r1 = noise_randomValue( c1 );
				float r2 = noise_randomValue( c2 );
				float r3 = noise_randomValue( c3 );
				float bottomOfGrid = noise_interpolate( r0, r1, f.x );
				float topOfGrid = noise_interpolate( r2, r3, f.x );
				float t = noise_interpolate( bottomOfGrid, topOfGrid, f.y );
				return t;
			}
			
			float SimpleNoise(float2 UV)
			{
				float t = 0.0;
				float freq = pow( 2.0, float( 0 ) );
				float amp = pow( 0.5, float( 3 - 0 ) );
				t += valueNoise( UV/freq )*amp;
				freq = pow(2.0, float(1));
				amp = pow(0.5, float(3-1));
				t += valueNoise( UV/freq )*amp;
				freq = pow(2.0, float(2));
				amp = pow(0.5, float(3-2));
				t += valueNoise( UV/freq )*amp;
				return t;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = v.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2Dlod( _HeightMap, float4( panner9_g69, 0, 0.0) ) + tex2Dlod( _HeightMap, float4( panner13_g69, 0, 0.0) ) ) + tex2Dlod( _HeightMap, float4( panner18_g69, 0, 0.0) ) ) * 0.25 ) , temp_cast_0 ) ) * float4( v.ase_normal , 0.0 ) );
				
				float3 objectToViewPos = TransformWorldToView(TransformObjectToWorld(v.vertex.xyz));
				float eyeDepth = -objectToViewPos.z;
				o.ase_texcoord8.z = eyeDepth;
				
				o.ase_texcoord8.xy = v.texcoord.xy;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord8.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = vDisplacement160.rgb;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif
				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float3 positionVS = TransformWorldToView( positionWS );
				float4 positionCS = TransformWorldToHClip( positionWS );

				VertexNormalInputs normalInput = GetVertexNormalInputs( v.ase_normal, v.ase_tangent );

				o.tSpace0 = float4( normalInput.normalWS, positionWS.x);
				o.tSpace1 = float4( normalInput.tangentWS, positionWS.y);
				o.tSpace2 = float4( normalInput.bitangentWS, positionWS.z);

				#if defined(LIGHTMAP_ON)
					OUTPUT_LIGHTMAP_UV( v.texcoord1, unity_LightmapST, o.lightmapUVOrVertexSH.xy );
				#endif

				#if !defined(LIGHTMAP_ON)
					OUTPUT_SH( normalInput.normalWS.xyz, o.lightmapUVOrVertexSH.xyz );
				#endif

				#if defined(DYNAMICLIGHTMAP_ON)
					o.dynamicLightmapUV.xy = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					o.lightmapUVOrVertexSH.zw = v.texcoord;
					o.lightmapUVOrVertexSH.xy = v.texcoord * unity_LightmapST.xy + unity_LightmapST.zw;
				#endif

				half3 vertexLight = VertexLighting( positionWS, normalInput.normalWS );

				#ifdef ASE_FOG
					half fogFactor = ComputeFogFactor( positionCS.z );
				#else
					half fogFactor = 0;
				#endif

				o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.clipPos = positionCS;

				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
					o.screenPos = ComputeScreenPos(positionCS);
				#endif

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_tangent = v.ase_tangent;
				o.texcoord = v.texcoord;
				o.texcoord1 = v.texcoord1;
				o.texcoord2 = v.texcoord2;
				
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
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
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				o.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif

			half4 frag ( VertexOutput IN
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float2 sampleCoords = (IN.lightmapUVOrVertexSH.zw / _TerrainHeightmapRecipSize.zw + 0.5f) * _TerrainHeightmapRecipSize.xy;
					float3 WorldNormal = TransformObjectToWorldNormal(normalize(SAMPLE_TEXTURE2D(_TerrainNormalmapTexture, sampler_TerrainNormalmapTexture, sampleCoords).rgb * 2 - 1));
					float3 WorldTangent = -cross(GetObjectToWorldMatrix()._13_23_33, WorldNormal);
					float3 WorldBiTangent = cross(WorldNormal, -WorldTangent);
				#else
					float3 WorldNormal = normalize( IN.tSpace0.xyz );
					float3 WorldTangent = IN.tSpace1.xyz;
					float3 WorldBiTangent = IN.tSpace2.xyz;
				#endif

				float3 WorldPosition = float3(IN.tSpace0.w,IN.tSpace1.w,IN.tSpace2.w);
				float3 WorldViewDirection = _WorldSpaceCameraPos.xyz  - WorldPosition;
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
					float4 ScreenPos = IN.screenPos;
				#endif

				float2 NormalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(IN.clipPos);

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					ShadowCoords = IN.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
				#endif

				WorldViewDirection = SafeNormalize( WorldViewDirection );

				float4 ase_screenPosNorm = ScreenPos / ScreenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float screenDepth65 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth65 = abs( ( screenDepth65 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _ColorDepthFade ) );
				float4 lerpResult69 = lerp( _ColorShallow , _ColorDeep , saturate( distanceDepth65 ));
				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = IN.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2D( _HeightMap, panner9_g69 ) + tex2D( _HeightMap, panner13_g69 ) ) + tex2D( _HeightMap, panner18_g69 ) ) * 0.25 ) , temp_cast_0 ) ) * float4( IN.ase_normal , 0.0 ) );
				float4 lerpResult72 = lerp( lerpResult69 , ( lerpResult69 + float4( 0.5,0.5,0.5,0 ) ) , vDisplacement160);
				float4 vColorWaves73 = lerpResult72;
				float4 vFoamColor169 = ( _WaterFoamColor * _WaterFoamColorIntensity );
				float screenDepth9_g53 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth9_g53 = abs( ( screenDepth9_g53 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeFoamDepthFade ) );
				float mulTime4_g53 = _TimeParameters.x * 0.1;
				float2 temp_cast_2 = (_EdgeFoamScale).xx;
				float2 texCoord2_g53 = IN.ase_texcoord8.xy * temp_cast_2 + float2( 0,0 );
				float2 panner6_g53 = ( mulTime4_g53 * _EdgeFoamSpeed + texCoord2_g53);
				float simpleNoise13_g53 = SimpleNoise( panner6_g53*50.0 );
				float temp_output_22_0_g53 = ( step( ( saturate( distanceDepth9_g53 ) * _EdgeFoamCutoff ) , simpleNoise13_g53 ) * _EdgeFoamIntensity );
				float vEdgeFoam167 = temp_output_22_0_g53;
				float temp_output_7_0_g65 = ( _FlowRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g64 = IN.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g64 = ( _TimeParameters.x * _FlowSpeed + ( _FlowUVTiling * texCoord5_g64 ));
				float2 temp_output_2_0_g65 = panner7_g64;
				float2 panner9_g65 = ( temp_output_7_0_g65 * float2( 0.1,0.1 ) + temp_output_2_0_g65);
				float2 panner13_g65 = ( temp_output_7_0_g65 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g65 + float2( 0.45,0.3 ) ));
				float2 panner18_g65 = ( temp_output_7_0_g65 * float2( -0.1,0.1 ) + ( temp_output_2_0_g65 + float2( 0.85,0.14 ) ));
				float4 temp_cast_3 = (_FlowPower).xxxx;
				float4 vFlow168 = ( _FlowIntensity * pow( ( ( ( tex2D( _FlowMask, panner9_g65 ) + tex2D( _FlowMask, panner13_g65 ) ) + tex2D( _FlowMask, panner18_g65 ) ) * 0.25 ) , temp_cast_3 ) );
				float4 temp_output_37_0 = ( vEdgeFoam167 + vFlow168 );
				float temp_output_7_0_g67 = ( _FoamRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g66 = IN.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g66 = ( _TimeParameters.x * _FoamSpeed + ( _FoamUVTiling * texCoord5_g66 ));
				float2 temp_output_2_0_g67 = panner7_g66;
				float2 panner9_g67 = ( temp_output_7_0_g67 * float2( 0.1,0.1 ) + temp_output_2_0_g67);
				float2 panner13_g67 = ( temp_output_7_0_g67 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g67 + float2( 0.45,0.3 ) ));
				float2 panner18_g67 = ( temp_output_7_0_g67 * float2( -0.1,0.1 ) + ( temp_output_2_0_g67 + float2( 0.85,0.14 ) ));
				float4 temp_cast_4 = (_FoamPower).xxxx;
				float4 temp_output_198_0 = ( _FoamIntensity * pow( ( ( ( tex2D( _FoamMask, panner9_g67 ) + tex2D( _FoamMask, panner13_g67 ) ) + tex2D( _FoamMask, panner18_g67 ) ) * 0.25 ) , temp_cast_4 ) );
				float4 vSurfaceFoam166 = temp_output_198_0;
				float4 lerpResult47 = lerp( temp_output_37_0 , float4( 0,0,0,0 ) , vSurfaceFoam166);
				#ifdef _USESTEPFORFLOW_ON
				float staticSwitch185 = ( (step( temp_output_37_0 , vSurfaceFoam166 )).r + vEdgeFoam167 );
				#else
				float staticSwitch185 = (lerpResult47).r;
				#endif
				float clampResult59 = clamp( staticSwitch185 , 0.0 , 1.0 );
				float4 vFoam175 = ( vFoamColor169 * clampResult59 );
				float4 temp_output_77_0 = ( vColorWaves73 + vFoam175 );
				float temp_output_7_0_g71 = ( _NormalRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g70 = IN.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g70 = ( _TimeParameters.x * _NormalSpeed + ( _NormalUVTiling * texCoord5_g70 ));
				float2 temp_output_2_0_g71 = panner7_g70;
				float2 panner9_g71 = ( temp_output_7_0_g71 * float2( 0.1,0.1 ) + temp_output_2_0_g71);
				float temp_output_24_0_g71 = _NormalIntensity;
				float3 unpack10_g71 = UnpackNormalScale( tex2D( _NormalMap, panner9_g71 ), temp_output_24_0_g71 );
				unpack10_g71.z = lerp( 1, unpack10_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner13_g71 = ( temp_output_7_0_g71 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g71 + float2( 0.45,0.3 ) ));
				float3 unpack14_g71 = UnpackNormalScale( tex2D( _NormalMap, panner13_g71 ), temp_output_24_0_g71 );
				unpack14_g71.z = lerp( 1, unpack14_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner18_g71 = ( temp_output_7_0_g71 * float2( -0.1,0.1 ) + ( temp_output_2_0_g71 + float2( 0.85,0.14 ) ));
				float3 unpack20_g71 = UnpackNormalScale( tex2D( _NormalMap, panner18_g71 ), temp_output_24_0_g71 );
				unpack20_g71.z = lerp( 1, unpack20_g71.z, saturate(temp_output_24_0_g71) );
				float3 vNormal154 = BlendNormal( BlendNormal( unpack10_g71 , unpack14_g71 ) , unpack20_g71 );
				float eyeDepth = IN.ase_texcoord8.z;
				float eyeDepth28_g72 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float2 temp_output_20_0_g72 = ( (vNormal154).xy * ( _RefractionStrength / max( eyeDepth , 0.1 ) ) * saturate( ( eyeDepth28_g72 - eyeDepth ) ) );
				float eyeDepth2_g72 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ( float4( temp_output_20_0_g72, 0.0 , 0.0 ) + ase_screenPosNorm ).xy ),_ZBufferParams);
				float2 temp_output_32_0_g72 = (( float4( ( temp_output_20_0_g72 * saturate( ( eyeDepth2_g72 - eyeDepth ) ) ), 0.0 , 0.0 ) + ase_screenPosNorm )).xy;
				float4 fetchOpaqueVal125 = float4( SHADERGRAPH_SAMPLE_SCENE_COLOR( temp_output_32_0_g72 ), 1.0 );
				float4 vRefraction126 = fetchOpaqueVal125;
				float4 blendOpSrc131 = temp_output_77_0;
				float4 blendOpDest131 = vRefraction126;
				float screenDepth129 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth129 = abs( ( screenDepth129 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _RefractionDepth ) );
				float4 lerpResult133 = lerp( ( saturate( (( blendOpDest131 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest131 ) * ( 1.0 - blendOpSrc131 ) ) : ( 2.0 * blendOpDest131 * blendOpSrc131 ) ) )) , temp_output_77_0 , saturate( distanceDepth129 ));
				float4 vFinalColor180 = lerpResult133;
				

				float3 BaseColor = vFinalColor180.rgb;
				float3 Normal = vNormal154;
				float3 Emission = 0;
				float3 Specular = 0.5;
				float Metallic = _Metallic;
				float Smoothness = ( 1.0 - _Roughness );
				float Occlusion = 1;
				float Alpha = _Opacity;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = 0;
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
					inputData.fogCoord = IN.fogFactorAndVertexLight.x;
				#endif
					inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float3 SH = SampleSH(inputData.normalWS.xyz);
				#else
					float3 SH = IN.lightmapUVOrVertexSH.xyz;
				#endif

				#if defined(DYNAMICLIGHTMAP_ON)
					inputData.bakedGI = SAMPLE_GI(IN.lightmapUVOrVertexSH.xy, IN.dynamicLightmapUV.xy, SH, inputData.normalWS);
				#else
					inputData.bakedGI = SAMPLE_GI(IN.lightmapUVOrVertexSH.xy, SH, inputData.normalWS);
				#endif

				#ifdef ASE_BAKEDGI
					inputData.bakedGI = BakedGI;
				#endif

				inputData.normalizedScreenSpaceUV = NormalizedScreenSpaceUV;
				inputData.shadowMask = SAMPLE_SHADOWMASK(IN.lightmapUVOrVertexSH.xy);

				#if defined(DEBUG_DISPLAY)
					#if defined(DYNAMICLIGHTMAP_ON)
						inputData.dynamicLightmapUV = IN.dynamicLightmapUV.xy;
					#endif
					#if defined(LIGHTMAP_ON)
						inputData.staticLightmapUV = IN.lightmapUVOrVertexSH.xy;
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
					ApplyDecalToSurfaceData(IN.clipPos, surfaceData, inputData);
				#endif

				half4 color = UniversalFragmentPBR( inputData, surfaceData);

				#ifdef ASE_TRANSMISSION
				{
					float shadow = _TransmissionShadow;

					Light mainLight = GetMainLight( inputData.shadowCoord );
					float3 mainAtten = mainLight.color * mainLight.distanceAttenuation;
					mainAtten = lerp( mainAtten, mainAtten * mainLight.shadowAttenuation, shadow );
					half3 mainTransmission = max(0 , -dot(inputData.normalWS, mainLight.direction)) * mainAtten * Transmission;
					color.rgb += BaseColor * mainTransmission;

					#ifdef _ADDITIONAL_LIGHTS
						int transPixelLightCount = GetAdditionalLightsCount();
						for (int i = 0; i < transPixelLightCount; ++i)
						{
							Light light = GetAdditionalLight(i, inputData.positionWS);
							float3 atten = light.color * light.distanceAttenuation;
							atten = lerp( atten, atten * light.shadowAttenuation, shadow );

							half3 transmission = max(0 , -dot(inputData.normalWS, light.direction)) * atten * Transmission;
							color.rgb += BaseColor * transmission;
						}
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

					Light mainLight = GetMainLight( inputData.shadowCoord );
					float3 mainAtten = mainLight.color * mainLight.distanceAttenuation;
					mainAtten = lerp( mainAtten, mainAtten * mainLight.shadowAttenuation, shadow );

					half3 mainLightDir = mainLight.direction + inputData.normalWS * normal;
					half mainVdotL = pow( saturate( dot( inputData.viewDirectionWS, -mainLightDir ) ), scattering );
					half3 mainTranslucency = mainAtten * ( mainVdotL * direct + inputData.bakedGI * ambient ) * Translucency;
					color.rgb += BaseColor * mainTranslucency * strength;

					#ifdef _ADDITIONAL_LIGHTS
						int transPixelLightCount = GetAdditionalLightsCount();
						for (int i = 0; i < transPixelLightCount; ++i)
						{
							Light light = GetAdditionalLight(i, inputData.positionWS);
							float3 atten = light.color * light.distanceAttenuation;
							atten = lerp( atten, atten * light.shadowAttenuation, shadow );

							half3 lightDir = light.direction + inputData.normalWS * normal;
							half VdotL = pow( saturate( dot( inputData.viewDirectionWS, -lightDir ) ), scattering );
							half3 translucency = atten * ( VdotL * direct + inputData.bakedGI * ambient ) * Translucency;
							color.rgb += BaseColor * translucency * strength;
						}
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
						color.rgb = MixFogColor(color.rgb, half3( 0, 0, 0 ), IN.fogFactorAndVertexLight.x );
					#else
						color.rgb = MixFog(color.rgb, IN.fogFactorAndVertexLight.x);
					#endif
				#endif

				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
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

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 120108


			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile_vertex _ _CASTING_PUNCTUAL_LIGHT_SHADOW

			#define SHADERPASS SHADERPASS_SHADOWCASTER

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_VERT_NORMAL


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD1;
				#endif
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _ColorShallow;
			float4 _ColorDeep;
			float4 _WaterFoamColor;
			float2 _FlowSpeed;
			float2 _HeightSpeed;
			float2 _HeightUVTiling;
			float2 _FoamSpeed;
			float2 _FoamUVTiling;
			float2 _FlowUVTiling;
			float2 _NormalUVTiling;
			float2 _NormalSpeed;
			float2 _EdgeFoamSpeed;
			float _HeightIntensity;
			float _FoamPower;
			float _NormalIntensity;
			float _RefractionStrength;
			float _RefractionDepth;
			float _Metallic;
			float _NormalRandomizeUV;
			float _FoamRandomizeUV;
			float _FlowRandomizeUV;
			float _FlowPower;
			float _Roughness;
			float _FlowIntensity;
			float _EdgeFoamIntensity;
			float _EdgeFoamScale;
			float _EdgeFoamCutoff;
			float _EdgeFoamDepthFade;
			float _WaterFoamColorIntensity;
			float _ColorDepthFade;
			float _HeightPower;
			float _HeightRandomizeUV;
			float _FoamIntensity;
			float _Opacity;
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

			// Property used by ScenePickingPass
			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			// Properties used by SceneSelectionPass
			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D _HeightMap;


			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShadowCasterPass.hlsl"

			//#ifdef HAVE_VFX_MODIFICATION
			//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
			//#endif

			
			float3 _LightDirection;
			float3 _LightPosition;

			VertexOutput VertexFunction( VertexInput v )
			{
				VertexOutput o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = v.ase_texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2Dlod( _HeightMap, float4( panner9_g69, 0, 0.0) ) + tex2Dlod( _HeightMap, float4( panner13_g69, 0, 0.0) ) ) + tex2Dlod( _HeightMap, float4( panner18_g69, 0, 0.0) ) ) * 0.25 ) , temp_cast_0 ) ) * float4( v.ase_normal , 0.0 ) );
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = vDisplacement160.rgb;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					o.worldPos = positionWS;
				#endif

				float3 normalWS = TransformObjectToWorldDir(v.ase_normal);

				#if _CASTING_PUNCTUAL_LIGHT_SHADOW
					float3 lightDirectionWS = normalize(_LightPosition - positionWS);
				#else
					float3 lightDirectionWS = _LightDirection;
				#endif

				float4 clipPos = TransformWorldToHClip(ApplyShadowBias(positionWS, normalWS, lightDirectionWS));

				#if UNITY_REVERSED_Z
					clipPos.z = min(clipPos.z, UNITY_NEAR_CLIP_VALUE);
				#else
					clipPos.z = max(clipPos.z, UNITY_NEAR_CLIP_VALUE);
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = clipPos;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.clipPos = clipPos;

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
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
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif

			half4 frag(	VertexOutput IN
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 WorldPosition = IN.worldPos;
				#endif

				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				

				float Alpha = _Opacity;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = 0;
				#endif

				#ifdef _ALPHATEST_ON
					#ifdef _ALPHATEST_SHADOW_ON
						clip(Alpha - AlphaClipThresholdShadow);
					#else
						clip(Alpha - AlphaClipThreshold);
					#endif
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
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
			ColorMask 0
			AlphaToMask Off

			HLSLPROGRAM

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 120108


			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS SHADERPASS_DEPTHONLY

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_VERT_NORMAL


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _ColorShallow;
			float4 _ColorDeep;
			float4 _WaterFoamColor;
			float2 _FlowSpeed;
			float2 _HeightSpeed;
			float2 _HeightUVTiling;
			float2 _FoamSpeed;
			float2 _FoamUVTiling;
			float2 _FlowUVTiling;
			float2 _NormalUVTiling;
			float2 _NormalSpeed;
			float2 _EdgeFoamSpeed;
			float _HeightIntensity;
			float _FoamPower;
			float _NormalIntensity;
			float _RefractionStrength;
			float _RefractionDepth;
			float _Metallic;
			float _NormalRandomizeUV;
			float _FoamRandomizeUV;
			float _FlowRandomizeUV;
			float _FlowPower;
			float _Roughness;
			float _FlowIntensity;
			float _EdgeFoamIntensity;
			float _EdgeFoamScale;
			float _EdgeFoamCutoff;
			float _EdgeFoamDepthFade;
			float _WaterFoamColorIntensity;
			float _ColorDepthFade;
			float _HeightPower;
			float _HeightRandomizeUV;
			float _FoamIntensity;
			float _Opacity;
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

			// Property used by ScenePickingPass
			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			// Properties used by SceneSelectionPass
			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D _HeightMap;


			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/DepthOnlyPass.hlsl"

			//#ifdef HAVE_VFX_MODIFICATION
			//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
			//#endif

			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = v.ase_texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2Dlod( _HeightMap, float4( panner9_g69, 0, 0.0) ) + tex2Dlod( _HeightMap, float4( panner13_g69, 0, 0.0) ) ) + tex2Dlod( _HeightMap, float4( panner18_g69, 0, 0.0) ) ) * 0.25 ) , temp_cast_0 ) ) * float4( v.ase_normal , 0.0 ) );
				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = vDisplacement160.rgb;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;
				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float4 positionCS = TransformWorldToHClip( positionWS );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					o.worldPos = positionWS;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.clipPos = positionCS;

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
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
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif

			half4 frag(	VertexOutput IN
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif

				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				

				float Alpha = _Opacity;
				float AlphaClipThreshold = 0.5;
				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = 0;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
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

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 120108
			#define REQUIRE_DEPTH_TEXTURE 1
			#define REQUIRE_OPAQUE_TEXTURE 1


			#pragma vertex vert
			#pragma fragment frag

			#pragma shader_feature EDITOR_VISUALIZATION

			#define SHADERPASS SHADERPASS_META

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local _USESTEPFORFLOW_ON


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 worldPos : TEXCOORD0;
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
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _ColorShallow;
			float4 _ColorDeep;
			float4 _WaterFoamColor;
			float2 _FlowSpeed;
			float2 _HeightSpeed;
			float2 _HeightUVTiling;
			float2 _FoamSpeed;
			float2 _FoamUVTiling;
			float2 _FlowUVTiling;
			float2 _NormalUVTiling;
			float2 _NormalSpeed;
			float2 _EdgeFoamSpeed;
			float _HeightIntensity;
			float _FoamPower;
			float _NormalIntensity;
			float _RefractionStrength;
			float _RefractionDepth;
			float _Metallic;
			float _NormalRandomizeUV;
			float _FoamRandomizeUV;
			float _FlowRandomizeUV;
			float _FlowPower;
			float _Roughness;
			float _FlowIntensity;
			float _EdgeFoamIntensity;
			float _EdgeFoamScale;
			float _EdgeFoamCutoff;
			float _EdgeFoamDepthFade;
			float _WaterFoamColorIntensity;
			float _ColorDepthFade;
			float _HeightPower;
			float _HeightRandomizeUV;
			float _FoamIntensity;
			float _Opacity;
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

			// Property used by ScenePickingPass
			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			// Properties used by SceneSelectionPass
			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D _HeightMap;
			uniform float4 _CameraDepthTexture_TexelSize;
			sampler2D _FlowMask;
			sampler2D _FoamMask;
			sampler2D _NormalMap;


			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/LightingMetaPass.hlsl"

			//#ifdef HAVE_VFX_MODIFICATION
			//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
			//#endif

			inline float noise_randomValue (float2 uv) { return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453); }
			inline float noise_interpolate (float a, float b, float t) { return (1.0-t)*a + (t*b); }
			inline float valueNoise (float2 uv)
			{
				float2 i = floor(uv);
				float2 f = frac( uv );
				f = f* f * (3.0 - 2.0 * f);
				uv = abs( frac(uv) - 0.5);
				float2 c0 = i + float2( 0.0, 0.0 );
				float2 c1 = i + float2( 1.0, 0.0 );
				float2 c2 = i + float2( 0.0, 1.0 );
				float2 c3 = i + float2( 1.0, 1.0 );
				float r0 = noise_randomValue( c0 );
				float r1 = noise_randomValue( c1 );
				float r2 = noise_randomValue( c2 );
				float r3 = noise_randomValue( c3 );
				float bottomOfGrid = noise_interpolate( r0, r1, f.x );
				float topOfGrid = noise_interpolate( r2, r3, f.x );
				float t = noise_interpolate( bottomOfGrid, topOfGrid, f.y );
				return t;
			}
			
			float SimpleNoise(float2 UV)
			{
				float t = 0.0;
				float freq = pow( 2.0, float( 0 ) );
				float amp = pow( 0.5, float( 3 - 0 ) );
				t += valueNoise( UV/freq )*amp;
				freq = pow(2.0, float(1));
				amp = pow(0.5, float(3-1));
				t += valueNoise( UV/freq )*amp;
				freq = pow(2.0, float(2));
				amp = pow(0.5, float(3-2));
				t += valueNoise( UV/freq )*amp;
				return t;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = v.texcoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2Dlod( _HeightMap, float4( panner9_g69, 0, 0.0) ) + tex2Dlod( _HeightMap, float4( panner13_g69, 0, 0.0) ) ) + tex2Dlod( _HeightMap, float4( panner18_g69, 0, 0.0) ) ) * 0.25 ) , temp_cast_0 ) ) * float4( v.ase_normal , 0.0 ) );
				
				float4 ase_clipPos = TransformObjectToHClip((v.vertex).xyz);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				o.ase_texcoord4 = screenPos;
				float3 objectToViewPos = TransformWorldToView(TransformObjectToWorld(v.vertex.xyz));
				float eyeDepth = -objectToViewPos.z;
				o.ase_texcoord5.z = eyeDepth;
				
				o.ase_texcoord5.xy = v.texcoord0.xy;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord5.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = vDisplacement160.rgb;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					o.worldPos = positionWS;
				#endif

				o.clipPos = MetaVertexPosition( v.vertex, v.texcoord1.xy, v.texcoord1.xy, unity_LightmapST, unity_DynamicLightmapST );

				#ifdef EDITOR_VISUALIZATION
					float2 VizUV = 0;
					float4 LightCoord = 0;
					UnityEditorVizData(v.vertex.xyz, v.texcoord0.xy, v.texcoord1.xy, v.texcoord2.xy, VizUV, LightCoord);
					o.VizUV = float4(VizUV, 0, 0);
					o.LightCoord = LightCoord;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = o.clipPos;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.texcoord0 = v.texcoord0;
				o.texcoord1 = v.texcoord1;
				o.texcoord2 = v.texcoord2;
				
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
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
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.texcoord0 = patch[0].texcoord0 * bary.x + patch[1].texcoord0 * bary.y + patch[2].texcoord0 * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN  ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 WorldPosition = IN.worldPos;
				#endif

				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float4 screenPos = IN.ase_texcoord4;
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float screenDepth65 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth65 = abs( ( screenDepth65 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _ColorDepthFade ) );
				float4 lerpResult69 = lerp( _ColorShallow , _ColorDeep , saturate( distanceDepth65 ));
				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = IN.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2D( _HeightMap, panner9_g69 ) + tex2D( _HeightMap, panner13_g69 ) ) + tex2D( _HeightMap, panner18_g69 ) ) * 0.25 ) , temp_cast_0 ) ) * float4( IN.ase_normal , 0.0 ) );
				float4 lerpResult72 = lerp( lerpResult69 , ( lerpResult69 + float4( 0.5,0.5,0.5,0 ) ) , vDisplacement160);
				float4 vColorWaves73 = lerpResult72;
				float4 vFoamColor169 = ( _WaterFoamColor * _WaterFoamColorIntensity );
				float screenDepth9_g53 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth9_g53 = abs( ( screenDepth9_g53 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeFoamDepthFade ) );
				float mulTime4_g53 = _TimeParameters.x * 0.1;
				float2 temp_cast_2 = (_EdgeFoamScale).xx;
				float2 texCoord2_g53 = IN.ase_texcoord5.xy * temp_cast_2 + float2( 0,0 );
				float2 panner6_g53 = ( mulTime4_g53 * _EdgeFoamSpeed + texCoord2_g53);
				float simpleNoise13_g53 = SimpleNoise( panner6_g53*50.0 );
				float temp_output_22_0_g53 = ( step( ( saturate( distanceDepth9_g53 ) * _EdgeFoamCutoff ) , simpleNoise13_g53 ) * _EdgeFoamIntensity );
				float vEdgeFoam167 = temp_output_22_0_g53;
				float temp_output_7_0_g65 = ( _FlowRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g64 = IN.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g64 = ( _TimeParameters.x * _FlowSpeed + ( _FlowUVTiling * texCoord5_g64 ));
				float2 temp_output_2_0_g65 = panner7_g64;
				float2 panner9_g65 = ( temp_output_7_0_g65 * float2( 0.1,0.1 ) + temp_output_2_0_g65);
				float2 panner13_g65 = ( temp_output_7_0_g65 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g65 + float2( 0.45,0.3 ) ));
				float2 panner18_g65 = ( temp_output_7_0_g65 * float2( -0.1,0.1 ) + ( temp_output_2_0_g65 + float2( 0.85,0.14 ) ));
				float4 temp_cast_3 = (_FlowPower).xxxx;
				float4 vFlow168 = ( _FlowIntensity * pow( ( ( ( tex2D( _FlowMask, panner9_g65 ) + tex2D( _FlowMask, panner13_g65 ) ) + tex2D( _FlowMask, panner18_g65 ) ) * 0.25 ) , temp_cast_3 ) );
				float4 temp_output_37_0 = ( vEdgeFoam167 + vFlow168 );
				float temp_output_7_0_g67 = ( _FoamRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g66 = IN.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g66 = ( _TimeParameters.x * _FoamSpeed + ( _FoamUVTiling * texCoord5_g66 ));
				float2 temp_output_2_0_g67 = panner7_g66;
				float2 panner9_g67 = ( temp_output_7_0_g67 * float2( 0.1,0.1 ) + temp_output_2_0_g67);
				float2 panner13_g67 = ( temp_output_7_0_g67 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g67 + float2( 0.45,0.3 ) ));
				float2 panner18_g67 = ( temp_output_7_0_g67 * float2( -0.1,0.1 ) + ( temp_output_2_0_g67 + float2( 0.85,0.14 ) ));
				float4 temp_cast_4 = (_FoamPower).xxxx;
				float4 temp_output_198_0 = ( _FoamIntensity * pow( ( ( ( tex2D( _FoamMask, panner9_g67 ) + tex2D( _FoamMask, panner13_g67 ) ) + tex2D( _FoamMask, panner18_g67 ) ) * 0.25 ) , temp_cast_4 ) );
				float4 vSurfaceFoam166 = temp_output_198_0;
				float4 lerpResult47 = lerp( temp_output_37_0 , float4( 0,0,0,0 ) , vSurfaceFoam166);
				#ifdef _USESTEPFORFLOW_ON
				float staticSwitch185 = ( (step( temp_output_37_0 , vSurfaceFoam166 )).r + vEdgeFoam167 );
				#else
				float staticSwitch185 = (lerpResult47).r;
				#endif
				float clampResult59 = clamp( staticSwitch185 , 0.0 , 1.0 );
				float4 vFoam175 = ( vFoamColor169 * clampResult59 );
				float4 temp_output_77_0 = ( vColorWaves73 + vFoam175 );
				float temp_output_7_0_g71 = ( _NormalRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g70 = IN.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g70 = ( _TimeParameters.x * _NormalSpeed + ( _NormalUVTiling * texCoord5_g70 ));
				float2 temp_output_2_0_g71 = panner7_g70;
				float2 panner9_g71 = ( temp_output_7_0_g71 * float2( 0.1,0.1 ) + temp_output_2_0_g71);
				float temp_output_24_0_g71 = _NormalIntensity;
				float3 unpack10_g71 = UnpackNormalScale( tex2D( _NormalMap, panner9_g71 ), temp_output_24_0_g71 );
				unpack10_g71.z = lerp( 1, unpack10_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner13_g71 = ( temp_output_7_0_g71 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g71 + float2( 0.45,0.3 ) ));
				float3 unpack14_g71 = UnpackNormalScale( tex2D( _NormalMap, panner13_g71 ), temp_output_24_0_g71 );
				unpack14_g71.z = lerp( 1, unpack14_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner18_g71 = ( temp_output_7_0_g71 * float2( -0.1,0.1 ) + ( temp_output_2_0_g71 + float2( 0.85,0.14 ) ));
				float3 unpack20_g71 = UnpackNormalScale( tex2D( _NormalMap, panner18_g71 ), temp_output_24_0_g71 );
				unpack20_g71.z = lerp( 1, unpack20_g71.z, saturate(temp_output_24_0_g71) );
				float3 vNormal154 = BlendNormal( BlendNormal( unpack10_g71 , unpack14_g71 ) , unpack20_g71 );
				float eyeDepth = IN.ase_texcoord5.z;
				float eyeDepth28_g72 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float2 temp_output_20_0_g72 = ( (vNormal154).xy * ( _RefractionStrength / max( eyeDepth , 0.1 ) ) * saturate( ( eyeDepth28_g72 - eyeDepth ) ) );
				float eyeDepth2_g72 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ( float4( temp_output_20_0_g72, 0.0 , 0.0 ) + ase_screenPosNorm ).xy ),_ZBufferParams);
				float2 temp_output_32_0_g72 = (( float4( ( temp_output_20_0_g72 * saturate( ( eyeDepth2_g72 - eyeDepth ) ) ), 0.0 , 0.0 ) + ase_screenPosNorm )).xy;
				float4 fetchOpaqueVal125 = float4( SHADERGRAPH_SAMPLE_SCENE_COLOR( temp_output_32_0_g72 ), 1.0 );
				float4 vRefraction126 = fetchOpaqueVal125;
				float4 blendOpSrc131 = temp_output_77_0;
				float4 blendOpDest131 = vRefraction126;
				float screenDepth129 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth129 = abs( ( screenDepth129 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _RefractionDepth ) );
				float4 lerpResult133 = lerp( ( saturate( (( blendOpDest131 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest131 ) * ( 1.0 - blendOpSrc131 ) ) : ( 2.0 * blendOpDest131 * blendOpSrc131 ) ) )) , temp_output_77_0 , saturate( distanceDepth129 ));
				float4 vFinalColor180 = lerpResult133;
				

				float3 BaseColor = vFinalColor180.rgb;
				float3 Emission = 0;
				float Alpha = _Opacity;
				float AlphaClipThreshold = 0.5;

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				MetaInput metaInput = (MetaInput)0;
				metaInput.Albedo = BaseColor;
				metaInput.Emission = Emission;
				#ifdef EDITOR_VISUALIZATION
					metaInput.VizUV = IN.VizUV.xy;
					metaInput.LightCoord = IN.LightCoord;
				#endif

				return UnityMetaFragment(metaInput);
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "Universal2D"
			Tags { "LightMode"="Universal2D" }

			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZWrite Off
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA

			HLSLPROGRAM

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 120108
			#define REQUIRE_DEPTH_TEXTURE 1
			#define REQUIRE_OPAQUE_TEXTURE 1


			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS SHADERPASS_2D

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local _USESTEPFORFLOW_ON


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _ColorShallow;
			float4 _ColorDeep;
			float4 _WaterFoamColor;
			float2 _FlowSpeed;
			float2 _HeightSpeed;
			float2 _HeightUVTiling;
			float2 _FoamSpeed;
			float2 _FoamUVTiling;
			float2 _FlowUVTiling;
			float2 _NormalUVTiling;
			float2 _NormalSpeed;
			float2 _EdgeFoamSpeed;
			float _HeightIntensity;
			float _FoamPower;
			float _NormalIntensity;
			float _RefractionStrength;
			float _RefractionDepth;
			float _Metallic;
			float _NormalRandomizeUV;
			float _FoamRandomizeUV;
			float _FlowRandomizeUV;
			float _FlowPower;
			float _Roughness;
			float _FlowIntensity;
			float _EdgeFoamIntensity;
			float _EdgeFoamScale;
			float _EdgeFoamCutoff;
			float _EdgeFoamDepthFade;
			float _WaterFoamColorIntensity;
			float _ColorDepthFade;
			float _HeightPower;
			float _HeightRandomizeUV;
			float _FoamIntensity;
			float _Opacity;
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

			// Property used by ScenePickingPass
			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			// Properties used by SceneSelectionPass
			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D _HeightMap;
			uniform float4 _CameraDepthTexture_TexelSize;
			sampler2D _FlowMask;
			sampler2D _FoamMask;
			sampler2D _NormalMap;


			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/PBR2DPass.hlsl"

			//#ifdef HAVE_VFX_MODIFICATION
			//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
			//#endif

			inline float noise_randomValue (float2 uv) { return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453); }
			inline float noise_interpolate (float a, float b, float t) { return (1.0-t)*a + (t*b); }
			inline float valueNoise (float2 uv)
			{
				float2 i = floor(uv);
				float2 f = frac( uv );
				f = f* f * (3.0 - 2.0 * f);
				uv = abs( frac(uv) - 0.5);
				float2 c0 = i + float2( 0.0, 0.0 );
				float2 c1 = i + float2( 1.0, 0.0 );
				float2 c2 = i + float2( 0.0, 1.0 );
				float2 c3 = i + float2( 1.0, 1.0 );
				float r0 = noise_randomValue( c0 );
				float r1 = noise_randomValue( c1 );
				float r2 = noise_randomValue( c2 );
				float r3 = noise_randomValue( c3 );
				float bottomOfGrid = noise_interpolate( r0, r1, f.x );
				float topOfGrid = noise_interpolate( r2, r3, f.x );
				float t = noise_interpolate( bottomOfGrid, topOfGrid, f.y );
				return t;
			}
			
			float SimpleNoise(float2 UV)
			{
				float t = 0.0;
				float freq = pow( 2.0, float( 0 ) );
				float amp = pow( 0.5, float( 3 - 0 ) );
				t += valueNoise( UV/freq )*amp;
				freq = pow(2.0, float(1));
				amp = pow(0.5, float(3-1));
				t += valueNoise( UV/freq )*amp;
				freq = pow(2.0, float(2));
				amp = pow(0.5, float(3-2));
				t += valueNoise( UV/freq )*amp;
				return t;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = v.ase_texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2Dlod( _HeightMap, float4( panner9_g69, 0, 0.0) ) + tex2Dlod( _HeightMap, float4( panner13_g69, 0, 0.0) ) ) + tex2Dlod( _HeightMap, float4( panner18_g69, 0, 0.0) ) ) * 0.25 ) , temp_cast_0 ) ) * float4( v.ase_normal , 0.0 ) );
				
				float4 ase_clipPos = TransformObjectToHClip((v.vertex).xyz);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				o.ase_texcoord2 = screenPos;
				float3 objectToViewPos = TransformWorldToView(TransformObjectToWorld(v.vertex.xyz));
				float eyeDepth = -objectToViewPos.z;
				o.ase_texcoord3.z = eyeDepth;
				
				o.ase_texcoord3.xy = v.ase_texcoord.xy;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord3.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = vDisplacement160.rgb;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float4 positionCS = TransformWorldToHClip( positionWS );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					o.worldPos = positionWS;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.clipPos = positionCS;

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
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
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN  ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 WorldPosition = IN.worldPos;
				#endif

				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float4 screenPos = IN.ase_texcoord2;
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float screenDepth65 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth65 = abs( ( screenDepth65 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _ColorDepthFade ) );
				float4 lerpResult69 = lerp( _ColorShallow , _ColorDeep , saturate( distanceDepth65 ));
				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = IN.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2D( _HeightMap, panner9_g69 ) + tex2D( _HeightMap, panner13_g69 ) ) + tex2D( _HeightMap, panner18_g69 ) ) * 0.25 ) , temp_cast_0 ) ) * float4( IN.ase_normal , 0.0 ) );
				float4 lerpResult72 = lerp( lerpResult69 , ( lerpResult69 + float4( 0.5,0.5,0.5,0 ) ) , vDisplacement160);
				float4 vColorWaves73 = lerpResult72;
				float4 vFoamColor169 = ( _WaterFoamColor * _WaterFoamColorIntensity );
				float screenDepth9_g53 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth9_g53 = abs( ( screenDepth9_g53 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeFoamDepthFade ) );
				float mulTime4_g53 = _TimeParameters.x * 0.1;
				float2 temp_cast_2 = (_EdgeFoamScale).xx;
				float2 texCoord2_g53 = IN.ase_texcoord3.xy * temp_cast_2 + float2( 0,0 );
				float2 panner6_g53 = ( mulTime4_g53 * _EdgeFoamSpeed + texCoord2_g53);
				float simpleNoise13_g53 = SimpleNoise( panner6_g53*50.0 );
				float temp_output_22_0_g53 = ( step( ( saturate( distanceDepth9_g53 ) * _EdgeFoamCutoff ) , simpleNoise13_g53 ) * _EdgeFoamIntensity );
				float vEdgeFoam167 = temp_output_22_0_g53;
				float temp_output_7_0_g65 = ( _FlowRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g64 = IN.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g64 = ( _TimeParameters.x * _FlowSpeed + ( _FlowUVTiling * texCoord5_g64 ));
				float2 temp_output_2_0_g65 = panner7_g64;
				float2 panner9_g65 = ( temp_output_7_0_g65 * float2( 0.1,0.1 ) + temp_output_2_0_g65);
				float2 panner13_g65 = ( temp_output_7_0_g65 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g65 + float2( 0.45,0.3 ) ));
				float2 panner18_g65 = ( temp_output_7_0_g65 * float2( -0.1,0.1 ) + ( temp_output_2_0_g65 + float2( 0.85,0.14 ) ));
				float4 temp_cast_3 = (_FlowPower).xxxx;
				float4 vFlow168 = ( _FlowIntensity * pow( ( ( ( tex2D( _FlowMask, panner9_g65 ) + tex2D( _FlowMask, panner13_g65 ) ) + tex2D( _FlowMask, panner18_g65 ) ) * 0.25 ) , temp_cast_3 ) );
				float4 temp_output_37_0 = ( vEdgeFoam167 + vFlow168 );
				float temp_output_7_0_g67 = ( _FoamRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g66 = IN.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g66 = ( _TimeParameters.x * _FoamSpeed + ( _FoamUVTiling * texCoord5_g66 ));
				float2 temp_output_2_0_g67 = panner7_g66;
				float2 panner9_g67 = ( temp_output_7_0_g67 * float2( 0.1,0.1 ) + temp_output_2_0_g67);
				float2 panner13_g67 = ( temp_output_7_0_g67 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g67 + float2( 0.45,0.3 ) ));
				float2 panner18_g67 = ( temp_output_7_0_g67 * float2( -0.1,0.1 ) + ( temp_output_2_0_g67 + float2( 0.85,0.14 ) ));
				float4 temp_cast_4 = (_FoamPower).xxxx;
				float4 temp_output_198_0 = ( _FoamIntensity * pow( ( ( ( tex2D( _FoamMask, panner9_g67 ) + tex2D( _FoamMask, panner13_g67 ) ) + tex2D( _FoamMask, panner18_g67 ) ) * 0.25 ) , temp_cast_4 ) );
				float4 vSurfaceFoam166 = temp_output_198_0;
				float4 lerpResult47 = lerp( temp_output_37_0 , float4( 0,0,0,0 ) , vSurfaceFoam166);
				#ifdef _USESTEPFORFLOW_ON
				float staticSwitch185 = ( (step( temp_output_37_0 , vSurfaceFoam166 )).r + vEdgeFoam167 );
				#else
				float staticSwitch185 = (lerpResult47).r;
				#endif
				float clampResult59 = clamp( staticSwitch185 , 0.0 , 1.0 );
				float4 vFoam175 = ( vFoamColor169 * clampResult59 );
				float4 temp_output_77_0 = ( vColorWaves73 + vFoam175 );
				float temp_output_7_0_g71 = ( _NormalRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g70 = IN.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g70 = ( _TimeParameters.x * _NormalSpeed + ( _NormalUVTiling * texCoord5_g70 ));
				float2 temp_output_2_0_g71 = panner7_g70;
				float2 panner9_g71 = ( temp_output_7_0_g71 * float2( 0.1,0.1 ) + temp_output_2_0_g71);
				float temp_output_24_0_g71 = _NormalIntensity;
				float3 unpack10_g71 = UnpackNormalScale( tex2D( _NormalMap, panner9_g71 ), temp_output_24_0_g71 );
				unpack10_g71.z = lerp( 1, unpack10_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner13_g71 = ( temp_output_7_0_g71 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g71 + float2( 0.45,0.3 ) ));
				float3 unpack14_g71 = UnpackNormalScale( tex2D( _NormalMap, panner13_g71 ), temp_output_24_0_g71 );
				unpack14_g71.z = lerp( 1, unpack14_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner18_g71 = ( temp_output_7_0_g71 * float2( -0.1,0.1 ) + ( temp_output_2_0_g71 + float2( 0.85,0.14 ) ));
				float3 unpack20_g71 = UnpackNormalScale( tex2D( _NormalMap, panner18_g71 ), temp_output_24_0_g71 );
				unpack20_g71.z = lerp( 1, unpack20_g71.z, saturate(temp_output_24_0_g71) );
				float3 vNormal154 = BlendNormal( BlendNormal( unpack10_g71 , unpack14_g71 ) , unpack20_g71 );
				float eyeDepth = IN.ase_texcoord3.z;
				float eyeDepth28_g72 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float2 temp_output_20_0_g72 = ( (vNormal154).xy * ( _RefractionStrength / max( eyeDepth , 0.1 ) ) * saturate( ( eyeDepth28_g72 - eyeDepth ) ) );
				float eyeDepth2_g72 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ( float4( temp_output_20_0_g72, 0.0 , 0.0 ) + ase_screenPosNorm ).xy ),_ZBufferParams);
				float2 temp_output_32_0_g72 = (( float4( ( temp_output_20_0_g72 * saturate( ( eyeDepth2_g72 - eyeDepth ) ) ), 0.0 , 0.0 ) + ase_screenPosNorm )).xy;
				float4 fetchOpaqueVal125 = float4( SHADERGRAPH_SAMPLE_SCENE_COLOR( temp_output_32_0_g72 ), 1.0 );
				float4 vRefraction126 = fetchOpaqueVal125;
				float4 blendOpSrc131 = temp_output_77_0;
				float4 blendOpDest131 = vRefraction126;
				float screenDepth129 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth129 = abs( ( screenDepth129 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _RefractionDepth ) );
				float4 lerpResult133 = lerp( ( saturate( (( blendOpDest131 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest131 ) * ( 1.0 - blendOpSrc131 ) ) : ( 2.0 * blendOpDest131 * blendOpSrc131 ) ) )) , temp_output_77_0 , saturate( distanceDepth129 ));
				float4 vFinalColor180 = lerpResult133;
				

				float3 BaseColor = vFinalColor180.rgb;
				float Alpha = _Opacity;
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

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 120108


			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS SHADERPASS_DEPTHNORMALSONLY

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_VERT_NORMAL


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD1;
				#endif
				float3 worldNormal : TEXCOORD2;
				float4 worldTangent : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _ColorShallow;
			float4 _ColorDeep;
			float4 _WaterFoamColor;
			float2 _FlowSpeed;
			float2 _HeightSpeed;
			float2 _HeightUVTiling;
			float2 _FoamSpeed;
			float2 _FoamUVTiling;
			float2 _FlowUVTiling;
			float2 _NormalUVTiling;
			float2 _NormalSpeed;
			float2 _EdgeFoamSpeed;
			float _HeightIntensity;
			float _FoamPower;
			float _NormalIntensity;
			float _RefractionStrength;
			float _RefractionDepth;
			float _Metallic;
			float _NormalRandomizeUV;
			float _FoamRandomizeUV;
			float _FlowRandomizeUV;
			float _FlowPower;
			float _Roughness;
			float _FlowIntensity;
			float _EdgeFoamIntensity;
			float _EdgeFoamScale;
			float _EdgeFoamCutoff;
			float _EdgeFoamDepthFade;
			float _WaterFoamColorIntensity;
			float _ColorDepthFade;
			float _HeightPower;
			float _HeightRandomizeUV;
			float _FoamIntensity;
			float _Opacity;
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

			// Property used by ScenePickingPass
			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			// Properties used by SceneSelectionPass
			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D _HeightMap;
			sampler2D _NormalMap;


			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/DepthNormalsOnlyPass.hlsl"

			//#ifdef HAVE_VFX_MODIFICATION
			//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
			//#endif

			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = v.ase_texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2Dlod( _HeightMap, float4( panner9_g69, 0, 0.0) ) + tex2Dlod( _HeightMap, float4( panner13_g69, 0, 0.0) ) ) + tex2Dlod( _HeightMap, float4( panner18_g69, 0, 0.0) ) ) * 0.25 ) , temp_cast_0 ) ) * float4( v.ase_normal , 0.0 ) );
				
				o.ase_texcoord4.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord4.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = vDisplacement160.rgb;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;
				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float3 normalWS = TransformObjectToWorldNormal( v.ase_normal );
				float4 tangentWS = float4(TransformObjectToWorldDir( v.ase_tangent.xyz), v.ase_tangent.w);
				float4 positionCS = TransformWorldToHClip( positionWS );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					o.worldPos = positionWS;
				#endif

				o.worldNormal = normalWS;
				o.worldTangent = tangentWS;

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.clipPos = positionCS;

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 ase_texcoord : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_tangent = v.ase_tangent;
				o.ase_texcoord = v.ase_texcoord;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
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
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif

			half4 frag(	VertexOutput IN
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 WorldPosition = IN.worldPos;
				#endif

				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				float3 WorldNormal = IN.worldNormal;
				float4 WorldTangent = IN.worldTangent;

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float temp_output_7_0_g71 = ( _NormalRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g70 = IN.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g70 = ( _TimeParameters.x * _NormalSpeed + ( _NormalUVTiling * texCoord5_g70 ));
				float2 temp_output_2_0_g71 = panner7_g70;
				float2 panner9_g71 = ( temp_output_7_0_g71 * float2( 0.1,0.1 ) + temp_output_2_0_g71);
				float temp_output_24_0_g71 = _NormalIntensity;
				float3 unpack10_g71 = UnpackNormalScale( tex2D( _NormalMap, panner9_g71 ), temp_output_24_0_g71 );
				unpack10_g71.z = lerp( 1, unpack10_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner13_g71 = ( temp_output_7_0_g71 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g71 + float2( 0.45,0.3 ) ));
				float3 unpack14_g71 = UnpackNormalScale( tex2D( _NormalMap, panner13_g71 ), temp_output_24_0_g71 );
				unpack14_g71.z = lerp( 1, unpack14_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner18_g71 = ( temp_output_7_0_g71 * float2( -0.1,0.1 ) + ( temp_output_2_0_g71 + float2( 0.85,0.14 ) ));
				float3 unpack20_g71 = UnpackNormalScale( tex2D( _NormalMap, panner18_g71 ), temp_output_24_0_g71 );
				unpack20_g71.z = lerp( 1, unpack20_g71.z, saturate(temp_output_24_0_g71) );
				float3 vNormal154 = BlendNormal( BlendNormal( unpack10_g71 , unpack14_g71 ) , unpack20_g71 );
				

				float3 Normal = vNormal154;
				float Alpha = _Opacity;
				float AlphaClipThreshold = 0.5;
				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = 0;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif

				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
				#endif

				#if defined(_GBUFFER_NORMALS_OCT)
					float2 octNormalWS = PackNormalOctQuadEncode(WorldNormal);
					float2 remappedOctNormalWS = saturate(octNormalWS * 0.5 + 0.5);
					half3 packedNormalWS = PackFloat2To888(remappedOctNormalWS);
					return half4(packedNormalWS, 0.0);
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
					return half4(NormalizeNormalPerPixel(normalWS), 0.0);
				#endif
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "GBuffer"
			Tags { "LightMode"="UniversalGBuffer" }

			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZWrite Off
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA
			

			HLSLPROGRAM

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma instancing_options renderinglayer
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 120108
			#define REQUIRE_DEPTH_TEXTURE 1
			#define REQUIRE_OPAQUE_TEXTURE 1


			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BLENDING
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BOX_PROJECTION
			#pragma multi_compile_fragment _ _SHADOWS_SOFT
			#pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
			#pragma multi_compile_fragment _ _LIGHT_LAYERS
			#pragma multi_compile_fragment _ _RENDER_PASS_ENABLED
			#pragma shader_feature_local _RECEIVE_SHADOWS_OFF
			#pragma shader_feature_local_fragment _SPECULARHIGHLIGHTS_OFF
			#pragma shader_feature_local_fragment _ENVIRONMENTREFLECTIONS_OFF

			#pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
			#pragma multi_compile _ SHADOWS_SHADOWMASK
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON
			#pragma multi_compile _ DYNAMICLIGHTMAP_ON
			#pragma multi_compile_fragment _ _GBUFFER_NORMALS_OCT

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS SHADERPASS_GBUFFER

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DBuffer.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(UNITY_INSTANCING_ENABLED) && defined(_TERRAIN_INSTANCED_PERPIXEL_NORMAL)
				#define ENABLE_TERRAIN_PERPIXEL_NORMAL
			#endif

			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local _USESTEPFORFLOW_ON


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 lightmapUVOrVertexSH : TEXCOORD0;
				half4 fogFactorAndVertexLight : TEXCOORD1;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				float4 shadowCoord : TEXCOORD2;
				#endif
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				float4 screenPos : TEXCOORD6;
				#endif
				#if defined(DYNAMICLIGHTMAP_ON)
				float2 dynamicLightmapUV : TEXCOORD7;
				#endif
				float4 ase_texcoord8 : TEXCOORD8;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _ColorShallow;
			float4 _ColorDeep;
			float4 _WaterFoamColor;
			float2 _FlowSpeed;
			float2 _HeightSpeed;
			float2 _HeightUVTiling;
			float2 _FoamSpeed;
			float2 _FoamUVTiling;
			float2 _FlowUVTiling;
			float2 _NormalUVTiling;
			float2 _NormalSpeed;
			float2 _EdgeFoamSpeed;
			float _HeightIntensity;
			float _FoamPower;
			float _NormalIntensity;
			float _RefractionStrength;
			float _RefractionDepth;
			float _Metallic;
			float _NormalRandomizeUV;
			float _FoamRandomizeUV;
			float _FlowRandomizeUV;
			float _FlowPower;
			float _Roughness;
			float _FlowIntensity;
			float _EdgeFoamIntensity;
			float _EdgeFoamScale;
			float _EdgeFoamCutoff;
			float _EdgeFoamDepthFade;
			float _WaterFoamColorIntensity;
			float _ColorDepthFade;
			float _HeightPower;
			float _HeightRandomizeUV;
			float _FoamIntensity;
			float _Opacity;
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

			// Property used by ScenePickingPass
			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			// Properties used by SceneSelectionPass
			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			sampler2D _HeightMap;
			uniform float4 _CameraDepthTexture_TexelSize;
			sampler2D _FlowMask;
			sampler2D _FoamMask;
			sampler2D _NormalMap;


			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityGBuffer.hlsl"
			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/PBRGBufferPass.hlsl"

			inline float noise_randomValue (float2 uv) { return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453); }
			inline float noise_interpolate (float a, float b, float t) { return (1.0-t)*a + (t*b); }
			inline float valueNoise (float2 uv)
			{
				float2 i = floor(uv);
				float2 f = frac( uv );
				f = f* f * (3.0 - 2.0 * f);
				uv = abs( frac(uv) - 0.5);
				float2 c0 = i + float2( 0.0, 0.0 );
				float2 c1 = i + float2( 1.0, 0.0 );
				float2 c2 = i + float2( 0.0, 1.0 );
				float2 c3 = i + float2( 1.0, 1.0 );
				float r0 = noise_randomValue( c0 );
				float r1 = noise_randomValue( c1 );
				float r2 = noise_randomValue( c2 );
				float r3 = noise_randomValue( c3 );
				float bottomOfGrid = noise_interpolate( r0, r1, f.x );
				float topOfGrid = noise_interpolate( r2, r3, f.x );
				float t = noise_interpolate( bottomOfGrid, topOfGrid, f.y );
				return t;
			}
			
			float SimpleNoise(float2 UV)
			{
				float t = 0.0;
				float freq = pow( 2.0, float( 0 ) );
				float amp = pow( 0.5, float( 3 - 0 ) );
				t += valueNoise( UV/freq )*amp;
				freq = pow(2.0, float(1));
				amp = pow(0.5, float(3-1));
				t += valueNoise( UV/freq )*amp;
				freq = pow(2.0, float(2));
				amp = pow(0.5, float(3-2));
				t += valueNoise( UV/freq )*amp;
				return t;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = v.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2Dlod( _HeightMap, float4( panner9_g69, 0, 0.0) ) + tex2Dlod( _HeightMap, float4( panner13_g69, 0, 0.0) ) ) + tex2Dlod( _HeightMap, float4( panner18_g69, 0, 0.0) ) ) * 0.25 ) , temp_cast_0 ) ) * float4( v.ase_normal , 0.0 ) );
				
				float3 objectToViewPos = TransformWorldToView(TransformObjectToWorld(v.vertex.xyz));
				float eyeDepth = -objectToViewPos.z;
				o.ase_texcoord8.z = eyeDepth;
				
				o.ase_texcoord8.xy = v.texcoord.xy;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord8.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = vDisplacement160.rgb;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float3 positionVS = TransformWorldToView( positionWS );
				float4 positionCS = TransformWorldToHClip( positionWS );

				VertexNormalInputs normalInput = GetVertexNormalInputs( v.ase_normal, v.ase_tangent );

				o.tSpace0 = float4( normalInput.normalWS, positionWS.x);
				o.tSpace1 = float4( normalInput.tangentWS, positionWS.y);
				o.tSpace2 = float4( normalInput.bitangentWS, positionWS.z);

				#if defined(LIGHTMAP_ON)
					OUTPUT_LIGHTMAP_UV(v.texcoord1, unity_LightmapST, o.lightmapUVOrVertexSH.xy);
				#endif

				#if defined(DYNAMICLIGHTMAP_ON)
					o.dynamicLightmapUV.xy = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
				#endif

				#if !defined(LIGHTMAP_ON)
					OUTPUT_SH(normalInput.normalWS.xyz, o.lightmapUVOrVertexSH.xyz);
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					o.lightmapUVOrVertexSH.zw = v.texcoord;
					o.lightmapUVOrVertexSH.xy = v.texcoord * unity_LightmapST.xy + unity_LightmapST.zw;
				#endif

				half3 vertexLight = VertexLighting( positionWS, normalInput.normalWS );

				o.fogFactorAndVertexLight = half4(0, vertexLight);

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

					o.clipPos = positionCS;

				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
					o.screenPos = ComputeScreenPos(positionCS);
				#endif

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_tangent = v.ase_tangent;
				o.texcoord = v.texcoord;
				o.texcoord1 = v.texcoord1;
				o.texcoord2 = v.texcoord2;
				
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
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
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				o.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif

			FragmentOutput frag ( VertexOutput IN
								#ifdef ASE_DEPTH_WRITE_ON
								,out float outputDepth : ASE_SV_DEPTH
								#endif
								 )
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float2 sampleCoords = (IN.lightmapUVOrVertexSH.zw / _TerrainHeightmapRecipSize.zw + 0.5f) * _TerrainHeightmapRecipSize.xy;
					float3 WorldNormal = TransformObjectToWorldNormal(normalize(SAMPLE_TEXTURE2D(_TerrainNormalmapTexture, sampler_TerrainNormalmapTexture, sampleCoords).rgb * 2 - 1));
					float3 WorldTangent = -cross(GetObjectToWorldMatrix()._13_23_33, WorldNormal);
					float3 WorldBiTangent = cross(WorldNormal, -WorldTangent);
				#else
					float3 WorldNormal = normalize( IN.tSpace0.xyz );
					float3 WorldTangent = IN.tSpace1.xyz;
					float3 WorldBiTangent = IN.tSpace2.xyz;
				#endif

				float3 WorldPosition = float3(IN.tSpace0.w,IN.tSpace1.w,IN.tSpace2.w);
				float3 WorldViewDirection = _WorldSpaceCameraPos.xyz  - WorldPosition;
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
					float4 ScreenPos = IN.screenPos;
				#endif

				float2 NormalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(IN.clipPos);

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					ShadowCoords = IN.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
				#else
					ShadowCoords = float4(0, 0, 0, 0);
				#endif

				WorldViewDirection = SafeNormalize( WorldViewDirection );

				float4 ase_screenPosNorm = ScreenPos / ScreenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float screenDepth65 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth65 = abs( ( screenDepth65 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _ColorDepthFade ) );
				float4 lerpResult69 = lerp( _ColorShallow , _ColorDeep , saturate( distanceDepth65 ));
				float temp_output_7_0_g69 = ( _HeightRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g68 = IN.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g68 = ( _TimeParameters.x * _HeightSpeed + ( _HeightUVTiling * texCoord5_g68 ));
				float2 temp_output_2_0_g69 = panner7_g68;
				float2 panner9_g69 = ( temp_output_7_0_g69 * float2( 0.1,0.1 ) + temp_output_2_0_g69);
				float2 panner13_g69 = ( temp_output_7_0_g69 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g69 + float2( 0.45,0.3 ) ));
				float2 panner18_g69 = ( temp_output_7_0_g69 * float2( -0.1,0.1 ) + ( temp_output_2_0_g69 + float2( 0.85,0.14 ) ));
				float4 temp_cast_0 = (_HeightPower).xxxx;
				float4 vDisplacement160 = ( ( _HeightIntensity * pow( ( ( ( tex2D( _HeightMap, panner9_g69 ) + tex2D( _HeightMap, panner13_g69 ) ) + tex2D( _HeightMap, panner18_g69 ) ) * 0.25 ) , temp_cast_0 ) ) * float4( IN.ase_normal , 0.0 ) );
				float4 lerpResult72 = lerp( lerpResult69 , ( lerpResult69 + float4( 0.5,0.5,0.5,0 ) ) , vDisplacement160);
				float4 vColorWaves73 = lerpResult72;
				float4 vFoamColor169 = ( _WaterFoamColor * _WaterFoamColorIntensity );
				float screenDepth9_g53 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth9_g53 = abs( ( screenDepth9_g53 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeFoamDepthFade ) );
				float mulTime4_g53 = _TimeParameters.x * 0.1;
				float2 temp_cast_2 = (_EdgeFoamScale).xx;
				float2 texCoord2_g53 = IN.ase_texcoord8.xy * temp_cast_2 + float2( 0,0 );
				float2 panner6_g53 = ( mulTime4_g53 * _EdgeFoamSpeed + texCoord2_g53);
				float simpleNoise13_g53 = SimpleNoise( panner6_g53*50.0 );
				float temp_output_22_0_g53 = ( step( ( saturate( distanceDepth9_g53 ) * _EdgeFoamCutoff ) , simpleNoise13_g53 ) * _EdgeFoamIntensity );
				float vEdgeFoam167 = temp_output_22_0_g53;
				float temp_output_7_0_g65 = ( _FlowRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g64 = IN.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g64 = ( _TimeParameters.x * _FlowSpeed + ( _FlowUVTiling * texCoord5_g64 ));
				float2 temp_output_2_0_g65 = panner7_g64;
				float2 panner9_g65 = ( temp_output_7_0_g65 * float2( 0.1,0.1 ) + temp_output_2_0_g65);
				float2 panner13_g65 = ( temp_output_7_0_g65 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g65 + float2( 0.45,0.3 ) ));
				float2 panner18_g65 = ( temp_output_7_0_g65 * float2( -0.1,0.1 ) + ( temp_output_2_0_g65 + float2( 0.85,0.14 ) ));
				float4 temp_cast_3 = (_FlowPower).xxxx;
				float4 vFlow168 = ( _FlowIntensity * pow( ( ( ( tex2D( _FlowMask, panner9_g65 ) + tex2D( _FlowMask, panner13_g65 ) ) + tex2D( _FlowMask, panner18_g65 ) ) * 0.25 ) , temp_cast_3 ) );
				float4 temp_output_37_0 = ( vEdgeFoam167 + vFlow168 );
				float temp_output_7_0_g67 = ( _FoamRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g66 = IN.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g66 = ( _TimeParameters.x * _FoamSpeed + ( _FoamUVTiling * texCoord5_g66 ));
				float2 temp_output_2_0_g67 = panner7_g66;
				float2 panner9_g67 = ( temp_output_7_0_g67 * float2( 0.1,0.1 ) + temp_output_2_0_g67);
				float2 panner13_g67 = ( temp_output_7_0_g67 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g67 + float2( 0.45,0.3 ) ));
				float2 panner18_g67 = ( temp_output_7_0_g67 * float2( -0.1,0.1 ) + ( temp_output_2_0_g67 + float2( 0.85,0.14 ) ));
				float4 temp_cast_4 = (_FoamPower).xxxx;
				float4 temp_output_198_0 = ( _FoamIntensity * pow( ( ( ( tex2D( _FoamMask, panner9_g67 ) + tex2D( _FoamMask, panner13_g67 ) ) + tex2D( _FoamMask, panner18_g67 ) ) * 0.25 ) , temp_cast_4 ) );
				float4 vSurfaceFoam166 = temp_output_198_0;
				float4 lerpResult47 = lerp( temp_output_37_0 , float4( 0,0,0,0 ) , vSurfaceFoam166);
				#ifdef _USESTEPFORFLOW_ON
				float staticSwitch185 = ( (step( temp_output_37_0 , vSurfaceFoam166 )).r + vEdgeFoam167 );
				#else
				float staticSwitch185 = (lerpResult47).r;
				#endif
				float clampResult59 = clamp( staticSwitch185 , 0.0 , 1.0 );
				float4 vFoam175 = ( vFoamColor169 * clampResult59 );
				float4 temp_output_77_0 = ( vColorWaves73 + vFoam175 );
				float temp_output_7_0_g71 = ( _NormalRandomizeUV * _TimeParameters.x );
				float2 texCoord5_g70 = IN.ase_texcoord8.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner7_g70 = ( _TimeParameters.x * _NormalSpeed + ( _NormalUVTiling * texCoord5_g70 ));
				float2 temp_output_2_0_g71 = panner7_g70;
				float2 panner9_g71 = ( temp_output_7_0_g71 * float2( 0.1,0.1 ) + temp_output_2_0_g71);
				float temp_output_24_0_g71 = _NormalIntensity;
				float3 unpack10_g71 = UnpackNormalScale( tex2D( _NormalMap, panner9_g71 ), temp_output_24_0_g71 );
				unpack10_g71.z = lerp( 1, unpack10_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner13_g71 = ( temp_output_7_0_g71 * float2( -0.1,-0.1 ) + ( temp_output_2_0_g71 + float2( 0.45,0.3 ) ));
				float3 unpack14_g71 = UnpackNormalScale( tex2D( _NormalMap, panner13_g71 ), temp_output_24_0_g71 );
				unpack14_g71.z = lerp( 1, unpack14_g71.z, saturate(temp_output_24_0_g71) );
				float2 panner18_g71 = ( temp_output_7_0_g71 * float2( -0.1,0.1 ) + ( temp_output_2_0_g71 + float2( 0.85,0.14 ) ));
				float3 unpack20_g71 = UnpackNormalScale( tex2D( _NormalMap, panner18_g71 ), temp_output_24_0_g71 );
				unpack20_g71.z = lerp( 1, unpack20_g71.z, saturate(temp_output_24_0_g71) );
				float3 vNormal154 = BlendNormal( BlendNormal( unpack10_g71 , unpack14_g71 ) , unpack20_g71 );
				float eyeDepth = IN.ase_texcoord8.z;
				float eyeDepth28_g72 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float2 temp_output_20_0_g72 = ( (vNormal154).xy * ( _RefractionStrength / max( eyeDepth , 0.1 ) ) * saturate( ( eyeDepth28_g72 - eyeDepth ) ) );
				float eyeDepth2_g72 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ( float4( temp_output_20_0_g72, 0.0 , 0.0 ) + ase_screenPosNorm ).xy ),_ZBufferParams);
				float2 temp_output_32_0_g72 = (( float4( ( temp_output_20_0_g72 * saturate( ( eyeDepth2_g72 - eyeDepth ) ) ), 0.0 , 0.0 ) + ase_screenPosNorm )).xy;
				float4 fetchOpaqueVal125 = float4( SHADERGRAPH_SAMPLE_SCENE_COLOR( temp_output_32_0_g72 ), 1.0 );
				float4 vRefraction126 = fetchOpaqueVal125;
				float4 blendOpSrc131 = temp_output_77_0;
				float4 blendOpDest131 = vRefraction126;
				float screenDepth129 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth129 = abs( ( screenDepth129 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _RefractionDepth ) );
				float4 lerpResult133 = lerp( ( saturate( (( blendOpDest131 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest131 ) * ( 1.0 - blendOpSrc131 ) ) : ( 2.0 * blendOpDest131 * blendOpSrc131 ) ) )) , temp_output_77_0 , saturate( distanceDepth129 ));
				float4 vFinalColor180 = lerpResult133;
				

				float3 BaseColor = vFinalColor180.rgb;
				float3 Normal = vNormal154;
				float3 Emission = 0;
				float3 Specular = 0.5;
				float Metallic = _Metallic;
				float Smoothness = ( 1.0 - _Roughness );
				float Occlusion = 1;
				float Alpha = _Opacity;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = 0;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				InputData inputData = (InputData)0;
				inputData.positionWS = WorldPosition;
				inputData.positionCS = IN.clipPos;
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

				inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float3 SH = SampleSH(inputData.normalWS.xyz);
				#else
					float3 SH = IN.lightmapUVOrVertexSH.xyz;
				#endif

				#ifdef ASE_BAKEDGI
					inputData.bakedGI = BakedGI;
				#else
					#if defined(DYNAMICLIGHTMAP_ON)
						inputData.bakedGI = SAMPLE_GI( IN.lightmapUVOrVertexSH.xy, IN.dynamicLightmapUV.xy, SH, inputData.normalWS);
					#else
						inputData.bakedGI = SAMPLE_GI( IN.lightmapUVOrVertexSH.xy, SH, inputData.normalWS );
					#endif
				#endif

				inputData.normalizedScreenSpaceUV = NormalizedScreenSpaceUV;
				inputData.shadowMask = SAMPLE_SHADOWMASK(IN.lightmapUVOrVertexSH.xy);

				#if defined(DEBUG_DISPLAY)
					#if defined(DYNAMICLIGHTMAP_ON)
						inputData.dynamicLightmapUV = IN.dynamicLightmapUV.xy;
						#endif
					#if defined(LIGHTMAP_ON)
						inputData.staticLightmapUV = IN.lightmapUVOrVertexSH.xy;
					#else
						inputData.vertexSH = SH;
					#endif
				#endif

				#ifdef _DBUFFER
					ApplyDecal(IN.clipPos,
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

				return BRDFDataToGbuffer(brdfData, inputData, Smoothness, Emission + color.rgb);
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "SceneSelectionPass"
			Tags { "LightMode"="SceneSelectionPass" }

			Cull Off

			HLSLPROGRAM

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 120108


			#pragma vertex vert
			#pragma fragment frag

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
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			

			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _ColorShallow;
			float4 _ColorDeep;
			float4 _WaterFoamColor;
			float2 _FlowSpeed;
			float2 _HeightSpeed;
			float2 _HeightUVTiling;
			float2 _FoamSpeed;
			float2 _FoamUVTiling;
			float2 _FlowUVTiling;
			float2 _NormalUVTiling;
			float2 _NormalSpeed;
			float2 _EdgeFoamSpeed;
			float _HeightIntensity;
			float _FoamPower;
			float _NormalIntensity;
			float _RefractionStrength;
			float _RefractionDepth;
			float _Metallic;
			float _NormalRandomizeUV;
			float _FoamRandomizeUV;
			float _FlowRandomizeUV;
			float _FlowPower;
			float _Roughness;
			float _FlowIntensity;
			float _EdgeFoamIntensity;
			float _EdgeFoamScale;
			float _EdgeFoamCutoff;
			float _EdgeFoamDepthFade;
			float _WaterFoamColorIntensity;
			float _ColorDepthFade;
			float _HeightPower;
			float _HeightRandomizeUV;
			float _FoamIntensity;
			float _Opacity;
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

			// Property used by ScenePickingPass
			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			// Properties used by SceneSelectionPass
			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			

			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SelectionPickingPass.hlsl"

			//#ifdef HAVE_VFX_MODIFICATION
			//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
			//#endif

			
			struct SurfaceDescription
			{
				float Alpha;
				float AlphaClipThreshold;
			};

			VertexOutput VertexFunction(VertexInput v  )
			{
				VertexOutput o;
				ZERO_INITIALIZE(VertexOutput, o);

				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );

				o.clipPos = TransformWorldToHClip(positionWS);

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
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
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN ) : SV_TARGET
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

			HLSLPROGRAM

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 120108


			#pragma vertex vert
			#pragma fragment frag

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
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			

			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _ColorShallow;
			float4 _ColorDeep;
			float4 _WaterFoamColor;
			float2 _FlowSpeed;
			float2 _HeightSpeed;
			float2 _HeightUVTiling;
			float2 _FoamSpeed;
			float2 _FoamUVTiling;
			float2 _FlowUVTiling;
			float2 _NormalUVTiling;
			float2 _NormalSpeed;
			float2 _EdgeFoamSpeed;
			float _HeightIntensity;
			float _FoamPower;
			float _NormalIntensity;
			float _RefractionStrength;
			float _RefractionDepth;
			float _Metallic;
			float _NormalRandomizeUV;
			float _FoamRandomizeUV;
			float _FlowRandomizeUV;
			float _FlowPower;
			float _Roughness;
			float _FlowIntensity;
			float _EdgeFoamIntensity;
			float _EdgeFoamScale;
			float _EdgeFoamCutoff;
			float _EdgeFoamDepthFade;
			float _WaterFoamColorIntensity;
			float _ColorDepthFade;
			float _HeightPower;
			float _HeightRandomizeUV;
			float _FoamIntensity;
			float _Opacity;
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

			// Property used by ScenePickingPass
			#ifdef SCENEPICKINGPASS
				float4 _SelectionID;
			#endif

			// Properties used by SceneSelectionPass
			#ifdef SCENESELECTIONPASS
				int _ObjectId;
				int _PassValue;
			#endif

			

			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
			//#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SelectionPickingPass.hlsl"

			//#ifdef HAVE_VFX_MODIFICATION
			//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
			//#endif

			
			struct SurfaceDescription
			{
				float Alpha;
				float AlphaClipThreshold;
			};

			VertexOutput VertexFunction(VertexInput v  )
			{
				VertexOutput o;
				ZERO_INITIALIZE(VertexOutput, o);

				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				o.clipPos = TransformWorldToHClip(positionWS);

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
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
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN ) : SV_TARGET
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
	
	CustomEditor "UnityEditor.ShaderGraphLitGUI"
	FallBack "Hidden/Shader Graph/FallbackError"
	
	Fallback "Hidden/InternalErrorShader"
}
