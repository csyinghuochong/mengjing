using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class FuntionConfigCategory : Singleton<FuntionConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, FuntionConfig> dict = new();
		
        public void Merge(object o)
        {
            FuntionConfigCategory s = o as FuntionConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public FuntionConfig Get(int id)
        {
            this.dict.TryGetValue(id, out FuntionConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (FuntionConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, FuntionConfig> GetAll()
        {
            return this.dict;
        }

        public FuntionConfig GetOne()
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

	public partial class FuntionConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>UI</summary>
		public string Name { get; set; }
		/// <summary>开启条件类型</summary>
		public int[] ConditionType { get; set; }
		/// <summary>开启条件参数</summary>
		public int[] ConditionParam { get; set; }
		/// <summary>开启时间</summary>
		public string OpenTime { get; set; }
		/// <summary>开始时间 周1-周7</summary>
		public int[] OpenDay { get; set; }
		/// <summary>是否开启</summary>
		public string IfOpen { get; set; }
		/// <summary>刷怪场景</summary>
		public int SceneId { get; set; }
		/// <summary>刷怪配置</summary>
		public int[] CreateMonsterPosi { get; set; }

	}
}
