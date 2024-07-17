using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetChouKaGet))]
	[EnableMethod]
	public  class DlgPetChouKaGetViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_BianYiDiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BianYiDiButton == null )
     			{
		    		this.m_E_BianYiDiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_BianYiDi");
     			}
     			return this.m_E_BianYiDiButton;
     		}
     	}

		public Image E_BianYiDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BianYiDiImage == null )
     			{
		    		this.m_E_BianYiDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_BianYiDi");
     			}
     			return this.m_E_BianYiDiImage;
     		}
     	}

		public Button E_LucklyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LucklyButton == null )
     			{
		    		this.m_E_LucklyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Luckly");
     			}
     			return this.m_E_LucklyButton;
     		}
     	}

		public Image E_LucklyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LucklyImage == null )
     			{
		    		this.m_E_LucklyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Luckly");
     			}
     			return this.m_E_LucklyImage;
     		}
     	}

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
     			if( es==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public RectTransform EG_ImageStarListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ImageStarListRectTransform == null )
     			{
		    		this.m_EG_ImageStarListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_ImageStarList");
     			}
     			return this.m_EG_ImageStarListRectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem1RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem1");
     			}
     			return this.m_EG_PetZiZhiItem1RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem2RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem2");
     			}
     			return this.m_EG_PetZiZhiItem2RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem3RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem3");
     			}
     			return this.m_EG_PetZiZhiItem3RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem4RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem4");
     			}
     			return this.m_EG_PetZiZhiItem4RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem5RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem5RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem5");
     			}
     			return this.m_EG_PetZiZhiItem5RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem6RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem6RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"UIPetInfoShow/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_Text_PetNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetNameText == null )
     			{
		    		this.m_E_Text_PetNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"UIPetInfoShow/E_Text_PetName");
     			}
     			return this.m_E_Text_PetNameText;
     		}
     	}

		public Text E_Text_PetLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetLevelText == null )
     			{
		    		this.m_E_Text_PetLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"UIPetInfoShow/E_Text_PetLevel");
     			}
     			return this.m_E_Text_PetLevelText;
     		}
     	}

		public Text E_Text_TipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TipText == null )
     			{
		    		this.m_E_Text_TipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"UIPetInfoShow/E_Text_Tip");
     			}
     			return this.m_E_Text_TipText;
     		}
     	}

		public Text E_Text_QualityText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_QualityText == null )
     			{
		    		this.m_E_Text_QualityText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"UIPetInfoShow/E_Text_Quality");
     			}
     			return this.m_E_Text_QualityText;
     		}
     	}

		public RectTransform EG_PiFuJiHuoRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PiFuJiHuoRectTransform == null )
     			{
		    		this.m_EG_PiFuJiHuoRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PiFuJiHuo");
     			}
     			return this.m_EG_PiFuJiHuoRectTransform;
     		}
     	}

		public Text E_Text_FightValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_FightValueText == null )
     			{
		    		this.m_E_Text_FightValueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"UIPetInfoShow/E_Text_FightValue");
     			}
     			return this.m_E_Text_FightValueText;
     		}
     	}

		public RectTransform EG_PetSkinIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetSkinIconRectTransform == null )
     			{
		    		this.m_EG_PetSkinIconRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetSkinIcon");
     			}
     			return this.m_EG_PetSkinIconRectTransform;
     		}
     	}

		public Text E_NewSkinNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NewSkinNameText == null )
     			{
		    		this.m_E_NewSkinNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PetSkinIcon/E_NewSkinName");
     			}
     			return this.m_E_NewSkinNameText;
     		}
     	}

		public Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BianYiDiButton = null;
			this.m_E_BianYiDiImage = null;
			this.m_E_LucklyButton = null;
			this.m_E_LucklyImage = null;
			this.m_es_modelshow = null;
			this.m_EG_ImageStarListRectTransform = null;
			this.m_EG_PetZiZhiItem1RectTransform = null;
			this.m_EG_PetZiZhiItem2RectTransform = null;
			this.m_EG_PetZiZhiItem3RectTransform = null;
			this.m_EG_PetZiZhiItem4RectTransform = null;
			this.m_EG_PetZiZhiItem5RectTransform = null;
			this.m_EG_PetZiZhiItem6RectTransform = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.m_E_Text_PetNameText = null;
			this.m_E_Text_PetLevelText = null;
			this.m_E_Text_TipText = null;
			this.m_E_Text_QualityText = null;
			this.m_EG_PiFuJiHuoRectTransform = null;
			this.m_E_Text_FightValueText = null;
			this.m_EG_PetSkinIconRectTransform = null;
			this.m_E_NewSkinNameText = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.uiTransform = null;
		}

		private Button m_E_BianYiDiButton = null;
		private Image m_E_BianYiDiImage = null;
		private Button m_E_LucklyButton = null;
		private Image m_E_LucklyImage = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private RectTransform m_EG_ImageStarListRectTransform = null;
		private RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private Text m_E_Text_PetNameText = null;
		private Text m_E_Text_PetLevelText = null;
		private Text m_E_Text_TipText = null;
		private Text m_E_Text_QualityText = null;
		private RectTransform m_EG_PiFuJiHuoRectTransform = null;
		private Text m_E_Text_FightValueText = null;
		private RectTransform m_EG_PetSkinIconRectTransform = null;
		private Text m_E_NewSkinNameText = null;
		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		public Transform uiTransform = null;
	}
}
