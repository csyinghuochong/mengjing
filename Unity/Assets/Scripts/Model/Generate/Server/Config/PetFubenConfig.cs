using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetFubenConfigCategory : Singleton<PetFubenConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetFubenConfig> dict = new();
		
        public void Merge(object o)
        {
            PetFubenConfigCategory s = o as PetFubenConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetFubenConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetFubenConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetFubenConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetFubenConfig> GetAll()
        {
            return this.dict;
        }

        public PetFubenConfig GetOne()
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

	public partial class PetFubenConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>推荐战力</summary>
		public int Combat { get; set; }
		/// <summary>推荐等级</summary>
		public int Lv { get; set; }
		/// <summary>格子1</summary>
		public string Cell_1 { get; set; }
		/// <summary>格子2</summary>
		public string Cell_2 { get; set; }
		/// <summary>格子3</summary>
		public string Cell_3 { get; set; }
		/// <summary>格子4</summary>
		public string Cell_4 { get; set; }
		/// <summary>格子5</summary>
		public string Cell_5 { get; set; }
		/// <summary>格子6</summary>
		public string Cell_6 { get; set; }
		/// <summary>格子7</summary>
		public string Cell_7 { get; set; }
		/// <summary>格子8</summary>
		public string Cell_8 { get; set; }
		/// <summary>格子9</summary>
		public string Cell_9 { get; set; }
		/// <summary>展示Icon</summary>
		public string ShowIcon { get; set; }

	}
}
