using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class CampFuLiConfigCategory : Singleton<CampFuLiConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, CampFuLiConfig> dict = new();
		
        public void Merge(object o)
        {
            CampFuLiConfigCategory s = o as CampFuLiConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public CampFuLiConfig Get(int id)
        {
            this.dict.TryGetValue(id, out CampFuLiConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (CampFuLiConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, CampFuLiConfig> GetAll()
        {
            return this.dict;
        }

        public CampFuLiConfig GetOne()
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

	public partial class CampFuLiConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>职位</summary>
		public string Postion { get; set; }
		/// <summary>胜利阵营币</summary>
		public int Win_Reward { get; set; }
		/// <summary>失败阵营币</summary>
		public int Fail_Reward { get; set; }

	}
}
