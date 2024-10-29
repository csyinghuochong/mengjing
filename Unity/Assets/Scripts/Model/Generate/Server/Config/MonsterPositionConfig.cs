using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MonsterPositionConfigCategory : Singleton<MonsterPositionConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MonsterPositionConfig> dict = new();
		
        public void Merge(object o)
        {
            MonsterPositionConfigCategory s = o as MonsterPositionConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MonsterPositionConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MonsterPositionConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MonsterPositionConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MonsterPositionConfig> GetAll()
        {
            return this.dict;
        }

        public MonsterPositionConfig GetOne()
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

	public partial class MonsterPositionConfig: ProtoObject, IConfig
	{
		/// <summary>id</summary>
		public int Id { get; set; }
		/// <summary>下一个刷新ID</summary>
		public int NextID { get; set; }
		/// <summary>类型</summary>
		public int Type { get; set; }
		/// <summary>坐标点</summary>
		public string Position { get; set; }
		/// <summary>怪物ID</summary>
		public int[] MonsterID { get; set; }
		/// <summary>刷怪范围</summary>
		public double CreateRange { get; set; }
		/// <summary>刷怪数量</summary>
		public int[] CreateNum { get; set; }
		/// <summary>刷新朝向</summary>
		public int Create { get; set; }
		/// <summary>其他参数</summary>
		public string Par { get; set; }

	}
}
