namespace ET
{
	public interface INumericWatcher
	{
		void Run(Unit unit, NumbericChange args);
	}
	
	public struct NumbericChange
	{
		public Unit Unit;
		public int NumericType;
		public long Old;
		public long New;
	}

}
