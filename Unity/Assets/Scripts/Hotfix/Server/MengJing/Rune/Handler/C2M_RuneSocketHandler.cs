namespace ET.Server
{
    /// <summary>
    /// 镶嵌符文：槽位类型要和符文类型一致，符文镶上后仍留在符文列表里
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_RuneSocketHandler : MessageLocationHandler<Unit, C2M_RuneSocketRequest, M2C_RuneSocketResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RuneSocketRequest request, M2C_RuneSocketResponse response)
        {
            RuneComponent runeComponent = unit.GetComponent<RuneComponent>();

            response.Error = runeComponent.OnSocketRune(request.SlotId, request.RuneId);
            response.Info = runeComponent.GetInfo();
            await ETTask.CompletedTask;
        }
    }
}
