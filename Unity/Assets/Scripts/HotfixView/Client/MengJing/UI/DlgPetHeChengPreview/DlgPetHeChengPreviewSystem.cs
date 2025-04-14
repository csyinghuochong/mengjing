using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(DlgPetHeChengPreview))]
    public static class DlgPetHeChengPreviewSystem
    {
        public static void RegisterUIEvent(this DlgPetHeChengPreview self)
        {
            self.PetZiZhiItemList[0] = self.View.EG_PetZiZhiItem1RectTransform.gameObject;
            self.PetZiZhiItemList[1] = self.View.EG_PetZiZhiItem2RectTransform.gameObject;
            self.PetZiZhiItemList[2] = self.View.EG_PetZiZhiItem3RectTransform.gameObject;
            self.PetZiZhiItemList[3] = self.View.EG_PetZiZhiItem4RectTransform.gameObject;
            self.PetZiZhiItemList[4] = self.View.EG_PetZiZhiItem5RectTransform.gameObject;
            self.PetZiZhiItemList[5] = self.View.EG_PetZiZhiItem6RectTransform.gameObject;

            self.View.E_CommonSkillItems_ALoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItems_ARefresh);
            self.View.E_CommonSkillItems_BLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItems_BRefresh);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);

            self.View.E_Btn_CloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetHeChengPreview);
            });
        }

        public static void ShowWindow(this DlgPetHeChengPreview self, Entity contextData = null)
        {
        }

        private static void OnCommonSkillItems_ARefresh(this DlgPetHeChengPreview self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems_A.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems_A[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdatePetSkill(self.PetAbaseSkillId[index], ABAtlasTypes.RoleSkillIcon);
        }

        private static void OnCommonSkillItems_BRefresh(this DlgPetHeChengPreview self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems_B.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems_B[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdatePetSkill(self.PetBbaseSkillId[index], ABAtlasTypes.RoleSkillIcon);
        }

        private static void OnCommonSkillItemsRefresh(this DlgPetHeChengPreview self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdatePetSkill(self.AllSkillId[index], ABAtlasTypes.RoleSkillIcon);
        }

        public static void UpdateInfo(this DlgPetHeChengPreview self, RolePetInfo rolePetA, RolePetInfo rolePetB)
        {
            RolePetInfo rolePetInfoMin = new();
            RolePetInfo rolePetInfoMax = new();
            (rolePetInfoMin, rolePetInfoMax) = PetHelper.GetPetHeChengZiZhiPreview(rolePetA, rolePetB);

            using (zstring.Block())
            {
                self.PetZiZhiItemList[0].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}-{1}", rolePetInfoMin.ZiZhi_Hp, rolePetInfoMax.ZiZhi_Hp);
                self.PetZiZhiItemList[1].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}-{1}", rolePetInfoMin.ZiZhi_Act, rolePetInfoMax.ZiZhi_Act);
                self.PetZiZhiItemList[2].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}-{1}", rolePetInfoMin.ZiZhi_Def, rolePetInfoMax.ZiZhi_Def);
                self.PetZiZhiItemList[3].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}-{1}", rolePetInfoMin.ZiZhi_Adf, rolePetInfoMax.ZiZhi_Adf);
                self.PetZiZhiItemList[4].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}-{1}", rolePetInfoMin.ZiZhi_MageAct, rolePetInfoMax.ZiZhi_MageAct);
                self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}-{1}", CommonViewHelper.ShowFloatValue(rolePetInfoMin.ZiZhi_ChengZhang),
                            CommonViewHelper.ShowFloatValue(rolePetInfoMax.ZiZhi_ChengZhang));
            }

            self.PetZiZhiItemList[0].transform.Find("ImageExpMinValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMin.ZiZhi_Hp / 3000, 0f, 1f);
            self.PetZiZhiItemList[0].transform.Find("ImageExpMaxValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMax.ZiZhi_Hp / 3000, 0f, 1f);

            self.PetZiZhiItemList[1].transform.Find("ImageExpMinValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMin.ZiZhi_Act / 1500, 0f, 1f);
            self.PetZiZhiItemList[1].transform.Find("ImageExpMaxValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMax.ZiZhi_Act / 1500, 0f, 1f);

            self.PetZiZhiItemList[2].transform.Find("ImageExpMinValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMin.ZiZhi_Def / 1500, 0f, 1f);
            self.PetZiZhiItemList[2].transform.Find("ImageExpMaxValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMax.ZiZhi_Def / 1500, 0f, 1f);

            self.PetZiZhiItemList[3].transform.Find("ImageExpMinValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMin.ZiZhi_Adf / 1500, 0f, 1f);
            self.PetZiZhiItemList[3].transform.Find("ImageExpMaxValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMax.ZiZhi_Adf / 1500, 0f, 1f);

            self.PetZiZhiItemList[4].transform.Find("ImageExpMinValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMin.ZiZhi_MageAct / 1500, 0f, 1f);
            self.PetZiZhiItemList[4].transform.Find("ImageExpMaxValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMax.ZiZhi_MageAct / 1500, 0f, 1f);

            self.PetZiZhiItemList[5].transform.Find("ImageExpMinValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMin.ZiZhi_ChengZhang / 1.25f, 0f, 1f);
            self.PetZiZhiItemList[5].transform.Find("ImageExpMaxValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfoMax.ZiZhi_ChengZhang / 1.25f, 0f, 1f);

            // 宠物A
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetA.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            ReferenceCollector rc = self.View.EG_PetItemARectTransform.transform.GetComponent<ReferenceCollector>();
            rc.Get<GameObject>("Image_ItemIcon").GetComponent<Image>().sprite = sp;
            rc.Get<GameObject>("Label_ItemName").GetComponent<Text>().text = rolePetA.PetName;
            self.PetAbaseSkillId.Clear();
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetA.ConfigId);
            string[] baseASkillID = petConfig.BaseSkillID.Split(';');
            for (int i = 0; i < baseASkillID.Length; i++)
            {
                self.PetAbaseSkillId.Add(int.Parse(baseASkillID[i]));
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems_A, self.PetAbaseSkillId.Count);
            self.View.E_CommonSkillItems_ALoopVerticalScrollRect.SetVisible(true, self.PetAbaseSkillId.Count);

            // 宠物B
            petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetB.SkinId);
            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            rc = self.View.EG_PetItemBRectTransform.transform.GetComponent<ReferenceCollector>();
            rc.Get<GameObject>("Image_ItemIcon").GetComponent<Image>().sprite = sp;
            rc.Get<GameObject>("Label_ItemName").GetComponent<Text>().text = rolePetB.PetName;
            self.PetBbaseSkillId.Clear();
            petConfig = PetConfigCategory.Instance.Get(rolePetB.ConfigId);
            string[] baseBSkillID = petConfig.BaseSkillID.Split(';');
            for (int i = 0; i < baseBSkillID.Length; i++)
            {
                self.PetBbaseSkillId.Add(int.Parse(baseBSkillID[i]));
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems_B, self.PetBbaseSkillId.Count);
            self.View.E_CommonSkillItems_BLoopVerticalScrollRect.SetVisible(true, self.PetBbaseSkillId.Count);

            // 概率消失技能
            self.AllSkillId.Clear();
            self.AllSkillId.AddRange(rolePetA.PetSkill);
            self.AllSkillId.AddRange(rolePetB.PetSkill);
            self.AllSkillId.RemoveAll(item => self.PetAbaseSkillId.Contains(item));
            self.AllSkillId.RemoveAll(item => self.PetBbaseSkillId.Contains(item));
            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.AllSkillId.Count);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.AllSkillId.Count);
        }
    }
}