using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.VFX;
using System;

namespace INab.Dissolve
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(VisualEffect))]
    public class UniformMeshBaker : MonoBehaviour
    {
        [Tooltip("Amount of points from which particles would be spawned.")]
        [SerializeField]
        private int _sampleCount = 2048;

        public int SampleCount
        {
            get => (int)(_sampleCount * SampleCountMultiplier);
        }

        [Range(0.01f,10f)]
        [Tooltip("Multiply sample count by this value to control density of the particles. Keep this as low as possible.")]
        public float SampleCountMultiplier = 0.3f;

        [Delayed]
        public string MeshPropertyName = "Mesh";
        [Delayed]
        public string GraphicsBufferName = "UniformMeshBuffer";

        [SerializeField, HideInInspector]
        public TriangleSampling[] m_BakedSampling;

        public GraphicsBuffer m_Buffer;

        public bool initializeOnEnable = false;

        public void ComputeBakedSampling()
        {
            var vfx = GetComponent<VisualEffect>();
            if (vfx == null)
            {
                Debug.LogWarning("UniformBaker expects a VisualEffect on the shared game object.");
                return;
            }

            if (!vfx.HasGraphicsBuffer(GraphicsBufferName))
            {
                Debug.LogWarningFormat("Graphics Buffer property '{0}' is invalid.", GraphicsBufferName);
                return;
            }

            Mesh mesh;
            var meshPropertyNameID = Shader.PropertyToID(MeshPropertyName);
            if (vfx.HasSkinnedMeshRenderer(meshPropertyNameID))
            {
                if(vfx.GetSkinnedMeshRenderer(meshPropertyNameID) == null)
                {
                    Debug.LogErrorFormat("There is no skinned mesh renderer assigned in the VFX Graph.", GraphicsBufferName);
                    return;
                }
                mesh = vfx.GetSkinnedMeshRenderer(meshPropertyNameID).sharedMesh;
            }
            else if (vfx.HasMesh(meshPropertyNameID))
            {
                if (vfx.GetMesh(meshPropertyNameID) == null)
                {
                    Debug.LogErrorFormat("There is no mesh assigned in the VFX Graph.", GraphicsBufferName);
                    return;
                }
                mesh = vfx.GetMesh(meshPropertyNameID);
            }
            else
            {
                Debug.LogWarningFormat("Mesh property '{0}' is invalid.", MeshPropertyName);
                return;
            }

            if (mesh == null)
            {
                Debug.LogWarningFormat("Unexpected null mesh.");
                return;
            }

            var meshData = VFXMeshSamplingHelper.ComputeDataCache(mesh);

            _sampleCount = meshData.triangles.Length;

            var rand = new System.Random(123); // use random number as seed
            m_BakedSampling = new TriangleSampling[SampleCount];
            for (int i = 0; i < SampleCount; ++i)
            {
                m_BakedSampling[i] = VFXMeshSamplingHelper.GetNextSampling(meshData, rand);
            }
        }

        public void Bake()
        {
            var vfx = GetComponent<VisualEffect>();
            ComputeBakedSampling();
            UpdateGraphicsBuffer();
            BindGraphicsBuffer(vfx);
        }

        public void UpdateGraphicsBuffer()
        {
            if (m_BakedSampling == null) return;

            if (SampleCount != m_BakedSampling.Length)
            {
                Debug.LogErrorFormat("The length of baked data mismatches with sample count : {0} vs {1}", SampleCount, m_BakedSampling.Length);
                return;
            }

            if (m_Buffer != null)
            {
                m_Buffer.Release();
                m_Buffer = null;
            }

            m_Buffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, SampleCount, Marshal.SizeOf(typeof(TriangleSampling)));
            m_Buffer.SetData(m_BakedSampling);
        }

        public void BindGraphicsBuffer(VisualEffect vfx)
        {
            vfx.SetGraphicsBuffer(GraphicsBufferName, m_Buffer);
        }

        public void SetGraphicsBuffer()
        {
            var vfx = GetComponent<VisualEffect>();
            UpdateGraphicsBuffer();
            BindGraphicsBuffer(vfx);
        }

        public void Start()
        {
            SetGraphicsBuffer();
        }

        public void OnEnable()
        {
            if (initializeOnEnable)
            {
                SetGraphicsBuffer();
            }
        }

        private void OnDisable()
        {
            if (m_Buffer != null)
            {
                m_Buffer.Release();
                m_Buffer = null;
            }
        }
    }
}
