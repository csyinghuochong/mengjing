using Unity.Mathematics;

namespace ET.Server
{
    
    public class AI_TargetRetreat : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            if (math.distance(aiComponent.TargetZhuiJi ,float3.zero) == 0)
            {
                return 1;
            }
            float distance = PositionHelper.Distance2D(aiComponent.TargetZhuiJi, unit.Position);
            return (!aiComponent.IsRetreat && distance >= aiComponent.ChaseRange) ? 0 : 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            if (unit.IsBoss())
            {
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.BossInCombat, 0);
                unit.GetComponent<HeroDataComponentS>().OnKillZhaoHuan(null);
                unit.GetComponent<AttackRecordComponent>().ClearBeAttack();
            }
            aiComponent.TargetID = 0;
            aiComponent.IsRetreat = true;
            unit.Stop(0);
            await ETTask.CompletedTask;
        }
    }
}
