using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgWeiJingShop))]
	[EnableMethod]
	public  class DlgWeiJingShopViewComponent : Entity,IAwake,IDestroy 
	{
		public LoopVerticalScrollRect E_WeiJingShopItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WeiJingShopItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_WeiJingShopItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_WeiJingShopItems");
     			}
     			return this.m_E_WeiJingShopItemsLoopVerticalScrollRect;
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

		public InputField E_Lab_RmbNumInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_RmbNumInputField == null )
     			{
		    		this.m_E_Lab_RmbNumInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"NumSet/E_Lab_RmbNum");
     			}
     			return this.m_E_Lab_RmbNumInputField;
     		}
     	}

		public Image E_Lab_RmbNumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_RmbNumImage == null )
     			{
		    		this.m_E_Lab_RmbNumImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NumSet/E_Lab_RmbNum");
     			}
     			return this.m_E_Lab_RmbNumImage;
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
		    		this.m_E_Btn_BuyNum_jia1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"NumSet/E_Btn_BuyNum_jia1");
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
		    		this.m_E_Btn_BuyNum_jia1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NumSet/E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Image;
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
		    		this.m_E_Btn_BuyNum_jia10Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"NumSet/E_Btn_BuyNum_jia10");
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
		    		this.m_E_Btn_BuyNum_jia10Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NumSet/E_Btn_BuyNum_jia10");
     			}
     			return this.m_E_Btn_BuyNum_jia10Image;
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
		    		this.m_E_Btn_BuyNum_jian1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"NumSet/E_Btn_BuyNum_jian1");
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
		    		this.m_E_Btn_BuyNum_jian1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NumSet/E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Image;
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
		    		this.m_E_Btn_BuyNum_jian10Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"NumSet/E_Btn_BuyNum_jian10");
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
		    		this.m_E_Btn_BuyNum_jian10Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"NumSet/E_Btn_BuyNum_jian10");
     			}
     			return this.m_E_Btn_BuyNum_jian10Image;
     		}
     	}

		public Text E_Lab_NumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NumText == null )
     			{
		    		this.m_E_Lab_NumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Num");
     			}
     			return this.m_E_Lab_NumText;
     		}
     	}

		public Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_WeiJingShopItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonBuyButton = null;
			this.m_E_ButtonBuyImage = null;
			this.m_E_Lab_RmbNumInputField = null;
			this.m_E_Lab_RmbNumImage = null;
			this.m_E_Btn_BuyNum_jia1Button = null;
			this.m_E_Btn_BuyNum_jia1Image = null;
			this.m_E_Btn_BuyNum_jia10Button = null;
			this.m_E_Btn_BuyNum_jia10Image = null;
			this.m_E_Btn_BuyNum_jian1Button = null;
			this.m_E_Btn_BuyNum_jian1Image = null;
			this.m_E_Btn_BuyNum_jian10Button = null;
			this.m_E_Btn_BuyNum_jian10Image = null;
			this.m_E_Lab_NumText = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_WeiJingShopItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonBuyButton = null;
		private Image m_E_ButtonBuyImage = null;
		private InputField m_E_Lab_RmbNumInputField = null;
		private Image m_E_Lab_RmbNumImage = null;
		private Button m_E_Btn_BuyNum_jia1Button = null;
		private Image m_E_Btn_BuyNum_jia1Image = null;
		private Button m_E_Btn_BuyNum_jia10Button = null;
		private Image m_E_Btn_BuyNum_jia10Image = null;
		private Button m_E_Btn_BuyNum_jian1Button = null;
		private Image m_E_Btn_BuyNum_jian1Image = null;
		private Button m_E_Btn_BuyNum_jian10Button = null;
		private Image m_E_Btn_BuyNum_jian10Image = null;
		private Text m_E_Lab_NumText = null;
		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		public Transform uiTransform = null;
	}
}
