using System;
using System.Collections.Generic;

namespace ET.Server
{
	[FriendOf(typeof(UserInfoComponentS))]
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
			gateMapComponent.Scene =  GateMapFactory.Create(gateMapComponent, player.Id, IdGenerater.Instance.GenerateInstanceId(), "GateMap");

			Scene scene = gateMapComponent.Scene;
			
            player.UnitId = request.UnitId;
            player.ActivityServerId = UnitCacheHelper.GetActivityServerId(session.Zone());
            player.FriendServerId = UnitCacheHelper.GetFriendServerId(session.Zone());
            player.MailServerID = UnitCacheHelper.GetMailServerId(session.Zone());
            player.RankServerID = UnitCacheHelper.GetRankServerId(session.Zone());
            player.PaiMaiServerID =  UnitCacheHelper.GetPaiMaiServerId(session.Zone());
            player.UnionServerID = UnitCacheHelper.GetUnionServerId(session.Zone());
            
            Unit unit = await UnitHelper.LoadUnit(player, scene, createRoleInfo, newAccountList[0].Account, request.AccountId); 
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "Map101");
			response.MyId = request.UnitId;
			unit.GateSessionActorId = player.Id;
			Log.Debug($"M2M_UnitTransferRequest_a:{unit.Components.Count}");
			player.ChatInfoInstanceId = await EnterWorldChatServer(unit);   //登录聊天服
			Log.Debug($"M2M_UnitTransferRequest_b:{unit.Components.Count}");
			// 等到一帧的最后面再传送，先让G2C_EnterMap返回，否则传送消息可能比G2C_EnterMap还早
			unit.GetComponent<UserInfoComponentS>().OnLogin(session.RemoteAddress.ToString(), "");
			
			TransferHelper.TransferAtFrameFinish(unit, startSceneConfig.ActorId, startSceneConfig.Name).Coroutine();
		}
		
		private async ETTask<long> EnterWorldChatServer(Unit unit)
		{
			ActorId chatServerId = UnitCacheHelper.GetChatId(unit.Zone());
			Chat2G_EnterChat chat2G_EnterChat = (Chat2G_EnterChat)await unit.Root().GetComponent<MessageSender>().Call(chatServerId, new G2Chat_EnterChat()
			{ 
				UnitId = unit.Id,
				Name = unit.GetComponent<UserInfoComponentS>().UserInfo.Name,
				UnionId = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0),
				GateSessionActorId = unit.GateSessionActorId
			});
			return chat2G_EnterChat.ChatInfoUnitInstanceId;
		}
	}
}