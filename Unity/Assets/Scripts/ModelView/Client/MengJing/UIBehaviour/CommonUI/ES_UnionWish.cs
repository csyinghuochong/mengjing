
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
		    		this.m_EG_LeaderShowRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_LeaderShow");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/EG_LeaderShow/ES_RewardList");
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
		    		this.m_E_ButtonSendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_LeaderShow/E_ButtonSend");
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
		    		this.m_E_ButtonSendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_LeaderShow/E_ButtonSend");
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
		    		this.m_E_Text_WishCostText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_LeaderShow/E_Text_WishCost");
     			}
     			return this.m_E_Text_WishCostText;
     		}
     	}

		public ES_UnionWishItem ES_UnionWishItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionWishItem es = this.m_es_unionwishitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_UnionWishItem_1");
		    	   this.m_es_unionwishitem_1 = this.AddChild<ES_UnionWishItem,Transform>(subTrans);
     			}
     			return this.m_es_unionwishitem_1;
     		}
     	}

		public ES_UnionWishItem ES_UnionWishItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionWishItem es = this.m_es_unionwishitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_UnionWishItem_2");
		    	   this.m_es_unionwishitem_2 = this.AddChild<ES_UnionWishItem,Transform>(subTrans);
     			}
     			return this.m_es_unionwishitem_2;
     		}
     	}

		public ES_UnionWishItem ES_UnionWishItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionWishItem es = this.m_es_unionwishitem_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_UnionWishItem_3");
		    	   this.m_es_unionwishitem_3 = this.AddChild<ES_UnionWishItem,Transform>(subTrans);
     			}
     			return this.m_es_unionwishitem_3;
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
			this.m_es_unionwishitem_1 = null;
			this.m_es_unionwishitem_2 = null;
			this.m_es_unionwishitem_3 = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LeaderShowRectTransform = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_ButtonSendButton = null;
		private UnityEngine.UI.Image m_E_ButtonSendImage = null;
		private UnityEngine.UI.Text m_E_Text_WishCostText = null;
		private EntityRef<ES_UnionWishItem> m_es_unionwishitem_1 = null;
		private EntityRef<ES_UnionWishItem> m_es_unionwishitem_2 = null;
		private EntityRef<ES_UnionWishItem> m_es_unionwishitem_3 = null;
		public Transform uiTransform = null;
	}
}
