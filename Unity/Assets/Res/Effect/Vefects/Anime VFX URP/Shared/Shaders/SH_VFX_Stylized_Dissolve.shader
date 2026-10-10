// Made with Amplify Shader Editor v1.9.7.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Vefects/SH_VFX_Stylized_Dissolve"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[Space(33)][Header(Main Texture)][Space(13)]_Texture("Texture", 2D) = "white" {}
		_TextureChannel("Texture Channel", Vector) = (0,1,0,0)
		_TextureRotation("Texture Rotation", Float) = 0
		_TexturePanSpeed("Texture Pan Speed", Vector) = (0,0,0,0)
		[Space(33)][Header(Color Texture)][Space(13)]_ColorTexture("Color Texture", 2D) = "white" {}
		_ColorRotation("Color Rotation", Float) = 0
		[Space(33)][Header(Gradient Shape)][Space(13)]_GradientShape("Gradient Shape", 2D) = "white" {}
		_GradientShapeChannel("Gradient Shape Channel", Vector) = (0,1,0,0)
		_GradientShapeRotation("Gradient Shape Rotation", Float) = 0
		[Space(33)][Header(Gradient Map)][Space(13)]_GradientMap("Gradient Map", 2D) = "white" {}
		_GradientMapDisplacement("Gradient Map Displacement", Float) = 0.1
		_InvertGradient("Invert Gradient", Float) = 0
		[Space(33)][Header(Distortion)][Space(13)]_DistortionMask("Distortion Mask", 2D) = "white" {}
		_DistortionMaskChannel("Distortion Mask Channel", Vector) = (0,1,0,0)
		_DistortionMaskRotation("Distortion Mask Rotation", Float) = 0
		_DistortionMaskPanSpeed("Distortion Mask Pan Speed", Vector) = (0,0,0,0)
		_DistortionIntensity("Distortion Intensity", Float) = 0
		[Space(33)][Header(Dissolve)][Space(13)]_DissolveMask("Dissolve Mask", 2D) = "white" {}
		_DissolveMaskChannel("Dissolve Mask Channel", Vector) = (0,1,0,0)
		_DissolveMaskRotation("Dissolve Mask Rotation", Float) = 0
		_DissolveMaskPanSpeed("Dissolve Mask Pan Speed", Vector) = (0,0,0,0)
		_DissolveMaskInvert("Dissolve Mask Invert", Range( 0 , 1)) = 0
		_DissolveOffset("Dissolve Offset", Float) = 0
		[Space(33)][Header(Properties)][Space(13)]_EmissionIntensity("Emission Intensity", Float) = 1
		_CoreColor("Core Color", Color) = (1,1,1,0)
		_DifferentCoreColor("Different Core Color", Float) = 0
		_CorePower("Core Power", Float) = 1
		_CoreIntensity("Core Intensity", Float) = 0
		_GlowIntensity("Glow Intensity", Float) = 1
		_AlphaBoldness("Alpha Boldness", Float) = 1
		[Toggle(_CUSTOMPANSWITCH_ON)] _CustomPanSwitch("CustomPanSwitch", Float) = 0
		[Toggle(_MESHVERTEXCOLOR_ON)] _MeshVertexColor("MeshVertexColor", Float) = 0
		[Toggle(_STEP_ON)] _Step("Step", Float) = 0
		_ValueStep("Value Step", Float) = 0
		_ValueStepAdd("Value Step Add", Float) = 0.1
		[Space(33)][Header(Depth Fade)][Space(13)][Toggle(_USEDEPTHFADE_ON)] _UseDepthFade("Use Depth Fade", Float) = 0
		_DepthFadeIntensity("Depth Fade Intensity", Float) = 0
		[Space(33)][Header(AR)][Space(13)]_Cull("Cull", Float) = 2
		_Src("Src", Float) = 5
		_Dst("Dst", Float) = 10
		_ZWrite("ZWrite", Float) = 0
		_ZTest("ZTest", Float) = 2


		//_TessPhongStrength( "Tess Phong Strength", Range( 0, 1 ) ) = 0.5
		//_TessValue( "Tess Max Tessellation", Range( 1, 32 ) ) = 16
		//_TessMin( "Tess Min Distance", Float ) = 10
		//_TessMax( "Tess Max Distance", Float ) = 25
		//_TessEdgeLength ( "Tess Edge length", Range( 2, 50 ) ) = 16
		//_TessMaxDisp( "Tess Max Displacement", Float ) = 25

		[HideInInspector] _QueueOffset("_QueueOffset", Float) = 0
        [HideInInspector] _QueueControl("_QueueControl", Float) = -1

        [HideInInspector][NoScaleOffset] unity_Lightmaps("unity_Lightmaps", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset] unity_LightmapsInd("unity_LightmapsInd", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset] unity_ShadowMasks("unity_ShadowMasks", 2DArray) = "" {}

		[HideInInspector][ToggleOff] _ReceiveShadows("Receive Shadows", Float) = 1.0
	}

	SubShader
	{
		LOD 0

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent" "UniversalMaterialType"="Unlit" }

		Cull [_Cull]
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

			Blend [_Src] [_Dst], One OneMinusSrcAlpha
			ZWrite Off
			ZTest [_ZTest]
			Offset 0 , 0
			ColorMask RGBA

			

			HLSLPROGRAM

			#pragma shader_feature_local _RECEIVE_SHADOWS_OFF
			#pragma multi_compile_instancing
			#pragma instancing_options renderinglayer
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define ASE_VERSION 19701
			#define ASE_SRP_VERSION 150006
			#define REQUIRE_DEPTH_TEXTURE 1


			#pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
			#pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3

			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DYNAMICLIGHTMAP_ON
			#pragma multi_compile_fragment _ DEBUG_DISPLAY

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS SHADERPASS_UNLIT

			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DBuffer.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Debug/Debugging3D.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceData.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#pragma shader_feature_local _USEDEPTHFADE_ON
			#pragma shader_feature_local _CUSTOMPANSWITCH_ON
			#pragma shader_feature_local _STEP_ON
			#pragma shader_feature_local _MESHVERTEXCOLOR_ON


			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
					float3 positionWS : TEXCOORD1;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					float4 shadowCoord : TEXCOORD2;
				#endif
				#ifdef ASE_FOG
					float fogFactor : TEXCOORD3;
				#endif
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _DissolveMaskChannel;
			float4 _Texture_ST;
			float4 _DissolveMask_ST;
			float4 _GradientShapeChannel;
			float4 _TextureChannel;
			float4 _GradientShape_ST;
			float4 _CoreColor;
			float4 _DistortionMaskChannel;
			float4 _ColorTexture_ST;
			float4 _DistortionMask_ST;
			float2 _DistortionMaskPanSpeed;
			float2 _TexturePanSpeed;
			float2 _DissolveMaskPanSpeed;
			float _CoreIntensity;
			float _DifferentCoreColor;
			float _CorePower;
			float _EmissionIntensity;
			float _GlowIntensity;
			float _AlphaBoldness;
			float _TextureRotation;
			float _ValueStep;
			float _GradientMapDisplacement;
			float _Cull;
			float _DissolveOffset;
			float _DissolveMaskInvert;
			float _ValueStepAdd;
			float _DissolveMaskRotation;
			float _GradientShapeRotation;
			float _DistortionIntensity;
			float _DistortionMaskRotation;
			float _ColorRotation;
			float _ZTest;
			float _ZWrite;
			float _Dst;
			float _Src;
			float _InvertGradient;
			float _DepthFadeIntensity;
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			sampler2D _ColorTexture;
			sampler2D _DistortionMask;
			sampler2D _GradientMap;
			sampler2D _GradientShape;
			sampler2D _DissolveMask;
			sampler2D _Texture;


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				o.ase_texcoord4 = v.ase_texcoord;
				o.ase_texcoord5.xy = v.ase_texcoord1.xy;
				o.ase_texcoord5.zw = v.ase_texcoord3.xy;
				o.ase_color = v.ase_color;

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

				#ifdef ASE_FOG
					o.fogFactor = ComputeFogFactor( vertexInput.positionCS.z );
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
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_color : COLOR;

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
				o.ase_texcoord = v.ase_texcoord;
				o.ase_texcoord1 = v.ase_texcoord1;
				o.ase_texcoord3 = v.ase_texcoord3;
				o.ase_color = v.ase_color;
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
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
				o.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
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
				#ifdef _WRITE_RENDERING_LAYERS
				, out float4 outRenderingLayers : SV_Target1
				#endif
				 ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
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

				float2 uv_ColorTexture = IN.ase_texcoord4.xy * _ColorTexture_ST.xy + _ColorTexture_ST.zw;
				float cos190 = cos( radians( _ColorRotation ) );
				float sin190 = sin( radians( _ColorRotation ) );
				float2 rotator190 = mul( uv_ColorTexture - float2( 0.5,0.5 ) , float2x2( cos190 , -sin190 , sin190 , cos190 )) + float2( 0.5,0.5 );
				float2 temp_cast_0 = (0.0).xx;
				float2 texCoord83 = IN.ase_texcoord5.xy * float2( 1,1 ) + float2( 0,0 );
				#ifdef _CUSTOMPANSWITCH_ON
				float2 staticSwitch85 = texCoord83;
				#else
				float2 staticSwitch85 = temp_cast_0;
				#endif
				float2 CustomUV89 = staticSwitch85;
				float2 uv_DistortionMask = IN.ase_texcoord4.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float cos95 = cos( radians( _DistortionMaskRotation ) );
				float sin95 = sin( radians( _DistortionMaskRotation ) );
				float2 rotator95 = mul( uv_DistortionMask - float2( 0.5,0.5 ) , float2x2( cos95 , -sin95 , sin95 , cos95 )) + float2( 0.5,0.5 );
				float4 uvs4_DistortionMask = IN.ase_texcoord4;
				uvs4_DistortionMask.xy = IN.ase_texcoord4.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float dotResult100 = dot( tex2D( _DistortionMask, ( rotator95 + uvs4_DistortionMask.w + CustomUV89 + ( _TimeParameters.x * _DistortionMaskPanSpeed ) ) ) , _DistortionMaskChannel );
				float Disto107 = ( saturate( dotResult100 ) * _DistortionIntensity );
				float2 texCoord181 = IN.ase_texcoord5.zw * float2( 1,1 ) + float2( 0,0 );
				float2 uv_GradientShape = IN.ase_texcoord4.xy * _GradientShape_ST.xy + _GradientShape_ST.zw;
				float cos218 = cos( radians( _GradientShapeRotation ) );
				float sin218 = sin( radians( _GradientShapeRotation ) );
				float2 rotator218 = mul( uv_GradientShape - float2( 0.5,0.5 ) , float2x2( cos218 , -sin218 , sin218 , cos218 )) + float2( 0.5,0.5 );
				float dotResult232 = dot( tex2D( _GradientShape, ( rotator218 + CustomUV89 + Disto107 ) ) , _GradientShapeChannel );
				float2 uv_DissolveMask = IN.ase_texcoord4.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float cos112 = cos( radians( _DissolveMaskRotation ) );
				float sin112 = sin( radians( _DissolveMaskRotation ) );
				float2 rotator112 = mul( uv_DissolveMask - float2( 0.5,0.5 ) , float2x2( cos112 , -sin112 , sin112 , cos112 )) + float2( 0.5,0.5 );
				float4 uvs4_DissolveMask = IN.ase_texcoord4;
				uvs4_DissolveMask.xy = IN.ase_texcoord4.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float dotResult122 = dot( tex2D( _DissolveMask, ( rotator112 + uvs4_DissolveMask.w + CustomUV89 + ( _TimeParameters.x * _DissolveMaskPanSpeed ) + Disto107 ) ) , _DissolveMaskChannel );
				float temp_output_126_0 = saturate( dotResult122 );
				float lerpResult138 = lerp( temp_output_126_0 , saturate( ( 1.0 - temp_output_126_0 ) ) , _DissolveMaskInvert);
				float4 texCoord141 = IN.ase_texcoord4;
				texCoord141.xy = IN.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_145_0 = ( saturate( lerpResult138 ) + texCoord141.z + _DissolveOffset );
				float temp_output_225_0 = saturate( ( saturate( dotResult232 ) * temp_output_145_0 ) );
				float lerpResult196 = lerp( saturate( ( 1.0 - temp_output_225_0 ) ) , temp_output_225_0 , _InvertGradient);
				float2 temp_cast_4 = (( lerpResult196 + _GradientMapDisplacement )).xx;
				float3 temp_output_157_0 = (IN.ase_color).rgb;
				float3 temp_output_198_0 = ( saturate( ( (tex2D( _ColorTexture, ( rotator190 + CustomUV89 + Disto107 ) )).rgb + texCoord181.x ) ) * (tex2D( _GradientMap, temp_cast_4 )).rgb * temp_output_157_0 );
				float2 uv_Texture = IN.ase_texcoord4.xy * _Texture_ST.xy + _Texture_ST.zw;
				float cos129 = cos( radians( _TextureRotation ) );
				float sin129 = sin( radians( _TextureRotation ) );
				float2 rotator129 = mul( uv_Texture - float2( 0.5,0.5 ) , float2x2( cos129 , -sin129 , sin129 , cos129 )) + float2( 0.5,0.5 );
				float dotResult140 = dot( tex2D( _Texture, ( rotator129 + ( _TimeParameters.x * _TexturePanSpeed ) + CustomUV89 + Disto107 ) ) , _TextureChannel );
				float temp_output_147_0 = ( temp_output_145_0 * saturate( dotResult140 ) );
				float temp_output_153_0 = ( pow( temp_output_147_0 , _CorePower ) * _CoreIntensity );
				float4 lerpResult188 = lerp( float4( temp_output_198_0 , 0.0 ) , _CoreColor , saturate( temp_output_153_0 ));
				float4 lerpResult217 = lerp( float4( temp_output_198_0 , 0.0 ) , saturate( lerpResult188 ) , _DifferentCoreColor);
				float3 temp_cast_8 = (1.0).xxx;
				#ifdef _MESHVERTEXCOLOR_ON
				float3 staticSwitch159 = temp_output_157_0;
				#else
				float3 staticSwitch159 = temp_cast_8;
				#endif
				float3 temp_output_167_0 = saturate( ( ( IN.ase_color.a * saturate( ( temp_output_153_0 + ( temp_output_147_0 * _GlowIntensity ) ) ) * staticSwitch159 ) * _AlphaBoldness ) );
				float3 temp_cast_9 = (_ValueStep).xxx;
				float3 temp_cast_10 = (( _ValueStep + _ValueStepAdd )).xxx;
				float3 smoothstepResult170 = smoothstep( temp_cast_9 , temp_cast_10 , temp_output_167_0);
				#ifdef _STEP_ON
				float3 staticSwitch183 = saturate( smoothstepResult170 );
				#else
				float3 staticSwitch183 = temp_output_167_0;
				#endif
				float4 temp_output_234_0 = ( ( saturate( lerpResult217 ) * _EmissionIntensity ) * float4( staticSwitch183 , 0.0 ) );
				float4 ase_screenPosNorm = ScreenPos / ScreenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float screenDepth213 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth213 = ( screenDepth213 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _DepthFadeIntensity );
				float temp_output_236_0 = saturate( distanceDepth213 );
				#ifdef _USEDEPTHFADE_ON
				float4 staticSwitch238 = ( temp_output_234_0 * temp_output_236_0 );
				#else
				float4 staticSwitch238 = temp_output_234_0;
				#endif
				
				#ifdef _USEDEPTHFADE_ON
				float3 staticSwitch239 = ( staticSwitch183 * temp_output_236_0 );
				#else
				float3 staticSwitch239 = staticSwitch183;
				#endif
				
				float3 BakedAlbedo = 0;
				float3 BakedEmission = 0;
				float3 Color = staticSwitch238.rgb;
				float Alpha = staticSwitch239.x;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;

				#ifdef _ALPHATEST_ON
					clip( Alpha - AlphaClipThreshold );
				#endif

				#if defined(_DBUFFER)
					ApplyDecalToBaseColor(IN.positionCS, Color);
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODFadeCrossFade( IN.positionCS );
				#endif

				#ifdef ASE_FOG
					Color = MixFog( Color, IN.fogFactor );
				#endif

				#ifdef _WRITE_RENDERING_LAYERS
					uint renderingLayers = GetMeshRenderingLayer();
					outRenderingLayers = float4( EncodeMeshRenderingLayer( renderingLayers ), 0, 0, 0 );
				#endif

				return half4( Color, Alpha );
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

			#pragma multi_compile_instancing
			#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define ASE_VERSION 19701
			#define ASE_SRP_VERSION 150006
			#define REQUIRE_DEPTH_TEXTURE 1


			#pragma vertex vert
			#pragma fragment frag

			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#pragma shader_feature_local _USEDEPTHFADE_ON
			#pragma shader_feature_local _STEP_ON
			#pragma shader_feature_local _CUSTOMPANSWITCH_ON
			#pragma shader_feature_local _MESHVERTEXCOLOR_ON


			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 positionWS : TEXCOORD1;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD2;
				#endif
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _DissolveMaskChannel;
			float4 _Texture_ST;
			float4 _DissolveMask_ST;
			float4 _GradientShapeChannel;
			float4 _TextureChannel;
			float4 _GradientShape_ST;
			float4 _CoreColor;
			float4 _DistortionMaskChannel;
			float4 _ColorTexture_ST;
			float4 _DistortionMask_ST;
			float2 _DistortionMaskPanSpeed;
			float2 _TexturePanSpeed;
			float2 _DissolveMaskPanSpeed;
			float _CoreIntensity;
			float _DifferentCoreColor;
			float _CorePower;
			float _EmissionIntensity;
			float _GlowIntensity;
			float _AlphaBoldness;
			float _TextureRotation;
			float _ValueStep;
			float _GradientMapDisplacement;
			float _Cull;
			float _DissolveOffset;
			float _DissolveMaskInvert;
			float _ValueStepAdd;
			float _DissolveMaskRotation;
			float _GradientShapeRotation;
			float _DistortionIntensity;
			float _DistortionMaskRotation;
			float _ColorRotation;
			float _ZTest;
			float _ZWrite;
			float _Dst;
			float _Src;
			float _InvertGradient;
			float _DepthFadeIntensity;
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			sampler2D _DissolveMask;
			sampler2D _DistortionMask;
			sampler2D _Texture;


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				o.ase_color = v.ase_color;
				o.ase_texcoord3 = v.ase_texcoord;
				o.ase_texcoord4.xy = v.ase_texcoord1.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord4.zw = 0;

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
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;

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
				o.ase_color = v.ase_color;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_texcoord1 = v.ase_texcoord1;
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
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

				float4 ClipPos = IN.clipPosV;
				float4 ScreenPos = ComputeScreenPos( IN.clipPosV );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float2 uv_DissolveMask = IN.ase_texcoord3.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float cos112 = cos( radians( _DissolveMaskRotation ) );
				float sin112 = sin( radians( _DissolveMaskRotation ) );
				float2 rotator112 = mul( uv_DissolveMask - float2( 0.5,0.5 ) , float2x2( cos112 , -sin112 , sin112 , cos112 )) + float2( 0.5,0.5 );
				float4 uvs4_DissolveMask = IN.ase_texcoord3;
				uvs4_DissolveMask.xy = IN.ase_texcoord3.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float2 temp_cast_0 = (0.0).xx;
				float2 texCoord83 = IN.ase_texcoord4.xy * float2( 1,1 ) + float2( 0,0 );
				#ifdef _CUSTOMPANSWITCH_ON
				float2 staticSwitch85 = texCoord83;
				#else
				float2 staticSwitch85 = temp_cast_0;
				#endif
				float2 CustomUV89 = staticSwitch85;
				float2 uv_DistortionMask = IN.ase_texcoord3.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float cos95 = cos( radians( _DistortionMaskRotation ) );
				float sin95 = sin( radians( _DistortionMaskRotation ) );
				float2 rotator95 = mul( uv_DistortionMask - float2( 0.5,0.5 ) , float2x2( cos95 , -sin95 , sin95 , cos95 )) + float2( 0.5,0.5 );
				float4 uvs4_DistortionMask = IN.ase_texcoord3;
				uvs4_DistortionMask.xy = IN.ase_texcoord3.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float dotResult100 = dot( tex2D( _DistortionMask, ( rotator95 + uvs4_DistortionMask.w + CustomUV89 + ( _TimeParameters.x * _DistortionMaskPanSpeed ) ) ) , _DistortionMaskChannel );
				float Disto107 = ( saturate( dotResult100 ) * _DistortionIntensity );
				float dotResult122 = dot( tex2D( _DissolveMask, ( rotator112 + uvs4_DissolveMask.w + CustomUV89 + ( _TimeParameters.x * _DissolveMaskPanSpeed ) + Disto107 ) ) , _DissolveMaskChannel );
				float temp_output_126_0 = saturate( dotResult122 );
				float lerpResult138 = lerp( temp_output_126_0 , saturate( ( 1.0 - temp_output_126_0 ) ) , _DissolveMaskInvert);
				float4 texCoord141 = IN.ase_texcoord3;
				texCoord141.xy = IN.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_145_0 = ( saturate( lerpResult138 ) + texCoord141.z + _DissolveOffset );
				float2 uv_Texture = IN.ase_texcoord3.xy * _Texture_ST.xy + _Texture_ST.zw;
				float cos129 = cos( radians( _TextureRotation ) );
				float sin129 = sin( radians( _TextureRotation ) );
				float2 rotator129 = mul( uv_Texture - float2( 0.5,0.5 ) , float2x2( cos129 , -sin129 , sin129 , cos129 )) + float2( 0.5,0.5 );
				float dotResult140 = dot( tex2D( _Texture, ( rotator129 + ( _TimeParameters.x * _TexturePanSpeed ) + CustomUV89 + Disto107 ) ) , _TextureChannel );
				float temp_output_147_0 = ( temp_output_145_0 * saturate( dotResult140 ) );
				float temp_output_153_0 = ( pow( temp_output_147_0 , _CorePower ) * _CoreIntensity );
				float3 temp_cast_4 = (1.0).xxx;
				float3 temp_output_157_0 = (IN.ase_color).rgb;
				#ifdef _MESHVERTEXCOLOR_ON
				float3 staticSwitch159 = temp_output_157_0;
				#else
				float3 staticSwitch159 = temp_cast_4;
				#endif
				float3 temp_output_167_0 = saturate( ( ( IN.ase_color.a * saturate( ( temp_output_153_0 + ( temp_output_147_0 * _GlowIntensity ) ) ) * staticSwitch159 ) * _AlphaBoldness ) );
				float3 temp_cast_5 = (_ValueStep).xxx;
				float3 temp_cast_6 = (( _ValueStep + _ValueStepAdd )).xxx;
				float3 smoothstepResult170 = smoothstep( temp_cast_5 , temp_cast_6 , temp_output_167_0);
				#ifdef _STEP_ON
				float3 staticSwitch183 = saturate( smoothstepResult170 );
				#else
				float3 staticSwitch183 = temp_output_167_0;
				#endif
				float4 ase_screenPosNorm = ScreenPos / ScreenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float screenDepth213 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth213 = ( screenDepth213 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _DepthFadeIntensity );
				float temp_output_236_0 = saturate( distanceDepth213 );
				#ifdef _USEDEPTHFADE_ON
				float3 staticSwitch239 = ( staticSwitch183 * temp_output_236_0 );
				#else
				float3 staticSwitch239 = staticSwitch183;
				#endif
				

				float Alpha = staticSwitch239.x;
				float AlphaClipThreshold = 0.5;

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODFadeCrossFade( IN.positionCS );
				#endif
				return 0;
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

			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define ASE_VERSION 19701
			#define ASE_SRP_VERSION 150006
			#define REQUIRE_DEPTH_TEXTURE 1


			#pragma vertex vert
			#pragma fragment frag

			#define ATTRIBUTES_NEED_NORMAL
			#define ATTRIBUTES_NEED_TANGENT
			#define SHADERPASS SHADERPASS_DEPTHONLY

			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _USEDEPTHFADE_ON
			#pragma shader_feature_local _STEP_ON
			#pragma shader_feature_local _CUSTOMPANSWITCH_ON
			#pragma shader_feature_local _MESHVERTEXCOLOR_ON


			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 positionCS : SV_POSITION;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord2 : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _DissolveMaskChannel;
			float4 _Texture_ST;
			float4 _DissolveMask_ST;
			float4 _GradientShapeChannel;
			float4 _TextureChannel;
			float4 _GradientShape_ST;
			float4 _CoreColor;
			float4 _DistortionMaskChannel;
			float4 _ColorTexture_ST;
			float4 _DistortionMask_ST;
			float2 _DistortionMaskPanSpeed;
			float2 _TexturePanSpeed;
			float2 _DissolveMaskPanSpeed;
			float _CoreIntensity;
			float _DifferentCoreColor;
			float _CorePower;
			float _EmissionIntensity;
			float _GlowIntensity;
			float _AlphaBoldness;
			float _TextureRotation;
			float _ValueStep;
			float _GradientMapDisplacement;
			float _Cull;
			float _DissolveOffset;
			float _DissolveMaskInvert;
			float _ValueStepAdd;
			float _DissolveMaskRotation;
			float _GradientShapeRotation;
			float _DistortionIntensity;
			float _DistortionMaskRotation;
			float _ColorRotation;
			float _ZTest;
			float _ZWrite;
			float _Dst;
			float _Src;
			float _InvertGradient;
			float _DepthFadeIntensity;
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			sampler2D _DissolveMask;
			sampler2D _DistortionMask;
			sampler2D _Texture;


			
			int _ObjectId;
			int _PassValue;

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
				o.ase_texcoord2 = screenPos;
				
				o.ase_color = v.ase_color;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_texcoord1.xy = v.ase_texcoord1.xy;
				
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
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;

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
				o.ase_color = v.ase_color;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_texcoord1 = v.ase_texcoord1;
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
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

				float2 uv_DissolveMask = IN.ase_texcoord.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float cos112 = cos( radians( _DissolveMaskRotation ) );
				float sin112 = sin( radians( _DissolveMaskRotation ) );
				float2 rotator112 = mul( uv_DissolveMask - float2( 0.5,0.5 ) , float2x2( cos112 , -sin112 , sin112 , cos112 )) + float2( 0.5,0.5 );
				float4 uvs4_DissolveMask = IN.ase_texcoord;
				uvs4_DissolveMask.xy = IN.ase_texcoord.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float2 temp_cast_0 = (0.0).xx;
				float2 texCoord83 = IN.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				#ifdef _CUSTOMPANSWITCH_ON
				float2 staticSwitch85 = texCoord83;
				#else
				float2 staticSwitch85 = temp_cast_0;
				#endif
				float2 CustomUV89 = staticSwitch85;
				float2 uv_DistortionMask = IN.ase_texcoord.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float cos95 = cos( radians( _DistortionMaskRotation ) );
				float sin95 = sin( radians( _DistortionMaskRotation ) );
				float2 rotator95 = mul( uv_DistortionMask - float2( 0.5,0.5 ) , float2x2( cos95 , -sin95 , sin95 , cos95 )) + float2( 0.5,0.5 );
				float4 uvs4_DistortionMask = IN.ase_texcoord;
				uvs4_DistortionMask.xy = IN.ase_texcoord.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float dotResult100 = dot( tex2D( _DistortionMask, ( rotator95 + uvs4_DistortionMask.w + CustomUV89 + ( _TimeParameters.x * _DistortionMaskPanSpeed ) ) ) , _DistortionMaskChannel );
				float Disto107 = ( saturate( dotResult100 ) * _DistortionIntensity );
				float dotResult122 = dot( tex2D( _DissolveMask, ( rotator112 + uvs4_DissolveMask.w + CustomUV89 + ( _TimeParameters.x * _DissolveMaskPanSpeed ) + Disto107 ) ) , _DissolveMaskChannel );
				float temp_output_126_0 = saturate( dotResult122 );
				float lerpResult138 = lerp( temp_output_126_0 , saturate( ( 1.0 - temp_output_126_0 ) ) , _DissolveMaskInvert);
				float4 texCoord141 = IN.ase_texcoord;
				texCoord141.xy = IN.ase_texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_145_0 = ( saturate( lerpResult138 ) + texCoord141.z + _DissolveOffset );
				float2 uv_Texture = IN.ase_texcoord.xy * _Texture_ST.xy + _Texture_ST.zw;
				float cos129 = cos( radians( _TextureRotation ) );
				float sin129 = sin( radians( _TextureRotation ) );
				float2 rotator129 = mul( uv_Texture - float2( 0.5,0.5 ) , float2x2( cos129 , -sin129 , sin129 , cos129 )) + float2( 0.5,0.5 );
				float dotResult140 = dot( tex2D( _Texture, ( rotator129 + ( _TimeParameters.x * _TexturePanSpeed ) + CustomUV89 + Disto107 ) ) , _TextureChannel );
				float temp_output_147_0 = ( temp_output_145_0 * saturate( dotResult140 ) );
				float temp_output_153_0 = ( pow( temp_output_147_0 , _CorePower ) * _CoreIntensity );
				float3 temp_cast_4 = (1.0).xxx;
				float3 temp_output_157_0 = (IN.ase_color).rgb;
				#ifdef _MESHVERTEXCOLOR_ON
				float3 staticSwitch159 = temp_output_157_0;
				#else
				float3 staticSwitch159 = temp_cast_4;
				#endif
				float3 temp_output_167_0 = saturate( ( ( IN.ase_color.a * saturate( ( temp_output_153_0 + ( temp_output_147_0 * _GlowIntensity ) ) ) * staticSwitch159 ) * _AlphaBoldness ) );
				float3 temp_cast_5 = (_ValueStep).xxx;
				float3 temp_cast_6 = (( _ValueStep + _ValueStepAdd )).xxx;
				float3 smoothstepResult170 = smoothstep( temp_cast_5 , temp_cast_6 , temp_output_167_0);
				#ifdef _STEP_ON
				float3 staticSwitch183 = saturate( smoothstepResult170 );
				#else
				float3 staticSwitch183 = temp_output_167_0;
				#endif
				float4 screenPos = IN.ase_texcoord2;
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float screenDepth213 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth213 = ( screenDepth213 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _DepthFadeIntensity );
				float temp_output_236_0 = saturate( distanceDepth213 );
				#ifdef _USEDEPTHFADE_ON
				float3 staticSwitch239 = ( staticSwitch183 * temp_output_236_0 );
				#else
				float3 staticSwitch239 = staticSwitch183;
				#endif
				

				surfaceDescription.Alpha = staticSwitch239.x;
				surfaceDescription.AlphaClipThreshold = 0.5;

				#if _ALPHATEST_ON
					float alphaClipThreshold = 0.01f;
					#if ALPHA_CLIP_THRESHOLD
						alphaClipThreshold = surfaceDescription.AlphaClipThreshold;
					#endif
					clip(surfaceDescription.Alpha - alphaClipThreshold);
				#endif

				half4 outColor = half4(_ObjectId, _PassValue, 1.0, 1.0);
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

			#define ASE_FOG 1
			#define _SURFACE_TYPE_TRANSPARENT 1
			#define ASE_VERSION 19701
			#define ASE_SRP_VERSION 150006
			#define REQUIRE_DEPTH_TEXTURE 1


			#pragma vertex vert
			#pragma fragment frag

			#define ATTRIBUTES_NEED_NORMAL
			#define ATTRIBUTES_NEED_TANGENT

			#define SHADERPASS SHADERPASS_DEPTHONLY

			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

			#if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _USEDEPTHFADE_ON
			#pragma shader_feature_local _STEP_ON
			#pragma shader_feature_local _CUSTOMPANSWITCH_ON
			#pragma shader_feature_local _MESHVERTEXCOLOR_ON


			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 positionCS : SV_POSITION;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord2 : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _DissolveMaskChannel;
			float4 _Texture_ST;
			float4 _DissolveMask_ST;
			float4 _GradientShapeChannel;
			float4 _TextureChannel;
			float4 _GradientShape_ST;
			float4 _CoreColor;
			float4 _DistortionMaskChannel;
			float4 _ColorTexture_ST;
			float4 _DistortionMask_ST;
			float2 _DistortionMaskPanSpeed;
			float2 _TexturePanSpeed;
			float2 _DissolveMaskPanSpeed;
			float _CoreIntensity;
			float _DifferentCoreColor;
			float _CorePower;
			float _EmissionIntensity;
			float _GlowIntensity;
			float _AlphaBoldness;
			float _TextureRotation;
			float _ValueStep;
			float _GradientMapDisplacement;
			float _Cull;
			float _DissolveOffset;
			float _DissolveMaskInvert;
			float _ValueStepAdd;
			float _DissolveMaskRotation;
			float _GradientShapeRotation;
			float _DistortionIntensity;
			float _DistortionMaskRotation;
			float _ColorRotation;
			float _ZTest;
			float _ZWrite;
			float _Dst;
			float _Src;
			float _InvertGradient;
			float _DepthFadeIntensity;
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			sampler2D _DissolveMask;
			sampler2D _DistortionMask;
			sampler2D _Texture;


			
			float4 _SelectionID;

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
				o.ase_texcoord2 = screenPos;
				
				o.ase_color = v.ase_color;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_texcoord1.xy = v.ase_texcoord1.xy;
				
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
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;

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
				o.ase_color = v.ase_color;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_texcoord1 = v.ase_texcoord1;
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
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

				float2 uv_DissolveMask = IN.ase_texcoord.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float cos112 = cos( radians( _DissolveMaskRotation ) );
				float sin112 = sin( radians( _DissolveMaskRotation ) );
				float2 rotator112 = mul( uv_DissolveMask - float2( 0.5,0.5 ) , float2x2( cos112 , -sin112 , sin112 , cos112 )) + float2( 0.5,0.5 );
				float4 uvs4_DissolveMask = IN.ase_texcoord;
				uvs4_DissolveMask.xy = IN.ase_texcoord.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float2 temp_cast_0 = (0.0).xx;
				float2 texCoord83 = IN.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				#ifdef _CUSTOMPANSWITCH_ON
				float2 staticSwitch85 = texCoord83;
				#else
				float2 staticSwitch85 = temp_cast_0;
				#endif
				float2 CustomUV89 = staticSwitch85;
				float2 uv_DistortionMask = IN.ase_texcoord.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float cos95 = cos( radians( _DistortionMaskRotation ) );
				float sin95 = sin( radians( _DistortionMaskRotation ) );
				float2 rotator95 = mul( uv_DistortionMask - float2( 0.5,0.5 ) , float2x2( cos95 , -sin95 , sin95 , cos95 )) + float2( 0.5,0.5 );
				float4 uvs4_DistortionMask = IN.ase_texcoord;
				uvs4_DistortionMask.xy = IN.ase_texcoord.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float dotResult100 = dot( tex2D( _DistortionMask, ( rotator95 + uvs4_DistortionMask.w + CustomUV89 + ( _TimeParameters.x * _DistortionMaskPanSpeed ) ) ) , _DistortionMaskChannel );
				float Disto107 = ( saturate( dotResult100 ) * _DistortionIntensity );
				float dotResult122 = dot( tex2D( _DissolveMask, ( rotator112 + uvs4_DissolveMask.w + CustomUV89 + ( _TimeParameters.x * _DissolveMaskPanSpeed ) + Disto107 ) ) , _DissolveMaskChannel );
				float temp_output_126_0 = saturate( dotResult122 );
				float lerpResult138 = lerp( temp_output_126_0 , saturate( ( 1.0 - temp_output_126_0 ) ) , _DissolveMaskInvert);
				float4 texCoord141 = IN.ase_texcoord;
				texCoord141.xy = IN.ase_texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_145_0 = ( saturate( lerpResult138 ) + texCoord141.z + _DissolveOffset );
				float2 uv_Texture = IN.ase_texcoord.xy * _Texture_ST.xy + _Texture_ST.zw;
				float cos129 = cos( radians( _TextureRotation ) );
				float sin129 = sin( radians( _TextureRotation ) );
				float2 rotator129 = mul( uv_Texture - float2( 0.5,0.5 ) , float2x2( cos129 , -sin129 , sin129 , cos129 )) + float2( 0.5,0.5 );
				float dotResult140 = dot( tex2D( _Texture, ( rotator129 + ( _TimeParameters.x * _TexturePanSpeed ) + CustomUV89 + Disto107 ) ) , _TextureChannel );
				float temp_output_147_0 = ( temp_output_145_0 * saturate( dotResult140 ) );
				float temp_output_153_0 = ( pow( temp_output_147_0 , _CorePower ) * _CoreIntensity );
				float3 temp_cast_4 = (1.0).xxx;
				float3 temp_output_157_0 = (IN.ase_color).rgb;
				#ifdef _MESHVERTEXCOLOR_ON
				float3 staticSwitch159 = temp_output_157_0;
				#else
				float3 staticSwitch159 = temp_cast_4;
				#endif
				float3 temp_output_167_0 = saturate( ( ( IN.ase_color.a * saturate( ( temp_output_153_0 + ( temp_output_147_0 * _GlowIntensity ) ) ) * staticSwitch159 ) * _AlphaBoldness ) );
				float3 temp_cast_5 = (_ValueStep).xxx;
				float3 temp_cast_6 = (( _ValueStep + _ValueStepAdd )).xxx;
				float3 smoothstepResult170 = smoothstep( temp_cast_5 , temp_cast_6 , temp_output_167_0);
				#ifdef _STEP_ON
				float3 staticSwitch183 = saturate( smoothstepResult170 );
				#else
				float3 staticSwitch183 = temp_output_167_0;
				#endif
				float4 screenPos = IN.ase_texcoord2;
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float screenDepth213 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth213 = ( screenDepth213 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _DepthFadeIntensity );
				float temp_output_236_0 = saturate( distanceDepth213 );
				#ifdef _USEDEPTHFADE_ON
				float3 staticSwitch239 = ( staticSwitch183 * temp_output_236_0 );
				#else
				float3 staticSwitch239 = staticSwitch183;
				#endif
				

				surfaceDescription.Alpha = staticSwitch239.x;
				surfaceDescription.AlphaClipThreshold = 0.5;

				#if _ALPHATEST_ON
					float alphaClipThreshold = 0.01f;
					#if ALPHA_CLIP_THRESHOLD
						alphaClipThreshold = surfaceDescription.AlphaClipThreshold;
					#endif
					clip(surfaceDescription.Alpha - alphaClipThreshold);
				#endif

				half4 outColor = 0;
				outColor = _SelectionID;

				return outColor;
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "DepthNormals"
			Tags { "LightMode"="DepthNormalsOnly" }

			ZTest LEqual
			ZWrite On

			HLSLPROGRAM

        	#pragma multi_compile_instancing
        	#pragma multi_compile_fragment _ LOD_FADE_CROSSFADE
        	#define ASE_FOG 1
        	#define _SURFACE_TYPE_TRANSPARENT 1
        	#define ASE_VERSION 19701
        	#define ASE_SRP_VERSION 150006
        	#define REQUIRE_DEPTH_TEXTURE 1


        	#pragma multi_compile_fragment _ _GBUFFER_NORMALS_OCT

			#pragma vertex vert
			#pragma fragment frag

			#define ATTRIBUTES_NEED_NORMAL
			#define ATTRIBUTES_NEED_TANGENT
			#define VARYINGS_NEED_NORMAL_WS

			#define SHADERPASS SHADERPASS_DEPTHNORMALSONLY

			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
			#include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"

            #if defined(LOD_FADE_CROSSFADE)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/LODCrossFade.hlsl"
            #endif

			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_SCREEN_POSITION
			#pragma shader_feature_local _USEDEPTHFADE_ON
			#pragma shader_feature_local _STEP_ON
			#pragma shader_feature_local _CUSTOMPANSWITCH_ON
			#pragma shader_feature_local _MESHVERTEXCOLOR_ON


			struct VertexInput
			{
				float4 positionOS : POSITION;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 positionCS : SV_POSITION;
				float4 clipPosV : TEXCOORD0;
				float3 normalWS : TEXCOORD1;
				float4 ase_color : COLOR;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _DissolveMaskChannel;
			float4 _Texture_ST;
			float4 _DissolveMask_ST;
			float4 _GradientShapeChannel;
			float4 _TextureChannel;
			float4 _GradientShape_ST;
			float4 _CoreColor;
			float4 _DistortionMaskChannel;
			float4 _ColorTexture_ST;
			float4 _DistortionMask_ST;
			float2 _DistortionMaskPanSpeed;
			float2 _TexturePanSpeed;
			float2 _DissolveMaskPanSpeed;
			float _CoreIntensity;
			float _DifferentCoreColor;
			float _CorePower;
			float _EmissionIntensity;
			float _GlowIntensity;
			float _AlphaBoldness;
			float _TextureRotation;
			float _ValueStep;
			float _GradientMapDisplacement;
			float _Cull;
			float _DissolveOffset;
			float _DissolveMaskInvert;
			float _ValueStepAdd;
			float _DissolveMaskRotation;
			float _GradientShapeRotation;
			float _DistortionIntensity;
			float _DistortionMaskRotation;
			float _ColorRotation;
			float _ZTest;
			float _ZWrite;
			float _Dst;
			float _Src;
			float _InvertGradient;
			float _DepthFadeIntensity;
			#ifdef ASE_TESSELLATION
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END

			sampler2D _DissolveMask;
			sampler2D _DistortionMask;
			sampler2D _Texture;


			
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

				o.ase_color = v.ase_color;
				o.ase_texcoord2 = v.ase_texcoord;
				o.ase_texcoord3.xy = v.ase_texcoord1.xy;
				
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

				o.positionCS = vertexInput.positionCS;
				o.clipPosV = vertexInput.positionCS;
				o.normalWS = TransformObjectToWorldNormal( v.normalOS );
				return o;
			}

			#if defined(ASE_TESSELLATION)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 normalOS : NORMAL;
				float4 ase_color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_texcoord1 : TEXCOORD1;

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
				o.ase_color = v.ase_color;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_texcoord1 = v.ase_texcoord1;
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
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_texcoord1 = patch[0].ase_texcoord1 * bary.x + patch[1].ase_texcoord1 * bary.y + patch[2].ase_texcoord1 * bary.z;
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

			void frag( VertexOutput IN
				, out half4 outNormalWS : SV_Target0
			#ifdef _WRITE_RENDERING_LAYERS
				, out float4 outRenderingLayers : SV_Target1
			#endif
				 )
			{
				float4 ClipPos = IN.clipPosV;
				float4 ScreenPos = ComputeScreenPos( IN.clipPosV );

				float2 uv_DissolveMask = IN.ase_texcoord2.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float cos112 = cos( radians( _DissolveMaskRotation ) );
				float sin112 = sin( radians( _DissolveMaskRotation ) );
				float2 rotator112 = mul( uv_DissolveMask - float2( 0.5,0.5 ) , float2x2( cos112 , -sin112 , sin112 , cos112 )) + float2( 0.5,0.5 );
				float4 uvs4_DissolveMask = IN.ase_texcoord2;
				uvs4_DissolveMask.xy = IN.ase_texcoord2.xy * _DissolveMask_ST.xy + _DissolveMask_ST.zw;
				float2 temp_cast_0 = (0.0).xx;
				float2 texCoord83 = IN.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				#ifdef _CUSTOMPANSWITCH_ON
				float2 staticSwitch85 = texCoord83;
				#else
				float2 staticSwitch85 = temp_cast_0;
				#endif
				float2 CustomUV89 = staticSwitch85;
				float2 uv_DistortionMask = IN.ase_texcoord2.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float cos95 = cos( radians( _DistortionMaskRotation ) );
				float sin95 = sin( radians( _DistortionMaskRotation ) );
				float2 rotator95 = mul( uv_DistortionMask - float2( 0.5,0.5 ) , float2x2( cos95 , -sin95 , sin95 , cos95 )) + float2( 0.5,0.5 );
				float4 uvs4_DistortionMask = IN.ase_texcoord2;
				uvs4_DistortionMask.xy = IN.ase_texcoord2.xy * _DistortionMask_ST.xy + _DistortionMask_ST.zw;
				float dotResult100 = dot( tex2D( _DistortionMask, ( rotator95 + uvs4_DistortionMask.w + CustomUV89 + ( _TimeParameters.x * _DistortionMaskPanSpeed ) ) ) , _DistortionMaskChannel );
				float Disto107 = ( saturate( dotResult100 ) * _DistortionIntensity );
				float dotResult122 = dot( tex2D( _DissolveMask, ( rotator112 + uvs4_DissolveMask.w + CustomUV89 + ( _TimeParameters.x * _DissolveMaskPanSpeed ) + Disto107 ) ) , _DissolveMaskChannel );
				float temp_output_126_0 = saturate( dotResult122 );
				float lerpResult138 = lerp( temp_output_126_0 , saturate( ( 1.0 - temp_output_126_0 ) ) , _DissolveMaskInvert);
				float4 texCoord141 = IN.ase_texcoord2;
				texCoord141.xy = IN.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_145_0 = ( saturate( lerpResult138 ) + texCoord141.z + _DissolveOffset );
				float2 uv_Texture = IN.ase_texcoord2.xy * _Texture_ST.xy + _Texture_ST.zw;
				float cos129 = cos( radians( _TextureRotation ) );
				float sin129 = sin( radians( _TextureRotation ) );
				float2 rotator129 = mul( uv_Texture - float2( 0.5,0.5 ) , float2x2( cos129 , -sin129 , sin129 , cos129 )) + float2( 0.5,0.5 );
				float dotResult140 = dot( tex2D( _Texture, ( rotator129 + ( _TimeParameters.x * _TexturePanSpeed ) + CustomUV89 + Disto107 ) ) , _TextureChannel );
				float temp_output_147_0 = ( temp_output_145_0 * saturate( dotResult140 ) );
				float temp_output_153_0 = ( pow( temp_output_147_0 , _CorePower ) * _CoreIntensity );
				float3 temp_cast_4 = (1.0).xxx;
				float3 temp_output_157_0 = (IN.ase_color).rgb;
				#ifdef _MESHVERTEXCOLOR_ON
				float3 staticSwitch159 = temp_output_157_0;
				#else
				float3 staticSwitch159 = temp_cast_4;
				#endif
				float3 temp_output_167_0 = saturate( ( ( IN.ase_color.a * saturate( ( temp_output_153_0 + ( temp_output_147_0 * _GlowIntensity ) ) ) * staticSwitch159 ) * _AlphaBoldness ) );
				float3 temp_cast_5 = (_ValueStep).xxx;
				float3 temp_cast_6 = (( _ValueStep + _ValueStepAdd )).xxx;
				float3 smoothstepResult170 = smoothstep( temp_cast_5 , temp_cast_6 , temp_output_167_0);
				#ifdef _STEP_ON
				float3 staticSwitch183 = saturate( smoothstepResult170 );
				#else
				float3 staticSwitch183 = temp_output_167_0;
				#endif
				float4 ase_screenPosNorm = ScreenPos / ScreenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				float screenDepth213 = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH( ase_screenPosNorm.xy ),_ZBufferParams);
				float distanceDepth213 = ( screenDepth213 - LinearEyeDepth( ase_screenPosNorm.z,_ZBufferParams ) ) / ( _DepthFadeIntensity );
				float temp_output_236_0 = saturate( distanceDepth213 );
				#ifdef _USEDEPTHFADE_ON
				float3 staticSwitch239 = ( staticSwitch183 * temp_output_236_0 );
				#else
				float3 staticSwitch239 = staticSwitch183;
				#endif
				

				float Alpha = staticSwitch239.x;
				float AlphaClipThreshold = 0.5;

				#if _ALPHATEST_ON
					clip( Alpha - AlphaClipThreshold );
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODFadeCrossFade( IN.positionCS );
				#endif

				#if defined(_GBUFFER_NORMALS_OCT)
					float3 normalWS = normalize(IN.normalWS);
					float2 octNormalWS = PackNormalOctQuadEncode(normalWS);           // values between [-1, +1], must use fp32 on some platforms
					float2 remappedOctNormalWS = saturate(octNormalWS * 0.5 + 0.5);   // values between [ 0,  1]
					half3 packedNormalWS = PackFloat2To888(remappedOctNormalWS);      // values between [ 0,  1]
					outNormalWS = half4(packedNormalWS, 0.0);
				#else
					float3 normalWS = IN.normalWS;
					outNormalWS = half4(NormalizeNormalPerPixel(normalWS), 0.0);
				#endif

				#ifdef _WRITE_RENDERING_LAYERS
					uint renderingLayers = GetMeshRenderingLayer();
					outRenderingLayers = float4(EncodeMeshRenderingLayer(renderingLayers), 0, 0, 0);
				#endif
			}

			ENDHLSL
		}

	
	}
	
	CustomEditor "UnityEditor.ShaderGraphUnlitGUI"
	FallBack "Hidden/Shader Graph/FallbackError"
	
	Fallback Off
}
/*ASEBEGIN
Version=19701
Node;AmplifyShaderEditor.CommentaryNode;81;-5920,-512;Inherit;False;1052.771;508.8153;PanInCustomUV;4;89;85;84;83;PanInCustomUV;0,0,0,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;82;-6112,-1536;Inherit;False;3687.623;895.329;Distortion;18;107;106;102;103;100;98;99;97;96;95;94;93;92;91;90;88;87;86;Distortion;0,0,0,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;84;-5888,-384;Inherit;False;Constant;_Value0;Value0;26;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;83;-5888,-256;Inherit;False;1;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;85;-5504,-384;Inherit;False;Property;_CustomPanSwitch;CustomPanSwitch;31;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT2;0,0;False;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT2;0,0;False;6;FLOAT2;0,0;False;7;FLOAT2;0,0;False;8;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;87;-6016,-1408;Inherit;True;Property;_DistortionMask;Distortion Mask;12;0;Create;True;0;0;0;False;3;Space(33);Header(Distortion);Space(13);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode;86;-5376,-1152;Inherit;False;Property;_DistortionMaskRotation;Distortion Mask Rotation;14;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;91;-4608,-896;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;92;-5376,-1280;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RadiansOpNode;90;-5120,-1152;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;89;-5120,-384;Inherit;False;CustomUV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;88;-4608,-816;Inherit;False;Property;_DistortionMaskPanSpeed;Distortion Mask Pan Speed;15;0;Create;True;0;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;94;-4352,-896;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;96;-4608,-1024;Inherit;False;89;CustomUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RotatorNode;95;-5120,-1280;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;93;-5376,-1024;Inherit;False;0;-1;4;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;97;-4224,-1280;Inherit;False;4;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;98;-3968,-1408;Inherit;True;Property;_TextureSample5;Texture Sample 5;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.Vector4Node;99;-3584,-1280;Inherit;False;Property;_DistortionMaskChannel;Distortion Mask Channel;13;0;Create;True;0;0;0;False;0;False;0,1,0,0;0,1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DotProductOpNode;100;-3584,-1408;Inherit;False;2;0;COLOR;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;101;-7248,592;Inherit;False;2848.594;729.824;Dissolve Mask;24;145;143;142;141;138;136;135;133;126;122;120;119;117;116;115;114;113;112;111;110;109;108;105;104;Dissolve Mask;0,0,0,1;0;0
Node;AmplifyShaderEditor.SaturateNode;102;-3456,-1408;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;103;-3072,-1280;Inherit;False;Property;_DistortionIntensity;Distortion Intensity;16;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;104;-6928,832;Inherit;False;Property;_DissolveMaskRotation;Dissolve Mask Rotation;19;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-3072,-1408;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;105;-7200,640;Inherit;True;Property;_DissolveMask;Dissolve Mask;17;0;Create;True;0;0;0;False;3;Space(33);Header(Dissolve);Space(13);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.Vector2Node;108;-6608,1152;Inherit;False;Property;_DissolveMaskPanSpeed;Dissolve Mask Pan Speed;20;0;Create;True;0;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;109;-6800,704;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RadiansOpNode;110;-6672,864;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;111;-6592,1072;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;107;-2816,-1408;Inherit;False;Disto;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;112;-6496,720;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;113;-6480,944;Inherit;False;89;CustomUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;114;-6928,944;Inherit;False;0;-1;4;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;115;-6496,1024;Inherit;False;107;Disto;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;116;-6352,1072;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;117;-6256,720;Inherit;False;5;5;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;118;-5984,1392;Inherit;False;1840.216;539.6607;Main Texture;15;146;140;139;137;134;132;131;130;129;128;127;125;124;123;121;Main Texture;0,0,0,1;0;0
Node;AmplifyShaderEditor.Vector4Node;119;-6000,848;Inherit;False;Property;_DissolveMaskChannel;Dissolve Mask Channel;18;0;Create;True;0;0;0;False;0;False;0,1,0,0;0,1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;120;-6064,640;Inherit;True;Property;_TextureSample3;Texture Sample 3;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.DotProductOpNode;122;-5728,704;Inherit;False;2;0;COLOR;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;123;-5824,1648;Inherit;False;Property;_TextureRotation;Texture Rotation;2;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;121;-5936,1440;Inherit;True;Property;_Texture;Texture;0;0;Create;True;0;0;0;False;3;Space(33);Header(Main Texture);Space(13);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SimpleTimeNode;124;-5376,1648;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;125;-5664,1520;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;126;-5504,704;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;127;-5392,1712;Inherit;False;Property;_TexturePanSpeed;Texture Pan Speed;3;0;Create;True;0;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RadiansOpNode;128;-5584,1648;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;129;-5408,1520;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;130;-5136,1872;Inherit;False;107;Disto;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;131;-5168,1648;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;132;-5152,1792;Inherit;False;89;CustomUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;133;-5376,800;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;134;-4944,1520;Inherit;False;4;4;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;135;-5328,896;Inherit;False;Property;_DissolveMaskInvert;Dissolve Mask Invert;21;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;136;-5200,800;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector4Node;137;-4688,1680;Inherit;False;Property;_TextureChannel;Texture Channel;1;0;Create;True;0;0;0;False;0;False;0,1,0,0;0,1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;138;-5008,704;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;139;-4784,1456;Inherit;True;Property;_TextureSample1;Texture Sample 1;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.DotProductOpNode;140;-4464,1504;Inherit;False;2;0;COLOR;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;141;-4816,896;Inherit;False;0;-1;4;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;143;-4800,784;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;142;-4736,1088;Inherit;False;Property;_DissolveOffset;Dissolve Offset;22;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;144;-3968,752;Inherit;False;1086.786;483.4392;Adjustments;9;223;158;155;153;152;151;150;149;148;Adjustments;0,0,0,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;145;-4560,784;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;146;-4304,1504;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;147;-4144,800;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;148;-3856,896;Inherit;False;Property;_CorePower;Core Power;26;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;149;-3712,800;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;150;-3904,1120;Inherit;False;Property;_GlowIntensity;Glow Intensity;28;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;151;-3600,912;Inherit;False;Property;_CoreIntensity;Core Intensity;27;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;152;-3712,1040;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;153;-3424,816;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;154;-2688,128;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;155;-3216,1024;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;157;-2432,128;Inherit;False;True;True;True;False;1;0;COLOR;0,0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;156;-2176,768;Inherit;False;Constant;_Value1;Value1;28;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;158;-3040,1008;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;159;-1920,768;Inherit;False;Property;_MeshVertexColor;MeshVertexColor;32;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;160;-1920,512;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;161;-1536,640;Inherit;False;Property;_AlphaBoldness;Alpha Boldness;29;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;165;-2176,1024;Inherit;False;Property;_ValueStep;Value Step;34;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;164;-2176,1152;Inherit;False;Property;_ValueStepAdd;Value Step Add;35;0;Create;True;0;0;0;False;0;False;0.1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;162;-1536,512;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode;242;-816,1344;Inherit;False;324;418.95;Depth Fade;3;219;213;236;Depth Fade;0,0,0,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;166;-1152,1152;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;167;-1280,512;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;219;-768,1664;Inherit;False;Property;_DepthFadeIntensity;Depth Fade Intensity;37;0;Create;True;0;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;170;-1152,1024;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;1,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DepthFade;213;-768,1536;Inherit;False;True;False;False;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;174;-896,1024;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;236;-768,1408;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;183;-896,512;Inherit;False;Property;_Step;Step;33;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode;163;-2048,1920;Inherit;False;1535.601;892.1229;Push Particle toward camera direction (no more glow clipping in the ground) | 0=Disabled;9;240;168;169;171;177;173;175;221;172;;0,0,0,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;15;462,-50;Inherit;False;1252;163.3674;Ge Lush was here! <3;5;10;11;12;13;14;Ge Lush was here! <3;0.4902092,0.3301886,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;176;-4640,-480;Inherit;False;1654.745;429.7096;Color Texture;11;210;202;199;192;191;190;189;187;184;181;180;Color Texture;0,0,0,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;178;-6480,16;Inherit;False;1951.449;483.7219;Gradient Shape;12;232;231;230;229;220;218;216;215;214;208;207;206;Gradient Shape;0,0,0,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;179;-4352,-48;Inherit;False;1447.081;551.8389;Gradient Map;10;226;225;222;209;205;203;196;186;185;182;Gradient Map;0,0,0,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;235;-448,416;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;10;512,0;Inherit;False;Property;_Cull;Cull;38;0;Create;True;0;0;0;True;3;Space(33);Header(AR);Space(13);False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;11;768,0;Inherit;False;Property;_Src;Src;39;0;Create;True;0;0;0;True;0;False;5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;12;1024,0.7006989;Inherit;False;Property;_Dst;Dst;40;0;Create;True;0;0;0;True;0;False;10;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;13;1280,0;Inherit;False;Property;_ZWrite;ZWrite;41;0;Create;True;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;233;-1024,-256;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;217;-1280,-256;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;224;-896,-256;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;234;-640,-256;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT3;0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;228;-384,-128;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;239;-384,128;Inherit;False;Property;_UseDepthFade1;Use Depth Fade;36;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Reference;238;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WorldPosInputsNode;172;-1920,2048;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;221;-1280,2048;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;175;-1664,2048;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WorldSpaceCameraPos;173;-1920,2192;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;177;-1280,2176;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.01;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;171;-1280,2304;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;169;-1920,2432;Inherit;False;Property;_CameraDirPush;CameraDirPush;30;0;Create;True;0;0;0;False;0;False;0;-50;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;168;-1920,2560;Inherit;False;3;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;240;-1024,2048;Inherit;False;cameraPush;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;241;0,256;Inherit;False;240;cameraPush;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;180;-4000,-224;Inherit;False;89;CustomUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;181;-3248,-192;Inherit;False;3;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ComponentMaskNode;184;-3200,-432;Inherit;False;True;True;True;False;1;0;COLOR;0,0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;185;-3968,192;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;187;-3776,-352;Inherit;False;3;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;189;-4000,-144;Inherit;False;107;Disto;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;190;-4016,-352;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;191;-4480,-224;Inherit;False;Property;_ColorRotation;Color Rotation;5;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RadiansOpNode;192;-4224,-224;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;196;-3776,208;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;197;-4496,224;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;200;-2944,-256;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;202;-4304,-352;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;203;-4112,192;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;205;-3600,224;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;206;-4688,224;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector4Node;207;-5248,288;Inherit;False;Property;_GradientShapeChannel;Gradient Shape Channel;7;0;Create;True;0;0;0;False;0;False;0,1,0,0;0,1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;210;-3536,-432;Inherit;True;Property;_TextureSample4;Texture Sample 4;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SamplerNode;214;-5280,64;Inherit;True;Property;_TextureSample2;Texture Sample 2;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.SimpleAddOpNode;215;-5456,128;Inherit;False;3;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;216;-5648,272;Inherit;False;89;CustomUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RotatorNode;218;-5680,128;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;220;-5616,368;Inherit;False;107;Disto;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;222;-3136,176;Inherit;False;True;True;True;False;1;0;COLOR;0,0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;223;-3040,816;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;225;-4304,240;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;226;-3440,192;Inherit;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.TextureCoordinatesNode;231;-5952,128;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DotProductOpNode;232;-4896,224;Inherit;False;2;0;COLOR;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;204;-2816,-256;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;198;-2304,-256;Inherit;False;3;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;211;-1664,-128;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;188;-1920,-128;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;201;-1920,0;Inherit;False;Property;_CoreColor;Core Color;24;0;Create;True;0;0;0;False;0;False;1,1,1,0;1,1,1,0;True;True;0;6;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT3;5
Node;AmplifyShaderEditor.RangedFloatNode;209;-3840,384;Inherit;False;Property;_GradientMapDisplacement;Gradient Map Displacement;10;0;Create;True;0;0;0;False;0;False;0.1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;14;1536,0;Inherit;False;Property;_ZTest;ZTest;42;0;Create;True;0;0;0;True;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;238;-384,-256;Inherit;False;Property;_UseDepthFade;Use Depth Fade;36;0;Create;True;0;0;0;False;3;Space(33);Header(Depth Fade);Space(13);False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexturePropertyNode;230;-6432,64;Inherit;True;Property;_GradientShape;Gradient Shape;6;0;Create;True;0;0;0;False;3;Space(33);Header(Gradient Shape);Space(13);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode;229;-6272,256;Inherit;False;Property;_GradientShapeRotation;Gradient Shape Rotation;8;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RadiansOpNode;208;-5888,256;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;182;-3712,0;Inherit;True;Property;_GradientMap;Gradient Map;9;0;Create;True;0;0;0;False;3;Space(33);Header(Gradient Map);Space(13);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode;186;-4064,304;Inherit;False;Property;_InvertGradient;Invert Gradient;11;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;199;-4592,-432;Inherit;True;Property;_ColorTexture;Color Texture;4;0;Create;True;0;0;0;False;3;Space(33);Header(Color Texture);Space(13);False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode;212;-1280,-128;Inherit;False;Property;_DifferentCoreColor;Different Core Color;25;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;193;-896,-128;Inherit;False;Property;_EmissionIntensity;Emission Intensity;23;0;Create;True;0;0;0;False;3;Space(33);Header(Properties);Space(13);False;1;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;1;New Amplify Shader;2992e84f91cbeb14eab234972e07ea9d;True;ExtraPrePass;0;0;ExtraPrePass;5;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1;0,0;Float;False;True;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;13;Vefects/SH_VFX_Stylized_Dissolve;2992e84f91cbeb14eab234972e07ea9d;True;Forward;0;1;Forward;8;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;True;True;0;True;_Cull;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Transparent=RenderType;Queue=Transparent=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;True;True;2;5;True;_Src;10;True;_Dst;1;1;False;;10;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;2;False;_ZWrite;True;3;True;_ZTest;True;True;0;False;;0;False;;True;1;LightMode=UniversalForwardOnly;False;False;0;;0;0;Standard;23;Surface;1;638463264845950016;  Blend;0;0;Two Sided;1;0;Forward Only;0;0;Alpha Clipping;0;638774900561332734;  Use Shadow Threshold;0;0;Cast Shadows;0;638463266204850631;Receive Shadows;1;0;GPU Instancing;1;0;LOD CrossFade;1;0;Built-in Fog;1;0;Meta Pass;0;0;Extra Pre Pass;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,;0;  Type;0;0;  Tess;16,False,;0;  Min;10,False,;0;  Max;25,False,;0;  Edge Length;16,False,;0;  Max Displacement;25,False,;0;Vertex Position,InvertActionOnDeselection;1;638485006437223309;0;10;False;True;False;True;False;False;True;True;True;False;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;2;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;1;New Amplify Shader;2992e84f91cbeb14eab234972e07ea9d;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=ShadowCaster;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;1;New Amplify Shader;2992e84f91cbeb14eab234972e07ea9d;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;True;False;False;False;False;0;False;;False;False;False;False;False;False;False;False;False;True;1;False;;False;False;True;1;LightMode=DepthOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;4;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;1;New Amplify Shader;2992e84f91cbeb14eab234972e07ea9d;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;5;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;1;New Amplify Shader;2992e84f91cbeb14eab234972e07ea9d;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;False;True;1;1;False;;0;False;;0;1;False;;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;LightMode=Universal2D;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;6;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;1;New Amplify Shader;2992e84f91cbeb14eab234972e07ea9d;True;SceneSelectionPass;0;6;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=SceneSelectionPass;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;7;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;1;New Amplify Shader;2992e84f91cbeb14eab234972e07ea9d;True;ScenePickingPass;0;7;ScenePickingPass;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Picking;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;8;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;1;New Amplify Shader;2992e84f91cbeb14eab234972e07ea9d;True;DepthNormals;0;8;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormalsOnly;False;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;9;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraphUnlitGUI;0;1;New Amplify Shader;2992e84f91cbeb14eab234972e07ea9d;True;DepthNormalsOnly;0;9;DepthNormalsOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;False;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;UniversalMaterialType=Unlit;True;5;True;12;all;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;;True;3;False;;False;True;1;LightMode=DepthNormalsOnly;False;True;9;d3d11;metal;vulkan;xboxone;xboxseries;playstation;ps4;ps5;switch;0;;0;0;Standard;0;False;0
WireConnection;85;1;84;0
WireConnection;85;0;83;0
WireConnection;92;2;87;0
WireConnection;90;0;86;0
WireConnection;89;0;85;0
WireConnection;94;0;91;0
WireConnection;94;1;88;0
WireConnection;95;0;92;0
WireConnection;95;2;90;0
WireConnection;93;2;87;0
WireConnection;97;0;95;0
WireConnection;97;1;93;4
WireConnection;97;2;96;0
WireConnection;97;3;94;0
WireConnection;98;0;87;0
WireConnection;98;1;97;0
WireConnection;100;0;98;0
WireConnection;100;1;99;0
WireConnection;102;0;100;0
WireConnection;106;0;102;0
WireConnection;106;1;103;0
WireConnection;109;2;105;0
WireConnection;110;0;104;0
WireConnection;107;0;106;0
WireConnection;112;0;109;0
WireConnection;112;2;110;0
WireConnection;114;2;105;0
WireConnection;116;0;111;0
WireConnection;116;1;108;0
WireConnection;117;0;112;0
WireConnection;117;1;114;4
WireConnection;117;2;113;0
WireConnection;117;3;116;0
WireConnection;117;4;115;0
WireConnection;120;0;105;0
WireConnection;120;1;117;0
WireConnection;122;0;120;0
WireConnection;122;1;119;0
WireConnection;125;2;121;0
WireConnection;126;0;122;0
WireConnection;128;0;123;0
WireConnection;129;0;125;0
WireConnection;129;2;128;0
WireConnection;131;0;124;0
WireConnection;131;1;127;0
WireConnection;133;0;126;0
WireConnection;134;0;129;0
WireConnection;134;1;131;0
WireConnection;134;2;132;0
WireConnection;134;3;130;0
WireConnection;136;0;133;0
WireConnection;138;0;126;0
WireConnection;138;1;136;0
WireConnection;138;2;135;0
WireConnection;139;0;121;0
WireConnection;139;1;134;0
WireConnection;140;0;139;0
WireConnection;140;1;137;0
WireConnection;143;0;138;0
WireConnection;145;0;143;0
WireConnection;145;1;141;3
WireConnection;145;2;142;0
WireConnection;146;0;140;0
WireConnection;147;0;145;0
WireConnection;147;1;146;0
WireConnection;149;0;147;0
WireConnection;149;1;148;0
WireConnection;152;0;147;0
WireConnection;152;1;150;0
WireConnection;153;0;149;0
WireConnection;153;1;151;0
WireConnection;155;0;153;0
WireConnection;155;1;152;0
WireConnection;157;0;154;0
WireConnection;158;0;155;0
WireConnection;159;1;156;0
WireConnection;159;0;157;0
WireConnection;160;0;154;4
WireConnection;160;1;158;0
WireConnection;160;2;159;0
WireConnection;162;0;160;0
WireConnection;162;1;161;0
WireConnection;166;0;165;0
WireConnection;166;1;164;0
WireConnection;167;0;162;0
WireConnection;170;0;167;0
WireConnection;170;1;165;0
WireConnection;170;2;166;0
WireConnection;213;0;219;0
WireConnection;174;0;170;0
WireConnection;236;0;213;0
WireConnection;183;1;167;0
WireConnection;183;0;174;0
WireConnection;235;0;183;0
WireConnection;235;1;236;0
WireConnection;233;0;217;0
WireConnection;217;0;198;0
WireConnection;217;1;211;0
WireConnection;217;2;212;0
WireConnection;224;0;233;0
WireConnection;224;1;193;0
WireConnection;234;0;224;0
WireConnection;234;1;183;0
WireConnection;228;0;234;0
WireConnection;228;1;236;0
WireConnection;239;1;183;0
WireConnection;239;0;235;0
WireConnection;221;0;175;0
WireConnection;221;1;177;0
WireConnection;175;0;172;0
WireConnection;175;1;173;0
WireConnection;177;0;171;0
WireConnection;171;0;169;0
WireConnection;171;1;168;2
WireConnection;240;0;221;0
WireConnection;184;0;210;0
WireConnection;185;0;203;0
WireConnection;187;0;190;0
WireConnection;187;1;180;0
WireConnection;187;2;189;0
WireConnection;190;0;202;0
WireConnection;190;2;192;0
WireConnection;192;0;191;0
WireConnection;196;0;185;0
WireConnection;196;1;225;0
WireConnection;196;2;186;0
WireConnection;197;0;206;0
WireConnection;197;1;145;0
WireConnection;200;0;184;0
WireConnection;200;1;181;1
WireConnection;202;2;199;0
WireConnection;203;0;225;0
WireConnection;205;0;196;0
WireConnection;205;1;209;0
WireConnection;206;0;232;0
WireConnection;210;0;199;0
WireConnection;210;1;187;0
WireConnection;214;0;230;0
WireConnection;214;1;215;0
WireConnection;215;0;218;0
WireConnection;215;1;216;0
WireConnection;215;2;220;0
WireConnection;218;0;231;0
WireConnection;218;2;208;0
WireConnection;222;0;226;0
WireConnection;223;0;153;0
WireConnection;225;0;197;0
WireConnection;226;0;182;0
WireConnection;226;1;205;0
WireConnection;231;2;230;0
WireConnection;232;0;214;0
WireConnection;232;1;207;0
WireConnection;204;0;200;0
WireConnection;198;0;204;0
WireConnection;198;1;222;0
WireConnection;198;2;157;0
WireConnection;211;0;188;0
WireConnection;188;0;198;0
WireConnection;188;1;201;0
WireConnection;188;2;223;0
WireConnection;238;1;234;0
WireConnection;238;0;228;0
WireConnection;208;0;229;0
WireConnection;1;2;238;0
WireConnection;1;3;239;0
ASEEND*/
//CHKSM=C59269F0B4BD35B176B8784C9968C1AB501E1DDB