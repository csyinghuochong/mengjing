Shader "Grass/AdditionalLight"
{
    Properties
    {
        _BaseColorTexture("Texture", 2D) = "white" { }
        [MainColor]
        _BaseColor("Main Color", Color) = (1.0, 1.0, 1.0)
        _GroundColor("Ground Color", Color) = (0.5, 0.5, 0.5)
        _GrassWidth("Width", Float) = 1.0
        _GrassHeight("Height", Float) = 1.0

        [Header(Lighting)]
        [Space()]
        _Normal("Normal", Float) = 0.1
        _LightIntensity("Light Intensity", Float) = 1.0

        [Header(Wind)]
        [Space()]
        _WindIntensity("Intensity", Float) = 1.25
        _WindFrequency("Frequency", Float) = 4
        _WindTilingX("Tiling X", Float) = 0.15
        _WindTilingY("Tiling Y", Float) = 0.15
        _WindWrapX("Wrap X", Float) = 0.4
        _WindWrapY("Wrap Y", Float) = 0.4
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline"}
        Pass
        {
            Cull Back
            ZTest Less

            Tags
            {
                "LightMode" = "UniversalForward"
            }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma target 3.0

            #pragma multi_compile _ _ADDITIONAL_LIGHTS
            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                half3 color : COLOR;
            };

            CBUFFER_START(UnityPerMaterial)

            float _GrassWidth;
            float _GrassHeight;

            float _WindIntensity;
            float _WindFrequency;
            float _WindTilingX;
            float _WindTilingY;
            float _WindWrapX;
            float _WindWrapY;

            half3 _BaseColor;
            float4 _BaseColorTexture_ST;
            half3 _GroundColor;

            half _Normal;
            float _LightIntensity;

            StructuredBuffer<float3> _InstancesBuffer;
            StructuredBuffer<uint> _InstanceIDBuffer;

            CBUFFER_END

            sampler2D _BaseColorTexture;

            half3 ApplySingleDirectLight(Light light, half3 N, half3 V, half3 albedo, half positionOSY)
            {
                return (albedo * (dot(N, light.direction) * 0.5 + 0.5) + pow(saturate(dot(N, normalize(light.direction + V))), 4) * 0.1 * positionOSY) * light.color * light.shadowAttenuation * light.distanceAttenuation * _LightIntensity;
            }

            Varyings vert(Attributes IN, uint instanceID : SV_InstanceID)
            {
                Varyings OUT;
                float3 perGrassPivotPosWS = _InstancesBuffer[_InstanceIDBuffer[instanceID]];
                float3 cameraTransformRightWS = UNITY_MATRIX_V[0];
                float3 positionOS = IN.positionOS.x * cameraTransformRightWS * _GrassWidth * (sin(perGrassPivotPosWS.x * 95.5 + perGrassPivotPosWS.z) * 0.45 + 0.55) + IN.positionOS.y * UNITY_MATRIX_V[1];
                positionOS.y *= lerp(2, 5, (sin(perGrassPivotPosWS.x * 23.5 + perGrassPivotPosWS.z) * 0.45 + 0.55)) * _GrassHeight;
                float3 viewWS = _WorldSpaceCameraPos - perGrassPivotPosWS;
                float viewWSLength = length(viewWS);
                positionOS += cameraTransformRightWS * IN.positionOS.x * max(0, viewWSLength * 0.025);
                float3 positionWS = positionOS + perGrassPivotPosWS;
                float wind = (sin(_Time.y * _WindFrequency + perGrassPivotPosWS.x * _WindTilingX + perGrassPivotPosWS.z * _WindTilingY) * _WindWrapX + _WindWrapY) * _WindIntensity * IN.positionOS.y;
                positionWS += cameraTransformRightWS * wind;
                OUT.positionCS = TransformWorldToHClip(positionWS);
                half3 N = normalize(half3(0, 1, 0) + (_Normal * sin(perGrassPivotPosWS.x * 82.5 + perGrassPivotPosWS.z) + wind * -0.25) * cameraTransformRightWS - -UNITY_MATRIX_V[2] * 0.5);
                half3 V = viewWS / viewWSLength;
                half3 albedo = lerp(_GroundColor, tex2Dlod(_BaseColorTexture, float4(TRANSFORM_TEX(positionWS.xz, _BaseColorTexture), 0, 0)) * _BaseColor, IN.positionOS.y);
                half3 lightingResult = SampleSH(0) * albedo + ApplySingleDirectLight(GetMainLight(), N, V, albedo, positionOS.y);
                int additionalLightsCount = GetAdditionalLightsCount();
                for (int i = 0; i < additionalLightsCount; ++i)
                {
                    lightingResult += ApplySingleDirectLight(GetAdditionalLight(i, positionWS), N, V, albedo, positionOS.y);
                }
                OUT.color = MixFog(lightingResult, ComputeFogFactor(OUT.positionCS.z));
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                return half4(IN.color, 1);
            }
            ENDHLSL
        }
    }
}