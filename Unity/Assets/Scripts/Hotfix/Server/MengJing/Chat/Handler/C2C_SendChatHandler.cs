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
                    T2C_GetTeamInfoResponse g_SendChatRequest1 =
                            (T2C_GetTeamInfoResponse)await root.GetComponent<MessageSender>().Call(teamServerId,
                                new C2T_GetTeamInfoRequest() { UserID = request.ChatInfo.UserId });

                    ActorId gateServerId = UnitCacheHelper.GetGateServerId(chatInfoUnit.Zone());
                    G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = null;
                    if (g_SendChatRequest1.Error == 0 && g_SendChatRequest1.TeamInfo != null)
                    {
                        for (int i = 0; i < g_SendChatRequest1.TeamInfo.PlayerList.Count; i++)
                        {
                            g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await root.GetComponent<MessageSender>().Call(gateServerId,
                                new T2G_GateUnitInfoRequest() { UserID = g_SendChatRequest1.TeamInfo.PlayerList[i].UserID });
                    
                            if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                            {
                                messageLocationSenderComponent.Get(LocationType.GateSession).Send(g2M_UpdateUnitResponse.SessionInstanceId, m2C_SyncChatInfo);
                            }
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
                    gateServerId = StartSceneConfigCategory.Instance.GetBySceneName(chatInfoUnit.Zone(), "Gate1").ActorId;
                    G2T_GateUnitInfoResponse g2TGateUnitInfoResponse = (G2T_GateUnitInfoResponse)await root.GetComponent<MessageSender>().Call(
                        gateServerId,
                        new T2G_GateUnitInfoRequest() { UserID = request.ChatInfo.ParamId });
                    
                    //发给好友
                    if (g2TGateUnitInfoResponse.PlayerState == (int)PlayerState.Game && g2TGateUnitInfoResponse.SessionInstanceId > 0)
                    {
                        messageLocationSenderComponent.Get(LocationType.GateSession)
                                .Send(g2TGateUnitInfoResponse.SessionInstanceId, m2C_SyncChatInfo);
                    }
                    else
                    {
                        //存入到离线消息
                        DBFriendInfo dBFriendInfo = await UnitCacheHelper.GetComponent<DBFriendInfo>( chatInfoUnit.Root(),  request.ChatInfo.ParamId);
                        if (dBFriendInfo != null && dBFriendInfo.FriendChats.Count < 10)
                        {
                            dBFriendInfo.FriendChats.Add(request.ChatInfo);
                            UnitCacheHelper.SaveComponent(chatInfoUnit.Root(), request.ChatInfo.ParamId, dBFriendInfo).Coroutine();
                        }
                    }

                    //发给自己
                    g2TGateUnitInfoResponse = (G2T_GateUnitInfoResponse)await root.GetComponent<MessageSender>().Call(gateServerId,
                        new T2G_GateUnitInfoRequest() { UserID = request.ChatInfo.UserId });
                    messageLocationSenderComponent.Get(LocationType.GateSession).Send(g2TGateUnitInfoResponse.SessionInstanceId, m2C_SyncChatInfo);
                    break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}