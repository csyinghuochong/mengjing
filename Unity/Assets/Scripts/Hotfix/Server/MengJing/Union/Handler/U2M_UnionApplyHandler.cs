namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class U2M_UnionApplyHandler : MessageLocationHandler<Unit, U2M_UnionApplyRequest, M2U_UnionApplyResponse>
    {
        protected override async ETTask Run(Unit unit, U2M_UnionApplyRequest request, M2U_UnionApplyResponse response)
        {
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.UnionLeader, 0);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.UnionId_0, request.UnionId);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.UnionName, request.UnionName);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleDataBroadcast(UserDataType.UnionName, request.UnionName);
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JoinUnion_9, 0, 1);
            unit.UpdateUnionToChat().Coroutine();

            await ETTask.CompletedTask;
        }
    }
}
