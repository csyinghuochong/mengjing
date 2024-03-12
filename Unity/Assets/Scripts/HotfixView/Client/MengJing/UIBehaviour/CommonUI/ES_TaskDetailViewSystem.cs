using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
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

            self.EG_RightRectTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskDetail self)
        {
            self.DestroyWidget();
        }

        public static void RefreshTaskInfo(this ES_TaskDetail self, TaskPro taskPro)
        {
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
                UserInfoComponentClient userInfoComponent = self.Root().GetComponent<UserInfoComponentClient>();
                coffiexp = ComHelp.GetTaskExpRewardCof(userInfoComponent.UserInfo.Lv);
                cofficoin = ComHelp.GetTaskCoinRewardCof(userInfoComponent.UserInfo.Lv);
            }

            int taskExp = (int)(taskConfig.TaskExp * coffiexp);
            int taskCoin = (int)(taskConfig.TaskCoin * cofficoin);

            string rewardStr = taskConfig.ItemID;
            string rewardNum = taskConfig.ItemNum;
            if (ComHelp.IfNull(rewardStr))
            {
                rewardStr = "1;2";
                rewardNum = taskCoin + ";" + taskExp;
            }
            else
            {
                rewardStr = "1;2;" + rewardStr;
                rewardNum = taskCoin + ";" + taskExp + ";" + rewardNum;
            }

            string[] rewarditems = rewardStr.Split(';');
            string[] rewardItemNums = rewardNum.Split(';');

            List<RewardItem> rewardItems = new List<RewardItem>();
            for (int i = 0; i < rewarditems.Length; i++)
            {
                rewardItems.Add(new RewardItem() { ItemID = int.Parse(rewarditems[i]), ItemNum = int.Parse(rewardItemNums[i]) });
            }

            self.ES_RewardList.Refresh(rewardItems);

            self.EG_RightRectTransform.gameObject.SetActive(true);
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
    }
}