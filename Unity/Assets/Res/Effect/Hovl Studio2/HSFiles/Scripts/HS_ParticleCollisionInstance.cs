using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Hovl
{
    public class HS_ParticleCollisionInstance : MonoBehaviour
    {
        public GameObject[] EffectsOnCollision;
        public float DestroyTimeDelay = 5f;
        public bool UseWorldSpacePosition;
        public float Offset = 0f;
        public Vector3 rotationOffset = new Vector3(0, 0, 0);
        public bool useOnlyRotationOffset = true;
        public bool UseFirePointRotation;
        public bool DestoyMainEffect = false;

        [Tooltip("Enable pooling to avoid Instantiate/Destroy spikes")]
        public bool UsePooling = true;

        [Tooltip("Maximum number of spawned effects processed per particle collision event (per OnParticleCollision call)")]
        public int MaxSpawnsPerCollisionCall = 50;

        private ParticleSystem part;
        private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

        // Pooling
        private Transform poolRoot;
        private Dictionary<GameObject, Queue<GameObject>> pools = new Dictionary<GameObject, Queue<GameObject>>();

        // Track instances that were spawned by this emitter and not yet returned to pool
        private HashSet<GameObject> activeInstances = new HashSet<GameObject>();

        void OnValidate()
        {
            if (DestroyTimeDelay < 0f) DestroyTimeDelay = 0f;
            if (MaxSpawnsPerCollisionCall < 1) MaxSpawnsPerCollisionCall = 1;
        }

        void Start()
        {
            part = GetComponent<ParticleSystem>();
            if (poolRoot == null)
            {
                var rootGO = GameObject.Find("[PS_Effect_Pool]");
                if (rootGO == null)
                {
                    rootGO = new GameObject("[PS_Effect_Pool]");
                    DontDestroyOnLoad(rootGO);
                }
                poolRoot = rootGO.transform;
            }
        }

        void OnParticleCollision(GameObject other)
        {
            if (part == null)
                part = GetComponent<ParticleSystem>();
            if (part == null)
                return; // nothing to do without particle system

            if (EffectsOnCollision == null || EffectsOnCollision.Length == 0)
                return;

            int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
            int spawned = 0;

            for (int i = 0; i < numCollisionEvents; i++)
            {
                if (spawned >= MaxSpawnsPerCollisionCall)
                    break; // throttle

                var hitPos = collisionEvents[i].intersection + collisionEvents[i].normal * Offset;

                foreach (var effect in EffectsOnCollision)
                {
                    if (effect == null)
                        continue;

                    if (spawned >= MaxSpawnsPerCollisionCall)
                        break;

                    GameObject instance = null;
                    if (UsePooling)
                        instance = GetPooledInstance(effect);
                    else
                        instance = Instantiate(effect, hitPos, Quaternion.identity) as GameObject;

                    if (instance == null)
                        continue;

                    // Track as active so we can clean up if this emitter is destroyed
                    activeInstances.Add(instance);

                    // Position & rotation logic
                    if (UseWorldSpacePosition)
                    {
                        instance.transform.position = hitPos;
                    }
                    else
                    {
                        // Keep world position consistent but do not parent to emitter to avoid accidental destruction.
                        // Compute local position relative to emitter and set world position accordingly.
                        var localPos = transform.InverseTransformPoint(hitPos);
                        instance.transform.position = transform.TransformPoint(localPos);
                    }

                    if (UseFirePointRotation)
                    {
                        instance.transform.LookAt(transform.position);
                    }
                    else if (rotationOffset != Vector3.zero && useOnlyRotationOffset)
                    {
                        instance.transform.rotation = Quaternion.Euler(rotationOffset);
                    }
                    else
                    {
                        instance.transform.LookAt(collisionEvents[i].intersection + collisionEvents[i].normal);
                        instance.transform.rotation *= Quaternion.Euler(rotationOffset);
                    }

                    // Activate and play particle systems inside the effect
                    instance.SetActive(true);
                    PlayParticleSystemsRecursive(instance.transform);

                    // Return to pool after a delay (or destroy if pooling disabled)
                    if (UsePooling)
                        StartCoroutine(ReturnToPoolAfterDelay(effect, instance, DestroyTimeDelay));
                    else
                        Destroy(instance, DestroyTimeDelay);

                    spawned++;
                }
            }

            if (DestoyMainEffect == true)
            {
                Destroy(gameObject, DestroyTimeDelay + 0.5f);
            }
        }

        // Play all particle systems in the spawned effect (in case of pooled ones they might be stopped)
        private void PlayParticleSystemsRecursive(Transform root)
        {
            var systems = root.GetComponentsInChildren<ParticleSystem>(true);
            foreach (var s in systems)
            {
                // Restart the system
                try
                {
                    s.Clear();
                    s.Play();
                }
                catch { }
            }
        }

        // Pool helpers
        private GameObject GetPooledInstance(GameObject prefab)
        {
            if (prefab == null)
                return null;

            Queue<GameObject> q;
            if (!pools.TryGetValue(prefab, out q) || q == null)
            {
                q = new Queue<GameObject>();
                pools[prefab] = q;
            }

            GameObject go = null;
            while (q.Count > 0)
            {
                var candidate = q.Dequeue();
                if (candidate != null)
                {
                    go = candidate;
                    break;
                }
            }

            if (go == null)
            {
                go = Instantiate(prefab, poolRoot);
            }

            // ensure under pool root so it survives emitter destruction
            go.transform.SetParent(poolRoot, true);
            return go;
        }

        private IEnumerator ReturnToPoolAfterDelay(GameObject prefab, GameObject instance, float delay)
        {
            if (instance == null)
                yield break;

            // clamp delay
            if (delay < 0f) delay = 0f;
            yield return new WaitForSeconds(delay);

            if (instance == null)
                yield break;

            // stop particle systems
            var systems = instance.GetComponentsInChildren<ParticleSystem>(true);
            foreach (var s in systems)
            {
                try { s.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); } catch { }
            }

            // deactivate and return to pool
            instance.SetActive(false);

            // Remove from active tracking for this emitter
            if (activeInstances.Contains(instance))
                activeInstances.Remove(instance);

            if (prefab == null)
            {
                Destroy(instance);
                yield break;
            }

            if (!pools.TryGetValue(prefab, out var q) || q == null)
                pools[prefab] = new Queue<GameObject>();

            pools[prefab].Enqueue(instance);
        }

        void OnDestroy()
        {
            // Destroy all active instances that were spawned by this emitter
            if (activeInstances != null)
            {
                foreach (var inst in activeInstances)
                {
                    if (inst != null)
                        Destroy(inst);
                }
                activeInstances.Clear();
            }

            // Destroy all pooled objects created by this emitter
            if (pools != null)
            {
                foreach (var kv in pools)
                {
                    var q = kv.Value;
                    if (q == null) continue;
                    while (q.Count > 0)
                    {
                        var go = q.Dequeue();
                        if (go != null)
                            Destroy(go);
                    }
                }
                pools.Clear();
            }
        }
    }
}