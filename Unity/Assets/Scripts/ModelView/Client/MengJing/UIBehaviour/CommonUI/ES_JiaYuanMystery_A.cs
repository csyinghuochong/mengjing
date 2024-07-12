
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanMystery_A : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public List<MysteryItemInfo> ShowMysteryItemInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanMysteryItem_A>> ScrollItemJiaYuanMysteryItemAs;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_JiaYuanMysteryItem_AsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanMysteryItem_AsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanMysteryItem_AsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanMysteryItem_As");
     			}
     			return this.m_E_JiaYuanMysteryItem_AsLoopVerticalScrollRect;
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
			this.m_E_JiaYuanMysteryItem_AsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_JiaYuanMysteryItem_AsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
