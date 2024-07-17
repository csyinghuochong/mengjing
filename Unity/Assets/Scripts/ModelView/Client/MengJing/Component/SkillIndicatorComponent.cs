using UnityEngine;

namespace ET.Client
{
    
    [ComponentOf(typeof(Scene))]
    public class SkillIndicatorComponent: Entity , IAwake, IDestroy
    {
        public long Timer;
        public float SkillRangeSize;
        public Camera MainCamera;
        public SkillConfig mSkillConfig;
        public SkillIndicatorItem SkillIndicator;
        public Vector2 StartIndicator;
    }
}