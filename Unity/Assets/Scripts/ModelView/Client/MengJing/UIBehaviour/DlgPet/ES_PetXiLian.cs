using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetXiLian : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		private EntityRef<ItemInfo> costItemInfo;
		public ItemInfo CostItemInfo { get => this.costItemInfo; set => this.costItemInfo = value; }
		public RolePetInfo RolePetInfo;
		public Dictionary<int, EntityRef<Scroll_Item_PetListItem>> ScrollItemPetListItems;
		public List<RolePetInfo> ShowRolePetInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		
		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/E_UIPetInfo1/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetListItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetListItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetListItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_UIPetInfo1/E_PetListItems");
     			}
     			return this.m_E_PetListItemsLoopVerticalScrollRect;
     		}
     	}

		public ES_PetInfoShow ES_PetInfoShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetInfoShow es = this.m_es_petinfoshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/E_UIPetInfo1/ES_PetInfoShow");
		    	   this.m_es_petinfoshow = this.AddChild<ES_PetInfoShow,Transform>(subTrans);
     			}
     			return this.m_es_petinfoshow;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CommonItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_CommonItems");
     			}
     			return this.m_E_CommonItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XiLianButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianButton == null )
     			{
		    		this.m_E_Btn_XiLianButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_XiLian");
     			}
     			return this.m_E_Btn_XiLianButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XiLianImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianImage == null )
     			{
		    		this.m_E_Btn_XiLianImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_XiLian");
     			}
     			return this.m_E_Btn_XiLianImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_ItemQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ItemQualityImage == null )
     			{
		    		this.m_E_Img_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Img_ItemQuality");
     			}
     			return this.m_E_Img_ItemQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_ItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_ItemIconImage == null )
     			{
		    		this.m_E_Img_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Img_ItemIcon");
     			}
     			return this.m_E_Img_ItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ItemNameText == null )
     			{
		    		this.m_E_Text_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_ItemName");
     			}
     			return this.m_E_Text_ItemNameText;
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
			this.m_es_modelshow = null;
			this.m_E_PetListItemsLoopVerticalScrollRect = null;
			this.m_es_petinfoshow = null;
			this.m_E_CommonItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_XiLianButton = null;
			this.m_E_Btn_XiLianImage = null;
			this.m_E_Img_ItemQualityImage = null;
			this.m_E_Img_ItemIconImage = null;
			this.m_E_Text_ItemNameText = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetListItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_PetInfoShow> m_es_petinfoshow = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_XiLianButton = null;
		private UnityEngine.UI.Image m_E_Btn_XiLianImage = null;
		private UnityEngine.UI.Image m_E_Img_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_Img_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_Text_ItemNameText = null;
		public Transform uiTransform = null;
	}
}
