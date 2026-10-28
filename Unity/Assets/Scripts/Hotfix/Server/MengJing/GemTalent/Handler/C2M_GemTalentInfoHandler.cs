namespace ET.Server
{
    /// <summary>
    /// 客户端打开宝石天赋界面前拉一次最新数据：激活状态是关键，历史最大点数也要顺带刷新
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_GemTalentInfoHandler : MessageLocationHandler<Unit, C2M_GemTalentInfoRequest, M2C_GemTalentInfoResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GemTalentInfoRequest request, M2C_GemTalentInfoResponse response)
        {
            GemTalentComponent gemTalentComponent = unit.GetComponent<GemTalentComponent>();

            gemTalentComponent.UpdateMaxPoint();
            response.Info = gemTalentComponent.GetInfo();
            await ETTask.CompletedTask;
        }
    }
}
