using UnityEditor;
using UnityEngine;

namespace ClientEditor
{
    class UIEditorController
    {
        [MenuItem("GameObject/SpawnEUICode", false, -2)]
        static public void CreateNewCode()
        {
            GameObject go = Selection.activeObject as GameObject;
            UICodeSpawner.SpawnEUICode(go);
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
