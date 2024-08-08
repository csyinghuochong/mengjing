using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_PhoneBingingHandler : MessageHandler<Session, C2M_PhoneBinging, M2C_PhoneBinging>
    {
        protected override async ETTask Run(Session session, C2M_PhoneBinging request, M2C_PhoneBinging response)
        {
            Log.Warning($"C2Center_PhoneBinging:{request.Account}");
            using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Register, request.Account.Trim().GetHashCode()))
            {
                // if (request.AccountId == 0 || string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.PhoneNumber))
                // {
                //     response.Error = ErrorCode.ERR_NetWorkError;
                //     return;
                // }
                //
                // DBManagerComponent dbManagerComponent = session.Root().GetComponent<DBManagerComponent>();
                // DBComponent dbComponent = dbManagerComponent.GetZoneDB(session.Zone());
                //
                // List<DBCenterAccountInfo> resultAccounts = await dbComponent.Query<DBCenterAccountInfo>(session.Zone(),
                //     _account => _account.Account.Equals(request.PhoneNumber));
                // if (resultAccounts.Count > 0)
                // {
                //     response.Error = ErrorCode.ERR_BingPhoneError_1;
                //     return;
                // }
                //
                // resultAccounts = await dbComponent.Query<DBCenterAccountInfo>(session.Zone(), 
                //     _account => _account.PlayerInfo!=null && _account.PlayerInfo.PhoneNumber.Equals(request.PhoneNumber));
                // if (resultAccounts.Count > 0)
                // {
                //     response.Error = ErrorCode.ERR_BingPhoneError_2;
                //     return;
                // }
                //
                // resultAccounts = await dbComponent.Query<DBCenterAccountInfo>(session.Zone(), _account => _account.Id == request.AccountId);
                // if (resultAccounts.Count == 0)
                // {
                //     Log.Error($"PhoneBinging: resultAccounts.Count");
                //     return;
                // }
                // DBCenterAccountInfo dBCenterAccountInfo = resultAccounts[0];
                // if (!string.IsNullOrWhiteSpace(dBCenterAccountInfo.PlayerInfo.PhoneNumber)
                //    && dBCenterAccountInfo.PlayerInfo.PhoneNumber.Equals(request.PhoneNumber))
                // {
                //     Log.Error($"PhoneBinging: resultAccounts.Count");
                //     response.Error = ErrorCode.ERR_BingPhoneError_2;
                //     return;
                // }
                //
                // dBCenterAccountInfo.PlayerInfo.PhoneNumber = request.PhoneNumber;
                //
                // await dbComponent.Save<DBCenterAccountInfo>(session.Zone(), dBCenterAccountInfo);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
