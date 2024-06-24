
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetMiningRewardItem : Entity,IAwake,IDestroy,IUIScrollItem 
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
     			if (this.isCacheNode)
     			{
     				if( this.m_es_rewardlist == null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     			else
     			{
     				if( this.m_es_rewardlist != null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			ES_RewardList es = this.m_es_rewardlist;
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

		public UnityEngine.UI.Button E_ButtonRewardButton
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
		    			this.m_E_ButtonRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonReward");
     				}
     				return this.m_E_ButtonRewardButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonReward");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonRewardImage
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
		    			this.m_E_ButtonRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonReward");
     				}
     				return this.m_E_ButtonRewardImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonReward");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageReceivedImage == null )
     				{
		    			this.m_E_ImageReceivedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageReceived");
     				}
     				return this.m_E_ImageReceivedImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageReceived");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_tipText
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
		    			this.m_E_Text_tipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_tip");
     				}
     				return this.m_E_Text_tipText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_tip");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_progressText
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
		    			this.m_E_Text_progressText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_progress");
     				}
     				return this.m_E_Text_progressText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_progress");
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
		private UnityEngine.UI.Button m_E_ButtonRewardButton = null;
		private UnityEngine.UI.Image m_E_ButtonRewardImage = null;
		private UnityEngine.UI.Image m_E_ImageReceivedImage = null;
		private UnityEngine.UI.Text m_E_Text_tipText = null;
		private UnityEngine.UI.Text m_E_Text_progressText = null;
		public Transform uiTransform = null;
	}
}
