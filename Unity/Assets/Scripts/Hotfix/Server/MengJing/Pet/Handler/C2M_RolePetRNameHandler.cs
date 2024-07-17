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
			M2C_PetDataUpdate M2C_PetDataUpdate = M2C_PetDataUpdate.Create();
			M2C_PetDataUpdate.UpdateType = (int)UserDataType.Name;
			M2C_PetDataUpdate.PetId = request.PetInfoId;
			M2C_PetDataUpdate.UpdateTypeValue = request.PetName;
			MapMessageHelper.SendToClient(unit, M2C_PetDataUpdate);

			M2C_PetDataBroadcast M2C_PetDataBroadcast = M2C_PetDataBroadcast.Create();
			M2C_PetDataBroadcast.UnitId = unit.Id;
			M2C_PetDataBroadcast.UpdateType = (int)UserDataType.Name;
			M2C_PetDataBroadcast.PetId = request.PetInfoId;
			M2C_PetDataBroadcast.UpdateTypeValue = request.PetName;
			MapMessageHelper.Broadcast(unit, M2C_PetDataBroadcast);
			await ETTask.CompletedTask;
		}
	}
}