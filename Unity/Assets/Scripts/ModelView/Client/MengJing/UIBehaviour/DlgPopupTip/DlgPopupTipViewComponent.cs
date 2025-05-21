
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPopupTip))]
	[EnableMethod]
	public  class DlgPopupTipViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_TitleText
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
		    		this.m_E_TitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Title");
     			}
     			return this.m_E_TitleText;
     		}
     	}

		public UnityEngine.UI.Text E_ContentText
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
		    		this.m_E_ContentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Content");
     			}
     			return this.m_E_ContentText;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButton
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
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
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
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.UI.Button E_TrueButton
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
		    		this.m_E_TrueButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_True");
     			}
     			return this.m_E_TrueButton;
     		}
     	}

		public UnityEngine.UI.Image E_TrueImage
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
		    		this.m_E_TrueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_True");
     			}
     			return this.m_E_TrueImage;
     		}
     	}

		public UnityEngine.UI.Button E_FalseButton
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
		    		this.m_E_FalseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_False");
     			}
     			return this.m_E_FalseButton;
     		}
     	}

		public UnityEngine.UI.Image E_FalseImage
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
		    		this.m_E_FalseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_False");
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

		private UnityEngine.UI.Text m_E_TitleText = null;
		private UnityEngine.UI.Text m_E_ContentText = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.UI.Button m_E_TrueButton = null;
		private UnityEngine.UI.Image m_E_TrueImage = null;
		private UnityEngine.UI.Button m_E_FalseButton = null;
		private UnityEngine.UI.Image m_E_FalseImage = null;
		public Transform uiTransform = null;
	}
}
