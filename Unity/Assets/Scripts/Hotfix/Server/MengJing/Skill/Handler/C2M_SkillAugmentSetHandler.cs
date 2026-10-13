namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SkillAugmentSetHandler : MessageLocationHandler<Unit, C2M_SkillAugmentSetRequest, M2C_SkillAugmentSetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillAugmentSetRequest request, M2C_SkillAugmentSetResponse response)
        {
            SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();
            response.Error = skillSetComponent.SetSkillAugment(request.BaseSkillId, request.TierIndex, request.AugmentId);
            if (response.Error == ErrorCode.ERR_Success)
            {
                response.SkillAugmentInfo = skillSetComponent.SkillAugmentList.Find( info => info.BaseSkillId == request.BaseSkillId);
            }

            await ETTask.CompletedTask;
        }
    }
}
