
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_FriendApplyItem : Entity,IAwake,IDestroy,IUIScrollItem
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

		public UnityEngine.UI.Image E_HeadIconImage
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
		    			this.m_E_HeadIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_HeadIcon");
     				}
     				return this.m_E_HeadIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_HeadIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_PlayerNameText
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
		    			this.m_E_PlayerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerName");
     				}
     				return this.m_E_PlayerNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_PlayerLevelText
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
		    			this.m_E_PlayerLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerLevel");
     				}
     				return this.m_E_PlayerLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerLevel");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_AgreeButton
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
		    			this.m_E_AgreeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Agree");
     				}
     				return this.m_E_AgreeButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Agree");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_AgreeImage
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
		    			this.m_E_AgreeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Agree");
     				}
     				return this.m_E_AgreeImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Agree");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_RefuseButton
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
		    			this.m_E_RefuseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Refuse");
     				}
     				return this.m_E_RefuseButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Refuse");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_RefuseImage
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
		    			this.m_E_RefuseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Refuse");
     				}
     				return this.m_E_RefuseImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Refuse");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_PlayerTipText
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
		    			this.m_E_PlayerTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerTip");
     				}
     				return this.m_E_PlayerTipText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerTip");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_PlayerOnLineText
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
		    			this.m_E_PlayerOnLineText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerOnLine");
     				}
     				return this.m_E_PlayerOnLineText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerOnLine");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_PlayerOccText
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
		    			this.m_E_PlayerOccText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerOcc");
     				}
     				return this.m_E_PlayerOccText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerOcc");
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

		private UnityEngine.UI.Image m_E_HeadIconImage = null;
		private UnityEngine.UI.Text m_E_PlayerNameText = null;
		private UnityEngine.UI.Text m_E_PlayerLevelText = null;
		private UnityEngine.UI.Button m_E_AgreeButton = null;
		private UnityEngine.UI.Image m_E_AgreeImage = null;
		private UnityEngine.UI.Button m_E_RefuseButton = null;
		private UnityEngine.UI.Image m_E_RefuseImage = null;
		private UnityEngine.UI.Text m_E_PlayerTipText = null;
		private UnityEngine.UI.Text m_E_PlayerOnLineText = null;
		private UnityEngine.UI.Text m_E_PlayerOccText = null;
		public Transform uiTransform = null;
	}
}
