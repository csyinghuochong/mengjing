using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [FriendOf(typeof(PlayerComponent))]
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_LoginHandler: MessageHandler<Scene, Main2NetClient_Login, NetClient2Main_Login>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_Login request, NetClient2Main_Login response)
        {
            Log.Debug("Main2NetClient_LoginHandler.");
            Console.WriteLine("Main2NetClient_LoginHandler.");
            
            string account = request.Account;
            string password = request.Password;
            
            root.RemoveComponent<RouterAddressComponent>();
            RouterAddressComponent routerAddressComponent =
                    root.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHostInter, ConstValue.RouterHttpPort);
            await routerAddressComponent.Init();
            root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily, NetworkProtocol.UDP);
            root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;

            NetComponent netComponent = root.GetComponent<NetComponent>();
            
            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

            R2C_LoginAccount r2CLogin;
            Session session = await netComponent.CreateRouterSession(realmAddress, account, password);
            r2CLogin = (R2C_LoginAccount)await session.Call(new C2R_LoginAccount() { Account = account, Password = password });
            if (r2CLogin.Error == ErrorCode.ERR_Success)
            {
                root.AddComponent<SessionComponent>().Session = session;
            }
            else
            {
                session?.Dispose();
            }
            
            response.AccountId = r2CLogin.AccountId;
            response.PlayerInfo = r2CLogin.PlayerInfo;
            response.RoleLists = r2CLogin.RoleLists;
            response.Key = r2CLogin.Key;
            response.Token = r2CLogin.Token;
            response.Error = r2CLogin.Error;
        }
    }
}