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

		public ItemInfo BagInfo_Equip { get; set; }
		public ItemInfo BagInfo_Appri { get; set; }
		public int AppraisalItemConfigId { get; set; }
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
	}
}
