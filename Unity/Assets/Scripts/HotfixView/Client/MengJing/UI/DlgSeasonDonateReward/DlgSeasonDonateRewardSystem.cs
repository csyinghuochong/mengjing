using System;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_SeasonDonateItem))]
	[FriendOf(typeof(DlgSeasonDonateReward))]
	public static  class DlgSeasonDonateRewardSystem
	{

		public static void RegisterUIEvent(this DlgSeasonDonateReward self)
		{
			self.View.E_ButtonCloseButton.AddListener(() =>
			{
				self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SeasonDonateReward);
			});
			
			self.View.E_SeasonDonateItemLoopVerticalScrollRect.AddItemRefreshListener(self.OnRechargeItemsRefresh);

		}

		public static void ShowWindow(this DlgSeasonDonateReward self, Entity contextData = null)
		{
			self.ShowRewardList();
		}

		 private static void OnRechargeItemsRefresh(this DlgSeasonDonateReward self, Transform transform, int index)
		 {
			 foreach (Scroll_Item_SeasonDonateItem item in self.ScrollItemRechargeItems.Values)
			 {
				 if (item.uiTransform == transform)
				 {
					 item.uiTransform = null;
				 }
			 }
			 
			 var item1 = ConfigData.CommonSeasonDonateReward.ToList()[index];
			 Scroll_Item_SeasonDonateItem scrollItemRechargeItem = self.ScrollItemRechargeItems[index].BindTrans(transform);
			 scrollItemRechargeItem.OnInitData(item1.Key, item1.Value);
			 //scrollItemRechargeItem.SetOnInitDataClickHandler((number) => { self.OnClickRechargeItem(number).Coroutine(); });
		 }
		
		private static void ShowRewardList(this DlgSeasonDonateReward self)
		{
			self.AddUIScrollItems(ref self.ScrollItemRechargeItems, ConfigData.CommonSeasonDonateReward.Count);
			self.View.E_SeasonDonateItemLoopVerticalScrollRect.SetVisible(true, ConfigData.CommonSeasonDonateReward.Count);
		}

	}
}
