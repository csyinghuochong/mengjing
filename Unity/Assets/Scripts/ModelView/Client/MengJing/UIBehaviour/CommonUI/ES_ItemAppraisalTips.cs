
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ItemAppraisalTips : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public BagInfo BagInfo;
		public ItemOperateEnum ItemOpetateType;
		public int CurrentHouse;
		
		public UnityEngine.UI.Image E_BackImage
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
		    		this.m_E_BackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back");
     			}
     			return this.m_E_BackImage;
     		}
     	}

		public UnityEngine.UI.Image E_QualityBgImage
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
		    		this.m_E_QualityBgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_QualityBg");
     			}
     			return this.m_E_QualityBgImage;
     		}
     	}

		public UnityEngine.UI.Image E_QualityLineImage
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
		    		this.m_E_QualityLineImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_QualityLine");
     			}
     			return this.m_E_QualityLineImage;
     		}
     	}

		public UnityEngine.UI.Image E_ItemBackImage
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
		    		this.m_E_ItemBackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemBack");
     			}
     			return this.m_E_ItemBackImage;
     		}
     	}

		public UnityEngine.UI.Image E_ItemQualityImage
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
		    		this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemQuality");
     			}
     			return this.m_E_ItemQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_ItemDiImage
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
		    		this.m_E_ItemDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemDi");
     			}
     			return this.m_E_ItemDiImage;
     		}
     	}

		public UnityEngine.UI.Text E_ItemNumText
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
		    		this.m_E_ItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemNum");
     			}
     			return this.m_E_ItemNumText;
     		}
     	}

		public UnityEngine.UI.Image E_ItemIconImage
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
		    		this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_ItemIcon");
     			}
     			return this.m_E_ItemIconImage;
     		}
     	}

		public UnityEngine.UI.Image E_BangDingImage
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
		    		this.m_E_BangDingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_BangDing");
     			}
     			return this.m_E_BangDingImage;
     		}
     	}

		public UnityEngine.UI.Text E_BangDingText
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
		    		this.m_E_BangDingText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_BangDing");
     			}
     			return this.m_E_BangDingText;
     		}
     	}

		public UnityEngine.UI.Image E_FengYinImage
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
		    		this.m_E_FengYinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/CommonItem/E_FengYin");
     			}
     			return this.m_E_FengYinImage;
     		}
     	}

		public UnityEngine.UI.Text E_ItemNameText
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
		    		this.m_E_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemName");
     			}
     			return this.m_E_ItemNameText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemTypeText
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
		    		this.m_E_ItemTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemType");
     			}
     			return this.m_E_ItemTypeText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemLvText
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
		    		this.m_E_ItemLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemLv");
     			}
     			return this.m_E_ItemLvText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemSubTypeText
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
		    		this.m_E_ItemSubTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemSubType");
     			}
     			return this.m_E_ItemSubTypeText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemMakeText
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
		    		this.m_E_ItemMakeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemMake");
     			}
     			return this.m_E_ItemMakeText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemDesText
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
		    		this.m_E_ItemDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemDes");
     			}
     			return this.m_E_ItemDesText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemCostDesText
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
		    		this.m_E_ItemCostDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemDes/E_ItemCostDes");
     			}
     			return this.m_E_ItemCostDesText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemJingHeQualityText
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
		    		this.m_E_ItemJingHeQualityText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemJingHeQuality");
     			}
     			return this.m_E_ItemJingHeQualityText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemJingHePropertyText
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
		    		this.m_E_ItemJingHePropertyText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemJingHeQuality/E_ItemJingHeProperty");
     			}
     			return this.m_E_ItemJingHePropertyText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemJingHeTipText
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
		    		this.m_E_ItemJingHeTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_ItemJingHeQuality/E_ItemJingHeTip");
     			}
     			return this.m_E_ItemJingHeTipText;
     		}
     	}

		public UnityEngine.RectTransform EG_BagOpenSetRectTransform
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
		    		this.m_EG_BagOpenSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet");
     			}
     			return this.m_EG_BagOpenSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SellButton
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
		    		this.m_E_SellButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Sell");
     			}
     			return this.m_E_SellButton;
     		}
     	}

		public UnityEngine.UI.Image E_SellImage
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
		    		this.m_E_SellImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Sell");
     			}
     			return this.m_E_SellImage;
     		}
     	}

		public UnityEngine.UI.Button E_UseButton
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
		    		this.m_E_UseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Use");
     			}
     			return this.m_E_UseButton;
     		}
     	}

		public UnityEngine.UI.Image E_UseImage
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
		    		this.m_E_UseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_Use");
     			}
     			return this.m_E_UseImage;
     		}
     	}

		public UnityEngine.UI.Button E_SaveStoreHouseButton
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
		    		this.m_E_SaveStoreHouseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_SaveStoreHouse");
     			}
     			return this.m_E_SaveStoreHouseButton;
     		}
     	}

		public UnityEngine.UI.Image E_SaveStoreHouseImage
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
		    		this.m_E_SaveStoreHouseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_BagOpenSet/E_SaveStoreHouse");
     			}
     			return this.m_E_SaveStoreHouseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_HuiShouSetRectTransform
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
		    		this.m_EG_HuiShouSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet");
     			}
     			return this.m_EG_HuiShouSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_HuiShouButton
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
		    		this.m_E_HuiShouButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet/E_HuiShou");
     			}
     			return this.m_E_HuiShouButton;
     		}
     	}

		public UnityEngine.UI.Image E_HuiShouImage
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
		    		this.m_E_HuiShouImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet/E_HuiShou");
     			}
     			return this.m_E_HuiShouImage;
     		}
     	}

		public UnityEngine.UI.Button E_HuiShouCancleButton
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
		    		this.m_E_HuiShouCancleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet/E_HuiShouCancle");
     			}
     			return this.m_E_HuiShouCancleButton;
     		}
     	}

		public UnityEngine.UI.Image E_HuiShouCancleImage
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
		    		this.m_E_HuiShouCancleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_HuiShouSet/E_HuiShouCancle");
     			}
     			return this.m_E_HuiShouCancleImage;
     		}
     	}

		public UnityEngine.UI.Button E_XieXiaGemButton
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
		    		this.m_E_XieXiaGemButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/E_XieXiaGem");
     			}
     			return this.m_E_XieXiaGemButton;
     		}
     	}

		public UnityEngine.UI.Image E_XieXiaGemImage
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
		    		this.m_E_XieXiaGemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_XieXiaGem");
     			}
     			return this.m_E_XieXiaGemImage;
     		}
     	}

		public UnityEngine.UI.Button E_TakeStoreHouseButton
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
		    		this.m_E_TakeStoreHouseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/E_TakeStoreHouse");
     			}
     			return this.m_E_TakeStoreHouseButton;
     		}
     	}

		public UnityEngine.UI.Image E_TakeStoreHouseImage
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
		    		this.m_E_TakeStoreHouseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_TakeStoreHouse");
     			}
     			return this.m_E_TakeStoreHouseImage;
     		}
     	}

		public UnityEngine.UI.Button E_JingHeAddQualityButton
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
		    		this.m_E_JingHeAddQualityButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/E_JingHeAddQuality");
     			}
     			return this.m_E_JingHeAddQualityButton;
     		}
     	}

		public UnityEngine.UI.Image E_JingHeAddQualityImage
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
		    		this.m_E_JingHeAddQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_JingHeAddQuality");
     			}
     			return this.m_E_JingHeAddQualityImage;
     		}
     	}

		public UnityEngine.UI.Button E_JingHeActivateButton
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
		    		this.m_E_JingHeActivateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/E_JingHeActivate");
     			}
     			return this.m_E_JingHeActivateButton;
     		}
     	}

		public UnityEngine.UI.Image E_JingHeActivateImage
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
		    		this.m_E_JingHeActivateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_JingHeActivate");
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

		private UnityEngine.UI.Image m_E_BackImage = null;
		private UnityEngine.UI.Image m_E_QualityBgImage = null;
		private UnityEngine.UI.Image m_E_QualityLineImage = null;
		private UnityEngine.UI.Image m_E_ItemBackImage = null;
		private UnityEngine.UI.Image m_E_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_ItemDiImage = null;
		private UnityEngine.UI.Text m_E_ItemNumText = null;
		private UnityEngine.UI.Image m_E_ItemIconImage = null;
		private UnityEngine.UI.Image m_E_BangDingImage = null;
		private UnityEngine.UI.Text m_E_BangDingText = null;
		private UnityEngine.UI.Image m_E_FengYinImage = null;
		private UnityEngine.UI.Text m_E_ItemNameText = null;
		private UnityEngine.UI.Text m_E_ItemTypeText = null;
		private UnityEngine.UI.Text m_E_ItemLvText = null;
		private UnityEngine.UI.Text m_E_ItemSubTypeText = null;
		private UnityEngine.UI.Text m_E_ItemMakeText = null;
		private UnityEngine.UI.Text m_E_ItemDesText = null;
		private UnityEngine.UI.Text m_E_ItemCostDesText = null;
		private UnityEngine.UI.Text m_E_ItemJingHeQualityText = null;
		private UnityEngine.UI.Text m_E_ItemJingHePropertyText = null;
		private UnityEngine.UI.Text m_E_ItemJingHeTipText = null;
		private UnityEngine.RectTransform m_EG_BagOpenSetRectTransform = null;
		private UnityEngine.UI.Button m_E_SellButton = null;
		private UnityEngine.UI.Image m_E_SellImage = null;
		private UnityEngine.UI.Button m_E_UseButton = null;
		private UnityEngine.UI.Image m_E_UseImage = null;
		private UnityEngine.UI.Button m_E_SaveStoreHouseButton = null;
		private UnityEngine.UI.Image m_E_SaveStoreHouseImage = null;
		private UnityEngine.RectTransform m_EG_HuiShouSetRectTransform = null;
		private UnityEngine.UI.Button m_E_HuiShouButton = null;
		private UnityEngine.UI.Image m_E_HuiShouImage = null;
		private UnityEngine.UI.Button m_E_HuiShouCancleButton = null;
		private UnityEngine.UI.Image m_E_HuiShouCancleImage = null;
		private UnityEngine.UI.Button m_E_XieXiaGemButton = null;
		private UnityEngine.UI.Image m_E_XieXiaGemImage = null;
		private UnityEngine.UI.Button m_E_TakeStoreHouseButton = null;
		private UnityEngine.UI.Image m_E_TakeStoreHouseImage = null;
		private UnityEngine.UI.Button m_E_JingHeAddQualityButton = null;
		private UnityEngine.UI.Image m_E_JingHeAddQualityImage = null;
		private UnityEngine.UI.Button m_E_JingHeActivateButton = null;
		private UnityEngine.UI.Image m_E_JingHeActivateImage = null;
		public Transform uiTransform = null;
	}
}
