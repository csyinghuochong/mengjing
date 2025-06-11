using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ET;
using MongoDB.Bson;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{ 
    public class SceneChecker6 : EditorWindow
    {
        
        static string sBundleCheckPath = "Assets/Bundles";
        static string sBundleUICheckPath = "Assets/Bundles/UI";
        static string sSceneCheckPath = "Assets/Bundles/Scenes";
        
     // [MenuItem("Asset / ), false, 1]
        [MenuItem("Assets/Custom/Check Dependencies", false, 1)] //路径
        public static void CheckDependencies()
        {
            string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            UnityEngine.Debug.Log("fontPath: " + fontPath);
            UnityEngine.Debug.Log("KCheckDependencies: Begin");

            string[] dependPathList = AssetDatabase.GetDependencies(new string[] { fontPath });
            foreach (string path in dependPathList)
            {
                using (var stream = File.OpenRead(path))
                {
                    long fileSize = stream.Length;
                    UnityEngine.Debug.Log(fileSize + "   " + path);
                }
            }

            UnityEngine.Debug.Log("KCheckDependencies: End");
        }

        [MenuItem("Assets/Custom/Check Dependencies Shader", false, 1)] //路径
        public static void CheckDependenciesShader()
        {
            string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            UnityEngine.Debug.Log("fontPath: " + fontPath);
            UnityEngine.Debug.Log("KCheckDependencies: Begin");

            string[] dependPathList = AssetDatabase.GetDependencies(new string[] { fontPath });
            foreach (string path in dependPathList)
            {
                if (path.Contains("Packages/com.unity.render-pipelines.universal"))
                {
                    continue;
                }

                if (path.EndsWith(".shader") || path.EndsWith(".shadergraph"))
                {
                    using (var stream = File.OpenRead(path))
                    {
                        long fileSize = stream.Length;
                        UnityEngine.Debug.Log(fileSize + "   " + path);
                    }
                }
            }

            UnityEngine.Debug.Log("KCheckDependencies: End");
        }
        
        
        // [MenuItem("Asset / ), false, 1]
        [MenuItem("Assets/Custom/Check References Bundler", false, 1)] //路径
        public static void KCheckBundleReferences()
        {
            string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);

            string[] assetPath = fontPath.Split('/');
            string fontAssetName = assetPath[assetPath.Length - 1];
            if (fontAssetName.Contains("."))
            {
                fontAssetName = fontAssetName.Split('.')[0];
            }

            UnityEngine.Debug.Log("KCheckFontReferences: Begin");

            List<string> fileList = new List<string>(Directory.GetFiles(sBundleCheckPath, "*.*", SearchOption.AllDirectories));
            //fileList.AddRange(GetFile(sBundleCheckPath, fileList));
            
            for (int i = 0; i < fileList.Count; i++)
            {
                string itemPath = fileList[i];
                if (itemPath.Contains(".meta"))
                {
                    continue;
                }
                
                string[] dependPathList = AssetDatabase.GetDependencies(new string[] { itemPath });
                foreach (string path in dependPathList)
                {
                    // string[] assetPath = path.Split('/');
                    //if (assetPath[assetPath.Length-1] == fongPath)

                    if (!path.Equals(fontPath))
                    {
                        continue;
                    }
                    
                    if (itemPath.Contains(".unity"))
                    {
                        Debug.Log($"以下场景有引用： {itemPath} ");
                        continue;
                    }

                   
                    Debug.Log($"以下文件有引用： {itemPath} ");

                    GameObject tmpObj = AssetDatabase.LoadAssetAtPath(itemPath, typeof (GameObject)) as GameObject;
                    if (tmpObj == null)
                    {
                        Debug.Log($"tmpObj == null： {itemPath} ");
                        continue;
                    }
                    //tmpObj = GameObject.Instantiate(tmpObj) as GameObject;
                    Text[] tmpAr = tmpObj.GetComponentsInChildren<Text>();
                    for (int t = 0; t < tmpAr.Length; t++)
                    {
                        Text textTemp = tmpAr[t];
                        Font fontTemp = textTemp.font;
                        if (fontTemp == null)
                        {
                            continue;
                        }

                        string assetName = fontTemp.name;
                        if (fontAssetName == assetName)
                        {
                            UnityEngine.Debug.Log($" {textTemp.name}");
                        }
                    }

                    // TextMeshPro[] tmpProAr = tmpObj.GetComponentsInChildren<TextMeshPro>();
                    // for (int t = 0; t < tmpProAr.Length; t++)
                    // {
                    //     TextMeshPro textTemp = tmpProAr[t];
                    //     TMP_FontAsset fontTemp = textTemp.font;
                    //     if (fontTemp == null)
                    //     {
                    //         continue;
                    //     }
                    //
                    //     string assetName = fontTemp.name;
                    //     if (fontAssetName == assetName)
                    //     {
                    //         UnityEngine.Debug.Log($" {textTemp.name}");
                    //     }
                    // }
                }
            }

            UnityEngine.Debug.Log("KCheckFontReferences: End");
        }

        // [MenuItem("Asset / ), false, 1]
        [MenuItem("Assets/Custom/Check References Scene", false, 1)] //路径
        public static void KCheckSceneReferences()
        {
            string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);

            string[] assetPath = fontPath.Split('/');
            string fontAssetName = assetPath[assetPath.Length - 1];
            if (fontAssetName.Contains("."))
            {
                fontAssetName = fontAssetName.Split('.')[0];
            }

            UnityEngine.Debug.Log("KCheckFontReferences: Begin");

            List<string> fileList = new List<string>(new List<string>(Directory.GetFiles(sSceneCheckPath, "*.*", SearchOption.AllDirectories)));
            //fileList.AddRange(GetFile(sSceneCheckPath, fileList));
            
            for (int i = 0; i < fileList.Count; i++)
            {
                string itemPath = fileList[i];
                if (itemPath.Contains(".meta"))
                {
                    continue;
                }

                
                string[] dependPathList = AssetDatabase.GetDependencies(new string[] { itemPath });
                foreach (string path in dependPathList)
                {
                    if (path == fontPath)
                    {
                        UnityEngine.Debug.Log($"以下文件有引用： {itemPath} ");
                    }
                }
            }

            UnityEngine.Debug.Log("KCheckFontReferences: End");
        }
        
        
        // [MenuItem("Asset / ), false, 1]
        [MenuItem("Assets/Custom/Check References Assets", false, 1)] //路径
        public static void KCheckAssetsReferences()
        {
            string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);

            string[] assetPath = fontPath.Split('/');
            string fontAssetName = assetPath[assetPath.Length - 1];
            if (fontAssetName.Contains("."))
            {
                fontAssetName = fontAssetName.Split('.')[0];
            }

            UnityEngine.Debug.Log("KCheckFontReferences: Begin");

            List<string> fileList = new List<string>(new List<string>(Directory.GetFiles("Assets", "*.*", SearchOption.AllDirectories)));
            //fileList.AddRange(GetFile(sSceneCheckPath, fileList));
            
            for (int i = 0; i < fileList.Count; i++)
            {
                string itemPath = fileList[i];
                if (itemPath.Contains(".meta"))
                {
                    continue;
                }
                
                string[] dependPathList = AssetDatabase.GetDependencies(new string[] { itemPath });
                foreach (string path in dependPathList)
                {
                    if (path == fontPath)
                    {
                        UnityEngine.Debug.Log($"以下文件有引用： {itemPath} ");
                    }
                }
            }
            UnityEngine.Debug.Log("KCheckFontReferences: End");
        }

    
        [MenuItem("Assets/Custom/Check References Bundler UI", false, 1)] //路径
        public static void KCheckBundleUIReferences()
        {
            string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);

            string[] assetPath = fontPath.Split('/');
            string fontAssetName = assetPath[assetPath.Length - 1];
            if (fontAssetName.Contains("."))
            {
                fontAssetName = fontAssetName.Split('.')[0];
            }

            UnityEngine.Debug.Log("KCheckFontReferences: Begin");

            List<string> fileList = new List<string>( Directory.GetFiles(sBundleUICheckPath, "*.*", SearchOption.AllDirectories));
            //fileList.AddRange(GetFile(sBundleUICheckPath, fileList));
            
            for (int i = 0; i < fileList.Count; i++)
            {
                string itemPath = fileList[i];
                if (itemPath.Contains(".meta"))
                {
                    continue;
                }

               // itemPath = itemPath.Remove(0, pathLength);
                string[] dependPathList = AssetDatabase.GetDependencies(new string[] { itemPath });
                foreach (string path in dependPathList)
                {
                    // string[] assetPath = path.Split('/');
                    //if (assetPath[assetPath.Length-1] == fongPath)
                    if (path == fontPath)
                    {
                        UnityEngine.Debug.Log($"以下文件有引用： {itemPath} ");

                        //GameObject tmpObj = AssetDatabase.LoadAssetAtPath(itemPath, typeof(GameObject)) as GameObject;
                        ////tmpObj = GameObject.Instantiate(tmpObj) as GameObject;
                        //Text[] tmpAr = tmpObj.GetComponentsInChildren<Text>();
                        //for (int t = 0; t < tmpAr.Length; t++)
                        //{
                        //    Text textTemp = tmpAr[t];
                        //    Font fontTemp = textTemp.font;
                        //    if (fontTemp == null)
                        //    {
                        //        continue;
                        //    }
                        //    string assetName = fontTemp.name;
                        //    if (fontAssetName == assetName)
                        //    {
                        //        UnityEngine.Debug.Log($" {textTemp.name}");
                        //    }
                        //}

                        //TextMeshPro[] tmpProAr = tmpObj.GetComponentsInChildren<TextMeshPro>();
                        //for (int t = 0; t < tmpProAr.Length; t++)
                        //{
                        //    TextMeshPro textTemp = tmpProAr[t];
                        //    TMP_FontAsset fontTemp = textTemp.font;
                        //    if (fontTemp == null)
                        //    {
                        //        continue;
                        //    }
                        //    string assetName = fontTemp.name;
                        //    if (fontAssetName == assetName)
                        //    {
                        //        UnityEngine.Debug.Log($" {textTemp.name}");
                        //    }
                        //}
                    }
                }
            }

            UnityEngine.Debug.Log("KCheckFontReferences: End");
        }
    }
}