using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TaskCountryConfigCategory : Singleton<TaskCountryConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TaskCountryConfig> dict = new();
		
        public void Merge(object o)
        {
            TaskCountryConfigCategory s = o as TaskCountryConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TaskCountryConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TaskCountryConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TaskCountryConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TaskCountryConfig> GetAll()
        {
            return this.dict;
        }

        public TaskCountryConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class TaskCountryConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>任务名称</summary>
		public string TaskName { get; set; }
		/// <summary>任务类型</summary>
		public int TaskType { get; set; }
		/// <summary>图标</summary>
		public int TaskIcon { get; set; }
		/// <summary>任务等级</summary>
		public int TaskLv { get; set; }
		/// <summary>下个任务</summary>
		public int NextTask { get; set; }
		/// <summary>触发概率</summary>
		public double TriggerPro { get; set; }
		/// <summary>触发类型</summary>
		public int TriggerType { get; set; }
		/// <summary>触发值</summary>
		public int TriggerValue { get; set; }
		/// <summary>活跃度奖励</summary>
		public int EveryTaskRewardNum { get; set; }
		/// <summary>奖励金币</summary>
		public int RewardGold { get; set; }
		/// <summary>奖励道具</summary>
		public string RewardItem { get; set; }
		/// <summary>目标类型</summary>
		public int TargetType { get; set; }
		/// <summary>目标ID</summary>
		public int[] Target { get; set; }
		/// <summary>目标值1</summary>
		public int[] TargetValue { get; set; }
		/// <summary>任务描述</summary>
		public string TaskDes { get; set; }

	}
}
