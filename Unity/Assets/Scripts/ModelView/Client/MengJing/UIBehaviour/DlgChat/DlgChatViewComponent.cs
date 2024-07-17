using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgChat))]
	[EnableMethod]
	public  class DlgChatViewComponent : Entity,IAwake,IDestroy 
	{
		public ToggleGroup E_FunctionSetBtnToggleGroup
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public Button E_CloseButton
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
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Rigt/E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public Image E_CloseImage
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
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Rigt/E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public LoopVerticalScrollRect E_ChatItemsLoopVerticalScrollRect
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
		    		this.m_E_ChatItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Rigt/E_ChatItems");
     			}
     			return this.m_E_ChatItemsLoopVerticalScrollRect;
     		}
     	}

		public InputField E_ChatInputField
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
		    		this.m_E_ChatInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"Rigt/ChatSendNode/E_Chat");
     			}
     			return this.m_E_ChatInputField;
     		}
     	}

		public Image E_ChatImage
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
		    		this.m_E_ChatImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Rigt/ChatSendNode/E_Chat");
     			}
     			return this.m_E_ChatImage;
     		}
     	}

		public Button E_SendButton
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
		    		this.m_E_SendButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Rigt/ChatSendNode/E_Send");
     			}
     			return this.m_E_SendButton;
     		}
     	}

		public Image E_SendImage
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
		    		this.m_E_SendImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Rigt/ChatSendNode/E_Send");
     			}
     			return this.m_E_SendImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_E_ChatItemsLoopVerticalScrollRect = null;
			this.m_E_ChatInputField = null;
			this.m_E_ChatImage = null;
			this.m_E_SendButton = null;
			this.m_E_SendImage = null;
			this.uiTransform = null;
		}

		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private Button m_E_CloseButton = null;
		private Image m_E_CloseImage = null;
		private LoopVerticalScrollRect m_E_ChatItemsLoopVerticalScrollRect = null;
		private InputField m_E_ChatInputField = null;
		private Image m_E_ChatImage = null;
		private Button m_E_SendButton = null;
		private Image m_E_SendImage = null;
		public Transform uiTransform = null;
	}
}
