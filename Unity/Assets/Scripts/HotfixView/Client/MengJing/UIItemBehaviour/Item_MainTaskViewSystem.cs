using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_MainTask))]
    [EntitySystemOf(typeof(Scroll_Item_MainTask))]
    public static partial class Scroll_Item_MainTaskSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_MainTask self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_MainTask self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_MainTask self, TaskPro taskPro)
        {
            self.TaskPro = taskPro;

            self.E_ClickButton.AddListener(() => { TaskViewHelp.ExcuteTask(self.Root(), self.TaskPro); });
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
            self.E_TaskNameText.text = taskConfig.TaskName;
            self.E_TaskTargetDesText.text = TaskViewHelp.GetTaskProgessDesc(taskPro);

            if (taskPro.taskStatus == (int)TaskStatuEnum.Completed)
            {
                self.E_TaskTargetDesText.color = Color.green;
                using (zstring.Block())
                {
                    self.E_TaskTargetDesText.text = zstring.Format("{0}({1})", self.E_TaskTargetDesText.text,
                        LanguageComponent.Instance.LoadLocalization("已完成"));
                }
            }
            else
            {
                self.E_TaskTargetDesText.color = Color.white;
            }
        }
    }
}