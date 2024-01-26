using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class BagComponent : Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        public List<int> QiangHuaLevel = new List<int>();

        public List<int> QiangHuaFails = new List<int>();
        
        /// <summary>
        /// ItemLocType.ItemWareHouse1 之后的所有仓库（购买格子数量）
        /// </summary>
        public List<int> WarehouseAddedCell = new List<int>();

        /// <summary>
        /// 附加格子，ItemLocType.ItemBag开始
        /// </summary>
        public List<int> AdditionalCellNum = new List<int>();

        /// <summary>
        /// 激活的时装
        /// </summary>
        public List<int> FashionActiveIds = new List<int>();

        /// <summary>
        /// 穿戴的时装
        /// </summary>
        public List<int> FashionEquipList = new List<int>();

        /// <summary>
        /// 赛季晶核方案
        /// </summary>
        public int SeasonJingHePlan = 0;

        public List<BagInfo> BagItemList = new List<BagInfo>();
        public List<BagInfo> BagItemPetHeXin = new List<BagInfo>();
        public List<BagInfo> EquipList = new List<BagInfo>();
        public List<BagInfo> GemList = new List<BagInfo>();
        public List<BagInfo> PetHeXinList = new List<BagInfo>();
        public List<BagInfo> Warehouse1 = new List<BagInfo>();
        public List<BagInfo> Warehouse2 = new List<BagInfo>();
        public List<BagInfo> Warehouse3 = new List<BagInfo>();
        public List<BagInfo> Warehouse4 = new List<BagInfo>();
        public List<BagInfo> JianYuanWareHouse1 = new List<BagInfo>();
        public List<BagInfo> JianYuanWareHouse2 = new List<BagInfo>();
        public List<BagInfo> JianYuanWareHouse3 = new List<BagInfo>();
        public List<BagInfo> JianYuanWareHouse4 = new List<BagInfo>();
        public List<BagInfo> JianYuanTreasureMapStorage1 = new List<BagInfo>();
        public List<BagInfo> JianYuanTreasureMapStorage2 = new List<BagInfo>();
        public List<BagInfo> ChouKaWarehouse = new List<BagInfo>();
        public List<BagInfo> EquipList_2 = new List<BagInfo>();
        public List<BagInfo> SeasonJingHe = new List<BagInfo>();
        public List<BagInfo> PetEquipList = new List<BagInfo>();
        public List<BagInfo> GemWareHouse1 = new List<BagInfo>();

        [BsonIgnore]
        public int FuMoItemId = 0;

        [BsonIgnore]
        public List<HideProList> FuMoProList = new List<HideProList>();

        //[BsonIgnore]
        //public M2C_RoleBagUpdate message = new M2C_RoleBagUpdate() { };

        [BsonIgnore]
        public List<int> InheritSkills = new List<int>() { };
    }
}