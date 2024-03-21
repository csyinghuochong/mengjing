using UnityEngine;

namespace ET.Client
{
    public static class GlobalHelp
    {
        public static Shader Find(string path)
        {
            Shader shader = null;
            GlobalData.ShaderList.TryGetValue(path, out shader);
            if (shader == null)
            {
                shader = Shader.Find(path);
                if (GlobalData.ShaderList.ContainsKey(path))
                {
                    GlobalData.ShaderList[path] = shader;
                }
                else
                {
                    GlobalData.ShaderList.Add(path, shader);
                }
            }

            return shader;
        }
    }
}