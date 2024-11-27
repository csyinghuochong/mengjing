namespace ET.Client
{
    public static class SettingHelper
    {
        public static void OnSmooth(string value)
        {
            SettingData.ShowTitle = value == "0";
            SettingData.ShowGuangHuan = value == "0";
        }

        public static void OnShowOther(string value)
        {
            SettingData.NoShowOther = value == "1";
        }
    }
}