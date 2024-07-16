using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class BattleSummonConfigCategory : Singleton<BattleSummonConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, BattleSummonConfig> dict = new();
		
        public void Merge(object o)
        {
            BattleSummonConfigCategory s = o as BattleSummonConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public BattleSummonConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BattleSummonConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BattleSummonConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BattleSummonConfig> GetAll()
        {
            return this.dict;
        }

        public BattleSummonConfig GetOne()
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

	public partial class BattleSummonConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>士兵名字</summary>
		public string ItemName { get; set; }
		/// <summary>战场ID</summary>
		public int SceneId { get; set; }
		/// <summary>士兵Id</summary>
		public int[] MonsterIds { get; set; }
		/// <summary>士兵数量</summary>
		public int MonsterNumber { get; set; }
		/// <summary>人口数量</summary>
		public int RenKouNumber { get; set; }
		/// <summary>消耗金币</summary>
		public int CostGold { get; set; }
		/// <summary>免费重置时间(s)</summary>
		public int FreeResetTime { get; set; }

	}
}
