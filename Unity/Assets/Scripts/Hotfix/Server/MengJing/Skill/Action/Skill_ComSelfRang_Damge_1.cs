using System;

namespace ET.Server
{

    /// <summary>
    /// 持续性伤害
    /// </summary>
    public class Skill_ComSelfRang_Damge_1 : SkillHandlerS
    {
     
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            if (string.IsNullOrEmpty(skillS.SkillConf.GameObjectParameter))
            {
                skillS.SkillTriggerInvelTime = 1000;
            }
            else
            {
                try
                {
                    skillS.SkillTriggerInvelTime = (long)(float.Parse(skillS.SkillConf.GameObjectParameter) * 1000);
                }
                catch (Exception ex)
                {
                    Log.Debug(ex.ToString());
                }
            }
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            skillS.IsExcuteHurt = false;
            if (skillS.SkillConf.SkillTargetType == SkillTargetType.SelfFollow)
            {
                skillS.UpdateCheckPoint(skillS.TheUnitFrom.Position);
            }

            long curTime = TimeHelper.ServerNow();
            for (int i = skillS.HurtIds.Count - 1; i >= 0; i--)
            {
                long unitId = skillS.HurtIds[i];
                Unit unit = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(unitId);
                if (unit == null || unit.IsDisposed)
                {
                    skillS.HurtIds.RemoveAt(i);
                    RemoveHurtTime(skillS,unitId);
                    continue;
                }

                if (!skillS.CheckShape(unit.Position))
                {
                    skillS.HurtIds.RemoveAt(i);
                    RemoveHurtTime(skillS, unitId);
                    continue;
                }
                if (!skillS.LastHurtTimes.ContainsKey(unitId))
                {
                    continue;
                }
           
                if (curTime - skillS.LastHurtTimes[unitId] >= skillS.SkillTriggerInvelTime)
                {
                    skillS.HurtIds.RemoveAt(i);
                    RemoveHurtTime(skillS, unitId);
                }
            }

            skillS.BaseOnUpdate();
            skillS.CheckChiXuHurt();

            for (int i = skillS.HurtIds.Count - 1; i >= 0; i--)
            {
                long unitId = skillS.HurtIds[i];
                if (!skillS.LastHurtTimes.ContainsKey(unitId))
                {
                    skillS.LastHurtTimes.Add(unitId, TimeHelper.ServerNow());
                }
            }
        }

        private void RemoveHurtTime(SkillS skillS, long unitId)
        {
            if (!skillS.LastHurtTimes.ContainsKey(unitId))
                return;
            skillS.LastHurtTimes.Remove(unitId);
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
