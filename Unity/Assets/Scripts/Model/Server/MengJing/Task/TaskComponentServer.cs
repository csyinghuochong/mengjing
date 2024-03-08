using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class TaskComponentServer : Entity, IAwake, ITransfer, IDestroy, IUnitCache, IDeserialize
    {
        public int OnLineTime = 0;
        public List<int> ReceiveHuoYueIds = new List<int>();
        public List<TaskPro> TaskCountryList = new List<TaskPro>();
        public List<TaskPro> RoleTaskList = new List<TaskPro>();
        public List<int> RoleComoleteTaskList = new List<int>();

        [BsonIgnore]
        public M2C_TaskCountryUpdate m2C_TaskCountryUpdate = new M2C_TaskCountryUpdate();
        [BsonIgnore]
        public M2C_TaskUpdate M2C_TaskUpdate = new M2C_TaskUpdate();
    }
}
