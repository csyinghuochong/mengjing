using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_TaskDetail))]
    [FriendOf(typeof (ES_TaskDetail))]
    public static partial class ES_TaskDetailSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TaskDetail self, Transform transform)
        {
            self.uiTransform = transform;

            self.ES_TaskType_0.InitData(TaskTypeEnum.Main, self.SetTalkUp);
            self.ES_TaskType_1.InitData(TaskTypeEnum.Branch, self.SetTalkUp);
            self.ES_TaskType_2.InitData(TaskTypeEnum.Daily, self.SetTalkUp);

            self.EG_RightRectTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskDetail self)
        {
            self.DestroyWidget();
        }

        public static void RefreshTaskInfo(this ES_TaskDetail self, TaskPro taskPro)
        {
            if (taskPro == null)
            {
                self.EG_RightRectTransform.gameObject.SetActive(false);
                return;
            }

            self.EG_RightRectTransform.gameObject.SetActive(true);

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);

            self.ES_RewardList.Refresh(new List<RewardItem>() { new() { ItemID = 1, ItemNum = 1 }, new() { ItemID = 2, ItemNum = 2 } });
            self.E_TeskDesText.text = taskConfig.TaskDes;
        }

        private static void SetTalkUp(this ES_TaskDetail self, int taskType)
        {
            if (taskType != TaskTypeEnum.Main)
            {
                self.ES_TaskType_0.TalkUp();
            }

            if (taskType != TaskTypeEnum.Branch)
            {
                self.ES_TaskType_1.TalkUp();
            }

            if (taskType != TaskTypeEnum.Daily)
            {
                self.ES_TaskType_2.TalkUp();
            }
        }
    }
}