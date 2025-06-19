using System;

namespace ET.Client
{
    [FriendOf(typeof(PlayerInfoComponent))]
    public static class LoginHelper
    {
        public static async ETTask<R2C_ServerList> GetServerList(Scene root, int versionMode)
        {
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();
            return await clientSenderCompnent.GetServerList(versionMode);
        }
        
        public static async ETTask<int> RealName(Scene root, string name, string idcard)
        {
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();
            PlayerInfoComponent playerInfoComponent = root.GetComponent<PlayerInfoComponent>();
            NetClient2Main_RealName netClient2MainRealName =   (NetClient2Main_RealName ) await clientSenderCompnent.RealNameAsync(playerInfoComponent.AccountId, name, idcard, playerInfoComponent.VersionMode);
            return netClient2MainRealName.Error;
        }
        
        /// <summary>
        /// 进入游戏后
        /// </summary>
        /// <param name="root"></param>
        /// <param name="name"></param>
        /// <param name="idcard"></param>
        /// <returns></returns>
        public static async ETTask<int> RealName_2(Scene root, string name, string idcard)
        {
            C2M_RealNameRequest request = C2M_RealNameRequest.Create();
            PlayerInfoComponent playerInfoComponent = root.GetComponent<PlayerInfoComponent>();
            request.Name = name;
            request.IdCardNO = idcard;
            request.AccountId = playerInfoComponent.AccountId;
            M2C_RealNameResponse response =  (M2C_RealNameResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == ErrorCode.ERR_Success && response.PlayerInfo != null)
            {
                playerInfoComponent.PlayerInfo = response.PlayerInfo;
           }
            return response.Error;
        }

        public static async ETTask<int> Login(Scene root, string account, string password, int reLink, int versionmode)
        {
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();
            
            int errCode =  await clientSenderCompnent.LoginAsync(account, password, reLink, versionmode);
            
            Log.Debug($"LoginAsync->{errCode}");
            if (errCode == ErrorCode.ERR_NotRealName)
            {
                EventSystem.Instance.Publish(root, new NotRealName() {   });
                return errCode;
            }

            if (errCode != ErrorCode.ERR_Success)
            {
                string errstr = string.Empty;
                ErrorViewData.ErrorHints.TryGetValue(errCode, out errstr);
                EventSystem.Instance.Publish(root, new CommonPopup() { HintText = $"无法进入游戏: {errstr}" });
                return errCode;
            }
            if (reLink == 0)
            {
                await EventSystem.Instance.PublishAsync(root, new LoginFinish());
            }
            return errCode;
        }

        public static async ETTask<int> LoginGameAsync(Scene root, int reLink)
        {
            try
            {
                //请求游戏角色进入Map地图
                PlayerInfoComponent playerInfoComponent = root.GetComponent<PlayerInfoComponent>();
                ClientSenderCompnent clientSenderComponent = root.GetComponent<ClientSenderCompnent>();
                C2R_GetRealmKey c2RGetRealmKey = C2R_GetRealmKey.Create();
                c2RGetRealmKey.Token = playerInfoComponent.Token;
                c2RGetRealmKey.Account = playerInfoComponent.Account;
                c2RGetRealmKey.ServerId = playerInfoComponent.ServerItem.ServerId;
                R2C_GetRealmKey r2CGetRealmKey = await clientSenderComponent.Call(c2RGetRealmKey) as R2C_GetRealmKey;

                if (r2CGetRealmKey.Error != ErrorCode.ERR_Success)
                {
                    Log.Error("获取RealmKey失败！");
                    return r2CGetRealmKey.Error;
                }

                NetClient2Main_LoginGame netClient2MainLoginGame = await clientSenderComponent.LoginGameAsync(playerInfoComponent.Account,
                    playerInfoComponent.AccountId,
                    r2CGetRealmKey.Key,
                    playerInfoComponent.CurrentRoleId,
                    r2CGetRealmKey.Address,
                    reLink);
                
                if (netClient2MainLoginGame.Error != ErrorCode.ERR_Success)
                {
                    Log.Error($"进入游戏失败：{netClient2MainLoginGame.Error}");
                    return netClient2MainLoginGame.Error;
                }
              
                if (reLink == 0)
                {
                    // 等待场景切换完成
                    await root.GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();

                    await UserInfoNetHelper.RequestUserInfoInit(root);
                    await BagClientNetHelper.RequestBagInit(root);
                    await PetNetHelper.RequestPetInfo(root);
                    await TaskClientNetHelper.RequestTaskInit(root);
                    await SkillNetHelper.RequestSkillSet(root);
                    await FriendNetHelper.RequestFriendInfo(root);
                    await ActivityNetHelper.RequestActivityInfo(root);
                    await ActivityNetHelper.RequestZhanQuInfo(root);
                    await ChengJiuNetHelper.GetChengJiuList(root);

                    EventSystem.Instance.Publish(root, new EnterMapFinish());
                }
                if (reLink != 0)
                {
                    //G2C_SecondLogin 处理
                    //断线重连 走一下登录流程 刷一下数据
                    Log.Debug($"LoginGameAsync..重连成功！！");
                }
                Log.Debug("进入游戏成功！！！");
                return ErrorCode.ERR_Success;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_Error;
            }
        }

        public static async ETTask<int> RequestCreateRole(Scene root, long accountId, int occ, string name)
        {
            PlayerInfoComponent playerInfoComponent = root.GetComponent<PlayerInfoComponent>();
            C2R_CreateRoleData request = C2R_CreateRoleData.Create();
            request.AccountId = accountId;
            request.CreateOcc = occ;
            request.CreateName = name;
            request.ServerId = playerInfoComponent.ServerItem.ServerId;

            R2C_CreateRoleData response = await root.GetComponent<ClientSenderCompnent>().Call(request) as R2C_CreateRoleData;
            if (response.Error == ErrorCode.ERR_Success)
            {
                playerInfoComponent.CreateRoleList.Add(response.createRoleInfo);
            }

            return response.Error;
        }

        public static async ETTask RequestDeleteRole(Scene root, long accountId, long userId, CreateRoleInfo createRoleInfo)
        {
            C2R_DeleteRoleData request = C2R_DeleteRoleData.Create();
            request.AccountId = accountId;
            request.UserId = userId;

            R2C_DeleteRoleData response = await root.GetComponent<ClientSenderCompnent>().Call(request) as R2C_DeleteRoleData;
            root.GetComponent<PlayerInfoComponent>().CreateRoleList.Remove(createRoleInfo);
        }
    }
}