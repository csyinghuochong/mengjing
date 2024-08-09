﻿using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [FriendOf(typeof(PlayerComponent))]
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_LoginHandler : MessageHandler<Scene, Main2NetClient_Login, NetClient2Main_Login>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_Login request, NetClient2Main_Login response)
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

            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account, request.ServerId);

            Session session = await netComponent.CreateRouterSession(realmAddress, account, password, SceneTypeEnum.LoginScene);
            C2R_LoginAccount c2RLoginAccount = C2R_LoginAccount.Create();
            c2RLoginAccount.Account = account;
            c2RLoginAccount.Password = password;
            c2RLoginAccount.ServerId = request.ServerId;
            c2RLoginAccount.Relink = request.Relink;
            R2C_LoginAccount r2CLoginAccount = (R2C_LoginAccount)await session.Call(c2RLoginAccount);
            if (r2CLoginAccount.Error == ErrorCode.ERR_Success)
            {
                root.AddComponent<SessionComponent>().Session = session;
            }
            else
            {
                session?.Dispose();
            }

            response.AccountId = r2CLoginAccount.AccountId;
            response.PlayerInfo = r2CLoginAccount.PlayerInfo;
            response.RoleLists = r2CLoginAccount.RoleLists;
            response.Token = r2CLoginAccount.Token;
            response.Error = r2CLoginAccount.Error;
        }
    }
}