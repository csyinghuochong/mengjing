using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TowerConfigCategory : Singleton<TowerConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TowerConfig> dict = new();
		
        public void Merge(object o)
        {
            TowerConfigCategory s = o as TowerConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TowerConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TowerConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TowerConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TowerConfig> GetAll()
        {
            return this.dict;
        }

        public TowerConfig GetOne()
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

	public partial class TowerConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>地图类型</summary>
		public int MapType { get; set; }
		/// <summary>层数</summary>
		public int CengNum { get; set; }
		/// <summary>出现怪物</summary>
		public string MonsterSet { get; set; }
		/// <summary>强制刷新下一波时间</summary>
		public int NextTime { get; set; }
		/// <summary>掉落展示</summary>
		public string DropShow { get; set; }

	}
}
