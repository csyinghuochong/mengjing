namespace ET.Client
{
    [NumericWatcher(SceneType.Demo, NumericType.Now_Dead)]
    public class NumericWatcher_Now_Dead: INumericWatcher
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