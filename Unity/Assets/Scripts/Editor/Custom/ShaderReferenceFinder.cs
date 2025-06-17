using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;

public class ShaderReferenceFinder : EditorWindow
{
    private Shader targetShader;
    private List<GameObject> referencingObjects = new List<GameObject>();
    private Vector2 scrollPosition;
    private bool showResults;

    [MenuItem("Tools/Shader Reference Finder")]
    public static void ShowWindow()
    {
        GetWindow<ShaderReferenceFinder>("Shader Reference Finder");
    }

    private void OnGUI()
    {
        GUILayout.Label("查找Shader引用", EditorStyles.boldLabel);
        
        // 从当前选中的资源获取Shader
        if (GUILayout.Button("从选中资源获取Shader"))
        {
            Object selectedObject = Selection.activeObject;
            if (selectedObject is Shader)
            {
                targetShader = selectedObject as Shader;
                EditorUtility.DisplayDialog("成功", "已获取选中的Shader", "确定");
            }
            else
            {
                EditorUtility.DisplayDialog("错误", "请选择一个Shader资源", "确定");
            }
        }

        // 手动选择Shader
        targetShader = (Shader)EditorGUILayout.ObjectField("目标Shader:", targetShader, typeof(Shader), false);

        if (targetShader == null)
        {
            EditorGUILayout.HelpBox("请选择一个Shader", MessageType.Info);
            return;
        }

        if (GUILayout.Button("查找引用"))
        {
            //FindReferencesInAllScenes();
            FindReferencesInScene(SceneManager.GetActiveScene());
            showResults = true;
        }

        if (showResults)
        {
            EditorGUILayout.Space();
            GUILayout.Label($"找到 {referencingObjects.Count} 个引用:", EditorStyles.boldLabel);

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            foreach (GameObject obj in referencingObjects)
            {
                if (obj != null)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.ObjectField(obj, typeof(GameObject), true);
                    
                    if (GUILayout.Button("选中", GUILayout.Width(60)))
                    {
                        Selection.activeObject = obj;
                        EditorGUIUtility.PingObject(obj);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndScrollView();

            if (referencingObjects.Count > 0 && GUILayout.Button("导出到文本文件"))
            {
                ExportResultsToFile();
            }
        }
    }

    private void FindReferencesInAllScenes()
    {
        referencingObjects.Clear();
        showResults = false;

        // 保存当前场景状态
        
        Scene currentScene = SceneManager.GetActiveScene();

        // 查找当前打开的场景
        FindReferencesInScene(SceneManager.GetActiveScene());

        // 查找所有已添加到Build Settings的场景
        foreach (EditorBuildSettingsScene buildScene in EditorBuildSettings.scenes)
        {
            if (buildScene.enabled && buildScene.path != currentScene.path)
            {
                Scene scene = EditorSceneManager.OpenScene(buildScene.path, OpenSceneMode.Additive);
                FindReferencesInScene(scene);
                EditorSceneManager.CloseScene(scene, true);
            }
        }

        // 恢复原始场景
        if (currentScene.IsValid())
        {
            EditorSceneManager.SetActiveScene(currentScene);
        }

        // 如果之前的场景是脏的，重新标记为脏
   

        showResults = true;
        Repaint();

        if (referencingObjects.Count > 0)
        {
            EditorUtility.DisplayDialog("完成", $"在场景中找到 {referencingObjects.Count} 个引用", "确定");
        }
        else
        {
            EditorUtility.DisplayDialog("完成", "未找到引用", "确定");
        }
    }

    private void FindReferencesInScene(Scene scene)
    {
        if (!scene.isLoaded)
            return;

        GameObject[] rootObjects = scene.GetRootGameObjects();
        foreach (GameObject root in rootObjects)
        {
            Renderer[] renderers = root.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer renderer in renderers)
            {
                if (renderer.sharedMaterials != null)
                {
                    foreach (Material material in renderer.sharedMaterials)
                    {
                        if (material != null && material.shader == targetShader)
                        {
                            referencingObjects.Add(renderer.gameObject);
                            break;
                        }
                    }
                }
            }

            // 处理粒子系统
            ParticleSystem[] particleSystems = root.GetComponentsInChildren<ParticleSystem>(true);
            foreach (ParticleSystem ps in particleSystems)
            {
                ParticleSystemRenderer psRenderer = ps.GetComponent<ParticleSystemRenderer>();
                if (psRenderer != null && psRenderer.sharedMaterials != null)
                {
                    foreach (Material material in psRenderer.sharedMaterials)
                    {
                        if (material != null && material.shader == targetShader)
                        {
                            referencingObjects.Add(ps.gameObject);
                            break;
                        }
                    }
                }
            }
        }
    }

    private void ExportResultsToFile()
    {
        string filePath = EditorUtility.SaveFilePanel("导出引用结果", "", "ShaderReferences.txt", "txt");
        if (string.IsNullOrEmpty(filePath))
            return;

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Shader引用结果: {targetShader.name}");
                writer.WriteLine($"找到 {referencingObjects.Count} 个引用");
                writer.WriteLine("=====================================");

                foreach (GameObject obj in referencingObjects)
                {
                    if (obj != null)
                    {
                        writer.WriteLine($"场景: {obj.scene.name}");
                        writer.WriteLine($"对象: {GetGameObjectPath(obj)}");
                        writer.WriteLine("-------------------------------------");
                    }
                }
            }

            EditorUtility.DisplayDialog("成功", $"结果已导出到: {filePath}", "确定");
        }
        catch (System.Exception e)
        {
            EditorUtility.DisplayDialog("错误", $"导出失败: {e.Message}", "确定");
        }
    }

    private string GetGameObjectPath(GameObject obj)
    {
        string path = obj.name;
        Transform parent = obj.transform.parent;
        while (parent != null)
        {
            path = parent.name + "/" + path;
            parent = parent.parent;
        }
        return path;
    }
}