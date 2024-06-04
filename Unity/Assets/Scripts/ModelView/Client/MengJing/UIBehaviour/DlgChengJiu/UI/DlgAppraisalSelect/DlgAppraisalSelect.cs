using System.Collections.Generic;

namespace ET.Client
{
	[ComponentOf(typeof (UIBaseWindow))]
	public class DlgAppraisalSelect: Entity, IAwake, IUILogic
	{

		public DlgAppraisalSelectViewComponent View
		{
			get => this.GetComponent<DlgAppraisalSelectViewComponent>();
		}

		public BagInfo BagInfo_Equip;
		public BagInfo BagInfo_Appri;
		public int AppraisalItemConfigId;
		public List<BagInfo> ShowBagInfos = new();
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
	}
}
