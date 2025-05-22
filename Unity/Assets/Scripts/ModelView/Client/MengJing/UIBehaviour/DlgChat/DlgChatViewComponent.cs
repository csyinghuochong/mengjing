
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgChat))]
	[EnableMethod]
	public  class DlgChatViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type_0Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_0Toggle == null )
     			{
		    		this.m_E_Type_0Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_0");
     			}
     			return this.m_E_Type_0Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_1Toggle == null )
     			{
		    		this.m_E_Type_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_1");
     			}
     			return this.m_E_Type_1Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type_2Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_2Toggle == null )
     			{
		    		this.m_E_Type_2Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_2");
     			}
     			return this.m_E_Type_2Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type_3Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_3Toggle == null )
     			{
		    		this.m_E_Type_3Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_3");
     			}
     			return this.m_E_Type_3Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type_6Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_6Toggle == null )
     			{
		    		this.m_E_Type_6Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_6");
     			}
     			return this.m_E_Type_6Toggle;
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
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Close");
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
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ChatItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChatItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_ChatItems");
     			}
     			return this.m_E_ChatItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ChatDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatDiImage == null )
     			{
		    		this.m_E_ChatDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/ChatSendNode/E_ChatDi");
     			}
     			return this.m_E_ChatDiImage;
     		}
     	}

		public UnityEngine.UI.InputField E_ChatInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatInputField == null )
     			{
		    		this.m_E_ChatInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Right/ChatSendNode/E_Chat");
     			}
     			return this.m_E_ChatInputField;
     		}
     	}

		public UnityEngine.UI.Image E_ChatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatImage == null )
     			{
		    		this.m_E_ChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/ChatSendNode/E_Chat");
     			}
     			return this.m_E_ChatImage;
     		}
     	}

		public UnityEngine.UI.Button E_SendButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SendButton == null )
     			{
		    		this.m_E_SendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/ChatSendNode/E_Send");
     			}
     			return this.m_E_SendButton;
     		}
     	}

		public UnityEngine.UI.Image E_SendImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SendImage == null )
     			{
		    		this.m_E_SendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/ChatSendNode/E_Send");
     			}
     			return this.m_E_SendImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Button_CloseButton = null;
			this.m_E_Button_CloseImage = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_0Toggle = null;
			this.m_E_Type_1Toggle = null;
			this.m_E_Type_2Toggle = null;
			this.m_E_Type_3Toggle = null;
			this.m_E_Type_6Toggle = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_E_ChatItemsLoopVerticalScrollRect = null;
			this.m_E_ChatDiImage = null;
			this.m_E_ChatInputField = null;
			this.m_E_ChatImage = null;
			this.m_E_SendButton = null;
			this.m_E_SendImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Button_CloseButton = null;
		private UnityEngine.UI.Image m_E_Button_CloseImage = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_Type_0Toggle = null;
		private UnityEngine.UI.Toggle m_E_Type_1Toggle = null;
		private UnityEngine.UI.Toggle m_E_Type_2Toggle = null;
		private UnityEngine.UI.Toggle m_E_Type_3Toggle = null;
		private UnityEngine.UI.Toggle m_E_Type_6Toggle = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ChatItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_ChatDiImage = null;
		private UnityEngine.UI.InputField m_E_ChatInputField = null;
		private UnityEngine.UI.Image m_E_ChatImage = null;
		private UnityEngine.UI.Button m_E_SendButton = null;
		private UnityEngine.UI.Image m_E_SendImage = null;
		public Transform uiTransform = null;
	}
}
