using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_StallBuyHandler: MessageLocationHandler<Unit, C2M_StallBuyRequest, M2C_StallBuyResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_StallBuyRequest request, M2C_StallBuyResponse response)
        {
            //背包是否有位置
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            PaiMaiItemInfo paiMaiItemInfo = request.PaiMaiItemInfo;
            if (request.PaiMaiItemInfo == null || request.PaiMaiItemInfo.BagInfo == null)
            {
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID);
            int cell = (int)math.ceil(paiMaiItemInfo.BagInfo.ItemNum * 1f / itemConfig.ItemPileSum);
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < cell)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            long needGold = (long)paiMaiItemInfo.Price * paiMaiItemInfo.BagInfo.ItemNum;
            if (paiMaiItemInfo.BagInfo.ItemNum < 0 || needGold < 0)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            //钱是否足够
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Gold < needGold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Buy, unit.Id))
            {
                ActorId paimaiServerId = UnitCacheHelper.GetPaiMaiServerId(unit.Zone());
                M2P_StallBuyRequest M2P_StallBuyRequest = M2P_StallBuyRequest.Create();
                M2P_StallBuyRequest.PaiMaiItemInfo = request.PaiMaiItemInfo;
                M2P_StallBuyRequest.ActorId = unit.GetComponent<UserInfoComponentS>().UserInfo.Gold;
                P2M_StallBuyResponse p2MStallBuyResponse = (P2M_StallBuyResponse)await unit.Root().GetComponent<MessageSender>().Call(paimaiServerId,M2P_StallBuyRequest);
                if (p2MStallBuyResponse.Error != ErrorCode.ERR_Success)
                {
                    response.Error = p2MStallBuyResponse.Error;
                    return;
                }

                needGold = (long)p2MStallBuyResponse.PaiMaiItemInfo.Price * p2MStallBuyResponse.PaiMaiItemInfo.BagInfo.ItemNum;

                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Gold, (needGold * -1).ToString(), true, ItemGetWay.StallBuy);
                //背包添加道具
                unit.GetComponent<BagComponentS>()
                        .OnAddItemData(p2MStallBuyResponse.PaiMaiItemInfo.BagInfo, $"{ItemGetWay.StallBuy}_{TimeHelper.ServerNow()}");

                //给出售者邮件发送金币
                ///MailHelp.SendPaiMaiEmail(unit.Root(), p2MStallBuyResponse.PaiMaiItemInfo, p2MStallBuyResponse.PaiMaiItemInfo.BagInfo.ItemNum, unit.Id);

                Log.Warning(
                    $"摆摊购买: {unit.Id} 购买 {p2MStallBuyResponse.PaiMaiItemInfo.UserId} 道具ID：{p2MStallBuyResponse.PaiMaiItemInfo.BagInfo.ItemNum} 花费：{needGold} ");
            }
            
            await ETTask.CompletedTask;
        }
    }
}