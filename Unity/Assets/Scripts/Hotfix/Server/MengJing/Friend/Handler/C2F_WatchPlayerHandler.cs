using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(NumericComponentS))]
    public class C2F_WatchPlayerHandler : MessageHandler<Scene, C2F_WatchPlayerRequest, F2C_WatchPlayerResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_WatchPlayerRequest request, F2C_WatchPlayerResponse response)
        {
            UserInfoComponentS userinfo = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), request.UserId);
            if (userinfo == null)
            {
                response.Error = ErrorCode.ERR_Error;
                return;
            }
            //根据类型返回不同的值
            switch (request.WatchType) 
            {
                //全部
                case 0:
                    response.Lv = userinfo.UserInfo.Lv;
                    response.Name = userinfo.UserInfo.Name;
                    BagComponentS bagComponents = await UnitCacheHelper.GetComponentCache<BagComponentS>(scene.Root(), request.UserId);
                    if (bagComponents == null)
                    {
                        response.Error = ErrorCode.ERR_Error;
                        return;
                    }

                    response.EquipList = bagComponents.EquipList;
                    response.PetHeXinList = bagComponents.PetHeXinList;
                    response.Occ = userinfo.UserInfo.Occ;
                   
                    PetComponentS petComponent = await UnitCacheHelper.GetComponentCache<PetComponentS>(scene.Root(), request.UserId);
                    response.RolePetInfos = petComponent.RolePetInfos;
                    response.PetSkinList = petComponent.PetSkinList;
                    
                    NumericComponentS numericComponent =  await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), request.UserId);
                    foreach ((int key, long value) in numericComponent.NumericDic)
                    {
                        if (key >= (int)NumericType.Max)
                        {
                            continue;
                        }
                        response.Ks.Add(key);
                        response.Vs.Add(value);
                    }
                    
                    response.FashionIds = bagComponents.FashionEquipList;
                    break;
                //只返回名字
                case 1:
                    response.Name = userinfo.UserInfo.Name;
                    break;
                case 2:
                    ActorId teamServerId = UnitCacheHelper.GetTeamServerId(scene.Zone());
                    T2C_GetTeamInfoResponse g_SendChatRequest1 = (T2C_GetTeamInfoResponse)await scene.Root().GetComponent<MessageSender>().Call
                        (teamServerId, new C2T_GetTeamInfoRequest() { UserID = request.UserId });

                    response.TeamId = g_SendChatRequest1.TeamInfo != null ? g_SendChatRequest1.TeamInfo.TeamId : 0;
                    break;
                default:
                    break;
            }

        }
    }
}
