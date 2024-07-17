using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_LobbyRole : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_LobbyRole>
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_LobbyRole BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text ELvText
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
     				if( this.m_ELvText == null )
     				{
		    			this.m_ELvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ELv");
     				}
     				return this.m_ELvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ELv");
     			}
     		}
     	}

		public Text ENameText
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
     				if( this.m_ENameText == null )
     				{
		    			this.m_ENameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EName");
     				}
     				return this.m_ENameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELvText = null;
			this.m_ENameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_ELvText = null;
		private Text m_ENameText = null;
		public Transform uiTransform = null;
	}
}
