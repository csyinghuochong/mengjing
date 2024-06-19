
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgChat))]
	[EnableMethod]
	public  class DlgChatViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Rigt/E_Close");
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
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Rigt/E_Close");
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
		    		this.m_E_ChatItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Rigt/E_ChatItems");
     			}
     			return this.m_E_ChatItemsLoopVerticalScrollRect;
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
		    		this.m_E_ChatInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Rigt/ChatSendNode/E_Chat");
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
		    		this.m_E_ChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Rigt/ChatSendNode/E_Chat");
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
		    		this.m_E_SendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Rigt/ChatSendNode/E_Send");
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
		    		this.m_E_SendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Rigt/ChatSendNode/E_Send");
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

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ChatItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.InputField m_E_ChatInputField = null;
		private UnityEngine.UI.Image m_E_ChatImage = null;
		private UnityEngine.UI.Button m_E_SendButton = null;
		private UnityEngine.UI.Image m_E_SendImage = null;
		public Transform uiTransform = null;
	}
}
