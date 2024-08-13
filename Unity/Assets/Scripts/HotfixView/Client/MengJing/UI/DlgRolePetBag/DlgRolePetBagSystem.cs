using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RolePetBagItem))]
    [FriendOf(typeof(DlgRolePetBag))]
    public static class DlgRolePetBagSystem
    {
        public static void RegisterUIEvent(this DlgRolePetBag self)
        {
            self.View.E_RolePetBagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRolePetBagItemsRefresh);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.View.E_FenjieBtnButton.AddListener(self.OnFenjieBtnButton);
            self.View.E_TakeOutBagBtnButton.AddListener(self.OnTakeOutBagBtnButton);
        }

        public static void ShowWindow(this DlgRolePetBag self, Entity contextData = null)
        {
            self.PetZiZhiItemList[0] = self.View.EG_PetZiZhiItem1RectTransform.gameObject;
            self.PetZiZhiItemList[1] = self.View.EG_PetZiZhiItem2RectTransform.gameObject;
            self.PetZiZhiItemList[2] = self.View.EG_PetZiZhiItem3RectTransform.gameObject;
            self.PetZiZhiItemList[3] = self.View.EG_PetZiZhiItem4RectTransform.gameObject;
            self.PetZiZhiItemList[4] = self.View.EG_PetZiZhiItem5RectTransform.gameObject;
            self.PetZiZhiItemList[5] = self.View.EG_PetZiZhiItem6RectTransform.gameObject;

            foreach (GameObject go in self.PetZiZhiItemList)
            {
                go.SetActive(false);
            }

            self.View.E_TakeOutBagBtnButton.AddListenerAsync(self.OnTakeOutBagBtn);
            self.View.E_FenjieBtnButton.AddListenerAsync(self.OnFenjieBtn);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_Close);

            self.OnUpdatePetList();
        }

        private static void OnCommonSkillItemsRefresh(this DlgRolePetBag self, Transform transform, int index)
        {
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdateUI(self.ShowSkills[index], ABAtlasTypes.PetSkillIcon,
                self.RolePetInfo.LockSkill.Contains(self.ShowSkills[index]));
        }

        private static void OnRolePetBagItemsRefresh(this DlgRolePetBag self, Transform transform, int index)
        {
            Scroll_Item_RolePetBagItem scrollItemRolePetBagItem = self.ScrollItemRolePetBagItems[index].BindTrans(transform);
            scrollItemRolePetBagItem.OnInitUI(self.ShowRolePetInfos[index]);
            scrollItemRolePetBagItem.SetClickHandler((petId) => { self.OnClickPetHandler(petId); });
        }

        public static async ETTask OnTakeOutBagBtn(this DlgRolePetBag self)
        {
            if (self.RolePetInfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("未选中宠物");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int petexpendNumber = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()
                    .GetAsInt(NumericType.PetExtendNumber);
            int maxNum = PetHelper.GetPetMaxNumber(userInfo.Lv, petexpendNumber);
            if (PetHelper.GetBagPetNum(self.Root().GetComponent<PetComponentC>().RolePetInfos) >= maxNum)
            {
                FlyTipComponent.Instance.ShowFlyTip("已达到宠物最大数量");
                return;
            }

            int error = await PetNetHelper.RequestPetTakeOutBag(self.Root(), self.RolePetInfo.Id);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.OnUpdatePetList();
        }

        public static async ETTask OnFenjieBtn(this DlgRolePetBag self)
        {
            if (self.RolePetInfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("未选中宠物");
                return;
            }

            int error = await PetNetHelper.RequestRolePetFenjie(self.Root(), self.RolePetInfo.Id);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.OnUpdatePetList();
        }

        public static void OnBtn_Close(this DlgRolePetBag self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RolePetBag);
        }

        public static void OnUpdatePetList(this DlgRolePetBag self)
        {
            self.RolePetInfo = null;

            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetBag;

            self.ShowRolePetInfos.Clear();
            self.ShowRolePetInfos.AddRange(rolePetInfos);

            self.AddUIScrollItems(ref self.ScrollItemRolePetBagItems, self.ShowRolePetInfos.Count);
            self.View.E_RolePetBagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);

            if (self.ShowRolePetInfos.Count > 0)
            {
                foreach (GameObject go in self.PetZiZhiItemList)
                {
                    go.SetActive(true);
                }

                Scroll_Item_RolePetBagItem scrollItemRolePetBagItem = self.ScrollItemRolePetBagItems[0];
                scrollItemRolePetBagItem.OnImage_ItemButton();
            }

            using (zstring.Block())
            {
                self.View.E_TextNumberText.text =
                        zstring.Format("宠物数量： {0}/{1}", rolePetInfos.Count, GlobalValueConfigCategory.Instance.Get(119).Value2);
            }
        }

        public static void OnClickPetHandler(this DlgRolePetBag self, RolePetInfo rolePetInfo)
        {
            self.RolePetInfo = rolePetInfo;

            if (self.ScrollItemRolePetBagItems != null)
            {
                foreach (Scroll_Item_RolePetBagItem item in self.ScrollItemRolePetBagItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(rolePetInfo.Id);
                }
            }

            self.UpdatePetZizhi(rolePetInfo);
            self.UpdateSkillList(rolePetInfo);
        }

        public static void UpdatePetZizhi(this DlgRolePetBag self, RolePetInfo rolePetInfo)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            using (zstring.Block())
            {
                self.PetZiZhiItemList[0].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}/{1}", rolePetInfo.ZiZhi_Hp, petConfig.ZiZhi_Hp_Max);
                self.PetZiZhiItemList[1].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}/{1}", rolePetInfo.ZiZhi_Act, petConfig.ZiZhi_Act_Max);
                self.PetZiZhiItemList[2].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}/{1}", rolePetInfo.ZiZhi_Def, petConfig.ZiZhi_Def_Max);
                self.PetZiZhiItemList[3].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}/{1}", rolePetInfo.ZiZhi_Adf, petConfig.ZiZhi_Adf_Max);
                self.PetZiZhiItemList[4].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}/{1}", rolePetInfo.ZiZhi_MageAct, petConfig.ZiZhi_MageAct_Max);
                self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}/{1}", CommonViewHelper.ShowFloatValue(rolePetInfo.ZiZhi_ChengZhang),
                            CommonViewHelper.ShowFloatValue((float)petConfig.ZiZhi_ChengZhang_Max));
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            Sprite sprite16 = resourcesLoaderComponent.LoadAssetSync<Sprite>("Assets/Bundles/Icon/OtherIcon/Pro_16.png");
            Sprite sprite17 = resourcesLoaderComponent.LoadAssetSync<Sprite>("Assets/Bundles/Icon/OtherIcon/Pro_17.png");

            self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Hp >= petConfig.ZiZhi_Hp_Max ? sprite16 : sprite17;
            self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Hp / (float)petConfig.ZiZhi_Hp_Max, 0f, 1f);

            self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Act >= petConfig.ZiZhi_Act_Max ? sprite16 : sprite17;
            self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Act / (float)petConfig.ZiZhi_Act_Max, 0f, 1f);

            self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Def >= petConfig.ZiZhi_Def_Max ? sprite16 : sprite17;
            self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Def / (float)petConfig.ZiZhi_Def_Max, 0f, 1f);

            self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Adf >= petConfig.ZiZhi_Adf_Max ? sprite16 : sprite17;
            self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Adf / (float)petConfig.ZiZhi_Adf_Max, 0f, 1f);

            self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_MageAct >= petConfig.ZiZhi_MageAct_Max ? sprite16 : sprite17;
            self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_MageAct / (float)petConfig.ZiZhi_MageAct_Max, 0f, 1f);

            self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_ChengZhang >= petConfig.ZiZhi_ChengZhang_Max ? sprite16 : sprite17;
            self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_ChengZhang / (float)petConfig.ZiZhi_ChengZhang_Max, 0f, 1f);
        }

        public static void UpdateSkillList(this DlgRolePetBag self, RolePetInfo rolePetInfo)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            List<int> zhuanzhuids = new List<int>();
            string[] zhuanzhuskills = petConfig.ZhuanZhuSkillID.Split(';');
            for (int i = 0; i < zhuanzhuskills.Length; i++)
            {
                if (zhuanzhuskills[i].Length > 1)
                {
                    zhuanzhuids.Add(int.Parse(zhuanzhuskills[i]));
                }
            }

            List<int> skills = new List<int>();
            for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            {
                if (zhuanzhuids.Contains(rolePetInfo.PetSkill[i]))
                {
                    skills.Insert(0, rolePetInfo.PetSkill[i]);
                }
                else
                {
                    skills.Add(rolePetInfo.PetSkill[i]);
                }
            }

            self.ShowSkills.Clear();
            self.ShowSkills.AddRange(skills);

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.ShowSkills.Count);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowSkills.Count);
        }
        public static void OnBtn_CloseButton(this DlgRolePetBag self)
        {
        }
        public static void OnFenjieBtnButton(this DlgRolePetBag self)
        {
        }
        public static void OnTakeOutBagBtnButton(this DlgRolePetBag self)
        {
        }
    }
}
