using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(DlgPetChouKaGet))]
    public static class DlgPetChouKaGetSystem
    {
        public static void RegisterUIEvent(this DlgPetChouKaGet self)
        {
            self.PetZiZhiItemList[0] = self.View.EG_PetZiZhiItem1RectTransform.gameObject;
            self.PetZiZhiItemList[1] = self.View.EG_PetZiZhiItem2RectTransform.gameObject;
            self.PetZiZhiItemList[2] = self.View.EG_PetZiZhiItem3RectTransform.gameObject;
            self.PetZiZhiItemList[3] = self.View.EG_PetZiZhiItem4RectTransform.gameObject;
            self.PetZiZhiItemList[4] = self.View.EG_PetZiZhiItem5RectTransform.gameObject;
            self.PetZiZhiItemList[5] = self.View.EG_PetZiZhiItem6RectTransform.gameObject;

            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
            self.View.E_BianYiDiButton.AddListener(self.OnBianYiDiButton);
            self.View.E_LucklyButton.AddListener(self.OnLucklyButton);
        }

        public static void ShowWindow(this DlgPetChouKaGet self, Entity contextData = null)
        {
        }

        private static void InitModelShowView(this DlgPetChouKaGet self, RolePetInfo rolePetInfo)
        {
            self.View.ES_ModelShow.SetCameraPosition(new Vector3(0f, 115, 257f));

            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            using (zstring.Block())
            {
                self.View.ES_ModelShow.ShowOtherModel(zstring.Format("Pet/{0}", petSkinConfig.SkinID)).Coroutine();
            }
        }

        private static void OnBtn_CloseButton(this DlgPetChouKaGet self)
        {
            self.Root().GetComponent<BattleMessageComponent>().ShowPetChouKaGet = false;
            // self.Root().GetComponent<BattleMessageComponent>().ShowRolePetAdd();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetChouKaGet);
        }

        public static void OnInitUI(this DlgPetChouKaGet self, RolePetInfo rolePetInfo, List<KeyValuePair> oldSkins,
        RolePetInfo oldRolePetInfo = null)
        {
            self.RolePetInfo = rolePetInfo;
            self.OldRolePetInfo = oldRolePetInfo;

            self.InitModelShowView(rolePetInfo);

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);

            bool newSkin = true;
            for (int p = 0; p < oldSkins.Count; p++)
            {
                if (oldSkins[p].KeyId != rolePetInfo.ConfigId)
                {
                    continue;
                }

                if (oldSkins[p].Value.Contains(rolePetInfo.SkinId.ToString()))
                {
                    newSkin = false;
                    break;
                }
            }

            // 获取此模型是否被激活
            if (newSkin == true)
            {
                self.View.E_NewSkinNameText.gameObject.SetActive(true);
                self.View.EG_PiFuJiHuoRectTransform.gameObject.SetActive(true);
            }
            else
            {
                self.View.E_NewSkinNameText.gameObject.SetActive(false);
                self.View.EG_PiFuJiHuoRectTransform.gameObject.SetActive(false);
            }

            self.View.E_Text_TipText.text = petConfig.PetName;

            ReferenceCollector rc = self.View.EG_PetSkinIconRectTransform.GetComponent<ReferenceCollector>();
            PetSkinConfig skillConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, skillConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            rc.Get<GameObject>("Image_ItemIcon").GetComponent<Image>().sprite = sp;
            rc.Get<GameObject>("TextSkinName").GetComponent<Text>().text = skillConfig.Name;
            rc.Get<GameObject>("JiHuoSet").SetActive(true);

            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            self.View.E_Text_PetNameText.text = petSkinConfig.Name;

            self.View.E_BianYiDiButton.gameObject.SetActive(rolePetInfo.SkinId != petConfig.Skin[0]);
            self.View.E_LucklyButton.gameObject.SetActive(rolePetInfo.Luckly == 1);

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.RolePetInfo.PetSkill.Count);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.RolePetInfo.PetSkill.Count);
            self.UpdateAttribute(rolePetInfo, oldRolePetInfo);

            self.View.E_Text_FightValueText.text = rolePetInfo.PetPingFen.ToString();
        }

        private static void OnCommonSkillItemsRefresh(this DlgPetChouKaGet self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdatePetSkill(self.RolePetInfo.PetSkill[index], ABAtlasTypes.RoleSkillIcon);
            if (self.OldRolePetInfo != null)
            {
                if (self.OldRolePetInfo.PetSkill.Contains(self.RolePetInfo.PetSkill[index]) == false)
                {
                    scrollItemCommonSkillItem.E_NewSkillHintImage.gameObject.SetActive(true);
                }
            }
        }

        private static void UpdateAttribute(this DlgPetChouKaGet self, RolePetInfo rolePetInfo, RolePetInfo oldPetInfo = null)
        {
            // for (int i = 0; i < self.View.EG_ImageStarListRectTransform.transform.childCount; i++)
            // {
            //     if (rolePetInfo.Star > i)
            //     {
            //         self.StartShowImg(self.View.EG_ImageStarListRectTransform.transform.GetChild(i).gameObject);
            //     }
            // }

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);

            using (zstring.Block())
            {
                self.View.E_Text_PetLevelText.text = zstring.Format("{0}级", rolePetInfo.PetLv.ToString());
            }

            self.View.E_Text_QualityText.text = CommonViewHelper.GetPetQualityName(petConfig.PetQuality);
            self.View.E_Text_QualityText.color = CommonViewHelper.QualityReturnColor(petConfig.PetQuality);

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
                        zstring.Format("{0}/{1}", rolePetInfo.ZiZhi_ChengZhang, petConfig.ZiZhi_ChengZhang_Max.ToString());

                if (oldPetInfo != null)
                {
                    self.PetZiZhiItemList[0].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                            zstring.Format("(提升{0}点", rolePetInfo.ZiZhi_Hp - oldPetInfo.ZiZhi_Hp);
                    self.PetZiZhiItemList[1].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                            zstring.Format("(提升{0}点", rolePetInfo.ZiZhi_Act - oldPetInfo.ZiZhi_Act);
                    self.PetZiZhiItemList[2].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                            zstring.Format("(提升{0}点", rolePetInfo.ZiZhi_Def - oldPetInfo.ZiZhi_Def);
                    self.PetZiZhiItemList[3].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                            zstring.Format("(提升{0}点", rolePetInfo.ZiZhi_Adf - oldPetInfo.ZiZhi_Adf);
                    self.PetZiZhiItemList[4].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                            zstring.Format("(提升{0}点", rolePetInfo.ZiZhi_MageAct - oldPetInfo.ZiZhi_MageAct);
                    self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                            zstring.Format("(提升{0}点", rolePetInfo.ZiZhi_ChengZhang - oldPetInfo.ZiZhi_ChengZhang);
                }

                self.PetZiZhiItemList[0].transform.Find("ImageExpValue").localScale =
                        new Vector3(Mathf.Clamp(rolePetInfo.ZiZhi_Hp * 1f / petConfig.ZiZhi_Hp_Max, 0f, 1f), 1f, 1f);
                self.PetZiZhiItemList[1].transform.Find("ImageExpValue").localScale =
                        new Vector3(Mathf.Clamp(rolePetInfo.ZiZhi_Act * 1f / petConfig.ZiZhi_Act_Max, 0f, 1f), 1f, 1f);
                self.PetZiZhiItemList[2].transform.Find("ImageExpValue").localScale =
                        new Vector3(Mathf.Clamp(rolePetInfo.ZiZhi_Def * 1f / petConfig.ZiZhi_Def_Max, 0f, 1f), 1f, 1f);
                self.PetZiZhiItemList[3].transform.Find("ImageExpValue").localScale =
                        new Vector3(Mathf.Clamp(rolePetInfo.ZiZhi_Adf * 1f / petConfig.ZiZhi_Adf_Max, 0f, 1f), 1f, 1f);
                self.PetZiZhiItemList[4].transform.Find("ImageExpValue").localScale =
                        new Vector3(Mathf.Clamp(rolePetInfo.ZiZhi_MageAct * 1f / petConfig.ZiZhi_MageAct_Max, 0f, 1f), 1f, 1f);
                self.PetZiZhiItemList[5].transform.Find("ImageExpValue").localScale =
                        new Vector3(Mathf.Clamp(rolePetInfo.ZiZhi_ChengZhang * 1f / (float)petConfig.ZiZhi_ChengZhang_Max, 0f, 1f), 1f, 1f);
            }
        }

        private static void StartShowImg(this DlgPetChouKaGet self, GameObject startObj)
        {
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Start_2");
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            startObj.GetComponent<Image>().sprite = sp;
        }
        public static void OnBianYiDiButton(this DlgPetChouKaGet self)
        {
        }
        public static void OnLucklyButton(this DlgPetChouKaGet self)
        {
        }
    }
}
