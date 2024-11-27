using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class ChengJiuComponentS : Entity, IAwake, ITransfer, IUnitCache
    {

        public long JingLingUnitId  { set; get; }= 0;
        
        public int TotalChengJiuPoint = 0;
        public List<ChengJiuInfo> ChengJiuProgessList = new List<ChengJiuInfo>();
        public List<JingLingInfo> JingLingList = new List<JingLingInfo>();
       
        public List<int> AlreadReceivedId = new List<int>();
        public List<int> ChengJiuCompleteList = new List<int>();

        public List<int> PetTuJianActives = new List<int>();
        
        public int RandomDrop { get; set; }
    }

}