namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionDonationHandler : MessageLocationHandler<Unit, C2M_UnionDonationRequest, M2C_UnionDonationResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionDonationRequest request, M2C_UnionDonationResponse response)
        {
            //获取公会等级
            long unionid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
            if (unionid == 0)
            {
                return;
            }

            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Donation, unit.Id))
            {
                if (request.Type == 0) // 金币捐献
                {
                    if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.UnionDonationNumber) >= 5)
                    {
                        response.Error = ErrorCode.ERR_TimesIsNot;
                        return;
                    }

                    long selfgold = unit.GetComponent<UserInfoComponentS>().UserInfo.Gold;
                    M2U_UnionOperationRequest M2U_UnionOperationRequest = M2U_UnionOperationRequest.Create();
                    M2U_UnionOperationRequest.OperateType = 3;
                    M2U_UnionOperationRequest.UnitId = unit.Id;
                    M2U_UnionOperationRequest.UnionId = unionid; 
                    M2U_UnionOperationRequest.Par = selfgold.ToString();
                    U2M_UnionOperationResponse responseUnionEnter = (U2M_UnionOperationResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        UnitCacheHelper.GetUnionServerId(unit.Zone()),M2U_UnionOperationRequest);

                    if (responseUnionEnter.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = responseUnionEnter.Error;
                        return;
                    }

                    int unionID = int.Parse(responseUnionEnter.Par);
                    UnionConfig unionCof = UnionConfigCategory.Instance.Get(unionID);
                    unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.UnionDonationNumber, 1);
                    UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();

                    userInfoComponent.UpdateRoleMoneySub(UserDataType.Gold, (unionCof.DonateGold * -1).ToString(), true, ItemGetWay.Donation);
                    int randNumExp = RandomHelper.RandomNumber(unionCof.DonateExp[0], unionCof.DonateExp[1] + 1);
                    int randNumGongXian = RandomHelper.RandomNumber(unionCof.DonateReward[0], unionCof.DonateReward[1] + 1);
                    int randUnionGold = RandomHelper.RandomNumber(unionCof.AddUnionGold[0], unionCof.AddUnionGold[1] + 1);
                    userInfoComponent.UpdateRoleMoneyAdd(UserDataType.UnionContri, randNumGongXian.ToString(), true, ItemGetWay.Donation);
                    userInfoComponent.UpdateRoleMoneyAdd(UserDataType.UnionExp, randNumExp.ToString(), true, ItemGetWay.Donation);
                    userInfoComponent.UpdateRoleMoneyAdd(UserDataType.UnionGold, randUnionGold.ToString(), true, ItemGetWay.Donation);
                }
                else if (request.Type == 1) // 钻石捐献
                {
                    if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.UnionDiamondDonationNumber) >= 10)
                    {
                        response.Error = ErrorCode.ERR_TimesIsNot;
                        return;
                    }

                    long selfDiamond = unit.GetComponent<UserInfoComponentS>().UserInfo.Diamond;
                    M2U_UnionOperationRequest M2U_UnionOperationRequest = M2U_UnionOperationRequest.Create();
                    M2U_UnionOperationRequest.OperateType = 4;
                    M2U_UnionOperationRequest.UnitId = unit.Id;
                    M2U_UnionOperationRequest.UnionId = unionid;
                    M2U_UnionOperationRequest.Par = selfDiamond.ToString();
                    
                    U2M_UnionOperationResponse responseUnionEnter = (U2M_UnionOperationResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        UnitCacheHelper.GetUnionServerId(unit.Zone()),M2U_UnionOperationRequest);

                    if (responseUnionEnter.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = responseUnionEnter.Error;
                        return;
                    }

                    int unionID = int.Parse(responseUnionEnter.Par);
                    UnionConfig unionCof = UnionConfigCategory.Instance.Get(unionID);
                    unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.UnionDiamondDonationNumber, 1);
                    // 花费250钻石，暂时写死，M2U_UnionOperationRequest也是
                    UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();

                    userInfoComponent.UpdateRoleMoneySub(UserDataType.Diamond, (unionCof.DonateDiamond * -1).ToString(), true, ItemGetWay.Donation);
                    int randNumExp = RandomHelper.RandomNumber(unionCof.DonateExp[0], unionCof.DonateExp[1] + 1);
                    int randNumGongXian = RandomHelper.RandomNumber(unionCof.DonateReward[0], unionCof.DonateReward[1] + 1);
                    int randUnionGold = RandomHelper.RandomNumber(unionCof.AddUnionGold[0], unionCof.AddUnionGold[1] + 1);
                    userInfoComponent.UpdateRoleMoneyAdd(UserDataType.UnionContri, randNumGongXian.ToString(), true, ItemGetWay.Donation);
                    userInfoComponent.UpdateRoleMoneyAdd(UserDataType.UnionExp, randNumExp.ToString(), true, ItemGetWay.Donation);
                    userInfoComponent.UpdateRoleMoneyAdd(UserDataType.UnionGold, randUnionGold.ToString(), true, ItemGetWay.Donation);
                }
            }


            await ETTask.CompletedTask;
        }
    }
}
