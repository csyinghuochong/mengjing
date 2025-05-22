using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PaiMaiShop : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int PaiMaiTypeId;
		public int PaiMaiSellId;
		public int BuyNum;
		public List<int> ShowPaiMaiIds = new();
		public UITypeViewComponent UITypeViewComponent { get; set; }
		public Dictionary<int, EntityRef<Scroll_Item_PaiMaiShopItem>> ScrollItemPaiMaiShopItems;
		public Dictionary<long, PaiMaiShopItemInfo> PaiMaiShopItemInfos { get; set; } = new();
		public GameObject UIPaiMaiShopType;
		
		public UnityEngine.RectTransform EG_TypeListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TypeListNodeRectTransform == null )
     			{
		    		this.m_EG_TypeListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/ScrollView2/Viewport/EG_TypeListNode");
     			}
     			return this.m_EG_TypeListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_BuyNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_BuyNumText == null )
     			{
		    		this.m_E_Lab_BuyNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_BuyNum");
     			}
     			return this.m_E_Lab_BuyNumText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_BuyPriceText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_BuyPriceText == null )
     			{
		    		this.m_E_Lab_BuyPriceText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_BuyPrice");
     			}
     			return this.m_E_Lab_BuyPriceText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BuyNum_jian10Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jian10Button == null )
     			{
		    		this.m_E_Btn_BuyNum_jian10Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jian10");
     			}
     			return this.m_E_Btn_BuyNum_jian10Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BuyNum_jian10Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jian10Image == null )
     			{
		    		this.m_E_Btn_BuyNum_jian10Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jian10");
     			}
     			return this.m_E_Btn_BuyNum_jian10Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BuyNum_jian1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jian1Button == null )
     			{
		    		this.m_E_Btn_BuyNum_jian1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BuyNum_jian1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jian1Image == null )
     			{
		    		this.m_E_Btn_BuyNum_jian1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BuyNum_jia10Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jia10Button == null )
     			{
		    		this.m_E_Btn_BuyNum_jia10Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jia10");
     			}
     			return this.m_E_Btn_BuyNum_jia10Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BuyNum_jia10Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jia10Image == null )
     			{
		    		this.m_E_Btn_BuyNum_jia10Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jia10");
     			}
     			return this.m_E_Btn_BuyNum_jia10Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BuyNum_jia1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jia1Button == null )
     			{
		    		this.m_E_Btn_BuyNum_jia1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BuyNum_jia1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyNum_jia1Image == null )
     			{
		    		this.m_E_Btn_BuyNum_jia1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BuyItemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyItemButton == null )
     			{
		    		this.m_E_Btn_BuyItemButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_BuyItem");
     			}
     			return this.m_E_Btn_BuyItemButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BuyItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyItemImage == null )
     			{
		    		this.m_E_Btn_BuyItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_BuyItem");
     			}
     			return this.m_E_Btn_BuyItemImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PaiMaiShopItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PaiMaiShopItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PaiMaiShopItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_PaiMaiShopItems");
     			}
     			return this.m_E_PaiMaiShopItemsLoopVerticalScrollRect;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_EG_TypeListNodeRectTransform = null;
			this.m_E_Lab_BuyNumText = null;
			this.m_E_Lab_BuyPriceText = null;
			this.m_E_Btn_BuyNum_jian10Button = null;
			this.m_E_Btn_BuyNum_jian10Image = null;
			this.m_E_Btn_BuyNum_jian1Button = null;
			this.m_E_Btn_BuyNum_jian1Image = null;
			this.m_E_Btn_BuyNum_jia10Button = null;
			this.m_E_Btn_BuyNum_jia10Image = null;
			this.m_E_Btn_BuyNum_jia1Button = null;
			this.m_E_Btn_BuyNum_jia1Image = null;
			this.m_E_Btn_BuyItemButton = null;
			this.m_E_Btn_BuyItemImage = null;
			this.m_E_PaiMaiShopItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_TypeListNodeRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_BuyNumText = null;
		private UnityEngine.UI.Text m_E_Lab_BuyPriceText = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jian10Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jian10Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jian1Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jian1Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jia10Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jia10Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jia1Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jia1Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyItemButton = null;
		private UnityEngine.UI.Image m_E_Btn_BuyItemImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PaiMaiShopItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
