using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 野外副本怪物AI
    /// </summary>
    public class AI_XunLuo: AAIHandler
    {
        
        /// <summary>
        /// 宠物副本，对位攻击。寻找对面的格子
        /// </summary>
        /// <param name="main"></param>
        /// <returns></returns>
        public static Unit GetNearestCell(Unit main)
        {
            int selfCell = main.GetComponent<NumericComponentS>().GetAsInt(NumericType.UnitPositon);

            ////对位攻击顺序
            List<int> postionAttack = ConfigData.PetPositionAttack[selfCell];

            Unit[] enemyUnit = new Unit[9];
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
                {
                    continue;
                }
                if (!main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                int position = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.UnitPositon);
                enemyUnit[position] = unit; 
            }

            for (int i = 0; i < postionAttack.Count; i++)
            {
                Unit enemy = enemyUnit[postionAttack[i]];
                if (enemy != null)
                {
                    return enemy;
                }
            }

            return null;
        }

        
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            if (aiComponent.TargetID != 0 || aiComponent.IsRetreat)
            {
                return 1;
            }
            Unit unit = aiComponent.GetParent<Unit>();
            Unit nearest = null;
            if (aiComponent.SceneType == MapTypeEnum.PetDungeon
                || aiComponent.SceneType == MapTypeEnum.PetTianTi)
            {
                nearest = GetNearestCell(unit);
            }
            else
            {
                nearest = GetTargetHelpS.GetNearestEnemy(unit, aiComponent.ActRange, true); ;
            } 
            if (nearest == null)
            {
                aiComponent.TargetID = 0;
                return 1;
            }

            if ( unit.IsBoss())
            {
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.BossInCombat, 1, true, true);
            }
            aiComponent.TargetID = nearest.Id;
            return (aiComponent.TargetID == 0) ? 1 : 0;
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
                    return;
                }
            }
        }

    }
}