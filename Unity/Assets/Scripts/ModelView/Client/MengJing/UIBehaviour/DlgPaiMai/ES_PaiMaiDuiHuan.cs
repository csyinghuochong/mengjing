using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PaiMaiDuiHuan : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public long ExchangeValue;
		public int ExchangeZuanShi;
		
		public UnityEngine.UI.Button E_Btn_DuiHuanButton
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
		    		this.m_E_Btn_DuiHuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_DuiHuan");
     			}
     			return this.m_E_Btn_DuiHuanButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_DuiHuanImage
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
		    		this.m_E_Btn_DuiHuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_DuiHuan");
     			}
     			return this.m_E_Btn_DuiHuanImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ShopButton
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
		    		this.m_E_Btn_ShopButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Shop");
     			}
     			return this.m_E_Btn_ShopButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ShopImage
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
		    		this.m_E_Btn_ShopImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Shop");
     			}
     			return this.m_E_Btn_ShopImage;
     		}
     	}

		public UnityEngine.UI.Text E_DuiHuan_GoldText
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
		    		this.m_E_DuiHuan_GoldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/tip_1/E_DuiHuan_Gold");
     			}
     			return this.m_E_DuiHuan_GoldText;
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
		    		this.m_E_Btn_BuyNum_jia1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/duihuan_1/E_Btn_BuyNum_jia1");
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
		    		this.m_E_Btn_BuyNum_jia1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/duihuan_1/E_Btn_BuyNum_jia1");
     			}
     			return this.m_E_Btn_BuyNum_jia1Image;
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
		    		this.m_E_Btn_BuyNum_jia10Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/duihuan_1/E_Btn_BuyNum_jia10");
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
		    		this.m_E_Btn_BuyNum_jia10Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/duihuan_1/E_Btn_BuyNum_jia10");
     			}
     			return this.m_E_Btn_BuyNum_jia10Image;
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
		    		this.m_E_Btn_BuyNum_jian1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/duihuan_1/E_Btn_BuyNum_jian1");
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
		    		this.m_E_Btn_BuyNum_jian1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/duihuan_1/E_Btn_BuyNum_jian1");
     			}
     			return this.m_E_Btn_BuyNum_jian1Image;
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
		    		this.m_E_Btn_BuyNum_jian10Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/duihuan_1/E_Btn_BuyNum_jian10");
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
		    		this.m_E_Btn_BuyNum_jian10Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/duihuan_1/E_Btn_BuyNum_jian10");
     			}
     			return this.m_E_Btn_BuyNum_jian10Image;
     		}
     	}

		public UnityEngine.UI.InputField E_Lab_RmbNumInputField
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
		    		this.m_E_Lab_RmbNumInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Right/duihuan_1/E_Lab_RmbNum");
     			}
     			return this.m_E_Lab_RmbNumInputField;
     		}
     	}

		public UnityEngine.UI.Image E_Lab_RmbNumImage
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
		    		this.m_E_Lab_RmbNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/duihuan_1/E_Lab_RmbNum");
     			}
     			return this.m_E_Lab_RmbNumImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_DuiHuanGoldProShowText
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
		    		this.m_E_Lab_DuiHuanGoldProShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_DuiHuanGoldProShow");
     			}
     			return this.m_E_Lab_DuiHuanGoldProShowText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_DuiHuanZuanShiProShowText
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
		    		this.m_E_Lab_DuiHuanZuanShiProShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_DuiHuanZuanShiProShow");
     			}
     			return this.m_E_Lab_DuiHuanZuanShiProShowText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_WeiJingGoldText
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
		    		this.m_E_Lab_WeiJingGoldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_WeiJingGold");
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

		private UnityEngine.UI.Button m_E_Btn_DuiHuanButton = null;
		private UnityEngine.UI.Image m_E_Btn_DuiHuanImage = null;
		private UnityEngine.UI.Button m_E_Btn_ShopButton = null;
		private UnityEngine.UI.Image m_E_Btn_ShopImage = null;
		private UnityEngine.UI.Text m_E_DuiHuan_GoldText = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jia1Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jia1Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jia10Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jia10Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jian1Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jian1Image = null;
		private UnityEngine.UI.Button m_E_Btn_BuyNum_jian10Button = null;
		private UnityEngine.UI.Image m_E_Btn_BuyNum_jian10Image = null;
		private UnityEngine.UI.InputField m_E_Lab_RmbNumInputField = null;
		private UnityEngine.UI.Image m_E_Lab_RmbNumImage = null;
		private UnityEngine.UI.Text m_E_Lab_DuiHuanGoldProShowText = null;
		private UnityEngine.UI.Text m_E_Lab_DuiHuanZuanShiProShowText = null;
		private UnityEngine.UI.Text m_E_Lab_WeiJingGoldText = null;
		public Transform uiTransform = null;
	}
}
