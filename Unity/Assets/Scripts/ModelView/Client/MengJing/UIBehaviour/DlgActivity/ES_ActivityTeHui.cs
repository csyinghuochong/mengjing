
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityTeHui : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_ActivityTeHuiItem>> ScrollItemActivityTeHuiItems;
		
		public UnityEngine.UI.LoopHorizontalScrollRect E_ActivityTeHuiItemsLoopHorizontalScrollRect
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
		    		this.m_E_ActivityTeHuiItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_ActivityTeHuiItems");
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

		private UnityEngine.UI.LoopHorizontalScrollRect m_E_ActivityTeHuiItemsLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
