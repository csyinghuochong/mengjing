
using System;

namespace ET.Server
{
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_PathfindingResultHandler : MessageLocationHandler<Unit, C2M_PathfindingResult>
	{

		protected override async ETTask Run(Unit unit, C2M_PathfindingResult message)
		{

			int petfightindex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);

			if (petfightindex == 0)
			{
				unit.FindPathMoveToAsync(message.Position).Coroutine();
			}
			else
			{
				PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
				if (petfightindex < 0 || petfightindex >= petComponentS.PetFightList.Count)
				{
					return;
				}

				RolePetInfo rolePetInfo = petComponentS.GetPetInfo(petComponentS.PetFightList[petfightindex]);
				Unit petunit = unit.GetParent<UnitComponent>().Get(rolePetInfo.Id);
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