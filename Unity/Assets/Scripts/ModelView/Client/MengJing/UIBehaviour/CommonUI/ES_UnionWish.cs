
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionWish : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.RectTransform EG_LeaderShowRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeaderShowRectTransform == null )
     			{
		    		this.m_EG_LeaderShowRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LeaderShow");
     			}
     			return this.m_EG_LeaderShowRectTransform;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_LeaderShow/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonSendButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSendButton == null )
     			{
		    		this.m_E_ButtonSendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LeaderShow/E_ButtonSend");
     			}
     			return this.m_E_ButtonSendButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonSendImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSendImage == null )
     			{
		    		this.m_E_ButtonSendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LeaderShow/E_ButtonSend");
     			}
     			return this.m_E_ButtonSendImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_WishCostText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_WishCostText == null )
     			{
		    		this.m_E_Text_WishCostText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LeaderShow/E_Text_WishCost");
     			}
     			return this.m_E_Text_WishCostText;
     		}
     	}

		public UnityEngine.RectTransform EG_WishItem_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_WishItem_1RectTransform == null )
     			{
		    		this.m_EG_WishItem_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_WishItem_1");
     			}
     			return this.m_EG_WishItem_1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_WishItem_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_WishItem_2RectTransform == null )
     			{
		    		this.m_EG_WishItem_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_WishItem_2");
     			}
     			return this.m_EG_WishItem_2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_WishItem_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_WishItem_3RectTransform == null )
     			{
		    		this.m_EG_WishItem_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_WishItem_3");
     			}
     			return this.m_EG_WishItem_3RectTransform;
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
			this.m_EG_LeaderShowRectTransform = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonSendButton = null;
			this.m_E_ButtonSendImage = null;
			this.m_E_Text_WishCostText = null;
			this.m_EG_WishItem_1RectTransform = null;
			this.m_EG_WishItem_2RectTransform = null;
			this.m_EG_WishItem_3RectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LeaderShowRectTransform = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_ButtonSendButton = null;
		private UnityEngine.UI.Image m_E_ButtonSendImage = null;
		private UnityEngine.UI.Text m_E_Text_WishCostText = null;
		private UnityEngine.RectTransform m_EG_WishItem_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_WishItem_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_WishItem_3RectTransform = null;
		public Transform uiTransform = null;
	}
}
