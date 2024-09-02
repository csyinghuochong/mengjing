using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemMeltingHandler: MessageLocationHandler<Unit, C2M_ItemMeltingRequest, M2C_ItemMeltingResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemMeltingRequest request, M2C_ItemMeltingResponse response)
        {//通过回收列表计算所得
            int getItemId = CommonHelp.MeltingItemId;
            int getNumber = 1;


            //根据不同的专业技能熔炼不同的道具
            switch (request.MakeType)
            {

                //锻造
                case 1:
                    getItemId = 10000144;
                    break;

                //裁缝
                case 2:
                    getItemId = 10000145;
                    break;

                //炼金
                case 3:
                    getItemId = 10000146;
                    break;

                //附魔
                case 6:
                    getItemId = 10000147;
                    break;

            }

            List<long> huishouIdList = request.OperateBagID;
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            int minNum = 0;
            int minMax = 0;

            for (int i = 0; i < huishouIdList.Count; i++)
            {
                ItemInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, huishouIdList[i]);
                if (bagInfo == null)
                {
                    Log.Info("C2M_ItemMelting无效的物品ID: " + huishouIdList[i]);
                    continue;
                }

                //to do
                minNum = 0;
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (itemCof.ItemQuality >= 4)
                {

                    if (itemCof.UseLv >= 1 && itemCof.UseLv < 20)
                    {
                        minNum = 1;
                        minMax = 3;

                    }
                    else if (itemCof.UseLv >= 20)
                    {

                        minNum = 1;
                        minMax = 4;

                    }
                    else if (itemCof.UseLv >= 30)
                    {

                        minNum = 2;
                        minMax = 4;
                    }
                    else if (itemCof.UseLv >= 40)
                    {
                        minNum = 2;
                        minMax = 5;
                    }
                    else if (itemCof.UseLv >= 50)
                    {
                        minNum = 3;
                        minMax = 5;
                    }
                }

                getNumber += RandomHelper.NextInt(minNum, minMax);
            }

            //扣除装备
            bagComponent.OnCostItemData(huishouIdList);

            bagComponent.OnAddItemData($"{getItemId};{getNumber}", $"{ItemGetWay.Melting}_{TimeHelper.ServerNow()}");
            await ETTask.CompletedTask;
        }
    }
}