// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "AxisDissolveSpecular"
{
	Properties
	{
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[Header(PBR Settings)][NoScaleOffset]_Albedo("Albedo", 2D) = "white" {}
		_Color("Color", Color) = (0,0,0,1)
		[NoScaleOffset][Normal]_NormalTexture("Normal Texture", 2D) = "bump" {}
		[NoScaleOffset]_SpecularTexture("Specular Texture", 2D) = "white" {}
		_SmoothnessValue("Smoothness Value", Range( 0 , 1)) = 0
		[NoScaleOffset]_EmissionTexture("Emission Texture", 2D) = "black" {}
		[HDR]_EmissionColor("Emission Color", Color) = (0,0,0,0)
		[NoScaleOffset]_OcclusionMap("Occlusion Map", 2D) = "white" {}
		[Header(Main Dissolve Settings)][Space]_DissolveAmount("Dissolve Amount", Range( 0 , 1)) = 1
		_MinValueWhenAmount0("Min Value (When Amount = 0)", Float) = 0
		_MaxValueWhenAmount1("Max Value (When Amount = 1)", Float) = 3
		[KeywordEnum(X,Y,Z)] _Axis("Axis", Float) = 1
		[Toggle(_USETRIPLANARUVS_ON)] _UseTriplanarUvs("Use Triplanar Uvs", Float) = 0
		[KeywordEnum(Albedo,Emission)] _EdgesAffect("EdgesAffect", Float) = 1
		[Toggle(_INVERTDIRECTIONMINMAX_ON)] _InvertDirectionMinMax("Invert Direction (Min & Max)", Float) = 0
		[Header(Dissolve Guide)][NoScaleOffset][Space]_GuideTexture("Guide Texture", 2D) = "white" {}
		_GuideTilling("Guide Tilling", Float) = 1
		_GuideTillingSpeed("Guide Tilling Speed", Range( -0.4 , 0.4)) = 0.005
		_GuideStrength("Guide Strength", Range( 0 , 10)) = 0
		[Toggle(_GUIDEAFFECTSEDGESBLENDING_ON)] _GuideAffectsEdgesBlending("Guide Affects Edges Blending", Float) = 0
		[Header(Vertex Displacement)]_VertexDisplacementMainEdge("Vertex Displacement Main Edge ", Range( 0 , 2)) = 0
		_VertexDisplacementSecondEdge("Vertex Displacement Second Edge", Range( 0 , 2)) = 0
		[NoScaleOffset]_DisplacementGuide(" Displacement Guide", 2D) = "white" {}
		_DisplacementGuideTillingSpeed("Displacement Guide Tilling Speed", Range( 0 , 0.2)) = 0.005
		_DisplacementGuideTilling("Displacement Guide Tilling", Float) = 1
		[Header(Main Edge)]_MainEdgeWidth("Main Edge Width", Range( 0 , 0.5)) = 0.01308131
		[NoScaleOffset]_MainEdgePattern("Main Edge Pattern", 2D) = "black" {}
		_MainEdgePatternTilling("Main Edge Pattern Tilling", Float) = 1
		[HDR]_MainEdgeColor1("Main Edge Color 1", Color) = (0,0.171536,1,1)
		[HDR]_MainEdgeColor2("Main Edge Color 2", Color) = (1,0,0.5446758,1)
		[Header(Second Edge)]_SecondEdgeWidth("Second Edge Width", Range( 0 , 0.5)) = 0.02225761
		[NoScaleOffset]_SecondEdgePattern("Second Edge Pattern", 2D) = "black" {}
		_SecondEdgePatternTilling("Second Edge Pattern Tilling", Float) = 1
		[HDR]_SecondEdgeColor1("Second Edge Color 1", Color) = (0,0.171536,1,1)
		[HDR]_SecondEdgeColor2("Second Edge Color 2", Color) = (1,0,0.5446758,1)
		[Toggle(_2SIDESSECONDEDGE_ON)] _2SidesSecondEdge("2 Sides Second Edge", Float) = 1
		[ASEEnd]_SpecularValue("Specular Value", Color) = (0,0,0,0)
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
	}

	SubShader
	{
		LOD 0

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" "Queue"="Geometry" }
		Cull Back
		AlphaToMask Off
		
		HLSLINCLUDE
		#pragma target 3.0

		#pragma prefer_hlslcc gles
		#pragma exclude_renderers d3d11_9x 


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
			
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _NORMAL_DROPOFF_TS 1
			#define _SPECULAR_SETUP 1
			#define _EMISSION
			#define _ALPHATEST_ON 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70701

			
			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS
			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
			#pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
			#pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
			#pragma multi_compile _ _SHADOWS_SOFT
			#pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
			
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_FORWARD

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			
			#if ASE_SRP_VERSION <= 70108
			#define REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR
			#endif

			#if defined(UNITY_INSTANCING_ENABLED) && defined(_TERRAIN_INSTANCED_PERPIXEL_NORMAL)
			    #define ENABLE_TERRAIN_PERPIXEL_NORMAL
			#endif

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_POSITION
			#define ASE_NEEDS_FRAG_NORMAL
			#pragma multi_compile_local __ _2SIDESSECONDEDGE_ON
			#pragma multi_compile_local __ _GUIDEAFFECTSEDGESBLENDING_ON
			#pragma multi_compile_local _AXIS_X _AXIS_Y _AXIS_Z
			#pragma multi_compile_local __ _USETRIPLANARUVS_ON
			#pragma shader_feature_local _INVERTDIRECTIONMINMAX_ON
			#pragma shader_feature_local _EDGESAFFECT_ALBEDO _EDGESAFFECT_EMISSION


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord : TEXCOORD0;
				
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
				float4 ase_texcoord7 : TEXCOORD7;
				float4 ase_texcoord8 : TEXCOORD8;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _MainEdgeColor2;
			float4 _MainEdgeColor1;
			float4 _SecondEdgeColor2;
			float4 _SecondEdgeColor1;
			float4 _Color;
			float4 _SpecularValue;
			float _VertexDisplacementSecondEdge;
			float _MainEdgePatternTilling;
			float _SecondEdgePatternTilling;
			float _MainEdgeWidth;
			float _MaxValueWhenAmount1;
			float _GuideStrength;
			float _GuideTillingSpeed;
			float _GuideTilling;
			float _SecondEdgeWidth;
			float _DissolveAmount;
			float _VertexDisplacementMainEdge;
			float _DisplacementGuideTillingSpeed;
			float _DisplacementGuideTilling;
			float _MinValueWhenAmount0;
			float _SmoothnessValue;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _DisplacementGuide;
			sampler2D _GuideTexture;
			sampler2D _Albedo;
			sampler2D _SecondEdgePattern;
			sampler2D _MainEdgePattern;
			sampler2D _NormalTexture;
			sampler2D _EmissionTexture;
			sampler2D _SpecularTexture;
			sampler2D _OcclusionMap;


			inline float4 TriplanarSampling68( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.zy * float2(  nsign.x, 1.0 ), 0, 0) );
				yNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xz * float2(  nsign.y, 1.0 ), 0, 0) );
				zNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xy * float2( -nsign.z, 1.0 ), 0, 0) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			
			inline float4 TriplanarSampling144( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
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
			
			inline float4 TriplanarSampling140( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
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
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float2 temp_cast_0 = (_DisplacementGuideTilling).xx;
				float2 temp_cast_1 = (( _TimeParameters.x * _DisplacementGuideTillingSpeed )).xx;
				float2 texCoord183 = v.texcoord.xy * temp_cast_0 + temp_cast_1;
				float4 tex2DNode186 = tex2Dlod( _DisplacementGuide, float4( texCoord183, 0, 0.0) );
				float DissolveAmount7 = _DissolveAmount;
				#ifdef _2SIDESSECONDEDGE_ON
				float staticSwitch155 = ( _SecondEdgeWidth / 2.0 );
				#else
				float staticSwitch155 = 0.0;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = v.vertex.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = v.vertex.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = v.vertex.xyz.z;
				#else
				float staticSwitch57 = v.vertex.xyz.y;
				#endif
				float2 temp_cast_2 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_3 = (temp_output_177_0).xx;
				float2 texCoord65 = v.texcoord.xy * temp_cast_2 + temp_cast_3;
				float2 temp_cast_4 = (_GuideTilling).xx;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( v.vertex.xyz + temp_output_177_0 ), v.ase_normal, 1.0, temp_cast_4, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2Dlod( _GuideTexture, float4( texCoord65, 0, 0.0) ).r;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				#ifdef _GUIDEAFFECTSEDGESBLENDING_ON
				float staticSwitch96 = temp_output_16_0;
				#else
				float staticSwitch96 = staticSwitch57;
				#endif
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g10 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_108_0 = ( ( staticSwitch96 - temp_output_1_0_g10 ) / ( DissolvelerpB103 - temp_output_1_0_g10 ) );
				float DissolveWithEdges104 = ( DissolveAmount7 + _MainEdgeWidth );
				float EdgesAlpha101 = ( step( ( DissolveAmount7 + staticSwitch155 ) , temp_output_108_0 ) - step( ( DissolveWithEdges104 + staticSwitch155 ) , temp_output_108_0 ) );
				float lerpResult53 = lerp( ( _VertexDisplacementSecondEdge * tex2DNode186.r ) , ( tex2DNode186.r * _VertexDisplacementMainEdge ) , EdgesAlpha101);
				float temp_output_1_0_g9 = DissolvelerpA102;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float smoothstepResult98 = smoothstep( 0.0 , 0.06 , ( temp_output_22_0 - step( ( DissolveAmount7 + ( _MainEdgeWidth + _SecondEdgeWidth ) ) , temp_output_19_0 ) ));
				float EdgeTexBlendAlpha41 = smoothstepResult98;
				float lerpResult56 = lerp( 0.0 , lerpResult53 , EdgeTexBlendAlpha41);
				float3 FinalVertexDisplaement51 = ( lerpResult56 * v.ase_normal );
				
				o.ase_texcoord7.xy = v.texcoord.xy;
				o.ase_texcoord8 = v.vertex;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord7.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = FinalVertexDisplaement51;
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

				OUTPUT_LIGHTMAP_UV( v.texcoord1, unity_LightmapST, o.lightmapUVOrVertexSH.xy );
				OUTPUT_SH( normalInput.normalWS.xyz, o.lightmapUVOrVertexSH.xyz );

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
			
			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				
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

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					ShadowCoords = IN.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
				#endif
	
				WorldViewDirection = SafeNormalize( WorldViewDirection );

				float2 uv_Albedo9 = IN.ase_texcoord7.xy;
				float4 temp_output_10_0 = ( tex2D( _Albedo, uv_Albedo9 ) * _Color );
				float4 color77 = IsGammaSpace() ? float4(0,0,0,1) : float4(0,0,0,1);
				float DissolveAmount7 = _DissolveAmount;
				float2 temp_cast_0 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_1 = (temp_output_177_0).xx;
				float2 texCoord65 = IN.ase_texcoord7.xy * temp_cast_0 + temp_cast_1;
				float2 temp_cast_2 = (_GuideTilling).xx;
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( IN.ase_texcoord8.xyz + temp_output_177_0 ), IN.ase_normal, 1.0, temp_cast_2, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2D( _GuideTexture, texCoord65 ).r;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = IN.ase_texcoord8.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = IN.ase_texcoord8.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = IN.ase_texcoord8.xyz.z;
				#else
				float staticSwitch57 = IN.ase_texcoord8.xyz.y;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g9 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float smoothstepResult98 = smoothstep( 0.0 , 0.06 , ( temp_output_22_0 - step( ( DissolveAmount7 + ( _MainEdgeWidth + _SecondEdgeWidth ) ) , temp_output_19_0 ) ));
				float EdgeTexBlendAlpha41 = smoothstepResult98;
				float4 lerpResult30 = lerp( temp_output_10_0 , color77 , EdgeTexBlendAlpha41);
				float2 temp_cast_3 = (_SecondEdgePatternTilling).xx;
				float2 texCoord146 = IN.ase_texcoord7.xy * temp_cast_3 + float2( 0,0 );
				float2 temp_cast_4 = (_SecondEdgePatternTilling).xx;
				float4 triplanar144 = TriplanarSampling144( _SecondEdgePattern, IN.ase_texcoord8.xyz, IN.ase_normal, 1.0, temp_cast_4, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch145 = triplanar144.x;
				#else
				float staticSwitch145 = tex2D( _SecondEdgePattern, texCoord146 ).r;
				#endif
				float4 lerpResult128 = lerp( _SecondEdgeColor1 , _SecondEdgeColor2 , staticSwitch145);
				float2 temp_cast_5 = (_MainEdgePatternTilling).xx;
				float2 texCoord75 = IN.ase_texcoord7.xy * temp_cast_5 + float2( 0,0 );
				float2 temp_cast_6 = (_MainEdgePatternTilling).xx;
				float4 triplanar140 = TriplanarSampling140( _MainEdgePattern, IN.ase_texcoord8.xyz, IN.ase_normal, 1.0, temp_cast_6, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch141 = triplanar140.x;
				#else
				float staticSwitch141 = tex2D( _MainEdgePattern, texCoord75 ).r;
				#endif
				float4 lerpResult72 = lerp( _MainEdgeColor1 , _MainEdgeColor2 , staticSwitch141);
				#ifdef _2SIDESSECONDEDGE_ON
				float staticSwitch155 = ( _SecondEdgeWidth / 2.0 );
				#else
				float staticSwitch155 = 0.0;
				#endif
				#ifdef _GUIDEAFFECTSEDGESBLENDING_ON
				float staticSwitch96 = temp_output_16_0;
				#else
				float staticSwitch96 = staticSwitch57;
				#endif
				float temp_output_1_0_g10 = DissolvelerpA102;
				float temp_output_108_0 = ( ( staticSwitch96 - temp_output_1_0_g10 ) / ( DissolvelerpB103 - temp_output_1_0_g10 ) );
				float DissolveWithEdges104 = ( DissolveAmount7 + _MainEdgeWidth );
				float EdgesAlpha101 = ( step( ( DissolveAmount7 + staticSwitch155 ) , temp_output_108_0 ) - step( ( DissolveWithEdges104 + staticSwitch155 ) , temp_output_108_0 ) );
				float4 lerpResult36 = lerp( lerpResult128 , lerpResult72 , EdgesAlpha101);
				float4 lerpResult79 = lerp( float4( 0,0,0,0 ) , lerpResult36 , EdgeTexBlendAlpha41);
				float4 EmissionColor85 = lerpResult79;
				float4 lerpResult203 = lerp( temp_output_10_0 , EmissionColor85 , EdgeTexBlendAlpha41);
				#if defined(_EDGESAFFECT_ALBEDO)
				float4 staticSwitch200 = lerpResult203;
				#elif defined(_EDGESAFFECT_EMISSION)
				float4 staticSwitch200 = lerpResult30;
				#else
				float4 staticSwitch200 = lerpResult30;
				#endif
				
				float2 uv_NormalTexture157 = IN.ase_texcoord7.xy;
				
				float2 uv_EmissionTexture159 = IN.ase_texcoord7.xy;
				float4 temp_output_160_0 = ( tex2D( _EmissionTexture, uv_EmissionTexture159 ) * _EmissionColor );
				#if defined(_EDGESAFFECT_ALBEDO)
				float4 staticSwitch201 = temp_output_160_0;
				#elif defined(_EDGESAFFECT_EMISSION)
				float4 staticSwitch201 = ( EmissionColor85 + temp_output_160_0 );
				#else
				float4 staticSwitch201 = ( EmissionColor85 + temp_output_160_0 );
				#endif
				
				float2 uv_SpecularTexture163 = IN.ase_texcoord7.xy;
				
				float2 uv_OcclusionMap167 = IN.ase_texcoord7.xy;
				
				float FinalAlpha43 = temp_output_22_0;
				
				float3 Albedo = staticSwitch200.rgb;
				float3 Normal = UnpackNormalScale( tex2D( _NormalTexture, uv_NormalTexture157 ), 1.0f );
				float3 Emission = staticSwitch201.rgb;
				float3 Specular = ( tex2D( _SpecularTexture, uv_SpecularTexture163 ).r * _SpecularValue ).rgb;
				float Metallic = 0;
				float Smoothness = _SmoothnessValue;
				float Occlusion = tex2D( _OcclusionMap, uv_OcclusionMap167 ).r;
				float Alpha = FinalAlpha43;
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

				InputData inputData;
				inputData.positionWS = WorldPosition;
				inputData.viewDirectionWS = WorldViewDirection;
				inputData.shadowCoord = ShadowCoords;

				#ifdef _NORMALMAP
					#if _NORMAL_DROPOFF_TS
					inputData.normalWS = TransformTangentToWorld(Normal, half3x3( WorldTangent, WorldBiTangent, WorldNormal ));
					#elif _NORMAL_DROPOFF_OS
					inputData.normalWS = TransformObjectToWorldNormal(Normal);
					#elif _NORMAL_DROPOFF_WS
					inputData.normalWS = Normal;
					#endif
					inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
				#else
					inputData.normalWS = WorldNormal;
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

				inputData.bakedGI = SAMPLE_GI( IN.lightmapUVOrVertexSH.xy, SH, inputData.normalWS );
				#ifdef _ASE_BAKEDGI
					inputData.bakedGI = BakedGI;
				#endif
				half4 color = UniversalFragmentPBR(
					inputData, 
					Albedo, 
					Metallic, 
					Specular, 
					Smoothness, 
					Occlusion, 
					Emission, 
					Alpha);

				#ifdef _TRANSMISSION_ASE
				{
					float shadow = _TransmissionShadow;

					Light mainLight = GetMainLight( inputData.shadowCoord );
					float3 mainAtten = mainLight.color * mainLight.distanceAttenuation;
					mainAtten = lerp( mainAtten, mainAtten * mainLight.shadowAttenuation, shadow );
					half3 mainTransmission = max(0 , -dot(inputData.normalWS, mainLight.direction)) * mainAtten * Transmission;
					color.rgb += Albedo * mainTransmission;

					#ifdef _ADDITIONAL_LIGHTS
						int transPixelLightCount = GetAdditionalLightsCount();
						for (int i = 0; i < transPixelLightCount; ++i)
						{
							Light light = GetAdditionalLight(i, inputData.positionWS);
							float3 atten = light.color * light.distanceAttenuation;
							atten = lerp( atten, atten * light.shadowAttenuation, shadow );

							half3 transmission = max(0 , -dot(inputData.normalWS, light.direction)) * atten * Transmission;
							color.rgb += Albedo * transmission;
						}
					#endif
				}
				#endif

				#ifdef _TRANSLUCENCY_ASE
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
					color.rgb += Albedo * mainTranslucency * strength;

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
							color.rgb += Albedo * translucency * strength;
						}
					#endif
				}
				#endif

				#ifdef _REFRACTION_ASE
					float4 projScreenPos = ScreenPos / ScreenPos.w;
					float3 refractionOffset = ( RefractionIndex - 1.0 ) * mul( UNITY_MATRIX_V, float4( WorldNormal, 0 ) ).xyz * ( 1.0 - dot( WorldNormal, WorldViewDirection ) );
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

			HLSLPROGRAM
			
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _NORMAL_DROPOFF_TS 1
			#define _SPECULAR_SETUP 1
			#define _EMISSION
			#define _ALPHATEST_ON 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70701

			
			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_SHADOWCASTER

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_POSITION
			#pragma multi_compile_local __ _2SIDESSECONDEDGE_ON
			#pragma multi_compile_local __ _GUIDEAFFECTSEDGESBLENDING_ON
			#pragma multi_compile_local _AXIS_X _AXIS_Y _AXIS_Z
			#pragma multi_compile_local __ _USETRIPLANARUVS_ON
			#pragma shader_feature_local _INVERTDIRECTIONMINMAX_ON


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
				float4 ase_texcoord4 : TEXCOORD4;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _MainEdgeColor2;
			float4 _MainEdgeColor1;
			float4 _SecondEdgeColor2;
			float4 _SecondEdgeColor1;
			float4 _Color;
			float4 _SpecularValue;
			float _VertexDisplacementSecondEdge;
			float _MainEdgePatternTilling;
			float _SecondEdgePatternTilling;
			float _MainEdgeWidth;
			float _MaxValueWhenAmount1;
			float _GuideStrength;
			float _GuideTillingSpeed;
			float _GuideTilling;
			float _SecondEdgeWidth;
			float _DissolveAmount;
			float _VertexDisplacementMainEdge;
			float _DisplacementGuideTillingSpeed;
			float _DisplacementGuideTilling;
			float _MinValueWhenAmount0;
			float _SmoothnessValue;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _DisplacementGuide;
			sampler2D _GuideTexture;


			inline float4 TriplanarSampling68( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.zy * float2(  nsign.x, 1.0 ), 0, 0) );
				yNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xz * float2(  nsign.y, 1.0 ), 0, 0) );
				zNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xy * float2( -nsign.z, 1.0 ), 0, 0) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			

			float3 _LightDirection;

			VertexOutput VertexFunction( VertexInput v )
			{
				VertexOutput o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float2 temp_cast_0 = (_DisplacementGuideTilling).xx;
				float2 temp_cast_1 = (( _TimeParameters.x * _DisplacementGuideTillingSpeed )).xx;
				float2 texCoord183 = v.ase_texcoord.xy * temp_cast_0 + temp_cast_1;
				float4 tex2DNode186 = tex2Dlod( _DisplacementGuide, float4( texCoord183, 0, 0.0) );
				float DissolveAmount7 = _DissolveAmount;
				#ifdef _2SIDESSECONDEDGE_ON
				float staticSwitch155 = ( _SecondEdgeWidth / 2.0 );
				#else
				float staticSwitch155 = 0.0;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = v.vertex.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = v.vertex.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = v.vertex.xyz.z;
				#else
				float staticSwitch57 = v.vertex.xyz.y;
				#endif
				float2 temp_cast_2 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_3 = (temp_output_177_0).xx;
				float2 texCoord65 = v.ase_texcoord.xy * temp_cast_2 + temp_cast_3;
				float2 temp_cast_4 = (_GuideTilling).xx;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( v.vertex.xyz + temp_output_177_0 ), v.ase_normal, 1.0, temp_cast_4, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2Dlod( _GuideTexture, float4( texCoord65, 0, 0.0) ).r;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				#ifdef _GUIDEAFFECTSEDGESBLENDING_ON
				float staticSwitch96 = temp_output_16_0;
				#else
				float staticSwitch96 = staticSwitch57;
				#endif
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g10 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_108_0 = ( ( staticSwitch96 - temp_output_1_0_g10 ) / ( DissolvelerpB103 - temp_output_1_0_g10 ) );
				float DissolveWithEdges104 = ( DissolveAmount7 + _MainEdgeWidth );
				float EdgesAlpha101 = ( step( ( DissolveAmount7 + staticSwitch155 ) , temp_output_108_0 ) - step( ( DissolveWithEdges104 + staticSwitch155 ) , temp_output_108_0 ) );
				float lerpResult53 = lerp( ( _VertexDisplacementSecondEdge * tex2DNode186.r ) , ( tex2DNode186.r * _VertexDisplacementMainEdge ) , EdgesAlpha101);
				float temp_output_1_0_g9 = DissolvelerpA102;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float smoothstepResult98 = smoothstep( 0.0 , 0.06 , ( temp_output_22_0 - step( ( DissolveAmount7 + ( _MainEdgeWidth + _SecondEdgeWidth ) ) , temp_output_19_0 ) ));
				float EdgeTexBlendAlpha41 = smoothstepResult98;
				float lerpResult56 = lerp( 0.0 , lerpResult53 , EdgeTexBlendAlpha41);
				float3 FinalVertexDisplaement51 = ( lerpResult56 * v.ase_normal );
				
				o.ase_texcoord3.xyz = ase_worldNormal;
				
				o.ase_texcoord2.xy = v.ase_texcoord.xy;
				o.ase_texcoord4 = v.vertex;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = FinalVertexDisplaement51;
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

				float4 clipPos = TransformWorldToHClip( ApplyShadowBias( positionWS, normalWS, _LightDirection ) );

				#if UNITY_REVERSED_Z
					clipPos.z = min(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
				#else
					clipPos.z = max(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
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

			#if defined(TESSELLATION_ON)
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

				float DissolveAmount7 = _DissolveAmount;
				float2 temp_cast_0 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_1 = (temp_output_177_0).xx;
				float2 texCoord65 = IN.ase_texcoord2.xy * temp_cast_0 + temp_cast_1;
				float2 temp_cast_2 = (_GuideTilling).xx;
				float3 ase_worldNormal = IN.ase_texcoord3.xyz;
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( IN.ase_texcoord4.xyz + temp_output_177_0 ), IN.ase_normal, 1.0, temp_cast_2, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2D( _GuideTexture, texCoord65 ).r;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = IN.ase_texcoord4.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = IN.ase_texcoord4.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = IN.ase_texcoord4.xyz.z;
				#else
				float staticSwitch57 = IN.ase_texcoord4.xyz.y;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g9 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float FinalAlpha43 = temp_output_22_0;
				
				float Alpha = FinalAlpha43;
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
			
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _NORMAL_DROPOFF_TS 1
			#define _SPECULAR_SETUP 1
			#define _EMISSION
			#define _ALPHATEST_ON 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70701

			
			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_DEPTHONLY

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_POSITION
			#pragma multi_compile_local __ _2SIDESSECONDEDGE_ON
			#pragma multi_compile_local __ _GUIDEAFFECTSEDGESBLENDING_ON
			#pragma multi_compile_local _AXIS_X _AXIS_Y _AXIS_Z
			#pragma multi_compile_local __ _USETRIPLANARUVS_ON
			#pragma shader_feature_local _INVERTDIRECTIONMINMAX_ON


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
				float4 ase_texcoord4 : TEXCOORD4;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _MainEdgeColor2;
			float4 _MainEdgeColor1;
			float4 _SecondEdgeColor2;
			float4 _SecondEdgeColor1;
			float4 _Color;
			float4 _SpecularValue;
			float _VertexDisplacementSecondEdge;
			float _MainEdgePatternTilling;
			float _SecondEdgePatternTilling;
			float _MainEdgeWidth;
			float _MaxValueWhenAmount1;
			float _GuideStrength;
			float _GuideTillingSpeed;
			float _GuideTilling;
			float _SecondEdgeWidth;
			float _DissolveAmount;
			float _VertexDisplacementMainEdge;
			float _DisplacementGuideTillingSpeed;
			float _DisplacementGuideTilling;
			float _MinValueWhenAmount0;
			float _SmoothnessValue;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _DisplacementGuide;
			sampler2D _GuideTexture;


			inline float4 TriplanarSampling68( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.zy * float2(  nsign.x, 1.0 ), 0, 0) );
				yNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xz * float2(  nsign.y, 1.0 ), 0, 0) );
				zNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xy * float2( -nsign.z, 1.0 ), 0, 0) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float2 temp_cast_0 = (_DisplacementGuideTilling).xx;
				float2 temp_cast_1 = (( _TimeParameters.x * _DisplacementGuideTillingSpeed )).xx;
				float2 texCoord183 = v.ase_texcoord.xy * temp_cast_0 + temp_cast_1;
				float4 tex2DNode186 = tex2Dlod( _DisplacementGuide, float4( texCoord183, 0, 0.0) );
				float DissolveAmount7 = _DissolveAmount;
				#ifdef _2SIDESSECONDEDGE_ON
				float staticSwitch155 = ( _SecondEdgeWidth / 2.0 );
				#else
				float staticSwitch155 = 0.0;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = v.vertex.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = v.vertex.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = v.vertex.xyz.z;
				#else
				float staticSwitch57 = v.vertex.xyz.y;
				#endif
				float2 temp_cast_2 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_3 = (temp_output_177_0).xx;
				float2 texCoord65 = v.ase_texcoord.xy * temp_cast_2 + temp_cast_3;
				float2 temp_cast_4 = (_GuideTilling).xx;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( v.vertex.xyz + temp_output_177_0 ), v.ase_normal, 1.0, temp_cast_4, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2Dlod( _GuideTexture, float4( texCoord65, 0, 0.0) ).r;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				#ifdef _GUIDEAFFECTSEDGESBLENDING_ON
				float staticSwitch96 = temp_output_16_0;
				#else
				float staticSwitch96 = staticSwitch57;
				#endif
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g10 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_108_0 = ( ( staticSwitch96 - temp_output_1_0_g10 ) / ( DissolvelerpB103 - temp_output_1_0_g10 ) );
				float DissolveWithEdges104 = ( DissolveAmount7 + _MainEdgeWidth );
				float EdgesAlpha101 = ( step( ( DissolveAmount7 + staticSwitch155 ) , temp_output_108_0 ) - step( ( DissolveWithEdges104 + staticSwitch155 ) , temp_output_108_0 ) );
				float lerpResult53 = lerp( ( _VertexDisplacementSecondEdge * tex2DNode186.r ) , ( tex2DNode186.r * _VertexDisplacementMainEdge ) , EdgesAlpha101);
				float temp_output_1_0_g9 = DissolvelerpA102;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float smoothstepResult98 = smoothstep( 0.0 , 0.06 , ( temp_output_22_0 - step( ( DissolveAmount7 + ( _MainEdgeWidth + _SecondEdgeWidth ) ) , temp_output_19_0 ) ));
				float EdgeTexBlendAlpha41 = smoothstepResult98;
				float lerpResult56 = lerp( 0.0 , lerpResult53 , EdgeTexBlendAlpha41);
				float3 FinalVertexDisplaement51 = ( lerpResult56 * v.ase_normal );
				
				o.ase_texcoord3.xyz = ase_worldNormal;
				
				o.ase_texcoord2.xy = v.ase_texcoord.xy;
				o.ase_texcoord4 = v.vertex;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = FinalVertexDisplaement51;
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

			#if defined(TESSELLATION_ON)
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

				float DissolveAmount7 = _DissolveAmount;
				float2 temp_cast_0 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_1 = (temp_output_177_0).xx;
				float2 texCoord65 = IN.ase_texcoord2.xy * temp_cast_0 + temp_cast_1;
				float2 temp_cast_2 = (_GuideTilling).xx;
				float3 ase_worldNormal = IN.ase_texcoord3.xyz;
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( IN.ase_texcoord4.xyz + temp_output_177_0 ), IN.ase_normal, 1.0, temp_cast_2, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2D( _GuideTexture, texCoord65 ).r;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = IN.ase_texcoord4.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = IN.ase_texcoord4.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = IN.ase_texcoord4.xyz.z;
				#else
				float staticSwitch57 = IN.ase_texcoord4.xyz.y;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g9 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float FinalAlpha43 = temp_output_22_0;
				
				float Alpha = FinalAlpha43;
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
			
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _NORMAL_DROPOFF_TS 1
			#define _SPECULAR_SETUP 1
			#define _EMISSION
			#define _ALPHATEST_ON 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70701

			
			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_META

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_POSITION
			#define ASE_NEEDS_FRAG_NORMAL
			#pragma multi_compile_local __ _2SIDESSECONDEDGE_ON
			#pragma multi_compile_local __ _GUIDEAFFECTSEDGESBLENDING_ON
			#pragma multi_compile_local _AXIS_X _AXIS_Y _AXIS_Z
			#pragma multi_compile_local __ _USETRIPLANARUVS_ON
			#pragma shader_feature_local _INVERTDIRECTIONMINMAX_ON
			#pragma shader_feature_local _EDGESAFFECT_ALBEDO _EDGESAFFECT_EMISSION


			#pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A

			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
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
				float4 ase_texcoord4 : TEXCOORD4;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _MainEdgeColor2;
			float4 _MainEdgeColor1;
			float4 _SecondEdgeColor2;
			float4 _SecondEdgeColor1;
			float4 _Color;
			float4 _SpecularValue;
			float _VertexDisplacementSecondEdge;
			float _MainEdgePatternTilling;
			float _SecondEdgePatternTilling;
			float _MainEdgeWidth;
			float _MaxValueWhenAmount1;
			float _GuideStrength;
			float _GuideTillingSpeed;
			float _GuideTilling;
			float _SecondEdgeWidth;
			float _DissolveAmount;
			float _VertexDisplacementMainEdge;
			float _DisplacementGuideTillingSpeed;
			float _DisplacementGuideTilling;
			float _MinValueWhenAmount0;
			float _SmoothnessValue;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _DisplacementGuide;
			sampler2D _GuideTexture;
			sampler2D _Albedo;
			sampler2D _SecondEdgePattern;
			sampler2D _MainEdgePattern;
			sampler2D _EmissionTexture;


			inline float4 TriplanarSampling68( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.zy * float2(  nsign.x, 1.0 ), 0, 0) );
				yNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xz * float2(  nsign.y, 1.0 ), 0, 0) );
				zNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xy * float2( -nsign.z, 1.0 ), 0, 0) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			
			inline float4 TriplanarSampling144( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
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
			
			inline float4 TriplanarSampling140( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
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
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float2 temp_cast_0 = (_DisplacementGuideTilling).xx;
				float2 temp_cast_1 = (( _TimeParameters.x * _DisplacementGuideTillingSpeed )).xx;
				float2 texCoord183 = v.ase_texcoord.xy * temp_cast_0 + temp_cast_1;
				float4 tex2DNode186 = tex2Dlod( _DisplacementGuide, float4( texCoord183, 0, 0.0) );
				float DissolveAmount7 = _DissolveAmount;
				#ifdef _2SIDESSECONDEDGE_ON
				float staticSwitch155 = ( _SecondEdgeWidth / 2.0 );
				#else
				float staticSwitch155 = 0.0;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = v.vertex.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = v.vertex.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = v.vertex.xyz.z;
				#else
				float staticSwitch57 = v.vertex.xyz.y;
				#endif
				float2 temp_cast_2 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_3 = (temp_output_177_0).xx;
				float2 texCoord65 = v.ase_texcoord.xy * temp_cast_2 + temp_cast_3;
				float2 temp_cast_4 = (_GuideTilling).xx;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( v.vertex.xyz + temp_output_177_0 ), v.ase_normal, 1.0, temp_cast_4, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2Dlod( _GuideTexture, float4( texCoord65, 0, 0.0) ).r;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				#ifdef _GUIDEAFFECTSEDGESBLENDING_ON
				float staticSwitch96 = temp_output_16_0;
				#else
				float staticSwitch96 = staticSwitch57;
				#endif
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g10 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_108_0 = ( ( staticSwitch96 - temp_output_1_0_g10 ) / ( DissolvelerpB103 - temp_output_1_0_g10 ) );
				float DissolveWithEdges104 = ( DissolveAmount7 + _MainEdgeWidth );
				float EdgesAlpha101 = ( step( ( DissolveAmount7 + staticSwitch155 ) , temp_output_108_0 ) - step( ( DissolveWithEdges104 + staticSwitch155 ) , temp_output_108_0 ) );
				float lerpResult53 = lerp( ( _VertexDisplacementSecondEdge * tex2DNode186.r ) , ( tex2DNode186.r * _VertexDisplacementMainEdge ) , EdgesAlpha101);
				float temp_output_1_0_g9 = DissolvelerpA102;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float smoothstepResult98 = smoothstep( 0.0 , 0.06 , ( temp_output_22_0 - step( ( DissolveAmount7 + ( _MainEdgeWidth + _SecondEdgeWidth ) ) , temp_output_19_0 ) ));
				float EdgeTexBlendAlpha41 = smoothstepResult98;
				float lerpResult56 = lerp( 0.0 , lerpResult53 , EdgeTexBlendAlpha41);
				float3 FinalVertexDisplaement51 = ( lerpResult56 * v.ase_normal );
				
				o.ase_texcoord3.xyz = ase_worldNormal;
				
				o.ase_texcoord2.xy = v.ase_texcoord.xy;
				o.ase_texcoord4 = v.vertex;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = FinalVertexDisplaement51;
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
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = o.clipPos;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
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
				o.texcoord1 = v.texcoord1;
				o.texcoord2 = v.texcoord2;
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
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
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

				float2 uv_Albedo9 = IN.ase_texcoord2.xy;
				float4 temp_output_10_0 = ( tex2D( _Albedo, uv_Albedo9 ) * _Color );
				float4 color77 = IsGammaSpace() ? float4(0,0,0,1) : float4(0,0,0,1);
				float DissolveAmount7 = _DissolveAmount;
				float2 temp_cast_0 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_1 = (temp_output_177_0).xx;
				float2 texCoord65 = IN.ase_texcoord2.xy * temp_cast_0 + temp_cast_1;
				float2 temp_cast_2 = (_GuideTilling).xx;
				float3 ase_worldNormal = IN.ase_texcoord3.xyz;
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( IN.ase_texcoord4.xyz + temp_output_177_0 ), IN.ase_normal, 1.0, temp_cast_2, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2D( _GuideTexture, texCoord65 ).r;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = IN.ase_texcoord4.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = IN.ase_texcoord4.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = IN.ase_texcoord4.xyz.z;
				#else
				float staticSwitch57 = IN.ase_texcoord4.xyz.y;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g9 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float smoothstepResult98 = smoothstep( 0.0 , 0.06 , ( temp_output_22_0 - step( ( DissolveAmount7 + ( _MainEdgeWidth + _SecondEdgeWidth ) ) , temp_output_19_0 ) ));
				float EdgeTexBlendAlpha41 = smoothstepResult98;
				float4 lerpResult30 = lerp( temp_output_10_0 , color77 , EdgeTexBlendAlpha41);
				float2 temp_cast_3 = (_SecondEdgePatternTilling).xx;
				float2 texCoord146 = IN.ase_texcoord2.xy * temp_cast_3 + float2( 0,0 );
				float2 temp_cast_4 = (_SecondEdgePatternTilling).xx;
				float4 triplanar144 = TriplanarSampling144( _SecondEdgePattern, IN.ase_texcoord4.xyz, IN.ase_normal, 1.0, temp_cast_4, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch145 = triplanar144.x;
				#else
				float staticSwitch145 = tex2D( _SecondEdgePattern, texCoord146 ).r;
				#endif
				float4 lerpResult128 = lerp( _SecondEdgeColor1 , _SecondEdgeColor2 , staticSwitch145);
				float2 temp_cast_5 = (_MainEdgePatternTilling).xx;
				float2 texCoord75 = IN.ase_texcoord2.xy * temp_cast_5 + float2( 0,0 );
				float2 temp_cast_6 = (_MainEdgePatternTilling).xx;
				float4 triplanar140 = TriplanarSampling140( _MainEdgePattern, IN.ase_texcoord4.xyz, IN.ase_normal, 1.0, temp_cast_6, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch141 = triplanar140.x;
				#else
				float staticSwitch141 = tex2D( _MainEdgePattern, texCoord75 ).r;
				#endif
				float4 lerpResult72 = lerp( _MainEdgeColor1 , _MainEdgeColor2 , staticSwitch141);
				#ifdef _2SIDESSECONDEDGE_ON
				float staticSwitch155 = ( _SecondEdgeWidth / 2.0 );
				#else
				float staticSwitch155 = 0.0;
				#endif
				#ifdef _GUIDEAFFECTSEDGESBLENDING_ON
				float staticSwitch96 = temp_output_16_0;
				#else
				float staticSwitch96 = staticSwitch57;
				#endif
				float temp_output_1_0_g10 = DissolvelerpA102;
				float temp_output_108_0 = ( ( staticSwitch96 - temp_output_1_0_g10 ) / ( DissolvelerpB103 - temp_output_1_0_g10 ) );
				float DissolveWithEdges104 = ( DissolveAmount7 + _MainEdgeWidth );
				float EdgesAlpha101 = ( step( ( DissolveAmount7 + staticSwitch155 ) , temp_output_108_0 ) - step( ( DissolveWithEdges104 + staticSwitch155 ) , temp_output_108_0 ) );
				float4 lerpResult36 = lerp( lerpResult128 , lerpResult72 , EdgesAlpha101);
				float4 lerpResult79 = lerp( float4( 0,0,0,0 ) , lerpResult36 , EdgeTexBlendAlpha41);
				float4 EmissionColor85 = lerpResult79;
				float4 lerpResult203 = lerp( temp_output_10_0 , EmissionColor85 , EdgeTexBlendAlpha41);
				#if defined(_EDGESAFFECT_ALBEDO)
				float4 staticSwitch200 = lerpResult203;
				#elif defined(_EDGESAFFECT_EMISSION)
				float4 staticSwitch200 = lerpResult30;
				#else
				float4 staticSwitch200 = lerpResult30;
				#endif
				
				float2 uv_EmissionTexture159 = IN.ase_texcoord2.xy;
				float4 temp_output_160_0 = ( tex2D( _EmissionTexture, uv_EmissionTexture159 ) * _EmissionColor );
				#if defined(_EDGESAFFECT_ALBEDO)
				float4 staticSwitch201 = temp_output_160_0;
				#elif defined(_EDGESAFFECT_EMISSION)
				float4 staticSwitch201 = ( EmissionColor85 + temp_output_160_0 );
				#else
				float4 staticSwitch201 = ( EmissionColor85 + temp_output_160_0 );
				#endif
				
				float FinalAlpha43 = temp_output_22_0;
				
				
				float3 Albedo = staticSwitch200.rgb;
				float3 Emission = staticSwitch201.rgb;
				float Alpha = FinalAlpha43;
				float AlphaClipThreshold = 0.5;

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				MetaInput metaInput = (MetaInput)0;
				metaInput.Albedo = Albedo;
				metaInput.Emission = Emission;
				
				return MetaFragment(metaInput);
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
			
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _NORMAL_DROPOFF_TS 1
			#define _SPECULAR_SETUP 1
			#define _EMISSION
			#define _ALPHATEST_ON 1
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70701

			
			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_2D

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_POSITION
			#define ASE_NEEDS_FRAG_NORMAL
			#pragma multi_compile_local __ _2SIDESSECONDEDGE_ON
			#pragma multi_compile_local __ _GUIDEAFFECTSEDGESBLENDING_ON
			#pragma multi_compile_local _AXIS_X _AXIS_Y _AXIS_Z
			#pragma multi_compile_local __ _USETRIPLANARUVS_ON
			#pragma shader_feature_local _INVERTDIRECTIONMINMAX_ON
			#pragma shader_feature_local _EDGESAFFECT_ALBEDO _EDGESAFFECT_EMISSION


			#pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A

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
				float4 ase_texcoord4 : TEXCOORD4;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _MainEdgeColor2;
			float4 _MainEdgeColor1;
			float4 _SecondEdgeColor2;
			float4 _SecondEdgeColor1;
			float4 _Color;
			float4 _SpecularValue;
			float _VertexDisplacementSecondEdge;
			float _MainEdgePatternTilling;
			float _SecondEdgePatternTilling;
			float _MainEdgeWidth;
			float _MaxValueWhenAmount1;
			float _GuideStrength;
			float _GuideTillingSpeed;
			float _GuideTilling;
			float _SecondEdgeWidth;
			float _DissolveAmount;
			float _VertexDisplacementMainEdge;
			float _DisplacementGuideTillingSpeed;
			float _DisplacementGuideTilling;
			float _MinValueWhenAmount0;
			float _SmoothnessValue;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _DisplacementGuide;
			sampler2D _GuideTexture;
			sampler2D _Albedo;
			sampler2D _SecondEdgePattern;
			sampler2D _MainEdgePattern;


			inline float4 TriplanarSampling68( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.zy * float2(  nsign.x, 1.0 ), 0, 0) );
				yNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xz * float2(  nsign.y, 1.0 ), 0, 0) );
				zNorm = tex2Dlod( topTexMap, float4(tiling * worldPos.xy * float2( -nsign.z, 1.0 ), 0, 0) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			
			inline float4 TriplanarSampling144( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
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
			
			inline float4 TriplanarSampling140( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
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
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float2 temp_cast_0 = (_DisplacementGuideTilling).xx;
				float2 temp_cast_1 = (( _TimeParameters.x * _DisplacementGuideTillingSpeed )).xx;
				float2 texCoord183 = v.ase_texcoord.xy * temp_cast_0 + temp_cast_1;
				float4 tex2DNode186 = tex2Dlod( _DisplacementGuide, float4( texCoord183, 0, 0.0) );
				float DissolveAmount7 = _DissolveAmount;
				#ifdef _2SIDESSECONDEDGE_ON
				float staticSwitch155 = ( _SecondEdgeWidth / 2.0 );
				#else
				float staticSwitch155 = 0.0;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = v.vertex.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = v.vertex.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = v.vertex.xyz.z;
				#else
				float staticSwitch57 = v.vertex.xyz.y;
				#endif
				float2 temp_cast_2 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_3 = (temp_output_177_0).xx;
				float2 texCoord65 = v.ase_texcoord.xy * temp_cast_2 + temp_cast_3;
				float2 temp_cast_4 = (_GuideTilling).xx;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( v.vertex.xyz + temp_output_177_0 ), v.ase_normal, 1.0, temp_cast_4, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2Dlod( _GuideTexture, float4( texCoord65, 0, 0.0) ).r;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				#ifdef _GUIDEAFFECTSEDGESBLENDING_ON
				float staticSwitch96 = temp_output_16_0;
				#else
				float staticSwitch96 = staticSwitch57;
				#endif
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g10 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_108_0 = ( ( staticSwitch96 - temp_output_1_0_g10 ) / ( DissolvelerpB103 - temp_output_1_0_g10 ) );
				float DissolveWithEdges104 = ( DissolveAmount7 + _MainEdgeWidth );
				float EdgesAlpha101 = ( step( ( DissolveAmount7 + staticSwitch155 ) , temp_output_108_0 ) - step( ( DissolveWithEdges104 + staticSwitch155 ) , temp_output_108_0 ) );
				float lerpResult53 = lerp( ( _VertexDisplacementSecondEdge * tex2DNode186.r ) , ( tex2DNode186.r * _VertexDisplacementMainEdge ) , EdgesAlpha101);
				float temp_output_1_0_g9 = DissolvelerpA102;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float smoothstepResult98 = smoothstep( 0.0 , 0.06 , ( temp_output_22_0 - step( ( DissolveAmount7 + ( _MainEdgeWidth + _SecondEdgeWidth ) ) , temp_output_19_0 ) ));
				float EdgeTexBlendAlpha41 = smoothstepResult98;
				float lerpResult56 = lerp( 0.0 , lerpResult53 , EdgeTexBlendAlpha41);
				float3 FinalVertexDisplaement51 = ( lerpResult56 * v.ase_normal );
				
				o.ase_texcoord3.xyz = ase_worldNormal;
				
				o.ase_texcoord2.xy = v.ase_texcoord.xy;
				o.ase_texcoord4 = v.vertex;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = FinalVertexDisplaement51;
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

			#if defined(TESSELLATION_ON)
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

				float2 uv_Albedo9 = IN.ase_texcoord2.xy;
				float4 temp_output_10_0 = ( tex2D( _Albedo, uv_Albedo9 ) * _Color );
				float4 color77 = IsGammaSpace() ? float4(0,0,0,1) : float4(0,0,0,1);
				float DissolveAmount7 = _DissolveAmount;
				float2 temp_cast_0 = (_GuideTilling).xx;
				float temp_output_177_0 = ( _TimeParameters.x * _GuideTillingSpeed );
				float2 temp_cast_1 = (temp_output_177_0).xx;
				float2 texCoord65 = IN.ase_texcoord2.xy * temp_cast_0 + temp_cast_1;
				float2 temp_cast_2 = (_GuideTilling).xx;
				float3 ase_worldNormal = IN.ase_texcoord3.xyz;
				float4 triplanar68 = TriplanarSampling68( _GuideTexture, ( IN.ase_texcoord4.xyz + temp_output_177_0 ), IN.ase_normal, 1.0, temp_cast_2, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch71 = triplanar68.x;
				#else
				float staticSwitch71 = tex2D( _GuideTexture, texCoord65 ).r;
				#endif
				#if defined(_AXIS_X)
				float staticSwitch57 = IN.ase_texcoord4.xyz.x;
				#elif defined(_AXIS_Y)
				float staticSwitch57 = IN.ase_texcoord4.xyz.y;
				#elif defined(_AXIS_Z)
				float staticSwitch57 = IN.ase_texcoord4.xyz.z;
				#else
				float staticSwitch57 = IN.ase_texcoord4.xyz.y;
				#endif
				float temp_output_16_0 = ( ( staticSwitch71 * _GuideStrength ) + staticSwitch57 );
				float2 appendResult170 = (float2(_MinValueWhenAmount0 , _MaxValueWhenAmount1));
				float2 appendResult171 = (float2(_MaxValueWhenAmount1 , _MinValueWhenAmount0));
				#ifdef _INVERTDIRECTIONMINMAX_ON
				float2 staticSwitch58 = appendResult171;
				#else
				float2 staticSwitch58 = appendResult170;
				#endif
				float2 break172 = staticSwitch58;
				float DissolvelerpA102 = break172.x;
				float temp_output_1_0_g9 = DissolvelerpA102;
				float DissolvelerpB103 = break172.y;
				float temp_output_19_0 = ( ( temp_output_16_0 - temp_output_1_0_g9 ) / ( DissolvelerpB103 - temp_output_1_0_g9 ) );
				float temp_output_22_0 = step( DissolveAmount7 , temp_output_19_0 );
				float smoothstepResult98 = smoothstep( 0.0 , 0.06 , ( temp_output_22_0 - step( ( DissolveAmount7 + ( _MainEdgeWidth + _SecondEdgeWidth ) ) , temp_output_19_0 ) ));
				float EdgeTexBlendAlpha41 = smoothstepResult98;
				float4 lerpResult30 = lerp( temp_output_10_0 , color77 , EdgeTexBlendAlpha41);
				float2 temp_cast_3 = (_SecondEdgePatternTilling).xx;
				float2 texCoord146 = IN.ase_texcoord2.xy * temp_cast_3 + float2( 0,0 );
				float2 temp_cast_4 = (_SecondEdgePatternTilling).xx;
				float4 triplanar144 = TriplanarSampling144( _SecondEdgePattern, IN.ase_texcoord4.xyz, IN.ase_normal, 1.0, temp_cast_4, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch145 = triplanar144.x;
				#else
				float staticSwitch145 = tex2D( _SecondEdgePattern, texCoord146 ).r;
				#endif
				float4 lerpResult128 = lerp( _SecondEdgeColor1 , _SecondEdgeColor2 , staticSwitch145);
				float2 temp_cast_5 = (_MainEdgePatternTilling).xx;
				float2 texCoord75 = IN.ase_texcoord2.xy * temp_cast_5 + float2( 0,0 );
				float2 temp_cast_6 = (_MainEdgePatternTilling).xx;
				float4 triplanar140 = TriplanarSampling140( _MainEdgePattern, IN.ase_texcoord4.xyz, IN.ase_normal, 1.0, temp_cast_6, 1.0, 0 );
				#ifdef _USETRIPLANARUVS_ON
				float staticSwitch141 = triplanar140.x;
				#else
				float staticSwitch141 = tex2D( _MainEdgePattern, texCoord75 ).r;
				#endif
				float4 lerpResult72 = lerp( _MainEdgeColor1 , _MainEdgeColor2 , staticSwitch141);
				#ifdef _2SIDESSECONDEDGE_ON
				float staticSwitch155 = ( _SecondEdgeWidth / 2.0 );
				#else
				float staticSwitch155 = 0.0;
				#endif
				#ifdef _GUIDEAFFECTSEDGESBLENDING_ON
				float staticSwitch96 = temp_output_16_0;
				#else
				float staticSwitch96 = staticSwitch57;
				#endif
				float temp_output_1_0_g10 = DissolvelerpA102;
				float temp_output_108_0 = ( ( staticSwitch96 - temp_output_1_0_g10 ) / ( DissolvelerpB103 - temp_output_1_0_g10 ) );
				float DissolveWithEdges104 = ( DissolveAmount7 + _MainEdgeWidth );
				float EdgesAlpha101 = ( step( ( DissolveAmount7 + staticSwitch155 ) , temp_output_108_0 ) - step( ( DissolveWithEdges104 + staticSwitch155 ) , temp_output_108_0 ) );
				float4 lerpResult36 = lerp( lerpResult128 , lerpResult72 , EdgesAlpha101);
				float4 lerpResult79 = lerp( float4( 0,0,0,0 ) , lerpResult36 , EdgeTexBlendAlpha41);
				float4 EmissionColor85 = lerpResult79;
				float4 lerpResult203 = lerp( temp_output_10_0 , EmissionColor85 , EdgeTexBlendAlpha41);
				#if defined(_EDGESAFFECT_ALBEDO)
				float4 staticSwitch200 = lerpResult203;
				#elif defined(_EDGESAFFECT_EMISSION)
				float4 staticSwitch200 = lerpResult30;
				#else
				float4 staticSwitch200 = lerpResult30;
				#endif
				
				float FinalAlpha43 = temp_output_22_0;
				
				
				float3 Albedo = staticSwitch200.rgb;
				float Alpha = FinalAlpha43;
				float AlphaClipThreshold = 0.5;

				half4 color = half4( Albedo, Alpha );

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				return color;
			}
			ENDHLSL
		}
		
	}
	
	
	Fallback "Hidden/InternalErrorShader"
	
}
/*ASEBEGIN
Version=18935
711;73;1848;650;683.0541;-449.9933;1.3;True;True
Node;AmplifyShaderEditor.RangedFloatNode;178;-5895.397,2304.062;Inherit;False;Property;_GuideTillingSpeed;Guide Tilling Speed;17;0;Create;True;0;0;0;False;0;False;0.005;0;-0.4;0.4;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;176;-5777.066,2163.882;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;177;-5593.397,2205.062;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;180;-5578.291,1858.146;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;66;-5792.507,1918.815;Inherit;False;Property;_GuideTilling;Guide Tilling;16;0;Create;True;0;0;0;False;0;False;1;2.6;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;65;-5476.412,2049.977;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexturePropertyNode;69;-5588.503,1649.266;Inherit;True;Property;_GuideTexture;Guide Texture;15;2;[Header];[NoScaleOffset];Create;True;1;Dissolve Guide;0;0;False;1;Space;False;None;b39489d9b019b7244b5d3363a36f50c4;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode;21;-4081.694,1495.139;Inherit;False;Property;_MaxValueWhenAmount1;Max Value (When Amount = 1);10;0;Create;True;0;0;0;False;0;False;3;1.7;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;181;-5374.291,1897.146;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;20;-4073.315,1382.84;Inherit;False;Property;_MinValueWhenAmount0;Min Value (When Amount = 0);9;0;Create;True;0;0;0;False;0;False;0;-12.93;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-4723.35,1366.183;Inherit;False;Property;_DissolveAmount;Dissolve Amount;8;1;[Header];Create;True;1;Main Dissolve Settings;0;0;False;1;Space;False;1;0.369;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;170;-3788.585,1412.314;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;7;-4429.246,1366.865;Inherit;False;DissolveAmount;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;171;-3758.585,1559.314;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;70;-5145.047,1941.204;Inherit;True;Property;_TextureSample0;Texture Sample 0;17;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TriplanarNode;68;-5235.764,1731.106;Inherit;True;Spherical;Object;False;Top Texture 0;_TopTexture0;white;-1;None;Mid Texture 0;_MidTexture0;white;-1;None;Bot Texture 0;_BotTexture0;white;-1;None;Triplanar Sampler;Tangent;10;0;SAMPLER2D;;False;5;FLOAT;1;False;1;SAMPLER2D;;False;6;FLOAT;0;False;2;SAMPLER2D;;False;7;FLOAT;0;False;9;FLOAT3;0,0,0;False;8;FLOAT;1;False;3;FLOAT2;1,1;False;4;FLOAT;1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;71;-4688.156,1800.375;Inherit;False;Property;_UseTriplanarUvs;Use Triplanar Uvs;12;0;Create;True;0;0;0;False;0;False;1;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;15;-4311.597,2273.074;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;58;-3525.311,1449.256;Inherit;False;Property;_InvertDirectionMinMax;Invert Direction (Min & Max);14;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT2;0,0;False;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT2;0,0;False;6;FLOAT2;0,0;False;7;FLOAT2;0,0;False;8;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;26;-3002.778,1863.25;Inherit;False;7;DissolveAmount;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;25;-3170.113,2015.005;Inherit;False;Property;_MainEdgeWidth;Main Edge Width;25;1;[Header];Create;True;1;Main Edge;0;0;False;0;False;0.01308131;0.068;0;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-4415.108,1939.412;Inherit;False;Property;_GuideStrength;Guide Strength;18;0;Create;True;0;0;0;False;0;False;0;0.98;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;57;-4055.09,2192.001;Inherit;True;Property;_Axis;Axis;11;0;Create;True;0;0;0;False;0;False;1;1;1;True;;KeywordEnum;3;X;Y;Z;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;172;-3244.081,1530.362;Inherit;False;FLOAT2;1;0;FLOAT2;0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleAddOpNode;24;-2730.302,1851.576;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-4031.11,1783.646;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;32;-3292.142,2140.939;Inherit;False;Property;_SecondEdgeWidth;Second Edge Width;30;1;[Header];Create;True;1;Second Edge;0;0;False;0;False;0.02225761;0.005;0;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;154;-3101.393,3140.02;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;102;-3118.011,1481.214;Inherit;False;DissolvelerpA;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;156;-3134.183,2940.329;Inherit;False;Constant;_Float3;Float 3;27;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;103;-3126.4,1579.968;Inherit;False;DissolvelerpB;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;104;-2568.533,1843.216;Inherit;False;DissolveWithEdges;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;16;-3751.864,1884.496;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;155;-2961.853,2983.751;Inherit;False;Property;_2SidesSecondEdge;2 Sides Second Edge;35;0;Create;True;0;0;0;False;0;False;1;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;38;-2859.61,2119.153;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;105;-2643.34,2989.775;Inherit;False;104;DissolveWithEdges;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;96;-3629.583,2298.69;Inherit;False;Property;_GuideAffectsEdgesBlending;Guide Affects Edges Blending;19;0;Create;True;0;0;0;False;0;False;1;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;107;-2752.049,2810.447;Inherit;False;103;DissolvelerpB;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;106;-2775.67,2711.133;Inherit;False;102;DissolvelerpA;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;110;-2612.986,2491.483;Inherit;False;7;DissolveAmount;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;133;-4663.433,-364.9583;Inherit;False;Property;_SecondEdgePatternTilling;Second Edge Pattern Tilling;32;0;Create;True;0;0;0;False;0;False;1;11;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;27;-2802.645,1464.292;Inherit;False;7;DissolveAmount;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;108;-2517.508,2772.353;Inherit;False;Inverse Lerp;-1;;10;09cbe79402f023141a4dc1fddd4c9511;0;3;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;31;-2638.214,2178.497;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;152;-2380.531,3021.329;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;153;-2373.864,2568.041;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;19;-2934.608,1604.059;Inherit;False;Inverse Lerp;-1;;9;09cbe79402f023141a4dc1fddd4c9511;0;3;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;74;-4349.984,582.1639;Inherit;False;Property;_MainEdgePatternTilling;Main Edge Pattern Tilling;27;0;Create;True;0;0;0;False;0;False;1;11.89;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;142;-4249.206,251.2721;Inherit;True;Property;_MainEdgePattern;Main Edge Pattern;26;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;None;a1d44fff5896b8b4db9e356abefaced0;False;black;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TextureCoordinatesNode;75;-4020.94,619.6528;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexturePropertyNode;147;-4480.706,-698.3071;Inherit;True;Property;_SecondEdgePattern;Second Edge Pattern;31;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;None;fc5895d0478aceb4d8032744f6a6b5c4;False;black;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.StepOpNode;112;-2184.15,2618.555;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;146;-4351.57,-426.1532;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;22;-2487.915,1439.74;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;191;-1951.41,4070.069;Inherit;False;Property;_DisplacementGuideTillingSpeed;Displacement Guide Tilling Speed;23;0;Create;True;0;0;0;False;0;False;0.005;0;0;0.2;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;190;-1774.981,3932.327;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;34;-2380.241,2126.751;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;109;-2196.445,2878.577;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;35;-2043.069,2044.558;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;189;-1591.312,3973.507;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TriplanarNode;140;-3819.137,294.6213;Inherit;True;Spherical;Object;False;Top Texture 1;_TopTexture1;white;-1;None;Mid Texture 1;_MidTexture1;white;-1;None;Bot Texture 1;_BotTexture1;white;-1;None;Triplanar Sampler;Tangent;10;0;SAMPLER2D;;False;5;FLOAT;1;False;1;SAMPLER2D;;False;6;FLOAT;0;False;2;SAMPLER2D;;False;7;FLOAT;0;False;9;FLOAT3;0,0,0;False;8;FLOAT;1;False;3;FLOAT2;1,1;False;4;FLOAT;1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TriplanarNode;144;-4133.371,-762.1162;Inherit;True;Spherical;Object;False;Top Texture 2;_TopTexture2;white;-1;None;Mid Texture 2;_MidTexture2;white;-1;None;Bot Texture 2;_BotTexture2;white;-1;None;Triplanar Sampler;Tangent;10;0;SAMPLER2D;;False;5;FLOAT;1;False;1;SAMPLER2D;;False;6;FLOAT;0;False;2;SAMPLER2D;;False;7;FLOAT;0;False;9;FLOAT3;0,0,0;False;8;FLOAT;1;False;3;FLOAT2;1,1;False;4;FLOAT;1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;113;-1775.684,2693.622;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;182;-1763.878,3781.344;Inherit;False;Property;_DisplacementGuideTilling;Displacement Guide Tilling;24;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;139;-3728.419,504.7194;Inherit;True;Property;_TextureSample1;Texture Sample 1;17;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;143;-4059.051,-541.0866;Inherit;True;Property;_TextureSample2;Texture Sample 2;17;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;141;-3271.528,363.8904;Inherit;False;Property;_UseTriplanarUvs;Use Triplanar Uvs;6;0;Create;True;0;0;0;False;0;False;1;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;129;-3529.823,-1019.033;Inherit;False;Property;_SecondEdgeColor2;Second Edge Color 2;34;1;[HDR];Create;True;0;0;0;False;0;False;1,0,0.5446758,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexturePropertyNode;185;-1459.425,3478.868;Inherit;True;Property;_DisplacementGuide; Displacement Guide;22;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;None;a1d44fff5896b8b4db9e356abefaced0;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.ColorNode;130;-3535.96,-1214.022;Inherit;False;Property;_SecondEdgeColor1;Second Edge Color 1;33;1;[HDR];Create;True;0;0;0;False;0;False;0,0.171536,1,1;0,7.647191,41.73181,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;145;-3602.16,-681.9156;Inherit;False;Property;_UseTriplanarUvs;Use Triplanar Uvs;6;0;Create;True;0;0;0;False;0;False;1;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;73;-3623.116,50.73708;Inherit;False;Property;_MainEdgeColor2;Main Edge Color 2;29;1;[HDR];Create;True;0;0;0;False;0;False;1,0,0.5446758,1;4.237095,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;98;-1751.459,2030.762;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.06;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;37;-3629.253,-144.2517;Inherit;False;Property;_MainEdgeColor1;Main Edge Color 1;28;1;[HDR];Create;True;0;0;0;False;0;False;0,0.171536,1,1;0.1415094,0.03451449,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;101;-1464.93,2703.59;Inherit;True;EdgesAlpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;183;-1360.834,3774.833;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;50;-422.6831,3956.343;Inherit;False;Property;_VertexDisplacementSecondEdge;Vertex Displacement Second Edge;21;0;Create;True;1;;0;0;False;0;False;0;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;186;-1068.313,3659.9;Inherit;True;Property;_TextureSample3;Texture Sample 3;17;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;128;-3102.957,-617.9714;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;40;-2890.088,209.703;Inherit;True;101;EdgesAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;54;-383.1441,3711.096;Inherit;False;Property;_VertexDisplacementMainEdge;Vertex Displacement Main Edge ;20;1;[Header];Create;True;1;Vertex Displacement;0;0;False;0;False;0;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;72;-3180.676,87.38479;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;41;-1499.246,2036.651;Inherit;True;EdgeTexBlendAlpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;78;-2381.322,302.6793;Inherit;False;41;EdgeTexBlendAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;36;-2703.718,18.67686;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;188;-122.9497,3578.502;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;46;161.5449,3633.82;Inherit;False;101;EdgesAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;197;-34.85767,4063.197;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;79;-2231.323,72.73815;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;55;252.8458,3726.76;Inherit;False;41;EdgeTexBlendAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;53;361.4249,3498.289;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;9;-551.9696,-169.3529;Inherit;True;Property;_Albedo;Albedo;0;2;[Header];[NoScaleOffset];Create;True;1;PBR Settings;0;0;False;0;False;-1;None;735005267e4d37c4ea0aa10b2cb94ed3;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;56;595.2147,3475.698;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;8;-521.3586,23.07026;Inherit;False;Property;_Color;Color;1;0;Create;True;0;0;0;False;0;False;0,0,0,1;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;85;-1871.134,70.58897;Inherit;False;EmissionColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.NormalVertexDataNode;48;597.0948,3811.602;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;204;-9.232084,12.27082;Inherit;False;41;EdgeTexBlendAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;77;-254.6662,184.8212;Inherit;False;Constant;_Color0;Color 0;20;0;Create;True;0;0;0;False;0;False;0,0,0,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;42;-177.0595,413.1865;Inherit;False;41;EdgeTexBlendAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-236.9604,4.551291;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;47;795.012,3662.44;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;202;-19.19021,-242.2177;Inherit;False;85;EmissionColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;30;47.28887,176.2776;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;203;236.1509,-131.4603;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;43;-2220.817,1355.663;Inherit;False;FinalAlpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;51;1007.176,3625.747;Inherit;False;FinalVertexDisplaement;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;166;726.4832,1414.126;Inherit;False;Property;_SmoothnessValue;Smoothness Value;4;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;205;125.8671,1450.763;Inherit;False;Property;_SpecularValue;Specular Value;36;0;Create;True;0;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;200;410.2835,318.8828;Inherit;False;Property;_EdgesAffect;EdgesAffect;13;0;Create;True;0;0;0;False;0;False;0;1;1;True;;KeywordEnum;2;Albedo;Emission;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;160;121.9856,922.1973;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;161;-219.5324,1040.567;Inherit;False;Property;_EmissionColor;Emission Color;6;1;[HDR];Create;True;0;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;86;-38.27685,612.5555;Inherit;False;85;EmissionColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;201;564.9861,739.3658;Inherit;False;Property;_EdgesAffect;EdgesAffect;13;0;Create;True;0;0;0;False;0;False;0;1;1;True;;KeywordEnum;2;Albedo;Emission;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;163;-70.5467,1170.995;Inherit;True;Property;_SpecularTexture;Specular Texture;3;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;159;-343.222,761.1112;Inherit;True;Property;_EmissionTexture;Emission Texture;5;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;black;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;29;1007.451,1432.885;Inherit;False;Constant;_Float0;Float 0;9;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;44;969.1602,1544.324;Inherit;False;43;FinalAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;52;957.9808,1292.172;Inherit;False;51;FinalVertexDisplaement;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;167;1450.498,1008.614;Inherit;True;Property;_OcclusionMap;Occlusion Map;7;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;157;1377.521,771.0546;Inherit;True;Property;_NormalTexture;Normal Texture;2;2;[NoScaleOffset];[Normal];Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;162;357.2116,693.8118;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;164;324.9483,1041.966;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;-302.678,732.7994;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;2;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ExtraPrePass;0;0;ExtraPrePass;5;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;True;17;d3d9;d3d11;glcore;gles;gles3;metal;vulkan;xbox360;xboxone;xboxseries;ps4;playstation;psp2;n3ds;wiiu;switch;nomrt;0;False;True;1;1;False;-1;0;False;-1;0;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;0;False;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;5;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;2;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;True;17;d3d9;d3d11;glcore;gles;gles3;metal;vulkan;xbox360;xboxone;xboxseries;ps4;playstation;psp2;n3ds;wiiu;switch;nomrt;0;False;True;1;1;False;-1;0;False;-1;1;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;False;False;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;LightMode=Universal2D;False;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;4;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;2;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;True;17;d3d9;d3d11;glcore;gles;gles3;metal;vulkan;xbox360;xboxone;xboxseries;ps4;playstation;psp2;n3ds;wiiu;switch;nomrt;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;3;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;2;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;True;17;d3d9;d3d11;glcore;gles;gles3;metal;vulkan;xbox360;xboxone;xboxseries;ps4;playstation;psp2;n3ds;wiiu;switch;nomrt;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;False;False;True;False;False;False;False;0;False;-1;False;False;False;False;False;False;False;False;False;True;1;False;-1;False;False;True;1;LightMode=DepthOnly;False;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;1;884.491,822.8542;Float;False;True;-1;2;;0;2;AxisDissolveSpecular;94348b07e5e8bab40bd6c8a1e3df54cd;True;Forward;0;1;Forward;18;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;2;True;17;d3d9;d3d11;glcore;gles;gles3;metal;vulkan;xbox360;xboxone;xboxseries;ps4;playstation;psp2;n3ds;wiiu;switch;nomrt;0;False;True;1;1;False;-1;0;False;-1;1;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;LightMode=UniversalForward;False;False;0;Hidden/InternalErrorShader;0;0;Standard;38;Workflow;0;637892317886498535;Surface;0;0;  Refraction Model;0;0;  Blend;0;0;Two Sided;1;0;Fragment Normal Space,InvertActionOnDeselection;0;637890066030807718;Transmission;0;0;  Transmission Shadow;0.5,False,-1;0;Translucency;0;0;  Translucency Strength;1,False,-1;0;  Normal Distortion;0.5,False,-1;0;  Scattering;2,False,-1;0;  Direct;0.9,False,-1;0;  Ambient;0.1,False,-1;0;  Shadow;0.5,False,-1;0;Cast Shadows;1;0;  Use Shadow Threshold;0;0;Receive Shadows;1;0;GPU Instancing;1;0;LOD CrossFade;1;0;Built-in Fog;1;0;_FinalColorxAlpha;0;0;Meta Pass;1;0;Override Baked GI;0;0;Extra Pre Pass;0;637890065982202104;DOTS Instancing;0;0;Tessellation;0;0;  Phong;0;0;  Strength;0.5,False,-1;0;  Type;0;0;  Tess;16,False,-1;0;  Min;10,False,-1;0;  Max;25,False,-1;0;  Edge Length;16,False,-1;0;  Max Displacement;25,False,-1;0;Write Depth;0;637890066170785359;  Early Z;0;637890066105496049;Vertex Position,InvertActionOnDeselection;1;0;0;6;False;True;True;True;True;True;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;2;0,0;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;2;New Amplify Shader;94348b07e5e8bab40bd6c8a1e3df54cd;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;True;17;d3d9;d3d11;glcore;gles;gles3;metal;vulkan;xbox360;xboxone;xboxseries;ps4;playstation;psp2;n3ds;wiiu;switch;nomrt;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;-1;True;3;False;-1;False;True;1;LightMode=ShadowCaster;False;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
WireConnection;177;0;176;0
WireConnection;177;1;178;0
WireConnection;65;0;66;0
WireConnection;65;1;177;0
WireConnection;181;0;180;0
WireConnection;181;1;177;0
WireConnection;170;0;20;0
WireConnection;170;1;21;0
WireConnection;7;0;6;0
WireConnection;171;0;21;0
WireConnection;171;1;20;0
WireConnection;70;0;69;0
WireConnection;70;1;65;0
WireConnection;68;0;69;0
WireConnection;68;9;181;0
WireConnection;68;3;66;0
WireConnection;71;1;70;1
WireConnection;71;0;68;1
WireConnection;58;1;170;0
WireConnection;58;0;171;0
WireConnection;57;1;15;1
WireConnection;57;0;15;2
WireConnection;57;2;15;3
WireConnection;172;0;58;0
WireConnection;24;0;26;0
WireConnection;24;1;25;0
WireConnection;17;0;71;0
WireConnection;17;1;18;0
WireConnection;154;0;32;0
WireConnection;102;0;172;0
WireConnection;103;0;172;1
WireConnection;104;0;24;0
WireConnection;16;0;17;0
WireConnection;16;1;57;0
WireConnection;155;1;156;0
WireConnection;155;0;154;0
WireConnection;38;0;25;0
WireConnection;38;1;32;0
WireConnection;96;1;57;0
WireConnection;96;0;16;0
WireConnection;108;1;106;0
WireConnection;108;2;107;0
WireConnection;108;3;96;0
WireConnection;31;0;26;0
WireConnection;31;1;38;0
WireConnection;152;0;105;0
WireConnection;152;1;155;0
WireConnection;153;0;110;0
WireConnection;153;1;155;0
WireConnection;19;1;102;0
WireConnection;19;2;103;0
WireConnection;19;3;16;0
WireConnection;75;0;74;0
WireConnection;112;0;153;0
WireConnection;112;1;108;0
WireConnection;146;0;133;0
WireConnection;22;0;27;0
WireConnection;22;1;19;0
WireConnection;34;0;31;0
WireConnection;34;1;19;0
WireConnection;109;0;152;0
WireConnection;109;1;108;0
WireConnection;35;0;22;0
WireConnection;35;1;34;0
WireConnection;189;0;190;0
WireConnection;189;1;191;0
WireConnection;140;0;142;0
WireConnection;140;3;74;0
WireConnection;144;0;147;0
WireConnection;144;3;133;0
WireConnection;113;0;112;0
WireConnection;113;1;109;0
WireConnection;139;0;142;0
WireConnection;139;1;75;0
WireConnection;143;0;147;0
WireConnection;143;1;146;0
WireConnection;141;1;139;1
WireConnection;141;0;140;1
WireConnection;145;1;143;1
WireConnection;145;0;144;1
WireConnection;98;0;35;0
WireConnection;101;0;113;0
WireConnection;183;0;182;0
WireConnection;183;1;189;0
WireConnection;186;0;185;0
WireConnection;186;1;183;0
WireConnection;128;0;130;0
WireConnection;128;1;129;0
WireConnection;128;2;145;0
WireConnection;72;0;37;0
WireConnection;72;1;73;0
WireConnection;72;2;141;0
WireConnection;41;0;98;0
WireConnection;36;0;128;0
WireConnection;36;1;72;0
WireConnection;36;2;40;0
WireConnection;188;0;186;1
WireConnection;188;1;54;0
WireConnection;197;0;50;0
WireConnection;197;1;186;1
WireConnection;79;1;36;0
WireConnection;79;2;78;0
WireConnection;53;0;197;0
WireConnection;53;1;188;0
WireConnection;53;2;46;0
WireConnection;56;1;53;0
WireConnection;56;2;55;0
WireConnection;85;0;79;0
WireConnection;10;0;9;0
WireConnection;10;1;8;0
WireConnection;47;0;56;0
WireConnection;47;1;48;0
WireConnection;30;0;10;0
WireConnection;30;1;77;0
WireConnection;30;2;42;0
WireConnection;203;0;10;0
WireConnection;203;1;202;0
WireConnection;203;2;204;0
WireConnection;43;0;22;0
WireConnection;51;0;47;0
WireConnection;200;1;203;0
WireConnection;200;0;30;0
WireConnection;160;0;159;0
WireConnection;160;1;161;0
WireConnection;201;1;160;0
WireConnection;201;0;162;0
WireConnection;162;0;86;0
WireConnection;162;1;160;0
WireConnection;164;0;163;1
WireConnection;164;1;205;0
WireConnection;1;0;200;0
WireConnection;1;1;157;0
WireConnection;1;2;201;0
WireConnection;1;9;164;0
WireConnection;1;4;166;0
WireConnection;1;5;167;0
WireConnection;1;6;44;0
WireConnection;1;7;29;0
WireConnection;1;8;52;0
ASEEND*/
//CHKSM=0B2C08991A488AADA0A642A0031ED6209ED4ECE9