using System.Collections.Generic;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class AttackRecordComponent : Entity, IAwake, IDestroy
    {
        public long AttackingId{ get; set; }

        public long BeAttackId{ get; set; }

        public long PetLockId { get; set; }

        public long LastBelongTime;

        /// <summary>
        /// 抢夺BOSS显示当前怪物掉落归属 怪物表 DropType 字段为1 的显示 [掉落归属是统计玩家伤害最高的,
        /// 如果脱离战斗或者死亡清空伤害数据]
        /// </summary>
        public int DropType = 0;
        /// <summary>
        /// 玩家ID
        /// </summary>
        public Dictionary<long, long> BeAttackPlayerList{ get; set; } = new Dictionary<long, long>();

        /// <summary>
        /// 战场召唤记录
        /// </summary>
        public List<BattleSummonInfo> BattleSummonList { get; set; } = new List<BattleSummonInfo>();
        
        /// <summary>
        /// 伤害列表   被击败的 为列表最后一个 
        /// </summary>
        /// <returns></returns>
        public List<DamageValueInfo> DamageValueList  { get; set; } = new List<DamageValueInfo>(); 
    }
}