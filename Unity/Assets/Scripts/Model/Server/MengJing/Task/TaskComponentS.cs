using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class TaskComponentS : Entity, IAwake, ITransfer, IDestroy, IUnitCache, IDeserialize
    {
        public int OnLineTime { get; set; } = 0;  //秒
        public List<int> ReceiveHuoYueIds = new List<int>();

        public List<int> ReceiveGrowUpRewardIds { get; set; } = new List<int>();

        public List<TaskPro> RoleTaskList = new List<TaskPro>();
        public List<int> RoleComoleteTaskList { get; set; } = new List<int>();

    }
}
