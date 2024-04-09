using System.Collections.Generic;

namespace ET.Client
{
    
    [ComponentOf(typeof(Unit))]
    public class AttackComponent: Entity, IAwake, IDestroy
    {
        public int SkillId;
        public int ComboSkillId;
        public long LastSkillTime;
        public long ComboStartTime;
        public long CombatEndTime;

        public bool AutoAttack  = true;
        public float AttackDistance;
        public List<int> Weights = new List<int>();
        public List<int> SkillList = new List<int> { };
        public List<int> SkillCDs = new List<int>();
        public readonly C2M_SkillCmd c2mSkillCmd = new C2M_SkillCmd();
        public long CDTime = 800;
        public long CDEndTime;

        public long MoveAttackTime = 0;
        public long MoveAttackId = 0;
        public long Timer;

        public BagComponentC BagComponent { get; set; }
    }
}