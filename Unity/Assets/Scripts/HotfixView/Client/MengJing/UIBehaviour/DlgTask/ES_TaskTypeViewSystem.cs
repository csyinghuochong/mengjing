using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_TaskTypeItem))]
    [EntitySystemOf(typeof (ES_TaskType))]
    [FriendOf(typeof (ES_TaskType))]
    public static partial class ES_TaskTypeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TaskType self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_TaskTypeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTaskTypeItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskType self)
        {
            self.DestroyWidget();
        }

        private static void OnSelectButton(this ES_TaskType self)
        {
            if (self.IsExpand)
            {
                self.TalkUp();
            }
            else
            {
                self.Expand();
            }
        }

        public static void InitData(this ES_TaskType self, int taskType, Action<int> onClickAction)
        {
            self.TaskType = taskType;

            switch (taskType)
            {
                case TaskTypeEnum.Main:
                    self.E_TaskTypeNameText.text = "主线任务";
                    break;
                case TaskTypeEnum.Branch:
                    self.E_TaskTypeNameText.text = "支线任务";
                    break;
                case TaskTypeEnum.Daily:
                    self.E_TaskTypeNameText.text = "每日任务";
                    break;
            }

            self.E_SelectButton.AddListener(() =>
            {
                onClickAction?.Invoke(self.TaskType);
                self.OnSelectButton();
            });
        }

        public static void Expand(this ES_TaskType self)
        {
            self.IsExpand = true;
            self.E_SelectImage.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            self.Refresh();

            // 默认选第一个
            if (self.ScrollItemTaskTypeItems.Values.Count > 0)
            {
                if (self.ScrollItemTaskTypeItems.Values.ToList()[0].uiTransform != null)
                {
                    ExecuteEvents.Execute(self.ScrollItemTaskTypeItems.Values.ToList()[0].E_ClickButton.gameObject,
                        new PointerEventData(UnityEngine.EventSystems.EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
            }
        }

        public static void TalkUp(this ES_TaskType self)
        {
            self.IsExpand = false;
            self.E_SelectImage.GetComponent<RectTransform>().localScale = new Vector3(1, -1, 1);
            self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 90f);
            self.E_TaskTypeItemsLoopVerticalScrollRect.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 1f);
            // 刷新一下父物体
            LayoutRebuilder.ForceRebuildLayoutImmediate(self.uiTransform.parent.GetComponent<RectTransform>());
        }

        private static void OnTaskTypeItemsRefresh(this ES_TaskType self, Transform transform, int index)
        {
            Scroll_Item_TaskTypeItem scrollItemTaskTypeItem = self.ScrollItemTaskTypeItems[index].BindTrans(transform);
            scrollItemTaskTypeItem.Refresh(self.ShowTaskPros[index], self.UpdateHighlight);
        }

        private static void UpdateHighlight(this ES_TaskType self, int taskId)
        {
            for (int i = 0; i < self.ScrollItemTaskTypeItems.Keys.Count - 1; i++)
            {
                if (self.ScrollItemTaskTypeItems[i].uiTransform != null)
                {
                    self.ScrollItemTaskTypeItems[i].UpdateHighlight(taskId);
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

            self.AddUIScrollItems(ref self.ScrollItemTaskTypeItems, self.ShowTaskPros.Count);
            self.E_TaskTypeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPros.Count);

            // 设置高度
            self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 90f + 90 * self.ShowTaskPros.Count);
            self.E_TaskTypeItemsLoopVerticalScrollRect.transform.GetComponent<RectTransform>().sizeDelta =
                    new Vector2(700, 1f + 90 * self.ShowTaskPros.Count);
            // 刷新一下父物体
            LayoutRebuilder.ForceRebuildLayoutImmediate(self.uiTransform.parent.GetComponent<RectTransform>());
        }
    }
}