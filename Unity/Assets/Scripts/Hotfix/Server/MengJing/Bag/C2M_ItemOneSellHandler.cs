using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemOneSellHandler: MessageLocationHandler<Unit, C2M_ItemOneSellRequest, M2C_ItemOneSellResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOneSellRequest request, M2C_ItemOneSellResponse response)
        {
            M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();

            for (int i = 0; i < request.BagInfoIds.Count; i++)
            {
                BagInfo useBagInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc((ItemLocType)request.OperateType, request.BagInfoIds[i]);
                if (useBagInfo == null)
                {
                    continue;
                }
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

                //Ĭ�ϳ���ȫ��
                //�����Ӧ��һ���ҽ���
                string[] gemids = useBagInfo.GemIDNew.Split('_');
                List<int> gemIdList = new List<int>();
                for (int gem = 0; gem < gemids.Length; gem++)
                {
                    if (gemids[gem] == "0")
                    {
                        continue;
                    }
                    gemIdList.Add(int.Parse(gemids[gem]));
                    ItemConfig itemConf = ItemConfigCategory.Instance.Get(int.Parse(gemids[gem]));
                    unit.GetComponent<UserInfoComponentServer>().UpdateRoleData((int)itemConf.SellMoneyType, (itemConf.SellMoneyValue).ToString());
                }

                //�䱦���Լ۸�����
                int sellValue = itemConfig.SellMoneyValue;
                if (useBagInfo.HideSkillLists.Contains(68000102))
                {
                    sellValue = itemConfig.SellMoneyValue * 20;
                }

                unit.GetComponent<UserInfoComponentServer>().UpdateRoleMoneyAdd((int)itemConfig.SellMoneyType, (useBagInfo.ItemNum * sellValue).ToString(), true, 39);
                unit.GetComponent<BagComponentServer    >().OnCostItemData(useBagInfo, (ItemLocType)request.OperateType, useBagInfo.ItemNum);

                if (useBagInfo.ItemNum == 0)
                {
                    m2c_bagUpdate.BagInfoDelete.Add(useBagInfo);
                }
                else
                {
                    m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo);
                }
            }
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            await ETTask.CompletedTask;
        }
    }
}