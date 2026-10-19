using UnityEngine;

namespace ET
{
    [DisallowMultipleComponent]
    public sealed class QualityVisibilityGroup: MonoBehaviour
    {
        [SerializeField]
        [Tooltip("该组物体显示所需的最低画质。")]
        private GraphicsQualityLevel minimumQuality = GraphicsQualityLevel.High;

        private void Awake()
        {
            GraphicsQualityManager.QualityChanged += Apply;
            Apply(GraphicsQualityManager.CurrentLevel);
        }

        private void OnDestroy()
        {
            GraphicsQualityManager.QualityChanged -= Apply;
        }

        public void Apply(GraphicsQualityLevel level)
        {
            bool visible = level >= minimumQuality;
            if (gameObject.activeSelf != visible)
            {
                gameObject.SetActive(visible);
            }
        }
    }
}
