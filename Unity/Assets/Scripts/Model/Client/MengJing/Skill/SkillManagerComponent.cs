﻿using System.Collections.Generic;

namespace ET.Client
{

    [ComponentOf(typeof(Unit))]
    public class SkillManagerComponent : Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 二段技能 原技能
        /// </summary>
        public Dictionary<int, int> SkillSecond = new Dictionary<int, int>();
        public List<SkillInfo> t_Skills = new List<SkillInfo>();
        public List<ASkillHandler> Skills = new List<ASkillHandler>();
        public List<SkillCDItem> SkillCDs = new List<SkillCDItem>();       //冷却时间列表
        public C2M_SkillCmd SkillCmd = null;
        public long SkillPublicCDTime;                                                              //技能公共CD
        public int FangunSkillId;
        public long FangunLastTime;

        public long SkillMoveTime;  //1旋风斩之类的技能. 可以移动但是需要保持技能动作
        public long SkillSingTime;  //吟唱， 移动会打断施法动作

        public bool MainHero;

        public long Timer;
    }

}
