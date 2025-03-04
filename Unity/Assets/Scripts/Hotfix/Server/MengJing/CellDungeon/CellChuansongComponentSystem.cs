using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    [EntitySystemOf(typeof(CellChuansongComponent))]
    [FriendOf(typeof(CellChuansongComponent))]
    public static partial class CellChuansongComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.CellChuansongComponent self)
        {
            self.InitTime = TimeHelper.Second * 3;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.CellChuansongTimer, self);
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Server.CellChuansongComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        [Invoke(TimerInvokeType.CellChuansongTimer)]
        public class DragonChuansongTimer : ATimer<CellChuansongComponent>
        {
            protected override void Run(CellChuansongComponent self)
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

        public static void Check(this CellChuansongComponent self)
        {
            if (self.InitTime >= 0)
            {
                self.InitTime -= 1000;
                return; 
            }

            List<Unit> unitlist = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            if (unitlist.Count <= 0)
            {
                return;
            }

            Unit mainhero = unitlist[0];
           
            float3 vector3 = self.GetParent<Unit>().Position;
            float distance = PositionHelper.Distance2D(vector3, mainhero.Position);

            if (distance <= 1.5f && !self.EnterRange)
            {
                if (!self.Scene().GetComponent<CellDungeonComponentS>().IsAllMonsterDead())
                {
                    return;
                }

                self.EnterRange = true;
            }

            if (distance > 1.5f && self.EnterRange)
            {
                self.EnterRange = false;
            }

            if (!self.EnterRange)
            {
                return; 
            }
            
            Scene scene = self.Scene();
            NumericComponentS numericComponentS = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            string paraminfo = $"{numericComponentS.GetAsInt(NumericType.CellIndex)}_{numericComponentS.GetAsInt(NumericType.DirectionType)}";
            
            UnitHelper.RemoveAllNoType(self.Scene(), new List<int>() { UnitType.Player, UnitType.Pet });

            CellDungeonComponentS cellDungeonComponentS = scene.GetComponent<CellDungeonComponentS>();
            cellDungeonComponentS.InitSonCell(paraminfo);
            cellDungeonComponentS.OnEnterSonCell(paraminfo);
            
            //UnitHelper.RemoveAllNoSelf(mainhero);
            //TransferHelper.AfterTransfer(mainhero, SceneTypeEnum.CellDungeon);
        }
       
    }
}