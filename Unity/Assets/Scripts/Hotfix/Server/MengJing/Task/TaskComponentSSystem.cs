using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(TaskComponentS))]
    [FriendOf(typeof(TaskComponentS))]
    public static partial class TaskComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this TaskComponentS self)
        {
            self.CheckInitTask();
        }
        [EntitySystem]
        private static void Destroy(this TaskComponentS self)
        {

        }
        [EntitySystem]
        private static void Deserialize(this TaskComponentS self)
        {

        }

        private static void CheckInitTask(this TaskComponentS self)
        {
            int initTask = GlobalValueConfigCategory.Instance.InitTaskId;
            if (!self.IsHaveTask(initTask))
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(initTask);
                TaskPro TaskPro = self.CreateTask(initTask);
                TaskPro.TrackStatus = 1;
                TaskPro.taskStatus = taskConfig.TargetType == TaskTargetType.LookingFor_3 ? (int)TaskStatuEnum.Completed : (int)TaskStatuEnum.Accepted;
                TaskPro.taskTargetNum_1 = 1;
            }
        }

        public static bool ShowPaiMai(this TaskComponentS self, int lv, int simulator)
        {
            if (simulator == 0)
            {
                return true;
            }
            //int mainTaskNumber = 0;
            //for (int i = 0; i < self.RoleComoleteTaskList.Count; i++)
            //{
            //    TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleComoleteTaskList[i]);
            //    if (taskConfig.TaskType == TaskTypeEnum.Main)
            //    {
            //        mainTaskNumber ++;  
            //    }
            //}
            return lv >= 5 && self.RoleComoleteTaskList.Count > lv;
        }

        public static int GetHuoYueDu(this TaskComponentS self)
        {
            int huoYueDu = 0;
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].taskStatus != (int)TaskStatuEnum.Commited)
                {
                    continue;
                }
                TaskConfig taskCountryConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskCountryConfig.TaskType != TaskTypeEnum.Country)
                {
                    continue;
                }

                huoYueDu += taskCountryConfig.EveryTaskRewardNum;
            }
            return huoYueDu;
        }

        public static void Check(this TaskComponentS self, int sceond)
        {
            self.OnLineTime+=sceond;
            if (self.OnLineTime >= 60)
            {
                self.OnLineTime = 0;
                self.OnLineTime(1);
            }
            
            //检测订单任务
        }

        public static bool IsTaskComplete(this TaskComponentS self, int taskid)
        {
            return self.RoleComoleteTaskList.IndexOf(taskid) >= 0;
        }


        public static int TaskTrack(this TaskComponentS self, C2M_TaskTrackRequest request)
        {
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].taskID == request.TaskId)
                {
                    self.RoleTaskList[i].TrackStatus = request.TrackStatus;
                }
            }
            return ErrorCode.ERR_Success;
        }


        public static void OnTaskNotice(this TaskComponentS self, C2M_TaskNoticeRequest request)
        {
            int taskid = request.TaskId;
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].taskID == taskid)
                {
                    self.RoleTaskList[i].taskTargetNum_1 = 1;
                    self.RoleTaskList[i].taskStatus = (int)TaskStatuEnum.Completed;
                }
            }
        }
        
        
        public static void OnRecvGiveUpTask(this TaskComponentS self, int taskId)
        {
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (self.RoleTaskList[i].taskID != taskId)
                {
                    continue;
                }
                self.RoleTaskList.RemoveAt(i);
                break;
            }
        }


        public static (TaskPro, int) OnAcceptedTask(this TaskComponentS self, int taskId)
        {
            if (taskId == 0)
            {
                return (null, ErrorCode.ERR_TaskCanNotGet);
            }
            Unit unit = self.GetParent<Unit>();
            int playerlv = unit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
            List<int> comtaskids = self.RoleComoleteTaskList;
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            bool canget = FunctionHelp.CheckTaskOn(taskConfig.TriggerType, taskConfig.TriggerValue, comtaskids, playerlv);
            if (!canget)
            {
                Log.Debug($"CanNotGetTask: {unit.Zone()} {unit.Id} {taskId}");
                return (null, ErrorCode.ERR_TaskCanNotGet);
            }
            if (self.IsHaveTask(taskId))
            {
                return (null, ErrorCode.ERR_TaskNoComplete); 
            }
            TaskPro taskPro =  self.CreateTask(taskId);
            return (taskPro, ErrorCode.ERR_Success);
        }

        public static TaskPro OnGetDailyTask(this TaskComponentS self, int taskId)
        {
            TaskPro taskPro = self.CreateTask(taskId);
            return taskPro;
        }

        public static string GetMainTaskId(this TaskComponentS self)
        {
            string maintask = string.Empty;
            List<TaskPro> taskPros = self.GetTaskList(TaskTypeEnum.Main);
            for (int i = 0; i < taskPros.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                maintask += $"{taskConfig.TaskName}_";
            }
            if (string.IsNullOrEmpty(maintask))
            {
                return "��";
            }
            else
            {
                return maintask;
            }
        }

        public static List<TaskPro> GetTaskList(this TaskComponentS self, int taskType)
        {
            List<TaskPro> taskPros = new List<TaskPro>();
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                TaskPro taskPro = self.RoleTaskList[i];
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
                if (taskConfig.TaskType != (int)taskType)
                {
                    continue;
                }
                taskPros.Add(taskPro);
            }
            return taskPros;
        }

        public static bool IsItemTask(this TaskComponentS self, int monsterid)
        {
            int taskId = 0;
            switch (monsterid)
            {
                case 41001008:
                    taskId = 30010013; //�󹤵Ĵ���
                    break;
                case 41001010:
                    taskId = 30010010;//�ⶾ��
                    break;
                case 41002001:
                    taskId = 30020102;//��ˮ
                    break;
                default:
                    break;
            }

            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].taskID == taskId)
                {
                    return self.RoleTaskList[i].taskStatus == (int)TaskStatuEnum.Accepted;
                }
            }
            return false;
        }

        public static bool IsHaveTask(this TaskComponentS self, int taskId)
        {
            if (self.RoleComoleteTaskList.Contains(taskId))
            {
                return true;
            }
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].taskID == taskId)
                {
                    return true;
                }
            }
            return false;
        }

        public static TaskPro CreateTask(this TaskComponentS self, int taskid)
        {
            Unit unit = self.GetParent<Unit>();
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
            TaskPro taskPro = TaskPro.Create();
            taskPro.taskID = taskid;

            switch (taskConfig.TargetType)
            {
                case (int)TaskTargetType.KillMonsterID_1:
                    taskPro.taskTargetNum_1 = unit.GetComponent<UserInfoComponentS>().GetReviveTime(taskConfig.Target[0]) > 0 ? 1 : 0;
                    break;
                case (int)TaskTargetType.ItemID_Number_2:
                    for (int i = 0; i < taskConfig.Target.Length; i++)
                    {
                        if (i == 0)
                        {
                            taskPro.taskTargetNum_1 = (int)unit.GetComponent<BagComponentS>().GetItemNumber(taskConfig.Target[i]);
                        }
                        if (i == 1)
                        {
                            taskPro.taskTargetNum_2 = (int)unit.GetComponent<BagComponentS>().GetItemNumber(taskConfig.Target[i]);
                        }
                    }
                    break;
                case (int)TaskTargetType.LookingFor_3:
                    taskPro.taskTargetNum_1 = 1;
                    break;
                case (int)(int)TaskTargetType.PlayerLv_4:
                    taskPro.taskTargetNum_1 = unit.GetComponent<UserInfoComponentS>().GetUserLv();
                    break;
                case (int)TaskTargetType.ChangeOcc_8:
                    taskPro.taskTargetNum_1 = unit.GetComponent<UserInfoComponentS>().GetOccTwo() > 0 ? 1 : 0;
                    break;
                case (int)TaskTargetType.JoinUnion_9:
                    taskPro.taskTargetNum_1 = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0) > 0 ? 1 : 0;
                    break;
                case (int)TaskTargetType.PetNumber1_11:
                    taskPro.taskTargetNum_1 = unit.GetComponent<PetComponentS>().GetAllPets().Count;
                    break;
                case (int)TaskTargetType.QiangHuaLevel_17:
                    taskPro.taskTargetNum_1 = unit.GetComponent<BagComponentS>().GetMaxQiangHuaLevel();
                    break;
                case (int)TaskTargetType.PetNSkill_18:
                    taskPro.taskTargetNum_1 = unit.GetComponent<PetComponentS>().GetMaxSkillNumber();
                    break;
                case (int)TaskTargetType.PetFubenId_19:
                    taskPro.taskTargetNum_1 = unit.GetComponent<PetComponentS>().GetPassMaxFubenId();
                    break;
                case (int)TaskTargetType.JiaYuanLevel_22:
                    taskPro.taskTargetNum_1 = unit.GetComponent<UserInfoComponentS>().GetJiaYuanLv() - 10000;
                    break;
                case (int)TaskTargetType.TrialTowerCeng_134:
                    int curtrialid = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.TrialDungeonId);
                    if (curtrialid > taskConfig.Target[0])
                    {
                        taskPro.taskTargetNum_1 = 1;
                    }
                    break;
                default:
                    taskPro.taskTargetNum_1 = 0;
                    break;
            }

            bool completed = self.IsCompleted(taskPro, taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue);
            taskPro.taskStatus = completed ? (int)TaskStatuEnum.Completed : (int)TaskStatuEnum.Accepted;
            if (taskConfig.TaskType == TaskTypeEnum.Treasure)
            {
                self.GetRandomFubenId(taskPro);
            }
            // if (taskConfig.TaskType != TaskTypeEnum.Season
            //     && taskConfig.TaskType != TaskTypeEnum.Welfare
            //     && taskConfig.TaskType != TaskTypeEnum.System
            //     && self.GetTrackTaskList().Count < 3)
            // {
            //     taskPro.TrackStatus = 1;
            // }
            if ((taskConfig.TaskType == TaskTypeEnum.Main 
                // || taskConfig.TaskType == TaskTypeEnum.Branch
                || taskConfig.TaskType == TaskTypeEnum.Daily
                || taskConfig.TaskType == TaskTypeEnum.Weekly
                || taskConfig.TaskType == TaskTypeEnum.Treasure
                || taskConfig.TaskType == TaskTypeEnum.Union
                || taskConfig.TaskType == TaskTypeEnum.Ring)
                && self.GetTrackTaskList().Count < 3)
            {
                taskPro.TrackStatus = 1;
            }

            self.RoleTaskList.Add(taskPro);
            return taskPro;
        }

        public static void GetRandomFubenId(this TaskComponentS self, TaskPro taskPro)
        {
            List<int> openfubenids = new List<int>();
            int lv = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetUserLv();

            Dictionary<int, DungeonConfig> allfuben = DungeonConfigCategory.Instance.GetAll();
            foreach ((int fubenid, DungeonConfig config) in allfuben)
            {
                if (config.Id == 50007)
                {
                    continue;
                }
                if (DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(config.Id))
                {
                    continue;
                }
                if (config.EnterLv <= lv && config.Id < ConfigData.GMDungeonId)
                {
                    openfubenids.Add(fubenid);
                }
            }
            int dungeonid = openfubenids[RandomHelper.RandomNumber(0, openfubenids.Count)];
            string[] monsters = SceneConfigHelper.GetLocalDungeonMonsters_2(dungeonid).Split('@');
            taskPro.FubenId = dungeonid;
            taskPro.WaveId = RandomHelper.RandomNumber(0, monsters.Length);
            Log.Warning($"GetRandomFubenId: {self.GetParent<Unit>().Id} {dungeonid} {taskPro.WaveId}");
        }

        public static bool IsCompleted(this TaskComponentS self, TaskPro taskPro, int TargetType, int[] Target, int[] TargetValue)
        {
            if (TargetType == (int)TaskTargetType.TeamDungeonHurt_136)
            {
                return taskPro.taskTargetNum_1 >= 1;
            }

            for (int i = 0; i < Target.Length; i++)
            {
                if (i == 0 && TargetValue[i] > taskPro.taskTargetNum_1)
                {
                    return false;
                }
                if (i == 1 && TargetValue[i] > taskPro.taskTargetNum_2)
                {
                    return false;
                }
            }
            return true;
        }

        public static void OnGMGetTask(this TaskComponentS self, int taskid)
        {
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].taskID == taskid)
                {
                    return;
                }
            }

            self.CreateTask(taskid);
            self.NoticeUpdateAllTask();
        }

        public static List<TaskPro> GetTrackTaskList(this TaskComponentS self)
        {
            List<TaskPro> taskPros = new List<TaskPro>();
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (self.RoleTaskList[i].TrackStatus == 1)
                {
                    taskPros.Add(self.RoleTaskList[i]);
                }
            }
            return taskPros;
        }

        public static TaskPro GetTaskById(this TaskComponentS self, int taskid)
        {
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (self.RoleTaskList[i].taskID == taskid)
                {
                    return self.RoleTaskList[i];
                }
            }
            return null;
        }

        public static int CheckGiveItemTask(this TaskComponentS self, int TargetType, int[] Target, int[] TargetValue, long BagInfoID, TaskPro taskPro)
        {
            BagComponentS bagComponent = self.GetParent<Unit>().GetComponent<BagComponentS>();
            if (TargetType == (int)TaskTargetType.ItemID_Number_2)
            {
                int needid = Target[0];
                int neednumber = TargetValue[0];
                int curnumber = (int)bagComponent.GetItemNumber(needid);
                if (curnumber < neednumber)
                {
                    self.TriggerTaskEvent(TaskTargetType.ItemID_Number_2, needid, 0);
                    return ErrorCode.ERR_ItemNotEnoughError;
                }

                bagComponent.OnCostItemData($"{needid};{neednumber}");
                return ErrorCode.ERR_Success;
            }

            if (TargetType == (int)TaskTargetType.GiveItem_10)
            {
                ItemInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, BagInfoID);
                if (bagInfo == null)
                {
                    return ErrorCode.ERR_ItemNotExist;
                }
                if (!TaskHelper.IsTaskGiveItem(TargetType, Target, TargetValue, bagInfo))
                {
                    return ErrorCode.ERR_ItemNotEnoughError;
                }
                bagComponent.OnCostItemData(BagInfoID, 1);
                return ErrorCode.ERR_Success;
            }

            if (TargetType == (int)TaskTargetType.GivePet_25)
            {
                PetComponentS petComponent = self.GetParent<Unit>().GetComponent<PetComponentS>();
                RolePetInfo rolePetInfo = petComponent.GetPetInfo(BagInfoID);
                if (rolePetInfo == null)
                {
                    return ErrorCode.ERR_ItemNotExist;
                }
                if (!TaskHelper.IsTaskGivePet(TargetType, Target, TargetValue, rolePetInfo))
                {
                    return ErrorCode.ERR_ItemNotEnoughError;
                }

                petComponent.OnRolePetFenjie(BagInfoID);
                return ErrorCode.ERR_Success;
            }

            if (taskPro == null)
            {
                return ErrorCode.ERR_ItemNotEnoughError;
            }

            return taskPro.taskStatus == (int)(TaskStatuEnum.Completed) ? ErrorCode.ERR_Success : ErrorCode.Pre_Condition_Error;
            //return ErrorCode.ERR_Success; 
        }


        public static int OnCommitTask(this TaskComponentS self, C2M_TaskCommitRequest request)
        {
            int taskid = request.TaskId;
           
            if (self.RoleComoleteTaskList.Contains(taskid))
            {
                return ErrorCode.ERR_ModifyData;
            }
            
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);

            TaskPro taskPro = self.GetTaskById(taskid);
            if (taskPro == null )
            {
                return ErrorCode.ERR_TaskCommited;
            }
            
            Unit unit = self.GetParent<Unit>();
            
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();

            List<RewardItem> rewardItems = TaskHelper.GetTaskRewards(taskid, taskConfig);
            if (taskConfig.TaskType == TaskTypeEnum.Weekly)
            {
                int weekTaskNumber = numericComponent.GetAsInt(NumericType.WeeklyTaskNumber) + 1;
                if (weekTaskNumber >= GlobalValueConfigCategory.Instance.WeeklyTaskLimit + 1)
                {
                    return ErrorCode.ERR_ModifyData;
                }

                int dropId = 0;
                ConfigData.WeekTaskDrop.TryGetValue(weekTaskNumber, out dropId);
                if (dropId > 0)
                {
                    List<RewardItem> droplist = new List<RewardItem>();
                    DropHelper.DropIDToDropItem_2(dropId, droplist);
                    rewardItems.AddRange(droplist);
                }
            }
            if (taskConfig.TaskType == TaskTypeEnum.Ring)
            {
                int ringTaskNumber = numericComponent.GetAsInt(NumericType.RingTaskNumber) + 1;
                if (ringTaskNumber >= 101)
                {
                    return ErrorCode.ERR_ModifyData;
                }

                int dropId = 0;
                ConfigData.RingTaskDrop.TryGetValue(ringTaskNumber, out dropId);
                if (dropId > 0)
                {
                    List<RewardItem> droplist = new List<RewardItem>();
                    DropHelper.DropIDToDropItem_2(dropId, droplist);
                    rewardItems.AddRange(droplist);
                }
            }
            if (taskConfig.TaskType == TaskTypeEnum.System)
            {

            }

            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) + 1 < rewardItems.Count)
            {
                return ErrorCode.ERR_BagIsFull;
            }
            int checkError = self.CheckGiveItemTask(taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue, request.BagInfoID, taskPro);
            if (checkError != ErrorCode.ERR_Success)
            {
                return checkError;
            }
            
            if (TaskHelper.IsMainTask(taskConfig.TaskType))
            {
                for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
                {
                    if (self.RoleTaskList[i].taskID == taskid)
                    {
                        self.RoleTaskList.RemoveAt(i);
                    }
                }
                if (!self.RoleComoleteTaskList.Contains(taskid))
                {
                    self.RoleComoleteTaskList.Add(taskid);
                }
            }
            else
            {
                for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
                {
                    if (self.RoleTaskList[i].taskID == taskid)
                    {
                        self.RoleTaskList[i].taskStatus = TaskStatuEnum.Commited;
                    }
                }
            }

            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            float coffiexp = 1f;
            float cofficoin = 1f;
            if (taskConfig.Development == 1)
            {
                coffiexp = CommonHelp.GetTaskExpRewardCof(userInfoComponent.GetUserLv());
                cofficoin = CommonHelp.GetTaskCoinRewardCof(userInfoComponent.GetUserLv());
            }

            int TaskExp = (int)(taskConfig.TaskExp * coffiexp);
            int TaskCoin = (int)(taskConfig.TaskCoin * cofficoin);
            userInfoComponent.UpdateRoleMoneyAdd(UserDataType.Exp, TaskExp.ToString(), true, ItemGetWay.TaskReward, taskid.ToString());
            userInfoComponent.UpdateRoleMoneyAdd(UserDataType.Gold, TaskCoin.ToString(), true, ItemGetWay.TaskReward, taskid.ToString());
            int roleLv = userInfoComponent.GetUserLv();
            bagComponent.OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.TaskReward}_{TimeHelper.ServerNow()}");
            if (taskConfig.TaskType != TaskTypeEnum.Main)
            {
                self.TriggerTaskEvent(TaskTargetType.EveryDayTask_1019, 0, 1);
            }

            switch (taskConfig.TaskType)
            {
                case TaskTypeEnum.Daily:
                    int dailyTaskNumber = numericComponent.GetAsInt(NumericType.DailyTaskNumber) + 1;
                    if (dailyTaskNumber < GlobalValueConfigCategory.Instance.MaxDailyTaskLimit)
                    {
                        numericComponent.ApplyValue(NumericType.DailyTaskNumber, dailyTaskNumber, true);
                        numericComponent.ApplyValue(NumericType.DailyTaskID, TaskHelper.GetTaskIdByType(TaskTypeEnum.Daily, roleLv), true);
                    }
                    else
                    {
                        numericComponent.ApplyValue(NumericType.DailyTaskID, 0, true);
                        numericComponent.ApplyValue(NumericType.DailyTaskNumber, dailyTaskNumber, true);
                    }

                    self.TriggerTaskEvent(TaskTargetType.DailyTask_1014, 0, 1);
                    break;
                case TaskTypeEnum.Weekly:
                    int weekTaskNumber = numericComponent.GetAsInt(NumericType.WeeklyTaskNumber) + 1;

                    if (weekTaskNumber <int.Parse( GlobalValueConfigCategory.Instance.Get(109).Value))
                    {
                        numericComponent.ApplyValue(NumericType.WeeklyTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Weekly, roleLv), true);
                        numericComponent.ApplyValue(NumericType.WeeklyTaskNumber, weekTaskNumber, true);
                    }
                    else
                    {
                        numericComponent.ApplyValue(NumericType.WeeklyTaskId, 0, true);
                        numericComponent.ApplyValue(NumericType.WeeklyTaskNumber, weekTaskNumber, true);
                    }
                    break;
                case TaskTypeEnum.Ring:
                    int ringTaskNumber = numericComponent.GetAsInt(NumericType.RingTaskNumber) + 1;

                    if (ringTaskNumber < 100)
                    {
                        numericComponent.ApplyValue(NumericType.RingTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Ring, roleLv), true);
                        numericComponent.ApplyValue(NumericType.RingTaskNumber, ringTaskNumber, true);
                    }
                    else
                    {
                        numericComponent.ApplyValue(NumericType.RingTaskId, 0, true);
                        numericComponent.ApplyValue(NumericType.RingTaskNumber, ringTaskNumber, true);
                    }
                    break;
                case TaskTypeEnum.Union:
                    int unionTaskNumber = numericComponent.GetAsInt(NumericType.UnionTaskNumber) + 1;
                    if (unionTaskNumber < GlobalValueConfigCategory.Instance.UnionTaskLimit)
                    {
                        numericComponent.ApplyValue( NumericType.UnionTaskNumber, unionTaskNumber, true);
                        numericComponent.ApplyValue(NumericType.UnionTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Union, roleLv), true);
                    }
                    else
                    {
                        numericComponent.ApplyValue(NumericType.UnionTaskId, 0, true);
                        numericComponent.ApplyValue(NumericType.UnionTaskNumber, unionTaskNumber,  true);
                    }
                    break;
                case TaskTypeEnum.Treasure:
                    for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
                    {
                        if (self.RoleTaskList[i].taskID == taskid)
                        {
                            self.RoleTaskList.RemoveAt(i);
                        }
                    }
                    
                    int treasureTask = numericComponent.GetAsInt(NumericType.TreasureTask);
                    numericComponent.ApplyValue(NumericType.TreasureTask, treasureTask + 1, true);
                    break;
                case TaskTypeEnum.Season:
                    numericComponent.ApplyValue(NumericType.SeasonTask, taskid, true);
                    if (TaskConfigCategory.Instance.Contain(taskid + 1) && TaskConfigCategory.Instance.Get(taskid + 1).TaskType == TaskTypeEnum.Season)
                    {
                        self.OnAcceptedTask(taskid + 1);
                    }
                    break;
                case TaskTypeEnum.System:
                    numericComponent.ApplyValue(NumericType.SystemTask, taskid, true  );
                    if (TaskConfigCategory.Instance.Contain(taskid + 1) && TaskConfigCategory.Instance.Get(taskid + 1).TaskType == TaskTypeEnum.System)
                    {
                        self.OnAcceptedTask(taskid + 1);
                    }
                    break;
                case TaskTypeEnum.UnionOrder:
                    int unionOrderTaskNumber = numericComponent.GetAsInt(NumericType.OrderTaskCompNumber) + 1;
                    numericComponent.ApplyValue(NumericType.OrderTaskCompNumber, unionOrderTaskNumber,  true);
                    break;
            }
            return ErrorCode.ERR_Success;
        }


        public static void OnChangeOccTwo(this TaskComponentS self)
        {
            self.TriggerTaskEvent(TaskTargetType.ChangeOcc_8, 0, 1);
        }


        public static void OnMakeItem(this TaskComponentS self)
        {
            self.TriggerTaskEvent(TaskTargetType.MakeItem_1006, 0, 1);
        }


        public static void OnPetXiLian(this TaskComponentS self, RolePetInfo rolePetInfo)
        {
            self.TriggerTaskEvent(TaskTargetType.PetNSkill_18, 0, rolePetInfo.PetSkill.Count);
            self.TriggerTaskEvent(TaskTargetType.PetXiLian_1007, 0, 1);
        }

        public static void OnPetHeCheng(this TaskComponentS self, RolePetInfo rolePetInfo)
        {
            self.TriggerTaskEvent(TaskTargetType.PetNumber1_11, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.PetHeCheng_23, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.PetNumber2_24, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.PetNSkill_18, 0, rolePetInfo.PetSkill.Count);

            self.TriggerTaskEvent(TaskTargetType.GetPet_1008, 0, 1);

            int combat = rolePetInfo.PetPingFen;
            self.TriggerTaskEvent(TaskTargetType.PetHeChengCombat_32, combat, 1);
        }

        public static void OnGetPet(this TaskComponentS self, RolePetInfo rolePetInfo)
        {
            self.TriggerTaskEvent(TaskTargetType.PetNumber1_11, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.PetNumber2_24, 0, 1);


            self.TriggerTaskEvent(TaskTargetType.PetNSkill_18, 0, rolePetInfo.PetSkill.Count);


            self.TriggerTaskEvent(TaskTargetType.PetNumber_31, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.GetPet_1008, 0, 1);
        }


        public static void OnEquipXiLian(this TaskComponentS self, int times)
        {
            self.TriggerTaskEvent(TaskTargetType.EquipXiLian_13, 0, times);
            self.TriggerTaskEvent(TaskTargetType.EquipXiLian_1009, 0, times);
        }


        public static void OnLineTime(this TaskComponentS self, int time)
        {
            self.TriggerTaskEvent(TaskTargetType.OnLineTime_1010, 0, 1);

            if (self.Scene().GetComponent<MapComponent>().MapType == MapTypeEnum.Battle)
            {
                self.TriggerTaskEvent(TaskTargetType.BattleExist_1103, 0, 1);
            }
        }


        public static void OnItemHuiShow(this TaskComponentS self, int itemNumber)
        {
            self.TriggerTaskEvent(TaskTargetType.EquipHuiShou_16, 0, itemNumber);

            self.TriggerTaskEvent(TaskTargetType.ItemHuiShou_1011, 0, itemNumber);
        }


        public static void OnCostCoin(this TaskComponentS self, int costCoin)
        {
            if (costCoin >= 0)
                return;
            self.TriggerTaskEvent(TaskTargetType.TotalCostGold_20, 0, costCoin * -1);
            self.TriggerTaskEvent(TaskTargetType.CostCoin_1005, 0, costCoin * -1);
        }


        public static void OnPassFuben(this TaskComponentS self, int difficulty, int chapterid, int star)
        {
            self.TriggerTaskEvent(TaskTargetType.PassFubenID_7, chapterid, 1);
            if ((int)difficulty >= (int)FubenDifficulty.TiaoZhan)  
            {
                self.TriggerTaskEvent(TaskTargetType.PassTianZhanFubenID_111, chapterid, 1);
            }
            if ((int)difficulty >= (int)FubenDifficulty.DiYu)  
            {
                self.TriggerTaskEvent(TaskTargetType.PassDiYuFubenID_112, chapterid, 1);
            }
        }

        public static void OnWinCampBattle(this TaskComponentS self)
        {
            self.TriggerTaskEvent(TaskTargetType.BattleWin_1101, 0, 1);
        }

        public static void OnPassTeamFuben(this TaskComponentS self)
        {
            self.TriggerTaskEvent(TaskTargetType.PassTeamFuben_1004, 0, 1);
        }

        public static async ETTask UpdateUnionRaceRank(this TaskComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            RankShouLieInfo rankingInfo = RankShouLieInfo.Create();
            rankingInfo.UnitID = unit.Id;
            rankingInfo.KillNumber = 1;
            rankingInfo.Occ = unit.GetComponent<UserInfoComponentS>().GetOcc();
            rankingInfo.PlayerName = unit.GetComponent<UserInfoComponentS>().GetName();

            M2R_RankUnionRaceRequest request = M2R_RankUnionRaceRequest.Create();
            request.RankingInfo = rankingInfo;

            ActorId mapInstanceId = UnitCacheHelper.GetRankServerId(self.Zone());
            R2M_RankUnionRaceResponse Response = (R2M_RankUnionRaceResponse)await self.Root().GetComponent<MessageSender>().Call
                     (mapInstanceId, request);
        }


        public static void OnKillUnit(this TaskComponentS self, Unit bekill, int sceneType)
        {
            if (bekill == null || bekill.IsDisposed)
                return;

            if (bekill.Type == UnitType.Player && sceneType == MapTypeEnum.Battle)
            {
                self.TriggerTaskEvent(TaskTargetType.BattleKillPlayer_1102, 0, 1);
                bekill.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.BattleDead_1104, 0, 1);
            }
            if (bekill.Type == UnitType.Player && sceneType == MapTypeEnum.UnionRace)
            {
                self.TriggerTaskEvent(TaskTargetType.UnionRaceKill_1301, 0, 1);
                self.UpdateUnionRaceRank().Coroutine();
            }
            if (bekill.Type == UnitType.Player)
            {
                self.TriggerTaskEvent(TaskTargetType.KillPlayer_21, 0, 1);
            }
            if (bekill.Type == UnitType.Monster)
            {
                MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
                if (mapComponent.MapType == MapTypeEnum.PetMelee || mapComponent.MapType == MapTypeEnum.PetMatch)
                {
                    return;
                }
                
                int unitconfigId = bekill.ConfigId;
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitconfigId);
                bool isBoss = monsterConfig.MonsterType == (int)MonsterTypeEnum.Boss;
                
                int fubenDifficulty = FubenDifficulty.None;

                if (mapComponent.MapType == (int)MapTypeEnum.CellDungeon)
                {
                    //fubenDifficulty = DomainScene.GetComponent<CellDungeonComponent>().FubenDifficulty;
                }
                if (mapComponent.MapType == (int)MapTypeEnum.LocalDungeon)
                {
                    //fubenDifficulty = DomainScene.GetComponent<LocalDungeonComponent>().FubenDifficulty;
                }

                self.TriggerTaskEvent(TaskTargetType.KillMonsterID_1, unitconfigId, 1);

                self.TriggerTaskEvent(TaskTargetType.KillMonster_5, 0, 1);
                self.TriggerTaskEvent(TaskTargetType.KillMonster_1002, 0, 1);

                if (isBoss)
                {
                    self.TriggerTaskEvent(TaskTargetType.KillBOSS_6, 0, 1);
                    self.TriggerTaskEvent(TaskTargetType.KillBoss_1003, 0, 1);
                }

                if ((int)fubenDifficulty >= (int)FubenDifficulty.TiaoZhan) 
                {
                    self.TriggerTaskEvent(TaskTargetType.KillTiaoZhanMonsterID_101, unitconfigId, 1);

                    self.TriggerTaskEvent(TaskTargetType.KillTianZhanMonsterNumber_121, 0, 1);
                    if (isBoss)
                    {
                        self.TriggerTaskEvent(TaskTargetType.KillTianZhanBossNumber_131, 0, 1);
                    }
                }

                if ((int)fubenDifficulty == (int)FubenDifficulty.DiYu)  
                {
                    self.TriggerTaskEvent(TaskTargetType.KillDiYuMonsterID_102, unitconfigId, 1);

                    self.TriggerTaskEvent(TaskTargetType.KillDiYuMonsterNumber_122, 0, 1);
                    if (isBoss)
                    {
                        self.TriggerTaskEvent(TaskTargetType.KillDiYuBossNumber_132, 0, 1);

                        self.TriggerTaskEvent(TaskTargetType.KillDiYuBoss_141, monsterConfig.Lv, 1);
                    }
                }

            }
        }


        public static void OnUpdateLevel(this TaskComponentS self, int rolelv)
        {
            self.TriggerTaskEvent(TaskTargetType.PlayerLv_4, 0, rolelv);

            if (rolelv == 10)
            {
                self.CheckDailyTask(true);
            }
            self.CheckWeeklyTask();
        }


        public static void OnLogin(this TaskComponentS self, int robotid)
        {
            UserInfoComponentS userInfoComponent = self.GetParent<Unit>().GetComponent<UserInfoComponentS>();
            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();

            self.CheckInitTask();
            
            if (self.RoleTaskList.Count == 0)
            {
                Log.Debug($"self.RoleTaskList.Count: {self.Zone()} {self.GetParent<Unit>().Id}");
            }
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType == TaskTypeEnum.System)
                {
                    self.RoleTaskList[i].TrackStatus = 0;
                }

                if (!TaskConfigCategory.Instance.Contain(self.RoleTaskList[i].taskID))
                {
                    self.RoleTaskList.RemoveAt(i);
                    continue;
                }
            }
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (!TaskConfigCategory.Instance.Contain(self.RoleTaskList[i].taskID))
                {
                    self.RoleTaskList.RemoveAt(i);
                }
            }
            
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                TaskPro taskPro = self.RoleTaskList[i];
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
                if (taskConfig.TargetType == TaskTargetType.ItemID_Number_2)
                {
                    self.TriggerTaskEvent(TaskTargetType.ItemID_Number_2, taskConfig.Target[0], 0);
                    continue;
                }
                if (taskConfig.TargetType == TaskTargetType.PlayerLv_4)
                {
                    int roleLv = userInfoComponent.GetUserLv();
                    self.TriggerTaskEvent(TaskTargetType.PlayerLv_4, taskConfig.Target[0], roleLv);
                    continue;
                }
                if (taskConfig.TargetType == TaskTargetType.JoinUnion_9)
                {
                    long unionid = numericComponent.GetAsLong(NumericType.UnionId_0);
                    self.TriggerTaskEvent(TaskTargetType.JoinUnion_9, taskConfig.Target[0], unionid > 0 ? 1 : 0);
                    continue;
                }
                if (taskConfig.TargetType == TaskTargetType.CombatToValue_133)
                {
                    int combat = userInfoComponent.GetCombat();
                    self.TriggerTaskEvent(TaskTargetType.CombatToValue_133, 0, combat);
                    continue;
                }
                if (taskConfig.TargetType == TaskTargetType.TrialTowerCeng_134)
                {
                    int trialid = numericComponent.GetAsInt(NumericType.TrialDungeonId);
                    if (trialid >= taskConfig.Target[0])
                    {
                        self.TriggerTaskEvent(TaskTargetType.TrialTowerCeng_134, taskConfig.Target[0], 1);
                    }
                }
            }


            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                int trialid = self.GetParent<Unit>().GetComponent<NumericComponentS>().GetAsInt(NumericType.TrialDungeonId);
                TaskConfig taskCountryConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskCountryConfig.TargetType == (int)TaskTargetType.TrialFuben_1012 && trialid >= 20100)
                {
                    self.TriggerTaskEvent(TaskTargetType.TrialFuben_1012, 0, taskCountryConfig.TargetValue[0]);
                }
            }


            if (numericComponent.GetAsInt(NumericType.DailyTaskID) == 0)
            {
                //self.UpdateDayTask(false);
                self.CheckDailyTask(false);
            }
            if (numericComponent.GetAsInt(NumericType.RingTaskId) == 0)
            {
                self.CheckRingTask();
            }
            if (numericComponent.GetAsInt(NumericType.UnionTaskId) == 0)
            {
                self.CheckUnionTask();
            }
            if (numericComponent.GetAsInt(NumericType.WeeklyTaskId) == 0)
            {
                self.CheckWeeklyTask();
            }
            if (numericComponent.GetAsInt(NumericType.SystemTask) == 0)
            {
                self.CheckSystemTask();
            }

            self.UpdateWelfareTask(false);
            self.TriggerTaskEvent(TaskTargetType.Login_1001, 0, 1, false);
            
            self.TriggerTaskEvent(TaskTargetType.TrialRank_81, numericComponent.GetAsInt(NumericType.TrialRankId), 1);

            self.TriggerTaskEvent(TaskTargetType.PetTianTiRank_82, numericComponent.GetAsInt(NumericType.PetTianTiRankID), 1);
          
            self.TriggerTaskEvent(TaskTargetType.CombatRank_83, numericComponent.GetAsInt(NumericType.CombatRankID), 1);
        }


        public static void OnGetItemForWarehouse(this TaskComponentS self, int itemId)
        {
            self.TriggerTaskEvent(TaskTargetType.ItemID_Number_2, itemId, 0);
        }


        public static void OnGetItemNumber(this TaskComponentS self, int getWay, int itemId, int itemNumber)
        {
            if (itemId == 1 || (getWay != ItemGetWay.ReceieMail && getWay != ItemGetWay.PaiMaiSell))
            {
                self.TriggerTaskEvent(TaskTargetType.GetItemNumber_142, itemId, itemNumber);
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            if (itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.ItemQuality >= 5)
            {
                self.TriggerTaskEvent(TaskTargetType.GetOrangeEquip_139, itemConfig.UseLv, 1);
            }
        }
        
        public static void OnGetItem_2(this TaskComponentS self, int itemId)
        {
            self.TriggerTaskEvent(TaskTargetType.ItemID_Number_2, itemId, 0);
        }

        public static void CompletCurrentTask(this TaskComponentS self)
        {
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                TaskPro taskPro = self.RoleTaskList[i];
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);

                if (taskPro.taskStatus == (int)TaskStatuEnum.Completed)
                {
                    continue;
                }

                for (int t = 0; t < taskConfig.Target.Length; t++)
                {
                    if (t == 0 && taskConfig.TargetValue.Length > 0)
                    {
                        taskPro.taskTargetNum_1 = taskConfig.TargetValue[0];
                    }
                    if (t == 1 && taskConfig.TargetValue.Length > 1)
                    {
                        taskPro.taskTargetNum_2 = taskConfig.TargetValue[1];
                    }
                }
                taskPro.taskStatus = (int)TaskStatuEnum.Completed;
            }

            self.NoticeUpdateAllTask();
        }

        public static void OnPetMineLogin(this TaskComponentS self, List<PetMingPlayerInfo> petMingPlayers, List<KeyValuePairInt> extends)
        {
            for (int i = 0; i < petMingPlayers.Count; i++)
            {
                for (int mineid = petMingPlayers[i].MineType; mineid <= 10003; mineid++)
                {
                    self.TriggerTaskEvent(TaskTargetType.MineHaveNumber_401, mineid, 1);
                }

                bool hexin = CommonHelp.IsHexinMine(petMingPlayers[i].MineType, petMingPlayers[i].Postion, extends);
                if (hexin)
                {
                    self.TriggerTaskEvent(TaskTargetType.MineHaveNumber_401, 0, 1);
                }
            }
        }

        public static void TriggerTaskEvent(this TaskComponentS self, int targetType, int targetTypeId, int targetValue, bool notice = true)
        {
            bool updateTask = false;

            for (int i =  self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                 if(!TaskConfigCategory.Instance.Contain(self.RoleTaskList[i].taskID))
                 {
                     self.RoleTaskList.RemoveAt(i);
                 }
            }

            List<TaskPro> taskProlist = new List<TaskPro>();
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                TaskPro taskPro = self.RoleTaskList[i];
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
                if (taskConfig.TargetType != targetType)
                {
                    continue;
                }

                if (taskPro.taskStatus >= (int)TaskStatuEnum.Completed)
                {
                    continue;
                }

                if (targetType != TaskTargetType.ItemID_Number_2 && taskPro.taskStatus == (int)TaskStatuEnum.Completed)
                {
                    continue;
                }
                updateTask = true;
                self.CheckTaskPro(taskPro, taskConfig.TargetType, taskConfig.Target, targetTypeId, targetValue);

                bool completed = self.IsCompleted(taskPro, taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue);
                taskPro.taskStatus = completed ? (int)TaskStatuEnum.Completed : (int)TaskStatuEnum.Accepted;
                
                taskProlist.Add(taskPro);
            }

            if (!updateTask)
            {
                return;
            }

            if (notice)
            {
                self.NoticeUpdateOneTask(taskProlist);
            }
        }

        private static void NoticeUpdateOneTask(this TaskComponentS self, List<TaskPro> taskProlist)
        {
            Unit unit = self.GetParent<Unit>();
            M2C_TaskUpdate m2C_TaskUpdate =  M2C_TaskUpdate.Create();
            m2C_TaskUpdate.UpdateMode = 2;
            m2C_TaskUpdate.RoleTaskList.AddRange(taskProlist); 
            m2C_TaskUpdate.RoleComoleteTaskList.AddRange( self.RoleComoleteTaskList );
            MapMessageHelper.SendToClient(unit, m2C_TaskUpdate);
        }
        
        private static void NoticeUpdateAllTask(this TaskComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            M2C_TaskUpdate m2C_TaskUpdate =  M2C_TaskUpdate.Create();
            m2C_TaskUpdate.UpdateMode = 0;
            m2C_TaskUpdate.RoleTaskList.AddRange(self.RoleTaskList); 
            m2C_TaskUpdate.RoleComoleteTaskList.AddRange( self.RoleComoleteTaskList );
            MapMessageHelper.SendToClient(unit, m2C_TaskUpdate);
        }
        
        /// <summary>
        /// ��TaskCountryTargetTypeΪ׼
        /// </summary>
        public static void CheckTaskPro(this TaskComponentS self, TaskPro taskPro, int targetType, int[] Target, int targetTypeId, int targetValue)
        {
            for (int t = 0; t < Target.Length; t++)
            {
                if (targetType == TaskTargetType.ItemID_Number_2)
                {
                    targetValue = (int)self.GetParent<Unit>().GetComponent<BagComponentS>().GetItemNumber(Target[t]);
                }

                if (targetType == TaskTargetType.MakeQulityNumber_29
                 || targetType == TaskTargetType.PetHeChengCombat_32
                 || targetType == TaskTargetType.FuMoQulity_41
                 || targetType == TaskTargetType.JianDingQulity_42
                 || targetType == TaskTargetType.JianDingAttrNumber_43
                 || targetType == TaskTargetType.XiLianSkillNumber_44
                 || targetType == TaskTargetType.GetOrangeEquip_139
                 || targetType == TaskTargetType.JianDingValue_140
                 || targetType == TaskTargetType.KillDiYuBoss_141)
                {
                    if (Target[t] <= targetTypeId)
                    {
                        if (t == 0)
                        {
                            taskPro.taskTargetNum_1++;
                        }
                        if (t == 1)
                        {
                            taskPro.taskTargetNum_2++;
                        }
                    }
                }
                else if (targetType == TaskTargetType.TrialRank_81
                    || targetType == TaskTargetType.PetTianTiRank_82
                    || targetType == TaskTargetType.CombatRank_83)
                {
                    if (targetTypeId != 0 && Target[t] >= targetTypeId)
                    {
                        if (t == 0)
                        {
                            taskPro.taskTargetNum_1++;
                        }
                        if (t == 1)
                        {
                            taskPro.taskTargetNum_2++;
                        }
                    }
                }
                else if (targetType == TaskTargetType.TeamDungeonHurt_136)
                {
                    if (Target[0] == targetTypeId && Target[1] <= targetValue)
                    {
                        taskPro.taskTargetNum_1 = 1;
                        taskPro.taskTargetNum_2 = 1;
                    }

                }
                else if (targetType == TaskTargetType.PlayerLv_4
                     || targetType == TaskTargetType.ItemID_Number_2
                     || targetType == TaskTargetType.QiangHuaLevel_17
                     || targetType == TaskTargetType.JiaYuanLevel_22
                     || targetType == TaskTargetType.CombatToValue_133)
                {
                    if (t == 0)
                    {
                        taskPro.taskTargetNum_1 = targetValue;
                    }
                    if (t == 1)
                    {
                        taskPro.taskTargetNum_2 = targetValue;
                    }
                }
                else if (targetType == TaskTargetType.PetNSkill_18
                    || targetType == TaskTargetType.PetFubenId_19)
                {
                    if (t == 0 && targetValue > taskPro.taskTargetNum_1)
                    {
                        taskPro.taskTargetNum_1 = targetValue;
                    }
                    if (t == 1 && targetValue > taskPro.taskTargetNum_2)
                    {
                        taskPro.taskTargetNum_2 = targetValue;
                    }
                }
                else
                {

                    if (Target[t] == targetTypeId)
                    {
                        if (t == 0)
                        {
                            taskPro.taskTargetNum_1 += targetValue;
                        }
                        if (t == 1)
                        {
                            taskPro.taskTargetNum_2 += targetValue;
                        }
                    }
                }
            }
        }

        public static void UpdateOrderTask(this TaskComponentS self)
        {
            self.RemoveTaskByType(TaskTypeEnum.UnionOrder);
                
            Unit unit = self.GetParent<Unit>();
            int playerlv = unit.GetComponent<UserInfoComponentS>().GetUserLv();
            List<int> taskids = TaskHelper.GetTaskListByWeight(TaskTypeEnum.UnionOrder, playerlv, 5);
            for (int i = 0; i < taskids.Count; i++)
            {
                self.CreateTask(taskids[i]);
            }
                
            self.NoticeUpdateAllTask();
        }

        private static void RemoveTaskByType(this TaskComponentS self, int taskType)
        {
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (!TaskConfigCategory.Instance.Contain(self.RoleTaskList[i].taskID))
                {
                    self.RoleTaskList.RemoveAt(i);
                    continue;
                }

                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType == taskType )
                {
                    self.RoleTaskList.RemoveAt(i);
                }
            }
            for (int i = self.RoleComoleteTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleComoleteTaskList[i]);
                if (taskConfig.TaskType == taskType)
                {
                    self.RoleComoleteTaskList.RemoveAt(i);
                }
            }
        }

        public static void UpdateDailyList(this TaskComponentS self, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            if (self.RoleTaskList.Count == 0)
            {
                Log.Debug($"self.TaskCountryList.Count == 0 {unit.Id} {notice} {self.Zone()} ");
            }
            
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskCountry = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskCountry.TaskType == TaskTypeEnum.SeasonDaily)
                {
                    continue;
                }

                if (TaskHelper.IsDailyTask(taskCountry.TaskType))
                {
                    self.RoleTaskList.RemoveAt(i);
                }
            }
            for (int i = self.RoleComoleteTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleComoleteTaskList[i]);
                if (TaskHelper.IsDailyTask(taskConfig.TaskType))
                {
                    self.RoleComoleteTaskList.RemoveAt(i);
                }
            }

            self.ReceiveHuoYueIds.Clear();
            int roleLv = unit.GetComponent<UserInfoComponentS>().GetUserLv();
            List<int> taskCountryList = new List<int>();
            taskCountryList.AddRange(TaskHelper.GetTaskCountrys(roleLv));
            taskCountryList.AddRange(TaskHelper.GetBattleTask());
            taskCountryList.AddRange(TaskHelper.GetShowLieTask());
            taskCountryList.AddRange(TaskHelper.GetUnionRaceTask());
            taskCountryList.AddRange(TaskHelper.GetMineTask());
            taskCountryList.AddRange(TaskHelper.GetActivityV1Task());

            for (int i = 0; i < taskCountryList.Count; i++)
            {
                self.CreateTask(taskCountryList[i]);
            }
            //UserInfoComponent userInfoComponent = unit.GetComponent<UserInfoComponent>();
            //userInfoComponent.UpdateRoleData(UserDataType.HuoYue, (0 - userInfoComponent.UserInfo.HuoYue).ToString(), notice);
            
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            
            numericComponent.ApplyValue(NumericType.DailyTaskNumber, 0, notice);
            numericComponent.ApplyValue(NumericType.UnionTaskNumber, 0, notice);
            numericComponent.ApplyValue(NumericType.DailyTaskID, TaskHelper.GetTaskIdByType(TaskTypeEnum.Daily, roleLv), notice);
            numericComponent.ApplyValue(NumericType.UnionTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Union, roleLv), notice);

            
            Log.Debug($"RoleTaskList:  {unit.Id} {self.Zone()}  {self.RoleTaskList.Count}");
            Console.WriteLine($"UpdateCountryList:  {self.RoleTaskList.Count}");
        }

        public static void CheckDailyTask(this TaskComponentS self, bool notice)
        {
            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.DailyTaskID) != 0)
            {
                return;
            }
            if (numericComponent.GetAsInt(NumericType.DailyTaskNumber) >= 1)
            {
                return;
            }

            int roleLv = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetUserLv();
            numericComponent.ApplyValue(NumericType.DailyTaskID, TaskHelper.GetTaskIdByType(TaskTypeEnum.Daily, roleLv), notice);
        }

        public static void CheckRingTask(this TaskComponentS self)
        {
            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.RingTaskId) == 0 && numericComponent.GetAsInt(NumericType.RingTaskNumber) < 1)
            {
                //self.ClearTypeTask(TaskTypeEnum.Ring);

                int roleLv = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetUserLv();
                int ringTaskId = TaskHelper.GetTaskIdByType(TaskTypeEnum.Ring, roleLv);
                numericComponent.ApplyValue(NumericType.RingTaskId, ringTaskId, false);
            }
        }

        public static void CheckWeeklyTask(this TaskComponentS self)
        {
            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.WeeklyTaskId) == 0 && numericComponent.GetAsInt(NumericType.WeeklyTaskNumber) < 1)
            {
                //self.ClearTypeTask(TaskTypeEnum.Ring);
                int roleLv = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetUserLv();
                int weekTaskId = TaskHelper.GetTaskIdByType(TaskTypeEnum.Weekly, roleLv);
                numericComponent.ApplyValue(NumericType.WeeklyTaskId, weekTaskId, false);
            }
        }

        public static void CheckSystemTask(this TaskComponentS self)
        {
            bool have = false;
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType != TaskTypeEnum.System)
                {
                    continue;
                }

                have = true;
                break;
            }

            if (have)
            {
                return;
            }

            int curTakskid = self.GetParent<Unit>().GetComponent<NumericComponentS>().GetAsInt(NumericType.SystemTask);
            foreach ((int taskid, TaskConfig taskcofnig) in TaskConfigCategory.Instance.GetAll())
            {
                if (taskcofnig.TaskType != TaskTypeEnum.System || taskid <= curTakskid)
                {
                    continue;
                }

                self.OnAcceptedTask(taskid);
                break;
            }

            self.NoticeUpdateAllTask();
        }

        public static void CheckUnionTask(this TaskComponentS self)
        {
            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.UnionTaskId) == 0 && numericComponent.GetAsInt(NumericType.UnionTaskNumber) < 1)
            {

                int roleLv = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetUserLv();
                numericComponent.ApplyValue(NumericType.UnionTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Union, roleLv), false);
            }
        }

        public static void OnResetSeason(this TaskComponentS self, bool notice)
        {
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType == TaskTypeEnum.Season || taskConfig.TaskType == TaskTypeEnum.SeasonDaily)
                {
                    self.RoleTaskList.RemoveAt(i);  
                }
            }
        }

        public static void InitSeasonMainTask(this TaskComponentS self, bool notice)
        {
            bool have = false;
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType == TaskTypeEnum.Season)
                {
                    have = true;
                    break;
                }
            }
            if (have)
            {
                return;
            }

            int curTakskid = self.GetParent<Unit>().GetComponent<NumericComponentS>().GetAsInt(NumericType.SeasonTask);
            foreach ((int taskid, TaskConfig taskcofnig) in TaskConfigCategory.Instance.GetAll())
            {
                if (taskcofnig.TaskType == TaskTypeEnum.Season && taskid > curTakskid)
                {
                    self.OnAcceptedTask(taskid);
                    break;
                }
            }

            if (notice)
            {
               self.NoticeUpdateAllTask();
            }
        }

        public static void UpdateWelfareTask(this TaskComponentS self, bool notice)
        {
            int createDay = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetCrateDay();
            if (createDay == 0 || createDay > ConfigData.WelfareTaskList.Count)
            {
                return;
            }
            
            List<int> taskids = new List<int>();
            for (int i = 0; i < createDay; i++)
            {
                taskids.AddRange(ConfigData.WelfareTaskList[i]);
            }
            for (int i = 0; i < taskids.Count; i++)
            {

                if (self.GetTaskById(taskids[i]) != null)
                {
                    continue;
                }
                if (self.RoleComoleteTaskList.Contains(taskids[i]))
                {
                    continue;
                }

                self.CreateTask(taskids[i]);
            }
        }
        
        public static TaskPro GetTreasureMonster(this TaskComponentS self, int fubenid)
        {
            List<TaskPro> taskPros = self.GetTaskList(TaskTypeEnum.Treasure);
            for (int i = 0; i < taskPros.Count; i++)
            {
                if (taskPros[i].taskStatus >= (int)TaskStatuEnum.Completed)
                {
                    continue;
                }
                if (taskPros[i].FubenId != fubenid)
                {
                    continue;
                }
                return taskPros[i];
            }
            return null;
        }

        public static void CheckWeeklyUpdate(this TaskComponentS self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            if (dateTime.DayOfWeek == DayOfWeek.Monday)
            {
                //Log.Console($"ResetWeeklyTask: passday:{self.Id} {dateTime.DayOfWeek == System.DayOfWeek.Monday}");
                self.ResetWeeklyTask();
            }
        }

        public static void ResetWeeklyTask(this TaskComponentS self)
        {
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (!TaskConfigCategory.Instance.Contain(self.RoleTaskList[i].taskID))
                {
                    self.RoleTaskList.RemoveAt(i);
                    continue;
                }

                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType == TaskTypeEnum.Weekly
                    || taskConfig.TaskType == TaskTypeEnum.Ring)
                {
                    if (self.RoleComoleteTaskList.Contains(taskConfig.Id))
                    {
                        self.RoleComoleteTaskList.Remove(taskConfig.Id);
                    }
                    self.RoleTaskList.RemoveAt(i);
                    continue;
                }
            }
            for (int i = self.RoleComoleteTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleComoleteTaskList[i]);
                if (taskConfig.TaskType == TaskTypeEnum.Weekly)
                {
                    self.RoleComoleteTaskList.RemoveAt(i);
                    continue;
                }
            }

            Unit unit = self.GetParent<Unit>();
            int roleLv = unit.GetComponent<UserInfoComponentS>().GetUserLv();
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.RingTaskNumber, 0, false);
            numericComponent.ApplyValue(NumericType.RingTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Ring, roleLv), false);

            numericComponent.ApplyValue(NumericType.WeeklyTaskNumber, 0, false);
            numericComponent.ApplyValue(NumericType.WeeklyTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Weekly, roleLv), false);

            self.UpdateSeasonWeekTask(false);
        }

        public static void UpdateSeasonWeekTask(this TaskComponentS self, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.SeasonTowerId, 0, notice);
            
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (!TaskConfigCategory.Instance.Contain(self.RoleTaskList[i].taskID))
                {
                    self.RoleTaskList.RemoveAt(i);
                    continue;
                }

                TaskConfig taskCountry = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskCountry.TaskType == TaskTypeEnum.SeasonDaily)
                {
                    self.RoleTaskList.RemoveAt(i);
                    continue;
                }
            }

            UserInfoComponentS userInfoComponent = self.GetParent<Unit>().GetComponent<UserInfoComponentS>();
            if (SeasonHelper.GetOpenSeason(userInfoComponent.GetUserLv())!=null)
            {
                List<int> taskCountryList = TaskHelper.GetSeasonTask();
                for (int i = 0; i < taskCountryList.Count; i++)
                {
                    self.CreateTask(taskCountryList[i]);
                }
            }

            if (notice)
            {
                self.NoticeUpdateAllTask();
            }
        }

        public static void CheckWeeklyUpdate(this TaskComponentS self, long lastTime, long curTime)
        {
            float passday = ((curTime - lastTime) * 1f / TimeHelper.OneDay);
            if (passday >= 7)
            {
                //Log.Warning($"ResetWeeklyTask: passday:{self.Id} {passday}");
                self.ResetWeeklyTask();
            }
            else
            {
                DateTime lastdateTime = TimeInfo.Instance.ToDateTime(lastTime);
                DateTime curdateTime = TimeInfo.Instance.ToDateTime(curTime);
                if ((curdateTime.DayOfWeek < lastdateTime.DayOfWeek && curdateTime.DayOfWeek != 0)
                 || (curdateTime.DayOfWeek > lastdateTime.DayOfWeek && lastdateTime.DayOfWeek == 0))
                {
                    Log.Warning($"ResetWeeklyTask:{self.Id} {curdateTime.DayOfWeek} {lastdateTime.DayOfWeek}");
                    self.ResetWeeklyTask();
                }
                //int curday = curdateTime.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)(curdateTime.DayOfWeek);
                //int lastday = lastdateTime.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)(lastdateTime.DayOfWeek);
                //if(curday < lastday)
                //{
                //    Log.Console($"ResetWeeklyTask:{self.Id} {curdateTime.DayOfWeek} {lastdateTime.DayOfWeek}");
                //    self.ResetWeeklyTask();
                //}
            }
        }

        public static void OnZeroClockUpdate(this TaskComponentS self, bool notice)
        {
            self.OnLineTime = 0;
        
            self.UpdateDailyList(notice);
            self.UpdateWelfareTask(notice);
            
            if (notice)
            {
                self.NoticeUpdateAllTask();
            }
        }
    }
}