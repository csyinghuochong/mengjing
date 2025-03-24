namespace ET.Server
{
    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(NumericComponentS))]
    public class C2F_WatchPlayerHandler : MessageHandler<Scene, C2F_WatchPlayerRequest, F2C_WatchPlayerResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_WatchPlayerRequest request, F2C_WatchPlayerResponse response)
        {
            UserInfoComponentS userInfoComponentS = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), request.UserId);
            UserInfo unionInfoCache = userInfoComponentS.ChildrenDB[0] as UserInfo;
            if (userInfoComponentS == null)
            {
                response.Error = ErrorCode.ERR_Error;
                return;
            }

            //根据类型返回不同的值
            switch (request.WatchType)
            {
                //全部
                case 0:
                    response.Lv = unionInfoCache.Lv;
                    response.Name = unionInfoCache.Name;
                    BagComponentS bagComponents = await UnitCacheHelper.GetComponentCache<BagComponentS>(scene.Root(), request.UserId);
                    if (bagComponents == null)
                    {
                        response.Error = ErrorCode.ERR_Error;
                        return;
                    }

                    PetComponentS petComponent = await UnitCacheHelper.GetComponentCache<PetComponentS>(scene.Root(), request.UserId);
                    NumericComponentS numericComponent = await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), request.UserId);
                    foreach ((int key, long value) in numericComponent.NumericDic)
                    {
                        if (key >= (int)NumericType.Max)
                        {
                            continue;
                        }

                        response.Ks.Add(key);
                        response.Vs.Add(value);
                    }

                    bagComponents.DeserializeDB();
                    foreach (ItemInfo itemInfo in bagComponents.GetItemByLoc(ItemLocType.ItemLocEquip))  
                    {
                        response.EquipList.Add(itemInfo.ToMessage());
                    }

                    foreach (ItemInfo itemInfo in bagComponents.GetItemByLoc(ItemLocType.ItemPetHeXinEquip))
                    {
                        response.PetHeXinList.Add(itemInfo.ToMessage());
                    }
                    
                    response.Occ = unionInfoCache.Occ;
                    response.RolePetInfos.AddRange(petComponent.RolePetInfos);
                    response.PetSkinList.AddRange(petComponent.PetSkinList);
                    response.FashionIds.AddRange(bagComponents.FashionEquipList);
                    break;
                //只返回名字
                case 1:
                    response.Name = unionInfoCache.Name;
                    break;
                case 2:
                    ActorId teamServerId = UnitCacheHelper.GetTeamServerId(scene.Zone());
                    C2T_GetTeamInfoRequest C2T_GetTeamInfoRequest = C2T_GetTeamInfoRequest.Create();
                    C2T_GetTeamInfoRequest.UserID = request.UserId;
                    T2C_GetTeamInfoResponse g_SendChatRequest1 =
                            (T2C_GetTeamInfoResponse)await scene.Root().GetComponent<MessageSender>().Call(teamServerId, C2T_GetTeamInfoRequest);

                    response.TeamId = g_SendChatRequest1.TeamInfo != null ? g_SendChatRequest1.TeamInfo.TeamId : 0;
                    break;
                default:
                    break;
            }
        }
    }
}