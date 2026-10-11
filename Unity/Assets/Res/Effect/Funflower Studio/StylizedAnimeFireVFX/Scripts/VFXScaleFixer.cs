using UnityEngine;

namespace FunflowerStudio.StylizedAnimeFireVFX
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(TrailRenderer))]
    public class VFXScaleFixer : MonoBehaviour
    {
        private TrailRenderer trail;
        [SerializeField] private float baseWidthMultiplier = 1.0f; 
        
        private Vector3 lastGlobalScale;

        void Start()
        {
            trail = GetComponent<TrailRenderer>();
            UpdateScale();
        }

        void Update()
        {
            if (transform.lossyScale != lastGlobalScale)
            {
                UpdateScale();
            }
        }

        void OnValidate()
        {
            if (trail == null) trail = GetComponent<TrailRenderer>();
            UpdateScale();
        }

        void UpdateScale()
        {
            if (trail == null) return;
            
            lastGlobalScale = transform.lossyScale;
            trail.widthMultiplier = baseWidthMultiplier * lastGlobalScale.x;
        }
    }
}