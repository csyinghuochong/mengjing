Shader"MyShader/P1_1_6"
{
    Properties
    {
        //命名要按标准来，这个属性才可以和Unity组件中的属性产生关联
        //比如说，在更改 Image 的源图片时，同时更改这个
        [PerRendererData]_MainTex("MainTex",2D) = "white"{}
        //暴露一个变量来供模板测试中 Ref 使用
        _Ref("Stencil Ref",int) = 0
        //暴露一个变量来供模板测试中 Comp 使用
        [Enum(UnityEngine.Rendering.CompareFunction)]_StencilComp("Stencil Comp",int) = 0
        
        [Enum(UnityEngine.Rendering.StencilOp)]_StencilOp("Stencil Op",int) = 0
    }
    
    SubShader
    {
        //更改渲染队列（UI的渲染队列一般是半透明层的）
        Tags {"Queue" = "TransParent"}
        //混合模式
        Blend SrcAlpha OneMinusSrcAlpha
        
        Stencil
        {
            Ref [_Ref]
            //以下两个属性一般不做修改
            //ReadMask [_StencilReadMask]
            //WriteMask [_StencilWriteMask]
            Comp [_StencilComp]
            Pass [_StencilOp]
            //Fail [_Fail]
            //ZFail [_ZFail]
        }
        Pass
        {
            CGPROGRAM
            #pragma vertex  vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            //存储 应用程序输入到顶点着色器的信息
            struct appdata
            {
                //顶点信息
                float4 vertex:POSITION;
                float2 uv : TEXCOORD;
                //这里定义一个语义为Color的4维向量，用于传入顶点颜色,设置语义为COLOR后，这个变量就会与顶点颜色对应
                fixed4 color:COLOR;
            };
            //存储 顶点着色器输入到片元着色器的信息
            struct v2f
            {
                //裁剪空间下的位置信息（SV_POSITION是必须的）
                float4 pos:SV_POSITION;
                float2 uv : TEXCOORD;
                //这里的语义主要代表精度不同，TEXCOORD 在这里只是代表高精度
                fixed4 color : TEXCOORD1;
            };
            
            sampler2D _MainTex;
            fixed4 _Color;
            v2f vert(appdata v)
            {
                v2f o;
                //把顶点信息转化到裁剪坐标下
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }
            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 mainTex = tex2D(_MainTex,i.uv);
                return  mainTex * i.color;
            }
            
            ENDCG
        }
    }
}