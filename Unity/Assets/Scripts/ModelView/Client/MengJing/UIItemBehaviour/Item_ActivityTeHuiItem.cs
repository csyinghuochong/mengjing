
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_ActivityTeHuiItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ActivityTeHuiItem> 
	{
		public Dictionary<int, EntityRef<Scroll_Item_RewardItem>> ScrollItemRewardItems = new();
		public ActivityConfig ActivityConfig;
		public List<string> AssetList { get; set; } = new();
		
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

		public UnityEngine.UI.Text E_TextTypeText
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
		    			this.m_E_TextTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextType");
     				}
     				return this.m_E_TextTypeText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextType");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageBoxImage
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
		    			this.m_E_ImageBoxImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageBox");
     				}
     				return this.m_E_ImageBoxImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageBox");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TipText
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
     				if( this.m_E_TipText == null )
     				{
		    			this.m_E_TipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Tip");
     				}
     				return this.m_E_TipText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Tip");
     			}
     		}
     	}

		public UnityEngine.UI.ScrollRect E_RewardItemsScrollRect
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
     				if( this.m_E_RewardItemsScrollRect == null )
     				{
		    			this.m_E_RewardItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"E_RewardItems");
     				}
     				return this.m_E_RewardItemsScrollRect;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"E_RewardItems");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_RewardItemsImage
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
     				if( this.m_E_RewardItemsImage == null )
     				{
		    			this.m_E_RewardItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RewardItems");
     				}
     				return this.m_E_RewardItemsImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RewardItems");
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
		    			this.m_E_TextPriceText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ButtonBuy/E_TextPrice");
     				}
     				return this.m_E_TextPriceText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ButtonBuy/E_TextPrice");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageReceivedImage
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
		    			this.m_E_ImageReceivedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageReceived");
     				}
     				return this.m_E_ImageReceivedImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageReceived");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextTypeText = null;
			this.m_E_ImageBoxImage = null;
			this.m_E_TipText = null;
			this.m_E_RewardItemsScrollRect = null;
			this.m_E_RewardItemsImage = null;
			this.m_E_ButtonBuyButton = null;
			this.m_E_ButtonBuyImage = null;
			this.m_E_TextPriceText = null;
			this.m_E_ImageReceivedImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_E_TextTypeText = null;
		private UnityEngine.UI.Image m_E_ImageBoxImage = null;
		private UnityEngine.UI.Text m_E_TipText = null;
		private UnityEngine.UI.ScrollRect m_E_RewardItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_RewardItemsImage = null;
		private UnityEngine.UI.Button m_E_ButtonBuyButton = null;
		private UnityEngine.UI.Image m_E_ButtonBuyImage = null;
		private UnityEngine.UI.Text m_E_TextPriceText = null;
		private UnityEngine.UI.Image m_E_ImageReceivedImage = null;
		public Transform uiTransform = null;
	}
}
