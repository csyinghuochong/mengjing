using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace GrassMobileShader
{
    [HelpURL("https://assetstore.unity.com/packages/slug/265141")]
    public class AsyncGrassManagersLoader : MonoBehaviour
    {
        public static AsyncGrassManagersLoader Instance { get; private set; }

        [HideInInspector]
        public List<GameObject> GrassManagers = new List<GameObject>();

        [Tooltip("How many frames will need to be skipped before loading a new GrassManager")]
        [SerializeField]
        private int skipFrames = 2;

        [Tooltip("The event that will be executed after all the GrassManager loads")]
        [SerializeField]
        private UnityEvent onComplete = null;

        /// <summary>
        /// Saving this instance of the class
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Sequential activation of all GrassManagers
        /// </summary>
        private IEnumerator Start()
        {
            GameObject[] objs = GrassManagers.ToArray();
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].SetActive(true);
                for (int j = 0; j < skipFrames; j++)
                {
                    yield return null;
                }
            }
            yield return null;
            onComplete?.Invoke();
            yield return null;
            Destroy(gameObject);
        }
    }
}
