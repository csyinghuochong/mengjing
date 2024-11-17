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

        public static void SetView(Scene root)
        {
            if (PlayerPrefsHelp.GetInt(PlayerPrefsHelp.UseCustomView) > 0)
            {
                float lenDepth = PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.LenDepth, PlayerPrefsHelp.LenDepth_Default);
                MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
                cameraComponent.LenDepth = lenDepth;
                cameraComponent.OffsetPostion =
                        new(PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.OffsetPostion_X, PlayerPrefsHelp.OffsetPostion_X_Default),
                            PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.OffsetPostion_Y, PlayerPrefsHelp.OffsetPostion_Y_Default),
                            PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.OffsetPostion_Z, PlayerPrefsHelp.OffsetPostion_Z_Default));
                cameraComponent.HorizontalOffset =
                        PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.CameraHorizontalOffset, PlayerPrefsHelp.CameraHorizontalOffset_Default);
                cameraComponent.VerticalOffset =
                        PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.CameraVerticalOffset, PlayerPrefsHelp.CameraVerticalOffset_Default);
            }
            else
            {
                MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
                cameraComponent.LenDepth = PlayerPrefsHelp.LenDepth_Default;
                cameraComponent.OffsetPostion = new(PlayerPrefsHelp.OffsetPostion_X_Default, PlayerPrefsHelp.OffsetPostion_Y_Default,
                    PlayerPrefsHelp.OffsetPostion_Z_Default);
                cameraComponent.HorizontalOffset = PlayerPrefsHelp.CameraHorizontalOffset_Default;
                cameraComponent.VerticalOffset = PlayerPrefsHelp.CameraVerticalOffset_Default;
            }
        }
    }
}