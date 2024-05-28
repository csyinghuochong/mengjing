﻿using System;
using System.Collections.Generic;

namespace ET
{

    [ActorMessageHandler]
    public class C2M_JiaYuanMysteryBuyHandler : AMActorLocationRpcHandler<Unit, C2M_JiaYuanMysteryBuyRequest, M2C_JiaYuanMysteryBuyResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanMysteryBuyRequest request, M2C_JiaYuanMysteryBuyResponse response, Action reply)
        {
            int mysteryId = request.MysteryId;

            if (!MysteryConfigCategory.Instance.Contain(mysteryId))
            {
                Log.Error($"C2M_JiaYuanMysteryBuyRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                reply();
                return;
            }

            MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryId);
            if (mysteryConfig == null)
            {
                response.Error = ErrorCode.ERR_NetWorkError;
                reply();
                return;
            }

            if (!unit.GetComponent<BagComponent>().CheckCostItem($"{mysteryConfig.SellType};{mysteryConfig.SellValue}"))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                reply();
                return;
            }

            if (request.ProductId != -1)
            {
                List<MysteryItemInfo> jiayuanList = new List<MysteryItemInfo>();
                if (unit.GetComponent<JiaYuanComponent>().NowOpenNpcId == 30000001)
                {
                    jiayuanList = unit.GetComponent<JiaYuanComponent>().PlantGoods_7;
                }

                if (unit.GetComponent<JiaYuanComponent>().NowOpenNpcId == 30000013)
                {
                    jiayuanList = unit.GetComponent<JiaYuanComponent>().JiaYuanStore;
                }

                int errorCode = unit.GetComponent<JiaYuanComponent>().OnMysteryBuyRequest(request.ProductId, jiayuanList);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    response.Error = errorCode;
                    reply();
                    return;
                }
                response.MysteryItemInfos = jiayuanList;
            }
            //unit.GetComponent<UserInfoComponent>().OnMysteryBuy(mysteryId);
            //扣除货币添加对应道具
            unit.GetComponent<BagComponent>().OnCostItemData($"{mysteryConfig.SellType};{mysteryConfig.SellValue}");
            unit.GetComponent<BagComponent>().OnAddItemData($"{mysteryConfig.SellItemID};1",
                $"{ItemGetWay.MysteryBuy}_{TimeHelper.ServerNow()}");
            
            reply();
            await ETTask.CompletedTask;
        }
    }
}
