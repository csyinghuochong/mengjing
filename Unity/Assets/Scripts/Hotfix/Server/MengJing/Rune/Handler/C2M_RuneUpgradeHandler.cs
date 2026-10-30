namespace ET.Server
{
    /// <summary>
    /// 升级符文：按符文唯一 id 升，镶嵌中的也能升
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_RuneUpgradeHandler : MessageLocationHandler<Unit, C2M_RuneUpgradeRequest, M2C_RuneUpgradeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RuneUpgradeRequest request, M2C_RuneUpgradeResponse response)
        {
            RuneComponent runeComponent = unit.GetComponent<RuneComponent>();

            response.Error = runeComponent.OnUpgradeRune(request.RuneId);
            response.Info = runeComponent.GetInfo();
            await ETTask.CompletedTask;
        }
    }
}
