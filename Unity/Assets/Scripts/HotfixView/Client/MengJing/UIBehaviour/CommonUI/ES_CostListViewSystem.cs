
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EntitySystemOf(typeof (ES_CostList))]
	[FriendOfAttribute(typeof (ES_CostList))]
	public static partial class ES_CostListSystem
	{
		[EntitySystem]
		private static void Awake(this ES_CostList self, Transform transform)
		{
			self.uiTransform = transform;

			self.E_CostItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
		}

		[EntitySystem]
		private static void Destroy(this ES_CostList self)
		{
			self.DestroyWidget();
		}

		private static void OnBagItemsRefresh(this ES_CostList self, Transform transform, int index)
		{
			Scroll_Item_CommonCostItem scrollItemCommonCostItem = self.ScrollItemCommonCostItems[index].BindTrans(transform);
			scrollItemCommonCostItem.UpdateItem(self.ShowBagInfos[index].ItemID, self.ShowBagInfos[index].ItemNum);
		}

		public static void Refresh(this ES_CostList self, List<RewardItem> rewardItems)
		{
			self.ShowBagInfos.Clear();
			foreach (RewardItem item in rewardItems)
			{
				self.ShowBagInfos.Add(new BagInfo() { ItemID = item.ItemID, ItemNum = item.ItemNum });
			}

			self.AddUIScrollItems(ref self.ScrollItemCommonCostItems, self.ShowBagInfos.Count);
			self.E_CostItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
		}

		public static void Refresh(this ES_CostList self, string rewarfItems)
		{
			self.ShowBagInfos.Clear();
			string[] items = rewarfItems.Split('@');
			foreach (string item in items)
			{
				string[] it = item.Split(';');
				self.ShowBagInfos.Add(new BagInfo() { ItemID = int.Parse(it[0]), ItemNum = int.Parse(it[1]) });
			}

			self.AddUIScrollItems(ref self.ScrollItemCommonCostItems, self.ShowBagInfos.Count);
			self.E_CostItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
		}
	}
}
