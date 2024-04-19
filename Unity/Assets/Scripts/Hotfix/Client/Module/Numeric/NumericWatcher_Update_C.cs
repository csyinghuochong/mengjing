namespace ET.Client
{
    
    [NumericWatcher(SceneType.Current, NumericType.Now_Hp)]
    public class NumericWatcher_Update_Now_Hp: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (unit == null || unit.IsDisposed)
            {
                Log.Debug("NumericType.Now_Hp == null");
            }
            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
            NumericComponentC numericComponentDefend = unit.GetComponent<NumericComponentC>();
            
            long nowHpValue = numericComponentDefend.GetAsLong(NumericType.Now_Hp);
            long costHp = (nowHpValue - args.OldValue);
            EventSystem.Instance.Publish( unit.Root(), new Now_Hp_Update()
            {
                Defend = unit,
                ChangeHpValue = costHp,
                DamgeType = args.DamgeType,
                SkillID = args.SkillId,
                Attack = args.Attack
            });
        }
    }
    
    
}