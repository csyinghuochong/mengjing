using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ZuoQiNengLiConfigCategory : Singleton<ZuoQiNengLiConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ZuoQiNengLiConfig> dict = new();
		
        public void Merge(object o)
        {
            ZuoQiNengLiConfigCategory s = o as ZuoQiNengLiConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ZuoQiNengLiConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ZuoQiNengLiConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ZuoQiNengLiConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ZuoQiNengLiConfig> GetAll()
        {
            return this.dict;
        }

        public ZuoQiNengLiConfig GetOne()
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

	public partial class ZuoQiNengLiConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>图标显示</summary>
		public string Icon { get; set; }
		/// <summary>下一级ID</summary>
		public int NextID { get; set; }
		/// <summary>等级</summary>
		public int Lv { get; set; }
		/// <summary>经验值</summary>
		public int Exp { get; set; }
		/// <summary>升级消耗</summary>
		public int UpCostItemID { get; set; }
		/// <summary>升级消耗</summary>
		public int UpCostZiJin { get; set; }
		/// <summary>升级消耗</summary>
		public int UpCostGold { get; set; }
		/// <summary>升级经验</summary>
		public int UpAddExp { get; set; }
		/// <summary>坐骑能力等级属性</summary>
		public string AddProperty { get; set; }

	}
}
