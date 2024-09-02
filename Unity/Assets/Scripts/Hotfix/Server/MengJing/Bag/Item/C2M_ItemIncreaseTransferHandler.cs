using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemIncreaseTransferHandler: MessageLocationHandler<Unit, C2M_ItemIncreaseTransferRequest, M2C_ItemIncreaseTransferResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemIncreaseTransferRequest request, M2C_ItemIncreaseTransferResponse response)
        {
            ItemInfo bagInfo_1 = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID_1);
            ItemInfo bagInfo_2 = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID_2);
            if (bagInfo_1 == null || bagInfo_2 == null)
            {
                return;
            }

            //判断品质
            ItemConfig itemConfig_0 = ItemConfigCategory.Instance.Get(bagInfo_1.ItemID);
            ItemConfig itemConfig_1 = ItemConfigCategory.Instance.Get(bagInfo_2.ItemID);

            if (itemConfig_0.EquipType == 101 || itemConfig_0.EquipType == 201)
            {
                response.Error = ErrorCode.ERR_ItemUseError;
                return;
            }

            if (itemConfig_1.EquipType == 101 || itemConfig_1.EquipType == 201)
            {
                response.Error = ErrorCode.ERR_ItemUseError;
                return;
            }

            //绑定装备无法转移(客户端已经给出对应提示)
            if (bagInfo_1.isBinging == true && bagInfo_2.isBinging == false && itemConfig_1.ItemQuality == 4)
            {
                bagInfo_2.isBinging = true;
            }

            //紫色品质以上才可以转移
            if (itemConfig_0.ItemQuality < 4 || itemConfig_1.ItemQuality < 4)
            {
                return;
            }

            //相同部位  只有护甲类型相同的装备才能转移
            if (itemConfig_0.EquipType != 99 && itemConfig_1.EquipType != 99)
            {
                //相同部位
                if (itemConfig_0.EquipType != itemConfig_1.EquipType)
                {
                    return;
                }
            }

            if (itemConfig_0.EquipType != 99 && itemConfig_1.EquipType != 99)
            {
                //相同部位  只有相同部位的装备才能转移
                if (itemConfig_0.ItemSubType != itemConfig_1.ItemSubType)
                {
                    return;
                }
            }

            string costItem = GlobalValueConfigCategory.Instance.Get(51).Value;
            if (!unit.GetComponent<BagComponentS   >().OnCostItemData(costItem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            List<HideProList> canTransfHideProLists = new List<HideProList>();
            List<int> canTransfSkillLists = new List<int>();
            // 从物品A获取能传承的属性，并移出
            for (int i = bagInfo_1.IncreaseProLists.Count - 1; i >= 0; i--)
            {
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(bagInfo_1.IncreaseProLists[i].HideID);
                if (hideProListConfig.IfMove == 1)
                {
                    canTransfHideProLists.Add(bagInfo_1.IncreaseProLists[i]);
                    bagInfo_1.IncreaseProLists.RemoveAt(i);
                }
            }
            // 从物品A获取能传承的技能，并移出
            for (int i = bagInfo_1.IncreaseSkillLists.Count - 1; i >= 0; i--)
            {
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(bagInfo_1.IncreaseSkillLists[i]);
                if (hideProListConfig.IfMove == 1)
                {
                    canTransfSkillLists.Add(bagInfo_1.IncreaseSkillLists[i]);
                    bagInfo_1.IncreaseSkillLists.RemoveAt(i);
                }
            }

            // 判断是否需要转移
            if (canTransfHideProLists.Count > 0 || canTransfSkillLists.Count > 0)
            {
                // 从物品B中移除拥有的传承属性，并加入新的传承属性
                for (int i = bagInfo_2.IncreaseProLists.Count - 1; i >= 0; i--)
                {
                    HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(bagInfo_2.IncreaseProLists[i].HideID);
                    if (hideProListConfig.IfMove == 1)
                    {
                        bagInfo_2.IncreaseProLists.RemoveAt(i);
                    }
                }
                bagInfo_2.IncreaseProLists.AddRange(canTransfHideProLists);

                // 从物品B中移除拥有的传承技能，并加入新的传承技能
                for (int i = bagInfo_2.IncreaseSkillLists.Count - 1; i >= 0; i--)
                {
                    HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(bagInfo_2.IncreaseSkillLists[i]);
                    if (hideProListConfig.IfMove == 1)
                    {
                        bagInfo_2.IncreaseSkillLists.RemoveAt(i);
                    }
                }
                bagInfo_2.IncreaseSkillLists.AddRange(canTransfSkillLists);
            }

            bagInfo_1.isBinging = true;
            bagInfo_2.isBinging = true;
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.IncreaseNumber_46, 0, 1);

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            //通知客户端背包道具发生改变
            m2c_bagUpdate.BagInfoUpdate = new List<ItemInfoProto>();
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfo_1.ToMessage());
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfo_2.ToMessage());
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            await ETTask.CompletedTask;
        }
    }
}