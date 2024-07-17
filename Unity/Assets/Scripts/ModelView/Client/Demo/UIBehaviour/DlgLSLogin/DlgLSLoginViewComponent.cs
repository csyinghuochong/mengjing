using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgLSLogin))]
	[EnableMethod]
	public  class DlgLSLoginViewComponent : Entity,IAwake,IDestroy 
	{
		public InputField EAccountInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EAccountInputField == null )
     			{
		    		this.m_EAccountInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Panel/EAccount");
     			}
     			return this.m_EAccountInputField;
     		}
     	}

		public Image EAccountImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EAccountImage == null )
     			{
		    		this.m_EAccountImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/EAccount");
     			}
     			return this.m_EAccountImage;
     		}
     	}

		public InputField EPasswordInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPasswordInputField == null )
     			{
		    		this.m_EPasswordInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Panel/EPassword");
     			}
     			return this.m_EPasswordInputField;
     		}
     	}

		public Image EPasswordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPasswordImage == null )
     			{
		    		this.m_EPasswordImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/EPassword");
     			}
     			return this.m_EPasswordImage;
     		}
     	}

		public Button ELoginBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoginBtnButton == null )
     			{
		    		this.m_ELoginBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Panel/ELoginBtn");
     			}
     			return this.m_ELoginBtnButton;
     		}
     	}

		public Image ELoginBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoginBtnImage == null )
     			{
		    		this.m_ELoginBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/ELoginBtn");
     			}
     			return this.m_ELoginBtnImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EAccountInputField = null;
			this.m_EAccountImage = null;
			this.m_EPasswordInputField = null;
			this.m_EPasswordImage = null;
			this.m_ELoginBtnButton = null;
			this.m_ELoginBtnImage = null;
			this.uiTransform = null;
		}

		private InputField m_EAccountInputField = null;
		private Image m_EAccountImage = null;
		private InputField m_EPasswordInputField = null;
		private Image m_EPasswordImage = null;
		private Button m_ELoginBtnButton = null;
		private Image m_ELoginBtnImage = null;
		public Transform uiTransform = null;
	}
}
