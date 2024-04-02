using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetChouKaGet))]
    public static class DlgPetChouKaGetSystem
    {
        public static void RegisterUIEvent(this DlgPetChouKaGet self)
        {
        }

        public static void ShowWindow(this DlgPetChouKaGet self, Entity contextData = null)
        {
        }

        public static void InitModelShowView(this DlgPetChouKaGet self, RolePetInfo rolePetInfo)
        {
            self.View.ES_ModelShow.SetPosition(Vector3.zero, new Vector3(0f, 115, 257f));

            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            self.View.ES_ModelShow.ShowOtherModel("Pet/" + petSkinConfig.SkinID).Coroutine();
        }

        private static void OnBtn_Close(this DlgPetChouKaGet self)
        {
            // self.Root().GetComponent<BattleMessageComponent>().ShowPetChouKaGet = false;
            // self.Root().GetComponent<BattleMessageComponent>().ShowRolePetAdd();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetChouKaGet);
        }

        private static void OnInitUI(this DlgPetChouKaGet self, RolePetInfo rolePetInfo, List<KeyValuePair> oldSkins,
        RolePetInfo oldRolePetInfo = null)
        {
            try
            {
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

                self.View.E_Text_TipText.text = $"{petConfig.PetName}";
                // self.PetSkinIconComponent.OnUpdateUI(rolePetInfo.SkinId, true);

                PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
                self.View.E_Text_PetNameText.text = petSkinConfig.Name;

                self.View.E_BianYiDiButton.gameObject.SetActive(rolePetInfo.SkinId != petConfig.Skin[0]);
                self.View.E_LucklyButton.gameObject.SetActive(rolePetInfo.Luckly == 1);

                self.UpdateSkillList(rolePetInfo, oldRolePetInfo);
                self.UpdateAttribute(rolePetInfo, oldRolePetInfo);

                self.View.E_Text_FightValueText.text = PetHelper.PetPingJia(rolePetInfo).ToString();
            }
            catch (Exception ex)
            {
                Log.Error("PetChouKaError: " + ex.ToString());
            }
        }

        public static void UpdateSkillList(this DlgPetChouKaGet self, RolePetInfo rolePetInfo, RolePetInfo oldPetInfo = null)
        {
            // var path = ABPathHelper.GetUGUIPath("Main/Common/UICommonSkillItem");
            // var bundleGameObject = ResourcesComponent.Instance.LoadAsset<GameObject>(path);
            //
            // for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            // {
            //     UICommonSkillItemComponent ui_item = null;
            //     if (i < self.PetSkillUIList.Count)
            //     {
            //         ui_item = self.PetSkillUIList[i];
            //         ui_item.GameObject.SetActive(true);
            //     }
            //     else
            //     {
            //         GameObject bagSpace = GameObject.Instantiate(bundleGameObject);
            //         UICommonHelper.SetParent(bagSpace, self.PetSkillNode);
            //         ui_item = self.AddChild<UICommonSkillItemComponent, GameObject>(bagSpace);
            //         self.PetSkillUIList.Add(ui_item);
            //
            //         if (oldPetInfo != null)
            //         {
            //             if (oldPetInfo.PetSkill.Contains(rolePetInfo.PetSkill[i]) == false)
            //             {
            //                 ui_item.NewSkillHint.SetActive(true);
            //             }
            //         }
            //     }
            //
            //     ui_item.OnUpdateUI(rolePetInfo.PetSkill[i], ABAtlasTypes.PetSkillIcon);
            // }
            //
            // for (int i = rolePetInfo.PetSkill.Count; i < self.PetSkillUIList.Count; i++)
            // {
            //     self.PetSkillUIList[i].GameObject.SetActive(false);
            // }
        }

        public static void UpdateAttribute(this DlgPetChouKaGet self, RolePetInfo rolePetInfo, RolePetInfo oldPetInfo = null)
        {
            for (int i = 0; i < self.View.EG_ImageStarListRectTransform.transform.childCount; i++)
            {
                //self.ImageStarList.transform.GetChild(i).gameObject.SetActive(rolePetInfo.Star > i);
                if (rolePetInfo.Star > i)
                {
                    self.StartShowImg(self.View.EG_ImageStarListRectTransform.transform.GetChild(i).gameObject);
                }
            }

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);

            self.View.E_Text_PetLevelText.text = rolePetInfo.PetLv.ToString() + "级";

            self.View.E_Text_QualityText.text = UICommonHelper.GetPetQualityName(petConfig.PetQuality);
            self.View.E_Text_QualityText.color = UICommonHelper.QualityReturnColor(petConfig.PetQuality);

            self.PetZiZhiItemList[0].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Hp}/{petConfig.ZiZhi_Hp_Max}";
            self.PetZiZhiItemList[1].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Act}/{petConfig.ZiZhi_Act_Max}";
            self.PetZiZhiItemList[2].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Def}/{petConfig.ZiZhi_Def_Max}";
            self.PetZiZhiItemList[3].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Adf}/{petConfig.ZiZhi_Adf_Max}";
            self.PetZiZhiItemList[4].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_MageAct}/{petConfig.ZiZhi_MageAct_Max}";
            self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_ChengZhang}/{petConfig.ZiZhi_ChengZhang_Max}";

            if (oldPetInfo != null)
            {
                self.PetZiZhiItemList[0].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                        string.Format("(提升" + (rolePetInfo.ZiZhi_Hp - oldPetInfo.ZiZhi_Hp) + "点)");
                self.PetZiZhiItemList[1].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                        string.Format("(提升" + (rolePetInfo.ZiZhi_Act - oldPetInfo.ZiZhi_Act) + "点)");
                self.PetZiZhiItemList[2].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                        string.Format("(提升" + (rolePetInfo.ZiZhi_Def - oldPetInfo.ZiZhi_Def) + "点)");
                self.PetZiZhiItemList[3].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                        string.Format("(提升" + (rolePetInfo.ZiZhi_Adf - oldPetInfo.ZiZhi_Adf) + "点)");
                self.PetZiZhiItemList[4].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                        string.Format("(提升" + (rolePetInfo.ZiZhi_MageAct - oldPetInfo.ZiZhi_MageAct) + "点)");
                self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiAddValue").GetComponent<Text>().text =
                        string.Format("(提升" + (rolePetInfo.ZiZhi_ChengZhang - oldPetInfo.ZiZhi_ChengZhang) + "点)");
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

        public static void StartShowImg(this DlgPetChouKaGet self, GameObject startObj)
        {
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Start_2");
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            startObj.GetComponent<Image>().sprite = sp;
        }
    }
}