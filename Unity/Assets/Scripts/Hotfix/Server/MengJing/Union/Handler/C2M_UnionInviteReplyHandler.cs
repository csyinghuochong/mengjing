namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionInviteReplyHandler : MessageLocationHandler<Unit, C2M_UnionInviteReplyRequest>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionInviteReplyRequest message)
        {
            long unionid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
            if (unionid != 0)
            {
                return;
            }

            ActorId unitonsceneid = UnitCacheHelper.GetUnionServerId( unit.Zone() );
            M2U_UnionInviteReplyMessage M2U_UnionInviteReplyMessage = M2U_UnionInviteReplyMessage.Create();
            M2U_UnionInviteReplyMessage.UnionId = message.UnionId;
            M2U_UnionInviteReplyMessage.UnitID = unit.Id;
            unit.Root().GetComponent<MessageSender>().Send(unitonsceneid, M2U_UnionInviteReplyMessage);
            await ETTask.CompletedTask;
        }
    }
}
