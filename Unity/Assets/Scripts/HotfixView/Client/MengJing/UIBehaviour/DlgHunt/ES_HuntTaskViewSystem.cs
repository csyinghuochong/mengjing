using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_HuntTaskItem))]
    [EntitySystemOf(typeof (ES_HuntTask))]
    [FriendOfAttribute(typeof (ES_HuntTask))]
    public static partial class ES_HuntTaskSystem
    {
        [EntitySystem]
        private static void Awake(this ES_HuntTask self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_HuntTaskItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnHuntTaskItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_HuntTask self)
        {
            self.DestroyWidget();
        }

        private static void OnHuntTaskItemsRefresh(this ES_HuntTask self, Transform transform, int index)
        {
            foreach (Scroll_Item_HuntTaskItem item in self.ScrollItemHuntTaskItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_HuntTaskItem scrollItemHuntTaskItem = self.ScrollItemHuntTaskItems[index].BindTrans(transform);
            scrollItemHuntTaskItem.OnUpdateData(self.ShowTaskPro[index]);
        }

        public static void OnUpdateUI(this ES_HuntTask self)
        {
            self.UpdateTaskCountrys();
        }

        public static void UpdateTaskCountrys(this ES_HuntTask self)
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
                if (taskConfig.TaskType != TaskTypeEnum.ShowLie)
                {
                    continue;
                }

                self.ShowTaskPro.Add(taskPros[i]);
            }

            // 测试数据
            // self.ShowTaskPro.Add(new TaskPro() { taskID = 300001, taskStatus = (int)TaskStatuEnum.Completed });
            // self.ShowTaskPro.Add(new TaskPro() { taskID = 300002, taskStatus = (int)TaskStatuEnum.Accepted });

            self.AddUIScrollItems(ref self.ScrollItemHuntTaskItems, self.ShowTaskPro.Count);
            self.E_HuntTaskItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPro.Count);
        }
    }
}
