
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPaiMaiSellPrice))]
	[EnableMethod]
	public  class DlgPaiMaiSellPriceViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageButtonButton
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
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
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_NameText
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
		    		this.m_E_Lab_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Lab_Name");
     			}
     			return this.m_E_Lab_NameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_TuijianText
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
		    		this.m_E_Lab_TuijianText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Lab_Tuijian");
     			}
     			return this.m_E_Lab_TuijianText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChuShouButton
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
		    		this.m_E_Btn_ChuShouButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ChuShou");
     			}
     			return this.m_E_Btn_ChuShouButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChuShouImage
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
		    		this.m_E_Btn_ChuShouImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ChuShou");
     			}
     			return this.m_E_Btn_ChuShouImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_AddNumButton
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
		    		this.m_E_Btn_AddNumButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_AddNumImage
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
		    		this.m_E_Btn_AddNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Btn_AddNumEventTrigger
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
		    		this.m_E_Btn_AddNumEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CostNumButton
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
		    		this.m_E_Btn_CostNumButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CostNumImage
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
		    		this.m_E_Btn_CostNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Btn_CostNumEventTrigger
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
		    		this.m_E_Btn_CostNumEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumEventTrigger;
     		}
     	}

		public UnityEngine.UI.InputField E_PriceInputFieldInputField
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
		    		this.m_E_PriceInputFieldInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Right/E_PriceInputField");
     			}
     			return this.m_E_PriceInputFieldInputField;
     		}
     	}

		public UnityEngine.UI.Image E_PriceInputFieldImage
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
		    		this.m_E_PriceInputFieldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_PriceInputField");
     			}
     			return this.m_E_PriceInputFieldImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_NumText
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
		    		this.m_E_Text_NumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Num");
     			}
     			return this.m_E_Text_NumText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_AddButton
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
		    		this.m_E_Btn_AddButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_AddImage
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
		    		this.m_E_Btn_AddImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CostButton
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
		    		this.m_E_Btn_CostButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Cost");
     			}
     			return this.m_E_Btn_CostButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CostImage
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
		    		this.m_E_Btn_CostImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Cost");
     			}
     			return this.m_E_Btn_CostImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Price11Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Price11Text == null )
     			{
		    		this.m_E_Text_Price11Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Price11");
     			}
     			return this.m_E_Text_Price11Text;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SellSumProText
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
		    		this.m_E_Lab_SellSumProText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_SellSumPro");
     			}
     			return this.m_E_Lab_SellSumProText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_es_commonitem = null;
			this.m_E_Lab_NameText = null;
			this.m_E_Lab_TuijianText = null;
			this.m_E_Btn_ChuShouButton = null;
			this.m_E_Btn_ChuShouImage = null;
			this.m_E_Btn_AddNumButton = null;
			this.m_E_Btn_AddNumImage = null;
			this.m_E_Btn_AddNumEventTrigger = null;
			this.m_E_Btn_CostNumButton = null;
			this.m_E_Btn_CostNumImage = null;
			this.m_E_Btn_CostNumEventTrigger = null;
			this.m_E_PriceInputFieldInputField = null;
			this.m_E_PriceInputFieldImage = null;
			this.m_E_Text_NumText = null;
			this.m_E_Btn_AddButton = null;
			this.m_E_Btn_AddImage = null;
			this.m_E_Btn_CostButton = null;
			this.m_E_Btn_CostImage = null;
			this.m_E_Text_Price11Text = null;
			this.m_E_Lab_SellSumProText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Text m_E_Lab_NameText = null;
		private UnityEngine.UI.Text m_E_Lab_TuijianText = null;
		private UnityEngine.UI.Button m_E_Btn_ChuShouButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChuShouImage = null;
		private UnityEngine.UI.Button m_E_Btn_AddNumButton = null;
		private UnityEngine.UI.Image m_E_Btn_AddNumImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_AddNumEventTrigger = null;
		private UnityEngine.UI.Button m_E_Btn_CostNumButton = null;
		private UnityEngine.UI.Image m_E_Btn_CostNumImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_CostNumEventTrigger = null;
		private UnityEngine.UI.InputField m_E_PriceInputFieldInputField = null;
		private UnityEngine.UI.Image m_E_PriceInputFieldImage = null;
		private UnityEngine.UI.Text m_E_Text_NumText = null;
		private UnityEngine.UI.Button m_E_Btn_AddButton = null;
		private UnityEngine.UI.Image m_E_Btn_AddImage = null;
		private UnityEngine.UI.Button m_E_Btn_CostButton = null;
		private UnityEngine.UI.Image m_E_Btn_CostImage = null;
		private UnityEngine.UI.Text m_E_Text_Price11Text = null;
		private UnityEngine.UI.Text m_E_Lab_SellSumProText = null;
		public Transform uiTransform = null;
	}
}
