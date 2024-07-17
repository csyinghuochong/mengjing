using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgGM))]
	[EnableMethod]
	public  class DlgGMViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Button_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CloseButton == null )
     			{
		    		this.m_E_Button_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Close");
     			}
     			return this.m_E_Button_CloseButton;
     		}
     	}

		public Image E_Button_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CloseImage == null )
     			{
		    		this.m_E_Button_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Close");
     			}
     			return this.m_E_Button_CloseImage;
     		}
     	}

		public Button E_Button_EmailButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_EmailButton == null )
     			{
		    		this.m_E_Button_EmailButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Email");
     			}
     			return this.m_E_Button_EmailButton;
     		}
     	}

		public Image E_Button_EmailImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_EmailImage == null )
     			{
		    		this.m_E_Button_EmailImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Email");
     			}
     			return this.m_E_Button_EmailImage;
     		}
     	}

		public InputField E_InputField_EmailItemInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_EmailItemInputField == null )
     			{
		    		this.m_E_InputField_EmailItemInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_InputField_EmailItem");
     			}
     			return this.m_E_InputField_EmailItemInputField;
     		}
     	}

		public Image E_InputField_EmailItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_EmailItemImage == null )
     			{
		    		this.m_E_InputField_EmailItemImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InputField_EmailItem");
     			}
     			return this.m_E_InputField_EmailItemImage;
     		}
     	}

		public Button E_Button_Broadcast_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Broadcast_1Button == null )
     			{
		    		this.m_E_Button_Broadcast_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Broadcast_1");
     			}
     			return this.m_E_Button_Broadcast_1Button;
     		}
     	}

		public Image E_Button_Broadcast_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Broadcast_1Image == null )
     			{
		    		this.m_E_Button_Broadcast_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Broadcast_1");
     			}
     			return this.m_E_Button_Broadcast_1Image;
     		}
     	}

		public Button E_Button_Broadcast_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Broadcast_2Button == null )
     			{
		    		this.m_E_Button_Broadcast_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Broadcast_2");
     			}
     			return this.m_E_Button_Broadcast_2Button;
     		}
     	}

		public Image E_Button_Broadcast_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Broadcast_2Image == null )
     			{
		    		this.m_E_Button_Broadcast_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Broadcast_2");
     			}
     			return this.m_E_Button_Broadcast_2Image;
     		}
     	}

		public InputField E_InputField_BroadcastInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_BroadcastInputField == null )
     			{
		    		this.m_E_InputField_BroadcastInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_InputField_Broadcast");
     			}
     			return this.m_E_InputField_BroadcastInputField;
     		}
     	}

		public Image E_InputField_BroadcastImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_BroadcastImage == null )
     			{
		    		this.m_E_InputField_BroadcastImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InputField_Broadcast");
     			}
     			return this.m_E_InputField_BroadcastImage;
     		}
     	}

		public Button E_Button_ReLoadButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ReLoadButton == null )
     			{
		    		this.m_E_Button_ReLoadButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_ReLoad");
     			}
     			return this.m_E_Button_ReLoadButton;
     		}
     	}

		public Image E_Button_ReLoadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ReLoadImage == null )
     			{
		    		this.m_E_Button_ReLoadImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_ReLoad");
     			}
     			return this.m_E_Button_ReLoadImage;
     		}
     	}

		public InputField E_InputField_ReLoadValueInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_ReLoadValueInputField == null )
     			{
		    		this.m_E_InputField_ReLoadValueInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_InputField_ReLoadValue");
     			}
     			return this.m_E_InputField_ReLoadValueInputField;
     		}
     	}

		public Image E_InputField_ReLoadValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_ReLoadValueImage == null )
     			{
		    		this.m_E_InputField_ReLoadValueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InputField_ReLoadValue");
     			}
     			return this.m_E_InputField_ReLoadValueImage;
     		}
     	}

		public Button E_Button_CommonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CommonButton == null )
     			{
		    		this.m_E_Button_CommonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Common");
     			}
     			return this.m_E_Button_CommonButton;
     		}
     	}

		public Image E_Button_CommonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CommonImage == null )
     			{
		    		this.m_E_Button_CommonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Common");
     			}
     			return this.m_E_Button_CommonImage;
     		}
     	}

		public InputField E_InputField_CommonInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_CommonInputField == null )
     			{
		    		this.m_E_InputField_CommonInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_InputField_Common");
     			}
     			return this.m_E_InputField_CommonInputField;
     		}
     	}

		public Image E_InputField_CommonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_CommonImage == null )
     			{
		    		this.m_E_InputField_CommonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InputField_Common");
     			}
     			return this.m_E_InputField_CommonImage;
     		}
     	}

		public Text E_Text_OnLineNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_OnLineNumberText == null )
     			{
		    		this.m_E_Text_OnLineNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_OnLineNumber");
     			}
     			return this.m_E_Text_OnLineNumberText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Button_CloseButton = null;
			this.m_E_Button_CloseImage = null;
			this.m_E_Button_EmailButton = null;
			this.m_E_Button_EmailImage = null;
			this.m_E_InputField_EmailItemInputField = null;
			this.m_E_InputField_EmailItemImage = null;
			this.m_E_Button_Broadcast_1Button = null;
			this.m_E_Button_Broadcast_1Image = null;
			this.m_E_Button_Broadcast_2Button = null;
			this.m_E_Button_Broadcast_2Image = null;
			this.m_E_InputField_BroadcastInputField = null;
			this.m_E_InputField_BroadcastImage = null;
			this.m_E_Button_ReLoadButton = null;
			this.m_E_Button_ReLoadImage = null;
			this.m_E_InputField_ReLoadValueInputField = null;
			this.m_E_InputField_ReLoadValueImage = null;
			this.m_E_Button_CommonButton = null;
			this.m_E_Button_CommonImage = null;
			this.m_E_InputField_CommonInputField = null;
			this.m_E_InputField_CommonImage = null;
			this.m_E_Text_OnLineNumberText = null;
			this.uiTransform = null;
		}

		private Button m_E_Button_CloseButton = null;
		private Image m_E_Button_CloseImage = null;
		private Button m_E_Button_EmailButton = null;
		private Image m_E_Button_EmailImage = null;
		private InputField m_E_InputField_EmailItemInputField = null;
		private Image m_E_InputField_EmailItemImage = null;
		private Button m_E_Button_Broadcast_1Button = null;
		private Image m_E_Button_Broadcast_1Image = null;
		private Button m_E_Button_Broadcast_2Button = null;
		private Image m_E_Button_Broadcast_2Image = null;
		private InputField m_E_InputField_BroadcastInputField = null;
		private Image m_E_InputField_BroadcastImage = null;
		private Button m_E_Button_ReLoadButton = null;
		private Image m_E_Button_ReLoadImage = null;
		private InputField m_E_InputField_ReLoadValueInputField = null;
		private Image m_E_InputField_ReLoadValueImage = null;
		private Button m_E_Button_CommonButton = null;
		private Image m_E_Button_CommonImage = null;
		private InputField m_E_InputField_CommonInputField = null;
		private Image m_E_InputField_CommonImage = null;
		private Text m_E_Text_OnLineNumberText = null;
		public Transform uiTransform = null;
	}
}
