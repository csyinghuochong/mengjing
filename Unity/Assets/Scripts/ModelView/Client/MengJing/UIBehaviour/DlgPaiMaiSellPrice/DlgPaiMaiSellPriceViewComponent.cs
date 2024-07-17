using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPaiMaiSellPrice))]
	[EnableMethod]
	public  class DlgPaiMaiSellPriceViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
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
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
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
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public Button E_Btn_ChuShouButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChuShouButton == null )
     			{
		    		this.m_E_Btn_ChuShouButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ChuShou");
     			}
     			return this.m_E_Btn_ChuShouButton;
     		}
     	}

		public Image E_Btn_ChuShouImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChuShouImage == null )
     			{
		    		this.m_E_Btn_ChuShouImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ChuShou");
     			}
     			return this.m_E_Btn_ChuShouImage;
     		}
     	}

		public Text E_Lab_TuijianText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_TuijianText == null )
     			{
		    		this.m_E_Lab_TuijianText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ShowShangJia/Image1/E_Lab_Tuijian");
     			}
     			return this.m_E_Lab_TuijianText;
     		}
     	}

		public Text E_Lab_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NameText == null )
     			{
		    		this.m_E_Lab_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Name");
     			}
     			return this.m_E_Lab_NameText;
     		}
     	}

		public Button E_Btn_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddButton == null )
     			{
		    		this.m_E_Btn_AddButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"SellPriceSet/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddButton;
     		}
     	}

		public Image E_Btn_AddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddImage == null )
     			{
		    		this.m_E_Btn_AddImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"SellPriceSet/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddImage;
     		}
     	}

		public Button E_Btn_CostButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CostButton == null )
     			{
		    		this.m_E_Btn_CostButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"SellPriceSet/E_Btn_Cost");
     			}
     			return this.m_E_Btn_CostButton;
     		}
     	}

		public Image E_Btn_CostImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CostImage == null )
     			{
		    		this.m_E_Btn_CostImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"SellPriceSet/E_Btn_Cost");
     			}
     			return this.m_E_Btn_CostImage;
     		}
     	}

		public InputField E_PriceInputFieldInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PriceInputFieldInputField == null )
     			{
		    		this.m_E_PriceInputFieldInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"SellPriceSet/E_PriceInputField");
     			}
     			return this.m_E_PriceInputFieldInputField;
     		}
     	}

		public Image E_PriceInputFieldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PriceInputFieldImage == null )
     			{
		    		this.m_E_PriceInputFieldImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"SellPriceSet/E_PriceInputField");
     			}
     			return this.m_E_PriceInputFieldImage;
     		}
     	}

		public Text E_Text_PriceText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PriceText == null )
     			{
		    		this.m_E_Text_PriceText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"SellPriceSet/E_PriceInputField/E_Text_Price");
     			}
     			return this.m_E_Text_PriceText;
     		}
     	}

		public Button E_Btn_AddNumButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddNumButton == null )
     			{
		    		this.m_E_Btn_AddNumButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"SellNumSet/E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumButton;
     		}
     	}

		public Image E_Btn_AddNumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddNumImage == null )
     			{
		    		this.m_E_Btn_AddNumImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"SellNumSet/E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumImage;
     		}
     	}

		public EventTrigger E_Btn_AddNumEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddNumEventTrigger == null )
     			{
		    		this.m_E_Btn_AddNumEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"SellNumSet/E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumEventTrigger;
     		}
     	}

		public Button E_Btn_CostNumButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CostNumButton == null )
     			{
		    		this.m_E_Btn_CostNumButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"SellNumSet/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumButton;
     		}
     	}

		public Image E_Btn_CostNumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CostNumImage == null )
     			{
		    		this.m_E_Btn_CostNumImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"SellNumSet/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumImage;
     		}
     	}

		public EventTrigger E_Btn_CostNumEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CostNumEventTrigger == null )
     			{
		    		this.m_E_Btn_CostNumEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"SellNumSet/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumEventTrigger;
     		}
     	}

		public Text E_Text_NumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NumText == null )
     			{
		    		this.m_E_Text_NumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"SellNumSet/E_Text_Num");
     			}
     			return this.m_E_Text_NumText;
     		}
     	}

		public Text E_Lab_SellSumProText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_SellSumProText == null )
     			{
		    		this.m_E_Lab_SellSumProText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Lab_Time (1)/E_Lab_SellSumPro");
     			}
     			return this.m_E_Lab_SellSumProText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_es_commonitem = null;
			this.m_E_Btn_ChuShouButton = null;
			this.m_E_Btn_ChuShouImage = null;
			this.m_E_Lab_TuijianText = null;
			this.m_E_Lab_NameText = null;
			this.m_E_Btn_AddButton = null;
			this.m_E_Btn_AddImage = null;
			this.m_E_Btn_CostButton = null;
			this.m_E_Btn_CostImage = null;
			this.m_E_PriceInputFieldInputField = null;
			this.m_E_PriceInputFieldImage = null;
			this.m_E_Text_PriceText = null;
			this.m_E_Btn_AddNumButton = null;
			this.m_E_Btn_AddNumImage = null;
			this.m_E_Btn_AddNumEventTrigger = null;
			this.m_E_Btn_CostNumButton = null;
			this.m_E_Btn_CostNumImage = null;
			this.m_E_Btn_CostNumEventTrigger = null;
			this.m_E_Text_NumText = null;
			this.m_E_Lab_SellSumProText = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Button m_E_Btn_ChuShouButton = null;
		private Image m_E_Btn_ChuShouImage = null;
		private Text m_E_Lab_TuijianText = null;
		private Text m_E_Lab_NameText = null;
		private Button m_E_Btn_AddButton = null;
		private Image m_E_Btn_AddImage = null;
		private Button m_E_Btn_CostButton = null;
		private Image m_E_Btn_CostImage = null;
		private InputField m_E_PriceInputFieldInputField = null;
		private Image m_E_PriceInputFieldImage = null;
		private Text m_E_Text_PriceText = null;
		private Button m_E_Btn_AddNumButton = null;
		private Image m_E_Btn_AddNumImage = null;
		private EventTrigger m_E_Btn_AddNumEventTrigger = null;
		private Button m_E_Btn_CostNumButton = null;
		private Image m_E_Btn_CostNumImage = null;
		private EventTrigger m_E_Btn_CostNumEventTrigger = null;
		private Text m_E_Text_NumText = null;
		private Text m_E_Lab_SellSumProText = null;
		public Transform uiTransform = null;
	}
}
