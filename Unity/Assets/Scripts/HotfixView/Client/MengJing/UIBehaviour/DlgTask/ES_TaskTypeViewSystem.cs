using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TaskTypeItem))]
    [EntitySystemOf(typeof(ES_TaskType))]
    [FriendOf(typeof(ES_TaskType))]
    public static partial class ES_TaskTypeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TaskType self, Transform transform)
        {
            self.uiTransform = transform;
            self.Height = self.uiTransform.GetComponent<RectTransform>().rect.height;
            self.E_Bg1Image.gameObject.SetActive(true);
            self.E_Bg2Image.gameObject.SetActive(false);
            self.E_TaskTypeName1Text.gameObject.SetActive(true);
            self.E_TaskTypeName2Text.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskType self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
            
            self.DestroyWidget();
        }

        public static void InitData(this ES_TaskType self, int taskType, Action<int> onClickAction)
        {
            self.TaskType = taskType;

            switch (taskType)
            {
                case TaskTypeEnum.Main:
                    self.E_TaskTypeName1Text.text = "主线任务";
                    self.E_TaskTypeName2Text.text = "主线任务";
                    break;
                case TaskTypeEnum.Branch:
                    self.E_TaskTypeName1Text.text = "支线任务";
                    self.E_TaskTypeName2Text.text = "支线任务";
                    break;
                case TaskTypeEnum.Daily:
                    self.E_TaskTypeName1Text.text = "每日任务";
                    self.E_TaskTypeName2Text.text = "每日任务";
                    break;
            }

            self.E_SelectButton.AddListener(() => { onClickAction?.Invoke(self.TaskType); });
        }

        public static void Expand(this ES_TaskType self)
        {
            self.IsExpand = true;
            self.E_Bg1Image.gameObject.SetActive(false);
            self.E_Bg2Image.gameObject.SetActive(true);
            self.E_TaskTypeName1Text.gameObject.SetActive(false);
            self.E_TaskTypeName2Text.gameObject.SetActive(true);
            self.Refresh();

            // 默认选第一个
            if (self.ShowTaskPros.Count > 0)
            {
                Scroll_Item_TaskTypeItem scrollItemTaskTypeItem = self.ScrollItemTaskTypeItems[0];
                scrollItemTaskTypeItem.OnClick();

                // // 模拟点击按钮
                // ExecuteEvents.Execute(scrollItemTaskTypeItem.E_ClickButton.gameObject,
                //     new PointerEventData(UnityEngine.EventSystems.EventSystem.current), ExecuteEvents.pointerClickHandler);
            }
            else
            {
                self.GetParent<ES_TaskDetail>().RefreshTaskInfo(null);
            }
        }

        public static void TalkUp(this ES_TaskType self)
        {
            self.IsExpand = false;
            self.E_Bg1Image.gameObject.SetActive(true);
            self.E_Bg2Image.gameObject.SetActive(false);
            self.E_TaskTypeName1Text.gameObject.SetActive(true);
            self.E_TaskTypeName2Text.gameObject.SetActive(false);
            self.EG_TaskTypeItemsRectTransform.gameObject.SetActive(false);
            self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(710, self.Height);

            // 刷新一下父物体
            LayoutRebuilder.ForceRebuildLayoutImmediate(self.uiTransform.parent.GetComponent<RectTransform>());
        }

        public static void UpdateHighlight(this ES_TaskType self, int taskId)
        {
            foreach (Scroll_Item_TaskTypeItem item in self.ScrollItemTaskTypeItems.Values)
            {
                if (item.uiTransform != null)
                {
                    item.UpdateHighlight(taskId);
                }
            }
        }

        private static void Refresh(this ES_TaskType self)
        {
            self.ShowTaskPros.Clear();

            TaskComponentC taskComponentC = self.Root().GetComponent<TaskComponentC>();
            self.ShowTaskPros = taskComponentC.GetTaskTypeList(self.TaskType);
            if (self.TaskType == TaskTypeEnum.Branch)
            {
            }

            if (self.TaskType == TaskTypeEnum.Daily)
            {
                self.ShowTaskPros.AddRange(taskComponentC.GetTaskTypeList(TaskTypeEnum.Treasure));
                self.ShowTaskPros.AddRange(taskComponentC.GetTaskTypeList(TaskTypeEnum.Union));
                self.ShowTaskPros.AddRange(taskComponentC.GetTaskTypeList(TaskTypeEnum.Ring));
                self.ShowTaskPros.AddRange(taskComponentC.GetTaskTypeList(TaskTypeEnum.Weekly));
            }
            
            self.EG_TaskTypeItemsRectTransform.gameObject.SetActive(true);
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowTaskPros.Count; i++)
            {
                if (!self.ScrollItemTaskTypeItems.ContainsKey(i))
                {
                    Scroll_Item_TaskTypeItem item = self.AddChild<Scroll_Item_TaskTypeItem>();
                    string path = "Assets/Bundles/UI/Item/Item_TaskTypeItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.EG_TaskTypeItemsRectTransform);
                    item.BindTrans(go.transform);
                    self.ScrollItemTaskTypeItems.Add(i, item);
                }

                Scroll_Item_TaskTypeItem scrollItemTaskTypeItem = self.ScrollItemTaskTypeItems[i];
                scrollItemTaskTypeItem.uiTransform.gameObject.SetActive(true);
                scrollItemTaskTypeItem.Refresh(self.ShowTaskPros[i]);
            }

            if (self.ScrollItemTaskTypeItems.Count > self.ShowTaskPros.Count)
            {
                for (int i = self.ShowTaskPros.Count; i < self.ScrollItemTaskTypeItems.Count; i++)
                {
                    Scroll_Item_TaskTypeItem scrollItemTaskTypeItem = self.ScrollItemTaskTypeItems[i];
                    scrollItemTaskTypeItem.uiTransform.gameObject.SetActive(false);
                }
            }
            
            // 设置高度
            self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(710, self.Height + 90 * self.ShowTaskPros.Count);

            // 刷新一下父物体
            LayoutRebuilder.ForceRebuildLayoutImmediate(self.uiTransform.parent.GetComponent<RectTransform>());
        }
    }
}