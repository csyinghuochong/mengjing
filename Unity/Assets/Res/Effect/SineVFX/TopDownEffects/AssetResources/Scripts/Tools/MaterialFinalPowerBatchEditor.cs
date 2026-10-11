#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MaterialFinalPowerBatchEditor : EditorWindow
{
    private enum Mode
    {
        GameObject,
        MaterialList
    }
    private Mode currentMode = Mode.GameObject;
    private GameObject targetGameObject;
    private List<Material> selectedMaterials = new List<Material>();
    private float multiplier = 1.0f;

    [MenuItem("Tools/SineVFX/Material FinalPower Batch Editor")]
    public static void ShowWindow()
    {
        GetWindow<MaterialFinalPowerBatchEditor>("Material FinalPower Batch Editor");
    }

    void OnGUI()
    {
        GUILayout.Label("Batch Edit _FinalPower Parameter", EditorStyles.boldLabel);

        currentMode = (Mode)EditorGUILayout.EnumPopup("Mode", currentMode);

        EditorGUILayout.Space();

        if (currentMode == Mode.GameObject)
        {
            DrawGameObjectMode();
        }
        else
        {
            DrawMaterialListMode();
        }
    }

    // Draws the UI for GameObject mode
    private void DrawGameObjectMode()
    {
        EditorGUILayout.HelpBox("This mode will edit the _FinalPower parameter on all materials of the target GameObject and its children.", MessageType.Info);

        EditorGUILayout.Space();

        targetGameObject = (GameObject)EditorGUILayout.ObjectField("Target GameObject", targetGameObject, typeof(GameObject), true);
        multiplier = EditorGUILayout.FloatField("Multiplier/Divider Value", multiplier);

        EditorGUILayout.Space();

        EditorGUI.BeginDisabledGroup(targetGameObject == null || multiplier == 0f);
        if (GUILayout.Button("Multiply"))
        {
            ApplyToMaterials_GameObject(true);
        }
        if (GUILayout.Button("Divide"))
        {
            ApplyToMaterials_GameObject(false);
        }
        EditorGUI.EndDisabledGroup();
    }

    // Draws the UI for MaterialList mode
    private void DrawMaterialListMode()
    {
        EditorGUILayout.HelpBox("This mode will edit the _FinalPower parameter on a list of selected materials.", MessageType.Info);

        EditorGUILayout.Space();

        multiplier = EditorGUILayout.FloatField("Multiplier/Divider Value", multiplier);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Materials", EditorStyles.boldLabel);

        // Button to clear all materials from the list
        if (selectedMaterials.Count > 0)
        {
            if (GUILayout.Button("Clear All"))
            {
                selectedMaterials.Clear();
            }
        }

        // Drag & drop area for adding multiple materials
        Rect dragAndDropArea = GUILayoutUtility.GetRect(0.0f, 60.0f, GUILayout.ExpandWidth(true));
        var centeredStyle = new GUIStyle(EditorStyles.helpBox)
        {
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Italic,
            fontSize = 12
        };
        GUI.Box(dragAndDropArea, "Drag & Drop Materials Here", centeredStyle);

        Event materialDragEvent = Event.current;
        if (materialDragEvent.type == EventType.DragUpdated || materialDragEvent.type == EventType.DragPerform)
        {
            if (dragAndDropArea.Contains(materialDragEvent.mousePosition))
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                if (materialDragEvent.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();
                    foreach (Object draggedObject in DragAndDrop.objectReferences)
                    {
                        Material mat = draggedObject as Material;
                        if (mat != null && !selectedMaterials.Contains(mat))
                        {
                            selectedMaterials.Add(mat);
                        }
                    }
                    materialDragEvent.Use();
                }
            }
        }

        // Draws each material field cell with a remove button
        for (int i = 0; i < selectedMaterials.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            selectedMaterials[i] = (Material)EditorGUILayout.ObjectField(selectedMaterials[i], typeof(Material), false);
            if (GUILayout.Button("Remove", GUILayout.Width(60)))
            {
                selectedMaterials.RemoveAt(i);
                i--;
            }
            EditorGUILayout.EndHorizontal();
        }

        // Button to add a new material field cell
        if (GUILayout.Button("Add Material"))
        {
            selectedMaterials.Add(null);
        }

        EditorGUILayout.Space();

        // Multiply and Divide buttons for selected materials
        EditorGUI.BeginDisabledGroup(selectedMaterials.Count == 0 || multiplier == 0f);
        if (GUILayout.Button("Multiply"))
        {
            ApplyToMaterials_List(true);
        }
        if (GUILayout.Button("Divide"))
        {
            ApplyToMaterials_List(false);
        }
        EditorGUI.EndDisabledGroup();
    }

    // Applies the multiply/divide operation to all materials in the target GameObject and its children
    private void ApplyToMaterials_GameObject(bool multiply)
    {
        if (targetGameObject == null || multiplier == 0f)
        {
            Debug.LogWarning("Assigned target GameObject and a non-zero multiplier/divider value are required.");
            return;
        }

        Renderer[] renderers = targetGameObject.GetComponentsInChildren<Renderer>(true);
        int materialCount = 0;
        foreach (Renderer renderer in renderers)
        {
            foreach (Material mat in renderer.sharedMaterials)
            {
                if (mat != null && mat.HasProperty("_FinalPower"))
                {
                    // Remove the Undo.RecordObject call in case where a large amount of materials are modified
                    Undo.RecordObject(mat, "Change _FinalPower");
                    float currentValue = mat.GetFloat("_FinalPower");
                    float newValue;
                    if (multiply)
                    {
                        newValue = currentValue * multiplier;
                    }
                    else
                    {
                        newValue = currentValue / multiplier;
                    }
                    mat.SetFloat("_FinalPower", newValue);
                    // Mark the material as dirty to ensure changes are saved correctly
                    EditorUtility.SetDirty(mat);
                    materialCount++;
                }
            }
        }
        Debug.Log($"Modified _FinalPower on {materialCount} materials.");
    }

    // Applies the multiply/divide operation to all selected materials in the "selectedMaterials" list
    private void ApplyToMaterials_List(bool multiply)
    {
        int materialCount = 0;
        foreach (Material mat in selectedMaterials)
        {
            if (mat != null && mat.HasProperty("_FinalPower"))
            {
                // Remove the Undo.RecordObject call in case where a large amount of materials are modified
                Undo.RecordObject(mat, "Change _FinalPower");
                float currentValue = mat.GetFloat("_FinalPower");
                float newValue;
                if (multiply)
                {
                    newValue = currentValue * multiplier;
                }
                else
                {
                    newValue = currentValue / multiplier;
                }
                mat.SetFloat("_FinalPower", newValue);
                // Mark the material as dirty to ensure changes are saved correctly
                EditorUtility.SetDirty(mat);
                materialCount++;
            }
        }
        Debug.Log($"Modified _FinalPower on {materialCount} materials.");
    }
}
#endif
