using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTeamDungeonCreate))]
	[EnableMethod]
	public  class DlgTeamDungeonCreateViewComponent : Entity,IAwake,IDestroy 
	{
		public Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public Image E_DungeonImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DungeonImgImage == null )
     			{
		    		this.m_E_DungeonImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_DungeonImg");
     			}
     			return this.m_E_DungeonImgImage;
     		}
     	}

		public Button E_Button_CreateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CreateButton == null )
     			{
		    		this.m_E_Button_CreateButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Create");
     			}
     			return this.m_E_Button_CreateButton;
     		}
     	}

		public Image E_Button_CreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CreateImage == null )
     			{
		    		this.m_E_Button_CreateImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Create");
     			}
     			return this.m_E_Button_CreateImage;
     		}
     	}

		public Text E_TextFubenName2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextFubenName2Text == null )
     			{
		    		this.m_E_TextFubenName2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextFubenName2");
     			}
     			return this.m_E_TextFubenName2Text;
     		}
     	}

		public Text E_TextFubenDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextFubenDescText == null )
     			{
		    		this.m_E_TextFubenDescText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextFubenDesc");
     			}
     			return this.m_E_TextFubenDescText;
     		}
     	}

		public Text E_TextPlayerLimitText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextPlayerLimitText == null )
     			{
		    		this.m_E_TextPlayerLimitText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextPlayerLimit");
     			}
     			return this.m_E_TextPlayerLimitText;
     		}
     	}

		public Text E_TextLevelLimitText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLevelLimitText == null )
     			{
		    		this.m_E_TextLevelLimitText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLevelLimit");
     			}
     			return this.m_E_TextLevelLimitText;
     		}
     	}

		public RectTransform EG_TeamdungeonListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TeamdungeonListRectTransform == null )
     			{
		    		this.m_EG_TeamdungeonListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_TeamdungeonList");
     			}
     			return this.m_EG_TeamdungeonListRectTransform;
     		}
     	}

		public RectTransform EG_TeamdungeonItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TeamdungeonItemRectTransform == null )
     			{
		    		this.m_EG_TeamdungeonItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_TeamdungeonList/EG_TeamdungeonItem");
     			}
     			return this.m_EG_TeamdungeonItemRectTransform;
     		}
     	}

		public Image E_ImageSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectImage == null )
     			{
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_TeamdungeonList/EG_TeamdungeonItem/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public Button E_Button_XieZhuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_XieZhuButton == null )
     			{
		    		this.m_E_Button_XieZhuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_XieZhu");
     			}
     			return this.m_E_Button_XieZhuButton;
     		}
     	}

		public Image E_Button_XieZhuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_XieZhuImage == null )
     			{
		    		this.m_E_Button_XieZhuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_XieZhu");
     			}
     			return this.m_E_Button_XieZhuImage;
     		}
     	}

		public Button E_CloseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonButton == null )
     			{
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonButton;
     		}
     	}

		public Image E_CloseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonImage == null )
     			{
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public RectTransform EG_ShenYuanRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ShenYuanRectTransform == null )
     			{
		    		this.m_EG_ShenYuanRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ShenYuan");
     			}
     			return this.m_EG_ShenYuanRectTransform;
     		}
     	}

		public Button E_ShenYuanButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShenYuanButtonButton == null )
     			{
		    		this.m_E_ShenYuanButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShenYuan/E_ShenYuanButton");
     			}
     			return this.m_E_ShenYuanButtonButton;
     		}
     	}

		public Image E_ShenYuanButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShenYuanButtonImage == null )
     			{
		    		this.m_E_ShenYuanButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShenYuan/E_ShenYuanButton");
     			}
     			return this.m_E_ShenYuanButtonImage;
     		}
     	}

		public Image E_ShenYuanModeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShenYuanModeImage == null )
     			{
		    		this.m_E_ShenYuanModeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShenYuan/E_ShenYuanMode");
     			}
     			return this.m_E_ShenYuanModeImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonImage = null;
			this.m_E_DungeonImgImage = null;
			this.m_E_Button_CreateButton = null;
			this.m_E_Button_CreateImage = null;
			this.m_E_TextFubenName2Text = null;
			this.m_E_TextFubenDescText = null;
			this.m_E_TextPlayerLimitText = null;
			this.m_E_TextLevelLimitText = null;
			this.m_EG_TeamdungeonListRectTransform = null;
			this.m_EG_TeamdungeonItemRectTransform = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_Button_XieZhuButton = null;
			this.m_E_Button_XieZhuImage = null;
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_es_rewardlist = null;
			this.m_EG_ShenYuanRectTransform = null;
			this.m_E_ShenYuanButtonButton = null;
			this.m_E_ShenYuanButtonImage = null;
			this.m_E_ShenYuanModeImage = null;
			this.uiTransform = null;
		}

		private Image m_E_ImageButtonImage = null;
		private Image m_E_DungeonImgImage = null;
		private Button m_E_Button_CreateButton = null;
		private Image m_E_Button_CreateImage = null;
		private Text m_E_TextFubenName2Text = null;
		private Text m_E_TextFubenDescText = null;
		private Text m_E_TextPlayerLimitText = null;
		private Text m_E_TextLevelLimitText = null;
		private RectTransform m_EG_TeamdungeonListRectTransform = null;
		private RectTransform m_EG_TeamdungeonItemRectTransform = null;
		private Image m_E_ImageSelectImage = null;
		private Button m_E_Button_XieZhuButton = null;
		private Image m_E_Button_XieZhuImage = null;
		private Button m_E_CloseButtonButton = null;
		private Image m_E_CloseButtonImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private RectTransform m_EG_ShenYuanRectTransform = null;
		private Button m_E_ShenYuanButtonButton = null;
		private Image m_E_ShenYuanButtonImage = null;
		private Image m_E_ShenYuanModeImage = null;
		public Transform uiTransform = null;
	}
}
