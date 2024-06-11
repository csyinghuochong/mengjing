
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgGM))]
	[EnableMethod]
	public  class DlgGMViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Button_CloseButton
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
		    		this.m_E_Button_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Close");
     			}
     			return this.m_E_Button_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_CloseImage
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
		    		this.m_E_Button_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Close");
     			}
     			return this.m_E_Button_CloseImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_EmailButton
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
		    		this.m_E_Button_EmailButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Email");
     			}
     			return this.m_E_Button_EmailButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_EmailImage
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
		    		this.m_E_Button_EmailImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Email");
     			}
     			return this.m_E_Button_EmailImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputField_EmailItemInputField
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
		    		this.m_E_InputField_EmailItemInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"E_InputField_EmailItem");
     			}
     			return this.m_E_InputField_EmailItemInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputField_EmailItemImage
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
		    		this.m_E_InputField_EmailItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_InputField_EmailItem");
     			}
     			return this.m_E_InputField_EmailItemImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Broadcast_1Button
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
		    		this.m_E_Button_Broadcast_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Broadcast_1");
     			}
     			return this.m_E_Button_Broadcast_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Broadcast_1Image
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
		    		this.m_E_Button_Broadcast_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Broadcast_1");
     			}
     			return this.m_E_Button_Broadcast_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Broadcast_2Button
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
		    		this.m_E_Button_Broadcast_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Broadcast_2");
     			}
     			return this.m_E_Button_Broadcast_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Broadcast_2Image
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
		    		this.m_E_Button_Broadcast_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Broadcast_2");
     			}
     			return this.m_E_Button_Broadcast_2Image;
     		}
     	}

		public UnityEngine.UI.InputField E_InputField_BroadcastInputField
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
		    		this.m_E_InputField_BroadcastInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"E_InputField_Broadcast");
     			}
     			return this.m_E_InputField_BroadcastInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputField_BroadcastImage
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
		    		this.m_E_InputField_BroadcastImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_InputField_Broadcast");
     			}
     			return this.m_E_InputField_BroadcastImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ReLoadButton
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
		    		this.m_E_Button_ReLoadButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_ReLoad");
     			}
     			return this.m_E_Button_ReLoadButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ReLoadImage
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
		    		this.m_E_Button_ReLoadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_ReLoad");
     			}
     			return this.m_E_Button_ReLoadImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputField_ReLoadValueInputField
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
		    		this.m_E_InputField_ReLoadValueInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"E_InputField_ReLoadValue");
     			}
     			return this.m_E_InputField_ReLoadValueInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputField_ReLoadValueImage
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
		    		this.m_E_InputField_ReLoadValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_InputField_ReLoadValue");
     			}
     			return this.m_E_InputField_ReLoadValueImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_CommonButton
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
		    		this.m_E_Button_CommonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Common");
     			}
     			return this.m_E_Button_CommonButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_CommonImage
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
		    		this.m_E_Button_CommonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Common");
     			}
     			return this.m_E_Button_CommonImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputField_CommonInputField
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
		    		this.m_E_InputField_CommonInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"E_InputField_Common");
     			}
     			return this.m_E_InputField_CommonInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputField_CommonImage
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
		    		this.m_E_InputField_CommonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_InputField_Common");
     			}
     			return this.m_E_InputField_CommonImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_OnLineNumberText
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
		    		this.m_E_Text_OnLineNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_OnLineNumber");
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

		private UnityEngine.UI.Button m_E_Button_CloseButton = null;
		private UnityEngine.UI.Image m_E_Button_CloseImage = null;
		private UnityEngine.UI.Button m_E_Button_EmailButton = null;
		private UnityEngine.UI.Image m_E_Button_EmailImage = null;
		private UnityEngine.UI.InputField m_E_InputField_EmailItemInputField = null;
		private UnityEngine.UI.Image m_E_InputField_EmailItemImage = null;
		private UnityEngine.UI.Button m_E_Button_Broadcast_1Button = null;
		private UnityEngine.UI.Image m_E_Button_Broadcast_1Image = null;
		private UnityEngine.UI.Button m_E_Button_Broadcast_2Button = null;
		private UnityEngine.UI.Image m_E_Button_Broadcast_2Image = null;
		private UnityEngine.UI.InputField m_E_InputField_BroadcastInputField = null;
		private UnityEngine.UI.Image m_E_InputField_BroadcastImage = null;
		private UnityEngine.UI.Button m_E_Button_ReLoadButton = null;
		private UnityEngine.UI.Image m_E_Button_ReLoadImage = null;
		private UnityEngine.UI.InputField m_E_InputField_ReLoadValueInputField = null;
		private UnityEngine.UI.Image m_E_InputField_ReLoadValueImage = null;
		private UnityEngine.UI.Button m_E_Button_CommonButton = null;
		private UnityEngine.UI.Image m_E_Button_CommonImage = null;
		private UnityEngine.UI.InputField m_E_InputField_CommonInputField = null;
		private UnityEngine.UI.Image m_E_InputField_CommonImage = null;
		private UnityEngine.UI.Text m_E_Text_OnLineNumberText = null;
		public Transform uiTransform = null;
	}
}
