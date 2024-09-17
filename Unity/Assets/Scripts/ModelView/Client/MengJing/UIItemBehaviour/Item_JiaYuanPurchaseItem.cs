using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_JiaYuanPurchaseItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_JiaYuanPurchaseItem> 
	{
		public JiaYuanPurchaseItem JiaYuanPurchaseItem;
		public Action Action_Buy;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_JiaYuanPurchaseItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		    	ES_CommonItem es = this.m_es_commonitem;
     			if (this.isCacheNode)
     			{
     				if( es == null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     			else
     			{
     				if( es != null )

     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			es = this.m_es_commonitem;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_commonitem = null;
		    				this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
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

		public Button E_Button_SellButton
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
     				if( this.m_E_Button_SellButton == null )
     				{
		    			this.m_E_Button_SellButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Sell");
     				}
     				return this.m_E_Button_SellButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Sell");
     			}
     		}
     	}

		public Image E_Button_SellImage
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
     				if( this.m_E_Button_SellImage == null )
     				{
		    			this.m_E_Button_SellImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Sell");
     				}
     				return this.m_E_Button_SellImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Sell");
     			}
     		}
     	}

		public Text E_Text_PriceText
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
     				if( this.m_E_Text_PriceText == null )
     				{
		    			this.m_E_Text_PriceText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Price");
     				}
     				return this.m_E_Text_PriceText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Price");
     			}
     		}
     	}

		public Text E_Text_TimeText
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
     				if( this.m_E_Text_TimeText == null )
     				{
		    			this.m_E_Text_TimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Time");
     				}
     				return this.m_E_Text_TimeText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Time");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_commonitem = null;
			this.m_es_rewardlist = null;
			this.m_E_Button_SellButton = null;
			this.m_E_Button_SellImage = null;
			this.m_E_Text_PriceText = null;
			this.m_E_Text_TimeText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_Button_SellButton = null;
		private Image m_E_Button_SellImage = null;
		private Text m_E_Text_PriceText = null;
		private Text m_E_Text_TimeText = null;
		public Transform uiTransform = null;
	}
}
