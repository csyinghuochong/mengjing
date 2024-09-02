using System.Collections.Generic;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgItemFumoSelect : Entity, IAwake, IUILogic
    {
        public DlgItemFumoSelectViewComponent View { get => this.GetComponent<DlgItemFumoSelectViewComponent>(); }

        public ItemInfo FumoItemInfo { get; set; }
        public List<Text> TextFomoPro = new();
        public List<EntityRef<ES_CommonItem>> ItemList = new();
        public List<ItemInfo> BagInfos { get; set; } = new();
    }
}