
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgItemBatchUse))]
	[EnableMethod]
	public  class DlgItemBatchUseViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Button E_Btn_OpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_OpenButton == null )
     			{
		    		this.m_E_Btn_OpenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_Open");
     			}
     			return this.m_E_Btn_OpenButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_OpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_OpenImage == null )
     			{
		    		this.m_E_Btn_OpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Open");
     			}
     			return this.m_E_Btn_OpenImage;
     		}
     	}

		public UnityEngine.UI.Text E_Label_ItemNumText
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
		    		this.m_E_Label_ItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Label_ItemNum");
     			}
     			return this.m_E_Label_ItemNumText;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
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
		    		this.m_E_Btn_AddImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Btn_AddEventTrigger
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
		    		this.m_E_Btn_AddEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddEventTrigger;
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
		    		this.m_E_Btn_CostImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Cost");
     			}
     			return this.m_E_Btn_CostImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Btn_CostEventTrigger
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
		    		this.m_E_Btn_CostEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/E_Btn_Cost");
     			}
     			return this.m_E_Btn_CostEventTrigger;
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
		    		this.m_E_PriceInputFieldInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/E_PriceInputField");
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
		    		this.m_E_PriceInputFieldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_PriceInputField");
     			}
     			return this.m_E_PriceInputFieldImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_Btn_OpenButton = null;
			this.m_E_Btn_OpenImage = null;
			this.m_E_Label_ItemNumText = null;
			this.m_es_commonitem = null;
			this.m_E_Btn_AddImage = null;
			this.m_E_Btn_AddEventTrigger = null;
			this.m_E_Btn_CostImage = null;
			this.m_E_Btn_CostEventTrigger = null;
			this.m_E_PriceInputFieldInputField = null;
			this.m_E_PriceInputFieldImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Button m_E_Btn_OpenButton = null;
		private UnityEngine.UI.Image m_E_Btn_OpenImage = null;
		private UnityEngine.UI.Text m_E_Label_ItemNumText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Image m_E_Btn_AddImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_AddEventTrigger = null;
		private UnityEngine.UI.Image m_E_Btn_CostImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_CostEventTrigger = null;
		private UnityEngine.UI.InputField m_E_PriceInputFieldInputField = null;
		private UnityEngine.UI.Image m_E_PriceInputFieldImage = null;
		public Transform uiTransform = null;
	}
}
