using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_NewYearCollectionWordItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_NewYearCollectionWordItem>
	{
		public Action ReceiveHandler;
		public ActivityConfig ActivityConfig;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_NewYearCollectionWordItem BindTrans(Transform trans)
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

		public ES_RewardList ES_RewardList_Word
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_RewardList es = this.m_es_rewardlist_word;
     			if (this.isCacheNode)
     			{
     				if( es == null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList_Word");
		    			this.m_es_rewardlist_word = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist_word;
     			}
     			else
     			{
     				if( es != null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList_Word");
		    			es = this.m_es_rewardlist_word;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_rewardlist_word = null;
		    				this.m_es_rewardlist_word = this.AddChild<ES_RewardList,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList_Word");
		    			this.m_es_rewardlist_word = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist_word;
     			}
     		}
     	}

		public Button E_ButtonDuiHuanButton
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
     				if( this.m_E_ButtonDuiHuanButton == null )
     				{
		    			this.m_E_ButtonDuiHuanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonDuiHuan");
     				}
     				return this.m_E_ButtonDuiHuanButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonDuiHuan");
     			}
     		}
     	}

		public Image E_ButtonDuiHuanImage
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
     				if( this.m_E_ButtonDuiHuanImage == null )
     				{
		    			this.m_E_ButtonDuiHuanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonDuiHuan");
     				}
     				return this.m_E_ButtonDuiHuanImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonDuiHuan");
     			}
     		}
     	}

		public Text E_LabDuiHuanText
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
     				if( this.m_E_LabDuiHuanText == null )
     				{
		    			this.m_E_LabDuiHuanText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LabDuiHuan");
     				}
     				return this.m_E_LabDuiHuanText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LabDuiHuan");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_rewardlist = null;
			this.m_es_rewardlist_word = null;
			this.m_E_ButtonDuiHuanButton = null;
			this.m_E_ButtonDuiHuanImage = null;
			this.m_E_LabDuiHuanText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_word = null;
		private Button m_E_ButtonDuiHuanButton = null;
		private Image m_E_ButtonDuiHuanImage = null;
		private Text m_E_LabDuiHuanText = null;
		public Transform uiTransform = null;
	}
}
