using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgLSLobby))]
	[EnableMethod]
	public  class DlgLSLobbyViewComponent : Entity,IAwake,IDestroy 
	{
		public Button EMatchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMatchButton == null )
     			{
		    		this.m_EMatchButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Panel/EMatch");
     			}
     			return this.m_EMatchButton;
     		}
     	}

		public Image EMatchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMatchImage == null )
     			{
		    		this.m_EMatchImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/EMatch");
     			}
     			return this.m_EMatchImage;
     		}
     	}

		public InputField EReplayPathInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EReplayPathInputField == null )
     			{
		    		this.m_EReplayPathInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Panel/GameObject/EReplayPath");
     			}
     			return this.m_EReplayPathInputField;
     		}
     	}

		public Image EReplayPathImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EReplayPathImage == null )
     			{
		    		this.m_EReplayPathImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/GameObject/EReplayPath");
     			}
     			return this.m_EReplayPathImage;
     		}
     	}

		public Button EReplayButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EReplayButton == null )
     			{
		    		this.m_EReplayButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Panel/GameObject/EReplay");
     			}
     			return this.m_EReplayButton;
     		}
     	}

		public Image EReplayImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EReplayImage == null )
     			{
		    		this.m_EReplayImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Panel/GameObject/EReplay");
     			}
     			return this.m_EReplayImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EMatchButton = null;
			this.m_EMatchImage = null;
			this.m_EReplayPathInputField = null;
			this.m_EReplayPathImage = null;
			this.m_EReplayButton = null;
			this.m_EReplayImage = null;
			this.uiTransform = null;
		}

		private Button m_EMatchButton = null;
		private Image m_EMatchImage = null;
		private InputField m_EReplayPathInputField = null;
		private Image m_EReplayPathImage = null;
		private Button m_EReplayButton = null;
		private Image m_EReplayImage = null;
		public Transform uiTransform = null;
	}
}
