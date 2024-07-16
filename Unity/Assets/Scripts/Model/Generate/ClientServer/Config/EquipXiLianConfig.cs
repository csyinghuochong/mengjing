using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EquipXiLianConfigCategory : Singleton<EquipXiLianConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EquipXiLianConfig> dict = new();
		
        public void Merge(object o)
        {
            EquipXiLianConfigCategory s = o as EquipXiLianConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EquipXiLianConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipXiLianConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipXiLianConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipXiLianConfig> GetAll()
        {
            return this.dict;
        }

        public EquipXiLianConfig GetOne()
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

	public partial class EquipXiLianConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>洗练类型</summary>
		public int XiLianType { get; set; }
		/// <summary>洗练等级</summary>
		public int XiLianLevel { get; set; }
		/// <summary>需要熟练度</summary>
		public int NeedShuLianDu { get; set; }
		/// <summary>称号</summary>
		public string Title { get; set; }
		/// <summary>属性类型</summary>
		public int[] ProList_Type { get; set; }
		/// <summary>属性值</summary>
		public int[] ProList_Value { get; set; }
		/// <summary>达成奖励</summary>
		public string RewardList { get; set; }

	}
}
