using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(DlgGiveTask))]
    public static class DlgGiveTaskSystem
    {
        public static void RegisterUIEvent(this DlgGiveTask self)
        {
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.View.E_CloseBtnButton.AddListener(self.OnCloseBtnButton);
            self.View.E_GiveBtnButton.AddListenerAsync(self.OnGiveBtnButton);

            self.OnBagListUpdate();
        }

        public static void ShowWindow(this DlgGiveTask self, Entity contextData = null)
        {
        }

        public static void InitTask(this DlgGiveTask self, int taskId)
        {
            self.TaskId = taskId;

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            self.View.E_TaskDesTextText.text = taskConfig.TaskDes;
        }

        public static void OnCloseBtnButton(this DlgGiveTask self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GiveTask);
        }

        private static void OnBagItemsRefresh(this DlgGiveTask self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.SkillSet, self.OnSelect);
        }

        public static void OnBagListUpdate(this DlgGiveTask self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();
            foreach (ItemInfo itemInfo in bagComponent.GetItemsByType(ItemTypeEnum.Equipment))
            {
                self.ShowBagInfos.Add(itemInfo);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void OnSelect(this DlgGiveTask self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(bagInfo);
                }
            }
        }

        public static async ETTask OnGiveBtnButton(this DlgGiveTask self)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.TaskId);
            if (TaskHelper.IsTaskGiveItem(taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue, self.BagInfo))
            {
                TaskPro taskPro = taskComponent.GetTaskById(self.TaskId);
                taskPro.taskStatus = (int)TaskStatuEnum.Completed;
                int errorCode = await TaskClientNetHelper.RequestCommitTask(self.Root(), self.TaskId, self.BagInfo.BagInfoID);
                if (errorCode == ErrorCode.ERR_Success)
                {
                    FlyTipComponent.Instance.ShowFlyTip("完成任务");
                    self.OnGiveAction?.Invoke();
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GiveTask);
                }
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTip("道具类型不符合任务要求");
            }
        }
    }
}