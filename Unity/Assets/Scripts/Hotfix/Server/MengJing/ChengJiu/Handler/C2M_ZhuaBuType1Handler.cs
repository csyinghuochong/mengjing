using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponentS))]
    public class C2M_ZhuaBuType1Handler : MessageLocationHandler<Unit, C2M_ZhuaBuType1Request, M2C_ZhuaBuType1Response>
    {
        protected override async ETTask Run(Unit unit, C2M_ZhuaBuType1Request request, M2C_ZhuaBuType1Response response)
        {
            Unit zhupuUnit = unit.GetParent<UnitComponent>().Get(request.JingLingId);
            if (zhupuUnit == null)
            {
                return;
            }

            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            if (request.ItemId != 0)
            {
                bool costresult =  unit.GetComponent<BagComponentS>().OnCostItemData($"{request.ItemId};1");
                if (costresult == false)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
            }

            int gailv = CommonHelp.GetZhuPuType1_GaiLv(zhupuUnit.ConfigId, request.ItemId, int.Parse(request.OperateType));
            if (RandomHelper.RandFloat01() <= gailv * 0.0001f)
            {
                response.Message = String.Empty;
                int skinId = zhupuUnit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetSkin);

                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(zhupuUnit.ConfigId);
                int getItemid = monsterConfig.Parameter[1];
                unit.GetComponent<BagComponentS>().OnAddItemData($"{getItemid};1",$"{ItemGetWay.PickItem}_{TimeHelper.ServerNow()}");

                List<ItemInfo> bagInfolist = unit.GetComponent<BagComponentS>().GetIdItemList(getItemid);
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