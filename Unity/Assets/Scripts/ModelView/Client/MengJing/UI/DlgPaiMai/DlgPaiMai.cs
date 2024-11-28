using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgPaiMaiViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPaiMai : Entity, IAwake, IUILogic
    {
        public DlgPaiMaiViewComponent View
        {
            get => this.GetComponent<DlgPaiMaiViewComponent>();
        }

        public Dictionary<long, PaiMaiShopItemInfo> PaiMaiShopItemInfos { get; set; } = new();
    }
}