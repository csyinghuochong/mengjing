﻿using System;
using System.Collections.Generic;

namespace ET
{
    [ActorMessageHandler]
    public class C2M_RealNameRewardHandler : AMActorLocationRpcHandler<Unit, C2M_RealNameRewardRequest, M2C_RealNameRewardResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_RealNameRewardRequest request, M2C_RealNameRewardResponse response, Action reply)
        {
            long accid = unit.GetComponent<UserInfoComponent>().UserInfo.AccInfoID;
            long dbCacheId = DBHelper.GetDbCacheId(unit.DomainZone());

            string globalValueConfig = GlobalValueConfigCategory.Instance.Get(6).Value;
            string[] itemCost = globalValueConfig.Split('@');
            List<RewardItem> rewardItems = new List<RewardItem>();
            for (int i = 0; i < itemCost.Length; i++)
            {
                string[] itemInfo = itemCost[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                rewardItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            bool sucess = unit.GetComponent<BagComponent>().OnAddItemData(rewardItems, string.Empty, string.Empty);
            response.Error = sucess ? ErrorCode.ERR_Success : ErrorCode.ERR_BagIsFull;

            reply();
            await ETTask.CompletedTask;
        }
    }
}
