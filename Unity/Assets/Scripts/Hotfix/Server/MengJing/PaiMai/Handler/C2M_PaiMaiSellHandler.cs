namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PaiMaiSellHandler : MessageLocationHandler<Unit, C2M_PaiMaiSellRequest, M2C_PaiMaiSellResponse>
    {

		protected override async ETTask Run(Unit unit, C2M_PaiMaiSellRequest request, M2C_PaiMaiSellResponse response)
		{
			using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Sell, unit.Id))
			{
				if (request.PaiMaiItemInfo.BagInfo.ItemNum <= 0)
                {
                    Log.Error($"C2M_PaiMaiSellRequest 1");
                    response.Error = ErrorCode.ERR_ModifyData;
					return;
				}
				long allprice = request.PaiMaiItemInfo.BagInfo.ItemNum * request.PaiMaiItemInfo.Price;
                if (allprice > 1000000 || allprice < 0)
                {
                    Log.Error($"C2M_PaiMaiSellRequest 2");
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                //获取时间戳
                long currentTime = TimeHelper.ServerNow();

                //获取出售数据
                long paimaiItemId = IdGenerater.Instance.GenerateId();
				request.PaiMaiItemInfo.Id = paimaiItemId;

                request.PaiMaiItemInfo.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
				request.PaiMaiItemInfo.UserId = unit.GetComponent<UserInfoComponentS>().UserInfo.UserId;
                request.PaiMaiItemInfo.Account = unit.GetComponent<UserInfoComponentS>().Account;
				request.PaiMaiItemInfo.SellTime = currentTime;

				//对比出售数量和道具是否匹配
				long bagInfoId = request.PaiMaiItemInfo.BagInfo.BagInfoID;
				ItemInfo bagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoId);
				if (bagInfo == null)
				{
					response.Error = ErrorCode.ERR_ItemNotEnoughError;      //道具不足
					return;
				}
				if (bagInfo.ItemNum < request.PaiMaiItemInfo.BagInfo.ItemNum)
				{
					response.Error = ErrorCode.ERR_ItemNotEnoughError;      //道具不足
					return;
				}

				//判断道具是否可以上架和绑定
				ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
				if (itemConfig.IfStopPaiMai == 1) 
				{
					response.Error = ErrorCode.Err_StopPaiMai;      //道具无法上架
					return;
				}
				if (bagInfo.isBinging) 
				{
					response.Error = ErrorCode.ERR_ItemBing;      //道具绑定
					return;
				}

				long gold = (long)request.PaiMaiItemInfo.BagInfo.ItemNum * request.PaiMaiItemInfo.Price;
				if (gold < 0)
                {
                    Log.Error($"C2M_PaiMaiSellRequest 3");
                    response.Error = ErrorCode.ERR_ModifyData;
					return;
				}

				//发送对应拍卖行信息
				ActorId paimaiServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "PaiMai").ActorId;
				M2P_PaiMaiSellRequest M2P_PaiMaiSellRequest = M2P_PaiMaiSellRequest.Create();
				M2P_PaiMaiSellRequest.UnitID = unit.Id;
				M2P_PaiMaiSellRequest.PaiMaiItemInfo = request.PaiMaiItemInfo;
				M2P_PaiMaiSellRequest.PaiMaiTodayGold = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.PaiMaiTodayGold);
				P2M_PaiMaiSellResponse r_GameStatusResponse = (P2M_PaiMaiSellResponse)await unit.Root().GetComponent<MessageSender>().Call
					(paimaiServerId,M2P_PaiMaiSellRequest);

				if (r_GameStatusResponse.Error == ErrorCode.ERR_Success)
				{
					//扣除对应道具
					unit.GetComponent<BagComponentS>().OnCostItemData(request.PaiMaiItemInfo.BagInfo.BagInfoID, request.PaiMaiItemInfo.BagInfo.ItemNum);
					unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.PaiMaiSell_1015, 0, 1);
					response.PaiMaiItemInfo = request.PaiMaiItemInfo;
					ServerLogHelper.LogWarning(response.PaiMaiItemInfo.PlayerName + "上架道具：" + request.PaiMaiItemInfo.BagInfo.ItemID + "数量" + request.PaiMaiItemInfo.BagInfo.ItemNum + "时间戳:" + currentTime.ToString(), true);
                }
                response.Error = r_GameStatusResponse.Error;
				await ETTask.CompletedTask;
			}
		}
	}
}
