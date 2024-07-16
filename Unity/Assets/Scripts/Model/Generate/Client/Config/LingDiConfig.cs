using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class LingDiConfigCategory : Singleton<LingDiConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, LingDiConfig> dict = new();
		
        public void Merge(object o)
        {
            LingDiConfigCategory s = o as LingDiConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public LingDiConfig Get(int id)
        {
            this.dict.TryGetValue(id, out LingDiConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (LingDiConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, LingDiConfig> GetAll()
        {
            return this.dict;
        }

        public LingDiConfig GetOne()
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

	public partial class LingDiConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>领地名称</summary>
		public string Name { get; set; }
		/// <summary>升级经验</summary>
		public int UpExp { get; set; }
		/// <summary>每次消耗金币</summary>
		public int GoldUp { get; set; }
		/// <summary>消耗增加经验</summary>
		public int AddExp { get; set; }
		/// <summary>每小时产出经验</summary>
		public int HoureExp { get; set; }
		/// <summary>每小时产出荣誉</summary>
		public int HoureHonor { get; set; }

	}
}
