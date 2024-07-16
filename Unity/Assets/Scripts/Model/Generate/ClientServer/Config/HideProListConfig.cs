using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class HideProListConfigCategory : Singleton<HideProListConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, HideProListConfig> dict = new();
		
        public void Merge(object o)
        {
            HideProListConfigCategory s = o as HideProListConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public HideProListConfig Get(int id)
        {
            this.dict.TryGetValue(id, out HideProListConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (HideProListConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, HideProListConfig> GetAll()
        {
            return this.dict;
        }

        public HideProListConfig GetOne()
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

	public partial class HideProListConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>隐藏属性名称</summary>
		public string Name { get; set; }
		/// <summary>下一ID</summary>
		public int NtxtID { get; set; }
		/// <summary>洗炼属性出现部位</summary>
		public int[] EquipSpace { get; set; }
		/// <summary>需要洗炼等级</summary>
		public int NeedXiLianLv { get; set; }
		/// <summary>随机概率</summary>
		public double TriggerPro { get; set; }
		/// <summary>隐藏属性类型</summary>
		public int PropertyType { get; set; }
		/// <summary>是否根据等级成长</summary>
		public int IfEquipLvUp { get; set; }
		/// <summary>隐藏属性类型</summary>
		public int HideProValueType { get; set; }
		/// <summary>隐藏属性最小值</summary>
		public string PropertyValueMin { get; set; }
		/// <summary>隐藏属性最大值</summary>
		public string PropertyValueMax { get; set; }
		/// <summary>附加战力</summary>
		public int AddFightValue { get; set; }
		/// <summary>转移是否继承</summary>
		public int IfMove { get; set; }
		/// <summary>激活条件</summary>
		public int NeedNumber { get; set; }

	}
}
