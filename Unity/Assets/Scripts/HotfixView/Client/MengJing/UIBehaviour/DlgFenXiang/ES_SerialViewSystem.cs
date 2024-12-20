using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_Serial))]
    [FriendOfAttribute(typeof (ES_Serial))]
    public static partial class ES_SerialSystem
    {
        [EntitySystem]
        private static void Awake(this ES_Serial self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonGetButton.AddListenerAsync(self.OnButtonGetButton);
            self.E_ButtonOkButton.AddListener(self.OnButtonOkButton);

            if (PlayerPrefsHelp.GetInt(PlayerPrefsHelp.ZhuBo) == 1)
            {
                self.E_QRImgImage.gameObject.SetActive(false);
            }

            if (GlobalHelp.GetPlatform() == 5 || GlobalHelp.GetPlatform() == 6)
            {
                self.E_QRImgImage.gameObject.SetActive(false);
            }

            self.ES_RewardList.Refresh(ConfigData.SerialReward[1]);
        }

        [EntitySystem]
        private static void Destroy(this ES_Serial self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonGetButton(this ES_Serial self)
        {
            if (Time.time - self.LastTime < 2f)
            {
                return;
            }

            if (self.Root().GetComponent<PlayerInfoComponent>().SerialErrorTime >= 10)
            {
                return;
            }

            string serial = self.E_InputField_CodeInputField.text;
            if (string.IsNullOrEmpty(serial))
            {
                return;
            }

            self.LastTime = Time.time;

            int publicserial = ActivityConfigCategory.Instance.GetPulicSerial(serial);
            if (publicserial > 0)
            {
                await ActivityNetHelper.ActivityReceive(self.Root(), 34, publicserial);
            }
            else
            {
                M2C_SerialReardResponse response = await ActivityNetHelper.SerialReardRequest(self.Root(), serial);
                if (response.Error != ErrorCode.ERR_Success)
                {
                    self.Root().GetComponent<PlayerInfoComponent>().SerialErrorTime++;
                }
            }
        }

        // public static HotVersion GetHotVersion(this ES_Serial self)
        // {
        //     var path_1 = ABPathHelper.GetTextPath("Version");
        //     var request = libx.Assets.LoadAsset(path_1, typeof (TextAsset));
        //     TextAsset textAsset3 = request.asset as TextAsset;
        //     return JsonHelper.FromJson<HotVersion>(textAsset3.text);
        // }

        public static void OnButtonOkButton(this ES_Serial self)
        {
            //             HotVersion hotVersion = self.GetHotVersion();
            //
            // #if UNITY_IPHONE || UNITY_IOS
            //             Application.OpenURL(hotVersion.IOS_URL);
            // #else
            //             Application.OpenURL("https://l.tapdb.net/uBzaWYgH?channel=rep-rep_u6yj0zgt91n");
            // #endif
        }
    }
}
