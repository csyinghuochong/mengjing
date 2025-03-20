namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionWishSendHandler : MessageLocationHandler<Unit, C2M_UnionWishSendRequest, M2C_UnionWishSendResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionWishSendRequest request, M2C_UnionWishSendResponse response)
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
            M2U_UnionWishSendRequest transferRequest = M2U_UnionWishSendRequest.Create();
            transferRequest.UnionId = unionid;
  
            U2M_UnionWishSendResponse responseUnionEnter = (U2M_UnionWishSendResponse)await unit.Root().GetComponent<MessageSender>().Call(unionserverid, transferRequest);

            if (responseUnionEnter.Error != ErrorCode.ERR_Success)
            {
                response.Error = responseUnionEnter.Error;
                return;
            }
            
            await ETTask.CompletedTask;
        }
    }
}
