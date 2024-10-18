using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class AttackComponent : Entity, IAwake, IDestroy
    {
        private EntityRef<Unit> unit;
        public Unit MainUnit { get => this.unit; set => this.unit = value; }
        public int SkillId { get; set; }
        public int ComboSkillId;
        public long LastSkillTime;
        public long ComboStartTime;
        public long CombatEndTime;

        public bool AutoAttack { get; set; } = true;
        public float AttackDistance { get; set; }
        public List<int> Weights = new();
        public List<int> SkillList = new();
        public List<int> SkillCDs = new();
        public readonly C2M_SkillCmd c2mSkillCmd = new();
        public long CDTime { get; set; } = 800;
        public long CDEndTime;

        public long MoveAttackTime { get; set; } = 0;
        public long MoveAttackId { get; set; } = 0;
        public long Timer;
    }
}