using System.Collections.Generic;

namespace ET.Client
{

    [EntitySystemOf(typeof(SceneAOIEntity))]
    [FriendOf(typeof(SceneAOIEntity))]
    public static partial class SceneAOIEntitySystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.SceneAOIEntity self, int distance, Unity.Mathematics.float3 pos)
        {
            self.ViewDistance = distance;
            self.Root().GetComponent<SceneAOIManagerComponent>().Add(self, pos.x, pos.z);
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.SceneAOIEntity self)
        {
             self.Root().GetComponent<SceneAOIManagerComponent>()?.Remove(self);
             self.ViewDistance = 0;
             self.SeeUnits.Clear();
             self.SeePlayers.Clear();
             self.BeSeePlayers.Clear();
             self.BeSeeUnits.Clear();
             self.SubEnterCells.Clear();
             self.SubLeaveCells.Clear();
        }
    }

    [FriendOf(typeof(SceneAOIEntity))]
    [FriendOf(typeof(SceneCell))]

    public static partial class SceneAOIEntitySystem
    {
                // 获取在自己视野中的对象
        public static Dictionary<long, EntityRef<SceneAOIEntity>> GetSeeUnits(this SceneAOIEntity self)
        {
            return self.SeeUnits;
        }

        public static Dictionary<long, EntityRef<SceneAOIEntity>> GetBeSeePlayers(this SceneAOIEntity self)
        {
            return self.BeSeePlayers;
        }

        public static Dictionary<long, EntityRef<SceneAOIEntity>> GetSeePlayers(this SceneAOIEntity self)
        {
            return self.SeePlayers;
        }

        // cell中的unit进入self的视野
        public static void SubEnter(this SceneAOIEntity self, SceneCell cell)
        {
            cell.SubsEnterEntities.Add(self.Id, self);
            foreach (KeyValuePair<long, EntityRef<SceneAOIEntity>> kv in cell.AOIUnits)
            {
                if (kv.Key == self.Id)
                {
                    continue;
                }

                self.EnterSight(kv.Value);
            }
        }

        public static void UnSubEnter(this SceneAOIEntity self, SceneCell cell)
        {
            cell.SubsEnterEntities.Remove(self.Id);
        }

        public static void SubLeave(this SceneAOIEntity self, SceneCell cell)
        {
            cell.SubsLeaveEntities.Add(self.Id, self);
        }

        // cell中的unit离开self的视野
        public static void UnSubLeave(this SceneAOIEntity self, SceneCell cell)
        {
            foreach (KeyValuePair<long, EntityRef<SceneAOIEntity>> kv in cell.AOIUnits)
            {
                if (kv.Key == self.Id)
                {
                    continue;
                }

                self.LeaveSight(kv.Value);
            }

            cell.SubsLeaveEntities.Remove(self.Id);
        }

        public static bool IsPlayer(this SceneAOIEntity self)
        {
            return self.MainHero == true;
        }

        // enter进入self视野
        public static void EnterSight(this SceneAOIEntity self, SceneAOIEntity enter)
        {
            // 有可能之前在Enter，后来出了Enter还在LeaveCell，这样仍然没有删除，继续进来Enter，这种情况不需要处理
            if (self.SeeUnits.ContainsKey(enter.Id))
            {
                return;
            }
            
            if (!SceneAOISeeCheckHelper.IsCanSee(self, enter))
            {
                return;
            }
            
            if (self.IsPlayer())
            {
                if (enter.IsPlayer())
                {
                    self.SeeUnits.Add(enter.Id, enter);
                    enter.BeSeeUnits.Add(self.Id, self);
                    self.SeePlayers.Add(enter.Id, enter);
                    enter.BeSeePlayers.Add(self.Id, self);
         
                }
                else
                {
                    self.SeeUnits.Add(enter.Id, enter);
                    enter.BeSeeUnits.Add(self.Id, self);
                    enter.BeSeePlayers.Add(self.Id, self);
                }
            }
            else
            {
                if (self.IsPlayer())
                {
                    self.SeeUnits.Add(enter.Id, enter);
                    enter.BeSeeUnits.Add(self.Id, self);
                    self.SeePlayers.Add(enter.Id, enter);
                }
                else
                {
                    self.SeeUnits.Add(enter.Id, enter);
                    enter.BeSeeUnits.Add(self.Id, self);
                }
            }

            if (self.IsPlayer()|| enter.IsPlayer())
            {
                EventSystem.Instance.Publish(self.Root(), new SceneUnitEnterSightRange() { A = self, B = enter });
            }
        }

        // leave离开self视野
        public static void LeaveSight(this SceneAOIEntity self, SceneAOIEntity leave)
        {
            if (self.Id == leave.Id)
            {
                return;
            }

            if (!self.SeeUnits.ContainsKey(leave.Id))
            {
                return;
            }
            
            self.SeeUnits.Remove(leave.Id);
            if (leave.IsPlayer())
            {
                self.SeePlayers.Remove(leave.Id);
            }

            leave.BeSeeUnits.Remove(self.Id);
            if (self.IsPlayer())
            {
                leave.BeSeePlayers.Remove(self.Id);
            }

            if (self.IsPlayer() || leave.IsPlayer())
            {
                EventSystem.Instance.Publish(self.Root(), new SceneUnitLeaveSightRange { A = self, B = leave });
            }
        }

        /// <summary>
        /// 是否在Unit视野范围内
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static bool IsBeSee(this SceneAOIEntity self, long unitId)
        {
            return self.BeSeePlayers.ContainsKey(unitId);
        }
    }
}