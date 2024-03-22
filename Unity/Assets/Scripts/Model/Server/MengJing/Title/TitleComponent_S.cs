using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class TitleComponent_S:         Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        //称号
        public List<KeyValuePairInt> TitleList = new List<KeyValuePairInt>();

        //public M2C_TitleUpdateResult TitleUpdateResult = new M2C_TitleUpdateResult();
    }
}
