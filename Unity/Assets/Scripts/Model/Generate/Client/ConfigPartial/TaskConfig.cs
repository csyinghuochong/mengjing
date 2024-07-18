using System.Collections.Generic;

namespace ET
{
    public partial class TaskConfigCategory
    {

        public Dictionary<int, List<int>> SeasonTaskList = new Dictionary<int, List<int>>();

        public override void EndInit()
        {
            foreach (TaskConfig taskCountryConfig in this.GetAll().Values)
            {

                if (taskCountryConfig.TaskType != TaskTypeEnum.Season)
                {
                    continue;
                }

                int taskNumber = 0; //数量

                if (taskCountryConfig.Id >= 600101 && taskCountryConfig.Id <= 600200)
                {
                    taskNumber = 5;
                }
                if (taskCountryConfig.Id >= 600201 && taskCountryConfig.Id <= 600300)
                {
                    taskNumber = 3;
                }
                if (taskCountryConfig.Id >= 600301 && taskCountryConfig.Id <= 600400)
                {
                    taskNumber = 2;
                }
                if (taskNumber == 0)
                {
                    continue;
                }

                if (!SeasonTaskList.ContainsKey(taskNumber))
                {
                    SeasonTaskList.Add(taskNumber, new List<int>());
                }
                SeasonTaskList[taskNumber].Add(taskCountryConfig.Id);
            }
        }
    }
}
