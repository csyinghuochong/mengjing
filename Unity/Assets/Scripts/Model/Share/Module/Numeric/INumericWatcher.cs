namespace ET
{
	public interface INumericWatcher
	{
		void Run(Unit unit, NumbericChange args);
	}
	
	public struct NumbericChange
	{
		public Unit Defend;
		public long AttackId;
		public int NumericType;
		public long OldValue;
		public long NewValue;
		public int SkillId;
		public int DamgeType;           //1 暴击   2闪避
	}

}
