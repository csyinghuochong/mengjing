
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetEggChouKaRewardItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public int RewardKey;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetEggChouKaRewardItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_Btn_RewardButton
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
		    			this.m_E_Btn_RewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Reward");
     				}
     				return this.m_E_Btn_RewardButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Reward");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Btn_RewardImage
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
		    			this.m_E_Btn_RewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Reward");
     				}
     				return this.m_E_Btn_RewardImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Reward");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextNeedTimesText
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
		    			this.m_E_TextNeedTimesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextNeedTimes");
     				}
     				return this.m_E_TextNeedTimesText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextNeedTimes");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextZuanshiText
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
		    			this.m_E_TextZuanshiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextZuanshi");
     				}
     				return this.m_E_TextZuanshiText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextZuanshi");
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
     			if (this.isCacheNode)
     			{
     				if( this.m_es_rewardlist ==null  )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     			else
     			{
     				if(! this.m_es_rewardlist ==null  )
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

		private UnityEngine.UI.Button m_E_Btn_RewardButton = null;
		private UnityEngine.UI.Image m_E_Btn_RewardImage = null;
		private UnityEngine.UI.Text m_E_TextNeedTimesText = null;
		private UnityEngine.UI.Text m_E_TextZuanshiText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		public Transform uiTransform = null;
	}
}
