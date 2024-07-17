using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanCookbook : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<int> ShowFoods = new();
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanCookbookItem>> ScrollItemJiaYuanCookbookItems;
		
		public LoopVerticalScrollRect E_JiaYuanCookbookItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanCookbookItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanCookbookItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanCookbookItems");
     			}
     			return this.m_E_JiaYuanCookbookItemsLoopVerticalScrollRect;
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
			this.m_E_JiaYuanCookbookItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_JiaYuanCookbookItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
