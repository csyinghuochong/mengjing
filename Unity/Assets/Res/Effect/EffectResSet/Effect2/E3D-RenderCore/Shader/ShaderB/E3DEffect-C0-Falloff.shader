Shader "E3DEffect/C0/Falloff" {
Properties {
    _RimColor ("Rim Color", Color) = (0.5,0.5,0.5,0.5)
    _InnerColor ("Inner Color", Color) = (0.5,0.5,0.5,0.5)
    _InnerColorPower ("Inner Color Power", Range(0.0,1.0)) = 0.5
    _RimPower ("Rim Power", Range(0.0,5.0)) = 2.5
    _AlphaPower ("Alpha Rim Power", Range(0.0,8.0)) = 4.0
    _AllPower ("All Power", Range(0.0, 10.0)) = 1.0
}
SubShader {
    Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
    Pass {
        Tags { "LightMode" = "UniversalForward" }

        HLSLPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"

        struct Attributes {
            float4 positionOS : POSITION;
            float3 normalOS : NORMAL;
        };

        struct Varyings {
            float4 positionHCS : SV_POSITION;
            float3 viewDirWS : TEXCOORD0;
            float3 normalWS : TEXCOORD1;
        };

        CBUFFER_START(UnityPerMaterial)
            float4 _RimColor;
            float _RimPower;
            float _AlphaPower;
            float _InnerColorPower;
            float _AllPower;
            float4 _InnerColor;
        CBUFFER_END

        Varyings vert(Attributes IN) {
            Varyings OUT;
            OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
            float3 worldPos = TransformObjectToWorld(IN.positionOS);
            OUT.viewDirWS = GetWorldSpaceViewDir(worldPos);
            OUT.normalWS = TransformObjectToWorldNormal(IN.normalOS);
            return OUT;
        }

        half4 frag(Varyings IN) : SV_TARGET {
            half rim = 1.0 - saturate(dot(normalize(IN.viewDirWS), IN.normalWS));
            half3 emission = _RimColor.rgb * pow(rim, _RimPower) * _AllPower + (_InnerColor.rgb * 2 * _InnerColorPower);
            half alpha = (pow(rim, _AlphaPower)) * _AllPower;

            half4 color = half4(emission, alpha);
            return color;
        }
        ENDHLSL
    }
}
Fallback "Hidden/Universal Render Pipeline/FallbackError"
}