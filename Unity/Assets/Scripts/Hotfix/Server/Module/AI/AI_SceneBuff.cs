using Unity.Mathematics;

namespace ET.Server
{

    public class AI_SceneBuff : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(unit.ConfigId);
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(monsterCof.ActSkillID);

            bool remove = false;
            long instanceId = aiComponent.InstanceId;
            for (int i = 0; i < 100000; ++i)
            {
                Unit target = GetTargetHelpS.GetNearestEnemy(unit, (float)skillConfig.SkillRangeSize, true);

                //检测目标是否在技能范围
                if (!remove &&  target != null )
                {
                    remove = true;
                    float3 direction = target.Position - unit.Position;

                    C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                    cmd.SkillID = monsterCof.ActSkillID;
                    cmd.TargetID = target.Id;
                    if (skillConfig.SkillZhishiTargetType == 1)  //自身点
                    {
                        cmd.TargetAngle = 0;
                        cmd.TargetDistance = 0;
                    }
                    else
                    {
                        float ange = math.degrees(math.atan2(direction.x, direction.z));
                        cmd.TargetAngle = (int)math.floor(ange);
                        cmd.TargetDistance = math.distance(unit.Position, target.Position);
                    }

                    //触发技能
                    unit.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, true);
                }

                long waitTime = remove ? 1000 : 200;
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(waitTime, cancellationToken);
                if (instanceId != aiComponent.InstanceId)
                {
                    return;
                }
                if (remove)
                {
                    //unit.GetParent<UnitComponent>().Remove(unit.Id);
                    unit.GetComponent<HeroDataComponentS>().OnDead(null);
                    return;
                }
            }
        }
    }
}
