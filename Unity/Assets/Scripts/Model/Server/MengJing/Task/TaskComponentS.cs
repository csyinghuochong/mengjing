using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class TaskComponentS : Entity, IAwake, ITransfer, IDestroy, IUnitCache, IDeserialize
    {
        public int OnLineTime { get; set; } = 0;
        public List<int> ReceiveHuoYueIds = new List<int>();
        public List<TaskPro> TaskCountryList = new List<TaskPro>();
        public List<TaskPro> RoleTaskList = new List<TaskPro>();
        public List<int> RoleComoleteTaskList { get; set; } = new List<int>();

        [BsonIgnore]
        public M2C_TaskCountryUpdate m2C_TaskCountryUpdate = M2C_TaskCountryUpdate.Create();

        [BsonIgnore]
        public M2C_TaskUpdate M2C_TaskUpdate = M2C_TaskUpdate.Create();
    }
}
