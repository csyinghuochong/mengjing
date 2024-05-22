using System;
using System.Collections.Generic;

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
            U2M_UnionLeaveResponse d2GGetUnit = (U2M_UnionLeaveResponse)await unit.Root().GetComponent<MessageSender>().Call(dbCacheId, new M2U_UnionLeaveRequest()
            {
                UnionId = numericComponent.GetAsLong(NumericType.UnionId_0),
                UserId = userInfoComponent.UserInfo.UserId,
            });

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
