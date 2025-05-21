using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGet_TaskDetailRefresh : AEvent<Scene, TaskGet>
    {
        protected override async ETTask Run(Scene scene, TaskGet args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTask>()?.View.ES_TaskDetail.SetExpand(TaskTypeEnum.Daily);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskUpdate_TaskDetailRefresh : AEvent<Scene, TaskUpdate>
    {
        protected override async ETTask Run(Scene scene, TaskUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTask>()?.View.ES_TaskDetail.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskComplete_TaskDetailRefresh : AEvent<Scene, TaskComplete>
    {
        protected override async ETTask Run(Scene scene, TaskComplete args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTask>()?.View.ES_TaskDetail.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGiveUp_TaskDetailRefresh : AEvent<Scene, TaskGiveUp>
    {
        protected override async ETTask Run(Scene scene, TaskGiveUp args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTask>()?.View.ES_TaskDetail.ReExpand();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_TaskType))]
    [FriendOf(typeof(UserInfoComponentC))]
    [EntitySystemOf(typeof(ES_TaskDetail))]
    [FriendOf(typeof(ES_TaskDetail))]
    public static partial class ES_TaskDetailSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TaskDetail self, Transform transform)
        {
            self.uiTransform = transform;

            GameObject go1 = UnityEngine.Object.Instantiate(self.ES_TaskType_0.uiTransform.gameObject, self.ES_TaskType_0.uiTransform.parent);
            go1.name = "ES_TaskType_1";
            GameObject go2 = UnityEngine.Object.Instantiate(self.ES_TaskType_0.uiTransform.gameObject, self.ES_TaskType_0.uiTransform.parent);
            go2.name = "ES_TaskType_2";

            self.ES_TaskType_1 = self.AddChild<ES_TaskType, Transform>(go1.transform);
            self.ES_TaskType_2 = self.AddChild<ES_TaskType, Transform>(go2.transform);
            
            self.ES_TaskType_0.InitData(TaskTypeEnum.Main, self.SetExpand);
            self.ES_TaskType_1.InitData(TaskTypeEnum.Branch, self.SetExpand);
            self.ES_TaskType_2.InitData(TaskTypeEnum.Daily, self.SetExpand);

            self.E_ZhuizongButton.AddListener(() => { self.OnTrackTask(true); });
            self.E_CancelZhuizongButton.AddListener(() => { self.OnTrackTask(false); });

            self.E_GiveupButton.AddListener(self.OnGiveupButton);
            self.E_GoingButton.AddListener(self.OnGoingButton);

            self.EG_RightRectTransform.gameObject.SetActive(false);

            self.OnSelectMain().Coroutine();
        }

        private static async  ETTask OnSelectMain(this ES_TaskDetail self)
        {
            // ExecuteEvents.Execute(scrollItemTaskTypeItem.E_ClickButton.gameObject,
            //new PointerEventData(UnityEngine.EventSystems.EventSystem.current), ExecuteEvents.pointerClickHandler);
            // 这个貌似有点问题， 先延迟一帧
            await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
            self.SetExpand(TaskTypeEnum.Main);
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskDetail self)
        {
            self.DestroyWidget();
        }

        public static void ReExpand(this ES_TaskDetail self)
        {
            if (self.ES_TaskType_0.IsExpand)
            {
                self.ES_TaskType_0.Expand();
            }

            if (self.ES_TaskType_1.IsExpand)
            {
                self.ES_TaskType_1.Expand();
            }

            if (self.ES_TaskType_2.IsExpand)
            {
                self.ES_TaskType_2.Expand();
            }
        }

        public static void OnRecvTaskUpdate(this ES_TaskDetail self)
        {
            TaskPro taskPro = self.Root().GetComponent<TaskComponentC>().GetTaskById(self.TaskId);

            if (taskPro == null)
            {
                self.ReExpand();
            }
            else
            {
                self.RefreshTaskInfo(taskPro);
            }
        }

        public static void RefreshTaskInfo(this ES_TaskDetail self, TaskPro taskPro)
        {
            self.TaskPro = taskPro;

            if (taskPro == null)
            {
                self.EG_RightRectTransform.gameObject.SetActive(false);

                return;
            }
            
            self.EG_RightRectTransform.gameObject.SetActive(true);

            self.TaskId = taskPro.taskID;

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);

            // if (taskConfig.CompleteNpcID > 0)
            // {
            //     string npcName = NpcConfigCategory.Instance.Get(taskConfig.CompleteNpcID).Name;
            //     using (zstring.Block())
            //     {
            //         self.E_ComTaskNpcText.text = zstring.Format("完成任务请找:<color=#5C7B32>{0}</color>", npcName);
            //     }
            // }

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
                rewardStr += $"@1;{taskCoin}@2;{taskExp}";
            }

            // 跑环任务显示对应的环数奖励
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int taskType = taskConfig.TaskType;
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

            self.ES_RewardList.Refresh(rewardItems, showNumber: true, showName: true, showNameOutline: false);

            self.E_GoingButton.transform.GetComponentInChildren<Text>().text = "前往任务";
            if (taskConfig.TargetType == TaskTargetType.GiveItem_10)
            {
                self.E_GoingButton.transform.GetComponentInChildren<Text>().text = "上交装备";
            }
            else if (taskConfig.TargetType == TaskTargetType.GivePet_25)
            {
                self.E_GoingButton.transform.GetComponentInChildren<Text>().text = "上交宠物";
            }

            if ((taskConfig.TaskType == TaskTypeEnum.Ring || taskConfig.TaskType == TaskTypeEnum.Union ||
                    taskConfig.TaskType == TaskTypeEnum.Daily || taskConfig.TaskType == TaskTypeEnum.Treasure) &&
                self.TaskPro.taskStatus == (int)TaskStatuEnum.Completed)
            {
                self.E_GoingButton.transform.GetComponentInChildren<Text>().text = "完成任务";
            }
        }

        private static void OnGiveupButton(this ES_TaskDetail self)
        {
            if (self.TaskPro == null)
                return;

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.TaskPro.taskID);
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            if (taskConfig.TaskType == (int)TaskTypeEnum.Main)
            {
                flyTipComponent.ShowFlyTip("主线任务不能放弃");
                return;
            }

            if (taskConfig.TaskType == TaskTypeEnum.Ring)
            {
                flyTipComponent.ShowFlyTip("跑环任务不能放弃");
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

        public static void SetExpand(this ES_TaskDetail self, int taskType)
        {
            if (taskType == TaskTypeEnum.Main)
            {
                self.ES_TaskType_0.Expand();
            }
            else
            {
                self.ES_TaskType_0.TalkUp();
            }

            if (taskType == TaskTypeEnum.Branch)
            {
                self.ES_TaskType_1.Expand();
            }
            else
            {
                self.ES_TaskType_1.TalkUp();
            }

            if (taskType == TaskTypeEnum.Daily)
            {
                self.ES_TaskType_2.Expand();
            }
            else
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
                flyTipComponent.ShowFlyTip("追踪数量不能超过三个!");
                return;
            }

            TaskClientNetHelper.RequestTaskTrack(self.Root(), self.TaskPro.taskID, self.TaskPro.TrackStatus == 0 ? 1 : 0).Coroutine();

            self.E_ZhuizongButton.gameObject.SetActive(!self.E_ZhuizongButton.gameObject.activeSelf);
            self.E_CancelZhuizongButton.gameObject.SetActive(!self.E_CancelZhuizongButton.gameObject.activeSelf);

            // 提示
            flyTipComponent.ShowFlyTip(self.E_ZhuizongButton.gameObject.activeSelf == false ? "任务开启追踪!" : "任务取消追踪!");
        }
    }
}