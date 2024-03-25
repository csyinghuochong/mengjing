using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof(TaskComponentC))]
    [EntitySystemOf(typeof(TaskComponentC))]
    public static partial class TaskComponent_CSystem
    {
        [EntitySystem]
        private static void Awake(this TaskComponentC self)
        {

        }
        [EntitySystem]
        private static void Destroy(this TaskComponentC self)
        {

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

        
    }
}

