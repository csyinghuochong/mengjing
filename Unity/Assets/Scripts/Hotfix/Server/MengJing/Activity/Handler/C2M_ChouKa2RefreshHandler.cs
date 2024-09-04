namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ChouKa2RefreshHandler : MessageLocationHandler<Unit, C2M_ChouKa2RefreshRequest, M2C_ChouKa2RefreshResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ChouKa2RefreshRequest request, M2C_ChouKa2RefreshResponse response)
        {
            ActivityComponentS activityComponent = unit.GetComponent <ActivityComponentS>();

            activityComponent.ActivityV1Info.ChouKa2ItemList = ActivityConfigHelper.GetChouKa2RewardList();
            activityComponent.ActivityV1Info.ChouKa2RewardIds.Clear();
            response.ActivityV1InfoProto = activityComponent.ActivityV1Info.ToMessage();
            await ETTask.CompletedTask;
        }
    }
}
