using System;

namespace ET.Client
{
    public struct CommonHintError 
    {
        public int ErrorValue;
    }
    
    [EntitySystemOf(typeof(ClientSenderCompnent))]
    [FriendOf(typeof(ClientSenderCompnent))]
    [FriendOf(typeof(PlayerInfoComponent))]
    public static partial class ClientSenderCompnentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientSenderCompnent self)
        {

        }
        
        [EntitySystem]
        private static void Destroy(this ClientSenderCompnent self)
        {
            self.RemoveFiberAsync().Coroutine();
        }

        private static async ETTask RemoveFiberAsync(this ClientSenderCompnent self)
        {
            if (self.fiberId == 0)
            {
                return;
            }

            int fiberId = self.fiberId;
            self.fiberId = 0;
            await FiberManager.Instance.Remove(fiberId);
        }
        
        public static async ETTask<R2C_ServerList> GetServerList(this ClientSenderCompnent self, int versionMode)
        {
            self.fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, 0, SceneType.NetClient, "");
            self.netClientActorId = new ActorId(self.Fiber().Process, self.fiberId);  // this.Root = new Scene(this, id, 1, sceneType, name); / this.InstanceId = 1;

            Main2NetClient_ServerList main2NetClientServerList = Main2NetClient_ServerList.Create();
            main2NetClientServerList.OwnerFiberId = self.Fiber().Id;
            main2NetClientServerList.VersionMode = versionMode;
            NetClient2Main_ServerList respone = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, main2NetClientServerList) as NetClient2Main_ServerList;
            R2C_ServerList r2CServerList = R2C_ServerList.Create();
            r2CServerList.ServerItems = respone.ServerItems;
            r2CServerList.NoticeText = respone.NoticeText;
            r2CServerList.NoticeText = respone.NoticeText;
            return r2CServerList;
        }
        
        public static async ETTask<NetClient2Main_RealName> RealNameAsync(this ClientSenderCompnent self, long accountId,string name,  string idcard, int versionmode)
        {
            self.fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, 0, SceneType.NetClient, "");
            self.netClientActorId = new ActorId(self.Fiber().Process, self.fiberId);  // this.Root = new Scene(this, id, 1, sceneType, name); / this.InstanceId = 1;

            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            Main2NetClient_RealName main2NetClientRealName = Main2NetClient_RealName.Create();
            main2NetClientRealName.Account = playerInfoComponent.Account;
            main2NetClientRealName.Password = playerInfoComponent.Password;
            main2NetClientRealName.AccountId = accountId;
            main2NetClientRealName.IdCardNO = idcard;
            main2NetClientRealName.Name = name;
            main2NetClientRealName.VersionMode = versionmode;

            NetClient2Main_RealName netClient2MainRealName = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, main2NetClientRealName) as NetClient2Main_RealName;
            if (netClient2MainRealName.Error == ErrorCode.ERR_Success && netClient2MainRealName.PlayerInfo != null)
            {
                playerInfoComponent.PlayerInfo = netClient2MainRealName.PlayerInfo;
            }

            return netClient2MainRealName;
        }

        public static async ETTask<int> LoginAsync(this ClientSenderCompnent self, string account, string password, int relink, int versionmode)
        {
            self.fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, 0, SceneType.NetClient, "");
            self.netClientActorId = new ActorId(self.Fiber().Process, self.fiberId);  // this.Root = new Scene(this, id, 1, sceneType, name); / this.InstanceId = 1;
            
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            Main2NetClient_Login main2NetClientLogin = Main2NetClient_Login.Create();
            main2NetClientLogin.OwnerFiberId = self.Fiber().Id;
            main2NetClientLogin.Account      = account;
            main2NetClientLogin.Password     = password;
            main2NetClientLogin.Relink       = relink;
            main2NetClientLogin.ServerId     = playerInfoComponent.ServerItem.ServerId;
            main2NetClientLogin.VersionMode  = versionmode;
            main2NetClientLogin.CheckRealName = playerInfoComponent.CheckRealName;
            NetClient2Main_Login response = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, main2NetClientLogin) as NetClient2Main_Login;
            
            playerInfoComponent.Token = response.Token;
            playerInfoComponent.AccountId = response.AccountId;
            playerInfoComponent.PlayerInfo = response.PlayerInfo;
            playerInfoComponent.CreateRoleList = response.RoleLists;
            
            return response.Error;
        }

        public static async ETTask<NetClient2Main_CheckSession> RequestCheckSession(this ClientSenderCompnent self, int maptype)
        {
            Main2NetClient_CheckSession main2NetClientCheck = Main2NetClient_CheckSession.Create();
            main2NetClientCheck.MapType = maptype;
            NetClient2Main_CheckSession respone = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, main2NetClientCheck) as NetClient2Main_CheckSession;
            return respone;
        }
        
        public static async ETTask<NetClient2Main_LoginGame> LoginGameAsync(this ClientSenderCompnent self, string account, long accountId, long key,long roleId,string address,int reLink)
        {
            Main2NetClient_LoginGame main2NetClientLoginGame = Main2NetClient_LoginGame.Create();
            main2NetClientLoginGame.RealmKey    = key;
            main2NetClientLoginGame.Account     = account;
            main2NetClientLoginGame.RoleId      = roleId;
            main2NetClientLoginGame.GateAddress = address;
            main2NetClientLoginGame.AccountId   = accountId;
            main2NetClientLoginGame.ReLink      = reLink;
            NetClient2Main_LoginGame response = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, main2NetClientLoginGame) as NetClient2Main_LoginGame;
            return response;
        }
        
        public static void Send(this ClientSenderCompnent self, IMessage message)
        {
            A2NetClient_Message a2NetClientMessage = A2NetClient_Message.Create();
            a2NetClientMessage.MessageObject = message;
            self.Root().GetComponent<ProcessInnerSender>().Send(self.netClientActorId, a2NetClientMessage);
        }

        public static async ETTask<IResponse> Call(this ClientSenderCompnent self, IRequest request, bool needException = true)
        {
            A2NetClient_Request a2NetClientRequest = A2NetClient_Request.Create();
            a2NetClientRequest.MessageObject = request;
            using A2NetClient_Response a2NetClientResponse = await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, a2NetClientRequest) as A2NetClient_Response;
            IResponse response = a2NetClientResponse.MessageObject;
                        
            if (response.Error == ErrorCore.ERR_MessageTimeout)
            {
                throw new RpcException(response.Error, $"Rpc error: request， 注意Actor消息超时，请注意查看是否死锁或者没有reply: {request}， response: {response}");
            }

            if (needException && ErrorCore.IsRpcNeedThrowException(response.Error))
            {
                throw new RpcException(response.Error, $"Rpc error: {request}, response: {response}");
            }
            
            if (response.Error != 0)
            {
                EventSystem.Instance.Publish(self.Root(), new CommonHintError() { ErrorValue = response.Error });
            }
            
            if (response.Error == ErrorCode.ERR_SessionDisconnect)
            {
               Log.Error($"response.Error == ErrorCode.ERR_SessionDisconnect.[网络已断开，但是没重连！！！！]");
            }
            
            return response;
        }

    }
}
