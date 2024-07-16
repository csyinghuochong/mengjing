using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ChapterSonConfigCategory : Singleton<ChapterSonConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ChapterSonConfig> dict = new();
		
        public void Merge(object o)
        {
            ChapterSonConfigCategory s = o as ChapterSonConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ChapterSonConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ChapterSonConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ChapterSonConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ChapterSonConfig> GetAll()
        {
            return this.dict;
        }

        public ChapterSonConfig GetOne()
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

	public partial class ChapterSonConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>关卡名称</summary>
		public string Name { get; set; }
		/// <summary>地块类型</summary>
		public int Type { get; set; }
		/// <summary>地图ID</summary>
		public int MapID { get; set; }
		/// <summary>NPC</summary>
		public int[] NpcList { get; set; }
		/// <summary>出生点</summary>
		public int[] BornPosLeft { get; set; }
		/// <summary>出生点</summary>
		public int[] BornPosUp { get; set; }
		/// <summary>出生点</summary>
		public int[] BornPosDwon { get; set; }
		/// <summary>出生点</summary>
		public int[] BornPosRight { get; set; }
		/// <summary>传送门坐标</summary>
		public string TransmitPosi { get; set; }
		/// <summary>特殊场景怪物生成坐标点</summary>
		public string CreateScenceMonsterPro { get; set; }
		/// <summary>特殊场景怪物生成坐标点</summary>
		public string CreateScenceMonster { get; set; }
		/// <summary>怪物生成坐标点</summary>
		public string CreateMonster { get; set; }

	}
}
