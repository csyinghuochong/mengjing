namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SeasonDonateHandler : MessageLocationHandler<Unit, C2M_SeasonDonateRequest, M2C_SeasonDonateResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_SeasonDonateRequest request, M2C_SeasonDonateResponse response)
        {
            
            
            await ETTask.CompletedTask;
        }
    }
}
