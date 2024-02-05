using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ET.Server
{

    [BsonIgnoreExtraElements]
    public class DBPaiMainInfo : Entity
    {
        public List<PaiMaiItemInfo> PaiMaiItemInfos = new List<PaiMaiItemInfo>();                       
        public List<PaiMaiShopItemInfo> PaiMaiShopItemInfos = new List<PaiMaiShopItemInfo>();         //商店，
    }
}
