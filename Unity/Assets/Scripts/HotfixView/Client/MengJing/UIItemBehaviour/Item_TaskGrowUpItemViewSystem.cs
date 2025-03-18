using UnityEngine;

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
            self.E_TextNameText.text = taskConfig.TaskName;
            self.EG_Completed.gameObject.SetActive(false);
            self.EG_Lock.gameObject.SetActive(false);   
        }

        public static void Selected(this Scroll_Item_TaskGrowUpItem self, int taskId)
        {
     
        }

        public static void SetCurId(this Scroll_Item_TaskGrowUpItem self, int curId)
        {
            if (self.TaskId > curId)
            {
                self.SetLocked(true);
            }
            else if (self.TaskId  == curId)
            {
                self.SetOpened();
            }
            else
            {
                self.SetCompleted();
            }
        }

        public static void SetLocked(this Scroll_Item_TaskGrowUpItem self, bool locked)
        {
            self.E_SeasonIconImage.material = locked ? self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui")) : null;
            self.EG_Lock.gameObject.SetActive(locked);    
        }
        
        public static void SetOpened(this Scroll_Item_TaskGrowUpItem self)
        {
            self.E_SeasonIconImage.material = null;
            self.EG_Lock.gameObject.SetActive(false);    
        }
        
        public static void SetCompleted(this Scroll_Item_TaskGrowUpItem self)
        {
            self.E_SeasonIconImage.material = null;
            self.EG_Lock.gameObject.SetActive(false);    
            self.EG_Completed.gameObject.SetActive(true);
        }
    }
}