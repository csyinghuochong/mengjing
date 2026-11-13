namespace ET.Server
{
    /// <summary>
    /// 卸下技能符文：把某个主动技能指定孔位上的符文放回背包。
    /// 响应里带回最新的技能符文数据
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_SkillRuneUnequipHandler : MessageLocationHandler<Unit, C2M_SkillRuneUnequipRequest, M2C_SkillRuneUnequipResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillRuneUnequipRequest request, M2C_SkillRuneUnequipResponse response)
        {
            SkillRuneComponent skillRuneComponent = unit.GetComponent<SkillRuneComponent>();

            response.Error = skillRuneComponent.OnUnequipRune(request.SkillId, request.SlotIndex);
            skillRuneComponent.ToMessage(response.RuneList, response.SlotList);
            await ETTask.CompletedTask;
        }
    }
}
