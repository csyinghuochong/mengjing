using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanDaShiProItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_JiaYuanDaShiPro))]
    [FriendOfAttribute(typeof(ES_JiaYuanDaShiPro))]
    public static partial class ES_JiaYuanDaShiProSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanDaShiPro self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonItemsRefresh);
            self.E_JiaYuanDaShiProItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJiaYuanDaShiProItemsRefresh);
            self.E_ButtonEatButton.AddListenerAsync(self.OnButtonEatButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanDaShiPro self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_JiaYuanDaShiPro self)
        {
            self.OnUpdateProList();
            self.OnUpdateItemList();
        }

        private static void OnJiaYuanDaShiProItemsRefresh(this ES_JiaYuanDaShiPro self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanDaShiProItem item in self.ScrollItemJiaYuanDaShiProItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanDaShiProItem scrollItemJiaYuanDaShiProItem = self.ScrollItemJiaYuanDaShiProItems[index].BindTrans(transform);

            string[] proinfo = self.ShowProlist[index].Split(',');
            scrollItemJiaYuanDaShiProItem.OnUpdateUI(self.Root().GetComponent<JiaYuanComponentC>().GetDaShiProInfo(int.Parse(proinfo[0])),
                self.ShowProlist[index]);
        }

        public static void OnUpdateProList(this ES_JiaYuanDaShiPro self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(userInfo.JiaYuanLv);

            string proMax = jiaYuanConfig.ProMax;
            string[] prolist = proMax.Split(';');
            self.ShowProlist.Clear();
            for (int i = 0; i < prolist.Length; i++)
            {
                if (CommonHelp.IfNull(prolist[i]))
                {
                    continue;
                }

                string[] proinfo = prolist[i].Split(',');
                if (proinfo.Length < 2)
                {
                    continue;
                }

                self.ShowProlist.Add(prolist[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemJiaYuanDaShiProItems, self.ShowProlist.Count);
            self.E_JiaYuanDaShiProItemsLoopVerticalScrollRect.SetVisible(true, self.ShowProlist.Count);
        }

        private static void OnCommonItemsRefresh(this ES_JiaYuanDaShiPro self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.None, self.OnSelectItem);
        }

        public static void OnUpdateItemList(this ES_JiaYuanDaShiPro self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            List<ItemInfo> bagInfos = bagComponent.GetBagList();
            self.ShowBagInfos.Clear();

            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemType != 1 || itemConfig.ItemSubType != 131)
                {
                    continue;
                }

                if (itemConfig.ItemQuality == 1)
                {
                    continue;
                }

                self.ShowBagInfos.Add(bagInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void OnSelectItem(this ES_JiaYuanDaShiPro self, ItemInfo bagInfo)
        {
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.E_XuanZhongImage.gameObject.SetActive(item.Baginfo.BagInfoID == bagInfo.BagInfoID);
                }
            }

            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.text = "1";
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);

            ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.E_Label_TipsText.text = itemCof.ItemBlackDes;
        }

        public static async ETTask OnButtonEatButton(this ES_JiaYuanDaShiPro self)
        {
            ItemInfo bagInfo = self.ES_CommonItem.Baginfo;
            if (bagInfo == null)
            {
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetItemNumber(bagInfo.ItemID) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("道具数量不足！");
                return;
            }

            int index = 0;
            if (self.ScrollItemCommonItems != null)
            {
                for (int i = 0; i < self.ScrollItemCommonItems.Count; i++)
                {
                    Scroll_Item_CommonItem item = self.ScrollItemCommonItems[i];

                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    if (item.Baginfo.BagInfoID != self.ES_CommonItem.Baginfo.BagInfoID)
                    {
                        continue;
                    }

                    index = i;
                    break;
                }
            }

            List<long> ids = new List<long>() { bagInfo.BagInfoID };

            M2C_JiaYuanDaShiResponse response = await JiaYuanNetHelper.JiaYuanDaShiRequest(self.Root(), ids);

            if (self.IsDisposed || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            string asstips = "增加属性： ";
            using (zstring.Block())
            {
                for (int i = 0; i < response.JiaYuanProAdd.Count; i++)
                {
                    string pname = ItemViewHelp.GetAttributeName(response.JiaYuanProAdd[i].KeyId);
                    asstips += zstring.Format("{0}: +{1} ", pname, response.JiaYuanProAdd[i].Value);
                }
            }

            FlyTipComponent.Instance.ShowFlyTip(asstips);

            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            jiaYuanComponentC.JiaYuanProList_7 = response.JiaYuanProList;
            jiaYuanComponentC.JiaYuanDaShiTime_1 = response.JiaYuanDaShiTime;

            if (bagComponent.GetItemNumber(self.ES_CommonItem.Baginfo.ItemID) < 1)
            {
                self.ES_CommonItem.UpdateItem(null, ItemOperateEnum.None);
                self.ES_CommonItem.E_ItemQualityImage.gameObject.SetActive(false);
                self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(false);
            }

            self.OnUpdateUI();

            self.E_Label_TipsText.text = "";

            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index];
            if (scrollItemCommonItem.uiTransform.gameObject.activeSelf)
            {
                self.OnSelectItem(scrollItemCommonItem.Baginfo);
            }
            else if (index > 0)
            {
                Scroll_Item_CommonItem scrollItemCommonItem1 = self.ScrollItemCommonItems[index - 1];
                if (scrollItemCommonItem1.uiTransform.gameObject.activeSelf)
                {
                    self.OnSelectItem(scrollItemCommonItem1.Baginfo);
                }
            }
        }
    }
}