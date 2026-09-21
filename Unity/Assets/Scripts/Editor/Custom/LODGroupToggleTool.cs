using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LODGroupToggleTool
{
    private const string MenuRoot = "Tools/LOD Group/";

    [MenuItem(MenuRoot + "全部启用", priority = 100)]
    private static void EnableAll()
    {
        SetAllLODGroupsEnabled(true);
    }

    [MenuItem(MenuRoot + "全部禁用", priority = 101)]
    private static void DisableAll()
    {
        SetAllLODGroupsEnabled(false);
    }

    [MenuItem(MenuRoot + "全部启用", true)]
    [MenuItem(MenuRoot + "全部禁用", true)]
    private static bool ValidateMenuItems()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        return activeScene.IsValid() && activeScene.isLoaded;
    }

    private static void SetAllLODGroupsEnabled(bool enabled)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (!activeScene.IsValid() || !activeScene.isLoaded)
        {
            Debug.LogWarning("当前没有可编辑的激活场景。");
            return;
        }

        GameObject[] rootObjects = activeScene.GetRootGameObjects();
        int changedCount = 0;
        int totalCount = 0;

        Undo.IncrementCurrentGroup();
        int undoGroup = Undo.GetCurrentGroup();
        Undo.SetCurrentGroupName(enabled ? "启用所有 LOD Group" : "禁用所有 LOD Group");

        foreach (GameObject rootObject in rootObjects)
        {
            LODGroup[] lodGroups = rootObject.GetComponentsInChildren<LODGroup>(true);
            totalCount += lodGroups.Length;

            foreach (LODGroup lodGroup in lodGroups)
            {
                if (lodGroup.enabled == enabled)
                {
                    continue;
                }

                Undo.RecordObject(lodGroup, enabled ? "启用 LOD Group" : "禁用 LOD Group");
                lodGroup.enabled = enabled;
                EditorUtility.SetDirty(lodGroup);
                changedCount++;
            }
        }

        Undo.CollapseUndoOperations(undoGroup);

        if (changedCount > 0)
        {
            EditorSceneManager.MarkSceneDirty(activeScene);
        }

        Debug.Log($"场景“{activeScene.name}”中共找到 {totalCount} 个 LOD Group，已{(enabled ? "启用" : "禁用")} {changedCount} 个。");
    }
}
