using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgHappyMain))]
	[EnableMethod]
	public  class DlgHappyMainViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ButtonMove_2Button
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
		    		this.m_E_ButtonMove_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonMove_2");
     			}
     			return this.m_E_ButtonMove_2Button;
     		}
     	}

		public Image E_ButtonMove_2Image
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
		    		this.m_E_ButtonMove_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonMove_2");
     			}
     			return this.m_E_ButtonMove_2Image;
     		}
     	}

		public Text E_TextTip_1Text
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
		    		this.m_E_TextTip_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_TextTip_1");
     			}
     			return this.m_E_TextTip_1Text;
     		}
     	}

		public Text E_TextTip_2Text
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
		    		this.m_E_TextTip_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_TextTip_2");
     			}
     			return this.m_E_TextTip_2Text;
     		}
     	}

		public Text E_TextTip_3Text
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
		    		this.m_E_TextTip_3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_TextTip_3");
     			}
     			return this.m_E_TextTip_3Text;
     		}
     	}

		public Button E_ButtonMove_1Button
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
		    		this.m_E_ButtonMove_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonMove_1");
     			}
     			return this.m_E_ButtonMove_1Button;
     		}
     	}

		public Image E_ButtonMove_1Image
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
		    		this.m_E_ButtonMove_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonMove_1");
     			}
     			return this.m_E_ButtonMove_1Image;
     		}
     	}

		public Button E_ButtonMove_3Button
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
		    		this.m_E_ButtonMove_3Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonMove_3");
     			}
     			return this.m_E_ButtonMove_3Button;
     		}
     	}

		public Image E_ButtonMove_3Image
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
		    		this.m_E_ButtonMove_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonMove_3");
     			}
     			return this.m_E_ButtonMove_3Image;
     		}
     	}

		public Text E_TextCoundownText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextCoundownText == null )
     			{
		    		this.m_E_TextCoundownText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Top/E_TextCoundown");
     			}
     			return this.m_E_TextCoundownText;
     		}
     	}

		public Text E_EndTimeTextText
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
		    		this.m_E_EndTimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Top/E_EndTimeText");
     			}
     			return this.m_E_EndTimeTextText;
     		}
     	}

		public Button E_ButtonPickButton
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
		    		this.m_E_ButtonPickButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_ButtonPick");
     			}
     			return this.m_E_ButtonPickButton;
     		}
     	}

		public Image E_ButtonPickImage
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
		    		this.m_E_ButtonPickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ButtonPick");
     			}
     			return this.m_E_ButtonPickImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonMove_2Button = null;
			this.m_E_ButtonMove_2Image = null;
			this.m_E_TextTip_1Text = null;
			this.m_E_TextTip_2Text = null;
			this.m_E_TextTip_3Text = null;
			this.m_E_ButtonMove_1Button = null;
			this.m_E_ButtonMove_1Image = null;
			this.m_E_ButtonMove_3Button = null;
			this.m_E_ButtonMove_3Image = null;
			this.m_E_TextCoundownText = null;
			this.m_E_EndTimeTextText = null;
			this.m_E_ButtonPickButton = null;
			this.m_E_ButtonPickImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonMove_2Button = null;
		private Image m_E_ButtonMove_2Image = null;
		private Text m_E_TextTip_1Text = null;
		private Text m_E_TextTip_2Text = null;
		private Text m_E_TextTip_3Text = null;
		private Button m_E_ButtonMove_1Button = null;
		private Image m_E_ButtonMove_1Image = null;
		private Button m_E_ButtonMove_3Button = null;
		private Image m_E_ButtonMove_3Image = null;
		private Text m_E_TextCoundownText = null;
		private Text m_E_EndTimeTextText = null;
		private Button m_E_ButtonPickButton = null;
		private Image m_E_ButtonPickImage = null;
		public Transform uiTransform = null;
	}
}
