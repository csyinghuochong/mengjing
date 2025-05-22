
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityMaoXian : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public int CurActivityId;
		
		public UnityEngine.UI.Image E_ImageProgressImage
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
		    		this.m_E_ImageProgressImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/ImageDi/E_ImageProgress");
     			}
     			return this.m_E_ImageProgressImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ProgressText
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
		    		this.m_E_Text_ProgressText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_Progress");
     			}
     			return this.m_E_Text_ProgressText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_TitleText
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
		    		this.m_E_Text_TitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Title");
     			}
     			return this.m_E_Text_TitleText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_GetRewardButton
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
		    		this.m_E_Btn_GetRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_GetReward");
     			}
     			return this.m_E_Btn_GetRewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_GetRewardImage
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
		    		this.m_E_Btn_GetRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_GetReward");
     			}
     			return this.m_E_Btn_GetRewardImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_GoToSupportButton
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
		    		this.m_E_Btn_GoToSupportButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_GoToSupport");
     			}
     			return this.m_E_Btn_GoToSupportButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_GoToSupportImage
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
		    		this.m_E_Btn_GoToSupportImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_GoToSupport");
     			}
     			return this.m_E_Btn_GoToSupportImage;
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

		public UnityEngine.UI.Button E_ButtonLeftButton
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
		    		this.m_E_ButtonLeftButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonLeft");
     			}
     			return this.m_E_ButtonLeftButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonLeftImage
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
		    		this.m_E_ButtonLeftImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonLeft");
     			}
     			return this.m_E_ButtonLeftImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonRightButton
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
		    		this.m_E_ButtonRightButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonRight");
     			}
     			return this.m_E_ButtonRightButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonRightImage
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
		    		this.m_E_ButtonRightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonRight");
     			}
     			return this.m_E_ButtonRightImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageReceivedImage
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
		    		this.m_E_ImageReceivedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ImageReceived");
     			}
     			return this.m_E_ImageReceivedImage;
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
			this.m_E_ImageProgressImage = null;
			this.m_E_Text_ProgressText = null;
			this.m_E_Text_TitleText = null;
			this.m_E_Btn_GetRewardButton = null;
			this.m_E_Btn_GetRewardImage = null;
			this.m_E_Btn_GoToSupportButton = null;
			this.m_E_Btn_GoToSupportImage = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonLeftButton = null;
			this.m_E_ButtonLeftImage = null;
			this.m_E_ButtonRightButton = null;
			this.m_E_ButtonRightImage = null;
			this.m_E_ImageReceivedImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ImageProgressImage = null;
		private UnityEngine.UI.Text m_E_Text_ProgressText = null;
		private UnityEngine.UI.Text m_E_Text_TitleText = null;
		private UnityEngine.UI.Button m_E_Btn_GetRewardButton = null;
		private UnityEngine.UI.Image m_E_Btn_GetRewardImage = null;
		private UnityEngine.UI.Button m_E_Btn_GoToSupportButton = null;
		private UnityEngine.UI.Image m_E_Btn_GoToSupportImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_ButtonLeftButton = null;
		private UnityEngine.UI.Image m_E_ButtonLeftImage = null;
		private UnityEngine.UI.Button m_E_ButtonRightButton = null;
		private UnityEngine.UI.Image m_E_ButtonRightImage = null;
		private UnityEngine.UI.Image m_E_ImageReceivedImage = null;
		public Transform uiTransform = null;
	}
}
