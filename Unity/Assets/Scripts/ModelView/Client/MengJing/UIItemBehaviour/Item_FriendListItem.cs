using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_FriendListItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_FriendListItem>
	{
		public FriendInfo FriendInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_FriendListItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_HeadIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_HeadIconImage == null )
     				{
		    			this.m_E_HeadIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_HeadIcon");
     				}
     				return this.m_E_HeadIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_HeadIcon");
     			}
     		}
     	}

		public Text E_PlayerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_PlayerNameText == null )
     				{
		    			this.m_E_PlayerNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerName");
     				}
     				return this.m_E_PlayerNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerName");
     			}
     		}
     	}

		public Text E_PlayerLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_PlayerLevelText == null )
     				{
		    			this.m_E_PlayerLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerLevel");
     				}
     				return this.m_E_PlayerLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerLevel");
     			}
     		}
     	}

		public Text E_OnLineTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_OnLineTimeText == null )
     				{
		    			this.m_E_OnLineTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_OnLineTime");
     				}
     				return this.m_E_OnLineTimeText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_OnLineTime");
     			}
     		}
     	}

		public Button E_WatchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_WatchButton == null )
     				{
		    			this.m_E_WatchButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Watch");
     				}
     				return this.m_E_WatchButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Watch");
     			}
     		}
     	}

		public Image E_WatchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_WatchImage == null )
     				{
		    			this.m_E_WatchImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Watch");
     				}
     				return this.m_E_WatchImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Watch");
     			}
     		}
     	}

		public Button E_ChatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ChatButton == null )
     				{
		    			this.m_E_ChatButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Chat");
     				}
     				return this.m_E_ChatButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Chat");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ChatImage == null )
     				{
		    			this.m_E_ChatImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Chat");
     				}
     				return this.m_E_ChatImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Chat");
     			}
     		}
     	}

		public Button E_DeleteButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_DeleteButton == null )
     				{
		    			this.m_E_DeleteButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Delete");
     				}
     				return this.m_E_DeleteButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Delete");
     			}
     		}
     	}

		public Image E_DeleteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_DeleteImage == null )
     				{
		    			this.m_E_DeleteImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Delete");
     				}
     				return this.m_E_DeleteImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Delete");
     			}
     		}
     	}

		public Text E_OccNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_OccNameText == null )
     				{
		    			this.m_E_OccNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_OccName");
     				}
     				return this.m_E_OccNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_OccName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_HeadIconImage = null;
			this.m_E_PlayerNameText = null;
			this.m_E_PlayerLevelText = null;
			this.m_E_OnLineTimeText = null;
			this.m_E_WatchButton = null;
			this.m_E_WatchImage = null;
			this.m_E_ChatButton = null;
			this.m_E_ChatImage = null;
			this.m_E_DeleteButton = null;
			this.m_E_DeleteImage = null;
			this.m_E_OccNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_HeadIconImage = null;
		private Text m_E_PlayerNameText = null;
		private Text m_E_PlayerLevelText = null;
		private Text m_E_OnLineTimeText = null;
		private Button m_E_WatchButton = null;
		private Image m_E_WatchImage = null;
		private Button m_E_ChatButton = null;
		private Image m_E_ChatImage = null;
		private Button m_E_DeleteButton = null;
		private Image m_E_DeleteImage = null;
		private Text m_E_OccNameText = null;
		public Transform uiTransform = null;
	}
}
