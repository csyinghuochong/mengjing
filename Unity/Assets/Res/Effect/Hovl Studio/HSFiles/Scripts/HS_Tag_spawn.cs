using System.Collections.Generic;
using UnityEngine;

namespace Hovl
{
    public class HS_Tag_spawn : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [SerializeField] private List<string> targetTags = new List<string>() { "Player" };
        [SerializeField] private GameObject prefab;
        [SerializeField] private Vector3 positionOffset = Vector3.zero;

        [Header("Buff Distance")]
        [SerializeField] private float maxDistance = 10f;

        [Tooltip("Delay in seconds before the buff starts.")]
        [SerializeField] private float buffDelay = 0f;

        [Tooltip("Time in seconds for the buff to reach Max Distance. 0 = instant.")]
        [SerializeField] private float buffSpreadTime = 0f;

        [Header("Loop")]
        [Tooltip("Restart the spawn cycle periodically.")]
        [SerializeField] private bool loop = false;
        [SerializeField] private float loopPeriod = 1f;

        private Vector3 startPosition;
        private float currentDistance;
        private float elapsedTime;
        private float delayTimer;
        private float loopTimer;

        private readonly HashSet<GameObject> spawnedTargets = new HashSet<GameObject>();

        private void Start()
        {
            startPosition = transform.position;
            ResetCycle();
        }

        private void Update()
        {
            if (prefab == null)
                return;

            // Wait before starting the buff.
            if (delayTimer < buffDelay)
            {
                delayTimer += Time.deltaTime;
            }
            else
            {
                if (buffSpreadTime <= 0f)
                {
                    currentDistance = maxDistance;
                }
                else if (currentDistance < maxDistance)
                {
                    elapsedTime += Time.deltaTime;

                    float progress = Mathf.Clamp01(elapsedTime / buffSpreadTime);
                    currentDistance = Mathf.Lerp(0f, maxDistance, progress);
                }

                SpawnPrefabs();
            }

            if (loop)
            {
                loopTimer += Time.deltaTime;

                if (loopTimer >= loopPeriod)
                {
                    // Keep timer accurate even if there is a frame spike.
                    loopTimer %= loopPeriod;

                    ResetCycle();
                }
            }
        }

        private void ResetCycle()
        {
            spawnedTargets.Clear();

            elapsedTime = 0f;
            delayTimer = 0f;

            if (buffDelay > 0f)
            {
                currentDistance = 0f;
            }
            else if (buffSpreadTime <= 0f)
            {
                currentDistance = maxDistance;
            }
            else
            {
                currentDistance = 0f;
            }
        }

        private void SpawnPrefabs()
        {
            foreach (string targetTag in targetTags)
            {
                if (string.IsNullOrEmpty(targetTag))
                    continue;

                GameObject[] targets;

                try
                {
                    targets = GameObject.FindGameObjectsWithTag(targetTag);
                }
                catch (UnityException)
                {
                    Debug.LogWarning($"HS_Tag_spawn: Tag \"{targetTag}\" does not exist.");
                    continue;
                }

                foreach (GameObject target in targets)
                {
                    if (target == null || spawnedTargets.Contains(target))
                        continue;

                    float distance = Vector3.Distance(
                        startPosition,
                        target.transform.position
                    );

                    if (distance > currentDistance || distance > maxDistance)
                        continue;

                    Instantiate(
                        prefab,
                        target.transform.position + positionOffset,
                        Quaternion.identity,
                        transform
                    );

                    spawnedTargets.Add(target);
                }
            }
        }
    }
}