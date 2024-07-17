using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgMJLogin))]
	[EnableMethod]
	public  class DlgMJLoginViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_LoginButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginButton == null )
     			{
		    		this.m_E_LoginButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"HideNode/BanHanNode/E_Login");
     			}
     			return this.m_E_LoginButton;
     		}
     	}

		public Image E_LoginImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoginImage == null )
     			{
		    		this.m_E_LoginImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"HideNode/BanHanNode/E_Login");
     			}
     			return this.m_E_LoginImage;
     		}
     	}

		public Text E_SelectServerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectServerNameText == null )
     			{
		    		this.m_E_SelectServerNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"HideNode/SelectGameServer/E_SelectServerName");
     			}
     			return this.m_E_SelectServerNameText;
     		}
     	}

		public Button E_SelectBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectBtnButton == null )
     			{
		    		this.m_E_SelectBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"HideNode/SelectGameServer/E_SelectBtn");
     			}
     			return this.m_E_SelectBtnButton;
     		}
     	}

		public Image E_SelectBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectBtnImage == null )
     			{
		    		this.m_E_SelectBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"HideNode/SelectGameServer/E_SelectBtn");
     			}
     			return this.m_E_SelectBtnImage;
     		}
     	}

		public InputField E_AccountInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AccountInputField == null )
     			{
		    		this.m_E_AccountInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Panel/E_Account");
     			}
     			return this.m_E_AccountInputField;
     		}
     	}

		public Image E_AccountImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AccountImage == null )
     			{
		    		this.m_E_AccountImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/E_Account");
     			}
     			return this.m_E_AccountImage;
     		}
     	}

		public InputField E_PasswordInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PasswordInputField == null )
     			{
		    		this.m_E_PasswordInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Panel/E_Password");
     			}
     			return this.m_E_PasswordInputField;
     		}
     	}

		public Image E_PasswordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PasswordImage == null )
     			{
		    		this.m_E_PasswordImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/E_Password");
     			}
     			return this.m_E_PasswordImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_LoginButton = null;
			this.m_E_LoginImage = null;
			this.m_E_SelectServerNameText = null;
			this.m_E_SelectBtnButton = null;
			this.m_E_SelectBtnImage = null;
			this.m_E_AccountInputField = null;
			this.m_E_AccountImage = null;
			this.m_E_PasswordInputField = null;
			this.m_E_PasswordImage = null;
			this.uiTransform = null;
		}

		private Button m_E_LoginButton = null;
		private Image m_E_LoginImage = null;
		private Text m_E_SelectServerNameText = null;
		private Button m_E_SelectBtnButton = null;
		private Image m_E_SelectBtnImage = null;
		private InputField m_E_AccountInputField = null;
		private Image m_E_AccountImage = null;
		private InputField m_E_PasswordInputField = null;
		private Image m_E_PasswordImage = null;
		public Transform uiTransform = null;
	}
}
