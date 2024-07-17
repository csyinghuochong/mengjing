using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PaiMaiDuiHuan : Entity,IAwake<Transform>,IDestroy 
	{
		public long ExchangeValue;
		public int ExchangeZuanShi;
		
		public Button E_Btn_DuiHuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_DuiHuanButton == null )
     			{
		    		this.m_E_Btn_DuiHuanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_DuiHuan");
     			}
     			return this.m_E_Btn_DuiHuanButton;
     		}
     	}

		public Image E_Btn_DuiHuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_DuiHuanImage == null )
     			{
		    		this.m_E_Btn_DuiHuanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_DuiHuan");
     			}
     			return this.m_E_Btn_DuiHuanImage;
     		}
     	}

		public Button E_Btn_ShopButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShopButton == null )
     			{
		    		this.m_E_Btn_ShopButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Shop");
     			}
     			return this.m_E_Btn_ShopButton;
     		}
     	}

		public Image E_Btn_ShopImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShopImage == null )
     			{
		    		this.m_E_Btn_ShopImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Shop");
     			}
     			return this.m_E_Btn_ShopImage;
     		}
     	}

		public Text E_DuiHuan_GoldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DuiHuan_GoldText == null )
     			{
		    		this.m_E_DuiHuan_GoldText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"tip_1/E_DuiHuan_Gold");
     			}
     			return this.m_E_DuiHuan_GoldText;
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
		    		this.m_E_Btn_BuyNum_jia1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"duihuan_1/E_Btn_BuyNum_jia1");
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
		    		this.m_E_Btn_BuyNum_jia1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"duihuan_1/E_Btn_BuyNum_jia1");
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
		    		this.m_E_Btn_BuyNum_jia10Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"duihuan_1/E_Btn_BuyNum_jia10");
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
		    		this.m_E_Btn_BuyNum_jia10Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"duihuan_1/E_Btn_BuyNum_jia10");
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
		    		this.m_E_Btn_BuyNum_jian1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"duihuan_1/E_Btn_BuyNum_jian1");
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
		    		this.m_E_Btn_BuyNum_jian1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"duihuan_1/E_Btn_BuyNum_jian1");
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
		    		this.m_E_Btn_BuyNum_jian10Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"duihuan_1/E_Btn_BuyNum_jian10");
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
		    		this.m_E_Btn_BuyNum_jian10Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"duihuan_1/E_Btn_BuyNum_jian10");
     			}
     			return this.m_E_Btn_BuyNum_jian10Image;
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
		    		this.m_E_Lab_RmbNumInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"duihuan_1/E_Lab_RmbNum");
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
		    		this.m_E_Lab_RmbNumImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"duihuan_1/E_Lab_RmbNum");
     			}
     			return this.m_E_Lab_RmbNumImage;
     		}
     	}

		public Text E_Lab_DuiHuanGoldProShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_DuiHuanGoldProShowText == null )
     			{
		    		this.m_E_Lab_DuiHuanGoldProShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_DuiHuanGoldProShow");
     			}
     			return this.m_E_Lab_DuiHuanGoldProShowText;
     		}
     	}

		public Text E_Lab_DuiHuanZuanShiProShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_DuiHuanZuanShiProShowText == null )
     			{
		    		this.m_E_Lab_DuiHuanZuanShiProShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_DuiHuanZuanShiProShow");
     			}
     			return this.m_E_Lab_DuiHuanZuanShiProShowText;
     		}
     	}

		public Text E_Lab_WeiJingGoldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_WeiJingGoldText == null )
     			{
		    		this.m_E_Lab_WeiJingGoldText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_WeiJingGold");
     			}
     			return this.m_E_Lab_WeiJingGoldText;
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
			this.m_E_Btn_DuiHuanButton = null;
			this.m_E_Btn_DuiHuanImage = null;
			this.m_E_Btn_ShopButton = null;
			this.m_E_Btn_ShopImage = null;
			this.m_E_DuiHuan_GoldText = null;
			this.m_E_Btn_BuyNum_jia1Button = null;
			this.m_E_Btn_BuyNum_jia1Image = null;
			this.m_E_Btn_BuyNum_jia10Button = null;
			this.m_E_Btn_BuyNum_jia10Image = null;
			this.m_E_Btn_BuyNum_jian1Button = null;
			this.m_E_Btn_BuyNum_jian1Image = null;
			this.m_E_Btn_BuyNum_jian10Button = null;
			this.m_E_Btn_BuyNum_jian10Image = null;
			this.m_E_Lab_RmbNumInputField = null;
			this.m_E_Lab_RmbNumImage = null;
			this.m_E_Lab_DuiHuanGoldProShowText = null;
			this.m_E_Lab_DuiHuanZuanShiProShowText = null;
			this.m_E_Lab_WeiJingGoldText = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_DuiHuanButton = null;
		private Image m_E_Btn_DuiHuanImage = null;
		private Button m_E_Btn_ShopButton = null;
		private Image m_E_Btn_ShopImage = null;
		private Text m_E_DuiHuan_GoldText = null;
		private Button m_E_Btn_BuyNum_jia1Button = null;
		private Image m_E_Btn_BuyNum_jia1Image = null;
		private Button m_E_Btn_BuyNum_jia10Button = null;
		private Image m_E_Btn_BuyNum_jia10Image = null;
		private Button m_E_Btn_BuyNum_jian1Button = null;
		private Image m_E_Btn_BuyNum_jian1Image = null;
		private Button m_E_Btn_BuyNum_jian10Button = null;
		private Image m_E_Btn_BuyNum_jian10Image = null;
		private InputField m_E_Lab_RmbNumInputField = null;
		private Image m_E_Lab_RmbNumImage = null;
		private Text m_E_Lab_DuiHuanGoldProShowText = null;
		private Text m_E_Lab_DuiHuanZuanShiProShowText = null;
		private Text m_E_Lab_WeiJingGoldText = null;
		public Transform uiTransform = null;
	}
}
