using System;

namespace ET.Client
{
    [NumericWatcher(SceneType.Current, NumericType.Now_Hp)]
    public class NumericWatcher_Update_Now_Hp : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (unit == null || unit.IsDisposed)
            {
                Log.Debug("NumericType.Now_Hp == null");
            }

            NumericComponentC numericComponentDefend = unit.GetComponent<NumericComponentC>();

            long nowHpValue = numericComponentDefend.GetAsLong(NumericType.Now_Hp);
            long costHp = (nowHpValue - args.OldValue);
            EventSystem.Instance.Publish(unit.Root(), new Now_Hp_Update()
            {
                Defend = unit,
                ChangeHpValue = costHp,
                DamgeType = args.DamgeType,
                SkillID = args.SkillId,
                Attack = args.Attack
            });
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.Now_Dead)]
    public class NumericWatcher_Now_Dead : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (args.NewValue == 0) //复活
            {
                unit.Position = unit.GetBornPostion();
                EventSystem.Instance.Publish(unit.Root(), new UnitRevive() { Unit = unit });
            }

            if (args.NewValue == 1) //死亡
            {
                unit.GetComponent<HeroDataComponentC>().OnDead(args.Attack);
                EventSystem.Instance.Publish(unit.Root(), new UnitDead() { Unit = unit });
            }
        }
    }
}