namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GemHeChengQuickHandler: MessageLocationHandler<Unit, C2M_GemHeChengQuickRequest, M2C_GemHeChengQuickResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GemHeChengQuickRequest request, M2C_GemHeChengQuickResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
    
}