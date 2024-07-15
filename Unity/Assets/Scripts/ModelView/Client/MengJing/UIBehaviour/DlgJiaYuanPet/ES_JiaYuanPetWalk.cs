
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_JiaYuanPetWalk : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_JiaYuanPetWalkItem>> ScrollItemJiaYuanPetWalkItems;
		public int Position;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_JiaYuanPetWalkItemsLoopVerticalScrollRect
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
		    		this.m_E_JiaYuanPetWalkItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JiaYuanPetWalkItems");
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

		private UnityEngine.UI.LoopVerticalScrollRect m_E_JiaYuanPetWalkItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
