using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class JiaYuanFarmConfigCategory : Singleton<JiaYuanFarmConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, JiaYuanFarmConfig> dict = new();
		
        public void Merge(object o)
        {
            JiaYuanFarmConfigCategory s = o as JiaYuanFarmConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public JiaYuanFarmConfig Get(int id)
        {
            this.dict.TryGetValue(id, out JiaYuanFarmConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (JiaYuanFarmConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, JiaYuanFarmConfig> GetAll()
        {
            return this.dict;
        }

        public JiaYuanFarmConfig GetOne()
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

	public partial class JiaYuanFarmConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>等级</summary>
		public int Lv { get; set; }
		/// <summary>模型ID</summary>
		public int ModelID { get; set; }
		/// <summary>成长时间</summary>
		public int[] UpTime { get; set; }
		/// <summary>人口数量</summary>
		public int PeopleNum { get; set; }
		/// <summary>购买价格</summary>
		public int BuyGold { get; set; }
		/// <summary>出售价格</summary>
		public int SellGold { get; set; }
		/// <summary>收获道具ID</summary>
		public int GetItemID { get; set; }
		/// <summary>描述</summary>
		public string Speak { get; set; }
		/// <summary>描述</summary>
		public string Des { get; set; }
		/// <summary>收货间隔时间</summary>
		public int GetItemTime { get; set; }
		/// <summary>收货次数上限</summary>
		public int GetItemNum { get; set; }

	}
}
