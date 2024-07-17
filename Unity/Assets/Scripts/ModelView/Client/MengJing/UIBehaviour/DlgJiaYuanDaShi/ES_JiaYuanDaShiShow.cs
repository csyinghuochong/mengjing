using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanDaShiShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<int> ShowIndex = new();
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanDaShiShowItem>> ScrollItemJiaYuanDaShiShowItems;
		
		public LoopVerticalScrollRect E_JiaYuanDaShiShowItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanDaShiShowItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanDaShiShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanDaShiShowItems");
     			}
     			return this.m_E_JiaYuanDaShiShowItemsLoopVerticalScrollRect;
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
			this.m_E_JiaYuanDaShiShowItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_JiaYuanDaShiShowItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
