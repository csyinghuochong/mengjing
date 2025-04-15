using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PaiMaiShopItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PaiMaiShopItem>
	{
		public PaiMaiShopItemInfo PaiMaiShopItemInfo;
		public int PaiMaiId;
		public Action<int> ClickHandler;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PaiMaiShopItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ImageButtonButton
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
		    			this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     		}
     	}

		public Image E_ImageButtonImage
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
		    			this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
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
     				if( es ==null )
     				{
		    			Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    			this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     				}
     				return this.m_es_commonitem;
     			}
     			else
     			{
     				if( es !=null  )
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

		public Text E_Lab_PriceText
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
     				if( this.m_E_Lab_PriceText == null )
     				{
		    			this.m_E_Lab_PriceText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Price");
     				}
     				return this.m_E_Lab_PriceText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Price");
     			}
     		}
     	}
		
		public Image E_Quality_Image
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
					if( this.m_E_Quality_Image == null )
					{
						this.m_E_Quality_Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Quality_Image");
					}
					return this.m_E_Quality_Image;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Quality_Image");
				}
			}
		}
		
		public Text E_Lab_TipsText
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
     				if( this.m_E_Lab_TipsText == null )
     				{
		    			this.m_E_Lab_TipsText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Tips");
     				}
     				return this.m_E_Lab_TipsText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Tips");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_ImageSelectImage = null;
			this.m_es_commonitem = null;
			this.m_E_Lab_PriceText = null;
			this.m_E_Lab_TipsText = null;
			this.m_E_Quality_Image = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private Image m_E_ImageSelectImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Text m_E_Lab_PriceText = null;
		private Text m_E_Lab_TipsText = null;
		private Image m_E_Quality_Image = null;
		public Transform uiTransform = null;
	}
}
