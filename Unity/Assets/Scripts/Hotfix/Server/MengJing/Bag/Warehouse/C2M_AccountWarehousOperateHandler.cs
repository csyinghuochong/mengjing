using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_AccountWarehousOperateHandler: MessageLocationHandler<Unit, C2M_AccountWarehousOperateRequest, M2C_AccountWarehousOperateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_AccountWarehousOperateRequest request, M2C_AccountWarehousOperateResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Buy, unit.Id))
            {
                long accountId = unit.GetComponent<UserInfoComponentS>().UserInfo.AccInfoID;
                DBAccountBagInfo dBAccountWarehouse = await UnitCacheHelper.GetComponent<DBAccountBagInfo>(unit.Root(), accountId);
                
                if(dBAccountWarehouse == null)
                {
                    response.Error = ErrorCode.ERR_NetWorkError;
                    return;
                }

                BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
                switch (request.OperatateType)
                {
                    ///1放入仓库  2取出仓库 3整理仓库 
                    case 1:
                        if (dBAccountWarehouse.BagInfoList.Count >= GlobalValueConfigCategory.Instance.AccountBagMax)
                        {
                            response.Error = ErrorCode.ERR_WarehouseIsFull;
                            return;
                        }

                        ItemInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID);
                        if (bagInfo == null)
                        {
                            response.Error = ErrorCode.ERR_ItemNotExist;
                            return;
                        }

                        if (bagInfo.isBinging || ItemHelper.GetGemIdList(bagInfo).Count > 0)
                        {
                            response.Error = ErrorCode.ERR_ItemUseError;
                            return;
                        }

                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                        if (itemConfig.ItemType != 3 || itemConfig.EquipType > 100)
                        {
                            response.Error = ErrorCode.ERR_ItemNotExist;
                            return;
                        }

                        if (dBAccountWarehouse.HaveItemById(bagInfo.BagInfoID) != -1)
                        {
                            response.Error = ErrorCode.ERR_AlreadyHave;
                            return;
                        }

                        dBAccountWarehouse.BagInfoList.Add(bagInfo);
                        bagComponent.OnCostItemData(new List<long>() { bagInfo.BagInfoID }, ItemLocType.ItemLocBag);
                        break;
                    case 2:
                        if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        int index = dBAccountWarehouse.HaveItemById(request.OperateBagID);
                        if (index == -1)
                        {
                            response.Error = ErrorCode.ERR_ItemNotExist;
                            return;
                        }

                        bagInfo = dBAccountWarehouse.BagInfoList[index];
                        dBAccountWarehouse.BagInfoList.RemoveAt(index);
                        bagComponent.OnAddItemData(bagInfo, bagInfo.GetWay);
                        break;
                    case 3:
                        ItemHelper.ItemLitSort(dBAccountWarehouse.BagInfoList);
                        break;
                    default:
                        break;
                }

                UnitCacheHelper.SaveComponentCache(unit.Root(),  bagComponent).Coroutine();
                UnitCacheHelper.SaveComponent(unit.Root(), accountId, dBAccountWarehouse).Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}