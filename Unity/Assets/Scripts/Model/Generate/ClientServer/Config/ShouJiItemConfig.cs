using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ShouJiItemConfigCategory : Singleton<ShouJiItemConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ShouJiItemConfig> dict = new();
		
        public void Merge(object o)
        {
            ShouJiItemConfigCategory s = o as ShouJiItemConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ShouJiItemConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ShouJiItemConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ShouJiItemConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ShouJiItemConfig> GetAll()
        {
            return this.dict;
        }

        public ShouJiItemConfig GetOne()
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

	public partial class ShouJiItemConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>下一个道具ID</summary>
		public int NextID { get; set; }
		/// <summary>道具ID</summary>
		public int ItemID { get; set; }
		/// <summary>道具星数</summary>
		public int StartNum { get; set; }
		/// <summary>章节</summary>
		public int Chap { get; set; }
		/// <summary>收集类型</summary>
		public int StartType { get; set; }
		/// <summary>激活数量</summary>
		public int AcitveNum { get; set; }
		/// <summary>附加属性</summary>
		public string AddPropreListStr { get; set; }

	}
}
