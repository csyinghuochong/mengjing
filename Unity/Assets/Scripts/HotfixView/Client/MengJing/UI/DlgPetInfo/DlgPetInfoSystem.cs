using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(Scroll_Item_PetSkinIconItem))]
    [FriendOf(typeof(DlgPetInfo))]
    public static class DlgPetInfoSystem
    {
        public static void RegisterUIEvent(this DlgPetInfo self)
        {
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);

            self.PetZiZhiItemList[0] = self.View.EG_PetZiZhiItem1RectTransform.gameObject;
            self.PetZiZhiItemList[1] = self.View.EG_PetZiZhiItem2RectTransform.gameObject;
            self.PetZiZhiItemList[2] = self.View.EG_PetZiZhiItem3RectTransform.gameObject;
            self.PetZiZhiItemList[3] = self.View.EG_PetZiZhiItem4RectTransform.gameObject;
            self.PetZiZhiItemList[4] = self.View.EG_PetZiZhiItem5RectTransform.gameObject;
            self.PetZiZhiItemList[5] = self.View.EG_PetZiZhiItem6RectTransform.gameObject;

            self.View.E_PetHeXinItem0Image.transform.Find("Node_1/ButtonAdd").GetComponent<Button>().AddListener(() =>
            {
                self.OnChangeNode(2);
                self.OnButtonPetHeXinItem(0);
            });
            self.View.E_PetHeXinItem1Image.transform.Find("Node_1/ButtonAdd").GetComponent<Button>().AddListener(() =>
            {
                self.OnChangeNode(2);
                self.OnButtonPetHeXinItem(1);
            });
            self.View.E_PetHeXinItem2Image.transform.Find("Node_1/ButtonAdd").GetComponent<Button>().AddListener(() =>
            {
                self.OnChangeNode(2);
                self.OnButtonPetHeXinItem(2);
            });

            self.View.E_PetHeXinItem0Image.transform.Find("ImageSelect").gameObject.SetActive(false);
            self.View.E_PetHeXinItem1Image.transform.Find("ImageSelect").gameObject.SetActive(false);
            self.View.E_PetHeXinItem2Image.transform.Find("ImageSelect").gameObject.SetActive(false);
            self.PetHeXinItemList = new GameObject[3];
            self.PetHeXinItemList[0] = self.View.E_PetHeXinItem0Image.gameObject;
            self.PetHeXinItemList[1] = self.View.E_PetHeXinItem1Image.gameObject;
            self.PetHeXinItemList[2] = self.View.E_PetHeXinItem2Image.gameObject;

            self.View.E_PetSkinIconItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetSkinIconItemsRefresh);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
            self.View.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);

            self.View.E_PetSkinRawImageButton.AddListener(self.OnPetSkinRawImageButton);
            self.View.E_ButtonUseSkinButton.AddListener(self.OnButtonUseSkinButton);
            self.View.E_ButtonEquipXieXiaButton.AddListener(self.OnButtonEquipXieXiaButton);
            self.View.E_ImageJinHuaButton.AddListener(self.OnImageJinHuaButton);
            self.View.E_JiBanButton.AddListener(self.OnJiBanButton);
            self.View.E_ButtonCloseHexinButton.AddListener(() => { self.OnChangeNode(1); });

            self.View.EG_EquipSetRectTransform.gameObject.SetActive(false);
            self.View.E_ButtonRNameButton.gameObject.SetActive(false);
            self.View.E_Btn_FangShengButton.gameObject.SetActive(false);
            self.View.E_ButtonUseSkinButton.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgPetInfo self, Entity contextData = null)
        {
        }

        public static void OnButtonCloseButton(this DlgPetInfo self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetInfo);
        }

        public static void OnUpdateUI(this DlgPetInfo self, RolePetInfo rolePetInfo, List<ItemInfoProto> bagInfos, List<int> keys, List<long> values)
        {
            self.PetSkinId = 0;
            self.PetHeXinList = bagInfos;
            self.LastSelectItem = rolePetInfo;
            self.Keys = keys;
            self.Values = values;

            self.OnClickPetHandler();
        }

        private static void OnItemTypeSet(this DlgPetInfo self, int index)
        {
            self.View.EG_PetZiZhiSetRectTransform.gameObject.SetActive(index == 0);
            self.View.E_PetProSetNodeImage.gameObject.SetActive(index == 1);
            self.View.EG_PetPiFuSetRectTransform.gameObject.SetActive(index == 2);

            self.View.EG_ButtonNodeRectTransform.gameObject.SetActive(index != 2);
        }

        public static async ETTask OnPetHeXinSuitButton(this DlgPetInfo self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetHeXinSuit);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetHeXinSuit>().UpdateInfo(self.PetHeXinSuit);
        }

        private static void OnPetSkinIconItemsRefresh(this DlgPetInfo self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetSkinIconItem item in self.ScrollItemPetSkinIconItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetSkinIconItem scrollItemPetSkinIconItem = self.ScrollItemPetSkinIconItems[index].BindTrans(transform);
            scrollItemPetSkinIconItem.OnUpdateUI(self.ShowPetSkins[index], self.ShowPetSkins[index] == self.LastSelectItem.SkinId);
            scrollItemPetSkinIconItem.SetClickHandler(self.OnSelectSkinHandler);
        }

        private static void OnCommonSkillItemsRefresh(this DlgPetInfo self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            bool unactive = self.ShowPetSkills[index] == self.UnactiveId;
            scrollItemCommonSkillItem.OnUpdatePetSkill(self.ShowPetSkills[index], ABAtlasTypes.RoleSkillIcon,
                self.LastSelectItem.LockSkill.Contains(self.ShowPetSkills[index]), unactive, self.UnactiveNum);
            CommonViewHelper.SetImageGray(self.Root(), scrollItemCommonSkillItem.E_ImageIconImage.gameObject, unactive);
        }

        private static void OnSelectSkinHandler(this DlgPetInfo self, int skinId)
        {
            self.PetSkinId = skinId;
            for (int i = 0; i < self.ScrollItemPetSkinIconItems.Count; i++)
            {
                Scroll_Item_PetSkinIconItem scrollItemPetSkinIconItem = self.ScrollItemPetSkinIconItems[i];
                if (scrollItemPetSkinIconItem.uiTransform != null)
                {
                    scrollItemPetSkinIconItem.OnSelected(skinId);
                }
            }

            PetSkinConfig petConfig = PetSkinConfigCategory.Instance.Get(skinId);

            self.View.ES_ModelShow.SetCameraPosition(new Vector3(0f, 115, 257f));
            using (zstring.Block())
            {
                self.View.ES_ModelShow.ShowOtherModel(zstring.Format("Pet/{0}", petConfig.SkinID.ToString()), true).Coroutine();
            }

            self.View.E_SkinJiHuoImage.gameObject.SetActive(self.LastSelectItem.SkinId == self.PetSkinId);
            self.View.E_SkinWeiJiHuoImage.gameObject.SetActive(!self.View.E_SkinJiHuoImage.gameObject.activeSelf);

            //显示激活属性
            if (petConfig.PripertyShow != "" && petConfig.PripertyShow != "0")
            {
                self.View.E_PropertyShowTextText.gameObject.SetActive(true);
                using (zstring.Block())
                {
                    self.View.E_PropertyShowTextText.text =
                            zstring.Format("{0}:{1}", LanguageComponent.Instance.LoadLocalization("激活属性"), petConfig.PripertyShow);
                }
            }
            else
            {
                self.View.E_PropertyShowTextText.gameObject.SetActive(false);
            }
        }

        private static void OnClickPetHandler(this DlgPetInfo self)
        {
            self.PetSkinId = 0;
            self.View.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
            self.OnChangeNode(1);
            self.OnUpdatePetInfo(self.LastSelectItem);
            self.UpdatePetHeXin(self.LastSelectItem);
        }

        public static void UpdatePetHeXin(this DlgPetInfo self, RolePetInfo rolePetItem)
        {
            for (int i = 0; i < self.PetHeXinItemList.Length; i++)
            {
                self.PetHeXinItemList[i].transform.Find("Node_2").gameObject.SetActive(false);
            }

            List<int> petheXinLv = new List<int>();
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            for (int i = 0; i < rolePetItem.PetHeXinList.Count; i++)
            {
                if (rolePetItem.PetHeXinList[i] == 0)
                {
                    continue;
                }

                ItemInfo bagInfo = bagComponent.GetBagInfo(rolePetItem.PetHeXinList[i]);
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                Transform itemTransform = self.PetHeXinItemList[i].transform;
                itemTransform.Find("Node_2").gameObject.SetActive(true);
                itemTransform.Find("Node_2/TextName").gameObject.GetComponent<Text>().text = itemConfig.ItemName;
                using (zstring.Block())
                {
                    itemTransform.Find("Node_2/TextIcon").gameObject.GetComponent<Text>().text = zstring.Format("等级 {0}", itemConfig.UseLv);
                }

                Image ImageIcon = itemTransform.Find("Node_2/ImageIcon").gameObject.GetComponent<Image>();
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                ImageIcon.sprite = sp;

                petheXinLv.Add(itemConfig.UseLv);
            }

            self.View.E_PetHeXinSuitButton.gameObject.SetActive(true);
            int lv5number = 0;
            int lv8number = 0;
            int lv10number = 0;
            Material mat = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
            for (int i = 0; i < petheXinLv.Count; i++)
            {
                if (petheXinLv[i] >= 5)
                {
                    lv5number++;
                }

                if (petheXinLv[i] >= 8)
                {
                    lv8number++;
                }

                if (petheXinLv[i] >= 10)
                {
                    lv10number++;
                }
            }

            int index = 0;
            if (lv10number >= 3)
            {
                self.View.E_PetHeXinSuitButton.GetComponentInChildren<Text>().text = "高级核心";
                self.View.E_PetHeXinSuitButton.GetComponent<Image>().material = null;
                index = 3;
                self.PetHeXinSuit = 10;
            }
            else if (lv8number >= 3)
            {
                self.View.E_PetHeXinSuitButton.GetComponentInChildren<Text>().text = "中级核心";
                self.View.E_PetHeXinSuitButton.GetComponent<Image>().material = null;
                index = 2;
                self.PetHeXinSuit = 8;
            }
            else if (lv5number >= 3)
            {
                self.View.E_PetHeXinSuitButton.GetComponentInChildren<Text>().text = "初级核心";
                self.View.E_PetHeXinSuitButton.GetComponent<Image>().material = null;
                index = 1;
                self.PetHeXinSuit = 5;
            }
            else
            {
                self.View.E_PetHeXinSuitButton.GetComponentInChildren<Text>().text = "初级核心";
                self.View.E_PetHeXinSuitButton.GetComponent<Image>().material = mat;
                index = 1;
                self.PetHeXinSuit = 0;
            }

            // 更换图标
            using (zstring.Block())
            {
                string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, (zstring)"hexin" + index);
                Sprite sp1 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);
                self.View.E_PetHeXinSuitButton.GetComponent<Image>().sprite = sp1;
            }
        }

        /// <summary>
        ///  //1 属性 2 宠物之核 3 加点
        /// </summary>
        /// <param name="self"></param>
        /// <param name="nodetype"></param>
        private static void OnChangeNode(this DlgPetInfo self, int nodetype)
        {
            self.View.EG_ButtonNodeRectTransform.gameObject.SetActive(nodetype == 1);
            self.View.EG_AttributeNodeRectTransform.gameObject.SetActive(nodetype == 1);
            self.View.EG_PetHeXinSetRectTransform.gameObject.SetActive(nodetype == 2);
            self.View.EG_PetAddPointRectTransform.gameObject.SetActive(nodetype == 3);
        }

        public static void OnButtonPetHeXinItem(this DlgPetInfo self, int position)
        {
            for (int i = 0; i < self.PetHeXinItemList.Length; i++)
            {
                self.PetHeXinItemList[i].transform.Find("ImageSelect").gameObject.SetActive(i == position);
            }

            self.Position = position;
            self.UpdatePetHexinItem(self.PetHeXinList);
        }

        private static void UpdatePetHexinItem(this DlgPetInfo self, List<ItemInfoProto> bagInfos)
        {
            self.View.E_ButtonHeXinHeChengButton.gameObject.SetActive(false);
            // self.View.E_ButtonEquipXieXiaButton.AddListenerAsync(self.OnButtonEquipXieXia);
            List<string> TypeNames = new List<string>() { "进攻能量", "守护能量", "生命能量" };
            self.View.E_TextTypeText.text = TypeNames[self.Position];

            CommonViewHelper.DestoryChild(self.View.EG_AttributeListNodeRectTransform.gameObject);
            long baginfoId = self.LastSelectItem.PetHeXinList[self.Position];
            ItemInfoProto bagInfo = null;
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].BagInfoID == baginfoId)
                {
                    bagInfo = bagInfos[i];
                }
            }

            self.View.E_ImageIconImage.gameObject.SetActive(bagInfo != null);
            self.View.E_ButtonEquipXieXiaButton.gameObject.SetActive(false);
            if (bagInfo == null)
            {
                self.View.E_TextNameText.text = "空";
                self.View.E_TextLevelText.text = "等级: 0";
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.View.E_TextNameText.text = itemConfig.ItemName;
            using (zstring.Block())
            {
                self.View.E_TextLevelText.text = zstring.Format("等级: {0}", itemConfig.UseLv);
            }

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_ImageIconImage.sprite = sp;

            self.ShowAttributeItemList(itemConfig.ItemUsePar, self.View.EG_AttributeListNodeRectTransform.gameObject,
                self.View.EG_TextAttributeItemRectTransform.gameObject);
        }

        private static void ShowAttributeItemList(this DlgPetInfo self, string itemList, GameObject itemNodeList, GameObject attributeItem)
        {
            string[] attributeinfos = itemList.Split('@');
            for (int i = 0; i < attributeinfos.Length; i++)
            {
                if (string.IsNullOrEmpty(attributeinfos[i]))
                {
                    continue;
                }

                string[] attributeInfo = attributeinfos[i].Split(';');
                int numberType = int.Parse(attributeInfo[0]);
                float numberValue = float.Parse(attributeInfo[1]);
                GameObject gameObject = GameObject.Instantiate(attributeItem);
                gameObject.SetActive(true);
                CommonViewHelper.SetParent(gameObject, itemNodeList);
                string icon = ItemViewHelp.GetAttributeIcon(numberType);

                icon = "PetPro_2";

                if (!string.IsNullOrEmpty(icon))
                {
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PropertyIcon, icon);
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                    gameObject.transform.Find("Img_Icon").GetComponent<Image>().sprite = sp;
                }

                int showType = NumericHelp.GetNumericValueType(numberType);
                string attribute;
                if (showType == 2)
                {
                    using (zstring.Block())
                    {
                        attribute = zstring.Format("{0}+{1}%", ItemViewHelp.GetAttributeName(numberType), numberValue * 100);
                    }
                }
                else
                {
                    using (zstring.Block())
                    {
                        attribute = zstring.Format("{0}+{1}", ItemViewHelp.GetAttributeName(numberType), numberValue);
                    }
                }

                gameObject.transform.Find("Lab_ProTypeValue").GetComponent<Text>().text = attribute;
            }
        }

        private static void OnUpdatePetInfo(this DlgPetInfo self, RolePetInfo rolePetInfo)
        {
            self.View.E_InputFieldNameInputField.text = rolePetInfo.PetName;
            self.View.E_Btn_XiuXiButton.gameObject.SetActive(false);
            self.View.E_Btn_ChuZhanButton.gameObject.SetActive(false);

            self.UpdateAttribute(rolePetInfo);
            self.UpdateExpAndLv(rolePetInfo);
            self.UpdatePetZizhi(rolePetInfo);
            self.UpdatePetSkin(rolePetInfo);
            self.UpdateSkillList(rolePetInfo);

            self.View.E_Text_PetPingFenText.text = rolePetInfo.PetPingFen.ToString();

            self.View.E_Text_ShouHuText.text = ConfigData.PetShouHuAttri[rolePetInfo.ShouHuPos - 1].Value;
            using (zstring.Block())
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("ShouHu_{0}", rolePetInfo.ShouHuPos - 1));
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.View.E_ImageShouHuImage.sprite = sp;
            }

            //更新宠物是否进化
            if (rolePetInfo.UpStageStatus == 0 || rolePetInfo.UpStageStatus == 1)
            {
                CommonViewHelper.SetImageGray(self.Root(), self.View.E_ImageJinHuaImage.gameObject, true);
                if (rolePetInfo.UpStageStatus == 1)
                {
                    self.View.E_JinHuaReddotImage.gameObject.SetActive(true);
                    self.View.E_Lab_JinHuaText.text = "点击进化";
                }
                else
                {
                    self.View.E_JinHuaReddotImage.gameObject.SetActive(false);
                    self.View.E_Lab_JinHuaText.GetComponent<Text>().text = "未进化";
                }
            }
            else
            {
                CommonViewHelper.SetImageGray(self.Root(), self.View.E_ImageJinHuaImage.gameObject, false);
                self.View.E_JinHuaReddotImage.gameObject.SetActive(false);
                self.View.E_Lab_JinHuaText.text = "已进化";
            }

            PetConfig petConfig = PetConfigCategory.Instance.Get(self.LastSelectItem.ConfigId);
            if (petConfig.PetType == 2)
            {
                CommonViewHelper.SetImageGray(self.Root(), self.View.E_ImageJinHuaImage.gameObject, false);
                self.View.E_JinHuaReddotImage.gameObject.SetActive(false);
                self.View.E_Lab_JinHuaText.text = "已进化";
            }
        }

        private static void UpdateAttribute(this DlgPetInfo self, RolePetInfo rolePetInfo)
        {
            long petAllAct = self.GetAsLong(NumericType.Now_PetAllAct);
            long petAllMageact = self.GetAsLong(NumericType.Now_PetAllMageAct);
            long petAllAdf = self.GetAsLong(NumericType.Now_PetAllAdf);
            long petAllDef = self.GetAsLong(NumericType.Now_PetAllDef);
            long petAllHp = self.GetAsLong(NumericType.Now_PetAllHp);

            petAllAct += (int)(NumericHelp.GetAttributeValue(rolePetInfo, NumericType.Now_MaxAct) *
                (1 + self.GetAsFloat(NumericType.Now_PetAllActPro)));
            petAllMageact += (int)(NumericHelp.GetAttributeValue(rolePetInfo, NumericType.Now_Mage) *
                (1 + self.GetAsFloat(NumericType.Now_PetAllMageActPro)));
            petAllDef += (int)(NumericHelp.GetAttributeValue(rolePetInfo, NumericType.Now_MaxDef) *
                (1 + self.GetAsFloat(NumericType.Now_PetAllDefPro)));
            petAllAdf += (int)(NumericHelp.GetAttributeValue(rolePetInfo, NumericType.Now_MaxAdf) *
                (1 + self.GetAsFloat(NumericType.Now_PetAllAdfPro)));

            float petAllCri = self.GetAsFloat(NumericType.Now_PetAllCri);
            float petAllHit = self.GetAsFloat(NumericType.Now_PetAllHit);
            float petAllDodge = self.GetAsFloat(NumericType.Now_PetAllDodge);

            //基础属性
            self.UpdateAttributeItem(0, self.View.EG_PetProSetItem_1RectTransform.gameObject, self.View.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_MaxAct), self.GetAttributeShow(rolePetInfo, NumericType.Now_MaxAct, petAllAct));

            self.UpdateAttributeItem(1, self.View.EG_PetProSetItem_1RectTransform.gameObject, self.View.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_Mage), self.GetAttributeShow(rolePetInfo, NumericType.Now_Mage, petAllMageact));

            self.UpdateAttributeItem(2, self.View.EG_PetProSetItem_1RectTransform.gameObject, self.View.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_MaxDef), self.GetAttributeShow(rolePetInfo, NumericType.Now_MaxDef, petAllDef));

            self.UpdateAttributeItem(3, self.View.EG_PetProSetItem_1RectTransform.gameObject, self.View.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_MaxAdf), self.GetAttributeShow(rolePetInfo, NumericType.Now_MaxAdf, petAllAdf));

            self.UpdateAttributeItem(4, self.View.EG_PetProSetItem_1RectTransform.gameObject, self.View.E_PetProSetNode_1Image.gameObject,
                ItemViewHelp.GetAttributeIcon(NumericType.Now_MaxHp), self.GetAttributeShow(rolePetInfo, NumericType.Now_MaxHp, petAllHp));

            //特殊属性
            self.UpdateAttributeItem(0, self.View.EG_PetProSetItem_2RectTransform.gameObject, self.View.E_PetProSetNode_2Image.gameObject, "",
                self.GetAttributeShow(rolePetInfo, NumericType.Now_Cri, petAllCri));
            self.UpdateAttributeItem(1, self.View.EG_PetProSetItem_2RectTransform.gameObject, self.View.E_PetProSetNode_2Image.gameObject, "",
                self.GetAttributeShow(rolePetInfo, NumericType.Now_Res, 0));
            self.UpdateAttributeItem(2, self.View.EG_PetProSetItem_2RectTransform.gameObject, self.View.E_PetProSetNode_2Image.gameObject, "",
                self.GetAttributeShow(rolePetInfo, NumericType.Now_Hit, petAllHit));
            self.UpdateAttributeItem(3, self.View.EG_PetProSetItem_2RectTransform.gameObject, self.View.E_PetProSetNode_2Image.gameObject, "",
                self.GetAttributeShow(rolePetInfo, NumericType.Now_Dodge, petAllDodge));
        }

        public static long GetAsLong(this DlgPetInfo self, int numericType)
        {
            if (self.Keys.Contains(numericType))
            {
                return self.Values[self.Keys.IndexOf(numericType)];
            }

            return 0;
        }

        public static float GetAsFloat(this DlgPetInfo self, int numericType)
        {
            if (self.Keys.Contains(numericType))
            {
                return (float)self.Values[self.Keys.IndexOf(numericType)] / 10000;
            }

            return 0f;
        }

        private static void UpdateExpAndLv(this DlgPetInfo self, RolePetInfo rolePetInfo)
        {
            self.View.E_Text_PetLevelText.text = rolePetInfo.PetLv.ToString() + LanguageComponent.Instance.LoadLocalization("级");
            ExpConfig expConfig = ExpConfigCategory.Instance.Get(rolePetInfo.PetLv);
            using (zstring.Block())
            {
                self.View.E_Text_PetExpText.text = zstring.Format("{0}/{1}", rolePetInfo.PetExp, expConfig.PetUpExp);
            }

            self.View.E_ImageExpValueImage.transform.localScale =
                    new Vector3(Mathf.Clamp(rolePetInfo.PetExp * 1f / expConfig.PetUpExp, 0f, 1f), 1f, 1f);
        }

        private static void UpdatePetZizhi(this DlgPetInfo self, RolePetInfo rolePetInfo)
        {
            for (int i = 0; i < self.View.EG_ImagePetStarRectTransform.transform.childCount; i++)
            {
                self.View.EG_ImagePetStarRectTransform.transform.GetChild(i).gameObject.SetActive(rolePetInfo.Star > i);
            }

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
                        zstring.Format("{0}/{1}",
                            CommonViewHelper.ShowFloatValue(rolePetInfo.ZiZhi_ChengZhang),
                            CommonViewHelper.ShowFloatValue((float)petConfig.ZiZhi_ChengZhang_Max));
                self.PetZiZhiItemList[5].transform.Find("Text_ZiZhiValue").GetComponent<Text>().text =
                        zstring.Format("{0}/{1}", rolePetInfo.ZiZhi_MageAct, petConfig.ZiZhi_MageAct_Max);
            }
            

            float ziZhi_HpProp = Mathf.Clamp(rolePetInfo.ZiZhi_Hp * 1f /  petConfig.ZiZhi_Hp_Max, 0f, 1f) ;
            self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_HpProp;
            //self.PetZiZhiItemList[0].transform.Find("Image_56").gameObject.SetActive(ziZhi_HpProp >= showImage_56);
            //self.PetZiZhiItemList[0].transform.Find("Image_56").localPosition = new Vector3(264 - 350 * (1f - ziZhi_HpProp), -1f, 0f);
            
            float ziZhi_ActProp = Mathf.Clamp(rolePetInfo.ZiZhi_Act * 1f / petConfig.ZiZhi_Act_Max, 0f, 1f);
            self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_ActProp;
            //self.PetZiZhiItemList[1].transform.Find("Image_56").gameObject.SetActive(ziZhi_ActProp >= showImage_56);
            //self.PetZiZhiItemList[1].transform.Find("Image_56").localPosition = new Vector3(264 - 350 * (1f - ziZhi_ActProp), -1f, 0f);
            
            float ziZhi_DefProp =   Mathf.Clamp(rolePetInfo.ZiZhi_Def * 1f  / petConfig.ZiZhi_Def_Max, 0f, 1f);
            self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_DefProp;
            //self.PetZiZhiItemList[2].transform.Find("Image_56").gameObject.SetActive(ziZhi_DefProp >= showImage_56);
            //self.PetZiZhiItemList[2].transform.Find("Image_56").localPosition = new Vector3(264 - 350 * (1f - ziZhi_DefProp), -1f, 0f);
            
            float ziZhi_AdfProp =Mathf.Clamp(rolePetInfo.ZiZhi_Adf * 1f / petConfig.ZiZhi_Adf_Max, 0f, 1f);
            self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_AdfProp;
            //self.PetZiZhiItemList[3].transform.Find("Image_56").gameObject.SetActive(ziZhi_AdfProp >= showImage_56);
            //self.PetZiZhiItemList[3].transform.Find("Image_56").localPosition = new Vector3(264 - 350 * (1f - ziZhi_AdfProp), -1f, 0f);


            float ziZhi_ChengZhangProp =    Mathf.Clamp(rolePetInfo.ZiZhi_ChengZhang / (float)petConfig.ZiZhi_ChengZhang_Max, -1f, 1f);
            self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_ChengZhangProp;
            //self.PetZiZhiItemList[4].transform.Find("Image_56").gameObject.SetActive(ziZhi_ChengZhangProp >= showImage_56);
            //self.PetZiZhiItemList[4].transform.Find("Image_56").localPosition = new Vector3(264 - 350 * (1f - ziZhi_ChengZhangProp), 0f, 0f);
            
            float ziZhi_MageActProp =   Mathf.Clamp(rolePetInfo.ZiZhi_MageAct * 1f / petConfig.ZiZhi_MageAct_Max, 0f, 1f);
            self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_MageActProp;
            //self.PetZiZhiItemList[5].transform.Find("Image_56").gameObject.SetActive(ziZhi_MageActProp >= showImage_56);
            //self.PetZiZhiItemList[5].transform.Find("Image_56").localPosition = new Vector3(264 - 350 * (1f - ziZhi_MageActProp), 0f, 0f);
        }

        private static void UpdatePetSkin(this DlgPetInfo self, RolePetInfo rolePetInfo)
        {
            if (self.LastSelectItem == null)
            {
                return;
            }

            PetConfig petConfig = PetConfigCategory.Instance.Get(self.LastSelectItem.ConfigId);
            int selectIndex = 0;
            for (int i = 0; i < petConfig.Skin.Length; i++)
            {
                if (petConfig.Skin[i] == 0)
                {
                    continue;
                }

                if (petConfig.Skin[i] == rolePetInfo.SkinId)
                {
                    selectIndex = i;
                }
            }

            self.ShowPetSkins = petConfig.Skin;
            self.AddUIScrollItems(ref self.ScrollItemPetSkinIconItems, self.ShowPetSkins.Length);
            self.View.E_PetSkinIconItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetSkins.Length);

            Scroll_Item_PetSkinIconItem scrollItemPetSkinIconItem = self.ScrollItemPetSkinIconItems[selectIndex];
            scrollItemPetSkinIconItem.OnImage_ItemButton();
        }

        private static void UpdateSkillList(this DlgPetInfo self, RolePetInfo rolePetInfo)
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

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            Dictionary<int, int> equipSkilllist = PetHelper.GetEquipSkillList(rolePetInfo, bagComponent.GetItemsByLoc(ItemLocType.PetLocEquip));
            foreach (var item in equipSkilllist)
            {
                if (!rolePetInfo.PetSkill.Contains(item.Key))
                {
                    self.UnactiveId = item.Key;
                    self.UnactiveNum = item.Value;
                    self.ShowPetSkills.Add(item.Key);
                    break;
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.ShowPetSkills.Count);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetSkills.Count);
        }

        private static void UpdateAttributeItem(this DlgPetInfo self, int index, GameObject itemObj, GameObject parentObj, string iconid,
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
                CommonViewHelper.SetParent(gameObject, parentObj);
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

        private static string GetAttributeShow(this DlgPetInfo self, RolePetInfo rolePetInfo, int numericType, float addValue)
        {
            NumericAttribute numericAttribute = ItemViewData.AttributeToName[numericType];
            if (NumericHelp.GetNumericValueType(numericType) == 2)
            {
                float fvalue = (NumericHelp.GetAttributeValue(rolePetInfo, numericType)) * 0.01f + addValue * 100;
                //string svalue = string.Format("{0:F}", fvalue);
                string svalue = fvalue.ToString("0.#####");
                using (zstring.Block())
                {
                    return zstring.Format("{0} {1}%", ItemViewHelp.GetAttributeName(numericType), svalue);
                }
            }
            else
            {
                using (zstring.Block())
                {
                    return zstring.Format("{0} {1}", ItemViewHelp.GetAttributeName(numericType),
                        (long)(NumericHelp.GetAttributeValue(rolePetInfo, numericType) + addValue));
                }
            }
        }

        public static void OnPetSkinRawImageButton(this DlgPetInfo self)
        {
        }

        public static void OnButtonUseSkinButton(this DlgPetInfo self)
        {
        }

        public static void OnButtonEquipXieXiaButton(this DlgPetInfo self)
        {
        }

        public static void OnImageJinHuaButton(this DlgPetInfo self)
        {
        }

        public static void OnJiBanButton(this DlgPetInfo self)
        {
        }
    }
}