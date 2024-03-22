
using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponent_S))]
    public class C2M_JingLingCatchHandler : MessageLocationHandler<Unit, C2M_JingLingCatchRequest, M2C_JingLingCatchResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JingLingCatchRequest request, M2C_JingLingCatchResponse response)
        {

            Unit zhupuUnit = unit.GetParent<UnitComponent>().Get(request.JingLingId);
            if (zhupuUnit == null)
            {
                return;
            }

            if (unit.GetComponent<BagComponent_S>().GetBagLeftCell() < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            if (request.ItemId != 0)
            {
                bool costresult =  unit.GetComponent<BagComponent_S>().OnCostItemData($"{request.ItemId};1");
                if (costresult == false)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
            }

            int gailv = ComHelp.GetZhuPuGaiLv(zhupuUnit.ConfigId, request.ItemId, int.Parse(request.OperateType));
            if (RandomHelper.RandFloat01() <= gailv * 0.0001f)
            {
                response.Message = String.Empty;
                int skinId = zhupuUnit.GetComponent<NumericComponent_S>().GetAsInt(NumericType.PetSkin);

                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(zhupuUnit.ConfigId);
                int getItemid = monsterConfig.Parameter[1];
                unit.GetComponent<BagComponent_S>().OnAddItemData($"{getItemid};1",$"{ItemGetWay.PickItem}_{TimeHelper.ServerNow()}");

                List<BagInfo> bagInfolist = unit.GetComponent<BagComponent_S>().GetIdItemList(getItemid);
                if (bagInfolist.Count > 0)
                {
                    bagInfolist[bagInfolist.Count - 1].ItemPar = skinId.ToString();
                }
            }
            else
            {
                response.Error = ErrorCode.ERR_ZhuaBuFail;
            }

            unit.GetParent<UnitComponent>().Remove(request.JingLingId);
            await ETTask.CompletedTask;
        }
    }
}