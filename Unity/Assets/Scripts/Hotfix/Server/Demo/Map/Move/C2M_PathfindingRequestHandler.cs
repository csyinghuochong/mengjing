
using System;

namespace ET.Server
{
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_PathfindingRequestHandler : MessageLocationHandler<Unit, C2M_PathfindingRequest>
	{

		protected override async ETTask Run(Unit unit, C2M_PathfindingRequest message)
		{
			unit.FindPathMoveToAsync(message.Position).Coroutine();
			
			await ETTask.CompletedTask;
		}
	}
}