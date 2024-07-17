namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_SeasonTaskItem))]
    [EntitySystemOf(typeof (Scroll_Item_SeasonTaskItem))]
    public static partial class Scroll_Item_SeasonTaskItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SeasonTaskItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SeasonTaskItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateData(this Scroll_Item_SeasonTaskItem self, int taskId)
        {
            self.TaskId = taskId;

            self.E_SeasonIconButton.AddListener(() => { self.GetParent<ES_SeasonTask>().UpdateInfo(self.TaskId); });
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            self.E_TextText.text = taskConfig.TaskName;
            self.E_Img_lineImage.gameObject.SetActive(true);
        }

        public static void Selected(this Scroll_Item_SeasonTaskItem self, int taskId)
        {
            self.E_ScelectImgImage.gameObject.SetActive(self.TaskId == taskId);
        }
    }
}