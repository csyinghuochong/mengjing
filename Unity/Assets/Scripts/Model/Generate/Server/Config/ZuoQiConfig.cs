using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ZuoQiConfigCategory : Singleton<ZuoQiConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ZuoQiConfig> dict = new();
		
        public void Merge(object o)
        {
            ZuoQiConfigCategory s = o as ZuoQiConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ZuoQiConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ZuoQiConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ZuoQiConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ZuoQiConfig> GetAll()
        {
            return this.dict;
        }

        public ZuoQiConfig GetOne()
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

	public partial class ZuoQiConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>图标显示</summary>
		public int Icon { get; set; }
		/// <summary>下一级ID</summary>
		public int NextID { get; set; }
		/// <summary>阶段名称</summary>
		public string JieName { get; set; }
		/// <summary>品质</summary>
		public int Lv { get; set; }
		/// <summary>升级需要</summary>
		public int UpNeedLv { get; set; }
		/// <summary>消耗金币</summary>
		public int UpZiZhiCostGold { get; set; }
		/// <summary>升级消耗</summary>
		public int UpCostZiJin { get; set; }
		/// <summary>资质上限</summary>
		public int ZiZhiMax { get; set; }
		/// <summary>额外属性</summary>
		public string AddProperty { get; set; }
		/// <summary>额外属性描述</summary>
		public string Des { get; set; }

	}
}
