using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_JingHeZhuruRequestHandler : MessageLocationHandler<Unit, C2M_JingHeZhuruRequest, M2C_JingHeZhuruResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JingHeZhuruRequest request, M2C_JingHeZhuruResponse response)
        {
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();

            ItemInfo bagInfoJinHe = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.BagInfoId);
            if (bagInfoJinHe == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            List<long> huishouList = request.OperateBagID;
            List<long> bagsList = new List<long>();
            List<int> qulitylist = new List<int> { };
            for (int i = 0; i < huishouList.Count; i++)
            {
                ItemInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, huishouList[i]);
                if (bagInfo == null)
                {
                    continue;
                }

                bagsList.Add(huishouList[i]);
                if (!string.IsNullOrEmpty(bagInfo.ItemPar))
                {
                    qulitylist.Add(int.Parse(bagInfo.ItemPar));
                }
            }

            int oldqulity = 0;
            if (!string.IsNullOrEmpty(bagInfoJinHe.ItemPar))
            {
                oldqulity = int.Parse(bagInfoJinHe.ItemPar);
            }
            List<int> valuerange = ItemHelper.GetJingHeAddQulity(qulitylist);
            int addqulity = RandomHelper.RandomNumber(valuerange[0], valuerange[1] + 1);
            oldqulity += addqulity;
            //做个限制
            if (oldqulity > 100)
            {
                oldqulity = 100;
            }

            bagInfoJinHe.ItemPar = oldqulity.ToString();
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfoJinHe.ToMessage());
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            bagComponent.OnCostItemData(bagsList, ItemLocType.ItemLocBag);
            await ETTask.CompletedTask;
        }
    }
}
