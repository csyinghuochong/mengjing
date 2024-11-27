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

			if (!unit.MainHero || !message.YaoGan)
			{
				float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
				speed *= (message.SpeedRate * 0.01f);
				unit.GetComponent<MoveComponent>().MoveToAsync(message.Points, speed, 100, message.SpeedRate).Coroutine();
			}
			
			await ETTask.CompletedTask;
		}
	}
}
