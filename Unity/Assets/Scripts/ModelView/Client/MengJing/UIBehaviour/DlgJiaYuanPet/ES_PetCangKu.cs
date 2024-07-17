using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetCangKu : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<RolePetInfo> ShowRolePetInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_PetCangKuItem>> ScrollItemPetCangKuItems;
		public List<(int, int)> ShowCangkuDefends = new();
		public Dictionary<int, EntityRef<Scroll_Item_PetCangKuDefend>> ScrollItemPetCangKuDefends;
		
		public LoopVerticalScrollRect E_PetCangKuItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetCangKuItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetCangKuItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetCangKuItems");
     			}
     			return this.m_E_PetCangKuItemsLoopVerticalScrollRect;
     		}
     	}

		public LoopVerticalScrollRect E_PetCangKuDefendsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetCangKuDefendsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetCangKuDefendsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PetCangKuDefends");
     			}
     			return this.m_E_PetCangKuDefendsLoopVerticalScrollRect;
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
			this.m_E_PetCangKuItemsLoopVerticalScrollRect = null;
			this.m_E_PetCangKuDefendsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_PetCangKuItemsLoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_PetCangKuDefendsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
