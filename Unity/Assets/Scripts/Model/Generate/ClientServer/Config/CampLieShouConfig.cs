using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class CampLieShouConfigCategory : Singleton<CampLieShouConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, CampLieShouConfig> dict = new();
		
        public void Merge(object o)
        {
            CampLieShouConfigCategory s = o as CampLieShouConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public CampLieShouConfig Get(int id)
        {
            this.dict.TryGetValue(id, out CampLieShouConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (CampLieShouConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, CampLieShouConfig> GetAll()
        {
            return this.dict;
        }

        public CampLieShouConfig GetOne()
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

	public partial class CampLieShouConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>任务名称</summary>
		public string TaskName { get; set; }
		/// <summary>目标类型</summary>
		public int TargetType { get; set; }
		/// <summary>目标ID</summary>
		public int[] Target { get; set; }
		/// <summary>目标值</summary>
		public int[] TargetValue { get; set; }

	}
}
