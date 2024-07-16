using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class FashionConfigCategory : Singleton<FashionConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, FashionConfig> dict = new();
		
        public void Merge(object o)
        {
            FashionConfigCategory s = o as FashionConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public FashionConfig Get(int id)
        {
            this.dict.TryGetValue(id, out FashionConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (FashionConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, FashionConfig> GetAll()
        {
            return this.dict;
        }

        public FashionConfig GetOne()
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

	public partial class FashionConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>职业</summary>
		public int[] Occ { get; set; }
		/// <summary>时装部位</summary>
		public int Position { get; set; }
		/// <summary>时装子类</summary>
		public int SubType { get; set; }
		/// <summary>时装名字</summary>
		public string Name { get; set; }
		/// <summary>时装模型</summary>
		public string Model { get; set; }
		/// <summary>激活条件</summary>
		public string ActiveCost { get; set; }
		/// <summary>时装属性加成Key</summary>
		public int[] ItemModelID { get; set; }
		/// <summary>摄像机参数</summary>
		public double[] Camera { get; set; }

	}
}
