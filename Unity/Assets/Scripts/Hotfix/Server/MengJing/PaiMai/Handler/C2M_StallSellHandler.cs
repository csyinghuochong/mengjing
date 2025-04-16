namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_StallSellHandler: MessageLocationHandler<Unit, C2M_StallSellRequest, M2C_StallSellResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_StallSellRequest request, M2C_StallSellResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Sell, unit.Id))
            {
                if (request.PaiMaiItemInfo.BagInfo.ItemNum <= 0)
                {
                    return;
                }

                //获取出售数据
                long paimaiItemId = IdGenerater.Instance.GenerateId();
                request.PaiMaiItemInfo.Id = paimaiItemId;

                request.PaiMaiItemInfo.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                request.PaiMaiItemInfo.UserId = unit.GetComponent<UserInfoComponentS>().UserInfo.UserId;

                //获取时间戳
                long currentTime = TimeHelper.ServerNow();
                request.PaiMaiItemInfo.SellTime = currentTime;

                //对比出售数量和道具是否匹配
                long bagInfoId = request.PaiMaiItemInfo.BagInfo.BagInfoID;
                ItemInfo bagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoId);
                if (bagInfo == null)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError; //道具不足
                    return;
                }

                if (bagInfo.ItemNum < request.PaiMaiItemInfo.BagInfo.ItemNum)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError; //道具不足
                    return;
                }

                //判断道具是否可以上架和绑定
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (itemConfig.IfStopPaiMai == 1)
                {
                    response.Error = ErrorCode.Err_StopPaiMai; //道具无法上架
                    return;
                }

                if (bagInfo.isBinging)
                {
                    response.Error = ErrorCode.ERR_ItemBing; //道具绑定
                    return;
                }

                long gold = (long)request.PaiMaiItemInfo.BagInfo.ItemNum * request.PaiMaiItemInfo.Price;
                if (gold < 0)
                {
                    return;
                }

                //发送对应拍卖行信息
                ActorId paimaiServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "PaiMai").ActorId;
                M2P_StallSellRequest M2P_StallSellRequest = M2P_StallSellRequest.Create();
                M2P_StallSellRequest.PaiMaiItemInfo = request.PaiMaiItemInfo;
                P2M_StallSellResponse p2MStallSellResponse =
                        (P2M_StallSellResponse)await unit.Root().GetComponent<MessageSender>().Call(paimaiServerId,M2P_StallSellRequest);

                if (p2MStallSellResponse.Error == ErrorCode.ERR_Success)
                {
                    //扣除对应道具
                    unit.GetComponent<BagComponentS>()
                            .OnCostItemData(request.PaiMaiItemInfo.BagInfo.BagInfoID, request.PaiMaiItemInfo.BagInfo.ItemNum);
                    // unit.GetComponent<TaskComponent>().TriggerTaskCountryEvent(TaskTargetType.PaiMaiSell_1015, 0, 1); // 触发对应任务
                    response.PaiMaiItemInfo = request.PaiMaiItemInfo;
                    ServerLogHelper.LogWarning(response.PaiMaiItemInfo.PlayerName + "上架摆摊道具：" + request.PaiMaiItemInfo.BagInfo.ItemID + "数量" +
                        request.PaiMaiItemInfo.BagInfo.ItemNum + "时间戳:" + currentTime.ToString(), true);
                }

                response.Error = p2MStallSellResponse.Error;
                await ETTask.CompletedTask;
            }
        }
    }
}