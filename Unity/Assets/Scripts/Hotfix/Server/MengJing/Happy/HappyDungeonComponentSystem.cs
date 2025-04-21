using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (HappyDungeonComponent))]
    [FriendOf(typeof (HappyDungeonComponent))]
    public static partial class HappyDungeonComponentSystem
    {
        
        [Invoke(TimerInvokeType.HappyDungeonTimer)]
        public class HappyDungeonTimer: ATimer<HappyDungeonComponent>
        {
            protected override void Run(HappyDungeonComponent self)
            {
                try
                {
                    self.OnTimer();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
        
        [EntitySystem]
        private static void Awake(this HappyDungeonComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this HappyDungeonComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }
        
        public static void OnHappyBegin(this HappyDungeonComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(HappyData.ItemFreshTime, TimerInvokeType.HappyDungeonTimer, self);

            //先刷新一次
            self.OnTimer();
        }

        public static async ETTask OnHappyOver(this HappyDungeonComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            Scene fubnescene = self.Scene();
            C2M_TransferMap actor_Transfer = C2M_TransferMap.Create();
            actor_Transfer.SceneType = MapTypeEnum.MainCityScene;

            await self.Root().GetComponent<TimerComponent>().WaitAsync(TimeHelper.Minute);
            List<EntityRef<Unit>> units = fubnescene.GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.Type != UnitType.Player)
                {
                    continue;
                }

                if (unit.IsDisposed || unit.IsRobot())
                {
                    continue;
                }

                await TransferHelper.TransferUnit(units[i], actor_Transfer);
            }

            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(10000, 20000));
            TransferHelper.NoticeFubenCenter(fubnescene, 2).Coroutine();
            fubnescene.Dispose();
        }

        public static void OnTimer(this HappyDungeonComponent self)
        {
            List<int> dropcells = new List<int>();
            List<Unit> droplist = UnitHelper.GetUnitList(self.Scene(), UnitType.DropItem);
            for (int i = 0; i < droplist.Count; i++)
            {
                int dropindex = droplist[i].GetComponent<NumericComponentS>().GetAsInt(NumericType.CellIndex);
                if (!dropcells.Contains(dropindex))
                {
                    dropcells.Add(dropindex);
                }
            }

            int openDay = ServerHelper.GetServeOpenDay( self.Zone());
            int dropid =  CommonHelp.GetHappyDropId(openDay, 96);

            for (int p = 0; p < HappyData.PositionList.Count; p++)
            {
                //空格子的概率
                if (RandomHelper.RandFloat01() < 0.3f)
                {
                    continue;
                }

                //该格子有道具
                if (dropcells.Contains(p + 1))
                {
                    continue;
                }

                List<RewardItem> rewardist = new List<RewardItem>();
                DropHelper.DropIDToDropItem(dropid, rewardist);
                if (rewardist.Count > 100)
                {
                    Log.Error($"rewardist.Count > 100:   {dropid}");
                    break;
                }

                UnitComponent unitComponent = self.Scene().GetComponent<UnitComponent>();
                for (int i = 0; i < rewardist.Count; i++)
                {
                    if (!ItemConfigCategory.Instance.Contain(rewardist[i].ItemID))
                    {
                        rewardist[i].ItemID = 1;
                        rewardist[i].ItemNum = 1;
                    }

                    Unit dropitem = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1);
                    unitComponent.Add(dropitem);
                    dropitem.AddComponent<UnitInfoComponent>();
                    dropitem.Type = UnitType.DropItem;
                    dropitem.AddComponent<DropComponentS>();
                    NumericComponentS numericComponentS = dropitem.AddComponent<NumericComponentS>();
                    numericComponentS.ApplyValue(NumericType.DropItemId, rewardist[i].ItemID, false);
                    numericComponentS.ApplyValue(NumericType.DropItemNum, rewardist[i].ItemNum, false);
                    numericComponentS.ApplyValue(NumericType.CellIndex, p + 1, false);
                    numericComponentS.ApplyValue(NumericType.DropType, 0, false);

                    float3 vector3 = HappyData.PositionList[p];
                    dropitem.Position = vector3;
                    dropitem.AddComponent<AOIEntity, int, float3>(2 * 1000, dropitem.Position);
                    
                }
            }

            List<Unit> unitlist = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            self.M2C_HappyInfoResult.NextRefreshTime = TimeHelper.ServerNow() + HappyData.ItemFreshTime;
            MapMessageHelper.SendToClient(unitlist, self.M2C_HappyInfoResult);
        }

        public static void NoticeRefreshTime(this HappyDungeonComponent self, Unit unit)
        {
            MapMessageHelper.SendToClient(unit, self.M2C_HappyInfoResult);
        }
    }
}