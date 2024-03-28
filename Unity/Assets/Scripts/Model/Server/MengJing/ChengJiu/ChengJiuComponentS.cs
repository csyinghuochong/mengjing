using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class ChengJiuComponentS : Entity, IAwake, ITransfer, IUnitCache
    {

        public long JingLingUnitId  { set; get; }= 0;
        public List<ChengJiuInfo> ChengJiuProgessList = new List<ChengJiuInfo>();
        public int TotalChengJiuPoint = 0;
        public List<int> AlreadReceivedId = new List<int>();
        public List<int> ChengJiuCompleteList = new List<int>();
        public List<int> JingLingList = new List<int>();
        public int JingLingId { set; get; } = 0;
        public int RandomDrop { get; set; }
    }

}