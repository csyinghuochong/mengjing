using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TitleConfigCategory : Singleton<TitleConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TitleConfig> dict = new();
		
        public void Merge(object o)
        {
            TitleConfigCategory s = o as TitleConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TitleConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TitleConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TitleConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TitleConfig> GetAll()
        {
            return this.dict;
        }

        public TitleConfig GetOne()
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

	public partial class TitleConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>图标显示</summary>
		public int Icon { get; set; }
		/// <summary>额外属性</summary>
		public string AddProperty { get; set; }
		/// <summary>序列帧动画</summary>
		public string AnimatorAsset { get; set; }
		/// <summary>序列帧动画数量</summary>
		public int AnimatorNumber { get; set; }
		/// <summary>有效期(秒)</summary>
		public int ValidityTime { get; set; }
		/// <summary>额外属性描述</summary>
		public string Des { get; set; }
		/// <summary>缩放大小</summary>
		public double size { get; set; }
		/// <summary>X偏移</summary>
		public double MoveX { get; set; }
		/// <summary>Y便宜</summary>
		public double MoveY { get; set; }
		/// <summary>额外属性描述</summary>
		public string GetDes { get; set; }

	}
}
