using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetTuJianConfigCategory : Singleton<PetTuJianConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetTuJianConfig> dict = new();
		
        public void Merge(object o)
        {
            PetTuJianConfigCategory s = o as PetTuJianConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetTuJianConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetTuJianConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetTuJianConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetTuJianConfig> GetAll()
        {
            return this.dict;
        }

        public PetTuJianConfig GetOne()
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

	public partial class PetTuJianConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>获取方式</summary>
		public int GetWay { get; set; }
		/// <summary>获取参数</summary>
		public int[] GetValue { get; set; }
		/// <summary>激活点数</summary>
		public int NeedPoint { get; set; }
		/// <summary>激活概率</summary>
		public double ActivePro { get; set; }
		/// <summary>精灵类型</summary>
		public int JingLingType { get; set; }
		/// <summary>召唤消耗</summary>
		public int Cost { get; set; }
		/// <summary>图标显示</summary>
		public int Icon { get; set; }
		/// <summary>模型</summary>
		public string Assets { get; set; }
		/// <summary>额外属性</summary>
		public string AddProperty { get; set; }
		/// <summary>境界</summary>
		public string Lv { get; set; }
		/// <summary>属性描述</summary>
		public string ProDes { get; set; }
		/// <summary>额外属性描述</summary>
		public string Des { get; set; }

	}
}
