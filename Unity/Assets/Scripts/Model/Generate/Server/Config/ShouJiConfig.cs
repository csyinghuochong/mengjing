using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ShouJiConfigCategory : Singleton<ShouJiConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ShouJiConfig> dict = new();
		
        public void Merge(object o)
        {
            ShouJiConfigCategory s = o as ShouJiConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ShouJiConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ShouJiConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ShouJiConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ShouJiConfig> GetAll()
        {
            return this.dict;
        }

        public ShouJiConfig GetOne()
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

	public partial class ShouJiConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>开启等级</summary>
		public int OpenLv { get; set; }
		/// <summary>章节ID</summary>
		public int ChapterNum { get; set; }
		/// <summary>章节描述</summary>
		public string ChapterDes { get; set; }
		/// <summary>物品ID</summary>
		public int ItemListID { get; set; }
		/// <summary>星级1</summary>
		public int ProList1_StartNum { get; set; }
		/// <summary>星级1属性类型</summary>
		public int[] ProList1_Type { get; set; }
		/// <summary>星级1属性值</summary>
		public long[] ProList1_Value { get; set; }
		/// <summary>奖励</summary>
		public string RewardList_1 { get; set; }
		/// <summary>星级2</summary>
		public int ProList2_StartNum { get; set; }
		/// <summary>星级2属性类型</summary>
		public int[] ProList2_Type { get; set; }
		/// <summary>星级2属性值</summary>
		public long[] ProList2_Value { get; set; }
		/// <summary>奖励</summary>
		public string RewardList_2 { get; set; }
		/// <summary>星级3</summary>
		public int ProList3_StartNum { get; set; }
		/// <summary>星级3属性类型</summary>
		public int[] ProList3_Type { get; set; }
		/// <summary>星级3属性值</summary>
		public long[] ProList3_Value { get; set; }
		/// <summary>奖励</summary>
		public string RewardList_3 { get; set; }

	}
}
