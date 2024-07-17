namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_SeasonOpenJingHeHandler : MessageLocationHandler<Unit, C2M_SeasonOpenJingHeRequest, M2C_SeasonOpenJingHeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SeasonOpenJingHeRequest request, M2C_SeasonOpenJingHeResponse response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();   
            if (userInfoComponent.UserInfo.OpenJingHeIds.Contains(request.JingHeId))
            {
                response.Error = ErrorCode.ERR_AlreadyLearn;
                return;
            }

            if (!SeasonJingHeConfigCategory.Instance.Contain(request.JingHeId))
            {
                Log.Error($"C2M_SeasonLevelRewardRequest 4");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            SeasonJingHeConfig seasonJingHeConfig = SeasonJingHeConfigCategory.Instance.Get(request.JingHeId);
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();  
            if (!bagComponent.CheckCostItem(seasonJingHeConfig.Cost))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            bagComponent.OnCostItemData(seasonJingHeConfig.Cost);
            userInfoComponent.UserInfo.OpenJingHeIds.Add(request.JingHeId);
            await ETTask.CompletedTask;
        }
    }
}
