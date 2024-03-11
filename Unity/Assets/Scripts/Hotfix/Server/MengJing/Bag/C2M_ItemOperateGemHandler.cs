using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemOperateGemHandler: MessageLocationHandler<Unit, C2M_ItemOperateGemRequest, M2C_ItemOperateGemResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateGemRequest request, M2C_ItemOperateGemResponse response)
        {
            long bagInfoID = request.OperateBagID;
            BagInfo useBagInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoID);
            if (useBagInfo == null)
            {
                useBagInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemLocEquip, bagInfoID);
            }
            if (useBagInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemUseError;
                return;
            }

            // ֪ͨ�ͻ��˱���ˢ��
            M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();
            //֪ͨ�ͻ��˱������߷����ı�
            m2c_bagUpdate.BagInfoUpdate = new List<BagInfo>();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

            //��Ƕ��ʯ
            if (request.OperateType == 9)
            {
                //��ʯ��Ƕ
                string[] geminfos = request.OperatePar.Split('_');
                long equipid = long.Parse(geminfos[0]);
                int gemIndex = int.Parse(geminfos[1]);

                BagInfo equipInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemLocEquip, equipid);

                //��ȡװ��baginfo
                if (equipInfo == null)
                {
                    equipInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemLocBag, equipid);
                }
                if (equipInfo == null)
                {
                    Log.Warning($"equipInfo == null {equipid}");
                    return;
                }

                //�жϿ�λ�Ƿ����
                string[] equipGeminfos = equipInfo.GemHole.Split('_');

                if (equipGeminfos[gemIndex] != itemConfig.ItemSubType.ToString() && itemConfig.ItemSubType != 110 && itemConfig.ItemSubType != 111)
                {
                    response.Error = ErrorCode.ERR_ItemUseError;
                    return;
                }

                //ʷʫ��ʯ�����Ƕ4��
                if (itemConfig.ItemSubType == 110)
                {
                    int equipShiShiGemNum = 0;
                    bool isTihuan = false;
                    List<BagInfo> EquipList = unit.GetComponent<BagComponentServer>().EquipList;
                    for (int i = 0; i < EquipList.Count; i++)
                    {
                        string[] gemList = EquipList[i].GemIDNew.Split('_');
                        for (int y = 0; y < gemList.Length; y++)
                        {
                            if (ComHelp.IfNull(gemList[y]) == false)
                            {
                                ItemConfig gemItemCof = ItemConfigCategory.Instance.Get(int.Parse(gemList[y]));
                                if (gemItemCof.ItemSubType == 110)
                                {
                                    equipShiShiGemNum += 1;
                                }
                            }
                            if (EquipList[i].BagInfoID == equipid && gemIndex == y)
                            {
                                isTihuan = true;
                                break;
                            }
                        }
                    }

                    if (!isTihuan && equipShiShiGemNum >= 4)
                    {
                        response.Error = ErrorCode.ERR_GemShiShiNumFull;
                        return;
                    }
                }


                string[] gemIdList = equipInfo.GemIDNew.Split('_');
                gemIdList[gemIndex] = useBagInfo.ItemID.ToString();
                string gemIDNew = "";
                for (int i = 0; i < gemIdList.Length; i++)
                {
                    gemIDNew = gemIDNew + gemIdList[i] + "_";
                }
                equipInfo.GemIDNew = gemIDNew.Substring(0, gemIDNew.Length - 1);
                equipInfo.isBinging = true;
                m2c_bagUpdate.BagInfoUpdate.Add(equipInfo);
                //���ı�ʯ
                unit.GetComponent<BagComponentServer>().OnCostItemData(useBagInfo.BagInfoID, 1);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            }

            //ж�±�ʯ
            if (request.OperateType == 10)
            {
                if (unit.GetComponent<BagComponentServer>().GetBagLeftCell() < 1)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                int gemIndex = int.Parse(request.OperatePar);
                string[] gemIdList = useBagInfo.GemIDNew.Split('_');
                int gemItemId = int.Parse(gemIdList[gemIndex]);

                //����110�Ĳ���ж
                if (!ItemConfigCategory.Instance.Contain(gemItemId))
                {
                    response.Error = ErrorCode.ERR_GemNoError;
                    return;
                }
                ItemConfig gemItemConfig = ItemConfigCategory.Instance.Get(gemItemId);
                if (gemItemConfig.ItemSubType == 110)
                {
                    response.Error = ErrorCode.ERR_GemNoError;
                    return;
                }

                gemIdList[gemIndex] = "0";
                string gemIDNew = "";
                for (int i = 0; i < gemIdList.Length; i++)
                {
                    gemIDNew = gemIDNew + gemIdList[i] + "_";
                }
                useBagInfo.GemIDNew = gemIDNew.Substring(0, gemIDNew.Length - 1);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo);

                //���ձ�ʯ
                if (gemItemId != 0)
                {
                    unit.GetComponent<BagComponentServer    >().OnAddItemData($"{gemItemId};1", $"{ItemGetWay.GemHuiShou}_{TimeHelper.ServerNow()}");
                    Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                }
            }
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            await ETTask.CompletedTask;
        }
    }
}