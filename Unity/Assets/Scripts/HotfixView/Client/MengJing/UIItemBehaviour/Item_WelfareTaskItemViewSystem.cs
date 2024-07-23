using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_WelfareTaskItem))]
    [EntitySystemOf(typeof(Scroll_Item_WelfareTaskItem))]
    public static partial class Scroll_Item_WelfareTaskItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_WelfareTaskItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_WelfareTaskItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateData(this Scroll_Item_WelfareTaskItem self, TaskPro taskPro, int day)
        {
            self.E_ReceiveBtnButton.AddListenerAsync(self.OnReceiveBtn);

            self.TaskPro = taskPro;
            self.Day = day;
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);

            self.E_TaskNameTextText.text = taskConfig.TaskName;
            self.E_TaskDescTextText.text = taskConfig.TaskDes;

            List<RewardItem> rewardItems = new List<RewardItem>();

            if (taskConfig.TaskCoin > 0)
            {
                rewardItems.Add(new RewardItem() { ItemID = 1, ItemNum = taskConfig.TaskCoin });
            }

            if (taskConfig.TaskExp > 0)
            {
                rewardItems.Add(new RewardItem() { ItemID = 2, ItemNum = taskConfig.TaskExp });
            }

            rewardItems.AddRange(TaskHelper.GetTaskRewards(taskPro.taskID));
            self.ES_RewardList.Refresh(rewardItems, 0.8f);

            using (zstring.Block())
            {
                self.E_TaskProgressText.text = zstring.Format("{0}/{1}", taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            self.E_ReceiveBtnButton.gameObject.SetActive(taskPro.taskStatus != (int)TaskStatuEnum.Commited);
            self.E_ReceivedImgImage.gameObject.SetActive(taskPro.taskStatus == (int)TaskStatuEnum.Commited);
        }

        public static async ETTask OnReceiveBtn(this Scroll_Item_WelfareTaskItem self)
        {
            if (self.TaskPro.taskStatus < (int)TaskStatuEnum.Completed)
            {
                FlyTipComponent.Instance.ShowFlyTip("任务还没有完成！");
                return;
            }

            if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Commited)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取过奖励！");
                return;
            }

            int error = await TaskClientNetHelper.RequestCommitTask(self.Root(), self.TaskPro.taskID, 0);

            if (error == 0)
            {
                self.GetParent<ES_WelfareTask>().UpdateInfo(self.Day);
            }
        }
    }
}