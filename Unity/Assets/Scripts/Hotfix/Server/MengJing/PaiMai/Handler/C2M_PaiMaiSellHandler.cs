﻿using System;

namespace ET
{
    [ActorMessageHandler]
    public class C2M_PaiMaiSellHandler : AMActorLocationRpcHandler<Unit, C2M_PaiMaiSellRequest, M2C_PaiMaiSellResponse>
    {

		protected override async ETTask Run(Unit unit, C2M_PaiMaiSellRequest request, M2C_PaiMaiSellResponse response, Action reply)
		{
			using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.Sell, unit.Id))
			{
				if (request.PaiMaiItemInfo.BagInfo.ItemNum <= 0)
                {
                    Log.Error($"C2M_PaiMaiSellRequest 1");
                    response.Error = ErrorCode.ERR_ModifyData;
                    reply();
					return;
				}
				long allprice = request.PaiMaiItemInfo.BagInfo.ItemNum * request.PaiMaiItemInfo.Price;
                if (allprice > 10000000 || allprice < 0)
                {
                    Log.Error($"C2M_PaiMaiSellRequest 2");
                    response.Error = ErrorCode.ERR_ModifyData;
                    reply();
                    return;
                }

				//if (allprice + unit.GetComponent<DataCollationComponent>().PaiMaiTodayGold >= 50000000)
				//{
    //                response.Error = ErrorCode.ERR_PaiMaiSellLimit;
    //                reply();
    //                return;
    //            }

                //获取时间戳
                long currentTime = TimeHelper.ServerNow();

                //获取出售数据
                long paimaiItemId = IdGenerater.Instance.GenerateId();
				request.PaiMaiItemInfo.Id = paimaiItemId;

                request.PaiMaiItemInfo.PlayerName = unit.GetComponent<UserInfoComponent>().UserInfo.Name;
				request.PaiMaiItemInfo.UserId = unit.GetComponent<UserInfoComponent>().UserInfo.UserId;
                request.PaiMaiItemInfo.Account = unit.GetComponent<UserInfoComponent>().Account;
				request.PaiMaiItemInfo.SellTime = currentTime;

				//对比出售数量和道具是否匹配
				long bagInfoId = request.PaiMaiItemInfo.BagInfo.BagInfoID;
				BagInfo bagInfo = unit.GetComponent<BagComponent>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoId);
				if (bagInfo == null)
				{
					response.Error = ErrorCode.ERR_ItemNotEnoughError;      //道具不足
					reply();
					return;
				}
				if (bagInfo.ItemNum < request.PaiMaiItemInfo.BagInfo.ItemNum)
				{
					response.Error = ErrorCode.ERR_ItemNotEnoughError;      //道具不足
					reply();
					return;
				}

				//判断道具是否可以上架和绑定
				ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
				if (itemConfig.IfStopPaiMai == 1) 
				{
					response.Error = ErrorCode.Err_StopPaiMai;      //道具无法上架
					reply();
					return;
				}
				if (bagInfo.isBinging) 
				{
					response.Error = ErrorCode.ERR_ItemBing;      //道具绑定
					reply();
					return;
				}

				long gold = (long)request.PaiMaiItemInfo.BagInfo.ItemNum * request.PaiMaiItemInfo.Price;
				if (gold < 0)
                {
                    Log.Error($"C2M_PaiMaiSellRequest 3");
                    response.Error = ErrorCode.ERR_ModifyData;
                    reply();
					return;
				}

				//发送对应拍卖行信息
				long paimaiServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), Enum.GetName(SceneType.PaiMai)).InstanceId;
				P2M_PaiMaiSellResponse r_GameStatusResponse = (P2M_PaiMaiSellResponse)await ActorMessageSenderComponent.Instance.Call
					(paimaiServerId, new M2P_PaiMaiSellRequest()
					{
						UnitID = unit.Id,
						PaiMaiItemInfo = request.PaiMaiItemInfo,
						PaiMaiTodayGold = unit.GetComponent<NumericComponent>().GetAsLong(NumericType.PaiMaiTodayGold),
					});

				if (r_GameStatusResponse.Error == ErrorCode.ERR_Success)
				{
					//扣除对应道具
					unit.GetComponent<BagComponent>().OnCostItemData(request.PaiMaiItemInfo.BagInfo.BagInfoID, request.PaiMaiItemInfo.BagInfo.ItemNum);
					unit.GetComponent<TaskComponent>().TriggerTaskCountryEvent(TaskTargetType.PaiMaiSell_1015, 0, 1);
					response.PaiMaiItemInfo = request.PaiMaiItemInfo;
					LogHelper.LogWarning(response.PaiMaiItemInfo.PlayerName + "上架道具：" + request.PaiMaiItemInfo.BagInfo.ItemID + "数量" + request.PaiMaiItemInfo.BagInfo.ItemNum + "时间戳:" + currentTime.ToString(), true);
                }
                response.Error = r_GameStatusResponse.Error;
				reply();
				await ETTask.CompletedTask;
			}
		}
	}
}
