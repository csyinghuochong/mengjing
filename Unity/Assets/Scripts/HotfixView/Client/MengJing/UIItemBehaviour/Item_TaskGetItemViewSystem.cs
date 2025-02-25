using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TaskGetItem))]
    [EntitySystemOf(typeof(Scroll_Item_TaskGetItem))]
    public static partial class Scroll_Item_TaskGetItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_TaskGetItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_TaskGetItem self)
        {
            self.DestroyWidget();
        }

        public static void InitData(this Scroll_Item_TaskGetItem self, int taskid)
        {
            self.E_ImageDiImage.gameObject.SetActive(true);
            self.E_ImageSelectImage.gameObject.SetActive(false);
            
            self.TaskId = taskid;
            TaskPro taskPro = self.Root().GetComponent<TaskComponentC>().GetTaskById(taskid);
            bool isCompleted = taskPro != null && taskPro.taskStatus == (int)TaskStatuEnum.Completed;
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
            if (!isCompleted)
            {
                self.E_TextTaskNameText.text = taskConfig.TaskName;
                self.E_TextTaskNameText.color = Color.white;
            }
            else
            {
                using (zstring.Block())
                {
                    self.E_TextTaskNameText.text = zstring.Format("{0}(已完成)", taskConfig.TaskName);
                }

                self.E_TextTaskNameText.color = new Color(131f / 255f, 255f / 255f, 83f / 255f);
            }

            self.E_ImageNotRecvImage.gameObject.SetActive(!isCompleted);
            self.E_ImageCompleteImage.gameObject.SetActive(isCompleted);
            self.E_ImageButtonButton.AddListener(self.OnClickSelectTask);
        }

        public static void SetSelected(this Scroll_Item_TaskGetItem self, int taskId)
        {
            self.E_ImageDiImage.gameObject.SetActive(self.TaskId != taskId);
            self.E_ImageSelectImage.gameObject.SetActive(self.TaskId == taskId);
        }

        public static void SetClickHandler(this Scroll_Item_TaskGetItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnClickSelectTask(this Scroll_Item_TaskGetItem self)
        {
            self.ClickHandler(self.TaskId);
        }
    }
}