using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_RealNameHandler: MessageHandler<Scene, Main2NetClient_RealName, NetClient2Main_RealName>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_RealName request, NetClient2Main_RealName response)
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
            
            Log.Debug($"Main2NetClient_RealNameHandler   22222:  {realmAddress.Address}" );
            
            C2R_RealNameRequest c2RRealNameRequest = C2R_RealNameRequest.Create();
            c2RRealNameRequest.AccountId = request.AccountId;
            c2RRealNameRequest.IdCardNO = request.IdCardNO;
            c2RRealNameRequest.Name = request.Name;
            R2C_RealNameResponse realNameResponse = (R2C_RealNameResponse)await session.Call(c2RRealNameRequest);
            Log.Debug("Main2NetClient_RealNameHandler   33333" );
            // if (realNameResponse.Error == ErrorCode.ERR_Success)
            // {
            //     root.AddComponent<SessionComponent>().Session = session;
            // }
            // else
            // {
            //     
            // }

            response.PlayerInfo =  realNameResponse.PlayerInfo;
            response.Error = realNameResponse.Error;
            
            session?.Dispose();
            Log.Warning($"C2R_RealNameRequest: session?.Dispose");
        }
    }
}