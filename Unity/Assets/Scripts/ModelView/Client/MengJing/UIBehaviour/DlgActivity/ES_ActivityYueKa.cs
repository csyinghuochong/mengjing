
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivityYueKa : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image E_Img_JiHuoImage
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
		    		this.m_E_Img_JiHuoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Img_JiHuo");
     			}
     			return this.m_E_Img_JiHuoImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_GoPayButton
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
		    		this.m_E_Btn_GoPayButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Btn_GoPay");
     			}
     			return this.m_E_Btn_GoPayButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_GoPayImage
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
		    		this.m_E_Btn_GoPayImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Btn_GoPay");
     			}
     			return this.m_E_Btn_GoPayImage;
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
		    		this.m_E_Btn_GetRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Btn_GetReward");
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
		    		this.m_E_Btn_GetRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Btn_GetReward");
     			}
     			return this.m_E_Btn_GetRewardImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_RemainingtimesText
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
		    		this.m_E_Text_RemainingtimesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_Remainingtimes");
     			}
     			return this.m_E_Text_RemainingtimesText;
     		}
     	}

		public UnityEngine.RectTransform EG_BtnOpenYueKaSetRectTransform
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
		    		this.m_EG_BtnOpenYueKaSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_BtnOpenYueKaSet");
     			}
     			return this.m_EG_BtnOpenYueKaSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TextYueKaCostText
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
		    		this.m_E_TextYueKaCostText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_BtnOpenYueKaSet/E_TextYueKaCost");
     			}
     			return this.m_E_TextYueKaCostText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_OpenYueKaButton
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
		    		this.m_E_Btn_OpenYueKaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_BtnOpenYueKaSet/E_Btn_OpenYueKa");
     			}
     			return this.m_E_Btn_OpenYueKaButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_OpenYueKaImage
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
		    		this.m_E_Btn_OpenYueKaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_BtnOpenYueKaSet/E_Btn_OpenYueKa");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
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
			this.m_E_Text_RemainingtimesText = null;
			this.m_EG_BtnOpenYueKaSetRectTransform = null;
			this.m_E_TextYueKaCostText = null;
			this.m_E_Btn_OpenYueKaButton = null;
			this.m_E_Btn_OpenYueKaImage = null;
			this.m_es_rewardlist = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_Img_JiHuoImage = null;
		private UnityEngine.UI.Button m_E_Btn_GoPayButton = null;
		private UnityEngine.UI.Image m_E_Btn_GoPayImage = null;
		private UnityEngine.UI.Button m_E_Btn_GetRewardButton = null;
		private UnityEngine.UI.Image m_E_Btn_GetRewardImage = null;
		private UnityEngine.UI.Text m_E_Text_RemainingtimesText = null;
		private UnityEngine.RectTransform m_EG_BtnOpenYueKaSetRectTransform = null;
		private UnityEngine.UI.Text m_E_TextYueKaCostText = null;
		private UnityEngine.UI.Button m_E_Btn_OpenYueKaButton = null;
		private UnityEngine.UI.Image m_E_Btn_OpenYueKaImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		public Transform uiTransform = null;
	}
}
