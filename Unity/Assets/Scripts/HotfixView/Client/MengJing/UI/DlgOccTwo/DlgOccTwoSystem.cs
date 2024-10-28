using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(DlgOccTwo))]
    public static class DlgOccTwoSystem
    {
        public static void RegisterUIEvent(this DlgOccTwo self)
        {
            self.View.E_Button_ZhiYe_3Button.AddListener(() => { self.OnButton_ZhiYe(2); });
            self.View.E_Button_ZhiYe_2Button.AddListener(() => { self.OnButton_ZhiYe(1); });
            self.View.E_Button_ZhiYe_1Button.AddListener(() => { self.OnButton_ZhiYe(0); });
            self.Button_ZhiYe_List.Add(self.View.E_Button_ZhiYe_1Button.gameObject);
            self.Button_ZhiYe_List.Add(self.View.E_Button_ZhiYe_2Button.gameObject);
            self.Button_ZhiYe_List.Add(self.View.E_Button_ZhiYe_3Button.gameObject);
            self.View.E_ButtonOccTwoButton.AddListener(self.OnButtonOccTwoButton);
            self.View.E_ButtonOccResetButton.AddListener(self.OnButtonOccResetButton);
            self.View.E_closeButtonButton.AddListener(self.OncloseButtonButton);
            self.View.E_Button_ZhiYeSelect_1Button.AddListener(self.OnButton_ZhiYeSelect_1Button);
            self.View.E_Button_ZhiYeSelect_2Button.AddListener(self.OnButton_ZhiYeSelect_2Button);
            self.View.E_Button_ZhiYeSelect_3Button.AddListener(self.OnButton_ZhiYeSelect_3Button);
            
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgOccTwo self, Entity contextData = null)
        {
        }

        public static void OnButtonOccTwoButton(this DlgOccTwo self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.OccTwo != 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("不能重复转职!");
                return;
            }

            OccupationTwoConfig occupationTwoConfig = OccupationTwoConfigCategory.Instance.Get(self.OccTwoId);
            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "转职", zstring.Format("是否转职为：{0}", occupationTwoConfig.OccupationName),
                    () => { self.RequestChangeOcc().Coroutine(); }).Coroutine();
            }
        }

        public static async ETTask RequestChangeOcc(this DlgOccTwo self)
        {
            bool ifChange = await SkillNetHelper.ChangeOccTwoRequest(self.Root(), self.OccTwoId);
            if (ifChange)
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_OccTwoShow).Coroutine();
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_OccTwo);
            }
        }

        public static void OnInitUI(this DlgOccTwo self)
        {
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(occ);
            self.View.E_Text_ZhiYeText.text = occupationConfig.OccupationName;

            int[] OccTwoID = occupationConfig.OccTwoID;
            self.View.E_Text_ZhiYe_1Text.text = OccupationTwoConfigCategory.Instance.Get(OccTwoID[0]).OccupationName;
            self.View.E_Text_ZhiYe_2Text.text = OccupationTwoConfigCategory.Instance.Get(OccTwoID[1]).OccupationName;
            self.View.E_Text_ZhiYe_3Text.text = OccupationTwoConfigCategory.Instance.Get(OccTwoID[2]).OccupationName;

            int occTwo = self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo;
            List<int> occTwoList = new List<int>(OccTwoID);
            int index = occTwoList.IndexOf(occTwo);
            index = index < 0 ? 0 : index;
            self.OnButton_ZhiYe(index);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"OccTwo_{OccTwoID[0]}");
            Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

            self.View.E_Button_ZhiYe_1Image.sprite = sp;

            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"OccTwo_{OccTwoID[1]}");
            sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

            self.View.E_Button_ZhiYe_2Image.sprite = sp;

            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"OccTwo_{OccTwoID[2]}");
            sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

            self.View.E_Button_ZhiYe_3Image.sprite = sp;

            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"Occ_{occ}");
            sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

            self.View.E_Image_ZhiYeImage.sprite = sp;
        }

        public static void OnButton_ZhiYe(this DlgOccTwo self, int index)
        {
            CommonViewHelper.SetImageGray(self.Root(), self.Button_ZhiYe_List[0], true);
            CommonViewHelper.SetImageGray(self.Root(), self.Button_ZhiYe_List[1], true);
            CommonViewHelper.SetImageGray(self.Root(), self.Button_ZhiYe_List[2], true);
            CommonViewHelper.SetImageGray(self.Root(), self.Button_ZhiYe_List[index], false);

            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(occ);
            self.OnSelectZhiYe(occupationConfig.OccTwoID[index]);

            //显示路线
            self.View.EG_OccLine_1RectTransform.gameObject.SetActive(false);
            self.View.EG_OccLine_2RectTransform.gameObject.SetActive(false);
            self.View.EG_OccLine_3RectTransform.gameObject.SetActive(false);

            self.View.E_Button_ZhiYeSelect_1Button.gameObject.SetActive(false);
            self.View.E_Button_ZhiYeSelect_2Button.gameObject.SetActive(false);
            self.View.E_Button_ZhiYeSelect_3Button.gameObject.SetActive(false);

            switch (index)
            {
                case 0:
                    self.View.EG_OccLine_1RectTransform.gameObject.SetActive(true);
                    self.View.E_Button_ZhiYeSelect_1Button.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.EG_OccLine_2RectTransform.gameObject.SetActive(true);
                    self.View.E_Button_ZhiYeSelect_2Button.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.EG_OccLine_3RectTransform.gameObject.SetActive(true);
                    self.View.E_Button_ZhiYeSelect_3Button.gameObject.SetActive(true);
                    break;
            }
        }

        public static void OnSelectZhiYe(this DlgOccTwo self, int occTwoId)
        {
            self.OccTwoId = occTwoId;
            OccupationTwoConfig occupationTwoConfig = OccupationTwoConfigCategory.Instance.Get(occTwoId);
            self.View.E_Text_ZhiYe_4Text.text = occupationTwoConfig.OccupationName;
            CommonViewHelper.DestoryChild(self.View.EG_SkillContainerRectTransform.gameObject);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            using (zstring.Block())
            {
                string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("HuJia_{0}", occupationTwoConfig.ArmorMastery));
                Sprite sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);

                self.View.E_Image_WuQi_ZhuanImage.sprite = sp1;

                path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("WuQi_{0}", occupationTwoConfig.WeaponType));
                sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);

                self.View.E_Image_WuQi_TypeImage.sprite = sp1;

                self.View.E_Lab_HuJiaText.text = zstring.Format("{0}专精", self.showType[occupationTwoConfig.ArmorMastery]);
                self.View.E_Lab_WuQiText.text = zstring.Format("{0}专精", self.showType[occupationTwoConfig.WeaponType]);

                path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("OccTwo_{0}", occupationTwoConfig.Id));
                sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);

                self.View.E_Image_ZhiYe_4Image.sprite = sp1;
            }

            self.View.EG_OccNengLi_1RectTransform.Find("Text_NengLiValue").GetComponent<Text>().text = occupationTwoConfig.Capacitys[0].ToString();
            self.View.EG_OccNengLi_2RectTransform.Find("Text_NengLiValue").GetComponent<Text>().text = occupationTwoConfig.Capacitys[1].ToString();
            self.View.EG_OccNengLi_3RectTransform.Find("Text_NengLiValue").GetComponent<Text>().text = occupationTwoConfig.Capacitys[2].ToString();

            using (zstring.Block())
            {
                Log.Info(zstring.Format("(float)occupationTwoConfig.Capacitys[0] * 1f / 100f = {0}", occupationTwoConfig.Capacitys[0] * 1f / 100f));
            }

            self.View.EG_OccNengLi_1RectTransform.Find("ImageProgress").GetComponent<Image>().fillAmount =
                    occupationTwoConfig.Capacitys[0] * 1f / 100f;
            self.View.EG_OccNengLi_1RectTransform.Find("ImageProgress").GetComponent<Image>().fillAmount =
                    occupationTwoConfig.Capacitys[1] * 1f / 100f;
            self.View.EG_OccNengLi_1RectTransform.Find("ImageProgress").GetComponent<Image>().fillAmount =
                    occupationTwoConfig.Capacitys[2] * 1f / 100f;

            var path = ABPathHelper.GetUGUIPath("Item/Item_CommonSkillItem");
            var bundleGameObject = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
            int[] skills = occupationTwoConfig.ShowTalentSkill;
            for (int i = 0; i < skills.Length; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
                CommonViewHelper.SetParent(go, self.View.EG_SkillContainerRectTransform.gameObject);
                go.SetActive(true);
                go.transform.localScale = Vector3.one * 1f;

                Scroll_Item_CommonSkillItem ui_item = self.AddChild<Scroll_Item_CommonSkillItem>();
                ui_item.uiTransform = go.transform;
                ui_item.OnUpdateUI(skills[i]);
            }
        }

        public static void OnButtonOccResetButton(this DlgOccTwo self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.OccTwo == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先选择一个职业！");
                return;
            }

            string costitem = CommonViewHelper.GetNeedItemDesc(ConfigData.ChangeOccItem);
            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "技能点重置", zstring.Format("是否花费{0}重置技能点", costitem), () => { self.RequestReset(2).Coroutine(); })
                        .Coroutine();
            }
        }

        public static async ETTask RequestReset(this DlgOccTwo self, int operation)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (!bagComponent.CheckNeedItem(ConfigData.ChangeOccItem))
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_ItemNotEnoughError);
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            int error = await SkillNetHelper.SkillOperation(self.Root(), operation);
            if (error != 0)
            {
                return;
            }

            userInfoComponent.UserInfo.OccTwo = 0;
            self.View.E_ButtonOccResetButton.gameObject.SetActive(false);
            EventSystem.Instance.Publish(self.Root(), new SkillReset());
        }
        public static void OncloseButtonButton(this DlgOccTwo self)
        {
        }
        public static void OnButton_ZhiYeSelect_1Button(this DlgOccTwo self)
        {
        }
        public static void OnButton_ZhiYeSelect_2Button(this DlgOccTwo self)
        {
        }
        public static void OnButton_ZhiYeSelect_3Button(this DlgOccTwo self)
        {
        }
    }
}
