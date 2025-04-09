using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public static class GetTargetHelpS
    {
        /// <summary>
        /// 查找前方的敌人
        /// </summary>
        /// <param name="main"></param>
        /// <param name="maxdis"></param>
        /// <param name="isMini"></param>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public static Unit GetForwardNearestEnemy(Unit main, float maxdis, float maxAngle, bool isMini = false, int unitType = 0)
        {
            Unit nearest = null;
            float minDistance = maxdis;
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
                {
                    continue;
                }

                if (unitType != 0 && unit.Type != unitType)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd > maxdis || !main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                float3 direction = unit.Position - main.Position;
                float3 direction2 = math.mul(main.Rotation, math.forward());
                float angle = Math.Abs(MathHelper.Angle(direction, direction2));
                if (angle > maxAngle)
                {
                    continue;
                }

                if (!isMini)
                {
                    //找到目标直接跳出来
                    nearest = unit;
                    break;
                }

                if (dd < minDistance)
                {
                    minDistance = dd;
                    nearest = unit;
                }
            }

            return nearest;
        }

        /// <summary>
        /// 服务器使用。不需要找最近的
        /// </summary>
        /// <param name="main"></param>
        /// <param name="maxdis"></param>
        /// <param name="isMini">是否要最小距离</param>
        /// <param name="unitType">目标Unit类型</param>
        /// <returns></returns>
        public static Unit GetNearestEnemy(Unit main, float maxdis, bool isMini = false, int unitType = 0)
        {
            Unit nearest = null;
            float minDistance = maxdis;
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
                {
                    continue;
                }

                if (unitType != 0 && unit.Type != unitType)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd > maxdis || !main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                if (!isMini)
                {
                    //找到目标直接跳出来
                    nearest = unit;
                    break;
                }

                if (dd < minDistance)
                {
                    minDistance = dd;
                    nearest = unit;
                }
            }

            return nearest;
        }

        
        /// <summary>
        /// 服务器使用。不需要找最近的
        /// </summary>
        /// <param name="main"></param>
        /// <param name="maxdis"></param>
        /// <param name="isMini">是否要最小距离</param>
        /// <param name="unitType">目标Unit类型</param>
        /// <returns></returns>
        public static Unit GetNearestEnemyAIPriority(Unit main, float maxdis, string aiNodeParams,  bool isMini = false)
        {
            Unit nearest = null;
            float minDistance = maxdis;
            
            //3;1;0
            
            
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit target = units[i];
                if (target.IsDisposed || main.Id == target.Id)
                {
                    continue;
                }

                string  targetinfo= target.GetAIPriorityParams();
                
                if (!aiNodeParams.Contains(targetinfo))
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, target.Position);
                if (dd > maxdis || !main.IsCanAttackUnit(target))
                {
                    continue;
                }

                if (!isMini)
                {
                    //找到目标直接跳出来
                    nearest = target;
                    break;
                }

                if (dd < minDistance)
                {
                    minDistance = dd;
                    nearest = target;
                }
            }

            return nearest;
        }

        public static Unit GetNearestEnemyByPosition(Unit main, float3 position, float maxdis)
        {
            Unit nearest = null;
            float minDistance = maxdis;
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(position, unit.Position);
                if (dd > maxdis || !main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                if (dd < minDistance)
                {
                    minDistance = dd;
                    nearest = unit;
                }
            }

            return nearest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="main"></param>
        /// <param name="maxdis"></param>
        /// <param name="numberType"></param>
        /// <returns></returns>
        public static List<long> GetNearestEnemyByNumber(Unit main, float maxdis, int number)
        {
            List<long> unitIdList = new List<long>();
            List<EnemyUnitInfo> enemyUnitInfos = new List<EnemyUnitInfo>();
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd > maxdis)
                {
                    continue;
                }

                if (!main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                enemyUnitInfos.Add(new EnemyUnitInfo() { Distacne = dd, UnitID = unit.Id });
            }

            if (enemyUnitInfos.Count == 0)
            {
                return unitIdList;
            }

            enemyUnitInfos.Sort(delegate(EnemyUnitInfo a, EnemyUnitInfo b) { return (int) (b.Distacne - a.Distacne); });

            number = enemyUnitInfos.Count >= number? number : enemyUnitInfos.Count;
            int[] index = RandomHelper.GetRandoms(number, 0, enemyUnitInfos.Count);
            for (int i = 0; i < index.Length; i++)
            {
                unitIdList.Add(enemyUnitInfos[index[i]].UnitID);
            }

            return unitIdList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="main"></param>
        /// <param name="maxdis"></param>
        /// <param name="numberType"></param>
        /// <returns></returns>
        public static List<long> GetNearestEnemyIds(Unit main, float maxdis, int numberType)
        {
            List<long> unitIdList = new List<long>();
            List<EnemyUnitInfo> enemyUnitInfos = new List<EnemyUnitInfo>();
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd > maxdis)
                {
                    continue;
                }

                if (!main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                enemyUnitInfos.Add(new EnemyUnitInfo() { Distacne = dd, UnitID = unit.Id });
            }

            if (enemyUnitInfos.Count == 0)
            {
                return unitIdList;
            }

            enemyUnitInfos.Sort(delegate(EnemyUnitInfo a, EnemyUnitInfo b) { return (int) (a.Distacne - b.Distacne); });
            switch (numberType)
            {
                case 1:
                    unitIdList.Add(enemyUnitInfos[RandomHelper.RandomNumber(0, enemyUnitInfos.Count)].UnitID);
                    break;
                case 2:
                    unitIdList.Add(enemyUnitInfos[0].UnitID);
                    break;
                case 3:
                    unitIdList.Add(enemyUnitInfos[enemyUnitInfos.Count - 1].UnitID);
                    break;
                case 21:
                    int number = enemyUnitInfos.Count >= 2? 2 : enemyUnitInfos.Count;
                    int[] index = RandomHelper.GetRandoms(number, 0, enemyUnitInfos.Count);
                    for (int i = 0; i < index.Length; i++)
                    {
                        unitIdList.Add(enemyUnitInfos[index[i]].UnitID);
                    }

                    break;
                case 101:
                    for (int i = 0; i < enemyUnitInfos.Count; i++)
                    {
                        unitIdList.Add(enemyUnitInfos[i].UnitID);
                    }

                    break;
                default:
                    if (enemyUnitInfos.Count > 0)
                    {
                        unitIdList.Add(enemyUnitInfos[0].UnitID);
                    }

                    break;
            }

            return unitIdList;
        }

        public static List<Unit> GetEnemyUnit(Unit main, int unitType, float3 pos, float maxdis)
        {
            List<Unit> nearest = new List<Unit>();

            List<EntityRef<Unit>> allunits = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < allunits.Count; i++)
            {
                Unit unit = allunits[i];
                if (unit.Type != unitType)
                {
                    continue;
                }

                if (PositionHelper.Distance2D(pos, unit.Position) > maxdis)
                {
                    continue;
                }

                if (!main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                nearest.Add(unit);
            }

            return nearest;
        }

        public static List<Unit> GetEnemyMonsters(Unit main, float3 pos, float maxdis)
        {
            List<Unit> nearest = new List<Unit>();

            List<EntityRef<Unit>> monsters = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < monsters.Count; i++)
            {
                Unit unit = monsters[i];
                if ( unit.Type != UnitType.Monster)
                {
                    continue;
                }

                if (PositionHelper.Distance2D(pos, unit.Position) > maxdis)
                {
                    continue;
                }

                if (!main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                nearest.Add(unit);
            }

            return nearest;
        }

         /// <summary>
                /// 
                /// </summary>
                /// <param name="main"></param>
                /// <param name="maxdis"></param>
                /// <param name="numberType"></param>
                /// <returns></returns>
                public static List<long> GetNearestEnemyByNumber(Unit main, float3 targetpos,  float maxdis, int number)
                {
                    List<long> unitIdList = new List<long>();
                    List<EnemyUnitInfo> enemyUnitInfos = new List<EnemyUnitInfo>();
                    List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
                    for (int i = 0; i < units.Count; i++)
                    {
                        Unit unit = units[i];
                        if (unit.IsDisposed || main.Id == unit.Id)
                        {
                            continue;
                        }
        
                        float dd = PositionHelper.Distance2D(targetpos, unit.Position);
                        if (dd > maxdis)
                        {
                            continue;
                        }
                        if (!main.IsCanAttackUnit(unit))
                        {
                            continue;
                        }
        
                        enemyUnitInfos.Add(new EnemyUnitInfo() { Distacne = dd, UnitID = unit.Id });
                    }
                    if (enemyUnitInfos.Count == 0)
                    {
                        return unitIdList;
                    }
        
                    enemyUnitInfos.Sort(delegate (EnemyUnitInfo a, EnemyUnitInfo b)
                    {
                        return (int)(b.Distacne - a.Distacne);
                    });
        
                    number = enemyUnitInfos.Count >= number ? number : enemyUnitInfos.Count;
                    int[] index = RandomHelper.GetRandoms(number, 0, enemyUnitInfos.Count);
                    for (int i = 0; i < index.Length; i++)
                    {
                        unitIdList.Add(enemyUnitInfos[index[i]].UnitID);
                    }
        
                    return unitIdList;
                }

        
        public static List<Unit> GetNearestMonsters(Unit main, float maxdis)
        {
            List<Unit> nearest = new List<Unit>();
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id || unit.Type != UnitType.Monster)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd > maxdis)
                {
                    continue;
                }

                if (!main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                nearest.Add(unit);
            }

            return nearest;
        }

        public static Unit GetNearestUnit(Unit unitForm, float3 position, float maxdis, List<long> hurtids)
        {
            Unit nearest = null;
            float distance = maxdis;
            List<EntityRef<Unit>> units = unitForm.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit uu = units[i];
                if (uu.Id == unitForm.Id || hurtids.Contains(uu.Id))
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(position, uu.Position);
                if (dd > maxdis)
                {
                    continue;
                }

                if (!unitForm.IsCanAttackUnit(uu))
                {
                    continue;
                }

                if (dd < distance)
                {
                    nearest = uu;
                    distance = dd;
                }
            }

            return nearest;
        }
    }
}