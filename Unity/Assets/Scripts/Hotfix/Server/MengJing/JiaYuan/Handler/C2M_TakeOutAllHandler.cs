using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TakeOutAllHandler: MessageLocationHandler<Unit, C2M_TakeOutAllRequest, M2C_TakeOutAllResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TakeOutAllRequest request, M2C_TakeOutAllResponse response)
        {
            int hourseId = request.HorseId;
            int leftBagSpace = unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag);
            if (leftBagSpace <= 0)
            {
                response.Error = ErrorCode.ERR_BagIsFull; //错误码:仓库已满
                return;
            }

            List<ItemInfo> storeLists = new List<ItemInfo>();
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            
            storeLists.AddRange(unit.GetComponent<BagComponentS>().GetItemByLoc(hourseId));

            for (int i = 0; i < storeLists.Count; i++)
            {
                unit.GetComponent<BagComponentS>().OnChangeItemLoc(storeLists[i], ItemLocType.ItemLocBag, hourseId);
                m2c_bagUpdate.BagInfoUpdate.Add(storeLists[i].ToMessage());
                leftBagSpace--;
                if (leftBagSpace <= 0)
                {
                    break;
                }
            }

            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            await ETTask.CompletedTask;
        }
    }
}