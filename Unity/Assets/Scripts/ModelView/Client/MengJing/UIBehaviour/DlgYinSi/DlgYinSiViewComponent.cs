using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgYinSi))]
	[EnableMethod]
	public  class DlgYinSiViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ButtonCloseButton
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
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public Image E_ButtonCloseImage
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
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public Button E_ButtonAgreeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonAgreeButton == null )
     			{
		    		this.m_E_ButtonAgreeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonAgree");
     			}
     			return this.m_E_ButtonAgreeButton;
     		}
     	}

		public Image E_ButtonAgreeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonAgreeImage == null )
     			{
		    		this.m_E_ButtonAgreeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonAgree");
     			}
     			return this.m_E_ButtonAgreeImage;
     		}
     	}

		public Button E_ButtonRefuseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRefuseButton == null )
     			{
		    		this.m_E_ButtonRefuseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonRefuse");
     			}
     			return this.m_E_ButtonRefuseButton;
     		}
     	}

		public Image E_ButtonRefuseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRefuseImage == null )
     			{
		    		this.m_E_ButtonRefuseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonRefuse");
     			}
     			return this.m_E_ButtonRefuseImage;
     		}
     	}

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
		    		this.m_E_TextButton_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_TextButton_1");
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
		    		this.m_E_TextButton_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextButton_1");
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
		    		this.m_E_TextButton_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_TextButton_2");
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
		    		this.m_E_TextButton_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextButton_2");
     			}
     			return this.m_E_TextButton_2Text;
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
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_E_ButtonAgreeButton = null;
			this.m_E_ButtonAgreeImage = null;
			this.m_E_ButtonRefuseButton = null;
			this.m_E_ButtonRefuseImage = null;
			this.m_E_TextButton_1Button = null;
			this.m_E_TextButton_1Text = null;
			this.m_E_TextButton_2Button = null;
			this.m_E_TextButton_2Text = null;
			this.m_EG_YinSiXieYiRectTransform = null;
			this.m_E_YinSiXieYiCloseButton = null;
			this.m_E_YinSiXieYiCloseImage = null;
			this.m_EG_YongHuXieYiRectTransform = null;
			this.m_E_YongHuXieYiCloseButton = null;
			this.m_E_YongHuXieYiCloseImage = null;
			this.m_E_TextYinSiText = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		private Button m_E_ButtonAgreeButton = null;
		private Image m_E_ButtonAgreeImage = null;
		private Button m_E_ButtonRefuseButton = null;
		private Image m_E_ButtonRefuseImage = null;
		private Button m_E_TextButton_1Button = null;
		private Text m_E_TextButton_1Text = null;
		private Button m_E_TextButton_2Button = null;
		private Text m_E_TextButton_2Text = null;
		private RectTransform m_EG_YinSiXieYiRectTransform = null;
		private Button m_E_YinSiXieYiCloseButton = null;
		private Image m_E_YinSiXieYiCloseImage = null;
		private RectTransform m_EG_YongHuXieYiRectTransform = null;
		private Button m_E_YongHuXieYiCloseButton = null;
		private Image m_E_YongHuXieYiCloseImage = null;
		private Text m_E_TextYinSiText = null;
		public Transform uiTransform = null;
	}
}
