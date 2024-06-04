
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
		public float TitleBigHeight_160;      //底图头部的宽度
		public float TextItemHeight_40;       //底图属性的宽度
		public float TitleMiniHeight_50;
		public GameObject[] Obj_UIEquipGemHoleList;
		public GameObject[] Obj_UIEquipGemHoleTextList;
		public GameObject[] Obj_UIEquipGemHoleIconList;
		
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

		public UnityEngine.RectTransform EG_EquipBaseSetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipBaseSetListRectTransform == null )
     			{
		    		this.m_EG_EquipBaseSetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBaseSetList");
     			}
     			return this.m_EG_EquipBaseSetListRectTransform;
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

		public UnityEngine.RectTransform EG_UIEquipGemHole_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIEquipGemHole_1RectTransform == null )
     			{
		    		this.m_EG_UIEquipGemHole_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1");
     			}
     			return this.m_EG_UIEquipGemHole_1RectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_UIEquipGemHoleIcon_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleIcon_1Image == null )
     			{
		    		this.m_E_UIEquipGemHoleIcon_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1/E_UIEquipGemHoleIcon_1");
     			}
     			return this.m_E_UIEquipGemHoleIcon_1Image;
     		}
     	}

		public UnityEngine.UI.Text E_UIEquipGemHoleText_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleText_1Text == null )
     			{
		    		this.m_E_UIEquipGemHoleText_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1/E_UIEquipGemHoleText_1");
     			}
     			return this.m_E_UIEquipGemHoleText_1Text;
     		}
     	}

		public UnityEngine.RectTransform EG_UIEquipGemHole_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIEquipGemHole_2RectTransform == null )
     			{
		    		this.m_EG_UIEquipGemHole_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_2");
     			}
     			return this.m_EG_UIEquipGemHole_2RectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_UIEquipGemHoleIcon_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleIcon_2Image == null )
     			{
		    		this.m_E_UIEquipGemHoleIcon_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_2/E_UIEquipGemHoleIcon_2");
     			}
     			return this.m_E_UIEquipGemHoleIcon_2Image;
     		}
     	}

		public UnityEngine.UI.Text E_UIEquipGemHoleText_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleText_2Text == null )
     			{
		    		this.m_E_UIEquipGemHoleText_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_2/E_UIEquipGemHoleText_2");
     			}
     			return this.m_E_UIEquipGemHoleText_2Text;
     		}
     	}

		public UnityEngine.RectTransform EG_UIEquipGemHole_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIEquipGemHole_3RectTransform == null )
     			{
		    		this.m_EG_UIEquipGemHole_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_3");
     			}
     			return this.m_EG_UIEquipGemHole_3RectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_UIEquipGemHoleIcon_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleIcon_3Image == null )
     			{
		    		this.m_E_UIEquipGemHoleIcon_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_3/E_UIEquipGemHoleIcon_3");
     			}
     			return this.m_E_UIEquipGemHoleIcon_3Image;
     		}
     	}

		public UnityEngine.UI.Text E_UIEquipGemHoleText_3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleText_3Text == null )
     			{
		    		this.m_E_UIEquipGemHoleText_3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_3/E_UIEquipGemHoleText_3");
     			}
     			return this.m_E_UIEquipGemHoleText_3Text;
     		}
     	}

		public UnityEngine.RectTransform EG_UIEquipGemHole_4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIEquipGemHole_4RectTransform == null )
     			{
		    		this.m_EG_UIEquipGemHole_4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_4");
     			}
     			return this.m_EG_UIEquipGemHole_4RectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_UIEquipGemHoleIcon_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleIcon_4Image == null )
     			{
		    		this.m_E_UIEquipGemHoleIcon_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_4/E_UIEquipGemHoleIcon_4");
     			}
     			return this.m_E_UIEquipGemHoleIcon_4Image;
     		}
     	}

		public UnityEngine.UI.Text E_UIEquipGemHoleText_4Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleText_4Text == null )
     			{
		    		this.m_E_UIEquipGemHoleText_4Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_4/E_UIEquipGemHoleText_4");
     			}
     			return this.m_E_UIEquipGemHoleText_4Text;
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

		public UnityEngine.UI.Text E_ZhuanJingStatusDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhuanJingStatusDesText == null )
     			{
		    		this.m_E_ZhuanJingStatusDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_EquipZhuanJingSet/Img_Title_1/E_ZhuanJingStatusDes");
     			}
     			return this.m_E_ZhuanJingStatusDesText;
     		}
     	}

		public UnityEngine.UI.Image E_ZhuanJingStatusImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhuanJingStatusImgImage == null )
     			{
		    		this.m_E_ZhuanJingStatusImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipZhuanJingSet/Img_Title_1/E_ZhuanJingStatusDes/E_ZhuanJingStatusImg");
     			}
     			return this.m_E_ZhuanJingStatusImgImage;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipZhuanJingSetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipZhuanJingSetListRectTransform == null )
     			{
		    		this.m_EG_EquipZhuanJingSetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipZhuanJingSet/EG_EquipZhuanJingSetList");
     			}
     			return this.m_EG_EquipZhuanJingSetListRectTransform;
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

		public UnityEngine.UI.Text E_SuitNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SuitNameText == null )
     			{
		    		this.m_E_SuitNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/E_SuitName");
     			}
     			return this.m_E_SuitNameText;
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

		public UnityEngine.RectTransform EG_EquipSuitSetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipSuitSetListRectTransform == null )
     			{
		    		this.m_EG_EquipSuitSetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/EG_EquipSuitSetList");
     			}
     			return this.m_EG_EquipSuitSetListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipSuitShowListSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipSuitShowListSetRectTransform == null )
     			{
		    		this.m_EG_EquipSuitShowListSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/EG_EquipSuitShowListSet");
     			}
     			return this.m_EG_EquipSuitShowListSetRectTransform;
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
		    		this.m_EquipSuitItemNamePropertyTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/EG_EquipSuitShowListSet/Img_back (2)/EquipSuitShowNameListSet/EquipSuitItemNamePropertyText");
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

		public UnityEngine.UI.Text E_WearNeedText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WearNeedText == null )
     			{
		    		this.m_E_WearNeedText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_EquipHintSkill/E_WearNeed");
     			}
     			return this.m_E_WearNeedText;
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

		public UnityEngine.UI.Text E_EquipMakeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipMakeText == null )
     			{
		    		this.m_E_EquipMakeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_EquipMake");
     			}
     			return this.m_E_EquipMakeText;
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

		public UnityEngine.RectTransform EG_EquipBottomRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipBottomRectTransform == null )
     			{
		    		this.m_EG_EquipBottomRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_EquipBottom");
     			}
     			return this.m_EG_EquipBottomRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_EquipDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipDesText == null )
     			{
		    		this.m_E_EquipDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_EquipBottom/E_EquipDes");
     			}
     			return this.m_E_EquipDesText;
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

		public UnityEngine.RectTransform EG_RoseEquipOpenSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoseEquipOpenSetRectTransform == null )
     			{
		    		this.m_EG_RoseEquipOpenSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_RoseEquipOpenSet");
     			}
     			return this.m_EG_RoseEquipOpenSetRectTransform;
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
		    		this.m_E_TakeoffButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_RoseEquipOpenSet/E_Takeoff");
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
		    		this.m_E_TakeoffImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_RoseEquipOpenSet/E_Takeoff");
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
			this.m_E_EquipIconImage = null;
			this.m_E_EquipNameText = null;
			this.m_E_EquipTypeSonText = null;
			this.m_E_EquipTypeText = null;
			this.m_E_EquipNeedLvText = null;
			this.m_E_EquipBangDingText = null;
			this.m_E_EquipBangDingImgImage = null;
			this.m_E_EquipQiangHuaText = null;
			this.m_EG_EquipBaseSetListRectTransform = null;
			this.m_E_EquipPropertyTextText = null;
			this.m_EG_UIEquipGemHoleSetRectTransform = null;
			this.m_EG_UIEquipGemHole_1RectTransform = null;
			this.m_E_UIEquipGemHoleIcon_1Image = null;
			this.m_E_UIEquipGemHoleText_1Text = null;
			this.m_EG_UIEquipGemHole_2RectTransform = null;
			this.m_E_UIEquipGemHoleIcon_2Image = null;
			this.m_E_UIEquipGemHoleText_2Text = null;
			this.m_EG_UIEquipGemHole_3RectTransform = null;
			this.m_E_UIEquipGemHoleIcon_3Image = null;
			this.m_E_UIEquipGemHoleText_3Text = null;
			this.m_EG_UIEquipGemHole_4RectTransform = null;
			this.m_E_UIEquipGemHoleIcon_4Image = null;
			this.m_E_UIEquipGemHoleText_4Text = null;
			this.m_EG_EquipZhuanJingSetRectTransform = null;
			this.m_E_ZhuanJingStatusDesText = null;
			this.m_E_ZhuanJingStatusImgImage = null;
			this.m_EG_EquipZhuanJingSetListRectTransform = null;
			this.m_EG_UIEquipSuitRectTransform = null;
			this.m_E_SuitNameText = null;
			this.m_E_ShowEquipSuitButton = null;
			this.m_E_ShowEquipSuitImage = null;
			this.m_EG_EquipSuitSetListRectTransform = null;
			this.m_EG_EquipSuitShowListSetRectTransform = null;
			this.m_EquipSuitItemNamePropertyTextText = null;
			this.m_EG_EquipHintSkillRectTransform = null;
			this.m_E_WearNeedText = null;
			this.m_EG_EquipBtnSetRectTransform = null;
			this.m_E_EquipMakeText = null;
			this.m_E_TakeButton = null;
			this.m_E_TakeImage = null;
			this.m_E_HuiShouFangZhiButton = null;
			this.m_E_HuiShouFangZhiImage = null;
			this.m_EG_EquipBottomRectTransform = null;
			this.m_E_EquipDesText = null;
			this.m_E_SaveStoreHouseButton = null;
			this.m_E_SaveStoreHouseImage = null;
			this.m_E_StoreHouseSetButton = null;
			this.m_E_StoreHouseSetImage = null;
			this.m_EG_BagOpenSetRectTransform = null;
			this.m_E_SellButton = null;
			this.m_E_SellImage = null;
			this.m_E_UseButton = null;
			this.m_E_UseImage = null;
			this.m_EG_RoseEquipOpenSetRectTransform = null;
			this.m_E_TakeoffButton = null;
			this.m_E_TakeoffImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_BackImage = null;
		private UnityEngine.UI.Image m_E_QualityBgImage = null;
		private UnityEngine.UI.Image m_E_QualityLineImage = null;
		private UnityEngine.UI.Image m_E_EquipQualityImage = null;
		private UnityEngine.UI.Image m_E_EquipIconImage = null;
		private UnityEngine.UI.Text m_E_EquipNameText = null;
		private UnityEngine.UI.Text m_E_EquipTypeSonText = null;
		private UnityEngine.UI.Text m_E_EquipTypeText = null;
		private UnityEngine.UI.Text m_E_EquipNeedLvText = null;
		private UnityEngine.UI.Text m_E_EquipBangDingText = null;
		private UnityEngine.UI.Image m_E_EquipBangDingImgImage = null;
		private UnityEngine.UI.Text m_E_EquipQiangHuaText = null;
		private UnityEngine.RectTransform m_EG_EquipBaseSetListRectTransform = null;
		private UnityEngine.UI.Text m_E_EquipPropertyTextText = null;
		private UnityEngine.RectTransform m_EG_UIEquipGemHoleSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_UIEquipGemHole_1RectTransform = null;
		private UnityEngine.UI.Image m_E_UIEquipGemHoleIcon_1Image = null;
		private UnityEngine.UI.Text m_E_UIEquipGemHoleText_1Text = null;
		private UnityEngine.RectTransform m_EG_UIEquipGemHole_2RectTransform = null;
		private UnityEngine.UI.Image m_E_UIEquipGemHoleIcon_2Image = null;
		private UnityEngine.UI.Text m_E_UIEquipGemHoleText_2Text = null;
		private UnityEngine.RectTransform m_EG_UIEquipGemHole_3RectTransform = null;
		private UnityEngine.UI.Image m_E_UIEquipGemHoleIcon_3Image = null;
		private UnityEngine.UI.Text m_E_UIEquipGemHoleText_3Text = null;
		private UnityEngine.RectTransform m_EG_UIEquipGemHole_4RectTransform = null;
		private UnityEngine.UI.Image m_E_UIEquipGemHoleIcon_4Image = null;
		private UnityEngine.UI.Text m_E_UIEquipGemHoleText_4Text = null;
		private UnityEngine.RectTransform m_EG_EquipZhuanJingSetRectTransform = null;
		private UnityEngine.UI.Text m_E_ZhuanJingStatusDesText = null;
		private UnityEngine.UI.Image m_E_ZhuanJingStatusImgImage = null;
		private UnityEngine.RectTransform m_EG_EquipZhuanJingSetListRectTransform = null;
		private UnityEngine.RectTransform m_EG_UIEquipSuitRectTransform = null;
		private UnityEngine.UI.Text m_E_SuitNameText = null;
		private UnityEngine.UI.Button m_E_ShowEquipSuitButton = null;
		private UnityEngine.UI.Image m_E_ShowEquipSuitImage = null;
		private UnityEngine.RectTransform m_EG_EquipSuitSetListRectTransform = null;
		private UnityEngine.RectTransform m_EG_EquipSuitShowListSetRectTransform = null;
		private UnityEngine.UI.Text m_EquipSuitItemNamePropertyTextText = null;
		private UnityEngine.RectTransform m_EG_EquipHintSkillRectTransform = null;
		private UnityEngine.UI.Text m_E_WearNeedText = null;
		private UnityEngine.RectTransform m_EG_EquipBtnSetRectTransform = null;
		private UnityEngine.UI.Text m_E_EquipMakeText = null;
		private UnityEngine.UI.Button m_E_TakeButton = null;
		private UnityEngine.UI.Image m_E_TakeImage = null;
		private UnityEngine.UI.Button m_E_HuiShouFangZhiButton = null;
		private UnityEngine.UI.Image m_E_HuiShouFangZhiImage = null;
		private UnityEngine.RectTransform m_EG_EquipBottomRectTransform = null;
		private UnityEngine.UI.Text m_E_EquipDesText = null;
		private UnityEngine.UI.Button m_E_SaveStoreHouseButton = null;
		private UnityEngine.UI.Image m_E_SaveStoreHouseImage = null;
		private UnityEngine.UI.Button m_E_StoreHouseSetButton = null;
		private UnityEngine.UI.Image m_E_StoreHouseSetImage = null;
		private UnityEngine.RectTransform m_EG_BagOpenSetRectTransform = null;
		private UnityEngine.UI.Button m_E_SellButton = null;
		private UnityEngine.UI.Image m_E_SellImage = null;
		private UnityEngine.UI.Button m_E_UseButton = null;
		private UnityEngine.UI.Image m_E_UseImage = null;
		private UnityEngine.RectTransform m_EG_RoseEquipOpenSetRectTransform = null;
		private UnityEngine.UI.Button m_E_TakeoffButton = null;
		private UnityEngine.UI.Image m_E_TakeoffImage = null;
		public Transform uiTransform = null;
	}
}
