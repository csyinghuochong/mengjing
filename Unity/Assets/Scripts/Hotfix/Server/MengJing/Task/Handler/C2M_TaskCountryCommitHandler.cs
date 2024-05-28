using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskCountryCommitHandler : MessageLocationHandler<Unit, C2M_CommitTaskCountryRequest, M2C_CommitTaskCountryResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_CommitTaskCountryRequest request, M2C_CommitTaskCountryResponse response)
        {
            if (!TaskCountryConfigCategory.Instance.Contain(request.TaskId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            TaskCountryConfig taskCountryConfig = TaskCountryConfigCategory.Instance.Get(request.TaskId);
            int itemItem = taskCountryConfig.RewardItem.Split('@').Length;
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell() < itemItem)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            int errorCode = ErrorCode.ERR_Success;
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
            TaskPro taskPro = null;
            for (int i = 0; i < taskComponent.TaskCountryList.Count; i++)
            {
                if (taskComponent.TaskCountryList[i].taskID != request.TaskId)
                {
                    continue;
                }

                taskPro = taskComponent.TaskCountryList[i];
                break;
            }

            if (taskPro == null)
            {
                response.Error = ErrorCode.ERR_TaskCommited;
                return;
            }
            if (taskPro.taskStatus == (int)TaskStatuEnum.Commited)
            {
                response.Error = ErrorCode.ERR_TaskCommited;
                return;
            }

            int checkError = unit.GetComponent<TaskComponentS>().CheckGiveItemTask(taskCountryConfig.TargetType, taskCountryConfig.Target, taskCountryConfig.TargetValue, request.BagInfoID, taskPro);
            if (checkError != ErrorCode.ERR_Success)
            {
                response.Error = checkError;
                return;
            }

            taskPro.taskStatus = (int)TaskStatuEnum.Commited;
            if (errorCode != ErrorCode.ERR_Success)
            {
                response.Error = errorCode;
                return;
            }

            unit.GetComponent<BagComponentS>().OnAddItemData(taskCountryConfig.RewardItem, $"{ItemGetWay.TaskCountry}_{TimeHelper.ServerNow()}");

            if (taskCountryConfig.RewardGold > 0)
            {
                //添加金币
                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(UserDataType.Gold, taskCountryConfig.RewardGold.ToString(), true, ItemGetWay.TaskCountry);
            }
            //添加活跃
            //unit.GetComponent<UserInfoComponent>().UpdateRoleData(UserDataType.HuoYue, taskCountryConfig.EveryTaskRewardNum.ToString());
            await ETTask.CompletedTask;
        }
    }
}
