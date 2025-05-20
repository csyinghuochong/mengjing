
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDungeonHappyMain))]
	[EnableMethod]
	public  class DlgDungeonHappyMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonMove_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMove_2Button == null )
     			{
		    		this.m_E_ButtonMove_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonMove_2");
     			}
     			return this.m_E_ButtonMove_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonMove_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMove_2Image == null )
     			{
		    		this.m_E_ButtonMove_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonMove_2");
     			}
     			return this.m_E_ButtonMove_2Image;
     		}
     	}

		public UnityEngine.UI.Text E_TextTip_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTip_1Text == null )
     			{
		    		this.m_E_TextTip_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextTip_1");
     			}
     			return this.m_E_TextTip_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_TextTip_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTip_2Text == null )
     			{
		    		this.m_E_TextTip_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextTip_2");
     			}
     			return this.m_E_TextTip_2Text;
     		}
     	}

		public UnityEngine.UI.Text E_TextTip_3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTip_3Text == null )
     			{
		    		this.m_E_TextTip_3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextTip_3");
     			}
     			return this.m_E_TextTip_3Text;
     		}
     	}

		public UnityEngine.UI.Text E_TextTip_MianFeiTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTip_MianFeiTimeText == null )
     			{
		    		this.m_E_TextTip_MianFeiTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextTip_MianFeiTime");
     			}
     			return this.m_E_TextTip_MianFeiTimeText;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonMove_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMove_1Button == null )
     			{
		    		this.m_E_ButtonMove_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonMove_1");
     			}
     			return this.m_E_ButtonMove_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonMove_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMove_1Image == null )
     			{
		    		this.m_E_ButtonMove_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonMove_1");
     			}
     			return this.m_E_ButtonMove_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonMove_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMove_3Button == null )
     			{
		    		this.m_E_ButtonMove_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonMove_3");
     			}
     			return this.m_E_ButtonMove_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonMove_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonMove_3Image == null )
     			{
		    		this.m_E_ButtonMove_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonMove_3");
     			}
     			return this.m_E_ButtonMove_3Image;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonPickButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPickButton == null )
     			{
		    		this.m_E_ButtonPickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonPick");
     			}
     			return this.m_E_ButtonPickButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonPickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonPickImage == null )
     			{
		    		this.m_E_ButtonPickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonPick");
     			}
     			return this.m_E_ButtonPickImage;
     		}
     	}

		public UnityEngine.UI.Text E_EndTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EndTimeTextText == null )
     			{
		    		this.m_E_EndTimeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_EndTimeText");
     			}
     			return this.m_E_EndTimeTextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonMove_2Button = null;
			this.m_E_ButtonMove_2Image = null;
			this.m_E_TextTip_1Text = null;
			this.m_E_TextTip_2Text = null;
			this.m_E_TextTip_3Text = null;
			this.m_E_TextTip_MianFeiTimeText = null;
			this.m_E_ButtonMove_1Button = null;
			this.m_E_ButtonMove_1Image = null;
			this.m_E_ButtonMove_3Button = null;
			this.m_E_ButtonMove_3Image = null;
			this.m_E_ButtonPickButton = null;
			this.m_E_ButtonPickImage = null;
			this.m_E_EndTimeTextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonMove_2Button = null;
		private UnityEngine.UI.Image m_E_ButtonMove_2Image = null;
		private UnityEngine.UI.Text m_E_TextTip_1Text = null;
		private UnityEngine.UI.Text m_E_TextTip_2Text = null;
		private UnityEngine.UI.Text m_E_TextTip_3Text = null;
		private UnityEngine.UI.Text m_E_TextTip_MianFeiTimeText = null;
		private UnityEngine.UI.Button m_E_ButtonMove_1Button = null;
		private UnityEngine.UI.Image m_E_ButtonMove_1Image = null;
		private UnityEngine.UI.Button m_E_ButtonMove_3Button = null;
		private UnityEngine.UI.Image m_E_ButtonMove_3Image = null;
		private UnityEngine.UI.Button m_E_ButtonPickButton = null;
		private UnityEngine.UI.Image m_E_ButtonPickImage = null;
		private UnityEngine.UI.Text m_E_EndTimeTextText = null;
		public Transform uiTransform = null;
	}
}
