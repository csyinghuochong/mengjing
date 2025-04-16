
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_StallSell : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.InputField E_Stall_NameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Stall_NameInputField == null )
     			{
		    		this.m_E_Stall_NameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"E_Stall_Name");
     			}
     			return this.m_E_Stall_NameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_Stall_NameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Stall_NameImage == null )
     			{
		    		this.m_E_Stall_NameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Stall_Name");
     			}
     			return this.m_E_Stall_NameImage;
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
		    		this.m_E_Btn_ChangeNameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_ChangeName");
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
		    		this.m_E_Btn_ChangeNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_ChangeName");
     			}
     			return this.m_E_Btn_ChangeNameImage;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PaiMaiSellItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PaiMaiSellItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PaiMaiSellItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PaiMaiSellItems");
     			}
     			return this.m_E_PaiMaiSellItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_StallButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StallButton == null )
     			{
		    		this.m_E_Btn_StallButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Stall");
     			}
     			return this.m_E_Btn_StallButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_StallImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StallImage == null )
     			{
		    		this.m_E_Btn_StallImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Stall");
     			}
     			return this.m_E_Btn_StallImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ShangJiaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShangJiaButton == null )
     			{
		    		this.m_E_Btn_ShangJiaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_ShangJia");
     			}
     			return this.m_E_Btn_ShangJiaButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ShangJiaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShangJiaImage == null )
     			{
		    		this.m_E_Btn_ShangJiaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_ShangJia");
     			}
     			return this.m_E_Btn_ShangJiaImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XiaJiaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiaJiaButton == null )
     			{
		    		this.m_E_Btn_XiaJiaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_XiaJia");
     			}
     			return this.m_E_Btn_XiaJiaButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XiaJiaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiaJiaImage == null )
     			{
		    		this.m_E_Btn_XiaJiaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_XiaJia");
     			}
     			return this.m_E_Btn_XiaJiaImage;
     		}
     	}

		public UnityEngine.UI.Text E_ShangJiaNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShangJiaNumberText == null )
     			{
		    		this.m_E_ShangJiaNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ShangJiaNumber");
     			}
     			return this.m_E_ShangJiaNumberText;
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
			this.m_E_Stall_NameInputField = null;
			this.m_E_Stall_NameImage = null;
			this.m_E_Btn_ChangeNameButton = null;
			this.m_E_Btn_ChangeNameImage = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_PaiMaiSellItemsLoopVerticalScrollRect = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_StallButton = null;
			this.m_E_Btn_StallImage = null;
			this.m_E_Btn_ShangJiaButton = null;
			this.m_E_Btn_ShangJiaImage = null;
			this.m_E_Btn_XiaJiaButton = null;
			this.m_E_Btn_XiaJiaImage = null;
			this.m_E_ShangJiaNumberText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.InputField m_E_Stall_NameInputField = null;
		private UnityEngine.UI.Image m_E_Stall_NameImage = null;
		private UnityEngine.UI.Button m_E_Btn_ChangeNameButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChangeNameImage = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PaiMaiSellItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_StallButton = null;
		private UnityEngine.UI.Image m_E_Btn_StallImage = null;
		private UnityEngine.UI.Button m_E_Btn_ShangJiaButton = null;
		private UnityEngine.UI.Image m_E_Btn_ShangJiaImage = null;
		private UnityEngine.UI.Button m_E_Btn_XiaJiaButton = null;
		private UnityEngine.UI.Image m_E_Btn_XiaJiaImage = null;
		private UnityEngine.UI.Text m_E_ShangJiaNumberText = null;
		public Transform uiTransform = null;
	}
}
