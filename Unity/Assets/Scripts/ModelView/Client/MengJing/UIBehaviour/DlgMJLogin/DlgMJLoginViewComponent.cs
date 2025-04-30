using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgMJLogin))]
	[EnableMethod]
	public  class DlgMJLoginViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_TextButton_1Button
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
		    		this.m_E_TextButton_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"HideNode/YinSiButon/E_TextButton_1");
     			}
     			return this.m_E_TextButton_1Button;
     		}
     	}

		public Text E_TextButton_1Text
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
		    		this.m_E_TextButton_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"HideNode/YinSiButon/E_TextButton_1");
     			}
     			return this.m_E_TextButton_1Text;
     		}
     	}

		public Button E_TextButton_2Button
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
		    		this.m_E_TextButton_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"HideNode/YinSiButon/E_TextButton_2");
     			}
     			return this.m_E_TextButton_2Button;
     		}
     	}

		public Text E_TextButton_2Text
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
		    		this.m_E_TextButton_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"HideNode/YinSiButon/E_TextButton_2");
     			}
     			return this.m_E_TextButton_2Text;
     		}
     	}

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

		public RectTransform EG_LoadingRectTransform
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
		    		this.m_EG_LoadingRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Loading");
     			}
     			return this.m_EG_LoadingRectTransform;
     		}
     	}

		public RectTransform EG_YinSiXieYiRectTransform
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
		    		this.m_EG_YinSiXieYiRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_YinSiXieYi");
     			}
     			return this.m_EG_YinSiXieYiRectTransform;
     		}
     	}

		public Button E_YinSiXieYiCloseButton
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
		    		this.m_E_YinSiXieYiCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_YinSiXieYi/E_YinSiXieYiClose");
     			}
     			return this.m_E_YinSiXieYiCloseButton;
     		}
     	}

		public Image E_YinSiXieYiCloseImage
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
		    		this.m_E_YinSiXieYiCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_YinSiXieYi/E_YinSiXieYiClose");
     			}
     			return this.m_E_YinSiXieYiCloseImage;
     		}
     	}

		public RectTransform EG_YongHuXieYiRectTransform
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
		    		this.m_EG_YongHuXieYiRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_YongHuXieYi");
     			}
     			return this.m_EG_YongHuXieYiRectTransform;
     		}
     	}

		public Button E_YongHuXieYiCloseButton
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
		    		this.m_E_YongHuXieYiCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_YongHuXieYi/E_YongHuXieYiClose");
     			}
     			return this.m_E_YongHuXieYiCloseButton;
     		}
     	}

		public Image E_YongHuXieYiCloseImage
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
		    		this.m_E_YongHuXieYiCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_YongHuXieYi/E_YongHuXieYiClose");
     			}
     			return this.m_E_YongHuXieYiCloseImage;
     		}
        }

        public Button E_buttonAgeTip
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_E_buttonAgeTip == null)
                {
                    this.m_E_buttonAgeTip = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "E_buttonAgeTip");
                }
                return this.m_E_buttonAgeTip;
            }
        }

        public Transform EG_UIAgeTip
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_EG_UIAgeTip == null)
                {
                    this.m_EG_UIAgeTip = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EG_UIAgeTip");
                }
                return this.m_EG_UIAgeTip;
            }
        }

        public Button E_AgeTipClose
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.m_E_AgeTipClose == null)
                {
                    this.m_E_AgeTipClose = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "EG_UIAgeTip/E_AgeTipClose");
                }
                return this.m_E_AgeTipClose;
            }
        }

        public Text E_TextYinSiText
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
		    		this.m_E_TextYinSiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_YongHuXieYi/Scroll View/Viewport/ChatContent/E_TextYinSi");
     			}
     			return this.m_E_TextYinSiText;
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
            this.m_E_buttonAgeTip = null;
            this.m_EG_UIAgeTip = null;
            this.m_E_AgeTipClose = null;
			this.uiTransform = null;
		}

		private Button m_E_TextButton_1Button = null;
		private Text m_E_TextButton_1Text = null;
		private Button m_E_TextButton_2Button = null;
		private Text m_E_TextButton_2Text = null;
		private Button m_E_LoginButton = null;
		private Image m_E_LoginImage = null;
		private Text m_E_SelectServerNameText = null;
		private Button m_E_SelectBtnButton = null;
		private Image m_E_SelectBtnImage = null;
		private InputField m_E_AccountInputField = null;
		private Image m_E_AccountImage = null;
		private InputField m_E_PasswordInputField = null;
		private Image m_E_PasswordImage = null;
		private RectTransform m_EG_LoadingRectTransform = null;
		private RectTransform m_EG_YinSiXieYiRectTransform = null;
		private Button m_E_YinSiXieYiCloseButton = null;
		private Image m_E_YinSiXieYiCloseImage = null;
		private RectTransform m_EG_YongHuXieYiRectTransform = null;
		private Button m_E_YongHuXieYiCloseButton = null;
		private Image m_E_YongHuXieYiCloseImage = null;
		private Text m_E_TextYinSiText = null;
        private Button m_E_buttonAgeTip = null;
        private Transform m_EG_UIAgeTip = null;
        private Button m_E_AgeTipClose = null;
        public Transform uiTransform = null;
	}
}
