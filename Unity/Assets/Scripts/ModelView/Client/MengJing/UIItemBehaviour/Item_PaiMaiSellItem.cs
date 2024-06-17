
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PaiMaiSellItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public PaiMaiItemInfo PaiMaiItemInfo;
		public Action<PaiMaiItemInfo> ClickHandler;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PaiMaiSellItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_ImageButtonButton
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
     				if( this.m_E_ImageButtonButton == null )
     				{
		    			this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
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
     				if( this.m_E_ImageButtonImage == null )
     				{
		    			this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Img_XuanZhongImage
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
     				if( this.m_E_Img_XuanZhongImage == null )
     				{
		    			this.m_E_Img_XuanZhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_XuanZhong");
     				}
     				return this.m_E_Img_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_XuanZhong");
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
     			if (this.isCacheNode)
     			{
     				if( this.m_es_commonitem ==null)
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     			else
     			{
     				if( !this.m_es_commonitem ==null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			ES_CommonItem es = this.m_es_commonitem;
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

		public UnityEngine.UI.Text E_TextPriceText
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
		    			this.m_E_TextPriceText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextPrice");
     				}
     				return this.m_E_TextPriceText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextPrice");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextNameText
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
     				if( this.m_E_TextNameText == null )
     				{
		    			this.m_E_TextNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     				}
     				return this.m_E_TextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextTimeText
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
     				if( this.m_E_TextTimeText == null )
     				{
		    			this.m_E_TextTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTime");
     				}
     				return this.m_E_TextTimeText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextTime");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_Img_XuanZhongImage = null;
			this.m_es_commonitem = null;
			this.m_E_TextPriceText = null;
			this.m_E_TextNameText = null;
			this.m_E_TextTimeText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Image m_E_Img_XuanZhongImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Text m_E_TextPriceText = null;
		private UnityEngine.UI.Text m_E_TextNameText = null;
		private UnityEngine.UI.Text m_E_TextTimeText = null;
		public Transform uiTransform = null;
	}
}
