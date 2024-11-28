using Unity.Mathematics;

namespace ET.Server
{
    public class TuoGuan_Follow : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 0;
            // Unit unit = aiComponent.GetParent<Unit>();
            // UnitComponent unitComponent = unit.GetParent<UnitComponent>();
            // int petfightindex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);
            // PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            // Unit master = petComponentS.GetFightPetByIndex(petfightindex);
            // if (master == null)
            // {
            //     return 1;
            // }
            //
            // float distance = math.distance(unit.Position, master.Position);
            // AttackRecordComponent attackRecordComponent = master.GetComponent<AttackRecordComponent>();
            // if (distance > aiComponent.ActRange) //超出追击距离，返回
            // {
            //     aiComponent.TargetID = 0;
            //     attackRecordComponent.PetLockId = 0;
            //     return 0;
            // }
            //
            // long mastaerAttackId = attackRecordComponent.PetLockId;
            // Unit enemyUnit = unitComponent.Get(mastaerAttackId);
            // if (enemyUnit == null || !enemyUnit.IsCanBeAttack())
            // {
            //     mastaerAttackId = attackRecordComponent.AttackingId;
            //     enemyUnit = unitComponent.Get(mastaerAttackId);
            // }
            //
            // if (enemyUnit == null || !enemyUnit.IsCanBeAttack())
            // {
            //     mastaerAttackId = attackRecordComponent.BeAttackId;
            //     enemyUnit = unitComponent.Get(mastaerAttackId);
            // }
            //
            // if (enemyUnit == null || !enemyUnit.IsCanBeAttack())
            // {
            //     enemyUnit = unitComponent.Get(aiComponent.TargetID);
            // }
            //
            // if (enemyUnit == null || !unit.IsCanAttackUnit(enemyUnit))
            // {
            //     aiComponent.TargetID = 0;
            //     return 0;
            // }
            //
            // distance = math.distance(unit.Position, enemyUnit.Position);
            // aiComponent.TargetID = enemyUnit.Id;
            // return (aiComponent.TargetID > 0) ? 1 : 0;
        }

        private static float3 GetFollowPosition(Unit unit, Unit master)
        {
            float3 dir = unit.Position - master.Position;
            float ange = math.degrees(math.atan2(dir.x, dir.z));
            float addg = unit.Id % 100 * (unit.Id % 2 == 0 ? 5 : -5);
            addg += RandomHelper.RandFloat() * 5f;
            quaternion rotation = quaternion.Euler(0, math.radians(ange + addg), 0);
            float3 tar = master.Position + math.mul(rotation, math.forward()) * 2f;
            return tar;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            int petfightindex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);
            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            Unit master = petComponentS.GetFightPetByIndex(petfightindex);

            long oldSpeed = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.Base_Speed_Base);
            while (true)
            {
                long nowspeed = 60000;
                int errorCode = unit.GetComponent<StateComponentS>().CanMove();
                float distacne = math.distance(unit.Position, master.Position);

                if (errorCode == ErrorCode.ERR_Success && distacne > 3f)
                {
                    nowspeed = (long)(nowspeed * distacne / 2f);
                }
                else
                {
                    nowspeed = 0;
                }

                //宠物移动速度限制
                if (nowspeed >= 100000)
                {
                    nowspeed = 100000;
                }

                if (nowspeed > 0)
                {
                    float3 nextTarget = GetFollowPosition(unit, master);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Base_Speed_Base, nowspeed);
                    unit.FindPathMoveToAsync(nextTarget).Coroutine();
                }

                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(200, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    break;
                }
            }

            if (!unit.IsDisposed)
            {
                unit.GetComponent<NumericComponentS>()?.ApplyValue(NumericType.Base_Speed_Base, oldSpeed);
            }

            await ETTask.CompletedTask;
        }
    }
}