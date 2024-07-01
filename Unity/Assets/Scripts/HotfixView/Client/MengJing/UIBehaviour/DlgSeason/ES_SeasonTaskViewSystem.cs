using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_SeasonTaskItem))]
    [FriendOf(typeof (Scroll_Item_SeasonDayTaskItem))]
    [EntitySystemOf(typeof (ES_SeasonTask))]
    [FriendOfAttribute(typeof (ES_SeasonTask))]
    public static partial class ES_SeasonTaskSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SeasonTask self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SeasonTaskItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSeasonTaskItemsRefresh);
            self.E_SeasonDayTaskItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSeasonDayTaskItemsRefresh);
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnFunctionSetBtn);

            self.E_GetBtnButton.AddListenerAsync(self.OnGetBtn);
            self.E_GiveBtnButton.AddListenerAsync(self.OnGiveBtn);

            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_SeasonTask self)
        {
            self.DestroyWidget();
        }

        private static void OnFunctionSetBtn(this ES_SeasonTask self, int index)
        {
            self.OnClickPageButton(index);
        }

        private static void OnSeasonTaskItemsRefresh(this ES_SeasonTask self, Transform transform, int index)
        {
            Scroll_Item_SeasonTaskItem scrollItemSeasonTaskItem = self.ScrollItemSeasonTaskItems[index].BindTrans(transform);
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

            scrollItemSeasonTaskItem.EG_ItemRectTransform.localPosition = posi;
            if (dre == 1)
            {
                scrollItemSeasonTaskItem.E_Img_lineImage.transform.GetComponent<RectTransform>().localPosition = new Vector3(87, -42, 0);
                scrollItemSeasonTaskItem.E_Img_lineImage.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 150);
                scrollItemSeasonTaskItem.E_Img_lineDiImage.transform.GetComponent<RectTransform>().localPosition = new Vector3(87, -42, 0);
                scrollItemSeasonTaskItem.E_Img_lineDiImage.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 150);
            }
            else
            {
                scrollItemSeasonTaskItem.E_Img_lineImage.transform.GetComponent<RectTransform>().localPosition = new Vector3(-124, -64, 0);
                scrollItemSeasonTaskItem.E_Img_lineImage.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -150);
                scrollItemSeasonTaskItem.E_Img_lineDiImage.transform.GetComponent<RectTransform>().localPosition = new Vector3(-124, -64, 0);
                scrollItemSeasonTaskItem.E_Img_lineDiImage.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -150);
            }

            scrollItemSeasonTaskItem.OnUpdateData(self.ShowTaskIds[index]);
            scrollItemSeasonTaskItem.E_SeasonIconImage.material = null;
            scrollItemSeasonTaskItem.E_Img_lineImage.gameObject.SetActive(true);
            scrollItemSeasonTaskItem.E_Img_lineDiImage.gameObject.SetActive(true);

            if (self.ShowTaskIds[index] > self.TaskPro.taskID)
            {
                scrollItemSeasonTaskItem.E_SeasonIconImage.material = self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
                scrollItemSeasonTaskItem.E_Img_lineImage.gameObject.SetActive(false);
            }

            if (self.ShowTaskIds[index] == self.TaskPro.taskID)
            {
                scrollItemSeasonTaskItem.E_Img_lineImage.gameObject.SetActive(false);
            }

            // 尾巴隐藏
            if (self.ShowTaskIds.Count > 0 && index == self.ShowTaskIds.Count - 1)
            {
                scrollItemSeasonTaskItem.E_Img_lineImage.gameObject.SetActive(false);
                scrollItemSeasonTaskItem.E_Img_lineDiImage.gameObject.SetActive(false);
            }
        }

        private static void OnSeasonDayTaskItemsRefresh(this ES_SeasonTask self, Transform transform, int index)
        {
            Scroll_Item_SeasonDayTaskItem scrollItemSeasonDayTaskItem = self.ScrollItemSeasonDayTaskItems[index].BindTrans(transform);
            scrollItemSeasonDayTaskItem.OnUpdateData(self.ShowTaskPros[index]);
        }

        public static void OnClickPageButton(this ES_SeasonTask self, int page)
        {
            self.TaskPro = null;
            if (page == 0)
            {
                self.TaskType = 1;

                self.E_SeasonTaskItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                self.E_SeasonDayTaskItemsLoopVerticalScrollRect.gameObject.SetActive(false);

                //赛季任务。  主任务面板要屏蔽赛季任务
                //服务器只记录当前的赛季任务。 小于此任务id的为已完成任务, 客户端需要显示所有的赛季任务
                // self.CompeletTaskId =
                //         (int)UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()[NumericType.SeasonTask];
                self.CompeletTaskId = 81000006;

                List<TaskPro> taskPros = self.Root().GetComponent<TaskComponentC>().RoleTaskList;
                for (int i = 0; i < taskPros.Count; i++)
                {
                    TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                    if (taskConfig.TaskType == TaskTypeEnum.Season)
                    {
                        self.TaskPro = taskPros[i];
                        break;
                    }
                }

                // 玩家身上没有赛季任务则可以任务全部完成
                if (self.TaskPro == null && self.CompeletTaskId > 0)
                {
                    self.TaskPro = new TaskPro() { taskID = self.CompeletTaskId };
                }

                int index = 0;
                self.ShowTaskIds.Clear();
                foreach (TaskConfig taskConfig in TaskConfigCategory.Instance.GetAll().Values)
                {
                    if (taskConfig.TaskType == TaskTypeEnum.Season)
                    {
                        self.ShowTaskIds.Add(taskConfig.Id);

                        if (self.TaskPro != null && taskConfig.Id == self.TaskPro.taskID)
                        {
                            index = self.ShowTaskIds.Count;
                        }
                    }
                }

                self.AddUIScrollItems(ref self.ScrollItemSeasonTaskItems, self.ShowTaskIds.Count);
                self.E_SeasonTaskItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskIds.Count);

                self.UpdateInfo(self.TaskPro.taskID);

                // 滑动到对应位置
                Vector3 vector3 = self.E_SeasonTaskItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>().localPosition;
                vector3.y = index * 160;
                self.E_SeasonTaskItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>().localPosition = vector3;
            }
            else
            {
                self.TaskType = 2;

                self.E_SeasonTaskItemsLoopVerticalScrollRect.gameObject.SetActive(false);
                self.E_SeasonDayTaskItemsLoopVerticalScrollRect.gameObject.SetActive(true);

                // 赛季每日任务
                // List<TaskPro> taskPros = self.Root().GetComponent<TaskComponentC>().TaskCountryList;

                List<TaskPro> taskPros = new();
                taskPros.Add(new TaskPro() { taskID = 600101, taskStatus = (int)TaskStatuEnum.Accepted });
                taskPros.Add(new TaskPro() { taskID = 600102, taskStatus = (int)TaskStatuEnum.Accepted });

                taskPros.Sort(delegate(TaskPro a, TaskPro b)
                {
                    int commita = a.taskStatus == (int)TaskStatuEnum.Commited? 1 : 0;
                    int commitb = b.taskStatus == (int)TaskStatuEnum.Commited? 1 : 0;
                    int completea = a.taskStatus == (int)TaskStatuEnum.Completed? 1 : 0;
                    int completeb = b.taskStatus == (int)TaskStatuEnum.Completed? 1 : 0;

                    if (commita == commitb)
                        return completeb - completea; //可以领取的在前
                    else
                        return commitb - commita; //已经完成的在前
                });

                TaskPro taskPro = null;
                self.ShowTaskPros.Clear();
                for (int i = 0; i < taskPros.Count; i++)
                {
                    TaskCountryConfig taskConfig = TaskCountryConfigCategory.Instance.Get(taskPros[i].taskID);
                    if (taskConfig.TaskType != TaskCountryType.Season)
                    {
                        continue;
                    }

                    if (taskPro == null && taskPros[i].taskStatus == (int)TaskStatuEnum.Completed)
                    {
                        taskPro = taskPros[i];
                    }

                    self.ShowTaskPros.Add(taskPros[i]);
                }

                self.AddUIScrollItems(ref self.ScrollItemSeasonDayTaskItems, self.ShowTaskPros.Count);
                self.E_SeasonDayTaskItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPros.Count);

                if (self.ScrollItemSeasonDayTaskItems != null)
                {
                    if (self.ScrollItemSeasonDayTaskItems.Count > 0)
                    {
                        self.UpdateInfo(taskPro ?? self.ScrollItemSeasonDayTaskItems[0].TaskPro);
                    }
                }
            }
        }

        /// <summary>
        /// 赛季每日任务信息
        /// </summary>
        /// <param name="self"></param>
        /// <param name="taskPro"></param>
        public static void UpdateInfo(this ES_SeasonTask self, TaskPro taskPro)
        {
            self.TaskPro = taskPro;
            TaskCountryConfig taskConfig = TaskCountryConfigCategory.Instance.Get(taskPro.taskID);

            self.E_TaskNameTextText.text = taskConfig.TaskName;
            // 已经完成
            if (taskPro.taskStatus == (int)TaskStatuEnum.Commited)
            {
                if (taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 ||
                    taskConfig.TargetType == (int)TaskTargetType.GivePet_25 ||
                    taskConfig.TargetType == (int)TaskTargetType.TeamDungeonHurt_136 ||
                    taskConfig.TargetType == (int)TaskTargetType.JianDingAttrNumber_43 ||
                    taskConfig.TargetType == (int)TaskTargetType.MakeQulityNumber_29)
                {
                    self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " + "1/1";
                }
                else
                {
                    self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " +
                            $"{taskPro.taskTargetNum_1}/{taskConfig.TargetValue[0]}";
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
                    self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " + "0/1";
                    self.E_GetBtnButton.gameObject.SetActive(false);
                    self.E_GiveBtnButton.gameObject.SetActive(true);
                }
                else if (taskConfig.TargetType == (int)TaskTargetType.JianDingAttrNumber_43 ||
                         taskConfig.TargetType == (int)TaskTargetType.TeamDungeonHurt_136 ||
                         taskConfig.TargetType == (int)TaskTargetType.MakeQulityNumber_29)
                {
                    if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Completed)
                    {
                        self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " + "1/1";
                        self.E_GetBtnButton.gameObject.SetActive(false);
                        self.E_GiveBtnButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " + "0/1";
                        self.E_GetBtnButton.gameObject.SetActive(true);
                        self.E_GiveBtnButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " +
                            $"{self.TaskPro.taskTargetNum_1}/{taskConfig.TargetValue[0]}";
                    self.E_GetBtnButton.gameObject.SetActive(true);
                    self.E_GiveBtnButton.gameObject.SetActive(false);
                }

                self.E_AcvityedImgImage.gameObject.SetActive(false);
            }

            self.E_TaskDescTextText.text = taskConfig.TaskDes;
            if (!CommonHelp.IfNull(taskConfig.RewardItem))
            {
                self.ES_RewardList.Refresh(taskConfig.RewardItem, 0.8f);
            }
        }

        /// <summary>
        /// 赛季任务信息
        /// </summary>
        /// <param name="self"></param>
        /// <param name="taskId"></param>
        public static void UpdateInfo(this ES_SeasonTask self, int taskId)
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
                    self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " + "1/1";
                }
                else
                {
                    self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " +
                            $"{taskConfig.TargetValue[0]}/{taskConfig.TargetValue[0]}";
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
                    self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " + "0/1";
                    self.E_GetBtnButton.gameObject.SetActive(false);
                    self.E_GiveBtnButton.gameObject.SetActive(true);
                }
                else if (taskConfig.TargetType == (int)TaskTargetType.JianDingAttrNumber_43 ||
                         taskConfig.TargetType == (int)TaskTargetType.TeamDungeonHurt_136 ||
                         taskConfig.TargetType == (int)TaskTargetType.MakeQulityNumber_29)
                {
                    if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Completed)
                    {
                        self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " + "1/1";
                        self.E_GetBtnButton.gameObject.SetActive(true);
                        self.E_GiveBtnButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " + "0/1";
                        self.E_GetBtnButton.gameObject.SetActive(true);
                        self.E_GiveBtnButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    self.E_ProgressTextText.text = GameSettingLanguge.LoadLocalization("当前进度值") + ": " +
                            $"{self.TaskPro.taskTargetNum_1}/{taskConfig.TargetValue[0]}";
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
            if (!CommonHelp.IfNull(taskConfig.ItemID))
            {
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
                self.ES_RewardList.Refresh(rewardItems, 0.8f);
            }

            if (self.ScrollItemSeasonTaskItems != null)
            {
                foreach (Scroll_Item_SeasonTaskItem item in self.ScrollItemSeasonTaskItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.Selected(taskId);
                }
            }
        }

        public static async ETTask OnGetBtn(this ES_SeasonTask self)
        {
            if (self.TaskPro.taskStatus < (int)TaskStatuEnum.Completed)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("任务还没有完成！");
                return;
            }

            if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Commited)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("已经领取过奖励！");
                return;
            }

            if (self.TaskType == 1)
            {
                await TaskClientNetHelper.RequestCommitTask(self.Root(), self.TaskPro.taskID, 0);
                self.OnClickPageButton(0);
            }
            else
            {
                int error = await TaskClientNetHelper.SendCommitTaskCountry(self.Root(), self.TaskPro.taskID);
                if (error == ErrorCode.ERR_Success)
                {
                    self.OnClickPageButton(1);
                }
            }
        }

        public static async ETTask OnGiveBtn(this ES_SeasonTask self)
        {
            if (self.TaskType == 1)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.TaskPro.taskID);
                if (taskConfig.TargetType == (int)TaskTargetType.GiveItem_10)
                {
                    // UI ui = await UIHelper.Create(self.ZoneScene(), UIType.UIGiveTask);
                    // ui.GetComponent<UIGiveTaskComponent>().InitTask(self.TaskPro.taskID, 1);
                    // ui.GetComponent<UIGiveTaskComponent>().OnGiveAction = self.UpdateSeasonTask;
                }
                else if (taskConfig.TargetType == (int)TaskTargetType.GivePet_25)
                {
                    // UI ui = await UIHelper.Create(self.ZoneScene(), UIType.UIGivePet);
                    // ui.GetComponent<UIGivePetComponent>().InitTask(self.TaskPro.taskID, 1);
                    // ui.GetComponent<UIGivePetComponent>().OnUpdateUI();
                    // ui.GetComponent<UIGivePetComponent>().OnGiveAction = self.UpdateSeasonTask;
                }
            }
            else
            {
                TaskCountryConfig taskCountryConfig = TaskCountryConfigCategory.Instance.Get(self.TaskPro.taskID);
                if (taskCountryConfig.TargetType == (int)TaskTargetType.GiveItem_10)
                {
                    // UI ui = await UIHelper.Create(self.ZoneScene(), UIType.UIGiveTask);
                    // ui.GetComponent<UIGiveTaskComponent>().InitTask(self.TaskPro.taskID, 2);
                    // ui.GetComponent<UIGiveTaskComponent>().OnGiveAction = self.UpdateSeasonDayTask;
                }
                else if (taskCountryConfig.TargetType == (int)TaskTargetType.GivePet_25)
                {
                    // UI ui = await UIHelper.Create(self.ZoneScene(), UIType.UIGivePet);
                    // ui.GetComponent<UIGivePetComponent>().InitTask(self.TaskPro.taskID, 2);
                    // ui.GetComponent<UIGivePetComponent>().OnUpdateUI();
                    // ui.GetComponent<UIGivePetComponent>().OnGiveAction = self.UpdateSeasonDayTask;
                }
            }

            await ETTask.CompletedTask;
        }

        public static void UpdateSeasonTask(this ES_SeasonTask self)
        {
            self.OnClickPageButton(0);
        }

        public static void UpdateSeasonDayTask(this ES_SeasonTask self)
        {
            self.OnClickPageButton(1);
        }
    }
}