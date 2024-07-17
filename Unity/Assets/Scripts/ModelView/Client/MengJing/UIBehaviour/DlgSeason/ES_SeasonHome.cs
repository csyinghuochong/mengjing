using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SeasonHome : Entity,IAwake<Transform>,IDestroy 
	{
		public Text E_SeasonTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonTextText == null )
     			{
		    		this.m_E_SeasonTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_SeasonText");
     			}
     			return this.m_E_SeasonTextText;
     		}
     	}

		public Text E_SeasonTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonTimeTextText == null )
     			{
		    		this.m_E_SeasonTimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_SeasonTimeText");
     			}
     			return this.m_E_SeasonTimeTextText;
     		}
     	}

		public Image E_SeasonExperienceImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonExperienceImgImage == null )
     			{
		    		this.m_E_SeasonExperienceImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_SeasonExperienceImg");
     			}
     			return this.m_E_SeasonExperienceImgImage;
     		}
     	}

		public Text E_SeasonExperienceTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonExperienceTextText == null )
     			{
		    		this.m_E_SeasonExperienceTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_SeasonExperienceText");
     			}
     			return this.m_E_SeasonExperienceTextText;
     		}
     	}

		public Text E_SeasonLvTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonLvTextText == null )
     			{
		    		this.m_E_SeasonLvTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"SeasonLv/E_SeasonLvText");
     			}
     			return this.m_E_SeasonLvTextText;
     		}
     	}

		public Image E_MonsterHeadImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MonsterHeadImgImage == null )
     			{
		    		this.m_E_MonsterHeadImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_MonsterHeadImg");
     			}
     			return this.m_E_MonsterHeadImgImage;
     		}
     	}

		public Text E_MonsterNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MonsterNameTextText == null )
     			{
		    		this.m_E_MonsterNameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_MonsterNameText");
     			}
     			return this.m_E_MonsterNameTextText;
     		}
     	}

		public Text E_MonsterPositionTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MonsterPositionTextText == null )
     			{
		    		this.m_E_MonsterPositionTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_MonsterPositionText");
     			}
     			return this.m_E_MonsterPositionTextText;
     		}
     	}

		public Text E_MonsterRefreshTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MonsterRefreshTimeTextText == null )
     			{
		    		this.m_E_MonsterRefreshTimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_MonsterRefreshTimeText");
     			}
     			return this.m_E_MonsterRefreshTimeTextText;
     		}
     	}

		public Button E_ShowBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowBtnButton == null )
     			{
		    		this.m_E_ShowBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ShowBtn");
     			}
     			return this.m_E_ShowBtnButton;
     		}
     	}

		public Image E_ShowBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowBtnImage == null )
     			{
		    		this.m_E_ShowBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ShowBtn");
     			}
     			return this.m_E_ShowBtnImage;
     		}
     	}

		public Text E_SeasonRewardTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonRewardTextText == null )
     			{
		    		this.m_E_SeasonRewardTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_SeasonRewardText");
     			}
     			return this.m_E_SeasonRewardTextText;
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

		public Button E_GetBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GetBtnButton == null )
     			{
		    		this.m_E_GetBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_GetBtn");
     			}
     			return this.m_E_GetBtnButton;
     		}
     	}

		public Image E_GetBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GetBtnImage == null )
     			{
		    		this.m_E_GetBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_GetBtn");
     			}
     			return this.m_E_GetBtnImage;
     		}
     	}

		public Image E_AcvityedImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AcvityedImgImage == null )
     			{
		    		this.m_E_AcvityedImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_AcvityedImg");
     			}
     			return this.m_E_AcvityedImgImage;
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
			this.m_E_SeasonTextText = null;
			this.m_E_SeasonTimeTextText = null;
			this.m_E_SeasonExperienceImgImage = null;
			this.m_E_SeasonExperienceTextText = null;
			this.m_E_SeasonLvTextText = null;
			this.m_E_MonsterHeadImgImage = null;
			this.m_E_MonsterNameTextText = null;
			this.m_E_MonsterPositionTextText = null;
			this.m_E_MonsterRefreshTimeTextText = null;
			this.m_E_ShowBtnButton = null;
			this.m_E_ShowBtnImage = null;
			this.m_E_SeasonRewardTextText = null;
			this.m_es_rewardlist = null;
			this.m_E_GetBtnButton = null;
			this.m_E_GetBtnImage = null;
			this.m_E_AcvityedImgImage = null;
			this.uiTransform = null;
		}

		private Text m_E_SeasonTextText = null;
		private Text m_E_SeasonTimeTextText = null;
		private Image m_E_SeasonExperienceImgImage = null;
		private Text m_E_SeasonExperienceTextText = null;
		private Text m_E_SeasonLvTextText = null;
		private Image m_E_MonsterHeadImgImage = null;
		private Text m_E_MonsterNameTextText = null;
		private Text m_E_MonsterPositionTextText = null;
		private Text m_E_MonsterRefreshTimeTextText = null;
		private Button m_E_ShowBtnButton = null;
		private Image m_E_ShowBtnImage = null;
		private Text m_E_SeasonRewardTextText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_GetBtnButton = null;
		private Image m_E_GetBtnImage = null;
		private Image m_E_AcvityedImgImage = null;
		public Transform uiTransform = null;
	}
}
