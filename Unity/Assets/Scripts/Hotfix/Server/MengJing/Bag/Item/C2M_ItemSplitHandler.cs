using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemSplitHandler: MessageLocationHandler<Unit, C2M_ItemSplitRequest, M2C_ItemSplitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemSplitRequest request, M2C_ItemSplitResponse response)
        {
            long bagInfoID = request.OperateBagID;
            ItemInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoID);
            if (useBagInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemUseError;
                return;
            }

            long splitNumber = 0;
            try
            {
                splitNumber = long.Parse(request.OperatePar);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (splitNumber <= 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (splitNumber >= useBagInfo.ItemNum)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (splitNumber >= 100000)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            useBagInfo.ItemNum -= (int)splitNumber;
            if (useBagInfo.ItemNum <= 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            unit.GetComponent<BagComponentS>().OnAddItemDataNewCell(useBagInfo, (int)splitNumber);
            Log.Warning($"道具拆分 {unit.Zone()} {unit.Id} {splitNumber}");

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            await ETTask.CompletedTask;
        }
    }
}