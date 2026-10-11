using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if !ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine.InputSystem; // Required for new Input System
#endif

public class PrefabSpawner : MonoBehaviour
{

    public GameObject[] prefabs;
    public Camera sceneCamera;
    public string nameOfThePrefab;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        nameOfThePrefab = prefabs[index].name;
    }

    // Update is called once per frame
    void Update()
    {
        nameOfThePrefab = prefabs[index].name;
    }

    // Spawning a Prefab of a Complete Effect on mouse position
    public void SpawnPrefab()
    {
#if !ENABLE_LEGACY_INPUT_MANAGER
        Ray ray = sceneCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Instantiate(prefabs[index], hit.point, Quaternion.identity);
        }
#else
        Ray ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Instantiate(prefabs[index], hit.point, Quaternion.identity);
        }
#endif
    }

    // Changing the index on Prefab array
    public void ChangePrefabIntex(bool bo)
    {
        if (bo == true)
        {
            index++;
            if (index == prefabs.Length)
            {
                index = 0;
            }
        }
        else
        {
            index--;
            if (index == -1)
            {
                index = prefabs.Length - 1;
            }
        }
    }
}
