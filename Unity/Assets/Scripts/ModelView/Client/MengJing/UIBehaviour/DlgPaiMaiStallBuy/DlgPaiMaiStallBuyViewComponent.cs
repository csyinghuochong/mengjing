
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPaiMaiStallBuy))]
	[EnableMethod]
	public  class DlgPaiMaiStallBuyViewComponent : Entity,IAwake,IDestroy 
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BuyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyButton == null )
     			{
		    		this.m_E_Btn_BuyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_Buy");
     			}
     			return this.m_E_Btn_BuyButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BuyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyImage == null )
     			{
		    		this.m_E_Btn_BuyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Buy");
     			}
     			return this.m_E_Btn_BuyImage;
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
		    		this.m_E_Btn_AddNumButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_AddNum");
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
		    		this.m_E_Btn_AddNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_AddNum");
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
		    		this.m_E_Btn_AddNumEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/E_Btn_AddNum");
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
		    		this.m_E_Btn_CostNumButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_CostNum");
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
		    		this.m_E_Btn_CostNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_CostNum");
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
		    		this.m_E_Btn_CostNumEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CloseButton
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
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CloseImage
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
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Btn_CloseEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseEventTrigger == null )
     			{
		    		this.m_E_Btn_CloseEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ChuShouPriceText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ChuShouPriceText == null )
     			{
		    		this.m_E_Lab_ChuShouPriceText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Lab_ChuShouPrice");
     			}
     			return this.m_E_Lab_ChuShouPriceText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ItemNameText == null )
     			{
		    		this.m_E_Lab_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Lab_ItemName");
     			}
     			return this.m_E_Lab_ItemNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_NumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NumberText == null )
     			{
		    		this.m_E_Text_NumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Number");
     			}
     			return this.m_E_Text_NumberText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_es_commonitem = null;
			this.m_E_Btn_BuyButton = null;
			this.m_E_Btn_BuyImage = null;
			this.m_E_Btn_AddNumButton = null;
			this.m_E_Btn_AddNumImage = null;
			this.m_E_Btn_AddNumEventTrigger = null;
			this.m_E_Btn_CostNumButton = null;
			this.m_E_Btn_CostNumImage = null;
			this.m_E_Btn_CostNumEventTrigger = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_Btn_CloseEventTrigger = null;
			this.m_E_Lab_ChuShouPriceText = null;
			this.m_E_Lab_ItemNameText = null;
			this.m_E_Text_NumberText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Button m_E_Btn_BuyButton = null;
		private UnityEngine.UI.Image m_E_Btn_BuyImage = null;
		private UnityEngine.UI.Button m_E_Btn_AddNumButton = null;
		private UnityEngine.UI.Image m_E_Btn_AddNumImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_AddNumEventTrigger = null;
		private UnityEngine.UI.Button m_E_Btn_CostNumButton = null;
		private UnityEngine.UI.Image m_E_Btn_CostNumImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_CostNumEventTrigger = null;
		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_CloseEventTrigger = null;
		private UnityEngine.UI.Text m_E_Lab_ChuShouPriceText = null;
		private UnityEngine.UI.Text m_E_Lab_ItemNameText = null;
		private UnityEngine.UI.Text m_E_Text_NumberText = null;
		public Transform uiTransform = null;
	}
}
