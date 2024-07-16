using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MulLanguageConfigCategory : Singleton<MulLanguageConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MulLanguageConfig> dict = new();
		
        public void Merge(object o)
        {
            MulLanguageConfigCategory s = o as MulLanguageConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MulLanguageConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MulLanguageConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MulLanguageConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MulLanguageConfig> GetAll()
        {
            return this.dict;
        }

        public MulLanguageConfig GetOne()
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

	public partial class MulLanguageConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Chinese { get; set; }
		/// <summary>描述</summary>
		public string English { get; set; }

	}
}
