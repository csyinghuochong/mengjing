
using System;

namespace ET.Server
{
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_PathfindingRequestHandler : MessageLocationHandler<Unit, C2M_PathfindingRequest>
	{

		protected override async ETTask Run(Unit unit, C2M_PathfindingRequest message)
		{
			
			SkillManagerComponentS skillManagerComponent = unit.GetComponent<SkillManagerComponentS>();
			if (skillManagerComponent.HaveChongJi())
			{
				return;
			}
			
			MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
			if (mapComponent.MapType == MapTypeEnum.Happy
			    || mapComponent.MapType == MapTypeEnum.PetTianTi
			    || mapComponent.MapType == MapTypeEnum.PetDungeon
			    || mapComponent.MapType == MapTypeEnum.PetMing
			    || mapComponent.MapType == MapTypeEnum.PetMelee
			    || mapComponent.MapType == MapTypeEnum.PetMatch)
			{
				return;
			}
			if (mapComponent.MapType == MapTypeEnum.LocalDungeon)
			{
				if (DungeonConfigCategory.Instance.Get(mapComponent.SceneId).MapType == SceneSubTypeEnum.LocalDungeon_1)
				{
					return;
				}
			}
            
			unit.GetComponent<SkillPassiveComponent>().OnPlayerMove();
			unit.GetComponent<BuffManagerComponentS>().BuffRemoveType(1);
			unit.FindPathMoveToAsync(message.Position).Coroutine();

			await ETTask.CompletedTask;
		}
	}
}