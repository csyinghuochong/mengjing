using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    public static class AIHelp
    {
        //己方位置
        public static List<float3> Formation_1()
        {
            return new List<float3>()
            {
                //前排
                new float3(-1.88f, 0f, -9.11f),
                new float3(1.17f, 0f, -9.11f),
                new float3(4.28f, 0f, -9.11f),
                //中排
                new float3(-1.88f, 0f, -12.16f),
                new float3(1.17f, 0f, -12.16f),
                new float3(4.28f, 0f, -12.16f),
                //后排
                new float3(-1.88f, 0f, -15.33f),
                new float3(1.17f, 0f, -15.33f),
                new float3(4.28f, 0f, -15.33f),
            };
        }

        //对方位置
        public static List<float3> Formation_2()
        {
            return new List<float3>()
            {
                //前排
                new float3(-1.88f, 0f, 9.87f),
                new float3(1.17f, 0f, 9.87f),
                new float3(4.28f, 0f, 9.87f),
                //中排
                new float3(-1.88f, 0f, 13.09f),
                new float3(1.17f, 0f, 13.09f),
                new float3(4.28f, 0f, 13.09f),
                //后排
                new float3(-1.88f, 0f, 16.14f),
                new float3(1.17f, 0f, 16.14f),
                new float3(4.28f, 0f, 16.14f),
            };
        }


        /// <summary>
        /// 每个格子对应的搜索顺序
        /// </summary>

        public static List<int>[] PetPositionAttack()
        {
            return new List<int>[]
            {
                new List<int>()
                {
                    0,
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8
                },
                new List<int>()
                {
                    1,
                    0,
                    2,
                    4,
                    3,
                    5,
                    7,
                    6,
                    8
                },
                new List<int>()
                {
                    2,
                    1,
                    0,
                    5,
                    4,
                    3,
                    8,
                    7,
                    6
                },
                new List<int>()
                {
                    0,
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8
                },
                new List<int>()
                {
                    1,
                    0,
                    2,
                    4,
                    3,
                    5,
                    7,
                    6,
                    8
                },
                new List<int>()
                {
                    2,
                    1,
                    0,
                    5,
                    4,
                    3,
                    8,
                    7,
                    6
                },
                new List<int>()
                {
                    0,
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8
                },
                new List<int>()
                {
                    1,
                    0,
                    2,
                    4,
                    3,
                    5,
                    7,
                    6,
                    8
                },
                new List<int>()
                {
                    2,
                    1,
                    0,
                    5,
                    4,
                    3,
                    8,
                    7,
                    6
                }
            };

        }

        //摄像机位置
        public static float3 FuBenCameraPosition()
        {
            return new float3(14, 22f, 0f);
        }

        public static float3 FuBenCameraRotation()
        {
            return new float3(60f, -90f, 0);
        }

        //拖动位置
        public const float FuBenCameraPositionMin_X = -50f;
        public const float FuBenCameraPositionMax_X = 50f;
        public const float FuBenCameraPositionMin_Z = -50f;
        public const float FuBenCameraPositionMax_Z = 50f;


        public static bool IsCanAttackUnit(this Unit self, Unit defend, bool checkdead = true)
        {
            return true;
        }

        public static Unit GetNearestEnemy_Client(Unit main, float maxdis)
        {
            Unit nearest = null;
            float distance = -1f;
            List<Unit> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd > maxdis || !main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                //找到目标直接跳出来
                if (dd < distance || distance < 0f)
                {
                    distance = dd;
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
        /// <returns></returns>
        public static Unit GetNearestEnemy(Unit main, float maxdis, bool isMini = false)
        {
            Unit nearest = null;
            float minDistance = maxdis;
            List<Unit> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
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


        public static Unit GetNearestEnemyByPosition(Unit main, float3 position, float maxdis)
        {
            Unit nearest = null;
            float minDistance = maxdis;
            List<Unit> units = main.GetParent<UnitComponent>().GetAll();
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
            List<Unit> units = main.GetParent<UnitComponent>().GetAll();
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
            List<Unit> units = main.GetParent<UnitComponent>().GetAll();
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

            List<Unit> allunits = main.GetParent<UnitComponent>().GetAll();
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

            List<Unit> monsters = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < monsters.Count; i++)
            {
                Unit unit = monsters[i];
                AIComponent aIComponent = monsters[i].GetComponent<AIComponent>();
                if (aIComponent == null || unit.Type != UnitType.Monster)
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

        public static List<Unit> GetNearestMonsters(Unit main, float maxdis)
        {
            List<Unit> nearest = new List<Unit>();
            List<Unit> units = main.GetParent<UnitComponent>().GetAll();
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
            List<Unit> units = unitForm.GetParent<UnitComponent>().GetAll();
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