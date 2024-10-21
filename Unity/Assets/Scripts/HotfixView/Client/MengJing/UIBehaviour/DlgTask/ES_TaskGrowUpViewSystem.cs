using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TaskGrowUpItem))]
    [EntitySystemOf(typeof(ES_TaskGrowUp))]
    [FriendOfAttribute(typeof(ES_TaskGrowUp))]
    public static partial class ES_TaskGrowUpSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TaskGrowUp self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_TaskGrowUpItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTaskGrowUpItemsRefresh);
            self.E_GetBtnButton.AddListenerAsync(self.OnGetBtnButton);
            self.E_GiveBtnButton.AddListenerAsync(self.OnGiveBtnButton);

            self.UpdateTask();
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskGrowUp self)
        {
            self.DestroyWidget();
        }

        private static void OnTaskGrowUpItemsRefresh(this ES_TaskGrowUp self, Transform transform, int index)
        {
            Scroll_Item_TaskGrowUpItem scrollItemTaskGrowUpItem = self.ScrollItemTaskGrowUpItems[index].BindTrans(transform);
            int i = index % 4;
            Vector3 posi = Vector3.zero;
            int dre = 1;
            if (i == 0)
            {
                posi = new Vector3(-250, 0, 0);
                dre = 1;
            }
            else if (i == 1)
            {
                posi = new Vector3(0, 0, 0);
                dre = 1;
            }
            else if (i == 2)
            {
                posi = new Vector3(250, 0, 0);
                dre = -1;
            }
            else if (i == 3)
            {
                posi = new Vector3(0, 0, 0);
                dre = -1;
            }

            scrollItemTaskGrowUpItem.EG_ItemRectTransform.localPosition = posi;
            if (dre == 1)
            {
                scrollItemTaskGrowUpItem.E_Img_lineImage.transform.GetComponent<RectTransform>().localPosition = new Vector3(87, -42, 0);
                scrollItemTaskGrowUpItem.E_Img_lineImage.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 150);
                scrollItemTaskGrowUpItem.E_Img_lineDiImage.transform.GetComponent<RectTransform>().localPosition = new Vector3(87, -42, 0);
                scrollItemTaskGrowUpItem.E_Img_lineDiImage.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 150);
            }
            else
            {
                scrollItemTaskGrowUpItem.E_Img_lineImage.transform.GetComponent<RectTransform>().localPosition = new Vector3(-124, -64, 0);
                scrollItemTaskGrowUpItem.E_Img_lineImage.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -150);
                scrollItemTaskGrowUpItem.E_Img_lineDiImage.transform.GetComponent<RectTransform>().localPosition = new Vector3(-124, -64, 0);
                scrollItemTaskGrowUpItem.E_Img_lineDiImage.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -150);
            }

            scrollItemTaskGrowUpItem.OnUpdateData(self.ShowTaskConfigIds[index]);
            scrollItemTaskGrowUpItem.E_SeasonIconImage.material = null;
            scrollItemTaskGrowUpItem.E_Img_lineImage.gameObject.SetActive(true);
            scrollItemTaskGrowUpItem.E_Img_lineDiImage.gameObject.SetActive(true);

            if (self.ShowTaskConfigIds[index] > self.TaskPro.taskID)
            {
                scrollItemTaskGrowUpItem.E_SeasonIconImage.material = self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
                scrollItemTaskGrowUpItem.E_Img_lineImage.gameObject.SetActive(false);
            }

            if (self.ShowTaskConfigIds[index] == self.TaskPro.taskID)
            {
                scrollItemTaskGrowUpItem.E_Img_lineImage.gameObject.SetActive(false);
            }

            // 尾巴隐藏
            if (self.ShowTaskConfigIds.Count > 0 && index == self.ShowTaskConfigIds.Count - 1)
            {
                scrollItemTaskGrowUpItem.E_Img_lineImage.gameObject.SetActive(false);
                scrollItemTaskGrowUpItem.E_Img_lineDiImage.gameObject.SetActive(false);
            }
        }

        public static void UpdateTask(this ES_TaskGrowUp self)
        {
            // self.CompeletTaskId =
            //         (int)UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()[NumericType.SystemTask];
            // 测试
            self.CompeletTaskId = 82000014;

            List<TaskPro> taskPros = self.Root().GetComponent<TaskComponentC>().RoleTaskList;
            for (int i = 0; i < taskPros.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                if (taskConfig.TaskType == TaskTypeEnum.System)
                {
                    self.TaskPro = taskPros[i];
                    break;
                }
            }

            if (self.TaskPro == null && self.CompeletTaskId > 0)
            {
                TaskPro taskPro = TaskPro.Create();
                taskPro.taskID = self.CompeletTaskId;
                self.TaskPro = taskPro;
            }

            int index = 0;

            self.ShowTaskConfigIds.Clear();
            foreach (TaskConfig taskConfig in TaskConfigCategory.Instance.GetAll().Values)
            {
                if (taskConfig.TaskType == TaskTypeEnum.System)
                {
                    self.ShowTaskConfigIds.Add(taskConfig.Id);

                    if (taskConfig.Id == self.TaskPro.taskID)
                    {
                        index = self.ShowTaskConfigIds.Count;
                    }
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemTaskGrowUpItems, self.ShowTaskConfigIds.Count);
            self.E_TaskGrowUpItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskConfigIds.Count);

            self.UpdateInfo(self.TaskPro.taskID);

            // 滑动到对应位置
            Vector3 vector3 = self.E_TaskGrowUpItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>().localPosition;
            vector3.y = index * 160;
            self.E_TaskGrowUpItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>().localPosition = vector3;
        }

        public static void UpdateInfo(this ES_TaskGrowUp self, int taskId)
        {
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            self.E_TaskNameTextText.text = taskConfig.TaskName;
            if (taskId < self.TaskPro.taskID || (taskId == self.TaskPro.taskID && taskId == self.CompeletTaskId))
            {
                // 已经完成
                if (taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 ||
                    taskConfig.TargetType == (int)TaskTargetType.GivePet_25 ||
                    taskConfig.TargetType == (int)TaskTargetType.TeamDungeonHurt_136 ||
                    taskConfig.TargetType == (int)TaskTargetType.JianDingAttrNumber_43 ||
                    taskConfig.TargetType == (int)TaskTargetType.MakeQulityNumber_29)
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}: 1/1", LanguageComponent.Instance.LoadLocalization("当前进度值"));
                    }
                }
                else
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}: {1}/{2}",
                            LanguageComponent.Instance.LoadLocalization("当前进度值"),
                            taskConfig.TargetValue[0], taskConfig.TargetValue[0]);
                    }
                }

                self.E_AcvityedImgImage.gameObject.SetActive(true);
                self.E_GetBtnButton.gameObject.SetActive(false);
                self.E_GiveBtnButton.gameObject.SetActive(false);
            }
            else
            {
                // 进行中
                if (taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 || taskConfig.TargetType == (int)TaskTargetType.GivePet_25)
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}: 0/1", LanguageComponent.Instance.LoadLocalization("当前进度值"));
                    }

                    self.E_GetBtnButton.gameObject.SetActive(false);
                    self.E_GiveBtnButton.gameObject.SetActive(true);
                }
                else if (taskConfig.TargetType == (int)TaskTargetType.JianDingAttrNumber_43 ||
                         taskConfig.TargetType == (int)TaskTargetType.TeamDungeonHurt_136 ||
                         taskConfig.TargetType == (int)TaskTargetType.MakeQulityNumber_29)
                {
                    if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Completed)
                    {
                        using (zstring.Block())
                        {
                            self.E_ProgressTextText.text = zstring.Format("{0}: 1/1", LanguageComponent.Instance.LoadLocalization("当前进度值"));
                        }

                        self.E_GetBtnButton.gameObject.SetActive(true);
                        self.E_GiveBtnButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        using (zstring.Block())
                        {
                            self.E_ProgressTextText.text = zstring.Format("{0}: 0/1", LanguageComponent.Instance.LoadLocalization("当前进度值"));
                        }

                        self.E_GetBtnButton.gameObject.SetActive(true);
                        self.E_GiveBtnButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    using (zstring.Block())
                    {
                        self.E_ProgressTextText.text = zstring.Format("{0}: {1}/{2}",
                            LanguageComponent.Instance.LoadLocalization("当前进度值"),
                            self.TaskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
                    }

                    self.E_GetBtnButton.gameObject.SetActive(true);
                    self.E_GiveBtnButton.gameObject.SetActive(false);
                }

                if (taskId > self.TaskPro.taskID)
                {
                    self.E_GetBtnButton.gameObject.SetActive(false);
                    self.E_GiveBtnButton.gameObject.SetActive(false);
                }

                self.E_AcvityedImgImage.gameObject.SetActive(false);
            }

            self.E_TaskDescTextText.text = taskConfig.TaskDes;

            List<RewardItem> rewardItems = new List<RewardItem>();
            if (taskConfig.TaskCoin != 0)
            {
                rewardItems.Add(new RewardItem() { ItemID = 1, ItemNum = taskConfig.TaskCoin });
            }

            if (taskConfig.TaskExp != 0)
            {
                rewardItems.Add(new RewardItem() { ItemID = 2, ItemNum = taskConfig.TaskExp });
            }

            rewardItems.AddRange(TaskHelper.GetTaskRewards(taskId));
            self.ES_RewardList.Refresh(rewardItems);

            for (int i = 0; i < self.ScrollItemTaskGrowUpItems.Count; i++)
            {
                Scroll_Item_TaskGrowUpItem scrollItemTaskGrowUpItem = self.ScrollItemTaskGrowUpItems[i];
                if (scrollItemTaskGrowUpItem.uiTransform != null)
                {
                    scrollItemTaskGrowUpItem.Selected(taskId);
                }
            }
        }

        public static async ETTask OnGetBtnButton(this ES_TaskGrowUp self)
        {
            if (self.TaskPro.taskStatus < (int)TaskStatuEnum.Completed)
            {
                FlyTipComponent.Instance.ShowFlyTip("任务还没有完成！");
                return;
            }

            if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Commited)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取过奖励！");
                return;
            }

            await TaskClientNetHelper.RequestCommitTask(self.Root(), self.TaskPro.taskID, 0);
            self.UpdateTask();
        }

        public static async ETTask OnGiveBtnButton(this ES_TaskGrowUp self)
        {
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.TaskPro.taskID);
            if (taskConfig.TargetType == TaskTargetType.GiveItem_10)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GiveTask);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGiveTask>().InitTask(self.TaskPro.taskID);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGiveTask>().OnGiveAction = self.UpdateTaskB;
            }
            else if (taskConfig.TargetType == TaskTargetType.GivePet_25)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GiveTask);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGivePet>().InitTask(self.TaskPro.taskID);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgGivePet>().OnGiveAction = self.UpdateTaskB;
            }
        }

        public static void UpdateTaskB(this ES_TaskGrowUp self)
        {
            self.UpdateTask();
        }
    }
}
