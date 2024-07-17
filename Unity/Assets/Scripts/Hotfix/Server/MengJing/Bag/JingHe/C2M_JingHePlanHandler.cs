namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JingHePlanHandler : MessageLocationHandler<Unit, C2M_JingHePlanRequest, M2C_JingHePlanResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JingHePlanRequest request, M2C_JingHePlanResponse response)
        {
            unit.GetComponent<BagComponentS>().SeasonJingHePlan = request.JingHePlan;
            await ETTask.CompletedTask;
        }
    }
}
