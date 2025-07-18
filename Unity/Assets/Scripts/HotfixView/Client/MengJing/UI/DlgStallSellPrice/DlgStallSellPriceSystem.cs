using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgStallSellPrice))]
	public static  class DlgStallSellPriceSystem
	{

		public static void RegisterUIEvent(this DlgStallSellPrice self)
		{
		  
		  self.View.E_ImageButtonButton.AddListener(self.OnImageButton);
		  self.View.E_Btn_ChuShouButton.AddListenerAsync(self.OnBtn_ChuShou);
		  self.View.E_Btn_CostButton.AddListener(self.OnCostPrice);
		  self.View.E_Btn_AddButton.AddListener(self.OnAddPrice);
		  self.View.E_PriceInputFieldInputField.onValueChanged.AddListener( (string value) => { self.OnChange(value); } );
		  self.View.E_Btn_CostNumButton.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_CostNum(pdata as PointerEventData).Coroutine(); });
		  self.View.E_Btn_CostNumButton.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_CostNum(pdata as PointerEventData); });
            
		  self.View.E_Btn_AddNumButton.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_Btn_AddNum(pdata as PointerEventData).Coroutine(); });
		   self.View.E_Btn_AddNumButton.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp_Btn_AddNum(pdata as PointerEventData); });
		}

		public static void ShowWindow(this DlgStallSellPrice self, Entity contextData = null)
		{
		}
		
		public static async ETTask PointerDown_Btn_CostNum(this DlgStallSellPrice self, PointerEventData pdata)
		{
			int interval = 0;
			self.IsHoldDown = true;
			self.OnCostNum();
			while (self.IsHoldDown)
			{
				interval++;
				if (interval > 60)
				{
					self.OnCostNum();
				}

				if (self.SellNum == 1)
				{
					break;
				}

				await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
			}
		}
		
		public static void PointerUp_Btn_CostNum(this DlgStallSellPrice self, PointerEventData pdata)
		{
			self.IsHoldDown = false;
		}
		
		public static async ETTask PointerDown_Btn_AddNum(this DlgStallSellPrice self, PointerEventData pdata)
		{
			int interval = 0;
			self.IsHoldDown = true;
			self.OnAddNum();
			while (self.IsHoldDown)
			{
				interval++;
				if (interval > 60)
				{
					self.OnAddNum();
				}

				if (self.SellNum >= self.BagInfo.ItemNum)
				{
					break;
				}

				await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
			}
		}

		public static void PointerUp_Btn_AddNum(this DlgStallSellPrice self, PointerEventData pdata)
		{
			self.IsHoldDown = false;
		}
		
		public static void OnImageButton(this DlgStallSellPrice self)
		{
			Log.Debug($"OnImageButtonOnImageButton");
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_StallSellPrice);
		}

		public static async ETTask OnBtn_ChuShou(this DlgStallSellPrice self)
		{
			ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
			// 橙色装备不能上架
			if (itemConfig.ItemQuality >= 5 && itemConfig.ItemType == 3)
			{
				FlyTipComponent.Instance.ShowFlyTip("橙色品质及以上的装备不能上架！");
				return;
			}

			if (self.SellNum == 0)
			{
				return;
			}

			PaiMaiItemInfo paiMaiItemInfo = PaiMaiItemInfo.Create();
			ItemInfo iteminfo = self.BagInfo;
			paiMaiItemInfo.BagInfo =  CommonHelp.DeepCopy(iteminfo.ToMessage());
			paiMaiItemInfo.BagInfo.ItemNum = self.SellNum;
			paiMaiItemInfo.Price = self.nowPrice;

			DlgPaiMai dlgPaiMai = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMai>();
			if (dlgPaiMai!= null && dlgPaiMai.PaiMaiShopItemInfos.ContainsKey(paiMaiItemInfo.BagInfo.ItemID))
			{
				int oldPrice = dlgPaiMai.PaiMaiShopItemInfos[paiMaiItemInfo.BagInfo.ItemID].Price;

				int nowPrice = (int)((float)paiMaiItemInfo.Price);
				if (nowPrice < (int)(oldPrice * 0.5f))
				{
					FlyTipComponent.Instance.ShowFlyTip("出售价格过低，当前最低价格为:" + (int)(oldPrice * 0.5f) * paiMaiItemInfo.BagInfo.ItemNum);
					return;
				}
			}

			//发送上架协议
			long instanceid = self.InstanceId;
			M2C_StallSellResponse 	m2CStallSellResponse = await PaiMaiNetHelper.RequestStallSell(self.Root(), paiMaiItemInfo );
			if (m2CStallSellResponse == null || instanceid != self.InstanceId)
			{
				return;
			}

			if (dlgPaiMai != null)
			{
				dlgPaiMai.View.ES_StallSell?.OnPaiBuyShangJia(m2CStallSellResponse.PaiMaiItemInfo);
			}

			self.OnImageButton();
		}
		
		public static void InitPriceUI(this DlgStallSellPrice self, ItemInfo bagInfo)
		 {
		     self.BagInfo = bagInfo;

		     FunctionUI.ItemObjShowName(self.View.E_Lab_NameText.gameObject, bagInfo.ItemID);
		     
		     //设置价格
		     self.oldPrice = 10000; //临时
		     //获取是否是快捷购买的道具列表
		     DlgPaiMai dlgPaiMai = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMai>();
		     if (dlgPaiMai!= null && dlgPaiMai.PaiMaiShopItemInfos.ContainsKey(bagInfo.ItemID))
		     {
		         self.oldPrice = dlgPaiMai.PaiMaiShopItemInfos[bagInfo.ItemID].Price;
		     }
		     
		     self.nowPrice = self.oldPrice;
		     self.SellNum = bagInfo.ItemNum;
		     
		     self.View.E_Lab_TuijianText.text = self.oldPrice.ToString();
		     self.View.E_Text_PriceText.text = self.SellNum.ToString();
		     
		     self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
		     self.View.ES_CommonItem.HideItemName();
		     self.View.ES_CommonItem.HideItemNumber();
		     
		     //初始化显示
		     self.priceProNum = 1;
		     self.OnCostPrice();
		 }
		
		
		public static void OnAddPrice(this DlgStallSellPrice self)
		{
			//Log.Info("OnAddPrice.....");

			self.priceProNum += 1;
			if (self.priceProNum >= 10)
			{
				self.priceProNum = 10;
				FlyTipComponent.Instance.ShowFlyTip("如需再提高价格，请手动修改价格!");
			}

			self.nowPrice = (int)(self.oldPrice * (1f + 0.1f * self.priceProNum));
			self.View.E_Lab_SellSumProText.text = ((int)(self.oldPrice * (1f + 0.1f * self.priceProNum) * self.SellNum)).ToString();
			self.View.E_PriceInputFieldInputField.text = self.nowPrice.ToString();
		}
        
		
		public static void OnCostPrice(this DlgStallSellPrice self)
		{
			self.priceProNum -= 1;
			if (self.priceProNum <= -10)
			{
				self.priceProNum = -10;
			}

			self.nowPrice = (int)(self.oldPrice * (1f + 0.1f * self.priceProNum));
			self.View.E_Lab_SellSumProText.text= ((int)(self.oldPrice * (1f + 0.1f * self.priceProNum) * self.SellNum)).ToString();
			self.View.E_PriceInputFieldInputField.text  = self.nowPrice.ToString();
		}
		
		public static void OnAddNum(this DlgStallSellPrice self)
		{
			self.SellNum += 1;
			if (self.SellNum >= self.BagInfo.ItemNum)
			{
				self.SellNum = self.BagInfo.ItemNum;
			}

			self.View.E_Text_PriceText.text = self.SellNum.ToString();
			//调整价格
			//self.PriceInputField.GetComponent<InputField>().text = self.nowPrice.ToString();
			self.View.E_Lab_SellSumProText.text = ((int)(self.oldPrice * (1f + 0.1f * self.priceProNum) * self.SellNum)).ToString();
		}

		public static void OnCostNum(this DlgStallSellPrice self)
		{
			self.SellNum -= 1;
			if (self.SellNum <= 1)
			{
				self.SellNum = 1;
			}

			self.View.E_Text_PriceText.text= self.SellNum.ToString();
			//调整价格
			//self.PriceInputField.GetComponent<InputField>().text = self.nowPrice.ToString();
			self.View.E_Lab_SellSumProText.text = ((int)(self.oldPrice * (1f + 0.1f * self.priceProNum) * self.SellNum)).ToString();
		}

		public static void OnChange(this DlgStallSellPrice self, string str)
		{
			self.nowPrice = int.Parse(str);
		}
	}
}
