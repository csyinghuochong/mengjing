using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_TaskTypeItem))]
    [EntitySystemOf(typeof (Scroll_Item_TaskTypeItem))]
    public static partial class Scroll_Item_TaskTypeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_TaskTypeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_TaskTypeItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_TaskTypeItem self, TaskPro taskPro, Action<int> onClickAction)
        {
            self.TaskPro = taskPro;

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
            self.E_HighlightImage.gameObject.SetActive(false);
            self.E_TaskNameText.text = taskConfig.TaskName;
            self.E_GoingImage.gameObject.SetActive(taskPro.taskStatus != (int)TaskStatuEnum.Completed);
            self.E_CompleteImage.gameObject.SetActive(taskPro.taskStatus == (int)TaskStatuEnum.Completed);

            self.E_ClickButton.AddListener(() =>
            {
                onClickAction?.Invoke(self.TaskPro.taskID);
                // 抛事件，通知任务面板刷新
                Log.Info($"点击任务：{taskConfig.TaskName}");
            });
        }

        public static void UpdateHighlight(this Scroll_Item_TaskTypeItem self, int taskConfigId)
        {
            self.E_HighlightImage.gameObject.SetActive(self.TaskPro.taskID == taskConfigId);
        }
    }
}