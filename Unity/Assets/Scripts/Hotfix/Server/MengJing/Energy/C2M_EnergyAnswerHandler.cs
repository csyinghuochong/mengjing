namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_EnergyAnswerHandler : MessageLocationHandler<Unit, C2M_EnergyAnswerRequest, M2C_EnergyAnswerResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_EnergyAnswerRequest request, M2C_EnergyAnswerResponse response)
        {
            if (unit.Zone() != 0)
            {
                Log.Error($"C2M_EnergyAnswerRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            EnergyComponentS energyComponent = unit.GetComponent<EnergyComponentS>();
            energyComponent.QuestionIndex++;
            if (request.AnswerIndex == 1)
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(15);
                unit.GetComponent<BagComponentS>().OnAddItemData(globalValueConfig.Value, $"{ItemGetWay.Energy}_{TimeHelper.ServerNow()}");
            }
            
            await ETTask.CompletedTask;
        }
    }
}
