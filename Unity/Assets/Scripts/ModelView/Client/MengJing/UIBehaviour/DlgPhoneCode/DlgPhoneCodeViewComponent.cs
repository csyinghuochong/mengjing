using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPhoneCode))]
	[EnableMethod]
	public  class DlgPhoneCodeViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCloseButton == null )
     			{
		    		this.m_E_ImageCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseButton;
     		}
     	}

		public Image E_ImageCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCloseImage == null )
     			{
		    		this.m_E_ImageCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseImage;
     		}
     	}

		public RectTransform EG_SendYanzhengRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SendYanzhengRectTransform == null )
     			{
		    		this.m_EG_SendYanzhengRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SendYanzheng");
     			}
     			return this.m_EG_SendYanzhengRectTransform;
     		}
     	}

		public InputField E_PhoneNumberInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PhoneNumberInputField == null )
     			{
		    		this.m_E_PhoneNumberInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"EG_SendYanzheng/E_PhoneNumber");
     			}
     			return this.m_E_PhoneNumberInputField;
     		}
     	}

		public Image E_PhoneNumberImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PhoneNumberImage == null )
     			{
		    		this.m_E_PhoneNumberImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_SendYanzheng/E_PhoneNumber");
     			}
     			return this.m_E_PhoneNumberImage;
     		}
     	}

		public Button E_ButtonGetCodeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetCodeButton == null )
     			{
		    		this.m_E_ButtonGetCodeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_SendYanzheng/E_ButtonGetCode");
     			}
     			return this.m_E_ButtonGetCodeButton;
     		}
     	}

		public Image E_ButtonGetCodeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetCodeImage == null )
     			{
		    		this.m_E_ButtonGetCodeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_SendYanzheng/E_ButtonGetCode");
     			}
     			return this.m_E_ButtonGetCodeImage;
     		}
     	}

		public RectTransform EG_YanZhengRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_YanZhengRectTransform == null )
     			{
		    		this.m_EG_YanZhengRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_YanZheng");
     			}
     			return this.m_EG_YanZhengRectTransform;
     		}
     	}

		public Text E_TextYanzhengText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextYanzhengText == null )
     			{
		    		this.m_E_TextYanzhengText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_YanZheng/E_TextYanzheng");
     			}
     			return this.m_E_TextYanzhengText;
     		}
     	}

		public InputField E_TextPhoneCodeInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextPhoneCodeInputField == null )
     			{
		    		this.m_E_TextPhoneCodeInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"EG_YanZheng/E_TextPhoneCode");
     			}
     			return this.m_E_TextPhoneCodeInputField;
     		}
     	}

		public Image E_TextPhoneCodeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextPhoneCodeImage == null )
     			{
		    		this.m_E_TextPhoneCodeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_YanZheng/E_TextPhoneCode");
     			}
     			return this.m_E_TextPhoneCodeImage;
     		}
     	}

		public Button E_ButtonCommitCodeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCommitCodeButton == null )
     			{
		    		this.m_E_ButtonCommitCodeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_YanZheng/E_ButtonCommitCode");
     			}
     			return this.m_E_ButtonCommitCodeButton;
     		}
     	}

		public Image E_ButtonCommitCodeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCommitCodeImage == null )
     			{
		    		this.m_E_ButtonCommitCodeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_YanZheng/E_ButtonCommitCode");
     			}
     			return this.m_E_ButtonCommitCodeImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageCloseButton = null;
			this.m_E_ImageCloseImage = null;
			this.m_EG_SendYanzhengRectTransform = null;
			this.m_E_PhoneNumberInputField = null;
			this.m_E_PhoneNumberImage = null;
			this.m_E_ButtonGetCodeButton = null;
			this.m_E_ButtonGetCodeImage = null;
			this.m_EG_YanZhengRectTransform = null;
			this.m_E_TextYanzhengText = null;
			this.m_E_TextPhoneCodeInputField = null;
			this.m_E_TextPhoneCodeImage = null;
			this.m_E_ButtonCommitCodeButton = null;
			this.m_E_ButtonCommitCodeImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageCloseButton = null;
		private Image m_E_ImageCloseImage = null;
		private RectTransform m_EG_SendYanzhengRectTransform = null;
		private InputField m_E_PhoneNumberInputField = null;
		private Image m_E_PhoneNumberImage = null;
		private Button m_E_ButtonGetCodeButton = null;
		private Image m_E_ButtonGetCodeImage = null;
		private RectTransform m_EG_YanZhengRectTransform = null;
		private Text m_E_TextYanzhengText = null;
		private InputField m_E_TextPhoneCodeInputField = null;
		private Image m_E_TextPhoneCodeImage = null;
		private Button m_E_ButtonCommitCodeButton = null;
		private Image m_E_ButtonCommitCodeImage = null;
		public Transform uiTransform = null;
	}
}
