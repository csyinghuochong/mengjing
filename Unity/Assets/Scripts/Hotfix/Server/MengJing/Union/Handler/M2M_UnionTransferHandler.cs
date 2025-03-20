namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2M_UnionTransferHandler : MessageLocationHandler<Unit, U2M_UnionTransferResult, M2U_UnionTransferResult>
    {
        protected override async ETTask Run(Unit unit, U2M_UnionTransferResult request, M2U_UnionTransferResult response)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue( NumericType.UnionLeader, request.UnionLeader, true );
            await ETTask.CompletedTask;
        }
    }
}
