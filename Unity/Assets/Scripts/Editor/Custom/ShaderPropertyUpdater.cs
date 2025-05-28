using UnityEditor;
using UnityEngine;


public class ShaderPropertyUpdater : EditorWindow
{
    [MenuItem("Tools/Update Shader Properties")]
    static void UpdateShaderProperties()
    {
        string targetShaderName = "Raygeas/Suntail Foliage"; // �޸ĺ��Shader����

        // ������Ҫ���µ�����ӳ�䣬֧�ֶ�����������
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

        // �������в���
        string[] guids = AssetDatabase.FindAssets("t:Material");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null && mat.shader.name == targetShaderName)
            {
                bool materialModified = false;

                // ����ÿ������ӳ��
                foreach (var mapping in propertyMappings)
                {
                    if (mat.HasProperty(mapping.oldName))
                    {
                        try
                        {
                            switch (mapping.type)
                            {
                                case ShaderUtil.ShaderPropertyType.TexEnv:
                                    // �����������ԣ�����Texture2D��Texture2DArray
                                    Texture tex = mat.GetTexture(mapping.oldName);
                                    if (tex != null)
                                    {
                                        mat.SetTexture(mapping.newName, tex);
                                        materialModified = true;
                                    }
                                    break;

                                case ShaderUtil.ShaderPropertyType.Float:
                                case ShaderUtil.ShaderPropertyType.Range:
                                    // ������ͷ�Χ����
                                    float floatValue = mat.GetFloat(mapping.oldName);
                                    mat.SetFloat(mapping.newName, floatValue);
                                    materialModified = true;
                                    break;

                                case ShaderUtil.ShaderPropertyType.Color:
                                    // ������ɫ����
                                    Color colorValue = mat.GetColor(mapping.oldName);
                                    mat.SetColor(mapping.newName, colorValue);
                                    materialModified = true;
                                    break;
                            }
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogError($"������� {mat.name} ������ {mapping.oldName} ʱ����: {e.Message}");
                        }
                    }
                }

                if (materialModified)
                {
                    EditorUtility.SetDirty(mat); // ��ǲ���Ϊ��
                }
            }
        }

        AssetDatabase.SaveAssets(); // �������
        Debug.Log("Shader���Ը������!");
    }
}


    //[MenuItem("Tools/Update Shader Properties")]
    //static void UpdateShaderProperties()
    //{
    //    string targetShaderName = "Raygeas/Suntail Surface"; // �޸ĺ��Shader����
    //    string oldPropertyName = "_Emission"; // ��������
    //    string newPropertyName = "_BumpMap"; // ��������

    //    // �������в���
    //    string[] guids = AssetDatabase.FindAssets("t:Material");
    //    foreach (string guid in guids)
    //    {
    //        string path = AssetDatabase.GUIDToAssetPath(guid);
    //        Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);
    //        if (mat.shader.name == targetShaderName)
    //        {
    //            // ���������Ƿ����
    //            if (mat.HasProperty(oldPropertyName))
    //            {
    //                Texture tex = mat.GetTexture(oldPropertyName);
    //                if (tex != null)
    //                {
    //                    // ����������ͼ��ֵ��������
    //                    mat.SetTexture(newPropertyName, tex);
    //                    EditorUtility.SetDirty(mat); // ��ǲ���Ϊ��
    //                }
    //            }
    //        }
    //    }
    //    AssetDatabase.SaveAssets(); // �������
    //}
