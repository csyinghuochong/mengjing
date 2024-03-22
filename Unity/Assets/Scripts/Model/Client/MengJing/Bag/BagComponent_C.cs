using System.Collections.Generic;

namespace ET.Client
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf(typeof (Scene))]
    public class BagComponent_C: Entity, IAwake, IDestroy
    {
        public int SeasonJingHePlan { get; set; }
        
        public List<int> QiangHuaLevel = new List<int>();
        
        public List<int> QiangHuaFails = new List<int>();
        
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
        
        
        public List<BagInfo>[] AllItemList;
        
        public bool RealAddItem;
    }
}