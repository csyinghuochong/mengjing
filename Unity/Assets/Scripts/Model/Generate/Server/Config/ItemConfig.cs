using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ItemConfigCategory : Singleton<ItemConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ItemConfig> dict = new();
		
        public void Merge(object o)
        {
            ItemConfigCategory s = o as ItemConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ItemConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ItemConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ItemConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ItemConfig> GetAll()
        {
            return this.dict;
        }

        public ItemConfig GetOne()
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

	public partial class ItemConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>道具名称</summary>
		public string ItemName { get; set; }
		/// <summary>道具Icon</summary>
		public string Icon { get; set; }
		/// <summary>道具模型ID</summary>
		public string ItemModelID { get; set; }
		/// <summary>道具品质</summary>
		public int ItemQuality { get; set; }
		/// <summary>使用等级</summary>
		public int UseLv { get; set; }
		/// <summary>使用职业</summary>
		public int UseOcc { get; set; }
		/// <summary>道具类型</summary>
		public int ItemType { get; set; }
		/// <summary>道具子类</summary>
		public int ItemSubType { get; set; }
		/// <summary>装备类型</summary>
		public int EquipType { get; set; }
		/// <summary>道具堆叠最大数量</summary>
		public int ItemPileSum { get; set; }
		/// <summary>出售货币类型</summary>
		public int SellMoneyType { get; set; }
		/// <summary>出售货币值</summary>
		public int SellMoneyValue { get; set; }
		/// <summary>装备ID</summary>
		public int ItemEquipID { get; set; }
		/// <summary>宠物之核合成新道具</summary>
		public int PetHeXinHeChengID { get; set; }
		/// <summary>道具使用参数</summary>
		public string ItemUsePar { get; set; }
		/// <summary>道具技能</summary>
		public string SkillID { get; set; }
		/// <summary>道具Tips显示技能</summary>
		public int SkillIDIfShow { get; set; }
		/// <summary>洗练石数量</summary>
		public int[] XiLianStone { get; set; }
		/// <summary>回收获取物品</summary>
		public string HuiShouGetItem { get; set; }
		/// <summary>道具描述</summary>
		public string ItemDes { get; set; }
		/// <summary>道具背景描述</summary>
		public string ItemBlackDes { get; set; }
		/// <summary>是否自动使用</summary>
		public int IfAutoUse { get; set; }
		/// <summary>是否禁止拍卖行上架</summary>
		public int IfStopPaiMai { get; set; }
		/// <summary>获取是否绑定</summary>
		public int IfLock { get; set; }
		/// <summary>每天使用次数</summary>
		public int DayUseNum { get; set; }

	}
}
