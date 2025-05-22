
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetHeXinChouKa : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image E_ItemImageIconImage
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
		    		this.m_E_ItemImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/CostItem/E_ItemImageIcon");
     			}
     			return this.m_E_ItemImageIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CostNumberText
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
		    		this.m_E_Text_CostNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/CostItem/E_Text_CostNumber");
     			}
     			return this.m_E_Text_CostNumberText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChouKaButton
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
		    		this.m_E_Btn_ChouKaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Btn_ChouKa");
     			}
     			return this.m_E_Btn_ChouKaButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaImage
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
		    		this.m_E_Btn_ChouKaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Btn_ChouKa");
     			}
     			return this.m_E_Btn_ChouKaImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_DiamondNumberText
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
		    		this.m_E_Text_DiamondNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_DiamondNumber");
     			}
     			return this.m_E_Text_DiamondNumberText;
     		}
     	}

		public UnityEngine.UI.Image E_ItemImageIcon10Image
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
		    		this.m_E_ItemImageIcon10Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ItemImageIcon10");
     			}
     			return this.m_E_ItemImageIcon10Image;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChouKaTenButton
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
		    		this.m_E_Btn_ChouKaTenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaTenImage
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
		    		this.m_E_Btn_ChouKaTenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_RolePetHeXinButton
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
		    		this.m_E_Btn_RolePetHeXinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_RolePetHeXin");
     			}
     			return this.m_E_Btn_RolePetHeXinButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_RolePetHeXinImage
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
		    		this.m_E_Btn_RolePetHeXinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_RolePetHeXin");
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
			this.m_E_Btn_ChouKaButton = null;
			this.m_E_Btn_ChouKaImage = null;
			this.m_E_Text_DiamondNumberText = null;
			this.m_E_ItemImageIcon10Image = null;
			this.m_E_Btn_ChouKaTenButton = null;
			this.m_E_Btn_ChouKaTenImage = null;
			this.m_E_Btn_RolePetHeXinButton = null;
			this.m_E_Btn_RolePetHeXinImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ItemImageIconImage = null;
		private UnityEngine.UI.Text m_E_Text_CostNumberText = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaImage = null;
		private UnityEngine.UI.Text m_E_Text_DiamondNumberText = null;
		private UnityEngine.UI.Image m_E_ItemImageIcon10Image = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaTenButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaTenImage = null;
		private UnityEngine.UI.Button m_E_Btn_RolePetHeXinButton = null;
		private UnityEngine.UI.Image m_E_Btn_RolePetHeXinImage = null;
		public Transform uiTransform = null;
	}
}
