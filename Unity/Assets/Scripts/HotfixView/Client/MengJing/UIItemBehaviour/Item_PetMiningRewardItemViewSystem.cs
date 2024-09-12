namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetMiningRewardItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetMiningRewardItem))]
    public static partial class Scroll_Item_PetMiningRewardItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetMiningRewardItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetMiningRewardItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonReward(this Scroll_Item_PetMiningRewardItem self)
        {
            if (self.TaskPro.taskStatus != (int)TaskStatuEnum.Completed)
            {
                FlyTipComponent.Instance.ShowFlyTip("任务未完成！");
                return;
            }

            int errorCode = await TaskClientNetHelper.RequestCommitTask(self.Root(), self.TaskPro.taskID, 0);
            if (errorCode == ErrorCode.ERR_Success)
            {
                self.E_ImageReceivedImage.gameObject.SetActive(true);
                self.E_ButtonRewardButton.gameObject.SetActive(false);
            }
        }

        public static void OnInitUI(this Scroll_Item_PetMiningRewardItem self, TaskPro taskPro)
        {
            self.E_ButtonRewardButton.AddListenerAsync(self.OnButtonReward);

            self.TaskPro = taskPro;
            TaskConfig taskCountryConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);

            self.E_Text_tipText.text = taskCountryConfig.TaskDes;
            using (zstring.Block())
            {
                self.E_Text_progressText.text = zstring.Format("{0}/{1}", taskPro.taskTargetNum_1, taskCountryConfig.TargetValue[0]);
            }

            self.E_ImageReceivedImage.gameObject.SetActive(taskPro.taskStatus == (int)TaskStatuEnum.Commited);
            self.E_ButtonRewardButton.gameObject.SetActive(taskPro.taskStatus != (int)TaskStatuEnum.Commited);

            self.ES_RewardList.Refresh(taskCountryConfig.RewardItem, 0.8f);
        }
    }
}