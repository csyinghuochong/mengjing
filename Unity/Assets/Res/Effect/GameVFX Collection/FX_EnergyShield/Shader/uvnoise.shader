// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-9589-OUT,custl-9581-OUT;n:type:ShaderForge.SFN_Tex2d,id:6265,x:32531,y:32451,ptovrint:False,ptlb:TEX,ptin:_TEX,varname:node_6265,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5153-OUT;n:type:ShaderForge.SFN_Color,id:7761,x:32557,y:32792,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7761,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:2576,x:32763,y:32746,varname:node_2576,prsc:2|A-2495-OUT,B-7761-RGB,C-7761-A,D-9879-RGB,E-4767-A;n:type:ShaderForge.SFN_Tex2d,id:9879,x:32556,y:33117,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_9879,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7896-OUT;n:type:ShaderForge.SFN_Color,id:7695,x:32935,y:33224,ptovrint:False,ptlb:glowcolor,ptin:_glowcolor,varname:node_7695,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:9581,x:32935,y:33016,varname:node_9581,prsc:2|A-2576-OUT,B-7695-RGB,C-4767-A,D-1268-OUT;n:type:ShaderForge.SFN_VertexColor,id:4767,x:32539,y:32956,varname:node_4767,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:4236,x:32081,y:32507,varname:node_4236,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:5153,x:32344,y:32512,varname:node_5153,prsc:2|A-4236-UVOUT,B-777-OUT;n:type:ShaderForge.SFN_Append,id:4267,x:31952,y:32755,varname:node_4267,prsc:2|A-8070-OUT,B-6174-OUT;n:type:ShaderForge.SFN_Multiply,id:777,x:32130,y:32693,varname:node_777,prsc:2|A-3476-T,B-4267-OUT;n:type:ShaderForge.SFN_Time,id:3476,x:31920,y:32577,varname:node_3476,prsc:2;n:type:ShaderForge.SFN_Slider,id:8070,x:31553,y:32582,ptovrint:False,ptlb:U,ptin:_U,varname:node_8070,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:1,max:10;n:type:ShaderForge.SFN_Slider,id:6174,x:31553,y:32786,ptovrint:False,ptlb:V,ptin:_V,varname:node_6174,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:1,max:10;n:type:ShaderForge.SFN_TexCoord,id:7622,x:31999,y:33038,varname:node_7622,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:7896,x:32262,y:33043,varname:node_7896,prsc:2|A-7622-UVOUT,B-8727-OUT;n:type:ShaderForge.SFN_Append,id:3912,x:31870,y:33286,varname:node_3912,prsc:2|A-6100-OUT,B-3656-OUT;n:type:ShaderForge.SFN_Multiply,id:8727,x:32048,y:33224,varname:node_8727,prsc:2|A-9486-T,B-3912-OUT;n:type:ShaderForge.SFN_Time,id:9486,x:31838,y:33108,varname:node_9486,prsc:2;n:type:ShaderForge.SFN_Slider,id:6100,x:31471,y:33113,ptovrint:False,ptlb:U_copy,ptin:_U_copy,varname:_U_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:1,max:10;n:type:ShaderForge.SFN_Slider,id:3656,x:31471,y:33317,ptovrint:False,ptlb:V_copy,ptin:_V_copy,varname:_V_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:1,max:10;n:type:ShaderForge.SFN_Slider,id:1268,x:32516,y:33374,ptovrint:False,ptlb:mask_power,ptin:_mask_power,varname:node_1268,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Power,id:2495,x:32863,y:32440,varname:node_2495,prsc:2|VAL-6265-RGB,EXP-2228-OUT;n:type:ShaderForge.SFN_Slider,id:2228,x:32564,y:32250,ptovrint:False,ptlb:Tex_power,ptin:_Tex_power,varname:node_2228,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:9589,x:32968,y:32758,varname:node_9589,prsc:2|A-2576-OUT,B-4767-RGB;proporder:6265-7761-9879-7695-8070-6174-6100-3656-1268-2228;pass:END;sub:END;*/

Shader "Shader Forge/uvnoise" {
    Properties {
        _TEX ("TEX", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Mask ("Mask", 2D) = "white" {}
        _glowcolor ("glowcolor", Color) = (0.5,0.5,0.5,1)
        _U ("U", Range(-10, 10)) = 1
        _V ("V", Range(-10, 10)) = 1
        _U_copy ("U_copy", Range(-10, 10)) = 1
        _V_copy ("V_copy", Range(-10, 10)) = 1
        _mask_power ("mask_power", Range(0, 10)) = 0
        _Tex_power ("Tex_power", Range(0, 10)) = 1
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
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles metal 
            #pragma target 3.0
            uniform sampler2D _TEX; uniform float4 _TEX_ST;
            uniform float4 _Color;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float4 _glowcolor;
            uniform float _U;
            uniform float _V;
            uniform float _U_copy;
            uniform float _V_copy;
            uniform float _mask_power;
            uniform float _Tex_power;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_3476 = _Time;
                float2 node_5153 = (i.uv0+(node_3476.g*float2(_U,_V)));
                float4 _TEX_var = tex2D(_TEX,TRANSFORM_TEX(node_5153, _TEX));
                float4 node_9486 = _Time;
                float2 node_7896 = (i.uv0+(node_9486.g*float2(_U_copy,_V_copy)));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_7896, _Mask));
                float3 node_2576 = (pow(_TEX_var.rgb,_Tex_power)*_Color.rgb*_Color.a*_Mask_var.rgb*i.vertexColor.a);
                float3 emissive = (node_2576*i.vertexColor.rgb);
                float3 finalColor = emissive + (node_2576*_glowcolor.rgb*i.vertexColor.a*_mask_power);
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles metal 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
