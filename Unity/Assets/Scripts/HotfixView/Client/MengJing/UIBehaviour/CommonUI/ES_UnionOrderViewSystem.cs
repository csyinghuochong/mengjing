
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionOrder))]
	[FriendOfAttribute(typeof(ES_UnionOrder))]
	public static partial class ES_UnionOrderSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionOrder self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_UnionMyItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionListItemsRefresh);

		}

		[EntitySystem]
		private static void Destroy(this ES_UnionOrder self)
		{
			self.DestroyWidget();
		}

		private static void OnUnionListItemsRefresh(this ES_UnionOrder self, Transform transform, int index)
		{
			Scroll_Item_UnionOrderItem scrollItemUnionListItem = self.ScrollItemUnionListItems[index].BindTrans(transform);
			//scrollItemUnionListItem.Refresh(self.ShowUnionListItems[index], self.OnSelectUnionItem);
		}
		
		public static async ETTask OnUpdateUI(this ES_UnionOrder self)
		{
			U2C_UnionMyInfoResponse response = await UnionNetHelper.UnionMyInfo(self.Root());

			self.ShowTaskIds = response.UnionMyInfo.UnionOrderTask;
			self.AddUIScrollItems(ref self.ScrollItemUnionListItems, self.ShowTaskIds.Count);
			self.E_UnionMyItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskIds.Count);
		}
	}


}
