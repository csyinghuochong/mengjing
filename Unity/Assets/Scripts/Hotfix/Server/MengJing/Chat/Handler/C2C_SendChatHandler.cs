using System;

namespace ET.Server
{
    [FriendOf(typeof (ChatSceneComponent))]
    [FriendOf(typeof (ChatInfoUnit))]
    [MessageHandler(SceneType.Chat)]
    public class C2C_SendChatHandler: MessageLocationHandler<ChatInfoUnit, C2C_SendChatRequest, C2C_SendChatResponse>
    {
        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, C2C_SendChatRequest request, C2C_SendChatResponse response)
        {
            Scene root = chatInfoUnit.Root();

            if (string.IsNullOrEmpty(request.ChatInfo.ChatMsg))
            {
                return;
            }

            long serverTime = TimeHelper.ServerNow();
            if (serverTime - chatInfoUnit.LastSendChat < TimeHelper.Second * 2)
            {
                response.Error = ErrorCode.ERR_OperationOften;
                return;
            }

            ChatSceneComponent chatInfoUnitsComponent = root.GetComponent<ChatSceneComponent>();
            MessageLocationSenderComponent messageLocationSenderComponent = root.GetComponent<MessageLocationSenderComponent>();

            
            C2C_SyncChatInfo m2C_SyncChatInfo = C2C_SyncChatInfo.Create();
            request.ChatInfo.Time = TimeHelper.ServerNow();
            m2C_SyncChatInfo.ChatInfo = request.ChatInfo;
            switch (request.ChatInfo.ChannelId)
            {
                case (int)ChannelEnum.PaiMai:
                case (int)ChannelEnum.Word:
                {
                   
                    foreach (var otherUnit in chatInfoUnitsComponent.ChatInfoUnitsDict.Values)
                    {
                        messageLocationSenderComponent.Get(LocationType.GateSession).Send(otherUnit.GateSessionActorId, m2C_SyncChatInfo);
                    }

                    if (request.ChatInfo.ChannelId == (int)ChannelEnum.Word)
                    {
                        chatInfoUnitsComponent.WordChatInfos.Add(request.ChatInfo);
                        if (chatInfoUnitsComponent.WordChatInfos.Count > 10)
                        {
                            chatInfoUnitsComponent.WordChatInfos.RemoveAt(chatInfoUnitsComponent.WordChatInfos.Count - 1);
                        }
                    }

                    if (chatInfoUnit.Zone() == 5)
                    {
                        bool havegm = false;
                        for (int i = 0; i < chatInfoUnitsComponent.WordChatInfos.Count; i++)
                        {
                            if (chatInfoUnitsComponent.WordChatInfos[i].ChatMsg.Contains("mail"))
                            {
                                havegm = true;
                                break;
                            }
                        }

                        if (havegm)
                        {
                            chatInfoUnitsComponent.WordChatInfos.Clear();
                        }
                    }

                    break;
                }
                case (int)ChannelEnum.Team:
                    ActorId teamServerId = StartSceneConfigCategory.Instance.GetBySceneName(chatInfoUnit.Zone(), "Team")
                            .ActorId;

                    C2T_GetTeamInfoRequest C2T_GetTeamInfoRequest = C2T_GetTeamInfoRequest.Create();
                    C2T_GetTeamInfoRequest.UserID = request.ChatInfo.UserId;
                    T2C_GetTeamInfoResponse g_SendChatRequest1 =
                            (T2C_GetTeamInfoResponse)await root.GetComponent<MessageSender>().Call(teamServerId,C2T_GetTeamInfoRequest );
                    if (g_SendChatRequest1.Error == 0 && g_SendChatRequest1.TeamInfo != null)
                    {
                        for (int i = 0; i < g_SendChatRequest1.TeamInfo.PlayerList.Count; i++)
                        {
                            messageLocationSenderComponent.Get(LocationType.GateSession).Send(g_SendChatRequest1.TeamInfo.PlayerList[i].UserID, m2C_SyncChatInfo);
                        }
                    }
                    break;
                case (int)ChannelEnum.Union:
                    long unionid = request.ChatInfo.ParamId;
                    if (unionid == 0)
                    {
                        response.Error = ErrorCode.ERR_Union_Not_Exist;
                        return;
                    }
                    
                    chatInfoUnitsComponent = chatInfoUnit.Root().GetComponent<ChatSceneComponent>();
                    foreach (var otherUnit in chatInfoUnitsComponent.ChatInfoUnitsDict.Values)
                    {
                        if (otherUnit.UnionId == unionid)
                        {
                            messageLocationSenderComponent.Get(LocationType.GateSession).Send(otherUnit.GateSessionActorId, m2C_SyncChatInfo);
                        }
                    }
                    break;
                case (int)ChannelEnum.Friend:
                {
                    G2M_SecondLogin g2MSecondLogin = G2M_SecondLogin.Create();
                    M2G_SecondLogin reqEnter = await chatInfoUnit.Root().GetComponent<MessageLocationSenderComponent>()
                            .Get(LocationType.Unit).Call(request.ChatInfo.ParamId, g2MSecondLogin) as M2G_SecondLogin;
                    if (reqEnter.Error == ErrorCode.ERR_Success)
                    {
                        //发给好友
                        Console.WriteLine("好友在线！！");
                        messageLocationSenderComponent.Get(LocationType.GateSession).Send( request.ChatInfo.ParamId, m2C_SyncChatInfo);
                    }
                    else
                    {
                        Console.WriteLine("好友不在线！！");
                        //存入到离线消息
                        DBFriendInfo dBFriendInfo = await UnitCacheHelper.GetComponent<DBFriendInfo>( chatInfoUnit.Root(),  request.ChatInfo.ParamId);
                        if (dBFriendInfo != null && dBFriendInfo.FriendChats.Count < 10)
                        {
                            dBFriendInfo.FriendChats.Add(request.ChatInfo);
                            UnitCacheHelper.SaveComponent(chatInfoUnit.Root(), request.ChatInfo.ParamId, dBFriendInfo).Coroutine();
                        }
                    }
                    
                    //发给自己
                    messageLocationSenderComponent.Get(LocationType.GateSession).Send(request.ChatInfo.UserId, m2C_SyncChatInfo);
                    break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}