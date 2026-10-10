using System.Collections.Generic;
using UnityEngine;

namespace Hovl
{
    [RequireComponent(typeof(ParticleSystem))]
    public class HS_ParticleTransformRotationToCustomData : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private ParticleSystem ps;

        private readonly List<Vector4> customData = new List<Vector4>();

        private float randomAngle;

        private void Reset()
        {
            ps = GetComponent<ParticleSystem>();
        }

        private void OnValidate()
        {
            if (ps == null)
                ps = GetComponent<ParticleSystem>();
        }

        private void Awake()
        {
            if (ps == null)
                ps = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            randomAngle = Random.Range(0f, 360f);
        }

        private void LateUpdate()
        {
            if (ps == null)
                return;

            int count = ps.particleCount;

            if (count <= 0)
                return;

            while (customData.Count < count)
                customData.Add(Vector4.zero);

            if (customData.Count > count)
                customData.RemoveRange(count, customData.Count - count);

            // World decal rotation.
            Quaternion decalRotation = transform.rotation;

            // Random rotation 0-360 around decal local Y axis.
            // This is the axis perpendicular to the decal plane in your setup.
            Quaternion randomLocalRotation = Quaternion.AngleAxis(randomAngle, Vector3.up);

            // Decal rotation + random rotation around decal attachment axis.
            Quaternion finalRotation = decalRotation * randomLocalRotation;

            // Convert final rotation to radians for Shader Graph.
            Vector3 rotationRad = finalRotation.eulerAngles * Mathf.Deg2Rad;

            Vector4 data = new Vector4(
                rotationRad.x,
                rotationRad.y,
                rotationRad.z,
                0f
            );

            for (int i = 0; i < count; i++)
                customData[i] = data;

            ps.SetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
        }
    }
}