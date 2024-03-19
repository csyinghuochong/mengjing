namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TianFuActiveHandler : MessageLocationHandler<Unit, C2M_TianFuActiveRequest, M2C_TianFuActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TianFuActiveRequest request, M2C_TianFuActiveResponse response)
        {
            await ETTask.CompletedTask;
            SkillSetComponentServer skillSetComponent = unit.GetComponent<SkillSetComponentServer>();
            int oldId = skillSetComponent.HaveSameTianFu(request.TianFuId);
            if (oldId != 0 && oldId != request.TianFuId)
            {
                // GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(48);
                TalentConfig talentConfig = TalentConfigCategory.Instance.Get(request.TianFuId);
                int num = 50000 + talentConfig.LearnRoseLv * 100;
                string cost = "1;" + num;
                if (!unit.GetComponent<BagComponentServer>().OnCostItemData(cost))
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
            }

            unit.GetComponent<SkillSetComponentServer>().OnActiveTianfu(request);
        }
    }
}