using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [FriendOf(typeof (ES_CommonItem))]
    [EntitySystemOf(typeof (ES_RoleXiLianTransfer))]
    [FriendOfAttribute(typeof (ES_RoleXiLianTransfer))]
    public static partial class ES_RoleXiLianTransferSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleXiLianTransfer self, Transform transform)
        {
            self.uiTransform = transform;

            self.IsHoldDown = false;
            self.BagInfo_Transfer = new ItemInfo[2];
            self.UIItem_Transfer = new EntityRef<ES_CommonItem>[2];
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_ButtonTransferButton.AddListenerAsync(self.OnButtonTransferButton);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianTransfer self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_RoleXiLianTransfer self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.SkillSet);
            scrollItemCommonItem.SetEventTrigger(true);
            scrollItemCommonItem.HideItemNumber();
            scrollItemCommonItem.BeginDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.BeginDrag(binfo, pdata); };
            scrollItemCommonItem.DragingHandler = (ItemInfo binfo, PointerEventData pdata) => { self.Draging(binfo, pdata); };
            scrollItemCommonItem.EndDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.EndDrag(binfo, pdata); };
            scrollItemCommonItem.PointerDownHandler = (ItemInfo binfo, PointerEventData pdata) =>
            {
                self.OnPointerDown(binfo, pdata).Coroutine();
            };
            scrollItemCommonItem.PointerUpHandler = (ItemInfo binfo, PointerEventData pdata) => { self.OnPointerUp(binfo, pdata); };
        }

        public static async ETTask OnButtonTransferButton(this ES_RoleXiLianTransfer self)
        {
            string costItem = GlobalValueConfigCategory.Instance.Get(51).Value;
            if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem(costItem))
            {
                FlyTipComponent.Instance.ShowFlyTip("材料不足！");
                return;
            }

            if (self.BagInfo_Transfer[0] == null || self.BagInfo_Transfer[1] == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择合适的装备转移！");
                return;
            }

            //圣光装备洗练继承功能 布甲只能继承布甲 同类型只能继承同类型
            ItemConfig itemConfig_0 = ItemConfigCategory.Instance.Get(self.BagInfo_Transfer[0].ItemID);
            ItemConfig itemConfig_1 = ItemConfigCategory.Instance.Get(self.BagInfo_Transfer[1].ItemID);

            //道具配置

            if (itemConfig_0.EquipType != itemConfig_1.EquipType)
            {
                FlyTipComponent.Instance.ShowFlyTip("只有护甲类型相同的装备才能转移！");
                return;
            }

            if (itemConfig_0.ItemSubType != itemConfig_1.ItemSubType)
            {
                FlyTipComponent.Instance.ShowFlyTip("只有相同部位的装备才能转移！");
                return;
            }

            //紫色品质以上才可以转移
            if (itemConfig_0.ItemQuality < 4 || itemConfig_1.ItemQuality < 4)
            {
                FlyTipComponent.Instance.ShowFlyTip("只有紫色及以上品质的装备才能转移！");
                return;
            }

            //绑定装备无法转移
            if (self.BagInfo_Transfer[0].isBinging && self.BagInfo_Transfer[1].isBinging == false && itemConfig_1.ItemQuality == 4)
            {
                FlyTipComponent.Instance.ShowFlyTip("绑定装备的洗练属性无法转移至未绑定的装备！");
                return;
            }

            M2C_ItemXiLianTransferResponse response =
                    await BagClientNetHelper.ItemXiLianTransfer(self.Root(), self.BagInfo_Transfer[0].BagInfoID, self.BagInfo_Transfer[1].BagInfoID);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("装备属性转移成功！");
            self.OnUpdateUI();
        }

        public static void OnInitUI(this ES_RoleXiLianTransfer self)
        {
            self.UpdateCost();

            self.UIItem_Transfer[0] = self.ES_CommonItem_1;
            self.UIItem_Transfer[1] = self.ES_CommonItem_2;
            self.ES_CommonItem_1.uiTransform.gameObject.SetActive(false);
            self.ES_CommonItem_2.uiTransform.gameObject.SetActive(false);
        }

        public static void OnUpdateUI(this ES_RoleXiLianTransfer self)
        {
            self.UpdateCost();
            self.ResetSelect();
            self.UpdateSelected();
            self.UpdateEquipItemUI();
        }

        public static void UpdateCost(this ES_RoleXiLianTransfer self)
        {
            string[] costItem = GlobalValueConfigCategory.Instance.Get(51).Value.Split(';');
            self.ES_CostItem.UpdateItem(int.Parse(costItem[0]), int.Parse(costItem[1]));
        }

        public static void ResetSelect(this ES_RoleXiLianTransfer self)
        {
            self.BagInfo_Transfer[0] = null;
            self.BagInfo_Transfer[1] = null;

            ES_CommonItem esCommonItem0 = self.UIItem_Transfer[0];
            ES_CommonItem esCommonItem1 = self.UIItem_Transfer[1];
            esCommonItem0.uiTransform.gameObject.SetActive(false);
            esCommonItem1.uiTransform.gameObject.SetActive(false);
        }

        public static void UpdateSelect(this ES_RoleXiLianTransfer self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemInfo bagInfo_1 = bagComponent.GetBagInfo(self.BagInfo_Transfer[0].BagInfoID);
            ItemInfo bagInfo_2 = bagComponent.GetBagInfo(self.BagInfo_Transfer[1].BagInfoID);
            ES_CommonItem esCommonItem0 = self.UIItem_Transfer[0];
            ES_CommonItem esCommonItem1 = self.UIItem_Transfer[1];
            esCommonItem0.UpdateItem(bagInfo_1, ItemOperateEnum.None);
            esCommonItem1.UpdateItem(bagInfo_2, ItemOperateEnum.None);
            esCommonItem0.HideItemNumber();
            esCommonItem1.HideItemNumber();
        }

        public static void UpdateEquipItemUI(this ES_RoleXiLianTransfer self)
        {
            self.ShowBagInfos.Clear();
            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                int itemID = bagInfos[i].ItemID;
                ItemConfig itemconf = ItemConfigCategory.Instance.Get(itemID);
                if (itemconf.ItemType != (int)ItemTypeEnum.Equipment || bagInfos[i].IfJianDing)
                {
                    continue;
                }

                if (itemconf.EquipType == 201)
                {
                    continue;
                }

                if (itemconf.ItemQuality < 4)
                {
                    continue;
                }

                self.ShowBagInfos.Add(bagInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static async ETTask OnPointerDown(this ES_RoleXiLianTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = true;
            EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = $"1_{binfo.BagInfoID}" });
            await self.Root().GetComponent<TimerComponent>().WaitAsync(400);
            if (!self.IsHoldDown)
                return;

            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = binfo,
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new List<ItemInfo>()
                });
        }

        public static void OnPointerUp(this ES_RoleXiLianTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
        }

        public static void BeginDrag(this ES_RoleXiLianTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.ES_CommonItem_Copy.uiTransform.gameObject.SetActive(true);

            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(binfo.ItemID);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.ES_CommonItem_Copy.E_ItemIconImage.sprite = sp;
            self.ES_CommonItem_Copy.E_ItemQualityImage.gameObject.SetActive(false);
            self.ES_CommonItem_Copy.E_BindingImage.gameObject.SetActive(false);
        }

        public static void Draging(this ES_RoleXiLianTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            RectTransform canvas = self.ES_CommonItem_Copy.uiTransform.parent.parent.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out self.localPoint);

            self.ES_CommonItem_Copy.uiTransform.localPosition = new Vector3(self.localPoint.x, self.localPoint.y, 0f);
        }

        public static bool IsSelcted(this ES_RoleXiLianTransfer self, long baginfoId)
        {
            long selctedId_1 = self.BagInfo_Transfer[0] != null? self.BagInfo_Transfer[0].BagInfoID : 0;
            long selctedId_2 = self.BagInfo_Transfer[1] != null? self.BagInfo_Transfer[1].BagInfoID : 0;
            return baginfoId == selctedId_1 || baginfoId == selctedId_2;
        }

        public static void UpdateSelected(this ES_RoleXiLianTransfer self)
        {
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    long bagInfoId = item.Baginfo.BagInfoID;
                    bool selected = self.IsSelcted(bagInfoId);
                    item.E_XuanZhongImage.gameObject.SetActive(selected);
                }
            }
        }

        public static void EndDrag(this ES_RoleXiLianTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            RectTransform canvas = self.ES_CommonItem_Copy.uiTransform.parent.parent.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (!name.Contains("UIRoleXiLianTransferItem_"))
                {
                    continue;
                }

                if (self.IsSelcted(binfo.BagInfoID))
                {
                    self.ResetSelect();
                }

                int index = int.Parse(name.Split('_')[1]);
                self.BagInfo_Transfer[index] = binfo;
                ES_CommonItem esCommonItem = self.UIItem_Transfer[index];
                esCommonItem.uiTransform.gameObject.SetActive(true);
                esCommonItem.UpdateItem(binfo, ItemOperateEnum.None);
                esCommonItem.HideItemNumber();
                break;
            }

            self.ES_CommonItem_Copy.uiTransform.gameObject.SetActive(false);

            self.UpdateSelected();
        }
    }
}
