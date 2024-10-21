using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RechargeItem))]
    [EntitySystemOf(typeof(Scroll_Item_RechargeItem))]
    public static partial class Scroll_Item_RechargeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RechargeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RechargeItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitData(this Scroll_Item_RechargeItem self, int recharge, int giveNumber)
        {
            self.E_ButtonChargeButton.AddListener(self.OnImageButton);
            self.RechargeNumber = recharge;

            using (zstring.Block())
            {
                self.E_Text_giveText.text = zstring.Format("{0} {1}", LanguageComponent.Instance.LoadLocalization("赠送"), giveNumber);
            }

            self.EG_ZengSongRectTransform.gameObject.SetActive(giveNumber > 0);
            self.E_Text_ZuanShiText.text = (recharge * 100).ToString();
            self.E_Text_RMBText.text = "￥" + recharge;

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RechageIcon, "UI_Image_Recharge_" + recharge);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageIconImage.sprite = sp;
            self.E_ImageIconImage.SetNativeSize();
            self.E_ImageIconImage.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }

        public static void OnImageButton(this Scroll_Item_RechargeItem self)
        {
            self.ClickHandler(self.RechargeNumber);
        }

        public static void SetClickHandler(this Scroll_Item_RechargeItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }
    }
}