using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPurchaseHandler : MessageLocationHandler<Unit, C2M_JiaYuanPurchaseRequest, M2C_JiaYuanPurchaseResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPurchaseRequest request, M2C_JiaYuanPurchaseResponse response )
        {
            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            List<JiaYuanPurchaseItem> purchaselist = jiaYuanComponent.PurchaseItemList_7;
            JiaYuanPurchaseItem jiaYuanPurchaseItem = null;
            long serverTime = TimeHelper.ServerNow();
            for (int i = purchaselist.Count - 1; i >= 0; i--)
            {
                if (purchaselist[i].PurchaseId == request.PurchaseId)
                {
                    jiaYuanPurchaseItem = purchaselist[i];
                    purchaselist.RemoveAt(i);
                    break;
                }
                if (purchaselist[i].EndTime < serverTime)
                {
                    purchaselist.RemoveAt(i);
                }
            }
            if (jiaYuanPurchaseItem == null)
            {
                response.Error = ErrorCode.ERR_NetWorkError;
                return;
            }
            if (unit.GetComponent<BagComponentS>().GetItemNumber(request.ItemId) < 1)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.JiaYuanFund, jiaYuanPurchaseItem.BuyZiJin.ToString());
            unit.GetComponent<BagComponentS>().OnCostItemData($"{request.ItemId};1");
            response.PurchaseItemList .AddRange(jiaYuanComponent.PurchaseItemList_7); 
            UnitCacheHelper.SaveComponentCache( unit.Root(), jiaYuanComponent).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
