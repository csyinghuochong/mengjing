using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ZuoQiShowConfigCategory : Singleton<ZuoQiShowConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ZuoQiShowConfig> dict = new();
		
        public void Merge(object o)
        {
            ZuoQiShowConfigCategory s = o as ZuoQiShowConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ZuoQiShowConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ZuoQiShowConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ZuoQiShowConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ZuoQiShowConfig> GetAll()
        {
            return this.dict;
        }

        public ZuoQiShowConfig GetOne()
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

	public partial class ZuoQiShowConfig: ProtoObject, IConfig
	{
		/// <summary>ID</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>品质</summary>
		public int Quality { get; set; }
		/// <summary>图标显示</summary>
		public string Icon { get; set; }
		/// <summary>模型ID</summary>
		public string ModelID { get; set; }
		/// <summary>拖尾特效名称</summary>
		public string TuoWeiEffectID { get; set; }
		/// <summary>描述</summary>
		public string Des { get; set; }
		/// <summary>属性描述</summary>
		public string AddPropertyDes { get; set; }
		/// <summary>额外属性</summary>
		public string AddProperty { get; set; }
		/// <summary>描述</summary>
		public string GetDes { get; set; }
		/// <summary>对应骑乘Buff</summary>
		public int MoveBuffID { get; set; }
		/// <summary>玩家名称显示上移</summary>
		public double NameShowUp { get; set; }

	}
}
