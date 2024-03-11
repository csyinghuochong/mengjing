using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemMeltingHandler: MessageLocationHandler<Unit, C2M_ItemMeltingRequest, M2C_ItemMeltingResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemMeltingRequest request, M2C_ItemMeltingResponse response)
        {//ͨ�������б��������
            int getItemId = ComHelp.MeltingItemId;
            int getNumber = 1;


            //���ݲ�ͬ��רҵ����������ͬ�ĵ���
            switch (request.MakeType)
            {

                //����
                case 1:
                    getItemId = 10000144;
                    break;

                //�÷�
                case 2:
                    getItemId = 10000145;
                    break;

                //����
                case 3:
                    getItemId = 10000146;
                    break;

                //��ħ
                case 6:
                    getItemId = 10000147;
                    break;

            }

            List<long> huishouIdList = request.OperateBagID;
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            int minNum = 0;
            int minMax = 0;

            for (int i = 0; i < huishouIdList.Count; i++)
            {
                BagInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, huishouIdList[i]);
                if (bagInfo == null)
                {
                    Log.Info("C2M_ItemMelting��Ч����ƷID: " + huishouIdList[i]);
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

            //�۳�װ��
            bagComponent.OnCostItemData(huishouIdList);

            bagComponent.OnAddItemData($"{getItemId};{getNumber}", $"{ItemGetWay.Melting}_{TimeHelper.ServerNow()}");
            await ETTask.CompletedTask;
        }
    }
}