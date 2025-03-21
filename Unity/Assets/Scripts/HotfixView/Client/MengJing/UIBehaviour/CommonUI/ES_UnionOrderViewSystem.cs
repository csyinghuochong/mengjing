
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
			
			self.E_Button_CommitButton.AddListenerAsync( self.OnClickCommitButton  );
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
			scrollItemUnionListItem.Refresh(self.ShowTaskIds[index], self.OnSelectUnionItem);

			if (index == 0)
			{
                self.OnSelectUnionItem(self.ShowTaskIds[index]);
			}
		}

		private static async ETTask OnClickCommitButton(this ES_UnionOrder self)
		{
			await ETTask.CompletedTask;
		}

		public static void OnSelectUnionItem(this ES_UnionOrder self, int taskid)
		{
			TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
			BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();	
			
			if (taskConfig.TargetType == TaskTargetType.GiveItem_10)
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
			self.E_Text_TaskDesText.text = taskConfig.TaskDes;
			self.ES_RewardList.Refresh(TaskHelper.GetTaskRewards(taskConfig.Id, taskConfig));
		}

		public static async ETTask OnUpdateUI(this ES_UnionOrder self)
		{
			U2C_UnionMyInfoResponse response = await UnionNetHelper.UnionMyInfo(self.Root());

			//self.ShowTaskIds = response.UnionMyInfo.UnionOrderTask;
			self.AddUIScrollItems(ref self.ScrollItemUnionListItems, self.ShowTaskIds.Count);
			self.E_UnionMyItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskIds.Count);
		}
	}


}
