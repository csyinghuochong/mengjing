using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetXiLian : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public ItemInfo CostItemInfo { get; set; }
		public RolePetInfo RolePetInfo;

		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_UIPetInfo1/ES_PetInfoShow");
		    	   this.m_es_petinfoshow = this.AddChild<ES_PetInfoShow,Transform>(subTrans);
     			}
     			return this.m_es_petinfoshow;
     		}
     	}

		public LoopVerticalScrollRect E_CommonItemsLoopVerticalScrollRect
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
		    		this.m_E_CommonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"DoMove/E_CommonItems");
     			}
     			return this.m_E_CommonItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Btn_XiLianButton
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
		    		this.m_E_Btn_XiLianButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"DoMove/E_Btn_XiLian");
     			}
     			return this.m_E_Btn_XiLianButton;
     		}
     	}

		public Image E_Btn_XiLianImage
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
		    		this.m_E_Btn_XiLianImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"DoMove/E_Btn_XiLian");
     			}
     			return this.m_E_Btn_XiLianImage;
     		}
     	}

		public Image E_Img_ItemQualityImage
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
		    		this.m_E_Img_ItemQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"DoMove/E_Img_ItemQuality");
     			}
     			return this.m_E_Img_ItemQualityImage;
     		}
     	}

		public Image E_Img_ItemIconImage
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
		    		this.m_E_Img_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"DoMove/E_Img_ItemIcon");
     			}
     			return this.m_E_Img_ItemIconImage;
     		}
     	}

		public Text E_Text_ItemNameText
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
		    		this.m_E_Text_ItemNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"DoMove/E_Text_ItemName");
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
			this.m_es_petinfoshow = null;
			this.m_E_CommonItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_XiLianButton = null;
			this.m_E_Btn_XiLianImage = null;
			this.m_E_Img_ItemQualityImage = null;
			this.m_E_Img_ItemIconImage = null;
			this.m_E_Text_ItemNameText = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_PetInfoShow> m_es_petinfoshow = null;
		private LoopVerticalScrollRect m_E_CommonItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_XiLianButton = null;
		private Image m_E_Btn_XiLianImage = null;
		private Image m_E_Img_ItemQualityImage = null;
		private Image m_E_Img_ItemIconImage = null;
		private Text m_E_Text_ItemNameText = null;
		public Transform uiTransform = null;
	}
}
