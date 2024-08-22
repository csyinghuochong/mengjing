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
            RankingInfo rankingInfo = RankingInfo.Create();
            rankingInfo.Combat = request.Price;
            rankingInfo.UserId = unit.Id;
            rankingInfo.PlayerLv = userInfo.Lv;
            rankingInfo.PlayerName = userInfo.Name;
            rankingInfo.Occ = userInfo.Occ;

            M2U_DonationRequest M2U_DonationRequest = M2U_DonationRequest.Create();
            M2U_DonationRequest.RankingInfo = rankingInfo;
            U2M_DonationResponse d2GGetUnit = (U2M_DonationResponse)await unit.Root().GetComponent<MessageSender>().Call(serverid,M2U_DonationRequest);

            if (d2GGetUnit.Error != ErrorCode.ERR_Success)
            {
                response.Error = d2GGetUnit.Error;
                return;
            }
            unit.GetComponent<NumericComponentS>().ApplyChange( NumericType.RaceDonationNumber, request.Price);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub( UserDataType.Gold,  (request.Price * -1).ToString(),true, ItemGetWay.Donation );

            await ETTask.CompletedTask;
        }
    }
}
