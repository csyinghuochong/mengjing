using UnityEngine;
using UnityEngine.Rendering;

namespace HighlightPlus {

    [DefaultExecutionOrder(100)]
    [ExecuteInEditMode]
    public class HighlightEffectBlocker : MonoBehaviour {

        Renderer thisRenderer;
        public bool blockOutlineAndGlow;
        public bool blockOverlay;
    
        void OnEnable () {
            thisRenderer = GetComponentInChildren<Renderer>();
            HighlightPlusRenderPassFeature.RegisterBlocker(this);
        }

        void OnDisable () {
            HighlightPlusRenderPassFeature.UnregisterBlocker(this);
        }

        public void BuildCommandBuffer(CommandBuffer cmd, Material mat) {
            if (thisRenderer == null) return;
            Material[] sharedMats = thisRenderer.sharedMaterials;
            if (sharedMats == null) return;
            int submeshCount = sharedMats.Length;
            for (int i = 0; i < submeshCount; i++) {
                cmd.DrawRenderer(thisRenderer, mat, i);
            }
        }

    }
}
