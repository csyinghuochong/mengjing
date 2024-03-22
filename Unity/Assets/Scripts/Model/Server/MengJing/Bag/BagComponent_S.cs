using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class BagComponent_S : Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        
        /// <summary>
        /// 赛季晶核方案
        /// </summary>
        public int SeasonJingHePlan { get; set; }

        public List<int> QiangHuaLevel { get; set; } = new();

        public List<int> QiangHuaFails { get; set; } = new();
        
        /// <summary>
        /// ItemLocType.ItemWareHouse1 之后的所有仓库（购买格子数量）
        /// </summary>
        public List<int> WarehouseAddedCell { get; set; } = new();

        /// <summary>
        /// 附加格子，ItemLocType.ItemBag开始
        /// </summary>
        public List<int> AdditionalCellNum { get; set; } = new();

        /// <summary>
        /// 激活的时装
        /// </summary>
        public List<int> FashionActiveIds { get; set; } = new();

        /// <summary>
        /// 穿戴的时装
        /// </summary>
        public List<int> FashionEquipList { get; set; } = new();
        
        public List<BagInfo> BagItemList { get; set; } = new();
        public List<BagInfo> BagItemPetHeXin { get; set; } = new();
        public List<BagInfo> EquipList { get; set; } = new();
        public List<BagInfo> GemList { get; set; } = new();
        public List<BagInfo> PetHeXinList { get; set; } = new();
        public List<BagInfo> Warehouse1 { get; set; } = new();
        public List<BagInfo> Warehouse2 { get; set; } = new();
        public List<BagInfo> Warehouse3 { get; set; } = new();
        public List<BagInfo> Warehouse4 { get; set; } = new();
        public List<BagInfo> JianYuanWareHouse1 { get; set; } = new();
        public List<BagInfo> JianYuanWareHouse2 { get; set; } = new();
        public List<BagInfo> JianYuanWareHouse3 { get; set; } = new();
        public List<BagInfo> JianYuanWareHouse4 { get; set; } = new();
        public List<BagInfo> JianYuanTreasureMapStorage1 { get; set; } = new();
        public List<BagInfo> JianYuanTreasureMapStorage2 { get; set; } = new();
        public List<BagInfo> ChouKaWarehouse { get; set; } = new();
        public List<BagInfo> EquipList_2 { get; set; } = new();
        public List<BagInfo> SeasonJingHe { get; set; } = new();
        public List<BagInfo> PetEquipList { get; set; } = new();
        public List<BagInfo> GemWareHouse1 { get; set; } = new();
        
        /// <summary>
        /// 可以放在unitinfocomponent
        /// </summary>
        public int FuMoItemId { get; set; }   

        [BsonIgnore]
        public M2C_RoleBagUpdate message = new M2C_RoleBagUpdate() { };

        [BsonIgnore]
        public List<HideProList> FuMoProList { get; set; } = new();
        
        [BsonIgnore]
        public List<int> InheritSkills { get; set; } = new();
    }
}