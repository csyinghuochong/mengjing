using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgItemExpBox))]
	[EnableMethod]
	public  class DlgItemExpBoxViewComponent : Entity,IAwake,IDestroy 
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

		public Button E_Btn_MianFeiOpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_MianFeiOpenButton == null )
     			{
		    		this.m_E_Btn_MianFeiOpenButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_MianFeiOpen");
     			}
     			return this.m_E_Btn_MianFeiOpenButton;
     		}
     	}

		public Image E_Btn_MianFeiOpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_MianFeiOpenImage == null )
     			{
		    		this.m_E_Btn_MianFeiOpenImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_MianFeiOpen");
     			}
     			return this.m_E_Btn_MianFeiOpenImage;
     		}
     	}

		public Button E_Btn_ZuanShiOpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZuanShiOpenButton == null )
     			{
		    		this.m_E_Btn_ZuanShiOpenButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ZuanShiOpen");
     			}
     			return this.m_E_Btn_ZuanShiOpenButton;
     		}
     	}

		public Image E_Btn_ZuanShiOpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZuanShiOpenImage == null )
     			{
		    		this.m_E_Btn_ZuanShiOpenImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ZuanShiOpen");
     			}
     			return this.m_E_Btn_ZuanShiOpenImage;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public Text E_Label_ItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Label_ItemNumText == null )
     			{
		    		this.m_E_Label_ItemNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Label_ItemNum");
     			}
     			return this.m_E_Label_ItemNumText;
     		}
     	}

		public Text E_Text_ZuanShiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ZuanShiText == null )
     			{
		    		this.m_E_Text_ZuanShiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_ZuanShi");
     			}
     			return this.m_E_Text_ZuanShiText;
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
		    		this.m_E_Btn_AddImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Add");
     			}
     			return this.m_E_Btn_AddImage;
     		}
     	}

		public EventTrigger E_Btn_AddEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddEventTrigger == null )
     			{
		    		this.m_E_Btn_AddEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Btn_Add");
     			}
     			return this.m_E_Btn_AddEventTrigger;
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
		    		this.m_E_Btn_CostImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Cost");
     			}
     			return this.m_E_Btn_CostImage;
     		}
     	}

		public EventTrigger E_Btn_CostEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CostEventTrigger == null )
     			{
		    		this.m_E_Btn_CostEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Btn_Cost");
     			}
     			return this.m_E_Btn_CostEventTrigger;
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
		    		this.m_E_PriceInputFieldInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_PriceInputField");
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
		    		this.m_E_PriceInputFieldImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_PriceInputField");
     			}
     			return this.m_E_PriceInputFieldImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_Btn_MianFeiOpenButton = null;
			this.m_E_Btn_MianFeiOpenImage = null;
			this.m_E_Btn_ZuanShiOpenButton = null;
			this.m_E_Btn_ZuanShiOpenImage = null;
			this.m_es_commonitem = null;
			this.m_E_Label_ItemNumText = null;
			this.m_E_Text_ZuanShiText = null;
			this.m_E_Btn_AddImage = null;
			this.m_E_Btn_AddEventTrigger = null;
			this.m_E_Btn_CostImage = null;
			this.m_E_Btn_CostEventTrigger = null;
			this.m_E_PriceInputFieldInputField = null;
			this.m_E_PriceInputFieldImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private Button m_E_Btn_MianFeiOpenButton = null;
		private Image m_E_Btn_MianFeiOpenImage = null;
		private Button m_E_Btn_ZuanShiOpenButton = null;
		private Image m_E_Btn_ZuanShiOpenImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Text m_E_Label_ItemNumText = null;
		private Text m_E_Text_ZuanShiText = null;
		private Image m_E_Btn_AddImage = null;
		private EventTrigger m_E_Btn_AddEventTrigger = null;
		private Image m_E_Btn_CostImage = null;
		private EventTrigger m_E_Btn_CostEventTrigger = null;
		private InputField m_E_PriceInputFieldInputField = null;
		private Image m_E_PriceInputFieldImage = null;
		public Transform uiTransform = null;
	}
}
