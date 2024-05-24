﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{

    [ActorMessageHandler]
    public class C2M_FirstWinSelfRewardHandler : AMActorLocationRpcHandler<Unit, C2M_FirstWinSelfRewardRequest, M2C_FirstWinSelfRewardResponse>
    {
		protected override async ETTask Run(Unit unit, C2M_FirstWinSelfRewardRequest request, M2C_FirstWinSelfRewardResponse response, Action reply)
		{
			if (!FirstWinConfigCategory.Instance.Contain(request.FirstWinId))
			{
				response.Error = ErrorCode.ERR_NetWorkError;
				reply();
				return;
			}

			
			string rewardlist = string.Empty;
			FirstWinConfig firstWinConfig = FirstWinConfigCategory.Instance.Get(request.FirstWinId);
			switch (request.Difficulty)
			{
				case 1:
					rewardlist = firstWinConfig.Self_RewardList_1;
					break;
				case 2:
					rewardlist = firstWinConfig.Self_RewardList_2;
					break;
				case 3:
					rewardlist = firstWinConfig.Self_RewardList_3;
					break;
				default:
					rewardlist = firstWinConfig.Self_RewardList_1;
					break;
			}
			string[] rewarditemlist = rewardlist.Split('@');
			if (unit.GetComponent<BagComponent>().GetBagLeftCell() < rewarditemlist.Length)
			{
				response.Error = ErrorCode.ERR_BagIsFull;
				reply();
				return;
			}

			int errorcode = unit.GetComponent<UserInfoComponent>().OnGetFirstWinSelf(request.FirstWinId, request.Difficulty);
			if (errorcode != ErrorCode.ERR_Success)
			{
				response.Error = errorcode;
				reply();
				return;
			}

			unit.GetComponent<BagComponent>().OnAddItemData(rewardlist, $"{ItemGetWay.FirstWin}_{TimeHelper.ServerNow()}");
			response.FirstWinInfos = unit.GetComponent<UserInfoComponent>().UserInfo.FirstWinSelf;
			reply();
			await ETTask.CompletedTask;
		}
	}
}
