using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPetHeXinHeCheng: Entity, IAwake, IUILogic
    {
        public DlgPetHeXinHeChengViewComponent View
        {
            get => this.GetComponent<DlgPetHeXinHeChengViewComponent>();
        }

        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
        public List<BagInfo> ShowBagInfos = new();
        public ETCancellationToken cancellationToken;
        public bool IsHoldDown;
        public BagInfo BagInfo;
        public GameObject BagItemCopy;
    }
}