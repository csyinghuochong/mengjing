using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_ServerListHandler: MessageHandler<Scene, Main2NetClient_ServerList, NetClient2Main_ServerList>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_ServerList request, NetClient2Main_ServerList response)
        {
            string account = "aaa";
            string password = "111";
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
            
            C2R_ServerList c2RLoginAccount = C2R_ServerList.Create();
            c2RLoginAccount.VersionMode = request.VersionMode;
            R2C_ServerList r2CLoginAccount = (R2C_ServerList)await session.Call(c2RLoginAccount);
            
            // if (r2CLoginAccount.Error == ErrorCode.ERR_Success)
            // {
            //     root.AddComponent<SessionComponent>().Session = session;
            //     Log.Warning($"R2C_ServerList: session!=null {r2CLoginAccount.Error}");
            // }
            // else
            // {
            //     
            // }

            response.ServerItems = r2CLoginAccount.ServerItems;
            response.NoticeVersion = r2CLoginAccount.NoticeVersion;
            response.NoticeText = r2CLoginAccount.NoticeText;
            response.Error = r2CLoginAccount.Error;
            
            session?.Dispose();
            Log.Warning($"R2C_ServerList: session?.Dispose");
        }
        
    }
}