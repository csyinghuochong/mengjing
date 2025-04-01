using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class EnergyComponentS: Entity, IAwake, IDestroy, ITransfer, IUnitCache, IDeserialize
    {
        //可否领取早睡奖励
        public bool EarlySleepReward{ get; set; } = true;

        //领取过奖励的记录
        public List<int> GetRewards { get; set; }= new List<int>() { 0, 0, 0};

        //答题列表
        public List<int> QuestionList { get; set; } = new List<int>();

        public int QuestionIndex { get; set; } = 0;
    }
}
