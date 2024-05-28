using System.Collections.Generic;

namespace ET.Server
{
    
    /// <summary>
    /// 1进入家园 2收获植物 3收获动物  4清理 
    /// </summary>
    public static class JiaYuanOperateType
    {
        public const int Visit = 1;
        public const int GatherPlant = 2;
        public const int GatherPasture = 3;
        public const int Pick = 4;
    }
    
    [ComponentOf(typeof(Unit))]
    public class JiaYuanComponentS:         Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        public long RefreshMonsterTime_2 { get; set; }= 0;

        public long JiaYuanDaShiTime_1 { get; set; }= 0;

        public long JiaYuanFuJinTime_3 { get; set; }= 0;

        public List<int> PlanOpenList_7 { get; set; }= new List<int>();

        public List<int> LearnMakeIds_7 { get; set; } = new List<int>();

        public List<long> JiaYuanFuJins_3{ get; set; } = new List<long>();

        public List<JiaYuanRecord> JiaYuanRecordList_1 { get; set; }= new List<JiaYuanRecord>();

        /// <summary>
        /// 家园收购列表
        /// </summary>
        public List<JiaYuanPurchaseItem> PurchaseItemList_7{ get; set; } = new List<JiaYuanPurchaseItem>();

        /// <summary>
        /// 家园植物
        /// </summary>
        public List<JiaYuanPlant> JianYuanPlantList_7 { get; set; } = new List<JiaYuanPlant>();

        /// <summary>
        /// 家园动物
        /// </summary>
        public List<JiaYuanPastures> JiaYuanPastureList_7 { get; set; }= new List<JiaYuanPastures>();

        /// <summary>
        /// 家园宠物
        /// </summary>
        public List<JiaYuanPet> JiaYuanPetList_2 { get; set; }= new List<JiaYuanPet>();

        /// <summary>
        /// 家园大师
        /// </summary>
        public List<KeyValuePair> JiaYuanProList_7 { get; set; }= new List<KeyValuePair>();
        /// <summary>
        /// 家园农场商店
        /// </summary>
        public List<MysteryItemInfo> PlantGoods_7 { get; set; }= new List<MysteryItemInfo>();

        /// <summary>
        /// 家园牧场商店
        /// </summary>
        public List<MysteryItemInfo> PastureGoods_7{ get; set; } = new List<MysteryItemInfo>();

        /// <summary>
        /// 家园商店
        /// </summary>
        public List<MysteryItemInfo> JiaYuanStore { get; set; }= new List<MysteryItemInfo>();

        /// <summary>
        /// 家园随机怪
        /// </summary>
        //keyValuePair.KeyId    怪物id
        //keyValuePair.Value    怪物出生时间戳
        //keyValuePair.Value2   怪物坐标
        public List<JiaYuanMonster> JiaYuanMonster_2{ get; set; } = new List<JiaYuanMonster>();

        public int NowOpenNpcId{ get; set; }

    }
}
