using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof (ES_PetList))]
	[FriendOf(typeof (ES_PetHeCheng))]
	[FriendOf(typeof (ES_PetXiLian))]
	[FriendOf(typeof (ES_PetShouHu))]
	[FriendOf(typeof (DlgPet))]
	public static class DlgPetSystem
	{
		public static void RegisterUIEvent(this DlgPet self)
		{
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
		}

		public static void ShowWindow(this DlgPet self, Entity contextData = null)
		{
			self.View.E_PetToggle.IsSelected(true);

			UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
			uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
			uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
		}

		private static void OnFunctionSetBtn(this DlgPet self, int index)
		{
			UICommonHelper.SetToggleShow(self.View.E_PetToggle.gameObject, index == 0);
			UICommonHelper.SetToggleShow(self.View.E_HeChengToggle.gameObject, index == 1);
			UICommonHelper.SetToggleShow(self.View.E_XiLianToggle.gameObject, index == 2);
			UICommonHelper.SetToggleShow(self.View.E_ShouHuToggle.gameObject, index == 3);

			UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
			switch (index)
			{
				case 0:
					self.View.ES_PetList.uiTransform.gameObject.SetActive(true);
					self.View.ES_PetList.OnUpdateUI();
					break;
				case 1:
					self.View.ES_PetHeCheng.uiTransform.gameObject.SetActive(true);
					break;
				case 2:
					self.View.ES_PetXiLian.uiTransform.gameObject.SetActive(true);
					break;
				case 3:
					self.View.ES_PetShouHu.uiTransform.gameObject.SetActive(true);
					break;
			}
		}

		private static void OnCloseButton(this DlgPet self)
		{
			UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

			uiComponent.CloseWindow(WindowID.WindowID_Pet);
		}
		
		public static async ETTask RequestPetHeXinSelect(this DlgPet self)
		{
			await self.View.ES_PetList.OnButtonEquipHeXin();
		}

	}
}
