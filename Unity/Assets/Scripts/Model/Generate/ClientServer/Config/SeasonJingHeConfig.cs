using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class SeasonJingHeConfigCategory : Singleton<SeasonJingHeConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, SeasonJingHeConfig> dict = new();
		
        public void Merge(object o)
        {
            SeasonJingHeConfigCategory s = o as SeasonJingHeConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public SeasonJingHeConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SeasonJingHeConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SeasonJingHeConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SeasonJingHeConfig> GetAll()
        {
            return this.dict;
        }

        public SeasonJingHeConfig GetOne()
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

	public partial class SeasonJingHeConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>开启消耗</summary>
		public string Cost { get; set; }
		/// <summary>额外属性</summary>
		public string AddProperty { get; set; }

	}
}
