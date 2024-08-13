using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (DlgSettingFrame))]
    public static class DlgSettingFrameSystem
    {
        public static void RegisterUIEvent(this DlgSettingFrame self)
        {
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);
            self.View.E_ImageDiCloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SettingFrame);
            });
            self.View.E_ButtonHighButton.AddListener(() => { self.OnButtonSetting("1").Coroutine(); });
            self.View.E_ButtonNormalButton.AddListener(() => { self.OnButtonSetting("0").Coroutine(); });
        }

        public static void ShowWindow(this DlgSettingFrame self, Entity contextData = null)
        {
        }

        public static void OnButtonCloseButton(this DlgSettingFrame self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SettingFrame);
        }
        
        public static async ETTask OnButtonSetting(this DlgSettingFrame self, string setvalue)
        {
            List<KeyValuePair> gameSettingInfos = new List<KeyValuePair>();
            gameSettingInfos.Add(new() { KeyId = (int)GameSettingEnum.HighFps, Value = setvalue });
            self.Root().GetComponent<UserInfoComponentC>().UpdateGameSetting(gameSettingInfos);

            await BagClientNetHelper.GameSetting(self.Root(), gameSettingInfos);
            CommonViewHelper.TargetFrameRate(setvalue == "1"? 60 : 30);

            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.LastFrame, 1);

            if (setvalue == "1")
            {
                FlyTipComponent.Instance.ShowFlyTip("你开启了高帧模式");
            }

            if (setvalue == "0")
            {
                FlyTipComponent.Instance.ShowFlyTip("你开启了普通模式");
            }

            //移除界面
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SettingFrame);
        }
    }
}
