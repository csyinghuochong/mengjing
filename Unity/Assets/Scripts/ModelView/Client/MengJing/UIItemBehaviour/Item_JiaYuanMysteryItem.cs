using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_JiaYuanMysteryItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_JiaYuanMysteryItem>
	{
		public MysteryItemInfo MysteryItemInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_JiaYuanMysteryItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_Image_goldImage
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
     				if( this.m_E_Image_goldImage == null )
     				{
		    			this.m_E_Image_goldImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_gold");
     				}
     				return this.m_E_Image_goldImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_gold");
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

		public Text E_Text_NumberText
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
     				if( this.m_E_Text_NumberText == null )
     				{
		    			this.m_E_Text_NumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Number");
     				}
     				return this.m_E_Text_NumberText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Number");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Image_goldImage = null;
			this.m_es_commonitem = null;
			this.m_E_ButtonBuyButton = null;
			this.m_E_ButtonBuyImage = null;
			this.m_E_Text_valueText = null;
			this.m_E_Text_NumberText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_Image_goldImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Button m_E_ButtonBuyButton = null;
		private Image m_E_ButtonBuyImage = null;
		private Text m_E_Text_valueText = null;
		private Text m_E_Text_NumberText = null;
		public Transform uiTransform = null;
	}
}
