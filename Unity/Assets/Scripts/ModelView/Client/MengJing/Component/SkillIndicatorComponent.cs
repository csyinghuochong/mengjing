using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class SkillIndicatorComponent : Entity, IAwake, IDestroy
    {
        private EntityRef<Unit> unit;
        public Unit MainUnit { get => this.unit; set => this.unit = value; }
        public long Timer;
        public float SkillRangeSize;
        public Camera MainCamera;
        public SkillConfig mSkillConfig;
        public SkillIndicatorItem SkillIndicator;
        public Vector2 StartIndicator;
    }
}