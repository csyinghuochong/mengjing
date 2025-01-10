namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleeFubenRewardHandler : MessageLocationHandler<Unit, C2M_PetMeleeFubenRewardRequest, M2C_PetMeleeFubenRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleeFubenRewardRequest request, M2C_PetMeleeFubenRewardResponse response)
        {
            if (!PetMeleeFubenRewardConfigCategory.Instance.Contain(request.Id))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            int totalStar = petComponentS.GetPetMeleeTotalStar();
            PetMeleeFubenRewardConfig rewardConfig = PetMeleeFubenRewardConfigCategory.Instance.Get(request.Id);

            if (petComponentS.PetMeleeFubeRewardIds.Contains(request.Id))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            if (rewardConfig.NeedStar > totalStar)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            unit.GetComponent<BagComponentS>().OnAddItemData(rewardConfig.RewardItems, $"{ItemGetWay.PetMeleeReward}_{TimeHelper.ServerNow()}");
            unit.GetComponent<PetComponentS>().PetMeleeFubeRewardIds.Add(request.Id);

            await ETTask.CompletedTask;
        }
    }
}