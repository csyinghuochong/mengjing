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
		
		public LoopVerticalScrollRect E_FriendBlackItemsLoopVerticalScrollRect
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
		    		this.m_E_FriendBlackItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_FriendBlackItems");
     			}
     			return this.m_E_FriendBlackItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FriendBlackItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_FriendBlackItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
