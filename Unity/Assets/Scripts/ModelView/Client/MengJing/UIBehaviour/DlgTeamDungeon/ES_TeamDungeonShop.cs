using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TeamDungeonShop : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int BuyNum;
		public int SellId;
		public List<StoreSellConfig> ShowStoreSellConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_BattleShopItem>> ScrollItemBattleShopItems;
		
		public LoopVerticalScrollRect E_BattleShopItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BattleShopItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BattleShopItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BattleShopItems");
     			}
     			return this.m_E_BattleShopItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_ItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNumText == null )
     			{
		    		this.m_E_ItemNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"PiLian/E_ItemNum");
     			}
     			return this.m_E_ItemNumText;
     		}
     	}

		public Image E_ItemIconShowImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemIconShowImage == null )
     			{
		    		this.m_E_ItemIconShowImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"PiLian/E_ItemIconShow");
     			}
     			return this.m_E_ItemIconShowImage;
     		}
     	}

		public Text E_Lab_BuyNumText
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
		    		this.m_E_Lab_BuyNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"PiLian/E_Lab_BuyNum");
     			}
     			return this.m_E_Lab_BuyNumText;
     		}
     	}

		public Button E_Btn_BuyNum_jian10Button
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
		    		this.m_E_Btn_BuyNum_jian10Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"PiLian/E_Btn_BuyNum_jian10");
     			}
     			return this.m_E_Btn_BuyNum_jian10Button;
     		}
     	}

		public Image E_Btn_BuyNum_jian10Image
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
		    		this.m_E_Btn_BuyNum_jian10Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"PiLian/E_Btn_BuyNum_jian10");
     			}
     			return this.m_E_Btn_BuyNum_jian10Image;
     		}
     	}

		public Button E_Btn_BuyNum_jian1Button
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
		    		this.m_E_Btn_BuyNum_jian1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"PiLian/E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Button;
     		}
     	}

		public Image E_Btn_BuyNum_jian1Image
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
		    		this.m_E_Btn_BuyNum_jian1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"PiLian/E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Image;
     		}
     	}

		public Button E_Btn_BuyNum_jia10Button
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
		    		this.m_E_Btn_BuyNum_jia10Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"PiLian/E_Btn_BuyNum_jia10");
     			}
     			return this.m_E_Btn_BuyNum_jia10Button;
     		}
     	}

		public Image E_Btn_BuyNum_jia10Image
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
		    		this.m_E_Btn_BuyNum_jia10Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"PiLian/E_Btn_BuyNum_jia10");
     			}
     			return this.m_E_Btn_BuyNum_jia10Image;
     		}
     	}

		public Button E_Btn_BuyNum_jia1Button
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
		    		this.m_E_Btn_BuyNum_jia1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"PiLian/E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Button;
     		}
     	}

		public Image E_Btn_BuyNum_jia1Image
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
		    		this.m_E_Btn_BuyNum_jia1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"PiLian/E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Image;
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
     			if( this.m_E_ButtonBuyButton == null )
     			{
		    		this.m_E_ButtonBuyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonBuy");
     			}
     			return this.m_E_ButtonBuyButton;
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
     			if( this.m_E_ButtonBuyImage == null )
     			{
		    		this.m_E_ButtonBuyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonBuy");
     			}
     			return this.m_E_ButtonBuyImage;
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
			this.m_E_BattleShopItemsLoopVerticalScrollRect = null;
			this.m_E_ItemNumText = null;
			this.m_E_ItemIconShowImage = null;
			this.m_E_Lab_BuyNumText = null;
			this.m_E_Btn_BuyNum_jian10Button = null;
			this.m_E_Btn_BuyNum_jian10Image = null;
			this.m_E_Btn_BuyNum_jian1Button = null;
			this.m_E_Btn_BuyNum_jian1Image = null;
			this.m_E_Btn_BuyNum_jia10Button = null;
			this.m_E_Btn_BuyNum_jia10Image = null;
			this.m_E_Btn_BuyNum_jia1Button = null;
			this.m_E_Btn_BuyNum_jia1Image = null;
			this.m_E_ButtonBuyButton = null;
			this.m_E_ButtonBuyImage = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_BattleShopItemsLoopVerticalScrollRect = null;
		private Text m_E_ItemNumText = null;
		private Image m_E_ItemIconShowImage = null;
		private Text m_E_Lab_BuyNumText = null;
		private Button m_E_Btn_BuyNum_jian10Button = null;
		private Image m_E_Btn_BuyNum_jian10Image = null;
		private Button m_E_Btn_BuyNum_jian1Button = null;
		private Image m_E_Btn_BuyNum_jian1Image = null;
		private Button m_E_Btn_BuyNum_jia10Button = null;
		private Image m_E_Btn_BuyNum_jia10Image = null;
		private Button m_E_Btn_BuyNum_jia1Button = null;
		private Image m_E_Btn_BuyNum_jia1Image = null;
		private Button m_E_ButtonBuyButton = null;
		private Image m_E_ButtonBuyImage = null;
		public Transform uiTransform = null;
	}
}
