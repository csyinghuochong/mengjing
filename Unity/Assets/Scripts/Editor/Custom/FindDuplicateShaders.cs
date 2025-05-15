using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ET.Client
{
    public static class FindDuplicateShaders
    {
        [MenuItem("Tools/Shader同名查找")]
        public static void FindDuplicates()
        {
            string[] guids = AssetDatabase.FindAssets("t:Shader");
            Dictionary<string, List<string>> shaderMap = new Dictionary<string, List<string>>();

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(path);
                if (shader == null) continue;

                string name = shader.name;
                if (!shaderMap.ContainsKey(name))
                    shaderMap[name] = new List<string>();
                shaderMap[name].Add(path);
            }

            var duplicates = shaderMap.Where(kvp => kvp.Value.Count > 1).ToList();

            if (duplicates.Count == 0)
            {
                Debug.Log("<color=green>没有找到同名Shader.</color>");
                return;
            }

            Debug.Log($"<color=orange>找到{duplicates.Count}个同名Shader name(s):</color>\n");

            int index = 1;
            foreach (var kvp in duplicates)
            {
                Debug.Log($"<color=yellow>▶({index}) Shader Name: {kvp.Key}</color>");
                foreach (string path in kvp.Value)
                {
                    Debug.Log($"    <color=cyan>• {path}</color>");
                }

                index++;
            }
        }
    }
}