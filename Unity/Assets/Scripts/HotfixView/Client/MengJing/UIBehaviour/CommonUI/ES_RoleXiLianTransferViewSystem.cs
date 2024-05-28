using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
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
            self.BagInfo_Transfer = new BagInfo[2];
            self.UIItem_Transfer = new ES_CommonItem[2];
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_ButtonTransferButton.AddListenerAsync(self.OnButtonTransfer);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianTransfer self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_RoleXiLianTransfer self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
        }

        public static async ETTask OnButtonTransfer(this ES_RoleXiLianTransfer self)
        {
            string costItem = GlobalValueConfigCategory.Instance.Get(51).Value;
            if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem(costItem))
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("材料不足！");
                return;
            }

            if (self.BagInfo_Transfer[0] == null || self.BagInfo_Transfer[1] == null)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请选择合适的装备转移！");
                return;
            }

            //圣光装备洗练继承功能 布甲只能继承布甲 同类型只能继承同类型
            ItemConfig itemConfig_0 = ItemConfigCategory.Instance.Get(self.BagInfo_Transfer[0].ItemID);
            ItemConfig itemConfig_1 = ItemConfigCategory.Instance.Get(self.BagInfo_Transfer[1].ItemID);

            //道具配置

            if (itemConfig_0.EquipType != itemConfig_1.EquipType)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("只有护甲类型相同的装备才能转移！");
                return;
            }

            if (itemConfig_0.ItemSubType != itemConfig_1.ItemSubType)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("只有相同部位的装备才能转移！");
                return;
            }

            //紫色品质以上才可以转移
            if (itemConfig_0.ItemQuality < 4 || itemConfig_1.ItemQuality < 4)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("只有紫色及以上品质的装备才能转移！");
                return;
            }

            //绑定装备无法转移
            if (self.BagInfo_Transfer[0].isBinging && self.BagInfo_Transfer[1].isBinging == false && itemConfig_1.ItemQuality == 4)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("绑定装备的洗炼属性无法转移至未绑定的装备！");
                return;
            }

            C2M_ItemXiLianTransferRequest request = new()
            {
                OperateBagID_1 = self.BagInfo_Transfer[0].BagInfoID, OperateBagID_2 = self.BagInfo_Transfer[1].BagInfoID
            };
            M2C_ItemXiLianTransferResponse response =
                    (M2C_ItemXiLianTransferResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            FlyTipComponent.Instance.SpawnFlyTipDi("装备属性转移成功！");
            self.OnUpdateUI();
        }

        public static void OnInitUI(this ES_RoleXiLianTransfer self)
        {
            self.UpdateCost();

            self.UIItem_Transfer[0] = self.ES_CommonItem_1;
            self.UIItem_Transfer[1] = self.ES_CommonItem_2;
            self.UIItem_Transfer[0].uiTransform.gameObject.SetActive(false);
            self.UIItem_Transfer[1].uiTransform.gameObject.SetActive(false);
        }

        public static void OnUpdateUI(this ES_RoleXiLianTransfer self)
        {
            self.UpdateCost();
            self.ResetSelect();
            self.UpdateSelected();
            self.UpdateEquipItemUI().Coroutine();
        }

        public static void UpdateCost(this ES_RoleXiLianTransfer self)
        {
            string[] costItem = GlobalValueConfigCategory.Instance.Get(51).Value.Split(';');
            self.ES_CommonItem_Cost.UpdateItem(int.Parse(costItem[0]), int.Parse(costItem[1]));
        }

        public static void ResetSelect(this ES_RoleXiLianTransfer self)
        {
            self.BagInfo_Transfer[0] = null;
            self.BagInfo_Transfer[1] = null;
            self.UIItem_Transfer[0].uiTransform.gameObject.SetActive(false);
            self.UIItem_Transfer[1].uiTransform.gameObject.SetActive(false);
        }

        public static void UpdateSelect(this ES_RoleXiLianTransfer self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            BagInfo bagInfo_1 = bagComponent.GetBagInfo(self.BagInfo_Transfer[0].BagInfoID);
            BagInfo bagInfo_2 = bagComponent.GetBagInfo(self.BagInfo_Transfer[1].BagInfoID);
            self.UIItem_Transfer[0].UpdateItem(bagInfo_1, ItemOperateEnum.None);
            self.UIItem_Transfer[1].UpdateItem(bagInfo_2, ItemOperateEnum.None);
        }

        public static async ETTask UpdateEquipItemUI(this ES_RoleXiLianTransfer self)
        {
            long instanceid = self.InstanceId;
            string path = ABPathHelper.GetUGUIPath("Main/Common/UICommonItem");
            GameObject bundleObj = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(path);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            int number = 0;
            List<BagInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
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

                UIItemComponent uIItemComponent = null;
                if (number < self.UIEquipList.Count)
                {
                    uIItemComponent = self.UIEquipList[number];
                    uIItemComponent.GameObject.SetActive(true);
                }
                else
                {
                    GameObject skillItem = GameObject.Instantiate(bundleObj);
                    UICommonHelper.SetParent(skillItem, self.ItemListNode);
                    uIItemComponent = self.AddChild<UIItemComponent, GameObject>(skillItem);
                    self.UIEquipList.Add(uIItemComponent);
                    uIItemComponent.SetEventTrigger(true);
                    uIItemComponent.BeginDragHandler = (BagInfo binfo, PointerEventData pdata) => { self.BeginDrag(binfo, pdata); };
                    uIItemComponent.DragingHandler = (BagInfo binfo, PointerEventData pdata) => { self.Draging(binfo, pdata); };
                    uIItemComponent.EndDragHandler = (BagInfo binfo, PointerEventData pdata) => { self.EndDrag(binfo, pdata); };
                    uIItemComponent.PointerDownHandler = (BagInfo binfo, PointerEventData pdata) => { self.OnPointerDown(binfo, pdata).Coroutine(); };
                    uIItemComponent.PointerUpHandler = (BagInfo binfo, PointerEventData pdata) => { self.OnPointerUp(binfo, pdata); };
                }

                uIItemComponent.UpdateItem(bagInfos[i], ItemOperateEnum.SkillSet);
                uIItemComponent.Image_XuanZhong.SetActive(false);
                number++;
            }

            for (int i = number; i < self.UIEquipList.Count; i++)
            {
                self.UIEquipList[i].GameObject.SetActive(false);
            }
        }

        public static async ETTask OnPointerDown(this ES_RoleXiLianTransfer self, BagInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = true;
            HintHelp.GetInstance().DataUpdate(LightingExplorerTableColumn.DataType.HuiShouSelect, $"1_{binfo.BagInfoID}");
            await TimerComponent.Instance.WaitAsync(400);
            if (!self.IsHoldDown)
                return;
            EventType.ShowItemTips.Instance.ZoneScene = self.DomainScene();
            EventType.ShowItemTips.Instance.bagInfo = binfo;
            EventType.ShowItemTips.Instance.itemOperateEnum = ItemOperateEnum.None;
            EventType.ShowItemTips.Instance.inputPoint = Input.mousePosition;
            EventType.ShowItemTips.Instance.Occ = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.Occ;
            Game.EventSystem.PublishClass(EventType.ShowItemTips.Instance);
        }

        public static void OnPointerUp(this ES_RoleXiLianTransfer self, BagInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            UIHelper.Remove(self.DomainScene(), UIType.UIEquipDuiBiTips);
        }

        public static void BeginDrag(this ES_RoleXiLianTransfer self, BagInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.UICommonItem_Copy = GameObject.Instantiate(self.UICommonItem_1);
            self.UICommonItem_Copy.SetActive(true);
            UICommonHelper.SetParent(self.UICommonItem_Copy, UIEventComponent.Instance.UILayers[(int)UILayer.Low].gameObject);

            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(binfo.ItemID);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = ResourcesComponent.Instance.LoadAsset<Sprite>(path);
            if (!self.AssetPath.Contains(path))
            {
                self.AssetPath.Add(path);
            }

            self.UICommonItem_Copy.transform.Find("Image_ItemIcon").GetComponent<Image>().sprite = sp;
            self.UICommonItem_Copy.transform.Find("Image_ItemQuality").gameObject.SetActive(false);
            self.UICommonItem_Copy.transform.Find("Image_Binding").gameObject.SetActive(false);
        }

        public static void Draging(this ES_RoleXiLianTransfer self, BagInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            RectTransform canvas = self.UICommonItem_Copy.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.DomainScene().GetComponent<UIComponent>().UICamera;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out self.localPoint);

            self.UICommonItem_Copy.transform.localPosition = new Vector3(self.localPoint.x, self.localPoint.y, 0f);
        }

        public static bool IsSelcted(this ES_RoleXiLianTransfer self, long baginfoId)
        {
            long selctedId_1 = self.BagInfo_Transfer[0] != null? self.BagInfo_Transfer[0].BagInfoID : 0;
            long selctedId_2 = self.BagInfo_Transfer[1] != null? self.BagInfo_Transfer[1].BagInfoID : 0;
            return baginfoId == selctedId_1 || baginfoId == selctedId_2;
        }

        public static void UpdateSelected(this ES_RoleXiLianTransfer self)
        {
            for (int i = 0; i < self.UIEquipList.Count; i++)
            {
                long bagInfoId = self.UIEquipList[i].Baginfo.BagInfoID;
                bool selected = self.IsSelcted(bagInfoId);
                self.UIEquipList[i].Image_XuanZhong.SetActive(selected);
            }
        }

        public static void EndDrag(this ES_RoleXiLianTransfer self, BagInfo binfo, PointerEventData pdata)
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
                self.UIItem_Transfer[index].GameObject.SetActive(true);
                self.UIItem_Transfer[index].UpdateItem(binfo, ItemOperateEnum.None);
                break;
            }

            if (self.UICommonItem_Copy != null)
            {
                GameObject.Destroy(self.UICommonItem_Copy);
                self.UICommonItem_Copy = null;
            }

            self.UpdateSelected();
        }
    }
}