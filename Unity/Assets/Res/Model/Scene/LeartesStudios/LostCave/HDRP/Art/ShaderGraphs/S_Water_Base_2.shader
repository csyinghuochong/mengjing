Shader "Shader Graphs/S_Water_Base_2"
{
    Properties
    {
        _Foam_Scale("Foam_Scale", Float) = 3
        _Wave_small_speed_3("Wave_small_speed (3)", Float) = 0.013
        _Wave_small_speed_2("Wave_small_speed (2)", Float) = 0.013
        _Wave_small_speed_1("Wave_small_speed (1)", Float) = 0.013
        _Foam_Speed("Foam_Speed", Float) = 0.015
        _Foam_Fade_Dist("Foam_Fade_Dist", Float) = 40
        _Fade_edge_distance("Fade_edge_distance", Float) = 5
        _Foam_Contrast("Foam_Contrast", Float) = 1
        _Wave_big_speed("Wave_big_speed", Float) = 0.013
        _Wave_small_speed("Wave_small_speed", Float) = 0.013
        _Wave_big_scale("Wave_big_scale", Float) = 4
        _Wave_small_scale("Wave_small_scale", Float) = 2
        _Water_Color("Water_Color", Color) = (0, 0.427451, 0.454902, 1)
        _Water_Color__deep("Water_Color _deep", Color) = (0, 0.2901961, 0.3803922, 1)
        _fade_distance_color("fade_distance_color", Float) = 1000
        _Rough_tiling("Rough_tiling", Float) = 0.5
        _Rough_mask_speed("Rough_mask_speed", Float) = 0.0125
        _Roughness("Roughness", Float) = 0.15
        _Rough_contrast("Rough_contrast", Float) = 0
        _Shore_fade_distance("Shore_fade_distance", Float) = 20
        _Opacity_shore("Opacity_shore", Float) = 0.05
        _Opacity_depth("Opacity_depth", Float) = 1
        _Opacity_mid("Opacity_mid", Float) = 0.7
        _Water_fade_distance("Water_fade_distance", Float) = 400
        _metallic("metallic", Float) = 0.6
        _Refraction_scale("Refraction_scale", Float) = 4.2
        _Refraction_speed("Refraction_speed", Float) = 0.013
        _Refraction_power("Refraction_power", Float) = 4
        _Refraction_distance("Refraction_distance", Float) = 1
        [NoScaleOffset]_SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_Texture_1_Texture2D("Texture2D_1", 2D) = "white" {}
        [Normal][NoScaleOffset]_SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_Texture_1_Texture2D("Texture2D_2", 2D) = "bump" {}
        [Normal][NoScaleOffset]_SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_Texture_1_Texture2D("Texture2D_3", 2D) = "bump" {}
        [HideInInspector]_WorkflowMode("_WorkflowMode", Float) = 1
        [HideInInspector]_CastShadows("_CastShadows", Float) = 1
        [HideInInspector]_ReceiveShadows("_ReceiveShadows", Float) = 1
        [HideInInspector]_Surface("_Surface", Float) = 0
        [HideInInspector]_Blend("_Blend", Float) = 0
        [HideInInspector]_AlphaClip("_AlphaClip", Float) = 0
        [HideInInspector]_BlendModePreserveSpecular("_BlendModePreserveSpecular", Float) = 0
        [HideInInspector]_SrcBlend("_SrcBlend", Float) = 1
        [HideInInspector]_DstBlend("_DstBlend", Float) = 0
        [HideInInspector][ToggleUI]_ZWrite("_ZWrite", Float) = 1
        [HideInInspector]_ZWriteControl("_ZWriteControl", Float) = 0
        [HideInInspector]_ZTest("_ZTest", Float) = 4
        [HideInInspector]_Cull("_Cull", Float) = 2
        [HideInInspector]_AlphaToMask("_AlphaToMask", Float) = 0
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Opaque"
            "UniversalMaterialType" = "Lit"
            "Queue"="Geometry"
            "DisableBatching"="False"
            "ShaderGraphShader"="true"
            "ShaderGraphTargetId"="UniversalLitSubTarget"
        }
        Pass
        {
            Name "Universal Forward"
            Tags
            {
                "LightMode" = "UniversalForward"
            }
        
        // Render State
        Cull [_Cull]
        Blend [_SrcBlend] [_DstBlend]
        ZTest [_ZTest]
        ZWrite [_ZWrite]
        AlphaToMask [_AlphaToMask]
        
        // Debug
        // <None>
        
        // --------------------------------------------------
        // Pass
        
        HLSLPROGRAM
        
        // Pragmas
        #pragma target 2.0
        #pragma multi_compile_instancing
        #pragma multi_compile_fog
        #pragma instancing_options renderinglayer
        #pragma vertex vert
        #pragma fragment frag
        
        // Keywords
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
        #pragma shader_feature_fragment _ _SURFACE_TYPE_TRANSPARENT
        #pragma shader_feature_local_fragment _ _ALPHAPREMULTIPLY_ON
        #pragma shader_feature_local_fragment _ _ALPHAMODULATE_ON
        #pragma shader_feature_local_fragment _ _ALPHATEST_ON
        #pragma shader_feature_local_fragment _ _SPECULAR_SETUP
        #pragma shader_feature_local _ _RECEIVE_SHADOWS_OFF
        // GraphKeywords: <None>
        
        // Defines
        
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
        /* WARNING: $splice Could not find named fragment 'PassInstancing' */
        #define SHADERPASS SHADERPASS_FORWARD
        #define _FOG_FRAGMENT 1
        #define REQUIRE_DEPTH_TEXTURE
        
        
        // custom interpolator pre-include
        /* WARNING: $splice Could not find named fragment 'sgci_CustomInterpolatorPreInclude' */
        
        // Includes
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DBuffer.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
        
        // --------------------------------------------------
        // Structs and Packing
        
        // custom interpolators pre packing
        /* WARNING: $splice Could not find named fragment 'CustomInterpolatorPrePacking' */
        
        struct Attributes
        {
             float3 positionOS : POSITION;
             float3 normalOS : NORMAL;
             float4 tangentOS : TANGENT;
             float4 uv0 : TEXCOORD0;
             float4 uv1 : TEXCOORD1;
             float4 uv2 : TEXCOORD2;
            #if UNITY_ANY_INSTANCING_ENABLED
             uint instanceID : INSTANCEID_SEMANTIC;
            #endif
        };
        struct Varyings
        {
             float4 positionCS : SV_POSITION;
             float3 positionWS;
             float3 normalWS;
             float4 tangentWS;
             float4 texCoord0;
            #if defined(LIGHTMAP_ON)
             float2 staticLightmapUV;
            #endif
            #if defined(DYNAMICLIGHTMAP_ON)
             float2 dynamicLightmapUV;
            #endif
            #if !defined(LIGHTMAP_ON)
             float3 sh;
            #endif
             float4 fogFactorAndVertexLight;
            #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
             float4 shadowCoord;
            #endif
            #if UNITY_ANY_INSTANCING_ENABLED
             uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
             uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
             uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
             FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };
        struct SurfaceDescriptionInputs
        {
             float3 TangentSpaceNormal;
             float3 WorldSpacePosition;
             float4 ScreenPosition;
             float2 NDCPosition;
             float2 PixelPosition;
             float4 uv0;
             float3 TimeParameters;
        };
        struct VertexDescriptionInputs
        {
             float3 ObjectSpaceNormal;
             float3 ObjectSpaceTangent;
             float3 ObjectSpacePosition;
        };
        struct PackedVaryings
        {
             float4 positionCS : SV_POSITION;
            #if defined(LIGHTMAP_ON)
             float2 staticLightmapUV : INTERP0;
            #endif
            #if defined(DYNAMICLIGHTMAP_ON)
             float2 dynamicLightmapUV : INTERP1;
            #endif
            #if !defined(LIGHTMAP_ON)
             float3 sh : INTERP2;
            #endif
            #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
             float4 shadowCoord : INTERP3;
            #endif
             float4 tangentWS : INTERP4;
             float4 texCoord0 : INTERP5;
             float4 fogFactorAndVertexLight : INTERP6;
             float3 positionWS : INTERP7;
             float3 normalWS : INTERP8;
            #if UNITY_ANY_INSTANCING_ENABLED
             uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
             uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
             uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
             FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };
        
        PackedVaryings PackVaryings (Varyings input)
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
        
        Varyings UnpackVaryings (PackedVaryings input)
        {
            Varyings output;
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
        
        
        // --------------------------------------------------
        // Graph
        
        // Graph Properties
        CBUFFER_START(UnityPerMaterial)
        float4 _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_Texture_1_Texture2D_TexelSize;
        float4 _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_Texture_1_Texture2D_TexelSize;
        float4 _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_Texture_1_Texture2D_TexelSize;
        float _Wave_small_speed_3;
        float _Wave_small_speed_2;
        float _Wave_small_speed_1;
        float _Foam_Speed;
        float _Foam_Scale;
        float _Fade_edge_distance;
        float _Foam_Fade_Dist;
        float _Foam_Contrast;
        float _Wave_big_scale;
        float _Wave_small_speed;
        float _Wave_small_scale;
        float _Wave_big_speed;
        float4 _Water_Color__deep;
        float4 _Water_Color;
        float _fade_distance_color;
        float _Rough_mask_speed;
        float _Rough_tiling;
        float _Rough_contrast;
        float _Roughness;
        float _Shore_fade_distance;
        float _Opacity_depth;
        float _Opacity_mid;
        float _Water_fade_distance;
        float _Opacity_shore;
        float _metallic;
        float _Refraction_scale;
        float _Refraction_power;
        float _Refraction_speed;
        float _Refraction_distance;
        CBUFFER_END
        
        
        // Object and Global properties
        SAMPLER(SamplerState_Linear_Repeat);
        TEXTURE2D(_SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_Texture_1_Texture2D);
        SAMPLER(sampler_SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_Texture_1_Texture2D);
        TEXTURE2D(_SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_Texture_1_Texture2D);
        SAMPLER(sampler_SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_Texture_1_Texture2D);
        TEXTURE2D(_SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_Texture_1_Texture2D);
        SAMPLER(sampler_SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_Texture_1_Texture2D);
        
        // Graph Includes
        // GraphIncludes: <None>
        
        // -- Property used by ScenePickingPass
        #ifdef SCENEPICKINGPASS
        float4 _SelectionID;
        #endif
        
        // -- Properties used by SceneSelectionPass
        #ifdef SCENESELECTIONPASS
        int _ObjectId;
        int _PassValue;
        #endif
        
        // Graph Functions
        
        void Unity_Multiply_float4_float4(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }
        
        void Unity_Multiply_float_float(float A, float B, out float Out)
        {
            Out = A * B;
        }
        
        void Unity_Add_float4(float4 A, float4 B, out float4 Out)
        {
            Out = A + B;
        }
        
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
        
        void Unity_Subtract_float(float A, float B, out float Out)
        {
            Out = A - B;
        }
        
        void Unity_Divide_float(float A, float B, out float Out)
        {
            Out = A / B;
        }
        
        void Unity_Saturate_float(float In, out float Out)
        {
            Out = saturate(In);
        }
        
        struct Bindings_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float
        {
        float4 ScreenPosition;
        float2 NDCPosition;
        };
        
        void SG_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float(float Vector1_823eac59178645a49a599f033d838d9a, Bindings_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float IN, out float4 Output_0)
        {
        float _SceneDepth_5360f1578d2c440a99c149920bb6a9a0_Out_1_Float;
        Unity_SceneDepth_Eye_float(float4(IN.NDCPosition.xy, 0, 0), _SceneDepth_5360f1578d2c440a99c149920bb6a9a0_Out_1_Float);
        float4 _ScreenPosition_54d0bf25682241baa8a714d7a8aa88f9_Out_0_Vector4 = IN.ScreenPosition;
        float _Split_28a0ce2c4d1249d5818634c129a23161_R_1_Float = _ScreenPosition_54d0bf25682241baa8a714d7a8aa88f9_Out_0_Vector4[0];
        float _Split_28a0ce2c4d1249d5818634c129a23161_G_2_Float = _ScreenPosition_54d0bf25682241baa8a714d7a8aa88f9_Out_0_Vector4[1];
        float _Split_28a0ce2c4d1249d5818634c129a23161_B_3_Float = _ScreenPosition_54d0bf25682241baa8a714d7a8aa88f9_Out_0_Vector4[2];
        float _Split_28a0ce2c4d1249d5818634c129a23161_A_4_Float = _ScreenPosition_54d0bf25682241baa8a714d7a8aa88f9_Out_0_Vector4[3];
        float _Subtract_667718e1a90c424098e6a633a4e9c5c2_Out_2_Float;
        Unity_Subtract_float(_SceneDepth_5360f1578d2c440a99c149920bb6a9a0_Out_1_Float, _Split_28a0ce2c4d1249d5818634c129a23161_A_4_Float, _Subtract_667718e1a90c424098e6a633a4e9c5c2_Out_2_Float);
        float _Property_19fe9a10c0da47e8986c8601f6c20f51_Out_0_Float = Vector1_823eac59178645a49a599f033d838d9a;
        float _Divide_51a9f2dd52c944b780a3e101c21a491d_Out_2_Float;
        Unity_Divide_float(_Subtract_667718e1a90c424098e6a633a4e9c5c2_Out_2_Float, _Property_19fe9a10c0da47e8986c8601f6c20f51_Out_0_Float, _Divide_51a9f2dd52c944b780a3e101c21a491d_Out_2_Float);
        float _Saturate_ab074abd680e4558a452603520c88d74_Out_1_Float;
        Unity_Saturate_float(_Divide_51a9f2dd52c944b780a3e101c21a491d_Out_2_Float, _Saturate_ab074abd680e4558a452603520c88d74_Out_1_Float);
        Output_0 = (_Saturate_ab074abd680e4558a452603520c88d74_Out_1_Float.xxxx);
        }
        
        void Unity_OneMinus_float4(float4 In, out float4 Out)
        {
            Out = 1 - In;
        }
        
        void Unity_Lerp_float4(float4 A, float4 B, float4 T, out float4 Out)
        {
            Out = lerp(A, B, T);
        }
        
        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }
        
        void Unity_Lerp_float(float A, float B, float T, out float Out)
        {
            Out = lerp(A, B, T);
        }
        
        void Unity_Clamp_float(float In, float Min, float Max, out float Out)
        {
            Out = clamp(In, Min, Max);
        }
        
        void Unity_ChannelMask_RedGreenBlueAlpha_float (float In, out float Out)
        {
        Out = In;
        }
        
        struct Bindings_SubGCheapContrast_fbb07af5f8c7a4543bf1374b2f130a6e_float
        {
        };
        
        void SG_SubGCheapContrast_fbb07af5f8c7a4543bf1374b2f130a6e_float(float _In, float _Contrast, Bindings_SubGCheapContrast_fbb07af5f8c7a4543bf1374b2f130a6e_float IN, out float Result_1)
        {
        float _Property_ce2b0460623f4e318a4e7dcb90133e21_Out_0_Float = _Contrast;
        float _Subtract_1afdc8e3a7e443688fa394a7770c36d9_Out_2_Float;
        Unity_Subtract_float(float(0), _Property_ce2b0460623f4e318a4e7dcb90133e21_Out_0_Float, _Subtract_1afdc8e3a7e443688fa394a7770c36d9_Out_2_Float);
        float _Add_f3df8073ca634461bfe6a0f2eab32ba9_Out_2_Float;
        Unity_Add_float(_Property_ce2b0460623f4e318a4e7dcb90133e21_Out_0_Float, float(1), _Add_f3df8073ca634461bfe6a0f2eab32ba9_Out_2_Float);
        float _Property_d6f23f79f130483fa106214016c1085f_Out_0_Float = _In;
        float _Lerp_45a4dc23b3cc40a486a8a1f631e650d4_Out_3_Float;
        Unity_Lerp_float(_Subtract_1afdc8e3a7e443688fa394a7770c36d9_Out_2_Float, _Add_f3df8073ca634461bfe6a0f2eab32ba9_Out_2_Float, _Property_d6f23f79f130483fa106214016c1085f_Out_0_Float, _Lerp_45a4dc23b3cc40a486a8a1f631e650d4_Out_3_Float);
        float _Clamp_74e7312ef74c4bb68a694105f6eeff14_Out_3_Float;
        Unity_Clamp_float(_Lerp_45a4dc23b3cc40a486a8a1f631e650d4_Out_3_Float, float(0), float(1), _Clamp_74e7312ef74c4bb68a694105f6eeff14_Out_3_Float);
        float _ChannelMask_c97326599d324ed5b048a8b32053ade5_Out_1_Float;
        Unity_ChannelMask_RedGreenBlueAlpha_float (_Clamp_74e7312ef74c4bb68a694105f6eeff14_Out_3_Float, _ChannelMask_c97326599d324ed5b048a8b32053ade5_Out_1_Float);
        Result_1 = _ChannelMask_c97326599d324ed5b048a8b32053ade5_Out_1_Float;
        }
        
        // Custom interpolators pre vertex
        /* WARNING: $splice Could not find named fragment 'CustomInterpolatorPreVertex' */
        
        // Graph Vertex
        struct VertexDescription
        {
            float3 Position;
            float3 Normal;
            float3 Tangent;
        };
        
        VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
        {
            VertexDescription description = (VertexDescription)0;
            description.Position = IN.ObjectSpacePosition;
            description.Normal = IN.ObjectSpaceNormal;
            description.Tangent = IN.ObjectSpaceTangent;
            return description;
        }
        
        // Custom interpolators, pre surface
        #ifdef FEATURES_GRAPH_VERTEX
        Varyings CustomInterpolatorPassThroughFunc(inout Varyings output, VertexDescription input)
        {
        return output;
        }
        #define CUSTOMINTERPOLATOR_VARYPASSTHROUGH_FUNC
        #endif
        
        // Graph Pixel
        struct SurfaceDescription
        {
            float3 BaseColor;
            float3 NormalTS;
            float3 Emission;
            float Metallic;
            float3 Specular;
            float Smoothness;
            float Occlusion;
            float Alpha;
            float AlphaClipThreshold;
        };
        
        SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
        {
            SurfaceDescription surface = (SurfaceDescription)0;
            float4 Color_393bb231074b4a80a01eaa88242baccc = IsGammaSpace() ? float4(0.6415094, 0.4327163, 0.4327163, 1) : float4(SRGBToLinear(float3(0.6415094, 0.4327163, 0.4327163)), 1);
            float4 _UV_5787310608944ea285bf9093cbc3f44f_Out_0_Vector4 = IN.uv0;
            float _Property_59599d4bb9c449c1b5db53596960d091_Out_0_Float = _Foam_Scale;
            float4 _Multiply_2cb87d17a0304bf184792c477e2f1253_Out_2_Vector4;
            Unity_Multiply_float4_float4(_UV_5787310608944ea285bf9093cbc3f44f_Out_0_Vector4, (_Property_59599d4bb9c449c1b5db53596960d091_Out_0_Float.xxxx), _Multiply_2cb87d17a0304bf184792c477e2f1253_Out_2_Vector4);
            float _Property_daee62ca75b74b41ba7834eb32481c86_Out_0_Float = _Foam_Speed;
            float _Multiply_3551518898994dcc89a47f99ac3ddf84_Out_2_Float;
            Unity_Multiply_float_float(IN.TimeParameters.x, _Property_daee62ca75b74b41ba7834eb32481c86_Out_0_Float, _Multiply_3551518898994dcc89a47f99ac3ddf84_Out_2_Float);
            float4 _Add_7724739711134414a46d51ca857019fb_Out_2_Vector4;
            Unity_Add_float4(_Multiply_2cb87d17a0304bf184792c477e2f1253_Out_2_Vector4, (_Multiply_3551518898994dcc89a47f99ac3ddf84_Out_2_Float.xxxx), _Add_7724739711134414a46d51ca857019fb_Out_2_Vector4);
            float4 _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(UnityBuildTexture2DStructNoScale(_SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_Texture_1_Texture2D).tex, UnityBuildTexture2DStructNoScale(_SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_Texture_1_Texture2D).samplerstate, UnityBuildTexture2DStructNoScale(_SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_Texture_1_Texture2D).GetTransformedUV((_Add_7724739711134414a46d51ca857019fb_Out_2_Vector4.xy)) );
            float _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_R_4_Float = _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_RGBA_0_Vector4.r;
            float _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_G_5_Float = _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_RGBA_0_Vector4.g;
            float _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_B_6_Float = _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_RGBA_0_Vector4.b;
            float _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_A_7_Float = _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_RGBA_0_Vector4.a;
            float4 _Add_fc60012374da46b986040fdde5cde7db_Out_2_Vector4;
            Unity_Add_float4(Color_393bb231074b4a80a01eaa88242baccc, _SampleTexture2D_de7059618b4041f2bd777f5c1ae55a8d_RGBA_0_Vector4, _Add_fc60012374da46b986040fdde5cde7db_Out_2_Vector4);
            float4 Color_19376133300e46edbacdbaa0f55410ee = IsGammaSpace() ? float4(0, 0, 0, 0) : float4(SRGBToLinear(float3(0, 0, 0)), 0);
            float _Property_f88573aaeaad4f53a6cb82eaa253722d_Out_0_Float = _Foam_Fade_Dist;
            Bindings_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float _SubGDepthFade_2ffdc7b25d454b00bf0424e12c136cc6;
            _SubGDepthFade_2ffdc7b25d454b00bf0424e12c136cc6.ScreenPosition = IN.ScreenPosition;
            _SubGDepthFade_2ffdc7b25d454b00bf0424e12c136cc6.NDCPosition = IN.NDCPosition;
            float4 _SubGDepthFade_2ffdc7b25d454b00bf0424e12c136cc6_Output_0_Vector4;
            SG_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float(_Property_f88573aaeaad4f53a6cb82eaa253722d_Out_0_Float, _SubGDepthFade_2ffdc7b25d454b00bf0424e12c136cc6, _SubGDepthFade_2ffdc7b25d454b00bf0424e12c136cc6_Output_0_Vector4);
            float _Property_747875f54e94422c814d0617883f7138_Out_0_Float = _Fade_edge_distance;
            Bindings_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float _SubGDepthFade_f4716c901c94431694f4c4fb1aad3b29;
            _SubGDepthFade_f4716c901c94431694f4c4fb1aad3b29.ScreenPosition = IN.ScreenPosition;
            _SubGDepthFade_f4716c901c94431694f4c4fb1aad3b29.NDCPosition = IN.NDCPosition;
            float4 _SubGDepthFade_f4716c901c94431694f4c4fb1aad3b29_Output_0_Vector4;
            SG_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float(_Property_747875f54e94422c814d0617883f7138_Out_0_Float, _SubGDepthFade_f4716c901c94431694f4c4fb1aad3b29, _SubGDepthFade_f4716c901c94431694f4c4fb1aad3b29_Output_0_Vector4);
            float4 _OneMinus_dde1280d793543e0b119649165b3eeaa_Out_1_Vector4;
            Unity_OneMinus_float4(_SubGDepthFade_f4716c901c94431694f4c4fb1aad3b29_Output_0_Vector4, _OneMinus_dde1280d793543e0b119649165b3eeaa_Out_1_Vector4);
            float4 _Add_1f6f4d4d226646d6ac3e675271fb7562_Out_2_Vector4;
            Unity_Add_float4(_SubGDepthFade_2ffdc7b25d454b00bf0424e12c136cc6_Output_0_Vector4, _OneMinus_dde1280d793543e0b119649165b3eeaa_Out_1_Vector4, _Add_1f6f4d4d226646d6ac3e675271fb7562_Out_2_Vector4);
            float4 _Lerp_428e27f0ea484825b7fe78bbecf81cce_Out_3_Vector4;
            Unity_Lerp_float4(_Add_fc60012374da46b986040fdde5cde7db_Out_2_Vector4, Color_19376133300e46edbacdbaa0f55410ee, _Add_1f6f4d4d226646d6ac3e675271fb7562_Out_2_Vector4, _Lerp_428e27f0ea484825b7fe78bbecf81cce_Out_3_Vector4);
            float _Property_9a5d3faf745e4dc9b5301d3d88a9c100_Out_0_Float = _Foam_Contrast;
            Bindings_SubGCheapContrast_fbb07af5f8c7a4543bf1374b2f130a6e_float _SubGCheapContrast_555571f8a27a4526a8027865b4fda527;
            float _SubGCheapContrast_555571f8a27a4526a8027865b4fda527_Result_1_Float;
            SG_SubGCheapContrast_fbb07af5f8c7a4543bf1374b2f130a6e_float((_Lerp_428e27f0ea484825b7fe78bbecf81cce_Out_3_Vector4).x, _Property_9a5d3faf745e4dc9b5301d3d88a9c100_Out_0_Float, _SubGCheapContrast_555571f8a27a4526a8027865b4fda527, _SubGCheapContrast_555571f8a27a4526a8027865b4fda527_Result_1_Float);
            float4 _Property_366793a37e1e4833a6635d56425a1ff1_Out_0_Vector4 = _Water_Color;
            float4 _Property_c9d1fd4694cf46c4bb5c2be917693c9a_Out_0_Vector4 = _Water_Color__deep;
            float _Property_3481b96a16eb4a069f705bedd26331a3_Out_0_Float = _fade_distance_color;
            Bindings_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float _SubGDepthFade_6f298b9fcf654cfd8e8b970a8585347c;
            _SubGDepthFade_6f298b9fcf654cfd8e8b970a8585347c.ScreenPosition = IN.ScreenPosition;
            _SubGDepthFade_6f298b9fcf654cfd8e8b970a8585347c.NDCPosition = IN.NDCPosition;
            float4 _SubGDepthFade_6f298b9fcf654cfd8e8b970a8585347c_Output_0_Vector4;
            SG_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float(_Property_3481b96a16eb4a069f705bedd26331a3_Out_0_Float, _SubGDepthFade_6f298b9fcf654cfd8e8b970a8585347c, _SubGDepthFade_6f298b9fcf654cfd8e8b970a8585347c_Output_0_Vector4);
            float4 _Lerp_bc21392f17044ac2b3bc27f14a1f8208_Out_3_Vector4;
            Unity_Lerp_float4(_Property_366793a37e1e4833a6635d56425a1ff1_Out_0_Vector4, _Property_c9d1fd4694cf46c4bb5c2be917693c9a_Out_0_Vector4, _SubGDepthFade_6f298b9fcf654cfd8e8b970a8585347c_Output_0_Vector4, _Lerp_bc21392f17044ac2b3bc27f14a1f8208_Out_3_Vector4);
            float4 _Add_dee42ddfffb94b7db04e2273fef59afd_Out_2_Vector4;
            Unity_Add_float4((_SubGCheapContrast_555571f8a27a4526a8027865b4fda527_Result_1_Float.xxxx), _Lerp_bc21392f17044ac2b3bc27f14a1f8208_Out_3_Vector4, _Add_dee42ddfffb94b7db04e2273fef59afd_Out_2_Vector4);
            float4 _UV_9bb1b6a997b84be38bfd5c15bda87272_Out_0_Vector4 = IN.uv0;
            float _Property_61c201ff491c4c148d5c450584843350_Out_0_Float = _Wave_big_speed;
            float4 _Multiply_452adb3ec2ba4a1c86e211507397d180_Out_2_Vector4;
            Unity_Multiply_float4_float4(_UV_9bb1b6a997b84be38bfd5c15bda87272_Out_0_Vector4, (_Property_61c201ff491c4c148d5c450584843350_Out_0_Float.xxxx), _Multiply_452adb3ec2ba4a1c86e211507397d180_Out_2_Vector4);
            float _Property_7e5283f810d4484c82e6e35520d25f99_Out_0_Float = _Wave_big_speed;
            float _Multiply_441641a1c8794dd28d3f14036ec62c51_Out_2_Float;
            Unity_Multiply_float_float(IN.TimeParameters.x, _Property_7e5283f810d4484c82e6e35520d25f99_Out_0_Float, _Multiply_441641a1c8794dd28d3f14036ec62c51_Out_2_Float);
            float4 _Add_aa6633a55907412fb560a22c410aa24d_Out_2_Vector4;
            Unity_Add_float4(_Multiply_452adb3ec2ba4a1c86e211507397d180_Out_2_Vector4, (_Multiply_441641a1c8794dd28d3f14036ec62c51_Out_2_Float.xxxx), _Add_aa6633a55907412fb560a22c410aa24d_Out_2_Vector4);
            float4 _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(UnityBuildTexture2DStructNoScale(_SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_Texture_1_Texture2D).tex, UnityBuildTexture2DStructNoScale(_SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_Texture_1_Texture2D).samplerstate, UnityBuildTexture2DStructNoScale(_SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_Texture_1_Texture2D).GetTransformedUV((_Add_aa6633a55907412fb560a22c410aa24d_Out_2_Vector4.xy)) );
            _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_RGBA_0_Vector4.rgb = UnpackNormal(_SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_RGBA_0_Vector4);
            float _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_R_4_Float = _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_RGBA_0_Vector4.r;
            float _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_G_5_Float = _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_RGBA_0_Vector4.g;
            float _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_B_6_Float = _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_RGBA_0_Vector4.b;
            float _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_A_7_Float = _SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_RGBA_0_Vector4.a;
            float _Property_116ec0bfb93b4722b6ea134845abd65e_Out_0_Float = _Wave_small_scale;
            float4 _Multiply_929030518f5d427296f4e32424575539_Out_2_Vector4;
            Unity_Multiply_float4_float4((_Property_116ec0bfb93b4722b6ea134845abd65e_Out_0_Float.xxxx), _UV_9bb1b6a997b84be38bfd5c15bda87272_Out_0_Vector4, _Multiply_929030518f5d427296f4e32424575539_Out_2_Vector4);
            float4 _Add_d696957235b94c9590a8e6c1a6a32588_Out_2_Vector4;
            Unity_Add_float4(_Multiply_929030518f5d427296f4e32424575539_Out_2_Vector4, (_Multiply_441641a1c8794dd28d3f14036ec62c51_Out_2_Float.xxxx), _Add_d696957235b94c9590a8e6c1a6a32588_Out_2_Vector4);
            float4 _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(UnityBuildTexture2DStructNoScale(_SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_Texture_1_Texture2D).tex, UnityBuildTexture2DStructNoScale(_SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_Texture_1_Texture2D).samplerstate, UnityBuildTexture2DStructNoScale(_SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_Texture_1_Texture2D).GetTransformedUV((_Add_d696957235b94c9590a8e6c1a6a32588_Out_2_Vector4.xy)) );
            _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_RGBA_0_Vector4.rgb = UnpackNormal(_SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_RGBA_0_Vector4);
            float _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_R_4_Float = _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_RGBA_0_Vector4.r;
            float _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_G_5_Float = _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_RGBA_0_Vector4.g;
            float _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_B_6_Float = _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_RGBA_0_Vector4.b;
            float _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_A_7_Float = _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_RGBA_0_Vector4.a;
            float4 _Add_7ba06375cca043e6b12e78479a1e0b7a_Out_2_Vector4;
            Unity_Add_float4(_SampleTexture2D_6e3a1a97bafe498f898f7f6bb0a8faf3_RGBA_0_Vector4, _SampleTexture2D_55f4a5de9ad046fa82d8b84f9b2323a6_RGBA_0_Vector4, _Add_7ba06375cca043e6b12e78479a1e0b7a_Out_2_Vector4);
            float4 Color_d41ae6a57dc14f48b2215547a4778638 = IsGammaSpace() ? float4(0.3568628, 0.4862745, 1, 1) : float4(SRGBToLinear(float3(0.3568628, 0.4862745, 1)), 1);
            float4 _Multiply_7820d85fe7dd4e6197b49bd75703a341_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Add_7ba06375cca043e6b12e78479a1e0b7a_Out_2_Vector4, Color_d41ae6a57dc14f48b2215547a4778638, _Multiply_7820d85fe7dd4e6197b49bd75703a341_Out_2_Vector4);
            float _Property_d46e624a1a3c41048ea2f6f690058388_Out_0_Float = _metallic;
            surface.BaseColor = (_Add_dee42ddfffb94b7db04e2273fef59afd_Out_2_Vector4.xyz);
            surface.NormalTS = (_Multiply_7820d85fe7dd4e6197b49bd75703a341_Out_2_Vector4.xyz);
            surface.Emission = float3(0, 0, 0);
            surface.Metallic = _Property_d46e624a1a3c41048ea2f6f690058388_Out_0_Float;
            surface.Specular = IsGammaSpace() ? float3(0.5, 0.5, 0.5) : SRGBToLinear(float3(0.5, 0.5, 0.5));
            surface.Smoothness = float(0.5);
            surface.Occlusion = float(1);
            surface.Alpha = float(1);
            surface.AlphaClipThreshold = float(0.5);
            return surface;
        }
        
        // --------------------------------------------------
        // Build Graph Inputs
        #ifdef HAVE_VFX_MODIFICATION
        #define VFX_SRP_ATTRIBUTES Attributes
        #define VFX_SRP_VARYINGS Varyings
        #define VFX_SRP_SURFACE_INPUTS SurfaceDescriptionInputs
        #endif
        VertexDescriptionInputs BuildVertexDescriptionInputs(Attributes input)
        {
            VertexDescriptionInputs output;
            ZERO_INITIALIZE(VertexDescriptionInputs, output);
        
            output.ObjectSpaceNormal =                          input.normalOS;
            output.ObjectSpaceTangent =                         input.tangentOS.xyz;
            output.ObjectSpacePosition =                        input.positionOS;
        
            return output;
        }
        SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
        
        #ifdef HAVE_VFX_MODIFICATION
        #if VFX_USE_GRAPH_VALUES
            uint instanceActiveIndex = asuint(UNITY_ACCESS_INSTANCED_PROP(PerInstance, _InstanceActiveIndex));
            /* WARNING: $splice Could not find named fragment 'VFXLoadGraphValues' */
        #endif
            /* WARNING: $splice Could not find named fragment 'VFXSetFragInputs' */
        
        #endif
        
            
        
        
        
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
            output.TimeParameters = _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
        #else
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
        #endif
        #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
        
                return output;
        }
        
        // --------------------------------------------------
        // Main
        
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/PBRForwardPass.hlsl"
        
        // --------------------------------------------------
        // Visual Effect Vertex Invocations
        #ifdef HAVE_VFX_MODIFICATION
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
        #endif
        
        ENDHLSL
        }
    }

    CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
    FallBack "Hidden/Shader Graph/FallbackError"
}