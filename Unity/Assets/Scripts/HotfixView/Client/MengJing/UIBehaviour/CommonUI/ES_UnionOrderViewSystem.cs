using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	
	[EntitySystemOf(typeof(ES_UnionOrder))]
	[FriendOfAttribute(typeof(ES_UnionOrder))]
	[FriendOfAttribute(typeof(Scroll_Item_UnionOrderItem))]
	public static partial class ES_UnionOrderSystem 
	{
		
		[Invoke(TimerInvokeType.UIUnionOrderTimer)]
		public class UIUnionOrderTimer : ATimer<ES_UnionOrder>
		{
			protected override void Run(ES_UnionOrder self)
			{
				try
				{
					self.OnUpdate();
				}
				catch (Exception e)
				{
					using (zstring.Block())
					{
						Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
					}
				}
			}
		}
        
		[EntitySystem]
		private static void Awake(this ES_UnionOrder self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_Button_CommitButton.AddListenerAsync( self.OnClickCommitButton  );
			self.E_Button_UpgradeButton.AddListener( self.OnClickUpgradeButton );
			self.E_UnionMyItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionListItemsRefresh);
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionOrder self)
		{
			self.Root().GetComponent<TimerComponent>().Remove(ref self.UpdateTime);
			
			self.DestroyWidget();
		}
		
		private static async ETTask OnClickCommitButton(this ES_UnionOrder self)
		{
            if(self.SelectTaskPro == null)
            {
	            return;
            }
			
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            if (numericComponentC.GetAsInt(NumericType.OrderTaskCompNumber) >= 10)
            {
	            FlyTipComponent.Instance.ShowFlyTip("今日已完成最大次数！");
	            return;	
            }

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.SelectTaskPro.taskID);
            if (taskConfig.TargetType == (int)TaskTargetType.GivePet_25)
            {
	            // 给予宠物界面
	            // 参考一下宠物界面 不能放生的宠物此处也不同提交。 添加道具检测一遍。  
	            // 加个任务测试
	            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GivePet);
	            DlgGivePet dlgGivePet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGivePet>();
	            dlgGivePet.InitTask(self.SelectTaskPro.taskID);
	            dlgGivePet.OnUpdateUI();
            }
            else if (taskConfig.TargetType == (int)TaskTargetType.GiveItem_10)
            {
	            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GiveTask);
	            DlgGiveTask dlgGiveTask = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGiveTask>();
	            dlgGiveTask.InitTask(self.SelectTaskPro.taskID);
            }
            else
            {
	            if (taskConfig.TargetType == TaskTargetType.ItemID_Number_2)
	            {
		            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();	
		            int neednum = taskConfig.TargetValue[0];
		            long havenum = bagComponentC.GetItemNumber(taskConfig.Target[0]);
		            if (havenum < neednum)
		            {
			            FlyTipComponent.Instance.ShowFlyTip("道具不足!");
			            return;
		            }
	            }

	            int errorCode = await TaskClientNetHelper.RequestCommitTask(self.Root(),  self.SelectTaskPro.taskID, 0);
	            if (errorCode == ErrorCode.ERR_Success)
	            {
		            FlyTipComponent.Instance.ShowFlyTip("任务完成!");
	            }
	            else
	            {
		            HintHelp.ShowErrorHint(self.Root(), errorCode);
	            }
            }
            // 普通道具直接扣
            self.UpdateTaskStatus();
            self.UpdateTodayNumber();
            self.OnSelectUnionItem(self.SelectTaskPro);
		}

		public static void OnSelectUnionItem(this ES_UnionOrder self, TaskPro taskPro)
		{
			self.SelectTaskPro = taskPro;	
			TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
			BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();	
			
			self.ES_CommonItem.UseTextColor = true;
			if (taskConfig.TargetType == TaskTargetType.ItemID_Number_2)
			{
				ItemInfo itemInfo = new ItemInfo();
				itemInfo.ItemID  =	taskConfig.Target[0];
				self.ES_CommonItem.UpdateItem(itemInfo, ItemOperateEnum.None);
				
				int neednum = taskConfig.TargetValue[0];
				long havenum = bagComponentC.GetItemNumber(itemInfo.ItemID);

				using (zstring.Block())
				{
					self.E_Text_NeedText.text = zstring.Format("需求:{0}", neednum);
					self.E_Text_HaveText.text = zstring.Format("拥有:{0}", havenum);
				}
			}
			else
			{
				self.ES_CommonItem.UpdateItem(null, ItemOperateEnum.None);
			}
			self.ES_CommonItem.HideItemNumber();
			self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
			self.E_Text_TaskDesText.text = taskConfig.TaskDes;
			self.ES_RewardList.Refresh(TaskHelper.GetTaskRewards(taskConfig.Id, taskConfig));
		}

		private static  void OnClickUpgradeButton(this ES_UnionOrder self)
		{
			UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
			if (userInfoComponentC.UserInfo.Diamond < 200)
			{
				FlyTipComponent.Instance.ShowFlyTip("钻石不足！");
				return;
			}
			
			PopupTipHelp.OpenPopupTip( self.Root(), "刷新订单", "是否花费200钻石进行升级？", async () =>
			{
				await TaskClientNetHelper.UnionOrderTaskRequest(self.Root(), 2 );
				self.UpdateTaskList();
				self.UpdateTodayNumber();
			},() => { }).Coroutine();
		}

		public static async ETTask OnUpdateUI(this ES_UnionOrder self)
		{
			await TaskClientNetHelper.UnionOrderTaskRequest(self.Root(), 1 );

			self.UpdateTaskList();
			self.ShowUpdateTime();
			self.UpdateTodayNumber();
		}

		private static void UpdateTaskStatus(this ES_UnionOrder self)
		{
			foreach (Scroll_Item_UnionOrderItem orderItem in self.ScrollItemUnionListItems.Values)
			{
				if (orderItem.uiTransform == null)
				{
					continue;
				}
				orderItem.UpdateTaskStatus();
			}
		}

		private static void OnUnionListItemsRefresh(this ES_UnionOrder self, Transform transform, int index)
		{
			foreach (Scroll_Item_UnionOrderItem item in self.ScrollItemUnionListItems.Values)
			{
				if (item.uiTransform == transform)
				{
					item.uiTransform = null;
				}
			}
			
			Scroll_Item_UnionOrderItem scrollItemUnionListItem = self.ScrollItemUnionListItems[index].BindTrans(transform);
			scrollItemUnionListItem.Refresh(self.ShowTaskIds[index], self.OnSelectUnionItem);

			if (index == 0)
			{
				self.OnSelectUnionItem(self.ShowTaskIds[index]);
			}
		}

		private static void ShowUpdateTime(this ES_UnionOrder self)
		{
			self.Root().GetComponent<TimerComponent>().Remove(ref self.UpdateTime);
			self.UpdateTime = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UIUnionOrderTimer, self);
			self.OnUpdate();
		}

		private static void OnUpdate(this ES_UnionOrder self)
		{
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());	
			NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
			long lastTime = numericComponentC.GetAsLong(NumericType.OrderTaskRefrehTime);
			long serverTime = TimeHelper.ServerNow();
			long leftTime = lastTime + TimeHelper.Hour * 2 - serverTime;
			

			if (leftTime <= 0)
			{
				self.E_Text_OrderCDText.text = string.Empty;
				TaskClientNetHelper.UnionOrderTaskRequest(self.Root(), 1 ).Coroutine();
			}
			else
			{
				self.E_Text_OrderCDText.text = TimeHelper.ShowLeftTime3(leftTime / 1000);
			}
		}

		private static void UpdateTodayNumber(this ES_UnionOrder self)
		{
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
			using (zstring.Block())
			{
				self.E_Text_TodayNumber.text = zstring.Format("今日已完成{0}/10次", numericComponentC.GetAsInt(NumericType.OrderTaskCompNumber));	
			}
		}
        
		private static void UpdateTaskList(this ES_UnionOrder self)
		{
			TaskComponentC taskComponentC = self.Root().GetComponent<TaskComponentC>();
			self.ShowTaskIds = taskComponentC.GetTaskTypeList(TaskTypeEnum.UnionOrder);
			self.AddUIScrollItems(ref self.ScrollItemUnionListItems, self.ShowTaskIds.Count);
			self.E_UnionMyItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskIds.Count);
		}
	}


}
