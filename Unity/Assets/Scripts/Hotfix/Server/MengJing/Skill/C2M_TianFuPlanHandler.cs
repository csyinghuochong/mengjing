namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TianFuPlanHandler : MessageLocationHandler<Unit, C2M_TianFuPlanRequest, M2C_TianFuPlanResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TianFuPlanRequest request, M2C_TianFuPlanResponse response)
        { 
            SkillSetComponentServer skillSetComponent = unit.GetComponent<SkillSetComponentServer>();
            skillSetComponent.UpdateTianFuPlan ( request.TianFuPlan);  
            await ETTask.CompletedTask;
        }
    }
}