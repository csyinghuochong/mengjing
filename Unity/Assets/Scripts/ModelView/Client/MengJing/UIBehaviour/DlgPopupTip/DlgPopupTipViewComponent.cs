using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPopupTip))]
	[EnableMethod]
	public  class DlgPopupTipViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_TitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TitleText == null )
     			{
		    		this.m_E_TitleText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Title");
     			}
     			return this.m_E_TitleText;
     		}
     	}

		public Text E_ContentText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ContentText == null )
     			{
		    		this.m_E_ContentText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Content");
     			}
     			return this.m_E_ContentText;
     		}
     	}

		public Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public Button E_TrueButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TrueButton == null )
     			{
		    		this.m_E_TrueButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_True");
     			}
     			return this.m_E_TrueButton;
     		}
     	}

		public Image E_TrueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TrueImage == null )
     			{
		    		this.m_E_TrueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_True");
     			}
     			return this.m_E_TrueImage;
     		}
     	}

		public Button E_FalseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FalseButton == null )
     			{
		    		this.m_E_FalseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_False");
     			}
     			return this.m_E_FalseButton;
     		}
     	}

		public Image E_FalseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FalseImage == null )
     			{
		    		this.m_E_FalseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_False");
     			}
     			return this.m_E_FalseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TitleText = null;
			this.m_E_ContentText = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_E_TrueButton = null;
			this.m_E_TrueImage = null;
			this.m_E_FalseButton = null;
			this.m_E_FalseImage = null;
			this.uiTransform = null;
		}

		private Text m_E_TitleText = null;
		private Text m_E_ContentText = null;
		private Button m_E_CloseButton = null;
		private Image m_E_CloseImage = null;
		private Button m_E_TrueButton = null;
		private Image m_E_TrueImage = null;
		private Button m_E_FalseButton = null;
		private Image m_E_FalseImage = null;
		public Transform uiTransform = null;
	}
}
