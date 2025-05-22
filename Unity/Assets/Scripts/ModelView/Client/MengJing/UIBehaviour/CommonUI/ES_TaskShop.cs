using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TaskShop : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy ,IUILogic
	{
		public int BuyNum;
		public int SellId;
		public List<StoreSellConfig> ShowStoreSellConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_TaskShopItem>> ScrollItemTaskShopItems;
		
		public UnityEngine.UI.ToggleGroup E_BtnItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_TaskShopItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskShopItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TaskShopItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_TaskShopItems");
     			}
     			return this.m_E_TaskShopItemsLoopVerticalScrollRect;
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
     			if( this.m_E_ButtonBuyButton == null )
     			{
		    		this.m_E_ButtonBuyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonBuy");
     			}
     			return this.m_E_ButtonBuyButton;
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
     			if( this.m_E_ButtonBuyImage == null )
     			{
		    		this.m_E_ButtonBuyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonBuy");
     			}
     			return this.m_E_ButtonBuyImage;
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
		    		this.m_E_Lab_BuyPriceText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/PiLian/E_Lab_BuyPrice");
     			}
     			return this.m_E_Lab_BuyPriceText;
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
		    		this.m_E_Lab_BuyNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/PiLian/E_Lab_BuyNum");
     			}
     			return this.m_E_Lab_BuyNumText;
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
		    		this.m_E_Btn_BuyNum_jian10Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/PiLian/E_Btn_BuyNum_jian10");
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
		    		this.m_E_Btn_BuyNum_jian10Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/PiLian/E_Btn_BuyNum_jian10");
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
		    		this.m_E_Btn_BuyNum_jian1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/PiLian/E_Btn_BuyNum_jian1");
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
		    		this.m_E_Btn_BuyNum_jian1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/PiLian/E_Btn_BuyNum_jian1");
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
		    		this.m_E_Btn_BuyNum_jia10Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/PiLian/E_Btn_BuyNum_jia10");
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
		    		this.m_E_Btn_BuyNum_jia10Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/PiLian/E_Btn_BuyNum_jia10");
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
		    		this.m_E_Btn_BuyNum_jia1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/PiLian/E_Btn_BuyNum_jia1");
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
		    		this.m_E_Btn_BuyNum_jia1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/PiLian/E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Image;
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
			this.m_E_BtnItemTypeSetToggleGroup = null;
			this.m_E_TaskShopItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonBuyButton = null;
			this.m_E_ButtonBuyImage = null;
			this.m_E_Lab_BuyPriceText = null;
			this.m_E_Lab_BuyNumText = null;
			this.m_E_Btn_BuyNum_jian10Button = null;
			this.m_E_Btn_BuyNum_jian10Image = null;
			this.m_E_Btn_BuyNum_jian1Button = null;
			this.m_E_Btn_BuyNum_jian1Image = null;
			this.m_E_Btn_BuyNum_jia10Button = null;
			this.m_E_Btn_BuyNum_jia10Image = null;
			this.m_E_Btn_BuyNum_jia1Button = null;
			this.m_E_Btn_BuyNum_jia1Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_TaskShopItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonBuyButton = null;
		private UnityEngine.UI.Image m_E_ButtonBuyImage = null;
		private UnityEngine.UI.Text m_E_Lab_BuyPriceText = null;
		private UnityEngine.UI.Text m_E_Lab_BuyNumText = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jian10Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jian10Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jian1Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jian1Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jia10Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jia10Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jia1Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jia1Image = null;
		public Transform uiTransform = null;
	}
}
