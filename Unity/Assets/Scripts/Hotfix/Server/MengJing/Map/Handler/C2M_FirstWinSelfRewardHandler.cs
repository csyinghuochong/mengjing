namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_FirstWinSelfRewardHandler : MessageLocationHandler<Unit, C2M_FirstWinSelfRewardRequest, M2C_FirstWinSelfRewardResponse>
    {
		protected override async ETTask Run(Unit unit, C2M_FirstWinSelfRewardRequest request, M2C_FirstWinSelfRewardResponse response)
		{
			if (!FirstWinConfigCategory.Instance.Contain(request.FirstWinId))
			{
				response.Error = ErrorCode.ERR_NetWorkError;
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
			if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < rewarditemlist.Length)
			{
				response.Error = ErrorCode.ERR_BagIsFull;
				return;
			}

			int errorcode = unit.GetComponent<UserInfoComponentS>().OnGetFirstWinSelf(request.FirstWinId, request.Difficulty);
			if (errorcode != ErrorCode.ERR_Success)
			{
				response.Error = errorcode;
				return;
			}

			unit.GetComponent<BagComponentS>().OnAddItemData(rewardlist, $"{ItemGetWay.FirstWin}_{TimeHelper.ServerNow()}");
			response.FirstWinInfos .AddRange(unit.GetComponent<UserInfoComponentS>().UserInfo.FirstWinSelf); 

			await ETTask.CompletedTask;
		}
	}
}
