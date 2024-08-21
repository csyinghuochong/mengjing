using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class BagComponentS : Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        
        /// <summary>
        /// 赛季晶核方案
        /// </summary>
        public int SeasonJingHePlan { get; set; }

        
        public List<int> QiangHuaLevel { get; set; }= new List<int>();

        public List<int> QiangHuaFails { get; set; } = new List<int>();
        
        /// <summary>
        /// ItemLocType.ItemLocBag 之后的所有仓库（购买格子数量）
        /// </summary>
        public List<int> WarehouseAddedCell { get; set; } = new();

        /// <summary>
        /// 附加格子，ItemLocType.ItemLocBag
        /// </summary>
        public List<int> AdditionalCellNum { get; set; } = new();

        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, List<BagInfo>> AllItemList { get; set; } = new();
       
        /// <summary>
        /// 可以放在unitinfocomponent
        /// </summary>
        public int FuMoItemId { get; set; }
        
        /// <summary>
        /// 激活的时装
        /// </summary>
        public List<int> FashionActiveIds { get; set; } = new();


        /// <summary>
        /// 穿戴的时装
        /// </summary>
        public List<int> FashionEquipList { get; set; } = new();
        
        
        [BsonIgnore]
        public M2C_RoleBagUpdate message = M2C_RoleBagUpdate.Create();

        [BsonIgnore]
        public List<HideProList> FuMoProList { get; set; } = new();
        
        [BsonIgnore]
        public List<int> InheritSkills { get; set; } = new();
    }
}