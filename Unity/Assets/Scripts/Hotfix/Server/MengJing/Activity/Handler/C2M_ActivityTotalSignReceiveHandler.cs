namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_ActivityTotalSignReceiveHandler : MessageLocationHandler<Unit, C2M_ActivityTotalSignReceiveRequest,
        M2C_ActivityTotalSignReceiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ActivityTotalSignReceiveRequest request, M2C_ActivityTotalSignReceiveResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Received, unit.Id))
            {
                ActivityComponentS activityComponent = unit.GetComponent<ActivityComponentS>();

                if (request.Type == 0) // 免费
                {
                    if (!ConfigData.TotalSignRewards.ContainsKey(request.Day))
                    {
                        response.Error = ErrorCode.ERR_ModifyData;
                        return;
                    }

                    if (activityComponent.TotalSignRewardsList.Contains(request.Day))
                    {
                        response.Error = ErrorCode.ERR_AlreadyReceived;
                        return;
                    }

                    if (activityComponent.TotalSignNumber < request.Day)
                    {
                        response.Error = ErrorCode.ERR_ModifyData;
                        return;
                    }

                    string[] rewarditems = ConfigData.TotalSignRewards[request.Day].Split('@');
                    if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                    {
                        response.Error = ErrorCode.ERR_BagIsFull;
                        return;
                    }

                    activityComponent.TotalSignRewardsList.Add(request.Day);
                    unit.GetComponent<BagComponentS>().OnAddItemData(ConfigData.TotalSignRewards[request.Day],
                        $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                }
                else if (request.Type == 1) // VIP
                {
                    if (!ConfigData.TotalSignRewards_VIP.ContainsKey(request.Day))
                    {
                        response.Error = ErrorCode.ERR_ModifyData;
                        return;
                    }

                    if (activityComponent.TotalSignRewardsList_VIP.Contains(request.Day))
                    {
                        response.Error = ErrorCode.ERR_AlreadyReceived;
                        return;
                    }

                    if (activityComponent.TotalSignNumber_VIP < request.Day)
                    {
                        response.Error = ErrorCode.ERR_ModifyData;
                        return;
                    }

                    string[] rewarditems = ConfigData.TotalSignRewards_VIP[request.Day].Split('@');
                    if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                    {
                        response.Error = ErrorCode.ERR_BagIsFull;
                        return;
                    }

                    activityComponent.TotalSignRewardsList_VIP.Add(request.Day);
                    unit.GetComponent<BagComponentS>().OnAddItemData(ConfigData.TotalSignRewards_VIP[request.Day],
                        $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                }
            }

            await ETTask.CompletedTask;
        }
    }
}