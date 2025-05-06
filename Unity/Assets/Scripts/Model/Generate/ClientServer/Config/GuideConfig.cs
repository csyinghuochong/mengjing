using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class GuideConfigCategory : Singleton<GuideConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, GuideConfig> dict = new();
		
        public void Merge(object o)
        {
            GuideConfigCategory s = o as GuideConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public GuideConfig Get(int id)
        {
            this.dict.TryGetValue(id, out GuideConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (GuideConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, GuideConfig> GetAll()
        {
            return this.dict;
        }

        public GuideConfig GetOne()
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

	public partial class GuideConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>组</summary>
		public int GroupId { get; set; }
		/// <summary>下一步</summary>
		public int NextID { get; set; }
		/// <summary>是否保存</summary>
		public int Save { get; set; }
		/// <summary>触发条件</summary>
		public int TrigerType { get; set; }
		/// <summary>触发目标</summary>
		public string TrigerParams { get; set; }
		/// <summary>行为类型</summary>
		public int ActionType { get; set; }
		/// <summary>行为对象</summary>
		public string ActionTarget { get; set; }
		/// <summary>行为参数</summary>
		public string ActionParams { get; set; }
		/// <summary>是否强引导</summary>
		public int Force { get; set; }
		/// <summary>引导文本</summary>
		public string Text { get; set; }
		/// <summary>文本位置[相对于按钮]</summary>
		public int TextPosition { get; set; }
		/// <summary>偏移</summary>
		public int[] Offset { get; set; }

	}
}
