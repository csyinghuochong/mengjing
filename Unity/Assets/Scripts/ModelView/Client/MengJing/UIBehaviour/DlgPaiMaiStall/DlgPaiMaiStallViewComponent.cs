
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPaiMaiStall))]
	[EnableMethod]
	public  class DlgPaiMaiStallViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Image E_RechargeItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RechargeItemsImage == null )
     			{
		    		this.m_E_RechargeItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_RechargeItems");
     			}
     			return this.m_E_RechargeItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RechargeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RechargeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RechargeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_RechargeItems");
     			}
     			return this.m_E_RechargeItemsLoopVerticalScrollRect;
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

		public UnityEngine.UI.Button E_Btn_ShouTanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShouTanButton == null )
     			{
		    		this.m_E_Btn_ShouTanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_ShouTan");
     			}
     			return this.m_E_Btn_ShouTanButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ShouTanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShouTanImage == null )
     			{
		    		this.m_E_Btn_ShouTanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_ShouTan");
     			}
     			return this.m_E_Btn_ShouTanImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_BuyItemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyItemButton == null )
     			{
		    		this.m_E_Btn_BuyItemButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_BuyItem");
     			}
     			return this.m_E_Btn_BuyItemButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_BuyItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_BuyItemImage == null )
     			{
		    		this.m_E_Btn_BuyItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_BuyItem");
     			}
     			return this.m_E_Btn_BuyItemImage;
     		}
     	}

		public UnityEngine.UI.InputField E_Lab_NameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NameInputField == null )
     			{
		    		this.m_E_Lab_NameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/E_Lab_Name");
     			}
     			return this.m_E_Lab_NameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_Lab_NameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NameImage == null )
     			{
		    		this.m_E_Lab_NameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Lab_Name");
     			}
     			return this.m_E_Lab_NameImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChangeNameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChangeNameButton == null )
     			{
		    		this.m_E_Btn_ChangeNameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_ChangeName");
     			}
     			return this.m_E_Btn_ChangeNameButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChangeNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChangeNameImage == null )
     			{
		    		this.m_E_Btn_ChangeNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_ChangeName");
     			}
     			return this.m_E_Btn_ChangeNameImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_RechargeItemsImage = null;
			this.m_E_RechargeItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.m_E_Btn_ShouTanButton = null;
			this.m_E_Btn_ShouTanImage = null;
			this.m_E_Btn_BuyItemButton = null;
			this.m_E_Btn_BuyItemImage = null;
			this.m_E_Lab_NameInputField = null;
			this.m_E_Lab_NameImage = null;
			this.m_E_Btn_ChangeNameButton = null;
			this.m_E_Btn_ChangeNameImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Image m_E_RechargeItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RechargeItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		private UnityEngine.UI.Button m_E_Btn_ShouTanButton = null;
		private UnityEngine.UI.Image m_E_Btn_ShouTanImage = null;
		private UnityEngine.UI.Button m_E_Btn_BuyItemButton = null;
		private UnityEngine.UI.Image m_E_Btn_BuyItemImage = null;
		private UnityEngine.UI.InputField m_E_Lab_NameInputField = null;
		private UnityEngine.UI.Image m_E_Lab_NameImage = null;
		private UnityEngine.UI.Button m_E_Btn_ChangeNameButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChangeNameImage = null;
		public Transform uiTransform = null;
	}
}
