using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace ET.Client
{

    class MyCustomBuildProcessor: IPreprocessShaders
    {

        public MyCustomBuildProcessor()
        {

        }

        public int callbackOrder
        {
            get
            {
                return 0;
            }
        }

        public void OnProcessShader(Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data)
        {
            //ShaderKeyword localKeywordRed = new ShaderKeyword(shader, "_RED");
            for (int i = data.Count - 1; i >= 0; --i)
            {
                ShaderCompilerData input = data[i];

                // if (input.shaderKeywordSet.IsEnabled(new ShaderKeyword("INSTANCING_ON"))
                //     || input.shaderKeywordSet.IsEnabled(new ShaderKeyword(shader, "INSTANCING_ON"))
                //     || input.shaderKeywordSet.IsEnabled(new ShaderKeyword(shader, "_ADDITIONAL_LIGHT_SHADOWS"))
                //     || input.shaderKeywordSet.IsEnabled(new ShaderKeyword(shader, "_ADDITIONAL_LIGHTS")))
                // {
                //     data.RemoveAt(i);
                // }
            }
        }
    }
}
   