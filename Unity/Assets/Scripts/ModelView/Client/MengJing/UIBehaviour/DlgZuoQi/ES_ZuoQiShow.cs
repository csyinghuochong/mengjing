using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ZuoQiShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_ZuoQiShowItem>> ScrollItemZuoQiShowItems;
		public List<ZuoQiShowConfig> ShowZuoQiShowConfigs = new();
		
		public LoopHorizontalScrollRect E_ZuoQiShowItemsLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZuoQiShowItemsLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_ZuoQiShowItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_ZuoQiShowItems");
     			}
     			return this.m_E_ZuoQiShowItemsLoopHorizontalScrollRect;
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
			this.m_E_ZuoQiShowItemsLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopHorizontalScrollRect m_E_ZuoQiShowItemsLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
