using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityMaoXian : Entity,IAwake<Transform>,IDestroy 
	{
		public int CurActivityId;
		
		public Text E_Text_TitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TitleText == null )
     			{
		    		this.m_E_Text_TitleText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Title");
     			}
     			return this.m_E_Text_TitleText;
     		}
     	}

		public Button E_Btn_GetRewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GetRewardButton == null )
     			{
		    		this.m_E_Btn_GetRewardButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_GetReward");
     			}
     			return this.m_E_Btn_GetRewardButton;
     		}
     	}

		public Image E_Btn_GetRewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GetRewardImage == null )
     			{
		    		this.m_E_Btn_GetRewardImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_GetReward");
     			}
     			return this.m_E_Btn_GetRewardImage;
     		}
     	}

		public Button E_Btn_GoToSupportButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GoToSupportButton == null )
     			{
		    		this.m_E_Btn_GoToSupportButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_GoToSupport");
     			}
     			return this.m_E_Btn_GoToSupportButton;
     		}
     	}

		public Image E_Btn_GoToSupportImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GoToSupportImage == null )
     			{
		    		this.m_E_Btn_GoToSupportImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_GoToSupport");
     			}
     			return this.m_E_Btn_GoToSupportImage;
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
		    		this.m_E_ImageProgressImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageDi/E_ImageProgress");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Button E_ButtonLeftButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonLeftButton == null )
     			{
		    		this.m_E_ButtonLeftButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonLeft");
     			}
     			return this.m_E_ButtonLeftButton;
     		}
     	}

		public Image E_ButtonLeftImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonLeftImage == null )
     			{
		    		this.m_E_ButtonLeftImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonLeft");
     			}
     			return this.m_E_ButtonLeftImage;
     		}
     	}

		public Button E_ButtonRightButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRightButton == null )
     			{
		    		this.m_E_ButtonRightButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonRight");
     			}
     			return this.m_E_ButtonRightButton;
     		}
     	}

		public Image E_ButtonRightImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRightImage == null )
     			{
		    		this.m_E_ButtonRightImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonRight");
     			}
     			return this.m_E_ButtonRightImage;
     		}
     	}

		public Image E_ImageReceivedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageReceivedImage == null )
     			{
		    		this.m_E_ImageReceivedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageReceived");
     			}
     			return this.m_E_ImageReceivedImage;
     		}
     	}

		public Text E_Text_ProgressText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ProgressText == null )
     			{
		    		this.m_E_Text_ProgressText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Progress");
     			}
     			return this.m_E_Text_ProgressText;
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
			this.m_E_Text_TitleText = null;
			this.m_E_Btn_GetRewardButton = null;
			this.m_E_Btn_GetRewardImage = null;
			this.m_E_Btn_GoToSupportButton = null;
			this.m_E_Btn_GoToSupportImage = null;
			this.m_E_ImageProgressImage = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonLeftButton = null;
			this.m_E_ButtonLeftImage = null;
			this.m_E_ButtonRightButton = null;
			this.m_E_ButtonRightImage = null;
			this.m_E_ImageReceivedImage = null;
			this.m_E_Text_ProgressText = null;
			this.uiTransform = null;
		}

		private Text m_E_Text_TitleText = null;
		private Button m_E_Btn_GetRewardButton = null;
		private Image m_E_Btn_GetRewardImage = null;
		private Button m_E_Btn_GoToSupportButton = null;
		private Image m_E_Btn_GoToSupportImage = null;
		private Image m_E_ImageProgressImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_ButtonLeftButton = null;
		private Image m_E_ButtonLeftImage = null;
		private Button m_E_ButtonRightButton = null;
		private Image m_E_ButtonRightImage = null;
		private Image m_E_ImageReceivedImage = null;
		private Text m_E_Text_ProgressText = null;
		public Transform uiTransform = null;
	}
}
