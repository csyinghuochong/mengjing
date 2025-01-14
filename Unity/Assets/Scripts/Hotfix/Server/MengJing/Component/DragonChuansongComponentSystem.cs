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

        }
        
        [Invoke(TimerInvokeType.DragonChuansongTimer)]
        public class DragonChuansongTimer: ATimer<DragonChuansongComponent>
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
                if (math.distance( chuansong.Position, unitlist[i].Position ) > 1.5f)
                {
                    allin = false;
                    break;
                }
            }

            if (!allin)
            {
                return;
            }

            NumericComponentS numericComponentS = chuansong.GetComponent<NumericComponentS>();
            string paraminfo = $"{numericComponentS.GetAsInt(NumericType.CellIndex)}_{numericComponentS.GetAsInt(NumericType.DirectionType)}";
            self.Scene().GetComponent<DragonDungeonComponentS>().InitSonCell(paraminfo);
            
            //通知客户端切场景
        }
    }
}