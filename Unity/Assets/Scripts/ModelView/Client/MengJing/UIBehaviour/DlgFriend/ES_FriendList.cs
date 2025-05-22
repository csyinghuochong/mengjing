using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FriendList : Entity,IAwake<Transform>,IDestroy ,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_FriendListItem>> ScrollItemFriendListItems;
		public List<FriendInfo> ShowFriendInfos = new();
		
		public UnityEngine.UI.LoopVerticalScrollRect E_FriendListItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendListItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_FriendListItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_FriendListItems");
     			}
     			return this.m_E_FriendListItemsLoopVerticalScrollRect;
     		}
     	}

		public ES_ChatView ES_ChatView
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ChatView es = this.m_es_chatview;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ChatView");
		    	   this.m_es_chatview = this.AddChild<ES_ChatView,Transform>(subTrans);
     			}
     			return this.m_es_chatview;
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
			this.m_E_FriendListItemsLoopVerticalScrollRect = null;
			this.m_es_chatview = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_FriendListItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_ChatView> m_es_chatview = null;
		public Transform uiTransform = null;
	}
}
