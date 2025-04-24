Shader "E3DEffect/C1/AirWave" {
Properties {
    _NoiseTex ("Noise Texture (RG)", 2D) = "white" {}
    _MainTex ("Alpha (A)", 2D) = "white" {}
    _HeatTime ("Heat Time", range (0,1.5)) = 1
    _HeatForce ("Heat Force", range (0,6)) = 0.1
    _GrabTexture ("Grab Texture", 2D) = "black" {} // 新增的属性，用于接收抓取的屏幕纹理
}

SubShader {
    Tags { "Queue"="Transparent+1" "RenderType"="Transparent" }
    Blend SrcAlpha OneMinusSrcAlpha
    Cull Off Lighting Off ZWrite Off ZTest LEqual
    
    Pass {
        Name "BASE"
        Tags { "LightMode" = "UniversalForward" } // 修改为URP的LightMode
        
        HLSLINCLUDE
        #pragma vertex vert
        #pragma fragment frag
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        struct appdata_t {
            float4 vertex : POSITION;
            float2 texcoord : TEXCOORD0;
        };

        struct v2f {
            float4 vertex : SV_POSITION;
            float4 uvgrab : TEXCOORD0;
            float2 uvmain : TEXCOORD1;
        };

        float _HeatForce;
        float _HeatTime;
        float4 _MainTex_ST;
        float4 _NoiseTex_ST;
        sampler2D _NoiseTex;
        sampler2D _MainTex;
        sampler2D _GrabTexture; // 新增的采样器，用于抓取的屏幕纹理

        v2f vert (appdata_t v)
        {
            v2f o;
            o.vertex = TransformObjectToHClip(v.vertex);
            o.uvgrab = TransformObjectToHClip(v.vertex); // 使用同样的方法计算uvgrab
            o.uvmain = TRANSFORM_TEX(v.texcoord, _MainTex);
            return o;
        }

        half4 frag(v2f i) : SV_Target
        {
            // noise effect
            half4 offsetColor1 = tex2D(_NoiseTex, i.uvmain + _TimeParameters.xz * _HeatTime);
            half4 offsetColor2 = tex2D(_NoiseTex, i.uvmain - _TimeParameters.yx * _HeatTime);
            i.uvgrab.x += ((offsetColor1.r + offsetColor1.r) - 1) * _HeatForce;
            i.uvgrab.y += ((offsetColor2.g + offsetColor2.g) - 1) * _HeatForce;

            half4 col = tex2D(_GrabTexture, i.uvgrab.xy / i.uvgrab.w); // 使用抓取的屏幕纹理
            col.a = 1.0f;
            half4 tint = tex2D(_MainTex, i.uvmain);
            tint.rgb = 1.0f;

            return col * tint;
        }
        ENDHLSL
    }
}

Fallback "Transparent/Cutout/VertexLit"
}