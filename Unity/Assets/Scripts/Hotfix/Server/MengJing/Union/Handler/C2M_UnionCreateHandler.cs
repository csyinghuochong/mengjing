namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionCreateHandler : MessageLocationHandler<Unit, C2M_UnionCreateRequest, M2C_UnionCreateResponse>
    {
        
        protected override async ETTask Run(Unit unit, C2M_UnionCreateRequest request, M2C_UnionCreateResponse response)
        {
            //判断等级、钻石
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsLong(NumericType.UnionId_0) != 0)
            {
                response.Error = ErrorCode.ERR_Union_Create;
                return;
            }
            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            int needLevel = GlobalValueConfigCategory.Instance.UnionCreateNeedLv;
            int needDiamond = GlobalValueConfigCategory.Instance.UnionCreateNeedDiamond;
            if (userInfo.Lv < needLevel || userInfo.Diamond < needDiamond)
            {
                response.Error = ErrorCode.ERR_Union_Create;
                return;
            }

            ActorId dbCacheId = UnitCacheHelper.GetUnionServerId(unit.Zone());
            M2U_UnionCreateRequest M2U_UnionCreateRequest = M2U_UnionCreateRequest.Create();
            M2U_UnionCreateRequest.UnionName = request.UnionName;
            M2U_UnionCreateRequest.UnionPurpose = request.UnionPurpose;
            M2U_UnionCreateRequest.UserID = userInfo.UserId;
            U2M_UnionCreateResponse d2GGetUnit = (U2M_UnionCreateResponse)await unit.Root().GetComponent<MessageSender>().Call(dbCacheId, M2U_UnionCreateRequest);

            if (d2GGetUnit.Error == ErrorCode.ERR_Success)
            {
                unit.GetComponent<NumericComponentS>().ApplyValue( NumericType.UnionLeader, 1, true);
                unit.GetComponent<NumericComponentS>().ApplyValue( NumericType.UnionId_0, d2GGetUnit.UnionId, true);
                unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.UnionName, request.UnionName);
                unit.GetComponent<UserInfoComponentS>().UpdateRoleDataBroadcast(UserDataType.UnionName, request.UnionName);
                unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JoinUnion_9, 0, 1);
                unit.UpdateUnionToChat().Coroutine();
            }
            response.Error = d2GGetUnit.Error;
            await ETTask.CompletedTask;
        }

    }
}
