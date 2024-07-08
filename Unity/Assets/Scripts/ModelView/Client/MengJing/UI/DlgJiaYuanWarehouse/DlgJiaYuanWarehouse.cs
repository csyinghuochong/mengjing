using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgJiaYuanWarehouse: Entity, IAwake, IUILogic
    {
        public DlgJiaYuanWarehouseViewComponent View
        {
            get => this.GetComponent<DlgJiaYuanWarehouseViewComponent>();
        }

        public List<GameObject> LockList = new();
        public List<GameObject> NoLockList = new();
        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemHouseItems;
        public List<BagInfo> ShowHouseBagInfos = new();
        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemBagItems;
        public List<BagInfo> ShowBagBagInfos = new();
    }
}