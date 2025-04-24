// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Mobile/Particles/Additive,iptp:1,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33535,y:32620,varname:node_4795,prsc:2|emission-1209-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32574,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ee563c601ce871f42ad3f66c8ae56b8e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2393,x:32670,y:32776,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT,E-567-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33121,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_DepthBlend,id:4085,x:32655,y:33056,varname:node_4085,prsc:2|DIST-7893-OUT;n:type:ShaderForge.SFN_Slider,id:7893,x:32382,y:33138,ptovrint:False,ptlb:EdgeSoftness,ptin:_EdgeSoftness,varname:_EdgeSoftness,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:567,x:32519,y:32544,varname:node_567,prsc:2|A-6074-A,B-2053-A,C-797-A;n:type:ShaderForge.SFN_Multiply,id:1209,x:33125,y:32651,varname:node_1209,prsc:2|A-2393-OUT,B-4085-OUT,C-5816-OUT;n:type:ShaderForge.SFN_Clamp,id:5816,x:33092,y:33026,varname:node_5816,prsc:2|IN-8001-VFACE,MIN-2399-OUT,MAX-9360-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2399,x:32916,y:33153,ptovrint:False,ptlb:DoubleSided,ptin:_DoubleSided,varname:_DoubleSided,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector1,id:9360,x:32916,y:33249,varname:node_9360,prsc:2,v1:1;n:type:ShaderForge.SFN_FaceSign,id:8001,x:33092,y:33180,varname:node_8001,prsc:2,fstp:0;proporder:797-6074-7893-2399;pass:END;sub:END;*/

Shader "GAP/Additive_EdgeSoft"
{
    Properties
    {
        _TintColor ("Color", Color) = (0.5, 0.5, 0.5, 1)
        _MainTex ("MainTex", 2D) = "white" {}
        _EdgeSoftness ("EdgeSoftness", Range(0, 1)) = 0.1
        _DoubleSided ("DoubleSided", Float) = 1
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }
        Pass
        {
            Name "ForwardLit"
            Tags
            {
                "LightMode"="UniversalForward"
            }

            Blend One One
            Cull Off
            ZWrite Off

            HLSLINCLUDE
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
                float4 screenPos : TEXCOORD1;
                UNITY_FOG_COORDS (
                2
                )
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _MainTex_ST;
            float4 _TintColor;
            float _EdgeSoftness;
            float _DoubleSided;

            Varyings vert(Attributes v)
            {
                Varyings o;
                o.positionHCS = TransformObjectToHClip(v.positionOS);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                o.screenPos = ComputeScreenPos(o.positionHCS);
                UNITY_TRANSFER_FOG(o, o.positionHCS);
                return o;
            }

            half4 frag(Varyings i, float facing : VFACE) : SV_TARGET
            {
                float isFrontFace = (facing >= 0 ? 1 : 0);
                float faceSign = (facing >= 0 ? 1 : -1);
                float sceneZ = max(0, LinearEyeDepth(
                                SAMPLE_DEPTH_TEXTURE2D_X(_CameraDepthTexture, sampler_CameraDepthTexture,
                                    i.screenPos.xy)));
                float partZ = max(0, i.screenPos.z);

                half4 mainTexColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                float3 emissive = (mainTexColor.rgb * i.color.rgb * _TintColor.rgb * 2.0 * (mainTexColor.a * i.color.a *
                    _TintColor.a)) * saturate((sceneZ - partZ) / _EdgeSoftness) * clamp(isFrontFace, _DoubleSided, 1.0);
                float3 finalColor = emissive;
                half4 finalRGBA = half4(finalColor, 1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Lit"
}