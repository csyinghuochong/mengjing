using System.IO;
using UnityEditor;
using UnityEngine;

namespace ClientEditor
{
    class UIEditorController
    {
        [MenuItem("GameObject/SpawnEUICode", false, -2)]
        public static void CreateNewCode()
        {
            GameObject go = Selection.activeObject as GameObject;
            UICodeSpawner.SpawnEUICode(go);
        }
        
        [MenuItem("GameObject/SpawnEUICode-UI组件自动生成(为Button自动注册方法)", false, -1)]
        public static void CreateUICode()
        {
            GameObject go = Selection.activeObject as GameObject;
            UICodeSpawner.SpawnUICode(go);
        }
        
        [MenuItem("Assets/EUITool/所有UI组件自动生成(为文件夹或Prefab中的所有Button自动注册方法)", false)]
        public static void CreateUICodeForFolderOrPrefab()
        {
            string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (Directory.Exists(assetPath))
            {
                string[] prefabPaths = Directory.GetFiles(assetPath, "*.prefab", SearchOption.AllDirectories);
                foreach (string prefabPath in prefabPaths)
                {
                    GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                    if (prefab != null)
                    {
                        UICodeSpawner.SpawnUICode(prefab);
                    }
                }
            }
            else if (PrefabUtility.IsPartOfAnyPrefab(Selection.activeObject))
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
                if (prefab != null)
                {
                    UICodeSpawner.SpawnUICode(prefab);
                }
            }
        }

        [MenuItem("Assets/AssetBundle/NameUIPrefab")]
        public static void NameAllUIPrefab()
        {
            string suffix = ".unity3d";
            Object[] selectAsset = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);
            for (int i = 0; i < selectAsset.Length; i++)
            {
                string prefabName = AssetDatabase.GetAssetPath(selectAsset[i]);
                //MARKER：判断是否是.prefab
                if (prefabName.EndsWith(".prefab"))
                {
                    Debug.Log(prefabName);
                    AssetImporter importer = AssetImporter.GetAtPath(prefabName);
                    importer.assetBundleName = selectAsset[i].name.ToLower() + suffix;
                }

            }
            AssetDatabase.Refresh();
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }

        [MenuItem("Assets/AssetBundle/ClearABName")]
        public static void ClearABName()
        {
            Object[] selectAsset = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);
            for (int i = 0; i < selectAsset.Length; i++)
            {
                string prefabName = AssetDatabase.GetAssetPath(selectAsset[i]);
                AssetImporter importer = AssetImporter.GetAtPath(prefabName);
                importer.assetBundleName = string.Empty;
                Debug.Log(prefabName);
            }
            AssetDatabase.Refresh();
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }
    }
}
