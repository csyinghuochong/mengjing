using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentC))]
    [EntitySystemOf(typeof (ES_TaskDetail))]
    [FriendOf(typeof (ES_TaskDetail))]
    public static partial class ES_TaskDetailSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TaskDetail self, Transform transform)
        {
            self.uiTransform = transform;

            self.ES_TaskType_0.InitData(TaskTypeEnum.Main, self.SetTalkUp);
            self.ES_TaskType_1.InitData(TaskTypeEnum.Branch, self.SetTalkUp);
            self.ES_TaskType_2.InitData(TaskTypeEnum.Daily, self.SetTalkUp);

            self.E_ZhuizongButton.AddListener(() => { self.OnTrackTask(true); });
            self.E_CancelZhuizongButton.AddListener(() => { self.OnTrackTask(false); });

            self.E_GiveupButton.AddListener(self.OnGiveupButton);
            self.E_GoingButton.AddListener(self.OnGoingButton);

            self.EG_RightRectTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskDetail self)
        {
            self.DestroyWidget();
        }

        public static void RefreshTaskInfo(this ES_TaskDetail self, TaskPro taskPro)
        {
            self.TaskPro = taskPro;

            if (taskPro == null)
            {
                self.EG_RightRectTransform.gameObject.SetActive(false);
                return;
            }

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);

            if (taskConfig.CompleteNpcID > 0)
            {
                string npcName = NpcConfigCategory.Instance.Get(taskConfig.CompleteNpcID).Name;
                self.E_ComTaskNpcText.text = $"完成任务请找:<color=#5C7B32>{npcName}</color>";
            }

            self.E_TeskDesText.text = taskConfig.TaskDes;

            self.E_TaskTargetText.text = TaskViewHelp.GetTaskProgessDesc(taskPro);

            self.E_ZhuizongButton.gameObject.SetActive(taskPro.TrackStatus == 0);
            self.E_CancelZhuizongButton.gameObject.SetActive(taskPro.TrackStatus == 1);

            float coffiexp = 1f;
            float cofficoin = 1f;
            if (taskConfig.Development == 1)
            {
                UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                coffiexp = CommonHelp.GetTaskExpRewardCof(userInfoComponent.UserInfo.Lv);
                cofficoin = CommonHelp.GetTaskCoinRewardCof(userInfoComponent.UserInfo.Lv);
            }

            int taskExp = (int)(taskConfig.TaskExp * coffiexp);
            int taskCoin = (int)(taskConfig.TaskCoin * cofficoin);

            string rewardStr = taskConfig.RewardItem;
            if (CommonHelp.IfNull(rewardStr))
            {
                rewardStr = $"1;{taskCoin}@2;{taskExp}";
            }
            else
            {
                rewardStr = $"1;{taskCoin}@2;{taskExp}@";
                rewardStr += rewardStr;
            }
            
            // 跑环任务显示对应的环数奖励
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int taskType = TaskConfigCategory.Instance.Get(taskPro.taskID).TaskType;
            int nowNum = 0;
            if (taskType == 5)
            {
                nowNum = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.WeeklyTaskNumber) + 1;

                if (nowNum != 0)
                {
                    if (ConfigData.WeekTaskDrop.ContainsKey(nowNum))
                    {
                        List<RewardItem> droplist = new List<RewardItem>();
                        DropHelper.DropIDToDropItem_2(ConfigData.WeekTaskDrop[nowNum], droplist);
                    }
                }
            }

            if (taskType == 10)
            {
                nowNum = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RingTaskNumber) + 1;

                if (nowNum != 0)
                {
                    if (ConfigData.RingTaskDrop.ContainsKey(nowNum))
                    {
                        List<RewardItem> droplist = new List<RewardItem>();
                        DropHelper.DropIDToDropItem_2(ConfigData.RingTaskDrop[nowNum], droplist);

                        if (droplist.Count > 0)
                        {
                            for (int i = 0; i < droplist.Count; i++)
                            {
                                
                            }
                        }
                    }
                }
            }

            List<RewardItem> rewardItems = ItemHelper.GetRewardItems(rewardStr);

            self.ES_RewardList.Refresh(rewardItems);

            self.EG_RightRectTransform.gameObject.SetActive(true);
        }

        private static void OnGiveupButton(this ES_TaskDetail self)
        {
            if (self.TaskPro == null)
                return;

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.TaskPro.taskID);
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            if (taskConfig.TaskType == (int)TaskTypeEnum.Main)
            {
                flyTipComponent.ShowFlyTipDi("主线任务不能放弃");
                return;
            }

            if (taskConfig.TaskType == TaskTypeEnum.Ring)
            {
                flyTipComponent.ShowFlyTipDi("跑环任务不能放弃");
                return;
            }

            TaskClientNetHelper.RequestGiveUpTask(self.Root(), self.TaskPro.taskID).Coroutine();
        }

        private static void OnGoingButton(this ES_TaskDetail self)
        {
            bool value = TaskViewHelp.ExcuteTask(self.Root(), self.TaskPro);
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.TaskPro.taskID);
            if (value && taskConfig.TaskType != TaskTypeEnum.Ring && taskConfig.TaskType != TaskTypeEnum.Union &&
                taskConfig.TaskType != TaskTypeEnum.Daily && taskConfig.TaskType != TaskTypeEnum.Treasure)
            {
                self.OnCloseTask();
            }
        }

        private static void OnCloseTask(this ES_TaskDetail self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Task);
        }

        private static void SetTalkUp(this ES_TaskDetail self, int taskType)
        {
            if (taskType != TaskTypeEnum.Main)
            {
                self.ES_TaskType_0.TalkUp();
            }

            if (taskType != TaskTypeEnum.Branch)
            {
                self.ES_TaskType_1.TalkUp();
            }

            if (taskType != TaskTypeEnum.Daily)
            {
                self.ES_TaskType_2.TalkUp();
            }
        }

        private static void OnTrackTask(this ES_TaskDetail self, bool track)
        {
            if (self.TaskPro == null)
            {
                return;
            }

            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            if (self.Root().GetComponent<TaskComponentC>().GetAllTrackList().Count >= 3 && track)
            {
                flyTipComponent.ShowFlyTipDi("追踪数量不能超过三个!");
                return;
            }

            TaskClientNetHelper.RequestTaskTrack(self.Root(), self.TaskPro.taskID, self.TaskPro.TrackStatus == 0? 1 : 0).Coroutine();

            self.E_ZhuizongButton.gameObject.SetActive(!self.E_ZhuizongButton.gameObject.activeSelf);
            self.E_CancelZhuizongButton.gameObject.SetActive(!self.E_CancelZhuizongButton.gameObject.activeSelf);

            // 提示
            flyTipComponent.ShowFlyTipDi(self.E_ZhuizongButton.gameObject.activeSelf == false? "任务开启追踪!" : "任务取消追踪!");
        }
    }
}