using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ActivityConfigCategory : Singleton<ActivityConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ActivityConfig> dict = new();
		
        public void Merge(object o)
        {
            ActivityConfigCategory s = o as ActivityConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ActivityConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ActivityConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ActivityConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ActivityConfig> GetAll()
        {
            return this.dict;
        }

        public ActivityConfig GetOne()
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

	public partial class ActivityConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>活动类型</summary>
		public int ActivityType { get; set; }
		/// <summary>Icon显示</summary>
		public string Icon { get; set; }
		/// <summary>参数_1</summary>
		public string Par_1 { get; set; }
		/// <summary>参数_2</summary>
		public string Par_2 { get; set; }
		/// <summary>参数_3</summary>
		public string Par_3 { get; set; }
		/// <summary>参数_4</summary>
		public string Par_4 { get; set; }

	}
}
