using Unity.Mathematics;

namespace ET.Server
{
    public class AI_Attack: AAIHandler
    {

        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            Unit target = aiComponent.Scene().GetComponent<UnitComponent>().Get(aiComponent.TargetID);
            if (target == null || target.IsDisposed)
            {
                aiComponent.TargetID = 0;
                return 1;
            }

            float distance = math.distance(target.Position, aiComponent.GetParent<Unit>().Position);
            return (distance > aiComponent.ActDistance) ? 1 : 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            SkillManagerComponentS skillManagerComponent = unit.GetComponent<SkillManagerComponentS>();
            StateComponentS stateComponent = unit.GetComponent<StateComponentS>();

            for (int i = 0; i < 100000; ++i)
            {
                long rigidityEndTime = 0;
                int skillId =  aiComponent.GetActSkillId();
                if (skillId == 0)
                {
                    break;
                }

                Unit target = unit.GetParent<UnitComponent>().Get(aiComponent.TargetID);
                if (target == null || !target.IsCanBeAttack())
                {
                    aiComponent.TargetID = 0;
                }

                if (aiComponent.TargetID != 0 && target != null)
                {
                    float distance = math.distance(target.Position, aiComponent.GetParent<Unit>().Position);
                    if(distance <= aiComponent.ActDistance && skillManagerComponent.IsCanUseSkill (skillId) == ErrorCode.ERR_Success)
                    {
                        SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
                        float3 direction = target.Position - unit.Position;

                        C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                        //触发技能
                        cmd.TargetID = target.Id;
                        cmd.SkillID = skillId;

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

                        skillManagerComponent.OnUseSkill(cmd, true);
                        rigidityEndTime = (long)(SkillConfigCategory.Instance.Get(cmd.SkillID).SkillRigidity * 1000) + TimeHelper.ClientNow();
                    }
                }

                if (rigidityEndTime > stateComponent.RigidityEndTime)
                {
                    stateComponent.SetRigidityEndTime(rigidityEndTime);
                }

                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(200, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }
    }
}