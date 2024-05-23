﻿using System;
using System.Collections.Generic;


namespace ET
{

    [MessageHandler]
    public class C2Center_PhoneBingingHandler : AMRpcHandler<C2Center_PhoneBinging, Center2C_PhoneBinging>
    {
        protected override async ETTask Run(Session session, C2Center_PhoneBinging request, Center2C_PhoneBinging response, Action reply)
        {
            Log.Warning($"C2Center_PhoneBinging:{request.Account}");
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.Register, request.Account.Trim().GetHashCode()))
            {
                if (request.AccountId == 0 || string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.PhoneNumber))
                {
                    response.Error = ErrorCode.ERR_NetWorkError;
                    reply();
                    return;
                }

                List<DBCenterAccountInfo> resultAccounts = await Game.Scene.GetComponent<DBComponent>().Query<DBCenterAccountInfo>(session.DomainZone(),
                    _account => _account.Account.Equals(request.PhoneNumber));
                if (resultAccounts.Count > 0)
                {
                    response.Error = ErrorCode.ERR_BingPhoneError_1;
                    reply();
                    return;
                }

                resultAccounts = await Game.Scene.GetComponent<DBComponent>().Query<DBCenterAccountInfo>(session.DomainZone(), 
                    _account => _account.PlayerInfo!=null && _account.PlayerInfo.PhoneNumber.Equals(request.PhoneNumber));
                if (resultAccounts.Count > 0)
                {
                    response.Error = ErrorCode.ERR_BingPhoneError_2;
                    reply();
                    return;
                }

                resultAccounts = await Game.Scene.GetComponent<DBComponent>().Query<DBCenterAccountInfo>(session.DomainZone(), _account => _account.Id == request.AccountId);
                if (resultAccounts.Count == 0)
                {
                    Log.Error($"PhoneBinging: resultAccounts.Count");
                    reply();
                    return;
                }
                DBCenterAccountInfo dBCenterAccountInfo = resultAccounts[0];
                if (!string.IsNullOrWhiteSpace(dBCenterAccountInfo.PlayerInfo.PhoneNumber)
                   && dBCenterAccountInfo.PlayerInfo.PhoneNumber.Equals(request.PhoneNumber))
                {
                    Log.Error($"PhoneBinging: resultAccounts.Count");
                    response.Error = ErrorCode.ERR_BingPhoneError_2;
                    reply();
                    return;
                }

                dBCenterAccountInfo.PlayerInfo.PhoneNumber = request.PhoneNumber;
                
                await Game.Scene.GetComponent<DBComponent>().Save<DBCenterAccountInfo>(session.DomainZone(), dBCenterAccountInfo);
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
