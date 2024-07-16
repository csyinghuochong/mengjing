using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class JiaYuanPastureConfigCategory : Singleton<JiaYuanPastureConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, JiaYuanPastureConfig> dict = new();
		
        public void Merge(object o)
        {
            JiaYuanPastureConfigCategory s = o as JiaYuanPastureConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public JiaYuanPastureConfig Get(int id)
        {
            this.dict.TryGetValue(id, out JiaYuanPastureConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (JiaYuanPastureConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, JiaYuanPastureConfig> GetAll()
        {
            return this.dict;
        }

        public JiaYuanPastureConfig GetOne()
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

	public partial class JiaYuanPastureConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>等级</summary>
		public int Lv { get; set; }
		/// <summary>模型资源</summary>
		public string Assets { get; set; }
		/// <summary>成长时间</summary>
		public int[] UpTime { get; set; }
		/// <summary>人口数量</summary>
		public int PeopleNum { get; set; }
		/// <summary>购买价格</summary>
		public int BuyGold { get; set; }
		/// <summary>出售价格</summary>
		public int SellGold { get; set; }
		/// <summary>掉落间隔时间</summary>
		public int DropTime { get; set; }
		/// <summary>掉落概率</summary>
		public double GetPro { get; set; }
		/// <summary>收获道具ID</summary>
		public int GetItemID { get; set; }
		/// <summary>描述</summary>
		public string Speak { get; set; }
		/// <summary>描述</summary>
		public string Des { get; set; }
		/// <summary>购买家园限制</summary>
		public int BuyJiaYuanLv { get; set; }
		/// <summary>购买家园权重</summary>
		public int BuyJiaYuanPro { get; set; }

	}
}
