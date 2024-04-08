using System;
using System.Collections.Generic;

namespace ET.Server
{

    //持续性伤害
    public class Skill_ComSelfRang_Damge_1 : SkillHandlerS
    {
     
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);

            if (string.IsNullOrEmpty(SkillConf.GameObjectParameter))
            {
                this.SkillTriggerInvelTime = 1000;
                Log.Warning($"SkillConf.GameObjectParameter:  {SkillConf.Id}  {SkillConf.GameObjectParameter}");
            }
            else
            {
                try
                {
                    this.SkillTriggerInvelTime = (long)(float.Parse(SkillConf.GameObjectParameter) * 1000);
                }
                catch (Exception ex)
                {
                    Log.Debug(ex.ToString());
                    Log.Warning($"SkillConf.GameObjectParameter:  {SkillConf.Id}  {SkillConf.GameObjectParameter}");
                }

            }
        }

        public override void OnExecute(SkillS skillS)
        {
            this.InitSelfBuff();
            this.OnUpdate();
        }

        public override void OnUpdate(SkillS skillS)
        {
            this.IsExcuteHurt = false;
            if (this.SkillConf.SkillTargetType == SkillTargetType.SelfFollow)
            {
                this.UpdateCheckPoint(this.TheUnitFrom.Position);
            }

            long curTime = TimeHelper.ServerNow();
            for (int i = HurtIds.Count - 1; i >= 0; i--)
            {
                long unitId = this.HurtIds[i];
                Unit unit = this.TheUnitFrom.Domain.GetComponent<UnitComponent>().Get(unitId);
                if (unit == null || unit.IsDisposed)
                {
                    this.HurtIds.RemoveAt(i);
                    RemoveHurtTime(unitId);
                    continue;
                }

                if (!this.CheckShape(unit.Position))
                {
                    this.HurtIds.RemoveAt(i);
                    RemoveHurtTime(unitId);
                    continue;
                }
                if (!this.LastHurtTimes.ContainsKey(unitId))
                {
                    continue;
                }
           
                if (curTime - this.LastHurtTimes[unitId] >= this.SkillTriggerInvelTime)
                {
                    this.HurtIds.RemoveAt(i);
                    RemoveHurtTime(unitId);
                }
            }

            this.BaseOnUpdate();
            this.CheckChiXuHurt();

            for (int i = HurtIds.Count - 1; i >= 0; i--)
            {
                long unitId = this.HurtIds[i];
                if (!this.LastHurtTimes.ContainsKey(unitId))
                {
                    this.LastHurtTimes.Add(unitId, TimeHelper.ServerNow());
                }
            }
        }

        private void RemoveHurtTime(long unitId)
        {
            if (!this.LastHurtTimes.ContainsKey(unitId))
                return;
            this.LastHurtTimes.Remove(unitId);
        }

        public override void OnFinished(SkillS skillS)
        {
            this.Clear();
        }
    }
}
