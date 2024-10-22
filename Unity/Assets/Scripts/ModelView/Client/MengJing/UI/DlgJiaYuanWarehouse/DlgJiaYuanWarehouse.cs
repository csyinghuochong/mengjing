using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanWarehouse : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanWarehouseViewComponent View
        {
            get => this.GetComponent<DlgJiaYuanWarehouseViewComponent>();
        }

        public List<GameObject> LockList = new();
        public List<GameObject> NoLockList = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemHouseItems;
        public List<EntityRef<ItemInfo>> ShowHouseBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemBagItems;
        public List<EntityRef<ItemInfo>> ShowBagBagInfos { get; set; } = new();
    }
}