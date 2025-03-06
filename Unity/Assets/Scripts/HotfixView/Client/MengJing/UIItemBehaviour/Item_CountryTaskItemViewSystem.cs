using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CountryTaskItem))]
    [EntitySystemOf(typeof(Scroll_Item_CountryTaskItem))]
    public static partial class Scroll_Item_CountryTaskItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CountryTaskItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CountryTaskItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateData(this Scroll_Item_CountryTaskItem self, TaskPro taskPro)
        {
            self.E_ButtonReceiveButton.AddListenerAsync(self.OnBtn_Receive);

            self.TaskPro = taskPro;
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);

            self.E_TextTaskNameText.text = taskConfig.TaskName;
            self.E_TextTaskDescText.text = taskConfig.TaskDes;

            taskPro.taskTargetNum_1 = taskPro.taskTargetNum_1 > taskConfig.TargetValue[0] ? taskConfig.TargetValue[0] : taskPro.taskTargetNum_1;
            using (zstring.Block())
            {
                self.E_TextTaskProgressText.text = zstring.Format("{0}: {1}/{2}", LanguageComponent.Instance.LoadLocalization("进度值"),
                    taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TaskIcon, taskConfig.TaskIcon.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ImageIconImage.sprite = sp;

            // foreach (string str in taskConfig.RewardItem.Split('@'))
            // {
            //     string[] reward = str.Split(',');
            //     if (reward[0] == "1")
            //     {
            //         using (zstring.Block())
            //         {
            //             self.E_ItemNumberText.text = zstring.Format(" +{0}", reward[1]);
            //         }
            //
            //         break;
            //     }
            // }

            using (zstring.Block())
            {
                zstring rewardItem = "1;" + taskConfig.TaskCoin;
                if (!CommonHelp.IfNull(taskConfig.RewardItem))
                {
                    rewardItem += "@" + taskConfig.RewardItem;
                }
                self.ES_RewardList.Refresh(rewardItem);
            }

            using (zstring.Block())
            {
                self.E_TextHuoyueValueText.text =
                        zstring.Format("{0} +{1}", LanguageComponent.Instance.LoadLocalization("活跃度"), taskConfig.EveryTaskRewardNum);
            }

            self.E_ButtonCompleteButton.gameObject.SetActive(taskPro.taskStatus == (int)TaskStatuEnum.Commited);
            self.E_ButtonReceiveButton.gameObject.SetActive(taskPro.taskStatus != (int)TaskStatuEnum.Commited);
        }

        public static async ETTask OnBtn_Receive(this Scroll_Item_CountryTaskItem self)
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

            long instanceid = self.InstanceId;
            int errorCode = await TaskClientNetHelper.RequestCommitTask(self.Root(), self.TaskPro.taskID, 0);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            if (errorCode == ErrorCode.ERR_Success)
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCountry>().OnUpdateRoleData();

                //显示领取
                self.E_ButtonCompleteButton.gameObject.SetActive(true);
                self.E_ButtonReceiveButton.gameObject.SetActive(false);
            }
        }
    }
}