using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof(TaskComponentC))]
    [EntitySystemOf(typeof(TaskComponentC))]
    public static partial class TaskComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this TaskComponentC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this TaskComponentC self)
        {
        }

        public static void OnZeroClockUpdate(this TaskComponentC self)
        {
            self.ReceiveHuoYueIds.Clear();
        }

        public static List<TaskPro> GetAllTrackList(this TaskComponentC self)
        {
            List<TaskPro> taskPros = new List<TaskPro>();
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].TrackStatus == 0)
                {
                    continue;
                }

                taskPros.Add(self.RoleTaskList[i]);
            }

            return taskPros;
        }

        public static List<TaskPro> GetTaskTypeList(this TaskComponentC self, int taskTypeEnum)
        {
            List<TaskPro> taskPros = new List<TaskPro>();
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType != (int)taskTypeEnum)
                {
                    continue;
                }

                taskPros.Add(self.RoleTaskList[i]);
            }

            return taskPros;
        }

        public static TaskPro GetTaskById(this TaskComponentC self, int taskId)
        {
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].taskID == taskId)
                    return self.RoleTaskList[i];
            }

            return null;
        }

        public static int GetNextMainTask(this TaskComponentC self)
        {
            int maxTask = 0;
            int nextTask = 0;
            List<int> completeTask = self.RoleComoleteTaskList;
            for (int i = 0; i < completeTask.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(completeTask[i]);
                if (taskConfig.TaskType != TaskTypeEnum.Main)
                {
                    continue;
                }

                if (taskConfig.Id > maxTask)
                {
                    maxTask = taskConfig.Id;
                }
            }

            List<TaskConfig> taskConfigs = TaskConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < taskConfigs.Count; i++)
            {
                if (taskConfigs[i].TaskType != TaskTypeEnum.Main)
                {
                    continue;
                }

                if (taskConfigs[i].Id > maxTask)
                {
                    nextTask = taskConfigs[i].Id;
                    break;
                }
            }

            return nextTask;
        }

        public static List<TaskPro> GetCompltedTaskByNpc(this TaskComponentC self, int npc)
        {
            List<TaskPro> taskPros = new List<TaskPro>();
            for (int k = 0; k < self.RoleTaskList.Count; k++)
            {
                if (!TaskConfigCategory.Instance.Contain(self.RoleTaskList[k].taskID))
                {
                    Log.Debug($"无效的任务ID {self.RoleTaskList[k].taskID}");
                    continue;
                }

                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[k].taskID);
                if (taskConfig.CompleteNpcID == npc && self.RoleTaskList[k].taskStatus == (int)TaskStatuEnum.Completed)
                {
                    taskPros.Add(self.RoleTaskList[k]);
                }
            }

            return taskPros;
        }

        public static List<int> GetOpenTaskIds(this TaskComponentC self, int npcid)
        {
            List<int> openTaskids = new List<int>();
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            if (npcConfig == null)
            {
                return openTaskids;
            }

            int[] taskid = npcConfig.TaskID;
            if (taskid == null)
            {
                return openTaskids;
            }
            
            Scene root = self.Root();

            int playerlv = root.GetComponent<UserInfoComponentC>().UserInfo.Lv;
            List<int> comtaskid = self.RoleComoleteTaskList;

            for (int i = 0; i < taskid.Length; i++)
            {
                if (taskid[i] == 0)
                    continue;
                if (self.GetTaskById(taskid[i]) != null)
                    continue;
                if (self.IsTaskFinished(taskid[i]))
                    continue;
                if (!TaskConfigCategory.Instance.Contain(taskid[i]))
                {
                    Log.Debug($"无效的任务ID {taskid[i]}");
                    continue;
                }

                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid[i]);
                if (taskConfig.TaskType == TaskTypeEnum.Treasure)
                {
                    Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
                    int treasureTask = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.TreasureTask);
                    if (FunctionHelp.CheckTreasure(taskid[i], treasureTask, playerlv) != ErrorCode.ERR_Success)
                    {
                        continue;
                    }
                }

                if (FunctionHelp.CheckTaskOn(taskConfig.TriggerType, taskConfig.TriggerValue, comtaskid, playerlv))
                {
                    openTaskids.Add(taskid[i]);
                }
            }

            return openTaskids;
        }

        public static void OnRecvTaskUpdate(this TaskComponentC self, M2C_TaskUpdate message)
        {
            if (message.UpdateMode == 2)
            {
                foreach (TaskPro taskpro in message.RoleTaskList)
                {
                    for (int i = 0; i < self.RoleTaskList.Count; i++)
                    {
                        if (taskpro.taskID != self.RoleTaskList[i].taskID)
                        {
                            continue;
                        }
                        self.RoleTaskList[i] = taskpro;
                    }
                }
            }
            else
            {
                self.RoleTaskList = message.RoleTaskList;
            }
            self.RoleComoleteTaskList = message.RoleComoleteTaskList;
            EventSystem.Instance.Publish(self.Root(), new TaskUpdate());
        }

        public static bool IsTaskFinished(this TaskComponentC self, int taskId)
        {
            return self.RoleComoleteTaskList.Contains(taskId);
        }

        public static int GetHuoYueDu(this TaskComponentC self)
        {
            int huoYueDu = 0;
            for (int i = 0; i < self.RoleTaskList.Count; i++)
            {
                if (self.RoleTaskList[i].taskStatus != (int)TaskStatuEnum.Commited)
                {
                    continue;
                }

                TaskConfig taskCountryConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                huoYueDu += taskCountryConfig.EveryTaskRewardNum;
            }

            return huoYueDu;
        }

        public static bool HaveWelfareReward(this TaskComponentC self)
        {
            for (int i = 0; i < ConfigData.WelfareTaskList.Count; i++)
            {
                List<int> taskList = ConfigData.WelfareTaskList[i];

                for (int task = 0; task < taskList.Count; task++)
                {
                    TaskPro taskPro = self.GetTaskById(taskList[task]);

                    if (taskPro != null && taskPro.taskStatus == (int)TaskStatuEnum.Completed)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static void OnResetSeason(this TaskComponentC self, bool notice)
        {
            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType == TaskTypeEnum.Season)
                {
                    self.RoleTaskList.RemoveAt(i);
                }
            }

            for (int i = self.RoleTaskList.Count - 1; i >= 0; i--)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(self.RoleTaskList[i].taskID);
                if (taskConfig.TaskType == TaskTypeEnum.Season)
                {
                    self.RoleTaskList.RemoveAt(i);
                }
            }
        }
    }
}