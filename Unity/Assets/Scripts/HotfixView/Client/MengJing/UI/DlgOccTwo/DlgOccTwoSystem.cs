using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof (DlgOccTwo))]
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
            self.View.E_ButtonOccTwoButton.AddListener(self.OnClickOccTwo);
            self.View.E_ButtonOccResetButton.AddListenerAsync(self.OnButtonOccReset);

            self.OnInitUI();
        }

        public static void ShowWindow(this DlgOccTwo self, Entity contextData = null)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        public static void OnCloseButton(this DlgOccTwo self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_OccTwo);
        }

        public static void OnClickOccTwo(this DlgOccTwo self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.OccTwo != 0)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("不能重复转职!");
                return;
            }

            OccupationTwoConfig occupationTwoConfig = OccupationTwoConfigCategory.Instance.Get(self.OccTwoId);
            PopupTipHelp.OpenPopupTip(self.Root(), "转职", $"是否转职为：{occupationTwoConfig.OccupationName}",
                () => { self.RequestChangeOcc().Coroutine(); }).Coroutine();
        }

        public static async ETTask RequestChangeOcc(this DlgOccTwo self)
        {
            bool ifChange = await SkillNetHelper.ChangeOccTwoRequest(self.Root(), self.OccTwoId);
            if (ifChange)
            {
                // self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_OccTwoShow).Coroutine();
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
            index = index < 0? 0 : index;
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
            UICommonHelper.SetImageGray(self.Root(), self.Button_ZhiYe_List[0], true);
            UICommonHelper.SetImageGray(self.Root(), self.Button_ZhiYe_List[1], true);
            UICommonHelper.SetImageGray(self.Root(), self.Button_ZhiYe_List[2], true);
            UICommonHelper.SetImageGray(self.Root(), self.Button_ZhiYe_List[index], false);

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
            UICommonHelper.DestoryChild(self.View.EG_SkillContainerRectTransform.gameObject);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"HuJia_{occupationTwoConfig.ArmorMastery}");
            Sprite sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);

            self.View.E_Image_WuQi_ZhuanImage.sprite = sp1;

            path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"WuQi_{occupationTwoConfig.WeaponType}");
            sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);

            self.View.E_Image_WuQi_TypeImage.sprite = sp1;

            self.View.E_Lab_HuJiaText.text = self.showType[occupationTwoConfig.ArmorMastery] + "专精";
            self.View.E_Lab_WuQiText.text = self.showType[occupationTwoConfig.WeaponType] + "专精";

            path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"OccTwo_{occupationTwoConfig.Id}");
            sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);

            self.View.E_Image_ZhiYe_4Image.sprite = sp1;

            self.View.EG_OccNengLi_1RectTransform.Find("Text_NengLiValue").GetComponent<Text>().text = occupationTwoConfig.Capacitys[0].ToString();
            self.View.EG_OccNengLi_2RectTransform.Find("Text_NengLiValue").GetComponent<Text>().text = occupationTwoConfig.Capacitys[1].ToString();
            self.View.EG_OccNengLi_3RectTransform.Find("Text_NengLiValue").GetComponent<Text>().text = occupationTwoConfig.Capacitys[2].ToString();

            Log.Info("(float)occupationTwoConfig.Capacitys[0] * 1f / 100f = " + occupationTwoConfig.Capacitys[0] * 1f / 100f);
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
                UICommonHelper.SetParent(go, self.View.EG_SkillContainerRectTransform.gameObject);
                go.SetActive(true);
                go.transform.localScale = Vector3.one * 1f;

                Scroll_Item_CommonSkillItem ui_item = self.AddChild<Scroll_Item_CommonSkillItem>();
                ui_item.uiTransform = go.transform;
                ui_item.OnUpdateUI(skills[i]);
            }
        }

        public static async ETTask OnButtonOccReset(this DlgOccTwo self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.OccTwo == 0)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请先选择一个职业！");
                return;
            }

            string costitem = UICommonHelper.GetNeedItemDesc(ConfigData.ChangeOccItem);
            PopupTipHelp.OpenPopupTip(self.Root(), "技能点重置", $"是否花费{costitem}重置技能点", () => { self.RequestReset(2).Coroutine(); }).Coroutine();

            await ETTask.CompletedTask;
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
            C2M_SkillOperation request = new() { OperationType = operation };
            M2C_SkillOperation response = (M2C_SkillOperation)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error != 0)
            {
                return;
            }

            userInfoComponent.UserInfo.OccTwo = 0;
            self.View.E_ButtonOccResetButton.gameObject.SetActive(false);
            EventSystem.Instance.Publish(self.Root(), new DataUpdate_SkillReset());
        }
    }
}