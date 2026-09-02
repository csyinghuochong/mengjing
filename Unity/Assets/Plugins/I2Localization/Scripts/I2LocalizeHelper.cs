

namespace I2.Loc
{
    public static class I2LocalizeHelper
    {
        #if UNITY_EDITOR
        public const string I2GlobalSourcesEditorPath = "Assets/Config/Localization/I2Languages.asset";
        #endif

        public const string I2ResAssetNamePrefix = "I2_";
    }
}