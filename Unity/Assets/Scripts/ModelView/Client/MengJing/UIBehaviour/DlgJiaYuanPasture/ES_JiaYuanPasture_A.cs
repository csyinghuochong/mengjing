using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanPasture_A : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<MysteryItemInfo> ShowMysteryItemInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanPastureItem_A>> ScrollItemJiaYuanPastureItemAs;
		
		public LoopVerticalScrollRect E_JiaYuanPastureItem_AsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanPastureItem_AsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanPastureItem_AsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanPastureItem_As");
     			}
     			return this.m_E_JiaYuanPastureItem_AsLoopVerticalScrollRect;
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
			this.m_E_JiaYuanPastureItem_AsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_JiaYuanPastureItem_AsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
