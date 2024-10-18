using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetHeXinHeCheng : Entity, IAwake, IUILogic
    {
        public DlgPetHeXinHeChengViewComponent View
        {
            get => this.GetComponent<DlgPetHeXinHeChengViewComponent>();
        }

        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
        public List<ItemInfo> ShowBagInfos { get; set; } = new();
        public ETCancellationToken cancellationToken;
        public bool IsHoldDown;
        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
        public GameObject BagItemCopy;
    }
}