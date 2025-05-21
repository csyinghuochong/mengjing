
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPhoneCode))]
	[EnableMethod]
	public  class DlgPhoneCodeViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageCloseButton
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
		    		this.m_E_ImageCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ImageClose");
     			}
     			return this.m_E_ImageCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageCloseImage
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
		    		this.m_E_ImageCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ImageClose");
     			}
     			return this.m_E_ImageCloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SendYanzhengRectTransform
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
		    		this.m_EG_SendYanzhengRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_SendYanzheng");
     			}
     			return this.m_EG_SendYanzhengRectTransform;
     		}
     	}

		public UnityEngine.UI.InputField E_PhoneNumberInputField
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
		    		this.m_E_PhoneNumberInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/EG_SendYanzheng/E_PhoneNumber");
     			}
     			return this.m_E_PhoneNumberInputField;
     		}
     	}

		public UnityEngine.UI.Image E_PhoneNumberImage
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
		    		this.m_E_PhoneNumberImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SendYanzheng/E_PhoneNumber");
     			}
     			return this.m_E_PhoneNumberImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGetCodeButton
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
		    		this.m_E_ButtonGetCodeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SendYanzheng/E_ButtonGetCode");
     			}
     			return this.m_E_ButtonGetCodeButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGetCodeImage
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
		    		this.m_E_ButtonGetCodeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SendYanzheng/E_ButtonGetCode");
     			}
     			return this.m_E_ButtonGetCodeImage;
     		}
     	}

		public UnityEngine.RectTransform EG_YanZhengRectTransform
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
		    		this.m_EG_YanZhengRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_YanZheng");
     			}
     			return this.m_EG_YanZhengRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TextYanzhengText
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
		    		this.m_E_TextYanzhengText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_YanZheng/E_TextYanzheng");
     			}
     			return this.m_E_TextYanzhengText;
     		}
     	}

		public UnityEngine.UI.InputField E_TextPhoneCodeInputField
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
		    		this.m_E_TextPhoneCodeInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/EG_YanZheng/E_TextPhoneCode");
     			}
     			return this.m_E_TextPhoneCodeInputField;
     		}
     	}

		public UnityEngine.UI.Image E_TextPhoneCodeImage
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
		    		this.m_E_TextPhoneCodeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_YanZheng/E_TextPhoneCode");
     			}
     			return this.m_E_TextPhoneCodeImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCommitCodeButton
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
		    		this.m_E_ButtonCommitCodeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_YanZheng/E_ButtonCommitCode");
     			}
     			return this.m_E_ButtonCommitCodeButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCommitCodeImage
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
		    		this.m_E_ButtonCommitCodeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_YanZheng/E_ButtonCommitCode");
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

		private UnityEngine.UI.Button m_E_ImageCloseButton = null;
		private UnityEngine.UI.Image m_E_ImageCloseImage = null;
		private UnityEngine.RectTransform m_EG_SendYanzhengRectTransform = null;
		private UnityEngine.UI.InputField m_E_PhoneNumberInputField = null;
		private UnityEngine.UI.Image m_E_PhoneNumberImage = null;
		private UnityEngine.UI.Button m_E_ButtonGetCodeButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetCodeImage = null;
		private UnityEngine.RectTransform m_EG_YanZhengRectTransform = null;
		private UnityEngine.UI.Text m_E_TextYanzhengText = null;
		private UnityEngine.UI.InputField m_E_TextPhoneCodeInputField = null;
		private UnityEngine.UI.Image m_E_TextPhoneCodeImage = null;
		private UnityEngine.UI.Button m_E_ButtonCommitCodeButton = null;
		private UnityEngine.UI.Image m_E_ButtonCommitCodeImage = null;
		public Transform uiTransform = null;
	}
}
