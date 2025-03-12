using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ZhanQuLevelItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ZhanQuLevelItem> 
	{
		public ActivityConfig ActivityConfig;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ZhanQuLevelItem BindTrans(Transform trans)
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

		public RectTransform EG_YiLingQuSetRectTransform
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
		    			this.m_EG_YiLingQuSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_YiLingQuSet");
     				}
     				return this.m_EG_YiLingQuSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_YiLingQuSet");
     			}
     		}
     	}

		public Button E_ButtonReceiveButton
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
		    			this.m_E_ButtonReceiveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonReceive");
     				}
     				return this.m_E_ButtonReceiveButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonReceive");
     			}
     		}
     	}

		public Image E_ButtonReceiveImage
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
		    			this.m_E_ButtonReceiveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonReceive");
     				}
     				return this.m_E_ButtonReceiveImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonReceive");
     			}
     		}
     	}

		public Text E_TextTip2Text
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
		    			this.m_E_TextTip2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextTip2");
     				}
     				return this.m_E_TextTip2Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextTip2");
     			}
     		}
     	}

		public Text E_TextLeftText
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
		    			this.m_E_TextLeftText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLeft");
     				}
     				return this.m_E_TextLeftText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLeft");
     			}
     		}
     	}

		public Image E_Img_LodingValue
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
					if( this.m_E_Img_LodingValue == null)
					{
						this.m_E_Img_LodingValue = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_LodingValue");
					}
					return this.m_E_Img_LodingValue;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_LodingValue");
				}
			}
		}
        
		public Text E_Text_levelText
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
		    			this.m_E_Text_levelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_level");
     				}
     				return this.m_E_Text_levelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_level");
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
			this.m_E_Img_LodingValue = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private RectTransform m_EG_YiLingQuSetRectTransform = null;
		private Button m_E_ButtonReceiveButton = null;
		private Image m_E_ButtonReceiveImage = null;
		private Image m_E_Img_LodingValue = null;	
		private Text m_E_TextTip2Text = null;
		private Text m_E_TextLeftText = null;
		private Text m_E_Text_levelText = null;
		public Transform uiTransform = null;
	}
}
