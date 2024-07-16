using System;

namespace ET.Client
{
    [FriendOf(typeof(PlayerComponent))]
    public static class LoginHelper
    {
        
        public static async ETTask<R2C_ServerList> GetServerList(Scene root, int versionMode)
        {
            await ETTask.CompletedTask;
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();
            return await clientSenderCompnent.GetServerList(versionMode);
        }
        
        public static async ETTask Login(Scene root, string account, string password)
        {
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();
            //登陆成功之后才有session.  才能call
            await clientSenderCompnent.LoginAsync(account, password);
            await EventSystem.Instance.PublishAsync(root, new LoginFinish());
        }

        public static async ETTask LoginGameAsync(Scene root)
        {
            try
            {
                //请求游戏角色进入Map地图
                PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();

                ClientSenderCompnent clientSenderComponent = root.GetComponent<ClientSenderCompnent>();

                C2R_GetRealmKey c2RGetRealmKey = C2R_GetRealmKey.Create();
                c2RGetRealmKey.Token = playerComponent.Token;
                c2RGetRealmKey.Account = playerComponent.Account;
                c2RGetRealmKey.ServerId = playerComponent.ServerItem.ServerId;
                R2C_GetRealmKey r2CGetRealmKey = await clientSenderComponent.Call(c2RGetRealmKey) as R2C_GetRealmKey;

                if (r2CGetRealmKey.Error != ErrorCode.ERR_Success)
                {
                    Log.Error("获取RealmKey失败！");
                    return;
                }

                NetClient2Main_LoginGame netClient2MainLoginGame = await clientSenderComponent.LoginGameAsync(playerComponent.Account,
                    playerComponent.AccountId,
                    r2CGetRealmKey.Key,
                    playerComponent.CurrentRoleId,
                    r2CGetRealmKey.Address);
                if (netClient2MainLoginGame.Error != ErrorCode.ERR_Success)
                {
                    Log.Error($"进入游戏失败：{netClient2MainLoginGame.Error}");
                    return;
                }

                // 等待场景切换完成
                await root.GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();

                await UserInfoNetHelper.RequestUserInfoInit(root);
                await BagClientNetHelper.RequestBagInit(root);
                await PetNetHelper.RequestPetInfo(root);
                await TaskClientNetHelper.RequestTaskInit(root);
                await SkillNetHelper.RequestSkillSet(root);
                await FriendNetHelper.RequestFriendInfo(root);
                await ActivityNetHelper.RequestActivityInfo(root);
                await ChengJiuNetHelper.GetChengJiuList(root);

                Log.Debug("进入游戏成功！！！");

                EventSystem.Instance.Publish(root, new EnterMapFinish());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static async ETTask RequestCreateRole(Scene root, long accountId, int occ, string name)
        {
            Log.Debug("C2A_CreateRoleData.client0");
            PlayerComponent PlayerComponent = root.GetComponent<PlayerComponent>();
            C2R_CreateRoleData request = C2R_CreateRoleData.Create();
            request.AccountId = accountId;
            request.CreateOcc = occ;
            request.CreateName = name;
            request.ServerId = PlayerComponent.ServerItem.ServerId;

            R2C_CreateRoleData response = await root.GetComponent<ClientSenderCompnent>().Call(request) as R2C_CreateRoleData;
            PlayerComponent.CreateRoleList.Add(response.createRoleInfo);
        }

        public static async ETTask RequestDeleteRole(Scene root, long accountId, long userId, CreateRoleInfo createRoleInfo)
        {
            C2R_DeleteRoleData request = C2R_DeleteRoleData.Create();
            request.AccountId = accountId;
            request.UserId = userId;

            R2C_DeleteRoleData response = await root.GetComponent<ClientSenderCompnent>().Call(request) as R2C_DeleteRoleData;
            root.GetComponent<PlayerComponent>().CreateRoleList.Remove(createRoleInfo);
        }
    }
}