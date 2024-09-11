// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "E3D/SHeroEffect/Actor-Effect-TransL1"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_MainTex("MainTex", 2D) = "white" {}
		_Noise1Scale("Noise1-Scale", Range( 0.1 , 150)) = 79.01261
		_Noise1Multiply("Noise1-Multiply", Range( 0 , 8)) = 3
		_Speed1("Speed 1", Range( -0.5 , 0.5)) = 0
		_Noise2TilingUV("Noise2-Tiling-UV", Range( 0.0001 , 1)) = 0.032
		_Noise2Scale("Noise2-Scale", Range( 0.1 , 150)) = 79.01261
		_Noise2Multiply("Noise2-Multiply", Range( 0 , 12)) = 3
		_Speed2("Speed 2", Range( -2 , 0.5)) = 0
		[HDR]_L3Color("L3-Color", Color) = (11.68357,12,6.264707,0)
		_L3Offset("L3-Offset", Range( 0 , 8)) = 0.8991984
		[HDR]_L2Color("L2-Color", Color) = (1,0.6413794,0,0)
		_L2Offset("L2-Offset", Range( 0 , 3)) = 0.8991984
		[HDR]_L1Color("L1-Color", Color) = (1,0,0,0)
		_L1Offset("L1-Offset", Range( 0 , 3)) = 0.8991984
		_VertexY("VertexY", Range( -10 , 30)) = 3
		_TranProgress("Tran-Progress", Range( 0 , 1)) = 0
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
		struct Input
		{
			float3 worldPos;
			float2 uv_texcoord;
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
		uniform float _VertexY;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float4 _L1Color;
		uniform float _L2Offset;
		uniform float _L1Offset;
		uniform float4 _L2Color;
		uniform float4 _L3Color;
		uniform float _Speed1;
		uniform float _Noise1Scale;
		uniform float _Noise1Multiply;
		uniform float _Noise2TilingUV;
		uniform float _Speed2;
		uniform float _Noise2Scale;
		uniform float _Noise2Multiply;
		uniform float _Cutoff = 0.5;


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


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float temp_output_174_0 = ( ase_worldPos.y + (-10.0 + (_TranProgress - 0.0) * (0.0 - -10.0) / (1.0 - 0.0)) );
			float temp_output_222_0 = ( temp_output_174_0 + _L3Offset );
			float OffsetY210 = temp_output_222_0;
			float3 appendResult206 = (float3(_VertexY , 0.0 , 0.0));
			v.vertex.xyz += ( saturate( OffsetY210 ) * appendResult206 );
		}

		inline half4 LightingStandardCustomLighting( inout SurfaceOutputCustomLightingCustom s, half3 viewDir, UnityGI gi )
		{
			UnityGIInput data = s.GIData;
			Input i = s.SurfInput;
			half4 c = 0;
			float mulTime167 = _Time.y * _Speed1;
			float2 appendResult171 = (float2(1.0 , mulTime167));
			float2 uv_TexCoord163 = i.uv_texcoord + appendResult171;
			float simplePerlin2D162 = snoise( uv_TexCoord163*_Noise1Scale );
			simplePerlin2D162 = simplePerlin2D162*0.5 + 0.5;
			float temp_output_168_0 = ( simplePerlin2D162 * _Noise1Multiply );
			float3 ase_worldPos = i.worldPos;
			float2 appendResult249 = (float2(ase_worldPos.x , ( ase_worldPos.y * _Noise2TilingUV )));
			float mulTime241 = _Time.y * _Speed2;
			float2 appendResult242 = (float2(1.0 , mulTime241));
			float simplePerlin2D234 = snoise( ( appendResult249 + appendResult242 )*_Noise2Scale );
			simplePerlin2D234 = simplePerlin2D234*0.5 + 0.5;
			float temp_output_237_0 = ( simplePerlin2D234 * _Noise2Multiply );
			float DissloveMask186 = ( 1.0 - ( temp_output_168_0 * saturate( temp_output_237_0 ) ) );
			float temp_output_174_0 = ( ase_worldPos.y + (-10.0 + (_TranProgress - 0.0) * (0.0 - -10.0) / (1.0 - 0.0)) );
			float temp_output_222_0 = ( temp_output_174_0 + _L3Offset );
			float temp_output_177_0 = ( temp_output_222_0 + _L2Offset );
			float L2Mask264 = saturate( temp_output_177_0 );
			float AlphaClip201 = saturate( ( ( 1.0 - ( DissloveMask186 * L2Mask264 ) ) * ( 1.0 - saturate( temp_output_174_0 ) ) ) );
			c.rgb = 0;
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
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			float3 ase_worldPos = i.worldPos;
			float temp_output_174_0 = ( ase_worldPos.y + (-10.0 + (_TranProgress - 0.0) * (0.0 - -10.0) / (1.0 - 0.0)) );
			float temp_output_222_0 = ( temp_output_174_0 + _L3Offset );
			float temp_output_177_0 = ( temp_output_222_0 + _L2Offset );
			float4 lerpResult179 = lerp( float4( 0,0,0,0 ) , _L1Color , saturate( ( temp_output_177_0 + _L1Offset ) ));
			float L2Mask264 = saturate( temp_output_177_0 );
			float4 lerpResult181 = lerp( lerpResult179 , _L2Color , L2Mask264);
			float4 lerpResult191 = lerp( lerpResult181 , _L3Color , saturate( temp_output_222_0 ));
			o.Emission = ( tex2D( _MainTex, uv_MainTex ) + lerpResult191 ).rgb;
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
				float3 worldPos : TEXCOORD2;
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
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
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
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
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
196;331;1135;557;-2220.432;1364.693;1.622787;True;False
Node;AmplifyShaderEditor.CommentaryNode;259;2522.559,-1525.579;Inherit;False;1164.734;858.2734;Noise UV;11;171;250;167;249;242;241;251;172;248;240;253;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;253;2553.255,-1025.642;Inherit;False;Property;_Noise2TilingUV;Noise2-Tiling-UV;5;0;Create;True;0;0;False;0;0.032;0.672;0.0001;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;248;2588.169,-1249.424;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;240;2772.108,-839.7226;Inherit;False;Property;_Speed2;Speed 2;8;0;Create;True;0;0;False;0;0;-0.38;-2;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;241;3089.415,-832.7506;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;251;2850.314,-1100.996;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;172;2922.292,-1436.109;Inherit;False;Property;_Speed1;Speed 1;4;0;Create;True;0;0;False;0;0;-0.041;-0.5;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;242;3320.159,-857.9847;Inherit;False;FLOAT2;4;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleTimeNode;167;3239.599,-1429.136;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;249;3026.475,-1227.589;Inherit;True;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;260;3792.848,-1549.082;Inherit;False;2051.296;851.6046;Noise-Combine;14;186;243;246;238;168;247;237;169;162;163;236;234;164;235;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;269;2689.194,-174.5094;Inherit;False;859.8975;460.0518;Tran-Y-Offset-Root;4;258;173;257;174;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;235;3842.848,-991.8956;Inherit;False;Property;_Noise2Scale;Noise2-Scale;6;0;Create;True;0;0;False;0;79.01261;1.4;0.1;150;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;258;2739.194,79.5424;Inherit;False;Property;_TranProgress;Tran-Progress;16;0;Create;True;0;0;False;0;0;0.721;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;171;3450.296,-1453.401;Inherit;False;FLOAT2;4;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;250;3505.617,-1074.481;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;267;3783.364,35.81268;Inherit;False;2584.145;847.575;Comment;18;222;178;177;189;188;180;185;179;190;181;182;265;264;210;184;191;192;223;;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;163;3879.257,-1499.082;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;164;3858.137,-1316.111;Inherit;False;Property;_Noise1Scale;Noise1-Scale;2;0;Create;True;0;0;False;0;79.01261;139;0.1;150;0;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;234;4213.238,-1083.227;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;257;3052.194,83.54241;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;-10;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;236;4193.669,-844.3921;Inherit;False;Property;_Noise2Multiply;Noise2-Multiply;7;0;Create;True;0;0;False;0;3;1.47;0;12;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;173;3007.029,-124.5094;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;169;4191.246,-1228.266;Inherit;False;Property;_Noise1Multiply;Noise1-Multiply;3;0;Create;True;0;0;False;0;3;0.99;0;8;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;237;4552.141,-995.2524;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;223;3833.364,346.5116;Inherit;False;Property;_L3Offset;L3-Offset;10;0;Create;True;0;0;False;0;0.8991984;1.24;0;8;0;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;162;4219.957,-1451.725;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;174;3314.092,-4.146039;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;168;4561.667,-1343.378;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;222;4223.033,327.1152;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;247;4804.465,-990.5543;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;178;4192.748,562.0956;Inherit;False;Property;_L2Offset;L2-Offset;12;0;Create;True;0;0;False;0;0.8991984;1.03;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;238;4977.9,-1070.932;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;177;4592.725,441.6782;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;246;5270.97,-1069.749;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;190;4904.294,311.289;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;264;5114.266,307.8617;Inherit;False;L2Mask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;268;3802.354,-611.6039;Inherit;False;1639.618;580.4785;AlphaMask;9;226;225;227;198;187;266;199;245;201;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;186;5588.175,-1071.662;Inherit;False;DissloveMask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;187;3852.355,-561.6039;Inherit;False;186;DissloveMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;266;3879.217,-469.8223;Inherit;False;264;L2Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;189;4537.672,703.3361;Inherit;False;Property;_L1Offset;L1-Offset;14;0;Create;True;0;0;False;0;0.8991984;0.49;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;198;4149.344,-556.3082;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;225;3857.92,-284.9606;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;188;4892.278,630.3877;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;199;4410.857,-557.8484;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;226;4409.003,-287.6286;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;185;5147.473,629.0285;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;180;5108.95,470.6151;Inherit;False;Property;_L1Color;L1-Color;13;1;[HDR];Create;True;0;0;False;0;1,0,0,0;0.04411763,0.04411763,0.04411763,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;265;5459.767,479.865;Inherit;False;264;L2Mask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;179;5391.667,583.8257;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;229;6493.639,434.4412;Inherit;False;733.8882;405.2561;Comment;5;217;208;211;206;216;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;227;4685.083,-423.8636;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;210;4636.799,326.4026;Inherit;False;OffsetY;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;182;5429.389,306.4528;Inherit;False;Property;_L2Color;L2-Color;11;1;[HDR];Create;True;0;0;False;0;1,0.6413794,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;192;5809.648,71.44849;Inherit;False;Property;_L3Color;L3-Color;9;1;[HDR];Create;True;0;0;False;0;11.68357,12,6.264707,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;245;4953.465,-430.7646;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;211;6603.373,484.4414;Inherit;True;210;OffsetY;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;184;4656.062,199.5902;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;181;5832.147,435.6254;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;208;6548.639,685.847;Inherit;False;Property;_VertexY;VertexY;15;0;Create;True;0;0;False;0;3;0.9;-10;30;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;218;6552.12,-8.082397;Inherit;True;Property;_MainTex;MainTex;1;0;Create;True;0;0;False;0;-1;None;fc49ab45793cdad49ad240c866252d57;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;217;6846.33,488.9891;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;206;6844.779,683.6978;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;191;6109.692,159.598;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;201;5190.425,-434.1282;Inherit;False;AlphaClip;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;202;7042.456,301.4241;Inherit;False;201;AlphaClip;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;216;7058.527,571.3268;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;243;4969.222,-1348.089;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;220;7069.217,133.742;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;61;7481.885,95.73007;Float;False;True;-1;2;ASEMaterialInspector;0;0;CustomLighting;E3D/SHeroEffect/Actor-Effect-TransL1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;TransparentCutout;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;241;0;240;0
WireConnection;251;0;248;2
WireConnection;251;1;253;0
WireConnection;242;1;241;0
WireConnection;167;0;172;0
WireConnection;249;0;248;1
WireConnection;249;1;251;0
WireConnection;171;1;167;0
WireConnection;250;0;249;0
WireConnection;250;1;242;0
WireConnection;163;1;171;0
WireConnection;234;0;250;0
WireConnection;234;1;235;0
WireConnection;257;0;258;0
WireConnection;237;0;234;0
WireConnection;237;1;236;0
WireConnection;162;0;163;0
WireConnection;162;1;164;0
WireConnection;174;0;173;2
WireConnection;174;1;257;0
WireConnection;168;0;162;0
WireConnection;168;1;169;0
WireConnection;222;0;174;0
WireConnection;222;1;223;0
WireConnection;247;0;237;0
WireConnection;238;0;168;0
WireConnection;238;1;247;0
WireConnection;177;0;222;0
WireConnection;177;1;178;0
WireConnection;246;0;238;0
WireConnection;190;0;177;0
WireConnection;264;0;190;0
WireConnection;186;0;246;0
WireConnection;198;0;187;0
WireConnection;198;1;266;0
WireConnection;225;0;174;0
WireConnection;188;0;177;0
WireConnection;188;1;189;0
WireConnection;199;0;198;0
WireConnection;226;0;225;0
WireConnection;185;0;188;0
WireConnection;179;1;180;0
WireConnection;179;2;185;0
WireConnection;227;0;199;0
WireConnection;227;1;226;0
WireConnection;210;0;222;0
WireConnection;245;0;227;0
WireConnection;184;0;222;0
WireConnection;181;0;179;0
WireConnection;181;1;182;0
WireConnection;181;2;265;0
WireConnection;217;0;211;0
WireConnection;206;0;208;0
WireConnection;191;0;181;0
WireConnection;191;1;192;0
WireConnection;191;2;184;0
WireConnection;201;0;245;0
WireConnection;216;0;217;0
WireConnection;216;1;206;0
WireConnection;243;0;168;0
WireConnection;243;1;237;0
WireConnection;220;0;218;0
WireConnection;220;1;191;0
WireConnection;61;2;220;0
WireConnection;61;10;202;0
WireConnection;61;11;216;0
ASEEND*/
//CHKSM=A02888B625BA4E16488D072A421C2E9C08D9FBC9