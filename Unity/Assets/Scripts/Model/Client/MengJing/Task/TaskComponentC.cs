using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class TaskComponentC: Entity, IAwake, IDestroy
    {
        public List<int> ReceiveHuoYueIds { get; set; } = new();
        
        public List<int> ReceiveGrowUpRewardIds { get; set; } = new List<int>();
        public List<TaskPro> RoleTaskList { get; set; } = new();
        
        public List<int> RoleComoleteTaskList { get; set; } = new();
    }
}