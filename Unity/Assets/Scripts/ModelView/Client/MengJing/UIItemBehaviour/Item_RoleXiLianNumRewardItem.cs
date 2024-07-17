using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_RoleXiLianNumRewardItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_RoleXiLianNumRewardItem>
	{
		public int RewardKey;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RoleXiLianNumRewardItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_Btn_RewardButton
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
     				if( this.m_E_Btn_RewardButton == null )
     				{
		    			this.m_E_Btn_RewardButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Reward");
     				}
     				return this.m_E_Btn_RewardButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Reward");
     			}
     		}
     	}

		public Image E_Btn_RewardImage
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
     				if( this.m_E_Btn_RewardImage == null )
     				{
		    			this.m_E_Btn_RewardImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Reward");
     				}
     				return this.m_E_Btn_RewardImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Reward");
     			}
     		}
     	}

		public Text E_TextNeedTimesText
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
     				if( this.m_E_TextNeedTimesText == null )
     				{
		    			this.m_E_TextNeedTimesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextNeedTimes");
     				}
     				return this.m_E_TextNeedTimesText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextNeedTimes");
     			}
     		}
     	}

		public Text E_TextZuanshiText
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
     				if( this.m_E_TextZuanshiText == null )
     				{
		    			this.m_E_TextZuanshiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextZuanshi");
     				}
     				return this.m_E_TextZuanshiText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextZuanshi");
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

		public void DestroyWidget()
		{
			this.m_E_Btn_RewardButton = null;
			this.m_E_Btn_RewardImage = null;
			this.m_E_TextNeedTimesText = null;
			this.m_E_TextZuanshiText = null;
			this.m_es_rewardlist = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_Btn_RewardButton = null;
		private Image m_E_Btn_RewardImage = null;
		private Text m_E_TextNeedTimesText = null;
		private Text m_E_TextZuanshiText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		public Transform uiTransform = null;
	}
}
