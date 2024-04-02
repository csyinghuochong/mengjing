using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public class UnitLockRange
    {
        public long Id;
        public int Range;
        public int Type;
    }

    public class SkillIndicatorItem
    {
        public int SkillZhishiType;
        public string EffectPath;
        public int TargetAngle;
        public float AttackDistance;
        public float LiveTime = -1;
        public float PassTime;
        public long InstanceId;
        public bool Enemy;
        public SkillInfo SkillInfo;
        public GameObject GameObject;
    }
    
    [ComponentOf(typeof(Unit))]
    public class SkillYujingComponent: Entity, IAwake, IDestroy
    {
        public SkillConfig mSkillConfig;
        public float SkillRangeSize;
        public List<SkillIndicatorItem> SkillIndicatorList = null;
        public long Timer;
    }
    
}