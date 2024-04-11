using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class LockTargetComponent: Entity, IAwake, IUpdate, IDestroy
    {
        public GameObject LockUnitEffect;
        public MyCamera_1 MyCamera_1;
        public int LastLockIndex = -1;
        public long LastLockId { get; set; } = 0;
        public int AttackTarget;
        public int SkillAttackPlayerFirst;

        public bool IsGuaJi;
    }
}