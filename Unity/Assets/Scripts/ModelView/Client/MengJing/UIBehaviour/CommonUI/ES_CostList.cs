using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_CostList : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<BagInfo> ShowBagInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonCostItem>> ScrollItemCommonCostItems;
		
		public LoopVerticalScrollRect E_CostItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CostItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_CostItems");
     			}
     			return this.m_E_CostItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CostItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_CostItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
