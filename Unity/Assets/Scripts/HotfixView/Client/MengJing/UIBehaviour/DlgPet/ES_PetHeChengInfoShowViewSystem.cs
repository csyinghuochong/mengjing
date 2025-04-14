using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(DlgPet))]
    [FriendOf(typeof(ES_PetHeChengInfoShow))]
    [EntitySystemOf(typeof(ES_PetHeChengInfoShow))]
    public static partial class ES_PetHeChengInfoShowViewSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetHeChengInfoShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.PetZiZhiItemList[0] = self.EG_PetZiZhiItem1RectTransform.gameObject;
            self.PetZiZhiItemList[1] = self.EG_PetZiZhiItem2RectTransform.gameObject;
            self.PetZiZhiItemList[2] = self.EG_PetZiZhiItem3RectTransform.gameObject;
            self.PetZiZhiItemList[3] = self.EG_PetZiZhiItem4RectTransform.gameObject;
            self.PetZiZhiItemList[4] = self.EG_PetZiZhiItem5RectTransform.gameObject;
            self.PetZiZhiItemList[5] = self.EG_PetZiZhiItem6RectTransform.gameObject;

            self.E_AddButton.AddListenerAsync(self.OnImg_PeteroQualityButton);
            self.E_TipButton.AddListenerAsync(self.OnImg_PeteroQualityButton);
            self.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetHeChengInfoShow self)
        {
            self.DestroyWidget();
        }

        private static async ETTask OnImg_PeteroQualityButton(this ES_PetHeChengInfoShow self)
        {
            DlgPet dlgPet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>();
            dlgPet.PetItemWeizhi = self.Weizhi;

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetSelect);
            DlgPetSelect dlgPetSelect = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetSelect>();
            dlgPetSelect.OnSetType(self.BagOperationType);
        }

        private static void OnCommonSkillItemsRefresh(this ES_PetHeChengInfoShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdatePetSkill(self.ShowPetSkills[index], ABAtlasTypes.RoleSkillIcon,
                self.RolePetInfo.LockSkill.Contains(self.ShowPetSkills[index]));
        }

        private static void UpdateSkillList(this ES_PetHeChengInfoShow self, RolePetInfo rolePetInfo)
        {
            self.RolePetInfo = rolePetInfo;
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

            self.ShowPetSkills.Clear();
            for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            {
                if (zhuanzhuids.Contains(rolePetInfo.PetSkill[i]))
                {
                    self.ShowPetSkills.Insert(0, rolePetInfo.PetSkill[i]);
                }
                else
                {
                    self.ShowPetSkills.Add(rolePetInfo.PetSkill[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.ShowPetSkills.Count);
            self.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetSkills.Count);
        }

        private static void UpdateAttribute(this ES_PetHeChengInfoShow self, RolePetInfo rolePetInfo)
        {
            self.E_Text_PetNameText.text = rolePetInfo.PetName;
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            
            //self.ES_ModelShow.SetPosition(new Vector3(1 * 1000, 0, 0), new Vector3(0f, 115, 257f));
            string[] strs = null;
            if (!CommonHelp.IfNull(petConfig.ModelShowPosi))
            {
                strs = petConfig.ModelShowPosi.Split(',');
            }
            if (strs != null && strs.Length >= 5)
            {
                self.ES_ModelShow.Camera.fieldOfView = float.Parse(strs[3]);
                self.ES_ModelShow.SetCameraPosition(new Vector3(float.Parse(strs[0]), float.Parse(strs[1]), float.Parse(strs[2])));
                self.ES_ModelShow.RotationY = float.Parse(strs[4]); 
            }
            else
            {
                self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 115, 257f));
            }
            
            using (zstring.Block())
            {
                self.ES_ModelShow.ShowOtherModel(zstring.Format("Pet/{0}", petSkinConfig.SkinID.ToString()), true).Coroutine();
            }
            
            self.E_Text_PetPingFen.text = rolePetInfo.PetPingFen.ToString();

            self.E_Text_PetLevelText.text = rolePetInfo.PetLv + LanguageComponent.Instance.LoadLocalization("级");
            ExpConfig expConfig = ExpConfigCategory.Instance.Get(rolePetInfo.PetLv);

            string expStr = rolePetInfo.PetExp.ToString();
            string upExpStr = expConfig.UpExp.ToString();

            using (zstring.Block())
            {
                if (rolePetInfo.PetExp >= 10000)
                {
                    expStr = (zstring)(int)(rolePetInfo.PetExp / 10000) + LanguageComponent.Instance.LoadLocalization("万");
                }

                if (expConfig.UpExp >= 10000)
                {
                    upExpStr = (zstring)(int)(expConfig.UpExp / 10000) + LanguageComponent.Instance.LoadLocalization("万");
                }

                self.E_Text_PetExpText.text = zstring.Format("{0}/{1}", expStr, upExpStr);
                self.E_ImageExpValueImage.transform.localScale = new Vector3(Mathf.Clamp(rolePetInfo.PetExp * 1f / expConfig.UpExp, 0f, 1f), 1f, 1f);

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
                        zstring.Format("{0}/{1}",
                            CommonViewHelper.ShowFloatValue(rolePetInfo.ZiZhi_ChengZhang),
                            CommonViewHelper.ShowFloatValue((float)petConfig.ZiZhi_ChengZhang_Max));
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

        private static void CheckNoPet(this ES_PetHeChengInfoShow self, bool havepet)
        {
            self.E_Text_PetNameText.gameObject.SetActive(havepet);
            self.E_TipImage.gameObject.SetActive(!havepet);
            self.ES_ModelShow.SetShow(havepet);
            self.E_Text_PetLevelText.gameObject.SetActive(havepet);
            self.E_Text_PetExpText.gameObject.SetActive(havepet);
            self.E_ImageExpDiImage.gameObject.SetActive(havepet);
            self.E_ImageExpValueImage.gameObject.SetActive(havepet);
            if (self.E_Text_PetPingFen != null)
            {
                self.E_Text_PetPingFen.gameObject.SetActive(havepet);
            }

            for (int i = 0; i < self.PetZiZhiItemList.Length; i++)
            {
                self.PetZiZhiItemList[i].SetActive(havepet);
            }

            self.ShowPetSkills.Clear();
            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.ShowPetSkills.Count);
            self.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetSkills.Count);
        }

        public static void OnInitData(this ES_PetHeChengInfoShow self, RolePetInfo rolePetInfo)
        {
            self.CheckNoPet(rolePetInfo != null);
            if (rolePetInfo == null)
            {
                self.E_Text_PetNameText.text = "未选择宠物";
                return;
            }

            self.UpdateSkillList(rolePetInfo);
            self.UpdateAttribute(rolePetInfo);
        }
    }
}