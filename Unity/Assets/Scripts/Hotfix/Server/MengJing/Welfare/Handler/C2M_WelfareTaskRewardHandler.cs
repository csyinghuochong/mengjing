namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_WelfareTaskRewardHandler : MessageLocationHandler<Unit, C2M_WelfareTaskRewardRequest, M2C_WelfareTaskRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_WelfareTaskRewardRequest request, M2C_WelfareTaskRewardResponse response)
        {
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();   
            bool canget = TaskHelper.IsDayTaskComplete(taskComponent.RoleComoleteTaskList, request.day);
            if (!canget)
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.WelfareTaskRewards.Contains(request.day))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            string reward = ConfigData.WelfareTaskReward[request.day];
            if (!unit.GetComponent<BagComponentS>().OnAddItemData(reward, $"{ItemGetWay.Welfare}_{TimeHelper.ServerNow()}"))
            { 
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            unit.GetComponent<UserInfoComponentS>().UserInfo.WelfareTaskRewards.Add(request.day);
            
            await ETTask.CompletedTask;
        }
    }
}
