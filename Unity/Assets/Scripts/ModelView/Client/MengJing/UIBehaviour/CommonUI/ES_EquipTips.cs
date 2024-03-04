
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_EquipTips : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
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
			this.m_EquipSuitItemNamePropertyTextText = null;
			this.m_EG_EquipHintSkillRectTransform = null;
			this.m_EG_EquipBtnSetRectTransform = null;
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
		private UnityEngine.UI.Text m_EquipSuitItemNamePropertyTextText = null;
		private UnityEngine.RectTransform m_EG_EquipHintSkillRectTransform = null;
		private UnityEngine.RectTransform m_EG_EquipBtnSetRectTransform = null;
		public Transform uiTransform = null;
	}
}
