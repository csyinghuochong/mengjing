namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class U2M_UnionKeJiQuickHandler : MessageHandler<Unit, M2U_UnionKeJiQuickRequest, U2M_UnionKeJiQuickResponse>
    {
        protected override async ETTask Run(Unit unit, M2U_UnionKeJiQuickRequest request, U2M_UnionKeJiQuickResponse response)
        {
            

            await ETTask.CompletedTask;
        }
    }
}
