using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if !ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine.InputSystem;
#endif

public class SineUIControllerTopDownEffects : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public PrefabSpawner prefabSpawnerObject;
    public Text nameInUI;

    private string nameOfThePrafab;

    private void Start()
    {
#if !ENABLE_LEGACY_INPUT_MANAGER
        // Check for Standalone Input Module and replace it with Input System UI Input Module
        var standaloneInputModule = FindFirstObjectByType<UnityEngine.EventSystems.StandaloneInputModule>();
        if (standaloneInputModule != null)
        {
            Debug.Log("Replacing Standalone Input Module with Input System UI Input Module.");
            var eventSystemGameObject = standaloneInputModule.gameObject;
            Destroy(standaloneInputModule);
            var inputSystemUIModule = eventSystemGameObject.AddComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
        }
#endif
    }

    void Update()
    {
#if !ENABLE_LEGACY_INPUT_MANAGER
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            canvasGroup.alpha = 1f - canvasGroup.alpha;
        }
        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            ChangeEffect(true);
        }
        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            ChangeEffect(false);
        }
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            prefabSpawnerObject.SpawnPrefab();
        }
#else
        if (Input.GetKeyDown(KeyCode.H))
        {
            canvasGroup.alpha = 1f - canvasGroup.alpha;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeEffect(true);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeEffect(false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            prefabSpawnerObject.SpawnPrefab();
        }
#endif

        nameOfThePrafab = prefabSpawnerObject.nameOfThePrefab;
        nameInUI.text = "Spawn - " + nameOfThePrafab;
    }

    // Change active VFX
    public void ChangeEffect(bool bo)
    {
        prefabSpawnerObject.ChangePrefabIntex(bo);
        nameOfThePrafab = prefabSpawnerObject.nameOfThePrefab;
    }
}
