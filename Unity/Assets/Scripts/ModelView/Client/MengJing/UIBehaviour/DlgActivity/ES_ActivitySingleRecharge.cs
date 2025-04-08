using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivitySingleRecharge : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<ActivityConfig> ShowItem = new();
		public Dictionary<int, EntityRef<Scroll_Item_ActivitySingleRechargeItem>> ScrollItemActivitySingleRechargeItems;
		
        
		public LoopVerticalScrollRect E_ActivitySingleRechargeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivitySingleRechargeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ActivitySingleRechargeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ActivitySingleRechargeItems");
     			}
     			return this.m_E_ActivitySingleRechargeItemsLoopVerticalScrollRect;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_ActivitySingleRechargeItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_ActivitySingleRechargeItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
