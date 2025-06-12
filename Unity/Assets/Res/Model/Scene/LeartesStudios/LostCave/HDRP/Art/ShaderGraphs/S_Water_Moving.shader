Shader "Shader Graphs/S_Water_Moving"
{
    Properties
    {
        _Water_color("Water_color", Color) = (0, 0.427451, 0.454902, 1)
        _Water_color_deep("Water_color_deep", Color) = (0, 0.2901961, 0.3803922, 1)
        _Fade_distance_color("Fade_distance_color", Float) = 1000
        _line_acceleration("line_acceleration", Float) = 0.5
        _line_scale_width("line_scale_width", Float) = 1
        _lines_main_speed("lines_main_speed", Float) = 1.3
        _lines_main_scale_Y("lines_main_scale_Y", Float) = 1.3
        _lines_main_scale_X("lines_main_scale_X", Float) = 0.5
        _Lines_secondary_scale_X("Lines_secondary_scale_X", Float) = 2
        _lines_Secondary_scale_Y("lines_Secondary_scale_Y", Float) = 1
        _time_secondary_speed("time_secondary_speed", Float) = 1.15
        [NoScaleOffset]_lines_main_tex("lines_main_tex", 2D) = "white" {}
        _line_threshold("line_threshold", Float) = 0.642857
        _uv_fade("uv_fade", Float) = 0
        _line_color("line_color", Color) = (0.572549, 0.9137256, 1, 1)
        [NoScaleOffset]_Rough_mask("Rough_mask", 2D) = "white" {}
        _roughness("roughness", Float) = 0.15
        _rough_contrast("rough_contrast", Float) = 0
        _WPO_Tiling("WPO_Tiling", Float) = 1
        _WPO_Speed("WPO_Speed", Float) = 1
        _tiling_large("tiling_large", Float) = 12
        _wave_large_normal_Strength("wave_large_normal_Strength", Float) = 0.8
        _tiling_small("tiling_small", Float) = 20
        _wave_small_normal_strength("wave_small_normal_strength", Float) = 0.8

        [NonModifiableTextureData][NoScaleOffset]_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D("Texture2D", 2D) = "white" {}
        [NonModifiableTextureData][Normal][NoScaleOffset]_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D("Texture2D", 2D) = "bump" {}
        [NonModifiableTextureData][Normal][NoScaleOffset]_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D("Texture2D", 2D) = "bump" {}


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
        #include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
        #include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
        #include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
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
        
        CBUFFER_START(UnityPerMaterial)
        float4 _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D_TexelSize;
        float4 _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D_TexelSize;
        float4 _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D_TexelSize;
        float4 _Water_color_deep;
        float4 _Water_color;
        float _Fade_distance_color;
        float _line_scale_width;
        float _line_acceleration;
        float _lines_main_scale_Y;
        float _lines_main_scale_X;
        float _lines_main_speed;
        float4 _lines_main_tex_TexelSize;
        float _Lines_secondary_scale_X;
        float _time_secondary_speed;
        float _lines_Secondary_scale_Y;
        float _line_threshold;
        float _uv_fade;
        float4 _line_color;
        float4 _Rough_mask_TexelSize;
        float _roughness;
        float _rough_contrast;
        float _WPO_Speed;
        float _WPO_Tiling;
        float _tiling_large;
        float _wave_large_normal_Strength;
        float _tiling_small;
        float _wave_small_normal_strength;

        CBUFFER_END

        SAMPLER(SamplerState_Linear_Repeat);
        TEXTURE2D(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D);
        SAMPLER(sampler_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D);
        TEXTURE2D(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D);
        SAMPLER(sampler_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D);
        TEXTURE2D(_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D);
        SAMPLER(sampler_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D);
        TEXTURE2D(_lines_main_tex);
        SAMPLER(sampler_lines_main_tex);
        TEXTURE2D(_Rough_mask);
        SAMPLER(sampler_Rough_mask);
        
        #ifdef SCENEPICKINGPASS
        float4 _SelectionID;
        #endif
        
        #ifdef SCENESELECTIONPASS
        int _ObjectId;
        int _PassValue;
        #endif
        
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
        
        void Unity_Lerp_float4(float4 A, float4 B, float4 T, out float4 Out)
        {
            Out = lerp(A, B, T);
        }
        
        void Unity_ChannelMask_Green_float4 (float4 In, out float4 Out)
        {
            Out = float4(0, In.g, 0, 0);
        }
        
        void Unity_Multiply_float4_float4(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }
        
        void Unity_ChannelMask_Red_float4 (float4 In, out float4 Out)
        {
            Out = float4(In.r, 0, 0, 0);
        }
        
        void Unity_Power_float4(float4 A, float4 B, out float4 Out)
        {
            Out = pow(A, B);
        }
        
        void Unity_Add_float4(float4 A, float4 B, out float4 Out)
        {
            Out = A + B;
        }
        
        void Unity_Multiply_float_float(float A, float B, out float Out)
        {
            Out = A * B;
        }
        
        void Unity_Subtract_float4(float4 A, float4 B, out float4 Out)
        {
            Out = A - B;
        }
        
        void Unity_Saturate_float4(float4 In, out float4 Out)
        {
            Out = saturate(In);
        }
        
        void Unity_OneMinus_float(float In, out float Out)
        {
            Out = 1 - In;
        }
        
        void Unity_Floor_float4(float4 In, out float4 Out)
        {
            Out = floor(In);
        }
        
        void Unity_ChannelMask_RedGreen_float4 (float4 In, out float4 Out)
        {
            Out = float4(In.r, In.g, 0, 0);
        }
        
        void Unity_Multiply_float2_float2(float2 A, float2 B, out float2 Out)
        {
        Out = A * B;
        }
        
        void Unity_Add_float2(float2 A, float2 B, out float2 Out)
        {
            Out = A + B;
        }
        
        void Unity_Cosine_float(float In, out float Out)
        {
            Out = cos(In);
        }
        
        void Unity_Sine_float(float In, out float Out)
        {
            Out = sin(In);
        }
        
        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }
        
        void Unity_DotProduct_float2(float2 A, float2 B, out float Out)
        {
            Out = dot(A, B);
        }
        
        struct Bindings_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float
        {
        };
        
        void SG_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float(float2 _RotationCenter, float2 _UVs, float _Rotation_Angle_0_1, Bindings_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float IN, out float4 OutVector4_1)
        {
        float2 _Property_6b8858fb6b28462c918c80ac9112d227_Out_0_Vector2 = _RotationCenter;
        float _Float_837e06e61252474386fa567fd343eb71_Out_0_Float = float(-1);
        float2 _Multiply_83b9ee383b5941709dfde9d52c3af917_Out_2_Vector2;
        Unity_Multiply_float2_float2(_Property_6b8858fb6b28462c918c80ac9112d227_Out_0_Vector2, (_Float_837e06e61252474386fa567fd343eb71_Out_0_Float.xx), _Multiply_83b9ee383b5941709dfde9d52c3af917_Out_2_Vector2);
        float2 _Property_294f3c7837c44761a037c9364bbeb91d_Out_0_Vector2 = _UVs;
        float2 _Add_3afafe14e3c844509fa747e9f33d0743_Out_2_Vector2;
        Unity_Add_float2(_Multiply_83b9ee383b5941709dfde9d52c3af917_Out_2_Vector2, _Property_294f3c7837c44761a037c9364bbeb91d_Out_0_Vector2, _Add_3afafe14e3c844509fa747e9f33d0743_Out_2_Vector2);
        float _Property_db8e8068e21446e3a3bfd4ca47e145f1_Out_0_Float = _Rotation_Angle_0_1;
        float _Cosine_296ae596397f49d9a6353cd13c5a4065_Out_1_Float;
        Unity_Cosine_float(_Property_db8e8068e21446e3a3bfd4ca47e145f1_Out_0_Float, _Cosine_296ae596397f49d9a6353cd13c5a4065_Out_1_Float);
        float _Sine_56b799a343d04818b655a5f52d79442f_Out_1_Float;
        Unity_Sine_float(_Property_db8e8068e21446e3a3bfd4ca47e145f1_Out_0_Float, _Sine_56b799a343d04818b655a5f52d79442f_Out_1_Float);
        float _Float_d59d60e890164f0f8472c97198167085_Out_0_Float = float(-1);
        float _Multiply_388ac2ddd64141e4a3fa3684cf5d9504_Out_2_Float;
        Unity_Multiply_float_float(_Sine_56b799a343d04818b655a5f52d79442f_Out_1_Float, _Float_d59d60e890164f0f8472c97198167085_Out_0_Float, _Multiply_388ac2ddd64141e4a3fa3684cf5d9504_Out_2_Float);
        float _Add_c40cf003951e433b86b3cde03c5eadb3_Out_2_Float;
        Unity_Add_float(_Cosine_296ae596397f49d9a6353cd13c5a4065_Out_1_Float, _Multiply_388ac2ddd64141e4a3fa3684cf5d9504_Out_2_Float, _Add_c40cf003951e433b86b3cde03c5eadb3_Out_2_Float);
        float _DotProduct_d1e961f7f43c4406b995e327c26f71a5_Out_2_Float;
        Unity_DotProduct_float2(_Add_3afafe14e3c844509fa747e9f33d0743_Out_2_Vector2, (_Add_c40cf003951e433b86b3cde03c5eadb3_Out_2_Float.xx), _DotProduct_d1e961f7f43c4406b995e327c26f71a5_Out_2_Float);
        float _Add_78a2abd0a43e42b7ae6e2c18213291b9_Out_2_Float;
        Unity_Add_float(_Sine_56b799a343d04818b655a5f52d79442f_Out_1_Float, _Cosine_296ae596397f49d9a6353cd13c5a4065_Out_1_Float, _Add_78a2abd0a43e42b7ae6e2c18213291b9_Out_2_Float);
        float _DotProduct_44875e243e6c4aafae36318025418586_Out_2_Float;
        Unity_DotProduct_float2(_Add_3afafe14e3c844509fa747e9f33d0743_Out_2_Vector2, (_Add_78a2abd0a43e42b7ae6e2c18213291b9_Out_2_Float.xx), _DotProduct_44875e243e6c4aafae36318025418586_Out_2_Float);
        float _Add_16c535c220da42e7adc575091e5a606c_Out_2_Float;
        Unity_Add_float(_DotProduct_d1e961f7f43c4406b995e327c26f71a5_Out_2_Float, _DotProduct_44875e243e6c4aafae36318025418586_Out_2_Float, _Add_16c535c220da42e7adc575091e5a606c_Out_2_Float);
        float2 _Add_d1fc380d358b40febdf860ef126c9433_Out_2_Vector2;
        Unity_Add_float2(_Property_6b8858fb6b28462c918c80ac9112d227_Out_0_Vector2, (_Add_16c535c220da42e7adc575091e5a606c_Out_2_Float.xx), _Add_d1fc380d358b40febdf860ef126c9433_Out_2_Vector2);
        OutVector4_1 = (float4(_Add_d1fc380d358b40febdf860ef126c9433_Out_2_Vector2, 0.0, 1.0));
        }
        
        void Unity_Lerp_float3(float3 A, float3 B, float3 T, out float3 Out)
        {
            Out = lerp(A, B, T);
        }
        
        struct Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float
        {
        };
        
        void SG_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float(float3 _Input_Normal, float _Input_Flatness, Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float IN, out float3 Out_Vector4_1)
        {
        float3 _Property_da3b89567e634fa6a223a4aaf0f855a8_Out_0_Vector3 = _Input_Normal;
        float3 _Vector3_697e2eeaaaaf4d78a93328f58dd06bfa_Out_0_Vector3 = float3(float(0), float(0), float(1));
        float _Property_e4cf7b886c5d4008b4d19bb5281eab91_Out_0_Float = _Input_Flatness;
        float3 _Lerp_be915237183140fab80bd249c1f18291_Out_3_Vector3;
        Unity_Lerp_float3(_Property_da3b89567e634fa6a223a4aaf0f855a8_Out_0_Vector3, _Vector3_697e2eeaaaaf4d78a93328f58dd06bfa_Out_0_Vector3, (_Property_e4cf7b886c5d4008b4d19bb5281eab91_Out_0_Float.xxx), _Lerp_be915237183140fab80bd249c1f18291_Out_3_Vector3);
        Out_Vector4_1 = _Lerp_be915237183140fab80bd249c1f18291_Out_3_Vector3;
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
            float4 _Property_43b0513665f64c5788d1f8f9b66268b0_Out_0_Vector4 = _Water_color;
            float4 _Property_e51710da9002445f864e7f6b0ae7c280_Out_0_Vector4 = _Water_color_deep;
            float _Property_d4d1a9c046824da382efe396dddf53b0_Out_0_Float = _Fade_distance_color;
            Bindings_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5;
            _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5.ScreenPosition = IN.ScreenPosition;
            _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5.NDCPosition = IN.NDCPosition;
            float4 _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5_Output_0_Vector4;
            SG_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float(_Property_d4d1a9c046824da382efe396dddf53b0_Out_0_Float, _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5, _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5_Output_0_Vector4);
            float4 _Lerp_94679fa3491f467684be9ff758a55d18_Out_3_Vector4;
            Unity_Lerp_float4(_Property_43b0513665f64c5788d1f8f9b66268b0_Out_0_Vector4, _Property_e51710da9002445f864e7f6b0ae7c280_Out_0_Vector4, _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5_Output_0_Vector4, _Lerp_94679fa3491f467684be9ff758a55d18_Out_3_Vector4);
            float4 _Property_f0a99b264fd34c2c8639c7af81725d40_Out_0_Vector4 = _line_color;
            float4 _UV_f973d15371ed43d68c2d790519a7c049_Out_0_Vector4 = IN.uv0;
            float4 _ChannelMask_de1cf82bedf447d1b6d8b9b18ca9bb13_Out_1_Vector4;
            Unity_ChannelMask_Green_float4 (_UV_f973d15371ed43d68c2d790519a7c049_Out_0_Vector4, _ChannelMask_de1cf82bedf447d1b6d8b9b18ca9bb13_Out_1_Vector4);
            float _Property_534fe33381254583b6b1befa0dc13246_Out_0_Float = _uv_fade;
            float4 _Multiply_ef93cbef5e614eff9e1fb9f97ee0d695_Out_2_Vector4;
            Unity_Multiply_float4_float4(_ChannelMask_de1cf82bedf447d1b6d8b9b18ca9bb13_Out_1_Vector4, (_Property_534fe33381254583b6b1befa0dc13246_Out_0_Float.xxxx), _Multiply_ef93cbef5e614eff9e1fb9f97ee0d695_Out_2_Vector4);
            UnityTexture2D _Property_95c5af2ee0fe418cbdf7161c9ba2440c_Out_0_Texture2D = UnityBuildTexture2DStructNoScale(_lines_main_tex);
            float _Property_8f943f1a1d6c439cba8d7cc7a0d178bb_Out_0_Float = _lines_main_scale_X;
            float _Property_33610de87cc64ef781360df2f29e6927_Out_0_Float = _line_scale_width;
            float4 _UV_0d8fd150812c4fd8924aeed78f2634b0_Out_0_Vector4 = IN.uv0;
            float4 _ChannelMask_eb198748341c44908ec268928a0cd5e1_Out_1_Vector4;
            Unity_ChannelMask_Red_float4 (_UV_0d8fd150812c4fd8924aeed78f2634b0_Out_0_Vector4, _ChannelMask_eb198748341c44908ec268928a0cd5e1_Out_1_Vector4);
            float4 _Multiply_3dc9e119d43443419e4aff06aff35de3_Out_2_Vector4;
            Unity_Multiply_float4_float4((_Property_33610de87cc64ef781360df2f29e6927_Out_0_Float.xxxx), _ChannelMask_eb198748341c44908ec268928a0cd5e1_Out_1_Vector4, _Multiply_3dc9e119d43443419e4aff06aff35de3_Out_2_Vector4);
            float4 _ChannelMask_19706ee76bce4d6fb9cb46094d13a511_Out_1_Vector4;
            Unity_ChannelMask_Green_float4 (_UV_0d8fd150812c4fd8924aeed78f2634b0_Out_0_Vector4, _ChannelMask_19706ee76bce4d6fb9cb46094d13a511_Out_1_Vector4);
            float _Property_7977d36e594e40d0a969f1d4a645d10e_Out_0_Float = _line_acceleration;
            float4 _Power_71e7adc33473482ea33c788e4664b10e_Out_2_Vector4;
            Unity_Power_float4(_ChannelMask_19706ee76bce4d6fb9cb46094d13a511_Out_1_Vector4, (_Property_7977d36e594e40d0a969f1d4a645d10e_Out_0_Float.xxxx), _Power_71e7adc33473482ea33c788e4664b10e_Out_2_Vector4);
            float4 _Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4;
            Unity_Add_float4(_Multiply_3dc9e119d43443419e4aff06aff35de3_Out_2_Vector4, _Power_71e7adc33473482ea33c788e4664b10e_Out_2_Vector4, _Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4);
            float4 _ChannelMask_74f4f7024a354a8daea19c3a0c9ea971_Out_1_Vector4;
            Unity_ChannelMask_Red_float4 (_Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4, _ChannelMask_74f4f7024a354a8daea19c3a0c9ea971_Out_1_Vector4);
            float4 _Multiply_a4c7b1aa4bbc4e299400dfe171cfcca2_Out_2_Vector4;
            Unity_Multiply_float4_float4((_Property_8f943f1a1d6c439cba8d7cc7a0d178bb_Out_0_Float.xxxx), _ChannelMask_74f4f7024a354a8daea19c3a0c9ea971_Out_1_Vector4, _Multiply_a4c7b1aa4bbc4e299400dfe171cfcca2_Out_2_Vector4);
            float4 _ChannelMask_16f9f46097254be3ade331e591a393ff_Out_1_Vector4;
            Unity_ChannelMask_Green_float4 (_Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4, _ChannelMask_16f9f46097254be3ade331e591a393ff_Out_1_Vector4);
            float _Property_8f2c7658224541e09a8c1b935f403b77_Out_0_Float = _lines_main_speed;
            float _Multiply_2964fdbce8b34a018e78584bf3dee7f4_Out_2_Float;
            Unity_Multiply_float_float(IN.TimeParameters.x, _Property_8f2c7658224541e09a8c1b935f403b77_Out_0_Float, _Multiply_2964fdbce8b34a018e78584bf3dee7f4_Out_2_Float);
            float4 _Subtract_75b080f7b090418aafc460aee6afdff9_Out_2_Vector4;
            Unity_Subtract_float4(_ChannelMask_16f9f46097254be3ade331e591a393ff_Out_1_Vector4, (_Multiply_2964fdbce8b34a018e78584bf3dee7f4_Out_2_Float.xxxx), _Subtract_75b080f7b090418aafc460aee6afdff9_Out_2_Vector4);
            float _Property_0b134d0fa3674d1dacae3b67c1e3ccd1_Out_0_Float = _lines_main_scale_Y;
            float4 _Multiply_35985ccfc709431cafe74d766d31d156_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Subtract_75b080f7b090418aafc460aee6afdff9_Out_2_Vector4, (_Property_0b134d0fa3674d1dacae3b67c1e3ccd1_Out_0_Float.xxxx), _Multiply_35985ccfc709431cafe74d766d31d156_Out_2_Vector4);
            float4 _Add_cab58967aa234b218161c4a09a035166_Out_2_Vector4;
            Unity_Add_float4(_Multiply_a4c7b1aa4bbc4e299400dfe171cfcca2_Out_2_Vector4, _Multiply_35985ccfc709431cafe74d766d31d156_Out_2_Vector4, _Add_cab58967aa234b218161c4a09a035166_Out_2_Vector4);
            float4 _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(_Property_95c5af2ee0fe418cbdf7161c9ba2440c_Out_0_Texture2D.tex, _Property_95c5af2ee0fe418cbdf7161c9ba2440c_Out_0_Texture2D.samplerstate, _Property_95c5af2ee0fe418cbdf7161c9ba2440c_Out_0_Texture2D.GetTransformedUV((_Add_cab58967aa234b218161c4a09a035166_Out_2_Vector4.xy)) );
            float _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_R_4_Float = _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4.r;
            float _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_G_5_Float = _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4.g;
            float _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_B_6_Float = _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4.b;
            float _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_A_7_Float = _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4.a;
            float4 _Multiply_8ed597f81bae4bae8725212db9d80190_Out_2_Vector4;
            Unity_Multiply_float4_float4(_SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4, float4(2, 2, 2, 2), _Multiply_8ed597f81bae4bae8725212db9d80190_Out_2_Vector4);
            float _Property_cc4358b701974681a1d957a4fb4f38c3_Out_0_Float = _Lines_secondary_scale_X;
            float4 _ChannelMask_f091e0a4e8f54629bc32ec7fb0d7098d_Out_1_Vector4;
            Unity_ChannelMask_Red_float4 (_Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4, _ChannelMask_f091e0a4e8f54629bc32ec7fb0d7098d_Out_1_Vector4);
            float4 _Multiply_42157befa0c44bee84c7175dd6d63162_Out_2_Vector4;
            Unity_Multiply_float4_float4((_Property_cc4358b701974681a1d957a4fb4f38c3_Out_0_Float.xxxx), _ChannelMask_f091e0a4e8f54629bc32ec7fb0d7098d_Out_1_Vector4, _Multiply_42157befa0c44bee84c7175dd6d63162_Out_2_Vector4);
            float4 _ChannelMask_17fc17cacb0047bda79edcf51a6e35da_Out_1_Vector4;
            Unity_ChannelMask_Green_float4 (_Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4, _ChannelMask_17fc17cacb0047bda79edcf51a6e35da_Out_1_Vector4);
            float _Property_e05be2924452414fa2ff6b9d19e0de93_Out_0_Float = _time_secondary_speed;
            float _Multiply_c7f664544ff5492db2bc2721eeebcff8_Out_2_Float;
            Unity_Multiply_float_float(IN.TimeParameters.x, _Property_e05be2924452414fa2ff6b9d19e0de93_Out_0_Float, _Multiply_c7f664544ff5492db2bc2721eeebcff8_Out_2_Float);
            float4 _Subtract_a949c19f1b434d0695669e68938e2434_Out_2_Vector4;
            Unity_Subtract_float4(_ChannelMask_17fc17cacb0047bda79edcf51a6e35da_Out_1_Vector4, (_Multiply_c7f664544ff5492db2bc2721eeebcff8_Out_2_Float.xxxx), _Subtract_a949c19f1b434d0695669e68938e2434_Out_2_Vector4);
            float _Property_c8d4ab07e0d14394adf6a43094e0b983_Out_0_Float = _lines_Secondary_scale_Y;
            float4 _Multiply_8800c918948a433e99eb661352fd4212_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Subtract_a949c19f1b434d0695669e68938e2434_Out_2_Vector4, (_Property_c8d4ab07e0d14394adf6a43094e0b983_Out_0_Float.xxxx), _Multiply_8800c918948a433e99eb661352fd4212_Out_2_Vector4);
            float4 _Add_2fda74c7055542548564bb348089f036_Out_2_Vector4;
            Unity_Add_float4(_Multiply_42157befa0c44bee84c7175dd6d63162_Out_2_Vector4, _Multiply_8800c918948a433e99eb661352fd4212_Out_2_Vector4, _Add_2fda74c7055542548564bb348089f036_Out_2_Vector4);
            float4 _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(UnityBuildTexture2DStructNoScale(_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D).tex, UnityBuildTexture2DStructNoScale(_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D).samplerstate, UnityBuildTexture2DStructNoScale(_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D).GetTransformedUV((_Add_2fda74c7055542548564bb348089f036_Out_2_Vector4.xy)) );
            float _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_R_4_Float = _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4.r;
            float _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_G_5_Float = _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4.g;
            float _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_B_6_Float = _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4.b;
            float _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_A_7_Float = _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4.a;
            float4 _Multiply_306905e98270411494f05439be90d579_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Multiply_8ed597f81bae4bae8725212db9d80190_Out_2_Vector4, _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4, _Multiply_306905e98270411494f05439be90d579_Out_2_Vector4);
            float _Float_14dd549b73b14affbb7da96db1116986_Out_0_Float = float(2);
            float4 _Multiply_39c13e7bf4d54596aae047aaac49c0e2_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Multiply_306905e98270411494f05439be90d579_Out_2_Vector4, (_Float_14dd549b73b14affbb7da96db1116986_Out_0_Float.xxxx), _Multiply_39c13e7bf4d54596aae047aaac49c0e2_Out_2_Vector4);
            float4 _Add_fcd3caf1b3774b55b4761493c4ac1625_Out_2_Vector4;
            Unity_Add_float4(_Multiply_ef93cbef5e614eff9e1fb9f97ee0d695_Out_2_Vector4, _Multiply_39c13e7bf4d54596aae047aaac49c0e2_Out_2_Vector4, _Add_fcd3caf1b3774b55b4761493c4ac1625_Out_2_Vector4);
            float4 _Saturate_b7dc9e7f380d4fabbd5d359bce8357e8_Out_1_Vector4;
            Unity_Saturate_float4(_Add_fcd3caf1b3774b55b4761493c4ac1625_Out_2_Vector4, _Saturate_b7dc9e7f380d4fabbd5d359bce8357e8_Out_1_Vector4);
            float _Property_9edfccb536454a8d8a2d8ad48c42167a_Out_0_Float = _line_threshold;
            float _OneMinus_5bba03c9ff974914b63bc52b5923cb65_Out_1_Float;
            Unity_OneMinus_float(_Property_9edfccb536454a8d8a2d8ad48c42167a_Out_0_Float, _OneMinus_5bba03c9ff974914b63bc52b5923cb65_Out_1_Float);
            float4 _Add_e016add5650b48438b7c1c2625e5cffe_Out_2_Vector4;
            Unity_Add_float4(_Saturate_b7dc9e7f380d4fabbd5d359bce8357e8_Out_1_Vector4, (_OneMinus_5bba03c9ff974914b63bc52b5923cb65_Out_1_Float.xxxx), _Add_e016add5650b48438b7c1c2625e5cffe_Out_2_Vector4);
            float4 _Saturate_7f657c8db2094d6c8ae40e095ac83ebd_Out_1_Vector4;
            Unity_Saturate_float4(_Add_e016add5650b48438b7c1c2625e5cffe_Out_2_Vector4, _Saturate_7f657c8db2094d6c8ae40e095ac83ebd_Out_1_Vector4);
            float4 _Floor_a4e91b5788a44b91a680580e3af68c38_Out_1_Vector4;
            Unity_Floor_float4(_Saturate_7f657c8db2094d6c8ae40e095ac83ebd_Out_1_Vector4, _Floor_a4e91b5788a44b91a680580e3af68c38_Out_1_Vector4);
            float4 _Lerp_9841dd6d2bd04e42b4cb57b33d0fe35a_Out_3_Vector4;
            Unity_Lerp_float4(_Lerp_94679fa3491f467684be9ff758a55d18_Out_3_Vector4, _Property_f0a99b264fd34c2c8639c7af81725d40_Out_0_Vector4, _Floor_a4e91b5788a44b91a680580e3af68c38_Out_1_Vector4, _Lerp_9841dd6d2bd04e42b4cb57b33d0fe35a_Out_3_Vector4);
            float4 _Add_4583e01988024b38998ac5e9c5a0d399_Out_2_Vector4;
            Unity_Add_float4(_Lerp_9841dd6d2bd04e42b4cb57b33d0fe35a_Out_3_Vector4, float4(0, 0, 0, 0), _Add_4583e01988024b38998ac5e9c5a0d399_Out_2_Vector4);
            float4 Color_1a97f4e858eb4c6d841021e72c5d3d64 = IsGammaSpace() ? float4(0, 0, 1, 1) : float4(SRGBToLinear(float3(0, 0, 1)), 1);
            float4 _ChannelMask_cf7ae72a728a44c08f15e60d9d26f0c3_Out_1_Vector4;
            Unity_ChannelMask_RedGreen_float4 (Color_1a97f4e858eb4c6d841021e72c5d3d64, _ChannelMask_cf7ae72a728a44c08f15e60d9d26f0c3_Out_1_Vector4);
            float _Float_00a4dadc48e1434288ce763bd643ad66_Out_0_Float = float(-0.5);
            float4 _Add_5e0bee7b7ac74672a7065961046451ee_Out_2_Vector4;
            Unity_Add_float4(_ChannelMask_cf7ae72a728a44c08f15e60d9d26f0c3_Out_1_Vector4, (_Float_00a4dadc48e1434288ce763bd643ad66_Out_0_Float.xxxx), _Add_5e0bee7b7ac74672a7065961046451ee_Out_2_Vector4);
            float _Float_1ccf8060dd92444dabe1369d4427d2e4_Out_0_Float = float(2);
            float4 _Multiply_92f5b69c104742a48468b928199b995f_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Add_5e0bee7b7ac74672a7065961046451ee_Out_2_Vector4, (_Float_1ccf8060dd92444dabe1369d4427d2e4_Out_0_Float.xxxx), _Multiply_92f5b69c104742a48468b928199b995f_Out_2_Vector4);
            float4 _UV_1a14460a201d4ae280a1eaa3563a82b7_Out_0_Vector4 = IN.uv0;
            float _Property_4aa4fa4ca33944418b3b63c25d1e222b_Out_0_Float = _tiling_large;
            float4 _Multiply_00173f44df554c4c969653140dae9159_Out_2_Vector4;
            Unity_Multiply_float4_float4(_UV_1a14460a201d4ae280a1eaa3563a82b7_Out_0_Vector4, (_Property_4aa4fa4ca33944418b3b63c25d1e222b_Out_0_Float.xxxx), _Multiply_00173f44df554c4c969653140dae9159_Out_2_Vector4);
            float4 _Add_dbbed777fe52417cb0b11fea42873d5c_Out_2_Vector4;
            Unity_Add_float4(_Multiply_92f5b69c104742a48468b928199b995f_Out_2_Vector4, _Multiply_00173f44df554c4c969653140dae9159_Out_2_Vector4, _Add_dbbed777fe52417cb0b11fea42873d5c_Out_2_Vector4);
            float4 _Add_4895008d45c549298ecf708d275da180_Out_2_Vector4;
            Unity_Add_float4(_Add_dbbed777fe52417cb0b11fea42873d5c_Out_2_Vector4, float4(0, 0, 0, 0), _Add_4895008d45c549298ecf708d275da180_Out_2_Vector4);
            Bindings_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float _SubGCustomRotator_ff07215028f84162b5c948c659cda1d4;
            float4 _SubGCustomRotator_ff07215028f84162b5c948c659cda1d4_OutVector4_1_Vector4;
            SG_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float(float2 (0, 0), (_Add_4895008d45c549298ecf708d275da180_Out_2_Vector4.xy), float(0), _SubGCustomRotator_ff07215028f84162b5c948c659cda1d4, _SubGCustomRotator_ff07215028f84162b5c948c659cda1d4_OutVector4_1_Vector4);
            float4 _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(UnityBuildTexture2DStructNoScale(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D).tex, UnityBuildTexture2DStructNoScale(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D).samplerstate, UnityBuildTexture2DStructNoScale(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D).GetTransformedUV((_SubGCustomRotator_ff07215028f84162b5c948c659cda1d4_OutVector4_1_Vector4.xy)) );
            _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.rgb = UnpackNormal(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4);
            float _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_R_4_Float = _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.r;
            float _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_G_5_Float = _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.g;
            float _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_B_6_Float = _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.b;
            float _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_A_7_Float = _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.a;
            float _Property_4c9962eaf54d4fb3b90d837f8a1e5135_Out_0_Float = _wave_large_normal_Strength;
            Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float _SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b;
            float3 _SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b_OutVector4_1_Vector3;
            SG_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float((_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.xyz), _Property_4c9962eaf54d4fb3b90d837f8a1e5135_Out_0_Float, _SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b, _SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b_OutVector4_1_Vector3);
            float4 _UV_7ecffc16ac6f4a6e8d6c9e15e019656a_Out_0_Vector4 = IN.uv0;
            float _Property_73d9afc5f3a3482fbb0913474af39ad9_Out_0_Float = _tiling_small;
            float4 _Multiply_382b99d1983f404aa8578fe246e8927d_Out_2_Vector4;
            Unity_Multiply_float4_float4(_UV_7ecffc16ac6f4a6e8d6c9e15e019656a_Out_0_Vector4, (_Property_73d9afc5f3a3482fbb0913474af39ad9_Out_0_Float.xxxx), _Multiply_382b99d1983f404aa8578fe246e8927d_Out_2_Vector4);
            float4 _Add_4ab28b643d854a368642d90a0ec0a075_Out_2_Vector4;
            Unity_Add_float4(_Multiply_92f5b69c104742a48468b928199b995f_Out_2_Vector4, _Multiply_382b99d1983f404aa8578fe246e8927d_Out_2_Vector4, _Add_4ab28b643d854a368642d90a0ec0a075_Out_2_Vector4);
            float2 _Vector2_0bc73a0cd1db49c884aa8967bc3e95d7_Out_0_Vector2 = float2(float(0), float(-2));
            float2 _Multiply_33854325de694851a4a01b1c6ac404cd_Out_2_Vector2;
            Unity_Multiply_float2_float2((IN.TimeParameters.x.xx), _Vector2_0bc73a0cd1db49c884aa8967bc3e95d7_Out_0_Vector2, _Multiply_33854325de694851a4a01b1c6ac404cd_Out_2_Vector2);
            float2 _Add_65717e3b5ba745769f124b49f3258b8f_Out_2_Vector2;
            Unity_Add_float2((_Add_4ab28b643d854a368642d90a0ec0a075_Out_2_Vector4.xy), _Multiply_33854325de694851a4a01b1c6ac404cd_Out_2_Vector2, _Add_65717e3b5ba745769f124b49f3258b8f_Out_2_Vector2);
            Bindings_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float _SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d;
            float4 _SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d_OutVector4_1_Vector4;
            SG_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float(float2 (0, 0), _Add_65717e3b5ba745769f124b49f3258b8f_Out_2_Vector2, float(0), _SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d, _SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d_OutVector4_1_Vector4);
            float4 _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(UnityBuildTexture2DStructNoScale(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D).tex, UnityBuildTexture2DStructNoScale(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D).samplerstate, UnityBuildTexture2DStructNoScale(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D).GetTransformedUV((_SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d_OutVector4_1_Vector4.xy)) );
            _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.rgb = UnpackNormal(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4);
            float _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_R_4_Float = _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.r;
            float _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_G_5_Float = _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.g;
            float _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_B_6_Float = _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.b;
            float _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_A_7_Float = _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.a;
            float _Property_a009c1b918b44c69b87d232216fb1476_Out_0_Float = _wave_small_normal_strength;
            Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21;
            float3 _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21_OutVector4_1_Vector3;
            SG_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float((_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.xyz), _Property_a009c1b918b44c69b87d232216fb1476_Out_0_Float, _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21, _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21_OutVector4_1_Vector3);
            float _Float_2567a353822f42709058c4132980ef56_Out_0_Float = float(0.5);
            float3 _Lerp_ee622e31b20c45db9e4a8c2f7c465980_Out_3_Vector3;
            Unity_Lerp_float3(_SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b_OutVector4_1_Vector3, _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21_OutVector4_1_Vector3, (_Float_2567a353822f42709058c4132980ef56_Out_0_Float.xxx), _Lerp_ee622e31b20c45db9e4a8c2f7c465980_Out_3_Vector3);
            float _Float_3b99d1827ec64b9382aced15b0c47fdc_Out_0_Float = float(1);
            Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float _SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00;
            float3 _SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00_OutVector4_1_Vector3;
            SG_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float(_Lerp_ee622e31b20c45db9e4a8c2f7c465980_Out_3_Vector3, _Float_3b99d1827ec64b9382aced15b0c47fdc_Out_0_Float, _SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00, _SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00_OutVector4_1_Vector3);
            float3 _Lerp_30afc261e4fa44aa87e3e7d36fe6d0cf_Out_3_Vector3;
            Unity_Lerp_float3(_SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00_OutVector4_1_Vector3, _Lerp_ee622e31b20c45db9e4a8c2f7c465980_Out_3_Vector3, float3(0, 0, 0), _Lerp_30afc261e4fa44aa87e3e7d36fe6d0cf_Out_3_Vector3);
            surface.BaseColor = (_Add_4583e01988024b38998ac5e9c5a0d399_Out_2_Vector4.xyz);
            surface.NormalTS = _Lerp_30afc261e4fa44aa87e3e7d36fe6d0cf_Out_3_Vector3;
            surface.Emission = float3(0, 0, 0);
            surface.Metallic = float(0);
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
        
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/PBRForwardPass.hlsl"
        
        // --------------------------------------------------
        #ifdef HAVE_VFX_MODIFICATION
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
        #endif
        
        ENDHLSL
        }
        Pass
        {
            Name "GBuffer"
            Tags
            {
                "LightMode" = "UniversalGBuffer"
            }
            
        Cull [_Cull]
        Blend [_SrcBlend] [_DstBlend]
        ZTest [_ZTest]
        ZWrite [_ZWrite]
   
        HLSLPROGRAM
        
        #pragma target 4.5
        #pragma exclude_renderers gles gles3 glcore
        #pragma multi_compile_instancing
        #pragma multi_compile_fog
        #pragma instancing_options renderinglayer
        #pragma vertex vert
        #pragma fragment frag
        
        #pragma multi_compile _ LIGHTMAP_ON
        #pragma multi_compile _ DYNAMICLIGHTMAP_ON
        #pragma multi_compile _ DIRLIGHTMAP_COMBINED
        #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
        #pragma multi_compile_fragment _ _REFLECTION_PROBE_BLENDING
        #pragma multi_compile_fragment _ _REFLECTION_PROBE_BOX_PROJECTION
        #pragma multi_compile_fragment _ _SHADOWS_SOFT _SHADOWS_SOFT_LOW _SHADOWS_SOFT_MEDIUM _SHADOWS_SOFT_HIGH
        #pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
        #pragma multi_compile _ SHADOWS_SHADOWMASK
        #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
        #pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
        #pragma multi_compile_fragment _ _GBUFFER_NORMALS_OCT
        #pragma multi_compile_fragment _ _RENDER_PASS_ENABLED
        #pragma multi_compile_fragment _ DEBUG_DISPLAY
        #pragma shader_feature_fragment _ _SURFACE_TYPE_TRANSPARENT
        #pragma shader_feature_local_fragment _ _ALPHAPREMULTIPLY_ON
        #pragma shader_feature_local_fragment _ _ALPHAMODULATE_ON
        #pragma shader_feature_local_fragment _ _ALPHATEST_ON
        #pragma shader_feature_local_fragment _ _SPECULAR_SETUP
        #pragma shader_feature_local _ _RECEIVE_SHADOWS_OFF

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
      
        #define SHADERPASS SHADERPASS_GBUFFER
        #define _FOG_FRAGMENT 1
        #define REQUIRE_DEPTH_TEXTURE
  
        #include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
        #include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
        #include_with_pragmas "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRenderingKeywords.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/FoveatedRendering.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DBuffer.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
       
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
        
        CBUFFER_START(UnityPerMaterial)
        float4 _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D_TexelSize;
        float4 _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D_TexelSize;
        float4 _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D_TexelSize;
        float4 _Water_color_deep;
        float4 _Water_color;
        float _Fade_distance_color;
        float _line_scale_width;
        float _line_acceleration;
        float _lines_main_scale_Y;
        float _lines_main_scale_X;
        float _lines_main_speed;
        float4 _lines_main_tex_TexelSize;
        float _Lines_secondary_scale_X;
        float _time_secondary_speed;
        float _lines_Secondary_scale_Y;
        float _line_threshold;
        float _uv_fade;
        float4 _line_color;
        float4 _Rough_mask_TexelSize;
        float _roughness;
        float _rough_contrast;
        float _WPO_Speed;
        float _WPO_Tiling;
        float _tiling_large;
        float _wave_large_normal_Strength;
        float _tiling_small;
        float _wave_small_normal_strength;

        CBUFFER_END
     
        SAMPLER(SamplerState_Linear_Repeat);
        TEXTURE2D(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D);
        SAMPLER(sampler_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D);
        TEXTURE2D(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D);
        SAMPLER(sampler_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D);
        TEXTURE2D(_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D);
        SAMPLER(sampler_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D);
        TEXTURE2D(_lines_main_tex);
        SAMPLER(sampler_lines_main_tex);
        TEXTURE2D(_Rough_mask);
        SAMPLER(sampler_Rough_mask);
     
        #ifdef SCENEPICKINGPASS
        float4 _SelectionID;
        #endif

        #ifdef SCENESELECTIONPASS
        int _ObjectId;
        int _PassValue;
        #endif
   
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
        
        void Unity_Lerp_float4(float4 A, float4 B, float4 T, out float4 Out)
        {
            Out = lerp(A, B, T);
        }
        
        void Unity_ChannelMask_Green_float4 (float4 In, out float4 Out)
        {
            Out = float4(0, In.g, 0, 0);
        }
        
        void Unity_Multiply_float4_float4(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }
        
        void Unity_ChannelMask_Red_float4 (float4 In, out float4 Out)
        {
            Out = float4(In.r, 0, 0, 0);
        }
        
        void Unity_Power_float4(float4 A, float4 B, out float4 Out)
        {
            Out = pow(A, B);
        }
        
        void Unity_Add_float4(float4 A, float4 B, out float4 Out)
        {
            Out = A + B;
        }
        
        void Unity_Multiply_float_float(float A, float B, out float Out)
        {
            Out = A * B;
        }
        
        void Unity_Subtract_float4(float4 A, float4 B, out float4 Out)
        {
            Out = A - B;
        }
        
        void Unity_Saturate_float4(float4 In, out float4 Out)
        {
            Out = saturate(In);
        }
        
        void Unity_OneMinus_float(float In, out float Out)
        {
            Out = 1 - In;
        }
        
        void Unity_Floor_float4(float4 In, out float4 Out)
        {
            Out = floor(In);
        }
        
        void Unity_ChannelMask_RedGreen_float4 (float4 In, out float4 Out)
        {
            Out = float4(In.r, In.g, 0, 0);
        }
        
        void Unity_Multiply_float2_float2(float2 A, float2 B, out float2 Out)
        {
        Out = A * B;
        }
        
        void Unity_Add_float2(float2 A, float2 B, out float2 Out)
        {
            Out = A + B;
        }
        
        void Unity_Cosine_float(float In, out float Out)
        {
            Out = cos(In);
        }
        
        void Unity_Sine_float(float In, out float Out)
        {
            Out = sin(In);
        }
        
        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }
        
        void Unity_DotProduct_float2(float2 A, float2 B, out float Out)
        {
            Out = dot(A, B);
        }
        
        struct Bindings_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float
        {
        };
        
        void SG_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float(float2 _RotationCenter, float2 _UVs, float _Rotation_Angle_0_1, Bindings_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float IN, out float4 OutVector4_1)
        {
        float2 _Property_6b8858fb6b28462c918c80ac9112d227_Out_0_Vector2 = _RotationCenter;
        float _Float_837e06e61252474386fa567fd343eb71_Out_0_Float = float(-1);
        float2 _Multiply_83b9ee383b5941709dfde9d52c3af917_Out_2_Vector2;
        Unity_Multiply_float2_float2(_Property_6b8858fb6b28462c918c80ac9112d227_Out_0_Vector2, (_Float_837e06e61252474386fa567fd343eb71_Out_0_Float.xx), _Multiply_83b9ee383b5941709dfde9d52c3af917_Out_2_Vector2);
        float2 _Property_294f3c7837c44761a037c9364bbeb91d_Out_0_Vector2 = _UVs;
        float2 _Add_3afafe14e3c844509fa747e9f33d0743_Out_2_Vector2;
        Unity_Add_float2(_Multiply_83b9ee383b5941709dfde9d52c3af917_Out_2_Vector2, _Property_294f3c7837c44761a037c9364bbeb91d_Out_0_Vector2, _Add_3afafe14e3c844509fa747e9f33d0743_Out_2_Vector2);
        float _Property_db8e8068e21446e3a3bfd4ca47e145f1_Out_0_Float = _Rotation_Angle_0_1;
        float _Cosine_296ae596397f49d9a6353cd13c5a4065_Out_1_Float;
        Unity_Cosine_float(_Property_db8e8068e21446e3a3bfd4ca47e145f1_Out_0_Float, _Cosine_296ae596397f49d9a6353cd13c5a4065_Out_1_Float);
        float _Sine_56b799a343d04818b655a5f52d79442f_Out_1_Float;
        Unity_Sine_float(_Property_db8e8068e21446e3a3bfd4ca47e145f1_Out_0_Float, _Sine_56b799a343d04818b655a5f52d79442f_Out_1_Float);
        float _Float_d59d60e890164f0f8472c97198167085_Out_0_Float = float(-1);
        float _Multiply_388ac2ddd64141e4a3fa3684cf5d9504_Out_2_Float;
        Unity_Multiply_float_float(_Sine_56b799a343d04818b655a5f52d79442f_Out_1_Float, _Float_d59d60e890164f0f8472c97198167085_Out_0_Float, _Multiply_388ac2ddd64141e4a3fa3684cf5d9504_Out_2_Float);
        float _Add_c40cf003951e433b86b3cde03c5eadb3_Out_2_Float;
        Unity_Add_float(_Cosine_296ae596397f49d9a6353cd13c5a4065_Out_1_Float, _Multiply_388ac2ddd64141e4a3fa3684cf5d9504_Out_2_Float, _Add_c40cf003951e433b86b3cde03c5eadb3_Out_2_Float);
        float _DotProduct_d1e961f7f43c4406b995e327c26f71a5_Out_2_Float;
        Unity_DotProduct_float2(_Add_3afafe14e3c844509fa747e9f33d0743_Out_2_Vector2, (_Add_c40cf003951e433b86b3cde03c5eadb3_Out_2_Float.xx), _DotProduct_d1e961f7f43c4406b995e327c26f71a5_Out_2_Float);
        float _Add_78a2abd0a43e42b7ae6e2c18213291b9_Out_2_Float;
        Unity_Add_float(_Sine_56b799a343d04818b655a5f52d79442f_Out_1_Float, _Cosine_296ae596397f49d9a6353cd13c5a4065_Out_1_Float, _Add_78a2abd0a43e42b7ae6e2c18213291b9_Out_2_Float);
        float _DotProduct_44875e243e6c4aafae36318025418586_Out_2_Float;
        Unity_DotProduct_float2(_Add_3afafe14e3c844509fa747e9f33d0743_Out_2_Vector2, (_Add_78a2abd0a43e42b7ae6e2c18213291b9_Out_2_Float.xx), _DotProduct_44875e243e6c4aafae36318025418586_Out_2_Float);
        float _Add_16c535c220da42e7adc575091e5a606c_Out_2_Float;
        Unity_Add_float(_DotProduct_d1e961f7f43c4406b995e327c26f71a5_Out_2_Float, _DotProduct_44875e243e6c4aafae36318025418586_Out_2_Float, _Add_16c535c220da42e7adc575091e5a606c_Out_2_Float);
        float2 _Add_d1fc380d358b40febdf860ef126c9433_Out_2_Vector2;
        Unity_Add_float2(_Property_6b8858fb6b28462c918c80ac9112d227_Out_0_Vector2, (_Add_16c535c220da42e7adc575091e5a606c_Out_2_Float.xx), _Add_d1fc380d358b40febdf860ef126c9433_Out_2_Vector2);
        OutVector4_1 = (float4(_Add_d1fc380d358b40febdf860ef126c9433_Out_2_Vector2, 0.0, 1.0));
        }
        
        void Unity_Lerp_float3(float3 A, float3 B, float3 T, out float3 Out)
        {
            Out = lerp(A, B, T);
        }
        
        struct Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float
        {
        };
        
        void SG_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float(float3 _Input_Normal, float _Input_Flatness, Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float IN, out float3 Out_Vector4_1)
        {
        float3 _Property_da3b89567e634fa6a223a4aaf0f855a8_Out_0_Vector3 = _Input_Normal;
        float3 _Vector3_697e2eeaaaaf4d78a93328f58dd06bfa_Out_0_Vector3 = float3(float(0), float(0), float(1));
        float _Property_e4cf7b886c5d4008b4d19bb5281eab91_Out_0_Float = _Input_Flatness;
        float3 _Lerp_be915237183140fab80bd249c1f18291_Out_3_Vector3;
        Unity_Lerp_float3(_Property_da3b89567e634fa6a223a4aaf0f855a8_Out_0_Vector3, _Vector3_697e2eeaaaaf4d78a93328f58dd06bfa_Out_0_Vector3, (_Property_e4cf7b886c5d4008b4d19bb5281eab91_Out_0_Float.xxx), _Lerp_be915237183140fab80bd249c1f18291_Out_3_Vector3);
        Out_Vector4_1 = _Lerp_be915237183140fab80bd249c1f18291_Out_3_Vector3;
        }
    
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

        #ifdef FEATURES_GRAPH_VERTEX
        Varyings CustomInterpolatorPassThroughFunc(inout Varyings output, VertexDescription input)
        {
        return output;
        }
        #define CUSTOMINTERPOLATOR_VARYPASSTHROUGH_FUNC
        #endif

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
            float4 _Property_43b0513665f64c5788d1f8f9b66268b0_Out_0_Vector4 = _Water_color;
            float4 _Property_e51710da9002445f864e7f6b0ae7c280_Out_0_Vector4 = _Water_color_deep;
            float _Property_d4d1a9c046824da382efe396dddf53b0_Out_0_Float = _Fade_distance_color;
            Bindings_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5;
            _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5.ScreenPosition = IN.ScreenPosition;
            _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5.NDCPosition = IN.NDCPosition;
            float4 _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5_Output_0_Vector4;
            SG_SubGDepthFade_64aa9b60ceb938b47a43663780795280_float(_Property_d4d1a9c046824da382efe396dddf53b0_Out_0_Float, _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5, _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5_Output_0_Vector4);
            float4 _Lerp_94679fa3491f467684be9ff758a55d18_Out_3_Vector4;
            Unity_Lerp_float4(_Property_43b0513665f64c5788d1f8f9b66268b0_Out_0_Vector4, _Property_e51710da9002445f864e7f6b0ae7c280_Out_0_Vector4, _SubGDepthFade_1b35b5ac26014c79ada16b36f856efa5_Output_0_Vector4, _Lerp_94679fa3491f467684be9ff758a55d18_Out_3_Vector4);
            float4 _Property_f0a99b264fd34c2c8639c7af81725d40_Out_0_Vector4 = _line_color;
            float4 _UV_f973d15371ed43d68c2d790519a7c049_Out_0_Vector4 = IN.uv0;
            float4 _ChannelMask_de1cf82bedf447d1b6d8b9b18ca9bb13_Out_1_Vector4;
            Unity_ChannelMask_Green_float4 (_UV_f973d15371ed43d68c2d790519a7c049_Out_0_Vector4, _ChannelMask_de1cf82bedf447d1b6d8b9b18ca9bb13_Out_1_Vector4);
            float _Property_534fe33381254583b6b1befa0dc13246_Out_0_Float = _uv_fade;
            float4 _Multiply_ef93cbef5e614eff9e1fb9f97ee0d695_Out_2_Vector4;
            Unity_Multiply_float4_float4(_ChannelMask_de1cf82bedf447d1b6d8b9b18ca9bb13_Out_1_Vector4, (_Property_534fe33381254583b6b1befa0dc13246_Out_0_Float.xxxx), _Multiply_ef93cbef5e614eff9e1fb9f97ee0d695_Out_2_Vector4);
            UnityTexture2D _Property_95c5af2ee0fe418cbdf7161c9ba2440c_Out_0_Texture2D = UnityBuildTexture2DStructNoScale(_lines_main_tex);
            float _Property_8f943f1a1d6c439cba8d7cc7a0d178bb_Out_0_Float = _lines_main_scale_X;
            float _Property_33610de87cc64ef781360df2f29e6927_Out_0_Float = _line_scale_width;
            float4 _UV_0d8fd150812c4fd8924aeed78f2634b0_Out_0_Vector4 = IN.uv0;
            float4 _ChannelMask_eb198748341c44908ec268928a0cd5e1_Out_1_Vector4;
            Unity_ChannelMask_Red_float4 (_UV_0d8fd150812c4fd8924aeed78f2634b0_Out_0_Vector4, _ChannelMask_eb198748341c44908ec268928a0cd5e1_Out_1_Vector4);
            float4 _Multiply_3dc9e119d43443419e4aff06aff35de3_Out_2_Vector4;
            Unity_Multiply_float4_float4((_Property_33610de87cc64ef781360df2f29e6927_Out_0_Float.xxxx), _ChannelMask_eb198748341c44908ec268928a0cd5e1_Out_1_Vector4, _Multiply_3dc9e119d43443419e4aff06aff35de3_Out_2_Vector4);
            float4 _ChannelMask_19706ee76bce4d6fb9cb46094d13a511_Out_1_Vector4;
            Unity_ChannelMask_Green_float4 (_UV_0d8fd150812c4fd8924aeed78f2634b0_Out_0_Vector4, _ChannelMask_19706ee76bce4d6fb9cb46094d13a511_Out_1_Vector4);
            float _Property_7977d36e594e40d0a969f1d4a645d10e_Out_0_Float = _line_acceleration;
            float4 _Power_71e7adc33473482ea33c788e4664b10e_Out_2_Vector4;
            Unity_Power_float4(_ChannelMask_19706ee76bce4d6fb9cb46094d13a511_Out_1_Vector4, (_Property_7977d36e594e40d0a969f1d4a645d10e_Out_0_Float.xxxx), _Power_71e7adc33473482ea33c788e4664b10e_Out_2_Vector4);
            float4 _Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4;
            Unity_Add_float4(_Multiply_3dc9e119d43443419e4aff06aff35de3_Out_2_Vector4, _Power_71e7adc33473482ea33c788e4664b10e_Out_2_Vector4, _Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4);
            float4 _ChannelMask_74f4f7024a354a8daea19c3a0c9ea971_Out_1_Vector4;
            Unity_ChannelMask_Red_float4 (_Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4, _ChannelMask_74f4f7024a354a8daea19c3a0c9ea971_Out_1_Vector4);
            float4 _Multiply_a4c7b1aa4bbc4e299400dfe171cfcca2_Out_2_Vector4;
            Unity_Multiply_float4_float4((_Property_8f943f1a1d6c439cba8d7cc7a0d178bb_Out_0_Float.xxxx), _ChannelMask_74f4f7024a354a8daea19c3a0c9ea971_Out_1_Vector4, _Multiply_a4c7b1aa4bbc4e299400dfe171cfcca2_Out_2_Vector4);
            float4 _ChannelMask_16f9f46097254be3ade331e591a393ff_Out_1_Vector4;
            Unity_ChannelMask_Green_float4 (_Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4, _ChannelMask_16f9f46097254be3ade331e591a393ff_Out_1_Vector4);
            float _Property_8f2c7658224541e09a8c1b935f403b77_Out_0_Float = _lines_main_speed;
            float _Multiply_2964fdbce8b34a018e78584bf3dee7f4_Out_2_Float;
            Unity_Multiply_float_float(IN.TimeParameters.x, _Property_8f2c7658224541e09a8c1b935f403b77_Out_0_Float, _Multiply_2964fdbce8b34a018e78584bf3dee7f4_Out_2_Float);
            float4 _Subtract_75b080f7b090418aafc460aee6afdff9_Out_2_Vector4;
            Unity_Subtract_float4(_ChannelMask_16f9f46097254be3ade331e591a393ff_Out_1_Vector4, (_Multiply_2964fdbce8b34a018e78584bf3dee7f4_Out_2_Float.xxxx), _Subtract_75b080f7b090418aafc460aee6afdff9_Out_2_Vector4);
            float _Property_0b134d0fa3674d1dacae3b67c1e3ccd1_Out_0_Float = _lines_main_scale_Y;
            float4 _Multiply_35985ccfc709431cafe74d766d31d156_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Subtract_75b080f7b090418aafc460aee6afdff9_Out_2_Vector4, (_Property_0b134d0fa3674d1dacae3b67c1e3ccd1_Out_0_Float.xxxx), _Multiply_35985ccfc709431cafe74d766d31d156_Out_2_Vector4);
            float4 _Add_cab58967aa234b218161c4a09a035166_Out_2_Vector4;
            Unity_Add_float4(_Multiply_a4c7b1aa4bbc4e299400dfe171cfcca2_Out_2_Vector4, _Multiply_35985ccfc709431cafe74d766d31d156_Out_2_Vector4, _Add_cab58967aa234b218161c4a09a035166_Out_2_Vector4);
            float4 _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(_Property_95c5af2ee0fe418cbdf7161c9ba2440c_Out_0_Texture2D.tex, _Property_95c5af2ee0fe418cbdf7161c9ba2440c_Out_0_Texture2D.samplerstate, _Property_95c5af2ee0fe418cbdf7161c9ba2440c_Out_0_Texture2D.GetTransformedUV((_Add_cab58967aa234b218161c4a09a035166_Out_2_Vector4.xy)) );
            float _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_R_4_Float = _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4.r;
            float _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_G_5_Float = _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4.g;
            float _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_B_6_Float = _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4.b;
            float _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_A_7_Float = _SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4.a;
            float4 _Multiply_8ed597f81bae4bae8725212db9d80190_Out_2_Vector4;
            Unity_Multiply_float4_float4(_SampleTexture2D_fcbe921c2b844629a7e3a2b3de72ec1a_RGBA_0_Vector4, float4(2, 2, 2, 2), _Multiply_8ed597f81bae4bae8725212db9d80190_Out_2_Vector4);
            float _Property_cc4358b701974681a1d957a4fb4f38c3_Out_0_Float = _Lines_secondary_scale_X;
            float4 _ChannelMask_f091e0a4e8f54629bc32ec7fb0d7098d_Out_1_Vector4;
            Unity_ChannelMask_Red_float4 (_Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4, _ChannelMask_f091e0a4e8f54629bc32ec7fb0d7098d_Out_1_Vector4);
            float4 _Multiply_42157befa0c44bee84c7175dd6d63162_Out_2_Vector4;
            Unity_Multiply_float4_float4((_Property_cc4358b701974681a1d957a4fb4f38c3_Out_0_Float.xxxx), _ChannelMask_f091e0a4e8f54629bc32ec7fb0d7098d_Out_1_Vector4, _Multiply_42157befa0c44bee84c7175dd6d63162_Out_2_Vector4);
            float4 _ChannelMask_17fc17cacb0047bda79edcf51a6e35da_Out_1_Vector4;
            Unity_ChannelMask_Green_float4 (_Add_89ae3ffb169640b0929160d0fcd2d642_Out_2_Vector4, _ChannelMask_17fc17cacb0047bda79edcf51a6e35da_Out_1_Vector4);
            float _Property_e05be2924452414fa2ff6b9d19e0de93_Out_0_Float = _time_secondary_speed;
            float _Multiply_c7f664544ff5492db2bc2721eeebcff8_Out_2_Float;
            Unity_Multiply_float_float(IN.TimeParameters.x, _Property_e05be2924452414fa2ff6b9d19e0de93_Out_0_Float, _Multiply_c7f664544ff5492db2bc2721eeebcff8_Out_2_Float);
            float4 _Subtract_a949c19f1b434d0695669e68938e2434_Out_2_Vector4;
            Unity_Subtract_float4(_ChannelMask_17fc17cacb0047bda79edcf51a6e35da_Out_1_Vector4, (_Multiply_c7f664544ff5492db2bc2721eeebcff8_Out_2_Float.xxxx), _Subtract_a949c19f1b434d0695669e68938e2434_Out_2_Vector4);
            float _Property_c8d4ab07e0d14394adf6a43094e0b983_Out_0_Float = _lines_Secondary_scale_Y;
            float4 _Multiply_8800c918948a433e99eb661352fd4212_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Subtract_a949c19f1b434d0695669e68938e2434_Out_2_Vector4, (_Property_c8d4ab07e0d14394adf6a43094e0b983_Out_0_Float.xxxx), _Multiply_8800c918948a433e99eb661352fd4212_Out_2_Vector4);
            float4 _Add_2fda74c7055542548564bb348089f036_Out_2_Vector4;
            Unity_Add_float4(_Multiply_42157befa0c44bee84c7175dd6d63162_Out_2_Vector4, _Multiply_8800c918948a433e99eb661352fd4212_Out_2_Vector4, _Add_2fda74c7055542548564bb348089f036_Out_2_Vector4);
            float4 _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(UnityBuildTexture2DStructNoScale(_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D).tex, UnityBuildTexture2DStructNoScale(_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D).samplerstate, UnityBuildTexture2DStructNoScale(_SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_Texture_1_Texture2D).GetTransformedUV((_Add_2fda74c7055542548564bb348089f036_Out_2_Vector4.xy)) );
            float _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_R_4_Float = _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4.r;
            float _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_G_5_Float = _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4.g;
            float _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_B_6_Float = _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4.b;
            float _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_A_7_Float = _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4.a;
            float4 _Multiply_306905e98270411494f05439be90d579_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Multiply_8ed597f81bae4bae8725212db9d80190_Out_2_Vector4, _SampleTexture2D_f64e160b100a4c1faf2dfe6fb27e0c39_RGBA_0_Vector4, _Multiply_306905e98270411494f05439be90d579_Out_2_Vector4);
            float _Float_14dd549b73b14affbb7da96db1116986_Out_0_Float = float(2);
            float4 _Multiply_39c13e7bf4d54596aae047aaac49c0e2_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Multiply_306905e98270411494f05439be90d579_Out_2_Vector4, (_Float_14dd549b73b14affbb7da96db1116986_Out_0_Float.xxxx), _Multiply_39c13e7bf4d54596aae047aaac49c0e2_Out_2_Vector4);
            float4 _Add_fcd3caf1b3774b55b4761493c4ac1625_Out_2_Vector4;
            Unity_Add_float4(_Multiply_ef93cbef5e614eff9e1fb9f97ee0d695_Out_2_Vector4, _Multiply_39c13e7bf4d54596aae047aaac49c0e2_Out_2_Vector4, _Add_fcd3caf1b3774b55b4761493c4ac1625_Out_2_Vector4);
            float4 _Saturate_b7dc9e7f380d4fabbd5d359bce8357e8_Out_1_Vector4;
            Unity_Saturate_float4(_Add_fcd3caf1b3774b55b4761493c4ac1625_Out_2_Vector4, _Saturate_b7dc9e7f380d4fabbd5d359bce8357e8_Out_1_Vector4);
            float _Property_9edfccb536454a8d8a2d8ad48c42167a_Out_0_Float = _line_threshold;
            float _OneMinus_5bba03c9ff974914b63bc52b5923cb65_Out_1_Float;
            Unity_OneMinus_float(_Property_9edfccb536454a8d8a2d8ad48c42167a_Out_0_Float, _OneMinus_5bba03c9ff974914b63bc52b5923cb65_Out_1_Float);
            float4 _Add_e016add5650b48438b7c1c2625e5cffe_Out_2_Vector4;
            Unity_Add_float4(_Saturate_b7dc9e7f380d4fabbd5d359bce8357e8_Out_1_Vector4, (_OneMinus_5bba03c9ff974914b63bc52b5923cb65_Out_1_Float.xxxx), _Add_e016add5650b48438b7c1c2625e5cffe_Out_2_Vector4);
            float4 _Saturate_7f657c8db2094d6c8ae40e095ac83ebd_Out_1_Vector4;
            Unity_Saturate_float4(_Add_e016add5650b48438b7c1c2625e5cffe_Out_2_Vector4, _Saturate_7f657c8db2094d6c8ae40e095ac83ebd_Out_1_Vector4);
            float4 _Floor_a4e91b5788a44b91a680580e3af68c38_Out_1_Vector4;
            Unity_Floor_float4(_Saturate_7f657c8db2094d6c8ae40e095ac83ebd_Out_1_Vector4, _Floor_a4e91b5788a44b91a680580e3af68c38_Out_1_Vector4);
            float4 _Lerp_9841dd6d2bd04e42b4cb57b33d0fe35a_Out_3_Vector4;
            Unity_Lerp_float4(_Lerp_94679fa3491f467684be9ff758a55d18_Out_3_Vector4, _Property_f0a99b264fd34c2c8639c7af81725d40_Out_0_Vector4, _Floor_a4e91b5788a44b91a680580e3af68c38_Out_1_Vector4, _Lerp_9841dd6d2bd04e42b4cb57b33d0fe35a_Out_3_Vector4);
            float4 _Add_4583e01988024b38998ac5e9c5a0d399_Out_2_Vector4;
            Unity_Add_float4(_Lerp_9841dd6d2bd04e42b4cb57b33d0fe35a_Out_3_Vector4, float4(0, 0, 0, 0), _Add_4583e01988024b38998ac5e9c5a0d399_Out_2_Vector4);
            float4 Color_1a97f4e858eb4c6d841021e72c5d3d64 = IsGammaSpace() ? float4(0, 0, 1, 1) : float4(SRGBToLinear(float3(0, 0, 1)), 1);
            float4 _ChannelMask_cf7ae72a728a44c08f15e60d9d26f0c3_Out_1_Vector4;
            Unity_ChannelMask_RedGreen_float4 (Color_1a97f4e858eb4c6d841021e72c5d3d64, _ChannelMask_cf7ae72a728a44c08f15e60d9d26f0c3_Out_1_Vector4);
            float _Float_00a4dadc48e1434288ce763bd643ad66_Out_0_Float = float(-0.5);
            float4 _Add_5e0bee7b7ac74672a7065961046451ee_Out_2_Vector4;
            Unity_Add_float4(_ChannelMask_cf7ae72a728a44c08f15e60d9d26f0c3_Out_1_Vector4, (_Float_00a4dadc48e1434288ce763bd643ad66_Out_0_Float.xxxx), _Add_5e0bee7b7ac74672a7065961046451ee_Out_2_Vector4);
            float _Float_1ccf8060dd92444dabe1369d4427d2e4_Out_0_Float = float(2);
            float4 _Multiply_92f5b69c104742a48468b928199b995f_Out_2_Vector4;
            Unity_Multiply_float4_float4(_Add_5e0bee7b7ac74672a7065961046451ee_Out_2_Vector4, (_Float_1ccf8060dd92444dabe1369d4427d2e4_Out_0_Float.xxxx), _Multiply_92f5b69c104742a48468b928199b995f_Out_2_Vector4);
            float4 _UV_1a14460a201d4ae280a1eaa3563a82b7_Out_0_Vector4 = IN.uv0;
            float _Property_4aa4fa4ca33944418b3b63c25d1e222b_Out_0_Float = _tiling_large;
            float4 _Multiply_00173f44df554c4c969653140dae9159_Out_2_Vector4;
            Unity_Multiply_float4_float4(_UV_1a14460a201d4ae280a1eaa3563a82b7_Out_0_Vector4, (_Property_4aa4fa4ca33944418b3b63c25d1e222b_Out_0_Float.xxxx), _Multiply_00173f44df554c4c969653140dae9159_Out_2_Vector4);
            float4 _Add_dbbed777fe52417cb0b11fea42873d5c_Out_2_Vector4;
            Unity_Add_float4(_Multiply_92f5b69c104742a48468b928199b995f_Out_2_Vector4, _Multiply_00173f44df554c4c969653140dae9159_Out_2_Vector4, _Add_dbbed777fe52417cb0b11fea42873d5c_Out_2_Vector4);
            float4 _Add_4895008d45c549298ecf708d275da180_Out_2_Vector4;
            Unity_Add_float4(_Add_dbbed777fe52417cb0b11fea42873d5c_Out_2_Vector4, float4(0, 0, 0, 0), _Add_4895008d45c549298ecf708d275da180_Out_2_Vector4);
            Bindings_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float _SubGCustomRotator_ff07215028f84162b5c948c659cda1d4;
            float4 _SubGCustomRotator_ff07215028f84162b5c948c659cda1d4_OutVector4_1_Vector4;
            SG_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float(float2 (0, 0), (_Add_4895008d45c549298ecf708d275da180_Out_2_Vector4.xy), float(0), _SubGCustomRotator_ff07215028f84162b5c948c659cda1d4, _SubGCustomRotator_ff07215028f84162b5c948c659cda1d4_OutVector4_1_Vector4);
            float4 _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(UnityBuildTexture2DStructNoScale(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D).tex, UnityBuildTexture2DStructNoScale(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D).samplerstate, UnityBuildTexture2DStructNoScale(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_Texture_1_Texture2D).GetTransformedUV((_SubGCustomRotator_ff07215028f84162b5c948c659cda1d4_OutVector4_1_Vector4.xy)) );
            _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.rgb = UnpackNormal(_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4);
            float _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_R_4_Float = _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.r;
            float _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_G_5_Float = _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.g;
            float _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_B_6_Float = _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.b;
            float _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_A_7_Float = _SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.a;
            float _Property_4c9962eaf54d4fb3b90d837f8a1e5135_Out_0_Float = _wave_large_normal_Strength;
            Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float _SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b;
            float3 _SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b_OutVector4_1_Vector3;
            SG_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float((_SampleTexture2D_19c2ee1cfad84fc8ab6b00b0833b25bf_RGBA_0_Vector4.xyz), _Property_4c9962eaf54d4fb3b90d837f8a1e5135_Out_0_Float, _SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b, _SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b_OutVector4_1_Vector3);
            float4 _UV_7ecffc16ac6f4a6e8d6c9e15e019656a_Out_0_Vector4 = IN.uv0;
            float _Property_73d9afc5f3a3482fbb0913474af39ad9_Out_0_Float = _tiling_small;
            float4 _Multiply_382b99d1983f404aa8578fe246e8927d_Out_2_Vector4;
            Unity_Multiply_float4_float4(_UV_7ecffc16ac6f4a6e8d6c9e15e019656a_Out_0_Vector4, (_Property_73d9afc5f3a3482fbb0913474af39ad9_Out_0_Float.xxxx), _Multiply_382b99d1983f404aa8578fe246e8927d_Out_2_Vector4);
            float4 _Add_4ab28b643d854a368642d90a0ec0a075_Out_2_Vector4;
            Unity_Add_float4(_Multiply_92f5b69c104742a48468b928199b995f_Out_2_Vector4, _Multiply_382b99d1983f404aa8578fe246e8927d_Out_2_Vector4, _Add_4ab28b643d854a368642d90a0ec0a075_Out_2_Vector4);
            float2 _Vector2_0bc73a0cd1db49c884aa8967bc3e95d7_Out_0_Vector2 = float2(float(0), float(-2));
            float2 _Multiply_33854325de694851a4a01b1c6ac404cd_Out_2_Vector2;
            Unity_Multiply_float2_float2((IN.TimeParameters.x.xx), _Vector2_0bc73a0cd1db49c884aa8967bc3e95d7_Out_0_Vector2, _Multiply_33854325de694851a4a01b1c6ac404cd_Out_2_Vector2);
            float2 _Add_65717e3b5ba745769f124b49f3258b8f_Out_2_Vector2;
            Unity_Add_float2((_Add_4ab28b643d854a368642d90a0ec0a075_Out_2_Vector4.xy), _Multiply_33854325de694851a4a01b1c6ac404cd_Out_2_Vector2, _Add_65717e3b5ba745769f124b49f3258b8f_Out_2_Vector2);
            Bindings_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float _SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d;
            float4 _SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d_OutVector4_1_Vector4;
            SG_SubGCustomRotator_4e05c20388564fd4b86f269e1937cb6d_float(float2 (0, 0), _Add_65717e3b5ba745769f124b49f3258b8f_Out_2_Vector2, float(0), _SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d, _SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d_OutVector4_1_Vector4);
            float4 _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(UnityBuildTexture2DStructNoScale(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D).tex, UnityBuildTexture2DStructNoScale(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D).samplerstate, UnityBuildTexture2DStructNoScale(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_Texture_1_Texture2D).GetTransformedUV((_SubGCustomRotator_1d17c140b98f4353ae9d9bc6a10b784d_OutVector4_1_Vector4.xy)) );
            _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.rgb = UnpackNormal(_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4);
            float _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_R_4_Float = _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.r;
            float _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_G_5_Float = _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.g;
            float _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_B_6_Float = _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.b;
            float _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_A_7_Float = _SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.a;
            float _Property_a009c1b918b44c69b87d232216fb1476_Out_0_Float = _wave_small_normal_strength;
            Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21;
            float3 _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21_OutVector4_1_Vector3;
            SG_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float((_SampleTexture2D_059e5ab9551d4a10a1361de5ac7a2ab3_RGBA_0_Vector4.xyz), _Property_a009c1b918b44c69b87d232216fb1476_Out_0_Float, _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21, _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21_OutVector4_1_Vector3);
            float _Float_2567a353822f42709058c4132980ef56_Out_0_Float = float(0.5);
            float3 _Lerp_ee622e31b20c45db9e4a8c2f7c465980_Out_3_Vector3;
            Unity_Lerp_float3(_SubGFlattenNormal_362c184129814fd5a026c3fdf8eed53b_OutVector4_1_Vector3, _SubGFlattenNormal_69ef6e82eb14473e9b093df652b50b21_OutVector4_1_Vector3, (_Float_2567a353822f42709058c4132980ef56_Out_0_Float.xxx), _Lerp_ee622e31b20c45db9e4a8c2f7c465980_Out_3_Vector3);
            float _Float_3b99d1827ec64b9382aced15b0c47fdc_Out_0_Float = float(1);
            Bindings_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float _SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00;
            float3 _SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00_OutVector4_1_Vector3;
            SG_SubGFlattenNormal_fac51edb1b83ca24796ac00d88eafe78_float(_Lerp_ee622e31b20c45db9e4a8c2f7c465980_Out_3_Vector3, _Float_3b99d1827ec64b9382aced15b0c47fdc_Out_0_Float, _SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00, _SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00_OutVector4_1_Vector3);
            float3 _Lerp_30afc261e4fa44aa87e3e7d36fe6d0cf_Out_3_Vector3;
            Unity_Lerp_float3(_SubGFlattenNormal_8b38d9b081db412c81d757e8a1f99d00_OutVector4_1_Vector3, _Lerp_ee622e31b20c45db9e4a8c2f7c465980_Out_3_Vector3, float3(0, 0, 0), _Lerp_30afc261e4fa44aa87e3e7d36fe6d0cf_Out_3_Vector3);
            surface.BaseColor = (_Add_4583e01988024b38998ac5e9c5a0d399_Out_2_Vector4.xyz);
            surface.NormalTS = _Lerp_30afc261e4fa44aa87e3e7d36fe6d0cf_Out_3_Vector3;
            surface.Emission = float3(0, 0, 0);
            surface.Metallic = float(0);
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
            output.TimeParameters = _TimeParameters.xyz; 
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
        #else
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
        #endif
        #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
        
                return output;
        }

        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityGBuffer.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/PBRGBufferPass.hlsl"
    
        #ifdef HAVE_VFX_MODIFICATION
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
        #endif
        
        ENDHLSL
        }
    }

    CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
    CustomEditorForRenderPipeline "UnityEditor.Rendering.BuiltIn.ShaderGraph.BuiltInLitGUI" ""
    CustomEditorForRenderPipeline "UnityEditor.ShaderGraphLitGUI" "UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset"
    FallBack "Hidden/Shader Graph/FallbackError"
}