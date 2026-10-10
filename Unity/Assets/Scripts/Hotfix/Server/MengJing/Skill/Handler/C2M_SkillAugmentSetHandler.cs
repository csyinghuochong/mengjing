namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SkillAugmentSetHandler : MessageLocationHandler<Unit, C2M_SkillAugmentSetRequest, M2C_SkillAugmentSetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillAugmentSetRequest request, M2C_SkillAugmentSetResponse response)
        {
            response.Error = unit.GetComponent<SkillSetComponentS>().SetSkillAugment(request.BaseSkillId, request.SocketIndex, request.AugmentId);
            await ETTask.CompletedTask;
        }
    }
}
