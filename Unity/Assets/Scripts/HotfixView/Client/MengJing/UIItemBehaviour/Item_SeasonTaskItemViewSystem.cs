using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SeasonTaskItem))]
    [EntitySystemOf(typeof(Scroll_Item_SeasonTaskItem))]
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

            self.E_SeasonIconButton.onClick.RemoveAllListeners();
            self.E_SeasonIconButton.onClick.AddListener(() => { self.GetParent<ES_SeasonTask>().UpdateInfo(self.TaskId); });
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            self.E_TextNameText.text = taskConfig.TaskName;
            self.EG_CompletedRectTransform.gameObject.SetActive(false);
            self.EG_LockRectTransform.gameObject.SetActive(false);
        }

        public static void Selected(this Scroll_Item_SeasonTaskItem self, int taskId)
        {
        }

        public static void SetCurId(this Scroll_Item_SeasonTaskItem self, int curId)
        {
            if (self.TaskId > curId)
            {
                self.SetLocked(true);
            }
            else if (self.TaskId == curId)
            {
                self.SetOpened();
            }
            else
            {
                self.SetCompleted();
            }
        }

        public static void SetLocked(this Scroll_Item_SeasonTaskItem self, bool locked)
        {
            self.E_SeasonIconImage.material = locked ? self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui")) : null;
            self.EG_LockRectTransform.gameObject.SetActive(locked);
        }

        public static void SetOpened(this Scroll_Item_SeasonTaskItem self)
        {
            self.E_SeasonIconImage.material = null;
            self.EG_LockRectTransform.gameObject.SetActive(false);
        }

        public static void SetCompleted(this Scroll_Item_SeasonTaskItem self)
        {
            self.E_SeasonIconImage.material = null;
            self.EG_LockRectTransform.gameObject.SetActive(false);
            self.EG_CompletedRectTransform.gameObject.SetActive(true);
        }
    }
}