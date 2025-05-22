using System;

namespace ET.Client
{
    /// <summary>
    /// 逻辑public class NumericChangeEvent_NotifyWatcher: AEvent<Scene, NumbericChange>
    /// </summary>
    ///
    ///
    /// 
    [NumericWatcher(SceneType.Current, NumericType.Now_Dead)]
    public class NumericWatcher_Now_Dead : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (args.NewValue == 0) //复活
            {
                unit.Position = unit.GetBornPostion();
                EventSystem.Instance.Publish(args.Defend.Root(), new UnitRevive() { Unit = args.Defend });
            }

            if (args.NewValue == 1) //死亡
            {
                unit.GetComponent<HeroDataComponentC>().OnDead();
                EventSystem.Instance.Publish(args.Defend.Root(), new UnitDead() { Unit = args.Defend, Wait =  true});
            }
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.SoloRankId)]
    public class NumericWatcher_SoloRankId : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            // int no1_horse = 10009;
            //
            // if (args.Defend.MainHero)
            // {
            //     if (args.NewValue == 1) //排行第一
            //     {
            //         args.Defend.Root().GetComponent<UserInfoComponentC>().OnHorseActive(no1_horse, true);
            //     }
            //     else
            //     {
            //         args.Defend.Root().GetComponent<UserInfoComponentC>().OnHorseActive(no1_horse, false);
            //     }
            // }
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.CombatRankID)]
    public class NumericWatcher_CombatRankID : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            // int no1_horse = 10004;
            //
            // if (args.Defend.MainHero)
            // {
            //     if (args.NewValue == 1) //排行第一
            //     {
            //         args.Defend.Root().GetComponent<UserInfoComponentC>().OnHorseActive(no1_horse, true);
            //     }
            //     else
            //     {
            //         args.Defend.Root().GetComponent<UserInfoComponentC>().OnHorseActive(no1_horse, false);
            //     }
            // }
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.SeasonOpenTime)]
    public class NumericWatcher_SeasonOpenTime : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            Log.Debug($"NumericWatcher_SeasonOpenTime:  {args.NewValue}");

            if (args.NewValue == 0)
            {
                Scene root = unit.Root();
                root.GetComponent<UserInfoComponentC>().OnResetSeason(false);
                root.GetComponent<BagComponentC>().OnResetSeason(false);
                root.GetComponent<TaskComponentC>().OnResetSeason(false);
            }
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.Now_Speed)]
    public class NumericWatcher_Now_Speed : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            float speed = args.Defend.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            args.Defend.GetComponent<MoveComponent>().ChangeSpeed(speed);
        }
    }

}