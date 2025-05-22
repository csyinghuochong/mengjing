using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FriendApply : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_FriendApplyItem>> ScrollItemFriendApplyItems;
		public List<FriendInfo> ShowFriendInfos = new();
		
		public UnityEngine.UI.LoopVerticalScrollRect E_FriendApplyItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendApplyItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_FriendApplyItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_FriendApplyItems");
     			}
     			return this.m_E_FriendApplyItemsLoopVerticalScrollRect;
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
			this.m_E_FriendApplyItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_FriendApplyItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
