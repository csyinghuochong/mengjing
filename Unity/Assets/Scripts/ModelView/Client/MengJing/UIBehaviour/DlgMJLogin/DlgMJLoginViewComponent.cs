
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMJLogin))]
	[EnableMethod]
	public  class DlgMJLoginViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_TextButton_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextButton_1Button == null )
     			{
		    		this.m_E_TextButton_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/HideNode/YinSiButon/E_TextButton_1");
     			}
     			return this.m_E_TextButton_1Button;
     		}
     	}

		public UnityEngine.UI.Text E_TextButton_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextButton_1Text == null )
     			{
		    		this.m_E_TextButton_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/HideNode/YinSiButon/E_TextButton_1");
     			}
     			return this.m_E_TextButton_1Text;
     		}
     	}

		public UnityEngine.UI.Button E_TextButton_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextButton_2Button == null )
     			{
		    		this.m_E_TextButton_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/HideNode/YinSiButon/E_TextButton_2");
     			}
     			return this.m_E_TextButton_2Button;
     		}
     	}

		public UnityEngine.UI.Text E_TextButton_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextButton_2Text == null )
     			{
		    		this.m_E_TextButton_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/HideNode/YinSiButon/E_TextButton_2");
     			}
     			return this.m_E_TextButton_2Text;
     		}
     	}

		public UnityEngine.UI.Button E_LoginButton
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
		    		this.m_E_LoginButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/HideNode/BanHanNode/E_Login");
     			}
     			return this.m_E_LoginButton;
     		}
     	}

		public UnityEngine.UI.Image E_LoginImage
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
		    		this.m_E_LoginImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/HideNode/BanHanNode/E_Login");
     			}
     			return this.m_E_LoginImage;
     		}
     	}

		public UnityEngine.UI.Text E_SelectServerNameText
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
		    		this.m_E_SelectServerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/HideNode/SelectGameServer/E_SelectServerName");
     			}
     			return this.m_E_SelectServerNameText;
     		}
     	}

		public UnityEngine.UI.Button E_SelectBtnButton
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
		    		this.m_E_SelectBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/HideNode/SelectGameServer/E_SelectBtn");
     			}
     			return this.m_E_SelectBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectBtnImage
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
		    		this.m_E_SelectBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/HideNode/SelectGameServer/E_SelectBtn");
     			}
     			return this.m_E_SelectBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_buttonAgeTipButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_buttonAgeTipButton == null )
     			{
		    		this.m_E_buttonAgeTipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_buttonAgeTip");
     			}
     			return this.m_E_buttonAgeTipButton;
     		}
     	}

		public UnityEngine.UI.Image E_buttonAgeTipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_buttonAgeTipImage == null )
     			{
		    		this.m_E_buttonAgeTipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_buttonAgeTip");
     			}
     			return this.m_E_buttonAgeTipImage;
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
		    		this.m_E_AccountInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/Panel/E_Account");
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
		    		this.m_E_AccountImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/Panel/E_Account");
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
		    		this.m_E_PasswordInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/Panel/E_Password");
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
		    		this.m_E_PasswordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/Panel/E_Password");
     			}
     			return this.m_E_PasswordImage;
     		}
     	}

		public UnityEngine.RectTransform EG_LoadingRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LoadingRectTransform == null )
     			{
		    		this.m_EG_LoadingRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_Loading");
     			}
     			return this.m_EG_LoadingRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_YinSiXieYiRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_YinSiXieYiRectTransform == null )
     			{
		    		this.m_EG_YinSiXieYiRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_YinSiXieYi");
     			}
     			return this.m_EG_YinSiXieYiRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_YinSiXieYiCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YinSiXieYiCloseButton == null )
     			{
		    		this.m_E_YinSiXieYiCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_YinSiXieYi/E_YinSiXieYiClose");
     			}
     			return this.m_E_YinSiXieYiCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_YinSiXieYiCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YinSiXieYiCloseImage == null )
     			{
		    		this.m_E_YinSiXieYiCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_YinSiXieYi/E_YinSiXieYiClose");
     			}
     			return this.m_E_YinSiXieYiCloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_YongHuXieYiRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_YongHuXieYiRectTransform == null )
     			{
		    		this.m_EG_YongHuXieYiRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_YongHuXieYi");
     			}
     			return this.m_EG_YongHuXieYiRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_YongHuXieYiCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YongHuXieYiCloseButton == null )
     			{
		    		this.m_E_YongHuXieYiCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_YongHuXieYi/E_YongHuXieYiClose");
     			}
     			return this.m_E_YongHuXieYiCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_YongHuXieYiCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YongHuXieYiCloseImage == null )
     			{
		    		this.m_E_YongHuXieYiCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_YongHuXieYi/E_YongHuXieYiClose");
     			}
     			return this.m_E_YongHuXieYiCloseImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextYinSiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextYinSiText == null )
     			{
		    		this.m_E_TextYinSiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_YongHuXieYi/Scroll View/Viewport/ChatContent/E_TextYinSi");
     			}
     			return this.m_E_TextYinSiText;
     		}
     	}

		public UnityEngine.RectTransform EG_UIAgeTipRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIAgeTipRectTransform == null )
     			{
		    		this.m_EG_UIAgeTipRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_UIAgeTip");
     			}
     			return this.m_EG_UIAgeTipRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_AgeTipCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AgeTipCloseButton == null )
     			{
		    		this.m_E_AgeTipCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_UIAgeTip/E_AgeTipClose");
     			}
     			return this.m_E_AgeTipCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_AgeTipCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AgeTipCloseImage == null )
     			{
		    		this.m_E_AgeTipCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_UIAgeTip/E_AgeTipClose");
     			}
     			return this.m_E_AgeTipCloseImage;
     		}
     	}

		public UnityEngine.UI.Button E_AgeTipClose_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AgeTipClose_2Button == null )
     			{
		    		this.m_E_AgeTipClose_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_UIAgeTip/E_AgeTipClose_2");
     			}
     			return this.m_E_AgeTipClose_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_AgeTipClose_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AgeTipClose_2Image == null )
     			{
		    		this.m_E_AgeTipClose_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_UIAgeTip/E_AgeTipClose_2");
     			}
     			return this.m_E_AgeTipClose_2Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextButton_1Button = null;
			this.m_E_TextButton_1Text = null;
			this.m_E_TextButton_2Button = null;
			this.m_E_TextButton_2Text = null;
			this.m_E_LoginButton = null;
			this.m_E_LoginImage = null;
			this.m_E_SelectServerNameText = null;
			this.m_E_SelectBtnButton = null;
			this.m_E_SelectBtnImage = null;
			this.m_E_buttonAgeTipButton = null;
			this.m_E_buttonAgeTipImage = null;
			this.m_E_AccountInputField = null;
			this.m_E_AccountImage = null;
			this.m_E_PasswordInputField = null;
			this.m_E_PasswordImage = null;
			this.m_EG_LoadingRectTransform = null;
			this.m_EG_YinSiXieYiRectTransform = null;
			this.m_E_YinSiXieYiCloseButton = null;
			this.m_E_YinSiXieYiCloseImage = null;
			this.m_EG_YongHuXieYiRectTransform = null;
			this.m_E_YongHuXieYiCloseButton = null;
			this.m_E_YongHuXieYiCloseImage = null;
			this.m_E_TextYinSiText = null;
			this.m_EG_UIAgeTipRectTransform = null;
			this.m_E_AgeTipCloseButton = null;
			this.m_E_AgeTipCloseImage = null;
			this.m_E_AgeTipClose_2Button = null;
			this.m_E_AgeTipClose_2Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_TextButton_1Button = null;
		private UnityEngine.UI.Text m_E_TextButton_1Text = null;
		private UnityEngine.UI.Button m_E_TextButton_2Button = null;
		private UnityEngine.UI.Text m_E_TextButton_2Text = null;
		private UnityEngine.UI.Button m_E_LoginButton = null;
		private UnityEngine.UI.Image m_E_LoginImage = null;
		private UnityEngine.UI.Text m_E_SelectServerNameText = null;
		private UnityEngine.UI.Button m_E_SelectBtnButton = null;
		private UnityEngine.UI.Image m_E_SelectBtnImage = null;
		private UnityEngine.UI.Button m_E_buttonAgeTipButton = null;
		private UnityEngine.UI.Image m_E_buttonAgeTipImage = null;
		private UnityEngine.UI.InputField m_E_AccountInputField = null;
		private UnityEngine.UI.Image m_E_AccountImage = null;
		private UnityEngine.UI.InputField m_E_PasswordInputField = null;
		private UnityEngine.UI.Image m_E_PasswordImage = null;
		private UnityEngine.RectTransform m_EG_LoadingRectTransform = null;
		private UnityEngine.RectTransform m_EG_YinSiXieYiRectTransform = null;
		private UnityEngine.UI.Button m_E_YinSiXieYiCloseButton = null;
		private UnityEngine.UI.Image m_E_YinSiXieYiCloseImage = null;
		private UnityEngine.RectTransform m_EG_YongHuXieYiRectTransform = null;
		private UnityEngine.UI.Button m_E_YongHuXieYiCloseButton = null;
		private UnityEngine.UI.Image m_E_YongHuXieYiCloseImage = null;
		private UnityEngine.UI.Text m_E_TextYinSiText = null;
		private UnityEngine.RectTransform m_EG_UIAgeTipRectTransform = null;
		private UnityEngine.UI.Button m_E_AgeTipCloseButton = null;
		private UnityEngine.UI.Image m_E_AgeTipCloseImage = null;
		private UnityEngine.UI.Button m_E_AgeTipClose_2Button = null;
		private UnityEngine.UI.Image m_E_AgeTipClose_2Image = null;
		public Transform uiTransform = null;
	}
}
