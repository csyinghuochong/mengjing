using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class DungeonSectionConfigCategory : Singleton<DungeonSectionConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, DungeonSectionConfig> dict = new();
		
        public void Merge(object o)
        {
            DungeonSectionConfigCategory s = o as DungeonSectionConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public DungeonSectionConfig Get(int id)
        {
            this.dict.TryGetValue(id, out DungeonSectionConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (DungeonSectionConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, DungeonSectionConfig> GetAll()
        {
            return this.dict;
        }

        public DungeonSectionConfig GetOne()
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

	public partial class DungeonSectionConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>章节名称</summary>
		public string ChapterName { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>章节关卡</summary>
		public int[] RandomArea { get; set; }
		/// <summary>开启等级</summary>
		public int[] OpenLevel { get; set; }
		/// <summary>神秘之门地图ID</summary>
		public string ShenMiEnterID { get; set; }
		/// <summary>ui偏移x,y</summary>
		public int[] Offset { get; set; }
		/// <summary>缩放</summary>
		public double[] Size { get; set; }

	}
}
