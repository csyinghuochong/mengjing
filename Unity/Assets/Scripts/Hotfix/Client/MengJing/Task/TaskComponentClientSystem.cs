using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(TaskComponentClient))]
    [EntitySystemOf(typeof(TaskComponentClient))]
    public static partial class TaskComponentClientSystem
    {
        [EntitySystem]
        private static void Awake(this TaskComponentClient self)
        {

        }
        [EntitySystem]
        private static void Destroy(this TaskComponentClient self)
        {

        }
        public static List<TaskPro> GetAllTrackList(this TaskComponentClient self)
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
        
        public static List<TaskPro> GetTaskTypeList(this TaskComponentClient self, int taskTypeEnum)
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
    }
}

