using System.Collections.Generic;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgItemFumoSelect : Entity, IAwake, IUILogic
    {
        public DlgItemFumoSelectViewComponent View { get => this.GetComponent<DlgItemFumoSelectViewComponent>(); }

        private EntityRef<ItemInfo> fumoItemInfo;
        public ItemInfo FumoItemInfo { get => this.fumoItemInfo; set => this.fumoItemInfo = value; }
        public List<Text> TextFomoPro = new();
        public List<EntityRef<ES_CommonItem>> ItemList = new();
        public List<ItemInfo> BagInfos { get; set; } = new();
    }
}