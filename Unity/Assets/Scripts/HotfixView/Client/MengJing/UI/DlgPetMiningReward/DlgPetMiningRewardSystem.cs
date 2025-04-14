using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetMiningRewardItem))]
    [FriendOf(typeof (DlgPetMiningReward))]
    public static class DlgPetMiningRewardSystem
    {
        public static void RegisterUIEvent(this DlgPetMiningReward self)
        {
            self.View.E_ImageCloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMiningReward);
            });
            self.View.E_PetMiningRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetMiningRewardItemsRefresh);
            
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgPetMiningReward self, Entity contextData = null)
        {
        }

        private static void OnPetMiningRewardItemsRefresh(this DlgPetMiningReward self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetMiningRewardItem item in self.ScrollItemPetMiningRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetMiningRewardItem scrollItemPetMiningRewardItem = self.ScrollItemPetMiningRewardItems[index].BindTrans(transform);
            scrollItemPetMiningRewardItem.OnInitUI(self.ShowTaskPros[index]);
        }

        public static void OnInitUI(this DlgPetMiningReward self)
        {
            List<TaskPro> taskPros = self.Root().GetComponent<TaskComponentC>().RoleTaskList;
            taskPros.Sort(delegate(TaskPro a, TaskPro b)
            {
                int commita = a.taskStatus == (int)TaskStatuEnum.Commited? 1 : 0;
                int commitb = b.taskStatus == (int)TaskStatuEnum.Commited? 1 : 0;
                int completea = a.taskStatus == (int)TaskStatuEnum.Completed? 1 : 0;
                int completeb = b.taskStatus == (int)TaskStatuEnum.Completed? 1 : 0;

                if (commita == commitb)
                    return completeb - completea; //可以领取的在前
                else
                    return commitb - commita; //已经完成的在前
            });

            self.ShowTaskPros.Clear();

            for (int i = 0; i < taskPros.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                if (taskConfig.TaskType != TaskTypeEnum.Mine)
                {
                    continue;
                }

                self.ShowTaskPros.Add(taskPros[i]);
            }

            // 测试数据
            // self.ShowTaskPros.Add(new TaskPro() { taskID = 500001, taskStatus = (int)TaskStatuEnum.Completed });
            // self.ShowTaskPros.Add(new TaskPro() { taskID = 500002, taskStatus = (int)TaskStatuEnum.Accepted });

            self.AddUIScrollItems(ref self.ScrollItemPetMiningRewardItems, self.ShowTaskPros.Count);
            self.View.E_PetMiningRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPros.Count);
        }
    }
}
