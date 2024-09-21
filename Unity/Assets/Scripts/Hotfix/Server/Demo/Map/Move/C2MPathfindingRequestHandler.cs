
using System;

namespace ET.Server
{
	[MessageLocationHandler(SceneType.Map)]
	public class C2MPathfindingRequestHandler : MessageLocationHandler<Unit, C2M_PathfindingRequest>
	{

		protected override async ETTask Run(Unit unit, C2M_PathfindingRequest message)
		{

			int petfightindex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);

			if (petfightindex == 0)
			{
				unit.FindPathMoveToAsync(message.Position).Coroutine();
			}
			else
			{
				PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
				Unit petunit = petComponentS.GetFightPetByIndex(petfightindex);
				if (petunit == null)
				{
					return;
				}

				petunit.FindPathMoveToAsync(message.Position).Coroutine();
			}
			
			await ETTask.CompletedTask;
		}
	}
}