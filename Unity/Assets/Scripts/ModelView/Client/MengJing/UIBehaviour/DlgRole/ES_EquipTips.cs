using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_EquipTips : Entity,IAwake<Transform>,IDestroy
	{
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public ItemOperateEnum ItemOpetateType;
		public int CurrentHouse;
		public float TitleBigHeight_234;      //底图头部的宽度
		public float TextItemHeight_40;       //底图属性的宽度
		public float TitleMiniHeight_50;

		public float ExceedWidth { get; set; } = 0f;

		public GameObject[] Obj_UIEquipGemHoleList;
		public GameObject[] Obj_UIEquipGemHoleTextList;
		public GameObject[] Obj_UIEquipGemHoleIconList;
		
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

		public Image E_EquipQualityImage
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
		    		this.m_E_EquipQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_EquipQuality");
     			}
     			return this.m_E_EquipQualityImage;
     		}
     	}

		public Image E_EquipIconImage
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
		    		this.m_E_EquipIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_EquipIcon");
     			}
     			return this.m_E_EquipIconImage;
     		}
     	}

		public Text E_EquipNameText
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
		    		this.m_E_EquipNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_EquipName");
     			}
     			return this.m_E_EquipNameText;
     		}
     	}

		public Text E_EquipTypeSonText
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
		    		this.m_E_EquipTypeSonText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_EquipTypeSon");
     			}
     			return this.m_E_EquipTypeSonText;
     		}
     	}

		public Text E_EquipTypeText
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
		    		this.m_E_EquipTypeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_EquipType");
     			}
     			return this.m_E_EquipTypeText;
     		}
     	}

		public Text E_EquipNeedLvText
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
		    		this.m_E_EquipNeedLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_EquipNeedLv");
     			}
     			return this.m_E_EquipNeedLvText;
     		}
     	}

		public Text E_EquipBangDingText
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
		    		this.m_E_EquipBangDingText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_EquipBangDing");
     			}
     			return this.m_E_EquipBangDingText;
     		}
     	}

		public Image E_EquipBangDingImgImage
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
		    		this.m_E_EquipBangDingImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/E_EquipBangDingImg");
     			}
     			return this.m_E_EquipBangDingImgImage;
     		}
     	}

		public Text E_EquipQiangHuaText
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
		    		this.m_E_EquipQiangHuaText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_EquipQiangHua");
     			}
     			return this.m_E_EquipQiangHuaText;
     		}
     	}

		public RectTransform EG_EquipBaseSetListRectTransform
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
		    		this.m_EG_EquipBaseSetListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBaseSetList");
     			}
     			return this.m_EG_EquipBaseSetListRectTransform;
     		}
     	}

		public Text E_EquipPropertyTextText
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
		    		this.m_E_EquipPropertyTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/E_EquipPropertyText");
     			}
     			return this.m_E_EquipPropertyTextText;
     		}
     	}

		public RectTransform EG_UIEquipGemHoleSetRectTransform
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
		    		this.m_EG_UIEquipGemHoleSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet");
     			}
     			return this.m_EG_UIEquipGemHoleSetRectTransform;
     		}
     	}

		public RectTransform EG_UIEquipGemHole_1RectTransform
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
		    		this.m_EG_UIEquipGemHole_1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1");
     			}
     			return this.m_EG_UIEquipGemHole_1RectTransform;
     		}
     	}

		public Image E_UIEquipGemHoleIcon_1Image
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
		    		this.m_E_UIEquipGemHoleIcon_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1/E_UIEquipGemHoleIcon_1");
     			}
     			return this.m_E_UIEquipGemHoleIcon_1Image;
     		}
     	}

		public Text E_UIEquipGemHoleText_1Text
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
		    		this.m_E_UIEquipGemHoleText_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1/E_UIEquipGemHoleText_1");
     			}
     			return this.m_E_UIEquipGemHoleText_1Text;
     		}
     	}

		public RectTransform EG_UIEquipGemHole_2RectTransform
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
		    		this.m_EG_UIEquipGemHole_2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_2");
     			}
     			return this.m_EG_UIEquipGemHole_2RectTransform;
     		}
     	}

		public Image E_UIEquipGemHoleIcon_2Image
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
		    		this.m_E_UIEquipGemHoleIcon_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_2/E_UIEquipGemHoleIcon_2");
     			}
     			return this.m_E_UIEquipGemHoleIcon_2Image;
     		}
     	}

		public Text E_UIEquipGemHoleText_2Text
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
		    		this.m_E_UIEquipGemHoleText_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_2/E_UIEquipGemHoleText_2");
     			}
     			return this.m_E_UIEquipGemHoleText_2Text;
     		}
     	}

		public RectTransform EG_UIEquipGemHole_3RectTransform
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
		    		this.m_EG_UIEquipGemHole_3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_3");
     			}
     			return this.m_EG_UIEquipGemHole_3RectTransform;
     		}
     	}

		public Image E_UIEquipGemHoleIcon_3Image
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
		    		this.m_E_UIEquipGemHoleIcon_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_3/E_UIEquipGemHoleIcon_3");
     			}
     			return this.m_E_UIEquipGemHoleIcon_3Image;
     		}
     	}

		public Text E_UIEquipGemHoleText_3Text
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
		    		this.m_E_UIEquipGemHoleText_3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_3/E_UIEquipGemHoleText_3");
     			}
     			return this.m_E_UIEquipGemHoleText_3Text;
     		}
     	}

		public RectTransform EG_UIEquipGemHole_4RectTransform
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
		    		this.m_EG_UIEquipGemHole_4RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_4");
     			}
     			return this.m_EG_UIEquipGemHole_4RectTransform;
     		}
     	}

		public Image E_UIEquipGemHoleIcon_4Image
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
		    		this.m_E_UIEquipGemHoleIcon_4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_4/E_UIEquipGemHoleIcon_4");
     			}
     			return this.m_E_UIEquipGemHoleIcon_4Image;
     		}
     	}

		public Text E_UIEquipGemHoleText_4Text
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
		    		this.m_E_UIEquipGemHoleText_4Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_4/E_UIEquipGemHoleText_4");
     			}
     			return this.m_E_UIEquipGemHoleText_4Text;
     		}
     	}

		public RectTransform EG_EquipZhuanJingSetRectTransform
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
		    		this.m_EG_EquipZhuanJingSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipZhuanJingSet");
     			}
     			return this.m_EG_EquipZhuanJingSetRectTransform;
     		}
     	}

		public Text E_ZhuanJingStatusDesText
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
		    		this.m_E_ZhuanJingStatusDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_EquipZhuanJingSet/Img_Title_1/E_ZhuanJingStatusDes");
     			}
     			return this.m_E_ZhuanJingStatusDesText;
     		}
     	}

		public Image E_ZhuanJingStatusImgImage
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
		    		this.m_E_ZhuanJingStatusImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_EquipZhuanJingSet/Img_Title_1/E_ZhuanJingStatusDes/E_ZhuanJingStatusImg");
     			}
     			return this.m_E_ZhuanJingStatusImgImage;
     		}
     	}

		public RectTransform EG_EquipZhuanJingSetListRectTransform
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
		    		this.m_EG_EquipZhuanJingSetListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipZhuanJingSet/EG_EquipZhuanJingSetList");
     			}
     			return this.m_EG_EquipZhuanJingSetListRectTransform;
     		}
     	}

		public RectTransform EG_UIEquipSuitRectTransform
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
		    		this.m_EG_UIEquipSuitRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit");
     			}
     			return this.m_EG_UIEquipSuitRectTransform;
     		}
     	}

		public Text E_SuitNameText
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
		    		this.m_E_SuitNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/E_SuitName");
     			}
     			return this.m_E_SuitNameText;
     		}
     	}

		public Button E_ShowEquipSuitButton
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
		    		this.m_E_ShowEquipSuitButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/E_ShowEquipSuit");
     			}
     			return this.m_E_ShowEquipSuitButton;
     		}
     	}

		public Image E_ShowEquipSuitImage
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
		    		this.m_E_ShowEquipSuitImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/E_ShowEquipSuit");
     			}
     			return this.m_E_ShowEquipSuitImage;
     		}
     	}

		public RectTransform EG_EquipSuitSetListRectTransform
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
		    		this.m_EG_EquipSuitSetListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/EG_EquipSuitSetList");
     			}
     			return this.m_EG_EquipSuitSetListRectTransform;
     		}
     	}

		public RectTransform EG_EquipSuitShowListSetRectTransform
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
		    		this.m_EG_EquipSuitShowListSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/EG_EquipSuitShowListSet");
     			}
     			return this.m_EG_EquipSuitShowListSetRectTransform;
     		}
     	}

		public Text EquipSuitItemNamePropertyTextText
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
		    		this.m_EquipSuitItemNamePropertyTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipSuit/EG_EquipSuitShowListSet/Img_back (2)/EquipSuitShowNameListSet/EquipSuitItemNamePropertyText");
     			}
     			return this.m_EquipSuitItemNamePropertyTextText;
     		}
     	}

		public RectTransform EG_EquipHintSkillRectTransform
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
		    		this.m_EG_EquipHintSkillRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipHintSkill");
     			}
     			return this.m_EG_EquipHintSkillRectTransform;
     		}
     	}

		public RectTransform EG_EquipHintSkillSetList
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_EG_EquipHintSkillSetList == null )
				{
					this.m_EG_EquipHintSkillSetList = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipHintSkill/E_EquipHintSkillSetList");
				}
				return this.m_EG_EquipHintSkillSetList;
			}
		}

		public Text E_WearNeedText
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
		    		this.m_E_WearNeedText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_EquipHintSkill/E_WearNeed");
     			}
     			return this.m_E_WearNeedText;
     		}
     	}

		public RectTransform EG_EquipBtnSetRectTransform
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
		    		this.m_EG_EquipBtnSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet");
     			}
     			return this.m_EG_EquipBtnSetRectTransform;
     		}
     	}

		public Text E_EquipMakeText
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
		    		this.m_E_EquipMakeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_EquipMake");
     			}
     			return this.m_E_EquipMakeText;
     		}
     	}

		public Button E_TakeButton
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
		    		this.m_E_TakeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_Take");
     			}
     			return this.m_E_TakeButton;
     		}
     	}

		public Image E_TakeImage
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
		    		this.m_E_TakeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_Take");
     			}
     			return this.m_E_TakeImage;
     		}
     	}

		public Button E_HuiShouFangZhiButton
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
		    		this.m_E_HuiShouFangZhiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_HuiShouFangZhi");
     			}
     			return this.m_E_HuiShouFangZhiButton;
     		}
     	}

		public Image E_HuiShouFangZhiImage
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
		    		this.m_E_HuiShouFangZhiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_HuiShouFangZhi");
     			}
     			return this.m_E_HuiShouFangZhiImage;
     		}
     	}

		public RectTransform EG_EquipBottomRectTransform
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
		    		this.m_EG_EquipBottomRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_EquipBottom");
     			}
     			return this.m_EG_EquipBottomRectTransform;
     		}
     	}

		public Text E_EquipDesText
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
		    		this.m_E_EquipDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_EquipBottom/E_EquipDes");
     			}
     			return this.m_E_EquipDesText;
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
		    		this.m_E_SaveStoreHouseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_SaveStoreHouse");
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
		    		this.m_E_SaveStoreHouseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_SaveStoreHouse");
     			}
     			return this.m_E_SaveStoreHouseImage;
     		}
     	}

		public Button E_StoreHouseSetButton
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
		    		this.m_E_StoreHouseSetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_StoreHouseSet");
     			}
     			return this.m_E_StoreHouseSetButton;
     		}
     	}

		public Image E_StoreHouseSetImage
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
		    		this.m_E_StoreHouseSetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_StoreHouseSet");
     			}
     			return this.m_E_StoreHouseSetImage;
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
		    		this.m_EG_BagOpenSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet");
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
		    		this.m_E_SellButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Sell");
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
		    		this.m_E_SellImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Sell");
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
		    		this.m_E_UseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Use");
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
		    		this.m_E_UseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Use");
     			}
     			return this.m_E_UseImage;
     		}
     	}

		public RectTransform EG_RoseEquipOpenSetRectTransform
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
		    		this.m_EG_RoseEquipOpenSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_RoseEquipOpenSet");
     			}
     			return this.m_EG_RoseEquipOpenSetRectTransform;
     		}
     	}

		public Button E_TakeoffButton
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
		    		this.m_E_TakeoffButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_RoseEquipOpenSet/E_Takeoff");
     			}
     			return this.m_E_TakeoffButton;
     		}
     	}

		public Image E_TakeoffImage
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
		    		this.m_E_TakeoffImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_RoseEquipOpenSet/E_Takeoff");
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
			this.m_EG_EquipHintSkillSetList = null;
			this.m_E_TakeoffButton = null;
			this.m_E_TakeoffImage = null;
			this.uiTransform = null;
		}

		private Image m_E_BackImage = null;
		private Image m_E_QualityBgImage = null;
		private Image m_E_QualityLineImage = null;
		private Image m_E_EquipQualityImage = null;
		private Image m_E_EquipIconImage = null;
		private Text m_E_EquipNameText = null;
		private Text m_E_EquipTypeSonText = null;
		private Text m_E_EquipTypeText = null;
		private Text m_E_EquipNeedLvText = null;
		private Text m_E_EquipBangDingText = null;
		private Image m_E_EquipBangDingImgImage = null;
		private Text m_E_EquipQiangHuaText = null;
		private RectTransform m_EG_EquipBaseSetListRectTransform = null;
		private Text m_E_EquipPropertyTextText = null;
		private RectTransform m_EG_UIEquipGemHoleSetRectTransform = null;
		private RectTransform m_EG_UIEquipGemHole_1RectTransform = null;
		private Image m_E_UIEquipGemHoleIcon_1Image = null;
		private Text m_E_UIEquipGemHoleText_1Text = null;
		private RectTransform m_EG_UIEquipGemHole_2RectTransform = null;
		private Image m_E_UIEquipGemHoleIcon_2Image = null;
		private Text m_E_UIEquipGemHoleText_2Text = null;
		private RectTransform m_EG_UIEquipGemHole_3RectTransform = null;
		private Image m_E_UIEquipGemHoleIcon_3Image = null;
		private Text m_E_UIEquipGemHoleText_3Text = null;
		private RectTransform m_EG_UIEquipGemHole_4RectTransform = null;
		private Image m_E_UIEquipGemHoleIcon_4Image = null;
		private Text m_E_UIEquipGemHoleText_4Text = null;
		private RectTransform m_EG_EquipZhuanJingSetRectTransform = null;
		private Text m_E_ZhuanJingStatusDesText = null;
		private Image m_E_ZhuanJingStatusImgImage = null;
		private RectTransform m_EG_EquipZhuanJingSetListRectTransform = null;
		private RectTransform m_EG_UIEquipSuitRectTransform = null;
		private Text m_E_SuitNameText = null;
		private Button m_E_ShowEquipSuitButton = null;
		private Image m_E_ShowEquipSuitImage = null;
		private RectTransform m_EG_EquipSuitSetListRectTransform = null;
		private RectTransform m_EG_EquipSuitShowListSetRectTransform = null;
		private Text m_EquipSuitItemNamePropertyTextText = null;
		private RectTransform m_EG_EquipHintSkillRectTransform = null;
		private Text m_E_WearNeedText = null;
		private RectTransform m_EG_EquipBtnSetRectTransform = null;
		private Text m_E_EquipMakeText = null;
		private Button m_E_TakeButton = null;
		private Image m_E_TakeImage = null;
		private Button m_E_HuiShouFangZhiButton = null;
		private Image m_E_HuiShouFangZhiImage = null;
		private RectTransform m_EG_EquipBottomRectTransform = null;
		private Text m_E_EquipDesText = null;
		private Button m_E_SaveStoreHouseButton = null;
		private Image m_E_SaveStoreHouseImage = null;
		private Button m_E_StoreHouseSetButton = null;
		private Image m_E_StoreHouseSetImage = null;
		private RectTransform m_EG_BagOpenSetRectTransform = null;
		private Button m_E_SellButton = null;
		private Image m_E_SellImage = null;
		private Button m_E_UseButton = null;
		private Image m_E_UseImage = null;
		private RectTransform m_EG_RoseEquipOpenSetRectTransform = null;
		private RectTransform m_EG_EquipHintSkillSetList = null;
		private Button m_E_TakeoffButton = null;
		private Image m_E_TakeoffImage = null;
		public Transform uiTransform = null;
	}
}
