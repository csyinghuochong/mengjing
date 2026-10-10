using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Hovl
{
    [RequireComponent(typeof(ParticleSystem))]
    public class HS_EffectOnDie : MonoBehaviour
    {
        public GameObject EffectsOnDie;
        public int poolSize = 10;
        public float poolReturnTimer = 1.5f;

        private ParticleSystem ps;
        private readonly List<GameObject> pooledObjects = new List<GameObject>();

        private ParticleSystem.Particle[] particles;
        private readonly HashSet<uint> triggeredParticles = new HashSet<uint>();
        private readonly HashSet<uint> aliveParticles = new HashSet<uint>();

        private void Awake()
        {
            ps = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[1024];
        }

        private void Start()
        {
            for (int i = 0; i < poolSize; i++)
            {
                CreateNewPoolObject();
            }
        }

        private void LateUpdate()
        {
            if (EffectsOnDie == null)
                return;

            int aliveCount = ps.particleCount;

            if (particles.Length < aliveCount)
                particles = new ParticleSystem.Particle[aliveCount];

            int count = ps.GetParticles(particles);

            aliveParticles.Clear();

            for (int i = 0; i < count; i++)
            {
                uint id = particles[i].randomSeed;
                aliveParticles.Add(id);

                if (particles[i].remainingLifetime <= Time.deltaTime)
                {
                    if (!triggeredParticles.Contains(id))
                    {
                        triggeredParticles.Add(id);

                        GameObject effectInstance = GetPooledObject();
                        effectInstance.transform.position = GetWorldPosition(particles[i].position);
                        effectInstance.transform.rotation = Quaternion.identity;
                        effectInstance.SetActive(true);

                        StartCoroutine(ReturnToPool(effectInstance));
                    }
                }
            }

            triggeredParticles.RemoveWhere(id => !aliveParticles.Contains(id));
        }

        private GameObject GetPooledObject()
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                    return pooledObjects[i];
            }

            return CreateNewPoolObject();
        }

        private GameObject CreateNewPoolObject()
        {
            GameObject obj = Instantiate(EffectsOnDie, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }

        private Vector3 GetWorldPosition(Vector3 particlePosition)
        {
            var main = ps.main;

            if (main.simulationSpace == ParticleSystemSimulationSpace.Local)
                return transform.TransformPoint(particlePosition);

            return particlePosition;
        }

        private IEnumerator ReturnToPool(GameObject obj)
        {
            yield return new WaitForSeconds(poolReturnTimer);
            obj.SetActive(false);
        }
    }
}