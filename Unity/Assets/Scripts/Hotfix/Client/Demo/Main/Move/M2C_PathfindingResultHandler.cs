namespace ET.Client
{
	[MessageHandler(SceneType.Demo)]
	public class M2C_PathfindingResultHandler : MessageHandler<Scene, M2C_PathfindingResult>
	{
		protected override async ETTask Run(Scene root, M2C_PathfindingResult message)
		{
			Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.Id);
			if (unit == null)
			{
				return;
			}

			if (SettingData.ShowFindPath && unit.MainHero)
			{
				long number = TimeInfo.Instance.FrameIndex;
				string formattedNumber = number.ToString().PadLeft(10, '0');
				SettingData.FindPathLog.Add(formattedNumber + "   "  + "/t" +  message.ToString());
				SettingData.FindPathList.Add(number, message);
				Log.Debug($"FrameIndex.Add:    {number}");
			}

			
			float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
			await unit.GetComponent<MoveComponent>().MoveToAsync(message.Points, speed);
		}
	}
}
