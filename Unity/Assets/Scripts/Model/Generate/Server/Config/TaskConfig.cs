using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TaskConfigCategory : Singleton<TaskConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TaskConfig> dict = new();
		
        public void Merge(object o)
        {
            TaskConfigCategory s = o as TaskConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TaskConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TaskConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TaskConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TaskConfig> GetAll()
        {
            return this.dict;
        }

        public TaskConfig GetOne()
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

	public partial class TaskConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>任务名称</summary>
		public string TaskName { get; set; }
		/// <summary>任务等级</summary>
		public int TaskLv { get; set; }
		/// <summary>任务图标</summary>
		public string TaskIcon { get; set; }
		/// <summary>最大接取等级</summary>
		public int TaskMaxLv { get; set; }
		/// <summary>任务类型</summary>
		public int TaskType { get; set; }
		/// <summary>任务子类</summary>
		public int TaskSonType { get; set; }
		/// <summary>触发类型</summary>
		public int TriggerType { get; set; }
		/// <summary>触发值</summary>
		public int TriggerValue { get; set; }
		/// <summary>下个任务</summary>
		public int NextTask { get; set; }
		/// <summary>任务经验</summary>
		public int TaskExp { get; set; }
		/// <summary>任务金币</summary>
		public int TaskCoin { get; set; }
		/// <summary>活跃度</summary>
		public int EveryTaskRewardNum { get; set; }
		/// <summary>奖励道具ID</summary>
		public string RewardItem { get; set; }
		/// <summary>接取任务的NPC</summary>
		public int GetNpcID { get; set; }
		/// <summary>交任务的Npc</summary>
		public int CompleteNpcID { get; set; }
		/// <summary>目标类型</summary>
		public int TargetType { get; set; }
		/// <summary>目标ID</summary>
		public int[] Target { get; set; }
		/// <summary>目标值</summary>
		public int[] TargetValue { get; set; }
		/// <summary>目标点</summary>
		public int TargetPosition { get; set; }
		/// <summary>任务描述</summary>
		public string TaskDes { get; set; }
		/// <summary>任务经验和金币是否跟随等级成长</summary>
		public int Development { get; set; }
		/// <summary>权重</summary>
		public int Weight { get; set; }

	}
}
