using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityYueKa : Entity,IAwake<Transform>,IDestroy 
	{
		public Image E_Img_JiHuoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_JiHuoImage == null )
     			{
		    		this.m_E_Img_JiHuoImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_JiHuo");
     			}
     			return this.m_E_Img_JiHuoImage;
     		}
     	}

		public Button E_Btn_GoPayButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GoPayButton == null )
     			{
		    		this.m_E_Btn_GoPayButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_GoPay");
     			}
     			return this.m_E_Btn_GoPayButton;
     		}
     	}

		public Image E_Btn_GoPayImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GoPayImage == null )
     			{
		    		this.m_E_Btn_GoPayImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_GoPay");
     			}
     			return this.m_E_Btn_GoPayImage;
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

		public RectTransform EG_BtnOpenYueKaSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BtnOpenYueKaSetRectTransform == null )
     			{
		    		this.m_EG_BtnOpenYueKaSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_BtnOpenYueKaSet");
     			}
     			return this.m_EG_BtnOpenYueKaSetRectTransform;
     		}
     	}

		public Text E_TextYueKaCostText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextYueKaCostText == null )
     			{
		    		this.m_E_TextYueKaCostText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_BtnOpenYueKaSet/E_TextYueKaCost");
     			}
     			return this.m_E_TextYueKaCostText;
     		}
     	}

		public Button E_Btn_OpenYueKaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_OpenYueKaButton == null )
     			{
		    		this.m_E_Btn_OpenYueKaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_BtnOpenYueKaSet/E_Btn_OpenYueKa");
     			}
     			return this.m_E_Btn_OpenYueKaButton;
     		}
     	}

		public Image E_Btn_OpenYueKaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_OpenYueKaImage == null )
     			{
		    		this.m_E_Btn_OpenYueKaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_BtnOpenYueKaSet/E_Btn_OpenYueKa");
     			}
     			return this.m_E_Btn_OpenYueKaImage;
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

		public Text E_Text_RemainingtimesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_RemainingtimesText == null )
     			{
		    		this.m_E_Text_RemainingtimesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Remainingtimes");
     			}
     			return this.m_E_Text_RemainingtimesText;
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
			this.m_E_Img_JiHuoImage = null;
			this.m_E_Btn_GoPayButton = null;
			this.m_E_Btn_GoPayImage = null;
			this.m_E_Btn_GetRewardButton = null;
			this.m_E_Btn_GetRewardImage = null;
			this.m_EG_BtnOpenYueKaSetRectTransform = null;
			this.m_E_TextYueKaCostText = null;
			this.m_E_Btn_OpenYueKaButton = null;
			this.m_E_Btn_OpenYueKaImage = null;
			this.m_es_rewardlist = null;
			this.m_E_Text_RemainingtimesText = null;
			this.uiTransform = null;
		}

		private Image m_E_Img_JiHuoImage = null;
		private Button m_E_Btn_GoPayButton = null;
		private Image m_E_Btn_GoPayImage = null;
		private Button m_E_Btn_GetRewardButton = null;
		private Image m_E_Btn_GetRewardImage = null;
		private RectTransform m_EG_BtnOpenYueKaSetRectTransform = null;
		private Text m_E_TextYueKaCostText = null;
		private Button m_E_Btn_OpenYueKaButton = null;
		private Image m_E_Btn_OpenYueKaImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Text m_E_Text_RemainingtimesText = null;
		public Transform uiTransform = null;
	}
}
