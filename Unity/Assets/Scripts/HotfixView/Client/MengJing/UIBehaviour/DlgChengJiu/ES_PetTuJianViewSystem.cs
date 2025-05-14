using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(Scroll_Item_PetTuJianItem))]
    [EntitySystemOf(typeof(ES_PetTuJian))]
    [FriendOfAttribute(typeof(ES_PetTuJian))]
    public static partial class ES_PetTuJianSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetTuJian self, Transform transform)
        {
            self.uiTransform = transform;

            self.PetZiZhiItemList[0] = self.EG_PetZiZhiItem1RectTransform.gameObject;
            self.PetZiZhiItemList[1] = self.EG_PetZiZhiItem2RectTransform.gameObject;
            self.PetZiZhiItemList[2] = self.EG_PetZiZhiItem3RectTransform.gameObject;
            self.PetZiZhiItemList[3] = self.EG_PetZiZhiItem4RectTransform.gameObject;
            self.PetZiZhiItemList[4] = self.EG_PetZiZhiItem5RectTransform.gameObject;
            self.PetZiZhiItemList[5] = self.EG_PetZiZhiItem6RectTransform.gameObject;

            ReferenceCollector rc = transform.GetComponent<ReferenceCollector>();
            self.LeftContent = rc.Get<GameObject>("LeftContent");
            self.UIPetTuJianType = rc.Get<GameObject>("UIPetTuJianType");
            self.UIPetTuJianItemListNode = rc.Get<GameObject>("UIPetTuJianItemListNode");

            self.UIPetTuJianType.SetActive(false);
            self.UIPetTuJianItemListNode.SetActive(false);

            self.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
            // self.E_PetSinIconItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetSinIconItemsRefresh);

            self.InitPetTuJianList();
            
        }

        [EntitySystem]
        private static void Destroy(this ES_PetTuJian self)
        {
            self.DestroyWidget();
        }

        public static void InitPetTuJianList(this ES_PetTuJian self)
        {
            List<int> showType = new List<int>();
            showType.Add(0);
            showType.Add(1);

            foreach (int type in showType)
            {
                GameObject go1 = UnityEngine.Object.Instantiate(self.UIPetTuJianType, self.LeftContent.transform);
                GameObject go2 = UnityEngine.Object.Instantiate(self.UIPetTuJianItemListNode, self.LeftContent.transform);
                UIPetTuJianType uiChengJiuShowType = self.AddChild<UIPetTuJianType, GameObject, GameObject>(go1, go2);
                go1.SetActive(true);
                uiChengJiuShowType.Init(type, self.OnType, self.OnClickPetHandler);

                self.UIPetTuJianTypes.Add(uiChengJiuShowType);
            }

            foreach (UIPetTuJianType ui in self.UIPetTuJianTypes)
            {
                ui.OnImageButton();
            }
            
            UIPetTuJianType uiq = self.UIPetTuJianTypes[0];
            uiq.SelectFirst();
        }

        public static void OnType(this ES_PetTuJian self, int type)
        {
            foreach (UIPetTuJianType uiChengJiuShowType in self.UIPetTuJianTypes)
            {
                if (uiChengJiuShowType.ChengJiuType == type)
                {
                    uiChengJiuShowType.SetSelected(type);
                    break;
                }
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(self.LeftContent.GetComponent<RectTransform>());
        }

        public static void OnClickPetHandler(this ES_PetTuJian self, int petid)
        {
            foreach (UIPetTuJianType ui in self.UIPetTuJianTypes)
            {
                foreach (UIPetTuJianItem item in ui.UIPetTuJianItems)
                {
                    item.SetSelected(petid);
                }
            }
            
            self.UpdatePetZizhi(petid);
            self.UpdateSkillList(petid);
            // self.UpdatePetSkinList(petid);
            PetConfig petConfig = PetConfigCategory.Instance.Get(petid);
            
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
            
            self.ES_ModelShow.ShowOtherModel($"Pet/{petConfig.PetModel}", true).Coroutine();

            self.E_Text_PetNameText.text = petConfig.PetName;
        }

        public static void InitModelShowView_1(this ES_PetTuJian self)
        {
          
        }

        public static void OnUpdateUI(this ES_PetTuJian self)
        {
        }

        public static void UpdatePetZizhi(this ES_PetTuJian self, int petid)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(petid);

            if (petConfig.PetType == 0)
            {
                using (zstring.Block())
                {
                    self.PetZiZhiItemList[0].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_Hp_Max, 3000);
                    self.PetZiZhiItemList[1].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_Act_Max, 1500);
                    self.PetZiZhiItemList[2].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_Def_Max, 1500);
                    self.PetZiZhiItemList[3].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_Adf_Max, 1500);
                    self.PetZiZhiItemList[4].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_MageAct_Max, 1500);
                    self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", (float)petConfig.ZiZhi_ChengZhang_Max, 1.25f);
                }

                Sprite sprite17 = self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Sprite>("Assets/Bundles/Icon/OtherIcon/Pro_17.png");
                self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite17;
                self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_Hp_Max / 3000f, 0f, 1f);
                self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite17;
                self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_Act_Max / 1500f, 0f, 1f);
                self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite17;
                self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_Def_Max / 1500f, 0f, 1f);
                self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite17;
                self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_Adf_Max / 1500f, 0f, 1f);
                self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite17;
                self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_MageAct_Max / 1500f, 0f, 1f);
                self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite17;
                self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_ChengZhang_Max / 1.25f, 0f, 1f);
            }
            else
            {
                using (zstring.Block())
                {
                    self.PetZiZhiItemList[0].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_Hp_Max, petConfig.ZiZhi_Hp_Max);
                    self.PetZiZhiItemList[1].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_Act_Max, petConfig.ZiZhi_Act_Max);
                    self.PetZiZhiItemList[2].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_Def_Max, petConfig.ZiZhi_Def_Max);
                    self.PetZiZhiItemList[3].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_Adf_Max, petConfig.ZiZhi_Adf_Max);
                    self.PetZiZhiItemList[4].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", petConfig.ZiZhi_MageAct_Max, petConfig.ZiZhi_MageAct_Max);
                    self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                            zstring.Format("{0}/{1}", (float)petConfig.ZiZhi_ChengZhang_Max, (float)petConfig.ZiZhi_ChengZhang_Max);
                }

                Sprite sprite16 = self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Sprite>("Assets/Bundles/Icon/OtherIcon/Pro_16.png");
                self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite16;
                self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_Hp_Max / petConfig.ZiZhi_Hp_Max, 0f, 1f);
                self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite16;
                self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_Act_Max / petConfig.ZiZhi_Act_Max, 0f, 1f);
                self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite16;
                self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_Def_Max / petConfig.ZiZhi_Def_Max, 0f, 1f);
                self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite16;
                self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_Adf_Max / petConfig.ZiZhi_Adf_Max, 0f, 1f);
                self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite16;
                self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_MageAct_Max / petConfig.ZiZhi_MageAct_Max, 0f, 1f);
                self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().sprite = sprite16;
                self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                        Mathf.Clamp((float)petConfig.ZiZhi_ChengZhang_Max / (float)petConfig.ZiZhi_ChengZhang_Max, 0f, 1f);
            }
        }

        public static void UpdateSkillList(this ES_PetTuJian self, int petid)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(petid);
            List<int> skills = new List<int>();

            string[] baseskill = petConfig.BaseSkillID.Split(';');
            for (int i = 0; i < baseskill.Length; i++)
            {
                if (CommonHelp.IfNull(baseskill[i]))
                {
                    continue;
                }

                int baseskillid = int.Parse(baseskill[i]);
                if (!skills.Contains(baseskillid))
                {
                    skills.Add(baseskillid);
                }
            }

            string randomSkillID = petConfig.RandomSkillID;
            if (!CommonHelp.IfNull(randomSkillID))
            {
                string[] randomSkillList = randomSkillID.Split(';');
                for (int i = 0; i < randomSkillList.Length; i++)
                {
                    string[] skillInfo = randomSkillList[i].Split(',');

                    int zhuanzhuskill = int.Parse(skillInfo[0]);
                    if (!skills.Contains(zhuanzhuskill))
                    {
                        skills.Add(zhuanzhuskill);
                    }
                }
            }

            self.ShowSkill.Clear();
            self.ShowSkill.AddRange(skills);

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.ShowSkill.Count);
            self.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowSkill.Count);
        }

        private static void OnCommonSkillItemsRefresh(this ES_PetTuJian self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdateUI(self.ShowSkill[index], ABAtlasTypes.RoleSkillIcon);
        }

        // private static void OnPetSinIconItemsRefresh(this ES_PetTuJian self, Transform transform, int index)
        // {
        //     Scroll_Item_PetSkinIconItem scrollItemPetSkinIconItem = self.ScrollItemPetSkinIconItems[index].BindTrans(transform);
        //     scrollItemPetSkinIconItem.SetClickHandler(self.OnSelectSkinHandler);
        //     scrollItemPetSkinIconItem.OnUpdateUI(self.ShowSkin[index], index == 0);
        // }

        // public static void UpdatePetSkinList(this ES_PetTuJian self, int petid)
        // {
        //     PetConfig petConfig = PetConfigCategory.Instance.Get(petid);
        //
        //     self.ShowSkin.Clear();
        //     self.ShowSkin.AddRange(petConfig.Skin);
        //
        //     self.AddUIScrollItems(ref self.ScrollItemPetSkinIconItems, self.ShowSkin.Count);
        //     self.E_PetSinIconItemsLoopVerticalScrollRect.SetVisible(true, self.ShowSkin.Count);
        // }

        // public static void OnSelectSkinHandler(this ES_PetTuJian self, int skinId)
        // {
        // }
    }
}