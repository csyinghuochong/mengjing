using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public class AI_Retreat : AAIHandler
    {

        /// <summary>
        /// boss范围圈内最近的敌人
        /// </summary>
        /// <param name="main"></param>
        /// <param name="bornpos"></param>
        /// <param name="maxdis"></param>
        /// <returns></returns>
        public Unit GetHaveEnemy(AIComponent aIComponent, float3 bornpos, float maxdis)
        {
            Unit nearest = null;
            Unit main = aIComponent.GetParent<Unit>();
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(bornpos, unit.Position);
                if (dd > maxdis)
                {
                    continue;
                }
              
                if (!main.IsCanAttackUnit(unit, false))
                {
                    continue;
                }
                nearest = unit;
                break;
            }
            return nearest;
        }


        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            //Unit unit = aiComponent.GetParent<Unit>();
            Unit unit = aiComponent.GetParent<Unit>();
            float3 posVec3 = unit.GetBornPostion();
            float distance =  math.distance(posVec3, unit.Position);
            if (unit.IsBoss())
            {
                Unit enemy = GetHaveEnemy(aiComponent, posVec3, aiComponent.ChaseRange);
                return (distance >= aiComponent.ChaseRange && enemy == null) ? 0: 1;
            }
            else
            {
                return (distance >= aiComponent.ChaseRange) ? 0 : 1;
            }
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
            List<Unit> units = UnitHelper.GetUnitList(unit.Scene(), UnitType.Player);
            for (int i = 0; i < units.Count; i++)
            {
                units[i].GetComponent<BuffManagerComponentS>().OnRetreatRemoveBuff(unit.Id);
            }
            float3 bornVector3 = unit.GetBornPostion();

            while (true)
            {
                if (unit.GetComponent<StateComponentS>().CanMove()== ErrorCode.ERR_Success)
                {
                    unit.FindPathMoveToAsync(bornVector3).Coroutine();
                } 
                
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(1000, cancellationToken);
                if (!cancellationToken.IsCancel() && math.distance(bornVector3, unit.Position) < 0.5f && !unit.IsDisposed)
                {
                    NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
                    if (aiComponent.SceneType != MapTypeEnum.TeamDungeon && numericComponent.GetAsInt(NumericType.Now_Dead) == 0)
                    {
                        long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
                        numericComponent.ApplyValue(NumericType.Now_Hp, max_hp);
                    }
                    aiComponent.IsRetreat = false;
                }

                if (cancellationToken.IsCancel())
                {
                    aiComponent.IsRetreat = false;
                }

                //返回出生点
                if (!aiComponent.IsRetreat && unit.IsBoss())
                {
                    SkillManagerComponentS skillManagerComponent = unit.GetComponent<SkillManagerComponentS>();
                    skillManagerComponent?.OnFinish(true);
                }
                if (!aiComponent.IsRetreat)
                {
                    return;
                }
            }
        }
    }
}
