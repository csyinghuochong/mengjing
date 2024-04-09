using System;

namespace ET.Server
{
    
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_RolePetRNameHandler : MessageLocationHandler<Unit, C2M_RolePetRName, M2C_RolePetRName>
	{
		protected override async ETTask Run(Unit unit, C2M_RolePetRName request, M2C_RolePetRName response)
		{
			//读取数据库
			RolePetInfo petinfo = unit.GetComponent<PetComponentS>().GetPetInfo(request.PetInfoId);
			if (petinfo==null)
			{
				return;
			}

			petinfo.PetName = request.PetName;

			//通知客户端
			MapMessageHelper.SendToClient(unit, new M2C_PetDataUpdate() { UpdateType = (int)UserDataType.Name, PetId = request.PetInfoId, UpdateTypeValue = request.PetName });
			MapMessageHelper.Broadcast(unit, new M2C_PetDataBroadcast() { UnitId = unit.Id, UpdateType = (int)UserDataType.Name, PetId = request.PetInfoId, UpdateTypeValue = request.PetName });
			await ETTask.CompletedTask;
		}
	}
}