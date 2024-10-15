using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 闪电链3,传递电下去，每次只电一下(当前目标死了也能传递下去，能否传递只跟两者间的距离、技能存在时间有关)
    /// https://www.bilibili.com/video/BV13F411d7XL/?spm_id_from=333.337.search-card.all.click&amp;vd_source=df9f0a2e3f52f77e8636fbb4dc7e8532
    /// </summary>
    public class Skill_ChainLightning_3: SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
            
            float3 nowposition = new float3(
                        theUnitFrom.Position.x,
                        theUnitFrom.Position.y + SkillHelp.GetCenterHigh(theUnitFrom.Type, theUnitFrom.ConfigId),
                        theUnitFrom.Position.z
                        );
            skillS.NowPosition = nowposition;
            skillS.SkillTriggerInvelTime = 500; // 传递时间
            skillS.SkillTriggerLastTime = TimeHelper.ServerNow();
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            OnUpdate(skillS, 0);
        }

        public void BroadcastSkill(SkillS skillS, long unitid, long targetId, float x, float y, float z)
        {
            M2C_ChainLightning M2C_ChainLightning = M2C_ChainLightning.Create();
            M2C_ChainLightning.UnitId = unitid;
            M2C_ChainLightning.TargetID = targetId;
            M2C_ChainLightning.SkillID = skillS.SkillInfo.WeaponSkillID;
            M2C_ChainLightning.PosX = x;
            M2C_ChainLightning.PosY = y;
            M2C_ChainLightning.PosZ = z;
            M2C_ChainLightning.Type = 3;
            M2C_ChainLightning.InstanceId = skillS.InstanceId;
            MapMessageHelper.Broadcast(skillS.TheUnitFrom,M2C_ChainLightning);
        }

        public override void OnUpdate(SkillS skillS,int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();
            if (serverNow > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
            }

            if (skillS.HurtIds.Count == 0)
            {
                skillS.TheUnitTarget = GetTargetHelpS.GetNearestEnemy(skillS.TheUnitFrom, (float)skillS.SkillConf.DamgeRange[0], true);
                if (skillS.TheUnitTarget == null || skillS.TheUnitTarget.IsDisposed)
                {
                    skillS.SetSkillState(SkillState.Finished);
                    return;
                }

                skillS.OnAddHurtIds(skillS.TheUnitTarget.Id);
                BroadcastSkill(skillS, skillS.TheUnitFrom.Id, skillS.TheUnitTarget.Id, 0f, 0f, 0f);
                float3 targetPosition = new float3(
                            skillS.TheUnitTarget.Position.x,
                            skillS.TheUnitTarget.Position.y + SkillHelp.GetCenterHigh(skillS.TheUnitTarget.Type, skillS.TheUnitTarget.ConfigId), 
                            skillS.TheUnitTarget.Position.z
                    );
                skillS.TargetPosition = targetPosition;
            }

            if (skillS.TheUnitTarget == null || skillS.TheUnitTarget.IsDisposed)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }
            
            if (serverNow - skillS.SkillTriggerLastTime < skillS.SkillTriggerInvelTime)
            {
                return;
            }
            skillS.SkillTriggerLastTime = serverNow;

            Unit lastTarget = null;
            lastTarget = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(skillS.HurtIds[^1]);
            // this.OnCollisionUnit(lastTarget);

            skillS.TheUnitTarget = GetTargetHelpS.GetNearestUnit(skillS.TheUnitFrom, lastTarget.Position, (float)skillS.SkillConf.DamgeRange[0], skillS.HurtIds);
            if (skillS.TheUnitTarget == null)
            {
                BroadcastSkill(skillS, lastTarget.Id, lastTarget.Id, 0f, 0f, 0f);
                skillS.OnCollisionUnit(lastTarget);
                skillS.SetSkillState(SkillState.Finished);
                return;
            }

            float3 TargetPosition = new float3(skillS.TheUnitTarget.Position.x,
                skillS.TheUnitTarget.Position.y + SkillHelp.GetCenterHigh(skillS.TheUnitTarget.Type, skillS.TheUnitTarget.ConfigId),
                skillS.TheUnitTarget.Position.z);
            skillS.TargetPosition = TargetPosition;
            skillS.OnAddHurtIds(skillS.TheUnitTarget.Id);
            BroadcastSkill(skillS, lastTarget.Id, skillS.TheUnitTarget.Id, 0f, 0f, 0f);
            skillS.OnCollisionUnit(lastTarget);
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}