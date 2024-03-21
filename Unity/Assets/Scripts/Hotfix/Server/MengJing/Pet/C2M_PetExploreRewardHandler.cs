using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetExploreRewardHandler: MessageLocationHandler<Unit, C2M_PetExploreReward, M2C_PetExploreReward>
    {
        protected override async ETTask Run(Unit unit, C2M_PetExploreReward request, M2C_PetExploreReward response)
        {

            UserInfoComponentServer userInfoComponent = unit.GetComponent<UserInfoComponentServer>();
            if (userInfoComponent.GetPetExploreRewardIds().Contains(request.RewardId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            if (!ConfigData.PetExploreReward.Keys.Contains(request.RewardId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (unit.GetComponent<NumericComponentServer>().GetAsInt(NumericType.PetExploreNumber) < request.RewardId)
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }

            string[] reward = ConfigData.PetExploreReward[request.RewardId].Split('$');
            string[] items = reward[0].Split('@');
            string[] diamond = reward[1].Split(';')[1].Split(',');
            if (unit.GetComponent<BagComponentServer>().GetBagLeftCell() < items.Length)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            userInfoComponent.GetPetExploreRewardIds().Add(request.RewardId);
            int randomZuanshi = RandomHelper.RandomNumber(int.Parse(diamond[0]), int.Parse(diamond[1]));
            unit.GetComponent<BagComponentServer>().OnAddItemData(reward[0], $"{ItemGetWay.PetChouKa}_{TimeHelper.ServerNow()}");
            unit.GetComponent<UserInfoComponentServer>().UpdateRoleMoneyAdd(UserDataType.Diamond, randomZuanshi.ToString(), true, ItemGetWay.PetChouKa);
            
            await ETTask.CompletedTask;
        }
    }
}

