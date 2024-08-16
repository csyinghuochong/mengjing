using System;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgOneSellSet))]
    public static class DlgOneSellSetSystem
    {
        public static void RegisterUIEvent(this DlgOneSellSet self)
        {
            self.View.E_Btn_OneSellButton.AddListener(self.OnBtn_OneSellButton);
            self.View.E_Btn_CloseButton.AddListener(() => { self.OnBtn_CloseButton().Coroutine(); });

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string value = userInfoComponent.GetGameSettingValue(GameSettingEnum.OneSellSet2);
            string[] setvalues = value.Split('@');
            if (setvalues.Length < 6)
            {
                Array.Resize(ref setvalues, setvalues.Length + 1);
                setvalues[^1] = "0";
            }

            self.View.EG_OneSellSetRectTransform.Find("Image_Click_0").gameObject.SetActive(setvalues[0] == "1");
            self.View.EG_OneSellSetRectTransform.Find("Image_Click_1").gameObject.SetActive(setvalues[1] == "1");
            self.View.EG_OneSellSetRectTransform.Find("Image_Click_2").gameObject.SetActive(setvalues[2] == "1");
            self.View.EG_OneSellSetRectTransform.Find("Image_Click_3").gameObject.SetActive(setvalues[3] == "1");
            self.View.EG_OneSellSetRectTransform.Find("Image_Click_4").gameObject.SetActive(setvalues[4] == "1");
            self.View.EG_OneSellSetRectTransform.Find("Image_Click_5").gameObject.SetActive(setvalues[5] == "1");

            self.View.EG_OneSellSetRectTransform.Find("Btn_Click_0").GetComponent<Button>().onClick.AddListener(() => { self.OnBtn_OneSellSet(0); });
            self.View.EG_OneSellSetRectTransform.Find("Btn_Click_1").GetComponent<Button>().onClick.AddListener(() => { self.OnBtn_OneSellSet(1); });
            self.View.EG_OneSellSetRectTransform.Find("Btn_Click_2").GetComponent<Button>().onClick.AddListener(() => { self.OnBtn_OneSellSet(2); });
            self.View.EG_OneSellSetRectTransform.Find("Btn_Click_3").GetComponent<Button>().onClick.AddListener(() => { self.OnBtn_OneSellSet(3); });
            self.View.EG_OneSellSetRectTransform.Find("Btn_Click_4").GetComponent<Button>().onClick.AddListener(() => { self.OnBtn_OneSellSet(4); });
            self.View.EG_OneSellSetRectTransform.Find("Btn_Click_5").GetComponent<Button>().onClick.AddListener(() => { self.OnBtn_OneSellSet(5); });
        }

        public static void ShowWindow(this DlgOneSellSet self, Entity contextData = null)
        {
        }

        public static void OnBtn_OneSellSet(this DlgOneSellSet self, int index)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string value = userInfoComponent.GetGameSettingValue(GameSettingEnum.OneSellSet2);
            string[] setvalues = value.Split('@');
            if (setvalues.Length < 6)
            {
                Array.Resize(ref setvalues, setvalues.Length + 1);
                setvalues[setvalues.Length - 1] = "0";
            }

            setvalues[index] = setvalues[index] == "1" ? "0" : "1";
            value = $"{setvalues[0]}@{setvalues[1]}@{setvalues[2]}@{setvalues[3]}@{setvalues[4]}@{setvalues[5]}";

            self.View.EG_OneSellSetRectTransform.Find($"Image_Click_{index}").gameObject.SetActive(setvalues[index] == "1");
            self.SaveSettings(GameSettingEnum.OneSellSet2, value);
        }

        public static void OnBtn_OneSellButton(this DlgOneSellSet self)
        {
            BagClientNetHelper.RequestOneSell2(self.Root(), ItemLocType.ItemLocBag).Coroutine();
        }

        public static void SaveSettings(this DlgOneSellSet self, GameSettingEnum gameSettingEnum, string value)
        {
            bool exit = false;
            for (int i = 0; i < self.GameSettingInfos.Count; i++)
            {
                if (self.GameSettingInfos[i].KeyId == (int)gameSettingEnum)
                {
                    self.GameSettingInfos[i].Value = value;
                    exit = true;
                    break;
                }
            }

            if (!exit)
            {
                self.GameSettingInfos.Add(new KeyValuePair() { KeyId = (int)gameSettingEnum, Value = value });
            }

            self.Root().GetComponent<UserInfoComponentC>().UpdateGameSetting(self.GameSettingInfos);
        }

        public static async ETTask OnBtn_CloseButton(this DlgOneSellSet self)
        {
            if (self.GameSettingInfos.Count > 0)
            {
                self.Root().GetComponent<UserInfoComponentC>().UpdateGameSetting(self.GameSettingInfos);

                EventSystem.Instance.Publish(self.Root(), new SettingUpdate());

                await BagClientNetHelper.GameSetting(self.Root(), self.GameSettingInfos);
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_OneSellSet);
        }
    }
}
