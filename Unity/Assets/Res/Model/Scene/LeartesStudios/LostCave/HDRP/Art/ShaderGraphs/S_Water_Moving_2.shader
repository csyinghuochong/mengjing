Shader "Shader Graphs/S_Water_Moving_2"
{
    Properties
    {
        // 水的基础颜色属性
        _WaterColor("Water Color", Color) = (0, 0.427451, 0.454902, 1)
        _WaterColorDeep("Water Color Deep", Color) = (0, 0.2901961, 0.3803922, 1)
        _FadeDistanceColor("Fade Distance Color", Float) = 1000
        
        // 水波纹线条效果属性
        _LineAcceleration("Line Acceleration", Float) = 0.5
        _LineScaleWidth("Line Scale Width", Float) = 1
        _LinesMainSpeed("Lines Main Speed", Float) = 1.3
        _LinesMainScaleY("Lines Main Scale Y", Float) = 1.3
        _LinesMainScaleX("Lines Main Scale X", Float) = 0.5
        _LinesSecondaryScaleX("Lines Secondary Scale X", Float) = 2
        _LinesSecondaryScaleY("Lines Secondary Scale Y", Float) = 1
        _TimeSecondarySpeed("Time Secondary Speed", Float) = 1.15
        [NoScaleOffset]_LinesMainTex("Lines Main Texture", 2D) = "white" {}
        _LineThreshold("Line Threshold", Float) = 0.642857
        _UVFade("UV Fade", Float) = 0
        _LineColor("Line Color", Color) = (0.572549, 0.9137256, 1, 1)
        
        // 水面法线贴图属性
        _TilingLarge("Tiling Large", Float) = 12
        _WaveLargeNormalStrength("Wave Large Normal Strength", Float) = 0.8
        _TilingSmall("Tiling Small", Float) = 20
        _WaveSmallNormalStrength("Wave Small Normal Strength", Float) = 0.8

        [NoScaleOffset]_BaseTexture("Base Texture", 2D) = "white" {}
        [Normal][NoScaleOffset]_LargeNormalMap("Large Normal Map", 2D) = "bump" {}
        [Normal][NoScaleOffset]_SmallNormalMap("Small Normal Map", 2D) = "bump" {}

        // 渲染管线隐藏属性
        [HideInInspector]_Surface("_Surface", Float) = 0
        [HideInInspector]_Blend("_Blend", Float) = 0
        [HideInInspector]_SrcBlend("_SrcBlend", Float) = 1
        [HideInInspector]_DstBlend("_DstBlend", Float) = 0
        [HideInInspector][ToggleUI]_ZWrite("_ZWrite", Float) = 1
        [HideInInspector]_ZTest("_ZTest", Float) = 4
        [HideInInspector]_Cull("_Cull", Float) = 2
        [HideInInspector]_AlphaToMask("_AlphaToMask", Float) = 0
    }
    
    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "RenderType" = "Opaque"
            "UniversalMaterialType" = "Lit"
            "Queue" = "Geometry"
            "DisableBatching" = "False"
            "ShaderGraphShader" = "true"
            "ShaderGraphTargetId" = "UniversalLitSubTarget"
        }
        
        Pass
        {
            Name "Universal Forward"
            Tags { "LightMode" = "UniversalForward" }
            
            Cull [_Cull]
            Blend [_SrcBlend] [_DstBlend]
            ZTest [_ZTest]
            ZWrite [_ZWrite]
            AlphaToMask [_AlphaToMask]
            
            HLSLPROGRAM
            // 编译指令优化 - 整理顺序并添加注释
            #pragma target 2.0                          // 着色器目标版本
            #pragma multi_compile_instancing            // 支持实例化渲染
            #pragma multi_compile_fog                   // 支持雾效
            #pragma instancing_options renderinglayer  // 实例化渲染层选项
            #pragma vertex vert                        // 顶点着色器入口
            #pragma fragment frag                      // 片段着色器入口
            
            // 光照和阴影相关编译指令
            #pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DYNAMICLIGHTMAP_ON
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile_fragment _ _REFLECTION_PROBE_BLENDING
            #pragma multi_compile_fragment _ _REFLECTION_PROBE_BOX_PROJECTION
            #pragma multi_compile_fragment _ _SHADOWS_SOFT _SHADOWS_SOFT_LOW _SHADOWS_SOFT_MEDIUM _SHADOWS_SOFT_HIGH
            #pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
            #pragma multi_compile _ SHADOWS_SHADOWMASK
            #pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
            #pragma multi_compile_fragment _ _LIGHT_LAYERS
            #pragma multi_compile_fragment _ DEBUG_DISPLAY
            #pragma multi_compile_fragment _ _LIGHT_COOKIES
            #pragma multi_compile _ _FORWARD_PLUS
            #pragma multi_compile _ EVALUATE_SH_MIXED EVALUATE_SH_VERTEX
            
            // 表面类型和混合模式编译指令
            #pragma shader_feature_fragment _ _SURFACE_TYPE_TRANSPARENT
            #pragma shader_feature_local_fragment _ _ALPHAPREMULTIPLY_ON
            #pragma shader_feature_local_fragment _ _ALPHAMODULATE_ON
            #pragma shader_feature_local_fragment _ _ALPHATEST_ON
            #pragma shader_feature_local_fragment _ _SPECULAR_SETUP
            #pragma shader_feature_local _ _RECEIVE_SHADOWS_OFF
            
            // 定义法线贴图支持
            #define _NORMALMAP 1
            #define _NORMAL_DROPOFF_TS 1
            #define ATTRIBUTES_NEED_NORMAL
            #define ATTRIBUTES_NEED_TANGENT
            #define ATTRIBUTES_NEED_TEXCOORD0
            #define ATTRIBUTES_NEED_TEXCOORD1
            #define ATTRIBUTES_NEED_TEXCOORD2
            #define VARYINGS_NEED_POSITION_WS
            #define VARYINGS_NEED_NORMAL_WS
            #define VARYINGS_NEED_TANGENT_WS
            #define VARYINGS_NEED_TEXCOORD0
            #define VARYINGS_NEED_FOG_AND_VERTEX_LIGHT
            #define VARYINGS_NEED_SHADOW_COORD
            #define FEATURES_GRAPH_VERTEX
            #define SHADERPASS SHADERPASS_FORWARD
            #define _FOG_FRAGMENT 1
            #define REQUIRE_DEPTH_TEXTURE
            
            // 包含必要的HLSL库文件 - 按功能分组
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"         // 颜色相关函数
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"       // 纹理相关函数
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"     // 核心功能
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"  // 光照计算
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"     // 输入处理
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"  // 纹理栈操作
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl" // ShaderGraph函数
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl" // ShaderPass包含
            
            // 输入输出结构定义 - 优化命名
            struct Attributes
            {
                float3 positionOS : POSITION;       // 物体空间位置
                float3 normalOS : NORMAL;          // 物体空间法线
                float4 tangentOS : TANGENT;        // 物体空间切线
                float4 uv0 : TEXCOORD0;            // 纹理坐标0
                float4 uv1 : TEXCOORD1;            // 纹理坐标1
                float4 uv2 : TEXCOORD2;            // 纹理坐标2
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : INSTANCEID_SEMANTIC; // 实例ID
                #endif
            };
            
            struct Varyings
            {
                float4 positionCS : SV_POSITION;    // 裁剪空间位置
                float3 positionWS;                  // 世界空间位置
                float3 normalWS;                    // 世界空间法线
                float4 tangentWS;                   // 世界空间切线
                float4 texCoord0;                   // 插值后纹理坐标0
                #if defined(LIGHTMAP_ON)
                float2 staticLightmapUV;            // 静态光照图UV
                #endif
                #if defined(DYNAMICLIGHTMAP_ON)
                float2 dynamicLightmapUV;           // 动态光照图UV
                #endif
                #if !defined(LIGHTMAP_ON)
                float3 sh;                          // 球面调和光照
                #endif
                float4 fogFactorAndVertexLight;     // 雾因子和顶点光照
                #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
                float4 shadowCoord;                 // 阴影坐标
                #endif
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // 自定义实例ID
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0; // 立体渲染相关
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex; // 立体渲染目标索引
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC; // 面剔除类型
                #endif
            };
            
            struct SurfaceDescriptionInputs
            {
                float3 TangentSpaceNormal;          // 切线空间法线
                float3 WorldSpacePosition;          // 世界空间位置
                float4 ScreenPosition;              // 屏幕位置
                float2 NDCPosition;                 // 标准化设备坐标位置
                float2 PixelPosition;               // 像素位置
                float4 uv0;                         // 纹理坐标0
                float3 TimeParameters;              // 时间参数
            };
            
            struct VertexDescriptionInputs
            {
                float3 ObjectSpaceNormal;           // 物体空间法线
                float3 ObjectSpaceTangent;          // 物体空间切线
                float3 ObjectSpacePosition;         // 物体空间位置
            };
            
            struct PackedVaryings
            {
                float4 positionCS : SV_POSITION;    // 裁剪空间位置
                #if defined(LIGHTMAP_ON)
                float2 staticLightmapUV : INTERP0;  // 静态光照图UV插值
                #endif
                #if defined(DYNAMICLIGHTMAP_ON)
                float2 dynamicLightmapUV : INTERP1; // 动态光照图UV插值
                #endif
                #if !defined(LIGHTMAP_ON)
                float3 sh : INTERP2;                // 球面调和光照插值
                #endif
                #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
                float4 shadowCoord : INTERP3;       // 阴影坐标插值
                #endif
                float4 tangentWS : INTERP4;         // 世界空间切线插值
                float4 texCoord0 : INTERP5;         // 纹理坐标0插值
                float4 fogFactorAndVertexLight : INTERP6; // 雾因子和顶点光照插值
                float3 positionWS : INTERP7;        // 世界空间位置插值
                float3 normalWS : INTERP8;          // 世界空间法线插值
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID; // 自定义实例ID
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0; // 立体渲染混合索引
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex; // 立体渲染目标数组索引
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC; // 面剔除类型
                #endif
            };
            
            // 优化：合并打包和解包函数的注释
            PackedVaryings PackVaryings(Varyings input)
            {
                PackedVaryings output;
                ZERO_INITIALIZE(PackedVaryings, output);
                output.positionCS = input.positionCS;
                #if defined(LIGHTMAP_ON)
                output.staticLightmapUV = input.staticLightmapUV;
                #endif
                #if defined(DYNAMICLIGHTMAP_ON)
                output.dynamicLightmapUV = input.dynamicLightmapUV;
                #endif
                #if !defined(LIGHTMAP_ON)
                output.sh = input.sh;
                #endif
                #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
                output.shadowCoord = input.shadowCoord;
                #endif
                output.tangentWS.xyzw = input.tangentWS;
                output.texCoord0.xyzw = input.texCoord0;
                output.fogFactorAndVertexLight.xyzw = input.fogFactorAndVertexLight;
                output.positionWS.xyz = input.positionWS;
                output.normalWS.xyz = input.normalWS;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
            
            Varyings UnpackVaryings(PackedVaryings input)
            {
                Varyings output;
                output.positionCS = input.positionCS;
                #if !defined(LIGHTMAP_ON)
                output.sh = input.sh;
                #endif
                #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
                output.shadowCoord = input.shadowCoord;
                #endif
                output.tangentWS = input.tangentWS.xyzw;
                output.texCoord0 = input.texCoord0.xyzw;
                output.fogFactorAndVertexLight = input.fogFactorAndVertexLight.xyzw;
                output.positionWS = input.positionWS.xyz;
                output.normalWS = input.normalWS.xyz;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
            
            // 优化：将材质属性按功能分组并添加注释
            CBUFFER_START(UnityPerMaterial)
            // 纹理属性
            float4 _BaseTexture_TexelSize;
            float4 _LargeNormalMap_TexelSize;
            float4 _SmallNormalMap_TexelSize;
            
            // 水颜色属性
            float4 _WaterColorDeep;
            float4 _WaterColor;
            float _FadeDistanceColor;
            
            // 线条效果属性
            float _LineScaleWidth;
            float _LineAcceleration;
            float _LinesMainScaleY;
            float _LinesMainScaleX;
            float _LinesMainSpeed;
            float4 _LinesMainTex_TexelSize;
            float _LinesSecondaryScaleX;
            float _TimeSecondarySpeed;
            float _LinesSecondaryScaleY;
            float _LineThreshold;
            float _UVFade;
            float4 _LineColor;
            
            // 法线贴图属性
            float _TilingLarge;
            float _WaveLargeNormalStrength;
            float _TilingSmall;
            float _WaveSmallNormalStrength;
            CBUFFER_END
            
            // 纹理采样器定义 - 优化命名
            SAMPLER(SamplerState_Linear_Repeat);
            TEXTURE2D(_BaseTexture);
            SAMPLER(sampler_BaseTexture);
            TEXTURE2D(_LargeNormalMap);
            SAMPLER(sampler_LargeNormalMap);
            TEXTURE2D(_SmallNormalMap);
            SAMPLER(sampler_SmallNormalMap);
            TEXTURE2D(_LinesMainTex);
            SAMPLER(sampler_LinesMainTex);
            
            // 辅助函数 - 优化注释
            void Unity_SceneDepth_Eye_float(float4 UV, out float Out)
            {
                if (unity_OrthoParams.w == 1.0)
                {
                    Out = LinearEyeDepth(ComputeWorldSpacePosition(UV.xy, SHADERGRAPH_SAMPLE_SCENE_DEPTH(UV.xy), UNITY_MATRIX_I_VP), UNITY_MATRIX_V);
                }
                else
                {
                    Out = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH(UV.xy), _ZBufferParams);
                }
            }
            
            // 以下是各种数学运算辅助函数，已优化注释
            void Unity_Subtract_float(float A, float B, out float Out) { Out = A - B; }
            void Unity_Divide_float(float A, float B, out float Out) { Out = A / B; }
            void Unity_Saturate_float(float In, out float Out) { Out = saturate(In); }
            
            // 深度渐变子图函数
            struct Bindings_SubGDepthFade
            {
                float4 ScreenPosition;
                float2 NDCPosition;
            };
            
            void SG_SubGDepthFade(float fadeDistance, Bindings_SubGDepthFade input, out float4 output)
            {
                float sceneDepth;
                Unity_SceneDepth_Eye_float(float4(input.NDCPosition.xy, 0, 0), sceneDepth);
                
                float screenZ = input.ScreenPosition.w;
                float depthDifference = sceneDepth - screenZ;
                float fadeFactor = depthDifference / fadeDistance;
                float saturatedFade = saturate(fadeFactor);
                
                output = float4(saturatedFade, saturatedFade, saturatedFade, saturatedFade);
            }
            
            // 颜色插值和混合函数
            void Unity_Lerp_float4(float4 A, float4 B, float4 T, out float4 Out) { Out = lerp(A, B, T); }
            void Unity_ChannelMask_Green_float4(float4 In, out float4 Out) { Out = float4(0, In.g, 0, 0); }
            void Unity_Multiply_float4_float4(float4 A, float4 B, out float4 Out) { Out = A * B; }
            void Unity_ChannelMask_Red_float4(float4 In, out float4 Out) { Out = float4(In.r, 0, 0, 0); }
            void Unity_Power_float4(float4 A, float4 B, out float4 Out) { Out = pow(A, B); }
            void Unity_Add_float4(float4 A, float4 B, out float4 Out) { Out = A + B; }
            void Unity_Multiply_float_float(float A, float B, out float Out) { Out = A * B; }
            void Unity_Subtract_float4(float4 A, float4 B, out float4 Out) { Out = A - B; }
            void Unity_Saturate_float4(float4 In, out float4 Out) { Out = saturate(In); }
            void Unity_OneMinus_float(float In, out float Out) { Out = 1 - In; }
            void Unity_Floor_float4(float4 In, out float4 Out) { Out = floor(In); }
            void Unity_ChannelMask_RedGreen_float4(float4 In, out float4 Out) { Out = float4(In.r, In.g, 0, 0); }
            void Unity_Multiply_float2_float2(float2 A, float2 B, out float2 Out) { Out = A * B; }
            void Unity_Add_float2(float2 A, float2 B, out float2 Out) { Out = A + B; }
            void Unity_Cosine_float(float In, out float Out) { Out = cos(In); }
            void Unity_Sine_float(float In, out float Out) { Out = sin(In); }
            void Unity_Add_float(float A, float B, out float Out) { Out = A + B; }
            void Unity_DotProduct_float2(float2 A, float2 B, out float Out) { Out = dot(A, B); }
            
            // 自定义旋转子图函数
            struct Bindings_SubGCustomRotator
            {
            };
            
            void SG_SubGCustomRotator(float2 rotationCenter, float2 uvs, float rotationAngle, Bindings_SubGCustomRotator input, out float4 output)
            {
                float2 rotatedUVs = uvs - rotationCenter;
                
                float cosAngle = cos(rotationAngle);
                float sinAngle = sin(rotationAngle);
                
                float2 rotatedX = float2(cosAngle, -sinAngle);
                float2 rotatedY = float2(sinAngle, cosAngle);
                
                float dotX = dot(rotatedUVs, rotatedX);
                float dotY = dot(rotatedUVs, rotatedY);
                
                float2 resultUVs = rotationCenter + float2(dotX, dotY);
                output = float4(resultUVs, 0.0, 1.0);
            }
            
            // 法线平滑子图函数
            struct Bindings_SubGFlattenNormal
            {
            };
            
            void SG_SubGFlattenNormal(float3 inputNormal, float flatness, Bindings_SubGFlattenNormal input, out float3 output)
            {
                float3 flatNormal = float3(0, 0, 1);
                output = lerp(inputNormal, flatNormal, float3(flatness, flatness, flatness));
            }
            
            // 顶点描述函数
            struct VertexDescription
            {
                float3 Position;
                float3 Normal;
                float3 Tangent;
            };
            
            VertexDescription VertexDescriptionFunction(VertexDescriptionInputs input)
            {
                VertexDescription description = (VertexDescription)0;
                description.Position = input.ObjectSpacePosition;
                description.Normal = input.ObjectSpaceNormal;
                description.Tangent = input.ObjectSpaceTangent;
                return description;
            }
            
            // 表面描述函数 - 核心水效果实现
            struct SurfaceDescription
            {
                float3 BaseColor;         // 基础颜色
                float3 NormalTS;          // 切线空间法线
                float3 Emission;          // 自发光
                float Metallic;           // 金属度
                float3 Specular;          // 高光
                float Smoothness;         // 光滑度
                float Occlusion;          // 环境光遮蔽
                float Alpha;              // 透明度
                float AlphaClipThreshold; // 透明裁剪阈值
            };
            
           SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs input)
{
    // 显式初始化所有结构体成员
    SurfaceDescription surface = (SurfaceDescription)0;
    
    // 1. 深度渐变颜色混合
    Bindings_SubGDepthFade depthFadeInput;
    depthFadeInput.ScreenPosition = input.ScreenPosition;
    depthFadeInput.NDCPosition = input.NDCPosition;
    
    float4 depthFadeOutput;
    SG_SubGDepthFade(_FadeDistanceColor, depthFadeInput, depthFadeOutput);
    
    float4 waterColor = lerp(_WaterColor, _WaterColorDeep, depthFadeOutput);
    
    // 2. 线条效果计算
    float4 uv0 = input.uv0;
    float4 uvFade = float4(0, input.uv0.g * _UVFade, 0, 0);
    
    // 主线条纹理处理
    float4 mainLineUV = uv0;
    float4 mainLineScale = float4(_LineScaleWidth * mainLineUV.r, pow(mainLineUV.g, _LineAcceleration), 0, 0);
    // 修改主线条纹理移动方向
    float4 mainLineUVScaled = float4(
        _LinesMainScaleX * mainLineScale.r,
        _LinesMainScaleY * (mainLineScale.g + input.TimeParameters.x * _LinesMainSpeed), // 将减号改为加号
        0, 0
    );
    
    float4 mainLineTex = SAMPLE_TEXTURE2D(_LinesMainTex, sampler_LinesMainTex, mainLineUVScaled.xy);
    float4 mainLineEnhanced = mainLineTex * float4(2, 2, 2, 2);
    
    // 次线条纹理处理
    float4 secondaryLineUV = uv0;
    // 修改次线条纹理移动方向
    float4 secondaryLineScale = float4(
        _LinesSecondaryScaleX * secondaryLineUV.r,
        _LinesSecondaryScaleY * (secondaryLineUV.g + input.TimeParameters.x * _TimeSecondarySpeed), // 将减号改为加号
        0, 0
    );

    
    float4 secondaryLineTex = SAMPLE_TEXTURE2D(_BaseTexture, sampler_BaseTexture, secondaryLineScale.xy);
    float4 combinedLines = mainLineEnhanced * secondaryLineTex * float4(2, 2, 2, 2);
    
    // 线条混合和阈值处理
    float4 finalLines = uvFade + combinedLines;
    float4 saturatedLines = saturate(finalLines);
    float4 lineMask = floor(saturate(saturatedLines + (1 - _LineThreshold)));
    
    // 最终颜色混合 - 确保所有颜色通道都被初始化
    float4 finalColor = lerp(waterColor, _LineColor, lineMask);
    
    // 3. 法线贴图处理
    // 大波纹法线
    float4 largeNormalUV = uv0 * _TilingLarge;
    float4 rotationVector = float4(0, -0.5, 0, 0) * 2;
    float4 rotatedLargeUV = largeNormalUV + rotationVector;
    
    Bindings_SubGCustomRotator rotatorInput;
    float4 rotatedLargeNormalUV;
    SG_SubGCustomRotator(float2(0, 0), rotatedLargeUV.xy, 0, rotatorInput, rotatedLargeNormalUV);
    
    float4 largeNormalTex = SAMPLE_TEXTURE2D(_LargeNormalMap, sampler_LargeNormalMap, rotatedLargeNormalUV.xy);
    largeNormalTex.rgb = UnpackNormal(largeNormalTex);
    float3 largeNormal = largeNormalTex.rgb;
    
    // 小波纹法线
    float4 smallNormalUV = uv0 * _TilingSmall;
   // 修改小波纹法线移动方向
    float2 smallNormalMotion = float2(0, 2) * input.TimeParameters.x; // 移除负号或修改符号
    float2 rotatedSmallUV = smallNormalUV.xy + smallNormalMotion;
    
    float4 rotatedSmallNormalUV;
    SG_SubGCustomRotator(float2(0, 0), rotatedSmallUV, 0, rotatorInput, rotatedSmallNormalUV);
    
    float4 smallNormalTex = SAMPLE_TEXTURE2D(_SmallNormalMap, sampler_SmallNormalMap, rotatedSmallNormalUV.xy);
    smallNormalTex.rgb = UnpackNormal(smallNormalTex);
    float3 smallNormal = smallNormalTex.rgb;
    
    // 法线混合
    float3 blendedNormal = lerp(
        largeNormal, 
        smallNormal, 
        float3(0.5, 0.5, 0.5)
    );
    
    // 法线平滑处理
    float3 finalNormal;
    SG_SubGFlattenNormal(blendedNormal, 1.0, (Bindings_SubGFlattenNormal)0, finalNormal);
    finalNormal = lerp(finalNormal, blendedNormal, float3(0, 0, 0));
    
    // 显式设置结构体的所有成员
    surface.BaseColor = finalColor.xyz;
    surface.NormalTS = finalNormal;
    surface.Emission = float3(0, 0, 0);
    surface.Metallic = 0.0f;
    surface.Specular = IsGammaSpace() ? float3(0.5, 0.5, 0.5) : SRGBToLinear(float3(0.5, 0.5, 0.5));
    surface.Smoothness = 0.5f;
    surface.Occlusion = 1.0f;
    surface.Alpha = 1.0f;
    surface.AlphaClipThreshold = 0.5f;
    
    return surface;
}
            
            // 构建输入数据函数
            #ifdef HAVE_VFX_MODIFICATION
            #define VFX_SRP_ATTRIBUTES Attributes
            #define VFX_SRP_VARYINGS Varyings
            #define VFX_SRP_SURFACE_INPUTS SurfaceDescriptionInputs
            #endif
            
            VertexDescriptionInputs BuildVertexDescriptionInputs(Attributes input)
            {
                VertexDescriptionInputs output;
                ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                output.ObjectSpaceNormal = input.normalOS;
                output.ObjectSpaceTangent = input.tangentOS.xyz;
                output.ObjectSpacePosition = input.positionOS;
                
                return output;
            }
            
            SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
            {
                SurfaceDescriptionInputs output;
                ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                output.TangentSpaceNormal = float3(0.0f, 0.0f, 1.0f);
                output.WorldSpacePosition = input.positionWS;
                output.ScreenPosition = ComputeScreenPos(TransformWorldToHClip(input.positionWS), _ProjectionParams.x);
                
                #if UNITY_UV_STARTS_AT_TOP
                output.PixelPosition = float2(input.positionCS.x, (_ProjectionParams.x < 0) ? (_ScaledScreenParams.y - input.positionCS.y) : input.positionCS.y);
                #else
                output.PixelPosition = float2(input.positionCS.x, (_ProjectionParams.x > 0) ? (_ScaledScreenParams.y - input.positionCS.y) : input.positionCS.y);
                #endif
                
                output.NDCPosition = output.PixelPosition.xy / _ScaledScreenParams.xy;
                output.NDCPosition.y = 1.0f - output.NDCPosition.y;
                output.uv0 = input.texCoord0;
                output.TimeParameters = _TimeParameters.xyz;
                
                return output;
            }
            
            // 包含PBR渲染逻辑
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/PBRForwardPass.hlsl"
            
            #ifdef HAVE_VFX_MODIFICATION
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
            #endif
            
            ENDHLSL
        }
    }
    
    CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
    FallBack "Hidden/Shader Graph/FallbackError"
}