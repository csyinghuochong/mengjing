using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDamageValue :Entity,IAwake,IUILogic
	{

		public DlgDamageValueViewComponent View { get => this.GetComponent<DlgDamageValueViewComponent>();} 

		 
		public Dictionary<int, EntityRef<Scroll_Item_DamageValueItem>> ScrollItemRechargeItems;
		public List<DamageValueInfo> DamageValueList;
	}
}
