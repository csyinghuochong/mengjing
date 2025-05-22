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
		
		public UnityEngine.UI.Text E_ChatPlayNameText
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
		    		this.m_E_ChatPlayNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/ImageDi/E_ChatPlayName");
     			}
     			return this.m_E_ChatPlayNameText;
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
		    		this.m_E_SendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Send");
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
		    		this.m_E_SendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Send");
     			}
     			return this.m_E_SendImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputInputField
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
		    		this.m_E_InputInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/E_Input");
     			}
     			return this.m_E_InputInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputImage
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
		    		this.m_E_InputImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Input");
     			}
     			return this.m_E_InputImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_FriendChatItemsLoopVerticalScrollRect
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
		    		this.m_E_FriendChatItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_FriendChatItems");
     			}
     			return this.m_E_FriendChatItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_CloseChatButton
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
		    		this.m_E_CloseChatButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_CloseChat");
     			}
     			return this.m_E_CloseChatButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseChatImage
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
		    		this.m_E_CloseChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_CloseChat");
     			}
     			return this.m_E_CloseChatImage;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
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

		private UnityEngine.UI.Text m_E_ChatPlayNameText = null;
		private UnityEngine.UI.Button m_E_SendButton = null;
		private UnityEngine.UI.Image m_E_SendImage = null;
		private UnityEngine.UI.InputField m_E_InputInputField = null;
		private UnityEngine.UI.Image m_E_InputImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_FriendChatItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_CloseChatButton = null;
		private UnityEngine.UI.Image m_E_CloseChatImage = null;
		public Transform uiTransform = null;
	}
}
