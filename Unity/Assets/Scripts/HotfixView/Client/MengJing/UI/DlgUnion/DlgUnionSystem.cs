using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	
	[FriendOf(typeof(ES_UnionMy))]
	[FriendOf(typeof(ES_UnionShow))]
	[FriendOf(typeof(ES_UnionMember))]
	[FriendOf(typeof(DlgUnion))]
	public static  class DlgUnionSystem
	{

		public static void RegisterUIEvent(this DlgUnion self)
		{
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
		
			self.RequestFriendInfo().Coroutine();
        }

		public static async ETTask RequestFriendInfo(this DlgUnion self)
		{
			if (self.IsDisposed)
			{
				return;
			}

			self.ClickEnabled = true;
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			long unionId = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);
			if (unionId > 0)
			{
				self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(1);
			}
			else
			{
				self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
			}
			await ETTask.CompletedTask;	
		}
		
		public static void ShowWindow(this DlgUnion self, Entity contextData = null)
		{
		}

		private static void OnFunctionSetBtn(this DlgUnion self, int index)
		{
			if (!self.ClickEnabled)
			{
				return;
			}

			CommonViewHelper.HideChildren(self.View.EG_SubViewNodeRectTransform);

			switch (index)
			{
				case 0:
					self.View.ES_UnionShow.uiTransform.gameObject.SetActive(true);
					self.View.ES_UnionShow.OnUpdateUI();
					break;
				case 1:
					Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
					long unionId = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);
					if (unionId == 0)
					{
						FlyTipComponent.Instance.ShowFlyTip("请先创建或者加入一个家族");
						return;
					}

					self.View.ES_UnionMy.uiTransform.gameObject.SetActive(true);
					self.View.ES_UnionMy.OnUpdateUI().Coroutine();
					break;
				case 2:
					unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
					unionId = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);
					if (unionId == 0)
					{
						FlyTipComponent.Instance.ShowFlyTip("请先创建或者加入一个家族");
						return;
					}
					self.View.ES_UnionMember.uiTransform.gameObject.SetActive(true);
					self.View.ES_UnionMember.OnUpdateUI().Coroutine();
					break;	
				default:
					break;	
			}
		}
		
		
		public static void OnCreateUnion(this DlgUnion self)
		{
			self.View.ES_UnionShow.OnCreateUnion();
		}

		public static void OnLeaveUnion(this DlgUnion self)
		{
			self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
		}

		public static void OnUpdateMyUnion(this DlgUnion self)
		{
			self.View.ES_UnionMy.OnUpdateUI().Coroutine();
		}
	}
}
