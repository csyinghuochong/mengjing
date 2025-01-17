using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 单人副本怪物AI
    /// </summary>
    public class AI_LocalDungeon : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            if (aiComponent.TargetID != 0 || aiComponent.IsRetreat)
            {
                return 1;
            }
            Unit nearest = null;
            Unit unit = aiComponent.GetParent<Unit>();
            List<Unit> unitlist = UnitHelper.GetUnitList(aiComponent.Scene(), UnitType.Player);
            if (unitlist.Count == 0)
            {
                aiComponent.Stop();
                return 0;
            }

            Unit playe = unitlist[0];
            if (math.distance(unit.Position, playe.Position) <= aiComponent.ActRange)
            {
                nearest = playe;
            }
            if (nearest == null)
            {
                List<Unit> petlist = UnitHelper.GetUnitList(aiComponent.Scene(), UnitType.Pet);
                if (petlist.Count > 0  && math.distance(unit.Position, petlist[0].Position) <= aiComponent.ActRange)
                {
                    nearest = petlist[0];
                }
            }
            
            if (nearest == null || !nearest.IsCanBeAttack())
            {
                aiComponent.TargetID = 0;
                return 0;
            }

            if (unit.IsBoss())
            {
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.BossInCombat, 1, true, true);
            }
            aiComponent.TargetID = nearest.Id;
            return (aiComponent.TargetID > 0)?1 : 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            while (true)
            {
                if (aiComponent.PatrolRange > 0f)
                {
                    float3 initVec3 = unit.GetBornPostion();
                    float new_x = initVec3.x + RandomHelper.RandomNumberFloat(-1 * aiComponent.PatrolRange, aiComponent.PatrolRange);
                    float new_z = initVec3.z + RandomHelper.RandomNumberFloat(-1 * aiComponent.PatrolRange, aiComponent.PatrolRange);
                    float3 nextTarget = new float3(new_x, initVec3.y, new_z);

                    unit.FindPathMoveToAsync(nextTarget).Coroutine();
                }
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(10000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    //Log.Debug("巡逻被打断！！" );
                    return;
                }
            }
        }

    }
}
