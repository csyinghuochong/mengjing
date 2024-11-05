using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MapObjectConfigCategory : Singleton<MapObjectConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MapObjectConfig> dict = new();
		
        public void Merge(object o)
        {
            MapObjectConfigCategory s = o as MapObjectConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MapObjectConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MapObjectConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MapObjectConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MapObjectConfig> GetAll()
        {
            return this.dict;
        }

        public MapObjectConfig GetOne()
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

	public partial class MapObjectConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>场景配置</summary>
		public string MapConfig { get; set; }

	}
}
