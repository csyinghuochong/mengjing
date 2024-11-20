using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ItemAppraisalTips : Entity,IAwake<Transform>,IDestroy
	{
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public ItemOperateEnum ItemOpetateType;
		public int CurrentHouse;
		public float ExceedWidth { get; set; } = 0f;

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

		public Image E_QualityBgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QualityBgImage == null )
     			{
		    		this.m_E_QualityBgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_QualityBg");
     			}
     			return this.m_E_QualityBgImage;
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

		public Image E_ItemBackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemBackImage == null )
     			{
		    		this.m_E_ItemBackImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemBack");
     			}
     			return this.m_E_ItemBackImage;
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

		public Image E_ItemDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDiImage == null )
     			{
		    		this.m_E_ItemDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemDi");
     			}
     			return this.m_E_ItemDiImage;
     		}
     	}

		public Text E_ItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNumText == null )
     			{
		    		this.m_E_ItemNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemNum");
     			}
     			return this.m_E_ItemNumText;
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

		public Image E_BangDingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BangDingImage == null )
     			{
		    		this.m_E_BangDingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_BangDing");
     			}
     			return this.m_E_BangDingImage;
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

		public Image E_FengYinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FengYinImage == null )
     			{
		    		this.m_E_FengYinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_FengYin");
     			}
     			return this.m_E_FengYinImage;
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

		public Text E_ItemSubTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemSubTypeText == null )
     			{
		    		this.m_E_ItemSubTypeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemSubType");
     			}
     			return this.m_E_ItemSubTypeText;
     		}
     	}

		public Text E_ItemMakeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemMakeText == null )
     			{
		    		this.m_E_ItemMakeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemMake");
     			}
     			return this.m_E_ItemMakeText;
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

		public Text E_ItemCostDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemCostDesText == null )
     			{
		    		this.m_E_ItemCostDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemDes/E_ItemCostDes");
     			}
     			return this.m_E_ItemCostDesText;
     		}
     	}

		public Text E_ItemJingHeQualityText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemJingHeQualityText == null )
     			{
		    		this.m_E_ItemJingHeQualityText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemJingHeQuality");
     			}
     			return this.m_E_ItemJingHeQualityText;
     		}
     	}

		public Text E_ItemJingHePropertyText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemJingHePropertyText == null )
     			{
		    		this.m_E_ItemJingHePropertyText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemJingHeQuality/E_ItemJingHeProperty");
     			}
     			return this.m_E_ItemJingHePropertyText;
     		}
     	}

		public Text E_ItemJingHeTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemJingHeTipText == null )
     			{
		    		this.m_E_ItemJingHeTipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_ItemJingHeQuality/E_ItemJingHeTip");
     			}
     			return this.m_E_ItemJingHeTipText;
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

		public Button E_SaveStoreHouseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveStoreHouseButton == null )
     			{
		    		this.m_E_SaveStoreHouseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_SaveStoreHouse");
     			}
     			return this.m_E_SaveStoreHouseButton;
     		}
     	}

		public Image E_SaveStoreHouseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveStoreHouseImage == null )
     			{
		    		this.m_E_SaveStoreHouseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_SaveStoreHouse");
     			}
     			return this.m_E_SaveStoreHouseImage;
     		}
     	}

		public RectTransform EG_HuiShouSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HuiShouSetRectTransform == null )
     			{
		    		this.m_EG_HuiShouSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet");
     			}
     			return this.m_EG_HuiShouSetRectTransform;
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
		    		this.m_E_HuiShouButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet/E_HuiShou");
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
		    		this.m_E_HuiShouImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet/E_HuiShou");
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
		    		this.m_E_HuiShouCancleButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet/E_HuiShouCancle");
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
		    		this.m_E_HuiShouCancleImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet/E_HuiShouCancle");
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

		public Button E_TakeStoreHouseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeStoreHouseButton == null )
     			{
		    		this.m_E_TakeStoreHouseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/E_TakeStoreHouse");
     			}
     			return this.m_E_TakeStoreHouseButton;
     		}
     	}

		public Image E_TakeStoreHouseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeStoreHouseImage == null )
     			{
		    		this.m_E_TakeStoreHouseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_TakeStoreHouse");
     			}
     			return this.m_E_TakeStoreHouseImage;
     		}
     	}

		public Button E_JingHeAddQualityButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingHeAddQualityButton == null )
     			{
		    		this.m_E_JingHeAddQualityButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/E_JingHeAddQuality");
     			}
     			return this.m_E_JingHeAddQualityButton;
     		}
     	}

		public Image E_JingHeAddQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingHeAddQualityImage == null )
     			{
		    		this.m_E_JingHeAddQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_JingHeAddQuality");
     			}
     			return this.m_E_JingHeAddQualityImage;
     		}
     	}

		public Button E_JingHeActivateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingHeActivateButton == null )
     			{
		    		this.m_E_JingHeActivateButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/E_JingHeActivate");
     			}
     			return this.m_E_JingHeActivateButton;
     		}
     	}

		public Image E_JingHeActivateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingHeActivateImage == null )
     			{
		    		this.m_E_JingHeActivateImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_JingHeActivate");
     			}
     			return this.m_E_JingHeActivateImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BackImage = null;
			this.m_E_QualityBgImage = null;
			this.m_E_QualityLineImage = null;
			this.m_E_ItemBackImage = null;
			this.m_E_ItemQualityImage = null;
			this.m_E_ItemDiImage = null;
			this.m_E_ItemNumText = null;
			this.m_E_ItemIconImage = null;
			this.m_E_BangDingImage = null;
			this.m_E_BangDingText = null;
			this.m_E_FengYinImage = null;
			this.m_E_ItemNameText = null;
			this.m_E_ItemTypeText = null;
			this.m_E_ItemLvText = null;
			this.m_E_ItemSubTypeText = null;
			this.m_E_ItemMakeText = null;
			this.m_E_ItemDesText = null;
			this.m_E_ItemCostDesText = null;
			this.m_E_ItemJingHeQualityText = null;
			this.m_E_ItemJingHePropertyText = null;
			this.m_E_ItemJingHeTipText = null;
			this.m_EG_BagOpenSetRectTransform = null;
			this.m_E_SellButton = null;
			this.m_E_SellImage = null;
			this.m_E_UseButton = null;
			this.m_E_UseImage = null;
			this.m_E_SaveStoreHouseButton = null;
			this.m_E_SaveStoreHouseImage = null;
			this.m_EG_HuiShouSetRectTransform = null;
			this.m_E_HuiShouButton = null;
			this.m_E_HuiShouImage = null;
			this.m_E_HuiShouCancleButton = null;
			this.m_E_HuiShouCancleImage = null;
			this.m_E_XieXiaGemButton = null;
			this.m_E_XieXiaGemImage = null;
			this.m_E_TakeStoreHouseButton = null;
			this.m_E_TakeStoreHouseImage = null;
			this.m_E_JingHeAddQualityButton = null;
			this.m_E_JingHeAddQualityImage = null;
			this.m_E_JingHeActivateButton = null;
			this.m_E_JingHeActivateImage = null;
			this.uiTransform = null;
		}

		private Image m_E_BackImage = null;
		private Image m_E_QualityBgImage = null;
		private Image m_E_QualityLineImage = null;
		private Image m_E_ItemBackImage = null;
		private Image m_E_ItemQualityImage = null;
		private Image m_E_ItemDiImage = null;
		private Text m_E_ItemNumText = null;
		private Image m_E_ItemIconImage = null;
		private Image m_E_BangDingImage = null;
		private Text m_E_BangDingText = null;
		private Image m_E_FengYinImage = null;
		private Text m_E_ItemNameText = null;
		private Text m_E_ItemTypeText = null;
		private Text m_E_ItemLvText = null;
		private Text m_E_ItemSubTypeText = null;
		private Text m_E_ItemMakeText = null;
		private Text m_E_ItemDesText = null;
		private Text m_E_ItemCostDesText = null;
		private Text m_E_ItemJingHeQualityText = null;
		private Text m_E_ItemJingHePropertyText = null;
		private Text m_E_ItemJingHeTipText = null;
		private RectTransform m_EG_BagOpenSetRectTransform = null;
		private Button m_E_SellButton = null;
		private Image m_E_SellImage = null;
		private Button m_E_UseButton = null;
		private Image m_E_UseImage = null;
		private Button m_E_SaveStoreHouseButton = null;
		private Image m_E_SaveStoreHouseImage = null;
		private RectTransform m_EG_HuiShouSetRectTransform = null;
		private Button m_E_HuiShouButton = null;
		private Image m_E_HuiShouImage = null;
		private Button m_E_HuiShouCancleButton = null;
		private Image m_E_HuiShouCancleImage = null;
		private Button m_E_XieXiaGemButton = null;
		private Image m_E_XieXiaGemImage = null;
		private Button m_E_TakeStoreHouseButton = null;
		private Image m_E_TakeStoreHouseImage = null;
		private Button m_E_JingHeAddQualityButton = null;
		private Image m_E_JingHeAddQualityImage = null;
		private Button m_E_JingHeActivateButton = null;
		private Image m_E_JingHeActivateImage = null;
		public Transform uiTransform = null;
	}
}
