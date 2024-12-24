// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32716,y:32678,varname:node_4795,prsc:2|emission-2393-OUT,alpha-798-OUT,clip-1177-R;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32156,y:32548,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2474-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32495,y:32678,varname:node_2393,prsc:2|A-5567-OUT,B-2053-RGB,C-797-RGB,D-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32069,y:32739,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32069,y:32902,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32069,y:33061,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:798,x:32495,y:32872,varname:node_798,prsc:2|A-6074-A,B-2053-A,C-797-A;n:type:ShaderForge.SFN_Tex2d,id:1177,x:32495,y:33100,ptovrint:False,ptlb:clip,ptin:_clip,varname:node_1177,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4223-OUT;n:type:ShaderForge.SFN_Power,id:5567,x:32387,y:32482,varname:node_5567,prsc:2|VAL-6074-RGB,EXP-6809-OUT;n:type:ShaderForge.SFN_Slider,id:6809,x:32213,y:32352,ptovrint:False,ptlb:power,ptin:_power,varname:node_6809,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Append,id:7068,x:31567,y:32573,varname:node_7068,prsc:2|A-3413-OUT,B-9424-OUT;n:type:ShaderForge.SFN_Slider,id:3413,x:31260,y:32509,ptovrint:False,ptlb:U,ptin:_U,varname:node_3413,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Slider,id:9424,x:31244,y:32674,ptovrint:False,ptlb:V,ptin:_V,varname:node_9424,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:7278,x:31765,y:32573,varname:node_7278,prsc:2|A-8554-T,B-7068-OUT;n:type:ShaderForge.SFN_Time,id:8554,x:31567,y:32390,varname:node_8554,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:1124,x:31765,y:32334,varname:node_1124,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:2474,x:31991,y:32548,varname:node_2474,prsc:2|A-1124-UVOUT,B-7278-OUT;n:type:ShaderForge.SFN_Append,id:121,x:31639,y:33176,varname:node_121,prsc:2|A-9270-OUT,B-4592-OUT;n:type:ShaderForge.SFN_Slider,id:9270,x:31198,y:33061,ptovrint:False,ptlb:U(clip),ptin:_Uclip,varname:node_9270,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Slider,id:4592,x:31241,y:33200,ptovrint:False,ptlb:V(clip),ptin:_Vclip,varname:node_4592,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:6111,x:31815,y:33129,varname:node_6111,prsc:2|A-279-T,B-121-OUT;n:type:ShaderForge.SFN_Time,id:279,x:31639,y:33017,varname:node_279,prsc:2;n:type:ShaderForge.SFN_Add,id:4223,x:32069,y:33146,varname:node_4223,prsc:2|A-7974-UVOUT,B-6111-OUT;n:type:ShaderForge.SFN_TexCoord,id:7974,x:31784,y:32969,varname:node_7974,prsc:2,uv:0,uaff:False;proporder:6074-797-6809-3413-9424-1177-9270-4592;pass:END;sub:END;*/

Shader "Shader Forge/water_ramp" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _power ("power", Range(0, 5)) = 0
        _U ("U", Range(-5, 5)) = 0
        _V ("V", Range(-5, 5)) = 0
        _clip ("clip", 2D) = "white" {}
        _Uclip ("U(clip)", Range(-5, 5)) = 0
        _Vclip ("V(clip)", Range(-5, 5)) = 0
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform sampler2D _clip; uniform float4 _clip_ST;
            uniform float _power;
            uniform float _U;
            uniform float _V;
            uniform float _Uclip;
            uniform float _Vclip;
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
                float4 node_279 = _Time;
                float2 node_4223 = (i.uv0+(node_279.g*float2(_Uclip,_Vclip)));
                float4 _clip_var = tex2D(_clip,TRANSFORM_TEX(node_4223, _clip));
                clip(_clip_var.r - 0.5);
////// Lighting:
////// Emissive:
                float4 node_8554 = _Time;
                float2 node_2474 = (i.uv0+(node_8554.g*float2(_U,_V)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_2474, _MainTex));
                float3 emissive = (pow(_MainTex_var.rgb,_power)*i.vertexColor.rgb*_TintColor.rgb*2.0);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_MainTex_var.a*i.vertexColor.a*_TintColor.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
