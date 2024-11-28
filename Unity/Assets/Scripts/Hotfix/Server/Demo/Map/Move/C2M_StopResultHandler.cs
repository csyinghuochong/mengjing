namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_StopResultHandler: MessageLocationHandler<Unit, C2M_StopResult>
    {
        protected override async ETTask Run(Unit unit, C2M_StopResult message)
        {
            unit.StopResult(message.Position, 0);
            
            await ETTask.CompletedTask;
        }
    }
}