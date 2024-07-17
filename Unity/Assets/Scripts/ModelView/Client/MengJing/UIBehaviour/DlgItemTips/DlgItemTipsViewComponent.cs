using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgItemTips))]
	[EnableMethod]
	public  class DlgItemTipsViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_BGButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BGButton == null )
     			{
		    		this.m_E_BGButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_BG");
     			}
     			return this.m_E_BGButton;
     		}
     	}

		public Image E_BGImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BGImage == null )
     			{
		    		this.m_E_BGImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_BG");
     			}
     			return this.m_E_BGImage;
     		}
     	}

		public Image E_BackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BackImage == null )
     			{
		    		this.m_E_BackImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back");
     			}
     			return this.m_E_BackImage;
     		}
     	}

		public Image E_QulityBgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QulityBgImage == null )
     			{
		    		this.m_E_QulityBgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_QulityBg");
     			}
     			return this.m_E_QulityBgImage;
     		}
     	}

		public Image E_QualityLineImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QualityLineImage == null )
     			{
		    		this.m_E_QualityLineImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_QualityLine");
     			}
     			return this.m_E_QualityLineImage;
     		}
     	}

		public Image E_ItemQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemQualityImage == null )
     			{
		    		this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemQuality");
     			}
     			return this.m_E_ItemQualityImage;
     		}
     	}

		public Image E_ItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemIconImage == null )
     			{
		    		this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemIcon");
     			}
     			return this.m_E_ItemIconImage;
     		}
     	}

		public Image E_BindingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BindingImage == null )
     			{
		    		this.m_E_BindingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_Binding");
     			}
     			return this.m_E_BindingImage;
     		}
     	}

		public Text E_ItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNameText == null )
     			{
		    		this.m_E_ItemNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemName");
     			}
     			return this.m_E_ItemNameText;
     		}
     	}

		public Text E_ItemTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeText == null )
     			{
		    		this.m_E_ItemTypeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemType");
     			}
     			return this.m_E_ItemTypeText;
     		}
     	}

		public Text E_ItemLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemLvText == null )
     			{
		    		this.m_E_ItemLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemLv");
     			}
     			return this.m_E_ItemLvText;
     		}
     	}

		public Text E_ItemDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDesText == null )
     			{
		    		this.m_E_ItemDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemDes");
     			}
     			return this.m_E_ItemDesText;
     		}
     	}

		public Text E_BangDingText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BangDingText == null )
     			{
		    		this.m_E_BangDingText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_BangDing");
     			}
     			return this.m_E_BangDingText;
     		}
     	}

		public Text E_FuLingText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FuLingText == null )
     			{
		    		this.m_E_FuLingText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_FuLing");
     			}
     			return this.m_E_FuLingText;
     		}
     	}

		public Text E_FuLingDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FuLingDesText == null )
     			{
		    		this.m_E_FuLingDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_FuLingDes");
     			}
     			return this.m_E_FuLingDesText;
     		}
     	}

		public RectTransform EG_BagOpenSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BagOpenSetRectTransform == null )
     			{
		    		this.m_EG_BagOpenSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet");
     			}
     			return this.m_EG_BagOpenSetRectTransform;
     		}
     	}

		public Button E_SellButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SellButton == null )
     			{
		    		this.m_E_SellButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Sell");
     			}
     			return this.m_E_SellButton;
     		}
     	}

		public Image E_SellImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SellImage == null )
     			{
		    		this.m_E_SellImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Sell");
     			}
     			return this.m_E_SellImage;
     		}
     	}

		public Button E_UseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UseButton == null )
     			{
		    		this.m_E_UseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Use");
     			}
     			return this.m_E_UseButton;
     		}
     	}

		public Image E_UseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UseImage == null )
     			{
		    		this.m_E_UseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Use");
     			}
     			return this.m_E_UseImage;
     		}
     	}

		public Button E_SplitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SplitButton == null )
     			{
		    		this.m_E_SplitButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Split");
     			}
     			return this.m_E_SplitButton;
     		}
     	}

		public Image E_SplitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SplitImage == null )
     			{
		    		this.m_E_SplitImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Split");
     			}
     			return this.m_E_SplitImage;
     		}
     	}

		public Button E_PlanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlanButton == null )
     			{
		    		this.m_E_PlanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Plan");
     			}
     			return this.m_E_PlanButton;
     		}
     	}

		public Image E_PlanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlanImage == null )
     			{
		    		this.m_E_PlanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Plan");
     			}
     			return this.m_E_PlanImage;
     		}
     	}

		public Button E_StoreHouseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoreHouseButton == null )
     			{
		    		this.m_E_StoreHouseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_StoreHouse");
     			}
     			return this.m_E_StoreHouseButton;
     		}
     	}

		public Image E_StoreHouseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoreHouseImage == null )
     			{
		    		this.m_E_StoreHouseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_StoreHouse");
     			}
     			return this.m_E_StoreHouseImage;
     		}
     	}

		public Button E_HuiShouButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HuiShouButton == null )
     			{
		    		this.m_E_HuiShouButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/E_HuiShou");
     			}
     			return this.m_E_HuiShouButton;
     		}
     	}

		public Image E_HuiShouImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HuiShouImage == null )
     			{
		    		this.m_E_HuiShouImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_HuiShou");
     			}
     			return this.m_E_HuiShouImage;
     		}
     	}

		public Button E_HuiShouCancleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HuiShouCancleButton == null )
     			{
		    		this.m_E_HuiShouCancleButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/E_HuiShouCancle");
     			}
     			return this.m_E_HuiShouCancleButton;
     		}
     	}

		public Image E_HuiShouCancleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HuiShouCancleImage == null )
     			{
		    		this.m_E_HuiShouCancleImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_HuiShouCancle");
     			}
     			return this.m_E_HuiShouCancleImage;
     		}
     	}

		public Button E_XieXiaGemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XieXiaGemButton == null )
     			{
		    		this.m_E_XieXiaGemButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/E_XieXiaGem");
     			}
     			return this.m_E_XieXiaGemButton;
     		}
     	}

		public Image E_XieXiaGemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XieXiaGemImage == null )
     			{
		    		this.m_E_XieXiaGemImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_XieXiaGem");
     			}
     			return this.m_E_XieXiaGemImage;
     		}
     	}

		public Button E_PutBagButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PutBagButton == null )
     			{
		    		this.m_E_PutBagButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/E_PutBag");
     			}
     			return this.m_E_PutBagButton;
     		}
     	}

		public Image E_PutBagImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PutBagImage == null )
     			{
		    		this.m_E_PutBagImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_PutBag");
     			}
     			return this.m_E_PutBagImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BGButton = null;
			this.m_E_BGImage = null;
			this.m_E_BackImage = null;
			this.m_E_QulityBgImage = null;
			this.m_E_QualityLineImage = null;
			this.m_E_ItemQualityImage = null;
			this.m_E_ItemIconImage = null;
			this.m_E_BindingImage = null;
			this.m_E_ItemNameText = null;
			this.m_E_ItemTypeText = null;
			this.m_E_ItemLvText = null;
			this.m_E_ItemDesText = null;
			this.m_E_BangDingText = null;
			this.m_E_FuLingText = null;
			this.m_E_FuLingDesText = null;
			this.m_EG_BagOpenSetRectTransform = null;
			this.m_E_SellButton = null;
			this.m_E_SellImage = null;
			this.m_E_UseButton = null;
			this.m_E_UseImage = null;
			this.m_E_SplitButton = null;
			this.m_E_SplitImage = null;
			this.m_E_PlanButton = null;
			this.m_E_PlanImage = null;
			this.m_E_StoreHouseButton = null;
			this.m_E_StoreHouseImage = null;
			this.m_E_HuiShouButton = null;
			this.m_E_HuiShouImage = null;
			this.m_E_HuiShouCancleButton = null;
			this.m_E_HuiShouCancleImage = null;
			this.m_E_XieXiaGemButton = null;
			this.m_E_XieXiaGemImage = null;
			this.m_E_PutBagButton = null;
			this.m_E_PutBagImage = null;
			this.uiTransform = null;
		}

		private Button m_E_BGButton = null;
		private Image m_E_BGImage = null;
		private Image m_E_BackImage = null;
		private Image m_E_QulityBgImage = null;
		private Image m_E_QualityLineImage = null;
		private Image m_E_ItemQualityImage = null;
		private Image m_E_ItemIconImage = null;
		private Image m_E_BindingImage = null;
		private Text m_E_ItemNameText = null;
		private Text m_E_ItemTypeText = null;
		private Text m_E_ItemLvText = null;
		private Text m_E_ItemDesText = null;
		private Text m_E_BangDingText = null;
		private Text m_E_FuLingText = null;
		private Text m_E_FuLingDesText = null;
		private RectTransform m_EG_BagOpenSetRectTransform = null;
		private Button m_E_SellButton = null;
		private Image m_E_SellImage = null;
		private Button m_E_UseButton = null;
		private Image m_E_UseImage = null;
		private Button m_E_SplitButton = null;
		private Image m_E_SplitImage = null;
		private Button m_E_PlanButton = null;
		private Image m_E_PlanImage = null;
		private Button m_E_StoreHouseButton = null;
		private Image m_E_StoreHouseImage = null;
		private Button m_E_HuiShouButton = null;
		private Image m_E_HuiShouImage = null;
		private Button m_E_HuiShouCancleButton = null;
		private Image m_E_HuiShouCancleImage = null;
		private Button m_E_XieXiaGemButton = null;
		private Image m_E_XieXiaGemImage = null;
		private Button m_E_PutBagButton = null;
		private Image m_E_PutBagImage = null;
		public Transform uiTransform = null;
	}
}
