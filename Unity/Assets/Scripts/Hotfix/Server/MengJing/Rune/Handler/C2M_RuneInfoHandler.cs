namespace ET.Server
{
    /// <summary>
    /// 客户端打开符文界面前拉一次最新数据
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_RuneInfoHandler : MessageLocationHandler<Unit, C2M_RuneInfoRequest, M2C_RuneInfoResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RuneInfoRequest request, M2C_RuneInfoResponse response)
        {
            RuneComponent runeComponent = unit.GetComponent<RuneComponent>();

            response.Info = runeComponent.GetInfo();
            await ETTask.CompletedTask;
        }
    }
}
