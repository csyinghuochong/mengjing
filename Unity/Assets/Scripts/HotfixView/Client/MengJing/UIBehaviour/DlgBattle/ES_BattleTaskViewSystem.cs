using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_BattleTaskItem))]
    [EntitySystemOf(typeof (ES_BattleTask))]
    [FriendOfAttribute(typeof (ES_BattleTask))]
    public static partial class ES_BattleTaskSystem
    {
        [EntitySystem]
        private static void Awake(this ES_BattleTask self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BattleTaskItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBattleTaskItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_BattleTask self)
        {
            self.DestroyWidget();
        }

        private static void OnBattleTaskItemsRefresh(this ES_BattleTask self, Transform transform, int index)
        {
            foreach (Scroll_Item_BattleTaskItem item in self.ScrollItemBattleTaskItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_BattleTaskItem scrollItemBattleTaskItem = self.ScrollItemBattleTaskItems[index].BindTrans(transform);
            scrollItemBattleTaskItem.OnUpdateData(self.ShowTaskPro[index]);
        }

        public static void OnUpdateUI(this ES_BattleTask self)
        {
            self.UpdateTaskCountrys();
        }

        public static void UpdateTaskCountrys(this ES_BattleTask self)
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

            self.ShowTaskPro.Clear();

            for (int i = 0; i < taskPros.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                if (taskConfig.TaskType != TaskTypeEnum.Battle)
                {
                    continue;
                }

                self.ShowTaskPro.Add(taskPros[i]);
            }

            // 测试数据
            // self.ShowTaskPro.Add(new TaskPro() { taskID = 200001, taskStatus = (int)TaskStatuEnum.Completed });
            // self.ShowTaskPro.Add(new TaskPro() { taskID = 200002, taskStatus = (int)TaskStatuEnum.Accepted });

            self.AddUIScrollItems(ref self.ScrollItemBattleTaskItems, self.ShowTaskPro.Count);
            self.E_BattleTaskItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPro.Count);
        }
    }
}
