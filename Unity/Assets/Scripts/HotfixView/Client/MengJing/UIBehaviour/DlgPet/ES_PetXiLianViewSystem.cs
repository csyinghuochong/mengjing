using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(Scroll_Item_PetListItem))]
    [FriendOf(typeof(ES_PetInfoShow))]
    [EntitySystemOf(typeof(ES_PetXiLian))]
    [FriendOfAttribute(typeof(ES_PetXiLian))]
    public static partial class ES_PetXiLianSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetXiLian self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_XiLianButton.AddListenerAsync(self.OnBtn_XiLianButton);
            self.E_CommonItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonItemsRefresh);
            self.E_PetListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetListItemsRefresh);
            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetXiLian self)
        {
            self.DestroyWidget();
        }

        private static void OnInitUI(this ES_PetXiLian self)
        {
            self.ES_PetInfoShow.Weizhi = 0;
            self.ES_PetInfoShow.BagOperationType = PetOperationType.XiLian;
            self.ES_PetInfoShow.OnInitData(null);
        }

        public static async ETTask OnBtn_XiLianButton(this ES_PetXiLian self)
        {
            if (self.RolePetInfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择宠物！");
                return;
            }

            if (self.CostItemInfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择道具！");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.CostItemInfo.ItemID);

            if (itemConfig.ItemSubType == 136)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetXiLianLockSkill);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetXiLianLockSkill>().UpdateSkillList(self.RolePetInfo, self.CostItemInfo);
                return;
            }

            if ((itemConfig.ItemSubType == 108 || itemConfig.ItemSubType == 109) && self.RolePetInfo.PetLv >= userInfo.Lv + 5)
            {
                FlyTipComponent.Instance.ShowFlyTip("宠物等级不能高于玩家5级！");
                return;
            }

            PetConfig petConfig = PetConfigCategory.Instance.Get(self.RolePetInfo.ConfigId);
            if (itemConfig.ItemSubType == 119 && self.RolePetInfo.ZiZhi_ChengZhang >= petConfig.ZiZhi_ChengZhang_Max) //成长
            {
                FlyTipComponent.Instance.ShowFlyTip("宠物成长已经达到上限！");
                return;
            }

            if ( /*itemConfig.ItemSubType == 105 || */itemConfig.ItemSubType == 134)
            {
                if (PetHelper.IsBianYI(self.RolePetInfo))
                {
                    FlyTipComponent.Instance.ShowFlyTip("变异的宠物不能使用此道具！");
                    return;
                }
            }

            //if (itemConfig.ItemSubType == 133)
            //{
            //    if (!PetHelper.IsBianYI(self.RolePetInfo))
            //    {
            //        FloatTipManager.Instance.ShowFloatTip("只有变异宠物能使用此道具！");
            //        return;
            //    }
            //}

            long oldSkin = self.RolePetInfo.SkinId;
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            await PetNetHelper.RequestXiLian(self.Root(), self.CostItemInfo.BagInfoID, self.RolePetInfo.Id);
            if (self.IsDisposed)
            {
                return;
            }

            if (oldSkin == self.RolePetInfo.SkinId)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_PetChouKaGet);
            if (self.IsDisposed)
            {
                return;
            }

            List<KeyValuePair> oldPetSkin = petComponent.GetPetSkinCopy();
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetChouKaGet>()
                    .OnInitUI(petComponent.GetPetInfoByID(self.RolePetInfo.Id), oldPetSkin, null);
        }

        public static void OnXiLianUpdate(this ES_PetXiLian self)
        {
            self.RolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(self.RolePetInfo.Id);
            self.ES_PetInfoShow.OnInitData(self.RolePetInfo);

            self.UpdateConsume();
            self.UpdatePetListItemInfo();
        }

        public static void OnXiLianSelect(this ES_PetXiLian self, RolePetInfo rolePetInfo)
        {
            self.RolePetInfo = rolePetInfo;
            self.ES_PetInfoShow.OnInitData(rolePetInfo);

            self.UpdateConsume();
            self.UpdatePetSelected(rolePetInfo);
            
            PetSkinConfig petConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 115, 257f));
            using (zstring.Block())
            {
                self.ES_ModelShow.ShowOtherModel(zstring.Format("Pet/{0}", petConfig.SkinID.ToString()), true).Coroutine();
            }
        }

        private static void UpdatePetListItemInfo(this ES_PetXiLian self)
        {
            for (int i = 0; i < self.ScrollItemPetListItems.Count; i++)
            {
                Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[i];
                if (scrollItemPetListItem.uiTransform != null)
                {
                    scrollItemPetListItem.UpdateLv();
                }
            }
        }

        private static void UpdatePetSelected(this ES_PetXiLian self, RolePetInfo rolePetItem)
        {
            for (int i = 0; i < self.ScrollItemPetListItems.Count; i++)
            {
                Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[i];
                if (scrollItemPetListItem.uiTransform != null)
                {
                    scrollItemPetListItem.OnSelectUI(rolePetItem);
                }
            }
        }

        private static void OnSelectItem(this ES_PetXiLian self, ItemInfo bagInfo)
        {
            self.CostItemInfo = bagInfo;
            if (bagInfo == null)
            {
                self.E_Img_ItemIconImage.gameObject.SetActive(false);
                self.E_Img_ItemQualityImage.gameObject.SetActive(false);
                self.E_Text_ItemNameText.text = "";
                return;
            }

            self.E_Img_ItemIconImage.gameObject.SetActive(true);
            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_Img_ItemIconImage.sprite = sp;
            
            self.E_Img_ItemQualityImage.gameObject.SetActive(true);
            string qualityiconStr = FunctionUI.ItemQualiytoPath(itemconfig.ItemQuality);
            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);

            self.E_Img_ItemQualityImage.sprite = sp2;
            self.E_Text_ItemNameText.text = itemconfig.ItemName;
        }

        public static void OnUpdateUI(this ES_PetXiLian self)
        {
            self.RolePetInfo = null;
            self.OnSelectItem(null);
            self.UpdateConsume();

            self.RefreshCreateRoleItems();
            if (self.ShowRolePetInfos.Count > 0)
            {
                Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[0];
                scrollItemPetListItem.OnClickPetItem();
            }
            else
            {
                self.ES_PetInfoShow.OnInitData(null);
            }
        }

        private static void OnCommonItemsRefresh(this ES_PetXiLian self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.UpdateItem(self.ShowBagInfos[index], ItemOperateEnum.PetXiLian);
            scrollItemCommonItem.SetClickHandler((bagInfo) => { self.OnSelectItem(bagInfo); });
            scrollItemCommonItem.HideItemName();
            scrollItemCommonItem.E_ItemNumText.gameObject.SetActive(true);
        }

        private static void UpdateConsume(this ES_PetXiLian self)
        {
            self.ShowBagInfos.Clear();
            List<ItemInfo> bagList = self.Root().GetComponent<BagComponentC>().GetBagList();

            for (int i = 0; i < bagList.Count; i++)
            {
                int itemID = bagList[i].ItemID;
                ItemConfig conf = ItemConfigCategory.Instance.Get(itemID);
                int itemType = conf.ItemType;
                int itemSubType = conf.ItemSubType;

                if (itemSubType != 105 && itemSubType != 108 && itemSubType != 109
                    && itemSubType != 117 && itemSubType != 118 && itemSubType != 119
                    && itemSubType != 122 && itemSubType != 133 && itemSubType != 134
                    && itemSubType != 136)
                {
                    continue;
                }

                self.ShowBagInfos.Add(bagList[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_CommonItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);

            self.OnSelectItem(null);
        }

        private static void RefreshCreateRoleItems(this ES_PetXiLian self)
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

            self.AddUIScrollItems(ref self.ScrollItemPetListItems, self.ShowRolePetInfos.Count);
            self.E_PetListItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }

        private static void OnPetListItemsRefresh(this ES_PetXiLian self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetListItem item in self.ScrollItemPetListItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[index].BindTrans(transform);
            scrollItemPetListItem.SetClickHandler((long petId) =>
            {
                RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(petId);
                self.OnXiLianSelect(rolePetInfo);
            });

            scrollItemPetListItem.E_ImageDiButtonButton.gameObject.SetActive(true);
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.gameObject.SetActive(false);

            scrollItemPetListItem.OnInitData(self.ShowRolePetInfos[index], 0);
        }
    }
}