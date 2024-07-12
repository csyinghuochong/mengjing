
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SeasonStoreItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SeasonStoreItem>
	{
		public int StoreSellConfigId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SeasonStoreItem BindTrans(Transform trans)
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

		public UnityEngine.UI.Text E_NameTextText
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
     				if( this.m_E_NameTextText == null )
     				{
		    			this.m_E_NameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NameText");
     				}
     				return this.m_E_NameTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NameText");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_GoldImgImage
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
     				if( this.m_E_GoldImgImage == null )
     				{
		    			this.m_E_GoldImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GoldImg");
     				}
     				return this.m_E_GoldImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_GoldImg");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_ValueTextText
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
     				if( this.m_E_ValueTextText == null )
     				{
		    			this.m_E_ValueTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ValueText");
     				}
     				return this.m_E_ValueTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ValueText");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_BuyBtnButton
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
     				if( this.m_E_BuyBtnButton == null )
     				{
		    			this.m_E_BuyBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BuyBtn");
     				}
     				return this.m_E_BuyBtnButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BuyBtn");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_BuyBtnImage
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
     				if( this.m_E_BuyBtnImage == null )
     				{
		    			this.m_E_BuyBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BuyBtn");
     				}
     				return this.m_E_BuyBtnImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BuyBtn");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_commonitem = null;
			this.m_E_NameTextText = null;
			this.m_E_GoldImgImage = null;
			this.m_E_ValueTextText = null;
			this.m_E_BuyBtnButton = null;
			this.m_E_BuyBtnImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Text m_E_NameTextText = null;
		private UnityEngine.UI.Image m_E_GoldImgImage = null;
		private UnityEngine.UI.Text m_E_ValueTextText = null;
		private UnityEngine.UI.Button m_E_BuyBtnButton = null;
		private UnityEngine.UI.Image m_E_BuyBtnImage = null;
		public Transform uiTransform = null;
	}
}
