using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class U2M_UnionKickOutHandler : MessageHandler<Unit, U2M_UnionKickOutRequest, M2U_UnionKickOutResponse>
    {
        protected override async ETTask Run(Unit unit, U2M_UnionKickOutRequest request, M2U_UnionKickOutResponse response)
        {
            Console.WriteLine($"U2M_UnionKickOutHandler:  {unit.Id}");
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.UnionLeader,0);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.UnionId_0, 0);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.UnionName, "");
            unit.GetComponent<UserInfoComponentS>().UpdateRoleDataBroadcast(UserDataType.UnionName, "");
            unit.GetComponent<DBSaveComponent>().UpdateCacheDB();
            unit.UpdateUnionToChat().Coroutine();

            await ETTask.CompletedTask;
        }
    }
}
