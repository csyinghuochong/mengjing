using UnityEngine;

namespace ET
{
    public sealed class FPSManager: MonoBehaviour
    {
        private const float RefreshInterval = 0.5f;
        private const float MaximumAcceptedFrameTime = 1f;

        private static FPSManager instance;

        private float elapsedTime;
        private int frameCount;

        public static float CurrentFps { get; private set; }

        public static void Initialize()
        {
            EnsureInstance();
        }

        private static FPSManager EnsureInstance()
        {
            if (instance != null)
            {
                return instance;
            }

            GameObject managerObject = new GameObject("[FPSManager]");
            managerObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSave;
            DontDestroyOnLoad(managerObject);
            instance = managerObject.AddComponent<FPSManager>();
            return instance;
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            float deltaTime = Time.unscaledDeltaTime;
            if (!Application.isFocused || deltaTime <= 0f || deltaTime > MaximumAcceptedFrameTime)
            {
                return;
            }

            elapsedTime += deltaTime;
            frameCount++;
            if (elapsedTime < RefreshInterval)
            {
                return;
            }

            CurrentFps = frameCount / elapsedTime;
            elapsedTime = 0f;
            frameCount = 0;
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
                CurrentFps = 0f;
            }
        }
    }
}
