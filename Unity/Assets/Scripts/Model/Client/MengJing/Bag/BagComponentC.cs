using System.Collections.Generic;

namespace ET.Client
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf(typeof(Scene))]
    public class BagComponentC : Entity, IAwake, IDestroy
    {
        public int SeasonJingHePlan { get; set; }

        public List<int> QiangHuaLevel { get; set; } = new();

        public List<int> QiangHuaFails { get; set; } = new();

        /// <summary>
        /// ItemLocType.ItemLocBag 
        /// </summary>
        public List<int> BagBuyCellNumber { get; set; } = new();

        /// <summary>
        /// 附加格子，ItemLocType.ItemLocBag
        /// </summary>
        public List<int> BagAddCellNumber { get; set; } = new();

        /// <summary>
        /// 激活的时装
        /// </summary>
        public List<int> FashionActiveIds { get; set; } = new();

        /// <summary>
        /// 穿戴的时装
        /// </summary>
        public List<int> FashionEquipList { get; set; } = new();

        //public List<BagInfo>[] AllItemList { get; set; }
        
        public Dictionary<int, List<ItemInfo>> AllItemList { get; set; } = new();

        /// <summary>
        /// 小于0，不用弹出tip
        /// </summary>
        public int RealAddItem { get; set; } 
    }
}