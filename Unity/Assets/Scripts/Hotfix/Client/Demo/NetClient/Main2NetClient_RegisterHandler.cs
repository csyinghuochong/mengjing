using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [FriendOf(typeof(PlayerInfoComponent))]
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_RegisterHandler: MessageHandler<Scene, Main2NetClient_Register, NetClient2Main_Register>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_Register request, NetClient2Main_Register response)
        {
            string account = request.Account;
            string password = request.Password;
            string httphost = request.VersionMode == VersionMode.Alpha ? ConstValue.RouterHttpHostInter : ConstValue.RouterHttpHostOuter;
            root.RemoveComponent<RouterAddressComponent>();
            RouterAddressComponent routerAddressComponent =
                    root.AddComponent<RouterAddressComponent, string, int>(httphost, ConstValue.RouterHttpPort);
            await routerAddressComponent.Init();
            root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily,
                NetworkProtocol.UDP);
            root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;

            NetComponent netComponent = root.GetComponent<NetComponent>();

            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress();

            Session session = await netComponent.CreateRealmSession(realmAddress, account, password);
            C2R_RegisterAccount requset = C2R_RegisterAccount.Create();
            requset.Account = account;
            requset.Password = password;
            R2C_RegisterAccount r2CLoginAccount = (R2C_RegisterAccount)await session.Call(requset);

            session?.Dispose();
            
            response.Error = r2CLoginAccount.Error;
        }
    }
}