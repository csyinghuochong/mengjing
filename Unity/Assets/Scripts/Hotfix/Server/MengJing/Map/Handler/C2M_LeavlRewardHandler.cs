namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_LeavlRewardHandler: MessageLocationHandler<Unit, C2M_LeavlRewardRequest, M2C_LeavlRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_LeavlRewardRequest request, M2C_LeavlRewardResponse response)
        {
            if (!ConfigData.LeavlRewardItem.Keys.Contains(request.LvKey))
            {
                Log.Error($"C2M_LeavlRewardRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.LeavlReward) >= request.LvKey)
            {
                response.Error = ErrorCode.ERR_Parameter;
                return;
            }

            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Lv < request.LvKey)
            {
                Log.Error($"C2M_LeavlRewardRequest 3");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            string[] occItems = ConfigData.LeavlRewardItem[request.LvKey].Split('&');
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
                Log.Error($"C2M_LeavlRewardRequest 4");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            string item = items[request.Index];
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.LeavlReward, request.LvKey);
            unit.GetComponent<BagComponentS>().OnAddItemData(item, $"{ItemGetWay.LeavlReward}_{TimeHelper.ServerNow()}");
            await ETTask.CompletedTask;
        }
    }
}