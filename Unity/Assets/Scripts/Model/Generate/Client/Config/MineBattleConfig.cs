using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MineBattleConfigCategory : Singleton<MineBattleConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MineBattleConfig> dict = new();
		
        public void Merge(object o)
        {
            MineBattleConfigCategory s = o as MineBattleConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MineBattleConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MineBattleConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MineBattleConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MineBattleConfig> GetAll()
        {
            return this.dict;
        }

        public MineBattleConfig GetOne()
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

	public partial class MineBattleConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>地图类型(未用)</summary>
		public int Type { get; set; }
		/// <summary>图标</summary>
		public string Icon { get; set; }
		/// <summary>金币产出/小时</summary>
		public int GoldOutPut { get; set; }
		/// <summary>上限</summary>
		public int ChanChuLimit { get; set; }
		/// <summary>默认守护</summary>
		public int[] PetDefendInit { get; set; }

	}
}
