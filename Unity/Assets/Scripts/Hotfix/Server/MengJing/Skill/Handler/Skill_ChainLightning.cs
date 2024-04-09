namespace ET.Server
{

    //闪电链
    public class Skill_ChainLightning : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            OnUpdate(skillS, 0);
        }

        public void BroadcastSkill(SkillS skillS, long unitid, long targetId, float x, float y, float z)
        {
            MapMessageHelper.Broadcast(skillS.TheUnitFrom, new M2C_ChainLightning() 
            {
                UnitId = unitid,
                TargetID = targetId, 
                SkillID = skillS.SkillInfo.WeaponSkillID,
                PosX = x, PosY = y, PosZ = z
            });
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();
            if (serverNow - skillS.SkillTriggerLastTime < 500)
            {
                return;
            }
            skillS.SkillTriggerLastTime = serverNow;

            //从目标点最近的位置开始释放闪电链。最多连5米以内的5个单位
            Unit lastTarget = skillS.TheUnitFrom;
            Unit target = null;
            if (skillS.HurtIds.Count == 0)
            {
                target = AIHelp.GetNearestEnemy(lastTarget, 10f, true);
                if (target == null ||( target!= null && !skillS.CheckShape(target.Position)))
                {
                    skillS.SetSkillState(SkillState.Finished);
                    BroadcastSkill(skillS, skillS.TheUnitFrom.Id, 0, skillS.TargetPosition.x, skillS.TargetPosition.y, skillS.TargetPosition.z);
                    return;
                }
            }
            else
            { 
                lastTarget = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(skillS.HurtIds[skillS.HurtIds.Count - 1]);
                if (lastTarget == null)
                {
                    skillS.SetSkillState(SkillState.Finished);
                    return;
                }
                target = AIHelp.GetNearestUnit(skillS.TheUnitFrom, lastTarget.Position, 5f, skillS.HurtIds);
                if (target == null)
                {
                    skillS.SetSkillState(SkillState.Finished);
                    return;
                }
            }

            if (lastTarget != null && target != null)
            {
                skillS.HurtIds.Add(target.Id);
                skillS.OnCollisionUnit(target);
                BroadcastSkill(skillS, lastTarget.Id, target.Id, 0f,0f,0f);
            }

            if (serverNow > skillS.SkillEndTime || skillS.HurtIds.Count >= 5)
            {
                skillS.SetSkillState(SkillState.Finished);
            }

            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
