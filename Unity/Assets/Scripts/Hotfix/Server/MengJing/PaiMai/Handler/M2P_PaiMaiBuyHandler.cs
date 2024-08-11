using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.PaiMai)]
    public class M2P_PaiMaiBuyHandler : MessageHandler<Scene, M2P_PaiMaiBuyRequest, P2M_PaiMaiBuyResponse>
    {

        protected override async ETTask Run(Scene scene, M2P_PaiMaiBuyRequest request, P2M_PaiMaiBuyResponse response)
        {
            //获取列表,对应的缓存进行清空
            if (!ItemConfigCategory.Instance.Contain(request.PaiMaiItemInfo.BagInfo.ItemID))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            ItemConfig itemCof = ItemConfigCategory.Instance.Get(request.PaiMaiItemInfo.BagInfo.ItemID);
            int itemType = itemCof.ItemType;
            DBPaiMainInfo dBPaiMainInfo = scene.GetComponent<PaiMaiSceneComponent>().GetPaiMaiDBByType(itemType);
            if (dBPaiMainInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            long needGold = 0;
            PaiMaiItemInfo paiMaiItemInfo = null;
            List<PaiMaiItemInfo> paiMaiItemInfos = dBPaiMainInfo.PaiMaiItemInfos;
            for (int i = paiMaiItemInfos.Count - 1; i >= 0; i--)
            {
                if (paiMaiItemInfos[i].Id == request.PaiMaiItemInfo.Id)
                {
                    paiMaiItemInfo = paiMaiItemInfos[i];
                    break;
                }
            }

            if (paiMaiItemInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            if (request.BuyNum < 0 || request.BuyNum > paiMaiItemInfo.BagInfo.ItemNum)
            {
                response.Error = ErrorCode.ERR_Parameter;
                return;
            }

            needGold = (long)paiMaiItemInfo.Price * request.BuyNum;
            if (request.Gold < needGold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            BagInfo bagInfo = paiMaiItemInfo.BagInfo;
            if (request.BuyNum == bagInfo.ItemNum)
            {
                response.PaiMaiItemInfo = paiMaiItemInfo;
                paiMaiItemInfos.Remove(paiMaiItemInfo);
            }
            else
            {
                bagInfo.ItemNum -= request.BuyNum;
                PaiMaiItemInfo paiMaiItemInfo2 = PaiMaiItemInfo.Create();

                BagInfo useBagInfo = BagInfo.Create();
                useBagInfo.ItemID = bagInfo.ItemID;
                useBagInfo.ItemNum = request.BuyNum;
                useBagInfo.Loc = itemCof.ItemType == (int)ItemTypeEnum.PetHeXin ? (int)ItemLocType.ItemPetHeXinBag : (int)ItemLocType.ItemLocBag;
                useBagInfo.BagInfoID = IdGenerater.Instance.GenerateId();
                useBagInfo.GemHole = ConfigData.DefaultGem;
                useBagInfo.GemIDNew = ConfigData.DefaultGem;
                useBagInfo.GetWay = bagInfo.GetWay;
                useBagInfo.isBinging = bagInfo.isBinging;

                paiMaiItemInfo2.Id = IdGenerater.Instance.GenerateId();
                paiMaiItemInfo2.BagInfo = useBagInfo;
                paiMaiItemInfo2.UserId = paiMaiItemInfo.UserId;
                paiMaiItemInfo2.Price = paiMaiItemInfo.Price;
                paiMaiItemInfo2.PlayerName = paiMaiItemInfo.PlayerName;
                paiMaiItemInfo2.SellTime = paiMaiItemInfo.SellTime;

                response.PaiMaiItemInfo = paiMaiItemInfo2;
            }


            if (request.UnitId != request.PaiMaiItemInfo.UserId)
            {
                long locationactor = request.PaiMaiItemInfo.UserId;

                P2M_PaiMaiBuyInfoRequest r2M_RechargeRequest = P2M_PaiMaiBuyInfoRequest.Create();
                r2M_RechargeRequest.PlayerId = request.UnitId;
                r2M_RechargeRequest.CostGold = (long)(needGold * 0.95f);
                M2P_PaiMaiBuyInfoResponse m2G_RechargeResponse = (M2P_PaiMaiBuyInfoResponse)await scene.Root()
                        .GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(locationactor, r2M_RechargeRequest);

                if (m2G_RechargeResponse.Error != ErrorCode.ERR_Success)
                {
                    DataCollationComponent dataCollationComponent =
                            await UnitCacheHelper.GetComponentCache<DataCollationComponent>(scene.Root(),
                                locationactor);
                    if (dataCollationComponent != null)
                    {
                        dataCollationComponent.UpdateBuySelfPlayerList((long)(needGold * 0.95f), request.UnitId, false);
                        UnitCacheHelper.SaveComponentCache(scene.Root(), dataCollationComponent).Coroutine();
                    }

                    NumericComponentS numericComponent = await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), locationactor);
                    if (numericComponent != null)
                    {
                        long paimaigold = numericComponent.GetAsLong(NumericType.PaiMaiTodayGold) + (long)(needGold * 0.95f);
                        numericComponent.ApplyValue(NumericType.PaiMaiTodayGold, paimaigold, false);
                        UnitCacheHelper.SaveComponentCache(scene.Root(), numericComponent).Coroutine();
                    }
                }

                await ETTask.CompletedTask;
            }
        }
    }
}