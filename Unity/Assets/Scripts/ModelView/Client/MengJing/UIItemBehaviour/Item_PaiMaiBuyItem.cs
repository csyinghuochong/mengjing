
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PaiMaiBuyItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public PaiMaiItemInfo PaiMaiItemInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PaiMaiBuyItem BindTrans(Transform trans)
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
     			if (this.isCacheNode)
     			{
     				if( this.m_es_commonitem .Equals(null) )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     			else
     			{
     				if( !this.m_es_commonitem .Equals(null) )
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

		public UnityEngine.UI.Text E_Text_NameText
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
     				if( this.m_E_Text_NameText == null )
     				{
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Name");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_PriceText
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
		    			this.m_E_Text_PriceText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Price");
     				}
     				return this.m_E_Text_PriceText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Price");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_LeftTimeText
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
     				if( this.m_E_Text_LeftTimeText == null )
     				{
		    			this.m_E_Text_LeftTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_LeftTime");
     				}
     				return this.m_E_Text_LeftTimeText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_LeftTime");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_OwnerText
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
     				if( this.m_E_Text_OwnerText == null )
     				{
		    			this.m_E_Text_OwnerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Owner");
     				}
     				return this.m_E_Text_OwnerText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Owner");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonBuyButton
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
		    			this.m_E_ButtonBuyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonBuy");
     				}
     				return this.m_E_ButtonBuyButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonBuy");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonBuyImage
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
		    			this.m_E_ButtonBuyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonBuy");
     				}
     				return this.m_E_ButtonBuyImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonBuy");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_PDListBtnButton
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
     				if( this.m_E_PDListBtnButton == null )
     				{
		    			this.m_E_PDListBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_PDListBtn");
     				}
     				return this.m_E_PDListBtnButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_PDListBtn");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_PDListBtnImage
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
     				if( this.m_E_PDListBtnImage == null )
     				{
		    			this.m_E_PDListBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_PDListBtn");
     				}
     				return this.m_E_PDListBtnImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_PDListBtn");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_commonitem = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_PriceText = null;
			this.m_E_Text_LeftTimeText = null;
			this.m_E_Text_OwnerText = null;
			this.m_E_ButtonBuyButton = null;
			this.m_E_ButtonBuyImage = null;
			this.m_E_PDListBtnButton = null;
			this.m_E_PDListBtnImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Text m_E_Text_PriceText = null;
		private UnityEngine.UI.Text m_E_Text_LeftTimeText = null;
		private UnityEngine.UI.Text m_E_Text_OwnerText = null;
		private UnityEngine.UI.Button m_E_ButtonBuyButton = null;
		private UnityEngine.UI.Image m_E_ButtonBuyImage = null;
		private UnityEngine.UI.Button m_E_PDListBtnButton = null;
		private UnityEngine.UI.Image m_E_PDListBtnImage = null;
		public Transform uiTransform = null;
	}
}
