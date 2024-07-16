using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TakeCardConfigCategory : Singleton<TakeCardConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TakeCardConfig> dict = new();
		
        public void Merge(object o)
        {
            TakeCardConfigCategory s = o as TakeCardConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TakeCardConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TakeCardConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TakeCardConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TakeCardConfig> GetAll()
        {
            return this.dict;
        }

        public TakeCardConfig GetOne()
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

	public partial class TakeCardConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>抽卡等级</summary>
		public int RoseLvLimit { get; set; }
		/// <summary>抽卡消耗钻石</summary>
		public int ZuanShiNum { get; set; }
		/// <summary>抽卡消耗钻石</summary>
		public int ZuanShiNum_Ten { get; set; }
		/// <summary>掉落ID</summary>
		public int DropID { get; set; }
		/// <summary>掉落展示ID</summary>
		public string DropShow { get; set; }

	}
}
