Shader "Polyart/Dreamscape Surface Coverage Optimized"
{
    Properties
    {
        // 隐藏属性集中管理

        // MAIN 组
        [Header(MAIN)]_AlbedoTint("Albedo Tint", Color) = (1,1,1,0)
        _AlbedoTexture("Albedo Texture", 2D) = "white" {}
        _NormalTexture("Normal Texture", 2D) = "bump" {}
        _SmoothnessMultiplier("Smoothness Multiplier", Range(-2, 2)) = 1
        _SmoothnessTexture("Smoothness Texture", 2D) = "white" {}
        _MetallicMultiplier("Metallic Multiplier", Range(0, 2)) = 0
        _MetallicTexture("Metallic Texture", 2D) = "black" {}
        
        // GROUND COVERAGE 组
        [Header(GROUND COVERAGE)][Toggle(_GROUNDCOVERON)] _GroundCoverON("Ground Cover ON", Float) = 0
        [Toggle(_BLENDNORMALS)] _BlendNormalsON("Blend Normals ON", Float) = 1
        _CoverageMask("Coverage Mask", 2D) = "white" {}
        _CoverageContrast("Coverage Contrast", Range(0.1, 1)) = 0.25
        _CoverageLevel("Coverage Level", Float) = 0
        _CoverageFade("Coverage Fade", Range(-1, 1)) = 0.5058824
        _CoverageTint("Coverage Tint", Color) = (1,1,1,0)
        _CoverageTexture("Coverage Texture", 2D) = "white" {}
        _CoverageMetallic("Coverage Metallic", Float) = 0
        _CoverageSmoothnessMultiplier("Coverage Smoothness Multiplier", Range(-2, 2)) = 1
        _CoverageNormalTexture("Coverage Normal Texture", 2D) = "bump" {}
        _CoverageThickness("Coverage Thickness", Range(0, 1)) = 1
        
        // 新增亮度控制参数
        [Header(BRIGHTNESS)]_Brightness("Brightness", Range(0, 3)) = 1
        _Contrast("Contrast", Range(0, 3)) = 1
    }

    SubShader
    {
        LOD 100 // 基础LOD
        //LODFadeCrossFade // 平滑过渡
        
        Tags { 
            "RenderPipeline"="UniversalPipeline" 
            "RenderType"="Opaque" 
            "Queue"="Geometry" 
            "UniversalMaterialType"="Lit" 
        }

        Cull Back
        ZWrite On
        ZTest LEqual
        Offset 0, 0
        AlphaToMask Off // 不透明材质无需透明测试

        HLSLINCLUDE
        #pragma target 3.5
        #pragma prefer_hlslcc gles
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"
        ENDHLSL

        Pass
        {
            Name "Forward"
            Tags { "LightMode"="UniversalForward" }

            // 移除无效混合（Opaque材质无需混合）
            ZWrite On
            ZTest LEqual
            Offset 0, 0
            ColorMask RGBA

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ _GROUNDCOVERON
            #pragma multi_compile _ _BLENDNORMALS

            // 精简CBUFFER，使用单分量变量
            CBUFFER_START(UnityPerMaterial)
            float4 _AlbedoTint;
            float4 _CoverageTint; // 添加这一行
            float4 _AlbedoTexture_ST;
            float4 _CoverageTexture_ST;
            float4 _CoverageMask_ST;
            float _CoverageContrast;
            float _CoverageFade;
            float _CoverageLevel;
            float _CoverageThickness;
            float _EmissiveMultiplier;
            float _MetallicMultiplier;
            float _CoverageMetallic;
            float _SmoothnessMultiplier;
            float _CoverageSmoothnessMultiplier;
              float _Brightness; // 新增亮度控制
            float _Contrast;   // 新增对比度控制
            CBUFFER_END

            // 纹理采样器
            sampler2D _AlbedoTexture;
            sampler2D _CoverageTexture;
            sampler2D _CoverageMask;
            sampler2D _NormalTexture;
            sampler2D _CoverageNormalTexture;
            sampler2D _MetallicTexture;
            sampler2D  _SmoothnessTexture;


            struct VertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct VertexOutput
            {
                float4 clipPos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
                float3 worldTangent : TEXCOORD2;
                float2 uv : TEXCOORD3;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            VertexOutput vert(VertexInput v)
            {
                VertexOutput o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.clipPos = TransformWorldToHClip(TransformObjectToWorld(v.vertex.xyz));
                o.worldPos = TransformObjectToWorld(v.vertex.xyz);
                o.worldNormal = normalize(TransformObjectToWorldNormal(v.normal));
                o.worldTangent = TransformObjectToWorldDir(v.tangent.xyz);
                o.uv = v.uv * _AlbedoTexture_ST.xy + _AlbedoTexture_ST.zw; // 复用UV计算

                return o;
            }

            half4 frag(VertexOutput IN) : SV_Target
            {
                // 统一UV坐标（覆盖纹理与主纹理共用UV变换）
                float2 uv = IN.uv;
                float2 maskUV = uv * _CoverageMask_ST.xy + _CoverageMask_ST.zw;

                // 优化覆盖强度计算
                float height = IN.worldNormal.y + _CoverageLevel;
                float mask = tex2D(_CoverageMask, maskUV).r;
                float coverage = saturate(lerp(height * _CoverageFade * 5, mask, 0.5)); // 用lerp替代部分pow
                coverage = pow(coverage, _CoverageContrast * 8); // 降低指数复杂度

                // 主纹理与覆盖纹理混合
                float4 albedoMain = tex2D(_AlbedoTexture, uv) * _AlbedoTint;

                float2 coverUV = uv * _CoverageTexture_ST.xy + _CoverageTexture_ST.zw;
                float4 albedoCover = tex2D(_CoverageTexture, coverUV) * _CoverageTint;

                
                float4 albedo = lerp(albedoMain, albedoCover, coverage * _GROUNDCOVERON);

                // 法线混合（默认开启优化路径）
                float3 normalMain = UnpackNormal(tex2D(_NormalTexture, uv));
                float3 normalCover = UnpackNormal(tex2D(_CoverageNormalTexture, uv));
                float3 normal = _BLENDNORMALS ? BlendNormal(normalMain, normalCover) : normalCover;
                normal = TransformTangentToWorld(normal, float3x3(IN.worldTangent, cross(IN.worldNormal, IN.worldTangent), IN.worldNormal));

                // 金属度与光滑度（单分量优化）
                 // 金属度与光滑度（单分量优化）
                float metallic = lerp(
                    tex2D(_MetallicTexture, uv).r * _MetallicMultiplier,
                    _CoverageMetallic,
                    coverage * _GROUNDCOVERON
                );
                float smoothness = lerp(
                    (1 - tex2D(_SmoothnessTexture, uv).r) * _SmoothnessMultiplier,
                    (1 - tex2D(_SmoothnessTexture, uv).r) * _CoverageSmoothnessMultiplier,
                    coverage * _GROUNDCOVERON
                );

                // 亮度和对比度调整
                albedo.rgb = (albedo.rgb - 0.5) * _Contrast + 0.5;
               albedo.rgb *= _Brightness;

                
                // PBR光照计算
                SurfaceData surfaceData = (SurfaceData)0;
                surfaceData.albedo = albedo.rgb;
                surfaceData.normalTS = normal;
                surfaceData.metallic = 1;
                surfaceData.smoothness = smoothness;
                surfaceData.occlusion = 1;
                surfaceData.emission = 0; // 如需 emissive 需单独处理

                
                InputData inputData = (InputData)0;
                inputData.positionWS = IN.worldPos;
                inputData.viewDirectionWS = SafeNormalize(_WorldSpaceCameraPos - IN.worldPos);
                inputData.normalWS = surfaceData.normalTS;
                inputData.shadowCoord = TransformWorldToShadowCoord(IN.worldPos);

                half4 color = UniversalFragmentPBR(inputData, surfaceData);
                return color;
            }
            ENDHLSL
        }
    }

    CustomEditor "UnityEditor.ShaderGraphLitGUI"
    FallBack "Hidden/Shader Graph/FallbackError"
    Fallback Off
}