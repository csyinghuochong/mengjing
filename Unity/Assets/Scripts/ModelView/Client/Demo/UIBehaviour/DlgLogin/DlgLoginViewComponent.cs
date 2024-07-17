using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgLogin))]
	[EnableMethod]
	public  class DlgLoginViewComponent : Entity,IAwake,IDestroy 
	{


		public Button ELoginButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoginButton == null )
     			{
		    		this.m_ELoginButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Sprite_BackGround/ELogin");
     			}
     			return this.m_ELoginButton;
     		}
     	}

		public Image ELoginImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoginImage == null )
     			{
		    		this.m_ELoginImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Sprite_BackGround/ELogin");
     			}
     			return this.m_ELoginImage;
     		}
     	}

		public InputField EAccountInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EAccountInputField == null )
     			{
		    		this.m_EAccountInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Sprite_BackGround/EAccount");
     			}
     			return this.m_EAccountInputField;
     		}
     	}

		public Image EAccountImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EAccountImage == null )
     			{
		    		this.m_EAccountImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Sprite_BackGround/EAccount");
     			}
     			return this.m_EAccountImage;
     		}
     	}

		public InputField EPasswordInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPasswordInputField == null )
     			{
		    		this.m_EPasswordInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Sprite_BackGround/EPassword");
     			}
     			return this.m_EPasswordInputField;
     		}
     	}

		public Image EPasswordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPasswordImage == null )
     			{
		    		this.m_EPasswordImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Sprite_BackGround/EPassword");
     			}
     			return this.m_EPasswordImage;
     		}
     	}

		public LoopHorizontalScrollRect ELoopTestLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopTestLoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopTestLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<LoopHorizontalScrollRect>(this.uiTransform.gameObject,"ELoopTest");
     			}
     			return this.m_ELoopTestLoopHorizontalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELoginButton = null;
			this.m_ELoginImage = null;
			this.m_EAccountInputField = null;
			this.m_EAccountImage = null;
			this.m_EPasswordInputField = null;
			this.m_EPasswordImage = null;
			this.m_ELoopTestLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}
		
		private Button m_ELoginButton = null;
		private Image m_ELoginImage = null;
		private InputField m_EAccountInputField = null;
		private Image m_EAccountImage = null;
		private InputField m_EPasswordInputField = null;
		private Image m_EPasswordImage = null;
		private LoopHorizontalScrollRect m_ELoopTestLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
