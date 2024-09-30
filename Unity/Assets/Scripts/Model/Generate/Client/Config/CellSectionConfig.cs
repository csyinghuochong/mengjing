using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class CellSectionConfigCategory : Singleton<CellSectionConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, CellSectionConfig> dict = new();
		
        public void Merge(object o)
        {
            CellSectionConfigCategory s = o as CellSectionConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public CellSectionConfig Get(int id)
        {
            this.dict.TryGetValue(id, out CellSectionConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (CellSectionConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, CellSectionConfig> GetAll()
        {
            return this.dict;
        }

        public CellSectionConfig GetOne()
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

	public partial class CellSectionConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>章节名称</summary>
		public string ChapterName { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>章节关卡</summary>
		public int[] RandomArea { get; set; }

	}
}
