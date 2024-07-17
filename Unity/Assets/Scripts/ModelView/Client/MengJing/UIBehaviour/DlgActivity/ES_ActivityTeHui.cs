using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityTeHui : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_ActivityTeHuiItem>> ScrollItemActivityTeHuiItems;
		
		public LoopHorizontalScrollRect E_ActivityTeHuiItemsLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivityTeHuiItemsLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_ActivityTeHuiItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_ActivityTeHuiItems");
     			}
     			return this.m_E_ActivityTeHuiItemsLoopHorizontalScrollRect;
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
			this.m_E_ActivityTeHuiItemsLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopHorizontalScrollRect m_E_ActivityTeHuiItemsLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
