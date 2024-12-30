Shader "E3DEffect/C2/Add-HardEdge" {
    Properties {
        _BaseRGBA ("Base-RGBA", 2D) = "white" {}
        [MaterialToggle] _Base2uv ("Base-2uv", Float ) = 0
        _ShapeRGB ("Shape-RGB", 2D) = "white" {}
        [MaterialToggle] _Shape2uv ("Shape-2uv", Float ) = 0
        _EdgeClip ("EdgeClip", Range(0, 10)) = 6.74703
        _BaseAlphaAdd ("BaseAlpha-Add", Range(0, 1)) = 0.5
        _BaseColor ("BaseColor", Color) = (0.5,0.5,0.5,1)
        _AddColor ("Add-Color", Color) = (0.5,0.5,0.5,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Overlay"
            "RenderType"="TransparentCutout"
            "RenderPipeline"="UniversalPipeline"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="UniversalForward"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderVariablesFunctions.hlsl"
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _ADDITIONAL_LIGHTS

            TEXTURE2D(_BaseRGBA);
            SAMPLER(sampler_BaseRGBA);
            float4 _BaseRGBA_ST;
            float _EdgeClip;
            TEXTURE2D(_ShapeRGB);
            SAMPLER(sampler_ShapeRGB);
            float4 _ShapeRGB_ST;
            float4 _BaseColor;
            half _Base2uv;
            float _BaseAlphaAdd;
            float4 _AddColor;
            half _Shape2uv;

            struct Attributes {
                float4 positionOS : POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };

            struct Varyings {
                float4 positionHCS : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };

            Varyings vert(Attributes input) {
                Varyings output = (Varyings)0;
                output.positionHCS = TransformObjectToHClip(input.positionOS);
                output.uv0 = TRANSFORM_TEX(input.uv0, _BaseRGBA);
                output.uv1 = TRANSFORM_TEX(input.uv1, _ShapeRGB);
                output.vertexColor = input.vertexColor;
                return output;
            }

            half4 frag(Varyings input, float facing : VFACE) : SV_Target {
                float isFrontFace = (facing >= 0 ? 1 : 0);
                float faceSign = (facing >= 0 ? 1 : -1);
                float2 _Base2uv_var = lerp(input.uv0, input.uv1, _Base2uv);
                float4 _BaseRGBA_var = SAMPLE_TEXTURE2D(_BaseRGBA, sampler_BaseRGBA, _Base2uv_var);
                float2 _Shape2uv_var = lerp(input.uv0, input.uv1, _Shape2uv);
                float4 _ShapeRGB_var = SAMPLE_TEXTURE2D(_ShapeRGB, sampler_ShapeRGB, _Shape2uv_var);
                clip(((((_BaseRGBA_var.a + _BaseAlphaAdd) * _ShapeRGB_var.rgb) * _EdgeClip) * input.vertexColor.a) - 0.5);

                // Emissive:
                float3 emissive = ((_BaseRGBA_var.rgb * _BaseColor.rgb * _ShapeRGB_var.rgb * input.vertexColor.rgb) + _AddColor.rgb);
                float3 finalColor = emissive;
                return half4(finalColor, 1);
            }
            ENDHLSL
        }
        
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderVariablesFunctions.hlsl"
            #pragma multi_compile_shadowcaster

            TEXTURE2D(_BaseRGBA);
            SAMPLER(sampler_BaseRGBA);
            float4 _BaseRGBA_ST;
            float _EdgeClip;
            TEXTURE2D(_ShapeRGB);
            SAMPLER(sampler_ShapeRGB);
            float4 _ShapeRGB_ST;
            half _Base2uv;
            float _BaseAlphaAdd;
            half _Shape2uv;

            struct Attributes {
                float4 positionOS : POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };

            struct Varyings {
                float4 positionHCS : SV_POSITION;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };

            Varyings vert(Attributes input) {
                Varyings output = (Varyings)0;
                output.positionHCS = TransformObjectToHClip(input.positionOS);
                output.uv0 = TRANSFORM_TEX(input.uv0, _BaseRGBA);
                output.uv1 = TRANSFORM_TEX(input.uv1, _ShapeRGB);
                output.vertexColor = input.vertexColor;
                return output;
            }

            half4 frag(Varyings input, float facing : VFACE) : SV_Target {
                float isFrontFace = (facing >= 0 ? 1 : 0);
                float faceSign = (facing >= 0 ? 1 : -1);
                float2 _Base2uv_var = lerp(input.uv0, input.uv1, _Base2uv);
                float4 _BaseRGBA_var = SAMPLE_TEXTURE2D(_BaseRGBA, sampler_BaseRGBA, _Base2uv_var);
                float2 _Shape2uv_var = lerp(input.uv0, input.uv1, _Shape2uv);
                float4 _ShapeRGB_var = SAMPLE_TEXTURE2D(_ShapeRGB, sampler_ShapeRGB, _Shape2uv_var);
                clip(((((_BaseRGBA_var.a + _BaseAlphaAdd) * _ShapeRGB_var.rgb) * _EdgeClip) * input.vertexColor.a) - 0.5);
                return 0;
            }
            ENDHLSL
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}