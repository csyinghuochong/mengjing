using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class OutlineComponent : Entity, IAwake, IUpdate, IDestroy
    {
        public GameObject GameObject;

        public HashSet<Mesh> registeredMeshes = new HashSet<Mesh>();

        public enum Mode
        {
            OutlineAll,
            OutlineVisible,
            OutlineHidden,
            OutlineAndSilhouette,
            SilhouetteOnly
        }

        public Mode OutlineMode
        {
            get { return outlineMode; }
            set
            {
                outlineMode = value;
                needsUpdate = true;
            }
        }

        public Color OutlineColor
        {
            get { return outlineColor; }
            set
            {
                outlineColor = value;
                needsUpdate = true;
            }
        }

        public float OutlineWidth
        {
            get { return outlineWidth; }
            set
            {
                outlineWidth = value;
                needsUpdate = true;
            }
        }

        [EnableClass]
        public class ListVector3
        {
            public List<Vector3> data;
        }

        // ---------可以修改的设置-------------
        public Mode outlineMode;

        public Color outlineColor = Color.red;

        // Range(0f, 10f)
        public float outlineWidth = 4f;

        // "Precompute enabled: Per-vertex calculations are performed in the editor and serialized with the object. "
        // + "Precompute disabled: Per-vertex calculations are performed at runtime in Awake(). This may cause a pause for large meshes.")]
        public bool precomputeOutline;

        // ----------------------------------

        public List<Mesh> bakeKeys = new List<Mesh>();

        public List<ListVector3> bakeValues = new List<ListVector3>();

        public Renderer[] renderers;
        public Material outlineMaskMaterial;
        public Material outlineFillMaterial;

        public bool needsUpdate;
    }
}