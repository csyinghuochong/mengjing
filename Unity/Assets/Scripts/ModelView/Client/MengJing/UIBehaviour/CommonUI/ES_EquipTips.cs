
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_EquipTips : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		public BagInfo BagInfo;
		public ItemOperateEnum ItemOpetateType;
		
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

		public UnityEngine.UI.Image E_EquipQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipQualityImage == null )
     			{
		    		this.m_E_EquipQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_EquipQuality");
     			}
     			return this.m_E_EquipQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_EquipDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipDiImage == null )
     			{
		    		this.m_E_EquipDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_EquipDi");
     			}
     			return this.m_E_EquipDiImage;
     		}
     	}

		public UnityEngine.UI.Image E_EquipIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipIconImage == null )
     			{
		    		this.m_E_EquipIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_EquipIcon");
     			}
     			return this.m_E_EquipIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_EquipNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipNameText == null )
     			{
		    		this.m_E_EquipNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipName");
     			}
     			return this.m_E_EquipNameText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipTypeSonText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipTypeSonText == null )
     			{
		    		this.m_E_EquipTypeSonText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipTypeSon");
     			}
     			return this.m_E_EquipTypeSonText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipLvText == null )
     			{
		    		this.m_E_EquipLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipLv");
     			}
     			return this.m_E_EquipLvText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipTypeText == null )
     			{
		    		this.m_E_EquipTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipType");
     			}
     			return this.m_E_EquipTypeText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipNeedLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipNeedLvText == null )
     			{
		    		this.m_E_EquipNeedLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipNeedLv");
     			}
     			return this.m_E_EquipNeedLvText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipNeedProText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipNeedProText == null )
     			{
		    		this.m_E_EquipNeedProText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipNeedPro");
     			}
     			return this.m_E_EquipNeedProText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipBangDingText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipBangDingText == null )
     			{
		    		this.m_E_EquipBangDingText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipBangDing");
     			}
     			return this.m_E_EquipBangDingText;
     		}
     	}

		public UnityEngine.UI.Image E_EquipBangDingImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipBangDingImgImage == null )
     			{
		    		this.m_E_EquipBangDingImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_EquipBangDingImg");
     			}
     			return this.m_E_EquipBangDingImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_EquipQiangHuaText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipQiangHuaText == null )
     			{
		    		this.m_E_EquipQiangHuaText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipQiangHua");
     			}
     			return this.m_E_EquipQiangHuaText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipPropertyTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipPropertyTextText == null )
     			{
		    		this.m_E_EquipPropertyTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipPropertyText");
     			}
     			return this.m_E_EquipPropertyTextText;
     		}
     	}

		public UnityEngine.RectTransform EG_UIEquipGemHoleSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIEquipGemHoleSetRectTransform == null )
     			{
		    		this.m_EG_UIEquipGemHoleSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet");
     			}
     			return this.m_EG_UIEquipGemHoleSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipZhuanJingSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipZhuanJingSetRectTransform == null )
     			{
		    		this.m_EG_EquipZhuanJingSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipZhuanJingSet");
     			}
     			return this.m_EG_EquipZhuanJingSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_UIEquipSuitRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIEquipSuitRectTransform == null )
     			{
		    		this.m_EG_UIEquipSuitRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit");
     			}
     			return this.m_EG_UIEquipSuitRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ShowEquipSuitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowEquipSuitButton == null )
     			{
		    		this.m_E_ShowEquipSuitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/E_ShowEquipSuit");
     			}
     			return this.m_E_ShowEquipSuitButton;
     		}
     	}

		public UnityEngine.UI.Image E_ShowEquipSuitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowEquipSuitImage == null )
     			{
		    		this.m_E_ShowEquipSuitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/E_ShowEquipSuit");
     			}
     			return this.m_E_ShowEquipSuitImage;
     		}
     	}

		public UnityEngine.UI.Text EquipSuitItemNamePropertyTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EquipSuitItemNamePropertyTextText == null )
     			{
		    		this.m_EquipSuitItemNamePropertyTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/EquipSuitShowListSet/Img_back (2)/EquipSuitShowNameListSet/EquipSuitItemNamePropertyText");
     			}
     			return this.m_EquipSuitItemNamePropertyTextText;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipHintSkillRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipHintSkillRectTransform == null )
     			{
		    		this.m_EG_EquipHintSkillRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipHintSkill");
     			}
     			return this.m_EG_EquipHintSkillRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipBtnSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipBtnSetRectTransform == null )
     			{
		    		this.m_EG_EquipBtnSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet");
     			}
     			return this.m_EG_EquipBtnSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_TakeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeButton == null )
     			{
		    		this.m_E_TakeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_Take");
     			}
     			return this.m_E_TakeButton;
     		}
     	}

		public UnityEngine.UI.Image E_TakeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeImage == null )
     			{
		    		this.m_E_TakeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_Take");
     			}
     			return this.m_E_TakeImage;
     		}
     	}

		public UnityEngine.UI.Button E_HuiShouFangZhiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HuiShouFangZhiButton == null )
     			{
		    		this.m_E_HuiShouFangZhiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_HuiShouFangZhi");
     			}
     			return this.m_E_HuiShouFangZhiButton;
     		}
     	}

		public UnityEngine.UI.Image E_HuiShouFangZhiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HuiShouFangZhiImage == null )
     			{
		    		this.m_E_HuiShouFangZhiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_HuiShouFangZhi");
     			}
     			return this.m_E_HuiShouFangZhiImage;
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
		    		this.m_E_SaveStoreHouseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_SaveStoreHouse");
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
		    		this.m_E_SaveStoreHouseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_SaveStoreHouse");
     			}
     			return this.m_E_SaveStoreHouseImage;
     		}
     	}

		public UnityEngine.UI.Button E_StoreHouseSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoreHouseSetButton == null )
     			{
		    		this.m_E_StoreHouseSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_StoreHouseSet");
     			}
     			return this.m_E_StoreHouseSetButton;
     		}
     	}

		public UnityEngine.UI.Image E_StoreHouseSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoreHouseSetImage == null )
     			{
		    		this.m_E_StoreHouseSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_StoreHouseSet");
     			}
     			return this.m_E_StoreHouseSetImage;
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
		    		this.m_EG_BagOpenSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet");
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
		    		this.m_E_SellButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Sell");
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
		    		this.m_E_SellImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Sell");
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
		    		this.m_E_UseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Use");
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
		    		this.m_E_UseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Use");
     			}
     			return this.m_E_UseImage;
     		}
     	}

		public UnityEngine.UI.Button E_TakeoffButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeoffButton == null )
     			{
		    		this.m_E_TakeoffButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/RoseEquipOpenSet/E_Takeoff");
     			}
     			return this.m_E_TakeoffButton;
     		}
     	}

		public UnityEngine.UI.Image E_TakeoffImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeoffImage == null )
     			{
		    		this.m_E_TakeoffImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/RoseEquipOpenSet/E_Takeoff");
     			}
     			return this.m_E_TakeoffImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BackImage = null;
			this.m_E_QualityBgImage = null;
			this.m_E_QualityLineImage = null;
			this.m_E_EquipQualityImage = null;
			this.m_E_EquipDiImage = null;
			this.m_E_EquipIconImage = null;
			this.m_E_EquipNameText = null;
			this.m_E_EquipTypeSonText = null;
			this.m_E_EquipLvText = null;
			this.m_E_EquipTypeText = null;
			this.m_E_EquipNeedLvText = null;
			this.m_E_EquipNeedProText = null;
			this.m_E_EquipBangDingText = null;
			this.m_E_EquipBangDingImgImage = null;
			this.m_E_EquipQiangHuaText = null;
			this.m_E_EquipPropertyTextText = null;
			this.m_EG_UIEquipGemHoleSetRectTransform = null;
			this.m_EG_EquipZhuanJingSetRectTransform = null;
			this.m_EG_UIEquipSuitRectTransform = null;
			this.m_E_ShowEquipSuitButton = null;
			this.m_E_ShowEquipSuitImage = null;
			this.m_EquipSuitItemNamePropertyTextText = null;
			this.m_EG_EquipHintSkillRectTransform = null;
			this.m_EG_EquipBtnSetRectTransform = null;
			this.m_E_TakeButton = null;
			this.m_E_TakeImage = null;
			this.m_E_HuiShouFangZhiButton = null;
			this.m_E_HuiShouFangZhiImage = null;
			this.m_E_SaveStoreHouseButton = null;
			this.m_E_SaveStoreHouseImage = null;
			this.m_E_StoreHouseSetButton = null;
			this.m_E_StoreHouseSetImage = null;
			this.m_EG_BagOpenSetRectTransform = null;
			this.m_E_SellButton = null;
			this.m_E_SellImage = null;
			this.m_E_UseButton = null;
			this.m_E_UseImage = null;
			this.m_E_TakeoffButton = null;
			this.m_E_TakeoffImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_BackImage = null;
		private UnityEngine.UI.Image m_E_QualityBgImage = null;
		private UnityEngine.UI.Image m_E_QualityLineImage = null;
		private UnityEngine.UI.Image m_E_EquipQualityImage = null;
		private UnityEngine.UI.Image m_E_EquipDiImage = null;
		private UnityEngine.UI.Image m_E_EquipIconImage = null;
		private UnityEngine.UI.Text m_E_EquipNameText = null;
		private UnityEngine.UI.Text m_E_EquipTypeSonText = null;
		private UnityEngine.UI.Text m_E_EquipLvText = null;
		private UnityEngine.UI.Text m_E_EquipTypeText = null;
		private UnityEngine.UI.Text m_E_EquipNeedLvText = null;
		private UnityEngine.UI.Text m_E_EquipNeedProText = null;
		private UnityEngine.UI.Text m_E_EquipBangDingText = null;
		private UnityEngine.UI.Image m_E_EquipBangDingImgImage = null;
		private UnityEngine.UI.Text m_E_EquipQiangHuaText = null;
		private UnityEngine.UI.Text m_E_EquipPropertyTextText = null;
		private UnityEngine.RectTransform m_EG_UIEquipGemHoleSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_EquipZhuanJingSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_UIEquipSuitRectTransform = null;
		private UnityEngine.UI.Button m_E_ShowEquipSuitButton = null;
		private UnityEngine.UI.Image m_E_ShowEquipSuitImage = null;
		private UnityEngine.UI.Text m_EquipSuitItemNamePropertyTextText = null;
		private UnityEngine.RectTransform m_EG_EquipHintSkillRectTransform = null;
		private UnityEngine.RectTransform m_EG_EquipBtnSetRectTransform = null;
		private UnityEngine.UI.Button m_E_TakeButton = null;
		private UnityEngine.UI.Image m_E_TakeImage = null;
		private UnityEngine.UI.Button m_E_HuiShouFangZhiButton = null;
		private UnityEngine.UI.Image m_E_HuiShouFangZhiImage = null;
		private UnityEngine.UI.Button m_E_SaveStoreHouseButton = null;
		private UnityEngine.UI.Image m_E_SaveStoreHouseImage = null;
		private UnityEngine.UI.Button m_E_StoreHouseSetButton = null;
		private UnityEngine.UI.Image m_E_StoreHouseSetImage = null;
		private UnityEngine.RectTransform m_EG_BagOpenSetRectTransform = null;
		private UnityEngine.UI.Button m_E_SellButton = null;
		private UnityEngine.UI.Image m_E_SellImage = null;
		private UnityEngine.UI.Button m_E_UseButton = null;
		private UnityEngine.UI.Image m_E_UseImage = null;
		private UnityEngine.UI.Button m_E_TakeoffButton = null;
		private UnityEngine.UI.Image m_E_TakeoffImage = null;
		public Transform uiTransform = null;
	}
}
