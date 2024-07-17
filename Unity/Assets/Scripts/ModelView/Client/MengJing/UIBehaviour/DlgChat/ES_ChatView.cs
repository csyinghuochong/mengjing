using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChatView : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public FriendInfo FriendInfo;
		public Dictionary<int, EntityRef<Scroll_Item_FriendChatItem>> ScrollItemFriendChatItems;
		public List<ChatInfo> ShowChatInfos = new();
		
		public Text E_ChatPlayNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatPlayNameText == null )
     			{
		    		this.m_E_ChatPlayNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ImageDi/E_ChatPlayName");
     			}
     			return this.m_E_ChatPlayNameText;
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
		    		this.m_E_SendButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Send");
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
		    		this.m_E_SendImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Send");
     			}
     			return this.m_E_SendImage;
     		}
     	}

		public InputField E_InputInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputInputField == null )
     			{
		    		this.m_E_InputInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_Input");
     			}
     			return this.m_E_InputInputField;
     		}
     	}

		public Image E_InputImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputImage == null )
     			{
		    		this.m_E_InputImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Input");
     			}
     			return this.m_E_InputImage;
     		}
     	}

		public LoopVerticalScrollRect E_FriendChatItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendChatItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_FriendChatItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_FriendChatItems");
     			}
     			return this.m_E_FriendChatItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_CloseChatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseChatButton == null )
     			{
		    		this.m_E_CloseChatButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_CloseChat");
     			}
     			return this.m_E_CloseChatButton;
     		}
     	}

		public Image E_CloseChatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseChatImage == null )
     			{
		    		this.m_E_CloseChatImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CloseChat");
     			}
     			return this.m_E_CloseChatImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ChatPlayNameText = null;
			this.m_E_SendButton = null;
			this.m_E_SendImage = null;
			this.m_E_InputInputField = null;
			this.m_E_InputImage = null;
			this.m_E_FriendChatItemsLoopVerticalScrollRect = null;
			this.m_E_CloseChatButton = null;
			this.m_E_CloseChatImage = null;
			this.uiTransform = null;
		}

		private Text m_E_ChatPlayNameText = null;
		private Button m_E_SendButton = null;
		private Image m_E_SendImage = null;
		private InputField m_E_InputInputField = null;
		private Image m_E_InputImage = null;
		private LoopVerticalScrollRect m_E_FriendChatItemsLoopVerticalScrollRect = null;
		private Button m_E_CloseChatButton = null;
		private Image m_E_CloseChatImage = null;
		public Transform uiTransform = null;
	}
}
