using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class DungeonTransferConfigCategory : Singleton<DungeonTransferConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, DungeonTransferConfig> dict = new();
		
        public void Merge(object o)
        {
            DungeonTransferConfigCategory s = o as DungeonTransferConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public DungeonTransferConfig Get(int id)
        {
            this.dict.TryGetValue(id, out DungeonTransferConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (DungeonTransferConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, DungeonTransferConfig> GetAll()
        {
            return this.dict;
        }

        public DungeonTransferConfig GetOne()
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

	public partial class DungeonTransferConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>地图ID</summary>
		public int MapID { get; set; }
		/// <summary>进入等级</summary>
		public int EnterLv { get; set; }
		/// <summary>位置【进入新场景出生点】</summary>
		public int[] BornPos { get; set; }
		/// <summary>位置[传送门]</summary>
		public int[] Position { get; set; }

	}
}
