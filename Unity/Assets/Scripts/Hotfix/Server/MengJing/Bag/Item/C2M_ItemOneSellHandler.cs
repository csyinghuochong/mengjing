using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemOneSellHandler: MessageLocationHandler<Unit, C2M_ItemOneSellRequest, M2C_ItemOneSellResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOneSellRequest request, M2C_ItemOneSellResponse response)
        {
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            for (int i = 0; i < request.BagInfoIds.Count; i++)
            {
                ItemInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(request.OperateType, request.BagInfoIds[i]);
                if (useBagInfo == null)
                {
                    continue;
                }
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

                //默认出售全部
                //给与对应金币或货币奖励
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
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleData((int)itemConf.SellMoneyType, (itemConf.SellMoneyValue).ToString());
                }

                //珍宝属性价格提升
                int sellValue = itemConfig.SellMoneyValue;
                if (useBagInfo.HideSkillLists.Contains(68000102))
                {
                    sellValue = itemConfig.SellMoneyValue * 20;
                }

                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd((int)itemConfig.SellMoneyType, (useBagInfo.ItemNum * sellValue).ToString(), true, 39);
                unit.GetComponent<BagComponentS    >().OnCostItemData(useBagInfo, request.OperateType, useBagInfo.ItemNum);

                if (useBagInfo.ItemNum == 0)
                {
                    m2c_bagUpdate.BagInfoDelete.Add(useBagInfo.ToMessage());
                }
                else
                {
                    m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
                }
            }
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            await ETTask.CompletedTask;
        }
    }
}