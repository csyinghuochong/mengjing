using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_WelfareTaskItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_WelfareTaskItem>
	{
		public TaskPro TaskPro;
		public int Day;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_WelfareTaskItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_IconImgImage
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
     				if( this.m_E_IconImgImage == null )
     				{
		    			this.m_E_IconImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_IconImg");
     				}
     				return this.m_E_IconImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_IconImg");
     			}
     		}
     	}

		public Text E_TaskNameTextText
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
     				if( this.m_E_TaskNameTextText == null )
     				{
		    			this.m_E_TaskNameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskNameText");
     				}
     				return this.m_E_TaskNameTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskNameText");
     			}
     		}
     	}

		public Text E_TaskDescTextText
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
     				if( this.m_E_TaskDescTextText == null )
     				{
		    			this.m_E_TaskDescTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskDescText");
     				}
     				return this.m_E_TaskDescTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskDescText");
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
     				if( es ==null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     			else
     			{
     				if( es !=null )
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

		public Text E_TaskProgressText
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
     				if( this.m_E_TaskProgressText == null )
     				{
		    			this.m_E_TaskProgressText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskProgress");
     				}
     				return this.m_E_TaskProgressText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskProgress");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_IconImgImage = null;
			this.m_E_TaskNameTextText = null;
			this.m_E_TaskDescTextText = null;
			this.m_es_rewardlist = null;
			this.m_E_ReceiveBtnButton = null;
			this.m_E_ReceiveBtnImage = null;
			this.m_E_ReceivedImgImage = null;
			this.m_E_TaskProgressText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_IconImgImage = null;
		private Text m_E_TaskNameTextText = null;
		private Text m_E_TaskDescTextText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_ReceiveBtnButton = null;
		private Image m_E_ReceiveBtnImage = null;
		private Image m_E_ReceivedImgImage = null;
		private Text m_E_TaskProgressText = null;
		public Transform uiTransform = null;
	}
}
