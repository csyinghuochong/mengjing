
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_NewYearCollectionWordItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public Action ReceiveHandler;
		public ActivityConfig ActivityConfig;
		public List<Scroll_Item_CommonItem> WordItems = new();
		
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

		public UnityEngine.RectTransform EG_WordListRectTransform
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
     				if( this.m_EG_WordListRectTransform == null )
     				{
		    			this.m_EG_WordListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_WordList");
     				}
     				return this.m_EG_WordListRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_WordList");
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
     				if( this.m_es_rewardlist.Equals(null)  )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    			this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     				}
     				return this.m_es_rewardlist;
     			}
     			else
     			{
     				if( !this.m_es_rewardlist.Equals(null)  )
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

		public UnityEngine.UI.Button E_ButtonDuiHuanButton
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
		    			this.m_E_ButtonDuiHuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonDuiHuan");
     				}
     				return this.m_E_ButtonDuiHuanButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonDuiHuan");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonDuiHuanImage
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
		    			this.m_E_ButtonDuiHuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonDuiHuan");
     				}
     				return this.m_E_ButtonDuiHuanImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonDuiHuan");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_LabDuiHuanText
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
		    			this.m_E_LabDuiHuanText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LabDuiHuan");
     				}
     				return this.m_E_LabDuiHuanText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LabDuiHuan");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_WordListRectTransform = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonDuiHuanButton = null;
			this.m_E_ButtonDuiHuanImage = null;
			this.m_E_LabDuiHuanText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.RectTransform m_EG_WordListRectTransform = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_ButtonDuiHuanButton = null;
		private UnityEngine.UI.Image m_E_ButtonDuiHuanImage = null;
		private UnityEngine.UI.Text m_E_LabDuiHuanText = null;
		public Transform uiTransform = null;
	}
}
