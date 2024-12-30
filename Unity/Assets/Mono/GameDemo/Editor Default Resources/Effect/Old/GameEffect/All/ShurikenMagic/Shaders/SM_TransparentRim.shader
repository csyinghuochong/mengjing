Shader "ShurikenMagic/TransparentRimURP" {
    Properties {
        _RimColor ("Rim Color", Color) = (0.5,0.5,0.5,0.5)
        _InnerColor ("Inner Color", Color) = (0.5,0.5,0.5,0.5)
        _InnerColorPower ("Inner Color Power", Range(0.0,1.0)) = 0.5
        _RimPower ("Rim Power", Range(0.0,5.0)) = 2.5
        _AlphaPower ("Alpha Rim Power", Range(0.0,8.0)) = 4.0
        _AllPower ("All Power", Range(0.0, 10.0)) = 1.0
    }

    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }

        Pass {
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            
            struct Attributes {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
            };

            struct Varyings {
                float4 positionHCS : SV_POSITION;
                float3 viewDirWS : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
            };

            float4 _RimColor;
            float _RimPower;
            float _AlphaPower;
            float _InnerColorPower;
            float _AllPower;
            float4 _InnerColor;

            Varyings vert(Attributes input) {
                Varyings output;

                // Transform object space position to homogenous clip space
                output.positionHCS = TransformObjectToHClip(input.positionOS);
                // Calculate view direction in world space
                float3 worldPos = TransformObjectToWorld(input.positionOS);
                output.viewDirWS = normalize(GetWorldSpaceViewDir(worldPos));
                // Transform object space normal to world space
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                return output;
            }

            half4 frag(Varyings input) : SV_Target {
                half rim = 1.0 - saturate(dot(normalize(input.viewDirWS), input.normalWS));
                half3 emission = _RimColor.rgb * pow(rim, _RimPower) * _AllPower + (_InnerColor.rgb * 2 * _InnerColorPower);
                half alpha = pow(rim, _AlphaPower) * _AllPower;
                return half4(emission, alpha);
            }

            ENDHLSL
        }
    }
    Fallback "Hidden/InternalErrorShader"
}