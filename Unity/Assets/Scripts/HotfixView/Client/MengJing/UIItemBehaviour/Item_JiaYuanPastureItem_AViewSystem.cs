using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanPastureItem_A))]
    [EntitySystemOf(typeof(Scroll_Item_JiaYuanPastureItem_A))]
    public static partial class Scroll_Item_JiaYuanPastureItem_ASystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JiaYuanPastureItem_A self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JiaYuanPastureItem_A self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this Scroll_Item_JiaYuanPastureItem_A self, JiaYuanPastureConfig zuoQiConfig, int index)
        {
            // self.ES_ModelShow.ShowOtherModel("Pasture/" + zuoQiConfig.Assets).Coroutine();
            self.ES_ModelShow.ShowOtherModel("Pasture/10001").Coroutine();
            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 100f, 450f));
            self.ES_ModelShow.Camera.fieldOfView = 30;
            // self.ES_ModelShow.SetRootPosition(new Vector2(index * 1000 + 1000, 0));
            self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanPastureItem_A self, MysteryItemInfo mysteryItemInfo, int index)
        {
            self.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuy);

            JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(mysteryItemInfo.MysteryId);
            self.OnInitUI(jiaYuanPastureConfig, index);
            self.MysteryItemInfo = mysteryItemInfo;

            // 判断家园等级是否足够
            int jiayuanid = self.Root().GetComponent<UserInfoComponentC>().UserInfo.JiaYuanLv;
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(jiayuanid);
            if (jiaYuanPastureConfig.BuyJiaYuanLv <= jiayuanCof.Lv)
            {
                using (zstring.Block())
                {
                    self.E_Text_RenKouText.text = zstring.Format("人口：{0}", jiaYuanPastureConfig.PeopleNum);
                }

                self.E_Text_NameText.text = jiaYuanPastureConfig.Name;
                self.E_Text_value2Text.text = ((int)(jiaYuanPastureConfig.BuyGold * 1.5f)).ToString();

                int hour = jiaYuanPastureConfig.UpTime[3] / 3600;
                using (zstring.Block())
                {
                    self.E_Text_valueText.text = zstring.Format("{0}小时", hour);
                }
            }
            else
            {
                self.E_Text_NameText.text = jiaYuanPastureConfig.Name;

                Material mat = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
                self.ES_ModelShow.E_RenderRawImage.material = mat;
                self.E_Text_RenKouText.gameObject.SetActive(false);
                self.E_Text_Tip11Text.gameObject.SetActive(false);
                self.E_Text_Tip12Text.gameObject.SetActive(false);
                self.E_Text_value2Text.gameObject.SetActive(false);
                self.E_Text_valueText.gameObject.SetActive(false);
                self.E_Text_TipText.gameObject.SetActive(true);
                using (zstring.Block())
                {
                    self.E_Text_TipText.text = zstring.Format("家园{0}级开启", jiaYuanPastureConfig.BuyJiaYuanLv);
                }
            }
        }

        public static async ETTask OnButtonBuy(this Scroll_Item_JiaYuanPastureItem_A self)
        {
            JiaYuanPastureConfig myJiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(self.MysteryItemInfo.MysteryId);

            // 判断家园等级是否足够
            int jiayuanid = self.Root().GetComponent<UserInfoComponentC>().UserInfo.JiaYuanLv;
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(jiayuanid);
            if (myJiaYuanPastureConfig.BuyJiaYuanLv > jiayuanCof.Lv)
            {
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("家园{0}级开启", myJiaYuanPastureConfig.BuyJiaYuanLv));
                }

                return;
            }

            int leftSpace = self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag);
            if (leftSpace < 1)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_BagIsFull);
                return;
            }

            JiaYuanPastureConfig mysteryConfig = JiaYuanPastureConfigCategory.Instance.Get(self.MysteryItemInfo.MysteryId);
            using (zstring.Block())
            {
                if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem(zstring.Format("13;{0}", mysteryConfig.BuyGold)))
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_HouBiNotEnough);
                    return;
                }
            }

            M2C_JiaYuanPastureBuyResponse response =
                    await JiaYuanNetHelper.JiaYuanPastureBuyRequest(self.Root(), self.MysteryItemInfo.MysteryId, self.MysteryItemInfo.ProductId);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<JiaYuanComponentC>().JiaYuanPastureList_7 = response.JiaYuanPastureList;

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>().OnUpdatePlanNumber();

            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("购买{0}成功", mysteryConfig.Name));
            }
        }
    }
}