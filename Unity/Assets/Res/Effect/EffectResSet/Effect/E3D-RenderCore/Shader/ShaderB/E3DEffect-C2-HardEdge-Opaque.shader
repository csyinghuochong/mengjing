Shader "E3DEffect/C2/HardEdge-Opaque-URP" {
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
            "IgnoreProjector"="True"
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="UniversalForward"
            }
            Cull Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"

            TEXTURE2D(_BaseRGBA);
            SAMPLER(sampler_BaseRGBA);

            TEXTURE2D(_ShapeRGB);
            SAMPLER(sampler_ShapeRGB);

            float _Base2uv;
            float _EdgeClip;
            float _BaseAlphaAdd;
            float4 _BaseColor;
            float4 _AddColor;
            float _Shape2uv;

            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };

            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };

            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;
                o.pos = TransformObjectToHClip(v.vertex);
                return o;
            }

            half4 frag(VertexOutput i) : SV_Target {
                float2 _Base2uv_var = lerp(i.uv0, i.uv1, _Base2uv);
                float4 _BaseRGBA_var = SAMPLE_TEXTURE2D(_BaseRGBA, sampler_BaseRGBA, _Base2uv_var);
                float2 _Shape2uv_var = lerp(i.uv0, i.uv1, _Shape2uv);
                float4 _ShapeRGB_var = SAMPLE_TEXTURE2D(_ShapeRGB, sampler_ShapeRGB, _Shape2uv_var);
                clip(((((_BaseRGBA_var.a + _BaseAlphaAdd) * _ShapeRGB_var.rgb) * _EdgeClip) * i.vertexColor.a) - 0.5);
                float3 emissive = ((_BaseRGBA_var.rgb * _BaseColor.rgb * _ShapeRGB_var.rgb) + _AddColor.rgb);
                float3 finalColor = emissive;
                return half4(finalColor, 1.0);
            }
            ENDHLSL
        }  
    }
}