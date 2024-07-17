using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanPetWalk : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanPetWalkItem>> ScrollItemJiaYuanPetWalkItems;
		public int Position;
		
		public LoopVerticalScrollRect E_JiaYuanPetWalkItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanPetWalkItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JiaYuanPetWalkItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanPetWalkItems");
     			}
     			return this.m_E_JiaYuanPetWalkItemsLoopVerticalScrollRect;
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
			this.m_E_JiaYuanPetWalkItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_JiaYuanPetWalkItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
