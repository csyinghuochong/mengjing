namespace ET.Client
{
    public static class TaskViewHelp
    {
        public delegate bool TaskExcuteDelegate(Scene scene, TaskPro taskPro, TaskConfig taskConfig);

        public delegate string TaskDescDelegate(TaskPro taskPro, TaskConfig taskConfig);

        public struct TaskLogic
        {
            public TaskExcuteDelegate taskExcute;
            public TaskDescDelegate taskProgess;
        }

        public static TaskLogic GetTaskLogic(int targetType)
        {
            switch (targetType)
            {
                case TaskTargetType.KillMonsterID_1:
                    return new TaskLogic() { taskExcute = ExcuteKillMonsterID, taskProgess = GetDescKillMonsterID };
                case TaskTargetType.ItemID_Number_2:
                    return new TaskLogic() { taskExcute = ExcuteItemId, taskProgess = GetDescItemId };
            }

            return default;
        }

        private static bool ExcuteKillMonsterID(Scene root, TaskPro taskPro, TaskConfig taskConfig)
        {
            return true;
        }

        private static string GetDescKillMonsterID(TaskPro taskPro, TaskConfig taskConfig)
        {
            string desc = "";
            string progress = "击败{0} {1}/{2} {3}";

            for (int i = 0; i < taskConfig.Target.Length; i++)
            {
                int monsterId = taskConfig.Target[i];
                int fubenId = SceneConfigHelper.GetFubenByMonster(monsterId);
                fubenId = taskPro.FubenId > 0? taskPro.FubenId : fubenId;
                string fubenName = fubenId > 0? " (地图:" + DungeonConfigCategory.Instance.Get(fubenId).ChapterName + ")" : "";
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);

                string text1 = "";
                if (i == 0)
                {
                    text1 = string.Format(progress, monsterConfig.MonsterName, taskPro.taskTargetNum_1, taskConfig.TargetValue[i], fubenName);
                }

                if (i == 1)
                {
                    text1 = string.Format(progress, monsterConfig.MonsterName, taskPro.taskTargetNum_2, taskConfig.TargetValue[i], fubenName);
                }

                desc = desc + text1 + "\n";
            }

            return desc;
        }

        private static bool ExcuteItemId(Scene domainscene, TaskPro taskPro, TaskConfig taskConfig)
        {
            return true;
        }

        private static string GetDescItemId(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = GameSettingLanguge.LoadLocalization("寻找道具{0} {1}/{2}");
            int itemId = taskConfig.Target[0];
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            string text1 = string.Format(progress, itemConfig.ItemName, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            return text1;
        }

        public static string GetTaskProgessDesc(TaskPro taskPro)
        {
            int taskId = taskPro.taskID;
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            int TargetType = taskConfig.TargetType;

            return GetTaskLogic(TargetType).taskProgess(taskPro, taskConfig);
        }
    }
}