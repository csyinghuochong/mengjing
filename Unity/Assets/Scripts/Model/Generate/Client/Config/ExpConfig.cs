using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ExpConfigCategory : Singleton<ExpConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ExpConfig> dict = new();
		
        public void Merge(object o)
        {
            ExpConfigCategory s = o as ExpConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ExpConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ExpConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ExpConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ExpConfig> GetAll()
        {
            return this.dict;
        }

        public ExpConfig GetOne()
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

	public partial class ExpConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>角色升级经验</summary>
		public int UpExp { get; set; }
		/// <summary>宠物升级经验</summary>
		public int PetUpExp { get; set; }
		/// <summary>宠物经验道具</summary>
		public int PetItemUpExp { get; set; }
		/// <summary>每级对应经验产出</summary>
		public int RoseExpPro { get; set; }
		/// <summary>每级对应金币产出</summary>
		public int RoseGoldPro { get; set; }
		/// <summary>基础怪物血量</summary>
		public int BaseHp { get; set; }
		/// <summary>攻击</summary>
		public int BaseAct { get; set; }
		/// <summary>物防</summary>
		public int BaseDef { get; set; }
		/// <summary>魔防</summary>
		public int BaseAdf { get; set; }

	}
}
