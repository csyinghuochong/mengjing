namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionMysteryBuyHandler : MessageLocationHandler<Unit, C2M_UnionMysteryBuyRequest, M2C_UnionMysteryBuyResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_UnionMysteryBuyRequest request, M2C_UnionMysteryBuyResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Buy, unit.Id))
            {
                long unionid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
                if (unionid == 0)
                {
                    response.Error = ErrorCode.ERR_NetWorkError;
                    return;
                }

                int mysteryId = request.MysteryId;
                if (!MysteryConfigCategory.Instance.Contain(mysteryId))
                {
                    Log.Error($"C2M_UnionMysteryBuyRequest 1");
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryId);
                if (mysteryConfig == null)
                {
                    response.Error = ErrorCode.ERR_NetWorkError;
                    return;
                }
                if (unit.GetComponent<UserInfoComponentS>().GetMysteryBuy(mysteryId) >= mysteryConfig.BuyNumMax)
                {
                    response.Error = ErrorCode.ERR_MysteryItem_Max;
                    return;
                }
                if (!unit.GetComponent<BagComponentS>().CheckCostItem($"{mysteryConfig.SellType};{mysteryConfig.SellValue}"))
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
                request.BuyNumber = 1;
                ActorId unionServerId = UnitCacheHelper.GetUnionServerId(unit.Zone());
                M2U_UnionMysteryBuyRequest M2U_UnionMysteryBuyRequest = M2U_UnionMysteryBuyRequest.Create();
                M2U_UnionMysteryBuyRequest.MysteryId = mysteryId;
                M2U_UnionMysteryBuyRequest.BuyNumber = request.BuyNumber;
                M2U_UnionMysteryBuyRequest.UnionId = unionid;
                U2M_UnionMysteryBuyResponse r_GameStatusResponse = (U2M_UnionMysteryBuyResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (unionServerId, M2U_UnionMysteryBuyRequest);

                if (r_GameStatusResponse.Error != ErrorCode.ERR_Success)
                {
                    response.Error = r_GameStatusResponse.Error;
                    return;
                }

                Log.Warning($"公会神秘商人购买道具: {unit.Zone()} {unit.Id} {mysteryId}");
                unit.GetComponent<UserInfoComponentS>().OnMysteryBuy(mysteryId);
                unit.GetComponent<BagComponentS>().OnCostItemData($"{mysteryConfig.SellType};{mysteryConfig.SellValue}");
                unit.GetComponent<BagComponentS>().OnAddItemData($"{mysteryConfig.SellItemID};{1}",
                    $"{ItemGetWay.UnionMysteryBuy}_{TimeHelper.ServerNow()}");
            }
        }
    }
}
