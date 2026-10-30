namespace ET.Server
{
    /// <summary>
    /// 拆卸符文：槽位里的符文放回背包
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_RuneUnsocketHandler : MessageLocationHandler<Unit, C2M_RuneUnsocketRequest, M2C_RuneUnsocketResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RuneUnsocketRequest request, M2C_RuneUnsocketResponse response)
        {
            RuneComponent runeComponent = unit.GetComponent<RuneComponent>();

            response.Error = runeComponent.OnUnsocketRune(request.SlotId);
            response.Info = runeComponent.GetInfo();
            await ETTask.CompletedTask;
        }
    }
}
