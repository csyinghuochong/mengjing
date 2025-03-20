using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class UnionConfigCategory : Singleton<UnionConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, UnionConfig> dict = new();
		
        public void Merge(object o)
        {
            UnionConfigCategory s = o as UnionConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public UnionConfig Get(int id)
        {
            this.dict.TryGetValue(id, out UnionConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (UnionConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, UnionConfig> GetAll()
        {
            return this.dict;
        }

        public UnionConfig GetOne()
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

	public partial class UnionConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>升级经验</summary>
		public int Exp { get; set; }
		/// <summary>修炼上限</summary>
		public int XiuLianLevel { get; set; }
		/// <summary>人员上限</summary>
		public int PeopleNum { get; set; }
		/// <summary>捐献消耗金币</summary>
		public int DonateGold { get; set; }
		/// <summary>捐献消耗钻石</summary>
		public int DonateDiamond { get; set; }
		/// <summary>捐献增加经验</summary>
		public int[] DonateExp { get; set; }
		/// <summary>捐献增加贡献值</summary>
		public int[] DonateReward { get; set; }
		/// <summary>升级全员奖励</summary>
		public string UpAllReward { get; set; }
		/// <summary>捐献增加家族金币</summary>
		public int[] AddUnionGold { get; set; }
		/// <summary>家族金币上限</summary>
		public int UnionGoldLimit { get; set; }
		/// <summary>消耗家族资金</summary>
		public int UnionGoldCost { get; set; }

	}
}
