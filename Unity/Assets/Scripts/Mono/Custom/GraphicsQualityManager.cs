using System;
using UnityEngine;

namespace ET
{
    public sealed class GraphicsQualityManager: MonoBehaviour
    {
        public const string PlayerPrefsKey = "MJ_GraphicsQualityLevel";

        private static GraphicsQualityManager instance;
        private static bool initialized;

        public static GraphicsQualityLevel CurrentLevel { get; private set; } = GraphicsQualityLevel.High;

        public static event Action<GraphicsQualityLevel> QualityChanged;

        public static bool HasManualSetting => TryGetManualLevel(out _);

        public static void Initialize()
        {
            if (initialized)
            {
                EnsureInstance();
                return;
            }

            instance = null;
            initialized = true;

            EnsureInstance();

            if (TryGetManualLevel(out GraphicsQualityLevel level))
            {
                ApplyQuality(level);
                return;
            }

            ApplyQuality(GraphicsQualityLevel.High);
        }

        private static GraphicsQualityManager EnsureInstance()
        {
            if (instance != null)
            {
                return instance;
            }

            GameObject managerObject = new GameObject("[GraphicsQualityManager]");
            managerObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSave;
            DontDestroyOnLoad(managerObject);
            instance = managerObject.AddComponent<GraphicsQualityManager>();
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

        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

        private static void EnsureInitialized()
        {
            if (initialized)
            {
                EnsureInstance();
                return;
            }

            Initialize();
        }

        public static void SetManualQuality(GraphicsQualityLevel level)
        {
            EnsureInitialized();
            level = ClampLevel(level);
            PlayerPrefs.SetInt(PlayerPrefsKey, (int)level);
            PlayerPrefs.Save();
            ApplyQuality(level);
        }

        public static void ResetToDefault()
        {
            EnsureInitialized();
            PlayerPrefs.DeleteKey(PlayerPrefsKey);
            PlayerPrefs.Save();
            ApplyQuality(GraphicsQualityLevel.High);
        }

        public static void ApplyQuality(GraphicsQualityLevel level)
        {
            Log.Warning($"设置画质 {level}");
            level = ClampLevel(level);
            CurrentLevel = level;
            QualityChanged?.Invoke(CurrentLevel);
        }

        private static bool TryGetManualLevel(out GraphicsQualityLevel level)
        {
            level = GraphicsQualityLevel.High;
            if (!PlayerPrefs.HasKey(PlayerPrefsKey))
            {
                return false;
            }

            int savedLevel = PlayerPrefs.GetInt(PlayerPrefsKey);
            if (savedLevel < (int)GraphicsQualityLevel.Low || savedLevel > (int)GraphicsQualityLevel.High)
            {
                PlayerPrefs.DeleteKey(PlayerPrefsKey);
                return false;
            }

            level = (GraphicsQualityLevel)savedLevel;
            return true;
        }

        private static GraphicsQualityLevel ClampLevel(GraphicsQualityLevel level)
        {
            return (GraphicsQualityLevel)Mathf.Clamp((int)level, (int)GraphicsQualityLevel.Low, (int)GraphicsQualityLevel.High);
        }
    }
}
