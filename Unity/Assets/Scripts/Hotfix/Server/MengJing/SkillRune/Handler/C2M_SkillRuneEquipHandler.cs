namespace ET.Server
{
    /// <summary>
    /// 镶嵌技能符文：把背包里的符文装到某个主动技能的指定孔位。
    /// 响应里带回最新的技能符文数据
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_SkillRuneEquipHandler : MessageLocationHandler<Unit, C2M_SkillRuneEquipRequest, M2C_SkillRuneEquipResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillRuneEquipRequest request, M2C_SkillRuneEquipResponse response)
        {
            SkillRuneComponent skillRuneComponent = unit.GetComponent<SkillRuneComponent>();

            response.Error = skillRuneComponent.OnEquipRune(request.SkillId, request.SlotIndex, request.RuneId);
            skillRuneComponent.ToMessage(response.RuneList, response.SlotList);
            await ETTask.CompletedTask;
        }
    }
}
