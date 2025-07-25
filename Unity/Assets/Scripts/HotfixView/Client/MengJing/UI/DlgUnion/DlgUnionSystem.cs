using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(ES_UnionBoss))]
	[FriendOf(typeof(ES_UnionMystery))]
	[FriendOf(typeof(ES_UnionMy))]
	[FriendOf(typeof(ES_UnionShow))]
	[FriendOf(typeof(ES_UnionMember))]
	[FriendOf(typeof(ES_UnionWish))]
	[FriendOf(typeof(ES_UnionOrder))]
	[FriendOf(typeof(DlgUnion))]
	public static  class DlgUnionSystem
	{

		public static void RegisterUIEvent(this DlgUnion self)
		{
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn, self.CheckPageButton_1);
			
			IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
			self.RequestFriendInfo().Coroutine();
        }

		public static bool CheckPageButton_1(this DlgUnion self, int page)
		{
			if (page == 0)
			{
				return true;
			}

			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			long unionId = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);
			if (unionId == 0)
			{
				FlyTipComponent.Instance.ShowFlyTip("请先创建或者加入一个公会");
			}
			
			return unionId > 0;
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
					self.View.ES_UnionMy.uiTransform.gameObject.SetActive(true);
					self.View.ES_UnionMy.OnUpdateUI().Coroutine();
					break;
				case 2:
					self.View.ES_UnionMember.uiTransform.gameObject.SetActive(true);
					self.View.ES_UnionMember.OnUpdateUI().Coroutine();
					break;	
				case 3:
					self.View.ES_UnionMystery.uiTransform.gameObject.SetActive(true);
					break;
				case 4:
					self.View.ES_UnionBoss.uiTransform.gameObject.SetActive(true);
					break;	
				case 5:
					self.View.ES_UnionWish.uiTransform.gameObject.SetActive(true);
					self.View.ES_UnionWish.OnUpdateUI();
					break;
				case 6:
					self.View.ES_UnionOrder.uiTransform.gameObject.SetActive(true);
					self.View.ES_UnionOrder.OnUpdateUI().Coroutine();
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
