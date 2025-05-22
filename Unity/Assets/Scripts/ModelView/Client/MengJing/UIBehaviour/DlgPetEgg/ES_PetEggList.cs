
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetEggList : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public Dictionary<int, EntityRef<Scroll_Item_PetEggSelectItem>> ScrollItemPetEggSelectItems = new();
		public List<EntityRef<ES_PetEggListItem>> PetList = new();
		public List<string> AssetList { get; set; } = new();
		
		public UnityEngine.UI.Text E_PetEggNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEggNumText == null )
     			{
		    		this.m_E_PetEggNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_PetEggNum");
     			}
     			return this.m_E_PetEggNumText;
     		}
     	}

		public UnityEngine.RectTransform EG_PetNodeListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetNodeListRectTransform == null )
     			{
		    		this.m_EG_PetNodeListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_PetNodeList");
     			}
     			return this.m_EG_PetNodeListRectTransform;
     		}
     	}

		public ES_PetEggListItem ES_PetEggListItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetEggListItem es = this.m_es_petegglistitem;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_PetNodeList/ES_PetEggListItem");
		    	   this.m_es_petegglistitem = this.AddChild<ES_PetEggListItem,Transform>(subTrans);
     			}
     			return this.m_es_petegglistitem;
     		}
     	}

		public UnityEngine.RectTransform EG_PetEggSelectRootRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetEggSelectRootRectTransform == null )
     			{
		    		this.m_EG_PetEggSelectRootRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetEggSelectRoot");
     			}
     			return this.m_EG_PetEggSelectRootRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ClosePetEggSelectButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ClosePetEggSelectButton == null )
     			{
		    		this.m_E_Btn_ClosePetEggSelectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PetEggSelectRoot/E_Btn_ClosePetEggSelect");
     			}
     			return this.m_E_Btn_ClosePetEggSelectButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ClosePetEggSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ClosePetEggSelectImage == null )
     			{
		    		this.m_E_Btn_ClosePetEggSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PetEggSelectRoot/E_Btn_ClosePetEggSelect");
     			}
     			return this.m_E_Btn_ClosePetEggSelectImage;
     		}
     	}

		public UnityEngine.UI.Image E_PetEggSelectPanelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEggSelectPanelImage == null )
     			{
		    		this.m_E_PetEggSelectPanelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PetEggSelectRoot/E_PetEggSelectPanel");
     			}
     			return this.m_E_PetEggSelectPanelImage;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_PetEggSelectItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEggSelectItemsScrollRect == null )
     			{
		    		this.m_E_PetEggSelectItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"EG_PetEggSelectRoot/E_PetEggSelectPanel/E_PetEggSelectItems");
     			}
     			return this.m_E_PetEggSelectItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_PetEggSelectItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEggSelectItemsImage == null )
     			{
		    		this.m_E_PetEggSelectItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PetEggSelectRoot/E_PetEggSelectPanel/E_PetEggSelectItems");
     			}
     			return this.m_E_PetEggSelectItemsImage;
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
			this.m_E_PetEggNumText = null;
			this.m_EG_PetNodeListRectTransform = null;
			this.m_es_petegglistitem = null;
			this.m_EG_PetEggSelectRootRectTransform = null;
			this.m_E_Btn_ClosePetEggSelectButton = null;
			this.m_E_Btn_ClosePetEggSelectImage = null;
			this.m_E_PetEggSelectPanelImage = null;
			this.m_E_PetEggSelectItemsScrollRect = null;
			this.m_E_PetEggSelectItemsImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_PetEggNumText = null;
		private UnityEngine.RectTransform m_EG_PetNodeListRectTransform = null;
		private EntityRef<ES_PetEggListItem> m_es_petegglistitem = null;
		private UnityEngine.RectTransform m_EG_PetEggSelectRootRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_ClosePetEggSelectButton = null;
		private UnityEngine.UI.Image m_E_Btn_ClosePetEggSelectImage = null;
		private UnityEngine.UI.Image m_E_PetEggSelectPanelImage = null;
		private UnityEngine.UI.ScrollRect m_E_PetEggSelectItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_PetEggSelectItemsImage = null;
		public Transform uiTransform = null;
	}
}
