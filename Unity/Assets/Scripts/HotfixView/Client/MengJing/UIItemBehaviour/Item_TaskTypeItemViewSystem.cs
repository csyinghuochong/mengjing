using System;

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

        public static void Refresh(this Scroll_Item_TaskTypeItem self, TaskPro taskPro)
        {
            self.TaskPro = taskPro;
            self.E_ClickButton.AddListener(self.OnClick);

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
            self.E_HighlightImage.gameObject.SetActive(false);
            self.E_TaskNameText.text = taskConfig.TaskName;
            self.E_GoingImage.gameObject.SetActive(taskPro.taskStatus != (int)TaskStatuEnum.Completed);
            self.E_CompleteImage.gameObject.SetActive(taskPro.taskStatus == (int)TaskStatuEnum.Completed);
        }

        public static void OnClick(this Scroll_Item_TaskTypeItem self)
        {
            self.GetParent<ES_TaskType>().UpdateHighlight(self.TaskPro.taskID);
            self.GetParent<ES_TaskType>().GetParent<ES_TaskDetail>().RefreshTaskInfo(self.TaskPro);
        }

        public static void UpdateHighlight(this Scroll_Item_TaskTypeItem self, int taskConfigId)
        {
            self.E_HighlightImage.gameObject.SetActive(self.TaskPro.taskID == taskConfigId);
        }
    }
}