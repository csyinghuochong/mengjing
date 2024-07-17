using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ActivityLoginItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ActivityLoginItem>
	{
		public ActivityConfig ActivityConfig;

		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ActivityLoginItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_Lab_NameText
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
     				if( this.m_E_Lab_NameText == null )
     				{
		    			this.m_E_Lab_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Name");
     				}
     				return this.m_E_Lab_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Name");
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
     				if( es ==null  )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     			else
     			{
     				if( es !=null  )
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

		public Button E_Btn_ReceiveButton
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
     				if( this.m_E_Btn_ReceiveButton == null )
     				{
		    			this.m_E_Btn_ReceiveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Receive");
     				}
     				return this.m_E_Btn_ReceiveButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Receive");
     			}
     		}
     	}

		public Image E_Btn_ReceiveImage
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
     				if( this.m_E_Btn_ReceiveImage == null )
     				{
		    			this.m_E_Btn_ReceiveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Receive");
     				}
     				return this.m_E_Btn_ReceiveImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Receive");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageReceivedImage == null )
     				{
		    			this.m_E_ImageReceivedImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageReceived");
     				}
     				return this.m_E_ImageReceivedImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageReceived");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Lab_NameText = null;
			this.m_es_rewardlist = null;
			this.m_E_Btn_ReceiveButton = null;
			this.m_E_Btn_ReceiveImage = null;
			this.m_E_ImageReceivedImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_Lab_NameText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_Btn_ReceiveButton = null;
		private Image m_E_Btn_ReceiveImage = null;
		private Image m_E_ImageReceivedImage = null;
		public Transform uiTransform = null;
	}
}
