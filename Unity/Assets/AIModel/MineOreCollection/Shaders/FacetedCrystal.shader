Shader "MineOreCollection/FacetedCrystal"
{
    Properties
    {
        _BaseMap("Crystal Interior",2D)="white"{}
        _BaseColor("Crystal Color",Color)=(.1,.4,1,1)
        _BumpMap("Micro Normal",2D)="bump"{}
        _BumpScale("Micro Normal Strength",Range(0,1))=.2
        _MetallicGlossMap("Metallic Smoothness",2D)="white"{}
        _Metallic("Metallic",Range(0,1))=.1
        _Smoothness("Smoothness",Range(0,1))=1
        _GlossMapScale("Smoothness Scale",Range(0,1))=1
        _EmissionMap("Interior Emission",2D)="white"{}
        [HDR]_EmissionColor("Interior Glow",Color)=(.02,.06,.12,1)
        _FacetHighlight("Painted Facet Contrast",Range(0,2))=.95
        _FresnelStrength("Edge Light",Range(0,1))=.20
        _GlowStrength("Glow Strength",Range(0,2))=.6
        [HideInInspector]_Surface("Surface",Float)=0
    }
    SubShader
    {
        Tags{"RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" "Queue"="Geometry"}
        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
        TEXTURE2D(_MetallicGlossMap);SAMPLER(sampler_MetallicGlossMap);
        CBUFFER_START(UnityPerMaterial)
            float4 _BaseMap_ST;
            half4 _BaseColor,_EmissionColor;
            half _BumpScale,_Metallic,_Smoothness,_GlossMapScale,_FacetHighlight,_FresnelStrength,_GlowStrength,_Surface;
        CBUFFER_END
        struct Attributes
        {
            float4 positionOS:POSITION;float3 normalOS:NORMAL;float4 tangentOS:TANGENT;float2 uv:TEXCOORD0;float2 lightmapUV:TEXCOORD1;float2 dynamicUV:TEXCOORD2;half4 color:COLOR;
            UNITY_VERTEX_INPUT_INSTANCE_ID
        };
        struct Varyings
        {
            float4 positionCS:SV_POSITION;float3 positionWS:TEXCOORD0;half3 normalWS:TEXCOORD1;half4 tangentWS:TEXCOORD2;float2 uv:TEXCOORD3;half4 style:TEXCOORD4;half4 fogAndLight:TEXCOORD5;
            DECLARE_LIGHTMAP_OR_SH(lightmapUV,vertexSH,6);
            UNITY_VERTEX_INPUT_INSTANCE_ID
            UNITY_VERTEX_OUTPUT_STEREO
        };
        Varyings OreVertex(Attributes input)
        {
            Varyings output=(Varyings)0;UNITY_SETUP_INSTANCE_ID(input);UNITY_TRANSFER_INSTANCE_ID(input,output);UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);
            VertexPositionInputs position=GetVertexPositionInputs(input.positionOS.xyz);VertexNormalInputs normal=GetVertexNormalInputs(input.normalOS,input.tangentOS);
            output.positionCS=position.positionCS;output.positionWS=position.positionWS;output.normalWS=normal.normalWS;output.tangentWS=half4(normal.tangentWS,input.tangentOS.w*GetOddNegativeScale());output.uv=TRANSFORM_TEX(input.uv,_BaseMap);output.style=input.color;
            output.fogAndLight=half4(ComputeFogFactor(position.positionCS.z),VertexLighting(position.positionWS,normal.normalWS));OUTPUT_LIGHTMAP_UV(input.lightmapUV,unity_LightmapST,output.lightmapUV);OUTPUT_SH(normal.normalWS,output.vertexSH);return output;
        }
        half3 CrystalNormal(Varyings input)
        {
            half3 n=UnpackNormalScale(SAMPLE_TEXTURE2D(_BumpMap,sampler_BumpMap,input.uv),_BumpScale);half3 bitangent=input.tangentWS.w*cross(input.normalWS,input.tangentWS.xyz);return NormalizeNormalPerPixel(TransformTangentToWorld(n,half3x3(input.tangentWS.xyz,bitangent,input.normalWS)));
        }
        half4 OreFragment(Varyings input):SV_Target
        {
            UNITY_SETUP_INSTANCE_ID(input);UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);
            half4 texColor=SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,input.uv);half4 packed=SAMPLE_TEXTURE2D(_MetallicGlossMap,sampler_MetallicGlossMap,input.uv);half3 normal=CrystalNormal(input);half3 view=GetWorldSpaceNormalizeViewDir(input.positionWS);
            half height=saturate(input.style.a);half fracture=saturate((texColor.r-.58h)*3);half whitening=saturate(input.style.g*_FacetHighlight+smoothstep(.82h,1,height)*.06h+fracture*.035h);
            half3 tint=lerp(_BaseColor.rgb,half3(1,1,1),whitening);half depth=lerp(.48h,1.08h,smoothstep(0,.82h,height));half edge=pow(1-saturate(dot(normal,view)),3)*_FresnelStrength;
            SurfaceData surface=(SurfaceData)0;surface.albedo=texColor.rgb*tint*depth;surface.metallic=saturate(packed.r*_Metallic*10);surface.smoothness=packed.a*_Smoothness*_GlossMapScale;surface.normalTS=half3(0,0,1);surface.alpha=1;surface.occlusion=1;
            surface.emission=texColor.rgb*_EmissionColor.rgb*depth+lerp(_BaseColor.rgb,half3(1,1,1),.35h)*(edge*.4h+fracture*.04h)*_GlowStrength;
            InputData data=(InputData)0;data.positionWS=input.positionWS;data.normalWS=normal;data.viewDirectionWS=view;data.shadowCoord=TransformWorldToShadowCoord(input.positionWS);data.fogCoord=input.fogAndLight.x;data.vertexLighting=input.fogAndLight.yzw;data.bakedGI=SAMPLE_GI(input.lightmapUV,input.vertexSH,normal);data.normalizedScreenSpaceUV=GetNormalizedScreenSpaceUV(input.positionCS);data.shadowMask=SAMPLE_SHADOWMASK(input.lightmapUV);
            half4 color=UniversalFragmentPBR(data,surface);color.rgb=MixFog(color.rgb,data.fogCoord);return color;
        }
        struct DepthVaryings{float4 positionCS:SV_POSITION;UNITY_VERTEX_INPUT_INSTANCE_ID UNITY_VERTEX_OUTPUT_STEREO};
        DepthVaryings DepthVertex(Attributes input)
        {DepthVaryings o=(DepthVaryings)0;UNITY_SETUP_INSTANCE_ID(input);UNITY_TRANSFER_INSTANCE_ID(input,o);UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);o.positionCS=TransformObjectToHClip(input.positionOS.xyz);return o;}
        half4 DepthFragment(DepthVaryings input):SV_Target{return 0;}
        half4 NormalFragment(Varyings input):SV_Target
        {
            half3 normal=CrystalNormal(input);
            #if defined(_GBUFFER_NORMALS_OCT)
                float2 oct=PackNormalOctQuadEncode(normal);half3 packed=PackFloat2To888(saturate(oct*.5+.5));return half4(packed,0);
            #else
                return half4(normal,0);
            #endif
        }
        ENDHLSL
        Pass
        {
            Name "ForwardLit" Tags{"LightMode"="UniversalForwardOnly"}
            Cull Back ZWrite On ZTest LEqual
            HLSLPROGRAM
            #pragma target 3.0
            #pragma vertex OreVertex
            #pragma fragment OreFragment
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile_fragment _ _SHADOWS_SOFT
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ _FORWARD_PLUS
            #pragma multi_compile_fog
            #pragma multi_compile_instancing
            ENDHLSL
        }
        Pass
        {
            Name "ShadowCaster" Tags{"LightMode"="ShadowCaster"}
            Cull Back ZWrite On ZTest LEqual ColorMask 0
            HLSLPROGRAM
            #pragma target 3.0
            #pragma vertex ShadowVertex
            #pragma fragment DepthFragment
            #pragma multi_compile_vertex _ _CASTING_PUNCTUAL_LIGHT_SHADOW
            #pragma multi_compile_instancing
            float3 _LightDirection;float3 _LightPosition;
            DepthVaryings ShadowVertex(Attributes input)
            {
                DepthVaryings o=(DepthVaryings)0;UNITY_SETUP_INSTANCE_ID(input);UNITY_TRANSFER_INSTANCE_ID(input,o);UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);float3 position=TransformObjectToWorld(input.positionOS.xyz);float3 normal=TransformObjectToWorldNormal(input.normalOS);
                #if defined(_CASTING_PUNCTUAL_LIGHT_SHADOW)
                    float3 light=normalize(_LightPosition-position);
                #else
                    float3 light=_LightDirection;
                #endif
                o.positionCS=TransformWorldToHClip(ApplyShadowBias(position,normal,light));
                #if UNITY_REVERSED_Z
                    o.positionCS.z=min(o.positionCS.z,UNITY_NEAR_CLIP_VALUE*o.positionCS.w);
                #else
                    o.positionCS.z=max(o.positionCS.z,UNITY_NEAR_CLIP_VALUE*o.positionCS.w);
                #endif
                return o;
            }
            ENDHLSL
        }
        Pass
        {
            Name "DepthOnly" Tags{"LightMode"="DepthOnly"}
            Cull Back ZWrite On ColorMask R
            HLSLPROGRAM
            #pragma target 3.0
            #pragma vertex DepthVertex
            #pragma fragment DepthFragment
            #pragma multi_compile_instancing
            ENDHLSL
        }
        Pass
        {
            Name "DepthNormals" Tags{"LightMode"="DepthNormals"}
            Cull Back ZWrite On
            HLSLPROGRAM
            #pragma target 3.0
            #pragma vertex OreVertex
            #pragma fragment NormalFragment
            #pragma multi_compile_fragment _ _GBUFFER_NORMALS_OCT
            #pragma multi_compile_instancing
            ENDHLSL
        }
        Pass
        {
            Name "Meta" Tags{"LightMode"="Meta"} Cull Off
            HLSLPROGRAM
            #pragma target 3.0
            #pragma vertex CrystalMetaVertex
            #pragma fragment CrystalMetaFragment
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"
            struct MetaVaryings{float4 positionCS:SV_POSITION;float2 uv:TEXCOORD0;half4 style:TEXCOORD1;};
            MetaVaryings CrystalMetaVertex(Attributes input)
            {MetaVaryings o=(MetaVaryings)0;o.positionCS=MetaVertexPosition(input.positionOS,input.lightmapUV,input.dynamicUV,unity_LightmapST,unity_DynamicLightmapST);o.uv=TRANSFORM_TEX(input.uv,_BaseMap);o.style=input.color;return o;}
            half4 CrystalMetaFragment(MetaVaryings input):SV_Target
            {MetaInput meta=(MetaInput)0;half3 tex=SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,input.uv).rgb;half whitening=saturate(input.style.g*_FacetHighlight+smoothstep(.82h,1,input.style.a)*.06h);meta.Albedo=tex*lerp(_BaseColor.rgb,half3(1,1,1),whitening)*lerp(.48h,1.08h,smoothstep(0,.82h,input.style.a));meta.Emission=tex*_EmissionColor.rgb;return MetaFragment(meta);}
            ENDHLSL
        }
    }
    FallBack "Hidden/Universal Render Pipeline/FallbackError"
}
