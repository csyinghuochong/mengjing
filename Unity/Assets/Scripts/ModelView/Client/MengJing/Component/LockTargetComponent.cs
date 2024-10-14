using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class LockTargetComponent : Entity, IAwake, IUpdate, IDestroy
    {
        public EntityRef<Unit> MainUnit { get; set; }
        public GameObject LockUnitEffect { get; set; }
        public int Type { get; set; }
        public Dictionary<int, GameObject> EffectMap { get; set; } = new();
        public MyCamera_1 MyCamera_1 { get; set; }
        public int LastLockIndex { get; set; } = -1;
        public long LastLockId { get; set; } = 0;
        public int AttackTarget { get; set; }
        public int SkillAttackPlayerFirst { get; set; }

        public bool IsGuaJi { get; set; }
    }
}