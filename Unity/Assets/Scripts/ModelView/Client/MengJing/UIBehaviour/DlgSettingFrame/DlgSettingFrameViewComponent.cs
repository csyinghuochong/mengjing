
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSettingFrame))]
	[EnableMethod]
	public  class DlgSettingFrameViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageDiCloseButton
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
		    		this.m_E_ImageDiCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageDiClose");
     			}
     			return this.m_E_ImageDiCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageDiCloseImage
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
		    		this.m_E_ImageDiCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageDiClose");
     			}
     			return this.m_E_ImageDiCloseImage;
     		}
     	}

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

		public UnityEngine.UI.Button E_ButtonNormalButton
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
		    		this.m_E_ButtonNormalButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ButtonNormal");
     			}
     			return this.m_E_ButtonNormalButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonNormalImage
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
		    		this.m_E_ButtonNormalImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ButtonNormal");
     			}
     			return this.m_E_ButtonNormalImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonHighButton
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
		    		this.m_E_ButtonHighButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ButtonHigh");
     			}
     			return this.m_E_ButtonHighButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonHighImage
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
		    		this.m_E_ButtonHighImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ButtonHigh");
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

		private UnityEngine.UI.Button m_E_ImageDiCloseButton = null;
		private UnityEngine.UI.Image m_E_ImageDiCloseImage = null;
		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		private UnityEngine.UI.Button m_E_ButtonNormalButton = null;
		private UnityEngine.UI.Image m_E_ButtonNormalImage = null;
		private UnityEngine.UI.Button m_E_ButtonHighButton = null;
		private UnityEngine.UI.Image m_E_ButtonHighImage = null;
		public Transform uiTransform = null;
	}
}
