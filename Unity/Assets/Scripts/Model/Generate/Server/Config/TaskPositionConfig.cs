using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TaskPositionConfigCategory : Singleton<TaskPositionConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TaskPositionConfig> dict = new();
		
        public void Merge(object o)
        {
            TaskPositionConfigCategory s = o as TaskPositionConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TaskPositionConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TaskPositionConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TaskPositionConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TaskPositionConfig> GetAll()
        {
            return this.dict;
        }

        public TaskPositionConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            
            var enumerator = this.dict.Values.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current; 
        }
    }

	public partial class TaskPositionConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>传送点名称</summary>
		public string MapName { get; set; }
		/// <summary>传送地图</summary>
		public int MapID { get; set; }
		/// <summary>传送坐标点</summary>
		public string PositionName { get; set; }
		/// <summary>其余地图</summary>
		public string OtherMapMove { get; set; }

	}
}
