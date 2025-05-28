using UnityEditor;
using UnityEngine;


public class ShaderPropertyUpdater : EditorWindow
{
    [MenuItem("Tools/Update Shader Properties")]
    static void UpdateShaderProperties()
    {
        string targetShaderName = "Raygeas/Suntail Foliage"; // 修改后的Shader名称

        // 定义需要更新的属性映射，支持多种属性类型
        var propertyMappings = new (string oldName, string newName, ShaderUtil.ShaderPropertyType type)[]
        {
            ("_SmoothnessTexture", "_MetallicGlossMap", ShaderUtil.ShaderPropertyType.TexEnv),
            //("_Color", "_BaseColor", ShaderUtil.ShaderPropertyType.Color),
            //("_SurfaceSmoothness", "_Smoothness", ShaderUtil.ShaderPropertyType.Range),
            //("_MetallicSmoothness", "_MetallicGlossMap", ShaderUtil.ShaderPropertyType.TexEnv),
            //("_OldFloatProperty", "_NewFloatProperty", ShaderUtil.ShaderPropertyType.Float),
            //("_OldRangeProperty", "_NewRangeProperty", ShaderUtil.ShaderPropertyType.Range),
            //("_OldColorProperty", "_NewColorProperty", ShaderUtil.ShaderPropertyType.Color),
            //("_OldTexArrayProperty", "_NewTexArrayProperty", ShaderUtil.ShaderPropertyType.TexEnv),
        };

        // 遍历所有材质
        string[] guids = AssetDatabase.FindAssets("t:Material");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null && mat.shader.name == targetShaderName)
            {
                bool materialModified = false;

                // 处理每个属性映射
                foreach (var mapping in propertyMappings)
                {
                    if (mat.HasProperty(mapping.oldName))
                    {
                        try
                        {
                            switch (mapping.type)
                            {
                                case ShaderUtil.ShaderPropertyType.TexEnv:
                                    // 处理纹理属性，包括Texture2D和Texture2DArray
                                    Texture tex = mat.GetTexture(mapping.oldName);
                                    if (tex != null)
                                    {
                                        mat.SetTexture(mapping.newName, tex);
                                        materialModified = true;
                                    }
                                    break;

                                case ShaderUtil.ShaderPropertyType.Float:
                                case ShaderUtil.ShaderPropertyType.Range:
                                    // 处理浮点和范围属性
                                    float floatValue = mat.GetFloat(mapping.oldName);
                                    mat.SetFloat(mapping.newName, floatValue);
                                    materialModified = true;
                                    break;

                                case ShaderUtil.ShaderPropertyType.Color:
                                    // 处理颜色属性
                                    Color colorValue = mat.GetColor(mapping.oldName);
                                    mat.SetColor(mapping.newName, colorValue);
                                    materialModified = true;
                                    break;
                            }
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogError($"处理材质 {mat.name} 的属性 {mapping.oldName} 时出错: {e.Message}");
                        }
                    }
                }

                if (materialModified)
                {
                    EditorUtility.SetDirty(mat); // 标记材质为脏
                }
            }
        }

        AssetDatabase.SaveAssets(); // 保存更改
        Debug.Log("Shader属性更新完成!");
    }
}


    //[MenuItem("Tools/Update Shader Properties")]
    //static void UpdateShaderProperties()
    //{
    //    string targetShaderName = "Raygeas/Suntail Surface"; // 修改后的Shader名称
    //    string oldPropertyName = "_Emission"; // 旧属性名
    //    string newPropertyName = "_BumpMap"; // 新属性名

    //    // 遍历所有材质
    //    string[] guids = AssetDatabase.FindAssets("t:Material");
    //    foreach (string guid in guids)
    //    {
    //        string path = AssetDatabase.GUIDToAssetPath(guid);
    //        Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);
    //        if (mat.shader.name == targetShaderName)
    //        {
    //            // 检查旧属性是否存在
    //            if (mat.HasProperty(oldPropertyName))
    //            {
    //                Texture tex = mat.GetTexture(oldPropertyName);
    //                if (tex != null)
    //                {
    //                    // 将旧属性贴图赋值给新属性
    //                    mat.SetTexture(newPropertyName, tex);
    //                    EditorUtility.SetDirty(mat); // 标记材质为脏
    //                }
    //            }
    //        }
    //    }
    //    AssetDatabase.SaveAssets(); // 保存更改
    //}
