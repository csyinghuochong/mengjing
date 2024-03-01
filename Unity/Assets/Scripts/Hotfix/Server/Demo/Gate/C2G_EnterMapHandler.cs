using System;
using System.Collections.Generic;

namespace ET.Server
{
	[FriendOf(typeof(Unit))]
	[FriendOf(typeof(DBAccountInfo))]
	[MessageSessionHandler(SceneType.Gate)]
	public class C2G_EnterMapHandler : MessageSessionHandler<C2G_EnterMap, G2C_EnterMap>
	{
		protected override async ETTask Run(Session session, C2G_EnterMap request, G2C_EnterMap response)
		{
			DBComponent dbComponent = session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone());
			List<DBAccountInfo> newAccountList = await dbComponent.Query<DBAccountInfo>(session.Zone(), d => d.Id == request.AccountId);

			if (newAccountList == null || newAccountList.Count == 0)
			{
				response.Error = ErrorCode.ERR_NotFindAccount;
				return;
			}

			CreateRoleInfo createRoleInfo = null;
			for (int i = 0; i < newAccountList[0].RoleList.Count; i++)
			{
				if (newAccountList[0].RoleList[i].UnitId == request.UnitId)
				{
					createRoleInfo = newAccountList[0].RoleList[i];
					break;
				}
			}

			if (createRoleInfo == null)
			{
				response.Error = ErrorCode.ERR_NotFindAccount;
				return;
			}

			Player player = session.GetComponent<SessionPlayerComponent>().Player;
			
            // 在Gate上动态创建一个Map Scene，把Unit从DB中加载放进来，然后传送到真正的Map中，这样登陆跟传送的逻辑就完全一样了
            GateMapComponent gateMapComponent = player.AddComponent<GateMapComponent>();
			gateMapComponent.Scene = await GateMapFactory.Create(gateMapComponent, player.Id, IdGenerater.Instance.GenerateInstanceId(), "GateMap");

			Scene scene = gateMapComponent.Scene;

            // 这里可以从DB中加载Unit
            //Unit unit=  UnitFactory.Create(scene, player.Id, UnitType.Player);
            
            //测试，先写死
            player.UnitId = request.UnitId;
            player.ActivityServerId = UnitCacheHelper.GetActivityId(session.Zone());
            player.FriendServerId = UnitCacheHelper.GetFriendId(session.Zone());

            (bool isNewPlayer, Unit unit)  = await UnitHelper.LoadUnit(player, scene, createRoleInfo, newAccountList[0].Account, request.AccountId); 
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "Map1");
			response.MyId = request.UnitId;
			unit.GateSessionActorId = player.Id;

			// 等到一帧的最后面再传送，先让G2C_EnterMap返回，否则传送消息可能比G2C_EnterMap还早
			TransferHelper.TransferAtFrameFinish(unit, startSceneConfig.ActorId, startSceneConfig.Name).Coroutine();
		}
	}
}