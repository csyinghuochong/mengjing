using System.Collections.Generic;

namespace ET.Client
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf(typeof (Scene))]
    public class BagComponentClient: Entity, IAwake, IDestroy
    {
        public List<int> QiangHuaLevel = new List<int>();
        
        public List<BagInfo>[] AllItemList;
        
        public bool RealAddItem;
        /// <summary>
        /// ItemLocType.ItemWareHouse1 之后的所有仓库（购买格子数量）
        /// </summary>
        public List<int> WarehouseAddedCell = new List<int>();

        /// <summary>
        /// 附加格子，ItemLocType.ItemBag开始
        /// </summary>
        public List<int> AdditionalCellNum = new List<int>();
    }
}