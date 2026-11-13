namespace ET.Server
{
    /// <summary>
    /// 客户端打开技能符文界面/登录时拉一次最新的技能符文数据
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_SkillRuneInfoHandler : MessageLocationHandler<Unit, C2M_SkillRuneInfoRequest, M2C_SkillRuneInfoResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillRuneInfoRequest request, M2C_SkillRuneInfoResponse response)
        {
            SkillRuneComponent skillRuneComponent = unit.GetComponent<SkillRuneComponent>();

            skillRuneComponent.ToMessage(response.RuneList, response.SlotList);
            await ETTask.CompletedTask;
        }
    }
}
