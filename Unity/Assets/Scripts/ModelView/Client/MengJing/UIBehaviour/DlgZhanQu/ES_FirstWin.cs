using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FirstWin : Entity,IAwake<Transform>,IDestroy
	{
		public List<GameObject> SkillDescriptionList = new();
		public GameObject TypeListNode;
		public UITypeViewComponent UITypeViewComponent { get; set; }

		public List<FirstWinInfo> FirstWinInfos = new();
		public int FirstWinId;
		public long LastUpdateTime;
		public int BossId;
		public int ChapterId;

		public Image E_ImageBossIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBossIconImage == null )
     			{
		    		this.m_E_ImageBossIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ImageBossIcon");
     			}
     			return this.m_E_ImageBossIconImage;
     		}
     	}

		public Image E_ImageProgressImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageProgressImage == null )
     			{
		    		this.m_E_ImageProgressImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ImageProgress");
     			}
     			return this.m_E_ImageProgressImage;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Button E_Button_FirstWinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_FirstWinButton == null )
     			{
		    		this.m_E_Button_FirstWinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Button_FirstWin");
     			}
     			return this.m_E_Button_FirstWinButton;
     		}
     	}

		public Button E_Button_SkillDes
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Button_SkillDes == null )
				{
					this.m_E_Button_SkillDes = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Button_SkillDes");
				}
				return this.m_E_Button_SkillDes;
			}
		}

		public Image E_Button_FirstWinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_FirstWinImage == null )
     			{
		    		this.m_E_Button_FirstWinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_FirstWin");
     			}
     			return this.m_E_Button_FirstWinImage;
     		}
     	}

		public Button E_Button_FirstWinSelfButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_FirstWinSelfButton == null )
     			{
		    		this.m_E_Button_FirstWinSelfButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Button_FirstWinSelf");
     			}
     			return this.m_E_Button_FirstWinSelfButton;
     		}
     	}

		public Image E_Button_FirstWinSelfImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_FirstWinSelfImage == null )
     			{
		    		this.m_E_Button_FirstWinSelfImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Button_FirstWinSelf");
     			}
     			return this.m_E_Button_FirstWinSelfImage;
     		}
     	}

		public Text E_Text_UpdateStatusText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_UpdateStatusText == null )
     			{
		    		this.m_E_Text_UpdateStatusText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_UpdateStatus");
     			}
     			return this.m_E_Text_UpdateStatusText;
     		}
     	}

		public Text E_Text_BossDevpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_BossDevpText == null )
     			{
		    		this.m_E_Text_BossDevpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_BossDevp");
     			}
     			return this.m_E_Text_BossDevpText;
     		}
     	}

		public Text E_Text_BossExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_BossExpText == null )
     			{
		    		this.m_E_Text_BossExpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_BossExp");
     			}
     			return this.m_E_Text_BossExpText;
     		}
     	}

		public Text E_Text_SkillJieShaoText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_SkillJieShaoText == null )
     			{
		    		this.m_E_Text_SkillJieShaoText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_SkillJieShao");
     			}
     			return this.m_E_Text_SkillJieShaoText;
     		}
     	}

		public Text E_Text_JiSha_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_JiSha_1Text == null )
     			{
		    		this.m_E_Text_JiSha_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_JiSha_1");
     			}
     			return this.m_E_Text_JiSha_1Text;
     		}
     	}

		public Text E_Text_JiSha_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_JiSha_2Text == null )
     			{
		    		this.m_E_Text_JiSha_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_JiSha_2");
     			}
     			return this.m_E_Text_JiSha_2Text;
     		}
     	}

		public Text E_Text_JiSha_3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_JiSha_3Text == null )
     			{
		    		this.m_E_Text_JiSha_3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_JiSha_3");
     			}
     			return this.m_E_Text_JiSha_3Text;
     		}
     	}

		public Text E_Text_LvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LvText == null )
     			{
		    		this.m_E_Text_LvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Lv");
     			}
     			return this.m_E_Text_LvText;
     		}
     	}

		public RectTransform EG_SkillDescriptionListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillDescriptionListNodeRectTransform == null )
     			{
		    		this.m_EG_SkillDescriptionListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/Scroll View/Viewport/EG_SkillDescriptionListNode");
     			}
     			return this.m_EG_SkillDescriptionListNodeRectTransform;
     		}
     	}

		public Text E_SkillDescriptionItemTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillDescriptionItemTextText == null )
     			{
		    		this.m_E_SkillDescriptionItemTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/Scroll View/Viewport/EG_SkillDescriptionListNode/E_SkillDescriptionItemText");
     			}
     			return this.m_E_SkillDescriptionItemTextText;
     		}
     	}

		public Text E_Text_BossDevpNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_BossDevpNameText == null )
     			{
		    		this.m_E_Text_BossDevpNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_BossDevpName");
     			}
     			return this.m_E_Text_BossDevpNameText;
     		}
     	}

		public Text E_Text_BossFreshTImeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_BossFreshTImeText == null )
     			{
		    		this.m_E_Text_BossFreshTImeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_BossFreshTIme");
     			}
     			return this.m_E_Text_BossFreshTImeText;
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
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public Text E_Text_BossNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_BossNameText == null )
     			{
		    		this.m_E_Text_BossNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_BossName");
     			}
     			return this.m_E_Text_BossNameText;
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
			this.m_E_ImageBossIconImage = null;
			this.m_E_ImageProgressImage = null;
			this.m_es_rewardlist = null;
			this.m_E_Button_FirstWinButton = null;
			this.m_E_Button_FirstWinImage = null;
			this.m_E_Button_FirstWinSelfButton = null;
			this.m_E_Button_SkillDes = null;
			this.m_E_Button_FirstWinSelfImage = null;
			this.m_E_Text_UpdateStatusText = null;
			this.m_E_Text_BossDevpText = null;
			this.m_E_Text_BossExpText = null;
			this.m_E_Text_SkillJieShaoText = null;
			this.m_E_Text_JiSha_1Text = null;
			this.m_E_Text_JiSha_2Text = null;
			this.m_E_Text_JiSha_3Text = null;
			this.m_E_Text_LvText = null;
			this.m_EG_SkillDescriptionListNodeRectTransform = null;
			this.m_E_SkillDescriptionItemTextText = null;
			this.m_E_Text_BossDevpNameText = null;
			this.m_E_Text_BossFreshTImeText = null;
			this.m_es_modelshow = null;
			this.m_E_Text_BossNameText = null;
			this.uiTransform = null;
		}

		private Image m_E_ImageBossIconImage = null;
		private Image m_E_ImageProgressImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_Button_FirstWinButton = null;
		private Image m_E_Button_FirstWinImage = null;
		private Button m_E_Button_FirstWinSelfButton = null;
		private Button m_E_Button_SkillDes = null;
		private Image m_E_Button_FirstWinSelfImage = null;
		private Text m_E_Text_UpdateStatusText = null;
		private Text m_E_Text_BossDevpText = null;
		private Text m_E_Text_BossExpText = null;
		private Text m_E_Text_SkillJieShaoText = null;
		private Text m_E_Text_JiSha_1Text = null;
		private Text m_E_Text_JiSha_2Text = null;
		private Text m_E_Text_JiSha_3Text = null;
		private Text m_E_Text_LvText = null;
		private RectTransform m_EG_SkillDescriptionListNodeRectTransform = null;
		private Text m_E_SkillDescriptionItemTextText = null;
		private Text m_E_Text_BossDevpNameText = null;
		private Text m_E_Text_BossFreshTImeText = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Text m_E_Text_BossNameText = null;
		public Transform uiTransform = null;
	}
}
