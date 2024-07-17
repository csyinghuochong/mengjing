namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionTransferHandler : MessageLocationHandler<Unit, C2M_UnionTransferRequest, M2C_UnionTransferResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionTransferRequest request, M2C_UnionTransferResponse response)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            long unionid = numericComponent.GetAsLong( NumericType.UnionId_0 );
            if (unionid == 0)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }
            if (numericComponent.GetAsInt(NumericType.UnionLeader)== 0)
            {
                response.Error = ErrorCode.ERR_Union_NotLeader;
                return;
            }

            ActorId unionserverid = UnitCacheHelper.GetUnionServerId( unit.Zone() );
            M2U_UnionTransferRequest transferRequest = M2U_UnionTransferRequest.Create();
            transferRequest.NewLeader = request.NewLeader;
            transferRequest.UnionId = unionid;
            transferRequest.UnitID = unit.Id;
            U2M_UnionTransferResponse responseUnionEnter = (U2M_UnionTransferResponse)await unit.Root().GetComponent<MessageSender>().Call(unionserverid, transferRequest);

            if (responseUnionEnter.Error != ErrorCode.ERR_Success)
            {
                response.Error = responseUnionEnter.Error;
                return;
            }
            
            await ETTask.CompletedTask;
        }
    }
}
