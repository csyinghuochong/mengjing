// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-2393-OUT,custl-3975-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32172,y:32534,ptovrint:False,ptlb:tex,ptin:_tex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9962-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32433,y:32729,varname:node_2393,prsc:2|A-1708-OUT,B-2053-A,C-797-RGB,D-6158-RGB,E-797-A;n:type:ShaderForge.SFN_VertexColor,id:2053,x:31999,y:33030,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32122,y:32879,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_TexCoord,id:9398,x:31353,y:32333,varname:node_9398,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:6158,x:31999,y:33190,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_6158,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2315-OUT;n:type:ShaderForge.SFN_Slider,id:4640,x:30900,y:32863,ptovrint:False,ptlb:U,ptin:_U,varname:node_4640,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:0,max:10;n:type:ShaderForge.SFN_Slider,id:1091,x:30900,y:33038,ptovrint:False,ptlb:v,ptin:_v,varname:node_1091,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:0,max:10;n:type:ShaderForge.SFN_Add,id:9962,x:31815,y:32566,varname:node_9962,prsc:2|A-5366-UVOUT,B-2078-OUT;n:type:ShaderForge.SFN_Multiply,id:2078,x:31628,y:32695,varname:node_2078,prsc:2|A-9763-T,B-374-OUT;n:type:ShaderForge.SFN_Append,id:374,x:31312,y:32964,varname:node_374,prsc:2|A-4640-OUT,B-1091-OUT;n:type:ShaderForge.SFN_Time,id:9763,x:31400,y:32705,varname:node_9763,prsc:2;n:type:ShaderForge.SFN_Slider,id:4187,x:32257,y:33310,ptovrint:False,ptlb:liangdu,ptin:_liangdu,varname:node_4187,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:20;n:type:ShaderForge.SFN_Power,id:1708,x:32473,y:32525,varname:node_1708,prsc:2|VAL-6074-RGB,EXP-5505-OUT;n:type:ShaderForge.SFN_Slider,id:5505,x:32109,y:32434,ptovrint:False,ptlb:duibi,ptin:_duibi,varname:node_5505,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:3975,x:32509,y:32982,varname:node_3975,prsc:2|A-2393-OUT,B-4187-OUT,C-2053-A,D-6324-RGB;n:type:ShaderForge.SFN_Color,id:6324,x:32571,y:33214,ptovrint:False,ptlb:glowcolor,ptin:_glowcolor,varname:node_6324,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Rotator,id:5366,x:31484,y:32529,varname:node_5366,prsc:2|UVIN-9398-UVOUT,ANG-54-OUT,SPD-9062-OUT;n:type:ShaderForge.SFN_Slider,id:9062,x:31044,y:32744,ptovrint:False,ptlb:UVrotator,ptin:_UVrotator,varname:node_9062,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:5,max:5;n:type:ShaderForge.SFN_Slider,id:54,x:30799,y:32564,ptovrint:False,ptlb:jiao'dujiao'du,ptin:_jiaodujiaodu,varname:node_54,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:45,max:360;n:type:ShaderForge.SFN_TexCoord,id:6132,x:31135,y:33188,varname:node_6132,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:8833,x:30893,y:33540,ptovrint:False,ptlb:U_mask,ptin:_U_mask,varname:_U_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:0,max:10;n:type:ShaderForge.SFN_Slider,id:8224,x:30893,y:33715,ptovrint:False,ptlb:v_mask,ptin:_v_mask,varname:_v_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:0,max:10;n:type:ShaderForge.SFN_Add,id:2315,x:31747,y:33229,varname:node_2315,prsc:2|A-918-UVOUT,B-360-OUT;n:type:ShaderForge.SFN_Multiply,id:360,x:31592,y:33436,varname:node_360,prsc:2|A-6696-T,B-4806-OUT;n:type:ShaderForge.SFN_Append,id:4806,x:31305,y:33641,varname:node_4806,prsc:2|A-8833-OUT,B-8224-OUT;n:type:ShaderForge.SFN_Time,id:6696,x:31333,y:33396,varname:node_6696,prsc:2;n:type:ShaderForge.SFN_Rotator,id:918,x:31416,y:33192,varname:node_918,prsc:2|UVIN-6132-UVOUT,ANG-2463-OUT,SPD-972-OUT;n:type:ShaderForge.SFN_Slider,id:972,x:30976,y:33407,ptovrint:False,ptlb:UVrotator_mask,ptin:_UVrotator_mask,varname:_UVrotator_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:5,max:5;n:type:ShaderForge.SFN_Slider,id:2463,x:30731,y:33227,ptovrint:False,ptlb:jiao'dujiao'du_mask,ptin:_jiaodujiaodu_mask,varname:_jiaodujiaodu_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:45,max:360;proporder:6074-797-6158-4640-1091-4187-5505-6324-9062-54-8833-8224-972-2463;pass:END;sub:END;*/

Shader "Shader Forge/henshuuv" {
    Properties {
        _tex ("tex", 2D) = "white" {}
        [HDR]_TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _mask ("mask", 2D) = "white" {}
        _U ("U", Range(-10, 10)) = 0
        _v ("v", Range(-10, 10)) = 0
        _liangdu ("liangdu", Range(0, 20)) = 0
        _duibi ("duibi", Range(0, 10)) = 1
        [HDR]_glowcolor ("glowcolor", Color) = (0.5,0.5,0.5,1)
        _UVrotator ("UVrotator", Range(-5, 5)) = 5
        _jiaodujiaodu ("jiao'dujiao'du", Range(0, 360)) = 45
        _U_mask ("U_mask", Range(-10, 10)) = 0
        _v_mask ("v_mask", Range(-10, 10)) = 0
        _UVrotator_mask ("UVrotator_mask", Range(-5, 5)) = 5
        _jiaodujiaodu_mask ("jiao'dujiao'du_mask", Range(0, 360)) = 45
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _tex; uniform float4 _tex_ST;
            uniform float4 _TintColor;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float _U;
            uniform float _v;
            uniform float _liangdu;
            uniform float _duibi;
            uniform float4 _glowcolor;
            uniform float _UVrotator;
            uniform float _jiaodujiaodu;
            uniform float _U_mask;
            uniform float _v_mask;
            uniform float _UVrotator_mask;
            uniform float _jiaodujiaodu_mask;
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
                float node_5366_ang = _jiaodujiaodu;
                float node_5366_spd = _UVrotator;
                float node_5366_cos = cos(node_5366_spd*node_5366_ang);
                float node_5366_sin = sin(node_5366_spd*node_5366_ang);
                float2 node_5366_piv = float2(0.5,0.5);
                float2 node_5366 = (mul(i.uv0-node_5366_piv,float2x2( node_5366_cos, -node_5366_sin, node_5366_sin, node_5366_cos))+node_5366_piv);
                float4 node_9763 = _Time;
                float2 node_9962 = (node_5366+(node_9763.g*float2(_U,_v)));
                float4 _tex_var = tex2D(_tex,TRANSFORM_TEX(node_9962, _tex));
                float node_918_ang = _jiaodujiaodu_mask;
                float node_918_spd = _UVrotator_mask;
                float node_918_cos = cos(node_918_spd*node_918_ang);
                float node_918_sin = sin(node_918_spd*node_918_ang);
                float2 node_918_piv = float2(0.5,0.5);
                float2 node_918 = (mul(i.uv0-node_918_piv,float2x2( node_918_cos, -node_918_sin, node_918_sin, node_918_cos))+node_918_piv);
                float4 node_6696 = _Time;
                float2 node_2315 = (node_918+(node_6696.g*float2(_U_mask,_v_mask)));
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(node_2315, _mask));
                float3 node_2393 = (pow(_tex_var.rgb,_duibi)*i.vertexColor.a*_TintColor.rgb*_mask_var.rgb*_TintColor.a);
                float3 emissive = node_2393;
                float3 finalColor = emissive + (node_2393*_liangdu*i.vertexColor.a*_glowcolor.rgb);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
