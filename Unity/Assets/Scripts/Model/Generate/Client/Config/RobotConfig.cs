using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class RobotConfigCategory : Singleton<RobotConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, RobotConfig> dict = new();
		
        public void Merge(object o)
        {
            RobotConfigCategory s = o as RobotConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public RobotConfig Get(int id)
        {
            this.dict.TryGetValue(id, out RobotConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (RobotConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, RobotConfig> GetAll()
        {
            return this.dict;
        }

        public RobotConfig GetOne()
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

	public partial class RobotConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>等级</summary>
		public int Level { get; set; }
		/// <summary>第一职业</summary>
		public int Occ { get; set; }
		/// <summary>第二职业</summary>
		public int OccTwo { get; set; }
		/// <summary>装备</summary>
		public int[] EquipList { get; set; }
		/// <summary>属性点</summary>
		public int[] PointList { get; set; }
		/// <summary>行为</summary>
		public int Behaviour { get; set; }
		/// <summary>行为ID</summary>
		public int BehaviourID { get; set; }
		/// <summary>参数</summary>
		public string AIParameter { get; set; }

	}
}
