using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSettingFrame))]
	[EnableMethod]
	public  class DlgSettingFrameViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageDiCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageDiCloseButton == null )
     			{
		    		this.m_E_ImageDiCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageDiClose");
     			}
     			return this.m_E_ImageDiCloseButton;
     		}
     	}

		public Image E_ImageDiCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageDiCloseImage == null )
     			{
		    		this.m_E_ImageDiCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDiClose");
     			}
     			return this.m_E_ImageDiCloseImage;
     		}
     	}

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

		public Button E_ButtonNormalButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonNormalButton == null )
     			{
		    		this.m_E_ButtonNormalButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonNormal");
     			}
     			return this.m_E_ButtonNormalButton;
     		}
     	}

		public Image E_ButtonNormalImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonNormalImage == null )
     			{
		    		this.m_E_ButtonNormalImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonNormal");
     			}
     			return this.m_E_ButtonNormalImage;
     		}
     	}

		public Button E_ButtonHighButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonHighButton == null )
     			{
		    		this.m_E_ButtonHighButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonHigh");
     			}
     			return this.m_E_ButtonHighButton;
     		}
     	}

		public Image E_ButtonHighImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonHighImage == null )
     			{
		    		this.m_E_ButtonHighImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonHigh");
     			}
     			return this.m_E_ButtonHighImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageDiCloseButton = null;
			this.m_E_ImageDiCloseImage = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_E_ButtonNormalButton = null;
			this.m_E_ButtonNormalImage = null;
			this.m_E_ButtonHighButton = null;
			this.m_E_ButtonHighImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageDiCloseButton = null;
		private Image m_E_ImageDiCloseImage = null;
		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		private Button m_E_ButtonNormalButton = null;
		private Image m_E_ButtonNormalImage = null;
		private Button m_E_ButtonHighButton = null;
		private Image m_E_ButtonHighImage = null;
		public Transform uiTransform = null;
	}
}
