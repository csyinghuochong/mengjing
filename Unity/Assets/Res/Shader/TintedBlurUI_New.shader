Shader "Custom/ScreenGaussianBlur_Final"
{
    Properties
    {
         [PerRendererData]_MainTex ("Base Texture", 2D) = "white" {}
        _BlurStrength ("Blur Strength", Range(0, 10)) = 1.0
        _BlurSampleCount ("Sample Count", Range(1, 5)) = 3
        [Toggle(_USE_ALPHA_CONTROL)] _AlphaControl ("Use Alpha Control", Float) = 0
        _BlurIterations ("Blur Iterations", Range(1, 3)) = 1
    }

    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Opaque" }
        ZWrite Off
        Blend One OneMinusSrcAlpha
        
        // 水平模糊Pass
        Pass
        {
            Name "HBLUR"
            CGPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag
            #pragma target 3.0
            
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float baseStrength : TEXCOORD1;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _BlurStrength;
            float _BlurSampleCount;
            int _USE_ALPHA_CONTROL;
            int _BlurIterations;
            
            v2f Vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.baseStrength = _BlurStrength;
                return o;
            }
            
            fixed4 Frag(v2f i) : SV_Target
            {
                // 采样主纹理获取颜色和alpha
                fixed4 texColor = tex2D(_MainTex, i.uv);
                float alpha = texColor.a;
                
                // 计算有效模糊强度（alpha=0时模糊为0）
                float effectiveStrength = i.baseStrength;
                if (_USE_ALPHA_CONTROL == 1)
                {
                    effectiveStrength = i.baseStrength * alpha;
                    effectiveStrength = max(effectiveStrength, 0.0);
                }
                
                // 计算采样偏移量（基于有效强度）
                float2 step = _MainTex_TexelSize.xy * 2.0 * effectiveStrength;
                
                // 高斯模糊权重（5x5采样点）
                float weights[5] = {0.05, 0.2, 0.3, 0.2, 0.05};
                int sampleCount = min((int)_BlurSampleCount, 5);
                
                // 水平方向模糊计算
                fixed4 sum = texColor * weights[2];
                if (sampleCount > 1) sum += tex2D(_MainTex, i.uv + step * float2(-1, 0)) * weights[1];
                if (sampleCount > 1) sum += tex2D(_MainTex, i.uv + step * float2(1, 0)) * weights[1];
                if (sampleCount > 3) sum += tex2D(_MainTex, i.uv + step * float2(-2, 0)) * weights[0];
                if (sampleCount > 3) sum += tex2D(_MainTex, i.uv + step * float2(2, 0)) * weights[0];
                
                // 保持主纹理alpha值
                sum.a = texColor.a;
                return sum;
            }
            ENDCG
        }
        
        // 垂直模糊Pass
        Pass
        {
            Name "VBLUR"
            CGPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag
            #pragma target 3.0
            
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float baseStrength : TEXCOORD1;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _BlurStrength;
            float _BlurSampleCount;
            int _USE_ALPHA_CONTROL;
            int _BlurIterations;
            
            v2f Vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.baseStrength = _BlurStrength;
                return o;
            }
            
            fixed4 Frag(v2f i) : SV_Target
            {
                // 采样主纹理获取颜色和alpha
                fixed4 texColor = tex2D(_MainTex, i.uv);
                float alpha = texColor.a;
                
                // 计算有效模糊强度
                float effectiveStrength = i.baseStrength;
                if (_USE_ALPHA_CONTROL == 1)
                {
                    effectiveStrength = i.baseStrength * alpha;
                    effectiveStrength = max(effectiveStrength, 0.0);
                }
                
                // 计算采样偏移量
                float2 step = _MainTex_TexelSize.xy * 2.0 * effectiveStrength;
                
                // 高斯模糊权重
                float weights[5] = {0.05, 0.2, 0.3, 0.2, 0.05};
                int sampleCount = min((int)_BlurSampleCount, 5);
                
                // 垂直方向模糊计算
                fixed4 sum = texColor * weights[2];
                if (sampleCount > 1) sum += tex2D(_MainTex, i.uv + step * float2(0, -1)) * weights[1];
                if (sampleCount > 1) sum += tex2D(_MainTex, i.uv + step * float2(0, 1)) * weights[1];
                if (sampleCount > 3) sum += tex2D(_MainTex, i.uv + step * float2(0, -2)) * weights[0];
                if (sampleCount > 3) sum += tex2D(_MainTex, i.uv + step * float2(0, 2)) * weights[0];
                
                // 保持主纹理alpha值
                sum.a = texColor.a;
                return sum;
            }
            ENDCG
        }
    }
    
    FallBack "Diffuse"
}