// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "E3D/Tran-Normal-WorldY"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_MainTex("MainTex", 2D) = "white" {}
		[HDR]_L3Color("L3-Color", Color) = (11.68357,12,6.264707,0)
		_L3Offset("L3-Offset", Range( 0 , 8)) = 0.8991984
		[HDR]_L2Color("L2-Color", Color) = (1,0.6413794,0,0)
		_L2Offset("L2-Offset", Range( 0 , 3)) = 0.8991984
		[HDR]_L1Color("L1-Color", Color) = (1,0,0,0)
		_L1Offset("L1-Offset", Range( 0 , 3)) = 0.8991984
		_TranProgress("Tran-Progress", Range( 0 , 1)) = 0
		_OffsetY("OffsetY", Range( 0 , 30)) = 1
		_SpecMap("SpecMap", 2D) = "white" {}
		_Smooth("Smooth", Range( 0 , 2)) = 1
		_NormalMap("NormalMap", 2D) = "bump" {}
		_GlowMap("GlowMap", 2D) = "white" {}
		_Glow("Glow", Range( 0 , 4)) = 1
		_NoiseTexture("NoiseTexture", 2D) = "white" {}
		_NoiseSpeed1("NoiseSpeed1", Range( 0 , 25)) = 1
		_NoiseSpeed2("NoiseSpeed2", Range( 0 , 25)) = 1
		_Noise2Add("Noise2Add", Range( -0.5 , 3)) = -0.5
		_NoiseFinMin("NoiseFinMin", Range( 0 , 1)) = -0.5
		_UTling("U-Tling", Range( 0.01 , 4)) = 2
		_VTing("V-Ting", Range( 0.1 , 12)) = 2
		_Noise2Tiling("Noise2-Tiling", Range( 1 , 12)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityPBSLighting.cginc"
		#include "UnityShaderVariables.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif
		struct Input
		{
			float3 worldPos;
			float2 uv_texcoord;
			float3 worldNormal;
			INTERNAL_DATA
		};

		struct SurfaceOutputCustomLightingCustom
		{
			half3 Albedo;
			half3 Normal;
			half3 Emission;
			half Metallic;
			half Smoothness;
			half Occlusion;
			half Alpha;
			Input SurfInput;
			UnityGIInput GIData;
		};

		uniform float _TranProgress;
		uniform float _L3Offset;
		uniform float _OffsetY;
		uniform sampler2D _GlowMap;
		uniform float4 _GlowMap_ST;
		uniform float _Glow;
		uniform float4 _L1Color;
		uniform float _L2Offset;
		uniform float _L1Offset;
		uniform float4 _L2Color;
		uniform float4 _L3Color;
		uniform sampler2D _NoiseTexture;
		uniform float _NoiseSpeed1;
		uniform float _UTling;
		uniform float _VTing;
		uniform float _Noise2Tiling;
		uniform float _NoiseSpeed2;
		uniform float _Noise2Add;
		uniform float _NoiseFinMin;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform sampler2D _NormalMap;
		uniform float4 _NormalMap_ST;
		uniform sampler2D _SpecMap;
		uniform float4 _SpecMap_ST;
		uniform float _Smooth;
		uniform float _Cutoff = 0.5;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float temp_output_174_0 = ( ase_worldPos.y + (-10.0 + (_TranProgress - 0.0) * (0.0 - -10.0) / (1.0 - 0.0)) );
			float temp_output_222_0 = ( temp_output_174_0 + _L3Offset );
			float OffsetY210 = temp_output_222_0;
			float3 appendResult310 = (float3(0.0 , _OffsetY , 0.0));
			float4 ase_vertex4Pos = v.vertex;
			float4 transform298 = mul(unity_ObjectToWorld,ase_vertex4Pos);
			float4 transform308 = mul(unity_WorldToObject,( float4( appendResult310 , 0.0 ) + transform298 ));
			float3 ase_vertex3Pos = v.vertex.xyz;
			v.vertex.xyz += ( saturate( OffsetY210 ) * ( transform308 - float4( ase_vertex3Pos , 0.0 ) ) ).xyz;
		}

		inline half4 LightingStandardCustomLighting( inout SurfaceOutputCustomLightingCustom s, half3 viewDir, UnityGI gi )
		{
			UnityGIInput data = s.GIData;
			Input i = s.SurfInput;
			half4 c = 0;
			float mulTime337 = _Time.y * -1.0;
			float3 ase_worldPos = i.worldPos;
			float temp_output_336_0 = ( ( mulTime337 * _NoiseSpeed1 ) + ase_worldPos.y );
			float2 appendResult325 = (float2(temp_output_336_0 , ase_worldPos.z));
			float2 appendResult365 = (float2(_UTling , _VTing));
			float2 appendResult324 = (float2(temp_output_336_0 , ase_worldPos.x));
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float4 lerpResult333 = lerp( tex2D( _NoiseTexture, ( appendResult325 * appendResult365 ) ) , tex2D( _NoiseTexture, ( appendResult324 * appendResult365 ) ) , saturate( (0.0 + (abs( ase_worldNormal.z ) - 0.1) * (2.0 - 0.0) / (1.0 - 0.1)) ));
			float2 temp_output_375_0 = ( appendResult365 * _Noise2Tiling );
			float mulTime342 = _Time.y * -1.0;
			float temp_output_346_0 = ( ( mulTime342 * _NoiseSpeed2 ) + ase_worldPos.y );
			float2 appendResult348 = (float2(temp_output_346_0 , ase_worldPos.z));
			float2 appendResult350 = (float2(temp_output_346_0 , ase_worldPos.x));
			float4 lerpResult354 = lerp( tex2D( _NoiseTexture, ( temp_output_375_0 * appendResult348 ) ) , tex2D( _NoiseTexture, ( temp_output_375_0 * appendResult350 ) ) , saturate( (0.0 + (abs( ase_worldNormal.z ) - 0.1) * (2.0 - 0.0) / (1.0 - 0.1)) ));
			float luminance357 = Luminance(( lerpResult333 * ( lerpResult354 * _Noise2Add ) ).rgb);
			float DissloveMask186 = saturate( (0.0 + (luminance357 - _NoiseFinMin) * (2.0 - 0.0) / (1.5 - _NoiseFinMin)) );
			float temp_output_174_0 = ( ase_worldPos.y + (-10.0 + (_TranProgress - 0.0) * (0.0 - -10.0) / (1.0 - 0.0)) );
			float temp_output_222_0 = ( temp_output_174_0 + _L3Offset );
			float temp_output_177_0 = ( temp_output_222_0 + _L2Offset );
			float L2Mask264 = saturate( temp_output_177_0 );
			float AlphaClip201 = saturate( ( ( ( DissloveMask186 * L2Mask264 ) + ( 1.0 - L2Mask264 ) ) * ( 1.0 - saturate( temp_output_174_0 ) ) ) );
			SurfaceOutputStandard s270 = (SurfaceOutputStandard ) 0;
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			s270.Albedo = tex2D( _MainTex, uv_MainTex ).rgb;
			float2 uv_NormalMap = i.uv_texcoord * _NormalMap_ST.xy + _NormalMap_ST.zw;
			s270.Normal = WorldNormalVector( i , UnpackNormal( tex2D( _NormalMap, uv_NormalMap ) ) );
			s270.Emission = float3( 0,0,0 );
			float2 uv_SpecMap = i.uv_texcoord * _SpecMap_ST.xy + _SpecMap_ST.zw;
			float4 tex2DNode272 = tex2D( _SpecMap, uv_SpecMap );
			s270.Metallic = ( tex2DNode272.a + 0.0 );
			s270.Smoothness = ( ( tex2DNode272.r + 0.5 ) * _Smooth );
			s270.Occlusion = 1.0;

			data.light = gi.light;

			UnityGI gi270 = gi;
			#ifdef UNITY_PASS_FORWARDBASE
			Unity_GlossyEnvironmentData g270 = UnityGlossyEnvironmentSetup( s270.Smoothness, data.worldViewDir, s270.Normal, float3(0,0,0));
			gi270 = UnityGlobalIllumination( data, s270.Occlusion, s270.Normal, g270 );
			#endif

			float3 surfResult270 = LightingStandard ( s270, viewDir, gi270 ).rgb;
			surfResult270 += s270.Emission;

			#ifdef UNITY_PASS_FORWARDADD//270
			surfResult270 -= s270.Emission;
			#endif//270
			c.rgb = surfResult270;
			c.a = 1;
			clip( AlphaClip201 - _Cutoff );
			return c;
		}

		inline void LightingStandardCustomLighting_GI( inout SurfaceOutputCustomLightingCustom s, UnityGIInput data, inout UnityGI gi )
		{
			s.GIData = data;
		}

		void surf( Input i , inout SurfaceOutputCustomLightingCustom o )
		{
			o.SurfInput = i;
			o.Normal = float3(0,0,1);
			float2 uv_GlowMap = i.uv_texcoord * _GlowMap_ST.xy + _GlowMap_ST.zw;
			float3 ase_worldPos = i.worldPos;
			float temp_output_174_0 = ( ase_worldPos.y + (-10.0 + (_TranProgress - 0.0) * (0.0 - -10.0) / (1.0 - 0.0)) );
			float temp_output_222_0 = ( temp_output_174_0 + _L3Offset );
			float temp_output_177_0 = ( temp_output_222_0 + _L2Offset );
			float4 lerpResult179 = lerp( float4( 0,0,0,0 ) , _L1Color , saturate( ( temp_output_177_0 + _L1Offset ) ));
			float L2Mask264 = saturate( temp_output_177_0 );
			float4 lerpResult181 = lerp( lerpResult179 , _L2Color , L2Mask264);
			float4 lerpResult191 = lerp( lerpResult181 , _L3Color , saturate( temp_output_222_0 ));
			o.Emission = ( ( tex2D( _GlowMap, uv_GlowMap ) * _Glow ) + lerpResult191 ).rgb;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf StandardCustomLighting keepalpha fullforwardshadows vertex:vertexDataFunc 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float4 tSpace0 : TEXCOORD2;
				float4 tSpace1 : TEXCOORD3;
				float4 tSpace2 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				vertexDataFunc( v, customInputData );
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.worldNormal = float3( IN.tSpace0.z, IN.tSpace1.z, IN.tSpace2.z );
				surfIN.internalSurfaceTtoW0 = IN.tSpace0.xyz;
				surfIN.internalSurfaceTtoW1 = IN.tSpace1.xyz;
				surfIN.internalSurfaceTtoW2 = IN.tSpace2.xyz;
				SurfaceOutputCustomLightingCustom o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputCustomLightingCustom, o )
				surf( surfIN, o );
				UnityGI gi;
				UNITY_INITIALIZE_OUTPUT( UnityGI, gi );
				o.Alpha = LightingStandardCustomLighting( o, worldViewDir, gi ).a;
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17500
352;598;1317;478;-5320.203;330.5468;1.911337;True;False
Node;AmplifyShaderEditor.CommentaryNode;340;1553.45,-1511.222;Inherit;False;2832.895;772.9218;Comment;18;341;348;346;343;342;344;350;345;354;351;353;352;349;347;371;372;373;374;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;335;1582.162,-2283.903;Inherit;False;2797.782;742.8256;Comment;21;324;325;336;321;338;326;339;337;333;322;332;334;331;327;362;363;365;366;367;369;375;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;341;1714.053,-1350.608;Inherit;False;Property;_NoiseSpeed2;NoiseSpeed2;17;0;Create;True;0;0;False;0;1;1;0;25;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;342;1807.694,-1429.441;Inherit;False;1;0;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;339;1652.479,-2148.956;Inherit;False;Property;_NoiseSpeed1;NoiseSpeed1;16;0;Create;True;0;0;False;0;1;1;0;25;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;344;1946.855,-1267.934;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;363;2155.881,-1789.06;Inherit;False;Property;_VTing;V-Ting;21;0;Create;True;0;0;False;0;2;3;0.1;12;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;343;2028.854,-1379.907;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;337;1738.321,-2239.49;Inherit;False;1;0;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;362;2160.124,-1867.93;Inherit;False;Property;_UTling;U-Tling;20;0;Create;True;0;0;False;0;2;3;0.01;4;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;365;2478.616,-1838.454;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;369;2294.155,-1604.711;Inherit;False;Property;_Noise2Tiling;Noise2-Tiling;22;0;Create;True;0;0;False;0;0;4.33;1;12;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;346;2224.313,-1342.969;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;338;1959.48,-2189.956;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;321;1933.882,-2085.382;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldNormalVector;345;3225.506,-1074.874;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DynamicAppendNode;348;2458.612,-1342.84;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;350;2471.704,-1205.124;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;336;2154.938,-2153.018;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.AbsOpNode;347;3502.195,-1034.9;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;326;3305.952,-1820.872;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;375;2669.511,-1673.645;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;325;2389.237,-2152.888;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.AbsOpNode;327;3543.468,-1795.021;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;349;3638.073,-1037.772;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0.1;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;324;2382.263,-2021.42;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;371;2924.933,-1401.166;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;372;2921.445,-1221.882;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;367;2788.257,-1864.785;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;366;2779.27,-2151.952;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;269;2689.194,-174.5094;Inherit;False;859.8975;460.0518;Tran-Y-Offset-Root;4;258;173;257;174;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;353;3542.191,-1424.152;Inherit;True;Property;_TextureSample2;Texture Sample 2;15;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Instance;322;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;351;3844.434,-1043.657;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;331;3679.346,-1797.893;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0.1;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;352;3536.804,-1239.259;Inherit;True;Property;_TextureSample1;Texture Sample 1;15;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Instance;322;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;258;2733.758,84.97825;Inherit;False;Property;_TranProgress;Tran-Progress;8;0;Create;True;0;0;False;0;0;0.508;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;354;4048.47,-1094.324;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;373;3915.129,-954.1971;Inherit;False;Property;_Noise2Add;Noise2Add;18;0;Create;True;0;0;False;0;-0.5;3;-0.5;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;332;3898.782,-1801.908;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;334;3578.077,-1999.379;Inherit;True;Property;_TextureSample0;Texture Sample 0;15;0;Create;True;0;0;False;0;-1;None;None;True;0;False;white;Auto;False;Instance;322;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;322;3579.463,-2186.272;Inherit;True;Property;_NoiseTexture;NoiseTexture;15;0;Create;True;0;0;False;0;-1;None;46a48ced0ebbb9540a791deaf4793014;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WorldPosInputsNode;173;3007.029,-124.5094;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.CommentaryNode;379;4514.95,-1387.907;Inherit;False;1397.452;421.1396;Comment;6;355;357;361;358;359;186;;1,1,1,1;0;0
Node;AmplifyShaderEditor.TFHCRemapNode;257;3047.194,90.54241;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;-10;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;267;3792.061,24.94159;Inherit;False;2584.145;847.575;Comment;18;222;178;177;189;188;180;185;179;190;181;182;265;264;210;184;191;192;223;;1,1,1,1;0;0
Node;AmplifyShaderEditor.LerpOp;333;4122.598,-1850.659;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;374;4264.642,-1013.098;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;223;3842.061,335.6406;Inherit;False;Property;_L3Offset;L3-Offset;3;0;Create;True;0;0;False;0;0.8991984;2.89;0;8;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;174;3314.092,-4.146039;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;355;4564.95,-1337.907;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LuminanceNode;357;4825.727,-1335.607;Inherit;True;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;361;4686.837,-1081.767;Inherit;False;Property;_NoiseFinMin;NoiseFinMin;19;0;Create;True;0;0;False;0;-0.5;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;222;4231.73,316.2442;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;178;4201.445,551.2245;Inherit;False;Property;_L2Offset;L2-Offset;5;0;Create;True;0;0;False;0;0.8991984;0.16;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;177;4601.422,430.8072;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;358;5067.24,-1287.014;Inherit;True;5;0;FLOAT;0;False;1;FLOAT;0.58;False;2;FLOAT;1.5;False;3;FLOAT;0;False;4;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;359;5420.633,-1288.199;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;190;4912.991,300.418;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;186;5669.401,-1277.052;Inherit;False;DissloveMask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;264;5122.963,296.9907;Inherit;False;L2Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;189;4546.369,692.465;Inherit;False;Property;_L1Offset;L1-Offset;7;0;Create;True;0;0;False;0;0.8991984;0.05;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;268;4484.599,-630.7761;Inherit;False;1639.618;580.4785;AlphaMask;10;226;225;227;198;187;266;199;245;201;377;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;381;6530.383,654.9955;Inherit;False;1509.758;651.8746;Comment;11;211;216;217;297;303;310;298;299;302;308;301;;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;187;4524.6,-583.7761;Inherit;False;186;DissloveMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;188;4900.975,619.5166;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;266;4539.04,-497.9945;Inherit;True;264;L2Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;303;6580.383,980.5736;Inherit;False;Property;_OffsetY;OffsetY;9;0;Create;True;0;0;False;0;1;2.6;0;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;225;4528.114,-270.9926;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;297;6589.787,1090.94;Inherit;False;1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;199;4801.36,-355.8315;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;198;4803.385,-586.3859;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;185;5156.17,618.1574;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;180;5117.647,459.7441;Inherit;False;Property;_L1Color;L1-Color;6;1;[HDR];Create;True;0;0;False;0;1,0,0,0;0.4411767,0.3014706,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;226;5091.248,-281.1925;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;378;6944.002,-1327.304;Inherit;False;1476.351;1008.328;PBR;9;289;272;274;288;287;273;218;276;270;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;377;5140.819,-587.956;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ObjectToWorldTransfNode;298;6861.917,1091.907;Inherit;False;1;0;FLOAT4;0,0,0,1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;310;6920.624,963.5538;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;179;5400.364,572.9546;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;182;5438.086,295.5818;Inherit;False;Property;_L2Color;L2-Color;4;1;[HDR];Create;True;0;0;False;0;1,0.6413794,0,0;0.778564,0,2.130034,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;265;5468.464,468.994;Inherit;False;264;L2Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;282;6474.335,44.63073;Inherit;False;Property;_Glow;Glow;14;0;Create;True;0;0;False;0;1;1.74;0;4;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;210;4599.496,318.5316;Inherit;False;OffsetY;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;299;7242.239,958.2881;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;289;7128.811,-1277.304;Inherit;False;Constant;_Float0;Float 0;22;0;Create;True;0;0;False;0;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;278;6480.21,-168.5682;Inherit;True;Property;_GlowMap;GlowMap;13;0;Create;True;0;0;False;0;-1;None;a55eba92d222bac44a1314760fc4c0d9;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;272;6994.002,-939.5916;Inherit;True;Property;_SpecMap;SpecMap;10;0;Create;True;0;0;False;0;-1;None;2561b5c462685af44b9d7528a9610535;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;181;5840.844,424.7544;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;184;4664.759,188.7191;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;192;5818.345,60.5774;Inherit;False;Property;_L3Color;L3-Color;2;1;[HDR];Create;True;0;0;False;0;11.68357,12,6.264707,0;0,10.14524,18.621,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;227;5388.585,-446.3061;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;211;7414.827,704.9954;Inherit;True;210;OffsetY;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;280;6923.768,-57.43482;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.PosVertexDataNode;302;7423.518,1127.87;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WorldToObjectTransfNode;308;7417.765,956.2804;Inherit;False;1;0;FLOAT4;0,0,0,1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;274;7420.432,-1165.413;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;191;6118.389,148.7269;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;245;5642.274,-449.9368;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;288;7345.247,-917.8361;Inherit;False;Property;_Smooth;Smooth;11;0;Create;True;0;0;False;0;1;1.16;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;276;7360.406,-792.6838;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;201;5875.044,-458.0504;Inherit;False;AlphaClip;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;301;7700.893,1030.523;Inherit;False;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;287;7795.771,-1064.462;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;220;7213.96,125.5542;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;217;7649.636,708.379;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;218;7278.426,-548.9763;Inherit;True;Property;_MainTex;MainTex;1;0;Create;True;0;0;False;0;-1;None;fc49ab45793cdad49ad240c866252d57;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;273;7009.124,-1182.715;Inherit;True;Property;_NormalMap;NormalMap;12;0;Create;True;0;0;False;0;-1;None;72b1e69e5eeb1244b86be9b7e1b16803;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WireNode;380;7947.464,131.707;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;279;6475.744,215.8212;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;202;8520.278,119.348;Inherit;False;201;AlphaClip;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.CustomStandardSurface;270;8160.354,-646.7997;Inherit;False;Metallic;Tangent;6;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,1;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;216;7871.142,793.0446;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;61;8996.187,-89.3984;Float;False;True;-1;2;ASEMaterialInspector;0;0;CustomLighting;E3D/Tran-Normal-WorldY;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;TransparentCutout;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;343;0;342;0
WireConnection;343;1;341;0
WireConnection;365;0;362;0
WireConnection;365;1;363;0
WireConnection;346;0;343;0
WireConnection;346;1;344;2
WireConnection;338;0;337;0
WireConnection;338;1;339;0
WireConnection;348;0;346;0
WireConnection;348;1;344;3
WireConnection;350;0;346;0
WireConnection;350;1;344;0
WireConnection;336;0;338;0
WireConnection;336;1;321;2
WireConnection;347;0;345;3
WireConnection;375;0;365;0
WireConnection;375;1;369;0
WireConnection;325;0;336;0
WireConnection;325;1;321;3
WireConnection;327;0;326;3
WireConnection;349;0;347;0
WireConnection;324;0;336;0
WireConnection;324;1;321;1
WireConnection;371;0;375;0
WireConnection;371;1;348;0
WireConnection;372;0;375;0
WireConnection;372;1;350;0
WireConnection;367;0;324;0
WireConnection;367;1;365;0
WireConnection;366;0;325;0
WireConnection;366;1;365;0
WireConnection;353;1;371;0
WireConnection;351;0;349;0
WireConnection;331;0;327;0
WireConnection;352;1;372;0
WireConnection;354;0;353;0
WireConnection;354;1;352;0
WireConnection;354;2;351;0
WireConnection;332;0;331;0
WireConnection;334;1;367;0
WireConnection;322;1;366;0
WireConnection;257;0;258;0
WireConnection;333;0;322;0
WireConnection;333;1;334;0
WireConnection;333;2;332;0
WireConnection;374;0;354;0
WireConnection;374;1;373;0
WireConnection;174;0;173;2
WireConnection;174;1;257;0
WireConnection;355;0;333;0
WireConnection;355;1;374;0
WireConnection;357;0;355;0
WireConnection;222;0;174;0
WireConnection;222;1;223;0
WireConnection;177;0;222;0
WireConnection;177;1;178;0
WireConnection;358;0;357;0
WireConnection;358;1;361;0
WireConnection;359;0;358;0
WireConnection;190;0;177;0
WireConnection;186;0;359;0
WireConnection;264;0;190;0
WireConnection;188;0;177;0
WireConnection;188;1;189;0
WireConnection;225;0;174;0
WireConnection;199;0;266;0
WireConnection;198;0;187;0
WireConnection;198;1;266;0
WireConnection;185;0;188;0
WireConnection;226;0;225;0
WireConnection;377;0;198;0
WireConnection;377;1;199;0
WireConnection;298;0;297;0
WireConnection;310;1;303;0
WireConnection;179;1;180;0
WireConnection;179;2;185;0
WireConnection;210;0;222;0
WireConnection;299;0;310;0
WireConnection;299;1;298;0
WireConnection;181;0;179;0
WireConnection;181;1;182;0
WireConnection;181;2;265;0
WireConnection;184;0;222;0
WireConnection;227;0;377;0
WireConnection;227;1;226;0
WireConnection;280;0;278;0
WireConnection;280;1;282;0
WireConnection;308;0;299;0
WireConnection;274;0;272;1
WireConnection;274;1;289;0
WireConnection;191;0;181;0
WireConnection;191;1;192;0
WireConnection;191;2;184;0
WireConnection;245;0;227;0
WireConnection;276;0;272;4
WireConnection;201;0;245;0
WireConnection;301;0;308;0
WireConnection;301;1;302;0
WireConnection;287;0;274;0
WireConnection;287;1;288;0
WireConnection;220;0;280;0
WireConnection;220;1;191;0
WireConnection;217;0;211;0
WireConnection;380;0;220;0
WireConnection;279;0;191;0
WireConnection;270;0;218;0
WireConnection;270;1;273;0
WireConnection;270;3;276;0
WireConnection;270;4;287;0
WireConnection;216;0;217;0
WireConnection;216;1;301;0
WireConnection;61;2;380;0
WireConnection;61;10;202;0
WireConnection;61;13;270;0
WireConnection;61;11;216;0
ASEEND*/
//CHKSM=1067ABA652F1A19E79A7B900F7546103AAEAAE8E