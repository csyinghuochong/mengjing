using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    [EntitySystemOf(typeof(DragonChuansongComponent))]
    [FriendOf(typeof(DragonChuansongComponent))]
    public static partial class DragonChuansongComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.DragonChuansongComponent self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.DragonChuansongTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.DragonChuansongComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }
        
        [Invoke(TimerInvokeType.DragonChuansongTimer)]
        public class DragonChuansongTimer : ATimer<DragonChuansongComponent>
        {
            protected override void Run(DragonChuansongComponent self)
            {
                try
                {
                    self.Check();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        public static void Check(this DragonChuansongComponent self)
        {
            List<Unit> unitlist = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            if (unitlist.Count <= 0)
            {
                return;
            }

            Unit mainUnit = unitlist[0];
            bool allMonsterDead = FubenHelp.IsAllMonsterDead(self.Scene(), mainUnit);
            if (!allMonsterDead)
            {
                return;
            }

            bool allin = true;
            Unit chuansong = self.GetParent<Unit>();
            for (int i = 0; i < unitlist.Count; i++)
            {
                if (math.distance(chuansong.Position, unitlist[i].Position) > 1.5f)
                {
                    allin = false;
                    break;
                }
            }

            if (!allin)
            {
                return;
            }

            Scene scene = self.Scene();
            NumericComponentS numericComponentS = chuansong.GetComponent<NumericComponentS>();
            string paraminfo = $"{numericComponentS.GetAsInt(NumericType.CellIndex)}_{numericComponentS.GetAsInt(NumericType.DirectionType)}";
            
            UnitHelper.RemoveAllNoType(self.Scene(), new List<int>() { UnitType.Player, UnitType.Pet });

            DragonDungeonComponentS dragonDungeonComponentS = scene.GetComponent<DragonDungeonComponentS>();
            dragonDungeonComponentS.InitSonCell(paraminfo);

            //通知客户端切场景
            dragonDungeonComponentS.OnEnterSonCell(paraminfo);
        }
        
    }
}