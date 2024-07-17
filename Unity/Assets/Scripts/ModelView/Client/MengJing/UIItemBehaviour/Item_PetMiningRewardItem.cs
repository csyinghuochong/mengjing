using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetMiningRewardItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetMiningRewardItem>
	{
		public TaskPro TaskPro;
		public int Number;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetMiningRewardItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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

		public Button E_ButtonRewardButton
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
     				if( this.m_E_ButtonRewardButton == null )
     				{
		    			this.m_E_ButtonRewardButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonReward");
     				}
     				return this.m_E_ButtonRewardButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonReward");
     			}
     		}
     	}

		public Image E_ButtonRewardImage
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
     				if( this.m_E_ButtonRewardImage == null )
     				{
		    			this.m_E_ButtonRewardImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonReward");
     				}
     				return this.m_E_ButtonRewardImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonReward");
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

		public Text E_Text_tipText
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
     				if( this.m_E_Text_tipText == null )
     				{
		    			this.m_E_Text_tipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_tip");
     				}
     				return this.m_E_Text_tipText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_tip");
     			}
     		}
     	}

		public Text E_Text_progressText
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
     				if( this.m_E_Text_progressText == null )
     				{
		    			this.m_E_Text_progressText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_progress");
     				}
     				return this.m_E_Text_progressText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_progress");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_rewardlist = null;
			this.m_E_ButtonRewardButton = null;
			this.m_E_ButtonRewardImage = null;
			this.m_E_ImageReceivedImage = null;
			this.m_E_Text_tipText = null;
			this.m_E_Text_progressText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_ButtonRewardButton = null;
		private Image m_E_ButtonRewardImage = null;
		private Image m_E_ImageReceivedImage = null;
		private Text m_E_Text_tipText = null;
		private Text m_E_Text_progressText = null;
		public Transform uiTransform = null;
	}
}
