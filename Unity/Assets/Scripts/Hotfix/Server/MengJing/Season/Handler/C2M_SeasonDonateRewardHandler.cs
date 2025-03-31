namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_SeasonDonateRewardHandler : MessageLocationHandler<Unit, C2M_SeasonDonateRewardRequest, M2C_SeasonDonateRewardResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_SeasonDonateRewardRequest request, M2C_SeasonDonateRewardResponse response)
        {
           
            await ETTask.CompletedTask;
        }
    }
}
