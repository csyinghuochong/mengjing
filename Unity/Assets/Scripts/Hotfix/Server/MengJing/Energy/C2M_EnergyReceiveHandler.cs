namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_EnergyReceiveHandler : MessageLocationHandler<Unit, C2M_EnergyReceiveRequest, M2C_EnergyReceiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_EnergyReceiveRequest request, M2C_EnergyReceiveResponse response)
        {
            if (unit.Zone() != 3)
            {
                Log.Error($"C2M_EnergyReceiveRequest.1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            EnergyComponentS energyComponent = unit.GetComponent<EnergyComponentS>();
            if (request.RewardType < 0 || request.RewardType >= energyComponent.GetRewards.Count)
            {
                Log.Error($"C2M_EnergyReceiveRequest.2");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            if (energyComponent.GetRewards[request.RewardType] == 1)
            {
                Log.Error($"C2M_EnergyReceiveRequest.3");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            //0 早起  1早睡 2 答题
            if (request.RewardType == 1 && !energyComponent.EarlySleepReward)
            {
                Log.Error($"C2M_EnergyReceiveRequest.4");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            unit.GetComponent<EnergyComponentS>().GetRewards[request.RewardType] = 1;

            string rewardItems = "";
            if (request.RewardType == 0)
                rewardItems = GlobalValueConfigCategory.Instance.Get(13).Value;
            else if (request.RewardType == 1)
                rewardItems = GlobalValueConfigCategory.Instance.Get(14).Value;
            else
                rewardItems = "";

            unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, $"{ItemGetWay.Energy}_{TimeHelper.ServerNow()}");
            await ETTask.CompletedTask;
        }

    }
}
