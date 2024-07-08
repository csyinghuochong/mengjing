using System.Collections.Generic;

namespace ET.Client
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
    
    [ComponentOf(typeof (Scene))]
    public class JiaYuanComponentC: Entity, IAwake
    {
        public long RefreshMonsterTime_2 { get; set; } = 0;

        public long JiaYuanDaShiTime_1 { get; set; } = 0;

        public long JiaYuanFuJinTime_3 { get; set; } = 0;

        public List<int> PlanOpenList_7 { get; set; } = new();

        public List<int> LearnMakeIds_7 { get; set; } = new();

        public List<long> JiaYuanFuJins_3 { get; set; } = new();

        public List<JiaYuanRecord> JiaYuanRecordList_1 { get; set; } = new();

        /// <summary>
        /// 家园收购列表
        /// </summary>
        public List<JiaYuanPurchaseItem> PurchaseItemList_7 { get; set; } = new();

        /// <summary>
        /// 家园植物
        /// </summary>
        public List<JiaYuanPlant> JianYuanPlantList_7 { get; set; } = new();

        /// <summary>
        /// 家园动物
        /// </summary>
        public List<JiaYuanPastures> JiaYuanPastureList_7 { get; set; } = new();

        /// <summary>
        /// 家园宠物
        /// </summary>
        public List<JiaYuanPet> JiaYuanPetList_2 { get; set; } = new();

        /// <summary>
        /// 家园大师
        /// </summary>
        public List<KeyValuePair> JiaYuanProList_7 { get; set; } = new();

        public long MasterId { get; set; } = 0;
    }
}