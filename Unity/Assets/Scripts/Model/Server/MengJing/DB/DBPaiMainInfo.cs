using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    
    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBPaiMainInfo : Entity, IAwake
    {
        public List<PaiMaiItemInfo> PaiMaiItemInfos { get; set; } = new List<PaiMaiItemInfo>();
        public List<PaiMaiShopItemInfo> PaiMaiShopItemInfos  { get; set; }= new List<PaiMaiShopItemInfo>();         //商店，
        
        public List<PaiMaiItemInfo> StallItemInfos { get; set; } = new List<PaiMaiItemInfo>();                       //摆摊，废弃掉，PaiMaiItemInfos
    }
}
