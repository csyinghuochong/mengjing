using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class LockTargetComponent : Entity, IAwake, IUpdate, IDestroy
    {
        private EntityRef<Unit> unit;
        public Unit MainUnit { get => this.unit; set => this.unit = value; }
        public GameObject LockUnitEffect { get; set; }
        public int Type { get; set; }
        public Dictionary<int, GameObject> EffectMap { get; set; } = new();
        public MyCamera_1 MyCamera_1 { get; set; }
        public int LastLockIndex { get; set; } = -1;
        public long LastLockId { get; set; } = 0;
        public GameObject LastHighlightGameObject{ get; set; }
        public int AttackTarget { get; set; }
        public int SkillAttackPlayerFirst { get; set; }

        public bool IsGuaJi { get; set; }
    }
}