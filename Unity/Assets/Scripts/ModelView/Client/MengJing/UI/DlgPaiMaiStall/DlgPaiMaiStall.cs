using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPaiMaiStall :Entity,IAwake,IUILogic
	{

		public DlgPaiMaiStallViewComponent View { get => this.GetComponent<DlgPaiMaiStallViewComponent>();}


		public PaiMaiItemInfo PaiMaiItemInfo;
		public Dictionary<int, EntityRef<Scroll_Item_PaiMaiStallItem>> ScrollItemPaiMaiSellItems;
		public List<PaiMaiItemInfo> ShowPaiMaiItemInfos = new();
		public long UserId;

	}
}
