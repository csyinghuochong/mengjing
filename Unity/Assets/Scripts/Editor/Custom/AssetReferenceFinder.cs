using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class AssetReferenceFinder : EditorWindow
{
    private UnityEngine.Object targetAsset;
    private List<string> referencingAssets = new List<string>();
    private Vector2 scrollPosition;

    [MenuItem("Tools/Find Asset References")]
    public static void ShowWindow()
    {
        GetWindow<AssetReferenceFinder>("Asset Reference Finder");
    }

    private void OnGUI()
    {
        GUILayout.Label("Find References to Asset", EditorStyles.boldLabel);
        
        targetAsset = EditorGUILayout.ObjectField("Target Asset", targetAsset, typeof(UnityEngine.Object), false);
        
        if (GUILayout.Button("Find References"))
        {
            FindReferences();
        }
        
        if (referencingAssets.Count > 0)
        {
            GUILayout.Label($"Found {referencingAssets.Count} references:");
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            
            foreach (var assetPath in referencingAssets)
            {
                if (GUILayout.Button(assetPath))
                {
                    var asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
                    if (asset != null)
                    {
                        Selection.activeObject = asset;
                        EditorGUIUtility.PingObject(asset);
                    }
                }
            }
            
            EditorGUILayout.EndScrollView();
        }
    }

    private void FindReferences()
    {
        if (targetAsset == null)
        {
            Debug.LogError("Please select a target asset first.");
            return;
        }

        referencingAssets.Clear();
        string targetGuid = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(targetAsset));
        
        if (string.IsNullOrEmpty(targetGuid))
        {
            Debug.LogError("Could not get GUID for selected asset.");
            return;
        }

        string[] allAssetPaths = AssetDatabase.GetAllAssetPaths();
        int processedCount = 0;
        int totalCount = allAssetPaths.Length;

        foreach (string assetPath in allAssetPaths)
        {
            EditorUtility.DisplayProgressBar("Searching for References", 
                $"Processing {processedCount}/{totalCount}", 
                (float)processedCount / totalCount);
            
            if (assetPath.EndsWith(".meta") || !assetPath.StartsWith("Assets/"))
            {
                processedCount++;
                continue;
            }

            try
            {
                string assetContent = File.ReadAllText(assetPath);
                if (Regex.IsMatch(assetContent, targetGuid))
                {
                    referencingAssets.Add(assetPath);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning($"Could not read file: {assetPath}. Error: {e.Message}");
            }

            processedCount++;
        }

        EditorUtility.ClearProgressBar();
        Repaint();
    }
}