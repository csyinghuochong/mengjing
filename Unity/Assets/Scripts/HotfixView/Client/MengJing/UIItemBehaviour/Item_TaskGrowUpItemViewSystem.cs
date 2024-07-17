namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_TaskGrowUpItem))]
    [EntitySystemOf(typeof (Scroll_Item_TaskGrowUpItem))]
    public static partial class Scroll_Item_TaskGrowUpItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_TaskGrowUpItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_TaskGrowUpItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateData(this Scroll_Item_TaskGrowUpItem self, int taskId)
        {
            self.TaskId = taskId;

            self.E_SeasonIconButton.onClick.RemoveAllListeners();
            self.E_SeasonIconButton.onClick.AddListener(() => { self.GetParent<ES_TaskGrowUp>().UpdateInfo(self.TaskId); });
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            self.E_TextText.text = taskConfig.TaskName;
            self.E_Img_lineImage.gameObject.SetActive(true);
        }

        public static void Selected(this Scroll_Item_TaskGrowUpItem self, int taskId)
        {
            self.E_ScelectImgImage.gameObject.SetActive(self.TaskId == taskId);
        }
    }
}