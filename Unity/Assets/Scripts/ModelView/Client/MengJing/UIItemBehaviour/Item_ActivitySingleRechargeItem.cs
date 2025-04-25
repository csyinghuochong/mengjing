using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_ActivitySingleRechargeItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ActivitySingleRechargeItem> 
	{
		public ActivityConfig ActivityConfig;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ActivitySingleRechargeItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_ConsumeNumTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ConsumeNumTextText == null )
     				{
		    			this.m_E_ConsumeNumTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ConsumeNumText");
     				}
     				return this.m_E_ConsumeNumTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ConsumeNumText");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( es == null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     			else
     			{
     				if( es != null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			es = this.m_es_rewardlist;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_rewardlist = null;
		    				this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     		}
     	}

		public Button E_ReceiveBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ReceiveBtnButton == null )
     				{
		    			this.m_E_ReceiveBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ReceiveBtn");
     				}
     				return this.m_E_ReceiveBtnButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ReceiveBtn");
     			}
     		}
     	}

		public Image E_ReceiveBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ReceiveBtnImage == null )
     				{
		    			this.m_E_ReceiveBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ReceiveBtn");
     				}
     				return this.m_E_ReceiveBtnImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ReceiveBtn");
     			}
     		}
     	}

		public Image E_ReddotImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ReddotImage == null )
     				{
		    			this.m_E_ReddotImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ReceiveBtn/E_Reddot");
     				}
     				return this.m_E_ReddotImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ReceiveBtn/E_Reddot");
     			}
     		}
     	}

		public Image E_ReceivedImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ReceivedImgImage == null )
     				{
		    			this.m_E_ReceivedImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ReceivedImg");
     				}
     				return this.m_E_ReceivedImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ReceivedImg");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ConsumeNumTextText = null;
			this.m_es_rewardlist = null;
			this.m_E_ReceiveBtnButton = null;
			this.m_E_ReceiveBtnImage = null;
			this.m_E_ReddotImage = null;
			this.m_E_ReceivedImgImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_ConsumeNumTextText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_ReceiveBtnButton = null;
		private Image m_E_ReceiveBtnImage = null;
		private Image m_E_ReddotImage = null;
		private Image m_E_ReceivedImgImage = null;
		public Transform uiTransform = null;
	}
}
