using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ChengJiuConfigCategory : Singleton<ChengJiuConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ChengJiuConfig> dict = new();
		
        public void Merge(object o)
        {
            ChengJiuConfigCategory s = o as ChengJiuConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ChengJiuConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ChengJiuConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ChengJiuConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ChengJiuConfig> GetAll()
        {
            return this.dict;
        }

        public ChengJiuConfig GetOne()
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

	public partial class ChengJiuConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>成就类型</summary>
		public int ChengjiuType { get; set; }
		/// <summary>章节ID</summary>
		public int ChapterId { get; set; }
		/// <summary>成就名称</summary>
		public string Name { get; set; }
		/// <summary>称号图片</summary>
		public int Icon { get; set; }
		/// <summary>奖励成就点数</summary>
		public int RewardNum { get; set; }
		/// <summary>目标要求类型</summary>
		public int TargetType { get; set; }
		/// <summary>目标要求值</summary>
		public int TargetID { get; set; }
		/// <summary>目标要求值</summary>
		public int TargetValue { get; set; }
		/// <summary>描述</summary>
		public string Des { get; set; }

	}
}
