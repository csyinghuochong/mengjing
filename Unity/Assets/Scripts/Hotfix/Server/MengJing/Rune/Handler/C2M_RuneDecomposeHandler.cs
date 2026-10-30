namespace ET.Server
{
    /// <summary>
    /// 分解符文：只能分解背包里的，镶嵌中的要先卸下
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_RuneDecomposeHandler : MessageLocationHandler<Unit, C2M_RuneDecomposeRequest, M2C_RuneDecomposeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RuneDecomposeRequest request, M2C_RuneDecomposeResponse response)
        {
            RuneComponent runeComponent = unit.GetComponent<RuneComponent>();

            response.Error = runeComponent.OnDecomposeRune(request.RuneId);
            response.Info = runeComponent.GetInfo();
            await ETTask.CompletedTask;
        }
    }
}
