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
            Log.Debug("Main2NetClient_ServerListHandler.");
            Console.WriteLine("Main2NetClient_ServerListHandler.");

            string account = "tcg01";
            string password = "111111";

            root.RemoveComponent<RouterAddressComponent>();
            RouterAddressComponent routerAddressComponent =
                    root.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHostInter, ConstValue.RouterHttpPort);
            await routerAddressComponent.Init();
            root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily,
                NetworkProtocol.UDP);
            root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;

            NetComponent netComponent = root.GetComponent<NetComponent>();

            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

            Session session = await netComponent.CreateRouterSession(realmAddress, account, password);


            C2R_ServerList c2RLoginAccount = C2R_ServerList.Create();
            R2C_ServerList r2CLoginAccount = (R2C_ServerList)await session.Call(c2RLoginAccount);
            
            Log.Debug($"R2C_ServerList: {r2CLoginAccount.Error}");
            
            if (r2CLoginAccount.Error == ErrorCode.ERR_Success)
            {
                root.AddComponent<SessionComponent>().Session = session;
            }
            else
            {
                session?.Dispose();
            }

            //response.ServerItems = r2CLoginAccount.ServerItems;
            response.NoticeVersion = r2CLoginAccount.NoticeVersion;
            response.NoticeText = r2CLoginAccount.NoticeText;
            response.Error = r2CLoginAccount.Error;
        }
    }
}