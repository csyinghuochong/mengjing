using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class OccupationJueXingConfigCategory : Singleton<OccupationJueXingConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, OccupationJueXingConfig> dict = new();
		
        public void Merge(object o)
        {
            OccupationJueXingConfigCategory s = o as OccupationJueXingConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public OccupationJueXingConfig Get(int id)
        {
            this.dict.TryGetValue(id, out OccupationJueXingConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (OccupationJueXingConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, OccupationJueXingConfig> GetAll()
        {
            return this.dict;
        }

        public OccupationJueXingConfig GetOne()
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

	public partial class OccupationJueXingConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>觉醒经验</summary>
		public int costExp { get; set; }
		/// <summary>觉醒金币</summary>
		public int costGold { get; set; }
		/// <summary>前置技能</summary>
		public int[] Pre_Condition { get; set; }
		/// <summary>消耗道具</summary>
		public string costItem { get; set; }

	}
}
