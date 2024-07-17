using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetHeXinChouKa : Entity,IAwake<Transform>,IDestroy 
	{
		public Image E_ItemImageIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemImageIconImage == null )
     			{
		    		this.m_E_ItemImageIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"CostItem/E_ItemImageIcon");
     			}
     			return this.m_E_ItemImageIconImage;
     		}
     	}

		public Text E_Text_CostNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CostNumberText == null )
     			{
		    		this.m_E_Text_CostNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"CostItem/E_Text_CostNumber");
     			}
     			return this.m_E_Text_CostNumberText;
     		}
     	}

		public Text E_Text_DiamondNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_DiamondNumberText == null )
     			{
		    		this.m_E_Text_DiamondNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_DiamondNumber");
     			}
     			return this.m_E_Text_DiamondNumberText;
     		}
     	}

		public Image E_ItemImageIcon10Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemImageIcon10Image == null )
     			{
		    		this.m_E_ItemImageIcon10Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ItemImageIcon10");
     			}
     			return this.m_E_ItemImageIcon10Image;
     		}
     	}

		public Button E_Btn_ChouKaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaButton == null )
     			{
		    		this.m_E_Btn_ChouKaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ChouKa");
     			}
     			return this.m_E_Btn_ChouKaButton;
     		}
     	}

		public Image E_Btn_ChouKaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaImage == null )
     			{
		    		this.m_E_Btn_ChouKaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ChouKa");
     			}
     			return this.m_E_Btn_ChouKaImage;
     		}
     	}

		public Button E_Btn_ChouKaTenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaTenButton == null )
     			{
		    		this.m_E_Btn_ChouKaTenButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenButton;
     		}
     	}

		public Image E_Btn_ChouKaTenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaTenImage == null )
     			{
		    		this.m_E_Btn_ChouKaTenImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenImage;
     		}
     	}

		public Button E_Btn_RolePetHeXinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RolePetHeXinButton == null )
     			{
		    		this.m_E_Btn_RolePetHeXinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_RolePetHeXin");
     			}
     			return this.m_E_Btn_RolePetHeXinButton;
     		}
     	}

		public Image E_Btn_RolePetHeXinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RolePetHeXinImage == null )
     			{
		    		this.m_E_Btn_RolePetHeXinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_RolePetHeXin");
     			}
     			return this.m_E_Btn_RolePetHeXinImage;
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
			this.m_E_ItemImageIconImage = null;
			this.m_E_Text_CostNumberText = null;
			this.m_E_Text_DiamondNumberText = null;
			this.m_E_ItemImageIcon10Image = null;
			this.m_E_Btn_ChouKaButton = null;
			this.m_E_Btn_ChouKaImage = null;
			this.m_E_Btn_ChouKaTenButton = null;
			this.m_E_Btn_ChouKaTenImage = null;
			this.m_E_Btn_RolePetHeXinButton = null;
			this.m_E_Btn_RolePetHeXinImage = null;
			this.uiTransform = null;
		}

		private Image m_E_ItemImageIconImage = null;
		private Text m_E_Text_CostNumberText = null;
		private Text m_E_Text_DiamondNumberText = null;
		private Image m_E_ItemImageIcon10Image = null;
		private Button m_E_Btn_ChouKaButton = null;
		private Image m_E_Btn_ChouKaImage = null;
		private Button m_E_Btn_ChouKaTenButton = null;
		private Image m_E_Btn_ChouKaTenImage = null;
		private Button m_E_Btn_RolePetHeXinButton = null;
		private Image m_E_Btn_RolePetHeXinImage = null;
		public Transform uiTransform = null;
	}
}
