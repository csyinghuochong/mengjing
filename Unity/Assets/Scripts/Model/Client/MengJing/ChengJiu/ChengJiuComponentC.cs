using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class ChengJiuComponentC: Entity, IAwake, IDestroy
    {
        public int TotalChengJiuPoint { get; set; } = 0;
        public List<int> AlreadReceivedId { get; set; } = new List<int>();
        public List<int> ChengJiuCompleteList { get; set; } = new List<int>();
        public List<int> JingLingList { get; set; } = new List<int>();
        public int JingLingId { get; set; } = 0;
        public int RandomDrop { get; set; } = 0;
        public Dictionary<int, ChengJiuInfo> ChengJiuProgessList { get; set; } = new Dictionary<int, ChengJiuInfo>();
    }
}