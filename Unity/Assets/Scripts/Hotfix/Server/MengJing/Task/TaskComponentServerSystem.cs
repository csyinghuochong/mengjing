using System.Collections.Generic;

namespace ET.Server
{

    [EntitySystemOf(typeof(TaskComponentServer))]
    [FriendOf(typeof(TaskComponentServer))]
    public static partial class TaskComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.TaskComponentServer self)
        {
            if (self.RoleTaskList.Count == 0)
            {
                int initTask = int.Parse(GlobalValueConfigCategory.Instance.Get(1).Value);
                self.RoleTaskList.Add(new TaskPro() { taskID = initTask, TrackStatus = 1, taskStatus = (int)TaskStatuEnum.Completed, taskTargetNum_1 = 1 });
            }
        }
        [EntitySystem]
        private static void Destroy(this ET.Server.TaskComponentServer self)
        {

        }
        [EntitySystem]
        private static void Deserialize(this ET.Server.TaskComponentServer self)
        {

        }

        public static bool ShowPaiMai(this TaskComponentServer self, int lv, int simulator)
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

        public static int GetHuoYueDu(this TaskComponentServer self)
        {
            int huoYueDu = 0;
            for (int i = 0; i < self.TaskCountryList.Count; i++)
            {
                if (self.TaskCountryList[i].taskStatus != (int)TaskStatuEnum.Commited)
                {
                    continue;
                }
                TaskCountryConfig taskCountryConfig = TaskCountryConfigCategory.Instance.Get(self.TaskCountryList[i].taskID);
                huoYueDu += taskCountryConfig.EveryTaskRewardNum;
            }
            return huoYueDu;
        }

        public static void Check(this TaskComponentServer self)
        {
            self.OnLineTime++;
            self.OnLineTime(1);
        }

        public static bool IsTaskComplete(this TaskComponentServer self, int taskid)
        {
            return self.RoleComoleteTaskList.IndexOf(taskid) >= 0;
        }

        //����׷��
        public static int TaskTrack(this TaskComponentServer self, C2M_TaskTrackRequest request)
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

        //�Ի�֮��������ɿͻ��˴������
        public static void OnTaskNotice(this TaskComponentServer self, C2M_TaskNoticeRequest request)
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

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="self"></param>
        /// <param name="taskId"></param>
        public static void OnRecvGiveUpTask(this TaskComponentServer self, int taskId)
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

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="self"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public static (TaskPro, int) OnAcceptedTask(this TaskComponentServer self, int taskId)
        {
            if (taskId == 0)
            {
                return (null, ErrorCode.ERR_TaskCanNotGet);
            }
            Unit unit = self.GetParent<Unit>();
            bool canget = FunctionHelp.CheckTaskOn(unit, TaskConfigCategory.Instance.Get(taskId));
            if (!canget)
            {
                Log.Debug($"CanNotGetTask: {unit.Zone()} {unit.Id} {taskId}");
                return (null, ErrorCode.ERR_TaskCanNotGet);
            }
            if (self.IsHaveTask(taskId))
            {
                return (null, ErrorCode.ERR_TaskNoComplete);
            }
            TaskPro taskPro = self.CreateTask(taskId);
            self.RoleTaskList.Add(taskPro);
            return (taskPro, ErrorCode.ERR_Success);
        }

        public static TaskPro OnGetDailyTask(this TaskComponentServer self, int taskId)
        {
            TaskPro taskPro = self.CreateTask(taskId);
            self.RoleTaskList.Add(taskPro);
            return taskPro;
        }

        public static string GetMainTaskId(this TaskComponentServer self)
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

        public static List<TaskPro> GetTaskList(this TaskComponentServer self, int taskType)
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

        public static bool IsItemTask(this TaskComponentServer self, int monsterid)
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

        public static bool IsHaveTask(this TaskComponentServer self, int taskId)
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

        public static TaskPro CreateTask(this TaskComponentServer self, int taskid)
        {
            Unit unit = self.GetParent<Unit>();
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
            TaskPro taskPro = new TaskPro();
            taskPro.taskID = taskid;

            switch (taskConfig.TargetType)
            {
                case (int)TaskTargetType.KillMonsterID_1:
                    taskPro.taskTargetNum_1 = unit.GetComponent<UserInfoComponentServer>().GetReviveTime(taskConfig.Target[0]) > 0 ? 1 : 0;
                    break;
                case (int)TaskTargetType.ItemID_Number_2:
                    for (int i = 0; i < taskConfig.Target.Length; i++)
                    {
                        if (i == 0)
                        {
                            taskPro.taskTargetNum_1 = (int)unit.GetComponent<BagComponentServer>().GetItemNumber(taskConfig.Target[i]);
                        }
                        if (i == 1)
                        {
                            taskPro.taskTargetNum_2 = (int)unit.GetComponent<BagComponentServer>().GetItemNumber(taskConfig.Target[i]);
                        }
                    }
                    break;
                case (int)TaskTargetType.LookingFor_3:
                    taskPro.taskTargetNum_1 = 1;
                    break;
                case (int)(int)TaskTargetType.PlayerLv_4:
                    taskPro.taskTargetNum_1 = unit.GetComponent<UserInfoComponentServer>().GetUserLv();
                    break;
                case (int)TaskTargetType.ChangeOcc_8:
                    taskPro.taskTargetNum_1 = unit.GetComponent<UserInfoComponentServer>().GetOccTwo() > 0 ? 1 : 0;
                    break;
                case (int)TaskTargetType.JoinUnion_9:
                    taskPro.taskTargetNum_1 = unit.GetComponent<NumericComponentServer>().GetAsLong(NumericType.UnionId_0) > 0 ? 1 : 0;
                    break;
                case (int)TaskTargetType.PetNumber1_11:
                    taskPro.taskTargetNum_1 = unit.GetComponent<PetComponentServer>().GetAllPets().Count;
                    break;
                case (int)TaskTargetType.QiangHuaLevel_17:
                    taskPro.taskTargetNum_1 = unit.GetComponent<BagComponentServer>().GetMaxQiangHuaLevel();
                    break;
                case (int)TaskTargetType.PetNSkill_18:
                    taskPro.taskTargetNum_1 = unit.GetComponent<PetComponentServer>().GetMaxSkillNumber();
                    break;
                case (int)TaskTargetType.PetFubenId_19:
                    taskPro.taskTargetNum_1 = unit.GetComponent<PetComponentServer>().GetPassMaxFubenId();
                    break;
                case (int)TaskTargetType.JiaYuanLevel_22:
                    taskPro.taskTargetNum_1 = unit.GetComponent<UserInfoComponentServer>().GetJiaYuanLv() - 10000;
                    break;
                case (int)TaskTargetType.TrialTowerCeng_134:
                    int curtrialid = unit.GetComponent<NumericComponentServer>().GetAsInt(NumericType.TrialDungeonId);
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
            if (taskConfig.TaskType != TaskTypeEnum.Season
                && taskConfig.TaskType != TaskTypeEnum.Welfare
                && taskConfig.TaskType != TaskTypeEnum.System
                && self.GetTrackTaskList().Count < 3)
            {
                taskPro.TrackStatus = 1;
            }
            return taskPro;
        }

        public static void GetRandomFubenId(this TaskComponentServer self, TaskPro taskPro)
        {
            List<int> openfubenids = new List<int>();
            int lv = self.GetParent<Unit>().GetComponent<UserInfoComponentServer>().GetUserLv();

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
                if (config.EnterLv <= lv && config.Id < ConfigHelper.GMDungeonId())
                {
                    openfubenids.Add(fubenid);
                }
            }
            int dungeonid = openfubenids[RandomHelper.RandomNumber(0, openfubenids.Count)];
            string[] monsters = SceneConfigHelper.GetLocalDungeonMonsters_2(dungeonid).Split('@');
            taskPro.FubenId = dungeonid;
            taskPro.WaveId = RandomHelper.RandomNumber(0, monsters.Length);
            Log.Warning($"���ɲر�ͼ�����: {self.GetParent<Unit>().Id} {dungeonid} {taskPro.WaveId}");
        }

        public static bool IsCompleted(this TaskComponentServer self, TaskPro taskPro, int TargetType, int[] Target, int[] TargetValue)
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

        public static void OnGMGetTask(this TaskComponentServer self, int taskid)
        {
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].taskID == taskid)
                {
                    return;
                }
            }

            TaskPro taskPro = self.CreateTask(taskid);
            self.RoleTaskList.Add(taskPro);

            M2C_TaskUpdate m2C_TaskUpdate = self.M2C_TaskUpdate;
            m2C_TaskUpdate.RoleTaskList = self.RoleTaskList;
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_TaskUpdate);
        }

        public static List<TaskPro> GetTrackTaskList(this TaskComponentServer self)
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

        public static TaskPro GetTaskById(this TaskComponentServer self, int taskid)
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

        public static int CheckGiveItemTask(this TaskComponentServer self, int TargetType, int[] Target, int[] TargetValue, long BagInfoID, TaskPro taskPro)
        {
            //�ռ����ߵ�����

            if (TargetType == (int)TaskTargetType.ItemID_Number_2)
            {
                BagComponentServer bagComponent = self.GetParent<Unit>().GetComponent<BagComponentServer>();
                int needid = Target[0];
                int neednumber = TargetValue[0];
                int curnumber = (int)bagComponent.GetItemNumber(needid);
                if (curnumber < neednumber)
                {
                    self.TriggerTaskEvent(TaskTargetType.ItemID_Number_2, needid, 0);
                    self.TriggerTaskCountryEvent(TaskTargetType.ItemID_Number_2, needid, 0);
                    return ErrorCode.ERR_ItemNotEnoughError;
                }

                bagComponent.OnCostItemData($"{needid};{neednumber}");
                return ErrorCode.ERR_Success;
            }
            //��������
            if (TargetType == (int)TaskTargetType.GiveItem_10)
            {
                BagComponentServer bagComponent = self.GetParent<Unit>().GetComponent<BagComponentServer>();
                BagInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, BagInfoID);
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
            //�������
            if (TargetType == (int)TaskTargetType.GivePet_25)
            {
                PetComponentServer petComponent = self.GetParent<Unit>().GetComponent<PetComponentServer>();
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
            return taskPro.taskStatus == (int)(TaskStatuEnum.Completed) ? ErrorCode.ERR_Success : ErrorCode.Pre_Condition_Error;
            //return ErrorCode.ERR_Success; 
        }

        //��ȡ����
        public static int OnCommitTask(this TaskComponentServer self, C2M_TaskCommitRequest request)
        {
            int taskid = request.TaskId;
            TaskPro taskPro = self.GetTaskById(taskid);
            if (taskPro == null)
            {
                return ErrorCode.ERR_TaskCommited;
            }
            Unit unit = self.GetParent<Unit>();
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();

            List<RewardItem> rewardItems = TaskHelper.GetTaskRewards(taskid, taskConfig);
            if (taskConfig.TaskType == TaskTypeEnum.Weekly)
            {
                int weekTaskNumber = numericComponent.GetAsInt(NumericType.WeeklyTaskNumber) + 1;
                if (weekTaskNumber >= GlobalValueConfigCategory.Instance.Get(109).Value2 + 1)
                {
                    return ErrorCode.ERR_ModifyData;
                }

                int dropId = 0;
                ConfigHelper.WeekTaskDrop().TryGetValue(weekTaskNumber, out dropId);
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
                ConfigHelper.RingTaskDrop().TryGetValue(ringTaskNumber, out dropId);
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

            if (bagComponent.GetBagLeftCell() + 1 < rewardItems.Count)
            {
                return ErrorCode.ERR_BagIsFull;
            }
            int checkError = self.CheckGiveItemTask(taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue, request.BagInfoID, taskPro);
            if (checkError != ErrorCode.ERR_Success)
            {
                return checkError;
            }

            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (self.RoleTaskList[i].taskID == taskid)
                {
                    self.RoleTaskList.RemoveAt(i);
                }
            }

            if (taskConfig.TaskType != TaskTypeEnum.Daily
              && taskConfig.TaskType != TaskTypeEnum.Weekly
              && taskConfig.TaskType != TaskTypeEnum.Treasure
              && taskConfig.TaskType != TaskTypeEnum.Union
              && taskConfig.TaskType != TaskTypeEnum.Season
              && taskConfig.TaskType != TaskTypeEnum.Ring
              && taskConfig.TaskType != TaskTypeEnum.System)
            {
                if (self.RoleComoleteTaskList.Contains(taskid))
                {
                    return ErrorCode.ERR_ModifyData;
                }

                if (!self.RoleComoleteTaskList.Contains(taskid))
                {
                    self.RoleComoleteTaskList.Add(taskid);
                }
            }

            UserInfoComponentServer userInfoComponent = unit.GetComponent<UserInfoComponentServer>();
            float coffiexp = 1f;
            float cofficoin = 1f;
            if (taskConfig.Development == 1)
            {
                coffiexp = ComHelp.GetTaskExpRewardCof(userInfoComponent.GetUserLv());
                cofficoin = ComHelp.GetTaskCoinRewardCof(userInfoComponent.GetUserLv());
            }

            int TaskExp = (int)(taskConfig.TaskExp * coffiexp);
            int TaskCoin = (int)(taskConfig.TaskCoin * cofficoin);

            userInfoComponent.UpdateRoleMoneyAdd(UserDataType.Exp, TaskExp.ToString(), true, ItemGetWay.TaskReward, taskid.ToString());
            userInfoComponent.UpdateRoleMoneyAdd(UserDataType.Gold, TaskCoin.ToString(), true, ItemGetWay.TaskReward, taskid.ToString());
            int roleLv = userInfoComponent.GetUserLv();
            bagComponent.OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.TaskReward}_{TimeHelper.ServerNow()}");
            if (taskConfig.TaskType == TaskTypeEnum.Daily)
            {
                int dailyTaskNumber = numericComponent.GetAsInt(NumericType.DailyTaskNumber) + 1;
                if (dailyTaskNumber < GlobalValueConfigCategory.Instance.Get(58).Value2)
                {
                    numericComponent.SetEvent(NumericType.DailyTaskNumber, dailyTaskNumber, true);
                    numericComponent.SetEvent(NumericType.DailyTaskID, TaskHelper.GetTaskIdByType(TaskTypeEnum.Daily, roleLv), true);
                }
                else
                {
                    numericComponent.SetEvent(NumericType.DailyTaskID, 0, true);
                    numericComponent.SetEvent(NumericType.DailyTaskNumber, dailyTaskNumber, true);
                }

                self.TriggerTaskCountryEvent(TaskTargetType.DailyTask_1014, 0, 1);
            }
            if (taskConfig.TaskType == TaskTypeEnum.Weekly)
            {
                int weekTaskNumber = numericComponent.GetAsInt(NumericType.WeeklyTaskNumber) + 1;

                if (weekTaskNumber < GlobalValueConfigCategory.Instance.Get(109).Value2)
                {
                    numericComponent.SetEvent(NumericType.WeeklyTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Weekly, roleLv), true);
                    numericComponent.SetEvent(NumericType.WeeklyTaskNumber, weekTaskNumber, true);
                }
                else
                {
                    numericComponent.SetEvent(NumericType.WeeklyTaskId, 0, true);
                    numericComponent.SetEvent(NumericType.WeeklyTaskNumber, weekTaskNumber, true);
                }
            }
            if (taskConfig.TaskType == TaskTypeEnum.Ring)
            {
                int ringTaskNumber = numericComponent.GetAsInt(NumericType.RingTaskNumber) + 1;

                if (ringTaskNumber < 100)
                {
                    numericComponent.SetEvent(NumericType.RingTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Ring, roleLv), true);
                    numericComponent.SetEvent(NumericType.RingTaskNumber, ringTaskNumber, true);
                }
                else
                {
                    numericComponent.SetEvent(NumericType.RingTaskId, 0, true);
                    numericComponent.SetEvent(NumericType.RingTaskNumber, ringTaskNumber, true);
                }
            }
            if (taskConfig.TaskType == TaskTypeEnum.Union)
            {
                int unionTaskNumber = numericComponent.GetAsInt(NumericType.UnionTaskNumber) + 1;
                if (unionTaskNumber < GlobalValueConfigCategory.Instance.Get(108).Value2)
                {
                    numericComponent.SetEvent(null, NumericType.UnionTaskNumber, unionTaskNumber, 0);
                    numericComponent.SetEvent(NumericType.UnionTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Union, roleLv), true);
                }
                else
                {
                    numericComponent.SetEvent(NumericType.UnionTaskId, 0, true);
                    numericComponent.SetEvent(null, NumericType.UnionTaskNumber, unionTaskNumber, 0, true);
                }

            }
            if (taskConfig.TaskType == TaskTypeEnum.Treasure)
            {
                int treasureTask = numericComponent.GetAsInt(NumericType.TreasureTask);
                numericComponent.SetEvent(NumericType.TreasureTask, treasureTask + 1, true);
            }
            if (taskConfig.TaskType == TaskTypeEnum.Season)
            {
                numericComponent.SetEvent(NumericType.SeasonTask, taskid, true);
                if (TaskConfigCategory.Instance.Contain(taskid + 1) && TaskConfigCategory.Instance.Get(taskid + 1).TaskType == TaskTypeEnum.Season)
                {
                    self.OnAcceptedTask(taskid + 1);

                    M2C_TaskUpdate m2C_TaskUpdate = self.M2C_TaskUpdate;
                    m2C_TaskUpdate.RoleTaskList = self.RoleTaskList;
                    MapMessageHelper.SendToClient(unit, m2C_TaskUpdate);
                }
            }
            if (taskConfig.TaskType == TaskTypeEnum.System)
            {
                numericComponent.SetEvent(NumericType.SystemTask, taskid, true  );
                if (TaskConfigCategory.Instance.Contain(taskid + 1) && TaskConfigCategory.Instance.Get(taskid + 1).TaskType == TaskTypeEnum.System)
                {
                    self.OnAcceptedTask(taskid + 1);

                    M2C_TaskUpdate m2C_TaskUpdate = self.M2C_TaskUpdate;
                    m2C_TaskUpdate.RoleTaskList = self.RoleTaskList;
                    MapMessageHelper.SendToClient(unit, m2C_TaskUpdate);
                }
            }
            if (taskConfig.TaskType != TaskTypeEnum.Main)
            {
                self.TriggerTaskCountryEvent(TaskTargetType.EveryDayTask_1019, 0, 1);
            }
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// תְ
        /// </summary>
        /// <param name="self"></param>
        public static void OnChangeOccTwo(this TaskComponentServer self)
        {
            self.TriggerTaskEvent(TaskTargetType.ChangeOcc_8, 0, 1);
            self.TriggerTaskCountryEvent(TaskTargetType.ChangeOcc_8, 0, 1);
        }

        /// <summary>
        /// ����
        /// </summary>
        public static void OnMakeItem(this TaskComponentServer self)
        {
            self.TriggerTaskCountryEvent(TaskTargetType.MakeItem_1006, 0, 1);
        }

        /// <summary>
        /// ����ϴ��
        /// </summary>
        /// <param name="self"></param>
        public static void OnPetXiLian(this TaskComponentServer self, RolePetInfo rolePetInfo)
        {
            self.TriggerTaskEvent(TaskTargetType.PetNSkill_18, 0, rolePetInfo.PetSkill.Count);
            self.TriggerTaskCountryEvent(TaskTargetType.PetNSkill_18, 0, rolePetInfo.PetSkill.Count);

            self.TriggerTaskCountryEvent(TaskTargetType.PetXiLian_1007, 0, 1);
        }

        public static void OnPetHeCheng(this TaskComponentServer self, RolePetInfo rolePetInfo)
        {
            self.TriggerTaskEvent(TaskTargetType.PetNumber1_11, 0, 1);
            self.TriggerTaskCountryEvent(TaskTargetType.PetNumber1_11, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.PetHeCheng_23, 0, 1);
            self.TriggerTaskCountryEvent(TaskTargetType.PetHeCheng_23, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.PetNumber2_24, 0, 1);
            self.TriggerTaskCountryEvent(TaskTargetType.PetNumber2_24, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.PetNSkill_18, 0, rolePetInfo.PetSkill.Count);
            self.TriggerTaskCountryEvent(TaskTargetType.PetNSkill_18, 0, rolePetInfo.PetSkill.Count);

            self.TriggerTaskCountryEvent(TaskTargetType.GetPet_1008, 0, 1);

            int combat = PetHelper.PetPingJia(rolePetInfo);
            self.TriggerTaskEvent(TaskTargetType.PetHeChengCombat_32, combat, 1);
            self.TriggerTaskCountryEvent(TaskTargetType.PetHeChengCombat_32, combat, 1);
        }

        /// <summary>
        /// ��ó���
        /// </summary>
        /// <param name="self"></param>
        public static void OnGetPet(this TaskComponentServer self, RolePetInfo rolePetInfo)
        {
            self.TriggerTaskEvent(TaskTargetType.PetNumber1_11, 0, 1);
            self.TriggerTaskCountryEvent(TaskTargetType.PetNumber1_11, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.PetNumber2_24, 0, 1);
            self.TriggerTaskCountryEvent(TaskTargetType.PetNumber2_24, 0, 1);

            self.TriggerTaskEvent(TaskTargetType.PetNSkill_18, 0, rolePetInfo.PetSkill.Count);
            self.TriggerTaskCountryEvent(TaskTargetType.PetNSkill_18, 0, rolePetInfo.PetSkill.Count);

            self.TriggerTaskEvent(TaskTargetType.PetNumber_31, 0, 1);
            self.TriggerTaskCountryEvent(TaskTargetType.PetNumber_31, 0, 1);

            self.TriggerTaskCountryEvent(TaskTargetType.GetPet_1008, 0, 1);
        }

        /// <summary>
        /// ����ϴ��
        /// </summary>
        /// <param name="self"></param>
        public static void OnEquipXiLian(this TaskComponentServer self, int times)
        {
            self.TriggerTaskEvent(TaskTargetType.EquipXiLian_13, 0, times);
            self.TriggerTaskCountryEvent(TaskTargetType.EquipXiLian_13, 0, times);
            self.TriggerTaskCountryEvent(TaskTargetType.EquipXiLian_1009, 0, times);
        }

        /// <summary>
        /// ����ʱ������ʱһ���Ӵ���һ��
        /// </summary>
        /// <param name="self"></param>
        public static void OnLineTime(this TaskComponentServer self, int time)
        {
            self.TriggerTaskCountryEvent(TaskTargetType.OnLineTime_1010, 0, 1);

            if (self.Root().GetComponent<MapComponent>().SceneType == SceneTypeEnum.Battle)
            {
                self.TriggerTaskCountryEvent(TaskTargetType.BattleExist_1103, 0, 1);
            }
        }

        /// <summary>
        /// ���߻���
        /// </summary>
        /// <param name="self"></param>
        public static void OnItemHuiShow(this TaskComponentServer self, int itemNumber)
        {
            self.TriggerTaskEvent(TaskTargetType.EquipHuiShou_16, 0, itemNumber);
            self.TriggerTaskCountryEvent(TaskTargetType.EquipHuiShou_16, 0, itemNumber);
            self.TriggerTaskCountryEvent(TaskTargetType.ItemHuiShou_1011, 0, itemNumber);
        }

        /// <summary>
        /// ���Ľ��
        /// </summary>
        /// <param name="self"></param>
        public static void OnCostCoin(this TaskComponentServer self, int costCoin)
        {
            if (costCoin >= 0)
                return;
            self.TriggerTaskEvent(TaskTargetType.TotalCostGold_20, 0, costCoin * -1);
            self.TriggerTaskCountryEvent(TaskTargetType.TotalCostGold_20, 0, costCoin * -1);
            self.TriggerTaskCountryEvent(TaskTargetType.CostCoin_1005, 0, costCoin * -1);
        }

        /// <summary>
        /// ͨ�ظ���
        /// </summary>
        /// <param name="self"></param>
        /// <param name="difficulty"></param>
        /// <param name="chapterid"></param>
        /// <param name="star"></param>
        public static void OnPassFuben(this TaskComponentServer self, int difficulty, int chapterid, int star)
        {
            self.TriggerTaskEvent(TaskTargetType.PassFubenID_7, chapterid, 1);
            self.TriggerTaskCountryEvent(TaskTargetType.PassFubenID_7, chapterid, 1);
            if ((int)difficulty >= (int)FubenDifficulty.TiaoZhan)  //��ս
            {
                self.TriggerTaskEvent(TaskTargetType.PassTianZhanFubenID_111, chapterid, 1);
                self.TriggerTaskCountryEvent(TaskTargetType.PassTianZhanFubenID_111, chapterid, 1);
            }
            if ((int)difficulty >= (int)FubenDifficulty.DiYu)  //����
            {
                self.TriggerTaskEvent(TaskTargetType.PassDiYuFubenID_112, chapterid, 1);
                self.TriggerTaskCountryEvent(TaskTargetType.PassDiYuFubenID_112, chapterid, 1);
            }
        }

        public static void OnWinCampBattle(this TaskComponentServer self)
        {
            self.TriggerTaskCountryEvent(TaskTargetType.BattleWin_1101, 0, 1);
        }

        public static void OnPassTeamFuben(this TaskComponentServer self)
        {
            self.TriggerTaskCountryEvent(TaskTargetType.PassTeamFuben_1004, 0, 1);
        }

        public static async ETTask UpdateUnionRaceRank(this TaskComponentServer self)
        {
            Unit unit = self.GetParent<Unit>();
            RankShouLieInfo rankingInfo = new RankShouLieInfo()
            {
                UnitID = unit.Id,
                KillNumber = 1,
                Occ = unit.GetComponent<UserInfoComponentServer>().GetOcc(),
                PlayerName = unit.GetComponent<UserInfoComponentServer>().GetName()
            };
            M2R_RankUnionRaceRequest request = new M2R_RankUnionRaceRequest()
            {
                RankingInfo = rankingInfo
            };
            ActorId mapInstanceId = UnitCacheHelper.GetRankServerId(self.Zone());
            R2M_RankUnionRaceResponse Response = (R2M_RankUnionRaceResponse)await self.Root().GetComponent<MessageSender>().Call
                     (mapInstanceId, request);
        }

        //��ɱ����ɴ����������͵�����
        public static void OnKillUnit(this TaskComponentServer self, Unit bekill, int sceneType)
        {
            if (bekill == null || bekill.IsDisposed)
                return;

            if (bekill.Type == UnitType.Player && sceneType == SceneTypeEnum.Battle)
            {
                self.TriggerTaskCountryEvent(TaskTargetType.BattleKillPlayer_1102, 0, 1);
                bekill.GetComponent<TaskComponentServer>().TriggerTaskCountryEvent(TaskTargetType.BattleDead_1104, 0, 1);
            }
            if (bekill.Type == UnitType.Player && sceneType == SceneTypeEnum.UnionRace)
            {
                self.TriggerTaskCountryEvent(TaskTargetType.UnionRaceKill_1301, 0, 1);
                self.UpdateUnionRaceRank().Coroutine();
            }
            if (bekill.Type == UnitType.Player)
            {
                self.TriggerTaskEvent(TaskTargetType.KillPlayer_21, 0, 1);
                self.TriggerTaskCountryEvent(TaskTargetType.KillPlayer_21, 0, 1);
            }
            if (bekill.Type == UnitType.Monster)
            {
                int unitconfigId = bekill.ConfigId;
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitconfigId);
                bool isBoss = monsterConfig.MonsterType == (int)MonsterTypeEnum.Boss;
                MapComponent mapComponent = self.DomainScene().GetComponent<MapComponent>();
                int fubenDifficulty = FubenDifficulty.None;
                Scene DomainScene = self.GetParent<Unit>().DomainScene();
                if (mapComponent.SceneTypeEnum == (int)SceneTypeEnum.CellDungeon)
                {
                    fubenDifficulty = DomainScene.GetComponent<CellDungeonComponent>().FubenDifficulty;
                }
                if (mapComponent.SceneTypeEnum == (int)SceneTypeEnum.LocalDungeon)
                {
                    fubenDifficulty = DomainScene.GetComponent<LocalDungeonComponent>().FubenDifficulty;
                }

                self.TriggerTaskEvent(TaskTargetType.KillMonsterID_1, unitconfigId, 1);
                self.TriggerTaskCountryEvent(TaskTargetType.KillMonsterID_1, unitconfigId, 1);

                self.TriggerTaskEvent(TaskTargetType.KillMonster_5, 0, 1);
                self.TriggerTaskCountryEvent(TaskTargetType.KillMonster_5, 0, 1);
                self.TriggerTaskCountryEvent(TaskTargetType.KillMonster_1002, 0, 1);

                if (isBoss)
                {
                    self.TriggerTaskEvent(TaskTargetType.KillBOSS_6, 0, 1);
                    self.TriggerTaskCountryEvent(TaskTargetType.KillBOSS_6, 0, 1);
                    self.TriggerTaskCountryEvent(TaskTargetType.KillBoss_1003, 0, 1);
                }

                if ((int)fubenDifficulty >= (int)FubenDifficulty.TiaoZhan) //��ս
                {
                    self.TriggerTaskEvent(TaskTargetType.KillTiaoZhanMonsterID_101, unitconfigId, 1);
                    self.TriggerTaskCountryEvent(TaskTargetType.KillTiaoZhanMonsterID_101, unitconfigId, 1);

                    self.TriggerTaskEvent(TaskTargetType.KillTianZhanMonsterNumber_121, 0, 1);
                    self.TriggerTaskCountryEvent(TaskTargetType.KillTianZhanMonsterNumber_121, 0, 1);
                    if (isBoss)
                    {
                        self.TriggerTaskEvent(TaskTargetType.KillTianZhanBossNumber_131, 0, 1);
                        self.TriggerTaskCountryEvent(TaskTargetType.KillTianZhanBossNumber_131, 0, 1);
                    }
                }

                if ((int)fubenDifficulty == (int)FubenDifficulty.DiYu)  //����
                {
                    self.TriggerTaskEvent(TaskTargetType.KillDiYuMonsterID_102, unitconfigId, 1);
                    self.TriggerTaskCountryEvent(TaskTargetType.KillDiYuMonsterID_102, unitconfigId, 1);

                    self.TriggerTaskEvent(TaskTargetType.KillDiYuMonsterNumber_122, 0, 1);
                    self.TriggerTaskCountryEvent(TaskTargetType.KillDiYuMonsterNumber_122, 0, 1);
                    if (isBoss)
                    {
                        self.TriggerTaskEvent(TaskTargetType.KillDiYuBossNumber_132, 0, 1);
                        self.TriggerTaskCountryEvent(TaskTargetType.KillDiYuBossNumber_132, 0, 1);

                        self.TriggerTaskEvent(TaskTargetType.KillDiYuBoss_141, monsterConfig.Lv, 1);
                        self.TriggerTaskCountryEvent(TaskTargetType.KillDiYuBoss_141, monsterConfig.Lv, 1);
                    }
                }

            }
        }

        //�ȼ�����
        public static void OnUpdateLevel(this TaskComponentServer self, int rolelv)
        {
            self.TriggerTaskEvent(TaskTargetType.PlayerLv_4, 0, rolelv);
            self.TriggerTaskCountryEvent(TaskTargetType.PlayerLv_4, 0, rolelv);

            if (rolelv == 10)
            {
                self.CheckDailyTask(true);
            }
            self.CheckWeeklyTask();
        }

        //��¼
        public static void OnLogin(this TaskComponentServer self)
        {
            UserInfoComponentServer userInfoComponent = self.GetParent<Unit>().GetComponent<UserInfoComponentServer>();
            NumericComponentServer numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentServer>();

            if (self.TaskCountryList.Count == 0)
            {
                Log.Debug($"��Ծ����Ϊ��: {self.Zone()} {self.GetParent<Unit>().Id}");
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
            for (int i = self.TaskCountryList.Count - 1; i >= 0; i--)
            {
                if (!TaskCountryConfigCategory.Instance.Contain(self.TaskCountryList[i].taskID))
                {
                    self.TaskCountryList.RemoveAt(i);
                }
            }

            //����һ���Ѽ��������͵�����
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
                    self.TriggerTaskCountryEvent(TaskTargetType.JoinUnion_9, taskConfig.Target[0], unionid > 0 ? 1 : 0);
                    continue;
                }
                if (taskConfig.TargetType == TaskTargetType.CombatToValue_133)
                {
                    int combat = userInfoComponent.UserInfo.Combat;
                    self.TriggerTaskEvent(TaskTargetType.CombatToValue_133, 0, combat);
                    self.TriggerTaskCountryEvent(TaskTargetType.CombatToValue_133, 0, combat);
                    continue;
                }
                if (taskConfig.TargetType == TaskTargetType.TrialTowerCeng_134)
                {
                    //��������
                    int trialid = numericComponent.GetAsInt(NumericType.TrialDungeonId);
                    if (trialid >= taskConfig.Target[0])
                    {
                        self.TriggerTaskEvent(TaskTargetType.TrialTowerCeng_134, taskConfig.Target[0], 1);
                        self.TriggerTaskCountryEvent(TaskTargetType.TrialTowerCeng_134, taskConfig.Target[0], 1);
                    }
                }
            }

            //��������
            for (int i = 0; i < self.TaskCountryList.Count; i++)
            {
                int trialid = self.GetParent<Unit>().GetComponent<NumericComponentServer>().GetAsInt(NumericType.TrialDungeonId);
                TaskCountryConfig taskCountryConfig = TaskCountryConfigCategory.Instance.Get(self.TaskCountryList[i].taskID);
                if (taskCountryConfig.TargetType == (int)TaskTargetType.TrialFuben_1012 && trialid >= 20100)
                {
                    self.TriggerTaskCountryEvent(TaskTargetType.TrialFuben_1012, 0, taskCountryConfig.TargetValue[0], false);
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

            self.UpdateTargetTask(false);
            self.TriggerTaskCountryEvent(TaskTargetType.Login_1001, 0, 1, false);

            //numericComponent.ApplyValue(NumericType.RankID, chat2G_EnterChat.RankId, false, false);
            //numericComponent.ApplyValue(NumericType.PetRankID, chat2G_EnterChat.PetRankId, false, false);
            //numericComponent.ApplyValue(NumericType.SoloRankId, chat2G_EnterChat.SoloRankId, false, false);
            //numericComponent.ApplyValue(NumericType.TrialRankId, chat2G_EnterChat.TrialRankId, false, false);
            self.TriggerTaskEvent(TaskTargetType.TrialRank_81, numericComponent.GetAsInt(NumericType.TrialRankId), 1);
            self.TriggerTaskCountryEvent(TaskTargetType.TrialRank_81, numericComponent.GetAsInt(NumericType.TrialRankId), 1);

            self.TriggerTaskEvent(TaskTargetType.PetTianTiRank_82, numericComponent.GetAsInt(NumericType.PetTianTiRankID), 1);
            self.TriggerTaskCountryEvent(TaskTargetType.PetTianTiRank_82, numericComponent.GetAsInt(NumericType.PetTianTiRankID), 1);

            self.TriggerTaskEvent(TaskTargetType.CombatRank_83, numericComponent.GetAsInt(NumericType.CombatRankID), 1);
            self.TriggerTaskCountryEvent(TaskTargetType.CombatRank_83, numericComponent.GetAsInt(NumericType.CombatRankID), 1);
        }

        //�ռ�����
        public static void OnGetItemForWarehouse(this TaskComponentServer self, int itemId)
        {
            self.TriggerTaskEvent(TaskTargetType.ItemID_Number_2, itemId, 0);
            self.TriggerTaskCountryEvent(TaskTargetType.ItemID_Number_2, itemId, 0);
        }

        //�ۼƻ�õ�������
        public static void OnGetItemNumber(this TaskComponentServer self, int getWay, int itemId, int itemNumber)
        {
            if (itemId == 1 || (getWay != ItemGetWay.ReceieMail && getWay != ItemGetWay.PaiMaiSell))
            {
                self.TriggerTaskEvent(TaskTargetType.GetItemNumber_142, itemId, itemNumber);
                self.TriggerTaskCountryEvent(TaskTargetType.GetItemNumber_142, itemId, itemNumber);
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            if (itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.ItemQuality >= 5)
            {
                self.TriggerTaskEvent(TaskTargetType.GetOrangeEquip_139, itemConfig.UseLv, 1);
                self.TriggerTaskCountryEvent(TaskTargetType.GetOrangeEquip_139, itemConfig.UseLv, 1);
            }
        }

        //�ռ�����
        public static void OnGetItem_2(this TaskComponentServer self, int itemId)
        {
            self.TriggerTaskEvent(TaskTargetType.ItemID_Number_2, itemId, 0);
            self.TriggerTaskCountryEvent(TaskTargetType.ItemID_Number_2, itemId, 0);
        }

        public static void CompletCurrentTask(this TaskComponentServer self)
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

            M2C_TaskUpdate m2C_TaskUpdate = self.M2C_TaskUpdate;
            m2C_TaskUpdate.RoleTaskList = self.RoleTaskList;
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_TaskUpdate);
        }

        public static void OnPetMineLogin(this TaskComponentServer self, List<PetMingPlayerInfo> petMingPlayers, List<KeyValuePairInt> extends)
        {
            for (int i = 0; i < petMingPlayers.Count; i++)
            {
                for (int mineid = petMingPlayers[i].MineType; mineid <= 10003; mineid++)
                {
                    self.TriggerTaskCountryEvent(TaskTargetType.MineHaveNumber_401, mineid, 1);
                    self.TriggerTaskEvent(TaskTargetType.MineHaveNumber_401, mineid, 1);
                }

                bool hexin = ComHelp.IsHexinMine(petMingPlayers[i].MineType, petMingPlayers[i].Postion, extends);
                if (hexin)
                {
                    self.TriggerTaskCountryEvent(TaskTargetType.MineHaveNumber_401, 0, 1);
                    self.TriggerTaskEvent(TaskTargetType.MineHaveNumber_401, 0, 1);
                }
            }
        }

        public static void TriggerTaskEvent(this TaskComponentServer self, int targetType, int targetTypeId, int targetValue)
        {
            bool updateTask = false;

            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                TaskPro taskPro = self.RoleTaskList[i];
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
                if (taskConfig.TargetType != targetType)
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
            }

            if (!updateTask)
            {
                return;
            }

            M2C_TaskUpdate m2C_TaskUpdate = self.M2C_TaskUpdate;
            m2C_TaskUpdate.RoleTaskList = self.RoleTaskList;
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_TaskUpdate);
        }


        /// <summary>
        /// ��TaskCountryTargetTypeΪ׼
        /// </summary>
        public static void CheckTaskPro(this TaskComponentServer self, TaskPro taskPro, int targetType, int[] Target, int targetTypeId, int targetValue)
        {
            for (int t = 0; t < Target.Length; t++)
            {
                if (targetType == TaskTargetType.ItemID_Number_2)
                {
                    targetValue = (int)self.GetParent<Unit>().GetComponent<BagComponentServer>().GetItemNumber(Target[t]);
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

        public static void TriggerTaskCountryEvent(this TaskComponentServer self, int targetType, int targetTypeId, int targetValue, bool notice = true)
        {
            bool updateTask = false;
            List<TaskPro> countryList = new List<TaskPro>();

            for (int i = 0; i < self.TaskCountryList.Count; i++)
            {
                TaskPro taskPro = self.TaskCountryList[i];
                TaskCountryConfig taskConfig = TaskCountryConfigCategory.Instance.Get(taskPro.taskID);
                int taskCountryTargetType = taskConfig.TargetType;
                if (taskCountryTargetType != targetType)
                {
                    continue;
                }

                if (taskPro.taskStatus >= (int)TaskStatuEnum.Completed)
                {
                    continue;
                }

                updateTask = true;
                self.CheckTaskPro(taskPro, taskConfig.TargetType, taskConfig.Target, targetTypeId, targetValue);

                bool completed = self.IsCompleted(taskPro, taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue);
                taskPro.taskStatus = completed ? (int)TaskStatuEnum.Completed : (int)TaskStatuEnum.Accepted;
                countryList.Add(taskPro);
            }

            if (!updateTask || !notice)
                return;
            M2C_TaskCountryUpdate m2C_TaskUpdate = self.m2C_TaskCountryUpdate;
            m2C_TaskUpdate.UpdateMode = 1;
            m2C_TaskUpdate.TaskCountryList = countryList;
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_TaskUpdate);
        }

        public static void UpdateCountryList(this TaskComponentServer self, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            if (self.TaskCountryList.Count == 0)
            {
                Log.Debug($"���»�Ծ����ERROE:  {unit.Id} {notice} {self.DomainZone()} ");
            }

            //��������ÿ�����
            for (int i = self.TaskCountryList.Count - 1; i >= 0; i--)
            {
                TaskCountryConfig taskCountry = TaskCountryConfigCategory.Instance.Get(self.TaskCountryList[i].taskID);
                if (taskCountry.TaskType == TaskCountryType.Season)
                {
                    continue;
                }
                self.TaskCountryList.RemoveAt(i);
            }

            self.ReceiveHuoYueIds.Clear();
            List<int> taskCountryList = new List<int>();
            taskCountryList.AddRange(TaskHelper.GetTaskCountrys(unit));
            taskCountryList.AddRange(TaskHelper.GetBattleTask());
            taskCountryList.AddRange(TaskHelper.GetShowLieTask());
            taskCountryList.AddRange(TaskHelper.GetUnionRaceTask());
            taskCountryList.AddRange(TaskHelper.GetMineTask());
            taskCountryList.AddRange(TaskHelper.GetActivityV1Task());

            for (int i = 0; i < taskCountryList.Count; i++)
            {
                self.TaskCountryList.Add(new TaskPro() { taskID = taskCountryList[i] });
            }
            //UserInfoComponent userInfoComponent = unit.GetComponent<UserInfoComponent>();
            //userInfoComponent.UpdateRoleData(UserDataType.HuoYue, (0 - userInfoComponent.UserInfo.HuoYue).ToString(), notice);
            Log.Debug($"���»�Ծ����:  {unit.Id} {self.Zone()}  {self.TaskCountryList.Count}");
        }

        public static void CheckDailyTask(this TaskComponentServer self, bool notice)
        {
            NumericComponentServer numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentServer>();
            if (numericComponent.GetAsInt(NumericType.DailyTaskID) != 0)
            {
                return;
            }
            if (numericComponent.GetAsInt(NumericType.DailyTaskNumber) >= 1)
            {
                return;
            }

            int roleLv = self.GetParent<Unit>().GetComponent<UserInfoComponentServer>().GetUserLv();
            numericComponent.SetEvent(NumericType.DailyTaskID, TaskHelper.GetTaskIdByType(TaskTypeEnum.Daily, roleLv), notice);
        }

        public static void CheckRingTask(this TaskComponentServer self)
        {
            NumericComponentServer numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentServer>();
            if (numericComponent.GetAsInt(NumericType.RingTaskId) == 0 && numericComponent.GetAsInt(NumericType.RingTaskNumber) < 1)
            {
                //self.ClearTypeTask(TaskTypeEnum.Ring);

                int roleLv = self.GetParent<Unit>().GetComponent<UserInfoComponent>().UserInfo.Lv;
                int ringTaskId = TaskHelper.GetTaskIdByType(TaskTypeEnum.Ring, roleLv);
                numericComponent.ApplyValue(NumericType.RingTaskId, ringTaskId, false);
            }
        }

        public static void CheckWeeklyTask(this TaskComponentServer self)
        {
            NumericComponentServer numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentServer>();
            if (numericComponent.GetAsInt(NumericType.WeeklyTaskId) == 0 && numericComponent.GetAsInt(NumericType.WeeklyTaskNumber) < 1)
            {
                //self.ClearTypeTask(TaskTypeEnum.Ring);
                int roleLv = self.GetParent<Unit>().GetComponent<UserInfoComponentServer>().GetUserLv();
                int weekTaskId = TaskHelper.GetTaskIdByType(TaskTypeEnum.Weekly, roleLv);
                numericComponent.SetEvent(NumericType.WeeklyTaskId, weekTaskId, false);
            }
        }

        public static void CheckSystemTask(this TaskComponentServer self)
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

            int curTakskid = self.GetParent<Unit>().GetComponent<NumericComponentServer>().GetAsInt(NumericType.SystemTask);
            foreach ((int taskid, TaskConfig taskcofnig) in TaskConfigCategory.Instance.GetAll())
            {
                if (taskcofnig.TaskType != TaskTypeEnum.System || taskid <= curTakskid)
                {
                    continue;
                }

                self.OnAcceptedTask(taskid);
                break;
            }

            M2C_TaskUpdate m2C_TaskUpdate = self.M2C_TaskUpdate;
            m2C_TaskUpdate.RoleTaskList = self.RoleTaskList;
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_TaskUpdate);
        }

        public static void CheckUnionTask(this TaskComponentServer self)
        {
            NumericComponentServer numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentServer>();
            if (numericComponent.GetAsInt(NumericType.UnionTaskId) == 0 && numericComponent.GetAsInt(NumericType.UnionTaskNumber) < 1)
            {

                int roleLv = self.GetParent<Unit>().GetComponent<UserInfoComponentServer>().GetUserLv();
                numericComponent.SetEvent(NumericType.UnionTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Union, roleLv), false);
            }
        }

        public static void ClearSeasonData(this TaskComponentServer self)
        {

        }

        public static void InitSeasonMainTask(this TaskComponentServer self, bool notice)
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

            int curTakskid = self.GetParent<Unit>().GetComponent<NumericComponentServer>().GetAsInt(NumericType.SeasonTask);
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
                M2C_TaskUpdate m2C_TaskUpdate = self.M2C_TaskUpdate;
                m2C_TaskUpdate.RoleTaskList = self.RoleTaskList;
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_TaskUpdate);
            }
        }

        public static void UpdateTargetTask(this TaskComponentServer self, bool notice)
        {
            int createDay = self.GetParent<Unit>().GetComponent<UserInfoComponentServer>().GetCrateDay();
            if (createDay == 0 || createDay > ConfigHelper.WelfareTaskList().Count)
            {
                return;
            }

            //��������
            List<int> taskids = new List<int>();
            for (int i = 0; i < createDay; i++)
            {
                taskids.AddRange(ConfigHelper.WelfareTaskList()[i]);
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

                self.RoleTaskList.Add(self.CreateTask(taskids[i]));
            }
        }

        public static void ClearTypeTask(this TaskComponentServer self, int taskType)
        {
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType == taskType)
                {
                    if (self.RoleComoleteTaskList.Contains(taskConfig.Id))
                    {
                        self.RoleComoleteTaskList.Remove(taskConfig.Id);
                    }
                    self.RoleTaskList.RemoveAt(i);
                    continue;
                }
            }
        }

        public static void UpdateDayTask(this TaskComponentServer self, bool notice)
        {

            //���ÿ������
            Unit unit = self.GetParent<Unit>();
            System.DateTime dateTime = TimeHelper.DateTimeNow();
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType == TaskTypeEnum.Daily
                    || taskConfig.TaskType == TaskTypeEnum.Union)
                {
                    if (self.RoleComoleteTaskList.Contains(taskConfig.Id))
                    {
                        self.RoleComoleteTaskList.Remove(taskConfig.Id);
                    }
                    self.RoleTaskList.RemoveAt(i);
                    continue;
                }
            }

            NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
            int roleLv = unit.GetComponent<UserInfoComponentServer>().GetUserLv();

            numericComponent.SetEvent(NumericType.DailyTaskNumber, 0, notice);
            numericComponent.SetEvent(NumericType.UnionTaskNumber, 0, notice);
            numericComponent.SetEvent(NumericType.DailyTaskID, TaskHelper.GetTaskIdByType(TaskTypeEnum.Daily, roleLv), notice);
            numericComponent.SetNoEvent(NumericType.UnionTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Union, roleLv), notice);

            //int ringTaskId = TaskHelper.GetTaskIdByType(TaskTypeEnum.Ring, roleLv);
            //numericComponent.ApplyValue(NumericType.RingTaskId, ringTaskId, notice);
            //Log.Debug($"����ÿ������: {numericComponent.GetAsInt(NumericType.DailyTaskID)}");
        }

        public static TaskPro GetTreasureMonster(this TaskComponentServer self, int fubenid)
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

        public static void CheckWeeklyUpdate(this TaskComponentServer self)
        {
            System.DateTime dateTime = TimeHelper.DateTimeNow();
            if (dateTime.DayOfWeek == System.DayOfWeek.Monday)
            {
                //Log.Console($"ResetWeeklyTask: passday:{self.Id} {dateTime.DayOfWeek == System.DayOfWeek.Monday}");
                self.ResetWeeklyTask();
            }
        }

        public static void ResetWeeklyTask(this TaskComponentServer self)
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
            int roleLv = unit.GetComponent<UserInfoComponentServer>().GetUserLv();
            NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
            numericComponent.SetEvent(NumericType.RingTaskNumber, 0, false);
            numericComponent.SetEvent(NumericType.RingTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Ring, roleLv), false);

            numericComponent.SetEvent(NumericType.WeeklyTaskNumber, 0, false);
            numericComponent.SetEvent(NumericType.WeeklyTaskId, TaskHelper.GetTaskIdByType(TaskTypeEnum.Weekly, roleLv), false);

            self.UpdateSeasonWeekTask(false);
        }

        public static void UpdateSeasonWeekTask(this TaskComponentServer self, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            unit.GetComponent<NumericComponentServer>().ApplyValue(NumericType.SeasonTowerId, 0, notice);

            //��������ÿ�����
            for (int i = self.TaskCountryList.Count - 1; i >= 0; i--)
            {
                if (!TaskCountryConfigCategory.Instance.Contain(self.TaskCountryList[i].taskID))
                {
                    self.TaskCountryList.RemoveAt(i);
                    continue;
                }

                TaskCountryConfig taskCountry = TaskCountryConfigCategory.Instance.Get(self.TaskCountryList[i].taskID);
                if (taskCountry.TaskType == TaskCountryType.Season)
                {
                    self.TaskCountryList.RemoveAt(i);
                    continue;
                }
            }

            UserInfoComponentServer userInfoComponent = self.GetParent<Unit>().GetComponent<UserInfoComponentServer>();
            if (SeasonHelper.IsOpenSeason(userInfoComponent.UserInfo.Lv))
            {
                List<int> taskCountryList = TaskHelper.GetSeasonTask();
                for (int i = 0; i < taskCountryList.Count; i++)
                {
                    self.TaskCountryList.Add(new TaskPro() { taskID = taskCountryList[i] });
                }
            }

            if (notice)
            {
                M2C_TaskCountryUpdate m2C_TaskUpdate = self.m2C_TaskCountryUpdate;
                m2C_TaskUpdate.UpdateMode = 2;
                m2C_TaskUpdate.TaskCountryList = self.TaskCountryList;
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_TaskUpdate);
            }
        }

        public static void CheckWeeklyUpdate(this TaskComponentServer self, long lastTime, long curTime)
        {
            //�ж������� ����һ�ܻ��߹�����ĩ
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

        /// <summary>
        /// ����ÿ�ջ�Ծ
        /// </summary> 
        /// <param name="self"></param>
        public static void OnZeroClockUpdate(this TaskComponentServer self, bool notice)
        {
            self.OnLineTime = 0;
            Unit unit = self.GetParent<Unit>();
            self.UpdateCountryList(notice);
            self.UpdateDayTask(notice);
            self.UpdateTargetTask(notice);

            if (notice)
            {
                M2C_TaskCountryUpdate m2C_TaskUpdate = self.m2C_TaskCountryUpdate;
                m2C_TaskUpdate.UpdateMode = 2;
                m2C_TaskUpdate.TaskCountryList = self.TaskCountryList;
                MapMessageHelper.SendToClient(unit, m2C_TaskUpdate);
            }
            if (notice)
            {
                M2C_TaskUpdate m2C_TaskUpdate = self.M2C_TaskUpdate;
                m2C_TaskUpdate.RoleTaskList = self.RoleTaskList;
                MapMessageHelper.SendToClient(unit, m2C_TaskUpdate);
            }
        }
    }
}