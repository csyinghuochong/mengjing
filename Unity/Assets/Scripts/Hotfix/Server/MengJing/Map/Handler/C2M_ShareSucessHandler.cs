namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ShareSucessHandler : MessageLocationHandler<Unit, C2M_ShareSucessRequest, M2C_ShareSucessResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ShareSucessRequest request, M2C_ShareSucessResponse response)
        {
            if (request.ShareType != 1 && request.ShareType != 2)
            {
                return;
            }

            
            UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            UserInfo userInfo = userInfoComponentS.UserInfo;
            if (userInfo.Lv < 10)
            {
                response.Error = ErrorCode.ERR_LevelIsNot;
                return;
            }
            
            if (userInfoComponentS.TodayOnLine < 1800)
            {
                response.Error = ErrorCode.Err_OnLineTimeNot;
                return;
            }
            if (unit.GetComponent<TaskComponentS>().GetHuoYueDu() < 30)
            {
                response.Error = ErrorCode.ERR_HuoYueNot;
                return;
            }

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            long shareSet = numericComponent.GetAsLong(NumericType.FenShangSet);
            if ((shareSet & request.ShareType) > 0)
            {
                response.Error = ErrorCode.ERR_TimesIsNot;
                return;
            }

            ActorId accountZone = UnitCacheHelper.GetLoginCenterId();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            M2L_ShareSucessRequest M2Center_ShareSucessRequest = M2L_ShareSucessRequest.Create();
            M2Center_ShareSucessRequest.AccountId = userInfoComponent.UserInfo.AccInfoID;
            L2M_ShareSucessResponse centerAccount = (L2M_ShareSucessResponse)await unit.Root().GetComponent<MessageSender>().Call(accountZone,M2Center_ShareSucessRequest);
            if (centerAccount.Error != ErrorCode.ERR_Success)
            {
                response.Error = centerAccount.Error;
                return;
            }

            shareSet = shareSet | (long)request.ShareType;
            numericComponent.ApplyValue(NumericType.FenShangSet, shareSet);

            //给钻石
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd( UserDataType.Diamond, "120", true, ItemGetWay.Share);

            unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.ShareTotalNumber_220, 0, 1);
            await ETTask.CompletedTask;
        }
    }
}
