
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ZhanQuCombatItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public ActivityConfig ActivityConfig;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ZhanQuCombatItem BindTrans(Transform trans)
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

		public UnityEngine.RectTransform EG_YiLingQuSetRectTransform
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
     				if( this.m_EG_YiLingQuSetRectTransform == null )
     				{
		    			this.m_EG_YiLingQuSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_YiLingQuSet");
     				}
     				return this.m_EG_YiLingQuSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_YiLingQuSet");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonReceiveButton
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
     				if( this.m_E_ButtonReceiveButton == null )
     				{
		    			this.m_E_ButtonReceiveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonReceive");
     				}
     				return this.m_E_ButtonReceiveButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonReceive");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonReceiveImage
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
     				if( this.m_E_ButtonReceiveImage == null )
     				{
		    			this.m_E_ButtonReceiveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonReceive");
     				}
     				return this.m_E_ButtonReceiveImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonReceive");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextTip2Text
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
     				if( this.m_E_TextTip2Text == null )
     				{
		    			this.m_E_TextTip2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTip2");
     				}
     				return this.m_E_TextTip2Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTip2");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextLeftText
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
     				if( this.m_E_TextLeftText == null )
     				{
		    			this.m_E_TextLeftText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextLeft");
     				}
     				return this.m_E_TextLeftText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextLeft");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_levelText
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
     				if( this.m_E_Text_levelText == null )
     				{
		    			this.m_E_Text_levelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_level");
     				}
     				return this.m_E_Text_levelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_level");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_rewardlist = null;
			this.m_EG_YiLingQuSetRectTransform = null;
			this.m_E_ButtonReceiveButton = null;
			this.m_E_ButtonReceiveImage = null;
			this.m_E_TextTip2Text = null;
			this.m_E_TextLeftText = null;
			this.m_E_Text_levelText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.RectTransform m_EG_YiLingQuSetRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonReceiveButton = null;
		private UnityEngine.UI.Image m_E_ButtonReceiveImage = null;
		private UnityEngine.UI.Text m_E_TextTip2Text = null;
		private UnityEngine.UI.Text m_E_TextLeftText = null;
		private UnityEngine.UI.Text m_E_Text_levelText = null;
		public Transform uiTransform = null;
	}
}
