using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_DonationRequestHandler : MessageLocationHandler<Unit, C2M_DonationRequest, M2C_DonationResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_DonationRequest request, M2C_DonationResponse response)
        {
            if (request.Price < 100000)
            {
                return;
            }
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Gold < request.Price)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            //using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.Donation, unit.Id))
            //{

            //}
            request.UnitId = unit.Id;
            ActorId serverid = UnitCacheHelper.GetUnionServerId(unit.Zone());
            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            RankingInfo rankingInfo = new RankingInfo()
            {
                Combat = request.Price,
                UserId = unit.Id,
                PlayerLv = userInfo.Lv,
                PlayerName = userInfo.Name, 
                Occ = userInfo.Occ, 
            };
            U2M_DonationResponse d2GGetUnit = (U2M_DonationResponse)await unit.Root().GetComponent<MessageSender>().Call(serverid,
                new M2U_DonationRequest() { RankingInfo = rankingInfo }
                );

            if (d2GGetUnit.Error != ErrorCode.ERR_Success)
            {
                response.Error = d2GGetUnit.Error;
                return;
            }
            unit.GetComponent<NumericComponentS>().ApplyChange(unit, NumericType.RaceDonationNumber, request.Price, 0);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub( UserDataType.Gold,  (request.Price * -1).ToString(),true, ItemGetWay.Donation );

            await ETTask.CompletedTask;
        }
    }
}
