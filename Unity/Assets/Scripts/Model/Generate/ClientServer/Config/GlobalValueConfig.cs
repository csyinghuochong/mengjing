using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class GlobalValueConfigCategory : Singleton<GlobalValueConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, GlobalValueConfig> dict = new();
		
        public void Merge(object o)
        {
            GlobalValueConfigCategory s = o as GlobalValueConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public GlobalValueConfig Get(int id)
        {
            this.dict.TryGetValue(id, out GlobalValueConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (GlobalValueConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, GlobalValueConfig> GetAll()
        {
            return this.dict;
        }

        public GlobalValueConfig GetOne()
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

	public partial class GlobalValueConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>值</summary>
		public string Value { get; set; }

	}
}
