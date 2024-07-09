using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgJiaYuanPetFeed: Entity, IAwake, IUILogic
    {
        public DlgJiaYuanPetFeedViewComponent View
        {
            get => this.GetComponent<DlgJiaYuanPetFeedViewComponent>();
        }

        public GameObject[] MoodList = new GameObject[5];
        public ES_CommonItem[] CostItemList = new ES_CommonItem[3];
        public JiaYuanPet JiaYuanPet;
        public bool IsHoldDown;
        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
        public List<BagInfo> ShowBagInfos = new();
    }
}