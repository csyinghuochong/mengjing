﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ActivityTeHuiItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ActivityTeHuiItem>
	{
		public ActivityConfig ActivityConfig;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ActivityTeHuiItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_ImageBoxImage
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
     				if( this.m_E_ImageBoxImage == null )
     				{
		    			this.m_E_ImageBoxImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBox");
     				}
     				return this.m_E_ImageBoxImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBox");
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

		public Button E_ButtonBuyButton
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
     				if( this.m_E_ButtonBuyButton == null )
     				{
		    			this.m_E_ButtonBuyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonBuy");
     				}
     				return this.m_E_ButtonBuyButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonBuy");
     			}
     		}
     	}

		public Image E_ButtonBuyImage
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
     				if( this.m_E_ButtonBuyImage == null )
     				{
		    			this.m_E_ButtonBuyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonBuy");
     				}
     				return this.m_E_ButtonBuyImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonBuy");
     			}
     		}
     	}

		public Text E_TextPriceText
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
     				if( this.m_E_TextPriceText == null )
     				{
		    			this.m_E_TextPriceText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ButtonBuy/E_TextPrice");
     				}
     				return this.m_E_TextPriceText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ButtonBuy/E_TextPrice");
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

		public Text E_TextTypeText
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
     				if( this.m_E_TextTypeText == null )
     				{
		    			this.m_E_TextTypeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextType");
     				}
     				return this.m_E_TextTypeText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextType");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageBoxImage = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonBuyButton = null;
			this.m_E_ButtonBuyImage = null;
			this.m_E_TextPriceText = null;
			this.m_E_ImageReceivedImage = null;
			this.m_E_TextTypeText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_ImageBoxImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_ButtonBuyButton = null;
		private Image m_E_ButtonBuyImage = null;
		private Text m_E_TextPriceText = null;
		private Image m_E_ImageReceivedImage = null;
		private Text m_E_TextTypeText = null;
		public Transform uiTransform = null;
	}
}
