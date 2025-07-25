using System;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof (UserInfoComponentS))]
    [FriendOf(typeof (Unit))]
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_EnterGameHandler: MessageSessionHandler<C2G_EnterGame, G2C_EnterGame>
    {
        protected override async ETTask Run(Session session, C2G_EnterGame request, G2C_EnterGame response)
        {
            
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                return;
            }
            if (session.Root().SceneType != SceneType.Gate)
            {
                Log.Error($"LoginTest C2G_EnterMapHandler请求的Scene错误，当前Scene为：{session.Root().SceneType}");
                session.Dispose();
                return;
            }

            SessionPlayerComponent sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
            if (null == sessionPlayerComponent)
            {
                response.Error = ErrorCode.ERR_SessionPlayerError;
                return;
            }

            Player player = sessionPlayerComponent.Player;

            if (player == null )
            {
                Console.WriteLine($"C2G_EnterGame: player == null  {request.UnitId}  {session.Id}");
                response.Error = ErrorCode.ERR_NonePlayerError;
                return;
            }
            if ( player.IsDisposed)
            {
                Console.WriteLine($"C2G_EnterGame: player.IsDisposed  {request.UnitId}  {session.Id}");
                response.Error = ErrorCode.ERR_NonePlayerError;
                return;
            }

            CoroutineLockComponent coroutineLockComponent = session.Root().GetComponent<CoroutineLockComponent>();
            long instanceId = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await coroutineLockComponent.Wait(CoroutineLockType.LoginGate, player.Account.GetLongHashCode()))
                {
                    if (instanceId != session.InstanceId || player.IsDisposed)
                    {
                        response.Error = ErrorCode.ERR_PlayerSessionError;
                        return;
                    }

                    if (player.PlayerState == PlayerState.Game && request.ReLink == 0)
                    {
                        Console.WriteLine($"G2M_RequestExitGame:  {player.Id} ");
                        var m2GRequestExitGame = (M2G_RequestExitGame)await player.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(player.UnitId, G2M_RequestExitGame.Create());
                        player.RemoveComponent<GateMapComponent>();
                        player.PlayerState = PlayerState.Gate;
                    }
                    if (player.PlayerState == PlayerState.Game&& request.ReLink > 0)
                    {
                        try
                        {
                            G2M_SecondLogin g2MSecondLogin = G2M_SecondLogin.Create();
                            M2G_SecondLogin reqEnter = await session.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(player.UnitId, g2MSecondLogin) as M2G_SecondLogin;
                            if (reqEnter.Error == ErrorCode.ERR_Success)
                            {
                                Console.WriteLine($"二次登陆逻辑，补全下发切换场景消息:{request.UnitId}");
                                G2C_SecondLogin g2CSecondLogin = G2C_SecondLogin.Create();
                                g2CSecondLogin.SceneType = reqEnter.SceneType;
                                g2CSecondLogin.SceneId = reqEnter.SceneId;
                                session.Send(g2CSecondLogin);
                                return;
                            }

                            Log.Error("二次登录失败  " + reqEnter.Error + " | " + reqEnter.Message);
                            Console.WriteLine("二次登录失败  " + reqEnter.Error + " | " + reqEnter.Message);
                            response.Error = ErrorCode.ERR_ReEnterGameError;
                            await DisconnectHelper.KickPlayerNoLock(player, 1);
                            session.Disconnect().Coroutine();
                        }
                        catch (Exception e)
                        {
                            Log.Error("二次登录失败  " + e);
                            response.Error = ErrorCode.ERR_ReEnterGameError2;
                            await DisconnectHelper.KickPlayerNoLock(player, 2);
                            session.Disconnect().Coroutine();
                        }

                        return;
                    }

                    try
                    {
                        DBComponent dbComponent = session.Root().GetComponent<DBManagerComponent>().GetZoneDB(CommonHelp.GetCenterZone());
                        List<DBCenterAccountInfo> newAccountList = await dbComponent.Query<DBCenterAccountInfo>(CommonHelp.GetCenterZone(), d => d.Id == request.AccountId); 
                        if (newAccountList == null || newAccountList.Count == 0)
                        {
                            response.Error = ErrorCode.ERR_NotFindAccount;
                            return;
                        }

                        CreateRoleInfo createRoleInfo = newAccountList[0].GetRoleInfo(session.Zone(), request.UnitId);
                        if (createRoleInfo == null)
                        {
                            response.Error = ErrorCode.ERR_NotFindAccount;
                            return;
                        }

                        // 在Gate上动态创建一个Map Scene，把Unit从DB中加载放进来，然后传送到真正的Map中，这样登陆跟传送的逻辑就完全一样了
                        GateMapComponent gateMapComponent = player.AddComponent<GateMapComponent>();
                        gateMapComponent.Scene =
                                GateMapFactory.Create(gateMapComponent, player.Id, IdGenerater.Instance.GenerateInstanceId(), "GateMap");

                        Scene scene = gateMapComponent.Scene;

                        player.UnitId = request.UnitId;
                        player.ActivityServerId = UnitCacheHelper.GetActivityServerId(session.Zone());
                        player.FriendServerId = UnitCacheHelper.GetFriendServerId(session.Zone());
                        player.MailServerID = UnitCacheHelper.GetMailServerId(session.Zone());
                        player.RankServerID = UnitCacheHelper.GetRankServerId(session.Zone());
                        player.PaiMaiServerID = UnitCacheHelper.GetPaiMaiServerId(session.Zone());
                        player.UnionServerID = UnitCacheHelper.GetUnionServerId(session.Zone());
                        player.SoloServerID = UnitCacheHelper.GetSoloServerId(session.Zone());
                        player.PetMatchServerID = UnitCacheHelper.GetPetMatchServerId(session.Zone());
                        player.PopularizeServerID = UnitCacheHelper.GetPopularizeServerId(session.Zone());
                        player.TeamServerID = UnitCacheHelper.GetTeamServerId(session.Zone());
                        player.PlayerState = PlayerState.Game;
                        Unit unit = await UnitFactory.LoadUnit(player, scene, createRoleInfo, newAccountList[0].Account, request.AccountId);
                        StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "Map101");
                        response.MyId = request.UnitId;
 
                        player.ChatInfoInstanceId = await EnterWorldChatServer(unit); //登录聊天服
                        // 等到一帧的最后面再传送，先让G2C_EnterMap返回，否则传送消息可能比G2C_EnterMap还早

                        unit.GetComponent<ChengJiuComponentS>().CheckData();
                        Function_Fight.UnitUpdateProperty_Base(unit,false, false);
                        unit.OnLogin(session.RemoteAddress.ToString(), "");

                        TransferHelper.TransferAtFrameFinish(unit, startSceneConfig.ActorId, startSceneConfig.Name).Coroutine();

                        player.PlayerState = PlayerState.Game;
                    }
                    catch (Exception e)
                    {
                        Log.Error($"角色进入游戏逻辑服出现问题 账号Id: {player.Account}  角色Id: {player.Id}   异常信息： {e}");
                        response.Error = ErrorCode.ERR_EnterGameError;
                        await DisconnectHelper.KickPlayerNoLock(player, 3);
                        session.Disconnect().Coroutine();
                    }
                }
            }
        }

        private async ETTask<long> EnterWorldChatServer(Unit unit)
        {
            ActorId chatServerId = UnitCacheHelper.GetChatId(unit.Zone());
            G2Chat_EnterChat g2ChatEnterChat = G2Chat_EnterChat.Create(); 
            g2ChatEnterChat.UnitId = unit.Id;
            g2ChatEnterChat.Name = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
            g2ChatEnterChat.UnionId = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
            g2ChatEnterChat.GateSessionActorId = unit.Id;
            Chat2G_EnterChat chat2G_EnterChat = (Chat2G_EnterChat)await unit.Root().GetComponent<MessageSender>().Call(chatServerId,
                g2ChatEnterChat);
            return chat2G_EnterChat.ChatInfoUnitInstanceId;
        }
    }
}