using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_RankUnionTaskItem))]
    [EntitySystemOf(typeof (Scroll_Item_RankUnionTaskItem))]
    public static partial class Scroll_Item_RankUnionTaskItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RankUnionTaskItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RankUnionTaskItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateData(this Scroll_Item_RankUnionTaskItem self, TaskPro taskPro)
        {
            self.E_ButtonReceiveButton.AddListener(self.OnBtn_Receive);

            self.TaskPro = taskPro;
            TaskCountryConfig taskConfig = TaskCountryConfigCategory.Instance.Get(taskPro.taskID);
            if (!ComHelp.IfNull(taskConfig.RewardItem))
            {
                self.ES_RewardList.Refresh(taskConfig.RewardItem, 0.8f);
            }

            self.E_TextTaskNameText.text = taskConfig.TaskName;
            self.E_TextTaskDescText.text = taskConfig.TaskDes;

            taskPro.taskTargetNum_1 = taskPro.taskTargetNum_1 > taskConfig.TargetValue[0]? taskConfig.TargetValue[0] : taskPro.taskTargetNum_1;
            self.E_TextTaskProgressText.text =
                    GameSettingLanguge.LoadLocalization("进度值") + ": " + $"{taskPro.taskTargetNum_1}/{taskConfig.TargetValue[0]}";

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TaskIcon, taskConfig.TaskIcon.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageIconImage.sprite = sp;

            self.E_ItemNumberText.text = " +" + taskConfig.RewardGold;

            self.E_TextHuoyueValueText.text = GameSettingLanguge.LoadLocalization("活跃度") + " +" + taskConfig.EveryTaskRewardNum;

            self.E_ButtonCompleteButton.gameObject.SetActive(taskPro.taskStatus == (int)TaskStatuEnum.Commited);
            self.E_ButtonReceiveButton.gameObject.SetActive(taskPro.taskStatus != (int)TaskStatuEnum.Commited);
        }

        public static void OnBtn_Receive(this Scroll_Item_RankUnionTaskItem self)
        {
            if (self.TaskPro.taskStatus < (int)TaskStatuEnum.Completed)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("任务还没有完成！");
                return;
            }

            if (self.TaskPro.taskStatus == (int)TaskStatuEnum.Commited)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("已经领取过奖励！");
                return;
            }

            TaskClientNetHelper.SendCommitTaskCountry(self.Root(), self.TaskPro.taskID).Coroutine();

            self.E_ButtonCompleteButton.gameObject.SetActive(true);
            self.E_ButtonReceiveButton.gameObject.SetActive(false);
        }
    }
}