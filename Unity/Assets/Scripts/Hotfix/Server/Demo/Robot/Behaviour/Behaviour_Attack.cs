using System;
using ET.Client;
using Unity.Mathematics;
using UnitHelper = ET.Client.UnitHelper;

namespace ET
{
    //战场
    public class Behaviour_Attack : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_Attack;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            if (aiComponent.TargetID == 0)
            {
                return false;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(aiComponent.Root());
            Unit target = unit.GetParent<UnitComponent>().Get(aiComponent.TargetID);
            if (target == null || target.IsDisposed)
            {
                return false;
            }

            float distance = PositionHelper.Distance2D(target.Position, unit.Position);
            if (distance < aiComponent.ActDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            //Console.WriteLine("Behaviour_Attack.Execute");
            Scene root = aiComponent.Root();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            int sceneType = root.GetComponent<MapComponent>().MapType;
            while (true)
            {
                if (unit.IsDisposed)
                {
                    break;
                }

                Unit target = unit.GetParent<UnitComponent>().Get(aiComponent.TargetID);
                if (target != null && target.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_Dead) == 0
                    && math.distance(unit.Position, target.Position) < aiComponent.ActDistance)
                {
                    int[] weights = new int[] { 70, 30 };
                    int index = RandomHelper.RandomByWeight(weights);
                    if (index == 0)
                    {
                        aiComponent.Root().GetComponent<AttackComponent>().AutoAttack_1(unit, target);
                    }

                    if (index == 1)
                    {
                        //触发技能
                        SkillPro skillPro = root.GetComponent<SkillSetComponentC>().GetCanUseSkill();
                       
                        if (SkillConfigCategory.Instance.Contain(skillPro.SkillID) &&
                            SkillConfigCategory.Instance.Get(skillPro.SkillID).SkillType == 1)
                        {
                            float3 direction = target.Position - unit.Position;

                            // 返回一个四元数，该四元数表示绕单位轴旋转一个以弧度为单位的角度。
                            // quaternion.AxisAngle(math.up() , skillcmd.TargetAngle / 57.3f );
                            //
                            // math.degrees()                                 弧度转角度
                            // math.radians(skillcmd.TargetAngle)   角度转弧度

                            float ange = math.degrees(math.atan2(direction.x, direction.z));
                            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(SkillHelp.GetWeaponSkill(skillPro.SkillID,
                                UnitHelper.GetEquipType(aiComponent.Root()), null));
                            float targetDistance = skillConfig.SkillZhishiType == 1 ? math.distance(unit.Position, target.Position) : 0;
                            unit.GetComponent<SkillManagerComponentC>()
                                    .SendUseSkill(skillPro.SkillID, 0, (int)ange, target.Id, targetDistance).Coroutine();
                        }
                    }
                }
                else
                {
                    aiComponent.TargetID = 0;
                    aiComponent.ChangeBehaviour(BehaviourType.Behaviour_ZhuiJi);
                    return;
                }

                if (sceneType == MapTypeEnum.Battle && target.GetComponent<BuffManagerComponentC>().GetBuffByConfigId(90106002).Count > 0)
                {
                    aiComponent.TargetID = 0;
                    aiComponent.ChangeBehaviour(BehaviourType.Behaviour_Retreat);
                }

                long cdTime = root.GetComponent<AttackComponent>().CDTime;

                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(cdTime, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    //Console.WriteLine("Behaviour_Attack.Exit: IsCancel");
                    return;
                }
            }
        }
    }
}