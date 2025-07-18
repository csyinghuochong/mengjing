using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgPaiMaiStall))]
	[FriendOf(typeof(Scroll_Item_PaiMaiStallItem))]
	public static  class DlgPaiMaiStallSystem
	{

		public static void RegisterUIEvent(this DlgPaiMaiStall self)
		{
		 
			self.View.E_ImageButtonButton.AddListener(self.OnButtonClose);
			self.View.E_Btn_CloseButton.AddListener(self.OnButtonClose);
			
			self.View.E_Lab_NameInputField.onValueChanged.AddListener( (string text) => { self.CheckSensitiveWords(); } );

			self.View.E_Btn_BuyItemButton.AddListenerAsync(self.OnBtn_BuyItem);
			self.View.E_Btn_ShouTanButton.AddListener(self.OnButtonShouTan);
			self.View.E_Btn_ChangeNameButton.AddListenerAsync(self.OnBtn_ChangeName);
			
			self.View.E_RechargeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPaiMaiSellItemsRefresh);

		}

		public static void ShowWindow(this DlgPaiMaiStall self, Entity contextData = null)
		{
		}

		public static void CheckSensitiveWords(this DlgPaiMaiStall self)
		{
			string text_new = "";
			string text_old = self.View.E_Lab_NameInputField.text;
			MaskWordHelper.Instance.IsContainSensitiveWords(ref text_old, out text_new);
			self.View.E_Lab_NameInputField.text = text_old;
		}

		public static async ETTask OnBtn_ChangeName(this DlgPaiMaiStall self)
		{
			string name =self.View.E_Lab_NameInputField.text;
			bool mask = MaskWordHelper.Instance.IsContainSensitiveWords(name);
			if (mask)
			{
				FlyTipComponent.Instance.ShowFlyTip("请重新输入！");
				return;
			}

			M2C_StallOperationResponse response =  await PaiMaiNetHelper.RequestStallOperation(self.Root(), 2, name);
			if (response.Error != ErrorCode.ERR_Success || self.IsDisposed)
			{
				return;
			}

			self.View.E_Lab_NameInputField.text = name;
		}
		
		public static void OnUpdateUI(this DlgPaiMaiStall self, Unit unit)
		{
			self.UserId = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.MasterId);

			long selfId = UnitHelper.GetMyUnitId(self.Root());
			bool ifSelf = selfId == self.UserId;
			self.View.E_Btn_BuyItemButton.gameObject.SetActive(!ifSelf);
			self.View.E_Btn_ShouTanButton.gameObject.SetActive(ifSelf);
			self.View.E_Btn_ChangeNameButton.gameObject.SetActive(ifSelf);
			if (!string.IsNullOrEmpty(unit.GetComponent<UnitInfoComponent>().UnitName))
			{
				self.View.E_Lab_NameInputField.text = unit.GetComponent<UnitInfoComponent>().UnitName;
			}
			else
			{
				self.View.E_Lab_NameInputField.text = "商品摊位";
			}

			self.RequestStallInfo().Coroutine();
		}
        
		private static void OnPaiMaiSellItemsRefresh(this DlgPaiMaiStall self, Transform transform, int index)
		{
			foreach (Scroll_Item_PaiMaiStallItem item in self.ScrollItemPaiMaiSellItems.Values)
			{
				if (item.uiTransform == transform)
				{
					item.uiTransform = null;
				}
			}
            
			Scroll_Item_PaiMaiStallItem scrollItemPaiMaiSellItem = self.ScrollItemPaiMaiSellItems[index].BindTrans(transform);
			scrollItemPaiMaiSellItem.SetClickHandler((bagInfo) => { self.OnSelectStallItem(bagInfo); });
			scrollItemPaiMaiSellItem.OnUpdateUI(self.ShowPaiMaiItemInfos[index]);
		}
        
		public static async ETTask RequestStallInfo(this DlgPaiMaiStall self)
		{
			long instanceId = self.InstanceId;

			P2C_StallListResponse p2CStallListResponse =  await PaiMaiNetHelper.RequestStallList(self.Root(), self.UserId);
			if (p2CStallListResponse == null || self.IsDisposed)
			{
				return;
			}
			if (self.InstanceId != instanceId)
			{
				return;
			}

			self.ShowPaiMaiItemInfos = p2CStallListResponse.PaiMaiItemInfos;
			self.AddUIScrollItems(ref self.ScrollItemPaiMaiSellItems, self.ShowPaiMaiItemInfos.Count);
			self.View.E_RechargeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPaiMaiItemInfos.Count);
		}
		
		public static void OnSelectStallItem(this DlgPaiMaiStall self, PaiMaiItemInfo bagInfo)
		{
			if (self.ScrollItemPaiMaiSellItems != null)
			{
				foreach (Scroll_Item_PaiMaiStallItem item in self.ScrollItemPaiMaiSellItems.Values)
				{
					if (item.uiTransform == null)
					{
						continue;
					}

					item.SetSelected(bagInfo.Id);
				}
			}

			self.PaiMaiItemInfo = bagInfo;
		}
		
		public static async ETTask OnBtn_BuyItem(this DlgPaiMaiStall self)
		{
			await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PaiMaiStallBuy);
			self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMaiStallBuy>().OnUpdateUI(self.PaiMaiItemInfo);
			await ETTask.CompletedTask;
		}
		
		public static void OnButtonClose(this DlgPaiMaiStall self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMaiStall);
		}
		
		//收回摊位
		public static void OnButtonShouTan(this DlgPaiMaiStall self)
		{
			PopupTipHelp.OpenPopupTip(self.Root(), "摊位提示", "是否收起自己的摊位?\n 支持下线，摊位可以离线显示6小时!",
				() =>
				{
					PaiMaiNetHelper.RequestStallOperation(self.Root(), 0, string.Empty).Coroutine();
					//界面存在就销毁界面
					//UIHelper.Remove(self.DomainScene(), UIType.UIPaiMaiStall);
					//弹出提示
					FlyTipComponent.Instance.ShowFlyTip("摊位已收起!");
				}).Coroutine();
		}
	}
}
