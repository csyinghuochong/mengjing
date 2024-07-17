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
            if (aiComponent.LocalDungeonUnit == null)
            {
                aiComponent.Stop();
                Log.Error($"aiComponent.LocalDungeonUnit == null: scenetype:{ aiComponent.SceneType}  confidid: {unit.ConfigId}");
                return 0;
            }
            if (math.distance(unit.Position, aiComponent.LocalDungeonUnit.Position) <= aiComponent.ActRange)
            {
                nearest = aiComponent.LocalDungeonUnit;
            }
            if (nearest == null)
            {
                RolePetInfo rolePetInfo = aiComponent.LocalDungeonUnit.GetComponent<PetComponentS>().GetFightPet();
                if (rolePetInfo != null)
                {
                    Unit pet = unit.GetParent<UnitComponent>().Get(rolePetInfo.Id);
                    if (pet != null && math.distance(unit.Position, pet.Position) <= aiComponent.ActRange)
                    {
                        nearest = pet;
                    }
                }
            }
            
            if (nearest == null || !nearest.IsCanBeAttack())
            {
                aiComponent.TargetID = 0;
                aiComponent.noCheckStatus = true;
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
