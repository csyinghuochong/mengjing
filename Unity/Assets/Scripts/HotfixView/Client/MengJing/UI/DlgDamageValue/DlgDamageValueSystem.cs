using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgDamageValue))]
	public static  class DlgDamageValueSystem
	{

		public static void RegisterUIEvent(this DlgDamageValue self)
		{
			self.View.E_RankShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRDamageItemsRefresh);
			
			self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);

		}
		
		public static void OnButtonCloseButton(this DlgDamageValue self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DamageValue);
		}

		public static void ShowWindow(this DlgDamageValue self, Entity contextData = null)
		{
		}
		
		private static void OnRDamageItemsRefresh(this DlgDamageValue self, Transform transform, int index)
		{
			var item = self.DamageValueList[index];
			Scroll_Item_DamageValueItem scrollItemRechargeItem = self.ScrollItemRechargeItems[index].BindTrans(transform);
			scrollItemRechargeItem.OnInitData(item);
		}

		public static void OnInitUI(this DlgDamageValue self, M2C_DamageValueListResponse info)
		{
			self.DamageValueList = info.DamageValueList;	
			self.AddUIScrollItems(ref self.ScrollItemRechargeItems, info.DamageValueList.Count);
			self.View.E_RankShowItemsLoopVerticalScrollRect.SetVisible(true, info.DamageValueList.Count, true);
		}

	}
}
