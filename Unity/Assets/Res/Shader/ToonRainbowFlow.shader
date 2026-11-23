Shader "Toon/RainbowFlow"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BaseColor ("Color", Color) = (0.5, 0.5, 0.5, 1)
        [Space]
        _OutlineWidth ("Outline Width", Range(0.0, 1.0)) = 0.15
        _OutlineColor ("Outline Color", Color) = (0.0, 0.0, 0.0, 1)
        [Header(Rainbow Flow)]
        _RainbowSpeed ("Speed (Cycles per Second)", Range(-2.0, 2.0)) = 0.35
        _RainbowDensity ("Band Density", Range(0.1, 12.0)) = 4.0
        _RainbowIntensity ("Intensity", Range(0.0, 2.0)) = 1.1
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

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseColor;
                float _RainbowSpeed;
                float _RainbowDensity;
                float _RainbowIntensity;
            CBUFFER_END

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float2 uv : TEXCOORD0;
                float3 positionOS : TEXCOORD1;
                half3 normalWS : TEXCOORD2;
                float3 viewDirWS : TEXCOORD3;
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
                output.positionOS = input.positionOS.xyz;
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.viewDirWS = GetWorldSpaceViewDir(vertexInput.positionWS);
                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv) * _BaseColor;
                // Object-space bands stay continuous across texture seams.
                float flow = dot(input.positionOS, float3(0.55, 1.0, 0.3));
                flow += 0.035 * sin(dot(input.positionOS, float3(15.0, 3.0, 10.0)));
                float phase = flow * _RainbowDensity - _Time.y * _RainbowSpeed;
                half3 rainbow = saturate(abs(frac(phase + float3(0.0, 2.0 / 3.0, 1.0 / 3.0)) * 6.0 - 3.0) - 1.0);

                half band = smoothstep(0.2, 0.9, 0.5 + 0.5 * cos((phase * 2.0 + 0.18) * TWO_PI));
                half rim = 1.0 - saturate(dot(SafeNormalize(input.normalWS), SafeNormalize(input.viewDirWS)));
                half tintWeight = saturate(_RainbowIntensity * (0.25 + 0.55 * band));
                color.rgb = lerp(color.rgb, color.rgb * (0.45 + 0.8 * rainbow), tintWeight);
                color.rgb += rainbow * _RainbowIntensity * (0.06 + 0.24 * band + 0.3 * rim * rim);
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
                o.pos = TransformObjectToHClip(v.vertex.xyz + v.normal * _OutlineWidth * 0.1);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return _OutlineColor;
            }
            ENDHLSL

        }


        Pass
        {
            Tags { "LightMode" = "ShadowCaster" }
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float4 vert(float4 positionOS : POSITION) : SV_POSITION
            {
                return TransformObjectToHClip(positionOS.xyz);
            }

            float4 frag() : SV_Target
            {
                return 0.0;
            }
            ENDHLSL
        }

    }
}
