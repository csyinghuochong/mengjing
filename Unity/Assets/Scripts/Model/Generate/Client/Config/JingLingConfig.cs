using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class JingLingConfigCategory : Singleton<JingLingConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, JingLingConfig> dict = new();
		
        public void Merge(object o)
        {
            JingLingConfigCategory s = o as JingLingConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public JingLingConfig Get(int id)
        {
            this.dict.TryGetValue(id, out JingLingConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (JingLingConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, JingLingConfig> GetAll()
        {
            return this.dict;
        }

        public JingLingConfig GetOne()
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

	public partial class JingLingConfig: ProtoObject, IConfig
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
		/// <summary>图标显示</summary>
		public int Icon { get; set; }
		/// <summary>模型</summary>
		public string Assets { get; set; }
		/// <summary>额外属性</summary>
		public string AddProperty { get; set; }
		/// <summary>序列帧动画</summary>
		public string AnimatorAsset { get; set; }
		/// <summary>序列帧动画数量</summary>
		public int AnimatorNumber { get; set; }
		/// <summary>有效期(秒)</summary>
		public int ValidityTime { get; set; }
		/// <summary>境界</summary>
		public string Lv { get; set; }
		/// <summary>属性描述</summary>
		public string ProDes { get; set; }
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
		/// <summary>功能类型</summary>
		public int FunctionType { get; set; }
		/// <summary>功能参数</summary>
		public string FunctionValue { get; set; }
		/// <summary>自动拾取</summary>
		public int AutoPick { get; set; }
		/// <summary>怪物显示的位置</summary>
		public string ModelShowPosi { get; set; }

	}
}
