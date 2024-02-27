
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

		public UnityEngine.UI.Toggle E_WordToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WordToggle == null )
     			{
		    		this.m_E_WordToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Word");
     			}
     			return this.m_E_WordToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_TeamToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TeamToggle == null )
     			{
		    		this.m_E_TeamToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Team");
     			}
     			return this.m_E_TeamToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_UnionToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionToggle == null )
     			{
		    		this.m_E_UnionToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Union");
     			}
     			return this.m_E_UnionToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_SystemToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SystemToggle == null )
     			{
		    		this.m_E_SystemToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_System");
     			}
     			return this.m_E_SystemToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_FriendToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendToggle == null )
     			{
		    		this.m_E_FriendToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Friend");
     			}
     			return this.m_E_FriendToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_PickToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PickToggle == null )
     			{
		    		this.m_E_PickToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Pick");
     			}
     			return this.m_E_PickToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_PaiMaiToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PaiMaiToggle == null )
     			{
		    		this.m_E_PaiMaiToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_PaiMai");
     			}
     			return this.m_E_PaiMaiToggle;
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
			this.m_E_WordToggle = null;
			this.m_E_TeamToggle = null;
			this.m_E_UnionToggle = null;
			this.m_E_SystemToggle = null;
			this.m_E_FriendToggle = null;
			this.m_E_PickToggle = null;
			this.m_E_PaiMaiToggle = null;
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
		private UnityEngine.UI.Toggle m_E_WordToggle = null;
		private UnityEngine.UI.Toggle m_E_TeamToggle = null;
		private UnityEngine.UI.Toggle m_E_UnionToggle = null;
		private UnityEngine.UI.Toggle m_E_SystemToggle = null;
		private UnityEngine.UI.Toggle m_E_FriendToggle = null;
		private UnityEngine.UI.Toggle m_E_PickToggle = null;
		private UnityEngine.UI.Toggle m_E_PaiMaiToggle = null;
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
