﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{

    [ActorMessageHandler]
    public  class C2M_PaiMaiShopHandler : AMActorLocationRpcHandler<Unit, C2M_PaiMaiShopRequest, M2C_PaiMaiShopResponse>
    {
		//拍卖快捷列表购买道具
		protected override async ETTask Run(Unit unit, C2M_PaiMaiShopRequest request, M2C_PaiMaiShopResponse response, Action reply)
		{
			if(!PaiMaiSellConfigCategory.Instance.Contain(request.PaiMaiId))
			{
                response.Error = ErrorCode.ERR_ItemNotExist;
                reply();
                return;
            }

			PaiMaiSellConfig paiMaiSellConfig = PaiMaiSellConfigCategory.Instance.Get(request.PaiMaiId);
			if (paiMaiSellConfig == null)
			{
				response.Error = ErrorCode.ERR_NetWorkError;
				reply();
				return;
			}

			ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiSellConfig.ItemID);
			int cell = Mathf.CeilToInt(request.BuyNum * 1f / itemConfig.ItemPileSum);
			if (unit.GetComponent<BagComponent>().GetBagLeftCell() < cell)
			{
				response.Error = ErrorCode.ERR_BagIsFull;
				reply();
				return;
			}
			if (request.BuyNum < 0 || request.BuyNum > 1000)
			{
				response.Error = ErrorCode.ERR_MysteryItem_Max;
				reply();
				return;
			}

            Log.Warning($"拍卖行购买请求 : {unit.Id}  {paiMaiSellConfig.ItemID}  {request.BuyNum}  {cell}");

            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.Buy, unit.Id))
			{

				M2P_PaiMaiShopRequest m2P_PaiMaiShopRequest = new M2P_PaiMaiShopRequest()
				{
					ItemID = paiMaiSellConfig.ItemID,
					BuyNum = request.BuyNum,
					//Price = r_PaiMaiShopResponse.PaiMaiShopItemInfo.Price,
					ActorId = unit.GetComponent<UserInfoComponent>().UserInfo.Gold,
				};

				long paimaiServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), Enum.GetName(SceneType.PaiMai)).InstanceId;
				P2M_PaiMaiShopResponse r_PaiMaiShopResponse = (P2M_PaiMaiShopResponse)await ActorMessageSenderComponent.Instance.Call(paimaiServerId, m2P_PaiMaiShopRequest);

				if (r_PaiMaiShopResponse.Error != ErrorCode.ERR_Success)
				{
					response.Error = r_PaiMaiShopResponse.Error;
					reply();
					return;
				}

				//消耗金币
				long costGold = (long)r_PaiMaiShopResponse.PaiMaiShopItemInfo.Price * request.BuyNum;
				if (costGold > 0 && unit.GetComponent<UserInfoComponent>().UserInfo.Gold >= costGold)
				{
					//发送金币
					unit.GetComponent<UserInfoComponent>().UpdateRoleMoneySub(UserDataType.Gold, (costGold * -1).ToString(), true, ItemGetWay.PaiMaiShop);

					//添加道具
					List<RewardItem> rewardItems = new List<RewardItem>();
					rewardItems.Add(new RewardItem() { ItemID = paiMaiSellConfig.ItemID, ItemNum = request.BuyNum });
					bool result =  unit.GetComponent<BagComponent>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PaiMaiShop}_{TimeHelper.ServerNow()}");
					Log.Warning($"拍卖行购买道具 : {unit.Id}  {paiMaiSellConfig.ItemID}  {request.BuyNum}  {r_PaiMaiShopResponse.PaiMaiShopItemInfo.Price} {cell} {result}");
				}
				else
				{
					response.Error = ErrorCode.ERR_GoldNotEnoughError;
				}
			}
			reply();
			await ETTask.CompletedTask;
		}

	}
}
