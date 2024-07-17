using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgItemSellTip))]
	[EnableMethod]
	public  class DlgItemSellTipViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public Button E_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddButton == null )
     			{
		    		this.m_E_AddButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Add");
     			}
     			return this.m_E_AddButton;
     		}
     	}

		public Image E_AddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddImage == null )
     			{
		    		this.m_E_AddImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Add");
     			}
     			return this.m_E_AddImage;
     		}
     	}

		public InputField E_NumInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NumInputField == null )
     			{
		    		this.m_E_NumInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_Num");
     			}
     			return this.m_E_NumInputField;
     		}
     	}

		public Image E_NumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NumImage == null )
     			{
		    		this.m_E_NumImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Num");
     			}
     			return this.m_E_NumImage;
     		}
     	}

		public Button E_CostButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostButton == null )
     			{
		    		this.m_E_CostButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Cost");
     			}
     			return this.m_E_CostButton;
     		}
     	}

		public Image E_CostImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostImage == null )
     			{
		    		this.m_E_CostImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Cost");
     			}
     			return this.m_E_CostImage;
     		}
     	}

		public Image E_MoneyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MoneyImage == null )
     			{
		    		this.m_E_MoneyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Money");
     			}
     			return this.m_E_MoneyImage;
     		}
     	}

		public Text E_TotalPricesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TotalPricesText == null )
     			{
		    		this.m_E_TotalPricesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TotalPrices");
     			}
     			return this.m_E_TotalPricesText;
     		}
     	}

		public Button E_CancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelButton == null )
     			{
		    		this.m_E_CancelButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Cancel");
     			}
     			return this.m_E_CancelButton;
     		}
     	}

		public Image E_CancelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CancelImage == null )
     			{
		    		this.m_E_CancelImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Cancel");
     			}
     			return this.m_E_CancelImage;
     		}
     	}

		public Button E_ChuShouButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChuShouButton == null )
     			{
		    		this.m_E_ChuShouButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ChuShou");
     			}
     			return this.m_E_ChuShouButton;
     		}
     	}

		public Image E_ChuShouImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChuShouImage == null )
     			{
		    		this.m_E_ChuShouImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ChuShou");
     			}
     			return this.m_E_ChuShouImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_E_AddButton = null;
			this.m_E_AddImage = null;
			this.m_E_NumInputField = null;
			this.m_E_NumImage = null;
			this.m_E_CostButton = null;
			this.m_E_CostImage = null;
			this.m_E_MoneyImage = null;
			this.m_E_TotalPricesText = null;
			this.m_E_CancelButton = null;
			this.m_E_CancelImage = null;
			this.m_E_ChuShouButton = null;
			this.m_E_ChuShouImage = null;
			this.uiTransform = null;
		}

		private Button m_E_CloseButton = null;
		private Image m_E_CloseImage = null;
		private Button m_E_AddButton = null;
		private Image m_E_AddImage = null;
		private InputField m_E_NumInputField = null;
		private Image m_E_NumImage = null;
		private Button m_E_CostButton = null;
		private Image m_E_CostImage = null;
		private Image m_E_MoneyImage = null;
		private Text m_E_TotalPricesText = null;
		private Button m_E_CancelButton = null;
		private Image m_E_CancelImage = null;
		private Button m_E_ChuShouButton = null;
		private Image m_E_ChuShouImage = null;
		public Transform uiTransform = null;
	}
}
