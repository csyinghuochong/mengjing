namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TalentReSetHandler : MessageLocationHandler<Unit, C2M_TalentReSetRequest, M2C_TalentReSetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TalentReSetRequest request, M2C_TalentReSetResponse response)
        {
            UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            SkillSetComponentS skillSetComponentS = unit.GetComponent<SkillSetComponentS>();

            if (!unit.GetComponent<BagComponentS>().OnCostItemData(GlobalValueConfigCategory.Instance.Get(139).Value))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            skillSetComponentS.TianFuReSet();

            await ETTask.CompletedTask;
        }
    }
}