namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_MysteryBuyHandler : MessageLocationHandler<Unit, C2M_MysteryBuyRequest, M2C_MysteryBuyResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_MysteryBuyRequest request, M2C_MysteryBuyResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Buy, unit.Id))
            {
                int mysteryId = request.MysteryItemInfo.MysteryId;
                if (!MysteryConfigCategory.Instance.Contain(mysteryId))
                {
                    Log.Error($"C2M_MysteryBuyRequest 1");
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
                if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                if (!unit.GetComponent<BagComponentS>().CheckCostItem($"{mysteryConfig.SellType};{mysteryConfig.SellValue}"))
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }

                ActorId chargeServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "Activity").ActorId;
                request.MysteryItemInfo.ItemID = mysteryConfig.SellItemID;
                request.MysteryItemInfo.ItemNumber = 1;

                M2A_MysteryBuyRequest M2A_MysteryBuyRequest = M2A_MysteryBuyRequest.Create();
                M2A_MysteryBuyRequest.MysteryItemInfo = request.MysteryItemInfo;
                A2M_MysteryBuyResponse r_GameStatusResponse = (A2M_MysteryBuyResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (chargeServerId, M2A_MysteryBuyRequest);

                if (r_GameStatusResponse.Error != ErrorCode.ERR_Success)
                {
                    response.Error = r_GameStatusResponse.Error;
                    return;
                }

                ServerLogHelper.LogWarning($"神秘商人购买道具: {unit.Zone()} {unit.Id} {mysteryId}");
                unit.GetComponent<UserInfoComponentS>().OnMysteryBuy(mysteryId);
                unit.GetComponent<BagComponentS>().OnCostItemData($"{mysteryConfig.SellType};{mysteryConfig.SellValue}");
                unit.GetComponent<BagComponentS>().OnAddItemData($"{mysteryConfig.SellItemID};{1}",
                    $"{ItemGetWay.MysteryBuy}_{TimeHelper.ServerNow()}");
            }
        }
    }
}
