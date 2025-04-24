// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33232,y:32540,varname:node_9361,prsc:2|emission-9169-OUT,alpha-2325-OUT,clip-4839-OUT;n:type:ShaderForge.SFN_Tex2d,id:9220,x:32740,y:32402,ptovrint:False,ptlb:TEX,ptin:_TEX,varname:node_6069,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-955-OUT;n:type:ShaderForge.SFN_Tex2d,id:3607,x:32641,y:32963,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_9683,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5655-OUT;n:type:ShaderForge.SFN_Color,id:2642,x:32701,y:32631,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7299,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:9169,x:33002,y:32555,varname:node_9169,prsc:2|A-9220-RGB,B-2642-RGB,C-3595-RGB;n:type:ShaderForge.SFN_Divide,id:4839,x:32948,y:32998,varname:node_4839,prsc:2|A-3607-R,B-1962-OUT;n:type:ShaderForge.SFN_Slider,id:1962,x:32647,y:33215,ptovrint:False,ptlb:Mask_Range,ptin:_Mask_Range,varname:node_1992,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:3;n:type:ShaderForge.SFN_VertexColor,id:3595,x:32758,y:32790,varname:node_3595,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:1224,x:32286,y:32452,varname:node_1224,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:955,x:32462,y:32550,varname:node_955,prsc:2|A-1224-UVOUT,B-8819-OUT;n:type:ShaderForge.SFN_Multiply,id:8819,x:32334,y:32703,varname:node_8819,prsc:2|A-8161-T,B-9231-OUT;n:type:ShaderForge.SFN_Append,id:9231,x:32080,y:32721,varname:node_9231,prsc:2|A-9032-OUT,B-9234-OUT;n:type:ShaderForge.SFN_Slider,id:9032,x:31659,y:32606,ptovrint:False,ptlb:U,ptin:_U,varname:node_9976,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Slider,id:9234,x:31626,y:32745,ptovrint:False,ptlb:V,ptin:_V,varname:node_872,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Time,id:8161,x:31988,y:32485,varname:node_8161,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:7952,x:32152,y:33005,varname:node_7952,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:5655,x:32412,y:33080,varname:node_5655,prsc:2|A-7952-UVOUT,B-1141-OUT;n:type:ShaderForge.SFN_Multiply,id:1141,x:32284,y:33233,varname:node_1141,prsc:2|A-9575-T,B-279-OUT;n:type:ShaderForge.SFN_Append,id:279,x:32030,y:33251,varname:node_279,prsc:2|A-1253-OUT,B-1914-OUT;n:type:ShaderForge.SFN_Slider,id:1253,x:31609,y:33136,ptovrint:False,ptlb:U_Mask,ptin:_U_Mask,varname:_U_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Slider,id:1914,x:31576,y:33275,ptovrint:False,ptlb:V_Mask,ptin:_V_Mask,varname:_V_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Time,id:9575,x:31938,y:33015,varname:node_9575,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2325,x:33007,y:32730,varname:node_2325,prsc:2|A-9220-A,B-2642-A,C-3595-A;proporder:9220-2642-9032-9234-3607-1962-1253-1914;pass:END;sub:END;*/

Shader "Shader Forge/dissolve_c" {
    Properties {
        _TEX ("TEX", 2D) = "white" {}
        [HDR]_Color ("Color", Color) = (0.5,0.5,0.5,1)
        _U ("U", Range(-5, 5)) = 0
        _V ("V", Range(-5, 5)) = 0
        _Mask ("Mask", 2D) = "white" {}
        _Mask_Range ("Mask_Range", Range(0, 3)) = 0
        _U_Mask ("U_Mask", Range(-5, 5)) = 0
        _V_Mask ("V_Mask", Range(-5, 5)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _TEX; uniform float4 _TEX_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float4 _Color;
            uniform float _Mask_Range;
            uniform float _U;
            uniform float _V;
            uniform float _U_Mask;
            uniform float _V_Mask;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_9575 = _Time;
                float2 node_5655 = (i.uv0+(node_9575.g*float2(_U_Mask,_V_Mask)));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_5655, _Mask));
                clip((_Mask_var.r/_Mask_Range) - 0.5);
////// Lighting:
////// Emissive:
                float4 node_8161 = _Time;
                float2 node_955 = (i.uv0+(node_8161.g*float2(_U,_V)));
                float4 _TEX_var = tex2D(_TEX,TRANSFORM_TEX(node_955, _TEX));
                float3 emissive = (_TEX_var.rgb*_Color.rgb*i.vertexColor.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_TEX_var.a*_Color.a*i.vertexColor.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Mask_Range;
            uniform float _U_Mask;
            uniform float _V_Mask;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_9575 = _Time;
                float2 node_5655 = (i.uv0+(node_9575.g*float2(_U_Mask,_V_Mask)));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_5655, _Mask));
                clip((_Mask_var.r/_Mask_Range) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
