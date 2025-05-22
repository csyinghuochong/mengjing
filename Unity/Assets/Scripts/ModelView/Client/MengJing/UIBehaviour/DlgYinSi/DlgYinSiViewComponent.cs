
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgYinSi))]
	[EnableMethod]
	public  class DlgYinSiViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Button E_ButtonAgreeButton
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
		    		this.m_E_ButtonAgreeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ButtonAgree");
     			}
     			return this.m_E_ButtonAgreeButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonAgreeImage
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
		    		this.m_E_ButtonAgreeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ButtonAgree");
     			}
     			return this.m_E_ButtonAgreeImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonRefuseButton
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
		    		this.m_E_ButtonRefuseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ButtonRefuse");
     			}
     			return this.m_E_ButtonRefuseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonRefuseImage
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
		    		this.m_E_ButtonRefuseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ButtonRefuse");
     			}
     			return this.m_E_ButtonRefuseImage;
     		}
     	}

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
		    		this.m_E_TextButton_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_TextButton_1");
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
		    		this.m_E_TextButton_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_TextButton_1");
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
		    		this.m_E_TextButton_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_TextButton_2");
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
		    		this.m_E_TextButton_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_TextButton_2");
     			}
     			return this.m_E_TextButton_2Text;
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

		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		private UnityEngine.UI.Button m_E_ButtonAgreeButton = null;
		private UnityEngine.UI.Image m_E_ButtonAgreeImage = null;
		private UnityEngine.UI.Button m_E_ButtonRefuseButton = null;
		private UnityEngine.UI.Image m_E_ButtonRefuseImage = null;
		private UnityEngine.UI.Button m_E_TextButton_1Button = null;
		private UnityEngine.UI.Text m_E_TextButton_1Text = null;
		private UnityEngine.UI.Button m_E_TextButton_2Button = null;
		private UnityEngine.UI.Text m_E_TextButton_2Text = null;
		private UnityEngine.RectTransform m_EG_YinSiXieYiRectTransform = null;
		private UnityEngine.UI.Button m_E_YinSiXieYiCloseButton = null;
		private UnityEngine.UI.Image m_E_YinSiXieYiCloseImage = null;
		private UnityEngine.RectTransform m_EG_YongHuXieYiRectTransform = null;
		private UnityEngine.UI.Button m_E_YongHuXieYiCloseButton = null;
		private UnityEngine.UI.Image m_E_YongHuXieYiCloseImage = null;
		private UnityEngine.UI.Text m_E_TextYinSiText = null;
		public Transform uiTransform = null;
	}
}
