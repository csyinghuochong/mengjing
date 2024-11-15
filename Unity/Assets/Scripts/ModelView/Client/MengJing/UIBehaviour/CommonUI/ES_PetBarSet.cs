
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBarSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		public long ClickTime;
		public bool IsDrag;
		public Dictionary<int, EntityRef<Scroll_Item_PetbarSetPetItem>> ScrollItemPetbarSetPetItems;
		
		public UnityEngine.UI.ToggleGroup E_PlanSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlanSetToggleGroup == null )
     			{
		    		this.m_E_PlanSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_PlanSet");
     			}
     			return this.m_E_PlanSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_PetTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetTypeSetToggleGroup == null )
     			{
		    		this.m_E_PetTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_PetTypeSet");
     			}
     			return this.m_E_PetTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetbarSetPetItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetbarSetPetItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetbarSetPetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_PetbarSetPetItems");
     			}
     			return this.m_E_PetbarSetPetItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmButton == null )
     			{
		    		this.m_E_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Confirm");
     			}
     			return this.m_E_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmImage == null )
     			{
		    		this.m_E_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Confirm");
     			}
     			return this.m_E_ConfirmImage;
     		}
     	}

		public UnityEngine.UI.Image E_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconImage == null )
     			{
		    		this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Icon");
     			}
     			return this.m_E_IconImage;
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
			this.m_E_PlanSetToggleGroup = null;
			this.m_E_PetTypeSetToggleGroup = null;
			this.m_E_PetbarSetPetItemsLoopVerticalScrollRect = null;
			this.m_E_ConfirmButton = null;
			this.m_E_ConfirmImage = null;
			this.m_E_IconImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_PlanSetToggleGroup = null;
		private UnityEngine.UI.ToggleGroup m_E_PetTypeSetToggleGroup = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetbarSetPetItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ConfirmButton = null;
		private UnityEngine.UI.Image m_E_ConfirmImage = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		public Transform uiTransform = null;
	}
}
