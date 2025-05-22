using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(Scroll_Item_PetSkinIconItem))]
    [FriendOf(typeof(Scroll_Item_PetListItem))]
    [EntitySystemOf(typeof(ES_WatchPet))]
    [FriendOf(typeof(ES_WatchPet))]
    public static partial class ES_WatchPetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WatchPet self, Transform transform)
        {
            self.uiTransform = transform;

            self.PetZiZhiItemList[0] = self.EG_PetZiZhiItem1RectTransform.gameObject;
            self.PetZiZhiItemList[1] = self.EG_PetZiZhiItem2RectTransform.gameObject;
            self.PetZiZhiItemList[2] = self.EG_PetZiZhiItem3RectTransform.gameObject;
            self.PetZiZhiItemList[3] = self.EG_PetZiZhiItem4RectTransform.gameObject;
            self.PetZiZhiItemList[4] = self.EG_PetZiZhiItem5RectTransform.gameObject;
            self.PetZiZhiItemList[5] = self.EG_PetZiZhiItem6RectTransform.gameObject;

            self.E_PetHeXinItem0Image.transform.Find("Node_1/ButtonAdd").GetComponent<Button>().AddListener(() =>
            {
                self.OnChangeNode(2);
                self.OnButtonPetHeXinItem(0);
            });
            self.E_PetHeXinItem1Image.transform.Find("Node_1/ButtonAdd").GetComponent<Button>().AddListener(() =>
            {
                self.OnChangeNode(2);
                self.OnButtonPetHeXinItem(1);
            });
            self.E_PetHeXinItem2Image.transform.Find("Node_1/ButtonAdd").GetComponent<Button>().AddListener(() =>
            {
                self.OnChangeNode(2);
                self.OnButtonPetHeXinItem(2);
            });

            self.E_PetHeXinItem0Image.transform.Find("ImageSelect").gameObject.SetActive(false);
            self.E_PetHeXinItem1Image.transform.Find("ImageSelect").gameObject.SetActive(false);
            self.E_PetHeXinItem2Image.transform.Find("ImageSelect").gameObject.SetActive(false);
            self.PetHeXinItemList = new GameObject[3];
            self.PetHeXinItemList[0] = self.E_PetHeXinItem0Image.gameObject;
            self.PetHeXinItemList[1] = self.E_PetHeXinItem1Image.gameObject;
            self.PetHeXinItemList[2] = self.E_PetHeXinItem2Image.gameObject;

            self.E_Btn_XiuXiButton.gameObject.SetActive(false);
            self.E_Btn_FangShengButton.gameObject.SetActive(false);
            self.E_Btn_ChuZhanButton.gameObject.SetActive(false);
            self.E_InputFieldNameInputField.enabled = false;
            self.E_PetListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetListItemsRefresh);
            self.E_PetSkinIconItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetSkinIconItemsRefresh);
            self.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
            // self.E_PetHeXinListLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetHeXinListItemsRefresh);
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_ButtonEquipHeXinButton.AddListenerAsync(self.OnButtonEquipHeXinButton);
            self.E_ButtonHeXinHeChengButton.AddListener(self.OnButtonHeXinHeChengButton);
            self.E_ButtonCloseHexinButton.AddListener(() => { self.OnChangeNode(1); });
            self.E_ButtonAddPointButton.AddListener(self.OnButtonAddPointButton);
            self.E_Btn_ConfirmButton.AddListenerAsync(self.OnBtn_ConfirmButton);
            self.E_ButtonCloseAddPointButton.AddListener(self.OnButtonCloseAddPointButton);
            self.E_PetHeXinSuitButton.AddListenerAsync(self.OnPetHeXinSuitButton);

            // EventTrigger LiLiang_Btn_Add = self.EG_AddProperty_LiLiangRectTransform.transform.Find("Btn_Add").GetComponent<EventTrigger>();
            // EventTrigger LiLiang_Btn_Cost = self.EG_AddProperty_LiLiangRectTransform.transform.Find("Btn_Cost").GetComponent<EventTrigger>();
            // LiLiang_Btn_Add.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_AddNum(0).Coroutine(); });
            // LiLiang_Btn_Cost.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_CostNum(0).Coroutine(); });
            // LiLiang_Btn_Add.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_AddNum(); });
            // LiLiang_Btn_Cost.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_AddNum(); });
            //
            // EventTrigger ZhiLi_Btn_Add = self.EG_AddProperty_ZhiLiRectTransform.transform.Find("Btn_Add").GetComponent<EventTrigger>();
            // EventTrigger ZhiLi_Btn_Cost = self.EG_AddProperty_ZhiLiRectTransform.transform.Find("Btn_Cost").GetComponent<EventTrigger>();
            // ZhiLi_Btn_Add.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_AddNum(0).Coroutine(); });
            // ZhiLi_Btn_Cost.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_CostNum(0).Coroutine(); });
            // ZhiLi_Btn_Add.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_AddNum(); });
            // ZhiLi_Btn_Cost.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_AddNum(); });
            //
            // EventTrigger TiZhi_Btn_Add = self.EG_AddProperty_TiZhiRectTransform.transform.Find("Btn_Add").GetComponent<EventTrigger>();
            // EventTrigger TiZhi_Btn_Cost = self.EG_AddProperty_TiZhiRectTransform.transform.Find("Btn_Cost").GetComponent<EventTrigger>();
            // TiZhi_Btn_Add.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_AddNum(0).Coroutine(); });
            // TiZhi_Btn_Cost.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_CostNum(0).Coroutine(); });
            // TiZhi_Btn_Add.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_AddNum(); });
            // TiZhi_Btn_Cost.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_AddNum(); });
            //
            // EventTrigger NaiLi_Btn_Add = self.EG_AddProperty_NaiLiRectTransform.transform.Find("Btn_Add").GetComponent<EventTrigger>();
            // EventTrigger NaiLi_Btn_Cost = self.EG_AddProperty_NaiLiRectTransform.transform.Find("Btn_Cost").GetComponent<EventTrigger>();
            // NaiLi_Btn_Add.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_AddNum(0).Coroutine(); });
            // NaiLi_Btn_Cost.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_CostNum(0).Coroutine(); });
            // NaiLi_Btn_Add.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_AddNum(); });
            // NaiLi_Btn_Cost.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_AddNum(); });
            self.E_ButtonRNameButton.AddListener(self.OnButtonRNameButton);
            self.E_Btn_ChuZhanButton.AddListener(self.OnBtn_ChuZhanButton);
            self.E_Btn_XiuXiButton.AddListener(self.OnBtn_XiuXiButton);
            self.E_Btn_FangShengButton.AddListener(self.OnBtn_FangShengButton);
            self.E_PetSkinRawImageButton.AddListener(self.OnPetSkinRawImageButton);
            self.E_ButtonUseSkinButton.AddListener(self.OnButtonUseSkinButton);
            self.E_ButtonEquipXieXiaButton.AddListener(self.OnButtonEquipXieXiaButton);
            self.E_ImageJinHuaButton.AddListener(self.OnImageJinHuaButton);
            self.E_JiBanButton.AddListener(self.OnJiBanButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_WatchPet self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_WatchPet self)
        {
            self.PetSkinId = 0;
            self.LastSelectItem = null;

            self.RefreshCreateRoleItems();
        }

        private static void OnItemTypeSet(this ES_WatchPet self, int index)
        {
            self.EG_PetZiZhiSetRectTransform.gameObject.SetActive(index == 0);
            self.E_PetProSetNodeImage.gameObject.SetActive(index == 1);
            self.EG_PetPiFuSetRectTransform.gameObject.SetActive(index == 2);

            self.EG_ButtonNodeRectTransform.gameObject.SetActive(index != 2);
        }

        public static async ETTask OnPetHeXinSuitButton(this ES_WatchPet self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetHeXinSuit);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetHeXinSuit>().UpdateInfo(self.PetHeXinSuit);
        }

        private static void OnPetListItemsRefresh(this ES_WatchPet self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetListItem item in self.ScrollItemPetListItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[index].BindTrans(transform);
            scrollItemPetListItem.SetClickHandler((long petId) => { self.OnClickPetHandler(petId); });

            scrollItemPetListItem.E_ImageDiButtonButton.gameObject.SetActive(true);

            // scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.triggers.Clear();
            // scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
            //     (pdata) => { self.OnPointerDown(pdata as PointerEventData); });
            // scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
            //     (pdata) => { self.OnPointerUp(pdata as PointerEventData, index); });
            // scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.BeginDrag,
            //     (pdata) => { self.OnBeginDrag(pdata as PointerEventData, index); });
            // scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.Drag,
            //     (pdata) => { self.OnDraging(pdata as PointerEventData); });
            // scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.EndDrag,
            //     (pdata) => { self.OnEndDrag(pdata as PointerEventData, index); });
            // scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.gameObject.SetActive(true);

            using (zstring.Block())
            {
                scrollItemPetListItem.uiTransform.gameObject.name = zstring.Format("UIPetListItem_{0}", index);
            }

            scrollItemPetListItem.OnInitData(self.ShowRolePetInfos[index], self.NextPetNumber());
        }

        private static void OnPetSkinIconItemsRefresh(this ES_WatchPet self, Transform transform, int index)
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

        private static void OnCommonSkillItemsRefresh(this ES_WatchPet self, Transform transform, int index)
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

        private static void OnSelectSkinHandler(this ES_WatchPet self, int skinId)
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

            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 115, 257f));
            using (zstring.Block())
            {
                self.ES_ModelShow.ShowOtherModel(zstring.Format("Pet/{0}", petConfig.SkinID.ToString()), true).Coroutine();
            }

            self.E_SkinJiHuoImage.gameObject.SetActive(self.LastSelectItem.SkinId == self.PetSkinId);
            self.E_SkinWeiJiHuoImage.gameObject.SetActive(!self.E_SkinJiHuoImage.gameObject.activeSelf);

            //显示激活属性
            if (petConfig.PripertyShow != "" && petConfig.PripertyShow != "0")
            {
                self.E_PropertyShowTextText.gameObject.SetActive(true);
                using (zstring.Block())
                {
                    self.E_PropertyShowTextText.text =
                            zstring.Format("{0}:{1}", LanguageComponent.Instance.LoadLocalization("激活属性"), petConfig.PripertyShow);
                }
            }
            else
            {
                self.E_PropertyShowTextText.gameObject.SetActive(false);
            }
        }

        private static void RefreshCreateRoleItems(this ES_WatchPet self)
        {
            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatch>().F2C_WatchPlayerResponse.RolePetInfos;
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
                Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[0];
                scrollItemPetListItem.OnClickPetItem();
            }
            else
            {
                self.EG_RightRectTransform.gameObject.SetActive(false);
                self.EG_GameObject2RectTransform.gameObject.SetActive(true);
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int maxNum = PetHelper.GetPetMaxNumber(userInfo.Lv, unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber));
            using (zstring.Block())
            {
                self.E_Text_PetNumberText.text = zstring.Format("{0}/{1}", PetHelper.GetBagPetNum(rolePetInfos), maxNum);
            }
            
            self.uiTransform.Find("EG_Right/PetShowDi").gameObject.SetActive(self.ShowRolePetInfos.Count > 0);
            self.uiTransform.Find("EG_Right/PetTip").gameObject.SetActive(self.ShowRolePetInfos.Count > 0);
        }

        private static int NextPetNumber(this ES_WatchPet self)
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

        private static void OnClickPetHandler(this ES_WatchPet self, long petId)
        {
            self.PetSkinId = 0;
            self.LastSelectItem = self.GetPetInfoByID(petId);
            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
            self.OnChangeNode(1);
            self.OnUpdatePetInfo(self.LastSelectItem);
            self.UpdatePetSelected(self.LastSelectItem);
            self.UpdatePetHeXin(self.LastSelectItem);
            self.E_JiBanButton.gameObject.SetActive(PetHelper.IsShenShou(self.LastSelectItem.ConfigId));
        }

        public static RolePetInfo GetPetInfoByID(this ES_WatchPet self, long petId)
        {
            for (int i = 0; i < self.ShowRolePetInfos.Count; i++)
            {
                if (self.ShowRolePetInfos[i].Id == petId)
                {
                    return self.ShowRolePetInfos[i];
                }
            }

            return null;
        }

        public static void UpdatePetHeXin(this ES_WatchPet self, RolePetInfo rolePetItem)
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

            // for (int i = 0; i < self.EquipList.Count; i++)
            // {
            //     self.EquipList[i].InitUI(FunctionUI.GetItemSubtypeByWeizhi_Pet(i));
            // }
            //
            // for (int i = 0; i < rolePetItem.PetEquipList.Count; i++)
            // {
            //     BagInfo bagInfo = bagComponent.GetBagInfo(rolePetItem.PetEquipList[i]);
            //     ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            //     self.EquipList[itemConfig.ItemSubType - 3001].UpdateData(bagInfo, ItemOperateEnum.None, null);
            // }

            self.E_PetHeXinSuitButton.gameObject.SetActive(true);
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

            if (lv10number >= 3)
            {
                self.E_PetHeXinSuitButton.GetComponentInChildren<Text>().text = "高级核心";
                self.E_PetHeXinSuitButton.GetComponent<Image>().material = null;
                self.PetHeXinSuit = 10;
            }
            else if (lv8number >= 3)
            {
                self.E_PetHeXinSuitButton.GetComponentInChildren<Text>().text = "中级核心";
                self.E_PetHeXinSuitButton.GetComponent<Image>().material = null;
                self.PetHeXinSuit = 8;
            }
            else if (lv5number >= 3)
            {
                self.E_PetHeXinSuitButton.GetComponentInChildren<Text>().text = "初级核心";
                self.E_PetHeXinSuitButton.GetComponent<Image>().material = null;
                self.PetHeXinSuit = 5;
            }
            else
            {
                self.E_PetHeXinSuitButton.GetComponentInChildren<Text>().text = "初级核心";
                self.E_PetHeXinSuitButton.GetComponent<Image>().material = mat;
                self.PetHeXinSuit = 0;
            }

            // 暂时用不上
            // 更换图标
            // string path1;
            // using (zstring.Block())
            // {
            //     path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("hexin{0}", index));
            // }
            //
            // Sprite sp1 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);
            //
            // self.E_PetHeXinSuitButton.GetComponent<Image>().sprite = sp1;
        }

        /// <summary>
        ///  //1 属性 2 宠物之核 3 加点
        /// </summary>
        /// <param name="self"></param>
        /// <param name="nodetype"></param>
        private static void OnChangeNode(this ES_WatchPet self, int nodetype)
        {
            self.EG_ButtonNodeRectTransform.gameObject.SetActive(nodetype == 1);
            self.EG_AttributeNodeRectTransform.gameObject.SetActive(nodetype == 1);
            self.EG_PetHeXinSetRectTransform.gameObject.SetActive(nodetype == 2);
            self.EG_PetAddPointRectTransform.gameObject.SetActive(nodetype == 3);
        }

        # region 核心

        public static void OnButtonPetHeXinItem(this ES_WatchPet self, int position)
        {
            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemPetHeXinBag);
            List<ItemInfo> eqipInfos = self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemPetHeXinEquip);
            for (int i = 0; i < self.PetHeXinItemList.Length; i++)
            {
                self.PetHeXinItemList[i].transform.Find("ImageSelect").gameObject.SetActive(i == position);
            }

            self.BagInfo = null;
            self.Position = position;
            self.UpdatePetHexinItem(eqipInfos);
            // self.OnUpdateItemList(bagInfos);
        }

        private static void UpdatePetHexinItem(this ES_WatchPet self, List<ItemInfo> bagInfos)
        {
            self.E_ButtonHeXinHeChengButton.gameObject.SetActive(true);
            self.E_ButtonEquipXieXiaButton.AddListenerAsync(self.OnButtonEquipXieXia);
            List<string> TypeNames = new List<string>() { "进攻能量", "守护能量", "生命能量" };
            self.E_TextTypeText.text = TypeNames[self.Position];

            CommonViewHelper.DestoryChild(self.EG_AttributeListNodeRectTransform.gameObject);
            long baginfoId = self.LastSelectItem.PetHeXinList[self.Position];
            ItemInfo bagInfo = null;
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].BagInfoID == baginfoId)
                {
                    bagInfo = bagInfos[i];
                }
            }

            self.E_ImageIconImage.gameObject.SetActive(bagInfo != null);
            self.E_ButtonEquipXieXiaButton.gameObject.SetActive(bagInfo != null);
            if (bagInfo == null)
            {
                self.E_TextNameText.text = "空";
                self.E_TextLevelText.text = "等级: 0";
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.E_TextNameText.text = itemConfig.ItemName;

            using (zstring.Block())
            {
                self.E_TextLevelText.text = zstring.Format("等级: {0}", itemConfig.UseLv);
            }

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageIconImage.sprite = sp;

            self.ShowAttributeItemList(itemConfig.ItemUsePar, self.EG_AttributeListNodeRectTransform.gameObject,
                self.EG_TextAttributeItemRectTransform.gameObject);
        }

        private static void ShowAttributeItemList(this ES_WatchPet self, string itemList, GameObject itemNodeList, GameObject attributeItem)
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
                        attribute = zstring.Format("{0} + {1}%", ItemViewHelp.GetAttributeName(numberType), numberValue * 100);
                    }
                }
                else
                {
                    using (zstring.Block())
                    {
                        attribute = zstring.Format("{0} + {1}", ItemViewHelp.GetAttributeName(numberType), numberValue);
                    }
                }

                gameObject.transform.Find("Lab_ProTypeValue").GetComponent<Text>().text = attribute;
            }
        }

        // private static void OnUpdateItemList(this ES_WatchPet self, List<BagInfo> bagInfos)
        // {
        //     self.BagInfo = null;
        //
        //     self.ShowBagInfos.Clear();
        //     for (int i = 0; i < bagInfos.Count; i++)
        //     {
        //         ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
        //
        //         if (itemConfig.ItemSubType - 1 != self.Position)
        //         {
        //             continue;
        //         }
        //
        //         self.ShowBagInfos.Add(bagInfos[i]);
        //     }
        //
        //     self.ShowBagInfos.Sort((bagInfo1, bagInfo2) =>
        //     {
        //         ItemConfig itemConfig1 = ItemConfigCategory.Instance.Get(bagInfo1.ItemID);
        //         ItemConfig itemConfig2 = ItemConfigCategory.Instance.Get(bagInfo2.ItemID);
        //         return itemConfig2.UseLv - itemConfig1.UseLv;
        //     });
        //
        //     self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
        //     self.E_PetHeXinListLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        // }

        private static void OnPetHeXinListItemsRefresh(this ES_WatchPet self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.PetHeXinBag);
            scrollItemCommonItem.SetClickHandler(self.SelectItemHandlder);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.ShowBagInfos[index].ItemID);
            using (zstring.Block())
            {
                scrollItemCommonItem.E_ItemNumText.text = zstring.Format("{0}级", itemConfig.UseLv);
            }
        }

        private static void SelectItemHandlder(this ES_WatchPet self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            for (int i = 0; i < self.ScrollItemCommonItems.Count; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.SetSelected(bagInfo);
                }
            }
        }

        public static async ETTask OnButtonEquipHeXinButton(this ES_WatchPet self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            if (itemConfig.ItemType != (int)ItemTypeEnum.PetHeXin)
            {
                return;
            }

            if (itemConfig.ItemSubType - 1 != self.Position)
            {
                FlyTipComponent.Instance.ShowFlyTip("孔位不符！");
                return;
            }

            self.LastSelectItem =
                    await PetNetHelper.RequestRolePetHeXin(self.Root(), 1, self.BagInfo.BagInfoID, self.LastSelectItem.Id, self.Position);

            self.OnEquipPetHeXin();
        }

        public static void OnButtonHeXinHeChengButton(this ES_WatchPet self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetHeXinHeCheng).Coroutine();
        }

        private static async ETTask OnButtonEquipXieXia(this ES_WatchPet self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            long baginfoId = self.LastSelectItem.PetHeXinList[self.Position];
            ItemInfo bagInfo = bagComponent.GetBagInfo(baginfoId);

            self.LastSelectItem = await PetNetHelper.RequestRolePetHeXin(self.Root(), 2, bagInfo.BagInfoID, self.LastSelectItem.Id, self.Position);
            self.OnEquipPetHeXin();
        }

        public static void OnEquipPetHeXin(this ES_WatchPet self)
        {
            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemPetHeXinBag);
            List<ItemInfo> eqipInfos = self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemPetHeXinEquip);
            self.UpdatePetHeXin(self.LastSelectItem);
            self.UpdateAttribute(self.LastSelectItem);
            self.SelectItemHandlder(null);
            self.UpdatePetHexinItem(eqipInfos);
            // self.OnUpdateItemList(bagInfos);
        }

        # endregion

        # region 加点

        private static void OnButtonAddPointButton(this ES_WatchPet self)
        {
            self.OnChangeNode(3);
            self.OnInitAddPointUI();
        }

        private static void OnButtonCloseAddPointButton(this ES_WatchPet self)
        {
            self.OnChangeNode(1);
        }

        private static void OnInitAddPointUI(this ES_WatchPet self)
        {
            self.PointList.Clear();
            self.PointInit.Clear();
            string[] propertyList = self.LastSelectItem.AddPropretyValue.Split('_');
            self.PointList.Add(int.Parse(propertyList[0]));
            self.PointList.Add(int.Parse(propertyList[1]));
            self.PointList.Add(int.Parse(propertyList[2]));
            self.PointList.Add(int.Parse(propertyList[3]));
            self.PointInit.Clear();
            self.PointInit.AddRange(self.PointList);
            self.PointRemain = self.LastSelectItem.AddPropretyNum;

            self.OnUpdateAddPointUI();
        }

        private static void OnUpdateAddPointUI(this ES_WatchPet self)
        {
            self.E_Lab_ShengYuNumText.text = self.PointRemain.ToString();
            self.OnUpdateItem(self.EG_AddProperty_LiLiangRectTransform.gameObject, self.PointList[0], self.LastSelectItem.PetLv);
            self.OnUpdateItem(self.EG_AddProperty_ZhiLiRectTransform.gameObject, self.PointList[1], self.LastSelectItem.PetLv);
            self.OnUpdateItem(self.EG_AddProperty_TiZhiRectTransform.gameObject, self.PointList[2], self.LastSelectItem.PetLv);
            self.OnUpdateItem(self.EG_AddProperty_NaiLiRectTransform.gameObject, self.PointList[3], self.LastSelectItem.PetLv);
        }

        private static void OnUpdateItem(this ES_WatchPet self, GameObject gameObject, int number, int level)
        {
            gameObject.transform.Find("Lab_Value").GetComponent<Text>().text = (number + level).ToString();
        }

        private static async ETTask PointerDown_Btn_AddNum(this ES_WatchPet self, int addType)
        {
            self.IsHoldDown = true;
            self.Btn_AddProprety(addType, 1);
            int interval = 0;
            while (self.IsHoldDown)
            {
                interval++;
                if (interval > 60)
                {
                    self.Btn_AddProprety(addType, 1);
                }

                await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
            }
        }

        private static async ETTask PointerDown_Btn_CostNum(this ES_WatchPet self, int addType)
        {
            self.IsHoldDown = true;
            self.Btn_AddProprety(addType, -1);
            int interval = 0;
            while (self.IsHoldDown)
            {
                interval++;
                if (interval > 60)
                {
                    self.Btn_AddProprety(addType, -1);
                }

                await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
            }
        }

        private static void PointerUp_Btn_AddNum(this ES_WatchPet self)
        {
            self.IsHoldDown = false;
        }

        private static void Btn_AddProprety(this ES_WatchPet self, int addType, int value)
        {
            if (self.PointRemain <= 0 && value > 0)
            {
                return;
            }

            int typeValue = self.PointList[addType];
            if (typeValue <= self.PointInit[addType] && value < 0)
            {
                return;
            }

            self.PointRemain += (value * -1);
            self.PointList[addType] += value;

            self.OnUpdateUI();
        }

        private static async ETTask OnBtn_ConfirmButton(this ES_WatchPet self)
        {
            self.LastSelectItem = await PetNetHelper.RequestRolePetJiadian(self.Root(), self.LastSelectItem.Id, self.PointList);
            self.OnInitAddPointUI();
            self.OnUpdatePetPoint(self.LastSelectItem);
        }

        # endregion

        private static void OnUpdatePetInfo(this ES_WatchPet self, RolePetInfo rolePetInfo)
        {
            self.E_InputFieldNameInputField.text = rolePetInfo.PetName;
            self.E_Text_Lv.text = rolePetInfo.PetLv.ToString();

            self.UpdateAttribute(rolePetInfo);
            self.UpdateExpAndLv(rolePetInfo);
            self.UpdatePetZizhi(rolePetInfo);
            self.UpdatePetSkin(rolePetInfo);
            self.UpdateSkillList(rolePetInfo);

            self.E_Text_PetPingFenText.text = rolePetInfo.PetPingFen.ToString();

            self.E_Text_ShouHuText.text = ConfigData.PetShouHuAttri[rolePetInfo.ShouHuPos - 1].Value;
            // 暂时用不上
            // using (zstring.Block())
            // {
            //     string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("ShouHu_{0}", rolePetInfo.ShouHuPos - 1));
            //     Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            //     self.E_ImageShouHuImage.sprite = sp;
            // }

            //更新宠物是否进化
            if (rolePetInfo.UpStageStatus == 0 || rolePetInfo.UpStageStatus == 1)
            {
                CommonViewHelper.SetImageGray(self.Root(), self.E_ImageJinHuaImage.gameObject, true);
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
                CommonViewHelper.SetImageGray(self.Root(), self.E_ImageJinHuaImage.gameObject, false);
                self.E_JinHuaReddotImage.gameObject.SetActive(false);
                self.E_Lab_JinHuaText.text = "已进化";
            }

            PetConfig petConfig = PetConfigCategory.Instance.Get(self.LastSelectItem.ConfigId);
            if (petConfig.PetType == 2)
            {
                CommonViewHelper.SetImageGray(self.Root(), self.E_ImageJinHuaImage.gameObject, false);
                self.E_JinHuaReddotImage.gameObject.SetActive(false);
                self.E_Lab_JinHuaText.text = "已进化";
            }
        }

        private static void UpdateAttribute(this ES_WatchPet self, RolePetInfo rolePetInfo)
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

        private static void UpdateExpAndLv(this ES_WatchPet self, RolePetInfo rolePetInfo)
        {
            self.E_Text_PetLevelText.text = rolePetInfo.PetLv.ToString() + LanguageComponent.Instance.LoadLocalization("级");
            ExpConfig expConfig = ExpConfigCategory.Instance.Get(rolePetInfo.PetLv);
            using (zstring.Block())
            {
                self.E_Text_PetExpText.text = zstring.Format("{0}/{1}", rolePetInfo.PetExp, expConfig.PetUpExp);
            }

            self.E_ImageExpValueImage.transform.localScale = new Vector3(Mathf.Clamp(rolePetInfo.PetExp * 1f / expConfig.PetUpExp, 0f, 1f), 1f, 1f);
        }

        private static void UpdatePetZizhi(this ES_WatchPet self, RolePetInfo rolePetInfo)
        {
            for (int i = 0; i < self.EG_ImagePetStarRectTransform.transform.childCount; i++)
            {
                self.EG_ImagePetStarRectTransform.transform.GetChild(i).gameObject.SetActive(rolePetInfo.Star > i);
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

         
            //小于80%不显示拖尾
            float showImage_56 = 0.1f;
            float ziZhi_HpProp = Mathf.Clamp(rolePetInfo.ZiZhi_Hp * 1f /  petConfig.ZiZhi_Hp_Max, 0f, 1f) ;
            self.PetZiZhiItemList[0].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_HpProp;
            self.PetZiZhiItemList[0].transform.Find("Image_56").gameObject.SetActive(ziZhi_HpProp >= showImage_56);
            self.PetZiZhiItemList[0].transform.Find("Image_56").localPosition = new Vector3(285 - 409 * (1f - ziZhi_HpProp), -1f, 0f);
            
            float ziZhi_ActProp = Mathf.Clamp(rolePetInfo.ZiZhi_Act * 1f / petConfig.ZiZhi_Act_Max, 0f, 1f);
            self.PetZiZhiItemList[1].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_ActProp;
            self.PetZiZhiItemList[1].transform.Find("Image_56").gameObject.SetActive(ziZhi_ActProp >= showImage_56);
            self.PetZiZhiItemList[1].transform.Find("Image_56").localPosition = new Vector3(285 - 409 * (1f - ziZhi_ActProp), -1f, 0f);

            float ziZhi_DefProp =   Mathf.Clamp(rolePetInfo.ZiZhi_Def * 1f  / petConfig.ZiZhi_Def_Max, 0f, 1f); 
            self.PetZiZhiItemList[2].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_DefProp;
            self.PetZiZhiItemList[2].transform.Find("Image_56")?.gameObject.SetActive(ziZhi_DefProp >= showImage_56);
            self.PetZiZhiItemList[2].transform.Find("Image_56").localPosition = new Vector3(285 - 409 * (1f - ziZhi_DefProp), -1f, 0f);

            float ziZhi_AdfProp =Mathf.Clamp(rolePetInfo.ZiZhi_Adf * 1f / petConfig.ZiZhi_Adf_Max, 0f, 1f); 
            self.PetZiZhiItemList[3].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =ziZhi_AdfProp;
            self.PetZiZhiItemList[3].transform.Find("Image_56").gameObject.SetActive(ziZhi_AdfProp >= showImage_56);
            self.PetZiZhiItemList[3].transform.Find("Image_56").localPosition = new Vector3(285 - 409 * (1f - ziZhi_AdfProp), -1f, 0f);
            
            float ziZhi_ChengZhangProp =    Mathf.Clamp(rolePetInfo.ZiZhi_ChengZhang / (float)petConfig.ZiZhi_ChengZhang_Max, 0f, 1f); 
            self.PetZiZhiItemList[4].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount = ziZhi_ChengZhangProp;
            self.PetZiZhiItemList[4].transform.Find("Image_56")?.gameObject.SetActive(ziZhi_ChengZhangProp >= showImage_56);
            self.PetZiZhiItemList[4].transform.Find("Image_56").localPosition = new Vector3(285 - 409 * (1f - ziZhi_ChengZhangProp), -1f, 0f);

            float ziZhi_MageActProp =   Mathf.Clamp(rolePetInfo.ZiZhi_MageAct * 1f / petConfig.ZiZhi_MageAct_Max, 0f, 1f); 
            self.PetZiZhiItemList[5].transform.Find("ImageExpValue").GetComponent<Image>().fillAmount =ziZhi_MageActProp;
            self.PetZiZhiItemList[5].transform.Find("Image_56")?.gameObject.SetActive(ziZhi_MageActProp >= showImage_56);
            self.PetZiZhiItemList[5].transform.Find("Image_56").localPosition = new Vector3(285 - 409 * (1f - ziZhi_MageActProp), -1f, 0f);
        }

        private static void UpdatePetSkin(this ES_WatchPet self, RolePetInfo rolePetInfo)
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
            self.E_PetSkinIconItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetSkins.Length);

            Scroll_Item_PetSkinIconItem scrollItemPetSkinIconItem = self.ScrollItemPetSkinIconItems[selectIndex];
            scrollItemPetSkinIconItem.OnImage_ItemButton();
        }

        private static void UpdateSkillList(this ES_WatchPet self, RolePetInfo rolePetInfo)
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
            self.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetSkills.Count);
        }

        private static void UpdateAttributeItem(this ES_WatchPet self, int index, GameObject itemObj, GameObject parentObj, string iconid,
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

        private static void UpdatePetSelected(this ES_WatchPet self, RolePetInfo rolePetItem)
        {
            for (int i = 0; i < self.ScrollItemPetListItems.Count; i++)
            {
                Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[i];
                if (scrollItemPetListItem.uiTransform != null)
                {
                    scrollItemPetListItem.OnSelectUI(rolePetItem);
                }
            }

            self.OnUpdatePetPoint(rolePetItem);
        }

        private static void OnUpdatePetPoint(this ES_WatchPet self, RolePetInfo rolePetItem)
        {
            self.LastSelectItem = rolePetItem;
            self.E_ButtonAddPointButton.transform.Find("Reddot").gameObject.SetActive(rolePetItem != null && rolePetItem.AddPropretyNum > 0);
            for (int i = 0; i < self.ScrollItemPetListItems.Count; i++)
            {
                Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[i];
                scrollItemPetListItem.OnUpdatePetPoint(rolePetItem);
            }

            self.UpdateAttribute(self.LastSelectItem);
        }

        private static string GetAttributeShow(this ES_WatchPet self, RolePetInfo rolePetInfo, int numericType, float addValue)
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

        private static void OnPointerDown(this ES_WatchPet self, PointerEventData pdata)
        {
            self.ClickTime = TimeHelper.ServerNow();
            self.IsChange = false;
        }

        private static void OnPointerUp(this ES_WatchPet self, PointerEventData pdata, int index1)
        {
            if (TimeHelper.ServerNow() - self.ClickTime <= 200)
            {
                self.OnClick(index1);
            }

            self.ClickTime = 0;
        }

        private static void OnBeginDrag(this ES_WatchPet self, PointerEventData pdata, int index1)
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
                Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[index1];
                self.EG_MaskRectTransform.transform.Find("Img_PetIcon").GetComponent<Image>().sprite =
                        scrollItemPetListItem.E_Img_PetHeroIonImage.sprite;
                // self.EG_MaskRectTransform.transform.SetParent(self.Root().GetComponent<GlobalComponent>().PopUpRoot);
                self.EG_MaskRectTransform.transform.localScale = Vector3.one;
            }
        }

        private static void OnDraging(this ES_WatchPet self, PointerEventData pdata)
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

        private static void OnEndDrag(this ES_WatchPet self, PointerEventData pdata, int index1)
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

                // self.EG_MaskRectTransform.transform.SetParent(self.uiTransform);
                self.EG_MaskRectTransform.gameObject.SetActive(false);
            }
            else
            {
                self.E_PetListItemsLoopVerticalScrollRect.OnEndDrag(pdata);
            }
        }

        private static void OnClick(this ES_WatchPet self, int index)
        {
            Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[index];
            scrollItemPetListItem.OnClickPetItem();
        }

        private static void ChangePos(this ES_WatchPet self, int index1, int index2)
        {
            if (index1 == index2)
            {
                return;
            }

            Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[index1];
            long petId1 = scrollItemPetListItem.PetId;
            scrollItemPetListItem = self.ScrollItemPetListItems[index2];
            long petId2 = scrollItemPetListItem.PetId;

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
        public static void OnButtonRNameButton(this ES_WatchPet self)
        {
        }
        public static void OnBtn_ChuZhanButton(this ES_WatchPet self)
        {
        }
        public static void OnBtn_XiuXiButton(this ES_WatchPet self)
        {
        }
        public static void OnBtn_FangShengButton(this ES_WatchPet self)
        {
        }
        public static void OnPetSkinRawImageButton(this ES_WatchPet self)
        {
        }
        public static void OnButtonUseSkinButton(this ES_WatchPet self)
        {
        }
        public static void OnButtonEquipXieXiaButton(this ES_WatchPet self)
        {
        }
        public static void OnImageJinHuaButton(this ES_WatchPet self)
        {
        }
        public static void OnJiBanButton(this ES_WatchPet self)
        {
        }
    }
}
