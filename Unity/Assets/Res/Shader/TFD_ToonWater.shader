// Made with Amplify Shader Editor v1.9.6.3
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Toon/TFD_ToonWater"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		_ShallowColor("Shallow Color", Color) = (0,0.6117647,1,1)
		_DeepColor("Deep Color", Color) = (0,0.3333333,0.8509804,1)
		_ShallowColorDepth("Shallow Color Depth", Range( 0 , 30)) = 2.75
		_FresnelColor("Fresnel Color", Color) = (0.8313726,0.8313726,0.8313726,1)
		_FresnelIntensity("Fresnel Intensity", Range( 0 , 1)) = 0.4
		_EdgeOpacity("Edge Opacity", Range( 0 , 1)) = 0
		_Opacity("Opacity", Range( 0 , 1)) = 1
		_OpacityDepth("Opacity Depth", Range( 0 , 30)) = 6.5
		_SurfaceFoamIntensity("Surface Foam Intensity", Range( -0.4 , 0.4)) = 0.05
		_SurfaceFoamScrollSpeed("Surface Foam Scroll Speed", Range( -1 , 1)) = -0.025
		_SurfaceFoamScale("Surface Foam Scale", Range( 0 , 40)) = 1
		_EdgeFoamColor("Edge Foam Color", Color) = (1,1,1,1)
		_EdgeFoamHardness("Edge Foam Hardness", Range( 0 , 1)) = 0.33
		_EdgeFoamDistance("Edge Foam Distance", Range( 0 , 1)) = 1
		_EdgeFoamOpacity("Edge Foam Opacity", Range( 0 , 1)) = 0.65
		_EdgeFoamScale("Edge Foam Scale", Range( 0 , 1)) = 0.2
		_EdgeFoamSpeed("Edge Foam Speed", Range( 0 , 1)) = 0.125
		_ReflectionsOpacity("Reflections Opacity", Range( 0 , 1)) = 0.65
		_ReflectionsScale("Reflections Scale", Range( 1 , 40)) = 4.8
		_ReflectionsScrollSpeed("Reflections Scroll Speed", Range( -1 , 1)) = -1
		_ReflectionsCutoff("Reflections Cutoff", Range( 0 , 1)) = 0.35
		_ReflectionsCutoffScale("Reflections Cutoff Scale", Range( 1 , 40)) = 3
		_ReflectionsCutoffScrollSpeed("Reflections Cutoff Scroll Speed", Range( -1 , 1)) = -0.025
		_RefractionIntensity("Refraction Intensity", Range( 0 , 1)) = 0.1
		_RefractionScrollSpeed("Refraction Scroll Speed", Range( -1 , 1)) = -0.025
		_RefractionCutoffScale("Refraction Cutoff Scale", Range( 0 , 40)) = 1
		[Normal]_NormalMap("Normal Map", 2D) = "bump" {}
		_NoiseTexture("Noise Texture", 2D) = "white" {}


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

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent" "UniversalMaterialType"="Lit" }

		Cull Back
		ZWrite Off
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

			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZWrite On
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA

			

			HLSLPROGRAM

			

			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
			#pragma multi_compile_instancing
			#pragma instancing_options renderinglayer
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#pragma shader_feature_local _RECEIVE_SHADOWS_OFF
			#define _EMISSION
			#define ASE_SRP_VERSION 140007
			#define REQUIRE_OPAQUE_TEXTURE 1
			#define REQUIRE_DEPTH_TEXTURE 1


			

			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
			#pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS

			
            #pragma multi_compile _ EVALUATE_SH_MIXED EVALUATE_SH_VERTEX
		

			#pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BLENDING
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BOX_PROJECTION

			
			#pragma multi_compile_fragment _ _SHADOWS_SOFT
           

			

			#pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
			#pragma multi_compile _ _LIGHT_LAYERS
			#pragma multi_compile_fragment _ _LIGHT_COOKIES
			#pragma multi_compile _ _FORWARD_PLUS

			

			#pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
			#pragma multi_compile _ SHADOWS_SHADOWMASK
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON
			#pragma multi_compile _ DYNAMICLIGHTMAP_ON
			#pragma multi_compile_fragment _ DEBUG_DISPLAY

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

			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#define ASE_NEEDS_FRAG_WORLD_VIEW_DIR
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_SHADOWCOORDS


			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE) && (SHADER_TARGET >= 45)
				#define ASE_SV_DEPTH SV_DepthLessEqual
				#define ASE_SV_POSITION_QUALIFIERS linear noperspective centroid
			#else
				#define ASE_SV_DEPTH SV_Depth
				#define ASE_SV_POSITION_QUALIFIERS
			#endif

			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				float4 lightmapUVOrVertexSH : TEXCOORD1;
				half4 fogFactorAndVertexLight : TEXCOORD2;
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
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EdgeFoamColor;
			float4 _FresnelColor;
			float4 _DeepColor;
			float4 _ShallowColor;
			float _ReflectionsScrollSpeed;
			float _ReflectionsCutoffScale;
			float _ReflectionsCutoffScrollSpeed;
			float _FresnelIntensity;
			float _ShallowColorDepth;
			float _OpacityDepth;
			float _Opacity;
			float _EdgeFoamOpacity;
			float _EdgeFoamHardness;
			float _EdgeFoamDistance;
			float _EdgeFoamScale;
			float _EdgeFoamSpeed;
			float _RefractionCutoffScale;
			float _RefractionScrollSpeed;
			float _RefractionIntensity;
			float _SurfaceFoamIntensity;
			float _SurfaceFoamScale;
			float _SurfaceFoamScrollSpeed;
			float _ReflectionsOpacity;
			float _ReflectionsScale;
			float _ReflectionsCutoff;
			float _EdgeOpacity;
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

			sampler2D _NoiseTexture;
			sampler2D _NormalMap;


			inline float4 ASE_ComputeGrabScreenPos( float4 pos )
			{
				#if UNITY_UV_STARTS_AT_TOP
				float scale = -1.0;
				#else
				float scale = 1.0;
				#endif
				float4 o = pos;
				o.y = pos.w * 0.5f;
				o.y = ( pos.y - o.y ) * _ProjectionParams.x * scale + o.y;
				return o;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 ase_worldPos = TransformObjectToWorld( (v.positionOS).xyz );
				float2 vertexToFrag366 = ( (ase_worldPos).xz * float2( 0.025,0.025 ) );
				o.ase_texcoord8.xy = vertexToFrag366;
				
				o.ase_texcoord8.zw = v.texcoord.xy;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.positionOS.xyz = vertexValue;
				#else
					v.positionOS.xyz += vertexValue;
				#endif
				v.normalOS = v.normalOS;
				v.tangentOS = v.tangentOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( v.positionOS.xyz );
				VertexNormalInputs normalInput = GetVertexNormalInputs( v.normalOS, v.tangentOS );

				o.tSpace0 = float4( normalInput.normalWS, vertexInput.positionWS.x );
				o.tSpace1 = float4( normalInput.tangentWS, vertexInput.positionWS.y );
				o.tSpace2 = float4( normalInput.bitangentWS, vertexInput.positionWS.z );

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
					o.lightmapUVOrVertexSH.zw = v.texcoord.xy;
					o.lightmapUVOrVertexSH.xy = v.texcoord.xy * unity_LightmapST.xy + unity_LightmapST.zw;
				#endif

				half3 vertexLight = VertexLighting( vertexInput.positionWS, normalInput.normalWS );

				#ifdef ASE_FOG
					half fogFactor = ComputeFogFactor( vertexInput.positionCS.z );
				#else
					half fogFactor = 0;
				#endif

				o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.positionCS = vertexInput.positionCS;
				o.clipPosV = vertexInput.positionCS;
				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
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
				o.vertex = v.positionOS;
				o.normalOS = v.normalOS;
				o.tangentOS = v.tangentOS;
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
				o.positionOS = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				o.tangentOS = patch[0].tangentOS * bary.x + patch[1].tangentOS * bary.y + patch[2].tangentOS * bary.z;
				o.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.positionOS.xyz - patch[i].normalOS * (dot(o.positionOS.xyz, patch[i].normalOS) - dot(patch[i].vertex.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				o.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.positionOS.xyz;
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

			half4 frag ( VertexOutput IN
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						#ifdef _WRITE_RENDERING_LAYERS
						, out float4 outRenderingLayers : SV_Target1
						#endif
						 ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( IN.positionCS );
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

				float4 ClipPos = IN.clipPosV;
				float4 ScreenPos = ComputeScreenPos( IN.clipPosV );

				float2 NormalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(IN.positionCS);

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					ShadowCoords = IN.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
				#endif

				WorldViewDirection = SafeNormalize( WorldViewDirection );

				float4 ase_screenPosNorm = ScreenPos / ScreenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float2 appendResult31 = (float2(( ase_screenPosNorm.x + 0.01 ) , ( ase_screenPosNorm.y + 0.01 )));
				float2 temp_cast_1 = (_ReflectionsScrollSpeed).xx;
				float2 vertexToFrag366 = IN.ase_texcoord8.xy;
				float2 GlobalUV368 = vertexToFrag366;
				float2 panner40 = ( 1.0 * _Time.y * temp_cast_1 + ( _ReflectionsScale * GlobalUV368 ));
				float Turbulence291 = ( UnpackNormalScale( tex2D( _NormalMap, panner40 ), 1.0f ).g * (0.0 + (_ReflectionsOpacity - 0.0) * (8.0 - 0.0) / (1.0 - 0.0)) );
				float4 lerpResult24 = lerp( ase_screenPosNorm , float4( appendResult31, 0.0 , 0.0 ) , Turbulence291);
				float4 Lighting2619 = ( 0.0 * tex2D( _NoiseTexture, lerpResult24.xy ) );
				float temp_output_608_0 = (-0.2 + (_SurfaceFoamScrollSpeed - -1.0) * (0.2 - -0.2) / (1.0 - -1.0));
				float2 temp_cast_3 = (temp_output_608_0).xx;
				float2 temp_output_495_0 = ( GlobalUV368 * (1.0 + (_SurfaceFoamScale - 0.0) * (10.0 - 1.0) / (40.0 - 0.0)) );
				float2 panner498 = ( 1.0 * _Time.y * temp_cast_3 + temp_output_495_0);
				float4 tex2DNode483 = tex2D( _NoiseTexture, panner498 );
				float lerpResult550 = lerp( step( tex2DNode483.r , 1.0 ) , ( 1.0 - tex2DNode483.r ) , 1.0);
				float2 temp_cast_4 = (temp_output_608_0).xx;
				float2 panner496 = ( -1.0 * _Time.y * temp_cast_4 + ( temp_output_495_0 * 0.777 ));
				float Foam487 = ( ( lerpResult550 * -tex2D( _NoiseTexture, panner496 ).r ) * -_SurfaceFoamIntensity );
				float4 temp_cast_5 = (Foam487).xxxx;
				float2 temp_cast_6 = (_RefractionScrollSpeed).xx;
				float2 temp_output_422_0 = ( GlobalUV368 * (1.0 + (_RefractionCutoffScale - 0.0) * (10.0 - 1.0) / (40.0 - 0.0)) );
				float2 panner423 = ( 1.0 * _Time.y * temp_cast_6 + temp_output_422_0);
				float3 unpack416 = UnpackNormalScale( tex2D( _NormalMap, panner423 ), 5.7 );
				unpack416.z = lerp( 1, unpack416.z, saturate(5.7) );
				float2 temp_cast_7 = (_RefractionScrollSpeed).xx;
				float2 panner470 = ( -1.0 * _Time.y * temp_cast_7 + temp_output_422_0);
				float3 unpack425 = UnpackNormalScale( tex2D( _NormalMap, panner470 ), 2.3 );
				unpack425.z = lerp( 1, unpack425.z, saturate(2.3) );
				float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( ScreenPos );
				float4 ase_grabScreenPosNorm = ase_grabScreenPos / ase_grabScreenPos.w;
				float4 fetchOpaqueVal668 = float4( SHADERGRAPH_SAMPLE_SCENE_COLOR( ( float4( ( (0.0 + (_RefractionIntensity - 0.0) * (0.4 - 0.0) / (1.0 - 0.0)) * BlendNormal( unpack416 , unpack425 ) ) , 0.0 ) + ase_grabScreenPosNorm ).xy ), 1.0 );
				float4 Refractions378 = fetchOpaqueVal668;
				float screenDepth163 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth163 = abs( ( screenDepth163 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( ( tex2D( _NoiseTexture, ( ( _EdgeFoamSpeed * _TimeParameters.x ) + ( GlobalUV368 * (30.0 + (_EdgeFoamScale - 0.0) * (1.0 - 30.0) / (1.0 - 0.0)) ) ) ).r * (0.0 + (_EdgeFoamDistance - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) );
				float clampResult208 = clamp( distanceDepth163 , 0.0 , 1.0 );
				float clampResult160 = clamp( pow( clampResult208 , (1.0 + (_EdgeFoamHardness - 0.0) * (10.0 - 1.0) / (1.0 - 0.0)) ) , 0.0 , 1.0 );
				float temp_output_156_0 = ( ( 1.0 - clampResult160 ) * _EdgeFoamOpacity );
				float screenDepth191 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth191 = abs( ( screenDepth191 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( (0.0 + (_EdgeFoamDistance - 0.0) * (15.0 - 0.0) / (1.0 - 0.0)) ) );
				float clampResult207 = clamp( distanceDepth191 , 0.0 , 1.0 );
				float EdgeFoamSpeed435 = _EdgeFoamSpeed;
				float EdgeFoam626 = ( temp_output_156_0 + ( ( 1.0 - clampResult207 ) * ( (0.0 + (_EdgeFoamOpacity - 0.0) * (0.85 - 0.0) / (1.0 - 0.0)) * tex2D( _NoiseTexture, ( ( _TimeParameters.x * EdgeFoamSpeed435 ) + ( (15.0 + (_EdgeFoamScale - 0.0) * (1.0 - 15.0) / (1.0 - 0.0)) * GlobalUV368 ) ) ).r ) ) );
				float screenDepth294 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth294 = abs( ( screenDepth294 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _OpacityDepth ) );
				float clampResult295 = clamp( distanceDepth294 , 0.0 , 1.0 );
				float clampResult299 = clamp( ( EdgeFoam626 + _Opacity + clampResult295 ) , 0.0 , 1.0 );
				float Opacity405 = clampResult299;
				float4 lerpResult462 = lerp( Refractions378 , _ShallowColor , Opacity405);
				float4 lerpResult473 = lerp( Refractions378 , _DeepColor , Opacity405);
				float screenDepth146 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth146 = abs( ( screenDepth146 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _ShallowColorDepth ) );
				float clampResult211 = clamp( distanceDepth146 , 0.0 , 1.0 );
				float4 lerpResult142 = lerp( lerpResult462 , lerpResult473 , clampResult211);
				float fresnelNdotV136 = dot( WorldNormal, WorldViewDirection );
				float fresnelNode136 = ( 0.0 + 1.0 * pow( 1.0 - fresnelNdotV136, (0.0 + (_FresnelIntensity - 1.0) * (10.0 - 0.0) / (0.0 - 1.0)) ) );
				float clampResult209 = clamp( fresnelNode136 , 0.0 , 1.0 );
				float4 lerpResult133 = lerp( lerpResult142 , _FresnelColor , clampResult209);
				float4 WaterColor622 = lerpResult133;
				float4 blendOpSrc502 = temp_cast_5;
				float4 blendOpDest502 = WaterColor622;
				float4 blendOpSrc300 = Lighting2619;
				float4 blendOpDest300 = ( blendOpSrc502 + blendOpDest502 );
				float EdgeFoamBlend629 = temp_output_156_0;
				float3 temp_cast_10 = (1.0).xxx;
				float ase_lightIntensity = max( max( _MainLightColor.r, _MainLightColor.g ), _MainLightColor.b );
				float4 ase_lightColor = float4( _MainLightColor.rgb / ase_lightIntensity, ase_lightIntensity );
				float3 lerpResult7 = lerp( temp_cast_10 , ase_lightColor.rgb , 1.0);
				float3 normalizeResult232 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float2 temp_cast_12 = (_ReflectionsCutoffScrollSpeed).xx;
				float2 panner342 = ( 1.0 * _Time.y * temp_cast_12 + ( GlobalUV368 * (2.0 + (_ReflectionsCutoffScale - 0.0) * (10.0 - 2.0) / (10.0 - 0.0)) ));
				float3 tanToWorld0 = float3( WorldTangent.x, WorldBiTangent.x, WorldNormal.x );
				float3 tanToWorld1 = float3( WorldTangent.y, WorldBiTangent.y, WorldNormal.y );
				float3 tanToWorld2 = float3( WorldTangent.z, WorldBiTangent.z, WorldNormal.z );
				float3 tanNormal215 = UnpackNormalScale( tex2D( _NormalMap, panner342 ), 1.0f );
				float3 worldNormal215 = float3(dot(tanToWorld0,tanNormal215), dot(tanToWorld1,tanNormal215), dot(tanToWorld2,tanNormal215));
				float dotResult108 = dot( reflect( -normalizeResult232 , worldNormal215 ) , _MainLightPosition.xyz );
				float3 clampResult120 = clamp( ( ( pow( dotResult108 , exp( (0.0 + (_ReflectionsCutoff - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) * ase_lightColor.rgb ) * Turbulence291 ) , float3( 0,0,0 ) , float3( 1,1,1 ) );
				float3 ReflexionsCutoff612 = clampResult120;
				
				float2 texCoord376 = IN.ase_texcoord8.zw * float2( 1,1 ) + float2( 0,0 );
				float ase_lightAtten = 0;
				Light ase_mainLight = GetMainLight( ShadowCoords );
				ase_lightAtten = ase_mainLight.distanceAttenuation * ase_mainLight.shadowAttenuation;
				float3 lerpResult90 = lerp( ( ReflexionsCutoff612 * float3( texCoord376 ,  0.0 ) ) , ( ase_lightColor.rgb * ase_lightAtten ) , ( 1.0 - ase_lightAtten ));
				float3 Lighting1616 = lerpResult90;
				
				float screenDepth665 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth665 = abs( ( screenDepth665 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeOpacity ) );
				

				float3 BaseColor = ( ( ( ( blendOpSrc300 + blendOpDest300 ) + ( EdgeFoamBlend629 * _EdgeFoamColor ) + ( _EdgeFoamColor * EdgeFoam626 ) ) * float4( lerpResult7 , 0.0 ) ) + float4( ReflexionsCutoff612 , 0.0 ) ).rgb;
				float3 Normal = float3(0, 0, 1);
				float3 Emission = Lighting1616;
				float3 Specular = 0.5;
				float Metallic = 0.0;
				float Smoothness = 0.0;
				float Occlusion = 1;
				float Alpha = ( clampResult299 * saturate( distanceDepth665 ) );
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = IN.positionCS.z;
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
					ApplyDecalToSurfaceData(IN.positionCS, surfaceData, inputData);
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

								Light light = GetAdditionalLight(lightIndex, inputData.positionWS);
								#ifdef _LIGHT_LAYERS
								if (IsMatchingLightLayer(light.layerMask, meshRenderingLayers))
								#endif
								{
									SUM_LIGHT_TRANSMISSION( light );
								}
							}
						#endif
						LIGHT_LOOP_BEGIN( pixelLightCount )
							Light light = GetAdditionalLight(lightIndex, inputData.positionWS);
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

								Light light = GetAdditionalLight(lightIndex, inputData.positionWS);
								#ifdef _LIGHT_LAYERS
								if (IsMatchingLightLayer(light.layerMask, meshRenderingLayers))
								#endif
								{
									SUM_LIGHT_TRANSLUCENCY( light );
								}
							}
						#endif
						LIGHT_LOOP_BEGIN( pixelLightCount )
							Light light = GetAdditionalLight(lightIndex, inputData.positionWS);
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
						color.rgb = MixFogColor(color.rgb, half3( 0, 0, 0 ), IN.fogFactorAndVertexLight.x );
					#else
						color.rgb = MixFog(color.rgb, IN.fogFactorAndVertexLight.x);
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
			#define _EMISSION
			#define ASE_SRP_VERSION 140007
			#define REQUIRE_DEPTH_TEXTURE 1


			

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

			

			

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#define ASE_NEEDS_FRAG_SCREEN_POSITION


			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE) && (SHADER_TARGET >= 45)
				#define ASE_SV_DEPTH SV_DepthLessEqual
				#define ASE_SV_POSITION_QUALIFIERS linear noperspective centroid
			#else
				#define ASE_SV_DEPTH SV_Depth
				#define ASE_SV_POSITION_QUALIFIERS
			#endif

			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 positionWS : TEXCOORD1;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD2;
				#endif
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EdgeFoamColor;
			float4 _FresnelColor;
			float4 _DeepColor;
			float4 _ShallowColor;
			float _ReflectionsScrollSpeed;
			float _ReflectionsCutoffScale;
			float _ReflectionsCutoffScrollSpeed;
			float _FresnelIntensity;
			float _ShallowColorDepth;
			float _OpacityDepth;
			float _Opacity;
			float _EdgeFoamOpacity;
			float _EdgeFoamHardness;
			float _EdgeFoamDistance;
			float _EdgeFoamScale;
			float _EdgeFoamSpeed;
			float _RefractionCutoffScale;
			float _RefractionScrollSpeed;
			float _RefractionIntensity;
			float _SurfaceFoamIntensity;
			float _SurfaceFoamScale;
			float _SurfaceFoamScrollSpeed;
			float _ReflectionsOpacity;
			float _ReflectionsScale;
			float _ReflectionsCutoff;
			float _EdgeOpacity;
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

			sampler2D _NoiseTexture;


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 ase_worldPos = TransformObjectToWorld( (v.positionOS).xyz );
				float2 vertexToFrag366 = ( (ase_worldPos).xz * float2( 0.025,0.025 ) );
				o.ase_texcoord3.xy = vertexToFrag366;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord3.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.positionOS.xyz = vertexValue;
				#else
					v.positionOS.xyz += vertexValue;
				#endif

				v.normalOS = v.normalOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( v.positionOS.xyz );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					o.positionWS = vertexInput.positionWS;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.positionCS = vertexInput.positionCS;
				o.clipPosV = vertexInput.positionCS;
				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				
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
				o.vertex = v.positionOS;
				o.normalOS = v.normalOS;
				
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
				o.positionOS = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.positionOS.xyz - patch[i].normalOS * (dot(o.positionOS.xyz, patch[i].normalOS) - dot(patch[i].vertex.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				o.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.positionOS.xyz;
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

			half4 frag(	VertexOutput IN
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.positionWS;
				#endif

				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				float4 ClipPos = IN.clipPosV;
				float4 ScreenPos = ComputeScreenPos( IN.clipPosV );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float4 ase_screenPosNorm = ScreenPos / ScreenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float2 vertexToFrag366 = IN.ase_texcoord3.xy;
				float2 GlobalUV368 = vertexToFrag366;
				float screenDepth163 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth163 = abs( ( screenDepth163 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( ( tex2D( _NoiseTexture, ( ( _EdgeFoamSpeed * _TimeParameters.x ) + ( GlobalUV368 * (30.0 + (_EdgeFoamScale - 0.0) * (1.0 - 30.0) / (1.0 - 0.0)) ) ) ).r * (0.0 + (_EdgeFoamDistance - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) );
				float clampResult208 = clamp( distanceDepth163 , 0.0 , 1.0 );
				float clampResult160 = clamp( pow( clampResult208 , (1.0 + (_EdgeFoamHardness - 0.0) * (10.0 - 1.0) / (1.0 - 0.0)) ) , 0.0 , 1.0 );
				float temp_output_156_0 = ( ( 1.0 - clampResult160 ) * _EdgeFoamOpacity );
				float screenDepth191 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth191 = abs( ( screenDepth191 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( (0.0 + (_EdgeFoamDistance - 0.0) * (15.0 - 0.0) / (1.0 - 0.0)) ) );
				float clampResult207 = clamp( distanceDepth191 , 0.0 , 1.0 );
				float EdgeFoamSpeed435 = _EdgeFoamSpeed;
				float EdgeFoam626 = ( temp_output_156_0 + ( ( 1.0 - clampResult207 ) * ( (0.0 + (_EdgeFoamOpacity - 0.0) * (0.85 - 0.0) / (1.0 - 0.0)) * tex2D( _NoiseTexture, ( ( _TimeParameters.x * EdgeFoamSpeed435 ) + ( (15.0 + (_EdgeFoamScale - 0.0) * (1.0 - 15.0) / (1.0 - 0.0)) * GlobalUV368 ) ) ).r ) ) );
				float screenDepth294 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth294 = abs( ( screenDepth294 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _OpacityDepth ) );
				float clampResult295 = clamp( distanceDepth294 , 0.0 , 1.0 );
				float clampResult299 = clamp( ( EdgeFoam626 + _Opacity + clampResult295 ) , 0.0 , 1.0 );
				float screenDepth665 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth665 = abs( ( screenDepth665 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeOpacity ) );
				

				float Alpha = ( clampResult299 * saturate( distanceDepth665 ) );
				float AlphaClipThreshold = 0.5;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = IN.positionCS.z;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( IN.positionCS );
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
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _EMISSION
			#define ASE_SRP_VERSION 140007
			#define REQUIRE_OPAQUE_TEXTURE 1
			#define REQUIRE_DEPTH_TEXTURE 1

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

			

			

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_SHADOWCOORDS


			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
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
				float4 ase_texcoord8 : TEXCOORD8;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EdgeFoamColor;
			float4 _FresnelColor;
			float4 _DeepColor;
			float4 _ShallowColor;
			float _ReflectionsScrollSpeed;
			float _ReflectionsCutoffScale;
			float _ReflectionsCutoffScrollSpeed;
			float _FresnelIntensity;
			float _ShallowColorDepth;
			float _OpacityDepth;
			float _Opacity;
			float _EdgeFoamOpacity;
			float _EdgeFoamHardness;
			float _EdgeFoamDistance;
			float _EdgeFoamScale;
			float _EdgeFoamSpeed;
			float _RefractionCutoffScale;
			float _RefractionScrollSpeed;
			float _RefractionIntensity;
			float _SurfaceFoamIntensity;
			float _SurfaceFoamScale;
			float _SurfaceFoamScrollSpeed;
			float _ReflectionsOpacity;
			float _ReflectionsScale;
			float _ReflectionsCutoff;
			float _EdgeOpacity;
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

			sampler2D _NoiseTexture;
			sampler2D _NormalMap;


			inline float4 ASE_ComputeGrabScreenPos( float4 pos )
			{
				#if UNITY_UV_STARTS_AT_TOP
				float scale = -1.0;
				#else
				float scale = 1.0;
				#endif
				float4 o = pos;
				o.y = pos.w * 0.5f;
				o.y = ( pos.y - o.y ) * _ProjectionParams.x * scale + o.y;
				return o;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float4 ase_clipPos = TransformObjectToHClip((v.positionOS).xyz);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				o.ase_texcoord4 = screenPos;
				float3 ase_worldPos = TransformObjectToWorld( (v.positionOS).xyz );
				float2 vertexToFrag366 = ( (ase_worldPos).xz * float2( 0.025,0.025 ) );
				o.ase_texcoord5.xy = vertexToFrag366;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.normalOS);
				o.ase_texcoord6.xyz = ase_worldNormal;
				float3 ase_worldTangent = TransformObjectToWorldDir(v.ase_tangent.xyz);
				o.ase_texcoord7.xyz = ase_worldTangent;
				float ase_vertexTangentSign = v.ase_tangent.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_worldBitangent = cross( ase_worldNormal, ase_worldTangent ) * ase_vertexTangentSign;
				o.ase_texcoord8.xyz = ase_worldBitangent;
				
				o.ase_texcoord5.zw = v.texcoord0.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord6.w = 0;
				o.ase_texcoord7.w = 0;
				o.ase_texcoord8.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.positionOS.xyz = vertexValue;
				#else
					v.positionOS.xyz += vertexValue;
				#endif

				v.normalOS = v.normalOS;

				float3 positionWS = TransformObjectToWorld( v.positionOS.xyz );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					o.positionWS = positionWS;
				#endif

				o.positionCS = MetaVertexPosition( v.positionOS, v.texcoord1.xy, v.texcoord1.xy, unity_LightmapST, unity_DynamicLightmapST );

				#ifdef EDITOR_VISUALIZATION
					float2 VizUV = 0;
					float4 LightCoord = 0;
					UnityEditorVizData(v.positionOS.xyz, v.texcoord0.xy, v.texcoord1.xy, v.texcoord2.xy, VizUV, LightCoord);
					o.VizUV = float4(VizUV, 0, 0);
					o.LightCoord = LightCoord;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = o.positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_tangent : TANGENT;

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
				o.vertex = v.positionOS;
				o.normalOS = v.normalOS;
				o.texcoord0 = v.texcoord0;
				o.texcoord1 = v.texcoord1;
				o.texcoord2 = v.texcoord2;
				o.ase_tangent = v.ase_tangent;
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
				o.positionOS = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				o.texcoord0 = patch[0].texcoord0 * bary.x + patch[1].texcoord0 * bary.y + patch[2].texcoord0 * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.positionOS.xyz - patch[i].normalOS * (dot(o.positionOS.xyz, patch[i].normalOS) - dot(patch[i].vertex.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				o.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.positionOS.xyz;
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
					float3 WorldPosition = IN.positionWS;
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
				float2 appendResult31 = (float2(( ase_screenPosNorm.x + 0.01 ) , ( ase_screenPosNorm.y + 0.01 )));
				float2 temp_cast_1 = (_ReflectionsScrollSpeed).xx;
				float2 vertexToFrag366 = IN.ase_texcoord5.xy;
				float2 GlobalUV368 = vertexToFrag366;
				float2 panner40 = ( 1.0 * _Time.y * temp_cast_1 + ( _ReflectionsScale * GlobalUV368 ));
				float Turbulence291 = ( UnpackNormalScale( tex2D( _NormalMap, panner40 ), 1.0f ).g * (0.0 + (_ReflectionsOpacity - 0.0) * (8.0 - 0.0) / (1.0 - 0.0)) );
				float4 lerpResult24 = lerp( ase_screenPosNorm , float4( appendResult31, 0.0 , 0.0 ) , Turbulence291);
				float4 Lighting2619 = ( 0.0 * tex2D( _NoiseTexture, lerpResult24.xy ) );
				float temp_output_608_0 = (-0.2 + (_SurfaceFoamScrollSpeed - -1.0) * (0.2 - -0.2) / (1.0 - -1.0));
				float2 temp_cast_3 = (temp_output_608_0).xx;
				float2 temp_output_495_0 = ( GlobalUV368 * (1.0 + (_SurfaceFoamScale - 0.0) * (10.0 - 1.0) / (40.0 - 0.0)) );
				float2 panner498 = ( 1.0 * _Time.y * temp_cast_3 + temp_output_495_0);
				float4 tex2DNode483 = tex2D( _NoiseTexture, panner498 );
				float lerpResult550 = lerp( step( tex2DNode483.r , 1.0 ) , ( 1.0 - tex2DNode483.r ) , 1.0);
				float2 temp_cast_4 = (temp_output_608_0).xx;
				float2 panner496 = ( -1.0 * _Time.y * temp_cast_4 + ( temp_output_495_0 * 0.777 ));
				float Foam487 = ( ( lerpResult550 * -tex2D( _NoiseTexture, panner496 ).r ) * -_SurfaceFoamIntensity );
				float4 temp_cast_5 = (Foam487).xxxx;
				float2 temp_cast_6 = (_RefractionScrollSpeed).xx;
				float2 temp_output_422_0 = ( GlobalUV368 * (1.0 + (_RefractionCutoffScale - 0.0) * (10.0 - 1.0) / (40.0 - 0.0)) );
				float2 panner423 = ( 1.0 * _Time.y * temp_cast_6 + temp_output_422_0);
				float3 unpack416 = UnpackNormalScale( tex2D( _NormalMap, panner423 ), 5.7 );
				unpack416.z = lerp( 1, unpack416.z, saturate(5.7) );
				float2 temp_cast_7 = (_RefractionScrollSpeed).xx;
				float2 panner470 = ( -1.0 * _Time.y * temp_cast_7 + temp_output_422_0);
				float3 unpack425 = UnpackNormalScale( tex2D( _NormalMap, panner470 ), 2.3 );
				unpack425.z = lerp( 1, unpack425.z, saturate(2.3) );
				float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( screenPos );
				float4 ase_grabScreenPosNorm = ase_grabScreenPos / ase_grabScreenPos.w;
				float4 fetchOpaqueVal668 = float4( SHADERGRAPH_SAMPLE_SCENE_COLOR( ( float4( ( (0.0 + (_RefractionIntensity - 0.0) * (0.4 - 0.0) / (1.0 - 0.0)) * BlendNormal( unpack416 , unpack425 ) ) , 0.0 ) + ase_grabScreenPosNorm ).xy ), 1.0 );
				float4 Refractions378 = fetchOpaqueVal668;
				float screenDepth163 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth163 = abs( ( screenDepth163 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( ( tex2D( _NoiseTexture, ( ( _EdgeFoamSpeed * _TimeParameters.x ) + ( GlobalUV368 * (30.0 + (_EdgeFoamScale - 0.0) * (1.0 - 30.0) / (1.0 - 0.0)) ) ) ).r * (0.0 + (_EdgeFoamDistance - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) );
				float clampResult208 = clamp( distanceDepth163 , 0.0 , 1.0 );
				float clampResult160 = clamp( pow( clampResult208 , (1.0 + (_EdgeFoamHardness - 0.0) * (10.0 - 1.0) / (1.0 - 0.0)) ) , 0.0 , 1.0 );
				float temp_output_156_0 = ( ( 1.0 - clampResult160 ) * _EdgeFoamOpacity );
				float screenDepth191 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth191 = abs( ( screenDepth191 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( (0.0 + (_EdgeFoamDistance - 0.0) * (15.0 - 0.0) / (1.0 - 0.0)) ) );
				float clampResult207 = clamp( distanceDepth191 , 0.0 , 1.0 );
				float EdgeFoamSpeed435 = _EdgeFoamSpeed;
				float EdgeFoam626 = ( temp_output_156_0 + ( ( 1.0 - clampResult207 ) * ( (0.0 + (_EdgeFoamOpacity - 0.0) * (0.85 - 0.0) / (1.0 - 0.0)) * tex2D( _NoiseTexture, ( ( _TimeParameters.x * EdgeFoamSpeed435 ) + ( (15.0 + (_EdgeFoamScale - 0.0) * (1.0 - 15.0) / (1.0 - 0.0)) * GlobalUV368 ) ) ).r ) ) );
				float screenDepth294 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth294 = abs( ( screenDepth294 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _OpacityDepth ) );
				float clampResult295 = clamp( distanceDepth294 , 0.0 , 1.0 );
				float clampResult299 = clamp( ( EdgeFoam626 + _Opacity + clampResult295 ) , 0.0 , 1.0 );
				float Opacity405 = clampResult299;
				float4 lerpResult462 = lerp( Refractions378 , _ShallowColor , Opacity405);
				float4 lerpResult473 = lerp( Refractions378 , _DeepColor , Opacity405);
				float screenDepth146 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth146 = abs( ( screenDepth146 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _ShallowColorDepth ) );
				float clampResult211 = clamp( distanceDepth146 , 0.0 , 1.0 );
				float4 lerpResult142 = lerp( lerpResult462 , lerpResult473 , clampResult211);
				float3 ase_worldViewDir = ( _WorldSpaceCameraPos.xyz - WorldPosition );
				ase_worldViewDir = normalize(ase_worldViewDir);
				float3 ase_worldNormal = IN.ase_texcoord6.xyz;
				float fresnelNdotV136 = dot( ase_worldNormal, ase_worldViewDir );
				float fresnelNode136 = ( 0.0 + 1.0 * pow( 1.0 - fresnelNdotV136, (0.0 + (_FresnelIntensity - 1.0) * (10.0 - 0.0) / (0.0 - 1.0)) ) );
				float clampResult209 = clamp( fresnelNode136 , 0.0 , 1.0 );
				float4 lerpResult133 = lerp( lerpResult142 , _FresnelColor , clampResult209);
				float4 WaterColor622 = lerpResult133;
				float4 blendOpSrc502 = temp_cast_5;
				float4 blendOpDest502 = WaterColor622;
				float4 blendOpSrc300 = Lighting2619;
				float4 blendOpDest300 = ( blendOpSrc502 + blendOpDest502 );
				float EdgeFoamBlend629 = temp_output_156_0;
				float3 temp_cast_10 = (1.0).xxx;
				float ase_lightIntensity = max( max( _MainLightColor.r, _MainLightColor.g ), _MainLightColor.b );
				float4 ase_lightColor = float4( _MainLightColor.rgb / ase_lightIntensity, ase_lightIntensity );
				float3 lerpResult7 = lerp( temp_cast_10 , ase_lightColor.rgb , 1.0);
				float3 normalizeResult232 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float2 temp_cast_12 = (_ReflectionsCutoffScrollSpeed).xx;
				float2 panner342 = ( 1.0 * _Time.y * temp_cast_12 + ( GlobalUV368 * (2.0 + (_ReflectionsCutoffScale - 0.0) * (10.0 - 2.0) / (10.0 - 0.0)) ));
				float3 ase_worldTangent = IN.ase_texcoord7.xyz;
				float3 ase_worldBitangent = IN.ase_texcoord8.xyz;
				float3 tanToWorld0 = float3( ase_worldTangent.x, ase_worldBitangent.x, ase_worldNormal.x );
				float3 tanToWorld1 = float3( ase_worldTangent.y, ase_worldBitangent.y, ase_worldNormal.y );
				float3 tanToWorld2 = float3( ase_worldTangent.z, ase_worldBitangent.z, ase_worldNormal.z );
				float3 tanNormal215 = UnpackNormalScale( tex2D( _NormalMap, panner342 ), 1.0f );
				float3 worldNormal215 = float3(dot(tanToWorld0,tanNormal215), dot(tanToWorld1,tanNormal215), dot(tanToWorld2,tanNormal215));
				float dotResult108 = dot( reflect( -normalizeResult232 , worldNormal215 ) , _MainLightPosition.xyz );
				float3 clampResult120 = clamp( ( ( pow( dotResult108 , exp( (0.0 + (_ReflectionsCutoff - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) * ase_lightColor.rgb ) * Turbulence291 ) , float3( 0,0,0 ) , float3( 1,1,1 ) );
				float3 ReflexionsCutoff612 = clampResult120;
				
				float2 texCoord376 = IN.ase_texcoord5.zw * float2( 1,1 ) + float2( 0,0 );
				float ase_lightAtten = 0;
				Light ase_mainLight = GetMainLight( ShadowCoords );
				ase_lightAtten = ase_mainLight.distanceAttenuation * ase_mainLight.shadowAttenuation;
				float3 lerpResult90 = lerp( ( ReflexionsCutoff612 * float3( texCoord376 ,  0.0 ) ) , ( ase_lightColor.rgb * ase_lightAtten ) , ( 1.0 - ase_lightAtten ));
				float3 Lighting1616 = lerpResult90;
				
				float screenDepth665 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth665 = abs( ( screenDepth665 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeOpacity ) );
				

				float3 BaseColor = ( ( ( ( blendOpSrc300 + blendOpDest300 ) + ( EdgeFoamBlend629 * _EdgeFoamColor ) + ( _EdgeFoamColor * EdgeFoam626 ) ) * float4( lerpResult7 , 0.0 ) ) + float4( ReflexionsCutoff612 , 0.0 ) ).rgb;
				float3 Emission = Lighting1616;
				float Alpha = ( clampResult299 * saturate( distanceDepth665 ) );
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
			ZWrite On
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA

			HLSLPROGRAM

			#define _NORMAL_DROPOFF_TS 1
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _EMISSION
			#define ASE_SRP_VERSION 140007
			#define REQUIRE_OPAQUE_TEXTURE 1
			#define REQUIRE_DEPTH_TEXTURE 1


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

			

			

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_VERT_NORMAL


			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
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
				float4 ase_texcoord6 : TEXCOORD6;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EdgeFoamColor;
			float4 _FresnelColor;
			float4 _DeepColor;
			float4 _ShallowColor;
			float _ReflectionsScrollSpeed;
			float _ReflectionsCutoffScale;
			float _ReflectionsCutoffScrollSpeed;
			float _FresnelIntensity;
			float _ShallowColorDepth;
			float _OpacityDepth;
			float _Opacity;
			float _EdgeFoamOpacity;
			float _EdgeFoamHardness;
			float _EdgeFoamDistance;
			float _EdgeFoamScale;
			float _EdgeFoamSpeed;
			float _RefractionCutoffScale;
			float _RefractionScrollSpeed;
			float _RefractionIntensity;
			float _SurfaceFoamIntensity;
			float _SurfaceFoamScale;
			float _SurfaceFoamScrollSpeed;
			float _ReflectionsOpacity;
			float _ReflectionsScale;
			float _ReflectionsCutoff;
			float _EdgeOpacity;
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

			sampler2D _NoiseTexture;
			sampler2D _NormalMap;


			inline float4 ASE_ComputeGrabScreenPos( float4 pos )
			{
				#if UNITY_UV_STARTS_AT_TOP
				float scale = -1.0;
				#else
				float scale = 1.0;
				#endif
				float4 o = pos;
				o.y = pos.w * 0.5f;
				o.y = ( pos.y - o.y ) * _ProjectionParams.x * scale + o.y;
				return o;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float4 ase_clipPos = TransformObjectToHClip((v.positionOS).xyz);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				o.ase_texcoord2 = screenPos;
				float3 ase_worldPos = TransformObjectToWorld( (v.positionOS).xyz );
				float2 vertexToFrag366 = ( (ase_worldPos).xz * float2( 0.025,0.025 ) );
				o.ase_texcoord3.xy = vertexToFrag366;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.normalOS);
				o.ase_texcoord4.xyz = ase_worldNormal;
				float3 ase_worldTangent = TransformObjectToWorldDir(v.ase_tangent.xyz);
				o.ase_texcoord5.xyz = ase_worldTangent;
				float ase_vertexTangentSign = v.ase_tangent.w * ( unity_WorldTransformParams.w >= 0.0 ? 1.0 : -1.0 );
				float3 ase_worldBitangent = cross( ase_worldNormal, ase_worldTangent ) * ase_vertexTangentSign;
				o.ase_texcoord6.xyz = ase_worldBitangent;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord3.zw = 0;
				o.ase_texcoord4.w = 0;
				o.ase_texcoord5.w = 0;
				o.ase_texcoord6.w = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.positionOS.xyz = vertexValue;
				#else
					v.positionOS.xyz += vertexValue;
				#endif

				v.normalOS = v.normalOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( v.positionOS.xyz );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					o.positionWS = vertexInput.positionWS;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.positionCS = vertexInput.positionCS;

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 ase_tangent : TANGENT;

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
				o.vertex = v.positionOS;
				o.normalOS = v.normalOS;
				o.ase_tangent = v.ase_tangent;
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
				o.positionOS = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.positionOS.xyz - patch[i].normalOS * (dot(o.positionOS.xyz, patch[i].normalOS) - dot(patch[i].vertex.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				o.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.positionOS.xyz;
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
					float3 WorldPosition = IN.positionWS;
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
				float2 appendResult31 = (float2(( ase_screenPosNorm.x + 0.01 ) , ( ase_screenPosNorm.y + 0.01 )));
				float2 temp_cast_1 = (_ReflectionsScrollSpeed).xx;
				float2 vertexToFrag366 = IN.ase_texcoord3.xy;
				float2 GlobalUV368 = vertexToFrag366;
				float2 panner40 = ( 1.0 * _Time.y * temp_cast_1 + ( _ReflectionsScale * GlobalUV368 ));
				float Turbulence291 = ( UnpackNormalScale( tex2D( _NormalMap, panner40 ), 1.0f ).g * (0.0 + (_ReflectionsOpacity - 0.0) * (8.0 - 0.0) / (1.0 - 0.0)) );
				float4 lerpResult24 = lerp( ase_screenPosNorm , float4( appendResult31, 0.0 , 0.0 ) , Turbulence291);
				float4 Lighting2619 = ( 0.0 * tex2D( _NoiseTexture, lerpResult24.xy ) );
				float temp_output_608_0 = (-0.2 + (_SurfaceFoamScrollSpeed - -1.0) * (0.2 - -0.2) / (1.0 - -1.0));
				float2 temp_cast_3 = (temp_output_608_0).xx;
				float2 temp_output_495_0 = ( GlobalUV368 * (1.0 + (_SurfaceFoamScale - 0.0) * (10.0 - 1.0) / (40.0 - 0.0)) );
				float2 panner498 = ( 1.0 * _Time.y * temp_cast_3 + temp_output_495_0);
				float4 tex2DNode483 = tex2D( _NoiseTexture, panner498 );
				float lerpResult550 = lerp( step( tex2DNode483.r , 1.0 ) , ( 1.0 - tex2DNode483.r ) , 1.0);
				float2 temp_cast_4 = (temp_output_608_0).xx;
				float2 panner496 = ( -1.0 * _Time.y * temp_cast_4 + ( temp_output_495_0 * 0.777 ));
				float Foam487 = ( ( lerpResult550 * -tex2D( _NoiseTexture, panner496 ).r ) * -_SurfaceFoamIntensity );
				float4 temp_cast_5 = (Foam487).xxxx;
				float2 temp_cast_6 = (_RefractionScrollSpeed).xx;
				float2 temp_output_422_0 = ( GlobalUV368 * (1.0 + (_RefractionCutoffScale - 0.0) * (10.0 - 1.0) / (40.0 - 0.0)) );
				float2 panner423 = ( 1.0 * _Time.y * temp_cast_6 + temp_output_422_0);
				float3 unpack416 = UnpackNormalScale( tex2D( _NormalMap, panner423 ), 5.7 );
				unpack416.z = lerp( 1, unpack416.z, saturate(5.7) );
				float2 temp_cast_7 = (_RefractionScrollSpeed).xx;
				float2 panner470 = ( -1.0 * _Time.y * temp_cast_7 + temp_output_422_0);
				float3 unpack425 = UnpackNormalScale( tex2D( _NormalMap, panner470 ), 2.3 );
				unpack425.z = lerp( 1, unpack425.z, saturate(2.3) );
				float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( screenPos );
				float4 ase_grabScreenPosNorm = ase_grabScreenPos / ase_grabScreenPos.w;
				float4 fetchOpaqueVal668 = float4( SHADERGRAPH_SAMPLE_SCENE_COLOR( ( float4( ( (0.0 + (_RefractionIntensity - 0.0) * (0.4 - 0.0) / (1.0 - 0.0)) * BlendNormal( unpack416 , unpack425 ) ) , 0.0 ) + ase_grabScreenPosNorm ).xy ), 1.0 );
				float4 Refractions378 = fetchOpaqueVal668;
				float screenDepth163 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth163 = abs( ( screenDepth163 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( ( tex2D( _NoiseTexture, ( ( _EdgeFoamSpeed * _TimeParameters.x ) + ( GlobalUV368 * (30.0 + (_EdgeFoamScale - 0.0) * (1.0 - 30.0) / (1.0 - 0.0)) ) ) ).r * (0.0 + (_EdgeFoamDistance - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) );
				float clampResult208 = clamp( distanceDepth163 , 0.0 , 1.0 );
				float clampResult160 = clamp( pow( clampResult208 , (1.0 + (_EdgeFoamHardness - 0.0) * (10.0 - 1.0) / (1.0 - 0.0)) ) , 0.0 , 1.0 );
				float temp_output_156_0 = ( ( 1.0 - clampResult160 ) * _EdgeFoamOpacity );
				float screenDepth191 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth191 = abs( ( screenDepth191 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( (0.0 + (_EdgeFoamDistance - 0.0) * (15.0 - 0.0) / (1.0 - 0.0)) ) );
				float clampResult207 = clamp( distanceDepth191 , 0.0 , 1.0 );
				float EdgeFoamSpeed435 = _EdgeFoamSpeed;
				float EdgeFoam626 = ( temp_output_156_0 + ( ( 1.0 - clampResult207 ) * ( (0.0 + (_EdgeFoamOpacity - 0.0) * (0.85 - 0.0) / (1.0 - 0.0)) * tex2D( _NoiseTexture, ( ( _TimeParameters.x * EdgeFoamSpeed435 ) + ( (15.0 + (_EdgeFoamScale - 0.0) * (1.0 - 15.0) / (1.0 - 0.0)) * GlobalUV368 ) ) ).r ) ) );
				float screenDepth294 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth294 = abs( ( screenDepth294 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _OpacityDepth ) );
				float clampResult295 = clamp( distanceDepth294 , 0.0 , 1.0 );
				float clampResult299 = clamp( ( EdgeFoam626 + _Opacity + clampResult295 ) , 0.0 , 1.0 );
				float Opacity405 = clampResult299;
				float4 lerpResult462 = lerp( Refractions378 , _ShallowColor , Opacity405);
				float4 lerpResult473 = lerp( Refractions378 , _DeepColor , Opacity405);
				float screenDepth146 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth146 = abs( ( screenDepth146 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _ShallowColorDepth ) );
				float clampResult211 = clamp( distanceDepth146 , 0.0 , 1.0 );
				float4 lerpResult142 = lerp( lerpResult462 , lerpResult473 , clampResult211);
				float3 ase_worldViewDir = ( _WorldSpaceCameraPos.xyz - WorldPosition );
				ase_worldViewDir = normalize(ase_worldViewDir);
				float3 ase_worldNormal = IN.ase_texcoord4.xyz;
				float fresnelNdotV136 = dot( ase_worldNormal, ase_worldViewDir );
				float fresnelNode136 = ( 0.0 + 1.0 * pow( 1.0 - fresnelNdotV136, (0.0 + (_FresnelIntensity - 1.0) * (10.0 - 0.0) / (0.0 - 1.0)) ) );
				float clampResult209 = clamp( fresnelNode136 , 0.0 , 1.0 );
				float4 lerpResult133 = lerp( lerpResult142 , _FresnelColor , clampResult209);
				float4 WaterColor622 = lerpResult133;
				float4 blendOpSrc502 = temp_cast_5;
				float4 blendOpDest502 = WaterColor622;
				float4 blendOpSrc300 = Lighting2619;
				float4 blendOpDest300 = ( blendOpSrc502 + blendOpDest502 );
				float EdgeFoamBlend629 = temp_output_156_0;
				float3 temp_cast_10 = (1.0).xxx;
				float ase_lightIntensity = max( max( _MainLightColor.r, _MainLightColor.g ), _MainLightColor.b );
				float4 ase_lightColor = float4( _MainLightColor.rgb / ase_lightIntensity, ase_lightIntensity );
				float3 lerpResult7 = lerp( temp_cast_10 , ase_lightColor.rgb , 1.0);
				float3 normalizeResult232 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float2 temp_cast_12 = (_ReflectionsCutoffScrollSpeed).xx;
				float2 panner342 = ( 1.0 * _Time.y * temp_cast_12 + ( GlobalUV368 * (2.0 + (_ReflectionsCutoffScale - 0.0) * (10.0 - 2.0) / (10.0 - 0.0)) ));
				float3 ase_worldTangent = IN.ase_texcoord5.xyz;
				float3 ase_worldBitangent = IN.ase_texcoord6.xyz;
				float3 tanToWorld0 = float3( ase_worldTangent.x, ase_worldBitangent.x, ase_worldNormal.x );
				float3 tanToWorld1 = float3( ase_worldTangent.y, ase_worldBitangent.y, ase_worldNormal.y );
				float3 tanToWorld2 = float3( ase_worldTangent.z, ase_worldBitangent.z, ase_worldNormal.z );
				float3 tanNormal215 = UnpackNormalScale( tex2D( _NormalMap, panner342 ), 1.0f );
				float3 worldNormal215 = float3(dot(tanToWorld0,tanNormal215), dot(tanToWorld1,tanNormal215), dot(tanToWorld2,tanNormal215));
				float dotResult108 = dot( reflect( -normalizeResult232 , worldNormal215 ) , _MainLightPosition.xyz );
				float3 clampResult120 = clamp( ( ( pow( dotResult108 , exp( (0.0 + (_ReflectionsCutoff - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) * ase_lightColor.rgb ) * Turbulence291 ) , float3( 0,0,0 ) , float3( 1,1,1 ) );
				float3 ReflexionsCutoff612 = clampResult120;
				
				float screenDepth665 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth665 = abs( ( screenDepth665 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeOpacity ) );
				

				float3 BaseColor = ( ( ( ( blendOpSrc300 + blendOpDest300 ) + ( EdgeFoamBlend629 * _EdgeFoamColor ) + ( _EdgeFoamColor * EdgeFoam626 ) ) * float4( lerpResult7 , 0.0 ) ) + float4( ReflexionsCutoff612 , 0.0 ) ).rgb;
				float Alpha = ( clampResult299 * saturate( distanceDepth665 ) );
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
			Tags { "LightMode"="DepthNormalsOnly" }

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
			#define _EMISSION
			#define ASE_SRP_VERSION 140007
			#define REQUIRE_DEPTH_TEXTURE 1


			

			

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

			

			

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#define ASE_NEEDS_FRAG_SCREEN_POSITION


			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE) && (SHADER_TARGET >= 45)
				#define ASE_SV_DEPTH SV_DepthLessEqual
				#define ASE_SV_POSITION_QUALIFIERS linear noperspective centroid
			#else
				#define ASE_SV_DEPTH SV_Depth
				#define ASE_SV_POSITION_QUALIFIERS
			#endif

			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				ASE_SV_POSITION_QUALIFIERS float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
				float4 worldTangent : TEXCOORD2;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 positionWS : TEXCOORD3;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD4;
				#endif
				float4 ase_texcoord5 : TEXCOORD5;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EdgeFoamColor;
			float4 _FresnelColor;
			float4 _DeepColor;
			float4 _ShallowColor;
			float _ReflectionsScrollSpeed;
			float _ReflectionsCutoffScale;
			float _ReflectionsCutoffScrollSpeed;
			float _FresnelIntensity;
			float _ShallowColorDepth;
			float _OpacityDepth;
			float _Opacity;
			float _EdgeFoamOpacity;
			float _EdgeFoamHardness;
			float _EdgeFoamDistance;
			float _EdgeFoamScale;
			float _EdgeFoamSpeed;
			float _RefractionCutoffScale;
			float _RefractionScrollSpeed;
			float _RefractionIntensity;
			float _SurfaceFoamIntensity;
			float _SurfaceFoamScale;
			float _SurfaceFoamScrollSpeed;
			float _ReflectionsOpacity;
			float _ReflectionsScale;
			float _ReflectionsCutoff;
			float _EdgeOpacity;
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

			sampler2D _NoiseTexture;


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 ase_worldPos = TransformObjectToWorld( (v.positionOS).xyz );
				float2 vertexToFrag366 = ( (ase_worldPos).xz * float2( 0.025,0.025 ) );
				o.ase_texcoord5.xy = vertexToFrag366;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord5.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.positionOS.xyz = vertexValue;
				#else
					v.positionOS.xyz += vertexValue;
				#endif

				v.normalOS = v.normalOS;
				v.tangentOS = v.tangentOS;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( v.positionOS.xyz );

				float3 normalWS = TransformObjectToWorldNormal( v.normalOS );
				float4 tangentWS = float4( TransformObjectToWorldDir( v.tangentOS.xyz ), v.tangentOS.w );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					o.positionWS = vertexInput.positionWS;
				#endif

				o.worldNormal = normalWS;
				o.worldTangent = tangentWS;

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.positionCS = vertexInput.positionCS;
				o.clipPosV = vertexInput.positionCS;
				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 tangentOS : TANGENT;
				
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
				o.vertex = v.positionOS;
				o.normalOS = v.normalOS;
				o.tangentOS = v.tangentOS;
				
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
				o.positionOS = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				o.tangentOS = patch[0].tangentOS * bary.x + patch[1].tangentOS * bary.y + patch[2].tangentOS * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.positionOS.xyz - patch[i].normalOS * (dot(o.positionOS.xyz, patch[i].normalOS) - dot(patch[i].vertex.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				o.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.positionOS.xyz;
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

			void frag(	VertexOutput IN
						, out half4 outNormalWS : SV_Target0
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						#ifdef _WRITE_RENDERING_LAYERS
						, out float4 outRenderingLayers : SV_Target1
						#endif
						 )
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 WorldPosition = IN.positionWS;
				#endif

				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				float3 WorldNormal = IN.worldNormal;
				float4 WorldTangent = IN.worldTangent;

				float4 ClipPos = IN.clipPosV;
				float4 ScreenPos = ComputeScreenPos( IN.clipPosV );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float4 ase_screenPosNorm = ScreenPos / ScreenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float2 vertexToFrag366 = IN.ase_texcoord5.xy;
				float2 GlobalUV368 = vertexToFrag366;
				float screenDepth163 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth163 = abs( ( screenDepth163 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( ( tex2D( _NoiseTexture, ( ( _EdgeFoamSpeed * _TimeParameters.x ) + ( GlobalUV368 * (30.0 + (_EdgeFoamScale - 0.0) * (1.0 - 30.0) / (1.0 - 0.0)) ) ) ).r * (0.0 + (_EdgeFoamDistance - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) );
				float clampResult208 = clamp( distanceDepth163 , 0.0 , 1.0 );
				float clampResult160 = clamp( pow( clampResult208 , (1.0 + (_EdgeFoamHardness - 0.0) * (10.0 - 1.0) / (1.0 - 0.0)) ) , 0.0 , 1.0 );
				float temp_output_156_0 = ( ( 1.0 - clampResult160 ) * _EdgeFoamOpacity );
				float screenDepth191 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth191 = abs( ( screenDepth191 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( (0.0 + (_EdgeFoamDistance - 0.0) * (15.0 - 0.0) / (1.0 - 0.0)) ) );
				float clampResult207 = clamp( distanceDepth191 , 0.0 , 1.0 );
				float EdgeFoamSpeed435 = _EdgeFoamSpeed;
				float EdgeFoam626 = ( temp_output_156_0 + ( ( 1.0 - clampResult207 ) * ( (0.0 + (_EdgeFoamOpacity - 0.0) * (0.85 - 0.0) / (1.0 - 0.0)) * tex2D( _NoiseTexture, ( ( _TimeParameters.x * EdgeFoamSpeed435 ) + ( (15.0 + (_EdgeFoamScale - 0.0) * (1.0 - 15.0) / (1.0 - 0.0)) * GlobalUV368 ) ) ).r ) ) );
				float screenDepth294 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth294 = abs( ( screenDepth294 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _OpacityDepth ) );
				float clampResult295 = clamp( distanceDepth294 , 0.0 , 1.0 );
				float clampResult299 = clamp( ( EdgeFoam626 + _Opacity + clampResult295 ) , 0.0 , 1.0 );
				float screenDepth665 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth665 = abs( ( screenDepth665 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeOpacity ) );
				

				float3 Normal = float3(0, 0, 1);
				float Alpha = ( clampResult299 * saturate( distanceDepth665 ) );
				float AlphaClipThreshold = 0.5;

				#ifdef ASE_DEPTH_WRITE_ON
					float DepthValue = IN.positionCS.z;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#if defined(LOD_FADE_CROSSFADE)
					LODFadeCrossFade( IN.positionCS );
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
					outRenderingLayers = float4( EncodeMeshRenderingLayer( renderingLayers ), 0, 0, 0 );
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
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _EMISSION
			#define ASE_SRP_VERSION 140007
			#define REQUIRE_DEPTH_TEXTURE 1


			

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

			

			

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			
            #if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			

			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 positionCS : SV_POSITION;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EdgeFoamColor;
			float4 _FresnelColor;
			float4 _DeepColor;
			float4 _ShallowColor;
			float _ReflectionsScrollSpeed;
			float _ReflectionsCutoffScale;
			float _ReflectionsCutoffScrollSpeed;
			float _FresnelIntensity;
			float _ShallowColorDepth;
			float _OpacityDepth;
			float _Opacity;
			float _EdgeFoamOpacity;
			float _EdgeFoamHardness;
			float _EdgeFoamDistance;
			float _EdgeFoamScale;
			float _EdgeFoamSpeed;
			float _RefractionCutoffScale;
			float _RefractionScrollSpeed;
			float _RefractionIntensity;
			float _SurfaceFoamIntensity;
			float _SurfaceFoamScale;
			float _SurfaceFoamScrollSpeed;
			float _ReflectionsOpacity;
			float _ReflectionsScale;
			float _ReflectionsCutoff;
			float _EdgeOpacity;
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

			sampler2D _NoiseTexture;


			
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

				float4 ase_clipPos = TransformObjectToHClip((v.positionOS).xyz);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				o.ase_texcoord = screenPos;
				float3 ase_worldPos = TransformObjectToWorld( (v.positionOS).xyz );
				float2 vertexToFrag366 = ( (ase_worldPos).xz * float2( 0.025,0.025 ) );
				o.ase_texcoord1.xy = vertexToFrag366;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.positionOS.xyz = vertexValue;
				#else
					v.positionOS.xyz += vertexValue;
				#endif

				v.normalOS = v.normalOS;

				float3 positionWS = TransformObjectToWorld( v.positionOS.xyz );

				o.positionCS = TransformWorldToHClip(positionWS);

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				
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
				o.vertex = v.positionOS;
				o.normalOS = v.normalOS;
				
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
				o.positionOS = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.positionOS.xyz - patch[i].normalOS * (dot(o.positionOS.xyz, patch[i].normalOS) - dot(patch[i].vertex.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				o.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.positionOS.xyz;
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

				float4 screenPos = IN.ase_texcoord;
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float2 vertexToFrag366 = IN.ase_texcoord1.xy;
				float2 GlobalUV368 = vertexToFrag366;
				float screenDepth163 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth163 = abs( ( screenDepth163 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( ( tex2D( _NoiseTexture, ( ( _EdgeFoamSpeed * _TimeParameters.x ) + ( GlobalUV368 * (30.0 + (_EdgeFoamScale - 0.0) * (1.0 - 30.0) / (1.0 - 0.0)) ) ) ).r * (0.0 + (_EdgeFoamDistance - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) );
				float clampResult208 = clamp( distanceDepth163 , 0.0 , 1.0 );
				float clampResult160 = clamp( pow( clampResult208 , (1.0 + (_EdgeFoamHardness - 0.0) * (10.0 - 1.0) / (1.0 - 0.0)) ) , 0.0 , 1.0 );
				float temp_output_156_0 = ( ( 1.0 - clampResult160 ) * _EdgeFoamOpacity );
				float screenDepth191 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth191 = abs( ( screenDepth191 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( (0.0 + (_EdgeFoamDistance - 0.0) * (15.0 - 0.0) / (1.0 - 0.0)) ) );
				float clampResult207 = clamp( distanceDepth191 , 0.0 , 1.0 );
				float EdgeFoamSpeed435 = _EdgeFoamSpeed;
				float EdgeFoam626 = ( temp_output_156_0 + ( ( 1.0 - clampResult207 ) * ( (0.0 + (_EdgeFoamOpacity - 0.0) * (0.85 - 0.0) / (1.0 - 0.0)) * tex2D( _NoiseTexture, ( ( _TimeParameters.x * EdgeFoamSpeed435 ) + ( (15.0 + (_EdgeFoamScale - 0.0) * (1.0 - 15.0) / (1.0 - 0.0)) * GlobalUV368 ) ) ).r ) ) );
				float screenDepth294 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth294 = abs( ( screenDepth294 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _OpacityDepth ) );
				float clampResult295 = clamp( distanceDepth294 , 0.0 , 1.0 );
				float clampResult299 = clamp( ( EdgeFoam626 + _Opacity + clampResult295 ) , 0.0 , 1.0 );
				float screenDepth665 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth665 = abs( ( screenDepth665 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeOpacity ) );
				

				surfaceDescription.Alpha = ( clampResult299 * saturate( distanceDepth665 ) );
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
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define _EMISSION
			#define ASE_SRP_VERSION 140007
			#define REQUIRE_DEPTH_TEXTURE 1


			

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

			

			

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			
            #if ASE_SRP_VERSION >=140007
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#endif
		

			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			

			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 positionCS : SV_POSITION;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EdgeFoamColor;
			float4 _FresnelColor;
			float4 _DeepColor;
			float4 _ShallowColor;
			float _ReflectionsScrollSpeed;
			float _ReflectionsCutoffScale;
			float _ReflectionsCutoffScrollSpeed;
			float _FresnelIntensity;
			float _ShallowColorDepth;
			float _OpacityDepth;
			float _Opacity;
			float _EdgeFoamOpacity;
			float _EdgeFoamHardness;
			float _EdgeFoamDistance;
			float _EdgeFoamScale;
			float _EdgeFoamSpeed;
			float _RefractionCutoffScale;
			float _RefractionScrollSpeed;
			float _RefractionIntensity;
			float _SurfaceFoamIntensity;
			float _SurfaceFoamScale;
			float _SurfaceFoamScrollSpeed;
			float _ReflectionsOpacity;
			float _ReflectionsScale;
			float _ReflectionsCutoff;
			float _EdgeOpacity;
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

			sampler2D _NoiseTexture;


			
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

				float4 ase_clipPos = TransformObjectToHClip((v.positionOS).xyz);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				o.ase_texcoord = screenPos;
				float3 ase_worldPos = TransformObjectToWorld( (v.positionOS).xyz );
				float2 vertexToFrag366 = ( (ase_worldPos).xz * float2( 0.025,0.025 ) );
				o.ase_texcoord1.xy = vertexToFrag366;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord1.zw = 0;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.positionOS.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif

				float3 vertexValue = defaultVertexValue;

				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.positionOS.xyz = vertexValue;
				#else
					v.positionOS.xyz += vertexValue;
				#endif

				v.normalOS = v.normalOS;

				float3 positionWS = TransformObjectToWorld( v.positionOS.xyz );
				o.positionCS = TransformWorldToHClip(positionWS);

				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				
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
				o.vertex = v.positionOS;
				o.normalOS = v.normalOS;
				
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
				o.positionOS = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.normalOS = patch[0].normalOS * bary.x + patch[1].normalOS * bary.y + patch[2].normalOS * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.positionOS.xyz - patch[i].normalOS * (dot(o.positionOS.xyz, patch[i].normalOS) - dot(patch[i].vertex.xyz, patch[i].normalOS));
				float phongStrength = _TessPhongStrength;
				o.positionOS.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.positionOS.xyz;
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

				float4 screenPos = IN.ase_texcoord;
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float2 vertexToFrag366 = IN.ase_texcoord1.xy;
				float2 GlobalUV368 = vertexToFrag366;
				float screenDepth163 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth163 = abs( ( screenDepth163 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( ( tex2D( _NoiseTexture, ( ( _EdgeFoamSpeed * _TimeParameters.x ) + ( GlobalUV368 * (30.0 + (_EdgeFoamScale - 0.0) * (1.0 - 30.0) / (1.0 - 0.0)) ) ) ).r * (0.0 + (_EdgeFoamDistance - 0.0) * (10.0 - 0.0) / (1.0 - 0.0)) ) ) );
				float clampResult208 = clamp( distanceDepth163 , 0.0 , 1.0 );
				float clampResult160 = clamp( pow( clampResult208 , (1.0 + (_EdgeFoamHardness - 0.0) * (10.0 - 1.0) / (1.0 - 0.0)) ) , 0.0 , 1.0 );
				float temp_output_156_0 = ( ( 1.0 - clampResult160 ) * _EdgeFoamOpacity );
				float screenDepth191 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth191 = abs( ( screenDepth191 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( (0.0 + (_EdgeFoamDistance - 0.0) * (15.0 - 0.0) / (1.0 - 0.0)) ) );
				float clampResult207 = clamp( distanceDepth191 , 0.0 , 1.0 );
				float EdgeFoamSpeed435 = _EdgeFoamSpeed;
				float EdgeFoam626 = ( temp_output_156_0 + ( ( 1.0 - clampResult207 ) * ( (0.0 + (_EdgeFoamOpacity - 0.0) * (0.85 - 0.0) / (1.0 - 0.0)) * tex2D( _NoiseTexture, ( ( _TimeParameters.x * EdgeFoamSpeed435 ) + ( (15.0 + (_EdgeFoamScale - 0.0) * (1.0 - 15.0) / (1.0 - 0.0)) * GlobalUV368 ) ) ).r ) ) );
				float screenDepth294 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth294 = abs( ( screenDepth294 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _OpacityDepth ) );
				float clampResult295 = clamp( distanceDepth294 , 0.0 , 1.0 );
				float clampResult299 = clamp( ( EdgeFoam626 + _Opacity + clampResult295 ) , 0.0 , 1.0 );
				float screenDepth665 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth665 = abs( ( screenDepth665 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _EdgeOpacity ) );
				

				surfaceDescription.Alpha = ( clampResult299 * saturate( distanceDepth665 ) );
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
	
	Fallback Off
}
/*ASEBEGIN
Version=19603
Node;AmplifyShaderEditor.CommentaryNode;372;1394.915,-4196.619;Inherit;False;844.5542;236.5325;Global UV's;4;363;364;365;366;Global UV's;1,1,1,1;0;0
Node;AmplifyShaderEditor.WorldPosInputsNode;363;1444.915,-4145.087;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SwizzleNode;364;1651.666,-4145.532;Inherit;False;FLOAT2;0;2;2;2;1;0;FLOAT3;0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;365;1824.871,-4145.92;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0.025,0.025;False;1;FLOAT2;0
Node;AmplifyShaderEditor.VertexToFragmentNode;366;1997.468,-4146.618;Inherit;False;False;False;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;631;1403.001,-2070.273;Inherit;False;3315.78;661.7512;EdgeFoam;40;183;374;180;177;327;175;176;172;174;433;325;170;167;435;163;162;437;198;373;332;324;208;335;196;197;158;191;161;434;195;334;207;193;160;189;157;188;156;185;186;EdgeFoam;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;368;2297.268,-4147.682;Inherit;False;GlobalUV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;183;1453.001,-1581.784;Float;False;Property;_EdgeFoamScale;Edge Foam Scale;15;0;Create;True;0;0;0;False;0;False;0.2;0.907;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;374;1778.808,-1821.333;Inherit;False;368;GlobalUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleTimeNode;180;1682.296,-1904.183;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;177;1682.298,-1995.783;Float;False;Property;_EdgeFoamSpeed;Edge Foam Speed;16;0;Create;True;0;0;0;False;0;False;0.125;0.017;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;327;1779.221,-1744.231;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;30;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;173;1872.842,-4449.66;Float;True;Property;_NoiseTexture;Noise Texture;27;0;Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;175;2005.488,-1928.484;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;176;2004.795,-1821.884;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;431;2119.558,-4448.989;Inherit;False;NoiseMap;-1;True;1;0;SAMPLER2D;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.RangedFloatNode;172;2414.085,-1752.975;Float;False;Property;_EdgeFoamDistance;Edge Foam Distance;13;0;Create;True;0;0;0;False;0;False;1;0.15;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;174;2244.092,-1929.584;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;433;2219.438,-2014.354;Inherit;False;431;NoiseMap;1;0;OBJECT;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.TFHCRemapNode;325;2753.037,-1895.265;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;170;2408.664,-2015.278;Inherit;True;Property;_TextureSample3;Texture Sample 3;32;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;167;3029.252,-1995.603;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;435;2003.849,-2015.103;Inherit;False;EdgeFoamSpeed;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DepthFade;163;3207.802,-2020.012;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;162;2970.003,-1878.812;Float;False;Property;_EdgeFoamHardness;Edge Foam Hardness;12;0;Create;True;0;0;0;False;0;False;0.33;0.142;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;437;2687.507,-1610.817;Inherit;False;435;EdgeFoamSpeed;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;198;2717.701,-1700.222;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;373;2484.411,-1522.731;Inherit;False;368;GlobalUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TFHCRemapNode;332;2289.757,-1617.522;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;15;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;324;3301.299,-1909.817;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;1;False;4;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;208;3484.735,-2020.273;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;335;3092.653,-1792.669;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;15;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;196;2922.375,-1656.482;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;197;2922.373,-1545.83;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;158;3658.348,-1906.567;Float;False;Property;_EdgeFoamOpacity;Edge Foam Opacity;14;0;Create;True;0;0;0;False;0;False;0.65;0.075;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.DepthFade;191;3496.722,-1816.385;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;161;3788.302,-2019.112;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;434;3422.046,-1680.288;Inherit;False;431;NoiseMap;1;0;OBJECT;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.SimpleAddOpNode;195;3304.423,-1655.444;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ClampOpNode;207;3784.348,-1815.567;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;193;3651.8,-1679.212;Inherit;True;Property;_TextureSample4;Texture Sample 4;38;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.TFHCRemapNode;334;3990.347,-1735.567;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;0.85;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;160;4015.9,-1929.812;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;189;4195.001,-1814.085;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;157;4195.628,-1927.829;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;188;4193.796,-1735.743;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;156;4384.972,-1927.418;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;185;4383.386,-1816.352;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;186;4572.783,-1840.485;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;293;-1141.481,-1118.849;Float;False;Property;_OpacityDepth;Opacity Depth;7;0;Create;True;0;0;0;False;0;False;6.5;24.89;0;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;626;4754.541,-1841.351;Inherit;False;EdgeFoam;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DepthFade;294;-819.0759,-1143.404;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;296;-821.3647,-1234.603;Float;False;Property;_Opacity;Opacity;6;0;Create;True;0;0;0;False;0;False;1;0.53;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;295;-528.3999,-1171.153;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;627;-542.9607,-1263.318;Inherit;False;626;EdgeFoam;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;664;-836.1891,-1021.583;Inherit;False;Property;_EdgeOpacity;Edge Opacity;5;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;297;-351.3645,-1257.933;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DepthFade;665;-480.1484,-1043.725;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;615;1397.09,-590.3231;Inherit;False;2912.429;589.1261;Reflections Cutoff;26;107;120;117;505;115;116;242;232;218;428;342;231;230;234;108;106;104;103;109;215;341;340;228;370;344;339;Reflections Cutoff;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;507;1397.34,-1230.91;Inherit;False;1322.382;460.061;Turbulence;10;39;37;336;38;427;40;42;371;247;43;Turbulence;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;621;1398.495,-3857.467;Inherit;False;1432.128;792.9407;Lighting;19;93;94;614;376;91;87;95;90;329;250;304;432;24;26;31;27;28;292;29;Lighting;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;474;1395.82,126.7491;Inherit;False;2421.923;476.1914;Refractions;17;416;425;407;398;392;399;394;470;439;423;421;422;419;420;418;611;668;Refractions;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;605;1402.267,704.1461;Inherit;False;2405.97;488.6509;Surface Foam;22;494;497;482;483;478;551;552;550;554;476;555;475;498;496;557;556;493;492;491;495;606;608;Surface Foam;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;624;1405.082,-2982.796;Inherit;False;1244.43;749.1476;WaterColor;18;133;473;211;135;136;323;209;137;146;150;145;462;142;144;402;406;472;471;WaterColor;1,1,1,1;0;0
Node;AmplifyShaderEditor.ClampOpNode;299;-197.1057,-1258.663;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;666;-190.7188,-1095.917;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;45;1397.173,-4450.278;Float;True;Property;_NormalMap;Normal Map;26;1;[Normal];Create;True;0;0;0;False;0;False;None;None;True;bump;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RegisterLocalVarNode;426;1642.45,-4450.488;Inherit;False;NormalMap;-1;True;1;0;SAMPLER2D;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.RangedFloatNode;339;1447.09,-238.5895;Float;False;Property;_ReflectionsCutoffScale;Reflections Cutoff Scale;21;0;Create;True;0;0;0;False;0;False;3;2.15;1;40;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;370;1766.302,-323.0511;Inherit;False;368;GlobalUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TFHCRemapNode;344;1765.224,-238.2081;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;10;False;3;FLOAT;2;False;4;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceCameraPos;230;2223.982,-540.3228;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;341;2046.978,-259.461;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;340;1954.061,-139.0246;Float;False;Property;_ReflectionsCutoffScrollSpeed;Reflections Cutoff Scroll Speed;22;0;Create;True;0;0;0;False;0;False;-0.025;0.03;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;228;2041.272,-422.3221;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.GetLocalVarNode;371;1500.764,-1029.615;Inherit;False;368;GlobalUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;43;1448.907,-1106.275;Float;False;Property;_ReflectionsScale;Reflections Scale;18;0;Create;True;0;0;0;False;0;False;4.8;8.3;1;40;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;428;2261.608,-337.0813;Inherit;False;426;NormalMap;1;0;OBJECT;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.PannerNode;342;2260.071,-254.0279;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,0.1;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;231;2557.771,-445.4329;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;247;1447.34,-942.994;Float;False;Property;_ReflectionsScrollSpeed;Reflections Scroll Speed;19;0;Create;True;0;0;0;False;0;False;-1;-0.028;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;1756.286,-1107.647;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.NormalizeNode;232;2842.04,-416.6785;Inherit;False;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;218;2488.033,-336.4475;Inherit;True;Property;_TextureSample5;Texture Sample 5;40;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;38;1961.923,-979.8053;Float;False;Property;_ReflectionsOpacity;Reflections Opacity;17;0;Create;True;0;0;0;False;0;False;0.65;0.085;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;40;1931.38,-1107.214;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,0.1;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;427;1933.075,-1180.582;Inherit;False;426;NormalMap;1;0;OBJECT;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.NegateNode;242;3037.51,-416.3245;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;103;2891.405,-119.5714;Float;False;Property;_ReflectionsCutoff;Reflections Cutoff;20;0;Create;True;0;0;0;False;0;False;0.35;0.22;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;215;2790.225,-334.0784;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TFHCRemapNode;336;2259.732,-979.8444;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;8;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;39;2203.256,-1181.943;Inherit;True;Property;_TextureSample0;Texture Sample 0;7;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.ReflectOpNode;234;3223.294,-410.9876;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TFHCRemapNode;104;3228.605,-210.1964;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceLightDirHlpNode;109;2982.695,-272.8159;Inherit;False;False;1;0;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;2541.723,-1134.128;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DotProductOpNode;108;3424.693,-374.8152;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ExpOpNode;106;3422.604,-266.1964;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;291;2767.71,-1134.111;Inherit;False;Turbulence;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;107;3582.693,-352.8162;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LightColorNode;116;3583.664,-232.0431;Inherit;False;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.GetLocalVarNode;505;3763.005,-181.69;Inherit;False;291;Turbulence;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;115;3792.663,-291.041;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;117;3958.693,-246.2604;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ClampOpNode;120;4131.524,-246.2799;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;1,1,1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;612;4377.008,-251.5557;Inherit;False;ReflexionsCutoff;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LightAttenuation;94;2103.804,-3585.27;Inherit;False;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;376;1955.803,-3768.27;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LightColorNode;93;2169.803,-3719.27;Inherit;False;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.GetLocalVarNode;614;2184.803,-3810.27;Inherit;False;612;ReflexionsCutoff;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode;95;2423.803,-3601.27;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;91;2423.803,-3697.27;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;87;2423.803,-3793.27;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT2;0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;90;2631.804,-3745.27;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;616;2889.047,-3744.813;Inherit;False;Lighting1;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TFHCRemapNode;419;1742.559,279.9692;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;40;False;3;FLOAT;1;False;4;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;420;1742.949,197.9581;Inherit;False;368;GlobalUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;422;1947.298,201.6361;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;439;2170.142,336.104;Inherit;False;426;NormalMap;1;0;OBJECT;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.PannerNode;470;2171.124,418.278;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,0.1;False;1;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;423;2167.392,200.069;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,0.1;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;416;2401.042,176.7491;Inherit;True;Property;_TextureSample7;Texture Sample 5;27;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;5.7;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SamplerNode;425;2401.487,375.9399;Inherit;True;Property;_TextureSample8;Texture Sample 5;27;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;2.3;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.BlendNormalsNode;407;2792.894,294.4081;Inherit;False;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TFHCRemapNode;611;3042.084,168.6961;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;0.4;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;493;1762.396,772.2692;Inherit;False;368;GlobalUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TFHCRemapNode;492;1762.006,863.2809;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;40;False;3;FLOAT;1;False;4;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;494;1729.829,1066.644;Float;False;Property;_SurfaceFoamScrollSpeed;Surface Foam Scroll Speed;9;0;Create;True;0;0;0;False;0;False;-0.025;-0.15;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;392;3277.708,271.1711;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;495;1974.743,815.9459;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TFHCRemapNode;608;2148.726,993.7018;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;-1;False;2;FLOAT;1;False;3;FLOAT;-0.2;False;4;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;557;1975.424,934.3608;Inherit;False;Constant;_Scale;Scale;33;0;Create;True;0;0;0;False;0;False;0.777;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;394;3475.048,270.8542;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.GetLocalVarNode;497;2378.587,915.4149;Inherit;False;431;NoiseMap;1;0;OBJECT;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.PannerNode;498;2375.837,779.3781;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,0.1;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;556;2166.425,880.3607;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;483;2614.947,754.1461;Inherit;True;Property;_TextureSample6;Texture Sample 4;32;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Instance;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.PannerNode;496;2379.569,997.5868;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.1,0.1;False;1;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;482;2940.429,852.1158;Float;False;Constant;_Step;Step;2;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;378;3865.706,270.4731;Float;False;Refractions;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;26;1448.495,-3446.55;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;29;1479.251,-3183.528;Float;False;Constant;_Float2;Float 2;5;0;Create;True;0;0;0;False;0;False;0.01;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;137;1493.971,-2445.688;Float;False;Property;_FresnelIntensity;Fresnel Intensity;4;0;Create;True;0;0;0;False;0;False;0.4;0.4;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;405;58.79691,-1306.015;Inherit;False;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;150;1455.082,-2530.878;Float;False;Property;_ShallowColorDepth;Shallow Color Depth;2;0;Create;True;0;0;0;False;0;False;2.75;15.8;0;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;552;2612.764,965.7958;Inherit;True;Property;_TextureSample9;Texture Sample 4;32;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Instance;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.StepOpNode;478;3154.962,778.2291;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;551;2940.776,930.1139;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;27;1672.251,-3316.528;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;28;1673.251,-3201.529;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;323;1804.295,-2445.318;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.DepthFade;146;1760.964,-2556.355;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;145;1519.309,-2714.145;Float;False;Property;_DeepColor;Deep Color;1;0;Create;True;0;0;0;False;0;False;0,0.3333333,0.8509804,1;0.128649,0.4622641,0.4402676,1;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.ColorNode;144;1521.294,-2913.29;Float;False;Property;_ShallowColor;Shallow Color;0;0;Create;True;0;0;0;False;0;False;0,0.6117647,1,1;0.3290761,0.8207547,0.7458953,1;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.GetLocalVarNode;402;1802.02,-2932.796;Inherit;False;378;Refractions;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;406;1801.526,-2832.393;Inherit;False;405;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;472;1802.18,-2739.055;Inherit;False;378;Refractions;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;471;1803.672,-2639.254;Inherit;False;405;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;476;2941.378,1092.658;Float;False;Property;_SurfaceFoamIntensity;Surface Foam Intensity;8;0;Create;True;0;0;0;False;0;False;0.05;-0.25;-0.4;0.4;0;1;FLOAT;0
Node;AmplifyShaderEditor.NegateNode;554;2940.741,1009.826;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;550;3290.776,848.1149;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;31;1801.251,-3315.528;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;292;1804.721,-3196.852;Inherit;False;291;Turbulence;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;473;2039.427,-2732.656;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;211;2034.707,-2588.117;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.FresnelNode;136;2023.71,-2442.647;Inherit;False;Standard;WorldNormal;ViewDir;False;False;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;462;2038.67,-2904.389;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;555;3464.741,890.8258;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NegateNode;606;3462.342,1029.451;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;432;2074.844,-3416.326;Inherit;False;431;NoiseMap;1;0;OBJECT;;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.LerpOp;24;2107.045,-3333.332;Inherit;False;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ColorNode;135;2211.401,-2628.943;Float;False;Property;_FresnelColor;Fresnel Color;3;0;Create;True;0;0;0;False;0;False;0.8313726,0.8313726,0.8313726,1;0.545098,0.8527418,0.8588235,1;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.ClampOpNode;209;2266.447,-2443.123;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;142;2238.433,-2757.585;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;475;3630.24,939.5538;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;250;2285.309,-3416.643;Inherit;True;Property;_TextureSample1;Texture Sample 1;28;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;304;2423.803,-3489.27;Float;False;Constant;_Float4;Float 4;3;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;133;2471.511,-2649.12;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;487;3864.705,939.1221;Inherit;False;Foam;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;329;2663.804,-3441.27;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;622;2668.231,-2649.21;Inherit;False;WaterColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;629;4754.471,-1928.355;Inherit;False;EdgeFoamBlend;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;619;2889.047,-3440.813;Inherit;False;Lighting2;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;625;-1093.289,-1911.237;Inherit;False;622;WaterColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;508;-1092.613,-2000.19;Inherit;False;487;Foam;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;155;-819.552,-1791.3;Float;False;Property;_EdgeFoamColor;Edge Foam Color;11;0;Create;True;0;0;0;False;0;False;1,1,1,1;0.749199,0.8319869,0.8679245,1;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.BlendOpsNode;502;-821.8883,-1935.463;Inherit;False;LinearDodge;False;3;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;620;-790.4379,-2029.154;Inherit;False;619;Lighting2;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;630;-596.5209,-1873.549;Inherit;False;629;EdgeFoamBlend;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;628;-595.2843,-1701.629;Inherit;False;626;EdgeFoam;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.BlendOpsNode;300;-474.2447,-2011.072;Inherit;False;LinearDodge;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;153;-353.1398,-1873.521;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;184;-353.0648,-1760.878;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LightColorNode;10;-692.8977,-1437.913;Inherit;False;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;11;-511.0608,-1339.243;Float;False;Constant;_LightColorInfluence;Light Color Influence;17;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-383.8984,-1461.913;Float;False;Constant;_Float0;Float 0;1;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;12;-164.1463,-1897.206;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;7;-198.1302,-1438.161;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;123.654,-1675.305;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT3;0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;613;59.11874,-1395.322;Inherit;False;612;ReflexionsCutoff;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;3;388.2482,-1550.308;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT3;0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;667;62.3346,-1216.118;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenColorNode;668;3631.398,270.2554;Inherit;False;Global;_GrabScreen0;Grab Screen 0;12;0;Create;True;0;0;0;False;0;False;Object;-1;False;False;False;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GrabScreenPosition;399;3149.36,395.3168;Inherit;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;617;383.2409,-1209.288;Inherit;False;616;Lighting1;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;679;524.5515,-1346.168;Inherit;False;Constant;_Float1;Float 1;32;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;491;1452.267,863.9088;Float;False;Property;_SurfaceFoamScale;Surface Foam Scale;10;0;Create;True;0;0;0;False;0;False;1;3.9;0;40;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;398;2733.381,175.223;Float;False;Property;_RefractionIntensity;Refraction Intensity;23;0;Create;True;0;0;0;False;0;False;0.1;0.1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;418;1445.82,282.5991;Float;False;Property;_RefractionCutoffScale;Refraction Cutoff Scale;25;0;Create;True;0;0;0;False;0;False;1;1;0;40;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;421;1822.383,460.3339;Float;False;Property;_RefractionScrollSpeed;Refraction Scroll Speed;24;0;Create;True;0;0;0;False;0;False;-0.025;-0.025;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;669;809.7297,-1469.503;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ExtraPrePass;0;0;ExtraPrePass;5;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;670;809.7297,-1469.503;Float;False;True;-1;2;UnityEditor.ShaderGraphLitGUI;0;12;Toon/TFD_ToonWater;94348b07e5e8bab40bd6c8a1e3df54cd;True;Forward;0;1;Forward;21;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;2;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Transparent=RenderType;Queue=Transparent=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;5;False;;10;False;;1;1;False;;10;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalForwardOnly;False;False;0;;0;0;Standard;42;Lighting Model;0;0;Workflow;1;0;Surface;1;638470632602553932;  Refraction Model;0;0;  Blend;0;0;Two Sided;1;0;Fragment Normal Space,InvertActionOnDeselection;0;0;Forward Only;1;638615696002581053;Transmission;0;0;  Transmission Shadow;0.5,False,;0;Translucency;0;0;  Translucency Strength;1,False,;0;  Normal Distortion;0.5,False,;0;  Scattering;2,False,;0;  Direct;0.9,False,;0;  Ambient;0.1,False,;0;  Shadow;0.5,False,;0;Cast Shadows;0;638614991306522818;  Use Shadow Threshold;0;0;Receive Shadows;1;638615205060852736;Receive SSAO;1;0;GPU Instancing;1;0;LOD CrossFade;1;0;Built-in Fog;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Write Depth;0;0;  Early Z;0;0;Vertex Position,InvertActionOnDeselection;1;0;Debug Display;0;0;Clear Coat;0;0;0;10;False;True;False;True;True;True;True;False;True;True;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;671;809.7297,-1469.503;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;672;809.7297,-1469.503;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;673;809.7297,-1469.503;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;674;809.7297,-1469.503;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;5;False;;10;False;;1;1;False;;10;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;675;809.7297,-1469.503;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormalsOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;676;809.7297,-1469.503;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;GBuffer;0;7;GBuffer;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;True;1;5;False;;10;False;;1;1;False;;10;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=UniversalGBuffer;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;677;809.7297,-1469.503;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;SceneSelectionPass;0;8;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;678;809.7297,-1469.503;Float;False;False;-1;2;UnityEditor.ShaderGraphLitGUI;0;1;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ScenePickingPass;0;9;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Lit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
WireConnection;364;0;363;0
WireConnection;365;0;364;0
WireConnection;366;0;365;0
WireConnection;368;0;366;0
WireConnection;327;0;183;0
WireConnection;175;0;177;0
WireConnection;175;1;180;0
WireConnection;176;0;374;0
WireConnection;176;1;327;0
WireConnection;431;0;173;0
WireConnection;174;0;175;0
WireConnection;174;1;176;0
WireConnection;325;0;172;0
WireConnection;170;0;433;0
WireConnection;170;1;174;0
WireConnection;167;0;170;1
WireConnection;167;1;325;0
WireConnection;435;0;177;0
WireConnection;163;0;167;0
WireConnection;332;0;183;0
WireConnection;324;0;162;0
WireConnection;208;0;163;0
WireConnection;335;0;172;0
WireConnection;196;0;198;0
WireConnection;196;1;437;0
WireConnection;197;0;332;0
WireConnection;197;1;373;0
WireConnection;191;0;335;0
WireConnection;161;0;208;0
WireConnection;161;1;324;0
WireConnection;195;0;196;0
WireConnection;195;1;197;0
WireConnection;207;0;191;0
WireConnection;193;0;434;0
WireConnection;193;1;195;0
WireConnection;334;0;158;0
WireConnection;160;0;161;0
WireConnection;189;0;207;0
WireConnection;157;0;160;0
WireConnection;188;0;334;0
WireConnection;188;1;193;1
WireConnection;156;0;157;0
WireConnection;156;1;158;0
WireConnection;185;0;189;0
WireConnection;185;1;188;0
WireConnection;186;0;156;0
WireConnection;186;1;185;0
WireConnection;626;0;186;0
WireConnection;294;0;293;0
WireConnection;295;0;294;0
WireConnection;297;0;627;0
WireConnection;297;1;296;0
WireConnection;297;2;295;0
WireConnection;665;0;664;0
WireConnection;299;0;297;0
WireConnection;666;0;665;0
WireConnection;426;0;45;0
WireConnection;344;0;339;0
WireConnection;341;0;370;0
WireConnection;341;1;344;0
WireConnection;342;0;341;0
WireConnection;342;2;340;0
WireConnection;231;0;230;0
WireConnection;231;1;228;0
WireConnection;42;0;43;0
WireConnection;42;1;371;0
WireConnection;232;0;231;0
WireConnection;218;0;428;0
WireConnection;218;1;342;0
WireConnection;40;0;42;0
WireConnection;40;2;247;0
WireConnection;242;0;232;0
WireConnection;215;0;218;0
WireConnection;336;0;38;0
WireConnection;39;0;427;0
WireConnection;39;1;40;0
WireConnection;234;0;242;0
WireConnection;234;1;215;0
WireConnection;104;0;103;0
WireConnection;37;0;39;2
WireConnection;37;1;336;0
WireConnection;108;0;234;0
WireConnection;108;1;109;0
WireConnection;106;0;104;0
WireConnection;291;0;37;0
WireConnection;107;0;108;0
WireConnection;107;1;106;0
WireConnection;115;0;107;0
WireConnection;115;1;116;1
WireConnection;117;0;115;0
WireConnection;117;1;505;0
WireConnection;120;0;117;0
WireConnection;612;0;120;0
WireConnection;95;0;94;0
WireConnection;91;0;93;1
WireConnection;91;1;94;0
WireConnection;87;0;614;0
WireConnection;87;1;376;0
WireConnection;90;0;87;0
WireConnection;90;1;91;0
WireConnection;90;2;95;0
WireConnection;616;0;90;0
WireConnection;419;0;418;0
WireConnection;422;0;420;0
WireConnection;422;1;419;0
WireConnection;470;0;422;0
WireConnection;470;2;421;0
WireConnection;423;0;422;0
WireConnection;423;2;421;0
WireConnection;416;0;439;0
WireConnection;416;1;423;0
WireConnection;425;0;439;0
WireConnection;425;1;470;0
WireConnection;407;0;416;0
WireConnection;407;1;425;0
WireConnection;611;0;398;0
WireConnection;492;0;491;0
WireConnection;392;0;611;0
WireConnection;392;1;407;0
WireConnection;495;0;493;0
WireConnection;495;1;492;0
WireConnection;608;0;494;0
WireConnection;394;0;392;0
WireConnection;394;1;399;0
WireConnection;498;0;495;0
WireConnection;498;2;608;0
WireConnection;556;0;495;0
WireConnection;556;1;557;0
WireConnection;483;0;497;0
WireConnection;483;1;498;0
WireConnection;496;0;556;0
WireConnection;496;2;608;0
WireConnection;378;0;668;0
WireConnection;405;0;299;0
WireConnection;552;0;497;0
WireConnection;552;1;496;0
WireConnection;478;0;483;1
WireConnection;478;1;482;0
WireConnection;551;0;483;1
WireConnection;27;0;26;1
WireConnection;27;1;29;0
WireConnection;28;0;26;2
WireConnection;28;1;29;0
WireConnection;323;0;137;0
WireConnection;146;0;150;0
WireConnection;554;0;552;1
WireConnection;550;0;478;0
WireConnection;550;1;551;0
WireConnection;550;2;482;0
WireConnection;31;0;27;0
WireConnection;31;1;28;0
WireConnection;473;0;472;0
WireConnection;473;1;145;0
WireConnection;473;2;471;0
WireConnection;211;0;146;0
WireConnection;136;3;323;0
WireConnection;462;0;402;0
WireConnection;462;1;144;0
WireConnection;462;2;406;0
WireConnection;555;0;550;0
WireConnection;555;1;554;0
WireConnection;606;0;476;0
WireConnection;24;0;26;0
WireConnection;24;1;31;0
WireConnection;24;2;292;0
WireConnection;209;0;136;0
WireConnection;142;0;462;0
WireConnection;142;1;473;0
WireConnection;142;2;211;0
WireConnection;475;0;555;0
WireConnection;475;1;606;0
WireConnection;250;0;432;0
WireConnection;250;1;24;0
WireConnection;133;0;142;0
WireConnection;133;1;135;0
WireConnection;133;2;209;0
WireConnection;487;0;475;0
WireConnection;329;0;304;0
WireConnection;329;1;250;0
WireConnection;622;0;133;0
WireConnection;629;0;156;0
WireConnection;619;0;329;0
WireConnection;502;0;508;0
WireConnection;502;1;625;0
WireConnection;300;0;620;0
WireConnection;300;1;502;0
WireConnection;153;0;630;0
WireConnection;153;1;155;0
WireConnection;184;0;155;0
WireConnection;184;1;628;0
WireConnection;12;0;300;0
WireConnection;12;1;153;0
WireConnection;12;2;184;0
WireConnection;7;0;8;0
WireConnection;7;1;10;1
WireConnection;7;2;11;0
WireConnection;5;0;12;0
WireConnection;5;1;7;0
WireConnection;3;0;5;0
WireConnection;3;1;613;0
WireConnection;667;0;299;0
WireConnection;667;1;666;0
WireConnection;668;0;394;0
WireConnection;670;0;3;0
WireConnection;670;2;617;0
WireConnection;670;3;679;0
WireConnection;670;4;679;0
WireConnection;670;6;667;0
ASEEND*/
//CHKSM=54CF907F2A81783CA74A870AA512615BE9938235