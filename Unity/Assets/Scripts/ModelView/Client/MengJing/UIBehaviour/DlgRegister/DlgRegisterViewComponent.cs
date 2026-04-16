
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRegister))]
	[EnableMethod]
	public  class DlgRegisterViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public UnityEngine.UI.InputField E_AccountInputField
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
		    		this.m_E_AccountInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/E_Account");
     			}
     			return this.m_E_AccountInputField;
     		}
     	}

		public UnityEngine.UI.Image E_AccountImage
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
		    		this.m_E_AccountImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Account");
     			}
     			return this.m_E_AccountImage;
     		}
     	}

		public UnityEngine.UI.InputField E_PasswordInputField
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
		    		this.m_E_PasswordInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/E_Password");
     			}
     			return this.m_E_PasswordInputField;
     		}
     	}

		public UnityEngine.UI.Image E_PasswordImage
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
		    		this.m_E_PasswordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Password");
     			}
     			return this.m_E_PasswordImage;
     		}
     	}

		public UnityEngine.UI.InputField E_ConfirmPasswordInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmPasswordInputField == null )
     			{
		    		this.m_E_ConfirmPasswordInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/E_ConfirmPassword");
     			}
     			return this.m_E_ConfirmPasswordInputField;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmPasswordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmPasswordImage == null )
     			{
		    		this.m_E_ConfirmPasswordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ConfirmPassword");
     			}
     			return this.m_E_ConfirmPasswordImage;
     		}
     	}

		public UnityEngine.UI.Button E_RegisterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterButton == null )
     			{
		    		this.m_E_RegisterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Register");
     			}
     			return this.m_E_RegisterButton;
     		}
     	}

		public UnityEngine.UI.Image E_RegisterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RegisterImage == null )
     			{
		    		this.m_E_RegisterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Register");
     			}
     			return this.m_E_RegisterImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_E_AccountInputField = null;
			this.m_E_AccountImage = null;
			this.m_E_PasswordInputField = null;
			this.m_E_PasswordImage = null;
			this.m_E_ConfirmPasswordInputField = null;
			this.m_E_ConfirmPasswordImage = null;
			this.m_E_RegisterButton = null;
			this.m_E_RegisterImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		private UnityEngine.UI.InputField m_E_AccountInputField = null;
		private UnityEngine.UI.Image m_E_AccountImage = null;
		private UnityEngine.UI.InputField m_E_PasswordInputField = null;
		private UnityEngine.UI.Image m_E_PasswordImage = null;
		private UnityEngine.UI.InputField m_E_ConfirmPasswordInputField = null;
		private UnityEngine.UI.Image m_E_ConfirmPasswordImage = null;
		private UnityEngine.UI.Button m_E_RegisterButton = null;
		private UnityEngine.UI.Image m_E_RegisterImage = null;
		public Transform uiTransform = null;
	}
}
