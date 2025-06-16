Shader "Polyart/Dreamscape Waterfall Foam Volumetric"
{
    Properties
    {
        [HideInInspector] _AlphaCutoff("Alpha Cutoff", Range(0, 1)) = 0.5
        [HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
        [ASEBegin]_ScaleWidth("Scale Width", Float) = 1
        _Acceleration("Acceleration", Float) = 0
        _VerticalSpeed("Vertical Speed", Float) = 1
        _ScaleX("Scale X", Float) = 1
        _ScaleY("Scale Y", Float) = 1
        _TextureSample0("Foam Texture", 2D) = "white" {}
        _Threshold("Threshold", Float) = 0.1
        _Height("Height", Float) = 100
        _Color0("Foam Color", Color) = (0,0.9495223,1,0)
        [ASEEnd]_Color1("Water Color", Color) = (1,1,1,0)
    }

    SubShader
    {
        Tags 
        { 
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Opaque"
            "Queue"="Geometry"
        }

        Pass
        {
            Name "Forward"
            Tags { "LightMode"="UniversalForwardOnly" }
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #define ASE_SRP_VERSION 120108
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct VertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct VertexOutput
            {
                float4 clipPos : SV_POSITION;
                float2 uv : TEXCOORD0;
                #if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
                    float3 worldPos : TEXCOORD1;
                #endif
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            CBUFFER_START(UnityPerMaterial)
            float4 _Color0;
            float4 _Color1;
            float _ScaleX;
            float _ScaleWidth;
            float _Acceleration;
            float _VerticalSpeed;
            float _ScaleY;
            float _Threshold;
            float _Height;
            CBUFFER_END

            sampler2D _TextureSample0;

            VertexOutput vert (VertexInput v)
            {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                
                // 优化后的UV计算（标量运算）
                float timeOffset = _TimeParameters.x * _VerticalSpeed;
                float u = _ScaleWidth * v.uv.x;
                float vCoord = v.uv.y * _Acceleration;
                
                // 计算纹理UV
                float2 foamUV = float2(
                    _ScaleX * u,
                    (vCoord - timeOffset) * _ScaleY
                );
                
                // 采样泡沫纹理（仅使用红色通道）
                float foamValue = tex2Dlod(_TextureSample0, float4(foamUV, 0, 0)).r;
                
                // 计算高度偏移
                float foamHeight = v.uv.y * foamValue - _Threshold;
                foamHeight = saturate(foamHeight) * _Height - (_Height / 4.0);
                
                // 应用顶点偏移
                v.vertex.y += foamHeight;
                
                o.clipPos = TransformObjectToHClip(v.vertex.xyz);
                o.uv = v.uv;
                return o;
            }

            half4 frag (VertexOutput IN) : SV_Target
            {
                // 复用顶点着色器中的UV计算逻辑
                float timeOffset = _TimeParameters.x * _VerticalSpeed;
                float u = _ScaleWidth * IN.uv.x;
                float vCoord = IN.uv.y * _Acceleration;
                
                // 计算纹理UV
                float2 foamUV = float2(
                    _ScaleX * u,
                    (vCoord - timeOffset) * _ScaleY
                );
                
                // 采样泡沫纹理
                float4 foamTex = tex2D(_TextureSample0, foamUV);
                
                // 计算泡沫强度
                float foamStrength = IN.uv.y * foamTex.r - _Threshold;
                
                // 混合颜色
                half4 color = lerp(_Color0, _Color1, saturate(foamStrength));
                
                // Alpha通道使用泡沫强度
                color.a = saturate(foamStrength);
                return color;
            }
            ENDHLSL
        }
    }
    CustomEditor "UnityEditor.ShaderGraphUnlitGUI"
    FallBack "Hidden/Shader Graph/FallbackError"
}