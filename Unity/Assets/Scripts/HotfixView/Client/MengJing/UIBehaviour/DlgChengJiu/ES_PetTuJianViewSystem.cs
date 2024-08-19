using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PetTuJianItem))]
    [EntitySystemOf(typeof (ES_PetTuJian))]
    [FriendOfAttribute(typeof (ES_PetTuJian))]
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

            self.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
            self.E_PetSinIconItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetSinIconItemsRefresh);

            self.InitModelShowView_1();
            // self.E_Image_ItemButtonButton.AddListener(self.OnImage_ItemButtonButton);
            // self.E_Image_EventTriggerButton.AddListener(self.OnImage_EventTriggerButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetTuJian self)
        {
            self.DestroyWidget();
        }

        public static void InitModelShowView_1(this ES_PetTuJian self)
        {
            self.ES_ModelShow.SetPosition(new Vector3(0 * 1000, 0, 0), new Vector3(0f, 115, 257f));
        }

        public static void OnUpdateUI(this ES_PetTuJian self)
        {
            self.OnUpdatePetList();
        }

        public static void OnUpdatePetList(this ES_PetTuJian self)
        {
            List<PetConfig> petConfigs = PetConfigCategory.Instance.GetAll().Values.ToList();

            int commonPetNum = 0;
            int godPetNum = 0;
            for (int i = 0; i < petConfigs.Count; i++)
            {
                Scroll_Item_PetTuJianItem uIPetTuJianItem = null;
                if (i < self.uIPetTuJianItems.Count)
                {
                    uIPetTuJianItem = self.uIPetTuJianItems[i];
                    uIPetTuJianItem.uiTransform.gameObject.SetActive(true);
                }
                else
                {
                    GameObject go =
                            UnityEngine.Object.Instantiate(self.uiTransform.GetComponent<ReferenceCollector>().Get<GameObject>("UIPetTuJianItem"));
                    go.SetActive(true);
                    if (petConfigs[i].PetType == 0)
                    {
                        commonPetNum++;
                        int row = commonPetNum / 4;
                        row += commonPetNum % 4 > 0? 1 : 0;
                        self.EG_CommonPetListRectTransform.sizeDelta = new Vector2(713f, 150f + row * 160f);

                        CommonViewHelper.SetParent(go,
                            self.EG_CommonPetListRectTransform.GetComponent<ReferenceCollector>().Get<GameObject>("ItemNode"));
                    }
                    else
                    {
                        godPetNum++;
                        int row = godPetNum / 4;
                        row += godPetNum % 4 > 0? 1 : 0;
                        self.EG_GodPetListRectTransform.sizeDelta = new Vector2(713f, 150f + row * 160f);

                        CommonViewHelper.SetParent(go, self.EG_GodPetListRectTransform.GetComponent<ReferenceCollector>().Get<GameObject>("ItemNode"));
                    }

                    uIPetTuJianItem = self.AddChild<Scroll_Item_PetTuJianItem>();
                    uIPetTuJianItem.uiTransform = go.transform;
                    uIPetTuJianItem.OnInitUI(petConfigs[i].Id);
                    uIPetTuJianItem.SetClickHandler((int petId) => { self.OnClickPetHandler(petId); });
                    self.uIPetTuJianItems.Add(uIPetTuJianItem);
                }
            }

            for (int i = petConfigs.Count; i < self.uIPetTuJianItems.Count; i++)
            {
                Scroll_Item_PetTuJianItem item = self.uIPetTuJianItems[i];
                item.uiTransform.gameObject.SetActive(false);
            }

            Scroll_Item_PetTuJianItem scrollItemPetTuJianItem = self.uIPetTuJianItems[0];
            scrollItemPetTuJianItem.OnImage_ItemButton();
        }

        public static void OnClickPetHandler(this ES_PetTuJian self, int petid)
        {
            for (int i = 0; i < self.uIPetTuJianItems.Count; i++)
            {
                Scroll_Item_PetTuJianItem scrollItemPetTuJianItem = self.uIPetTuJianItems[i];
                scrollItemPetTuJianItem.SetSelected(petid);
            }

            self.UpdatePetZizhi(petid);
            self.UpdateSkillList(petid);
            self.UpdatePetSkinList(petid);

            PetConfig petConfig = PetConfigCategory.Instance.Get(petid);
            // self.ES_ModelShow.ShowOtherModel("Pet/" + petConfig.PetModel, true).Coroutine();
            // 测试
            self.ES_ModelShow.ShowOtherModel("Pet/1000101", true).Coroutine();

            self.E_Text_PetNameText.text = petConfig.PetName;
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
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdateUI(self.ShowSkill[index], ABAtlasTypes.PetSkillIcon);
        }

        private static void OnPetSinIconItemsRefresh(this ES_PetTuJian self, Transform transform, int index)
        {
            Scroll_Item_PetSkinIconItem scrollItemPetSkinIconItem = self.ScrollItemPetSkinIconItems[index].BindTrans(transform);
            scrollItemPetSkinIconItem.SetClickHandler(self.OnSelectSkinHandler);
            scrollItemPetSkinIconItem.OnUpdateUI(self.ShowSkin[index], index == 0);
        }

        public static void UpdatePetSkinList(this ES_PetTuJian self, int petid)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(petid);

            self.ShowSkin.Clear();
            self.ShowSkin.AddRange(petConfig.Skin);

            self.AddUIScrollItems(ref self.ScrollItemPetSkinIconItems, self.ShowSkin.Count);
            self.E_PetSinIconItemsLoopVerticalScrollRect.SetVisible(true, self.ShowSkin.Count);
        }

        public static void OnSelectSkinHandler(this ES_PetTuJian self, int skinId)
        {
        }
        public static void OnImage_ItemButtonButton(this ES_PetTuJian self)
        {
        }
        public static void OnImage_EventTriggerButton(this ES_PetTuJian self)
        {
        }
    }
}
