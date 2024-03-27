using System.Collections.Generic;

namespace ET.Client
{
    
    [ComponentOf(typeof(Scene))]
    public class ChengJiuComponentC: Entity, IAwake, IDestroy
    {
        public int TotalChengJiuPoint = 0;
        public List<int> AlreadReceivedId = new List<int>();
        public List<int> ChengJiuCompleteList = new List<int>();
        public List<int> JingLingList = new List<int>();
        public int JingLingId = 0;
        public int RandomDrop = 0;
        public Dictionary<int, ChengJiuInfo> ChengJiuProgessList = new Dictionary<int, ChengJiuInfo>();
    }
}