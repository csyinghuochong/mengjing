// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
Shader "Toon/BasicNormal"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BaseColor ("Color", Color) = (0.5, 0.5, 0.5, 1)
        [Space]
        _OutlineWidth ("Outline Width", Range(0.0, 1.0)) = 0.15
        _OutlineColor ("Outline Color", Color) = (0.0, 0.0, 0.0, 1)
        
        _NormalTex ("Normal Map", 2D) = "bump" {}
        _BumpScale ("Bump Scale", Float) = 1.0
        _Specular ("Specular", Color) = (1, 1, 1, 1)
        _Gloss ("Gloss", Range(8.0, 256)) = 20
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline"
        }
 
        Pass
        {
            Name "MainPass"
            Tags
            {
                "LightMode" = "UniversalForward"
            }
            HLSLPROGRAM
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
 
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
 
            TEXTURE2D(_MainTex); 
            TEXTURE2D(_NormalTex);
            SAMPLER(sampler_MainTex);
            SAMPLER(sampler_NormalTex);
 
            CBUFFER_START(UnityPerMaterial)
                float4 _BaseColor;
                float _BumpScale;
            CBUFFER_END


            CBUFFER_START(UnityPerFrame)
                float3 _WorldSpaceLightPos0; // Direction to the main light
            CBUFFER_END
            
            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
 
            struct Varyings
            {
                float2 uv : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float4 positionCS : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
 
            Varyings vert(Attributes input)
            {
                Varyings output;
                UNITY_SETUP_INSTANCE_ID(input);
                UNITY_TRANSFER_INSTANCE_ID(input, output);
 
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = vertexInput.positionCS;
                output.uv = input.uv;
 
                // Transform normal to world space
                float3 normalWS = TransformObjectToWorldNormal(input.normalOS);
                // Optionally calculate tangent-space binormal and tangent, but for simplicity we only need normal here
                output.normalWS = normalWS;
 
                return output;
            }

            //float4 frag_old(Varyings input) : SV_Target
            //{
            //    float4 mainTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
            //    return mainTex * _BaseColor;
            //}
 
            float4 frag(Varyings input) : SV_Target
            {
                float4 mainTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                //return mainTex * _BaseColor;
                
                float3 normalMap = UnpackNormal(SAMPLE_TEXTURE2D(_NormalTex, sampler_NormalTex, input.uv));
                normalMap = normalMap * 2.0 - 1.0; // Convert to [-1,1] range if not already
                normalMap = normalize(normalMap * _BumpScale); // Scale and normalize the normal
 
                // Here you would typically use the normalMap to calculate lighting,
                // but for simplicity let's just return a shaded color using the base color and a fixed light direction.
                float3 normal = normalize(input.normalWS + normalMap); // Combine world-space normal with normal map
                //init  固定灯光方向
                // float3 lightDir = normalize(float3(1, 1, -1)); // Example light direction
                //float diff =  max(0, dot(normal, lightDir)); // Diffuse lighting

                //
                //float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //float diff =  max(0, dot(normal, lightDir))  + 0.5; // Diffuse lighting
                
                float diff = 1;
                float4 color = mainTex * _BaseColor * diff;
                return color;
            }
            ENDHLSL
        }

        // Outline
        Pass
        {
            Name "Outline"
            Cull Front
            Tags
            {
                "LightMode" = "SRPDefaultUnlit"
            }
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            float _OutlineWidth;
            float4 _OutlineColor;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = TransformObjectToHClip(float4(v.vertex.xyz + v.normal * _OutlineWidth * 0.1, 1));
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return _OutlineColor;
            }
            ENDHLSL

        }


        pass {
			Tags{ "LightMode" = "ShadowCaster" }
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
 
			struct appdata
			{
				float4 vertex : POSITION;
			};
 
			struct v2f
			{
				float4 pos : SV_POSITION;
			};
 
			sampler2D _MainTex;
			float4 _MainTex_ST;
 
			v2f vert(appdata v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP,v.vertex);
				return o;
			}
			float4 frag(v2f i) : SV_Target
			{
				float4 color;
				color.xyz = float3(0.0, 0.0, 0.0);
				return color;
			}
			ENDHLSL
		}

    }
}
