using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemIncreaseTransferHandler: MessageLocationHandler<Unit, C2M_ItemIncreaseTransferRequest, M2C_ItemIncreaseTransferResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemIncreaseTransferRequest request, M2C_ItemIncreaseTransferResponse response)
        {
            BagInfo bagInfo_1 = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID_1);
            BagInfo bagInfo_2 = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID_2);
            if (bagInfo_1 == null || bagInfo_2 == null)
            {
                return;
            }

            //�ж�Ʒ��
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

            //��װ���޷�ת��(�ͻ����Ѿ�������Ӧ��ʾ)
            if (bagInfo_1.isBinging == true && bagInfo_2.isBinging == false && itemConfig_1.ItemQuality == 4)
            {
                bagInfo_2.isBinging = true;
            }

            //��ɫƷ�����ϲſ���ת��
            if (itemConfig_0.ItemQuality < 4 || itemConfig_1.ItemQuality < 4)
            {
                return;
            }

            //��ͬ��λ  ֻ�л���������ͬ��װ������ת��
            if (itemConfig_0.EquipType != 99 && itemConfig_1.EquipType != 99)
            {
                //��ͬ��λ
                if (itemConfig_0.EquipType != itemConfig_1.EquipType)
                {
                    return;
                }
            }

            if (itemConfig_0.EquipType != 99 && itemConfig_1.EquipType != 99)
            {
                //��ͬ��λ  ֻ����ͬ��λ��װ������ת��
                if (itemConfig_0.ItemSubType != itemConfig_1.ItemSubType)
                {
                    return;
                }
            }

            string costItem = GlobalValueConfigCategory.Instance.Get(51).Value;
            if (!unit.GetComponent<BagComponentServer   >().OnCostItemData(costItem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            List<HideProList> canTransfHideProLists = new List<HideProList>();
            List<int> canTransfSkillLists = new List<int>();
            // ����ƷA��ȡ�ܴ��е����ԣ����Ƴ�
            for (int i = bagInfo_1.IncreaseProLists.Count - 1; i >= 0; i--)
            {
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(bagInfo_1.IncreaseProLists[i].HideID);
                if (hideProListConfig.IfMove == 1)
                {
                    canTransfHideProLists.Add(bagInfo_1.IncreaseProLists[i]);
                    bagInfo_1.IncreaseProLists.RemoveAt(i);
                }
            }
            // ����ƷA��ȡ�ܴ��еļ��ܣ����Ƴ�
            for (int i = bagInfo_1.IncreaseSkillLists.Count - 1; i >= 0; i--)
            {
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(bagInfo_1.IncreaseSkillLists[i]);
                if (hideProListConfig.IfMove == 1)
                {
                    canTransfSkillLists.Add(bagInfo_1.IncreaseSkillLists[i]);
                    bagInfo_1.IncreaseSkillLists.RemoveAt(i);
                }
            }

            // �ж��Ƿ���Ҫת��
            if (canTransfHideProLists.Count > 0 || canTransfSkillLists.Count > 0)
            {
                // ����ƷB���Ƴ�ӵ�еĴ������ԣ��������µĴ�������
                for (int i = bagInfo_2.IncreaseProLists.Count - 1; i >= 0; i--)
                {
                    HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(bagInfo_2.IncreaseProLists[i].HideID);
                    if (hideProListConfig.IfMove == 1)
                    {
                        bagInfo_2.IncreaseProLists.RemoveAt(i);
                    }
                }
                bagInfo_2.IncreaseProLists.AddRange(canTransfHideProLists);

                // ����ƷB���Ƴ�ӵ�еĴ��м��ܣ��������µĴ��м���
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
            unit.GetComponent<TaskComponentServer>().TriggerTaskEvent(TaskTargetType.IncreaseNumber_46, 0, 1);
            unit.GetComponent<TaskComponentServer>().TriggerTaskCountryEvent(TaskTargetType.IncreaseNumber_46, 0, 1);

            M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();
            //֪ͨ�ͻ��˱������߷����ı�
            m2c_bagUpdate.BagInfoUpdate = new List<BagInfo>();
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfo_1);
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfo_2);
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            await ETTask.CompletedTask;
        }
    }
}