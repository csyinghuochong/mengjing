namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_KillMonsterRewardHandler: MessageLocationHandler<Unit, C2M_KillMonsterRewardRequest, M2C_KillMonsterRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_KillMonsterRewardRequest request, M2C_KillMonsterRewardResponse response)
        {
            if (!ConfigData.KillMonsterReward.Keys.Contains(request.Key))
            {
                Log.Error($"C2M_KillMonsterRewardRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;

                return;
            }

            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.KillMonsterReward) >= request.Key)
            {
                response.Error = ErrorCode.ERR_Parameter;
                return;
            }

            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.KillMonsterNumber) < request.Key)
            {
                Log.Error($"C2M_KillMonsterRewardRequest 3");
                response.Error = ErrorCode.ERR_ModifyData;
 
                return;
            }

            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            string[] occItems = ConfigData.KillMonsterReward[request.Key].Split('&');
            string[] items;
            if (occItems.Length == 3)
            {
                items = occItems[userInfoComponent.UserInfo.Occ - 1].Split('@');
            }
            else
            {
                items = occItems[0].Split('@');
            }

            if (items.Length < request.Index + 1 || request.Index < 0)
            {
                Log.Error($"C2M_KillMonsterRewardRequest 4");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            string item = items[request.Index];
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.KillMonsterReward, request.Key);
            unit.GetComponent<BagComponentS>().OnAddItemData(item, $"{ItemGetWay.KillMonsterReward}_{TimeHelper.ServerNow()}");
            await ETTask.CompletedTask;
        }
    }
}