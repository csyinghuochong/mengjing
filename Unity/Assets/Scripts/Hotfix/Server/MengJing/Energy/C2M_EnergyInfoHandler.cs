namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_EnergyInfoHandler : MessageLocationHandler<Unit, C2M_EnergyInfoRequest, M2C_EnergyInfoResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_EnergyInfoRequest request, M2C_EnergyInfoResponse response)
        {
            response.GetRewards .AddRange( unit.GetComponent<EnergyComponentS>().GetRewards);
            response.QuestionList .AddRange(  unit.GetComponent<EnergyComponentS>().QuestionList);
            response.QuestionIndex =  unit.GetComponent<EnergyComponentS>().QuestionIndex;
            
            await ETTask.CompletedTask;
        }
    }
}
