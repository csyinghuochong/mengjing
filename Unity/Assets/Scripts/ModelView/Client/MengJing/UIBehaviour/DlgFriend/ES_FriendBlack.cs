using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FriendBlack : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_FriendBlackItem>> ScrollItemFriendBlackItems;
		public List<FriendInfo> ShowFriendInfos = new();
		
		public UnityEngine.UI.LoopVerticalScrollRect E_FriendBlackItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendBlackItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_FriendBlackItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_FriendBlackItems");
     			}
     			return this.m_E_FriendBlackItemsLoopVerticalScrollRect;
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
			this.m_E_FriendBlackItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_FriendBlackItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
