using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class SeasonLevelConfigCategory : Singleton<SeasonLevelConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, SeasonLevelConfig> dict = new();
		
        public void Merge(object o)
        {
            SeasonLevelConfigCategory s = o as SeasonLevelConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public SeasonLevelConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SeasonLevelConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SeasonLevelConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SeasonLevelConfig> GetAll()
        {
            return this.dict;
        }

        public SeasonLevelConfig GetOne()
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

	public partial class SeasonLevelConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>升级经验</summary>
		public int UpExp { get; set; }
		/// <summary>奖励</summary>
		public string Reward { get; set; }
		/// <summary>赛季属性</summary>
		public string PripertySet { get; set; }

	}
}
