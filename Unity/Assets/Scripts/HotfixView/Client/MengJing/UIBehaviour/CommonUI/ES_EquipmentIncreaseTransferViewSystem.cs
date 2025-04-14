using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [EntitySystemOf(typeof(ES_EquipmentIncreaseTransfer))]
    [FriendOfAttribute(typeof(ES_EquipmentIncreaseTransfer))]
    public static partial class ES_EquipmentIncreaseTransferSystem
    {
        [EntitySystem]
        private static void Awake(this ES_EquipmentIncreaseTransfer self, Transform transform)
        {
            self.uiTransform = transform;

            self.IsHoldDown = false;
            self.BagInfo_Transfer = new ItemInfo[2];
            self.UIItem_Transfer = new ES_CommonItem[2];
            self.E_ButtonTransferButton.AddListenerAsync(self.OnButtonTransferButton);
            self.E_EquipItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnEquipItemsRefresh);

            self.UIItem_Transfer[0] = self.ES_CommonItem_1;
            self.UIItem_Transfer[1] = self.ES_CommonItem_2;
            self.ES_CommonItem_1.uiTransform.gameObject.SetActive(false);
            self.ES_CommonItem_2.uiTransform.gameObject.SetActive(false);
            self.UpdateCost();
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipmentIncreaseTransfer self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonTransferButton(this ES_EquipmentIncreaseTransfer self)
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

            bool ifMovePro = ItemHelper.IsHaveMovePro(self.BagInfo_Transfer[0]);

            if (!ifMovePro)
            {
                FlyTipComponent.Instance.ShowFlyTip("左侧装备未拥有传承增幅！");
                return;
            }

            //圣光装备洗练继承功能 布甲只能继承布甲 同类型只能继承同类型
            ItemConfig itemConfig_0 = ItemConfigCategory.Instance.Get(self.BagInfo_Transfer[0].ItemID);
            ItemConfig itemConfig_1 = ItemConfigCategory.Instance.Get(self.BagInfo_Transfer[1].ItemID);

            //紫色品质以上才可以转移
            if (itemConfig_0.ItemQuality < 4 || itemConfig_1.ItemQuality < 4)
            {
                FlyTipComponent.Instance.ShowFlyTip("只有紫色及以上品质的装备才能转移！");
                return;
            }

            //绑定装备无法转移
            if (self.BagInfo_Transfer[0].isBinging && self.BagInfo_Transfer[1].isBinging == false && itemConfig_1.ItemQuality == 4)
            {
                FlyTipComponent.Instance.ShowFlyTip("绑定装备的增幅属性无法转移至未绑定的装备！");
                return;
            }

            int error = await BagClientNetHelper.ItemIncreaseTransferRequest(self.Root(), self.BagInfo_Transfer[0], self.BagInfo_Transfer[1]);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("装备属性转移成功！");
            self.OnUpdateUI();
        }

        public static void OnUpdateUI(this ES_EquipmentIncreaseTransfer self)
        {
            self.UpdateCost();
            self.ResetSelect();
            self.UpdateSelected();
            self.UpdateEquipItemUI();
        }

        public static void UpdateCost(this ES_EquipmentIncreaseTransfer self)
        {
            self.ES_CostList.Refresh(GlobalValueConfigCategory.Instance.Get(51).Value);
        }

        public static void ResetSelect(this ES_EquipmentIncreaseTransfer self)
        {
            self.BagInfo_Transfer[0] = null;
            self.BagInfo_Transfer[1] = null;
            self.UIItem_Transfer[0].uiTransform.gameObject.SetActive(false);
            self.UIItem_Transfer[1].uiTransform.gameObject.SetActive(false);
        }

        public static void UpdateSelect(this ES_EquipmentIncreaseTransfer self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemInfo bagInfo_1 = bagComponent.GetBagInfo(self.BagInfo_Transfer[0].BagInfoID);
            ItemInfo bagInfo_2 = bagComponent.GetBagInfo(self.BagInfo_Transfer[1].BagInfoID);
            self.UIItem_Transfer[0].UpdateItem(bagInfo_1, ItemOperateEnum.None);
            self.UIItem_Transfer[1].UpdateItem(bagInfo_2, ItemOperateEnum.None);
        }

        private static void OnEquipItemsRefresh(this ES_EquipmentIncreaseTransfer self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemEquipItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemEquipItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowEquipBagInfos[index], ItemOperateEnum.SkillSet);

            scrollItemCommonItem.SetEventTrigger(true);
            scrollItemCommonItem.BeginDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.BeginDrag(binfo, pdata); };
            scrollItemCommonItem.DragingHandler = (ItemInfo binfo, PointerEventData pdata) => { self.Draging(binfo, pdata); };
            scrollItemCommonItem.EndDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.EndDrag(binfo, pdata); };
            scrollItemCommonItem.PointerDownHandler = (ItemInfo binfo, PointerEventData pdata) =>
            {
                self.OnPointerDown(binfo, pdata).Coroutine();
            };
            scrollItemCommonItem.PointerUpHandler = (ItemInfo binfo, PointerEventData pdata) => { self.OnPointerUp(binfo, pdata); };
        }

        public static void UpdateEquipItemUI(this ES_EquipmentIncreaseTransfer self)
        {
            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            self.ShowEquipBagInfos.Clear();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                int itemID = bagInfos[i].ItemID;
                ItemConfig itemconf = ItemConfigCategory.Instance.Get(itemID);
                if (itemconf.ItemType != (int)ItemTypeEnum.Equipment || bagInfos[i].IfJianDing)
                {
                    continue;
                }

                if (itemconf.EquipType == 101 || itemconf.EquipType == 201)
                {
                    continue;
                }

                if (itemconf.ItemQuality < 4)
                {
                    continue;
                }

                self.ShowEquipBagInfos.Add(bagInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemEquipItems, self.ShowEquipBagInfos.Count);
            self.E_EquipItemsLoopVerticalScrollRect.SetVisible(true, self.ShowEquipBagInfos.Count);
        }

        public static async ETTask OnPointerDown(this ES_EquipmentIncreaseTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = true;
            EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = $"1_{binfo.BagInfoID}" });

            await self.Root().GetComponent<TimerComponent>().WaitAsync(400);
            if (!self.IsHoldDown)
                return;
            EventSystem.Instance.Publish(self.Root(), new ShowItemTips()
            {
                BagInfo = binfo,
                ItemOperateEnum = ItemOperateEnum.None,
                InputPoint = Input.mousePosition,
                Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                EquipList = new List<ItemInfo>(),
            });
        }

        public static void OnPointerUp(this ES_EquipmentIncreaseTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
        }

        public static void BeginDrag(this ES_EquipmentIncreaseTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.UICommonItem_Copy = UnityEngine.Object.Instantiate(self.ES_CommonItem_1.uiTransform.gameObject);
            self.UICommonItem_Copy.SetActive(true);
            CommonViewHelper.SetParent(self.UICommonItem_Copy, self.uiTransform.parent.parent.gameObject);

            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(binfo.ItemID);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.UICommonItem_Copy.transform.Find("E_ItemIcon").GetComponent<Image>().sprite = sp;
            self.UICommonItem_Copy.transform.Find("E_ItemIcon").gameObject.SetActive(true);
            self.UICommonItem_Copy.transform.Find("E_ItemQuality").gameObject.SetActive(false);
            self.UICommonItem_Copy.transform.Find("E_Binding").gameObject.SetActive(false);
        }

        public static void Draging(this ES_EquipmentIncreaseTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            RectTransform canvas = self.UICommonItem_Copy.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = GlobalComponent.Instance.UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out self.localPoint);

            self.UICommonItem_Copy.transform.localPosition = new Vector3(self.localPoint.x, self.localPoint.y, 0f);
        }

        public static bool IsSelcted(this ES_EquipmentIncreaseTransfer self, long baginfoId)
        {
            long selctedId_1 = self.BagInfo_Transfer[0] != null ? self.BagInfo_Transfer[0].BagInfoID : 0;
            long selctedId_2 = self.BagInfo_Transfer[1] != null ? self.BagInfo_Transfer[1].BagInfoID : 0;
            return baginfoId == selctedId_1 || baginfoId == selctedId_2;
        }

        public static void UpdateSelected(this ES_EquipmentIncreaseTransfer self)
        {
            if (self.ScrollItemEquipItems != null)
            {
                foreach (var value in self.ScrollItemEquipItems.Values)
                {
                    Scroll_Item_CommonItem item = value;
                    if (item.uiTransform != null)
                    {
                        long bagInfoId = item.Baginfo.BagInfoID;
                        bool selected = self.IsSelcted(bagInfoId);
                        item.E_XuanZhongImage.gameObject.SetActive(selected);
                    }
                }
            }
        }

        public static void EndDrag(this ES_EquipmentIncreaseTransfer self, ItemInfo binfo, PointerEventData pdata)
        {
            RectTransform canvas = self.UICommonItem_Copy.transform.parent.GetComponent<RectTransform>();
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
                self.UIItem_Transfer[index].uiTransform.gameObject.SetActive(true);
                self.UIItem_Transfer[index].UpdateItem(binfo, ItemOperateEnum.None);
                break;
            }

            if (self.UICommonItem_Copy != null)
            {
                UnityEngine.Object.Destroy(self.UICommonItem_Copy);
                self.UICommonItem_Copy = null;
            }

            self.UpdateSelected();
        }
    }
}
