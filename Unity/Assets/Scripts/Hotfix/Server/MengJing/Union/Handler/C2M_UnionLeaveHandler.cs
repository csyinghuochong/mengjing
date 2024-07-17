namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionHandler : MessageLocationHandler<Unit, C2M_UnionLeaveRequest, M2C_UnionLeaveResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_UnionLeaveRequest request, M2C_UnionLeaveResponse response)
        {
            ActorId dbCacheId = UnitCacheHelper.GetUnionServerId(unit.Zone());
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            M2U_UnionLeaveRequest M2U_UnionLeaveRequest = M2U_UnionLeaveRequest.Create();
            M2U_UnionLeaveRequest.UnionId = numericComponent.GetAsLong(NumericType.UnionId_0);
            M2U_UnionLeaveRequest.UserId = userInfoComponent.UserInfo.UserId;
            U2M_UnionLeaveResponse d2GGetUnit = (U2M_UnionLeaveResponse)await unit.Root().GetComponent<MessageSender>().Call(dbCacheId, M2U_UnionLeaveRequest);

            if (d2GGetUnit.Error != ErrorCode.ERR_Success)
            {
                response.Error = d2GGetUnit.Error;
                return;
            }

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.UnionLeader, 0);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.UnionId_0, 0);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.UnionIdLeaveTime, TimeHelper.ServerNow());
            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.UnionName, "");
            unit.GetComponent<UserInfoComponentS>().UpdateRoleDataBroadcast(UserDataType.UnionName, "");
            unit.GetComponent<DBSaveComponent>().UpdateCacheDB();

            unit.UpdateUnionToChat().Coroutine();

            await ETTask.CompletedTask;
        }
    }
}
