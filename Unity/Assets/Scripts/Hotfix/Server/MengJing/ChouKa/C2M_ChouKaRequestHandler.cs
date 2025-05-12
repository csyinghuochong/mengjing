﻿using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ChouKaRequestHandler : MessageLocationHandler<Unit, C2M_ChouKaRequest, M2C_ChouKaResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ChouKaRequest request, M2C_ChouKaResponse response)
        {
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            // 判断背包和仓库是否能够装满
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) + bagComponent.GetChouKaLeftSpace() < request.ChouKaType)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            if (!TakeCardConfigCategory.Instance.Contain(request.ChapterId))
            {
                response.Error = ErrorCode.ERR_NetWorkError;
                return;
            }
            if (request.ChouKaType != 1 && request.ChouKaType != 10)
            {
                Log.Error($"C2M_ChouKaRequest.1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();

            int nowNum = numericComponent.GetAsInt(NumericType.ChouKa);
            int maxNum = GlobalValueConfigCategory.Instance.ChouKaLimit;
            if (nowNum + request.ChouKaType > maxNum)
            {
                response.Error = ErrorCode.ERR_TimesIsNot;
                return;
            }

            bool mianfei = false;
            long cdTime = long.Parse(GlobalValueConfigCategory.Instance.Get(request.ChouKaType == 1 ? 35:36).Value) * 1000;
            
            long lastTime = unit.GetComponent<NumericComponentS>().GetAsLong(request.ChouKaType == 1 ? NumericType.ChouKaOneTime: NumericType.ChouKaTenTime);
            mianfei = TimeHelper.ServerNow() - lastTime >= cdTime;

            TakeCardConfig takeCardConfig = TakeCardConfigCategory.Instance.Get(request.ChapterId);
            int needZuanshi = request.ChouKaType == 1 ? takeCardConfig.ZuanShiNum : takeCardConfig.ZuanShiNum_Ten;
            int totalTimes = numericComponent.GetAsInt(NumericType.ChouKa);
            if (totalTimes >= 250)
            {
                needZuanshi = (int)math.ceil(needZuanshi * 0.8f);
            }

            if (!mianfei && userInfo.Diamond < needZuanshi)
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                return;
            }

            int dropid = TakeCardConfigCategory.Instance.Get(request.ChapterId).DropID;
            List<RewardItem> droplist = new List<RewardItem>();
            for (int i = 0; i < request.ChouKaType; i++)
            {
                DropHelper.DropIDToDropItem_2(dropid, droplist);
            }
            for (int i = 0; i < droplist.Count; i++)
            {
                if (droplist[i].ItemID == 0)
                {
                    Log.Error($"抽卡[道具为0]： {unit.Id} {droplist[i].ItemID}");
                }
            }
            
            ServerLogHelper.LogWarning($"抽卡： {unit.Id} {droplist.Count}", true);
            
            // 判断背包是否能装下，不能的话剩下的放抽卡仓库
            int bagLeftSpace = bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag);
            bool addItemError = false; 
            if (bagLeftSpace < droplist.Count)
            {
                List<RewardItem> putInBag = new List<RewardItem>();
                List<RewardItem> putInChouKa = new List<RewardItem>();
                int i = 0;
                foreach (RewardItem item in droplist)
                {
                    if (i < bagLeftSpace)
                    {
                        putInBag.Add(item);
                    }
                    else
                    {
                        putInChouKa.Add(item);
                    }

                    i++;
                }

                // 放入背包
                addItemError = bagComponent.OnAddItemData(putInBag, string.Empty, $"{ItemGetWay.ChouKa}_{TimeHelper.ServerNow()}");
                if (addItemError)
                {
                    // 放入抽卡仓库
                    addItemError = bagComponent.OnAddItemData(putInChouKa, string.Empty, $"{ItemGetWay.ChouKa}_{TimeHelper.ServerNow()}",
                        UseLocType: ItemLocType.ChouKaWarehouse);
                }
                else
                {
                    Log.Error($"addItemError == false0 {bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag)}:{bagComponent.GetChouKaLeftSpace()}");
                }
            }
            else
            {
                addItemError = bagComponent.OnAddItemData(droplist, string.Empty, $"{ItemGetWay.ChouKa}_{TimeHelper.ServerNow()}");
            }

            if (addItemError == false)
            {
                for (int i = 0; i < droplist.Count; i++)
                {
                    Log.Error($"addItemError == false1 {droplist[i].ItemID}:{droplist[i].ItemNum}");
                }
                Log.Error($"addItemError == false2 {bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag)}:{bagComponent.GetChouKaLeftSpace()}");
            }

            unit.GetComponent<NumericComponentS>().ApplyChange( NumericType.ChouKa, request.ChouKaType);
            if (mianfei)
            {
                unit.GetComponent<NumericComponentS>().ApplyValue(request.ChouKaType == 1 ? NumericType.ChouKaOneTime : NumericType.ChouKaTenTime, TimeHelper.ServerNow());
            }
            else
            {
                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Diamond, (needZuanshi * -1).ToString(), true, ItemGetWay.ChouKa);
            }
            if (request.ChouKaType == 10)
            {
                unit.GetComponent<ChengJiuComponentS>().OnChouKaTen();
            }
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.ChouKa_1016, 0, request.ChouKaType);
            unit.GetComponent<DataCollationComponent>().OnChouKa(request.ChouKaType);
            response.RewardList = droplist;
            await ETTask.CompletedTask;
        }
    }
}
