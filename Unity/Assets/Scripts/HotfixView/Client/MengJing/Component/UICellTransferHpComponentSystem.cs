using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UICellTransferHpComponent))]
    [FriendOf(typeof(UICellTransferHpComponent))]
    public static partial class UICellTransferHpComponentSystem
    {
        [Invoke(TimerInvokeType.CellTransferUITimer)]
        public class CellTransferUITimer : ATimer<UICellTransferHpComponent>
        {
            protected override void Run(UICellTransferHpComponent self)
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
        private static void Awake(this UICellTransferHpComponent self)
        {
            self.EnterRange = false;
            self.InitTime = TimeHelper.ServerNow() + TimeHelper.Second * 3;
        }

        [EntitySystem]
        private static void Destroy(this UICellTransferHpComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        //chuansongComponent.CellIndex, chuansongComponent.DirectionType
        public static  void OnInitUI(this UICellTransferHpComponent self, int sceneType)
        {
            self.SceneType = sceneType;
        }

        public static void OnTimer(this UICellTransferHpComponent self)
        {
            if (!self.EnterRange)
            {
                return;
            }
            MoveHelper.Stop(self.Root());
            
            Unit mainhero = UnitHelper.GetMyUnitFromClientScene(self.Root());
            mainhero.GetComponent<StateComponentC>().StateTypeAdd(StateTypeEnum.NoMove);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_JoystickMove.ResetJoystick();
            Unit unit = self.GetParent<Unit>();
            MapComponent mapComponent = self.Root().GetComponent <MapComponent> ();
            EnterMapHelper.RequestTransfer(self.Root(), mapComponent.MapType, 0, mapComponent.FubenDifficulty,
                        $"{unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.CellIndex)}_{unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DirectionType)}")
                    .Coroutine();
        }

        public static void StartTimer(this UICellTransferHpComponent self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.Timer);
            long leftTime = self.InitTime - TimeHelper.ServerNow();
            leftTime = Math.Max(10, leftTime);
            self.Timer = timerComponent.NewOnceTimer(TimeHelper.ServerNow() + leftTime, TimerInvokeType.CellTransferUITimer, self);
        }

        public static void  OnCheckChuanSong(this UICellTransferHpComponent self, Unit mainhero)
        {
            Vector3 vector3 = self.GetParent<Unit>().Position;
            float distance = PositionHelper.Distance2D(vector3, mainhero.Position);

            long leftTime = self.InitTime - TimeHelper.ServerNow();
            if (leftTime > 0)
            {
                return;
            }

            if (distance <= 1.5f && !self.EnterRange)
            {
                self.EnterRange = true;
                if (!UnitHelper.IsAllMonsterDead(self.Root().CurrentScene()))
                {
                    FlyTipComponent.Instance.ShowFlyTip("消灭怪物后才可进行传送");
                    return;
                }

                //self.EnterRange = true;
                // if (self.SceneType == SceneTypeEnum.CellDungeon)
                // {
                //     self.StartTimer();
                // }
            }

            if (distance > 1.5f && self.EnterRange)
            {
                self.EnterRange = false;
            }
        }
    }
}