﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_WeiJingShopItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_WeiJingShopItem> 
	{
		public StoreSellConfig StoreSellConfig;
		public Action<int> ClickHandle;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_WeiJingShopItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_Image_bgButton
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
     				if( this.m_E_Image_bgButton == null )
     				{
		    			this.m_E_Image_bgButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Image_bg");
     				}
     				return this.m_E_Image_bgButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Image_bg");
     			}
     		}
     	}

		public Image E_Image_bgImage
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
     				if( this.m_E_Image_bgImage == null )
     				{
		    			this.m_E_Image_bgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_bg");
     				}
     				return this.m_E_Image_bgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_bg");
     			}
     		}
     	}

		public Image E_ImageSelectImage
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
     				if( this.m_E_ImageSelectImage == null )
     				{
		    			this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageSelect");
     				}
     				return this.m_E_ImageSelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageSelect");
     			}
     		}
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
     				if( es==null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     			else
     			{
     				if( es!=null )
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

		public ES_CommonItem ES_CommonItem_Gold
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_CommonItem es = this.m_es_commonitem_gold;
     			if (this.isCacheNode)
     			{
     				if( es ==null)
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_Gold");
		    			this.m_es_commonitem_gold = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem_gold;
     			}
     			else
     			{
     				if( es !=null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_Gold");
		    			es = this.m_es_commonitem_gold;
     					if( es.UITransform != subTrans )
     					{
     						es.Dispose();
		    				this.m_es_commonitem_gold = null;
		    				this.m_es_commonitem_gold = this.AddChild<ES_CommonItem,Transform>(subTrans);
     					}
     				}
     				else
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_Gold");
		    			this.m_es_commonitem_gold = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem_gold;
     			}
     		}
     	}

		public Text E_Text_valueText
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
     				if( this.m_E_Text_valueText == null )
     				{
		    			this.m_E_Text_valueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_value");
     				}
     				return this.m_E_Text_valueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_value");
     			}
     		}
     	}

		public Text E_Text_leftText
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
     				if( this.m_E_Text_leftText == null )
     				{
		    			this.m_E_Text_leftText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_left");
     				}
     				return this.m_E_Text_leftText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_left");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Image_bgButton = null;
			this.m_E_Image_bgImage = null;
			this.m_E_ImageSelectImage = null;
			this.m_es_commonitem = null;
			this.m_es_commonitem_gold = null;
			this.m_E_Text_valueText = null;
			this.m_E_Text_leftText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_Image_bgButton = null;
		private Image m_E_Image_bgImage = null;
		private Image m_E_ImageSelectImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_gold = null;
		private Text m_E_Text_valueText = null;
		private Text m_E_Text_leftText = null;
		public Transform uiTransform = null;
	}
}
