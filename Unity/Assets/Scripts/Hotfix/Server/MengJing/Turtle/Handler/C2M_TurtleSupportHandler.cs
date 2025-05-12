namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TurtleSupportHandler : MessageLocationHandler<Unit, C2M_TurtleSupportRequest, M2C_TurtleSupportResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TurtleSupportRequest request, M2C_TurtleSupportResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Buy, unit.Id))
            {
                UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
               
                long costgold = GlobalValueConfigCategory.Instance.TurtleSupportCost;
                if (userInfoComponent.UserInfo.Gold < costgold)
                {
                    response.Error = ErrorCode.ERR_GoldNotEnoughError;
                    return;
                }

                ActorId activtiyserverid = UnitCacheHelper.GetActivityServerId(unit.Zone());
                M2A_TurtleSupportRequest m2A_TurtleSupport = M2A_TurtleSupportRequest.Create();
                m2A_TurtleSupport.UnitId = unit.Id;
                m2A_TurtleSupport.AccountId = userInfoComponent.UserInfo.AccInfoID;
                m2A_TurtleSupport.SupportId = request.SupportId;
                A2M_TurtleSupportResponse a2M_TurtleSupport = (A2M_TurtleSupportResponse)await unit.Root().GetComponent<MessageSender>().Call
                        (activtiyserverid, m2A_TurtleSupport);

                if (a2M_TurtleSupport.Error != ErrorCode.ERR_Success)
                {
                    response.Error = a2M_TurtleSupport.Error;
                    return;
                }
                //扣除金币 
                userInfoComponent.UpdateRoleMoneySub(UserDataType.Gold, (costgold * -1).ToString(), true, ItemGetWay.Turtle);

            }
            await ETTask.CompletedTask;
        }
    }
}
