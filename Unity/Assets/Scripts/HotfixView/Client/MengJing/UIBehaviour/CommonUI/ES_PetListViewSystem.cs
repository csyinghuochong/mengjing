using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PetListItem))]
    [FriendOf(typeof (PetComponentC))]
    [EntitySystemOf(typeof (ES_PetList))]
    [FriendOfAttribute(typeof (ES_PetList))]
    public static partial class ES_PetListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetList self, Transform transform)
        {
            self.uiTransform = transform;

            self.PetZiZhiItemList[0] = self.EG_PetZiZhiItem1RectTransform.gameObject;
            self.PetZiZhiItemList[1] = self.EG_PetZiZhiItem2RectTransform.gameObject;
            self.PetZiZhiItemList[2] = self.EG_PetZiZhiItem3RectTransform.gameObject;
            self.PetZiZhiItemList[3] = self.EG_PetZiZhiItem4RectTransform.gameObject;
            self.PetZiZhiItemList[4] = self.EG_PetZiZhiItem5RectTransform.gameObject;
            self.PetZiZhiItemList[5] = self.EG_PetZiZhiItem6RectTransform.gameObject;

            self.E_PetListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetListItemsRefresh);
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetList self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_PetList self)
        {
            self.PetSkinId = 0;
            self.LastSelectItem = null;

            self.RefreshCreateRoleItems();
        }

        private static void OnItemTypeSet(this ES_PetList self, int index)
        {
            UICommonHelper.SetToggleShow(self.E_ZiZhiToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.E_ProToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.E_VariantToggle.gameObject, index == 2);

            self.EG_PetZiZhiSetRectTransform.gameObject.SetActive(index == 0);
            self.E_PetProSetNodeImage.gameObject.SetActive(index == 1);
            self.EG_PetPiFuSetRectTransform.gameObject.SetActive(index == 2);

            self.EG_ButtonNodeRectTransform.gameObject.SetActive(index != 2);
        }

        private static void OnPetListItemsRefresh(this ES_PetList self, Transform transform, int index)
        {
            Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[index].BindTrans(transform);
            scrollItemPetListItem.SetClickHandler((long petId) => { self.OnClickPetHandler(petId); });

            scrollItemPetListItem.E_ImageDiButtonButton.gameObject.SetActive(false);
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.gameObject.SetActive(true);
            int i1 = index;
            scrollItemPetListItem.uiTransform.gameObject.name = $"UIPetListItem_{i1}";

            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.OnPointerDown(pdata as PointerEventData); });
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.OnPointerUp(pdata as PointerEventData, i1); });
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.BeginDrag,
                (pdata) => { self.OnBeginDrag(pdata as PointerEventData, i1); });
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.Drag,
                (pdata) => { self.OnDraging(pdata as PointerEventData); });
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.EndDrag,
                (pdata) => { self.OnEndDrag(pdata as PointerEventData, i1); });

            scrollItemPetListItem.OnInitData(self.ShowRolePetInfos[index], self.NextPetNumber());
        }

        private static void RefreshCreateRoleItems(this ES_PetList self)
        {
            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetInfos;
            self.ShowRolePetInfos.Clear();
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                if (rolePetInfos[i].PetStatus != 3)
                {
                    self.ShowRolePetInfos.Add(rolePetInfos[i]);
                }
            }

            int nextLv = self.NextPetNumber();
            if (nextLv > 0)
            {
                self.ShowRolePetInfos.Add(null);
            }

            self.AddUIScrollItems(ref self.ScrollItemPetListItems, self.ShowRolePetInfos.Count);
            self.E_PetListItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);

            if (self.ShowRolePetInfos.Count > 0)
            {
                self.EG_RightRectTransform.gameObject.SetActive(true);
                self.EG_GameObject2RectTransform.gameObject.SetActive(false);
                self.ScrollItemPetListItems[0].OnClickPetItem();
            }
            else
            {
                self.EG_RightRectTransform.gameObject.SetActive(false);
                self.EG_GameObject2RectTransform.gameObject.SetActive(true);
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int maxNum = PetHelper.GetPetMaxNumber(userInfo.Lv, unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber));
            self.E_Text_PetNumberText.text = $"{PetHelper.GetBagPetNum(rolePetInfos)}/{maxNum}";
        }

        private static int NextPetNumber(this ES_PetList self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int level = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            int curNumber = PetHelper.GetBagPetNum(self.Root().GetComponent<PetComponentC>().RolePetInfos);
            if (curNumber < PetHelper.GetPetMaxNumber(level, unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber)))
            {
                return 0;
            }

            string[] petInfos = GlobalValueConfigCategory.Instance.Get(34).Value.Split('@');
            for (int i = 0; i < petInfos.Length; i++)
            {
                string[] petNumber = petInfos[i].Split(';');
                if (level < int.Parse(petNumber[0]))
                {
                    return int.Parse(petNumber[0]);
                }
            }

            return 0;
        }

        private static void OnClickPetHandler(this ES_PetList self, long petId)
        {
            if (self.Root().GetComponent<PetComponentC>().GetPetInfoByID(petId) == null)
            {
                return;
            }

            self.PetSkinId = 0;
            self.LastSelectItem = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(petId);
            self.E_ZiZhiToggle.IsSelected(true);
            self.OnChangeNode(1);
            self.OnUpdatePetInfo(self.LastSelectItem);
            // self.UpdatePetModel(self.LastSelectItem);
            self.UpdatePetSelected(self.LastSelectItem);
            // self.UpdatePetHeXin(self.LastSelectItem);
            self.E_JiBanButton.gameObject.SetActive(PetHelper.IsShenShou(self.LastSelectItem.ConfigId));
        }

        /// <summary>
        ///  //1 属性 2 宠物之核 3 加点
        /// </summary>
        /// <param name="self"></param>
        /// <param name="nodetype"></param>
        private static void OnChangeNode(this ES_PetList self, int nodetype)
        {
            self.EG_ButtonNodeRectTransform.gameObject.SetActive(nodetype == 1);
            self.EG_AttributeNodeRectTransform.gameObject.SetActive(nodetype == 1);
            self.EG_PetHeXinSetRectTransform.gameObject.SetActive(nodetype == 2);
            self.EG_PetAddPointRectTransform.gameObject.SetActive(nodetype == 3);
        }

        private static void OnUpdatePetInfo(this ES_PetList self, RolePetInfo rolePetInfo)
        {
            self.E_InputFieldNameInputField.text = rolePetInfo.PetName;
            self.E_Btn_XiuXiButton.gameObject.SetActive(rolePetInfo.PetStatus == 1);
            self.E_Btn_ChuZhanButton.gameObject.SetActive(rolePetInfo.PetStatus == 0);

            self.UpdateAttribute(rolePetInfo);
            self.UpdateExpAndLv(rolePetInfo);
            self.UpdatePetZizhi(rolePetInfo);
            // self.UpdatePetSkin(rolePetInfo);
            // self.UpdateSkillList(rolePetInfo);

            self.E_Text_PetPingFenText.text = PetHelper.PetPingJia(rolePetInfo).ToString();

            self.E_Text_ShouHuText.text = ConfigData.PetShouHuAttri[rolePetInfo.ShouHuPos - 1].Value;
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"ShouHu_{rolePetInfo.ShouHuPos - 1}");
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageShouHuImage.sprite = sp;

            //更新宠物是否进化
            if (rolePetInfo.UpStageStatus == 0 || rolePetInfo.UpStageStatus == 1)
            {
                UICommonHelper.SetImageGray(self.Root(), self.E_ImageJinHuaImage.gameObject, true);
                if (rolePetInfo.UpStageStatus == 1)
                {
                    self.E_JinHuaReddotImage.gameObject.SetActive(true);
                    self.E_Lab_JinHuaText.text = "点击进化";
                }
                else
                {
                    self.E_JinHuaReddotImage.gameObject.SetActive(false);
                    self.E_Lab_JinHuaText.GetComponent<Text>().text = "未进化";
                }
            }
            else
            {
                UICommonHelper.SetImageGray(self.Root(), self.E_ImageJinHuaImage.gameObject, false);
                self.E_JinHuaReddotImage.gameObject.SetActive(false);
                self.E_Lab_JinHuaText.text = "已进化";
            }

            PetConfig petConfig = PetConfigCategory.Instance.Get(self.LastSelectItem.ConfigId);
            if (petConfig.PetType == 2)
            {
                UICommonHelper.SetImageGray(self.Root(), self.E_ImageJinHuaImage.gameObject, false);
                self.E_JinHuaReddotImage.gameObject.SetActive(false);
                self.E_Lab_JinHuaText.text = "已进化";
            }
        }

        private static void UpdateAttribute(this ES_PetList self, RolePetInfo rolePetInfo)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            long petAllAct = numericComponentC.GetAsLong(NumericType.Now_PetAllAct);
            long petAllMageact = numericComponentC.GetAsLong(NumericType.Now_PetAllMageAct);
            long petAllAdf = numericComponentC.GetAsLong(NumericType.Now_PetAllAdf);
            long petAllDef = numericComponentC.GetAsLong(NumericType.Now_PetAllDef);
            long petAllHp = numericComponentC.GetAsLong(NumericType.Now_PetAllHp);

            //self.GetAttributeShow(rolePetInfo, NumericType.Now_MaxAct, 0);

            petAllAct += (int)(NumericHelp.GetAttributeValue(rolePetInfo, NumericType.Now_MaxAct) *
                (1 + numericComponentC.GetAsFloat(NumericType.Now_PetAllActPro)));
            petAllMageact += (int)(NumericHelp.GetAttributeValue(rolePetInfo, NumericType.Now_Mage) *
                (1 + numericComponentC.GetAsFloat(NumericType.Now_PetAllMageActPro)));
            petAllDef += (int)(NumericHelp.GetAttributeValue(rolePetInfo, NumericType.Now_MaxDef) *
                (1 + numericComponentC.GetAsFloat(NumericType.Now_PetAllDefPro)));
            petAllAdf += (int)(NumericHelp.GetAttributeValue(rolePetInfo, NumericType.Now_MaxAdf) *
                (1 + numericComponentC.GetAsFloat(NumericType.Now_PetAllAdfPro)));

            float petAllCri = numericComponentC.GetAsFloat(NumericType.Now_PetAllCri);
            float petAllHit = numericComponentC.GetAsFloat(NumericType.Now_PetAllHit);
            float petAllDodge = numericComponentC.GetAsFloat(NumericType.Now_PetAllDodge);

            //基础属性
            self.UpdateAttributeItem(0, self.EG_PetProSetItem_1RectTransform.gameObject, self.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_MaxAct), self.GetAttributeShow(rolePetInfo, NumericType.Now_MaxAct, petAllAct));

            self.UpdateAttributeItem(1, self.EG_PetProSetItem_1RectTransform.gameObject, self.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_Mage), self.GetAttributeShow(rolePetInfo, NumericType.Now_Mage, petAllMageact));

            self.UpdateAttributeItem(2, self.EG_PetProSetItem_1RectTransform.gameObject, self.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_MaxDef), self.GetAttributeShow(rolePetInfo, NumericType.Now_MaxDef, petAllDef));

            self.UpdateAttributeItem(3, self.EG_PetProSetItem_1RectTransform.gameObject, self.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_MaxAdf), self.GetAttributeShow(rolePetInfo, NumericType.Now_MaxAdf, petAllAdf));

            self.UpdateAttributeItem(4, self.EG_PetProSetItem_1RectTransform.gameObject, self.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_MaxHp), self.GetAttributeShow(rolePetInfo, NumericType.Now_MaxHp, petAllHp));

            //特殊属性
            self.UpdateAttributeItem(0, self.EG_PetProSetItem_2RectTransform.gameObject, self.E_PetProSetNode_2Image.gameObject, "",
                self.GetAttributeShow(rolePetInfo, NumericType.Now_Cri, petAllCri));
            self.UpdateAttributeItem(1, self.EG_PetProSetItem_2RectTransform.gameObject, self.E_PetProSetNode_2Image.gameObject, "",
                self.GetAttributeShow(rolePetInfo, NumericType.Now_Res, 0));
            self.UpdateAttributeItem(2, self.EG_PetProSetItem_2RectTransform.gameObject, self.E_PetProSetNode_2Image.gameObject, "",
                self.GetAttributeShow(rolePetInfo, NumericType.Now_Hit, petAllHit));
            self.UpdateAttributeItem(3, self.EG_PetProSetItem_2RectTransform.gameObject, self.E_PetProSetNode_2Image.gameObject, "",
                self.GetAttributeShow(rolePetInfo, NumericType.Now_Dodge, petAllDodge));
        }

        private static void UpdateExpAndLv(this ES_PetList self, RolePetInfo rolePetInfo)
        {
            self.E_Text_PetLevelText.text = rolePetInfo.PetLv.ToString() + GameSettingLanguge.LoadLocalization("级");
            ExpConfig expConfig = ExpConfigCategory.Instance.Get(rolePetInfo.PetLv);
            self.E_Text_PetExpText.text = string.Format("{0}/{1}", rolePetInfo.PetExp, expConfig.PetUpExp);
            self.E_ImageExpValueImage.transform.localScale = new Vector3(Mathf.Clamp(rolePetInfo.PetExp * 1f / expConfig.PetUpExp, 0f, 1f), 1f, 1f);
        }

        private static void UpdatePetZizhi(this ES_PetList self, RolePetInfo rolePetInfo)
        {
            for (int i = 0; i < self.EG_ImagePetStarRectTransform.transform.childCount; i++)
            {
                self.EG_ImagePetStarRectTransform.transform.GetChild(i).gameObject.SetActive(rolePetInfo.Star > i);
            }

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);

            self.PetZiZhiItemList[0].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Hp}/{petConfig.ZiZhi_Hp_Max}";
            self.PetZiZhiItemList[1].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Act}/{petConfig.ZiZhi_Act_Max}";
            self.PetZiZhiItemList[2].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Def}/{petConfig.ZiZhi_Def_Max}";
            self.PetZiZhiItemList[3].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_Adf}/{petConfig.ZiZhi_Adf_Max}";
            self.PetZiZhiItemList[4].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text = string.Format("{0}/{1}",
                UICommonHelper.ShowFloatValue(rolePetInfo.ZiZhi_ChengZhang), UICommonHelper.ShowFloatValue((float)petConfig.ZiZhi_ChengZhang_Max));
            self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                    $"{rolePetInfo.ZiZhi_MageAct}/{petConfig.ZiZhi_MageAct_Max}";

            Sprite sprite16 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>("Assets/Bundles/Icon/OtherIcon/Pro_16.png");
            Sprite sprite17 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>("Assets/Bundles/Icon/OtherIcon/Pro_17.png");

            self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Hp >= petConfig.ZiZhi_Hp_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Hp / (float)petConfig.ZiZhi_Hp_Max, 0f, 1f);

            self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Act >= petConfig.ZiZhi_Act_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Act / (float)petConfig.ZiZhi_Act_Max, 0f, 1f);

            self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Def >= petConfig.ZiZhi_Def_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Def / (float)petConfig.ZiZhi_Def_Max, 0f, 1f);

            self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_Adf >= petConfig.ZiZhi_Adf_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_Adf / (float)petConfig.ZiZhi_Adf_Max, 0f, 1f);

            self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_ChengZhang >= petConfig.ZiZhi_ChengZhang_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_ChengZhang / (float)petConfig.ZiZhi_ChengZhang_Max, 0f, 1f);

            self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().sprite =
                    rolePetInfo.ZiZhi_MageAct >= petConfig.ZiZhi_MageAct_Max? sprite16 : sprite17;
            self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =
                    Mathf.Clamp((float)rolePetInfo.ZiZhi_MageAct / (float)petConfig.ZiZhi_MageAct_Max, 0f, 1f);
        }

        private static void UpdatePetSkin(this ES_PetList self, RolePetInfo rolePetInfo)
        {
            // if (self.LastSelectItem == null)
            // {
            //     return;
            // }
            //
            // self.PetSkinList.Clear();
            // UICommonHelper.DestoryChild(self.ScrollViewSkin);
            // PetConfig petConfig = PetConfigCategory.Instance.Get(self.LastSelectItem.ConfigId);
            //
            // int selectIndex = 0;
            // var path = ABPathHelper.GetUGUIPath("Main/Pet/UIPetSkinIcon");
            // var bundleGameObject = ResourcesComponent.Instance.LoadAsset<GameObject>(path);
            // PetComponent petComponent = self.ZoneScene().GetComponent<PetComponent>();
            // for (int i = 0; i < petConfig.Skin.Length; i++)
            // {
            //     if (petConfig.Skin[i] == 0)
            //     {
            //         continue;
            //     }
            //
            //     if (petConfig.Skin[i] == rolePetInfo.SkinId)
            //     {
            //         selectIndex = i;
            //     }
            //
            //     GameObject bagSpace = GameObject.Instantiate(bundleGameObject);
            //     UICommonHelper.SetParent(bagSpace, self.ScrollViewSkin);
            //     UIPetSkinIconComponent uIPetSkinIcon = self.AddChild<UIPetSkinIconComponent, GameObject>(bagSpace);
            //     uIPetSkinIcon.OnUpdateUI(petConfig.Skin[i], petConfig.Skin[i] == self.LastSelectItem.SkinId);
            //     uIPetSkinIcon.SetClickHandler(self.OnSelectSkinHandler);
            //     self.PetSkinList.Add(uIPetSkinIcon);
            // }
            //
            // self.PetSkinList[selectIndex].OnImage_ItemButton();
        }

        private static void UpdateSkillList(this ES_PetList self, RolePetInfo rolePetInfo)
        {
            // var path = ABPathHelper.GetUGUIPath("Main/Common/UICommonSkillItem");
            // var bundleGameObject = ResourcesComponent.Instance.LoadAsset<GameObject>(path);
            //
            // PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            // List<int> zhuanzhuids = new List<int>();
            // string[] zhuanzhuskills = petConfig.ZhuanZhuSkillID.Split(';');
            // for (int i = 0; i < zhuanzhuskills.Length; i++)
            // {
            //     if (zhuanzhuskills[i].Length > 1)
            //     {
            //         zhuanzhuids.Add(int.Parse(zhuanzhuskills[i]));
            //     }
            // }
            //
            // List<int> skills = new List<int>();
            // for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            // {
            //     if (zhuanzhuids.Contains(rolePetInfo.PetSkill[i]))
            //     {
            //         skills.Insert(0, rolePetInfo.PetSkill[i]);
            //     }
            //     else
            //     {
            //         skills.Add(rolePetInfo.PetSkill[i]);
            //     }
            // }
            //
            // int unactiveId = 0;
            // int unactiveNum = 0;
            // BagComponent bagComponent = self.ZoneScene().GetComponent<BagComponent>();
            // Dictionary<int, int> equipSkilllist = PetHelper.GetEquipSkillList(rolePetInfo, bagComponent);
            // foreach (var item in equipSkilllist)
            // {
            //     if (!rolePetInfo.PetSkill.Contains(item.Key))
            //     {
            //         unactiveId = item.Key;
            //         unactiveNum = item.Value;
            //         skills.Add(item.Key);
            //         break;
            //     }
            // }
            //
            // for (int i = 0; i < skills.Count; i++)
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
            //     }
            //
            //     bool unactive = skills[i] == unactiveId;
            //     ui_item.OnUpdatePetSkill(skills[i], ABAtlasTypes.PetSkillIcon, rolePetInfo.LockSkill.Contains(skills[i]), unactive, unactiveNum);
            //     UICommonHelper.SetImageGray(ui_item.ImageIcon, unactive);
            // }
            //
            // for (int i = skills.Count; i < self.PetSkillUIList.Count; i++)
            // {
            //     self.PetSkillUIList[i].GameObject.SetActive(false);
            // }
        }

        private static void UpdateAttributeItem(this ES_PetList self, int index, GameObject itemObj, GameObject parentObj, string iconid,
        string value)
        {
            GameObject gameObject = null;
            if (parentObj.transform.childCount > index)
            {
                gameObject = parentObj.transform.GetChild(index).gameObject;
            }
            else
            {
                gameObject = UnityEngine.Object.Instantiate(itemObj);
                UICommonHelper.SetParent(gameObject, parentObj);
                gameObject.SetActive(true);
            }

            gameObject.transform.Find("Text_Attribute1").GetComponent<Text>().text = value;
            if (iconid.Length > 0)
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PropertyIcon, iconid);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                gameObject.transform.Find("ImageIcon").GetComponent<Image>().sprite = sp;
            }
        }

        private static void UpdatePetSelected(this ES_PetList self, RolePetInfo rolePetItem)
        {
            for (int i = 0; i < self.ScrollItemPetListItems.Count; i++)
            {
                if (self.ScrollItemPetListItems[i].uiTransform != null)
                {
                    self.ScrollItemPetListItems[i].OnSelectUI(rolePetItem);
                }
            }

            self.OnUpdatePetPoint(rolePetItem);
        }

        private static void OnUpdatePetPoint(this ES_PetList self, RolePetInfo rolePetItem)
        {
            self.LastSelectItem = rolePetItem;
            self.E_ButtonAddPointButton.transform.Find("Reddot").gameObject.SetActive(rolePetItem != null && rolePetItem.AddPropretyNum > 0);
            for (int i = 0; i < self.ScrollItemPetListItems.Count; i++)
            {
                self.ScrollItemPetListItems[i].OnUpdatePetPoint(rolePetItem);
            }

            self.UpdateAttribute(self.LastSelectItem);
        }

        private static string GetAttributeShow(this ES_PetList self, RolePetInfo rolePetInfo, int numericType, float addValue)
        {
            NumericAttribute numericAttribute = ItemViewData.AttributeToName[numericType];
            if (NumericHelp.GetNumericValueType(numericType) == 2)
            {
                float fvalue = (NumericHelp.GetAttributeValue(rolePetInfo, numericType)) * 0.01f + addValue * 100;
                //string svalue = string.Format("{0:F}", fvalue);
                string svalue = fvalue.ToString("0.#####");
                return $"{ItemViewHelp.GetAttributeName(numericType)} {svalue}%";
            }
            else
            {
                return $"{ItemViewHelp.GetAttributeName(numericType)} {(long)(NumericHelp.GetAttributeValue(rolePetInfo, numericType) + addValue)}";
            }
        }

        private static void OnPointerDown(this ES_PetList self, PointerEventData pdata)
        {
            self.ClickTime = TimeHelper.ServerNow();
            self.IsChange = false;
        }

        private static void OnPointerUp(this ES_PetList self, PointerEventData pdata, int index1)
        {
            if (TimeHelper.ServerNow() - self.ClickTime <= 200)
            {
                self.OnClick(index1);
            }

            self.ClickTime = 0;
        }

        private static void OnBeginDrag(this ES_PetList self, PointerEventData pdata, int index1)
        {
            if (TimeHelper.ServerNow() - self.ClickTime <= 500)
            {
                self.IsChange = false;
                self.E_PetListItemsLoopVerticalScrollRect.OnBeginDrag(pdata);
            }
            else
            {
                self.IsChange = true;
                self.EG_MaskRectTransform.gameObject.SetActive(true);
                self.EG_MaskRectTransform.transform.Find("Img_PetIcon").GetComponent<Image>().sprite =
                        self.ScrollItemPetListItems[index1].E_Img_PetHeroIonImage.sprite;
                self.EG_MaskRectTransform.transform.SetParent(self.Root().GetComponent<GlobalComponent>().PopUpRoot);
                self.EG_MaskRectTransform.transform.localScale = Vector3.one;
            }
        }

        private static void OnDraging(this ES_PetList self, PointerEventData pdata)
        {
            if (self.IsChange)
            {
                if (self.EG_MaskRectTransform == null)
                {
                    return;
                }

                Vector2 localPoint = new Vector3();
                RectTransform canvas = self.EG_MaskRectTransform.transform.parent.GetComponent<RectTransform>();
                Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

                self.EG_MaskRectTransform.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
            }
            else
            {
                self.E_PetListItemsLoopVerticalScrollRect.OnDrag(pdata);
            }
        }

        private static void OnEndDrag(this ES_PetList self, PointerEventData pdata, int index1)
        {
            if (self.IsChange)
            {
                if (self.EG_MaskRectTransform == null)
                {
                    return;
                }

                RectTransform canvas = self.EG_MaskRectTransform.transform.parent.GetComponent<RectTransform>();
                GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
                List<RaycastResult> results = new List<RaycastResult>();
                gr.Raycast(pdata, results);

                for (int i = 0; i < results.Count; i++)
                {
                    string name = results[i].gameObject.name;
                    if (!name.Contains("ImageDiEventTrigger"))
                    {
                        continue;
                    }

                    name = results[i].gameObject.transform.parent.parent.name;

                    int index2 = int.Parse(name.Substring(14, name.Length - 14));

                    self.ChangePos(index1, index2);

                    break;
                }

                self.EG_MaskRectTransform.transform.SetParent(self.uiTransform);
                self.EG_MaskRectTransform.gameObject.SetActive(false);
            }
            else
            {
                self.E_PetListItemsLoopVerticalScrollRect.OnEndDrag(pdata);
            }
        }

        private static void OnClick(this ES_PetList self, int index)
        {
            self.ScrollItemPetListItems[index].OnClickPetItem();
        }

        private static void ChangePos(this ES_PetList self, int index1, int index2)
        {
            if (index1 == index2)
            {
                return;
            }

            long petId1 = self.ScrollItemPetListItems[index1].PetId;
            long petId2 = self.ScrollItemPetListItems[index2].PetId;

            if (petId1 == 0 || petId2 == 0)
            {
                return;
            }

            RolePetInfo rolePetInfo1 = null;
            RolePetInfo rolePetInfo2 = null;
            int petIndex1 = 0;
            int petIndex2 = 0;
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            for (int i = 0; i < petComponentC.RolePetInfos.Count; i++)
            {
                if (petComponentC.RolePetInfos[i].Id == petId1)
                {
                    rolePetInfo1 = petComponentC.RolePetInfos[i];
                    petIndex1 = i;
                }

                if (petComponentC.RolePetInfos[i].Id == petId2)
                {
                    rolePetInfo2 = petComponentC.RolePetInfos[i];
                    petIndex2 = i;
                }
            }

            if (rolePetInfo1 == null || rolePetInfo2 == null)
            {
                return;
            }

            petComponentC.RolePetInfos[petIndex1] = rolePetInfo2;
            petComponentC.RolePetInfos[petIndex2] = rolePetInfo1;

            PetNetHelper.RequestChangePos(self.Root(), petIndex1, petIndex2).Coroutine();

            self.OnUpdateUI();
        }
    }
}