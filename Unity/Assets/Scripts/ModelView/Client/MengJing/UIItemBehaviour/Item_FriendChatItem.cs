using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_FriendChatItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_FriendChatItem>
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_FriendChatItem BindTrans(Transform trans)
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

		public Text E_NameText
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
     				if( this.m_E_NameText == null )
     				{
		    			this.m_E_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Name");
     				}
     				return this.m_E_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Name");
     			}
     		}
     	}

		public Text E_InfoText
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
     				if( this.m_E_InfoText == null )
     				{
		    			this.m_E_InfoText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Info");
     				}
     				return this.m_E_InfoText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Info");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_HeadIconImage = null;
			this.m_E_NameText = null;
			this.m_E_InfoText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_HeadIconImage = null;
		private Text m_E_NameText = null;
		private Text m_E_InfoText = null;
		public Transform uiTransform = null;
	}
}
