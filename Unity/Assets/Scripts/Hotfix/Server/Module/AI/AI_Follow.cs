using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    
    public class AI_Follow : AAIHandler
    {

        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            UnitComponent unitComponent = unit.GetParent<UnitComponent>();
            long masterid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId);
            Unit master = unitComponent.Get(masterid);
            if (master == null)
            {
                return 1;
            }

            float distance = math.distance(unit.Position, master.Position);
            AttackRecordComponent attackRecordComponent = master.GetComponent<AttackRecordComponent>();
            if (distance > aiComponent.ActRange)    //超出追击距离，返回
            {
                aiComponent.TargetID = 0;
                attackRecordComponent.PetLockId = 0;
                return 0;
            }

            long mastaerAttackId = attackRecordComponent.PetLockId;
            Unit enemyUnit = unitComponent.Get(mastaerAttackId);
            if (enemyUnit == null || !enemyUnit.IsCanBeAttack())
            {
                mastaerAttackId = attackRecordComponent.AttackingId;
                enemyUnit = unitComponent.Get(mastaerAttackId);
            }
            if (enemyUnit == null || !enemyUnit.IsCanBeAttack())
            {
                mastaerAttackId = attackRecordComponent.BeAttackId;
                enemyUnit = unitComponent.Get(mastaerAttackId);
            }
            if (enemyUnit == null || !enemyUnit.IsCanBeAttack())
            {
                enemyUnit = unitComponent.Get(aiComponent.TargetID);
            }
            if (enemyUnit == null || !unit.IsCanAttackUnit(enemyUnit))
            {
                aiComponent.TargetID = 0;
                return 0;
            }

            distance = math.distance(unit.Position, enemyUnit.Position);
            ///1
            aiComponent.TargetID = enemyUnit.Id;
            return (aiComponent.TargetID > 0) ? 1 : 0;
        }

        public static float3 GetFollowPosition(Unit unit, Unit master)
        {
            //Vector3 cur = unit.Position;
            //Vector3 tar = master.Position;
            //Vector3 dir = (cur - tar).normalized;
            //tar = tar + (1f * dir);
            float3 dir = unit.Position - master.Position;
            float ange = math.degrees(math.atan2(dir.x, dir.z));
            float addg = unit.Id % 10 * (unit.Id % 2 == 0 ? 5 : -5);
            addg += RandomHelper.RandFloat() * 5f;
            quaternion rotation = quaternion.Euler(0, math.radians(ange + addg), 0);
            float3 tar = master.Position + math.mul(rotation , math.forward());
            return tar;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            long masterid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId);
            Unit master = unit.GetParent<UnitComponent>().Get(masterid);
            /*
            while (true)
            {
                float distacne = Vector3.Distance(unit.Position, master.Position);
                if (distacne > 6f)
                {
                    Vector3 nextTarget = GetFollowPosition(unit, master);
                    unit.GetComponent<NumericComponent>().Set(NumericType.Now_Speed, 60000);
                    unit.FindPathMoveToAsync(nextTarget, cancellationToken, false).Coroutine();
                }
                
                else if (distacne > 1.1f)
                {
                    Vector3 nextTarget = GetFollowPosition(unit, master);
                    unit.GetComponent<NumericComponent>().Set(NumericType.Now_Speed, 30000);
                    unit.FindPathMoveToAsync(nextTarget, cancellationToken, false).Coroutine();
                }
                
                bool timeRet = await TimerComponent.Instance.WaitAsync(100, cancellationToken);
                if (!timeRet)
                {
                    return;
                }
            }
            */
            while (true) 
            {
                long nowspeed = 60000;
                if (master!=null && !master.IsDisposed)
                {
                    nowspeed = master.GetComponent<NumericComponentS>().GetAsLong(NumericType.Now_Speed);
                }
                int errorCode = unit.GetComponent<StateComponentS>().CanMove();
                float distacne = math.distance(unit.Position, master.Position);

                if (errorCode == ErrorCode.ERR_Success && distacne > 1.5f)
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
                    unit.GetComponent<NumericComponentS>().Set(NumericType.Now_Speed, nowspeed);
                    unit.FindPathMoveToAsync(nextTarget).Coroutine();
                }
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(200, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    break;
                }

            }
        }
    }
}