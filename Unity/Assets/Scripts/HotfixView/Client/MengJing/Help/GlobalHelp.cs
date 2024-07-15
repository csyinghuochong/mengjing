using UnityEngine;

namespace ET.Client
{
    public static class GlobalHelp
    {
        public static int GetVersionMode()
        {
            return GameObject.Find("Global").GetComponent<Init>().VersionMode;
        }

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

        public static int GetPlatform()
        {
            // #if UNITY_IPHONE || UNITY_IOS
            //             return 20001;
            // #else
            //             if (GetBigVersion() < 15)
            //             {
            //                 return 0;
            //             }
            //
            //             if (GetBigVersion() > 18)
            //             {
            //             }
            //
            //             return GameObject.Find("Global").GetComponent<Init>().Platform;
            // #endif

            return 0;
        }

        public static int GetBigVersion()
        {
            //             if (BigVersion != -1)
            //             {
            //                 return BigVersion;
            //             }
            //
            // #if UNITY_IPHONE || UNITY_IOS
            //             BigVersion =  GameObject.Find("Global").GetComponent<Init>().BigVersionIOS;
            //             return BigVersion;
            // #else
            //             BigVersion =  GameObject.Find("Global").GetComponent<Init>().BigVersion;
            //             return BigVersion;
            // #endif
            return 1;
        }
    }
}