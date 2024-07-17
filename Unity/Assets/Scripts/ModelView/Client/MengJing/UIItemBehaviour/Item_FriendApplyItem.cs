using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_FriendApplyItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_FriendApplyItem>
	{
		public FriendInfo FriendInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_FriendApplyItem BindTrans(Transform trans)
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

		public Button E_AgreeButton
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
     				if( this.m_E_AgreeButton == null )
     				{
		    			this.m_E_AgreeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Agree");
     				}
     				return this.m_E_AgreeButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Agree");
     			}
     		}
     	}

		public Image E_AgreeImage
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
     				if( this.m_E_AgreeImage == null )
     				{
		    			this.m_E_AgreeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Agree");
     				}
     				return this.m_E_AgreeImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Agree");
     			}
     		}
     	}

		public Button E_RefuseButton
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
     				if( this.m_E_RefuseButton == null )
     				{
		    			this.m_E_RefuseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Refuse");
     				}
     				return this.m_E_RefuseButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Refuse");
     			}
     		}
     	}

		public Image E_RefuseImage
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
     				if( this.m_E_RefuseImage == null )
     				{
		    			this.m_E_RefuseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Refuse");
     				}
     				return this.m_E_RefuseImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Refuse");
     			}
     		}
     	}

		public Text E_PlayerTipText
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
     				if( this.m_E_PlayerTipText == null )
     				{
		    			this.m_E_PlayerTipText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerTip");
     				}
     				return this.m_E_PlayerTipText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerTip");
     			}
     		}
     	}

		public Text E_PlayerOnLineText
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
     				if( this.m_E_PlayerOnLineText == null )
     				{
		    			this.m_E_PlayerOnLineText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerOnLine");
     				}
     				return this.m_E_PlayerOnLineText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerOnLine");
     			}
     		}
     	}

		public Text E_PlayerOccText
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
     				if( this.m_E_PlayerOccText == null )
     				{
		    			this.m_E_PlayerOccText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerOcc");
     				}
     				return this.m_E_PlayerOccText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerOcc");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_HeadIconImage = null;
			this.m_E_PlayerNameText = null;
			this.m_E_PlayerLevelText = null;
			this.m_E_AgreeButton = null;
			this.m_E_AgreeImage = null;
			this.m_E_RefuseButton = null;
			this.m_E_RefuseImage = null;
			this.m_E_PlayerTipText = null;
			this.m_E_PlayerOnLineText = null;
			this.m_E_PlayerOccText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_HeadIconImage = null;
		private Text m_E_PlayerNameText = null;
		private Text m_E_PlayerLevelText = null;
		private Button m_E_AgreeButton = null;
		private Image m_E_AgreeImage = null;
		private Button m_E_RefuseButton = null;
		private Image m_E_RefuseImage = null;
		private Text m_E_PlayerTipText = null;
		private Text m_E_PlayerOnLineText = null;
		private Text m_E_PlayerOccText = null;
		public Transform uiTransform = null;
	}
}
