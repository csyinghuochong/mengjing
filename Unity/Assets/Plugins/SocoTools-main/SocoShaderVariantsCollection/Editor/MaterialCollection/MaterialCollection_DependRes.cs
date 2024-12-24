using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Soco.ShaderVariantsCollection
{
    
    //用于获取资源表所引用的资源
    //注意，这个类并不在Soco.ShaderVariantsCollection名空间下，因为理想中，这个类是依赖于工程，而非工具的功能，所以继承时用到了类包含namespace的全名
    public sealed class MaterialCollection_DependRes : IMaterialCollector
    {
        private List<string> GetConfigFile()
        {
            //return new List<string>() { "Assets/Bundles/" };
            List<string> allasset =   new List<string>();
            string assetpath = "Assets/Bundles/";

            //获取assetpath 下的所有资源已经引用到的所有资源。填充到allasset
            
            return allasset;
        }

        public override void AddMaterialBuildDependency(IList<Material> buildDependencyList)
        {
            //获取资源表中所有资源....
            List<string> resList = GetConfigFile();
            foreach (string res in resList)
            {
                //如果资源本身是材质，则直接添加到列表中
                if (res.EndsWith(".mat"))
                {
                    Material mat = AssetDatabase.LoadAssetAtPath<Material>(res);
                    if(mat != null)
                        buildDependencyList.Add(mat);
                }
                //如果不是材质，则找到资源所引用的材质添加到列表中
                // else
                // {
                //     foreach (string depRes in AssetDatabase.GetDependencies(res))
                //     {
                //         if (depRes.EndsWith(".mat"))
                //         {
                //             Material mat = AssetDatabase.LoadAssetAtPath<Material>(depRes);
                //             if(mat != null)
                //                 buildDependencyList.Add(mat);
                //         }
                //     }
                // }
            }
        }
    }

}

